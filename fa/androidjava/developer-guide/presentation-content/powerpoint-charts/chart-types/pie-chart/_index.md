---
title: سفارشی‌سازی نمودارهای دایره‌ای در ارائه‌ها بر روی Android
linktitle: نمودار دایره‌ای
type: docs
url: /fa/androidjava/pie-chart/
keywords:
- نمودار دایره‌ای
- مدیریت نمودار
- سفارشی‌سازی نمودار
- گزینه‌های نمودار
- تنظیمات نمودار
- گزینه‌های رسم
- رنگ برش
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی نمودارهای دایره‌ای در Android با Aspose.Slides برای Android از طریق Java. پیکربندی نمودارهای ثانوی، نمایش برچسب‌های داده و اعمال رنگ‌های خودکار برش در PowerPoint."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه با چارت‌های دایره‌ای در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه گزینه‌های نمودار ثانوی برای چارت‌های Pie of Pie و Bar of Pie را پیکربندی کنید و چگونه رنگ‌آمیزی خودکار برش‌ها را برای یک چارت دایره‌ای استاندارد فعال کنید.

مثال‌ها بر وظایف سفارشی‌سازی چارت متمرکز هستند، مانند اضافه کردن یک چارت به اسلاید، تنظیم سری‌ها و برچسب‌ها، جایگزینی داده‌های پیش‌فرض چارت با دسته‌ها و مقادیر سفارشی، و ذخیره ارائه به‌روز شده.

## **گزینه‌های نمودار ثانوی برای چارت‌های Pie of Pie و Bar of Pie**

Aspose.Slides برای Android از طریق Java از گزینه‌های نمودار ثانوی برای چارت‌های Pie of Pie و Bar of Pie پشتیبانی می‌کند. این گزینه‌ها اندازه نمودار ثانوی و نحوه تقسیم نقاط داده بین دو نمودار را کنترل می‌کنند.

مثال زیر یک چارت Pie of Pie را در یک ارائه جدید ایجاد می‌کند و مقادیر نقاط داده را به‌عنوان برچسب نمایش می‌دهد. متد [setSecondPieSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) اندازه نمودار ثانوی را به 149٪ از نمودار اصلی تنظیم می‌کند. متد [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) تقسیم مبتنی بر درصد را انتخاب می‌کند و متد [setPieSplitPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) آستانه را به 53٪ تنظیم می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // نمایش مقادیر و پیکربندی نمودار ثانوی.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **انتخاب دسته‌ها برای نمودار ثانوی**

از تقسیم سفارشی استفاده کنید وقتی می‌خواهید دسته‌های خاصی را در نمودار ثانوی گروه‌بندی کنید بدون توجه به مقادیر درصدی آنها. به‌عنوان مثال، یک گزارش فروش ممکن است Online و Events را با هم نشان دهد تا خوانندگان بتوانند این دو کانال را مقایسه کنند، حتی اگر 35٪ و 10٪ از کل فروش را تشکیل دهند.

متد [setPieSplitBy](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) را با مقدار [PieSplitType.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplittype/#Custom) فراخوانی کنید و نقاط را از طریق [getPieSplitCustomPoints](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--) انتخاب کنید. متد [add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#add-int-) این مجموعه یک ایندکس صفر‑پایه در سری می‌گیرد؛ از [addItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) برای افزودن یک شیء نقطه داده استفاده کنید. در این مثال، ایندکس 1 Online را انتخاب می‌کند و نقطه‌ای با ایندکس 3 Events را انتخاب می‌کند. Partners نیز به‌صورت موقت اضافه می‌شود، سپس با استفاده از [removeItem](https://reference.aspose.com/slides/androidjava/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-) حذف می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // جایگزینی داده‌های پیش‌فرض با فروش بر اساس کانال.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // انتخاب Online با ایندکس صفر پایه و Events با شیء نقطه داده.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // حذف Partners از انتخاب بدون حذف داده منبع آن.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) و Events (10) به‌عنوان برش‌های جداگانه در نمودار ثانوی ظاهر می‌شوند. در نمودار اصلی، آنها به‌صورت یک برش ترکیبی با مقدار 45، به‌همراه Retail (40) و Partners (15) نشان داده می‌شوند. حذف Partners از انتخاب سفارشی فقط آن را از نمودار ثانوی حذف می‌کند؛ دسته یا مقدار آن از داده منبع چارت حذف نمی‌شود.

تصویر زیر ارائه ذخیره‌شده در PowerPoint را نشان می‌دهد:

![چارت Pie of Pie با Online و Events در نمودار ثانوی و مقدار ترکیبی 45 آن در نمودار اصلی](pie_of_pie_custom.png)

## **تنظیم رنگ‌های خودکار برش چارت دایره‌ای**

Aspose.Slides برای Android از طریق Java می‌تواند به‌صورت خودکار به برش‌های چارت دایره‌ای رنگ‌های متفاوت اختصاص دهد. مثال زیر یک چارت دایره‌ای با عنوان مرکزی ایجاد می‌کند و داده‌های پیش‌فرض را با سه دسته سه‌ماهه و مقادیرشان جایگزین می‌نماید. متد [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) مقادیر 20، 50 و 30 را به‌عنوان برچسب نمایش می‌دهد، در حالی که متد [setColorVaried](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) رنگ متمایزی برای هر برش فعال می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // افزودن عنوان مرکزچین شده به چارت.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // جایگزینی داده‌های پیش‌فرض با استفاده از اولین کاربرگ.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // نمایش مقادیر و تخصیص رنگ‌های متفاوت به برش‌ها.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا انواع Pie of Pie و Bar of Pie پشتیبانی می‌شوند؟**

بله، کتابخانه [پشتیبانی می‌کند](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) از یک نمودار ثانوی برای چارت‌های دایره‌ای، شامل انواع Pie of Pie و Bar of Pie.

**آیا می‌توانم فقط چارت را به‌عنوان تصویر (به‌عنوان مثال PNG) صادر کنم؟**

بله، می‌توانید [صدور خود چارت به عنوان تصویر](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) (مانند PNG) را بدون صادر کردن کل ارائه انجام دهید.