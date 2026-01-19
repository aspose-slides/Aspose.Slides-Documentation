---
title: تحويل العرض التقديمي إلى Tiff مع الملاحظات
type: docs
weight: 50
url: /ar/net/convert-presentation-to-tiff-with-notes/
---

TIFF هو أحد صيغ الصور واسعة الاستخدام التي يدعمها Aspose.Slides لـ .NET لتحويل عرض تقديمي يحتوي على ملاحظات إلى صور. يمكنك أيضًا إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. أدناه مثالان يوضحان كيفية إنشاء صور TIFF لعرض تقديمي في عرض ملاحظات الشريحة.

يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save) التي تقدمها فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) لتحويل كامل العرض التقديمي في عرض ملاحظات الشريحة إلى TIFF. يمكنك أيضًا إنشاء صورة مصغرة لشريحة في عرض ملاحظات الشريحة لشرائح فردية.
## **مثال**

``` 

  //Instantiate a Presentation object that represents a presentation file

 Presentation pres = new Presentation("Conversion.pptx");

 //Saving the presentation to TIFF notes

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **تنزيل المثال التشغيلي**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **تنزيل عينة الكود**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

لمزيد من التفاصيل، تفضل بزيارة [تحويل عروض PowerPoint إلى TIFF مع الملاحظات في .NET](/slides/ar/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}