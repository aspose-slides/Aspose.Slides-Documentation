---
title: تصدير مخططات العروض التقديمية في Java
linktitle: تصدير المخطط
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
description: "تعلم كيفية تصدير مخططات العروض التقديمية باستخدام Aspose.Slides for Java، مع دعم صيغ PPT و PPTX، وتبسيط إعداد التقارير في أي سير عمل."
---

## **الحصول على صورة المخطط**
يقدم Aspose.Slides for Java دعمًا لاستخراج صورة لمخطط معين. المثال التالي يُظهر ذلك.
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

**هل يمكنني تصدير مخطط كمتجه (SVG) بدلاً من صورة نقطية؟**  
نعم. المخطط هو شكل، ويمكن حفظ محتوياته كملف SVG باستخدام طريقة [shape-to-SVG saving method](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).

**كيف يمكنني تحديد الحجم الدقيق للمخطط المُصدَّر بالبكسل؟**  
استخدم الإصدارات الزائدة لـ image-rendering التي تسمح لك بتحديد الحجم أو المقياس — تدعم المكتبة تصيير الكائنات بالأبعاد أو المقياس المحدد.

**ماذا أفعل إذا ظهرت الخطوط في التسميات والوسيلة الإيضاحية بشكل غير صحيح بعد التصدير؟**  
[حمّل الخطوط المطلوبة](/slides/ar/java/custom-font/) عبر [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) حتى يحافظ تصيير المخطط على المقاييس ومظهر النص.

**هل يحترم التصدير سمة PowerPoint والأنماط والتأثيرات؟**  
نعم. يتبع المصدّر الخاص بـ Aspose.Slides تنسيق العرض (السمات، الأنماط، التعبئات، التأثيرات)، وبالتالي يُحافظ على مظهر المخطط.

**أين يمكنني العثور على قدرات التصيير/التصدير المتاحة غير صور المخططات؟**  
انظر إلى [API](https://reference.aspose.com/slides/java/com.aspose.slides/)/[التوثيق](/slides/ar/java/convert-powerpoint/) للحصول على أهداف الإخراج ([PDF](/slides/ar/java/convert-powerpoint-to-pdf/), [SVG](/slides/ar/java/render-a-slide-as-an-svg-image/), [XPS](/slides/ar/java/convert-powerpoint-to-xps/), [HTML](/slides/ar/java/convert-powerpoint-to-html/), إلخ) وخيارات التصيير المتعلقة.