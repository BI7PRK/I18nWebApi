using AspNetCore.Grpc.LocalizerStore;

namespace I18nWebApi
{
    public class TestLocalizerResources: ILocalizerResourceKeys
    {
        /// <summary>
        /// Token为空
        /// </summary>
        [LocalizerDefault("Token为空")]
        public const string AUTHOR_TOKEN_EMPTY = "author_token_empty";
        /// <summary>
        /// Token无效
        /// </summary>
        [LocalizerDefault("Token无效")]
        public const string AUTHOR_TOKEN_INVALID = "author_token_invalid";
        /// <summary>
        /// Token过期
        /// </summary>
        [LocalizerDefault("Token过期")]
        public const string AUTHOR_TOKEN_EXPIRE = "author_token_expire";
        /// <summary>
        /// 没有权限
        /// </summary>
        [LocalizerDefault("没有权限")]
        public const string AUTHOR_NO_PERMISSION = "author_no_permission";

        /// <summary>
        /// 帐号已锁定
        /// </summary>
        [LocalizerDefault("帐号已锁定，请{0}分钟后再重试")]
        public const string LOGIN_USER_LOCK_TIME = "login_user_lock_time";

        /// <summary>
        /// 还有{0}机会
        /// </summary>
        [LocalizerDefault("，还有{0}尝试机会")]
        public static string LOGIN_USER_TRY_COUNT = "login_user_try_count";

    }
}
