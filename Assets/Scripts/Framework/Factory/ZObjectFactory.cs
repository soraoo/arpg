using Framework.Common;

namespace Framework.Factory
{
    /// <summary>
    /// ZObject对象工厂
    /// </summary>
    public static class ZObjectFactory
    {
        public static ZObject Create()
        {
            return ZObjectPool.Create();
        }

        public static void Delete(ZObject obj)
        {
            ZObjectPool.Delete(obj);
        }
    }
}