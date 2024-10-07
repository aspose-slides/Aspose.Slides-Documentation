---
title: سلسلة الرسوم البيانية
type: docs
url: /java/chart-series/
keywords: "سلسلة الرسوم البيانية، لون السلسلة، عرض PowerPoint، جافا، Aspose.Slides لجافا"
description: "سلسلة الرسوم البيانية في عروض PowerPoint في جافا"
---

السلسلة هي صف أو عمود من الأرقام المرسومة في الرسم البياني.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تعيين تداخل سلسلة الرسوم البيانية**

باستخدام خاصية [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap)، يمكنك تحديد مقدار تداخل الأشرطة والأعمدة في الرسم البياني ثنائي الأبعاد (النطاق: -100 إلى 100). تنطبق هذه الخاصية على جميع السلاسل في مجموعة السلاسل الأم: هذه هي إسقاط الخاصية المناسبة للمجموعة. لذلك، هذه الخاصية للقراءة فقط.

استخدم خاصية `ParentSeriesGroup.Overlap` القابلة للقراءة/الكتابة لتعيين القيمة المفضلة لديك لـ `Overlap`.

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. أضف مخطط عمودي متراص على شريحة.
1. الوصول إلى السلسلة الأولى في الرسم البياني.
1. الوصول إلى `ParentSeriesGroup` الخاص بسلسلة الرسم البياني واضبط قيمة التداخل المفضلة لديك للسلسلة.
1. اكتب العرض المعدل إلى ملف PPTX.

توضح لك هذه الشيفرة الجافا كيفية تعيين التداخل لسلسلة الرسم البياني:

```java
Presentation pres = new Presentation();
try {
    // إضافة رسم بياني
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // تعيين تداخل السلسلة
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // كتابة ملف العرض إلى القرص
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغيير لون السلسلة**
يسمح Aspose.Slides لجافا بتغيير لون السلسلة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. أضف مخططًا على الشريحة.
1. الوصول إلى السلسلة التي تريد تغيير لونها.
1. قم بتعيين نوع التعبئة المفضل لديك ولون التعبئة.
1. احفظ العرض المعدل.

توضح لك هذه الشيفرة الجافا كيفية تغيير لون السلسلة:

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
يسمح Aspose.Slides لجافا بتغيير لون فئة السلسلة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. أضف مخططًا على الشريحة.
1. الوصول إلى فئة السلسلة التي تريد تغيير لونها.
1. قم بتعيين نوع التعبئة المفضل لديك ولون التعبئة.
1. احفظ العرض المعدل.

توضح لك هذه الشيفرة في جافا كيفية تغيير لون فئة السلسلة:

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

بشكل افتراضي، فإن أسماء الأسطورة للرسم البياني هي محتويات الخلايا فوق كل عمود أو صف من البيانات.

في مثالنا (صورة نموذجية)، 

* الأعمدة هي *سلسلة 1، سلسلة 2،* و *سلسلة 3*؛
* الصفوف هي *فئة 1، فئة 2، فئة 3،* و *فئة 4.* 

يسمح Aspose.Slides لجافا بتحديث أو تغيير اسم السلسلة في بيانات الرسم البياني والأسطورة الخاصة بها.

توضح لك هذه الشيفرة الجافا كيفية تغيير اسم السلسلة في بيانات الرسم البياني `ChartDataWorkbook`:

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

توضح لك هذه الشيفرة الجافا كيفية تغيير اسم السلسلة في أسطرتها من خلال `Series`:

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

## **تعيين لون تعبئة سلسلة الرسوم البيانية**

يسمح Aspose.Slides لجافا بتعيين لون التعبئة التلقائي لسلاسل الرسوم البيانية داخل منطقة الرسم بهذا الشكل:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. احصل على إشارة إلى الشريحة من خلال فهرسها.
1. أضف مخططًا مع بيانات افتراضية بناءً على نوعك المفضل (في المثال أدناه، استخدمنا `ChartType.ClusteredColumn`).
1. الوصول إلى سلسلة الرسم البياني وضع لون التعبئة على تلقائي.
1. احفظ العرض في ملف PPTX.

توضح لك هذه الشيفرة الجافا كيفية تعيين لون التعبئة التلقائي لسلسلة الرسوم البيانية:

```java
Presentation pres = new Presentation();
try {
    // إنشاء مخطط عمودي متراص
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // تعيين تنسيق تعبئة السلسلة على تلقائي
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // كتابة ملف العرض إلى القرص
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تعيين عكوس لون التعبئة لسلسلة الرسوم البيانية**
يسمح Aspose.Slides بتعيين لون التعبئة العكسي لسلسلة الرسوم البيانية داخل منطقة الرسم بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. احصل على إشارة إلى الشريحة من خلال فهرسها.
1. أضف مخططًا مع بيانات افتراضية بناءً على نوعك المفضل (في المثال أدناه، استخدمنا `ChartType.ClusteredColumn`).
1. الوصول إلى سلسلة الرسم البياني وضبط لون التعبئة على عكسي.
1. احفظ العرض في ملف PPTX.

توضح لك هذه الشيفرة الجافا كيفية تنفيذ العملية:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // إضافة سلاسل وفئات جديدة
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "سلسلة 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "فئة 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "فئة 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "فئة 3"));

    // يحضر أول سلسلة رسم بياني ويقوم بتعبئة بيانات السلسلة.
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


## **تعيين السلسلة للعكس عندما تكون القيمة سالبة**
يسمح Aspose.Slides بتعيين العكس من خلال الخصائص `IChartDataPoint.InvertIfNegative` و `ChartDataPoint.InvertIfNegative`. عندما يتم ضبط قلب باستخدام الخصائص، فإن نقطة البيانات تعكس ألوانها عندما تحصل على قيمة سالبة.

توضح لك هذه الشيفرة الجافا كيفية تنفيذ العملية:

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
يسمح Aspose.Slides لجافا بمسح بيانات `DataPoints` لسلسلة رسم بياني معينة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على إشارة إلى شريحة من خلال فهرسها.
3. احصل على إشارة إلى مخطط من خلال فهرسه.
4. قم بتمرير جميع `DataPoints` في الرسم البياني واضبط `XValue` و `YValue` على null.
5. مسح جميع `DataPoints` للسلسلة البيانية المحددة.
6. اكتب العرض المعدل إلى ملف PPTX.

توضح لك هذه الشيفرة الجافا كيفية تنفيذ العملية:

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
يسمح Aspose.Slides لجافا بتعيين عرض فجوة السلسلة من خلال خاصية **`GapWidth`** بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الوصول إلى الشريحة الأولى.
3. إضافة مخطط ببيانات افتراضية.
4. الوصول إلى أي سلسلة الرسم البياني.
5. تعيين خاصية `GapWidth`.
6. كتابة العرض المعدل إلى ملف PPTX.

توضح لك هذه الشيفرة الجافا كيفية تعيين عرض الفجوة للسلسلة:

```java
// إنشاء عرض تقديمي فارغ 
Presentation pres = new Presentation();
try {
    // الوصول إلى الشريحة الأولى في العرض التقديمي
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إضافة مخطط ببيانات افتراضية
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // تعيين فهرس ورقة بيانات الرسم البياني
    int defaultWorksheetIndex = 0;
    
    // الحصول على ورقة بيانات الرسم البياني
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // إضافة سلاسل
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "سلسلة 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "سلسلة 2"), chart.getType());
    
    // إضافة فئات
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "فئة 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "فئة 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "فئة 3"));
    
    // الحصول على السلسلة الثانية للرسم البياني
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // تعبئة بيانات السلسلة
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // تعيين قيمة GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // حفظ العرض على القرص
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```