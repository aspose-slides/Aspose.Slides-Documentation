---
title: خط
type: docs
weight: 50
url: /ar/net/Line/
keywords: "خط، شكل PowerPoint، عرض تقديمي PowerPoint، C#، Csharp، Aspose.Slides for .NET"
description: "إضافة خط في عرض تقديمي PowerPoint باستخدام C# أو .NET"
---

يدعم Aspose.Slides for .NET إضافة أنواع مختلفة من الأشكال إلى الشرائح. في هذا الموضوع، سنبدأ العمل مع الأشكال عن طريق إضافة خطوط إلى الشرائح. باستخدام Aspose.Slides for .NET، يمكن للمطورين ليس فقط إنشاء خطوط بسيطة، بل يمكن أيضًا رسم خطوط مزخرفة على الشرائح.
## **إنشاء خط عادي**
لإضافة خط عادي بسيط إلى شريحة مختارة من العرض التقديمي، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من [العرض التقديمي ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
- احصل على مرجع الشريحة باستخدام فهرسها.
- أضف AutoShape من نوع Line باستخدام طريقة [AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/methods/addautoshape/index) المعروضة بواسطة كائن Shapes.
- احفظ العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، أضفنا خطًا إلى الشريحة الأولى من العرض التقديمي.
```c#
// إنشاء فئة PresentationEx التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة AutoShape من النوع Line
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // حفظ PPTX إلى القرص
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```


## **إنشاء خط على شكل سهم**
يوفر Aspose.Slides for .NET أيضًا للمطورين إمكانية تكوين بعض خصائص الخط لجعله أكثر جاذبية. دعنا نجرب تكوين بعض خصائص الخط لجعله يبدو كسهم. يرجى اتباع الخطوات أدناه للقيام بذلك:

- إنشاء مثيل من [العرض التقديمي ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/aspose.slides/)[](http://www.aspose.com/api/net/slides/aspose.slides/).
- احصل على مرجع الشريحة باستخدام فهرسها.
- أضف AutoShape من نوع Line باستخدام طريقة AddAutoShape المعروضة بواسطة كائن Shapes.
- اضبط نمط الخط إلى أحد الأنماط المتاحة في Aspose.Slides for .NET.
- اضبط عرض الخط.
- اضبط [نمط الشرط](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle) للخط إلى أحد الأنماط المتاحة في Aspose.Slides for .NET.
- اضبط [نمط رأس السهم](https://reference.aspose.com/slides/net/aspose.slides/linearrowheadstyle) وطول نقطة البداية للخط.
- اضبط نمط رأس السهم وطول نقطة النهاية للخط.
- احفظ العرض التقديمي المعدل كملف PPTX.
```c#
// إنشاء فئة PresentationEx التي تمثل ملف PPTX
using (Presentation pres = new Presentation())
{
    // الحصول على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // إضافة AutoShape من النوع line
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

    //حفظ PPTX إلى القرص
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة المتداولة**

**هل يمكنني تحويل خط عادي إلى موصل بحيث "يلتصق" بالأشكال؟**

لا. لا يتحول الخط العادي (هو [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) من النوع [Line](https://reference.aspose.com/slides/net/aspose.slides/shapetype/)) تلقائيًا إلى موصل. لجعله يلتصق بالأشكال، استخدم النوع المخصص [Connector](https://reference.aspose.com/slides/net/aspose.slides/connector/) و[واجهات برمجة التطبيقات المقابلة](/slides/ar/net/connector/) للاتصالات.

**ماذا أفعل إذا كانت خصائص الخط موروثة من السمة ويصعب تحديد القيم النهائية؟**

[اقرأ الخصائص الفعالة](/slides/ar/net/shape-effective-properties/) عبر واجهات [ILineFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ilinefillformateffectivedata/) — هذه الواجهات تأخذ بالفعل في الاعتبار الوراثة وأنماط السمة.

**هل يمكنني قفل خط لمنع تحريره (نقله، تغيير حجمه)؟**

نعم. توفر الأشكال [كائنات القفل](https://reference.aspose.com/slides/net/aspose.slides/autoshape/autoshapelock/) التي تسمح لك [بمنع عمليات التحرير](/slides/ar/net/applying-protection-to-presentation/).
