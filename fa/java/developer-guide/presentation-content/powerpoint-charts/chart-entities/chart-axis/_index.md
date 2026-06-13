---
title: سفارشی‌سازی محورهای نمودار در ارائه‌ها با استفاده از جاوا
linktitle: محور نمودار
type: docs
url: /fa/java/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دست‌کاری محور
- مدیریت محور
- ویژگی‌های محور
- حداکثر مقدار
- حداقل مقدار
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- ارائه
- جاوا
- Aspose.Slides
description: "کشف کنید چگونه از Aspose.Slides برای جاوا برای سفارشی‌سازی محورهای نمودار در ارائه‌های پاورپوینت برای گزارش‌ها و بصری‌سازی‌ها استفاده کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه محورهای نمودار را در Aspose.Slides سفارشی کنید. این مقاله نشان می‌دهد چگونه مقادیر واقعی محور را دریافت کنید، داده‌ها را بین محورها جابه‌جا کنید، محور عمودی یا افقی نمودارهای خطی را مخفی کنید، نوع محور دسته‌بندی را تغییر دهید، قالب تاریخ برای مقادیر محور دسته‌بندی را تنظیم کنید، عنوان محور را چرخانده، موقعیت محور را تنظیم کنید و برچسب واحد را روی محور مقدار نمایش دهید.

## **دریافت بیشترین مقادیر روی محور عمودی در نمودارها**

Aspose.Slides برای Java به شما امکان می‌دهد مقادیر حداقل و حداکثر را روی یک محور عمودی دریافت کنید. این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. به اسلاید اول دسترسی پیدا کنید.
3. یک نمودار با داده‌های پیش‌فرض اضافه کنید.
4. مقدار حداکثر واقعی روی محور را دریافت کنید.
5. مقدار حداقل واقعی روی محور را دریافت کنید.
6. واحد اصلی واقعی محور را دریافت کنید.
7. واحد جزئی واقعی محور را دریافت کنید.
8. مقیاس واحد اصلی واقعی محور را دریافت کنید.
9. مقیاس واحد جزئی واقعی محور را دریافت کنید.

این کد نمونه — پیاده‌سازی مراحل فوق — نشان می‌دهد چگونه مقادیر مورد نیاز را در Java دریافت کنید:

```java
Presentation pres = new Presentation();
try {
	Chart chart = (Chart)pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
	chart.validateChartLayout();

	double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
	double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

	double majorUnit = chart.getAxes().getHorizontalAxis().getActualMajorUnit();
	double minorUnit = chart.getAxes().getHorizontalAxis().getActualMinorUnit();

	// ارائه را ذخیره می‌کند
	pres.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **جابه‌جایی داده‌ها بین محورها**

Aspose.Slides به شما امکان می‌دهد به سرعت داده‌ها را بین محورها جابه‌جا کنید — داده‌های نمایش داده‌شده روی محور عمودی (y-axis) به محور افقی (x-axis) منتقل می‌شوند و بالعکس.

این کد Java نشان می‌دهد چگونه کار جابه‌جایی داده‌ها بین محورهای یک نمودار را انجام دهید:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// سطرها و ستون‌ها را جابجا می‌کند
	// ارائه را ذخیره می‌کند
	pres.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **غیرفعال‌سازی محور عمودی برای نمودارهای خطی**

این کد Java نشان می‌دهد چگونه محور عمودی را برای یک نمودار خطی مخفی کنید:

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

## **غیرفعال‌سازی محور افقی برای نمودارهای خطی**

این کد نشان می‌دهد چگونه محور افقی را برای یک نمودار خطی مخفی کنید:

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

## **تغییر محور دسته‌بندی**

با استفاده از ویژگی **CategoryAxisType** می‌توانید نوع محور دسته‌بندی مورد نظر خود (**date** یا **text**) را مشخص کنید. این کد در Java عملیات را نشان می‌دهد:

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

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌بندی**

Aspose.Slides برای Java به شما امکان می‌دهد قالب تاریخ برای مقدار محور دسته‌بندی را تنظیم کنید. این عملیات در کد Java زیر نشان داده شده است:

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

## **تنظیم زاویه چرخش برای عنوان محور نمودار**

Aspose.Slides برای Java به شما امکان می‌دهد زاویه چرخش برای عنوان محور نمودار را تنظیم کنید. این کد Java عملیات را نشان می‌دهد:

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

## **تنظیم موقعیت محور روی یک محور دسته‌بندی یا مقدار**

Aspose.Slides برای Java به شما امکان می‌دهد موقعیت محور را در یک محور دسته‌بندی یا مقدار تنظیم کنید. این کد Java نشان می‌دهد چگونه این کار را انجام دهید:

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

## **فعال‌سازی نمایش برچسب واحد روی محور مقدار نمودار**

Aspose.Slides برای Java به شما امکان می‌دهد یک نمودار را طوری پیکربندی کنید که برچسب واحد را روی محور مقدار نشان دهد. این کد Java عملیات را نشان می‌دهد:

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

## **FAQ**

**چگونه مقدار تقاطع یک محور با محور دیگر (axis crossing) را تنظیم کنم؟**

محورها یک [تنظیم تقاطع](https://reference.aspose.com/slides/fa/java/com.aspose.slides/axis/#setCrossType-int-): می‌توانید تقاطع را در صفر، در حداکثر دسته/مقدار یا در یک مقدار عددی خاص تنظیم کنید. این برای جابه‌جایی محور X به بالا یا پایین یا برای تأکید بر یک خط پایه مفید است.

**چگونه می‌توانم برچسب‌های تیک را نسبت به محور موقعیت‌دهی کنم (کنار، بیرون، داخل)؟**

موقعیت [label position](https://reference.aspose.com/slides/fa/java/com.aspose.slides/axis/#setMajorTickMark-int-) را به "cross"، "outside" یا "inside" تنظیم کنید. این کار بر خوانایی تأثیر می‌گذارد و به صرفه‌جویی در فضا کمک می‌کند، به‌ویژه در نمودارهای کوچک.