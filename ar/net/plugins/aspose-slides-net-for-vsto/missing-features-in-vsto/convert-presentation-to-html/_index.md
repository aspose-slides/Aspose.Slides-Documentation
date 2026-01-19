---
title: تحويل العرض التقديمي إلى HTML
type: docs
weight: 40
url: /ar/net/convert-presentation-to-html/
---

**HTML** هو أحد الصيغ المستخدمة على نطاق واسع لتبادل البيانات. **Aspose.Slides for .NET** يوفر دعمًا لتحويل عرض تقديمي إلى HTML. أدناه مقتطف الشيفرة الذي يوضح لك كيف.
## **مثال**
``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

HtmlOptions htmlOpt = new HtmlOptions();

htmlOpt.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter("", false);

//Saving the presentation to HTML

pres.Save("Converted.html", Aspose.Slides.Export.SaveFormat.Html, htmlOpt);

``` 
## **تنزيل المثال القائم**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20HTML)
## **تنزيل كود العينة**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
لمزيد من التفاصيل، قم بزيارة [تحويل عروض PowerPoint إلى HTML في .NET](/slides/ar/net/convert-powerpoint-to-html/).
{{% /alert %}}