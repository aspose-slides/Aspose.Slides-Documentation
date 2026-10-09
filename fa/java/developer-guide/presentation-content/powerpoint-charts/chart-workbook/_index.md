---
title: "مدیریت کتاب‌کارهای نمودار در ارائه‌ها با استفاده از جاوا"
linktitle: "کتاب‌کار نمودار"
type: docs
weight: 70
url: /fa/java/chart-workbook/
keywords:
- "کتاب‌کار نمودار"
- "داده‌های نمودار"
- "سلول کتاب‌کار"
- "برچسب داده"
- "کاربرگ"
- "منبع داده"
- "کتاب‌کار خارجی"
- "داده‌های خارجی"
- "کش نمودار"
- "بازیابی کتاب‌کار"
- "PowerPoint"
- "ارائه"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides برای جاوا را کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را به‌صورت بهینه‌سازی‌شده سازماندهی نمایید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنیم. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به‌عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی داشته باشید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به‌عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی پیوست شده به یک نمودار را بازیابی کنید و داده‌های نمودار را زمانی که کتاب‌کار در دسترس است، ویرایش کنید.

برای سلول‌های کتاب‌کاری که نمایانگر داده‌های گمشده هستند، به [Control the Display of Empty Cells](/slides/fa/java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر را ببینید و مقایسه‌ای خطی از حالت‌های نمایش موجود را مشاهده کنید.

## **شامل داده‌ها از ردیف‌ها و ستون‌های پنهان**

از [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) برای کنترل این‌که آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های پنهان کاربرگ استخراج کند یا نه استفاده کنید. مقدار `true` فقط سلول‌های قابل‌مشاهده را ترسیم می‌کند و مقدار `false` هر دو سلول قابل‌مشاهده و پنهان را شامل می‌شود. این تنظیم فقط ترسیم نمودار را تحت تأثیر قرار می‌دهد؛ ردیف‌ها یا ستون‌های کاربرگ را پنهان یا نمایان نمی‌کند.

[ارائه نمونه](hidden-source-data.pptx) شامل یک نمودار ستونی به‌عنوان اولین شکل در اولین اسلاید آن است. کاربرگ توکار، `Sheet1`، بازه منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C پنهان هستند، اما سلول‌های آن‌ها همچنان مقدار دارند.

| سطر کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (سطر مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی پیدا کنید و با استفاده از [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) وضعیت مخفی بودن آن‌ها را بررسی کنید. این متد وضعیت مخفی بودن را بدون تغییر آن گزارش می‌کند. در این فایل، B2 قابل‌مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه کنید: کتاب‌کار توکار را با [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) نگه دارید و با [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) دوباره بارگذاری کنید. هنگام شامل کردن همه سلول‌ها، همچنین از [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) برای بازگرداندن بازه کامل، شامل دستهٔ فوریه پنهان، استفاده کنید. تنها تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ این نمونه و برچسب‌های دسته کافی نیست.

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

            // داده‌های نمودار را از کتاب‌کار توکار تازه کنید.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // بازه منبع کامل را بازیابی کنید، از جمله دسته‌های پنهان.
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

مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل‌مشاهده (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر دو حالت ترسیم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار توکار پنهان می‌مانند.

| فقط سلول‌های قابل‌مشاهده (`true`) | تمام سلول‌ها (`false`) |
| --- | --- |
| ![فقط سلول‌های قابل‌مشاهده: مقادیر خرده‌فروشی 10 و 20 برای ژانویه و مارس.](hidden_cells_True.png) | ![تمام سلول‌ها: مقادیر خرده‌فروشی و عمده‌فروشی برای ژانویه، فوریه و مارس.](hidden_cells_False.png) |

یک سلول پنهان که شامل مقدار است با یک سلول خالی متفاوت است. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این تنظیم به‌صورت خودکار داده‌های منبع مخفی را شامل یا مستثنی نمی‌کند. برای مثال به [Control the Display of Empty Cells](/slides/fa/java/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازیابی بازه داده‌های یک نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، بازه‌های منبع را بررسی کنید تا مشخص کنید هر نمودار از کدام سلول‌های کاربرگ استفاده می‌کند. متد [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) بازه دادهٔ فعلی را به‌صورت یک فرمول معتبر برای کاربرگ باز می‌گرداند، برای مثال `Sheet1!$A$1:$D$5`. در اینجا `Sheet1` نام کاربرگ است، `!` آن را از بازه سلول‌ها جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 (شامل) را شناسایی می‌کند. علامت‌های دلار به مرجع مطلق ردیف و ستون اشاره دارند.

این متد بازهٔ فعلی را می‌خواند بدون اینکه نمودار یا کتاب‌کار آن را تغییر دهد. اگر نمودار از کتاب‌کار به‌عنوان منبع داده استفاده نکند، `InvalidOperationException` پرتاب می‌شود. برای اطلاعات بیشتر، به [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و به‌صورت مستقیم شکل‌های هر اسلاید را برای یافتن نمودارها بررسی می‌کند. نام هر نمودار و بازه منبع آن را چاپ می‌کند. اگر نموداری از کتاب‌کار استفاده نکند، پیام مربوطه را چاپ می‌کند و به نمودار بعدی ادامه می‌دهد.

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

Aspose.Slides for Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) و [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) را ارائه می‌دهد که به شما امکان می‌دهد کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **Note** اینکه داده‌های نمودار باید به همان روش سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال یک ارائه با یک نمودار به‌عنوان اولین شکل در اولین اسلاید آن استفاده می‌کند. کتاب‌کار توکار را به‌صورت آرایه بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

هنگامی که کتاب‌کار توکار را با نسخهٔ اصلاح‌شده‌ای جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) با خطای «اندیس خارج از محدوده» شکست بخورد. قبل از نوشتن کتاب‌کار به‌روزشده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال یک نمودار که اولین شکل در اولین اسلاید است استفاده می‌کند. نظرات نشان می‌دهند کجا ویرایش کتاب‌کار انجام می‌شود؛ مثال قابل اجرا کتاب‌کار اصلی را بازمی‌نویسد و چیدمان را در حافظه اعتبارسنجی می‌کند.

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

پاک‌سازی مجموعه‌ها مراجع داده‌های منسوخ را قبل از نوشتن کتاب‌کار حذف می‌کند. قبل از استفاده از نمودار، هر سری و نگاشت دستهٔ موردنیاز برای کتاب‌کار به‌روزشده را بازسازی کنید.

## **تنظیم یک سلول کتاب‌کار به‌عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با دادهٔ پیش‌فرض به اولین اسلاید یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای سه برچسب اول در اولین سری استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌کند و ارائهٔ به‌روزشده را ذخیره می‌کند.

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

متد [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) دسترسی به کاربرگ‌های موجود در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را در کنسول چاپ می‌کند.

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

این مثال یک نمودار ستونی 3D با دادهٔ پیش‌فرض ایجاد می‌کند و دو نام سری را با استفاده از منابع داده متفاوت تنظیم می‌کند. نام اول از یک رشتهٔ متنی استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 استفاده می‌کند. شمارندهٔ [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روزشده ذخیره می‌کند.

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

## **تشخیص قالب‌های پشتیبانی‌نشدهٔ کتاب‌کار توکار**

Aspose.Slides از قالب کتاب‌کار باینری Excel (.xlsb) که می‌تواند در بعضی نمودارها توکار شود، پشتیبانی نمی‌کند. می‌توانید از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) روی [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) همراه با شمارندهٔ [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) برای شناسایی قالب‌های پشتیبانی‌نشده و رد کردن آن نمودارها استفاده کنید. این مثال شکل‌های اولین اسلاید یک ارائهٔ موجود را بررسی می‌کند، شکل‌های غیرنموداری را رد می‌کند و برای هر نمودار با کتاب‌کار .xlsb توکار یک پیام تشخیصی چاپ می‌کند.

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

Aspose.Slides پشتیبانی می‌کند از استفاده از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها.

### **ایجاد یک کتاب‌کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) و [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) برای خروجی گرفتن یک کتاب‌کار توکار نمودار به یک فایل و پیوند نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را صادر می‌کند. قبل از اختصاص کتاب‌کار خارجی به عنوان منبع دادهٔ نمودار، نوشتن فایل را تکمیل می‌کند، سپس ارائهٔ پیوندشده را ذخیره می‌کند.

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

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) می‌توانید یک کتاب‌کار خارجی را به‌عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورت جابجایی آن) استفاده شود.

اگرچه نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های از‌دور یا منابع را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال یک کتاب‌کار خارجی که کاربرگ آن به نام `Sheet1` شامل یک نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 است، استفاده می‌کند. این مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوند می‌دهد و با استفاده از [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) بازه A1:B4 را به یک سری و سه دسته نگاشت می‌کند. ارائهٔ حاوی نمودار پیوندشده را ذخیره می‌کند.

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
* وقتی `updateChartData` برابر `true` باشد، دادهٔ نمودار از کتاب‌کار هدف به‌روزرسانی می‌شود.

مثال زیر یک URL مکان‌نگرش با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شود و ارائه بدون بارگذاری کتاب‌کار غیراستاندارد ذخیره می‌شود.

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

برای شناسایی کتاب‌کاری که به یک نمودار پیوند داده شده است، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را بازیابی کنید.

این مثال اولین شکل در اولین اسلاید یک ارائه با کتاب‌کار خارجی پیونددهنده را بررسی می‌کند. اگر این شکل یک نمودار پیونددهنده به کتاب‌کار خارجی باشد، مثال [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) را در کنسول چاپ می‌کند. سپس یک نسخهٔ کپی از ارائه را ذخیره می‌کند.

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

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همان‌گونه که محتوای کتاب‌کارهای داخلی را ویرایش می‌کنید، ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنا پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی قابل دسترسی پیوند دارد استفاده می‌کند. مقدار پشتیبان‌ساز سلولی اولین نقطهٔ داده در اولین سری را به 100 تنظیم می‌کند و ارائهٔ به‌روزشده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیونددهنده را به‌روزرسانی کند، بنابراین برای حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

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

### **بازیابی کتاب‌کار از حافظهٔ کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که گم‌شده یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شیء [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) ایجاد کنید، متد [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) را فراخوانی کنید و قبل از باز کردن ارائه، [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را به `true` تنظیم کنید.

مثال زیر در جاوا داده‌های کتاب‌کار را برای یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی غیرقابل دسترس ارجاع می‌دهد، بازیابی می‌کند. داده‌های بازیابی‌شده از طریق [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌یابد:

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

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. فقط زمانی که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ قابل قبول باشد، بازیابی را فعال کنید؛ زیرا کش ممکن است تغییرات اعمال‌شده در کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه را شامل نشود.

## **سؤالات متداول**

**آیا می‌توانم تعیین کنم که آیا یک نمودار خاص به یک کتاب‌کار خارجی یا توکار پیوند دارد؟**

بله. یک نمودار دارای یک [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) و یک [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهای قرار گرفته بر روی منابع/اشتراک‌های شبکه استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دور از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides فایل XLSX خارجی را هنگام ذخیرهٔ ارائه بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) را ذخیره می‌کند. ویرایش داده‌های نمودار مبتنی بر سلول می‌تواند فایل XLSX محلی پیونددهنده را نیز به‌روزرسانی کند. اگر کتاب‌کار اصلی باید بدون تغییر بماند، از یک نسخهٔ کپی استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه کار کنم؟**

Aspose.Slides هنگام پیوند گذرواژه‌ای نمی‌پذیرد. یک روش معمول این است که پیش‌از‌پیش حفاظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (به‌عنوان مثال با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/java/)) تهیه کنید و به آن نسخه پیوند دهید.

**آیا چندین نمودار می‌توانند به همان کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار منعکس می‌شود.