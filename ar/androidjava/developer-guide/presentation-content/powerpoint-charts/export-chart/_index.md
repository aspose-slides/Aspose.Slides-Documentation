---
title: تصدير مخططات العرض التقديمي على Android
linktitle: تصدير مخطط
type: docs
weight: 90
url: /ar/androidjava/export-chart/
keywords:
- مخطط
- مخطط إلى صورة
- مخطط كصورة
- استخراج صورة المخطط
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية تصدير مخططات العروض التقديمية باستخدام Aspose.Slides لنظام Android عبر Java، مع دعم صيغ PPT و PPTX، وتبسيط إعداد التقارير في أي سير عمل."
---

## **Get a Chart Image**
توفر Aspose.Slides لنظام Android عبر Java دعمًا لاستخراج صورة لمخطط معين. المثال التالي موضح أدناه.
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**هل يمكنني تصدير مخطط كمتجه (SVG) بدلاً من صورة نقطية؟**

نعم. المخطط عبارة عن شكل، ويمكن حفظ محتوياته كملف SVG باستخدام [طريقة حفظ الشكل إلى SVG](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**كيف يمكنني تعيين الحجم الدقيق للمخطط المُصدَّر بالبكسل؟**

استخدم التحميلات الزائدة لتصوير الصورة التي تسمح بتحديد الحجم أو المقياس — المكتبة تدعم تصيير الكائنات بالأبعاد أو المقياس المحدد.

**ماذا أفعل إذا ظهرت الخطوط في التسميات والوسيلة الإيضاحية بشكل غير صحيح بعد التصدير؟**

[قم بتحميل الخطوط المطلوبة](/slides/ar/androidjava/custom-font/) عبر [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) لكي يحافظ تصيير المخطط على المقاييس ومظهر النص.

**هل يحترم التصدير موضوع PowerPoint والأنماط والتأثيرات؟**

نعم. يقوم مُصيّر Aspose.Slides باتباع تنسيق العرض (المواضيع، الأنماط، التعبئات، التأثيرات)، وبالتالي يتم الحفاظ على مظهر المخطط.

**أين يمكنني العثور على قدرات التصيير/التصدير المتاحة بخلاف صور المخططات؟**

انظر إلى [API](https://reference.aspose.com/slides/androidjava/com.aspose.slides/)/[التوثيق](/slides/ar/androidjava/convert-powerpoint/) للحصول على أهداف الإخراج ([PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)، [SVG](/slides/ar/androidjava/render-a-slide-as-an-svg-image/)، [XPS](/slides/ar/androidjava/convert-powerpoint-to-xps/)، [HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)، إلخ) وخيارات التصيير ذات الصلة.