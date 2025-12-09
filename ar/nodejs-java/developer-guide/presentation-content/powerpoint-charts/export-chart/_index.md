---
title: تصدير المخطط
type: docs
weight: 90
url: /ar/nodejs-java/export-chart/
---

## **الحصول على صورة المخطط**
توفر Aspose.Slides للـ Node.js عبر Java دعمًا لاستخراج صورة لمخطط محدد. المثال التالي موضح أدناه.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**هل يمكنني تصدير المخطط كمتجه (SVG) بدلاً من صورة نقطية؟**

نعم. المخطط هو شكل، ويمكن حفظ محتوياته كملف SVG باستخدام [طريقة حفظ الشكل إلى SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/).

**كيف يمكنني تحديد الحجم الدقيق للمخطط المُصدَّر بوحدات البكسل؟**

استخدم التحميلات الزائدة لـ image-rendering التي تسمح بتحديد الحجم أو المقياس؛ تدعم المكتبة عرض الكائنات بأبعاد/مقاييس محددة.

**ماذا أفعل إذا كانت الخطوط في التسميات والوسيلة الإيضاحية تظهر غير صحيحة بعد التصدير؟**

[حمّل الخطوط المطلوبة](/slides/ar/nodejs-java/custom-font/) عبر [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/) حتى يحافظ عرض المخطط على المقاييس ومظهر النص.

**هل يحترم التصدير سمة PowerPoint والأنماط والتأثيرات؟**

نعم. يتبع مُعرض Aspose.Slides تنسيق العرض (السماات، الأنماط، التعبئات، التأثيرات)، وبالتالي يتم الحفاظ على مظهر المخطط.

**أين يمكنني العثور على قدرات العرض/التصدير المتاحة بخلاف صور المخطط؟**

راجع [API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/)/[التوثيق](/slides/ar/nodejs-java/convert-powerpoint/) لأهداف الإخراج ([PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)، [SVG](/slides/ar/nodejs-java/render-a-slide-as-an-svg-image/)، [XPS](/slides/ar/nodejs-java/convert-powerpoint-to-xps/)، [HTML](/slides/ar/nodejs-java/convert-powerpoint-to-html/)، إلخ) وخيارات العرض ذات الصلة.