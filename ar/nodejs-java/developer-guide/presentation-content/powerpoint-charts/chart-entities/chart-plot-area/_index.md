---
title: مساحة رسم المخطط
type: docs
url: /ar/nodejs-java/chart-plot-area/
---

## **الحصول على عرض وارتفاع مساحة رسم المخطط**

توفر Aspose.Slides لـ Node.js عبر Java واجهة برمجة تطبيقات بسيطة.

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) .
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. استدعاء الطريقة [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) قبل الحصول على القيم الفعلية.
1. الحصول على موقع X الفعلي (اليسار) لعنصر المخطط بالنسبة إلى الزاوية العلوية اليسرى للمخطط.
1. الحصول على الموضع العلوي الفعلي لعنصر المخطط بالنسبة إلى الزاوية العلوية اليسرى للمخطط.
1. الحصول على العرض الفعلي لعنصر المخطط.
1. الحصول على الارتفاع الفعلي لعنصر المخطط.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.validateChartLayout();
    var x = chart.getPlotArea().getActualX();
    var y = chart.getPlotArea().getActualY();
    var w = chart.getPlotArea().getActualWidth();
    var h = chart.getPlotArea().getActualHeight();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **ضبط وضع تخطيط مساحة رسم المخطط**

توفر Aspose.Slides لـ Node.js عبر Java واجهة برمجة تطبيقات بسيطة لضبط وضع تخطيط مساحة رسم المخطط. تمت إضافة الطريقتين **setLayoutTargetType** و **getLayoutTargetType** إلى فئة **ChartPlotArea**. إذا تم تعريف تخطيط مساحة الرسم يدويًا، تحدد هذه الخاصية ما إذا كان يجب تخطيط مساحة الرسم من داخلها (دون تضمين المحور وعناوين المحاور) أو من خارجها (مع تضمين المحور وعناوين المحاور). هناك قيمتان محتملتان معرّفتان في تعداد **LayoutTargetType**.

- **LayoutTargetType.Inner** - يحدد أن حجم مساحة الرسم يحدد حجم مساحة الرسم، دون تضمين علامات الفواصل وعناوين المحاور.
- **LayoutTargetType.Outer** - يحدد أن حجم مساحة الرسم يحدد حجم مساحة الرسم، وعلامات الفواصل، وعناوين المحاور.

الشفرة النموذجية موضحة أدناه.
```javascript
// إنشاء كائن من فئة Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getPlotArea().setX(0.2);
    chart.getPlotArea().setY(0.2);
    chart.getPlotArea().setWidth(0.7);
    chart.getPlotArea().setHeight(0.7);
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    pres.save("SetLayoutMode_outer.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**بأي وحدات يتم إرجاع X الفعلي وY الفعلي والعرض الفعلي والارتفاع الفعلي؟**

بالنقاط؛ 1 بوصة = 72 نقطة. هذه هي وحدات إحداثيات Aspose.Slides.

**كيف تختلف مساحة الرسم عن مساحة المخطط من حيث المحتوى؟**

مساحة الرسم هي منطقة رسم البيانات (السلاسل، خطوط الشبكة، خطوط الاتجاه، إلخ)؛ بينما تشمل مساحة المخطط العناصر المحيطة (العنوان، المفتاح، إلخ). في المخططات ثلاثية الأبعاد، تشمل مساحة الرسم أيضًا الجدران/القاع والمحاور.

**كيف يتم تفسير X وY والعرض والارتفاع لمساحة الرسم عندما يكون التخطيط يدويًا؟**

إنها كسور (من 0 إلى 1) من الحجم الكلي للمخطط؛ في هذا الوضع يتم تعطيل التموضع التلقائي وتُستخدم الكسور التي تحددها.

**لماذا تغير موقع مساحة الرسم بعد إضافة/نقل المفتاح؟**

المفتاح يقع في مساحة المخطط خارج مساحة الرسم لكنه يؤثر على التخطيط والمساحة المتاحة، لذا قد تتحرك مساحة الرسم عندما يكون التموضع التلقائي مفعلاً. (هذا سلوك قياسي لمخططات PowerPoint.)