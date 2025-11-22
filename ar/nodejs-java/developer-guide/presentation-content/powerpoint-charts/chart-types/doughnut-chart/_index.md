---
title: مخطط الدونات
type: docs
weight: 30
url: /ar/nodejs-java/doughnut-chart/
---

## **تغيير الفجوة المركزية في مخطط الدونات**
{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java يدعم الآن تحديد حجم الفتحة في مخطط الدونات. في هذا الموضوع، سنرى مع مثال كيفية تحديد حجم الفتحة في مخطط الدونات.

{{% /alert %}} 

للتحديد حجم الفتحة في مخطط الدونات، يرجى اتباع الخطوات التالية:

1. إنشاء كائن [العرض التقديمي](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. إضافة مخطط الدونات إلى الشريحة.
1. تحديد حجم الفتحة في مخطط الدونات.
1. كتابة العرض التقديمي إلى القرص.

في المثال المعطى أدناه، قمنا بتعيين حجم الفتحة في مخطط الدونات.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // كتابة العرض التقديمي إلى القرص
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل يمكنني إنشاء دونات متعددة المستويات مع عدة حلقات؟**

نعم. أضف سلاسل متعددة إلى مخطط دونات واحد—تتحول كل سلسلة إلى حلقة منفصلة. يتم تحديد ترتيب الحلقات بناءً على ترتيب السلاسل في المجموعة.

**هل يتم دعم "دونات منفجرة" (شرائح منفصلة)؟**

نعم. هناك نوع مخطط [دونات منفجرة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) وخصائص انفجار على نقاط البيانات؛ يمكنك فصل الشرائح الفردية.

**كيف يمكنني الحصول على صورة لمخطط الدونات (PNG/SVG) لتقارير؟**

المخطط هو شكل؛ يمكنك تصييره إلى [صورة نقطية](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) أو تصدير المخطط إلى صورة [SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/).