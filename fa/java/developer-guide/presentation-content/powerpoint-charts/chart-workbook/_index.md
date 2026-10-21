---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با استفاده از جاوا
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/java/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده نمودار
- سلول کتاب‌کار
- برچسب داده
- ورق‌کاری
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "Aspose.Slides برای جاوا را کشف کنید: به‌سادگی کتاب‌کارهای نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را به‌ینه‌وار سازماندهی کنید."
---
## **نمای کلی**

این مقاله نحوه کار با کتاب‌کارهای نمودار در Aspose.Slides را توضیح می‌دهد. نحوه خواندن و نوشتن داده‌های نمودار از طریق جریان‌های کتاب‌کار، استفاده از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار، دسترسی به مجموعه‌های برگه‌کاری، و تعیین نوع منبع داده برای مقادیر نمودار را نشان می‌دهد.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داده شود، مسیر کتاب‌کار خارجی پیوست‌شده به یک نمودار دریافت شود، و داده‌های نمودار زمانی که کتاب‌کار در دسترس است، ویرایش شود.

برای سلول‌های کتاب‌کار که داده‌های گمشده را نشان می‌دهند، به [کنترل نمایش سلول‌های خالی](/slides/fa/java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر، و مقایسه‌ نمودار خطی از حالت‌های نمایش موجود را ببینید.

## **شامل کردن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) برای کنترل این که آیا نمودار فقط از سلول‌های قابل مشاهده ورق‌کاری داده‌ها رسم شود یا نه استفاده کنید. مقدار `true` باعث رسم فقط سلول‌های قابل مشاهده می‌شود و `false` باعث شامل شدن هر دو سلول قابل مشاهده و مخفی می‌شود. این تنظیم فقط بر رسم نمودار تأثیر دارد؛ ردیف‌ها یا ستون‌های ورق‌کاری را مخفی یا آشکار نمی‌کند.

[ارائه نمونه](hidden-source-data.pptx) شامل یک نمودار ستونی به عنوان اولین شکل در اسلاید اول است. ورق‌کاری جاسازی‌شده، `Sheet1`، محدودهٔ منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها هنوز مقدار دارند.

| ردیف ورق‌کاری | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (سطر مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی داشته و با [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) وضعیت مخفی بودن آن‌ها را بررسی کنید. این متد فقط وضعیت مخفی را گزارش می‌دهد بدون اینکه آن را تغییر دهد. در این پرونده، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم رسم، داده‌های نمودار را تازه‌سازی کنید: کتاب‌کار جاسازی‌شده را با [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) نگه دارید و با [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) مجدداً بارگذاری کنید. هنگام شامل کردن تمام سلول‌ها، از [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) برای بازگرداندن محدودهٔ کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. فقط تغییر پرچم کافی نیست تا داده‌های کش‌شدهٔ این نمونه به‌روز شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // داده‌های نمودار را از کتاب‌کار جاسازی‌شده تازه کنید.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // محدودهٔ منبع کامل را بازگردانید، شامل دسته‌های مخفی.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

این مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر دو حالت رسم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده مخفی باقی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | تمام سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی که مقداری دارد با یک سلول خالی متفاوت است. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) کنترل می‌کند که مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم مخفی بودن دادهٔ منبع را دربر نمی‌گیرد. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/java/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **دریافت محدودهٔ دادهٔ یک نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، محدوده‌های منبع را بررسی کنید تا مشخص کنید هر نمودار از کدام سلول‌های ورق‌کاری استفاده می‌کند. متد [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) محدودهٔ دادهٔ فعلی را به صورت یک فرمول معتبر برای ورق‌کاری برمی‌گرداند، مثلاً `Sheet1!$A$1:$D$5`. در اینجا `Sheet1` نام ورق‌کاری است، `!` آن را از محدودهٔ سلول جدا می‌کند، و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت دلار به مرجع سطر و ستون مطلق اشاره دارد.

این متد محدودهٔ فعلی را بدون تغییر نمودار یا کتاب‌کار می‌خواند. اگر نمودار از کتاب‌کار به عنوان منبع داده استفاده نکند، یک `InvalidOperationException` پرتاب می‌کند. برای اطلاعات بیشتر به [مرجع API ChartData](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌های هر اسلاید را مستقیم برای نمودارها بررسی می‌کند. نام هر نمودار و محدودهٔ منبع آن را چاپ می‌کند. اگر نمودار از کتاب‌کار استفاده نکند، پیام مربوطه را چاپ کرده و به نمودار بعدی می‌پردازد.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides for Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) و [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) را فراهم می‌کند که به شما امکان خواندن و نوشتن کتاب‌کارهای دادهٔ نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را می‌دهد. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال یک ارائه با یک نمودار به عنوان اولین شکل در اسلاید اول استفاده می‌کند. کتاب‌کار جاسازی‌شده را به یک آرایهٔ بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند، و همان کتاب‌کار را باز می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **اعتبارسنجی طرح نمودار پس از تغییر کتاب‌کار**

هنگامی که یک کتاب‌کار جاسازی‌شده با یک کتاب‌کار اصلاح‌شده جایگزین می‌شود، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) با خطای «اندیس خارج از محدوده» شکست بخورد. قبل از نوشتن کتاب‌کار به‌روز‌شده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اسلاید اول است استفاده می‌کند. نظرات نشان می‌دهند که ویرایش کتاب‌کار در کجا انجام می‌شود؛ مثال اجرایی کتاب‌کار اصلی را باز می‌نویسد و طرح را در حافظه اعتبارسنجی می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // در اینجا بایت‌های کتاب‌کار را تغییر دهید، به‌عنوان مثال با استفاده از Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

پاک‌سازی مجموعه‌ها قبل از نوشتن کتاب‌کار، ارجاعات دادهٔ منسوخ را حذف می‌کند. پیش از استفاده از نمودار، سری‌ها و نگاشت‌های دستهٔ مورد نیاز برای کتاب‌کار به‌روزرسانی‌شده را بازسازی کنید.

## **تنظیم قالب‌های عددی سفارشی برای سلول‌های کتاب‌کار**

از [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) برای کنترل نحوهٔ نمایش مقادیر عددی در کتاب‌کار جاسازی‌شدهٔ نمودار استفاده کنید. برای مثال، ممکن است گزارشی نیاز داشته باشد نرخ تبدیل به‌صورت درصد با چهار رقم اعشار و ضریبی با پنج رقم اعشار نمایش داده شود. هر دو مقدار را عددی نگه دارید تا برای محاسبات و رسم نمودار در دسترس بمانند.

قالب عددی فقط نمایش را تغییر می‌دهد، مقدار ذخیره‌شده ثابت می‌ماند. قالب `0.0000%` مقدار `0.125` را به `12.5000%` نمایش می‌دهد؛ عدد ذخیره‌شده هنوز `0.125` است. به‌طور مشابه، `0.00000` مقدار `0.1234567` را به `0.12346` نشان می‌دهد بدون این‌که مقدار ذخیره‌شده رند شود. اگر قالب سفارشی رشتهٔ خالی (`""`) باشد، قالب بازگردانده‌شده توسط [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) استفاده می‌شود.

مثال زیر یک نمودار ستونی ایجاد می‌کند و سلول‌های آن را از طریق [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌دهد. در ورق‌کاری 0، B2 نرخ تبدیل و C2 ضریب را دارد. هر دو سلول مقادیر نمودار را تامین می‌کنند. مثال همچنین برچسب‌های مقداری که به قالب‌های منبع پیوند دارند را فعال می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

قالب‌های سلول‌های کتاب‌کار جدا از قالب‌های تنظیم‌شده مستقیم بر محورها یا برچسب‌های داده هستند. در این مثال، هر برچسب مقدار سلول منبع خود را نشان می‌دهد چون [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) به `true` تنظیم شده و [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) نیز به `true` تنظیم شده است. پس از ذخیره و بازگشایی ارائه، برچسب‌ها `12.5000%` و `0.12346` را نمایش می‌دهند همان‌طور که در زیر مشاهده می‌شود. محور عمودی قالب عددی خود را دارد که با [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) به `0.00` تنظیم شده و [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) برابر `false` است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم پیوند به منبع آن را به `false` قرار دهید و قالب را با [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) اختصاص دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. برای مثال، قالب مستقل `0.00` مقدار اول را به `0.13` تبدیل می‌کند، در حالی که B2 همچنان `12.5000%` باقی می‌ماند. برای قالب‌بندی مستقیم برچسب‌ها به [برچسب‌های داده نمودار](/slides/fa/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

تصویر زیر پس از بازگشایی ارائه ذخیره‌شده رندر شده است:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **استفاده از یک سلول کتاب‌کار به عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اسلاید اول یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در ورق‌کاری 0 برای اولین سه برچسب در سری اول استفاده می‌کند، برچسب‌های سلولی را فعال می‌کند و ارائه به‌روزشده را ذخیره می‌نماید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مدیریت ورق‌های کاری**

متد [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) دسترسی به ورق‌های کاری در یک کتاب‌کار نمودار را فراهم می‌آورد. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض می‌سازد و نام هر ورق کاری را در کنسول چاپ می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **تعیین نوع منبع داده**

این مثال یک نمودار ستونی سه‌بعدی با داده‌های پیش‌فرض می‌سازد و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک رشتهٔ ثابت استفاده می‌کند؛ نام دوم از سلول C1 در ورق‌کاری 0 می‌گیرد. شمارش [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روزشده ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **شناسایی قالب‌های کتاب‌کار جاسازی‌شدهٔ غیرقابل پشتیبانی**

Aspose.Slides قالب کتاب‌کار باینری اکسل (.xlsb) را که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) بر روی [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) قالب‌های پشتیبانی‌نشده را شناسایی کرده و آن نمودارها را رد کنید. این مثال شکل‌های اسلاید اول یک ارائهٔ موجود را بررسی می‌کند، اشکالی که نمودار نیستند را رد می‌کند و برای هر نمودار با کتاب‌کار .xlsb یک پیام تشخیصی چاپ می‌نماید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // در اینجا داده‌های کتاب‌کار پشتیبانی‌شدهٔ نمودار را بخوانید یا تغییر دهید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) و [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) برای استخراج کتاب‌کار نمودار جاسازی‌شده به یک فایل و پیوند نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض می‌سازد و کتاب‌کار آن را استخراج می‌کند. نوشتن فایل را تکمیل می‌کند قبل از اینکه کتاب‌کار خارجی را به عنوان منبع دادهٔ نمودار اختصاص دهد، سپس ارائهٔ پیوست‌شده را ذخیره می‌کند.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) می‌توانید یک کتاب‌کار خارجی را به عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورتی که جابه‌جا شده باشد) نیز به کار رود.

در حالی که نمی‌توانید داده‌های کتاب‌کارهای ذخیره‌شده در مکان‌های ریموت یا منابع را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی فراهم شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که ورق‌کاری به نام `Sheet1` شامل نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای می‌سازد، کتاب‌کار را پیوست می‌کند و با [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) A1:B4 را به یک سری و سه دسته نگاشت می‌کند. سپس ارائه را با نمودار پیوست‌شده ذخیره می‌نماید.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پارامتر `updateChartData` متد [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) تعیین می‌کند که آیا کتاب‌کار بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند، بنابراین کتاب‌کار ممکن است در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شود.

مثال زیر یک URL جای‌نگهدار با `updateChartData` تنظیم‌شده بر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای را حفظ می‌کند و ارائه را بدون بارگذاری کتاب‌کار در دسترس ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی کتاب‌کاری که به یک نمودار پیوست است، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را دریافت کنید.

این مثال اولین شکل در اسلاید اول یک ارائه با کتاب‌کار خارجی پیوست‌شده را بررسی می‌کند. اگر این شکل یک نمودار پیوست به کتاب‌کار خارجی باشد، [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) را در کنسول چاپ می‌کند. سپس یک نسخهٔ کپی از ارائه را ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ویرایش دادهٔ نمودار**

می‌توانید داده‌های کتاب‌کارهای خارجی را همانند کتاب‌کارهای داخلی ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنا پرتاب می‌شود.

این مثال یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی قابل دسترس پیوست شده، استفاده می‌کند. مقدار پشتیبان سلولی اولین نقطه دادهٔ اولین سری را به 100 تنظیم کرده و ارائه به‌روزشده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوست‌شده را به‌روزرسانی کند؛ بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **بازیابی کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که گم شده یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) ایجاد کنید، [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) را فراخوانی کنید و [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را پیش از باز کردن ارائه به `true` تنظیم کنید.

مثال زیر در جاوا کتاب‌کار داده‌ها را برای یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی در دسترس نیست، بازیابی می‌کند. داده‌های بازیابی‌شده را از طریق [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌یابد:

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // داده‌های کتاب‌کار بازیابی‌شده را در اینجا بخوانید یا تغییر دهید.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. فقط زمانی که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ قابل قبول است، بازیابی را فعال کنید، زیرا ممکن است کش شامل تغییرات انجام‌شده در کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به کتاب‌کار خارجی یا جاسازی‌شده پیوست شده است؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) و [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا از استفادهٔ فایل خارجی اطمینان حاصل کنید.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که در منابع شبکه/به‌اشتراک‌گذاری قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای ریموت از Aspose.Slides پشتیبانی نمی‌شود؛ آنها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides فایل XLSX خارجی را هنگام ذخیرهٔ ارائه بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) را ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبان‌شده توسط سلول می‌تواند فایل XLSX محلی پیوست‌شده را نیز به‌روزرسانی کند. اگر فایل اصلی باید دست‌نخورده بماند، از یک کپی کتاب‌کار استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه باید کرد؟**

Aspose.Slides هنگام پیوند کردن رمز عبور را قبول نمی‌کند. یک رویکرد معمول این است که قبل از کار رمز عبور را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (مثلاً با [Aspose.Cells](https://reference.aspose.com/cells/java/)) آماده کنید و به آن پیوند دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی اشاره کنند؟**

بله. هر نمودار لینک مخصوص خود را ذخیره می‌کند. اگر همه به همان فایل اشاره داشته باشند، به‌روزرسانی آن فایل در هر نمودار در بارگذاری بعدی داده‌ها منعکس می‌شود.