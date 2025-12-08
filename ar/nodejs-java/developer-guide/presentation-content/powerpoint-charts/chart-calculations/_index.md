---
title: حسابات المخطط
type: docs
weight: 50
url: /ar/nodejs-java/chart-calculations/
---

## **حساب القيم الفعلية لعناصر المخطط**

توفر Aspose.Slides for Node.js عبر Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص صف [Axis](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis) معلومات حول الموضع الفعلي لعنصر المخطط المحوري ([Axis.getActualMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMaxValue--), [Axis.getActualMinValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinValue--), [Axis.getActualMajorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnit--), [Axis.getActualMinorUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnit--), [Axis.getActualMajorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMajorUnitScale--), [Axis.getActualMinorUnitScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Axis#getActualMinorUnitScale--)). من الضروري استدعاء الطريقة [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) مسبقًا لملء الخصائص بالقيم الفعلية.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();
    var maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    var minValue = chart.getAxes().getVerticalAxis().getActualMinValue();
    var majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
    var minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **حساب الموضع الفعلي لعناصر المخطط الأصلية**

توفر Aspose.Slides for Node.js عبر Java واجهة برمجة تطبيقات بسيطة للحصول على هذه الخصائص. توفر خصائص صف [ActualLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout) معلومات حول الموضع الفعلي لعنصر المخطط الأصلية ([ActualLayout.getActualX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualX--), [ActualLayout.getActualY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualY--), [ActualLayout.getActualWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualWidth--), [ActualLayout.getActualHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ActualLayout#getActualHeight--)). من الضروري استدعاء الطريقة [Chart.validateChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Chart#validateChartLayout--) مسبقًا لملء الخصائص بالقيم الفعلية.
```javascript
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


## **إخفاء المعلومات من المخطط**

هذه المقالة تساعدك على فهم كيفية إخفاء المعلومات من المخطط. باستخدام Aspose.Slides for Node.js عبر Java يمكنك إخفاء **العنوان، المحور الرأسي، المحور الأفقي** و **خطوط الشبكة** من المخطط. يعرض مثال الشيفرة أدناه كيفية استخدام هذه الخصائص.
```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 140, 118, 320, 370);
    // إخفاء عنوان المخطط
    chart.setTitle(false);
    // /إخفاء محور القيم
    chart.getAxes().getVerticalAxis().setVisible(false);
    // إظهار محور الفئات
    chart.getAxes().getHorizontalAxis().setVisible(false);
    // إخفاء وسيلة الإيضاح
    chart.setLegend(false);
    // إخفاء خطوط الشبكة الرئيسية
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().removeAt(i);
    }
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.Top);
    series.getMarker().setSize(15);
    // تعيين لون خط السلسلة
    series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Solid);
    pres.save("HideInformationFromChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل تعمل دفاتر Excel الخارجية كمصدر للبيانات، وكيف يؤثر ذلك على إعادة الحساب؟**

نعم. يمكن للمخطط الإشارة إلى دفتر عمل خارجي: عند الاتصال بالمصدر الخارجي أو تحديثه، تُؤخذ المعادلات والقيم من ذلك الدفتر، ويعكس المخطّط التحديثات أثناء عمليات الفتح/التعديل. تُتيح لك الواجهة برمجة التطبيقات [تحديد دفتر العمل الخارجي](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) المسار وإدارة البيانات المرتبطة.

**هل يمكنني حساب وعرض خطوط الاتجاه دون تنفيذ الانحدار بنفسي؟**

نعم. يتم إضافة [خطوط الاتجاه](/slides/ar/nodejs-java/trend-line/) (خطية، أسية، وغيرها) وتحديثها بواسطة Aspose.Slides؛ يتم إعادة حساب معلماتها تلقائيًا من بيانات السلسلة، لذا لا تحتاج إلى تنفيذ حساباتك الخاصة.

**إذا كان العرض التقديمي يحتوي على مخططات متعددة بروابط خارجية، هل يمكنني التحكم في دفتر العمل الذي يستخدمه كل مخطط للقيم المحسوبة؟**

نعم. يمكن لكل مخطط الإشارة إلى [دفتر عمل خارجي](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) خاص به، أو يمكنك إنشاء/استبدال دفتر عمل خارجي لكل مخطط بشكل مستقل عن الآخرين.