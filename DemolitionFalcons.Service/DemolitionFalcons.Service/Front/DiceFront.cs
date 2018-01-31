namespace DemolitionFalcons.Service.Front
{
    using System;

    public class DiceFront
    {
        public DiceFront(int result)
        {
            this.Result = result;
        }

        public int Result { get; set; }
    }
}
