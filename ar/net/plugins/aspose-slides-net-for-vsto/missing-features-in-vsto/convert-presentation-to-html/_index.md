---
title: تحويل العرض التقديمي إلى HTML
type: docs
weight: 40
url: /ar/net/convert-presentation-to-html/
---

**HTML** هو أحد التنسيقات المستخدمة على نطاق واسع لتبادل البيانات. **Aspose.Slides for .NET** يوفر دعمًا لتحويل العرض التقديمي إلى HTML. أدناه هو مقتطف من الكود يوضح لك كيفية القيام بذلك.
## **مثال**
``` 

 //إنشاء كائن عرض تقديمي يمثل ملف عرض تقديمي

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//حفظ العرض التقديمي كـ HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **تحميل مثال قيد التشغيل**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to HTML/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **تحميل مثال من الكود**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

لمزيد من التفاصيل، قم بزيارة [تحويل العرض التقديمي إلى HTML](/slides/ar/net/convert-powerpoint-ppt-and-pptx-to-html/).

{{% /alert %}}