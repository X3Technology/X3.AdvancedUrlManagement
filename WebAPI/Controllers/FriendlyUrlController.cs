using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Controllers;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Urls;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.Api;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace X3.AdvancedUrlManagement
{
    //[SupportedModules("X3.AdvancedUrlManagement")]
    public class FriendlyUrlController : DnnApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetHostSettings()
        {
            try
            {
                DotNetNuke.Entities.Urls.FriendlyUrlSettings fs = new DotNetNuke.Entities.Urls.FriendlyUrlSettings(-1);

                WebAPI.Models.FriendlyUrlSettings dto = new WebAPI.Models.FriendlyUrlSettings()
                {
                    auto_ascii_convert = fs.AutoAsciiConvert,
                    check_for_duplicate_urls = fs.CheckForDuplicateUrls,
                    deleted_tab_handling = fs.DeletedTabHandlingType.ToString(),
                    do_not_include_in_path_regex = fs.DoNotIncludeInPathRegex,
                    do_not_redirect_regex = fs.DoNotRedirectRegex,
                    do_not_redirect_secure_regex = fs.DoNotRedirectSecureRegex,
                    do_not_rewrite_regex = fs.DoNotRewriteRegex,
                    enable_custom_providers = fs.EnableCustomProviders,
                    force_lower_case = fs.ForceLowerCase,
                    force_lower_case_regex = fs.ForceLowerCaseRegex,
                    ignore_regex = fs.IgnoreRegex,
                    log_cache_messages = fs.LogCacheMessages,
                    no_friendly_url_regex = fs.NoFriendlyUrlRegex,
                    page_extension = fs.PageExtension,
                    page_extension_usage = fs.PageExtensionUsageType.ToString(),
                    redirect_old_profile_url = fs.RedirectOldProfileUrl,
                    redirect_unfriendly = fs.RedirectUnfriendly,
                    redirect_wrong_case = fs.RedirectWrongCase,
                    regex_match = fs.RegexMatch,
                    replace_chars = fs.ReplaceChars,
                    replace_space_with = fs.ReplaceSpaceWith,
                    ssl_client_redirect = fs.SSLClientRedirect,
                    url_format = fs.UrlFormat,
                    use_site_urls_regex = fs.UseSiteUrlsRegex,
                    valid_extensionless_urls_regex = fs.ValidExtensionlessUrlsRegex
                };

                // replace_char_with_char 
                foreach (var key in fs.ReplaceCharacterDictionary.Keys)
                {
                    dto.replace_char_with_char += key + "," + fs.ReplaceCharacterDictionary[key] + ";";
                }

                return Request.CreateResponse(HttpStatusCode.OK, dto);
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage SaveHostSettings(WebAPI.Models.FriendlyUrlSettings dto)
        {
            try
            {
                // AUM_AutoAsciiConvert
                HostController.Instance.Update(FriendlyUrlSettings.AutoAsciiConvertSetting, dto.auto_ascii_convert.ToString(), true);

                // AUM_CheckForDuplicatedUrls 
                HostController.Instance.Update(FriendlyUrlSettings.CheckForDuplicatedUrlsSetting, dto.check_for_duplicate_urls.ToString(), true);

                // AUM_DeletedTabHandlingType
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.DeletedTabHandlingTypeSetting, dto.deleted_tab_handling, true);

                // AUM_KeepInQueryStringRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.KeepInQueryStringRegexSetting, dto.do_not_include_in_path_regex, true);

                // AUM_DoNotRedirectUrlRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.DoNotRedirectUrlRegexSetting, dto.do_not_redirect_regex, true);

                // AUM_DoNotRedirectHttpsUrlRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.DoNotRedirectHttpsUrlRegexSetting, dto.do_not_redirect_secure_regex, true);

                // AUM_DoNotRewriteRegEx
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.DoNotRewriteRegExSetting, dto.do_not_rewrite_regex, true);

                // AUM_EnableCustomProviders
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.EnableCustomProvidersSetting, dto.enable_custom_providers.ToString(), true);

                // AUM_ForceLowerCase
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.ForceLowerCaseSetting, dto.force_lower_case.ToString(), true);

                // AUM_PreventLowerCaseUrlRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.PreventLowerCaseUrlRegexSetting, dto.force_lower_case_regex, true);

                // AUM_IgnoreUrlRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.IgnoreRegexSetting, dto.ignore_regex, true);

                // AUM_LogCacheMessages
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.LogCacheMessagesSetting, dto.log_cache_messages.ToString(), true);

                // AUM_DoNotUseFriendlyUrlRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.DoNotUseFriendlyUrlRegexSetting, dto.no_friendly_url_regex, true);

                // AUM_PageExtension                
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.PageExtensionSetting, dto.page_extension, true);

                // AUM_PageExtensionUsage
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.PageExtensionUsageSetting, dto.page_extension_usage, true);

                // AUM_RedirectOldProfileUrl
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.RedirectOldProfileUrlSetting, dto.redirect_old_profile_url.ToString(), true);

                // AUM_RedirectUnfriendly
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.RedirectUnfriendlySetting, dto.redirect_unfriendly.ToString(), true);

                // AUM_RedirectMixedCase
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.RedirectMixedCaseSetting, dto.redirect_wrong_case.ToString(), true);

                // AUM_ValidFriendlyUrlRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.ValidFriendlyUrlRegexSetting, dto.regex_match, true);

                // AUM_ReplaceChars                
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.ReplaceCharsSetting, dto.replace_chars, true);

                // AUM_ReplaceCharWithChar                         
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.ReplaceCharWithCharSetting, dto.replace_char_with_char, true);

                // AUM_ReplaceSpaceWith
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.ReplaceSpaceWithSetting, dto.replace_space_with, true);

                // AUM_SSLClientRedirect
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.SslClientRedirectSetting, dto.ssl_client_redirect.ToString(), true);

                // AUM_UrlFormat
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.UrlFormatSetting, dto.url_format, true);

                // AUM_SiteUrlsOnlyRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.SiteUrlsOnlyRegexSetting, dto.use_site_urls_regex, true);

                // AUM_UrlsWithNoExtensionRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.UrlsWithNoExtensionRegexSetting, dto.valid_extensionless_urls_regex, true);

                CacheController.FlushFriendlyUrlSettingsFromCache();
                CacheController.FlushPageIndexFromCache();

                Config.Touch();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage ClearHostSettings()
        {
            try
            {
                // AUM_AutoAsciiConvert
                HostController.Instance.Update(FriendlyUrlSettings.AutoAsciiConvertSetting, string.Empty, true);

                // AUM_CheckForDuplicatedUrls 
                HostController.Instance.Update(FriendlyUrlSettings.CheckForDuplicatedUrlsSetting, string.Empty, true);

                // AUM_DeletedTabHandlingType
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.DeletedTabHandlingTypeSetting, string.Empty, true);

                // AUM_KeepInQueryStringRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.KeepInQueryStringRegexSetting, string.Empty, true);

                // AUM_DoNotRedirectUrlRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.DoNotRedirectUrlRegexSetting, string.Empty, true);

                // AUM_DoNotRedirectHttpsUrlRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.DoNotRedirectHttpsUrlRegexSetting, string.Empty, true);

                // AUM_DoNotRewriteRegEx
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.DoNotRewriteRegExSetting, string.Empty, true);

                // AUM_EnableCustomProviders
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.EnableCustomProvidersSetting, string.Empty, true);

                // AUM_ForceLowerCase
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.ForceLowerCaseSetting, string.Empty, true);

                // AUM_PreventLowerCaseUrlRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.PreventLowerCaseUrlRegexSetting, string.Empty, true);

                // AUM_IgnoreUrlRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.IgnoreRegexSetting, string.Empty, true);

                // AUM_LogCacheMessages
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.LogCacheMessagesSetting, string.Empty, true);

                // AUM_DoNotUseFriendlyUrlRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.DoNotUseFriendlyUrlRegexSetting, string.Empty, true);

                // AUM_PageExtension                
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.PageExtensionSetting, string.Empty, true);

                // AUM_PageExtensionUsage
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.PageExtensionUsageSetting, string.Empty, true);

                // AUM_RedirectOldProfileUrl
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.RedirectOldProfileUrlSetting, string.Empty, true);

                // AUM_RedirectUnfriendly
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.RedirectUnfriendlySetting, string.Empty, true);

                // AUM_RedirectMixedCase
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.RedirectMixedCaseSetting, string.Empty, true);

                // AUM_ValidFriendlyUrlRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.ValidFriendlyUrlRegexSetting, string.Empty, true);

                // AUM_ReplaceChars                
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.ReplaceCharsSetting, string.Empty, true);

                // AUM_ReplaceCharWithChar                         
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.ReplaceCharWithCharSetting, string.Empty, true);

                // AUM_ReplaceSpaceWith
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.ReplaceSpaceWithSetting, string.Empty, true);

                // AUM_SSLClientRedirect
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.SslClientRedirectSetting, string.Empty, true);

                // AUM_UrlFormat
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.UrlFormatSetting, string.Empty, true);

                // AUM_SiteUrlsOnlyRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.SiteUrlsOnlyRegexSetting, string.Empty, true);

                // AUM_UrlsWithNoExtensionRegex
                HostController.Instance.Update(DotNetNuke.Entities.Urls.FriendlyUrlSettings.UrlsWithNoExtensionRegexSetting, string.Empty, true);


                CacheController.FlushFriendlyUrlSettingsFromCache();
                CacheController.FlushPageIndexFromCache();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetPortalSettings()
        {
            try
            {
                int portal_id = this.PortalSettings.PortalId;

                DotNetNuke.Entities.Urls.FriendlyUrlSettings fs = new DotNetNuke.Entities.Urls.FriendlyUrlSettings(portal_id);

                WebAPI.Models.FriendlyUrlSettings dto = new WebAPI.Models.FriendlyUrlSettings()
                {
                    auto_ascii_convert = fs.AutoAsciiConvert,
                    check_for_duplicate_urls = fs.CheckForDuplicateUrls,
                    deleted_tab_handling = fs.DeletedTabHandlingType.ToString(),
                    do_not_include_in_path_regex = fs.DoNotIncludeInPathRegex,
                    do_not_redirect_regex = fs.DoNotRedirectRegex,
                    do_not_redirect_secure_regex = fs.DoNotRedirectSecureRegex,
                    do_not_rewrite_regex = fs.DoNotRewriteRegex,
                    enable_custom_providers = fs.EnableCustomProviders,
                    force_lower_case = fs.ForceLowerCase,
                    force_lower_case_regex = fs.ForceLowerCaseRegex,
                    ignore_regex = fs.IgnoreRegex,
                    log_cache_messages = fs.LogCacheMessages,
                    no_friendly_url_regex = fs.NoFriendlyUrlRegex,
                    page_extension = fs.PageExtension,
                    page_extension_usage = fs.PageExtensionUsageType.ToString(),
                    redirect_old_profile_url = fs.RedirectOldProfileUrl,
                    redirect_unfriendly = fs.RedirectUnfriendly,
                    redirect_wrong_case = fs.RedirectWrongCase,
                    regex_match = fs.RegexMatch,
                    replace_chars = fs.ReplaceChars,
                    replace_space_with = fs.ReplaceSpaceWith,
                    ssl_client_redirect = fs.SSLClientRedirect,
                    url_format = fs.UrlFormat,
                    use_site_urls_regex = fs.UseSiteUrlsRegex,
                    valid_extensionless_urls_regex = fs.ValidExtensionlessUrlsRegex
                };

                // replace_char_with_char 
                foreach (var key in fs.ReplaceCharacterDictionary.Keys)
                {
                    dto.replace_char_with_char += key + "," + fs.ReplaceCharacterDictionary[key] + ";";
                }

                return Request.CreateResponse(HttpStatusCode.OK, dto);
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage SavePortalSettings(WebAPI.Models.FriendlyUrlSettings dto)
        {
            try
            {
                int portal_id = this.PortalSettings.PortalId;

                // AUM_AutoAsciiConvert
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.AutoAsciiConvertSetting, dto.auto_ascii_convert.ToString(), true);

                // AUM_CheckForDuplicatedUrls 
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.CheckForDuplicatedUrlsSetting, dto.check_for_duplicate_urls.ToString(), true);

                // AUM_DeletedTabHandlingType
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.DeletedTabHandlingTypeSetting, dto.deleted_tab_handling, true);

                // AUM_KeepInQueryStringRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.KeepInQueryStringRegexSetting, dto.do_not_include_in_path_regex, true);

                // AUM_DoNotRedirectUrlRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.DoNotRedirectUrlRegexSetting, dto.do_not_redirect_regex, true);

                // AUM_DoNotRedirectHttpsUrlRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.DoNotRedirectHttpsUrlRegexSetting, dto.do_not_redirect_secure_regex, true);

                // AUM_DoNotRewriteRegEx
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.DoNotRewriteRegExSetting, dto.do_not_rewrite_regex, true);

                // AUM_EnableCustomProviders
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.EnableCustomProvidersSetting, dto.enable_custom_providers.ToString(), true);

                // AUM_ForceLowerCase
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.ForceLowerCaseSetting, dto.force_lower_case.ToString(), true);

                // AUM_PreventLowerCaseUrlRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.PreventLowerCaseUrlRegexSetting, dto.force_lower_case_regex, true);

                // AUM_IgnoreUrlRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.IgnoreRegexSetting, dto.ignore_regex, true);

                // AUM_LogCacheMessages
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.LogCacheMessagesSetting, dto.log_cache_messages.ToString(), true);

                // AUM_DoNotUseFriendlyUrlRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.DoNotUseFriendlyUrlRegexSetting, dto.no_friendly_url_regex, true);

                // AUM_PageExtension                
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.PageExtensionSetting, dto.page_extension, true);

                // AUM_PageExtensionUsage
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.PageExtensionUsageSetting, dto.page_extension_usage, true);

                // AUM_RedirectOldProfileUrl
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.RedirectOldProfileUrlSetting, dto.redirect_old_profile_url.ToString(), true);

                // AUM_RedirectUnfriendly
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.RedirectUnfriendlySetting, dto.redirect_unfriendly.ToString(), true);

                // AUM_RedirectMixedCase
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.RedirectMixedCaseSetting, dto.redirect_wrong_case.ToString(), true);

                // AUM_ValidFriendlyUrlRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.ValidFriendlyUrlRegexSetting, dto.regex_match, true);

                // AUM_ReplaceChars                
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.ReplaceCharsSetting, dto.replace_chars, true);

                // AUM_ReplaceCharWithChar                         
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.ReplaceCharWithCharSetting, dto.replace_char_with_char, true);

                // AUM_ReplaceSpaceWith
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.ReplaceSpaceWithSetting, dto.replace_space_with, true);

                // AUM_SSLClientRedirect
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.SslClientRedirectSetting, dto.ssl_client_redirect.ToString(), true);

                // AUM_UrlFormat
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.UrlFormatSetting, dto.url_format, true);

                // AUM_SiteUrlsOnlyRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.SiteUrlsOnlyRegexSetting, dto.use_site_urls_regex, true);

                // AUM_UrlsWithNoExtensionRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.UrlsWithNoExtensionRegexSetting, dto.valid_extensionless_urls_regex, true);

                CacheController.FlushFriendlyUrlSettingsFromCache();
                CacheController.FlushPageIndexFromCache();

                Config.Touch();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage ClearPortalSettings()
        {
            try
            {
                int portal_id = this.PortalSettings.PortalId;

                // AUM_AutoAsciiConvert                
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.AutoAsciiConvertSetting, string.Empty, true);

                // AUM_CheckForDuplicatedUrls 
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.CheckForDuplicatedUrlsSetting, string.Empty, true);

                // AUM_DeletedTabHandlingType
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.DeletedTabHandlingTypeSetting, string.Empty, true);

                // AUM_KeepInQueryStringRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.KeepInQueryStringRegexSetting, string.Empty, true);

                // AUM_DoNotRedirectUrlRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.DoNotRedirectUrlRegexSetting, string.Empty, true);

                // AUM_DoNotRedirectHttpsUrlRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.DoNotRedirectHttpsUrlRegexSetting, string.Empty, true);

                // AUM_DoNotRewriteRegEx
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.DoNotRewriteRegExSetting, string.Empty, true);

                // AUM_EnableCustomProviders
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.EnableCustomProvidersSetting, string.Empty, true);

                // AUM_ForceLowerCase
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.ForceLowerCaseSetting, string.Empty, true);

                // AUM_PreventLowerCaseUrlRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.PreventLowerCaseUrlRegexSetting, string.Empty, true);

                // AUM_IgnoreUrlRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.IgnoreRegexSetting, string.Empty, true);

                // AUM_LogCacheMessages
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.LogCacheMessagesSetting, string.Empty, true);

                // AUM_DoNotUseFriendlyUrlRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.DoNotUseFriendlyUrlRegexSetting, string.Empty, true);

                // AUM_PageExtension                
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.PageExtensionSetting, string.Empty, true);

                // AUM_PageExtensionUsage
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.PageExtensionUsageSetting, string.Empty, true);

                // AUM_RedirectOldProfileUrl
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.RedirectOldProfileUrlSetting, string.Empty, true);

                // AUM_RedirectUnfriendly
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.RedirectUnfriendlySetting, string.Empty, true);

                // AUM_RedirectMixedCase
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.RedirectMixedCaseSetting, string.Empty, true);

                // AUM_ValidFriendlyUrlRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.ValidFriendlyUrlRegexSetting, string.Empty, true);

                // AUM_ReplaceChars                
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.ReplaceCharsSetting, string.Empty, true);

                // AUM_ReplaceCharWithChar                         
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.ReplaceCharWithCharSetting, string.Empty, true);

                // AUM_ReplaceSpaceWith
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.ReplaceSpaceWithSetting, string.Empty, true);

                // AUM_SSLClientRedirect
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.SslClientRedirectSetting, string.Empty, true);

                // AUM_UrlFormat
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.UrlFormatSetting, string.Empty, true);

                // AUM_SiteUrlsOnlyRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.SiteUrlsOnlyRegexSetting, string.Empty, true);

                // AUM_UrlsWithNoExtensionRegex
                PortalController.UpdatePortalSetting(portal_id, FriendlyUrlSettings.UrlsWithNoExtensionRegexSetting, string.Empty, true);


                CacheController.FlushFriendlyUrlSettingsFromCache();
                CacheController.FlushPageIndexFromCache();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Exceptions.LogException(ex);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        
    }
}

