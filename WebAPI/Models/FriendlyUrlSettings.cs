using System;
using System.Collections.Generic;

namespace X3.AdvancedUrlManagement.WebAPI.Models
{
    // this is just a POCO class is used to transmit settings value back and forth via WebAPI
    // reference to DotNetNuke.Entities.Urls.FriendlyUrlSettings

    // some of the the names of the variables stored in the HostSettings/PortalSettings table do not match the property names in the FriendlyURLSettings class, so some of these are not a 1-1 name match

    public class FriendlyUrlSettings
    {
        // AUM_DeletedTabHandlingType
        public string deleted_tab_handling { get; set; }

        // AUM_ForceLowerCase
        public bool force_lower_case { get; set; }

        // AUM_PageExtension
        public string page_extension { get; set; }

        // AUM_PageExtensionUsage
        public string page_extension_usage { get; set; }

        // AUM_RedirectOldProfileUrl 
        public bool redirect_old_profile_url { get; set; }

        // AUM_RedirectUnfriendly
        public bool redirect_unfriendly { get; set; }

        // AUM_ReplaceSpaceWith
        public string replace_space_with { get; set; }

        // AUM_UrlFormat 
        public string url_format { get; set; }

        // AUM_RedirectMixedCase
        public bool redirect_wrong_case { get; set; }

        //// AUM_SpaceEncodingValue // not implemented in DNN
        //public string space_encoding_value { get; set; }

        // AUM_AutoAsciiConvert
        public bool auto_ascii_convert { get; set; }

        // AUM_ReplaceCchars 
        public string replace_chars { get; set; }

        // AUM_CheckForDuplicatedUrls
        public bool check_for_duplicate_urls { get; set; }

        //// AUM_FriendlyAdminHostUrls // depricated in 9
        //public bool friendly_admin_host_urls { get; set; }

        // AUM_EnableCustomProviders
        public bool enable_custom_providers { get; set; }

        // AUM_ReplaceCharWithChar 
        public string replace_char_with_char { get; set; }

        // AUM_IgnoreUrlRegex
        public string ignore_regex { get; set; }

        // AUM_SiteUrlsOnlyRegex
        public string use_site_urls_regex { get; set; }

        // AUM_DoNotRedirectUrlRegex
        public string do_not_redirect_regex { get; set; }

        // AUM_DoNotRedirectHttpsUrlRegex
        public string do_not_redirect_secure_regex { get; set; }

        // AUM_PreventLowerCaseUrlRegex
        public string force_lower_case_regex { get; set; }

        // AUM_DoNotUseFriendlyUrlRegex
        public string no_friendly_url_regex { get; set; }

        // AUM_KeepInQueryStringRegex
        public string do_not_include_in_path_regex { get; set; }

        // AUM_UrlsWithNoExtensionRegex
        public string valid_extensionless_urls_regex { get; set; }

        // AUM_ValidFriendlyUrlRegex
        public string regex_match { get; set; }

        // AUM_DoNotRewriteRegEx
        public string do_not_rewrite_regex { get; set; }

        //// AUM_UsePortalDefaultLanguage // not implemented within DNN
        //public bool force_portal_default_language { get; set; }

        // AUM_AllowDebugCode -- not settable - should probably be removed

        // AUM_LogCacheMessages
        public bool log_cache_messages { get; set; }

        //// AUM_VanityUrlPrefix // not implemented within DNN
        //public string vanity_url_prefix { get; set; }

        //// AUM_RedirectDefaultPage
        //public bool redirect_default_page { get; set; }

        // AUM_SSLClientRedirect
        public bool ssl_client_redirect { get; set; }

        //// AUM_IllegalChars // not implemented
        //public string illegal_chars { get; set; }

        //// AUM_ReplaceDoubleChars // not implemented
        //public bool replace_double_chars { get; set; }

        //// AUM_Regex404 // not implemented
        //public string regex_404 { get; set; }

        //// AUM_Url404 // not implemented
        //public string url_404 { get; set; }

        // AUM_Url500 // not implemented
        //public string url_500 { get; set; }

        //// AUM_UseBaseFriendlyUrls // i think this is depricated in 9+.
        //public string use_base_friendly_urls { get; set; }

        //// AUM_InternalAliases
        //public string internal_aliases { get; set; }

        //// AUM_ProcessRequests
        //public List<string> process_requests { get; set; }

        //// AUM_CacheTime
        //public TimeSpan cache_time { get; set; }

        //// AUM_IncludePageName
        //public bool include_page_name { get; set; }
    }
}