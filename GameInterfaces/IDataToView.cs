using MVC;
using System.Collections.Generic;

namespace GameInterfaces
{
    interface IDataToView
    {
        List<ViewContent> DataToView();
    }
}
