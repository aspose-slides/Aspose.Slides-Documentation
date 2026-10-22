---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها در اندروید
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/androidjava/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- برگه کاری
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides برای اندروید از طریق جاوا را کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائهٔ خود را بهینه کنید."
---
## **نمای کلی**

این مقاله نحوه کار با کتاب‌کارهای نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های شیت‌ها دسترسی داشته باشید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کنید و دادهٔ نمودار را وقتی کتاب‌کار در دسترس است، ویرایش کنید.

برای سلول‌های کتاب‌کاری که نمایانگر دادهٔ گمشده‌اند، به [Control the Display of Empty Cells](/slides/fa/androidjava/chart-series/) مراجعه کنید تا تفاوت بین سلول خالی و صفر و مقایسهٔ نمودار خطی حالت‌های نمایش موجود را ببینید.

## **شامل کردن داده‌ها از سطرها و ستون‌های مخفی**

از [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) برای کنترل این که آیا یک نمودار داده‌ها را از سطرها و ستون‌های مخفی شیت رسم کند یا نه استفاده کنید. مقدار `true` باعث رسم تنها سلول‌های قابل مشاهده می‌شود و مقدار `false` هر دو سلول قابل مشاهده و مخفی را شامل می‌شود. این تنظیم فقط رسم نمودار را کنترل می‌کند؛ سطرها یا ستون‌های شیت را مخفی یا آشکار نمی‌کند.

[نمونهٔ ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی به عنوان اولین شکل در اسلاید اول است. شیت جاسازی شده، `Sheet1`، محدودهٔ منبع زیر را دارد: `A1:C4`. سطر 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها همچنان دارای مقدار هستند.

| سطر شیت | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (سطر مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

دست به سلول‌های منبع از طریق [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) شوید و با [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) وضعیت مخفی بودن آن‌ها را بررسی کنید. این متد وضعیت مخفی را بدون تغییر آن گزارش می‌کند. در این فایل، B2 قابل مشاهده است، B3 به سطر مخفی تعلق دارد و C2 به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم رسم، دادهٔ نمودار را تازه کنید: کتاب‌کار جاسازی‌شده را با [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) حفظ کنید و با [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) دوباره بارگذاری کنید. هنگام شامل کردن تمام سلول‌ها، همچنین از [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) برای بازگرداندن محدودهٔ کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. صرفاً تغییر پرچم برای تازه‌سازی دادهٔ کش‌شدهٔ این نمونه کافی نیست.

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

مثال دو نسخهٔ ارائه را ذخیره می‌کند: یکی تنها با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر حالت‌های رسم دوگانه را نشان می‌دهند. سطر 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | تمام سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی حاوی مقدار با یک سلول خالی متفاوت است. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم شامل یا مستثنی کردن داده‌های منبع مخفی نیست. برای مثال به [Control the Display of Empty Cells](/slides/fa/androidjava/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازیابی محدودهٔ دادهٔ یک نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، محدوده‌های منبع را بررسی کنید تا تشخیص دهید هر نمودار از چه سلول‌های شیتی استفاده می‌کند. متد [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) محدودهٔ دادهٔ کنونی را به صورت فرمولی با معیار شیت بر می‌گرداند؛ مانند `Sheet1!$A$1:$D$5`. در اینجا `Sheet1` نام شیت است، `!` آن را از محدودهٔ سلول جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را (شامل) مشخص می‌کند. علامت‌های دلار نشان‌دهندهٔ مراجع مطلق ردیف و ستون هستند.

این متد محدودهٔ کنونی را بدون تغییر نمودار یا کتاب‌کار می‌خواند. اگر نمودار از کتاب‌کار به عنوان منبع داده استفاده نکند، `InvalidOperationException` پرتاب می‌شود. برای اطلاعات بیشتر به [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/) نگاه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌های هر اسلاید را مستقیم برای یافتن نمودارها بررسی می‌کند. نام هر نمودار و محدودهٔ منبع آن را چاپ می‌کند. اگر نموداری از کتاب‌کار استفاده نکند، پیام مربوطه چاپ می‌شود و به نمودار بعدی ادامه می‌دهد.

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

## **خواندن و نوشتن دادهٔ نمودار از کتاب‌کار**

Aspose.Slides برای Android از طریق Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) و [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) را فراهم می‌کند که امکان خواندن و نوشتن کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را می‌دهند. **توجه** داشته باشید که دادهٔ نمودار باید به همان شکل سازماندهی شود یا ساختاری مشابه منبع داشته باشد.

این مثال یک ارائه با نموداری به عنوان اولین شکل در اسلاید اول استفاده می‌کند. کتاب‌کار جاسازی‌شده را به یک آرایهٔ بایت می‌خواند، سری‌ها و دسته‌ها را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی طرح‌بندی نمودار پس از تغییر کتاب‌کار**

هنگامی که کتاب‌کار جاسازی‌شده را با یک کتاب‌کار تغییر یافته جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این ناسازگاری می‌تواند باعث شود [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) با خطای «اندیس خارج از بازه» شکست بخورد. قبل از نوشتن کتاب‌کار به‌روزرسانی‌شده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال یک نمودار که اولین شکل اسلاید اول است استفاده می‌کند. نظرات محل ویرایش کتاب‌کار را نشان می‌دهند؛ مثال اجرایی کتاب‌کار اصلی را برمی‌گرداند و طرح‌بندی را در حافظه اعتبارسنجی می‌کند.

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

        // در اینجا بایت‌های کتاب‌کار را تغییر دهید، برای مثال با استفاده از Aspose.Cells.

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

پاک‌سازی مجموعه‌ها مراجع دادهٔ منقضی‌شده را پیش از نوشتن کتاب‌کار حذف می‌کند. پیش از استفاده از نمودار، هر سری و نگاشت دستهٔ لازم برای کتاب‌کار به‌روزرسانی‌شده را بازسازی کنید.

## **تنظیم قالب عددی سفارشی برای سلول‌های کتاب‌کار**

از [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) برای کنترل نحوهٔ نمایش مقادیر عددی در کتاب‌کار جاسازی‌شدهٔ نمودار استفاده کنید. به عنوان مثال، ممکن است گزارشی نیاز داشته باشد نرخ تبدیل به صورت درصد با چهار رقم اعشار و ضریب با پنج رقم اعشار نمایش داده شود. هر دو مقدار را عددی نگه دارید تا برای محاسبات و رسم نمودار در دسترس باقی بمانند.

یک قالب عددی نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` عدد `0.125` را به‌صورت `12.5000%` نمایش می‌دهد؛ مقدار ذخیره‌شده همچنان `0.125` است. به همین ترتیب، `0.00000` عدد `0.1234567` را به‌صورت `0.12346` نشان می‌دهد بدون این‌که مقدار ذخیره‌شده گرد شود. اگر قالب سفارشی یک رشتهٔ خالی (`""`) باشد، قالبی که توسط [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) برگردانده می‌شود استفاده می‌شود.

در مثال زیر یک نمودار ستونی ایجاد می‌کنیم و سلول‌های آن را از طریق [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌یابیم. در شیت 0، B2 حاوی نرخ تبدیل و C2 حاوی ضریب است. هر دو سلول مقادیر نمودار را تامین می‌کنند. مثال همچنین برچسب‌های مقدار را که به قالب‌های منبع لینک شده‌اند فعال می‌کند.

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

قالب‌های سلول کتاب‌کار جدا از قالب‌های تنظیم‌شده مستقیم بر محورها یا برچسب‌های داده‌اند. در این مثال هر برچسب مقدار سلول منبع خود را نشان می‌دهد زیرا [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) برابر `true` است و به قالب عددی منبع لینک می‌شود چون [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) برابر `true` است. پس از ذخیره و باز کردن مجدد ارائه، برچسب‌ها `12.5000%` و `0.12346` را نشان می‌دهند، همان‌طور که در زیر مشاهده می‌شود. محور عمودی قالب عددی خود را دارد که با [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) به‌صورت `0.00` تنظیم شده و [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) برابر `false` است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم لینک به منبع آن را `false` کنید و با [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) قالبی اختصاص دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. به عنوان مثال، قالب مستقل `0.00` مقدار اول را به‌صورت `0.13` نمایش می‌دهد، در حالی که B2 همچنان `12.5000%` را نشان می‌دهد. برای قالب‌بندی مستقیم برچسب‌ها به [Chart Data Labels](/slides/fa/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) مراجعه کنید.

تصویر زیر پس از باز کردن مجدد ارائه ذخیره‌شده رندر شده است:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار برای برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اسلاید اول یک ارائه موجود اضافه می‌کند. از سلول‌های A10:A12 در شیت 0 برای اولین سه برچسب در سری اول استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌سازد و ارائه به‌روزرسانی‌شده را ذخیره می‌کند.

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

## **مدیریت شیت‌ها**

متد [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) دسترسی به شیت‌های موجود در کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار پای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر شیت را در کنسول چاپ می‌کند.

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

## **مشخص کردن نوع منبع داده**

مقدارهای نقطه‌ای سری می‌توانند به‌صورت مستقیم به عنوان عددهای ثابت نیز ذخیره شوند. برای مثال کامل به [Set Series Values Using Numeric Literals](/slides/fa/androidjava/chart-series/#set-series-values-using-numeric-literals) مراجعه کنید. نوع منبع مقادیر نقطه‌ای جدا از پیکربندی کتاب‌کار داخلی یا خارجی نمودار است؛ استفاده از عددهای ثابت به‌تنهایی کتاب‌کار جاسازی‌شده را حذف نمی‌کند.

این مثال یک نمودار ستونی 3D با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده مختلف تنظیم می‌کند. نام نخست از یک literal رشته‌ای استفاده می‌کند؛ دومین نام از سلول C1 در شیت 0 می‌آید. شمارش [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روزرسانی‌شده ذخیره می‌کند.

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

## **تشخیص قالب‌های کتاب‌کار جاسازی‌شدهٔ پشتیبانی‌نشده**

Aspose.Slides قالب کتاب‌کار باینری Excel (.xlsb) را که می‌تواند در برخی نمودارها جاسازی شود پشتیبانی نمی‌کند. می‌توانید با استفاده از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) روی [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) قالب‌های غیرقابل پشتیبانی را شناسایی کرده و آن نمودارها را نادیده بگیرید. این مثال شکل‌های اسلاید اول یک ارائه موجود را بررسی می‌کند، شکل‌های غیرنموداری را کنار می‌گذارد و برای هر نمودار دارای کتاب‌کار داخلی .xlsb پیام تشخیص می‌دهد.

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

        // در اینجا داده‌های کتاب‌کار پشتیبانی‌شدهٔ نمودار را بخوانید یا ویرایش کنید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides امکان استفاده از کتاب‌کارهای خارجی به عنوان منبع دادهٔ نمودارها را فراهم می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) و [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) برای صادرات کتاب‌کار نمودار جاسازی‌شده به یک فایل و لینک کردن نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار پای با داده‌های پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را صادر می‌نماید. نوشتن فایل را قبل از اختصاص کتاب‌کار خارجی به عنوان منبع دادهٔ نمودار تکمیل می‌کند، سپس ارائهٔ لینک‌شده را ذخیره می‌نماید.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) می‌توانید یک کتاب‌کار خارجی را به عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد همچنین برای به‌روزرسانی مسیر کتاب‌کار خارجی (اگر جابه‌جا شده باشد) قابل استفاده است.

اگرچه نمی‌توانید داده‌ها را در کتاب‌کارهای ذخیره‌شده در مکان‌های راه دور یا منابع ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی فراهم شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از کتاب‌کار خارجی استفاده می‌کند که شیتی به نام `Sheet1` شامل نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار پای ایجاد می‌کند، کتاب‌کار را لینک می‌کند و با استفاده از [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) محدودهٔ A1:B4 را به یک سری و سه دسته نگاشت می‌کند. سپس ارائه را با نمودار لینک‌شده ذخیره می‌کند.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پارامتر `updateChartData` متد [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) کنترل می‌کند که آیا کتاب‌کار بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، تنها مسیر کتاب‌کار به‌روزرسانی می‌شود. دادهٔ نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شود، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، دادهٔ نمودار از کتاب‌کار هدف به‌روزرسانی می‌شود.

مثال زیر یک URL placeholder را با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار پای حفظ می‌شود و ارائه بدون بارگذاری کتاب‌کار غیرقابل دسترس ذخیره می‌شود.

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

### **به‌دست آوردن مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی کتاب‌کاری که به یک نمودار لینک شده است، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را بازیابی کنید.

این مثال اولین شکل اسلاید اول یک ارائه با کتاب‌کار خارجی لینک‌شده را بررسی می‌کند. اگر شکل یک نمودار لینک‌شده به کتاب‌کار خارجی باشد، متد [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را ذخیره می‌نماید.

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

می‌توانید داده‌های کتاب‌کارهای خارجی را همانند تغییر محتویات کتاب‌کارهای داخلی ویرایش کنید. اگر کتاب‌کار خارجی قابل بارگذاری نباشد، استثنا پرتاب می‌شود.

این مثال یک نمودار که اولین شکل اسلاید اول است و به یک کتاب‌کار خارجی قابل دسترس لینک شده است استفاده می‌کند. مقدار نقطهٔ دادهٔ اول در سری اول را به `100` تنظیم می‌کند و ارائه به‌روزرسانی‌شده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی لینک‌شده را به‌روز کند؛ بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

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

اگر یک نمودار از کتاب‌کار خارجی که غائب یا غیرقابل دسترس است استفاده می‌کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک شیء [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) ایجاد کنید، متد [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) را صدا بزنید و [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را به `true` تنظیم کنید.

مثال زیر در جاوا کتاب‌کار داده‌ها را برای یک نمودار که اولین شکل اسلاید اول است و به یک کتاب‌کار خارجی غیرقابل دسترس ارجاع می‌دهد، بازیابی می‌کند. داده‌های بازیابی‌شده را از طریق [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌یابد:

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

        // در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا ویرایش کنید.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. فقط زمانی که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ قابل قبول باشد بازیابی را فعال کنید، زیرا کش ممکن است شامل تغییرات انجام‌شده در کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **سؤالات متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به کتاب‌کار خارجی یا داخلی لینک شده است؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) و یک [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی لینک داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که در منابع شبکه/به‌اشتراک‌گذاری قرار دارند استفاده کنم؟**

بله، این کتاب‌کارها می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) را ذخیره می‌کند. ویرایش داده‌های نمودار که از سلول‌ها پشتیبانی می‌شود می‌تواند فایل XLSX محلی لینک‌شده را نیز به‌روز کند. اگر فایل اصلی باید ثابت بماند، از یک کپی کتاب‌کار استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد باید چه کار کنم؟**

Aspose.Slides هنگام لینک کردن رمز عبور را نمی‌پذیرد. رویکرد معمول این است که قبل از لینک کردن حفاظت را حذف کنید یا یک کپی رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/java/)) آماده کنید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار لینک مخصوص خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار در بارگذاری بعدی داده‌ها منعکس می‌شود.