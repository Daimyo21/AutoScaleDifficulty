using System;
using System.Reflection;


namespace AutoScaleDifficulty
{
    public static class AT
    {
        private static readonly BindingFlags _flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;

        public static void SetValue<T>(T value, Type type, object obj, string field)
        {
            FieldInfo _fieldInfo = type.GetField(field, _flags);
            if (_fieldInfo != null)
            {
                _fieldInfo.SetValue(obj, value);
            }
        }

        public static object GetValue(Type type, object obj, string value)
        {
            FieldInfo _fieldInfo = type.GetField(value, _flags);
            if (_fieldInfo != null)
            {
                return _fieldInfo.GetValue(obj);
            }
            else
            {
                return null;
            }
        }

        public static UID GetTagUid(string tagName)
        {
            foreach (Tag _tag in (Tag[])GetValue(typeof(TagSourceManager), TagSourceManager.Instance, "m_tags"))
            {
                if (_tag.TagName.Equals(tagName))
                {
                    return _tag.UID;
                }
            }
            return null;
        }

        public static float GetCharacterStat(CharacterStats stats, string field)
        {
            Stat _stat = (Stat)GetValue(typeof(CharacterStats), stats, field);
            return _stat.CurrentValue;
        }

        public static float GetPlayerStat(PlayerCharacterStats stats, string field)
        {
            Stat _stat = (Stat)GetValue(typeof(PlayerCharacterStats), stats, field);
            return _stat.CurrentValue;
        }
    }
}
