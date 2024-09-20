---
title: Конвертация презентации в HTML
type: docs
weight: 40
url: /net/convert-presentation-to-html/
---

**HTML** является одним из нескольких широко используемых форматов для обмена данными. **Aspose.Slides для .NET** предоставляет поддержку для конвертации презентации в HTML. Ниже приведен фрагмент кода, который показывает как это сделать.
## **Пример**
``` 

 //Создание объекта Presentation, представляющего файл презентации

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Сохранение презентации в HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Скачать рабочий пример**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to HTML/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **Скачать пример кода**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

Для получения дополнительной информации посетите [Конвертация презентаций в HTML](/slides/net/convert-powerpoint-ppt-and-pptx-to-html/).

{{% /alert %}}