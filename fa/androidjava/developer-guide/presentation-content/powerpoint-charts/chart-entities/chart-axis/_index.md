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
- فرمت تاریخ
- عنوان محور
- موقعیت محور
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "کشف کنید چگونه می‌توان از Aspose.Slides برای Android با استفاده از Java برای سفارشی‌سازی محورهای نمودار در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها استفاده کرد."
---
## **نمای کلی**

این مقاله نحوهٔ سفارشی‌سازی محورهای نمودار با Aspose.Slides برای Android از طریق Java را توضیح می‌دهد. موضوعاتی چون مقادیر محاسبه شدهٔ محور، جابجایی ردیف‌ها و ستون‌های نمودار، قابلیت مشاهدهٔ محور، فاصلهٔ برچسب‌های دسته و عبارت‌های تیک‌مارک، دسته‌های تاریخ و قالب‌بندی، چرخش عنوان، موقعیت‌یابی محور، واحدهای نمایش و مقیاس لگاریتمی را پوشش می‌دهد.

## **دریافت حداکثر مقادیر محور عمودی در نمودارها**

یک [ارائه](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) ایجاد کنید و یک نمودار مساحتی با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه شدهٔ محور، برای به‌روز نگه داشتن طرح‌بندی نمودار، [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) را فراخوانی کنید.

[getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) و [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) را برای محدودیت‌های محور بخوانید و [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) و [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) را برای فواصل تیک‌ها دریافت کنید. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) و [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) مقیاس‌های واحد زمانی را فراهم می‌کنند که برای محورهای تاریخ مرتبط هستند. این مثال این مقادیر را در متغیرهای محلی ذخیره کرده و نمودار را ذخیره می‌کند.

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

برای تعویض نقش سری‌ها و دسته‌ها در داده‌های نمودار از [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) استفاده کنید. هر دستهٔ پیشین تبدیل به سری می‌شود و هر سری پیشین تبدیل به دسته. این کار نحوهٔ گروه‌بندی داده‌ها را تغییر می‌دهد؛ محورهای افقی و عمودی را جابجا نمی‌کند. این مثال برای اتصال داده‌های پیش‌فرض به `Sheet1!A1:D5` (شامل ردیف سرعنوان و ستون دسته) قبل از جابجایی ردیف‌ها و ستون‌ها از [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) استفاده می‌کند. سپس نموداری با چهار سری و سه دسته ذخیره می‌شود.

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

## **غیرفعال‌سازی محور عمودی برای نمودارهای خطی**

برای مخفی کردن محور عمودی، [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) را با مقدار `false` فراخوانی کنید. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با محور عمودی مخفی ذخیره می‌کند.

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

برای مخفی کردن محور افقی، [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) را با مقدار `false` فراخوانی کنید. این مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد کرده و آن را با محور افقی مخفی ذخیره می‌کند.

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

برای انتخاب یک محور دسته‌ای تاریخ یا متن از [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) استفاده کنید. این مثال نیاز به `ExistingChart.pptx` دارد که در اولین شکل اسلاید اول یک نمودار داشته و سلول‌های دسته شامل مقادیر عددی تاریخ Excel هستند. محور افقی را به یک محور تاریخ تغییر می‌دهد. با فراخوانی [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) با مقدار `false`، [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) با مقدار `1`، و [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) با مقدار `TimeUnitType.Months` تیک‌های بزرگ را در فواصل یک ماهه قرار می‌دهد.

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

## **کنترل فواصل برچسب‌های محور دسته‌ای**

زمانی که یک نمودار دارای تعداد زیادی دسته باشد، می‌توانید تعداد برچسب‌های قابل مشاهدهٔ محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. ابتدا [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) را با مقدار `false` فراخوانی کنید، سپس فواصل دلخواه را با [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) تعیین کنید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته آغاز می‌شود:

| فواصل | برچسب‌های نمایش داده‌شده در مثال |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

فاصلهٔ `3` هر برچسب سوم را نمایش می‌دهد و دو برچسب بین برچسب‌های نمایش داده‌شده پنهان می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصلهٔ خودکار بر پایهٔ فضای موجود یک بازه انتخاب می‌کند؛ لزوماً همهٔ برچسب‌ها را نشان نمی‌دهد.

تیک‌مارک‌ها کنترل جداگانه‌ای دارند. با فراخوانی [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) با مقدار `false` و استفاده از [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) می‌توانید فواصل آن‌ها را تنظیم کنید. برای مثال، مقدار `1` یک تیک‌مارک را در هر فاصلهٔ دسته حفظ می‌کند در حالی که برچسب‌ها فقط هر سومین دسته ظاهر می‌شوند. با استفاده از [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) می‌توانید یک سبک قابل‌مشاهده انتخاب کنید. تنظیم‌کنندهٔ خودکار فواصل را دوباره با مقدار `true` فعال کنید تا نمودار بازهٔ مناسب را مجدداً انتخاب کند.

مثال زیر که به‌صورت مستقل عمل می‌کند، ۲۴ دسته و یک سری ایجاد می‌کند و سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصلهٔ خودکار، فاصلهٔ دستی برچسب‌ها با تیک‌مارک‌های مستقل، و بازگرداندن فاصلهٔ خودکار. دو نسخهٔ ذخیره‌شده داده‌های اصلی نمودار را حفظ می‌کنند. ارائهٔ ورودی نیازی نیست. متن برچسب افقی باعث می‌شود تفاوت چگالی به‌راحتی قابل مشاهده باشد.

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

    // اسلاید ۲: هر برچسب سوم را نشان بده، اما یک تیک‌مارک برای هر دسته حفظ کن.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // اسلاید ۳: اجازه بده نمودار دوباره هر دو بازه را انتخاب کند.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**فاصلهٔ خودکار (اسلاید ۱):** در این رندر، هر دومین برچسب دسته‌ای نمایش داده می‌شود و به دو خط می‌پیچد. نتیجهٔ خودکار ممکن است با اندازهٔ نمودار، فونت‌ها و رندرر متفاوت باشد.

![فاصلهٔ خودکار برچسب دسته‌ای با تمام ۲۴ ستون قابل مشاهده](category-axis-automatic.png)

**فاصلهٔ دستی (اسلاید ۲):** هر سومین برچسب در یک خط نمایش داده می‌شود، در حالی که تیک‌مارک‌ها در هر فاصلهٔ دسته باقی می‌مانند. تمام ۲۴ ستون، حتی آن‌هایی که برچسب ندارند، با همان مقادیر قابل مشاهده‌اند. اسلاید ۳ ظاهر خودکار را که در بالا نشان داده شده بازگردانده است.

![فاصلهٔ دستی برچسب دسته‌ای به مقدار سه با تمام ۲۴ ستون قابل مشاهده](category-axis-manual.png)

### **انتخاب محور و فاصلهٔ صحیح**

از این بازهٔ شمارش دسته برای یک محور دسته‌ای متنی استفاده کنید، مانند محور دسته‌ای یک نمودار ستون، خط، مساحت یا میله‌ای. در نمودار ستون، این محور افقی است. در نمودار میله‌ای افقی، محور دسته‌ای عمودی است، بنابراین این تنظیمات را بر روی محوری که توسط [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) برگردانده می‌شود اعمال کنید. فاصلهٔ تیک‌مارک همچنین برای محور سری در نمودارهایی که یکی دارند قابل‌استفاده است.

از فاصلهٔ برچسب دسته‌ای برای تنظیم مقیاس عددی یک محور مقدار استفاده نکنید. در یک محور مقدار، [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) اختلافی در مقادیر تعیین می‌کند: به عنوان مثال، یک واحد اصلی `10` تیک‌هایی در ۰، ۱۰، ۲۰ و غیره ایجاد می‌کند وقتی محور از صفر شروع شود. یک فاصلهٔ برچسب دسته‌ای `3` به‌جای مقادیر داده‌ای، موقعیت‌های دسته‌ای را می‌شمارد. نمودارهای پراکنده و حبابی از محورهای مقدار استفاده می‌کنند نه از محور دسته‌ای متنی. برای محور تاریخ، از واحدهای اصلی زمان‌محور و مقیاس‌های توصیف‌شده در [تغییر محور دسته‌ای](#change-a-category-axis) استفاده کنید.

## **تنظیم قالب تاریخ برای مقادیر محور دسته‌ای**

این مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به‌صورت شماره‌های سریال OLE Automation در اولین ورک‌شیٹ (اندیس `0`) ذخیره می‌شوند که به‌عنوان تعداد روزهای سپری شده از ۳۰ دسامبر ۱۸۹۹ محاسبه می‌شوند. هر دو تقویم از UTC استفاده می‌کنند و پیش از تنظیم تاریخ‌ها پاک می‌شوند تا تغییر ساعت تابستانی و زمان فعلی روز تأثیری نداشته باشد. با استفاده از [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) مقدار `CategoryAxisType.Date`، سپس [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) را با `false` فراخوانی کنید و `yyyy` را به [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) بدهید تا برچسب‌های دسته چهار رقم سال را صرف‌نظر از قالب سلول نمایش دهند.

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

برای محور عمودی، [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) را با مقدار `true` فراخوانی کنید، متن عنوان را فراهم کنید و با [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) زاویهٔ چرخش را تنظیم کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستون را با عنوان محور مقدار که به‌صورت ۹۰ درجه چرخانده شده ذخیره می‌کند.

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

## **تنظیم موقعیت محور در محور دسته‌ای یا مقدار**

برای کنترل اینکه آیا محور مقدار در بین دسته‌ها یا روی تیک‌مارک‌های دسته عبور می‌کند از [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) استفاده کنید. این تنظیم برای محورهای دسته‌ای اعمال می‌شود. مثال این ویژگی را روی محور دسته‌ای افقی یک نمودار ستون با مقدار `true` تنظیم کرده و نتیجه را ذخیره می‌کند.

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

## **تنظیم واحد نمایش در محور مقدار نمودار**

برای مقیاس‌بندی برچسب‌های یک محور مقدار بدون تغییر داده‌های پایه از [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) استفاده کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) به `Millions`، مقدار ۶۰٬۰۰۰٬۰۰۰ به صورت ۶۰ نمایش داده می‌شود. این مثال یک نمودار ستون ایجاد کرده و واحد نمایش «میلیون‌ها» را بر روی محور عمودی اعمال می‌کند.

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

یک محور مقدار لگاریتمی زمانی مفید است که مقادیر مثبت در چندین مقیاس مختلف قرار داشته باشند. به‌عنوان مثال، ممکن است یک سرویس در پنج دورهٔ زمانی ۱۰، ۱۰۰، ۱٬۰۰۰، ۱۰٬۰۰۰ و ۱۰۰٬۰۰۰ درخواست دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر به‌هم می‌چسبند. مقیاس لگاریتمی رشد نسبی آن‌ها را به‌صورت برابر توزیع می‌کند: فواصل مساوی نمایانگر نسبت‌های مساوی هستند نه اختلاف‌های عددی.

با فراخوانی [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) مقدار `true` بر روی محور مقدار و استفاده از [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) می‌توانید پایه را انتخاب کنید. این کار نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها یا خط روند لگاریتمی را اضافه نمی‌کند. خط روند یک ویژگی جداگانه است که رابطهٔ برازش شده در داده‌ها را نشان می‌دهد.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خط یا ستون، محور مقدار توسط [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) برگردانده می‌شود. برای یک نمودار میله‌ای افقی، محور مقدار توسط [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) برگردانده می‌شود. نمودارهای پراکنده و حبابی دو محور مقدار دارند، بنابراین می‌توانید محور افقی را برای مقادیر X، محور عمودی را برای مقادیر Y یا هر دو استفاده کنید. مقیاس لگاریتمی را روی محور دسته‌ای اعمال نکنید.

پایه پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX می‌توانید پایه‌ای بین `2` تا `1000` (شامل) استفاده کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایه `10` توان‌های متوالی مانند 10، 100، 1٬000 و 10٬000 به‌صورت مساوی فاصله دارند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال زیر که به‌صورت مستقل کار می‌کند، یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی کرده و در اسلاید دوم محور مقدار لگاریتمی پایه‑10 را فعال می‌کند. هر دو اسلاید داده‌های یکسانی را حفظ می‌کنند.

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

    // اسلاید اول را خطی نگه دارید و تنها مقیاس محور مقدار نسخهٔ کپی را تغییر دهید.
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

**مقیاس خطی (اسلاید ۱):** فواصل عمودی مساوی نشان‌دهندهٔ اختلاف‌های مساوی در شمارش درخواست‌ها هستند. بزرگ‌ترین مقدار نمودار را اشباع می‌کند و مقادیر کوچکتر دشوار به‌نظر می‌رسند.

![نمودار خطی در PowerPoint که پنج شمارش درخواست را بر روی محور مقدار خطی نشان می‌دهد](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید ۲):** فواصل عمودی مساوی نشان‌دهندهٔ نسبت‌های مساوی هستند. هر دوره درخواست‌ها ده برابر دورهٔ قبلی دارد، بنابراین نقاط در مقیاس پایه‑10 یک خط صعودی مستقیم تشکیل می‌دهند. برچسب‌های محور هنوز مقادیر اصلی درخواست‌ها را نشان می‌دهند.

![همان پنج شمارش درخواست در PowerPoint بر روی یک محور مقدار لگاریتمی پایه‑10](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

مقیاس لگاریتمی فقط مقادیر مثبت صریح را می‌تواند نمایش دهد. قبل از فعال‌سازی آن داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنی‌دار هستند، مقیاس خطی را حفظ کنید یا آنها را جداگانه نشان دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را توضیح دهید. به‌صورت خاموش آن‌ها را با عددهای مثبت کوچک جایگزین نکنید، زیرا معنا را تغییر می‌دهد. هر مقدار حداقل یا حداکثر به‌صورت دستی تنظیم‌شده برای یک محور لگاریتمی نیز باید مثبت باشد.

## **پرسش‌های متداول**

**چگونه مقدار نقطهٔ تقاطع یک محور با محور دیگر (crossing) را تنظیم کنم؟**

از [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) برای انتخاب رفتار تقاطع استفاده کنید. برای تعیین مقدار عددی تقاطع، از [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) استفاده کنید. این تنظیمات به شما امکان می‌دهد تقاطع محور را به خط مبنای مناسب منتقل کنید.

**چگونه می‌توانم برچسب‌های تیک را نسبت به محور موقعیت‌دهی کنم؟**

با فراخوانی [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) و استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/) مقادیر `Low`، `High`، `NextTo` یا `None` موقعیت برچسب‌ها را تنظیم کنید. برای کنترل خود تیک‌مارک‌ها، از [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) یا [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) استفاده کنید؛ این تنظیمات جدا از موقعیت‌دهی برچسب‌ها هستند.