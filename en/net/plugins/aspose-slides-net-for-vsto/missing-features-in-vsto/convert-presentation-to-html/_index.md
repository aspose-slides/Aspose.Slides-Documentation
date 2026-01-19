---
title: Convert Presentation to HTML
type: docs
weight: 40
url: /net/convert-presentation-to-html/
---

**HTML** is one of several widely used format for exchanging data. **Aspose.Slides for .NET** provides support for converting a presentation to HTML. Below is code snippet that shows you how.
## **Example**
``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Saving the presentation to HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **Download Running Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

For more details, visit [Convert PowerPoint Presentations to HTML in .NET](/slides/net/convert-powerpoint-to-html/).

{{% /alert %}}
