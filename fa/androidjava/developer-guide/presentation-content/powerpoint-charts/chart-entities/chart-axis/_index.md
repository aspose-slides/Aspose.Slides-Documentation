---
title: سفارشی‌سازی محورهای نمودار در ارائه‌های Android
linktitle: محور نمودار
type: docs
url: /fa/androidjava/chart-axis/
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
- Android
- Java
- Aspose.Slides
description: "کشف کنید چگونه از Aspose.Slides برای Android از طریق Java برای سفارشی‌سازی محورهای نمودار در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **مرور کلی**

این مقاله نحوهٔ سفارشی‌سازی محورهای نمودار در Aspose.Slides را توضیح می‌دهد. این مقاله نشان می‌دهد چگونه مقادیر واقعی محور را به‌دست‌آورید، داده‌ها را بین محورها جابجا کنید، محور عمودی یا افقی را برای نمودارهای خطی مخفی کنید، نوع محور دسته‌ای را تغییر دهید، قالب تاریخ برای مقادیر محور دسته‌ای را تنظیم کنید، عنوان یک محور را چرخانده، موقعیت محور را تنظیم کنید و برچسب واحد را بر محور مقدار نمایش دهید.

## **دریافت بیشترین مقادیر در محور عمودی نمودارها**
Aspose.Slides for Android via Java به شما امکان می‌دهد مقادیر حداقل و حداکثر را در یک محور عمودی به‌دست آورید. مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. به اسلاید اول دسترسی پیدا کنید.
1. یک نمودار با داده‌های پیش‌فرض اضافه کنید.
1. مقدار حداکثر واقعی محور را دریافت کنید.
1. مقدار حداقل واقعی محور را دریافت کنید.
1. واحد اصلی واقعی محور را دریافت کنید.
1. واحد فرعی واقعی محور را دریافت کنید.
1. مقیاس واحد اصلی واقعی محور را دریافت کنید.
1. مقیاس واحد فرعی واقعی محور را دریافت کنید.

این کد نمونه—یک پیاده‌سازی از مراحل فوق—نحو دریافت مقادیر مورد نیاز را در Java نشان می‌دهد:

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

## **جابجایی داده‌ها بین محورها**
Aspose.Slides به شما اجازه می‌دهد به‌سرعت داده‌ها را بین محورها جابجا کنید—داده‌های نمایش‌داده‌شده در محور عمودی (y-axis) به محور افقی (x-axis) منتقل می‌شوند و بالعکس.

این کد Java نشان می‌دهد چگونه وظیفه جابجایی داده‌ها بین محورها را در یک نمودار انجام دهید:

```java
Presentation pres = new Presentation();
try {
	IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	// سطرها و ستون‌ها را جابجا می‌کند
	chart.getChartData().switchRowColumn();

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

## **تغییر محور دسته‌ای**

با استفاده از ویژگی **CategoryAxisType** می‌توانید نوع محور دسته‌ای دلخواه خود (**date** یا **text**) را مشخص کنید. این کد در Java عملیات را نشان می‌دهد:

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

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌ای**
Aspose.Slides for Android via Java به شما امکان می‌دهد قالب تاریخ را برای مقدار محور دسته‌ای تنظیم کنید. این عملیات در کد Java زیر نشان داده شده است:

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
Aspose.Slides for Android via Java به شما اجازه می‌دهد زاویه چرخش عنوان محور نمودار را تنظیم کنید. این کد Java این عملیات را نشان می‌دهد:

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

## **تنظیم موقعیت محور در یک محور دسته‌ای یا مقدار**
Aspose.Slides for Android via Java به شما امکان می‌دهد موقعیت محور را در یک محور دسته‌ای یا مقدار تنظیم کنید. این کد Java نشان می‌دهد چگونه این کار را انجام دهید:

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
Aspose.Slides برای Android از طریق Java به شما امکان می‌دهد یک نمودار را طوری تنظیم کنید که برچسب واحد را روی محور مقدار آن نمایش دهد. این کد Java این عملیات را نشان می‌دهد:

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

## **سوالات متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر (Crossing محور) را تنظیم کنم؟**

محورها یک [تنظیم تقاطع](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/axis/#setCrossType-int-) ارائه می‌دهند: می‌توانید انتخاب کنید که در صفر، در بیشینه دسته/مقدار، یا در یک مقدار عددی خاص تقاطع داشته باشند. این برای جابجایی محور X به بالا یا پایین یا برای برجسته‌سازی یک خط پایه مفید است.

**چگونه می‌توانم برچسب‌های تیک را نسبت به محور موقعیت‌دهی کنم (در کنار، خارج، داخل)؟**

موقعیت [برچسب](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) را به «cross»، «outside» یا «inside» تنظیم کنید. این بر خوانایی تأثیر می‌گذارد و به‌خصوص در نمودارهای کوچک به صرفه‌جویی در فضا کمک می‌کند.