---
title: سلسلة الرسم البياني
type: docs
url: /androidjava/chart-series/
keywords: "سلسلة الرسم البياني، لون السلسلة، عرض PowerPoint، جافا، Aspose.Slides لـ Android عبر جافا"
description: "سلسلة الرسم البياني في عروض PowerPoint بلغة جافا"
---

السلسلة هي صف أو عمود من الأرقام المرسومة في رسم بياني.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة الرسم البياني**

مع خاصية [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap)، يمكنك تحديد مقدار التداخل الذي يجب أن يحدث بين الأعمدة والشرائط في الرسم البياني ثنائي الأبعاد (النطاق: -100 إلى 100). تنطبق هذه الخاصية على جميع السلاسل في مجموعة السلاسل الأم: هذه هي إسقاط لخاصية المجموعة المناسبة. لذلك، هذه الخاصية للقراءة فقط.

استخدم خاصية `ParentSeriesGroup.Overlap` لقراءة/كتابة لتعيين القيمة المفضلة لديك لـ `Overlap`.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. أضف رسمًا بيانيًا عموديًا متكتلًا على الشريحة.
1. الوصول إلى سلسلة الرسم البياني الأولى.
1. الوصول إلى `ParentSeriesGroup` لسلسلة الرسم البياني وتعيين قيمة التداخل المفضلة لديك للسلسلة.
1. قم بكتابة العرض المعدل إلى ملف PPTX.

يوضح كود جافا هذا كيفية تعيين التداخل لسلسلة الرسم البياني:

```java
Presentation pres = new Presentation();
try {
    // Adds chart
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Sets series overlap
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Writes the presentation file to disk
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغيير لون السلسلة**
يسمح Aspose.Slides لـ Android عبر جافا لك بتغيير لون السلسلة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. أضف الرسم البياني على الشريحة.
1. الوصول إلى السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة المفضل لديك ولون التعبئة.
1. قم بحفظ العرض المعدل.

يوضح كود جافا هذا كيفية تغيير لون السلسلة:

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
يسمح Aspose.Slides لـ Android عبر جافا لك بتغيير لون فئة السلسلة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. أضف الرسم البياني على الشريحة.
1. الوصول إلى فئة السلسلة التي تريد تغيير لونها.
1. تعيين نوع التعبئة المفضل لديك ولون التعبئة.
1. قم بحفظ العرض المعدل.

يوضح كود جافا هذا كيفية تغيير لون فئة السلسلة:

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

افتراضيًا، تكون أسماء الأسطورة للرسم البياني هي محتويات الخلايا الموجودة فوق كل عمود أو صف من البيانات.

في مثالنا (صورة عينة)،

* الأعمدة هي *السلسلة 1، السلسلة 2،* و *السلسلة 3*؛
* الصفوف هي *الفئة 1، الفئة 2، الفئة 3،* و *الفئة 4.* 

يسمح Aspose.Slides لـ Android عبر جافا لك بتحديث أو تغيير اسم السلسلة في بيانات الرسم البياني والأسطورة الخاصة بها.

يوضح كود جافا هذا كيفية تغيير اسم السلسلة في بيانات الرسم البياني `ChartDataWorkbook`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("اسم جديد");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

يوضح كود جافا هذا كيفية تغيير اسم السلسلة في الأسطورة من خلال`Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("اسم جديد");
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين لون التعبئة لسلسلة الرسم البياني**

يسمح Aspose.Slides لـ Android عبر جافا لك بتعيين لون التعبئة التلقائي لسلسلة الرسم البياني داخل منطقة الرسم بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا مع بيانات افتراضية بناءً على النوع المفضل لديك (في المثال أدناه، استخدمنا `ChartType.ClusteredColumn`).
1. الوصول إلى سلسلة الرسم البياني وتعيين لون التعبئة إلى تلقائي.
1. حفظ العرض إلى ملف PPTX.

يوضح كود جافا هذا كيفية تعيين لون التعبئة التلقائي لسلسلة الرسم البياني:

```java
Presentation pres = new Presentation();
try {
    // Creates a clustered column chart
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Sets series fill format to automatic
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Writes the presentation file to disk
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين ألوان تعبئة السلسلة العكسية**
يسمح Aspose.Slides لك بتعيين لون التعبئة العكسي لسلسلة الرسم البياني داخل منطقة الرسم بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة من خلال فهرسها.
1. أضف رسمًا بيانيًا مع بيانات افتراضية بناءً على النوع المفضل لديك (في المثال أدناه، استخدمنا `ChartType.ClusteredColumn`).
1. الوصول إلى سلسلة الرسم البياني وتعيين لون التعبئة إلى عكسي.
1. حفظ العرض إلى ملف PPTX.

يوضح كود جافا هذا العملية:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Adds new series and categories
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Takes the first chart series and populates its series data.
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


## **تعيين السلسلة للتعكس عندما تكون القيمة سلبية**
يسمح Aspose.Slides بتعيين التعكس من خلال الخصائص`IChartDataPoint.InvertIfNegative` و `ChartDataPoint.InvertIfNegative`. عند تعيين التعكس باستخدام الخصائص، تعكس نقطة البيانات ألوانها عندما تحصل على قيمة سالبة. 

يوضح كود جافا هذا العملية:

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

## **مسح بيانات نقاط البيانات المحددة**
يسمح Aspose.Slides لـ Android عبر جافا لك بمسح بيانات `DataPoints` لسلسلة الرسم البياني المحددة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. احصل على مرجع لشريحة من خلال فهرسها.
3. احصل على مرجع لرسم بياني من خلال فهرسه.
4. تكرار عبر جميع `DataPoints` للرسم البياني وتعيين `XValue` و `YValue` إلى فارغ.
5. مسح جميع `DataPoints` للسلسلة المحددة.
6. كتابة العرض المعدل إلى ملف PPTX.

يوضح كود جافا هذا العملية:

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
يسمح Aspose.Slides لـ Android عبر جافا لك بتعيين عرض الفجوة للسلسلة من خلال خاصية **`GapWidth`** بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. أضف الرسم البياني مع بيانات افتراضية.
4. الوصول إلى أي سلسلة من الرسم البياني.
5. تعيين خاصية `GapWidth`.
6. كتابة العرض المعدل إلى ملف PPTX.

يوضح كود جافا هذا كيفية تعيين عرض فجوة السلسلة:

```java
// Creates empty presentation 
Presentation pres = new Presentation();
try {
    // Accesses the presentation's first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adds a chart with default data
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Sets the index of the chart data sheet
    int defaultWorksheetIndex = 0;
    
    // Gets the chart data worksheet
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Adds series
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Adds Categories
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Takes the second chart series
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Populates the series data
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Sets GapWidth value
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Saves presentation to disk
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```