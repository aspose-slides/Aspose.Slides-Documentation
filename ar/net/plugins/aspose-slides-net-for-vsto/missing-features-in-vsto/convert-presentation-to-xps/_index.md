---
title: تحويل العرض التقديمي إلى XPS
type: docs
weight: 60
url: /net/convert-presentation-to-xps/
---

**XPS** هو تنسيق يُستخدم على نطاق واسع لتبادل البيانات. تحرص Aspose.Slides لـ .NET على أهمية هذا التنسيق وتوفر دعمًا مدمجًا لتحويل العرض التقديمي إلى وثيقة XPS.

يمكن استخدام طريقة **Save** المعروضة بواسطة فئة Presentation لتحويل العرض التقديمي بالكامل إلى وثيقة **XPS**. علاوة على ذلك، تعرض فئة **XpsOptions** خاصية **SaveMetafileAsPng** التي يمكن تعيينها إلى true أو false حسب الحاجة.
## **مثال**

``` 

 //إنشاء كائن Presentation يمثل ملف عرض تقديمي

Presentation pres = new Presentation("Conversion.ppt");

//حفظ العرض التقديمي إلى وثيقة TIFF

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **تنزيل المثال القابل للتشغيل**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Converting to XPS/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **تنزيل نموذج الشيفرة**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

للمزيد من التفاصيل، قم بزيارة [التحويل إلى XPS](/slides/net/convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document/).

{{% /alert %}}