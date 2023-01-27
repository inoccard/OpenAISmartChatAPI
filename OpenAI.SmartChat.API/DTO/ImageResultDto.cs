using System.Runtime.CompilerServices;
using System.Text;

namespace OpenAI.SmartChat.API.DTO
{
    public record ImageResultDto
    {
        public string? Url { get; set; }

        public string? B64 { get; set; }

        [CompilerGenerated]
        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.Append("ImageResultDto");
            stringBuilder.Append(" { ");
            if (PrintMembers(stringBuilder))
            {
                stringBuilder.Append(' ');
            }

            stringBuilder.Append('}');
            return stringBuilder.ToString();
        }

        [CompilerGenerated]
        protected virtual bool PrintMembers(StringBuilder builder)
        {
            RuntimeHelpers.EnsureSufficientExecutionStack();
            builder.Append("Url = ");
            builder.Append((object?)Url);
            builder.Append(", B64 = ");
            builder.Append((object?)B64);
            return true;
        }

        [CompilerGenerated]
        public override int GetHashCode()
        {
            return (EqualityComparer<Type>.Default.GetHashCode(EqualityContract) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Url)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(B64);
        }

        [CompilerGenerated]
        public virtual bool Equals(ImageResultDto? other)
        {
            if ((object)this != other)
            {
                if (other is not null && EqualityContract == other!.EqualityContract && EqualityComparer<string>.Default.Equals(Url, other!.Url))
                {
                    return EqualityComparer<string>.Default.Equals(B64, other!.B64);
                }

                return false;
            }

            return true;
        }

        [CompilerGenerated]
        protected ImageResultDto(ImageResultDto original)
        {
            Url = original.Url;
            B64 = original.B64;
        }
    }
}