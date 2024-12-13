using System.Collections;

namespace Interfaces
{
    /// <summary>
    /// Use this interface when wanting to wait for a generic Dialog system to finish showing text
    /// </summary>
    public interface IDisplayDialog
    {
        public IEnumerator DisplayDialogCoroutine(string text);
    }
}