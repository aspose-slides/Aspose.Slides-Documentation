---
title: "مدیریت کتاب‌کارهای نمودار در ارائه‌ها با Java"
linktitle: "کتاب‌کار نمودار"
type: docs
weight: 70
url: /fa/java/chart-workbook/
keywords:
- "کتاب‌کار نمودار"
- "دادهٔ نمودار"
- "سلول کتاب‌کار"
- "برچسب داده"
- "کاربرگ"
- "منبع داده"
- "کتاب‌کار خارجی"
- "دادهٔ خارجی"
- "کش نمودار"
- "بازیابی کتاب‌کار"
- "پاورپوینت"
- "ارائه"
- "جاوا"
- "Aspose.Slides"
description: "Aspose.Slides برای Java را کشف کنید: به راحتی کتاب‌کارهای نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائهٔ خود را بهینه کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را تعیین کنید.

همچنین نحوه کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی پیوست‌شده به یک نمودار را بازیابی کنید و داده‌های نمودار را وقتی کتاب‌کار در دسترس باشد، ویرایش کنید.

برای سلول‌های کتاب‌کاری که نمایانگر داده‌های گمشده هستند، به [کنترل نمایش سلول‌های خالی](/slides/fa/java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر، و مقایسهٔ خطی حالت‌های نمایش موجود را ببینید.

## **شامل‌کردن داده‌ها از ردیف‌ها و ستون‌های پنهان**

از [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) برای کنترل این که آیا یک نمودار داده‌های ردیف‌ها و ستون‌های پنهان کاربرگ را رسم می‌کند یا نه استفاده کنید. مقدار `true` باعث رسم فقط سلول‌های قابل مشاهده می‌شود و `false` هر دو سلول قابل مشاهده و پنهان را شامل می‌شود. این تنظیم فقط نحوهٔ رسم نمودار را کنترل می‌کند؛ ردیف‌ها یا ستون‌های کاربرگ را مخفی یا آشکار نمی‌کند.

[نمونهٔ ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی به عنوان اولین شکل در اولین اسلاید است. کاربرگ جاسازی‌شده، `Sheet1`، دامنهٔ منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C پنهان هستند، اما سلول‌های آن‌ها همچنان مقدار دارند.

| سطر کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون پنهان) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف پنهان) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی پیدا کنید و با استفاده از [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) وضعیت پنهان بودن آن‌ها را بررسی کنید. این متد وضعیت پنهان بودن را بدون تغییر آن گزارش می‌کند. در این مثال، B2 قابل مشاهده است، B3 به ردیف پنهان تعلق دارد و C2 به ستون پنهان؛ خروجی مثال به‌ترتیب `false`، `true` و `true` است.

برای این مثال، پس از تغییر تنظیم رسم، داده‌های نمودار را تازه کنید: کتاب‌کار جاسازی‌شده را با [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) نگه دارید و با [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) آن را دوباره بارگذاری کنید. هنگام شامل‌کردن همهٔ سلول‌ها، همچنین از [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) برای بازگرداندن دامنهٔ کامل، شامل دستهٔ پنهان «فوریه»، استفاده کنید. فقط تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ این نمونه کافی نیست.

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
                // دامنهٔ منبع کامل را بازگردانید، شامل دسته‌های پنهان.
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

این مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) و دیگری با همهٔ شش مقدار. تصاویر زیر دو حالت رسم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده پنهان می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | همهٔ سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول پنهان حاوی مقدار، متفاوت از یک سلول خالی است. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) نحوهٔ نمایش مقادیر گمشده را کنترل می‌کند؛ این تنظیم شامل یا حذف داده‌های منبع پنهان نمی‌شود. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/java/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازیابی دامنهٔ دادهٔ یک نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، دامنه‌های منبع را بررسی کنید تا مشخص شود هر نمودار چه سلول‌های کاربرگی را استفاده می‌کند. متد [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) دامنهٔ دادهٔ فعلی را به صورت یک فرمول کاربرگ‑کوانتوفایِد، مانند `Sheet1!$A$1:$D$5`، برمی‌گرداند. در اینجا، `Sheet1` نام کاربرگ است، `!` آن را از دامنهٔ سلول جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت دولار نشان‌دهندهٔ مراجع مطلق ردیف و ستون است.

این متد دامنهٔ فعلی را بدون تغییر نمودار یا کتاب‌کار می‌خواند. اگر نمودار از کتاب‌کار به عنوان منبع داده استفاده نکند، `InvalidOperationException` پرتاب می‌شود. برای اطلاعات بیشتر، به [مرجع API ChartData](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و برای هر اسلاید شکل‌های موجود را بررسی می‌کند تا نمودارها را پیدا کند. نام هر نمودار و دامنهٔ منبع آن را چاپ می‌کند. اگر نموداری از کتاب‌کار استفاده نکند، پیام مربوطه چاپ شده و به نمودار بعدی ادامه می‌دهد.

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

Aspose.Slides for Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) و [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که دادهٔ نمودار باید به همان شیوه سازماندهی شده باشد یا ساختاری مشابه منبع داشته باشد.

این مثال از یک ارائه با یک نمودار به عنوان اولین شکل در اولین اسلاید استفاده می‌کند. کتاب‌کار جاسازی‌شده را به یک آرایهٔ بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را باز می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**

زمانی که یک کتاب‌کار جاسازی‌شده را با کتاب‌کاری اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود که [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) با خطای out‑of‑range ایندکس مواجه شود. پیش از نوشتن کتاب‌کار به‌روزشده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اولین اسلاید است استفاده می‌کند. نظرات نشان می‌دهند که ویرایش کتاب‌کار کجا انجام می‌شود؛ مثال اجرایی کتاب‌کار اصلی را باز می‌نویسد و چیدمان را در حافظه اعتبارسنجی می‌کند.

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

        // تغییر بایت‌های کتاب‌کار در اینجا، برای مثال با استفاده از Aspose.Cells.

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

پاک‌کردن مجموعه‌ها مراجع دادهٔ منقضی‌شده را پیش از نوشتن کتاب‌کار حذف می‌کند. پیش از استفاده از نمودار، هر سری و دستهٔ لازم را برای کتاب‌کار به‌روزشده بازسازی کنید.

## **تنظیم قالب‌های عددی سفارشی برای سلول‌های کتاب‌کار**

از [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) برای کنترل نحوهٔ نمایش مقادیر عددی در کتاب‌کار جاسازی‌شدهٔ نمودار استفاده کنید. برای مثال، ممکن است گزارشی نیاز داشته باشد نرخ تبدیل به صورت درصد با چهار رقم اعشار نمایش داده شود و ضریب با پنج رقم اعشار. هر دو مقدار باید به صورت عددی باقی بمانند تا برای محاسبات و رسم نمودار در دسترس باشند.

قالب عددی نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` مقدار `0.125` را به‌صورت `12.5000%` نمایش می‌دهد؛ عدد ذخیره‌شده همچنان `0.125` است. به‌طور مشابه، `0.00000` مقدار `0.1234567` را به‌صورت `0.12346` نشان می‌دهد بدون این‌که مقدار ذخیره‌شده گرد شود. اگر قالب سفارشی رشتهٔ خالی (`""`) باشد، قالب برگشت داده‑شده توسط [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) استفاده می‌شود.

در مثال زیر یک نمودار ستونی ایجاد می‌شود و سلول‌های آن از طریق [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی پیدا می‌کند. در کاربرگ 0، B2 حاوی نرخ تبدیل و C2 حاوی ضریب است. هر دو سلول مقدارهای نمودار را فراهم می‌کنند. مثال همچنین برچسب‌های مقادیر را که به قالب‌های منبع لینک شده‌اند فعال می‌کند.

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

قالب‌های سلول کتاب‌کار جدا از قالب‌های تنظیم‌شده مستقیماً بر محورهای نمودار یا برچسب‌های داده هستند. در این مثال، هر برچسب مقدار سلول منبع خود را نشان می‌دهد چون [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) روی `true` تنظیم شده و به قالب عددی منبع لینک دارد چون [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) روی `true` است. پس از ذخیره و باز کردن مجدد ارائه، برچسب‌ها `12.5000%` و `0.12346` را نمایش می‌دهند، همان‌طور که در زیر مشاهده می‌شود. محور عمودی از قالب عددی خود استفاده می‌کند که با [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) به `0.00` تنظیم شده و با [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) روی `false` قرار گرفته است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم لینک به منبع آن را به `false` تنظیم کنید و با [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) قالبی اختصاص دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. به‌عنوان مثال، قالب مستقل `0.00` مقدار اول را به‌صورت `0.13` نمایش می‌دهد، در حالی که B2 همچنان `12.5000%` را نشان می‌دهد. برای جزئیات بیشتر به [برچسب‌های دادهٔ نمودار](/slides/fa/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) مراجعه کنید.

![نمودار ستونی با برچسب‌های لینک‌شده به منبع که 12.5000% و 0.12346 را نشان می‌دهند و یک محور عددی به‌صورت مستقل قالب‌بندی شده است.](custom-cell-formats.png)

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با داده‌های پیش‌فرض به اولین اسلاید یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای اولین سه برچسب در اولین سری استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌کند و ارائه به‌روزشده را ذخیره می‌کند.

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

## **مدیریت کاربرگ‌ها**

متد [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) دسترسی به کاربرگ‌های موجود در کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را به کنسول چاپ می‌کند.

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

## **مشخص‌کردن نوع منبع داده**

مقدارهای نقاط سری می‌توانند به‌صورت مستقیم به عنوان literals عددی ذخیره شوند. برای مثال کامل به [تنظیم مقادیر سری با literals عددی](/slides/fa/java/chart-series/#set-series-values-using-numeric-literals) مراجعه کنید. نوع منبع مقادیر نقطه، جدا از پیکربندی داخلی یا خارجی کتاب‌کار نمودار است؛ استفاده از literals عددی به تنهایی کتاب‌کار جاسازی‌شده را حذف نمی‌کند.

این مثال یک نمودار ستونی 3‑بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده مختلف تنظیم می‌کند. نام اول از literal رشته‌ای استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 استفاده می‌کند. enum [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روز‌شده ذخیره می‌کند.

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

## **تشخیص قالب‌های کتاب‌کار جاسازی‌شدهٔ پشتیبانی‑نشده**

Aspose.Slides از قالب کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) بر روی [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) همراه با enum [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) قالب‌های پشتیبانی‑نشده را شناسایی و از آن‌ها عبور کنید. این مثال شکل‌های اولین اسلاید یک ارائهٔ موجود را بررسی می‌کند، اشکال غیرنموداری را نادیده می‌گیرد و برای هر نموداری که کتاب‌کار .xlsb جاسازی‌شده دارد پیام عیب‌یابی چاپ می‌کند.

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

        // خواندن یا تغییر داده‌های کتاب‌کار نمودار پشتیبانی‌شده در اینجا.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) و [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) برای استخراج کتاب‌کار جاسازی‌شدهٔ نمودار به یک فایل و پیوست نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را صادر می‌کند. نوشتن فایل را تکمیل می‌کند قبل از اینکه کتاب‌کار خارجی را به‌عنوان منبع دادهٔ نمودار اختصاص دهد، سپس ارائهٔ پیوست‌شده را ذخیره می‌کند.

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

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به‌عنوان منبع دادهٔ آن اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (اگر کتاب‌کار جابه‌جا شده باشد) استفاده شود.

اگرچه نمی‌توانید داده‌های کتاب‌کارهای ذخیره‌شده در موقعیت‌های دوردست یا منابع را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی فراهم شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که کاربرگی به نام `Sheet1` دارای نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوست می‌کند و با [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) محدودهٔ A1:B4 را به یک سری و سه دسته نگاشت می‌کند. ارائه با نمودار پیوست‌شده ذخیره می‌شود.

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

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. دادهٔ نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شود، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، دادهٔ نمودار از کتاب‌کار هدف به‌روز می‌شود.

مثال زیر یک URL جایگزین را با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شوند و ارائه بدون بارگذاری کتاب‌کار در دسترس نیست ذخیره می‌شود.

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

برای شناسایی کتاب‌کاری که به یک نمودار پیوست شده است، بررسی کنید که آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را بازیابی کنید.

این مثال اولین شکل در اولین اسلاید یک ارائه با کتاب‌کار خارجی پیوست‌شده را بررسی می‌کند. اگر یک نمودار پیوست به کتاب‌کار خارجی باشد، [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را ذخیره می‌کند.

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

می‌توانید داده‌های کتاب‌کارهای خارجی را همانند تغییر محتویات کتاب‌کارهای داخلی ویرایش کنید. وقتی کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی قابل دسترس پیوست شده استفاده می‌کند. مقدار پشت‌سر‌سلولی اولین نقطه داده در اولین سری را به 100 تنظیم می‌کند و ارائه به‌روزشده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوست‌شده را به‌روزرسانی کند؛ بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی، از یک کپی استفاده کنید.

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

اگر یک نمودار از کتاب‌کار خارجی که مفقود یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) ایجاد کنید، متد [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) را فراخوانی کنید و [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را روی `true` تنظیم کنید.

مثال زیر در جاوا کتاب‌کار داده‌های یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی در دسترس نیست، بازیابی می‌کند. داده‌های بازیابی‌شده را از طریق [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌یابد:

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

        // خواندن یا تغییر داده‌های کتاب‌کار بازیابی‌شده در اینجا.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنایی پرتاب می‌کند. فقط زمانی بازیابی را فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ پذیرش‌پذیر باشد، زیرا کش ممکن است شامل تغییرات انجام‑شده بر روی کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **سؤال‌های متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به کتاب‌کار خارجی یا جاسازی‌شده پیوست شده است؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) و [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/اشتراک‌های شبکه‌ای قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دوردست از طریق Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [پیوند به فایل خارجی](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) را ذخیره می‌کند. ویرایش داده‌های نمودار که از سلول پشتیبانی می‌شود می‌تواند فایل XLSX محلی پیوست‌شده را نیز به‌روز کند. اگر کتاب‌کار اصلی باید دست‌نخورده بماند، یک کپی از آن استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه کاری باید انجام دهم؟**

Aspose.Slides در هنگام پیوند از رمز عبور پشتیبانی نمی‌کند. یک راه معمول این است که پیش از پیوند حفاظت را حذف کنید یا یک کپی رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/java/)) تهیه کنید و به آن پیوند دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی یکسان ارجاع دهند؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همگی به همان فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس می‌شود.