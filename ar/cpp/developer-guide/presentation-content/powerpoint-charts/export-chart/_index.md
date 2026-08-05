---
title: تصدير مخططات العرض التقديمي بـ C++
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
- C++
- Aspose.Slides
description: "تعرف على كيفية تصدير مخططات العرض التقديمي باستخدام Aspose.Slides للغة C++، مع دعم صيغ PPT و PPTX، وتبسيط إعداد التقارير في أي سير عمل."
---
## **نظرة عامة**

تتيح لك Aspose.Slides تصدير مخطط من عرض تقديمي كصورة. يوضح هذا المقال كيفية الحصول على صورة من مخطط وحفظها، وهو مفيد عندما تحتاج إلى إعادة استخدام مرئيات المخطط خارج عرض PowerPoint.

## **الحصول على صورة مخطط**
توفر Aspose.Slides للغة C++ دعم استخراج صورة لمخطط محدد. المثال التالي موضح أدناه.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **التعليمات المتكررة**

**هل يمكنني تصدير المخطط كمتجه (SVG) بدلاً من صورة نقطية؟**

نعم. المخطط هو شكل، ويمكن حفظ محتوياته كملف SVG باستخدام [طريقة حفظ الشكل إلى SVG](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shape/writeassvg/).

**كيف يمكنني ضبط الحجم الدقيق للمخطط المُصدَّر بالبكسل؟**

استخدم إصدارات الدالة التي تسمح بتحديد الحجم أو المقياس—المكتبة تدعم عرض الكائنات بأبعاد/مقاييس محددة.

**ماذا أفعل إذا ظهرت الخطوط في التسميات والوسيلة التوضيحية بشكل غير صحيح بعد التصدير؟**

[تحميل الخطوط المطلوبة](/slides/ar/cpp/custom-font/) عبر [FontsLoader](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsloader/) حتى يحافظ عرض المخطط على المقاييس ومظهر النص.

**هل يحترم التصدير موضوع PowerPoint والأنماط والتأثيرات؟**

نعم. يتبع عارض Aspose.Slides تنسيق العرض (المواضيع، الأنماط، التعبئات، التأثيرات)، وبالتالي يتم الحفاظ على مظهر المخطط.

**أين يمكنني العثور على قدرات العرض/التصدير المتاحة بخلاف صور المخطط؟**

انظر قسم التصدير في [API](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/)/[documentation](/slides/ar/cpp/convert-powerpoint/) لأهداف الإخراج ([PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/)، [SVG](/slides/ar/cpp/render-a-slide-as-an-svg-image/)، [XPS](/slides/ar/cpp/convert-powerpoint-to-xps/)، [HTML](/slides/ar/cpp/convert-powerpoint-to-html/)، إلخ) وخيارات العرض ذات الصلة.