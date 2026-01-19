---
title: Преобразовать презентацию в HTML
type: docs
weight: 40
url: /ru/net/convert-presentation-to-html/
---

**HTML** — один из нескольких широко используемых форматов обмена данными. **Aspose.Slides for .NET** поддерживает преобразование презентации в HTML. Ниже приведён фрагмент кода, показывающий, как это сделать.
## **Пример**
``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Saving the presentation to HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Скачать работающий пример**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Скачать пример кода**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Для получения дополнительной информации посетите [Конвертация презентаций PowerPoint в HTML в .NET](/slides/ru/net/convert-powerpoint-to-html/).

{{% /alert %}}