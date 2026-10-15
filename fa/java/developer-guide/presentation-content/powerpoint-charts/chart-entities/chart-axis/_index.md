---
title: سفارشی‌سازی محورهای نمودار در ارائه‌ها با استفاده از Java
linktitle: محور نمودار
type: docs
url: /fa/java/chart-axis/
keywords:
- محور نمودار
- محور عمودی
- محور افقی
- سفارشی‌سازی محور
- دستکاری محور
- مدیریت محور
- ویژگی‌های محور
- بیشینه مقدار
- کمینه مقدار
- خط محور
- قالب تاریخ
- عنوان محور
- موقعیت محور
- پاورپوینت
- ارائه
- Java
- Aspose.Slides
description: "کشف کنید چگونه با استفاده از Aspose.Slides for Java می‌توانید محورهای نمودار را در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها سفارشی کنید."
---
## **نمای کلی**

این مقاله نحوهٔ سفارشی‌سازی محورهای نمودار با Aspose.Slides for Java را توضیح می‌دهد. در آن به مقادیر محاسبه‌شدهٔ محور، جابجایی ردیف‌ها و ستون‌های نمودار، قابلیت مشاهدهٔ محور، فواصل برچسب دسته و تیک‌مارک‌ها، دسته‌بندی‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت‌گذاری محور، واحدهای نمایش و مقیاس لگاریتمی پرداخته می‌شود.

## **دریافت بیشینه‌ مقادیر در محور عمودی نمودارها**

یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شدهٔ محور، برای به‌روز شدن چیدمان نمودار، [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) را فراخوانی کنید.

[getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) و [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) را برای محدودهٔ محور بخوانید و برای فواصل تیک‌ها، [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) و [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) را دریافت کنید. مقیاس‌های زمان‌واحد را با [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) و [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) می‌توانید به‌دست آورید که برای محورهای تاریخ مرتبط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره می‌کند و نمودار را ذخیره می‌نماید.

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

## **جابه‌جایی داده‌ها بین محور‌ها**

از [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دستهٔ قبلی تبدیل به یک سری می‌شود و هر سری قبلی تبدیل به یک دسته. این عمل نحوهٔ گروه‌بندی داده‌ها را تغییر می‌دهد؛ محورهای افقی و عمودی را جابه‌جا نمی‌کند. مثال برای بایند کردن داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل ردیف سرصفحه و ستون دسته، قبل از جابه‌جایی ردیف و ستون از [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) استفاده می‌کند. سپس نموداری با چهار سری و سه دسته ذخیره می‌شود.

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

## **معکوس‌سازی ترتیب رسم محور**

از [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) برای معکوس‌کردن یک محور دسته یا مقدار استفاده کنید. برای مثال، یک نمودار میله‌ای افقی می‌تواند مراحل پروژه را از بالا به پایین به همان ترتیب برگهٔ کار نمایش دهد: برنامه‌ریزی، توسعه، آزمون. معکوس‌کردن یک محور جهت رسم را تغییر می‌دهد؛ داده‌های کتاب‌کار را مرتب یا جابه‌جا نمی‌کند. در مقایسه، [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) نقش سری‌ها و دسته‌ها را عوض می‌کند.

مثال زیر یک نمودار میله‌ای افقی با سه مرحله و یک سری ایجاد می‌کند. ارائه‌ای با سه اسلاید ذخیره می‌شود: ترتیب عادی، دسته‌های معکوس و مقادیر معکوس. هر نسخه از همان مجموعه داده استفاده می‌کند و فقط یک محور در هر نسخه معکوس می‌شود.

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

    // اسلاید ۳: تنها مقیاس عددی افقی را معکوس کنید.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

معکوس‌کردن یک محور می‌تواند محور مقابل را به سمت opposite side of the plot منتقل کند. با [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) می‌توانید محل تقاطع محور دیگر را تنظیم کنید. در اسلاید ۲، با مقدار `CrossesType.Maximum` بر روی محور دسته معکوس، محور مقدار افقی در پایین حفظ می‌شود. برای نقطهٔ تقاطع خاص، از [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) استفاده کنید. هنگام تغییر جهت، تنظیمات تقاطع را بررسی کنید، به‌ویژه اگر نمودار قبلاً نقطهٔ تقاطع سفارشی داشته باشد. با `false` برای `setPlotOrderReversed` می‌توانید جهت رسم عادی را بازگردانید؛ تنظیمات تقاطع مستقل هستند.

| ترتیب عادی (اسلاید 1) | دسته‌های معکوس (اسلاید 2) | مقادیر معکوس (اسلاید 3) |
| --- | --- | --- |
| ![نمودار میله‌ای افقی با ترتیب عادی محورهای دسته و مقدار](axis-order-normal.png) | ![نمودار میله‌ای افقی با دسته‌ها از بالا به پایین نمایش داده شده‌اند](axis-order-categories-reversed.png) | ![نمودار میله‌ای افقی با محور مقدار معکوس و صفر در سمت راست](axis-order-values-reversed.png) |
| دسته‌ها از پایین به بالا اجرا می‌شوند؛ مقادیر از چپ به راست افزایش می‌یابند. | برنامه‌ریزی، توسعه و آزمون از بالا به پایین اجرا می‌شوند. مقادیر و ترتیب ردیف‌های کتاب‌کار تغییری نمی‌کند. | دسته‌ها ترتیب عادی خود را حفظ می‌کنند؛ مقادیر از راست به چپ افزایش می‌یابند. محور دسته در صفر سمت راست تقاطع می‌کند. |

## **غیرفعال‌سازی محور عمودی برای نمودارهای خطی**

با فراخوانی [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) با مقدار `false` بر روی محور عمودی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌نماید.

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

## **غیرفعال‌سازی محور افقی برای نمودارهای خطی**

با فراخوانی [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) با مقدار `false` بر روی محور افقی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌نماید.

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

## **تغییر محور دسته‌ای**

از [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) برای انتخاب یک محور دسته‌ای تاریخ یا متن استفاده کنید. این مثال به فایل `ExistingChart.pptx` نیاز دارد که در اسلاید اول اولین شکل، یک نمودار دارد و سلول‌های دسته مقدارهای عددی تاریخ Excel را شامل می‌شوند. محور افقی به محور تاریخ تغییر می‌کند. با فراخوانی [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) با `false`، [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) با مقدار `1` و [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) با `TimeUnitType.Months` تیک‌های بزرگ در فواصل یک‌ماهه قرار می‌گیرند.

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

## **کنترل فواصل برچسب محور دسته‌ای**

زمانی که نمودار تعداد زیادی دسته داشته باشد، می‌توانید تعداد برچسب‌های قابل مشاهدهٔ محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. با فراخوانی [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) با `false`، سپس مقدار دلخواه فواصل دسته را به [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) پاس بدهید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته شروع می‌شود:

| فاصله | برچسب‌های نمایش داده‌شده در مثال |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

فاصلهٔ `3` هر سومین برچسب را نمایش می‌دهد و دو برچسب بین برچسب‌های نمایش داده‌شده مخفی می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصلهٔ خودکار بر پایهٔ فضای موجود انتخاب می‌شود؛ لزوماً همهٔ برچسب‌ها را نمایش نمی‌دهد.

تیک‌مارک‌ها کنترل جداگانه‌ای دارند. با فراخوانی [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) با `false` و استفاده از [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) می‌توانید فواصل آن‌ها را تنظیم کنید. برای مثال، مقدار `1` یک تیک‌مارک در هر فاصلهای دسته نگه می‌دارد در حالی که برچسب‌ها فقط هر سومین دسته نمایش داده می‌شوند. با [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) می‌توانید یک سبک قابل مشاهده برای تیک‌مارک‌های بزرگ تنظیم کنید. فراخوانی دوبارهٔ تنظیم‌کنندهٔ فاصلهٔ خودکار با `true` اجازه می‌دهد نمودار همان فاصله را مجدداً انتخاب کند.

مثال خودکفای زیر ۲۴ دسته و یک سری ایجاد می‌کند و سپس سه اسلاید را در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصلهٔ خودکار، فاصلهٔ دستی برچسب با تیک‌مارک‌های مستقل، و بازگرداندن فاصلهٔ خودکار. دو نسخه‌ی کپی داده‌های اصلی نمودار را حفظ می‌کنند. هیچ ارائهٔ ورودی موردنیاز نیست. متن برچسب افقی تفاوت چگالی را به‌وضوح نشان می‌دهد.

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

    // اسلاید ۲: نمایش هر سومین برچسب، اما نگه داشتن یک تیک‌مارک برای هر دسته.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // اسلاید ۳: اجازه دهید نمودار دوباره هر دو فاصلۀ برچسب و تیک‌مارک را انتخاب کند.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**فاصلهٔ خودکار (اسلاید 1):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و به دو خط می‌پیچد. نتیجهٔ خودکار می‌تواند بسته به اندازهٔ نمودار، قلم‌ها و رندرر متفاوت باشد.

![فاصلهٔ خودکار برچسب دسته با همهٔ ۲۴ ستون قابل مشاهده](category-axis-automatic.png)

**فاصلهٔ دستی (اسلاید 2):** هر سومین برچسب در یک خط نمایش داده می‌شود، در حالی که تیک‌مارک‌ها در هر فاصلهای دسته باقی می‌مانند. همهٔ ۲۴ ستون، از جمله آن‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده‌اند. اسلاید ۳ ظاهر خودکار را همان‌گونه که در بالا نشان داده شد باز می‌گرداند.

![فاصلهٔ دستی برچسب دسته به مقدار سه با همهٔ ۲۴ ستون قابل مشاهده](category-axis-manual.png)

### **انتخاب محور و فاصلهٔ صحیح**

از این فواصل برای یک محور دسته‌ای متنی استفاده کنید، مانند محور دسته‌ای یک نمودار ستونی، خطی، ناحیه‌ای یا میله‌ای. در یک نمودار ستونی، این محور افقی است. در یک نمودار میله‌ای افقی، محور دسته‌ای عمودی است، بنابراین این تنظیمات را برای محوری که توسط [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) برگردانده می‌شود اعمال کنید. فواصل تیک‌مارک نیز برای محور سری در نمودارهایی که چنین محوری دارند صادق است.

از فاصلهٔ برچسب دسته برای تنظیم مقیاس عددی یک محور مقدار استفاده نکنید. در یک محور مقدار، [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) اختلافی در مقادیر را تعیین می‌کند: به‌عنوان مثال، واحد بزرگ `10` تیک‌ها را در ۰، ۱۰، ۲۰ و غیره تولید می‌کند وقتی محور از صفر شروع شود. فاصلهٔ برچسب دسته `3` به‌جای مقادیر عددی، موقعیت‌های دسته‌ای را می‌شمارد. نمودارهای پراکندگی و حبابی از محورهای مقدار استفاده می‌کنند نه محور دسته‌ای متنی. برای محور تاریخ، از واحدها و مقیاس‌های زمان‑محور همان‌طور که در [تغییر محور دسته‌ای](#change-a-category-axis) توضیح داده شد استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌ای**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌صورت شماره‌های سریال OLE Automation در اولین برگهٔ کاری (اندیس `0`) ذخیره می‌شوند که عدد روزها از ۳۰ دسامبر ۱۸۹۹ تا این تاریخ‌ها را نشان می‌دهد. با استفاده از [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) با مقدار `CategoryAxisType.Date`، [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) را با `false` تنظیم کنید و `yyyy` را به [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) پاس بدهید تا برچسب‌های دسته سال‌های چهاررقمی را مستقل از قالب بندی سلول نمایش دهند.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
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

با فراخوانی [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) با مقدار `true` بر روی محور عمودی، متن عنوان را فراهم کنید و با [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) عنوان را بچرخانید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را با عنوان محور مقدار که به‌صورت ۹۰ درجه چرخیده ذخیره می‌کند.

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

## **تنظیم موقعیت محور بر روی محور دسته یا مقدار**

از [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) برای کنترل این که آیا محور مقدار بین دسته‌ها یا در تیک‌مارک‌های دسته عبور می‌کند استفاده کنید. این تنظیم برای محورهای دسته‌ای اعمال می‌شود. مثال این مقدار را بر روی محور دسته‌ای افقی یک نمودار ستونی به `true` تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

از [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) برای مقیاس‌بندی برچسب‌های یک محور مقدار بدون تغییر داده‌های پایه استفاده کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) به `Millions`، مقدار ۶۰٬۰۰۰٬۰۰۰ به‌صورت ۶۰ نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر محور عمودی اعمال می‌نماید.

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

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت در چندین مرتبهٔ مقدار متفاوت باشند. برای مثال، یک سرویس ممکن است ۱۰، ۱۰۰، ۱٬۰۰۰، ۱۰٬۰۰۰ و ۱۰۰٬۰۰۰ درخواست در پنج دوره دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر به‌هم چسبیده‌اند. مقیاس لگاریتمی رشد نسبی آن‌ها را آسان‌تر مقایسه می‌کند: فواصل برابر نشان‌دهندهٔ نسبت‌های برابر نه اختلاف‌های عددی برابر هستند.

با فراخوانی [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) با `true` بر روی محور مقدار و استفاده از [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) پایهٔ دلخواه را انتخاب کنید. این کار نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. خط روند رابطهٔ برازش‌شده‌ای در داده‌ها است و ویژگی مستقلی محسوب می‌شود.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خطی یا ستونی، محور مقدار توسط [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) بازگردانده می‌شود. برای یک نمودار میله‌ای افقی، توسط [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) باز می‌گردد. نمودارهای پراکندگی و حبابی دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو را انتخاب کنید. مقیاس لگاریتمی را بر روی محور دسته اعمال نکنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX می‌توانید پایه‌ای از `2` تا `1000` (شامل) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایهٔ `10` توان‌های متوالی ۱۰، ۱۰۰، ۱٬۰۰۰ و ۱۰٬۰۰۰ به‌صورت مساوی فاصله دارند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال خودکفای زیر یک نمودار خطی با پنج مقدار درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی می‌کند و در اسلاید دوم محور مقدار لگاریتمی پایهٔ ۱۰ را فعال می‌نماید. هر دو اسلاید همان داده‌ها را حفظ می‌کنند.

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

    // اسلاید اول را خطی نگه دارید و فقط مقیاس محور مقدار نسخه‌کپی را تغییر دهید.
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

**مقیاس خطی (اسلاید 1):** فواصل عمودی برابر نشان‌دهندهٔ اختلاف‌های برابر در تعداد درخواست‌ها هستند. بزرگ‌ترین مقدار بر نمودار غالب می‌شود و مقادیر کوچکتر تشخیصشان دشوار است.

![نمودار خطی در PowerPoint که پنج مقدار درخواست را بر روی محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید 2):** فواصل عمودی برابر نشان‌دهندهٔ نسبت‌های برابر هستند. هر دوره ده‌برابر دوره قبل است، بنابراین نقاط بر روی مقیاس پایهٔ ۱۰ یک خط صعودی مستقیم تشکیل می‌دهند. برچسب‌های محور هنوز مقدارهای درخواست اصلی را نمایش می‌دهند.

![همان پنج مقدار درخواست در PowerPoint بر روی محور مقدار لگاریتمی پایهٔ ۱۰](value-axis-logarithmic.png)

### **درج مقدار صفر و منفی**

مقیاس لگاریتمی فقط مقادیر مثبت صریح را می‌تواند نمایش دهد. پیش از فعال‌سازی آن داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنادار باشند، مقیاس خطی نگه دارید یا آن‌ها را به‌صورت جداگانه نشان دهید. اگر حذف این مقادیر برای تحلیل مناسب است، حذف را توضیح دهید. به‌صورت خام ساکن جایگزین نکنید، زیرا معنی داده‌ها تغییر می‌کند. هر حداقل یا حداکثر به‌صورت دستی پیکربندی‌شده برای محور لگاریتمی نیز باید مثبت باشد.

## **پرسش‌های متداول**

**چگونه مقدار تقاطع یک محور با محور دیگر را تنظیم کنم؟**

با استفاده از [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) رفتار تقاطع را انتخاب کنید. برای تعیین مقدار عددی تقاطع، از [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) استفاده کنید. این تنظیمات به شما اجازه می‌دهند تقاطع محور را به خط پایه‌ای مناسب منتقل کنید.

**چگونه می‌توانم برچسب‌های تیک را نسبت به محور موقعیت‌دهی کنم؟**

با فراخوانی [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) و استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, یا `None` موقعیت برچسب‌ها را تنظیم کنید. برای کنترل خود تیک‌مارک‌ها، از [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) یا [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-) استفاده کنید؛ این موارد جدا از موقعیت برچسب‌ها هستند.