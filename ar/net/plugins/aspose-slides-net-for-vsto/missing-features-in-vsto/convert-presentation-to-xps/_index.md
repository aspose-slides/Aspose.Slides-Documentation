---
title: تحويل العرض التقديمي إلى XPS
type: docs
weight: 60
url: /ar/net/convert-presentation-to-xps/
---

**XPS** يستخدم على نطاق واسع لتبادل البيانات. تتعامل Aspose.Slides for .NET مع أهميته وتوفر الدعم المدمج لتحويل عرض تقديمي إلى مستند **XPS**.

يمكن استخدام طريقة **Save** التي يوفرها صنف Presentation لتحويل العرض التقديمي بالكامل إلى مستند **XPS**. بالإضافة إلى ذلك، يعرض صنف **XpsOptions** الخاصية **SaveMetafileAsPng** التي يمكن تعيينها إلى true أو false وفقًا للمطلوب.
## **مثال**

``` 

 //Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation("Conversion.ppt");

//Saving the presentation to TIFF document

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **تنزيل المثال القائم**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **تنزيل عينة الكود**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
لمزيد من التفاصيل، قم بزيارة [Convert PowerPoint Presentations to XPS in .NET](/slides/ar/net/convert-powerpoint-to-xps/).
{{% /alert %}}