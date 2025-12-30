---
title: تصدير مخططات العرض التقديمي في PHP
linktitle: تصدير المخطط
type: docs
weight: 90
url: /ar/php-java/export-chart/
keywords:
- مخطط
- مخطط إلى صورة
- مخطط كصورة
- استخراج صورة المخطط
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعرف على كيفية تصدير مخططات العرض التقديمي باستخدام Aspose.Slides لبي إتش بي عبر جافا، مع دعم صيغ PPT و PPTX، وتبسيط إعداد التقارير في أي سير عمل."
---

## **الحصول على صورة مخطط**
توفر Aspose.Slides for PHP عبر Java دعمًا لاستخراج صورة مخطط معين. يُعطى المثال التالي.  
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتكررة**

**هل يمكنني تصدير مخطط كمتجه (SVG) بدلاً من صورة نقطية؟**  
نعم. المخطط هو شكل، ويمكن حفظ محتوياته كـ SVG باستخدام طريقة [shape-to-SVG saving method](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/).

**كيف يمكنني تعيين الحجم الدقيق للمخطط المصدَّر بالبكسل؟**  
استخدم التحميلات الزائدة لتصوير الصور التي تسمح بتحديد الحجم أو المقياس — المكتبة تدعم رسم الكائنات بأبعاد/مقاييس محددة.

**ماذا يجب أن أفعل إذا ظهرت الخطوط في التسميات والوسيلة الإيضاحية بشكل غير صحيح بعد التصدير؟**  
[Load the required fonts](/slides/ar/php-java/custom-font/) عبر [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/) حتى يحافظ عرض المخطط على المقاييس ومظهر النص.

**هل يحترم التصدير سمة PowerPoint والأنماط والتأثيرات؟**  
نعم. برنامج العرض في Aspose.Slides يتبع تنسيق العرض (السمات، الأنماط، التعبئات، التأثيرات)، وبالتالي يتم الحفاظ على مظهر المخطط.

**أين يمكنني العثور على قدرات التصدير/العرض المتاحة خارج صور المخططات؟**  
انظر إلى [API](https://reference.aspose.com/slides/php-java/aspose.slides/)/[documentation](/slides/ar/php-java/convert-powerpoint/) للحصول على أهداف الإخراج ([PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/ar/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/ar/php-java/convert-powerpoint-to-xps/), [HTML](/slides/ar/php-java/convert-powerpoint-to-html/)، إلخ) والخيارات ذات الصلة.