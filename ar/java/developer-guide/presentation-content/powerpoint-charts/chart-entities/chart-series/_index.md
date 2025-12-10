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
- العرض التقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية إدارة سلاسل المخطط في Java لبرنامج PowerPoint (PPT/PPTX) من خلال أمثلة عملية على الشفرة وأفضل الممارسات لتعزيز عروض البيانات الخاصة بك."
---

سلسلة هي صف أو عمود من الأرقام مرسومة في مخطط.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ضبط تداخل سلسلة المخطط**

مع خاصية [IChartSeriesOverlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/properties/overlap) يمكنك تحديد مقدار التداخل بين الأشرطة والأعمدة في مخطط ثلاثي الأبعاد (النطاق: -100 إلى 100). تنطبق هذه الخاصية على جميع السلاسل في مجموعة السلاسل الأصلية: هذا عرض للخاصية المناسبة للمجموعة. لذلك، هذه الخاصية للقراءة فقط.

استخدم الخاصية القابلة للقراءة/الكتابة `ParentSeriesGroup.Overlap` لتعيين القيمة المفضلة لـ `Overlap`.

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. أضف مخطط عمودي مجموعة على شريحة.
1. احصل على أول سلسلة في المخطط.
1. احصل على `ParentSeriesGroup` للسلسلة واضبط قيمة التداخل المفضلة للسلسلة.
1. احفظ العرض المعدل إلى ملف PPTX.

يعرض هذا الشيفرة Java كيفية ضبط التداخل لسلسلة مخطط:
```java
Presentation pres = new Presentation();
try {
    // إضافة مخطط
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // ضبط تداخل السلسلة
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // حفظ ملف العرض التقديمي على القرص
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تغيير لون السلسلة**

يسمح Aspose.Slides for Java بتغيير لون السلسلة بهذه الطريقة:

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. أضف مخططًا إلى الشريحة.
1. احصل على السلسلة التي تريد تغيير لونها.
1. اضبط نوع التعبئة ولون التعبئة المفضلين.
1. احفظ العرض المعدل.

يعرض هذا الشيفرة Java كيفية تغيير لون السلسلة:
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

يسمح Aspose.Slides for Java بتغيير لون فئة السلسلة بهذه الطريقة:

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. أضف مخططًا إلى الشريحة.
1. احصل على فئة السلسلة التي تريد تغيير لونها.
1. اضبط نوع التعبئة ولون التعبئة المفضلين.
1. احفظ العرض المعدل.

يعرض هذا الشيفرة Java كيفية تغيير لون فئة السلسلة:
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

في مثالنا (صورة عينة)،

* الأعمدة هي *Series 1* و*Series 2* و*Series 3*؛
* الصفوف هي *Category 1* و*Category 2* و*Category 3* و*Category 4*.

يسمح Aspose.Slides for Java بتحديث أو تغيير اسم السلسلة في بيانات المخطط ووسيلة الإيضاح.

يعرض هذا الشيفرة Java كيفية تغيير اسم السلسلة في بيانات المخطط `ChartDataWorkbook`:
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


يعرض هذا الشيفرة Java كيفية تغيير اسم السلسلة في وسيلة الإيضاح عبر `Series`:
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


## **ضبط لون تعبئة سلسلة المخطط**

يسمح Aspose.Slides for Java بتعيين لون تعبئة تلقائي لسلاسل المخطط داخل منطقة الرسم بهذه الطريقة:

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة عبر فهرستها.
1. أضف مخططًا ببيانات افتراضية بناءً على النوع المفضل لديك (في المثال أدناه، استخدمنا `ChartType.ClusteredColumn`).
1. احصل على سلسلة المخطط واضبط لون التعبئة إلى تلقائي.
1. احفظ العرض إلى ملف PPTX.

يعرض هذا الشيفرة Java كيفية تعيين لون تعبئة تلقائي لسلسلة مخطط:
```java
Presentation pres = new Presentation();
try {
    // إنشاء مخطط عمود مجمع
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // يضبط تنسيق تعبئة السلسلة إلى تلقائي
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // يحفظ ملف العرض التقديمي على القرص
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **ضبط لون تعبئة عكسي لسلسلة مخطط**
يسمح Aspose.Slides بتعيين لون تعبئة عكسي لسلاسل المخطط داخل منطقة الرسم بهذه الطريقة:

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. احصل على مرجع الشريحة عبر فهرستها.
1. أضف مخططًا ببيانات افتراضية بناءً على النوع المفضل لديك (في المثال أدناه، استخدمنا `ChartType.ClusteredColumn`).
1. احصل على سلسلة المخطط واضبط لون التعبئة إلى عكسي.
1. احفظ العرض إلى ملف PPTX.

يعرض هذا الشيفرة Java العملية:
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


## **ضبط عكس السلسلة عندما تكون القيمة سلبية**
يسمح Aspose.Slides بضبط العكس عبر خاصيتي `IChartDataPoint.InvertIfNegative` و`ChartDataPoint.InvertIfNegative`. عندما يتم ضبط العكس باستخدام الخصائص، يعكس نقطة البيانات ألوانها عند حصولها على قيمة سلبية.

يعرض هذا الشيفرة Java العملية:
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
يسمح Aspose.Slides for Java بمسح بيانات `DataPoints` لسلسلة مخطط معينة بهذه الطريقة:

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على مرجع شريحة عبر فهرستها.
3. احصل على مرجع مخطط عبر فهرسته.
4. استعرض جميع `DataPoints` للمخطط واضبط `XValue` و`YValue` إلى null.
5. امسح جميع `DataPoints` للسلسلة المحددة.
6. احفظ العرض المعدل إلى ملف PPTX.

يعرض هذا الشيفرة Java العملية:
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


## **ضبط عرض الفجوة للسلسلة**
يسمح Aspose.Slides for Java بضبط عرض الفجوة لسلسلة عبر خاصية **`GapWidth`** بهذه الطريقة:

1. أنشئ كائنًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. احصل على الشريحة الأولى.
1. أضف مخططًا ببيانات افتراضية.
1. احصل على أي سلسلة مخطط.
1. اضبط خاصية `GapWidth`.
1. احفظ العرض المعدل إلى ملف PPTX.

يعرض هذا الشيفرة Java كيفية ضبط عرض الفجوة لسلسلة:
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
    
    // يحدد قيمة GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // يحفظ العرض التقديمي على القرص
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل هناك حد لعدد السلاسل التي يمكن لمخطط واحد أن يحتويها؟**

لا يفرض Aspose.Slides حداً ثابتاً لعدد السلاسل التي يمكنك إضافتها. الحد العملي يحدده وضوح المخطط والذاكرة المتاحة لتطبيقك.

**ماذا لو كانت الأعمدة داخل مجموعة متقاربة جداً أو متباعدة جداً؟**

قم بضبط إعداد `GapWidth` لتلك السلسلة (أو مجموعة السلاسل الأصلية). زيادة القيمة توسع الفجوة بين الأعمدة، وتقليلها يقربها من بعضها.