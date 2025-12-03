---
title: إدارة سلاسل بيانات المخطط في العروض التقديمية باستخدام Java
linktitle: سلسلة البيانات
type: docs
url: /ar/java/chart-series/
keywords:
- سلسلة المخطط
- تداخل السلسلة
- لون السلسلة
- لون الفئة
- اسم السلسلة
- نقطة البيانات
- فجوة السلسلة
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: تعلم كيفية إدارة سلاسل المخطط في Java لـ PowerPoint (PPT/PPTX) مع أمثلة عملية للكود وأفضل الممارسات لتعزيز عروض البيانات الخاصة بك.
---

السلسلة هي صف أو عمود من الأرقام يتم رسمه في مخطط.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **تحديد تداخل سلسلة المخطط**

باستخدام خاصية [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) يمكنك تحديد مقدار تداخل الأعمدة والأشرطة في مخطط ثنائي الأبعاد (النطاق: -100 إلى 100). تُطبق هذه الخاصية على جميع سلاسل مجموعة السلسلة الأصلية: هذه نسخة من خاصية المجموعة المناسبة. لذلك، هذه الخاصية للقراءة فقط.  

استخدم خاصية `ParentSeriesGroup.Overlap` القابلة للقراءة والكتابة لتعيين القيمة المفضلة لـ `Overlap`.

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. أضف مخطط أعمدة مُجمّع إلى شريحة.
1. الوصول إلى أول سلسلة في المخطط.
1. الوصول إلى `ParentSeriesGroup` لسلسلة المخطط وتعيين قيمة التداخل المفضلة للسلسلة.
1. احفظ العرض التقديمي المعدّل إلى ملف PPTX.

هذا كود Java يوضح لك كيفية تعيين التداخل لسلسلة مخطط:
```java
Presentation pres = new Presentation();
try {
    // يضيف مخطط
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // يضبط تداخل السلسلة
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // يكتب ملف العرض التقديمي إلى القرص
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تغيير لون السلسلة**

Aspose.Slides for Java يسمح لك بتغيير لون السلسلة بهذه الطريقة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. أضف مخططًا إلى الشريحة.
1. الوصول إلى السلسلة التي تريد تغيير لونها.
1. عيّن نوع التعبئة ولون التعبئة المفضلين.
1. احفظ العرض التقديمي المعدّل.

هذا كود Java يوضح لك كيفية تغيير لون السلسلة:
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

Aspose.Slides for Java يسمح لك بتغيير لون فئة السلسلة بهذه الطريقة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. أضف مخططًا إلى الشريحة.
1. الوصول إلى فئة السلسلة التي تريد تغيير لونها.
1. عيّن نوع التعبئة ولون التعبئة المفضلين.
1. احفظ العرض التقديمي المعدّل.

هذا كود Java يوضح لك كيفية تغيير لون فئة السلسلة:
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

افتراضيًا، أسماء وسيلة الإيضاح لمخطط هي محتوى الخلايا التي تقع فوق كل عمود أو صف من البيانات.

في مثالنا (الصورة النموذجية),

* الأعمدة هي *Series 1, Series 2,* و *Series 3*؛
* الصفوف هي *Category 1, Category 2, Category 3,* و *Category 4*.

Aspose.Slides for Java يسمح لك بتحديث أو تغيير اسم السلسلة في بيانات المخطط ووسيلة الإيضاح.

هذا كود Java يوضح لك كيفية تغيير اسم السلسلة في بيانات المخطط `ChartDataWorkbook`:
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


هذا كود Java يوضح لك كيفية تغيير اسم السلسلة في وسيلة الإيضاح عبر `Series`:
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


## **تحديد لون تعبئة سلسلة المخطط**

Aspose.Slides for Java يسمح لك بتحديد لون التعبئة التلقائي لسلسلة المخطط داخل مساحة الرسم بهذه الطريقة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. احصل على مرجع شريحة باستخدام فهرسها.
1. أضف مخططًا ببيانات افتراضية بناءً على النوع المفضل لديك (في المثال أدناه استخدمنا `ChartType.ClusteredColumn`).
1. الوصول إلى سلسلة المخطط وتعيين لون التعبئة إلى Automatic.
1. احفظ العرض التقديمي إلى ملف PPTX.

هذا كود Java يوضح لك كيفية تحديد لون التعبئة التلقائي لسلسلة مخطط:
```java
Presentation pres = new Presentation();
try {
    // ينشئ مخطط عمودي مجمع
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // يضبط تنسيق تعبئة السلسلة إلى تلقائي
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // يكتب ملف العرض التقديمي إلى القرص
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تعيين ألوان تعبئة عكسية لسلسلة المخطط**

Aspose.Slides يسمح لك بتعيين لون التعبئة العكسي لسلسلة المخطط داخل مساحة الرسم بهذه الطريقة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. احصل على مرجع شريحة باستخدام فهرسها.
1. أضف مخططًا ببيانات افتراضية بناءً على النوع المفضل لديك (في المثال أدناه استخدمنا `ChartType.ClusteredColumn`).
1. الوصول إلى سلسلة المخطط وتعيين لون التعبئة إلى invert.
1. احفظ العرض التقديمي إلى ملف PPTX.

هذا كود Java يوضح العملية:
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

    // يأخذ أول سلسلة مخطط ويملأ بيانات السلسلة الخاصة بها
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


## **تعيين السلسلة لتنعكس عندما تكون القيمة سلبية**

Aspose.Slides يسمح لك بتعيين الانعكاس عبر خاصيتي `IChartDataPoint.InvertIfNegative` و `ChartDataPoint.InvertIfNegative`. عندما يتم تعيين الانعكاس باستخدام هذه الخصائص، تعكس نقطة البيانات ألوانها عندما تحصل على قيمة سلبية.

هذا كود Java يوضح العملية:
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

Aspose.Slides for Java يسمح لك بمسح بيانات `DataPoints` لسلسلة مخطط معينة بهذه الطريقة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع الشريحة باستخدام فهرسها.
3. احصل على مرجع المخطط باستخدام فهرسه.
4. تجول عبر جميع `DataPoints` للمخطط وعين `XValue` و `YValue` إلى null.
5. امسح جميع`DataPoints` لسلسلة مخطط محددة.
6. احفظ العرض التقديمي المعدّل إلى ملف PPTX.

هذا كود Java يوضح العملية:
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

Aspose.Slides for Java يسمح لك بتعيين عرض الفجوة لسلسلة عبر خاصية **`GapWidth`** بهذه الطريقة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. أضف مخططًا ببيانات افتراضية.
1. الوصول إلى أي سلسلة في المخطط.
1. عيّن خاصية `GapWidth`.
1. احفظ العرض التقديمي المعدّل إلى ملف PPTX.

هذا كود Java يوضح لك كيفية تعيين عرض الفجوة لسلسلة:
```java
// ينشئ عرض تقديمي فارغ 
Presentation pres = new Presentation();
try {
    // يحصل على الشريحة الأولى في العرض التقديمي
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
    
    // يضيف الفئات
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
    
    // يحدد قيمة GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // يحفظ العرض التقديمي إلى القرص
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل هناك حد لعدد السلاسل التي يمكن أن يحتويها مخطط واحد؟**

Aspose.Slides لا يفرض حدًا ثابتًا على عدد السلاسل التي يمكنك إضافتها. الحد العملي يحدده وضوح المخطط والذاكرة المتاحة لتطبيقك.

**ماذا لو كانت الأعمدة داخل مجموعة ما متقربة جدًا أو متباعدة جدًا؟**

اضبط إعداد `GapWidth` لتلك السلسلة (أو مجموعة السلسلة الأصلية). زيادة القيمة توسّع المسافة بين الأعمدة، بينما تقليلها يقرِّبها من بعضها.