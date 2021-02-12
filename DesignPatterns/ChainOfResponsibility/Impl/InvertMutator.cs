using System.Linq;

namespace DesignPatterns.ChainOfResponsibility.Impl
{
    public class InvertMutator : AbstractStringMutator
    {
        /*public IStringMutator SetNext(IStringMutator next)
        {
            throw new System.NotImplementedException();
        }*/
        public override string Mutate(string str)
        {
            //var newString = new string(Enumerable.Range(1, str.Length).Select(i => str[^i]).ToArray());
            return base.Mutate(new string(Enumerable.Range(1, str.Length).Select(i => str[^i]).ToArray()));
        }
    }
}