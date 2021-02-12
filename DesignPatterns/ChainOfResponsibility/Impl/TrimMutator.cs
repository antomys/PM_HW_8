namespace DesignPatterns.ChainOfResponsibility.Impl
{
    public class TrimMutator : AbstractStringMutator
    {
        /*public IStringMutator SetNext(IStringMutator next)
        {
            throw new System.NotImplementedException();
        }*/

        public override string Mutate(string str)
        {
            return base.Mutate(str.Trim());
        }
    }
}