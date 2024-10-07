---
title: تحويل العرض إلى TIFF مع الملاحظات
type: docs
weight: 50
url: /net/convert-presentation-to-tiff-with-notes/
---

TIFF هو واحد من عدة تنسيقات صور مستخدمة على نطاق واسع التي تدعمها Aspose.Slides لـ .NET لتحويل عرض تقديمي مع الملاحظات إلى صور. يمكنك أيضًا إنشاء صور مصغرة للشريحة في عرض الشريحة بالملاحظات. فيما يلي مقطعي شيفرة يوضحان كيفية إنشاء صور TIFF لعرض تقديمي في عرض الشريحة بالملاحظات.

يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) المقدمة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل العرض التقديمي بالكامل في عرض الشريحة بالملاحظات إلى TIFF. يمكنك أيضًا إنشاء صورة مصغرة للشريحة في عرض الشريحة بالملاحظات للشرائح الفردية.
## **مثال**

``` 

  //إنشاء كائن عرض يقدم ملف عرض تقديمي

 Presentation pres = new Presentation("Conversion.pptx");

 //حفظ العرض التقديمي إلى TIFF مع الملاحظات

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **تنزيل مثال قيد التشغيل**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Tiff conversion with note/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
## **تنزيل كود العينة**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

للحصول على مزيد من التفاصيل، قم بزيارة [تحويل العرض مع الملاحظات](/slides/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/).

{{% /alert %}}