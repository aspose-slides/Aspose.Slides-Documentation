---
title: Конвертация презентации в XPS
type: docs
weight: 60
url: /net/convert-presentation-to-xps/
---

Формат **XPS** также широко используется для обмена данными. Aspose.Slides для .NET учитывает его важность и предоставляет встроенную поддержку для конвертации презентации в документ XPS.

Метод **Save**, предоставляемый классом Presentation, можно использовать для конвертации всей презентации в документ **XPS**. Кроме того, класс **XpsOptions** предоставляет свойство **SaveMetafileAsPng**, которое можно установить в true или false в зависимости от требований.
## **Пример**

``` 

 //Создание объекта Presentation, представляющего файл презентации

Presentation pres = new Presentation("Conversion.ppt");

//Сохранение презентации в документе TIFF

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Скачать работающий пример**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to XPS/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Скачать пример кода**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Для получения дополнительной информации посетите [Конвертация в XPS](/slides/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/).

{{% /alert %}}