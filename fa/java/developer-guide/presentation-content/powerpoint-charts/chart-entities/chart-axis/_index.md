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
- جاوا
- Aspose.Slides
description: "کشف کنید چگونه از Aspose.Slides برای جاوا برای سفارشی‌سازی محورهای نمودار در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها استفاده کنید."
---
## **بررسی کلی**

این مقاله نحوهٔ سفارشی‌سازی محورهای نمودار را با Aspose.Slides برای جاوا توضیح می‌دهد. موارد زیر پوشش داده می‌شوند: مقادیر محاسبه‌شدهٔ محور، جابجایی سطرها و ستون‌های نمودار، نمایش یا پنهان‌سازی محور، فواصل برچسب‌های دسته و علامت‌های تیک، دسته‌های تاریخ و قالب‌بندی آن‌ها، چرخش عنوان، موقعیت محور، واحدهای نمایش و مقیاس لگاریتمی.

## **دریافت بیشینه مقادیر محور عمودی در نمودارها**

یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شدهٔ محور، برای به‌روزرسانی طرح نمودار، [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) را فراخوانی کنید.

[getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) و [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) را برای مرزهای محور بخوانید و [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) و [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) را برای فواصل تیک‌ها دریافت کنید. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) و [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) مقیاس‌های زمان‑واحد را فراهم می‌کنند که برای محورهای تاریخ مرتبط هستند. مثال این مقادیر را در متغیرهای محلی ذخیره کرده و نمودار را ذخیره می‌کند.

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

از [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دسته قبلی تبدیل به یک سری می‌شود و هر سری قبلی تبدیل به یک دسته می‌شود. این تغییر نحوهٔ گروه‌بندی داده‌ها را تحت تأثیر قرار می‌دهد؛ محورهای افقی و عمودی را جابجا نمی‌کند. مثال از [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) برای اتصال داده‌های پیش‌فرض به `Sheet1!A1:D5` (شامل سطر سرصفحه و ستون دسته) قبل از جابجایی سطرها و ستون‌ها استفاده می‌کند. سپس نموداری با چهار سری و سه دسته ذخیره می‌کند.

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

## **معکوس‌کردن ترتیب رسم محور**

از [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) برای معکوس‌کردن یک محور دسته یا مقدار استفاده کنید. به عنوان مثال، یک نمودار میله‌ای افقی می‌تواند مراحل پروژه را از بالا به پایین به همان ترتیبی که در صفحه‌کار موجود است نشان دهد: برنامه‌ریزی، توسعه، آزمون. معکوس‌کردن محور جهت رسم را تغییر می‌دهد؛ داده‌های صفحه‌کار را مرتب یا جابجا نمی‌کند. در مقایسه، [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) نقش سری‌ها و دسته‌ها را تعویض می‌کند.

مثال زیر یک نمودار میله‌ای افقی با سه مرحله و یک سری ایجاد می‌کند. یک ارائه با سه اسلاید ذخیره می‌شود: ترتیب عادی، دسته‌های معکوس و مقادیر معکوس. هر نسخه از همان مجموعه داده استفاده می‌کند و فقط یک محور در هر نسخه معکوس می‌شود.

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

معکوس‌کردن یک محور می‌تواند محور عمودی را به سمت مخالف نمودار منتقل کند. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) تعیین می‌کند که محور دیگر در کجا از محوری که پیکربندی می‌شود عبور می‌کند. در اسلاید ۲، فراخوانی آن با `CrossesType.Maximum` بر روی محور دستهٔ معکوس، محور مقدار افقی را در پایین نگه می‌دارد. برای تعیین نقطه عبور خاص، از [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) استفاده کنید. هنگام تغییر جهت، تنظیمات عبور را بررسی کنید، به‌ویژه اگر نمودار قبلاً نقطه عبور سفارشی داشته باشد. برای بازگرداندن جهت رسم عادی، `setPlotOrderReversed` را با `false` فراخوانی کنید؛ تنظیمات عبور جداگانه‌اند.

| ترتیب عادی (اسلاید ۱) | دسته‌های معکوس (اسلاید ۲) | مقادیر معکوس (اسلاید ۳) |
| --- | --- | --- |
| ![نمودار میله‌ای افقی با ترتیب عادی محور دسته و مقدار](axis-order-normal.png) | ![نمودار میله‌ای افقی با نمایش دسته‌ها از بالا به پایین](axis-order-categories-reversed.png) | ![نمودار میله‌ای افقی با محور مقدار معکوس و صفر در سمت راست](axis-order-values-reversed.png) |
| دسته‌ها از پایین به بالا می‌روند؛ مقادیر از چپ به راست افزایش می‌یابند. | برنامه‌ریزی، توسعه و آزمون از بالا به پایین می‌روند. مقادیر و ترتیب سطرهای صفحه‌کار تغییر نمی‌کند. | دسته‌ها ترتیب عادی خود را حفظ می‌کنند؛ مقادیر از راست به چپ افزایش می‌یابند. محور دسته در صفر سمت راست عبور می‌کند. |

## **غیرفعال‌سازی محور عمودی برای نمودارهای خطی**

با فراخوانی [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) با مقدار `false` بر روی محور عمودی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و با مخفی‌سازی محور عمودی ذخیره می‌شود.

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

با فراخوانی [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) با مقدار `false` بر روی محور افقی، آن را مخفی کنید. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و با مخفی‌سازی محور افقی ذخیره می‌شود.

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

## **نمایش یا مخفی‌سازی خطوط شبکه نمودار**

با فراخوانی [getShowMajorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMajorGridLines--) و [getShowMinorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMinorGridLines--) می‌توانید بررسی کنید که یک محور چه خطوط شبکه‌ای را نمایش می‌دهد. این متدها وضعیت فعلی نمایش را گزارش می‌کنند. برای نمایش خطوط شبکهٔ جزئی، از [getMinorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) استفاده کرده و پر خط را به رنگ ثابت و قابل رؤیت تنظیم کنید. برای مخفی‌کردن آن‌ها، پر را به [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/#NoFill) تغییر دهید. برای خطوط شبکهٔ اصلی، از [getMajorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) به‌همین شکل استفاده کنید. تغییر پر، نمایش محور و علامت‌های تیک را حفظ می‌کند.

محور عمودی این نمودار میله‌ای خوشه‌ای در ابتدا تنها خطوط شبکهٔ اصلی را نشان می‌دهد. مثال خطوط شبکهٔ جزئی را به رنگ نارنجی تیره نمایش می‌دهد، سپس دوباره آن‌ها را مخفی می‌کند و ارائه را ذخیره می‌دارد. در هر مرحله، وضعیت نمایش خطوط شبکه چاپ می‌شود.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(new Color(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| خطوط شبکهٔ جزئی فعال | خطوط شبکهٔ جزئی مخفی |
| --- | --- |
| ![خطوط شبکهٔ جزئی نارنجی بین خطوط شبکهٔ اصلی بر محور عمودی](minor-gridlines-enabled.png) | ![همان نمودار میله‌ای فقط با خطوط شبکهٔ اصلی قابل مشاهده](minor-gridlines-hidden.png) |

## **تغییر محور دسته‌بندی**

از [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) برای انتخاب محور تاریخ یا متن استفاده کنید. این مثال به `ExistingChart.pptx` نیاز دارد که در اولین اسلاید، اولین شکل، یک نمودار دارد و سلول‌های دسته مقادیر عددی تاریخ اکسل را شامل می‌شوند. محور افقی به محور تاریخ تبدیل می‌شود. با فراخوانی [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) با `false`، [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) با `1` و [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) با `TimeUnitType.Months`، تیک‌های اصلی در فواصل یک ماه تنظیم می‌شوند.

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

### **تشخیص نوع محور دسته‌بندی از داده‌ها**

پس از پرکردن دسته‌ها، [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) را فراخوانی کنید، سپس با خواندن [getCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getCategoryAxisType--) نوع انتخاب شده را بررسی کنید. این روش هنگامی مفید است که همان نمودار یا متن برچسب‌ها یا مقادیر عددی تاریخ دریافت کند. متد زمان فراخوانی، نوع را تعیین می‌کند؛ حالت دائمی‌ای که بعداً تغییرات داده را بازنگری کند فعال نمی‌کند. پس از جایگزینی دسته‌ها، دوباره آن را فراخوانی کنید.

مثال زیر یک نمودار با دسته‌های متنی ایجاد می‌کند و زمانی که نوع انتخابی `CategoryAxisType.Text` باشد، مقدار `true` چاپ می‌کند. سپس مقادیر سلول دسته را با تاریخ‌ها جایگزین می‌کند و دوباره متد را فراخوانی می‌کند؛ وقتی نوع انتخابی `CategoryAxisType.Date` باشد، `true` چاپ می‌شود. تاریخ‌ها به‌صورت عددی OLE Automation ذخیره می‌شوند (تعداد روزهای سپری شده از 30 دسامبر 1899) نه به‌صورت رشتهٔ تاریخ. [setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) نحوهٔ نمایش این مقادیر را کنترل می‌کند؛ متن را به تاریخ عددی تبدیل نمی‌کند. برای اطلاعات بیشتر دربارهٔ سلول‌های دسته، به [Chart Workbook](/slides/fa/java/chart-workbook/) مراجعه کنید.

از تعیین خودکار استفاده کنید وقتی ورودی منحصراً شامل دسته‌های متنی یا تاریخ‌های عددی باشد، همان‌طور که در این مثال نشان داده شده است. برای برچسب‌های عددی ساده، دسته‌های ترکیبی یا داده‌های خالی، به‌صراحت از [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisType-int-) فراخوانی کنید تا با معنی موردنظر مطابقت داشته باشد. مقادیر عددی به‌تنهایی نشان‌دهندۀ اینکه دسته‌ها تاریخ هستند، نیستند.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

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

    LocalDate baseDate = LocalDate.of(1899, 12, 30);
    LocalDate[] dates = { LocalDate.of(2026, 1, 1), LocalDate.of(2026, 1, 2), LocalDate.of(2026, 2, 1) };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        categoryCell.setValue((double)(dates[i].toEpochDay() - baseDate.toEpochDay()));
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // درست

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کنترل فواصل برچسب محور دسته‌بندی**

زمانی که نمودار دارای تعداد زیادی دسته باشد، می‌توانید تعداد برچسب‌های قابل مشاهدهٔ محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. ابتدا با فراخوانی [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) مقدار `false` تنظیم کنید، سپس فواصل دلخواه دسته را با [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) ارسال کنید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته آغاز می‌شود:

| فواصل | برچسب‌های نمایش داده‌شده در مثال |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

فاصلهٔ `3` هر سومین برچسب را نمایش می‌دهد و دو برچسب بین هر دو برچسب نمایش‌یافته مخفی می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصلهٔ خودکار براساس فضای موجود یک مقدار انتخاب می‌کند؛ لزوماً همه برچسب‌ها را نمایش نمی‌دهد.

علامت‌های تیک نیز کنترل جداگانه‌ای دارند. با فراخوانی [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) مقدار `false` و استفاده از [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) می‌توانید فاصلهٔ آن‌ها را تنظیم کنید. برای مثال، مقدار `1` یک علامت تیک در هر فاصلهٔ دسته حفظ می‌کند در حالی که برچسب‌ها فقط هر سومین دسته را نشان می‌دهند. با [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) می‌توانید یک سبک قابل رؤیت تعیین کنید تا نتیجه را ببینید. دوباره فراخوانی متدهای خودکار با مقدار `true` اجازه می‌دهد نمودار همان فاصله را مجدداً انتخاب کند.

مثال زیر یک نمودار خودکفا با ۲۴ دسته و یک سری ایجاد می‌کند، سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصلهٔ خودکار، فاصلهٔ دستی برچسب‌ها با علامت‌های تیک مستقل، و بازگرداندن فاصلهٔ خودکار. دو نسخهٔ کپی داده‌های اصلی نمودار را حفظ می‌کنند. نیازی به ارائه ورودی نیست. متن برچسب‌های افقی تفاوت چگالی را به‌راحتی نشان می‌دهد.

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

    // اسلاید ۲: نمایش هر سومین برچسب، اما نگه داشتن یک علامت تیک برای هر دسته.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // اسلاید ۳: اجازه دهید نمودار دوباره هر دو فاصله را انتخاب کند.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**فاصلهٔ خودکار (اسلاید ۱):** در این رندر، هر دومین برچسب دسته نمایش داده می‌شود و به دو خط می‌پیچد. نتیجهٔ خودکار ممکن است بسته به اندازهٔ نمودار، قلم‌ها و رندر متفاوت باشد.

![فاصلهٔ خودکار برچسب‌های دسته با نمایش همهٔ ۲۴ ستون](category-axis-automatic.png)

**فاصلهٔ دستی (اسلاید ۲):** هر سومین برچسب در یک خط نمایش داده می‌شود، در حالی که علامت‌های تیک در هر فاصلهٔ دسته باقی می‌مانند. همهٔ ۲۴ ستون، حتی آن‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده‌اند. اسلاید ۳ ظاهر خودکار را که در بالا نشان داده شد بازمی‌گرداند.

![فاصلهٔ دستی برچسب دسته به مقدار سه با نمایش همهٔ ۲۴ ستون](category-axis-manual.png)

### **انتخاب محور و فاصلهٔ صحیح**

از این فواصل تعداد‑دسته برای محور دسته‌بندی متنی استفاده کنید، همان‌طور که در نمودارهای میله‌ای، خطی، ناحیه‌ای یا ستونی بکار می‌روند. در نمودار ستونی، محور افقی است. در نمودار میله‌ای افقی، محور دسته‌بندی عمودی است، بنابراین این تنظیمات را بر محور بازگردانده شده توسط [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) اعمال کنید. فاصلهٔ علامت تیک نیز برای محور سری در نمودارهایی که چنین محوری دارند، اعمال می‌شود.

از فاصلهٔ برچسب دسته برای تنظیم مقیاس عددی یک محور مقدار استفاده نکنید. در محور مقدار، [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) اختلاف مقادیر را مشخص می‌کند؛ برای مثال، واحد اصلی `10` تیک‌هایی در 0، 10، 20 و ... تولید می‌کند وقتی محور از صفر شروع می‌شود. فاصلهٔ برچسب دسته `3` به‌جای مقدار، موقعیت دسته‌ها را می‌شمارد صرف‌نظر از مقادیر داده‌ای آن‌ها. نمودارهای پراکندگی و حبابی از محورهاى مقدار استفاده می‌کنند نه از محور دسته‌بندی متنی. برای محور تاریخ، از واحدهای اصلی زمان‑محور و مقیاس‌ها همان‌طور که در [تغییر محور دسته‌بندی](#change-a-category-axis) توضیح داده شد، استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌بندی**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌عنوان عددهای سریال OLE Automation در اولین صفحه‌کار (شاخص `0`) ذخیره می‌شوند (به‌عدد روزهای سپری‌شده از 30 دسامبر 1899). با استفاده از [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) مقدار `CategoryAxisType.Date`، سپس [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) را با `false` و `yyyy` را به [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) می‌فرستید تا برچسب‌های دسته به صورت سال‌های چهاررقمی независимо از قالب سلول نمایش داده شوند.

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

با فراخوانی [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) مقدار `true` بر روی محور عمودی، متن عنوان را فراهم کنید و با استفاده از [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) عنوان را چرخش دهید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را با عنوان محور مقدار که به‌صورت 90 درجه چرخانده شده است ذخیره می‌کند.

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

## **تنظیم موقعیت محور در یک محور دسته یا مقدار**

از [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) برای کنترل اینکه آیا محور مقدار در میان دسته‌ها یا در علامت‌های تیک دسته عبور می‌کند استفاده کنید. این تنظیم برای محورهاى دسته اعمال می‌شود. مثال این تنظیم را بر محور دستهٔ افقی یک نمودار ستونی به مقدار `true` می‌گیرد و نتیجه را ذخیره می‌کند.

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

با استفاده از [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) می‌توانید برچسب‌های محور مقدار را بدون تغییر داده‌های زیرین مقیاس کنید. هنگامی که [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) به `Millions` تنظیم شود، مقدار 60 000 000 به‌صورت 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر محور عمودی اعمال می‌کند.

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

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت در چندین مرتبه‌ی توان متفاوت باشند. برای مثال، سرویسی ممکن است 10، 100، 1 000، 10 000 و 100 000 درخواست در پنج دوره دریافت کند. در مقیاس خطی، مقادیر کوچک نزدیک به صفر به‌هم چسبیده ظاهر می‌شوند. مقیاس لگاریتمی رشد نسبی آن‌ها را آسان‌تر مقایسه می‌کند: فواصل برابر نسبت‌های برابر را نشان می‌دهند نه اختلاف‌های عددی برابر.

با فراخوانی [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) مقدار `true` بر روی محور مقدار و استفاده از [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) می‌توانید پایهٔ موردنظر را انتخاب کنید. این کار فقط نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. یک خط روند رابطه‌ای برآمده از داده‌هاست و ویژگی جداگانه‌ای است.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خطی یا ستونی، محور مقدار توسط [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) برگردانده می‌شود. برای یک نمودار میله‌ای افقی، توسط [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) برگردانده می‌شود. نمودارهای پراکندگی و حبابی دو محور مقدار دارند، بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو استفاده کنید. مقیاس لگاریتمی را بر محور دسته اعمال نکنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX می‌توانید پایه‌ای از `2` تا `1000` (شامل) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایهٔ `10` توان‌های متوالی 10، 100، 1 000 و 10 000 به‌صورت برابر فاصله دارند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال زیر یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی کرده و در اسلاید دوم محور مقدار لگاریتمی پایه‑10 را فعال می‌کند. هر دو اسلاید همان داده‌ها را حفظ می‌کنند.

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

    // اسلاید اول را خطی نگه دارید و فقط مقیاس محور مقدار نسخهٔ کپی را تغییر دهید.
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

**مقیاس خطی (اسلاید ۱):** فواصل عمودی برابر نشان‌دهندۀ اختلاف‌های مساوی در شمارش درخواست‌ها هستند. بزرگ‌ترین مقدار بر نمودار چیره می‌شود و مقادیر کوچکتر را تشخیص سخت می‌کند.

![نمودار خطی در پاورپوینت که پنج شمارش درخواست را بر محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید ۲):** فواصل عمودی برابر نشان‌دهندۀ نسبت‌های مساوی هستند. هر دوره ده‌برابر دورهٔ قبلی دارد، بنابراین نقاط روی مقیاس لگاریتمی پایه‑10 یک خط صعودی مستقیم می‌سازند. برچسب‌های محور هنوز شمارش درخواست اصلی را نشان می‌دهند.

![همان پنج شمارش درخواست در پاورپوینت بر محور مقدار لگاریتمی پایه‑10](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

مقیاس لگاریتمی فقط مقادیر مثبت صریح را نمایش می‌دهد. قبل از فعال‌سازی داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنی‌دار هستند، مقیاس خطی را حفظ کنید یا آن‌ها را جداگانه نمایش دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را توضیح دهید. به‌صورت مخفی آن‌ها را با اعداد مثبت کوچک جایگزین نکنید، چون معنای داده را تغییر می‌دهد. هر حداقل یا حداکثر دستی که برای یک محور لگاریتمی تنظیم می‌کنید نیز باید مثبت باشد.

## **پرسش‌های متداول**

**چگونه مقدار نقطه‌ی تقاطع یک محور با محور دیگر را تنظیم کنم؟**

از [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) برای انتخاب رفتار تقاطع استفاده کنید. برای مشخص کردن مقدار عددی تقاطع، از [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) استفاده کنید. این تنظیمات به شما اجازه می‌دهد نقطه تقاطع محور را به مبنای مناسب منتقل کنید.

**چگونه می‌توانم موقعیت برچسب‌های تیک را نسبت به محور تنظیم کنم؟**

از [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) به‌همراه [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) استفاده کنید: `Low`، `High`, `NextTo` یا `None`. برای کنترل خود علامت‌های تیک، از [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) یا [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-) استفاده کنید؛ این گزینه‌ها جدا از موقعیت برچسب‌ها هستند.