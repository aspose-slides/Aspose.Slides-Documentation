---
title: مدیریت سری‌های داده نمودار در ارائه‌ها بر روی Android
linktitle: سری داده‌ها
type: docs
url: /fa/androidjava/chart-series/
keywords:
- سری‌های نمودار
- همپوشانی سری
- رنگ سری
- نام سری
- نقطه داده
- سلول کتاب‌کار
- فاصله سری
- مقدار منفی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه در ارائه‌های Android سری‌های نمودار، نقاط داده، سلول‌های کتاب‌کار، قالب‌بندی، همپوشانی، عرض فاصله و مقادیر منفی را مدیریت کنید."
---
## **نمای کلی**

یک نمودار داده‌های ترسیم‌شده خود را در یک کتاب‌کار داده نمودار ذخیره می‌کند. یک [IChartSeries](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/) نمایانگر یک مجموعه از مقادیر مرتبط است و هر [IChartDataPoint](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/) در این مجموعه به یک یا چند سلول کتاب‌کار ارجاع می‌دهد. اشیاء [IChartCategory](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartcategory/) برچسب‌ها یا مقادیر گروه‌بندی که بین مجموعه‌ها مشترک است را فراهم می‌کنند. بنابراین نام مجموعه، دسته‌ها و مقادیر نقاط به اشیاء [IChartDataCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/) متصل هستند و تنها به‌صورت متن نمایش ذخیره نمی‌شوند.

برای یک نمودار دسته‌بندی معمول، کتاب‌کار پیش‌فرض از ردیف 0 برای نام‌های مجموعه، ستون 0 برای نام‌های دسته و سلول‌های باقی‌مانده برای مقادیر مجموعه استفاده می‌کند. اندیس‌های ورق‌کار، ردیف و ستون که به [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) پاس داده می‌شوند، صفر‑مبنا هستند. این چیدمان هنگام ایجاد نمودار با داده‌های پیش‌فرض مفید است، اما فرض نکنید که هر نمودار موجود از آن استفاده می‌کند. برای یک ارائه بارگذاری‌شده، قبل از تغییر مقادیر کتاب‌کار، سلول‌های ارجاع‌داده‌شده توسط مجموعه‌ها، دسته‌ها و نقاط داده را بررسی کنید.

تنظیمات نمودار در سه دامنه متفاوت هستند:

- تنظیمات در سطح مجموعه، مانند [IChartSeries.getFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getFormat--)، ظاهر پیش‌فرض تمام نقاط یک مجموعه را تعیین می‌کند.
- تنظیمات نقطه داده، مانند [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--)، ظاهر مجموعه را برای یک نقطه بازنویسی می‌کند.
- تنظیمات گروهی برای مجموعه‌های سازگاری که به یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/) تعلق دارند اعمال می‌شود. برای تنظیم گزینه‌هایی مانند همپوشانی یا عرض فاصله، از طریق [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) به گروه دسترسی پیدا کنید.

هنگامی که پر کردن صریحی برای نقطه یا مجموعه تنظیم نشده باشد، سبک و تم نمودار ظاهر خودکار را تعیین می‌کند. وقتی هم پر کردن مجموعه و هم نقطه وجود داشته باشد، پر کردن نقطه برای آن نقطه برتری دارد.

![نمودار‑سری‑پاورپوینت](chart-series-powerpoint.png)

## **تنظیم همپوشانی سری نمودار**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getOverlap--) گزارش می‌دهد که نوارها یا ستون‌ها در یک نمودار دو‑بعدی تا چه اندازه از هم همپوشانی دارند؛ مقدار از ‑۱۰۰ تا ۱۰۰ درصد است. این مقدار تنها یک تصویر خواندنی از تنظیمات گروه مجموعه والد است. برای به‌روزرسانی همه مجموعه‌های سازگار در آن گروه از [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) استفاده کنید. این گزینه برای انواع نموداری که نوارها یا ستون‌های گروهی نمایش می‌دهند اعمال می‌شود؛ بر گروه‌های مجموعه نامرتبط در یک نمودار ترکیبی تأثیر ندارد.

مثال زیر همپوشانی گروهی که شامل اولین مجموعه است را تنظیم می‌کند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // نمودار جدید شامل سری‌های نمونه، دسته‌ها و مقادیر است.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![همپوشانی سری‌ها](series_overlap.png)

## **تغییر رنگ پرکننده سری**

از [IChartSeries.getFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getFormat--) برای تنظیم پر کردن پیش‌فرض یک مجموعه کامل استفاده کنید. اگر یک نقطه پر کردن صریح داشته باشد، تنظیمات [IChartDataPoint.getFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) آن، پر کردن مجموعه را برای آن نقطه بازنویسی می‌کند.

مثال زیر پر کردن آبی جامد را به اولین مجموعه اعمال می‌کند:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![رنگ سری](series_color.png)

## **تغییر نام سری**

نام یک سری در کتاب‌کار داده نمودار ذخیره می‌شود و به‌طور معمول در توضیح‌نامه (Legend) نمایش داده می‌شود. در کتاب‌کار پیش‌فرض ایجاد‌شده برای یک نمودار ستونی گروهی، سلول B1 در ردیف 0، ستون 1 قرار دارد و شامل نام اولین سری است. ثابت‌های نام‌دار در مثال زیر این ساختار را واضح می‌سازند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

همچنین می‌توانید سلولی را که توسط [IChartSeries.getName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getName--) ارجاع داده شده است، به‌روزرسانی کنید. این روش از فرض یک ردیف و ستون خاص در یک نمودار موجود جلوگیری می‌کند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![نام سری](series_name.png)

## **دریافت رنگ پرکننده خودکار سری**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) رنگی را برمی‌گرداند که از اندیس سری و سبک نمودار به‌عنوان عدد صحیح ARGB اندروید محاسبه می‌شود. این همان رنگی است که وقتی پرکننده سری به‌صورت صریح تعریف نشده باشد، استفاده می‌شود. فراخوانی این متد فقط رنگ محاسبه‌شده را می‌خواند؛ مقدار جدیدی برای پر کردن اختصاص نمی‌دهد.

مثال زیر عدد صحیح رنگ خودکار هر سری پیش‌فرض را چاپ می‌کند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

مقادیر عددی دقیق بسته به سبک و تم نمودار متفاوت است.

## **تنظیم رنگ پرکننده معکوس برای یک سری نمودار**

برای مجموعه‌های نوار، ستون و حباب، [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) می‌تواند مقادیر منفی را با پرکننده متفاوتی نمایش دهد. پرکننده معمولی سری را به حالت جامد تنظیم کنید، واژگونی را فعال کنید و رنگ مقدار منفی را از طریق [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) اختصاص دهید. اعداد منفی در کتاب‌کار تغییر نمی‌کنند؛ فقط رنگ نمایش آن‌ها تغییر می‌یابد.

مثال زیر داده‌های پیش‌فرض نمودار را با یک سری جایگزین می‌کند. ردیف 0 ورق‌کار شامل نام سری، ستون 0 شامل نام‌های دسته و ستون 1 شامل مقادیر است:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![رنگ پرکننده جامد معکوس](inverted_solid_fill_color.png)

می‌توانید برای یک نقطه با استفاده از [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) واژگونی را فعال کنید. در مثال زیر واژگونی برای کل سری غیرفعال و فقط برای نقطه انتخاب‌شده فعال می‌شود. این نقطه نیز مقدار منفی دریافت می‌کند تا اثر قابل مشاهده باشد:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پاک کردن مقدار یک نقطه داده خاص**

برای خالی کردن یک نقطه بدون حذف سایر نقاط، سلول کتاب‌کار پشت آن را به `null` تنظیم کنید. برای یک نمودار ستونی، مقدار ترسیم‌شده از طریق [IChartDataPoint.getValue](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) در دسترس است. نقطه داده در همان موقعیت دسته باقی می‌ماند، اما نمودار مقدار آن را به‌عنوان خالی بر اساس تنظیمات مقدار خالی نمودار در نظر می‌گیرد.

مثال زیر تنها نقطه دوم در اولین سری را پاک می‌کند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نمودارهای پراکنده از سلول‌های X و Y جداگانه استفاده می‌کنند و نمودارهای حباب نیز یک سلول اندازه دارند. فقط سلولی را که نشان‌دهنده مقداری است که می‌خواهید حذف کنید، پاک کنید. هنگامیکه می‌خواهید سایر نقاط را نگه دارید، از فراخوانی [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) خودداری کنید زیرا این متد همه نقاط داده را از مجموعه حذف می‌کند.

## **تنظیم عرض فاصله سری**

عرض فاصله، فضای بین خوشه‌های نوار یا ستون مجاور است که به‌صورت درصدی از عرض نوار یا ستون بیان می‌شود. همانند همپوشانی، این تنظیم به گروه مجموعه والد تعلق دارد نه به یک مجموعه منفرد. برای گروه یک‌بار [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) را فراخوانی کنید. مقدار بزرگتر فضای بیشتری بین خوشه‌ها ایجاد می‌کند؛ مقدار کوچک‌تر آن‌ها را متراکم‌تر می‌کند.

مثال زیر عرض فاصله را تغییر می‌دهد و تنها ارائه نهایی را ذخیره می‌کند:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![عرض فاصله](gap_width.png)

## **سوالات متداول**

**کدام انواع نمودار از سری‌های داده پشتیبانی می‌کنند؟**

تمامی انواع نمودار که توسط enum [ChartType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/charttype/) نمایان شده‌اند از داده‌های نمودار استفاده می‌کنند، اما ساختار یا تنظیمات مقدار سری‌های آن‌ها یکسان نیست. به‌عنوان مثال، نمودارهای دسته‌ای از دسته‌ها و مقادیر استفاده می‌کنند، نمودارهای پراکنده از مقادیر X و Y، و نمودارهای حباب اندازه حباب‌ها را اضافه می‌کنند. از روش ایجاد نقطه داده‌ای استفاده کنید که با نوع سری مطابقت دارد. گزینه‌هایی مانند همپوشانی و عرض فاصله فقط برای گروه‌های نوار یا ستون سازگار اعمال می‌شوند.

**گروه سری نمودار چیست؟**

یک [IChartSeriesGroup](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/) شامل سری‌های سازگاری است که تنظیمات ترسیم سطح‌گروه را به اشتراک می‌گذارند. یک نمودار ترکیبی می‌تواند بیش از یک گروه داشته باشد، بنابراین تغییر گروهی که از طریق یک سری به آن دست می‌یابید لزوماً همه سری‌های نمودار را تغییر نمی‌دهد.

**آیا یک نمودار تازه ایجادشده شامل داده‌های پیش‌فرض است؟**

بله. به‌طور پیش‌فرض، متد [IShapeCollection.addChart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) نمونه‌ای از سری‌ها، دسته‌ها و مقادیر را ایجاد می‌کند. می‌توانید این سلول‌ها را ویرایش کنید یا قبل از افزودن یک مجموعه داده کاملاً سفارشی، هر دو مجموعه سری و دسته را پاک کنید. یک overload نیز می‌تواند نموداری بدون داده پیش‌فرض ایجاد کند.

**چگونگی ارتباط اشیاء نمودار با سلول‌های کتاب‌کار؟**

نام‌های سری، برچسب‌های دسته و مقادیر نقطه داده به سلول‌های یک [IChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/) ارجاع می‌دهند. تغییر یک سلول ارجاع‌شده، عنصر مربوط به نمودار را به‌روزرسانی می‌کند. هنگام ساخت داده سفارشی، ردیف‌های دسته و ردیف‌های مقدار سری را طوری تنظیم کنید که هر نقطه زیر دسته موردنظر ترسیم شود.

**چگونه یک نقطه را به‌جای پاک کردن کل سری حذف کنم؟**

سلول مقدار مربوطه را به `null` تنظیم کنید تا موقعیت دسته نقطه به‌عنوان نقطه خالی باقی بماند. فقط زمانی که قصد حذف تمام نقاط یک سری را دارید از [IChartDataPointCollection.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) استفاده کنید. اگر همزمان دسته‌ها را حذف می‌کنید، هر سری را به‌روزرسانی کنید تا مقادیر آن‌ها با مجموعه دسته‌ها هم‌راستا بماند.

**نقاط خالی چگونه نمایش داده می‌شوند؟**

نتیجه بسته به نوع نمودار و مقداری که از طریق [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) پیکربندی شده است، متفاوت است. نمودارهای پشتیبانی‌شده می‌توانند خالی‌ها را به‌عنوان فاصله، مقدار صفر یا با اتصال نقاط همسایه نمایش دهند. تنظیمی را انتخاب کنید که معنای داده‌های گمشده در ارائه شما را بازتاب دهد.

**مقادیر منفی چگونه قالب‌بندی می‌شوند؟**

برای سری‌های نوار، ستون و حباب پشتیبانی‌شده، [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) را فراخوانی کنید و رنگی که توسط [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) بازگردانده می‌شود را تنظیم کنید. می‌توانید رفتار را برای یک نقطه جداگانه با [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) بازنویسی کنید. این متدها صرفاً قالب‌بندی را تحت تأثیر قرار می‌دهند، نه مقادیر عددی ذخیره‌شده.

**زمانی که هم سری و هم نقطه قالب‌بندی شده باشند، کدام یک برتری دارد؟**

قالب‌بندی صریح نقطه داده برای آن نقطه برتری دارد. سایر نقاط به قالب صریح سری یا وقتی قالب سری تعریف نشده باشد، به سبک و تم خودکار نمودار ادامه می‌دهند. تنظیمات گروهی مانند همپوشانی و عرض فاصله برچیدگی را کنترل می‌کنند و بازنویسی‌های قالب‌بندی سطح نقطه نیستند.

**آیا محدودیتی برای تعداد سری‌های قابل‌استفاده در یک نمودار وجود دارد؟**

Aspose.Slides محدودیت ثابت جداگانه‌ای برای تعداد سری‌ها اعمال نمی‌کند. در عمل، محدودیت‌های فایل ارائه، حافظه موجود، زمان رندر و قابلیت خوانایی نمودار تعیین‌کننده حد قابل‌قبولی هستند.

**هنگامی که ستون‌ها بیش از حد نزدیک یا دور هستند، چه کاری باید انجام دهم؟**

بر روی گروه مجموعه والد مناسب از [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) فراخوانی کنید. برای افزایش فاصلۀ بین خوشه‌ها مقدار را بالا ببرید یا برای نزدیک‌تر شدن به‌یکدیگر مقدار را پایین ببرید.