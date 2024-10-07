---
title: محور الرسم البياني
type: docs
url: /java/chart-axis/
keywords: "محور الرسم البياني PowerPoint، الرسوم البيانية التقديمية، جافا، معالجة محور الرسم البياني، بيانات الرسم البياني"
description: "كيفية تحرير محور الرسم البياني PowerPoint في جافا"
---


## **الحصول على القيم القصوى على المحور العمودي في الرسوم البيانية**
تسمح لك Aspose.Slides لـ Java بالحصول على القيم الدنيا والقصوى على محور عمودي. تبع هذه الخطوات:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. الوصول إلى الشريحة الأولى.
1. إضافة رسم بياني بالبيانات الافتراضية.
1. الحصول على القيمة القصوى الفعلية على المحور.
1. الحصول على القيمة الدنيا الفعلية على المحور.
1. الحصول على الوحدة الرئيسية الفعلية للمحور.
1. الحصول على الوحدة الفرعية الفعلية للمحور.
1. الحصول على مقياس الوحدة الرئيسية الفعلية للمحور.
1. الحصول على مقياس الوحدة الفرعية الفعلية للمحور.

يوضح لك هذا الكود المثال—تطبيق للخطوات المذكورة أعلاه—كيفية الحصول على القيم المطلوبة في جافا:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// حفظ العرض التقديمي
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **تبديل البيانات بين المحاور**
تتيح لك Aspose.Slides بسرعة تبديل البيانات بين المحاور—البيانات المعروضة على المحور العمودي (محور Y) تنتقل إلى المحور الأفقي (محور X) والعكس صحيح.

يوضح لك هذا الكود في جافا كيفية تنفيذ مهمة تبديل البيانات بين المحاور على رسم بياني:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// تبديل الصفوف والأعمدة
	chart.getChartData().switchRowColumn();

	// حفظ العرض التقديمي
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **تعطيل المحور العمودي للرسوم البيانية الخطية**

يوضح لك هذا الكود في جافا كيفية إخفاء المحور العمودي لرسم بياني خطي:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getVerticalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **تعطيل المحور الأفقي للرسوم البيانية الخطية**

يوضح لك هذا الكود كيفية إخفاء المحور الأفقي لرسم بياني خطي:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
	chart.getAxes().getHorizontalAxis().setVisible(false);

	pres.save("chart.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **تغيير محور الفئة**

باستخدام خاصية **CategoryAxisType**، يمكنك تحديد نوع محور الفئة المفضل لديك (**تاريخ** أو **نص**). هذا الكود في جافا يوضح العملية:

```java
Presentation presentation = new Presentation("ExistingChart.pptx");
try {
	IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
	chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
	chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
	chart.getAxes().getHorizontalAxis().setMajorUnit(1);
	chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);
	presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

## **تعيين تنسيق تاريخ لقيمة محور الفئة**
تتيح لك Aspose.Slides لـ Java تعيين تنسيق تاريخ لقيمة محور الفئة. العملية موضحة في هذا الكود في جافا:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B2", 1));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B3", 2));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B4", 3));
    series.getDataPoints().addDataPointForLineSeries(wb.getCell(0, "B5", 4));
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");
	
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static String convertToOADate(GregorianCalendar date) throws ParseException
{
    double oaDate;
    SimpleDateFormat myFormat = new SimpleDateFormat("dd MM yyyy");
    java.util.Date baseDate = myFormat.parse("30 12 1899");
    Long days = TimeUnit.DAYS.convert(date.getTimeInMillis() - baseDate.getTime(), TimeUnit.MILLISECONDS);
    oaDate = (double) days + ((double) date.get(Calendar.HOUR_OF_DAY) / 24) + ((double) date.get(Calendar.MINUTE) / (60 * 24)) + ((double) date.get(Calendar.SECOND) / (60 * 24 * 60));
    return String.valueOf(oaDate);
}
```

## **تعيين زاوية الدوران لعنوان محور الرسم البياني**
تتيح لك Aspose.Slides لـ Java تعيين زاوية الدوران لعنوان محور الرسم البياني. هذا الكود في جافا يوضح العملية:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

```

## **تعيين محور الوضع في محور فئة أو قيمة**
تتيح لك Aspose.Slides لـ Java تعيين محور الوضع في محور فئة أو قيمة. يوضح لك هذا الكود في جافا كيفية تنفيذ المهمة:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تمكين عرض وحدة التسمية على محور قيمة الرسم البياني**
تتيح لك Aspose.Slides لـ Java تكوين رسم بياني لعرض وحدة تسمية على محور قيمته. هذا الكود في جافا يوضح العملية:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```