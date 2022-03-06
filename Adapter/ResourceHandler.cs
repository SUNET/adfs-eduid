// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ADFSTK.ExternalMFA.Common.Domain;
using ADFSTK.ExternalMFA.Resources;

namespace ADFSTK.ExternalMFA
{
    internal static class ResourceHandler
    {
        public static string GetResource(string resourceName, int lcid)
        {
            if (lcid != Constants.Lcid.En && lcid != Constants.Lcid.Sv)
            {
                lcid = Constants.Lcid.Sv;
            }
            LangText text = (from tt in texts.Where(t => t.Key == resourceName && t.Lcid == lcid) select tt).SingleOrDefault();
            if (text == null)
            {
                throw new ArgumentNullException();

            }
            return text.Value;
            //if (String.IsNullOrEmpty(resourceName))
            //{
            //    throw new ArgumentNullException("resourceName");
            //}

            //return StringResources.ResourceManager.GetString(resourceName, new CultureInfo(lcid));
        }

        public static string GetPresentationResource(string resourceName, int lcid)
        {
            if (String.IsNullOrEmpty(resourceName))
            {
                throw new ArgumentNullException("resourceName");
            }
            return PresentationResources.ResourceManager.GetString(resourceName, new CultureInfo(lcid));
        }
        private static List<LangText> texts =
            new List<LangText>()
            {
                //en
                new LangText(){Key="AdminFriendlyName",Lcid=9,Value="External Idp in Tab (RefedsMFA)"},
                new LangText(){Key="AuthenticationFailed",Lcid=9,Value="AuthenticationFailed"},
                new LangText(){Key="Description",Lcid=9,Value="External Idp in Tab (Refeds)"},
                new LangText(){Key="ErrorFailSelected",Lcid=9,Value="ErrorFailSelected"},
                new LangText(){Key="ErrorInvalidContext",Lcid=9,Value="ErrorInvalidContext"},
                new LangText(){Key="ErrorInvalidSessionId",Lcid=9,Value="ErrorInvalidSessionId"},
                new LangText(){Key="ErrorNoAnswerProvided",Lcid=9,Value="ErrorNoAnswerProvided"},
                new LangText(){Key="ErrorNoUserIdentity",Lcid=9,Value="ErrorNoUserIdentity"},
                new LangText(){Key="FailedLogin",Lcid=9,Value="Login with External Idp failed, and try again."},
                new LangText(){Key="FinishButtonLabel",Lcid=9,Value="Finish login"},
                new LangText(){Key="PageIntroductionText",Lcid=9,Value=""},
                new LangText(){Key="PageIntroductionTitle",Lcid=9,Value="Enter your password"},
                new LangText(){Key="PageTitle",Lcid=9,Value="PageTitle"},
                new LangText(){Key="SubmitButtonLabel",Lcid=9,Value="Sign in with EduID MFA"},
                new LangText(){Key="TabInfoText",Lcid=9,Value="Opens in a new tab! Allow new tabs to open from this location (and reload the page)"},
                //sv
                new LangText(){Key="AdminFriendlyName",Lcid=29,Value="Extern Idp i en ny Tab (RefedsMFA)"},
                new LangText(){Key="AuthenticationFailed",Lcid=29,Value="AuthenticationFailed"},
                new LangText(){Key="Description",Lcid=29,Value="Extern Idp i en ny Tab (RefedsMFA)"},
                new LangText(){Key="ErrorFailSelected",Lcid=29,Value="ErrorFailSelected"},
                new LangText(){Key="ErrorInvalidContext",Lcid=29,Value="ErrorInvalidContext"},
                new LangText(){Key="ErrorInvalidSessionId",Lcid=29,Value="ErrorInvalidSessionId"},
                new LangText(){Key="ErrorNoAnswerProvided",Lcid=29,Value="ErrorNoAnswerProvided"},
                new LangText(){Key="ErrorNoUserIdentity",Lcid=29,Value="ErrorNoUserIdentity"},
                new LangText(){Key="FailedLogin",Lcid=29,Value="Inloggningen med Extern Idp misslyckades, försök igen"},
                new LangText(){Key="FinishButtonLabel",Lcid=29,Value="Slutför inloggningen med EduID MFA"},
                new LangText(){Key="PageIntroductionText",Lcid=29,Value=""},
                new LangText(){Key="PageIntroductionTitle",Lcid=29,Value="Skriv in ditt lösenord"},
                new LangText(){Key="PageTitle",Lcid=29,Value="PageTitle"},
                new LangText(){Key="SubmitButtonLabel",Lcid=29,Value="Logga in med EduID MFA"},
                new LangText(){Key="TabInfoText",Lcid=29,Value="Öppnas i en ny flik! Tillåt att nya flikar öppnas från denna plats (och ladda om sidan)"},
            };
    }
}
