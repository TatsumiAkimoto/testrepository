namespace WordBookSystem.ViewModels.Word
{
    public class EditWord
    {
       
            public int WordId { get; set; }

            public string WordName { get; set; }

            public string WordMeaning { get; set; }

            public string? WordClass { get; set; }

            public string? WordExample { get; set; }

            public string? Memo { get; set; }
        }
    }
