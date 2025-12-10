---
title: تصدير مخططات العروض التقديمية في Java
linktitle: تصدير مخطط
type: docs
weight: 90
url: /ar/java/export-chart/
keywords:
- مخطط
- مخطط إلى صورة
- مخطط كصورة
- استخراج صورة المخطط
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعرف على كيفية تصدير مخططات العروض التقديمية باستخدام Aspose.Slides لـ Java، مع دعم صيغ PPT و PPTX، وتبسيط إعداد التقارير في أي سير عمل."
---

## **الحصول على صورة مخطط**
يقدم Aspose.Slides for Java دعمًا لاستخراج صورة لمخطط معين. فيما يلي مثال توضيحي.
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


## **الأسئلة الشائعة**

**هل يمكنني تصدير مخطط كرسوم متجهة (SVG) بدلًا من صورة نقطية؟**
نعم. المخطط هو شكل، ويمكن حفظ محتوياته إلى SVG باستخدام طريقة [طريقة حفظ الشكل إلى SVG](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**كيف يمكنني تعيين الحجم الدقيق للمخطط المُصدّر بالبكسل؟**
استخدم المتغيّرات الإضافية لتصوير الصورة التي تسمح بتحديد الحجم أو المقياس—المكتبة تدعم تصيير الكائنات بأبعاد/مقاييس محددة.

**ماذا أفعل إذا ظهرت الخطوط في التسميات والوسيلة الإيضاحية بشكل غير صحيح بعد التصدير؟**
[حمّل الخطوط المطلوبة](/slides/ar/java/custom-font/) عبر [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) حتى يحافظ تصيير المخطط على المقاييس ومظهر النص.

**هل يحترم التصدير سمة PowerPoint والأنماط والتأثيرات؟**
نعم. يُطبق عارض Aspose.Slides تنسيق العرض التقديمي (السمات، الأنماط، التعبئات، التأثيرات)، وبالتالي يتم الحفاظ على مظهر المخطط.

**أين يمكنني العثور على إمكانيات التصيير/التصدير المتاحة بخلاف صور المخططات؟**
راجع [API](https://reference.aspose.com/slides/java/com.aspose.slides/)/[documentation](/slides/ar/java/convert-powerpoint/) للحصول على أهداف الإخراج ([PDF](/slides/ar/java/convert-powerpoint-to-pdf/)، [SVG](/slides/ar/java/render-a-slide-as-an-svg-image/)، [XPS](/slides/ar/java/convert-powerpoint-to-xps/)، [HTML](/slides/ar/java/convert-powerpoint-to-html/)، إلخ) وخيارات التصيير ذات الصلة.