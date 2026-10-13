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
- Java
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید از Aspose.Slides برای جاوا استفاده کنید تا محورهای نمودار را در ارائه‌های PowerPoint برای گزارش‌ها و تجسم‌ها سفارشی کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه محورهای نمودار را با Aspose.Slides برای Java سفارشی کنید. این مقاله به مقادیر محاسبه‌شده محور، تعویض سطرها و ستون‌های نمودار، نمایش محور، فواصل برچسب‌های دسته و علامت‌های تیک، دسته‌های تاریخی و فرمت‌بندی، چرخش عنوان، موقعیت محور، واحدهای نمایش و مقیاس لگاریتمی می‌پردازد.

## **دریافت حداکثر مقادیر در محور عمودی نمودارها**

یک [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ایجاد کنید و یک نمودار ناحیه‌ای با داده‌های پیش‌فرض اضافه کنید. قبل از خواندن مقادیر محاسبه‌شده محور، [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) را صدا بزنید تا طرح‌بندی نمودار به‌روز باشد.

[ getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) و [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) را برای محدودیت‌های محور بخوانید و برای فواصل تیک‌ها [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) و [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) را فراخوانی کنید. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) و [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) مقیاس‌های زمان‑واحد را فراهم می‌کنند که برای محورهاى تاریخ مناسب هستند. مثال این مقادیر را در متغیرهای محلی ذخیره می‌کند و نمودار را ذخیره می‌نماید.

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

## **تعویض داده‌ها بین محورها**

از [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) برای تعویض نقش‌های سری‌ها و دسته‌ها در داده‌های نمودار استفاده کنید. هر دستهٔ قبلی تبدیل به یک سری می‌شود و هر سریٔ قبلی تبدیل به یک دسته. این کار فقط نحوهٔ گروه‌بندی داده‌ها را تغییر می‌دهد؛ محورهای افقی و عمودی را جابجا نمی‌کند. مثال از [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) برای بایند کردن داده‌های پیش‌فرض به `Sheet1!A1:D5`، شامل ردیف سرآیند و ستون دسته، قبل از تعویض سطرها و ستون‌ها استفاده می‌کند. سپس نموداری با چهار سری و سه دسته ذخیره می‌کند.

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

## **غیرفعال‌سازی محور عمودی در نمودارهای خطی**

روی محور عمودی، [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) را با مقدار `false` فراخوانی کنید تا مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور عمودی مخفی ذخیره می‌نماید.

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

## **غیرفعال‌سازی محور افقی در نمودارهای خطی**

روی محور افقی، [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) را با مقدار `false` فراخوانی کنید تا مخفی شود. مثال یک نمودار خطی با داده‌های پیش‌فرض ایجاد می‌کند و آن را با محور افقی مخفی ذخیره می‌نماید.

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

از [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) برای انتخاب یک محور دسته‌ای تاریخ یا متن استفاده کنید. این مثال به فایل `ExistingChart.pptx` نیاز دارد که در اولین اسلاید اولین شکل یک نمودار است و سلول‌های دسته مقادیر عددی تاریخ Excel را دارند. محور افقی به یک محور تاریخ تغییر می‌کند. با فراخوانی [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) با `false`، [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) با مقدار `1` و [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) با `TimeUnitType.Months` تیک‌های اصلی هر ماه تنظیم می‌شوند.

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

هنگامی که یک نمودار دسته‌های بسیاری داشته باشد، می‌توانید تعداد برچسب‌های قابل مشاهده محور را بدون حذف دسته‌ها یا نقاط داده کاهش دهید. [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) را با `false` صدا بزنید، سپس فاصلهٔ دلخواه دسته را به [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) پاس دهید. برای دسته‌های متنی در ترتیب عادی، شمارش از اولین دسته آغاز می‌شود:

| Interval | Labels displayed in the example |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

یک فاصلهٔ `3` هر برچسب سوم را نمایش می‌دهد و دو برچسب بین هر دو برچسب نشان‌داده‑شده مخفی می‌مانند. این کار ستون‌های مربوطه را حذف نمی‌کند. فاصلهٔ خودکار بر پایهٔ فضای موجود یک فاصله انتخاب می‌کند؛ لزوماً همهٔ برچسب‌ها را نشان نمی‌دهد.

علامت‌های تیک کنترل‌های جداگانه‌ای دارند. [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) را با `false` صدا بزنید و از [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) برای تنظیم فاصلهٔ آن‌ها استفاده کنید. برای مثال، مقدار `1` یک علامت تیک در هر فاصلهٔ دسته حفظ می‌کند در حالی که برچسب‌ها فقط هر سومین دسته نمایش داده می‌شوند. از [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) با یک سبک قابل رؤیت استفاده کنید تا نتیجه را ببینید. فراخوانی هر یک از تنظیم‌کننده‌های خودکار با مقدار `true` مجدداً به نمودار اجازه می‌دهد تا همان فاصله را انتخاب کند.

مثال خودکفا زیر ۲۴ دسته و یک سری ایجاد می‌کند، سپس سه اسلاید در `CategoryAxisIntervals.pptx` ذخیره می‌کند: فاصله‌گذاری خودکار، فاصله‌گذاری دستی برچسب‌ها با علامت‌های تیک مستقل، و بازگرداندن فاصله‌گذاری خودکار. دو نسخهٔ کپی داده‌های اصلی نمودار را حفظ می‌کنند. پرزنتیشن ورودی نیازی نیست. متن برچسب افقی اختلاف چگالی را به‌راحتی نشان می‌دهد.

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

    // اسلاید ۲: هر برچسب سوم را نشان دهید، اما برای هر دسته یک علامت تیک نگه دارید.
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

**فاصله‌گذاری خودکار (اسلاید 1):** در این رندر، هر برچسب دوم دسته نمایش داده می‌شود و به دو خط می‌پیچد. نتیجهٔ خودکار می‌تواند بسته به اندازهٔ نمودار، فونت‌ها و رندرر متفاوت باشد.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**فاصله‌گذاری دستی (اسلاید 2):** هر سومین برچسب در یک خط نمایش داده می‌شود، در حالی که علامت‌های تیک در هر فاصلهٔ دسته باقی می‌مانند. تمام ۲۴ ستون، حتی آنهایی که بدون برچسب هستند، با همان مقادیر قابل مشاهده هستند. اسلاید ۳ ظاهر خودکار نشان‑داده‌شده در بالا را بازمی‌گرداند.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **انتخاب محور و فاصلهٔ صحیح**

از این فاصلهٔ شمارش برای یک محور دسته‌ای متن استفاده کنید، مانند محور دسته‌ای یک نمودار ستون، خط، ناحیه یا میله. در یک نمودار ستون، این محور افقی است. در یک نمودار میله‌ای افقی، محور دسته‌ای عمودی است، بنابراین این تنظیمات را به محوری که [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) برمی‌گرداند اعمال کنید. فاصله‌گذاری علامت‌های تیک همچنین برای محور سری در نمودارهایی که یکی دارند، اعمال می‌شود.

از فاصله‌گذاری برچسب دسته برای تنظیم مقیاس عددی یک محور مقدار استفاده نکنید. در یک محور مقدار، [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) اختلافی در مقادیر مشخص می‌کند: به عنوان مثال، یک واحد اصلی `10` تیک‌های 0، 10، 20 و ... را زمانی که محور از صفر شروع می‌شود، تولید می‌کند. یک فاصلهٔ برچسب دسته‌ای `3` به جای مقادیر داده، موقعیت‌های دسته را می‌شمارد. نمودارهای پراکنده و حبابی از محورهای مقدار به‌جای محور دسته‌ای متن استفاده می‌کنند. برای یک محور تاریخ، از واحدهای اصلی زمان‑محور و مقیاس‌ها همان‌گونه که در [تغییر محور دسته‌ای](#change-a-category-axis) توضیح داده شده است، استفاده کنید.

## **تنظیم فرمت تاریخ برای مقادیر محور دسته‌ای**

مثال داده‌های پیش‌فرض نمودار را با چهار مقدار سالانه جایگزین می‌کند. تاریخ‌ها به عنوان اعداد سریال OLE Automation در اولین کاربرگ (شاخص `0`) ذخیره می‌شوند و عدد روزهای گذشته از 30 دسامبر 1899 محاسبه می‌شود. از [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) با `CategoryAxisType.Date`، سپس [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) با `false` و در نهایت `yyyy` به [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) پاس دهید تا برچسب‌های دسته سال‌های چهاررقمی را مستقل از قالب‌بندی سلول نشان دهند.

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

روی محور عمودی، [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) را با مقدار `true` فراخوانی کنید، متن عنوان را ارائه دهید و با [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) زاویهٔ چرخش را تنظیم کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک نمودار ستونی را با عنوان محور مقدار چرخانده به 90 درجه ذخیره می‌کند.

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

از [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) برای کنترل این که آیا محور مقدار در بین دسته‌ها یا در علامت‌های تیک دسته عبور می‌کند، استفاده کنید. این تنظیم برای محورهاى دسته اعمال می‌شود. مثال این مقدار را روی محور دسته‌ای افقی یک نمودار ستونی به `true` تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

از [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) برای مقیاس‌بندی برچسب‌های محور مقدار بدون تغییر داده‌های پایه استفاده کنید. با تنظیم [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) به `Millions`، مقدار 60 000 000 به شکل 60 نمایش داده می‌شود. مثال یک نمودار ستونی ایجاد می‌کند و واحد نمایش میلیون‌ها را بر محور عمودی آن اعمال می‌نماید.

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

یک محور مقدار لگاریتمی هنگامی مفید است که مقادیر مثبت در چندین مرتبهٔ قدرت متفاوت قرار گیرند. به عنوان مثال، یک سرویس ممکن است در پنج دوره درخواست‌های 10، 100، 1 000، 10 000 و 100 000 دریافت کند. در مقیاس خطی، مقادیر کوچکتر نزدیک به صفر به‌هم می‌چسبند. مقیاس لگاریتمی رشد نسبی آن‌ها را راحت‌تر مقایسه می‌کند: فواصل مساوی نمایانگر نسبت‌های مساوی هستند نه اختلاف‌های عددی.

[setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) را با مقدار `true` روی محور مقدار صدا بزنید و با [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) پایه را انتخاب کنید. این کار نحوهٔ نمایش مقادیر موجود را تغییر می‌دهد؛ داده‌ها را تغییر نمی‌دهد و خط روند لگاریتمی اضافه نمی‌کند. خط روند یک ویژگی جداگانه است.

### **انتخاب محور مقدار و پایه**

برای یک نمودار خط یا ستونی، محور مقدار توسط [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) بازگردانده می‌شود. برای یک نمودار میله‌ای افقی، این محور توسط [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) بازگردانده می‌شود. نمودارهای پراکنده و حبابی دو محور مقدار دارند؛ بنابراین برای مقادیر X محور افقی، برای مقادیر Y محور عمودی یا هر دو استفاده کنید. مقیاس لگاریتمی را روی محور دسته‌ای اعمال نکنید.

پایهٔ پیش‌فرض لگاریتمی `10` است. برای نمودارهای PPTX می‌توانید پایه‌ای بین `2` تا `1000` (شامل) انتخاب کنید؛ پایه‌های کسری مانند `2.5` نیز پشتیبانی می‌شوند. با پایهٔ `10` توان‌های متوالی 10، 100، 1 000، 10 000 به‌صورت مساوی فاصله‌گذاری می‌شوند.

### **مقایسه مقیاس خطی و لگاریتمی**

مثال خودکفا زیر یک نمودار خطی با پنج شمارش درخواست در اسلاید اول ایجاد می‌کند، سپس آن اسلاید را کپی می‌کند و در اسلاید دوم محور مقدار لگاریتمی با پایهٔ 10 فعال می‌کند. هر دو اسلاید همان داده‌ها را حفظ می‌کنند.

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

    // اسلاید اول را به‌صورت خطی نگه دارید و تنها مقیاس محور مقدار نسخه‌ی کپی‌شده را تغییر دهید.
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

**مقیاس خطی (اسلاید 1):** فواصل عمودی مساوی نمایانگر اختلاف‌های مساوی در شمارش درخواست‌ها هستند. مقدار بزرگتر بر نمودار غلبه می‌کند و مقادیر کوچک‌تر را تشخیص دشوار می‌سازد.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**مقیاس لگاریتمی (اسلاید 2):** فواصل عمودی مساوی نمایانگر نسبت‌های مساوی هستند. هر دوره ده برابر درخواست دورهٔ قبلی دارد، بنابراین نقاط در مقیاس پایه‑10 یک خط صعودی مستقیم تشکیل می‌دهند. برچسب‌های محور هنوز شمارش درخواست اصلی را نشان می‌دهند.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **مدیریت مقادیر صفر و منفی**

یک مقیاس لگاریتمی فقط مقادیر مثبت صریح را می‌تواند نمایش دهد. قبل از فعال‌سازی آن داده‌ها را بررسی کنید. اگر مقادیر صفر یا منفی معنا دار هستند، مقیاس خطی را حفظ کنید یا آن‌ها را به‌صورت جداگانه نشان دهید. اگر حذف این مقادیر برای تحلیل مناسب است، دلیل حذف را توضیح دهید. به‌طور ساکت آنها را با عددهای کوچک مثبت جایگزین نکنید، زیرا معنای داده را تغییر می‌دهد. هر حداقل یا حداکثر به‌صورت دستی تنظیم‌شده برای محور لگاریتمی نیز باید مثبت باشد.

## **سؤالات متداول**

**چگونه مقدار تقاطعی که یک محور با دیگری می‌رسد (crossing) را تنظیم کنم؟**

از [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) برای انتخاب رفتار تقاطع استفاده کنید. برای تعیین مقدار عددی تقاطع، از [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) استفاده کنید. این تنظیمات به شما امکان می‌دهند تقاطع محور را به یک خط پایه مناسب منتقل کنید.

**چگونه می‌توانم موقعیت برچسب‌های تیک را نسبت به محور تنظیم کنم؟**

[setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) را با استفاده از [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`، `High`، `NextTo` یا `None` فراخوانی کنید. برای کنترل خود علامت‌های تیک، از [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) یا [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-) استفاده کنید؛ این‌ها جدا از موقعیت برچسب‌ها هستند.