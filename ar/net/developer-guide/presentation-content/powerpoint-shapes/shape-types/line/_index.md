---
title: إضافة أشكال الخط إلى العروض التقديمية في .NET
linktitle: خط
type: docs
weight: 50
url: /ar/net/Line/
keywords:
- خط
- إنشاء خط
- إضافة خط
- خط عادي
- تكوين خط
- تخصيص خط
- نمط الشرط
- رأس السهم
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تعديل تنسيق الخطوط في عروض PowerPoint باستخدام Aspose.Slides for .NET. اكتشف الخصائص والطرق والأمثلة."
---

يدعم Aspose.Slides for .NET إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال عن طريق إضافة خطوط إلى الشرائح. باستخدام Aspose.Slides for .NET، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، بل أيضًا رسم خطوط مزخرفة على الشرائح.
## **إنشاء خط عادي**
لإضافة خط عادي بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات التالية:

- إنشاء مثيل من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
- الحصول على مرجع الشريحة باستخدام فهرستها Index.
- إضافة AutoShape من النوع Line باستخدام طريقة [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) التي يوفرها كائن Shapes.
- كتابة العرض التقديمي المعدل كملف PPTX.

في المثال الوارد أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض التقديمي.
```c#
// إنشاء كائن من فئة PresentationEx التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // احصل على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة شكل تلقائي من النوع خط
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    //Write حفظ ملف PPTX إلى القرص
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```



## **إنشاء خط على شكل سهم**
يسمح Aspose.Slides for .NET للمطورين أيضًا بتكوين بعض خصائص الخط لجعله أكثر جاذبية. دعونا نجرب تكوين بعض خصائص الخط لجعله يبدو كسهم. يرجى اتباع الخطوات التالية للقيام بذلك:

- إنشاء مثيل من فئة [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- الحصول على مرجع الشريحة باستخدام فهرستها Index.
- إضافة AutoShape من النوع Line باستخدام طريقة AddAutoShape التي يوفرها كائن Shapes.
- ضبط نمط الخط Line Style على أحد الأنماط المتاحة في Aspose.Slides for .NET.
- ضبط عرض الخط Width.
- ضبط [Dash Style](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) للخط على أحد الأنماط المتاحة في Aspose.Slides for .NET.
- ضبط [Arrow Head Style](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) وطول رأس السهم لنقطة البداية للخط.
- ضبط نمط وطول رأس السهم لنقطة النهاية للخط.
- كتابة العرض التقديمي المعدل كملف PPTX.
```c#
// إنشاء كائن من الفئة PresentationEx التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{

    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة شكل تلقائي من النوع خط
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // تطبيق بعض التنسيقات على الخط
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //حفظ ملف PPTX إلى القرص
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث «يلتقط» الأشكال؟**

لا. الخط العادي (وهو [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) لا يتحول تلقائيًا إلى موصل. لجعله يلتقط الأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) و[واجهات برمجة التطبيقات المقابلة](/slides/ar/net/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط مُوروثة من السمة وكان من الصعب تحديد القيم النهائية؟**

[اقرأ الخصائص الفعّالة](/slides/ar/net/shape-effective-properties/) عبر واجهات [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) — هذه الواجهات تأخذ بالفعل في الاعتبار الوراثة وأنماط السمات.

**هل يمكنني قفل الخط ضد التحرير (النقل، تغيير الحجم)؟**

نعم. توفر الأشكال كائنات قفل [lock objects](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) التي تتيح لك [منع عمليات التحرير](/slides/ar/net/applying-protection-to-presentation/).