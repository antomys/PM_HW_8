using System.Text.RegularExpressions;

namespace DesignPatterns.ChainOfResponsibility.Impl
{
    public class RemoveNumbersMutator : AbstractStringMutator
    {
        public override string Mutate(string str)
        {
            //str = Regex.Replace(str, @"[\d]", string.Empty);
            return base.Mutate(Regex.Replace(str, @"[\d]", ""));
        }
    }
}