---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية على Android
linktitle: سلسلة البيانات
type: docs
url: /ar/androidjava/chart-series/
keywords:
- سلسلة المخطط
- تراكب السلسلة
- لون السلسلة
- لون الفئة
- اسم السلسلة
- نقطة البيانات
- فجوة السلسلة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: تعلم كيفية إدارة سلاسل المخططات على Android لملفات PowerPoint (PPT/PPTX) مع أمثلة شفرة Java عملية وأفضل الممارسات لتحسين عروض البيانات الخاصة بك.
---

السلسلة هي صف أو عمود من الأرقام يتم رسمه في مخطط.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تراكب سلسلة المخطط**

باستخدام طريقة [IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) يمكنك تحديد مدى تراكب الأشرطة والأعمدة في مخطط ثنائي الأبعاد (النطاق: -100 إلى 100). تُطبق هذه الخاصية على جميع السلاسل في مجموعة السلاسل الأصلية: وهذا يمثل إسقاطًا لخاصية المجموعة المناسبة. لذلك، هذه الخاصية للقراءة فقط.

استخدم طريقة الكتابة `getParentSeriesGroup().setOverlap()` لتحديد القيمة المفضلة للتراكب.

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. إضافة مخطط عمود مُجمّع إلى شريحة.
1. الوصول إلى أول سلسلة مخطط.
1. الوصول إلى `ParentSeriesGroup` للسلسلة وتعيين قيمة التراكب المفضلة للسلسلة.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

هذا الكود بجافا يوضح لك كيفية تعيين التراكب لسلسلة مخطط:
```java
Presentation pres = new Presentation();
try {
    // إضافة مخطط
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // تعيين تراكب السلسلة
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // كتابة ملف العرض التقديمي إلى القرص
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تغيير لون السلسلة**
يتيح Aspose.Slides for Android عبر جافا تغيير لون السلسلة بهذه الطريقة:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. إضافة مخطط إلى الشريحة.
1. الوصول إلى السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة ولون التعبئة المفضلين.
1. حفظ العرض التقديمي المعدل.

هذا الكود بجافا يوضح لك كيفية تغيير لون السلسلة:
```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تغيير لون فئة السلسلة**
يتيح Aspose.Slides for Android عبر جافا تغيير لون فئة السلسلة بهذه الطريقة:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. إضافة مخطط إلى الشريحة.
1. الوصول إلى فئة السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة ولون التعبئة المفضلين.
1. حفظ العرض التقديمي المعدل.

هذا الكود بجافا يوضح لك كيفية تغيير لون فئة السلسلة:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تغيير اسم السلسلة** 

بشكل افتراضي، تكون أسماء وسيلة الإيضاح للمخطط هي محتويات الخلايا فوق كل عمود أو صف من البيانات.

في مثالنا (الصورة النموذجية)،

* الأعمدة هي *Series 1, Series 2,* و *Series 3*؛
* الصفوف هي *Category 1, Category 2, Category 3,* و *Category 4*.

يتيح Aspose.Slides for Android عبر جافا تحديث أو تغيير اسم السلسلة في بيانات المخطط ووسيلة الإيضاح.

هذا الكود بجافا يوضح لك كيفية تغيير اسم السلسلة في بيانات المخطط `ChartDataWorkbook`:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


هذا الكود بجافا يوضح لك كيفية تغيير اسم السلسلة في وسيلة الإيضاح عبر `Series`:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين لون تعبئة سلسلة المخطط**

يتيح Aspose.Slides for Android عبر جافا تعيين لون التعبئة التلقائي لسلسلة المخطط داخل منطقة الرسم بهذه الطريقة:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الحصول على مرجع الشريحة عبر مؤشرها.
1. إضافة مخطط ببيانات افتراضية بناءً على النوع المفضل (في المثال أدناه، استخدمنا `ChartType.ClusteredColumn`).
1. الوصول إلى سلسلة المخطط وتعيين لون التعبئة إلى Automatic.
1. حفظ العرض التقديمي إلى ملف PPTX.

هذا الكود بجافا يوضح لك كيفية تعيين لون التعبئة التلقائي لسلسلة مخطط:
```java
Presentation pres = new Presentation();
try {
    // إنشاء مخطط عمود مُجمّع
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // ضبط تنسيق تعبئة السلسلة إلى تلقائي
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // كتابة ملف العرض التقديمي إلى القرص
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين تعبئة مقلوبة لسلسلة مخطط**
يتيح Aspose.Slides تعيين تعبئة مقلوبة لسلسلة المخطط داخل منطقة الرسم بهذه الطريقة:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الحصول على مرجع الشريحة عبر مؤشرها.
1. إضافة مخطط ببيانات افتراضية بناءً على النوع المفضل (في المثال أدناه، استخدمنا `ChartType.ClusteredColumn`).
1. الوصول إلى سلسلة المخطط وتعيين لون التعبئة إلى invert.
1. حفظ العرض التقديمي إلى ملف PPTX.

هذا الكود بجافا يوضح العملية:
```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // يضيف سلاسل وفئات جديدة
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // يأخذ أول سلسلة مخطط ويملأ بيانات السلسلة الخاصة بها.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين عكس للسلسلة عند القيمة سالبة**
يتيح Aspose.Slides تعيين العكس عبر خصائص `IChartDataPoint.InvertIfNegative` و `ChartDataPoint.InvertIfNegative`. عندما يتم تعيين العكس باستخدام هذه الخصائص، يعكس نقطة البيانات ألوانها عند الحصول على قيمة سالبة.

هذا الكود بجافا يوضح العملية:
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **مسح بيانات نقطة محددة**
يتيح Aspose.Slides for Android عبر جافا مسح بيانات `DataPoints` لسلسلة مخطط محددة بهذه الطريقة:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على مرجع شريحة عبر مؤشرها.
3. الحصول على مرجع مخطط عبر مؤشره.
4. التنقل عبر جميع `DataPoints` للمخطط وتعيين `XValue` و `YValue` إلى null.
5. مسح جميع `DataPoints` للسلسلة المحددة.
6. كتابة العرض التقديمي المعدل إلى ملف PPTX.

هذا الكود بجافا يوضح العملية:
```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين عرض الفجوة للسلسلة**
يتيح Aspose.Slides for Android عبر جافا تعيين عرض الفجوة لسلسلة عبر خاصية **`GapWidth`** بهذه الطريقة:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة مخطط ببيانات افتراضية.
1. الوصول إلى أي سلسلة مخطط.
1. تعيين خاصية `GapWidth`.
1. كتابة العرض التقديمي المعدل إلى ملف PPTX.

هذا الكود بجافا يوضح لك كيفية تعيين عرض الفجوة لسلسلة:
```java
// ينشئ عرض تقديمي فارغ 
Presentation pres = new Presentation();
try {
    // يصل إلى الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);
    
    // يضيف مخططًا ببيانات افتراضية
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // يحدد فهرس ورقة بيانات المخطط
    int defaultWorksheetIndex = 0;
    
    // يحصل على ورقة عمل بيانات المخطط
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // يضيف سلاسل
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // يضيف فئات
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // يأخذ السلسلة الثانية في المخطط
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // يملأ بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // يضبط قيمة GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // يحفظ العرض التقديمي إلى القرص
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها مخطط واحد؟**

لا يفرض Aspose.Slides حدًا ثابتًا لعدد السلاسل التي يمكن إضافتها. الحد العملي يحدده قابلية قراءة المخطط والذاكرة المتاحة لتطبيقك.

**ماذا لو كانت الأعمدة داخل مجموعة التجميع متقاربة جدًا أو متباعدة جدًا؟**

قم بتعديل إعداد `GapWidth` لتلك السلسلة (أو مجموعة السلاسل الأصلية). زيادة القيمة توسّع المسافة بين الأعمدة، بينما تقليلها يجعلها أقرب إلى بعضها.