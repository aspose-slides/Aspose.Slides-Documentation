---
title: تصدير مخططات العرض التقديمي في С++
linktitle: تصدير المخطط
type: docs
weight: 90
url: /ar/cpp/export-chart/
keywords:
- مخطط
- مخطط إلى صورة
- مخطط كصورة
- استخراج صورة المخطط
- PowerPoint
- عرض تقديمي
- С++
- Aspose.Slides
description: "تعرف على كيفية تصدير مخططات العروض التقديمية باستخدام Aspose.Slides للـ С++، مع دعم صيغ PPT و PPTX، وتبسيط إعداد التقارير في أي سير عمل."
---

## **احصل على صورة مخطط**
توفر Aspose.Slides لـ C++ دعمًا لاستخراج صورة مخطط معين. فيما يلي مثال توضيحي.  
```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **الأسئلة المتكررة**

**هل يمكنني تصدير المخطط كناقل (SVG) بدلاً من صورة نقطية؟**

نعم. المخطط هو شكل، ويمكن حفظ محتوياته كملف SVG باستخدام [طريقة حفظ الشكل إلى SVG](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/).

**كيف يمكنني تحديد الحجم الدقيق للمخطط المصدّر بالبكسل؟**

استخدم وظائف التحميل الزائدة لتصوير الصورة التي تسمح بتحديد الحجم أو المقياس — يدعم المكتبة تصوير الكائنات بالأبعاد أو المقياس المحدد.

**ماذا أفعل إذا ظهرت الخطوط في التسميات والوسيلة الإيضاحية بشكل غير صحيح بعد التصدير؟**

[حمّل الخطوط المطلوبة](/slides/ar/cpp/custom-font/) عبر [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) حتى يحتفظ تصوير المخطط بالمقاييس ومظهر النص.

**هل يحترم التصدير سمة PowerPoint والأنماط والتأثيرات؟**

نعم. يتبع عارض Aspose.Slides تنسيق العرض التقديمي (السمات، الأنماط، التعبئة، التأثيرات)، وبالتالي يتم الحفاظ على مظهر المخطط.

**أين يمكنني العثور على إمكانيات التصوير/التصدير المتاحة بخلاف صور المخططات؟**

انظر قسم التصدير في [API](https://reference.aspose.com/slides/cpp/aspose.slides.export/)/[الوثائق](/slides/ar/cpp/convert-powerpoint/) للحصول على أهداف الإخراج ([PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، [SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/)، [XPS](/slides/ar/cpp/convert-powerpoint-to-xps/)، [HTML](/slides/ar/cpp/convert-powerpoint-to-html/)، إلخ) وخيارات التصوير ذات الصلة.