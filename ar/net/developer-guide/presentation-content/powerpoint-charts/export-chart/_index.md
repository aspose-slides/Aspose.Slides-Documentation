---
title: تصدير مخططات العرض التقديمي في .NET
linktitle: تصدير المخطط
type: docs
weight: 90
url: /ar/net/export-chart/
keywords:
- مخطط
- مخطط إلى صورة
- مخطط كصورة
- استخراج صورة المخطط
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تصدير مخططات العرض التقديمي باستخدام Aspose.Slides لـ .NET، مع دعم صيغ PPT و PPTX، وتبسيط إعداد التقارير في أي سير عمل."
---

## **الحصول على صورة المخطط**
توفر Aspose.Slides لـ .NET دعمًا لاستخراج صورة مخطط معين. المثال التالي موضح أدناه.  
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


## **الأسئلة المتكررة**

**هل يمكنني تصدير المخطط كمتجه (SVG) بدلاً من صورة نقطية؟**

نعم. المخطط هو شكل، ويمكن حفظ محتوياته كملف SVG باستخدام [طريقة حفظ الشكل إلى SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/).

**كيف يمكنني تعيين الحجم الدقيق للمخطط المُصدَّر بالبكسل؟**

استخدم التحميلات الزائدة لتصوير الصورة التي تسمح بتحديد الحجم أو المقياس—المكتبة تدعم تصيير الكائنات بأبعاد/مقاييس محددة.

**ماذا أفعل إذا ظهرت الخطوط في التسميات والوسيلة الإيضاحية بشكل غير صحيح بعد التصدير؟**

[حمّل الخطوط المطلوبة](/slides/ar/net/custom-font/) عبر [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) لضمان أن يُحافظ تصيير المخطط على المقاييس ومظهر النص.

**هل يحترم التصدير سمة PowerPoint والأنماط والتأثيرات؟**

نعم. يتبع المصدِّر في Aspose.Slides تنسيق العرض التقديمي (السمات، الأنماط، التعبئات، التأثيرات)، وبالتالي يتم الحفاظ على مظهر المخطط.

**أين يمكنني العثور على قدرات التصيير/التصدير المتاحة بخلاف صور المخططات؟**

انظر إلى قسم التصدير في [API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[التوثيق](/slides/ar/net/convert-powerpoint/) للحصول على أهداف الإخراج ([PDF](/slides/ar/net/convert-powerpoint-to-pdf/)، [SVG](/slides/ar/net/render-a-slide-as-an-svg-image/)، [XPS](/slides/ar/net/convert-powerpoint-to-xps/)، [HTML](/slides/ar/net/convert-powerpoint-to-html/)، إلخ) والخيارات المتعلقة بالتصيير.