#region Libraries 
using System;
#endregion

namespace LTSefpBL.Model
{
    /// <summary>
    /// Тип заработка.
    /// </summary>
    [Serializable]
    public class IncomeType
    {
        public int Id { get; set; }

        /// <summary>
        /// Тип.
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Создать новый тип.
        /// </summary>
        /// <param name="type">Имя типа.</param>

        public IncomeType() { }
        public IncomeType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentNullException(" Эта строка не может быть пустой", nameof(type));
            }
            else if(type.Length > 7)
            {
                throw new ArgumentNullException(" Эта строка не может быть такой длинной. Или вы любите змей?", nameof(type));
            }
            Type = type;
            
        }
        public override string ToString()
        {
            return Type;
        }
    }
}
