---
title: تحويل إلى HTML
type: docs
weight: 20
url: /ar/net/conversion-to-html/
---

**HTML** هو أحد الصيغ الواسعة الاستخدام لتبادل البيانات. **Aspose.Slides for .NET** يوفر دعماً لتحويل عرض تقديمي إلى HTML. أدناه مقتطف الشيفرة الذي يوضح لك كيفية ذلك.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Saving the presentation to HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **تحميل عينة الكود**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)