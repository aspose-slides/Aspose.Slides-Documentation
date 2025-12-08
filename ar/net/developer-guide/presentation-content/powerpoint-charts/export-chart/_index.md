---
title: تصدير المخطط
type: docs
weight: 90
url: /ar/net/export-chart/
keywords:
- مخطط
- صورة المخطط
- استخراج صورة المخطط
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: "احصل على صور المخططات من عروض PowerPoint التقديمية باستخدام C# أو .NET"
---

## **الحصول على صورة المخطط**
توفر Aspose.Slides for .NET دعمًا لاستخراج صورة لمخطط محدد. المثال التالي موضح أدناه.
```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```


## **الأسئلة الشائعة**

**هل يمكنني تصدير المخطط كمتجه (SVG) بدلاً من صورة نقطية؟**

نعم. المخطط هو شكل، ويمكن حفظ محتوياته كملف SVG باستخدام [طريقة حفظ الشكل إلى SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).

**كيف يمكنني تعيين الحجم الدقيق للمخطط المصدر بالبكسل؟**

استخدم التحميلات الخاصة برسم الصورة التي تسمح بتحديد الحجم أو المقياس—المكتبة تدعم رسم الكائنات بأبعاد/مقاييس محددة.

**ماذا أفعل إذا بدت الخطوط في التسميات والوسيلة الإيضاحية غير صحيحة بعد التصدير؟**

[قم بتحميل الخطوط المطلوبة](/slides/ar/net/custom-font/) عبر [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) حتى يحافظ رسم المخطط على المقاييس ومظهر النص.

**هل يحترم التصدير موضوعات PowerPoint والأنماط والتأثيرات؟**

نعم. يتبع مُظهر Aspose.Slides تنسيق العرض (المواضيع، الأنماط، التعبئات، التأثيرات)، وبالتالي يُحافظ على مظهر المخطط.

**أين يمكنني العثور على إمكانيات الرسم/التصدير المتاحة بخلاف صور المخططات؟**

اطلع على قسم التصدير في [API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[الوثائق](/slides/ar/net/convert-powerpoint/) للحصول على أهداف الإخراج ([PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [SVG](/slides/ar/net/render-a-slide-as-an-svg-image/)، [XPS](/slides/ar/net/convert-powerpoint-to-xps/)، [HTML](/slides/ar/net/convert-powerpoint-to-html/)، إلخ) والخيارات المتعلقة بالرسم.