---
title: خط الاتجاه
type: docs
url: /ar/nodejs-java/trend-line/
---

## **إضافة خط الاتجاه**

Aspose.Slides for Node.js via Java يوفر واجهة برمجة تطبيقات بسيطة لإدارة خطوط الاتجاه لمختلف المخططات:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر فهرستها.
3. إضافة مخطط ببيانات افتراضية مع أحد الأنواع المطلوبة (هذا المثال يستخدم ChartType.ClusteredColumn).
4. إضافة خط اتجاه أسي للسلسلة 1 في المخطط.
5. إضافة خط اتجاه خطي للسلسلة 1 في المخطط.
6. إضافة خط اتجاه لوغاريتمي للسلسلة 2 في المخطط.
7. إضافة خط اتجاه متوسط متحرك للسلسلة 2 في المخطط.
8. إضافة خط اتجاه متعدد الحدود للسلسلة 3 في المخطط.
9. إضافة خط اتجاه طاقة للسلسلة 3 في المخطط.
10. كتابة العرض المعدل إلى ملف PPTX.

الكود التالي يُستخدم لإنشاء مخطط مع خطوط الاتجاه.
```javascript
// إنشاء مثيل من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    // إنشاء مخطط عمودي مجمع
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // إضافة خط اتجاه أسي للسلسلة 1 في المخطط
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // إضافة خط اتجاه خطي للسلسلة 1 في المخطط
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // إضافة خط اتجاه لوغاريتمي للسلسلة 2 في المخطط
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // إضافة خط اتجاه متوسط متحرك للسلسلة 2 في المخطط
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // إضافة خط اتجاه متعدد الحدود للسلسلة 3 في المخطط
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // إضافة خط اتجاه طاقة للسلسلة 3 في المخطط
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // حفظ العرض
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **إضافة خط مخصص**

Aspose.Slides for Node.js via Java يوفر واجهة برمجة تطبيقات بسيطة لإضافة خطوط مخصصة في المخطط. لإضافة خط بسيط إلى شريحة مختارة من العرض، اتبع الخطوات أدناه:

- إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام فهرستها.
- إنشاء مخطط جديد باستخدام طريقة AddChart التي يوفرها كائن Shapes.
- إضافة AutoShape من نوع Line باستخدام طريقة AddAutoShape التي يوفرها كائن Shapes.
- تعيين لون خطوط الشكل.
- كتابة العرض المعدل كملف PPTX.

الكود التالي يُستخدم لإنشاء مخطط مع خطوط مخصصة.
```javascript
// إنشاء مثيل من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**ماذا يعني "forward" و "backward" بالنسبة لخط الاتجاه؟**

هما طولا خط الاتجاه الممدود إلى الأمام/الخلف: في المخططات النقطية (XY) — بوحدات المحور؛ في المخططات غير النقطية — بعدد الفئات. يُسمح فقط بالقيم غير السالبة.

**هل سيظل خط الاتجاه محفوظًا عند تصدير العرض إلى PDF أو SVG، أو عند تحويل الشريحة إلى صورة؟**

نعم. Aspose.Slides يقوم بتحويل العروض إلى [PDF](/slides/ar/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/ar/nodejs-java/render-a-slide-as-an-svg-image/) ويحول المخططات إلى صور؛ خطوط الاتجاه، كجزء من المخطط، تُحفظ خلال هذه العمليات. كما تتوفر طريقة لتصدير صورة للمخطط نفسه [هنا](/slides/ar/nodejs-java/create-shape-thumbnails/).