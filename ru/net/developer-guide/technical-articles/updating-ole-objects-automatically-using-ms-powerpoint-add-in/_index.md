---
title: Автоматическое обновление OLE-объектов с помощью надстройки PowerPoint
type: docs
weight: 10
url: /ru/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE-объект
- обновление OLE
- автоматически
- надстройка
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Узнайте, как автоматически обновлять OLE-диаграммы и объекты в PowerPoint с помощью надстройки и Aspose.Slides для .NET, включая практический код и рекомендации по оптимизации."
---

## **Обновление OLE-объектов автоматически**

Один из самых часто задаваемых вопросов клиентами Aspose.Slides for .NET — как создать или изменить редактируемые диаграммы (или другие OLE‑объекты), чтобы они обновлялись автоматически при открытии презентации. К сожалению, PowerPoint не поддерживает автоматические макросы так же, как Excel и Word. Доступны только макросы `Auto_Open` и `Auto_Close`, и они запускаются автоматически только из надстройки. В этом коротком техническом совете показано, как этого добиться.

Во‑первых, доступны несколько бесплатных надстроек, которые добавляют функцию макроса Auto_Open в PowerPoint, например [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) и [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

После установки одной из этих надстроек просто добавьте макрос `Auto_Open()` (или `OnPresentationOpen()`, если вы используете Event Generator) в шаблон презентации, как показано ниже:
```cs
public void Auto_Open()
{
    // Перебор всех слайдов в презентации.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // Перебор всех фигур на текущем слайде.
        foreach (var oShape in oSlide.Shapes)
        {
            // Проверка, является ли фигура объектом OLE.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // Найден объект OLE. Получаем его ссылку и обновляем.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Теперь завершите работу программы сервера OLE.
                // Это освобождает память и предотвращает проблемы.
                // Также установите oObject в Nothing, чтобы освободить объект.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```


Любые изменения OLE‑объектов с помощью Aspose.Slides for .NET будут автоматически применяться при открытии презентации в PowerPoint. Если у вас много OLE‑объектов и вы не хотите обновлять их все, просто добавьте пользовательский тег к нужным фигурам и проверяйте его в макросе.