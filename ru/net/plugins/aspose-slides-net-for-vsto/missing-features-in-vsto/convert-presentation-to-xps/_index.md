---
title: Конвертировать презентацию в XPS
type: docs
weight: 60
url: /ru/net/convert-presentation-to-xps/
---

**XPS** формат также широко используется для обмена данными. Aspose.Slides for .NET учитывает его важность и предоставляет встроенную поддержку преобразования презентации в документ XPS.

Метод **Save**, доступный в классе Presentation, можно использовать для преобразования всей презентации в документ **XPS**. Кроме того, класс **XpsOptions** предоставляет свойство **SaveMetafileAsPng**, которое можно установить в true или false в зависимости от требований.
## **Пример**

``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

//Saving the presentation to TIFF document

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Скачать работающий пример**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Для получения более подробной информации посетите [Convert PowerPoint Presentations to XPS in .NET](/slides/ru/net/convert-powerpoint-to-xps/).

{{% /alert %}}