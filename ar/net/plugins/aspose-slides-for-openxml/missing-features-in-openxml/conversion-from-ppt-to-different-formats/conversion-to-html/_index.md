---
title: تحويل إلى HTML
type: docs
weight: 20
url: /net/conversion-to-html/
---

**HTML** هو أحد عدة تنسيقات مستخدمة على نطاق واسع لتبادل البيانات. **Aspose.Slides لـ .NET** يوفر الدعم لتحويل عرض تقديمي إلى HTML. أدناه هو مقتطف من الكود يوضح لك كيفية ذلك.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to HTML.html";

// Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

// Saving the presentation to HTML

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **تنزيل كود العينة**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20HTML%20%28Aspose.Slides%29.zip)