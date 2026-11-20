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
- دستکاری محور
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
description: "کشف کنید چگونه می‌توانید از Aspose.Slides برای Android از طریق Java برای سفارشی‌سازی محورهای نمودار در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه می‌توان محورهای نمودار را در Aspose.Slides برای Android با استفاده از Java سفارشی کرد. این مطلب شامل مقادیر محاسبه‌شده محور، جابجایی سطرها و ستون‌های نمودار، قابلیت مشاهده محور، فواصل برچسب‌های دسته‌ای و علامت‌گذاری‌های تیک، دسته‌بندی‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت‌گذاری محور، واحدهای نمایش و مقیاس لگاریتمی را پوشش می‌دهد.

## **دریافت بیشترین مقادیر محور عمودی در نمودارها**

یک [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، برای به‌روز بودن طرح نمودار، متد [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) را فراخوانی کنید.

متدهای [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) و [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) را برای محدوده‌های محور بخوانید و متدهای [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) و [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) را برای فواصل تیک‌ها استفاده کنید. متدهای [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) و [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) مقیاس‌های واحد زمان را ارائه می‌دهند که برای محورهاى تاریخ مرتبط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره می‌کند و نمودار را ذخیره می‌نماید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **جابه‌جایی داده‌ها بین محورها**

از متد [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی تبدیل به سری می‌شود و هر سری قبلی تبدیل به دسته. این کار نحوه گروه‌بندی داده‌ها را تغییر می‌دهد؛ محورهای افقی و عمودی را جابه‌جا نمی‌کند. مثال از متد [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) برای اتصال داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل سطر سرایند و ستون دسته، پیش از جابه‌جایی سطرها و ستون‌ها استفاده می‌کند. سپس نموداری با چهار سری و سه دسته ذخیره می‌نماید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **معکوس کردن ترتیب رسم یک محور**

از متد [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) برای معکوس کردن یک محور دسته یا مقدار استفاده کنید. به عنوان مثال، یک نمودار میله‌ای افقی می‌تواند مراحل پروژه را از بالا به پایین به همان ترتیب برگه‌کار نشان دهد: برنامه‌ریزی، توسعه، تست. معکوس کردن یک محور جهت رسم را تغییر می‌دهد؛ داده‌های برگه‌کار را مرتب یا جابه‌جا نمی‌کند. برای مقایسه، متد [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) نقش سری‌ها و دسته‌ها را تعویض می‌کند.

مثال زیر یک نمودار میله‌ای افقی با سه مرحله و یک سری ایجاد می‌کند. ارائه‌ای شامل سه اسلاید ذخیره می‌کند: ترتیب عادی، دسته‌های معکوس و مقادیر معکوس. هر کپی از همان مجموعه داده‌ها استفاده می‌کند و فقط یک محور در هر کپی معکوس شده است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // اسلاید ۲: نمایش اولین دسته در بالا.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // محور مقدار افقی را در پایین نگه دارید.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // اسلاید ۳: فقط مقیاس عددی افقی را معکوس کنید.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

معکوس کردن یک محور می‌تواند محور عمودی را به طرف مخالف نمودار منتقل کند. متد [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) تعیین می‌کند که محور دیگر در کجا محور تنظیم‌شده را قطع کند. در اسلاید ۲، فراخوانی آن با `CrossesType.Maximum` روی محور دسته معکوس، محور مقدار افقی را در پایین نگه می‌دارد. برای تعیین نقطه تقاطع خاص، از متد [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) استفاده کنید. هنگام تغییر جهت، تنظیمات تقاطع را بررسی کنید، به‌ویژه اگر نمودار پیش‌ازاین یک نقطه تقاطع سفارشی داشته باشد. برای بازگرداندن جهت عادی، `setPlotOrderReversed` را با `false` فراخوانی کنید؛ تنظیمات تقاطع جداگانه هستند.

| ترتیب عادی (اسلاید ۱) | دسته‌های معکوس (اسلاید ۲) | مقادیر معکوس (اسلاید ۳) |
| --- | --- | --- |
| ![نمودار میله‌ای افقی با ترتیب عادی دسته و محور مقدار](axis-order-normal.png) | ![نمودار میله‌ای افقی با نمایش دسته‌ها از بالا به پایین](axis-order-categories-reversed.png) | ![نمودار میله‌ای افقی با محور مقدار معکوس و صفر در سمت راست](axis-order-values-reversed.png) |
| دسته‌ها از پایین به بالا می‌روند؛ مقادیر از چپ به راست افزایش می‌یابند. | برنامه‌ریزی، توسعه و تست از بالا به پایین نمایش داده می‌شوند. مقادیر و ترتیب سطرهای برگه‌کار تغییر نکرده‌اند. | دسته‌ها ترتیب عادی خود را حفظ می‌کنند؛ مقادیر از راست به چپ افزایش می‌یابند. محور دسته در نقطه صفر سمت راست عبور می‌کند. |

## **غیرفعال کردن محور عمودی برای نمودارهای خطی**

متد [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) را با مقدار `false` روی محور عمودی فراخوانی کنید تا آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌نماید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **غیرفعال کردن محور افقی برای نمودارهای خطی**

متد [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) را با مقدار `false` روی محور افقی فراخوانی کنید تا آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌نماید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **نمایش یا مخفی کردن خطوط توری نمودار**

متدهای [getShowMajorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMajorGridLines--) و [getShowMinorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMinorGridLines--) برای بررسی اینکه یک محور کدام خطوط توری را نمایش می‌دهد، فراخوانی کنید. این متدها وضعیت جاری قابل مشاهده را برمی‌گردانند. برای نمایش خطوط توری جزئی، از متد [getMinorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) استفاده کنید و پر کردن خط را به یک رنگ ثابت و قابل مشاهده تنظیم کنید. برای مخفی کردن آن‌ها، پر کردن را به [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/#NoFill) تغییر دهید. به همان صورت برای خطوط توری اصلی، از متد [getMajorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) استفاده کنید. تغییر پر کردن، قابلیت مشاهده محور و علامت‌های تیک را حفظ می‌کند.

محور عمودی این نمودار ستونی خوشه‌ای در ابتدا فقط خطوط توری اصلی را نشان می‌دهد. مثال خطوط توری جزئی را به رنگ نارنجی تیره نمایش می‌دهد، سپس قبل از ذخیره ارائه آن‌ها را دوباره مخفی می‌کند. در هر گام، وضعیت قابل مشاهده خطوط توری چاپ می‌شود.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(Color.rgb(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| خطوط توری جزئی فعال | خطوط توری جزئی مخفی |
| --- | --- |
| ![خطوط توری جزئی نارنجی بین خطوط توری اصلی روی محور عمودی](minor-gridlines-enabled.png) | ![همان نمودار ستونی فقط با خطوط توری اصلی قابل مشاهده](minor-gridlines-hidden.png) |

## **تغییر یک محور دسته‌ای**

از متد [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) برای انتخاب محور دسته‌ای تاریخ یا متن استفاده کنید. این مثال به `ExistingChart.pptx` نیاز دارد که در اولین اسلاید یک نمودار به‌عنوان اولین شکل دارد و سلول‌های دسته شامل مقادیر عددی تاریخ اکسل هستند. محور افقی را به یک محور تاریخ تغییر می‌دهد. با فراخوانی متد [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) با مقدار `false`، [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) با مقدار `1` و [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) با `TimeUnitType.Months`، تیک‌های اصلی را در فواصل یک ماهی تنظیم می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **تشخیص نوع محور دسته‌ای از داده‌ها**

پس از پر کردن دسته‌ها، متد [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) را فراخوانی کنید و سپس با [getCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getCategoryAxisType--) نوع انتخابی را بررسی کنید. این کار زمانی مفید است که همان نمودار یا متن‌های برچسب یا مقادیر عددی تاریخ دریافت کند. این متد پس از فراخوانی نوع را تعیین می‌کند؛ حالت پایداری که بعداً به‌روزرسانی داده‌ها را دوباره ارزیابی کند، فعال نمی‌شود. پس از جایگزینی دسته‌ها، دوباره آن را فراخوانی کنید.

مثال زیر یک نمودار با دسته‌های متنی ایجاد می‌کند و زمانی که نوع انتخابی `CategoryAxisType.Text` باشد، `true` چاپ می‌کند. سپس مقادیر سلول‌های دسته را با تاریخ‌ها جایگزین می‌کند و دوباره متد را فراخوانی می‌کند؛ این بار وقتی نوع انتخابی `CategoryAxisType.Date` باشد، `true` چاپ می‌شود. تاریخ‌ها به عنوان مقادیر عددی OLE Automation ذخیره می‌شوند و به‌عنوان تعداد روزهای گذشته از 30 دسامبر 1899 محاسبه می‌شوند، نه به‌صورت رشته تاریخ. هر دو تقویم از UTC استفاده می‌کنند و پیش از تنظیم تاریخ‌ها پاک می‌شوند تا زمان صرف‌نظر از DST و زمان روز تأثیری نداشته باشد. متد [setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) کنترل می‌کند که این مقادیر چگونه نمایش داده شوند؛ متنی را به تاریخ عددی تبدیل نمی‌کند. برای اطلاعات بیشتر درباره سلول‌های دسته، به بخش [Chart Workbook](/slides/fa/androidjava/chart-workbook/) مراجعه کنید.

از تشخیص خودکار زمانی استفاده کنید که ورودی حتماً شامل دسته‌های متنی یا تاریخ‌های عددی باشد، همانند این مثال. برای برچسب‌های عددی ساده، دسته‌های ترکیبی یا داده‌های خالی، به‌صورت صریح متد [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisType-int-) را فراخوانی کنید تا با معنای موردنظر مطابقت داشته باشد. مقادیر عددی به‌تنهایی نشان‌دهنده این نیستند که دسته‌ها تاریخ هستند.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    String[] labels = { "First", "Second", "Third" };

    for (int i = 0; i < labels.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // درست

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);
    int[][] dates = { { 2026, Calendar.JANUARY, 1 }, { 2026, Calendar.JANUARY, 2 }, { 2026, Calendar.FEBRUARY, 1 } };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(dates[i][0], dates[i][1], dates[i][2]);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        categoryCell.setValue(serialDate);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // درست

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کنترل فواصل برچسب‌های محور دسته‌ای**

زمانی که یک نمودار دارای تعداد زیادی دسته است، می‌توانید تعداد برچسب‌های محور قابل مشاهده را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. ابتدا متد [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) را با مقدار `false` فراخوانی کنید، سپس فاصله دسته دلخواه را به متد [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) منتقل کنید. برای دسته‌های متنی که به ترتیب عادی هستند، شمارش از اولین دسته آغاز می‌شود:

| فاصله | برچسب‌های نمایش داده‌شده در مثال |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

فاصله `3` هر سومین برچسب را نمایش می‌دهد و دو برچسب بین هر دو برچسب نمایان مخفی می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصله خودکار بر پایه فضای موجود یک مقدار انتخاب می‌کند؛ لزوماً هر برچسب را نمایش نمی‌دهد.

علامت‌های تیک کنترل جداگانه‌ای دارند. متد [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) را با مقدار `false` فراخوانی کنید و با استفاده از [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) فواصل آن‌ها را تنظیم کنید. برای مثال، مقدار `1` یک علامت تیک در هر فاصله دسته حفظ می‌کند در حالی که برچسب‌ها تنها هر سومین دسته نمایش داده می‌شوند. از متد [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) با سبک قابل مشاهده استفاده کنید تا نتیجه را ببینید. فراخوانی هر یک از تنظیم‌کننده‌های فاصله خودکار با مقدار `true` دوباره به نمودار اجازه می‌دهد همان فاصله را انتخاب کند.

مثال خودمحافظ زیر ۲۴ دسته و یک سری ایجاد می‌کند، سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌نماید: فاصله خودکار، فاصله دستی برچسب‌ها با علامت‌های تیک مستقل، و بازگرداندن فاصله خودکار. دو کپی داده‌های اصلی نمودار را حفظ می‌کنند. ارائه ورودی لازم نیست. متن برچسب افقی باعث می‌شود تراکم به‌راحتی مشاهده شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // اسلاید ۲: هر سومین برچسب را نمایش دهید، اما برای هر دسته یک علامت تیک نگه دارید.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // اسلاید ۳: بگذارید نمودار دوباره هر دو فاصله را انتخاب کند.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**فاصله خودکار (اسلاید ۱):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و به دو خط می‌پیچد. نتیجه خودکار ممکن است بسته به اندازه نمودار، قلم‌ها و رندر متفاوت باشد.

![فاصله خودکار برچسب‌های دسته با تمام ۲۴ ستون قابل مشاهده](category-axis-automatic.png)

**فاصله دستی (اسلاید ۲):** هر سومین برچسب روی یک خط نمایش داده می‌شود، در حالی که علامت‌های تیک در هر فاصله دسته باقی می‌مانند. تمام ۲۴ ستون، از جمله آن‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده هستند. اسلاید ۳ ظاهر خودکار نشان داده شده در بالا را بازمی‌گرداند.

![فاصله دستی برچسب‌های دسته به مقدار سه با تمام ۲۴ ستون قابل مشاهده](category-axis-manual.png)

### **انتخاب محور و فاصله صحیح**

از این فاصله‑شمارش‑دسته برای محور دسته‌ای متنی استفاده کنید، مانند محور دسته‌ای یک نمودار ستونی، خطی، ناحیه‌ای یا میله‌ای. در نمودار ستونی، این محور افقی است. در نمودار میله‌ای افقی، محور دسته‌ای عمودی است، بنابراین این تنظیمات را بر محور بازگردانده شده توسط [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) اعمال کنید. فاصله علامت‌های تیک همچنین برای محور سری در نمودارهایی که دارای آن هستند، اعمال می‌شود.

از تنظیم فاصله برچسب‌های دسته برای تعیین مقیاس عددی یک محور مقدار استفاده نکنید. بر روی یک محور مقدار، متد [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) اختلاف مقدار را تعیین می‌کند: به عنوان مثال، واحد اصلی `10` تیک‌ها را در مقادیر 0، 10، 20 و … تولید می‌کند وقتی محور از صفر شروع شود. فاصله برچسب دسته‌ای `3` به‌جای آن موقعیت‌های دسته‌ای را می‌شمارد، صرف‌نظر از مقادیر داده‌ای آن‌ها. نمودارهای پراکندگی و حبابی از محورهای مقدار استفاده می‌کنند نه محور دسته‌ای متنی. برای محور تاریخ، از واحدهای زمان اصلی و مقیاس‌ها همان‌طور که در بخش [تغییر یک محور دسته‌ای](#change-a-category-axis) توضیح داده شد، استفاده کنید.

## **تنظیم فرمت تاریخ برای مقادیر محور دسته‌ای**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌صورت شماره سریال OLE Automation در اولین کاربرگ (شاخص `0`) ذخیره می‌شوند و به‌عنوان تعداد روزهای گذشته از 30 دسامبر 1899 محاسبه می‌شوند. هر دو تقویم از UTC استفاده می‌کنند و قبل از تنظیم تاریخ‌ها پاک می‌شوند تا DST و زمان روز جاری بر محاسبه تأثیر نگذارند. از متد [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) با مقدار `CategoryAxisType.Date`، سپس متد [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) را با مقدار `false` فراخوانی کنید و `yyyy` را به متد [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) پاس بدهید تا برچسب‌های دسته چهار رقمی سال را مستقل از قالب‌بندی سلول نمایش دهند.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم زاویه چرخش برای عنوان محور نمودار**

متد [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) را با مقدار `true` روی محور عمودی فراخوانی کنید، متن عنوان را ارائه دهید و با متد [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) عنوان را بچرخانید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را با عنوان محور مقدار خود را به‌صورت 90 درجه می‌چرخاند و ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم موقعیت محور روی محور دسته یا مقدار**

از متد [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) برای کنترل اینکه آیا محور مقدار در میان دسته‌ها یا در علامت‌های تیک دسته تقاطع کند استفاده کنید. این تنظیم برای محورهاى دسته‌ای اعمال می‌شود. مثال این ویژگی را روی محور دسته‌ای افقی یک نمودار ستونی به مقدار `true` تنظیم کرده و نتیجه را ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم واحد نمایش روی محور مقدار نمودار**

از متد [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) برای مقیاس‌بندی برچسب‌های محور مقدار بدون تغییر داده‌های زیرین استفاده کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) به `Millions`، مقدار 60 000 000 به‌صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر محور عمودی آن اعمال می‌نماید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پیکربندی یک محور مقدار لگاریتمی**

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت در چندین مرتبه اندازه متفاوت باشند. به‌عنوان مثال، یک سرویس ممکن است 10، 100، 1 000، 10 000 و 100 000 درخواست در پنج بازه زمانی دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر به هم جمع می‌شوند. مقیاس لگاریتمی رشد نسبی آن‌ها را راحت‌تر مقایسه می‌کند: فواصل برابر نشان‌دهنده نسبت‌های برابر هستند نه اختلاف‌های عددی برابر.

متد [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) را با مقدار `true` روی محور مقدار فراخوانی کنید و با متد [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) پایه مورد نظر را انتخاب کنید. این کار نحوه نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. خط روند یک ویژگی جداگانه است که رابطهٔ برازش‌شده‌ای در داده‌ها را نشان می‌دهد.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خطی یا ستونی، محور مقدار توسط [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) بازگردانده می‌شود. برای یک نمودار میله‌ای افقی، توسط [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) بازگردانده می‌شود. نمودارهای پراکندگی و حبابی دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو را انتخاب کنید. لطفاً مقیاس لگاریتمی را بر محور دسته اعمال نکنید.

پایه پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX می‌توانید پایه‌ای بین `2` تا `1000` (شامل) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایه `10` توان‌های متوالی مثل 10، 100، 1 000 و 10 000 به‌صورت مساوی فاصله دارند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال خودمحافظ زیر یک نمودار خطی با پنج مقدار درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی می‌کند و در اسلاید دوم پایه لگاریتمی 10 را بر محور مقدار فعال می‌نماید. هر دو اسلاید همان داده‌ها را حفظ می‌کنند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // اسلاید اول را خطی نگه دارید و فقط مقیاس محور مقدار کپی را تغییر دهید.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


**مقیاس خطی (اسلاید ۱):** فواصل عمودی برابر نشان‌دهنده اختلاف‌های مساوی در تعداد درخواست‌ها هستند. بزرگ‌ترین مقدار نمودار را تحت‌الشعاع می‌گیرد و مقادیر کوچک‌تر را تشخیص دشوار می‌کند.

![نمودار خطی در PowerPoint که پنج تعداد درخواست را روی محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید ۲):** فواصل عمودی برابر نشان‌دهنده نسبت‌های مساوی هستند. هر بازه ده برابر بازه قبلی درخواست دارد، بنابراین نقاط روی مقیاس پایه‑10 یک خط صعودی مستقیم تشکیل می‌دهند. برچسب‌های محور همچنان تعداد درخواست‌های اصلی را نشان می‌دهند.

![همان پنج تعداد درخواست در PowerPoint روی محور مقدار لگاریتمی پایه‑10](value-axis-logarithmic.png)

### **برخورد با مقادیر صفر و منفی**

مقیاس لگاریتمی تنها می‌تواند مقادیر مثبت صریح را نمایش دهد. قبل از فعال‌سازی آن، داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنای مهمی دارند، مقیاس خطی را حفظ کنید یا آن‌ها را به‌صورت جداگانه نمایش دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را توضیح دهید. به‌صورت ساکت آنها را با اعداد مثبت کوچک جایگزین نکنید، چرا که معانی داده‌ها را تغییر می‌دهد. هر حداقل یا حداکثر به‌صورت دستی تنظیم‌شده برای یک محور لگاریتمی نیز باید مثبت باشد.

## **پرسش‌های متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر را تنظیم کنم؟**

از متد [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) برای انتخاب رفتار تقاطع استفاده کنید. برای تعیین مقدار عددی تقاطع، از متد [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) استفاده کنید. این تنظیمات به شما امکان می‌دهند تقاطع محور را به نقطهٔ مرجع مناسب منتقل کنید.

**چگونه می‌توانم موقعیت برچسب‌های تیک را نسبت به محور تنظیم کنم؟**

متد [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) را با استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) فراخوانی کنید: `Low`، `High`، `NextTo` یا `None`. برای کنترل خود علامت‌های تیک، از متدهای [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) یا [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) استفاده کنید؛ اینها جدا از موقعیت برچسب‌ها هستند.