---
title: Обновление OLE‑объектов автоматически с помощью надстройки PowerPoint
type: docs
weight: 10
url: /ru/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- OLE‑объект
- обновление OLE
- автоматически
- надстройка
- PowerPoint
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как автоматически обновлять OLE‑диаграммы и объекты в PowerPoint с помощью надстройки и Aspose.Slides for Java, включая практический код и рекомендации по оптимизации."
---

## **Автоматическое обновление OLE‑объектов**

Один из самых частых вопросов, задаваемых клиентами Aspose.Slides for Java, — как создать или изменить редактируемые диаграммы (или другие OLE‑объекты), чтобы они обновлялись автоматически при открытии презентации. К сожалению, PowerPoint не поддерживает автоматические макросы так же, как Excel и Word. Доступны только макросы `Auto_Open` и `Auto_Close`, и они работают автоматически только из надстройки. В этом небольшом техническом совете показано, как добиться этого.

Во‑первых, доступно несколько бесплатных надстроек, которые добавляют функцию макроса Auto_Open в PowerPoint, например [AutoEvents Add‑in](http://skp.mvps.org/autoevents.htm) и [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

После установки одной из этих надстроек просто добавьте макрос `Auto_Open()` (или `OnPresentationOpen()`, если вы используете Event Generator) в шаблон презентации, как показано ниже:
```java
// Перебрать каждый слайд в презентации.
for (var oSlide : ActivePresentation.Slides) {
    // Перебрать все фигуры на текущем слайде.
    for (var oShape : oSlide.Shapes) {
        // Проверить, является ли фигура OLE‑объектом.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // Найден OLE‑объект. Получить его ссылку и затем обновить его.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Теперь выйти из программы сервера OLE.
            // Это освобождает память и предотвращает проблемы.
            // Также установить oObject в Nothing, чтобы освободить объект.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```


Любые изменения, внесённые в OLE‑объекты с помощью Aspose.Slides for Java, будут автоматически обновляться при открытии презентации в PowerPoint. Если у вас много OLE‑объектов и вы не хотите обновлять их все, просто добавьте пользовательский тег к нужным фигурам и проверяйте его в макросе.