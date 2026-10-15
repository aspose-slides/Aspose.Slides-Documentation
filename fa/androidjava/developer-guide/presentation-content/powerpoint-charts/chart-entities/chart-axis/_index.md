---
title: "سفارشی‌سازی محورهای نمودار در ارائه‌های Android"
linktitle: "محور نمودار"
type: docs
url: /fa/androidjava/chart-axis/
keywords:
- "محور نمودار"
- "محور عمودی"
- "محور افقی"
- "سفارشی‌سازی محور"
- "دستکاری محور"
- "مدیریت محور"
- "ویژگی‌های محور"
- "حداکثر مقدار"
- "حداقل مقدار"
- "خط محور"
- "قالب تاریخ"
- "عنوان محور"
- "موقعیت محور"
- "PowerPoint"
- "ارائه"
- "Android"
- "Java"
- "Aspose.Slides"
description: "کشف کنید چگونه از Aspose.Slides برای Android از طریق Java استفاده کنید تا محورهای نمودار را در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها سفارشی‌سازی کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه در Aspose.Slides برای Android از طریق Java محورهای نمودار را سفارشی کنید. مواردی مانند مقادیر محاسبه‌شده محور، جابجایی سطرها و ستون‌های نمودار، قابل مشاهده بودن محور، فواصل برچسب و علامت‌گذاری دسته‌ها، دسته‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت محور، واحدهای نمایش و مقیاس لگاریتمی پوشش داده می‌شود.

## **دریافت بیشترین مقدارهای محور عمودی در نمودارها**

یک [ارائه](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. پیش از خواندن مقادیر محاسبه‌شده محور، متد [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) را فراخوانی کنید تا چیدمان نمودار به‌روز باشد.

برای دریافت حدود محور، از [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) و [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) استفاده کنید و برای فواصل علامت‌گذاری، از [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) و [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) استفاده کنید. مقادیر [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) و [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) مقیاس‌های زمانی را ارائه می‌دهند که برای محورهای تاریخ مرتبط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره می‌کند و نمودار را ذخیره می‌نماید.

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

از [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دستهٔ قبلی تبدیل به یک سری می‌شود و هر سریٔ قبلی تبدیل به یک دسته. این تغییر فقط نحوهٔ گروه‌بندی داده‌ها را تغییر می‌دهد؛ محورها افقی و عمودی جابه‌جا نمی‌شوند. مثال با استفاده از [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) داده‌های پیش‌فرض را به `Sheet1!A1:D5` (شامل سطر سرآیند و ستون دسته) متصل می‌کند و سپس سطرها و ستون‌ها را جابجا می‌نماید. نتیجه یک نمودار با چهار سری و سه دسته است.

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

## **معکوس کردن ترتیب رسم محور**

از [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) برای معکوس کردن محور دسته یا مقدار استفاده کنید. به‌عنوان مثال، یک نمودار میله‌ای افقی می‌تواند مراحل پروژه را از بالا به پایین به همان ترتیب شیت کاری نمایش دهد: برنامه‌ریزی، توسعه، آزمون. معکوس کردن محور جهت رسم را تغییر می‌دهد؛ داده‌های ورک‌بوک را مرتب یا جابه‌جا نمی‌کند. در مقایسه، [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) نقش سری‌ها و دسته‌ها را تعویض می‌کند.

مثال زیر یک نمودار میله‌ای افقی با سه مرحله و یک سری ایجاد می‌کند. ارائه‌ای با سه اسلاید ذخیره می‌کند: ترتیب عادی، دسته‌های معکوس و مقادیر معکوس. هر نسخه از همان مجموعه داده استفاده می‌کند و فقط یک محور در هر نسخه معکوس می‌شود.

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

    // اسلاید 2: نمایش اولین دسته در بالای اسلاید.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // محور مقدار افقی را در پایین نگه دارید.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // اسلاید 3: فقط مقیاس عددی افقی را معکوس کنید.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

معکوس کردن یک محور می‌تواند محور عمود را به سمت مخالف نمودار جابه‌جا کند. از [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) برای تعیین نقطهٔ عبور محور دیگر استفاده می‌شود. در اسلاید ۲، فراخوانی آن با مقدار `CrossesType.Maximum` بر روی محور دستهٔ معکوس، محور مقدار افقی را در پایین نگه می‌دارد. برای تعیین نقطهٔ عبور خاص، از [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) استفاده کنید. هنگام تغییر جهت، تنظیمات عبور را بررسی کنید، به‌ویژه اگر نمودار قبلاً نقطهٔ عبور سفارشی داشته باشد. برای بازگرداندن جهت رسم عادی، `setPlotOrderReversed` را با مقدار `false` فراخوانی کنید؛ تنظیمات عبور مستقل از این هستند.

| ترتیب عادی (اسلاید 1) | دسته‌های معکوس (اسلاید 2) | مقادیر معکوس (اسلاید 3) |
| --- | --- | --- |
| ![نمودار میله‌ای افقی با ترتیب عادی محور دسته و مقدار](axis-order-normal.png) | ![نمودار میله‌ای افقی با نمایش دسته‌ها از بالا به پایین](axis-order-categories-reversed.png) | ![نمودار میله‌ای افقی با محور مقدار معکوس و صفر در سمت راست](axis-order-values-reversed.png) |
| دسته‌ها از پایین به بالا حرکت می‌کنند؛ مقادیر از چپ به راست افزایش می‌یابند. | برنامه‌ریزی، توسعه و آزمون از بالا به پایین نمایش داده می‌شوند. مقادیر و ترتیب سطرهای ورک‌بوک تغییر نکرده‌اند. | دسته‌ها ترتیب عادی خود را حفظ می‌کنند؛ مقادیر از راست به چپ افزایش می‌یابند. محور دسته در نقطهٔ صفر سمت راست عبور می‌کند. |

## **غیرفعال کردن محور عمودی برای نمودارهای خطی**

با فراخوانی [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) برابر `false` بر روی محور عمودی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌نماید.

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

با فراخوانی [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) برابر `false` بر روی محور افقی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌نماید.

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

## **تغییر محور دسته**

از [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) برای انتخاب محور دستهٔ تاریخ یا متن استفاده کنید. این مثال نیاز به `ExistingChart.pptx` دارد که نموداری به عنوان اولین شکل در اولین اسلاید دارد و سلول‌های دسته شامل مقدارهای عددی تاریخ اکسل هستند. محور افقی را به محور تاریخ تغییر می‌دهد. با فراخوانی [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) برابر `false`، [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) برابر `1` و [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) برابر `TimeUnitType.Months` علامت‌های اصلی را در فواصل یک‌ماهه قرار می‌دهد.

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

## **کنترل فواصل برچسب محور دسته**

هنگامی که یک نمودار دسته‌های زیادی داشته باشد، می‌توانید تعداد برچسب‌های قابل مشاهدهٔ محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. با فراخوانی [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) برابر `false`، سپس فاصلهٔ دستهٔ دلخواه را به [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) بدهید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته آغاز می‌شود:

| فاصله | برچسب‌های نمایش داده شده در مثال |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

فاصلهٔ `3` هر برچسب سومی را نمایش می‌دهد و دو برچسب دیگر را بین برچسب‌های نمایش داده‌شده مخفی می‌کند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصلهٔ خودکار بر پایهٔ فضای موجود انتخاب می‌شود و لزوماً تمام برچسب‌ها را نمایش نمی‌دهد.

علامت‌گذاری‌ها کنترل‌های جداگانه‌ای دارند. با فراخوانی [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) برابر `false` و استفاده از [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) فاصلهٔ آن‌ها را تنظیم کنید. برای مثال، مقدار `1` یک علامت‌گذاری در هر فاصلهٔ دسته نگه می‌دارد در حالی که برچسب‌ها فقط هر سوم دسته نمایش داده می‌شوند. از [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) با یک سبک قابل مشاهده استفاده کنید تا نتیجه را ببینید. بازگرداندن تنظیمات خودکار با تنظیم دوبارهٔ هر دو متد به `true` باعث می‌شود نمودار دوباره فاصلهٔ مناسب را انتخاب کند.

مثال خودمختار زیر ۲۴ دسته و یک سری ایجاد می‌کند و سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصلهٔ خودکار، فاصلهٔ دستی برچسب با علامت‌گذاری‌های مستقل، و بازگرداندن فاصلهٔ خودکار. دو نسخهٔ کپی داده‌های اصلی نمودار را حفظ می‌کنند. هیچ ارائهٔ ورودی‌ای لازم نیست. متن برچسب‌های افقی تمایز چگالی را به‌راحتی نشان می‌دهد.

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

    // اسلاید 2: هر سومین برچسب را نشان دهید، اما یک علامت‌گذاری برای هر دسته حفظ شود.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // اسلاید 3: اجازه دهید نمودار دوباره هر دو بازه را انتخاب کند.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**فاصلهٔ خودکار (اسلاید 1):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و روی دو خط می‌افتد. نتیجهٔ خودکار می‌تواند بسته به اندازهٔ نمودار، قلم‌ها و رندر کننده متفاوت باشد.

![فاصلهٔ خودکار برچسب‌های دسته با نمایش تمام ۲۴ ستون](category-axis-automatic.png)

**فاصلهٔ دستی (اسلاید 2):** هر سومین برچسب بر روی یک خط نمایش داده می‌شود، در حالی که علامت‌گذاری‌ها در هر فاصلهٔ دسته باقی می‌مانند. تمام ۲۴ ستون، شامل ستون‌های بدون برچسب، با همان مقادیر قابل مشاهده‌اند. اسلاید ۳ ظاهر خودکار را بازمی‌گرداند.

![فاصلهٔ دستی برچسب‌های دسته به مقدار سه با نمایش تمام ۲۴ ستون](category-axis-manual.png)

### **انتخاب محور و فاصلهٔ صحیح**

از این فاصلهٔ شمارش دسته برای یک محور دستهٔ متنی، مانند محور دستهٔ نمودار ستونی، خطی، مساحتی یا میله‌ای استفاده کنید. در یک نمودار ستونی، این محور افقی است. در یک نمودار میله‌ای افقی، محور دسته عمودی است، بنابراین این تنظیمات را بر روی محوری که توسط [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) بازگردانده می‌شود اعمال کنید. فاصلهٔ علامت‌گذاری همچنین برای محور سری در نمودارهایی که یک محور سری دارند اعمال می‌شود.

از فاصلهٔ برچسب دسته برای تنظیم مقیاس عددی محور مقدار استفاده نکنید. در یک محور مقدار، [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) اختلافی در مقادیر را تعیین می‌کند: به‌عنوان مثال، مقدار اصلی `10` علامت‌گذاری‌هایی در ۰، ۱۰، ۲۰ و غیره تولید می‌کند هنگامی که محور از صفر آغاز می‌شود. فاصلهٔ برچسب دستهٔ `3` به‌جای مقادیر، موقعیت‌های دسته‌ای را می‌شمارد. نمودارهای پراکندگی و حبابی از محورهای مقدار استفاده می‌کنند نه محور دستهٔ متنی. برای محور تاریخ، از واحدهای اصلی و مقیاس‌های مبتنی بر زمان همان‌طور که در [تغییر محور دسته](#change-a-category-axis) توضیح داده شد، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته**

این مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌عنوان شماره‌های سریال OLE Automation در اولین برگه کاری (اندیس `0`) ذخیره می‌شوند؛ این عددها تعداد روزهای گذشته از ۳۰ دسامبر ۱۸۹۹ را نشان می‌دهند. هر دو تقویم به UTC تنظیم شده‌اند و قبل از تنظیم تاریخ‌ها پاک می‌شوند تا ذخیرهٔ ساعت تابستانی و زمان فعلی بر محاسبه تأثیر نگذارند. با استفاده از [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) برابر `CategoryAxisType.Date`، [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) برابر `false` و عبور `yyyy` به [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) برچسب‌های دسته را به‌صورت سال‌های چهاررقمی، صرف‌نظر از قالب سلول، نمایش می‌دهد.

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

## **تنظیم زاویهٔ چرخش برای عنوان محور نمودار**

با فراخوانی [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) برابر `true` روی محور عمودی، متن عنوان را تعیین کنید و با [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) زاویهٔ چرخش را تنظیم کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را با عنوان محور مقدار چرخیده به اندازهٔ ۹۰ درجه ذخیره می‌کند.

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

## **تنظیم موقعیت محور بر روی یک محور دسته یا مقدار**

با استفاده از [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) کنترل کنید که محور مقدار آیا بین دسته‌ها یا بر روی علامت‌گذاری‌های دسته عبور کند. این تنظیم برای محورهای دسته اعمال می‌شود. مثال این ویژگی را بر روی محور دستهٔ افقی یک نمودار ستونی برابر `true` قرار می‌دهد و نتیجه را ذخیره می‌کند.

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

## **تنظیم واحد نمایش بر روی محور مقدار نمودار**

با استفاده از [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) می‌توانید برچسب‌های محور مقدار را بدون تغییر داده‌های زیرین مقیاس‌بندی کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) برابر `Millions`، مقدار 60 000 000 به صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون را بر روی محور عمودی آن اعمال می‌نماید.

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

## **پیکربندی محور مقدار لگاریتمی**

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت در چندین مرتبهٔ بزرگی متفاوت باشند. به‌عنوان مثال، یک سرویس ممکن است در طول پنج دوره ۱۰، ۱۰۰، ۱ ۰۰۰، ۱۰ ۰۰۰ و ۱۰۰ ۰۰۰ درخواست دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر گروه‌بندی می‌شوند. مقیاس لگاریتمی رشد نسبی آن‌ها را آسان‌تر مقایسه می‌کند: فواصل برابر نشان‌دهندهٔ نسبت‌های برابر هستند نه اختلاف‌های برابر.

با فراخوانی [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) برابر `true` روی محور مقدار و استفاده از [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) پایهٔ دلخواه را انتخاب کنید. این کار نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها یا خط روند لگاریتمی اضافه نمی‌کند. خط روند یک ویژگی جداگانه است.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خطی یا ستونی، محور مقدار توسط [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) بازگردانده می‌شود. برای یک نمودار میله‌ای افقی، از [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) استفاده کنید. نمودارهای پراکندگی و حبابی دو محور مقدار دارند، پس برای مقادیر X محور افقی و برای مقادیر Y محور عمودی یا هر دو را می‌توانید انتخاب کنید. مقیاس لگاریتمی را روی محور دسته اعمال نکنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX می‌توانید پایه‌ای بین `2` تا `1000` (دربرگیرنده) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایهٔ `10` توان‌های متوالی 10، 100، 1 000 و 10 000 به‌صورت مساوی فاصله‌دار هستند.

### **مقایسهٔ مقیاس خطی و لگاریتمی**

مثال خودمختار زیر یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی می‌کند و در اسلاید دوم یک محور مقدار لگاریتمی با پایهٔ 10 فعال می‌نماید. هر دو اسلاید همان داده‌ها را حفظ می‌کنند.

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

    // اسلاید اول را خطی نگه دارید و تنها مقیاس محور مقدار نسخهٔ کپی شده را تغییر دهید.
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

**مقیاس خطی (اسلاید 1):** فواصل عمودی برابر نشان‌دهندهٔ اختلاف‌های مساوی در شمارش درخواست‌ها هستند. بزرگ‌ترین مقدار dominate نمودار را می‌گیرد و مقادیر کوچکتر را تشخیص دشوار می‌سازد.

![نمودار خطی در پاورپوینت که پنج شمارش درخواست را روی محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید 2):** فواصل عمودی برابر نمایانگر نسبت‌های مساوی هستند. هر دوره ده برابر دورهٔ قبلی درخواست دارد، بنابراین نقاط روی مقیاس پایهٔ 10 یک خط صعودی مستقیم می‌سازند. برچسب‌های محور هنوز مقادیر اصلی درخواست را نشان می‌دهند.

![پنج شمارش درخواست یکسان در پاورپوینت روی محور مقدار لگاریتمی با پایهٔ 10](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

مقیاس لگاریتمی فقط مقادیر مثبت صریح را نمایش می‌دهد. قبل از فعال‌سازی آن داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنا داشته باشند، از مقیاس خطی استفاده کنید یا آنها را به‌صورت جداگانه نمایش دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را توضیح دهید. به‌صورت ساکن آنها را با عددهای کوچک مثبت جایگزین نکنید، چون معنای داده را تغییر می‌دهد. هر حداقل یا حداکثر به‌صورت دستی تنظیم‌شده برای یک محور لگاریتمی نیز باید مثبت باشد.

## **پرسش‌های متداول**

**چگونه مقدار عبور یک محور را نسبت به محور دیگر تنظیم کنم (crossing)؟**

از [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) برای انتخاب رفتار عبور استفاده کنید. برای مشخص کردن مقدار عددی عبور، از [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) استفاده کنید. این تنظیمات به شما اجازه می‌دهند عبور محور را به یک مرجع مناسب منتقل کنید.

**چگونه می‌توان موقعیت برچسب‌های علامت‌گذاری را نسبت به محور تنظیم کرد؟**

با فراخوانی [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) و استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, یا `None`. برای کنترل خود علامت‌گذاری‌ها، از [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) یا [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) استفاده کنید؛ این‌ها جدا از موقعیت برچسب‌ها هستند.