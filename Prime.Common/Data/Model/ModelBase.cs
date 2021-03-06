using LiteDB;

namespace Prime.Common
{
    public abstract class ModelBase : IModelBase
    {
        [BsonId]
        public virtual ObjectId Id { get; set; }
    }
}