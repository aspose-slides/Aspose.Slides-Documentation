---
title: Автоматическое обновление OLE-объектов с помощью дополнения MS PowerPoint
type: docs
weight: 10
url: /ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **Об автоматическом обновлении OLE-объектов**
Один из самых частых вопросов, задаваемых клиентами Aspose.Slides для .NET, заключается в том, как создать или изменить редактируемые диаграммы или любые другие OLE-объекты и автоматически обновлять их при открытии презентации. К сожалению, PowerPoint не поддерживает автоматические макросы, доступные в Excel и Word. Единственные доступные макросы - это Auto_Open и Auto_Close. Однако они запускаются автоматически только из дополнения. Этот краткий технический совет показывает, как это осуществить.

Во-первых, доступно несколько бесплатных дополнений, которые добавляют функцию макроса Auto_Open в PowerPoint, например [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) и [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

После установки такого дополнения просто добавьте макрос Auto_Open() (OnPresentationOpen() в случае "Event Generator") в вашу шаблонную презентацию, как показано ниже:

```c#
public void Auto_Open()
{
    Shape oShape;
    Slide oSlide;
    object oGraph;

    // Цикл по каждому слайду в презентации.
    foreach (var oSlide in ActivePresentation.Slides)
    {

        // Цикл по всем фигурам на текущем слайде.
        foreach (var oShape in oSlide.Shapes)
        {

            // Проверяем, является ли фигура OLE-объектом.
            if (oShape.Type == msoEmbeddedOLEObject)
            {

                // Найден OLE-объект; получаем ссылку на объект, а затем обновляем.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Теперь завершаем работу программы OLE-сервера. Это освобождает
                // память и предотвращает любые проблемы. Также установите oObject равным
                // Nothing, чтобы освободить объект.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```

{{% alert color="primary" %}} 

Любые изменения, внесенные в OLE-объекты с помощью Aspose.Slides для .NET, будут автоматически обновлены, когда PowerPoint откроет презентацию. Если у вас много OLE-объектов в презентации и вы не хотите обновлять их все, просто добавьте пользовательский тег к фигурам, которые нужно обработать, и проверьте его в макросе.

{{% /alert %}}