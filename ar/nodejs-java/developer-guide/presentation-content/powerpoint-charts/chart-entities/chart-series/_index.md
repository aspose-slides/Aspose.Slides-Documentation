---
title: سلسلة المخطط
type: docs
url: /ar/nodejs-java/chart-series/
keywords: "سلسلة المخطط, لون السلسلة, عرض تقديمي PowerPoint, Java, Aspose.Slides for Node.js via Java"
description: "سلسلة المخطط في عروض PowerPoint التقديمية في JavaScript"
---

السلسلة هي صف أو عمود من الأرقام يتم رسمه في مخطط.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة المخطط**

باستخدام طريقة [ChartSeries.getOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) يمكنك تحديد مقدار تداخل الأعمدة والشرائح في مخطط ثنائي الأبعاد (النطاق: -100 إلى 100). تُطبق هذه الخاصية على جميع سلاسل مجموعة السلسلة الأصلية: فهي تمثيل للخاصية المناسبة للمجموعة. وبالتالي، هذه الخاصية للقراءة فقط.

استخدم الخاصية القابلة للقراءة/الكتابة `ParentSeriesGroup.getOverlap` لتعيين القيمة المفضلة لك لـ `Overlap`.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. إضافة مخطط أعمدة مترابطة إلى شريحة.
1. الوصول إلى أول سلسلة في المخطط.
1. الوصول إلى `ParentSeriesGroup` لسلسلة المخطط وتعيين قيمة التداخل المفضلة للسلسلة.
1. حفظ العرض التقديمي المعدل إلى ملف PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // إضافة مخطط
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // تعيين تداخل السلسلة
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // حفظ ملف العرض التقديمي إلى القرص
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تغيير لون السلسلة**

يتيح لك Aspose.Slides for Node.js عبر Java تغيير لون السلسلة بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. إضافة مخطط إلى الشريحة.
1. الوصول إلى السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة ولون التعبئة المفضلين.
1. حفظ العرض التقديمي المعدل.

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تغيير لون فئة السلسلة**

يتيح لك Aspose.Slides for Node.js عبر Java تغيير لون فئة السلسلة بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. إضافة مخطط إلى الشريحة.
1. الوصول إلى فئة السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة ولون التعبئة المفضلين.
1. حفظ العرض التقديمي المعدل.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تغيير اسم السلسلة**

بشكل افتراضي، تكون أسماء وسيلة الإيضاح للمخطط هي محتويات الخلايا فوق كل عمود أو صف من البيانات.

في مثالنا (الصورة النموذجية)،

* الأعمدة هي *Series 1, Series 2,* و *Series 3*;
* الصفوف هي *Category 1, Category 2, Category 3,* و *Category 4.*

يتيح لك Aspose.Slides for Node.js عبر Java تحديث أو تغيير اسم السلسلة في بيانات المخطط ووسيلة الإيضاح.

يعرض لك هذا الكود JavaScript كيفية تغيير اسم السلسلة في بيانات المخطط `ChartDataWorkbook`:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


يعرض لك هذا الكود JavaScript كيفية تغيير اسم السلسلة في وسيلة الإيضاح عبر `Series`:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين لون تعبئة سلسلة المخطط**

يتيح لك Aspose.Slides for Node.js عبر Java تعيين لون التعبئة التلقائي لسلاسل المخطط داخل منطقة الرسم بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الحصول على مرجع شريحة عبر رقمها.
1. إضافة مخطط ببيانات افتراضية بناءً على النوع المفضل لديك (في المثال أدناه استخدمنا `ChartType.ClusteredColumn`).
1. الوصول إلى سلسلة المخطط وتعيين لون التعبئة إلى Automatic.
1. حفظ العرض التقديمي إلى ملف PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // إنشاء مخطط عمود متجميع
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // تعيين تنسيق تعبئة السلسلة إلى تلقائي
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // حفظ ملف العرض التقديمي إلى القرص
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين ألوان تعبئة مقلوبة لسلسلة المخطط**

يتيح لك Aspose.Slides تعيين لون التعبئة المقلوب لسلاسل المخطط داخل منطقة الرسم بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الحصول على مرجع شريحة عبر رقمها.
1. إضافة مخطط ببيانات افتراضية بناءً على النوع المفضل لديك (في المثال أدناه استخدمنا `ChartType.ClusteredColumn`).
1. الوصول إلى سلسلة المخطط وتعيين لون التعبئة إلى invert.
1. حفظ العرض التقديمي إلى ملف PPTX.

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // يضيف سلاسل وفئات جديدة
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // يأخذ أول سلسلة مخطط ويملأ بيانات السلسلة الخاصة بها.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين السلسلة لتقلب اللون عندما تكون القيمة سلبية**

يتيح لك Aspose.Slides ضبط التقلبات عبر طريقة `ChartDataPoint.setInvertIfNegative`. عندما يتم ضبط التقلب باستخدام الخصائص، يقوم نقطة البيانات بعكس ألوانها عند حصولها على قيمة سلبية.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **مسح بيانات نقاط البيانات المحددة**

يتيح لك Aspose.Slides for Node.js عبر Java مسح بيانات `DataPoints` لسلسلة مخطط محددة بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
2. الحصول على مرجع الشريحة عبر رقمها.
3. الحصول على مرجع المخطط عبر رقمه.
4. التكرار عبر جميع `DataPoints` في المخطط وتعيين `XValue` و `YValue` إلى null.
5. مسح جميع `DataPoints` لسلسلة المخطط المحددة.
6. حفظ العرض التقديمي المعدل إلى ملف PPTX.

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **تعيين عرض الفجوة للسلسلة**

يتيح لك Aspose.Slides for Node.js عبر Java تعيين عرض الفجوة لسلسلة عبر الخاصية **`GapWidth`** بهذه الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. الوصول إلى أي سلسلة في المخطط.
1. تعيين الخاصية `GapWidth`.
1. حفظ العرض التقديمي المعدل إلى ملف PPTX.

```javascript
// إنشاء عرض تقديمي فارغ
var pres = new aspose.slides.Presentation();
try {
    // الوصول إلى الشريحة الأولى في العرض التقديمي
    var slide = pres.getSlides().get_Item(0);
    // إضافة مخطط ببيانات افتراضية
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // تعيين فهرس ورقة بيانات المخطط
    var defaultWorksheetIndex = 0;
    // الحصول على ورقة عمل بيانات المخطط
    var fact = chart.getChartData().getChartDataWorkbook();
    // إضافة السلاسل
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // إضافة الفئات
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // أخذ السلسلة الثانية في المخطط
    var series = chart.getChartData().getSeries().get_Item(1);
    // ملء بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // تعيين قيمة GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    // حفظ العرض التقديمي إلى القرص
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها مخطط واحد؟**

لا تفرض Aspose.Slides حدًا ثابتًا لعدد السلاسل التي يمكنك إضافتها. الحد العملي يحدده قابلية قراءة المخطط والذاكرة المتاحة لتطبيقك.

**ماذا لو كانت الأعمدة داخل مجموعة متقاربة جدًا أو متباعدة جدًا؟**

قم بضبط إعداد عرض الفجوة لتلك السلسلة (أو مجموعة السلسلة الأصلية). زيادة القيمة توسع المسافة بين الأعمدة، بينما تقليلها تقربها من بعضها.