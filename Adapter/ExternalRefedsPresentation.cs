﻿
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ADFSTK.ExternalMFA.Resources;
using Microsoft.IdentityServer.Web.Authentication.External;

namespace ADFSTK.ExternalMFA
{
    internal class ExternalRefedsPresentation : IAdapterPresentationForm
    {
        private readonly ExternalAuthenticationException _ex = null;

        private readonly string _username = string.Empty;
        private readonly string _url = string.Empty;
        private readonly string _trustedUrl = string.Empty;
        private readonly Dictionary<string, string> _dynamicContents = new Dictionary<string, string>()
        {
            {Constants.DynamicContentLabels.markerUserName, String.Empty},
            {Constants.DynamicContentLabels.markerOverallError, String.Empty},
            {Constants.DynamicContentLabels.markerActionUrl, String.Empty},
            {Constants.DynamicContentLabels.markerPageIntroductionTitle, String.Empty},
            {Constants.DynamicContentLabels.markerPageIntroductionText, String.Empty},
            {Constants.DynamicContentLabels.markerPageTitle, String.Empty},
            {Constants.DynamicContentLabels.markerPageTabInfoText,String.Empty },            
        };
        public ExternalRefedsPresentation(string username, string proxyUrl,string trustedUrl)
        {
            _username = username;
            _url = proxyUrl;
            _trustedUrl = trustedUrl;
        }
        public ExternalRefedsPresentation(string username, string url, ExternalAuthenticationException ex) : this(username, url,string.Empty)
        {
            _ex = ex;
            _url = url;
        }
        /// <summary>
        /// Replace template markers with explicitly given replacements.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="replacements"></param>
        /// <returns></returns>
        private static string Replace(string input, Dictionary<string, string> replacements)
        {
            if (string.IsNullOrEmpty(input) || null == replacements)
            {
                return input;
            }

            // Use StringBuiler and allocate buffer 3 times larger
            StringBuilder sb = new StringBuilder(input, input.Length * 3);
            foreach (string key in replacements.Keys)
            {
                sb.Replace(key, replacements[key]);
            }
            return sb.ToString();
        }
        #region IAdapterPresentationForm Members
        public string GetFormHtml(int lcid)
        {
            var dynamicContents = new Dictionary<string, string>(_dynamicContents)
            {
                [Constants.DynamicContentLabels.markerPageIntroductionTitle] =
                GetPresentationResource(Constants.ResourceNames.PageIntroductionTitle, lcid),
                [Constants.DynamicContentLabels.markerPageIntroductionText] =
                GetPresentationResource(Constants.ResourceNames.PageIntroductionText, lcid),
                [Constants.DynamicContentLabels.markerPageTitle] = GetPageTitle(lcid),
                [Constants.DynamicContentLabels.markerSubmitButton] =
                GetPresentationResource(Constants.ResourceNames.SubmitButtonLabel, lcid),
                [Constants.DynamicContentLabels.markerView] = Constants.ResourceNames.ViewStart,
                [Constants.DynamicContentLabels.markerPageTabInfoText] =
                GetPresentationResource(Constants.ResourceNames.TabInfoText,lcid),
            };

            string authPageTemplate = ResourceHandler.GetPresentationResource(Constants.ResourceNames.AuthPageTab, lcid);
            if (_ex != null)
            {
                dynamicContents[Constants.DynamicContentLabels.markerPageIntroductionText] = GetPresentationResource(Constants.ResourceNames.FailedLogin, lcid);
                authPageTemplate = ResourceHandler.GetPresentationResource(Constants.ResourceNames.AuthPageError, lcid);
            }

            dynamicContents[Constants.DynamicContentLabels.markerLoginPageUsername] = _username;
            dynamicContents[Constants.DynamicContentLabels.markerLoginExternalTabUrl] = _url;
            dynamicContents[Constants.DynamicContentLabels.markerPageTrustedUrl] = _trustedUrl;

            return Replace(authPageTemplate, dynamicContents);
        }

        #endregion
        #region IAdapterPresentationIndirect Members

        public string GetFormPreRenderHtml(int lcid)
        {
            return null;
        }

        public string GetPageTitle(int lcid)
        {
            return GetPresentationResource(Constants.ResourceNames.PageTitle, lcid);
        }

        #endregion

        protected string GetPresentationResource(string resourceName, int lcid)
        {
            return ResourceHandler.GetResource(resourceName, lcid);
        }
    }
}
