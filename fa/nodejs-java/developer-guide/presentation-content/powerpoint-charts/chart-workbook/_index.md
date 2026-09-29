---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با استفاده از JavaScript
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/nodejs-java/chart-workbook/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides برای Node.js via Java را کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را ساده‌سازی کنید."
---
## **مرور کلی**

این مقاله نحوه کار با کتاب‌کارهای نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه می‌توان داده‌های نمودار را از طریق جریان‌های کتاب‌کار خواند و نوشت، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کرد، به مجموعه‌های برگه کاری دسترسی پیدا کرد و نوع منبع داده برای مقادیر نمودار را مشخص کرد.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داده می‌شود، مسیر کتاب‌کار خارجی مرتبط با یک نمودار بازیابی می‌شود و داده‌های نمودار زمانی که کتاب‌کار موجود باشد ویرایش می‌گردد.

برای سلول‌های کتاب‌کار که نمایانگر داده‌های گمشده هستند، به بخش [Control the Display of Empty Cells](/slides/fa/nodejs-java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر را ببینید و مقایسه‌ای خطی از حالت‌های نمایش موجود در نمودار را مشاهده کنید.

## **شامل کردن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) برای کنترل اینکه آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی برگه کاری ترسیم می‌کند یا خیر استفاده کنید. آن را به `true` تنظیم کنید تا فقط سلول‌های قابل مشاهده ترسیم شوند، یا به `false` تا هر دو سلول قابل مشاهده و مخفی شامل شوند. این تنظیم فقط ترسیم نمودار را کنترل می‌کند؛ ردیف‌ها یا ستون‌های برگه کاری را مخفی یا نمایان نمی‌کند.

فایل [hidden-source-data.pptx](hidden-source-data.pptx) را دانلود کنید و در دایرکتوری کاری قرار دهید. اولین اسلاید آن شامل یک نمودار ستونی به عنوان اولین شکل است. برگه کاری تعبیه‌شده، `Sheet1`، دامنه منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها هنوز مقدار دارند.

| ردیف برگه کاری | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

از طریق [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) به سلول‌های منبع دسترسی پیدا کنید و با [ChartDataCell.isHidden](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdatacell/#isHidden) وضعیت مخفی بودن آن‌ها را بررسی کنید. این متد وضعیت مخفی بودن را بدون تغییر آن گزارش می‌کند. در این فایل، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه کنید: کتاب‌کار تعبیه‌شده را با [readWorkbookStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) نگه دارید و با [writeWorkbookStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) دوباره بارگذاری کنید. هنگام شامل کردن همه سلول‌ها، همچنین از [setRange](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#setRange) برای بازگرداندن دامنه کامل، از جمله دسته فوریه مخفی، استفاده کنید. فقط تغییر پرچم برای تازه‌سازی داده‌های کش شده این نمونه کافی نیست. مثال با تبدیل بافر Node.js به آرایه بایت جاوا قبل از پاس کردن به متد نوشتن، این کار را انجام می‌دهد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // داده‌های نمودار را از کتاب‌کار تعبیه‌شده تازه‌سازی کنید.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // دامنه منبع کامل را بازگردانید، از جمله دسته‌های مخفی.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

مثال `hidden_cells_true.pptx` را با فقط مقادیر خرده‌فروشی قابل مشاهده (10 و 20) و `hidden_cells_false.pptx` را با همه شش مقدار ذخیره می‌کند. تصاویر زیر دو حالت ترسیم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار تعبیه‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | همه سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی که دارای مقدار است، متفاوت از یک سلول خالی است. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) کنترل می‌کند که مقادیر گمشده چگونه نمایش داده شوند؛ این متد داده‌های منبع مخفی را شامل یا حذف نمی‌کند. برای مثال به [Control the Display of Empty Cells](/slides/fa/nodejs-java/chart-series/#control-the-display-of-empty-cells) رجوع کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides for Node.js via Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) و [writeWorkbookStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌کارهای داده نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال `chart.pptx` را باز می‌کند که باید یک نمودار به عنوان اولین شکل در اولین اسلاید داشته باشد. کتاب‌کار تعبیه‌شده را به یک آرایه بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **اعتبارسنجی طرح‌بندی نمودار پس از اصلاح کتاب‌کار**

زمانی که یک کتاب‌کار تعبیه‌شده را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعه‌های سری و دسته اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شکست [Chart.validateChartLayout](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/#validateChartLayout) با خطای out-of-range شود. قبل از نوشتن کتاب‌کار به‌روزشده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال به `chart.pptx` با یک نمودار به عنوان اولین شکل در اولین اسلاید نیاز دارد. علامت‌گذاری نظرات نشان می‌دهد که ویرایش کتاب‌کار در کجا انجام می‌شود؛ مثال قابل اجرا کتاب‌کار اصلی را بازنویسی می‌کند و طرح‌بندی را در حافظه اعتبارسنجی می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // در اینجا بایت‌های کتاب‌کار را تغییر دهید، برای مثال با استفاده از Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

پاک‌سازی مجموعه‌ها قبل از نوشتن کتاب‌کار، مراجع داده منسوخ را حذف می‌کند. پیش از استفاده از نمودار، هر سری و نگاشت دسته مورد نیاز برای کتاب‌کار به‌روزشده دوباره ساخته شود.

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب داده نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید. مراحل زیر نشان می‌دهد چگونه برچسب‌ها را در یک نمودار حبابی به سلول‌های کتاب‌کار داده مرتبط کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. اولین اسلاید را با اندیس صفر مبنا دسترسی پیدا کنید.
1. یک نمودار حبابی با داده پیش‌فرض اضافه کنید.
1. سری نمودار را دسترسی پیدا کنید.
1. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.
1. ارائه را ذخیره کنید.

این مثال `chart2.pptx` را باز می‌کند که باید حداقل یک اسلاید داشته باشد و یک نمودار حبابی با داده پیش‌فرض اضافه می‌کند. از سلول‌های A10:A12 در برگه کاری 0 برای سه برچسب اول در اولین سری استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌سازد و نتیجه را در `resultchart.pptx` ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مدیریت برگه‌های کاری**

متد [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) دسترسی به برگه‌های کاری در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده پیش‌فرض ایجاد می‌کند و نام هر برگه کاری را به کنسول چاپ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **مشخص کردن نوع منبع داده**

این مثال یک نمودار ستونی سه‌بعدی با داده پیش‌فرض ایجاد می‌کند و دو نام سری را با استفاده از منابع داده متفاوت تنظیم می‌کند. نام اول از یک رشته ثابت استفاده می‌کند؛ نام دوم از سلول C1 در برگه کاری 0 استفاده می‌کند. enumeration [DataSourceType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. نتیجه در `pres.pptx` ذخیره می‌شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تشخیص فرمت‌های کتاب‌کارهای تعبیه‌شده پشتیبانی‌نشده**

Aspose.Slides از فرمت کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها تعبیه شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) روی [ChartData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/) همراه با enumeration [WorkbookType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/workbooktype/) فرمت‌های پشتیبانی‌نشده را تشخیص داده و آن نمودارها را عبور کنید. این مثال شکل‌های اولین اسلاید `sample.pptx` را بررسی می‌کند، اشکال غیرنموداری را رد می‌کند و برای هر نموداری که کتاب‌کار .xlsb تعبیه‌شده دارد پیام تشخیصی چاپ می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // در اینجا داده‌های کتاب‌کار نمودار پشتیبانی‌شده را بخوانید یا تغییر دهید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) و [setExternalWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) برای استخراج کتاب‌کار نمودار تعبیه‌شده به یک فایل و لینک کردن نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده پیش‌فرض ایجاد می‌کند، کتاب‌کار آن را به `externalWorkbook1.xlsx` می‌نویسد و قبل از اختصاص فایل به عنوان منبع داده نمودار، نوشتن فایل را تکمیل می‌کند. ارائه لینک‌شده را در `externalWorkbook.pptx` ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به عنوان منبع داده اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورت جابه‌جایی آن) استفاده شود.

اگرچه نمی‌توانید داده‌ها رادر کتاب‌کارهای ذخیره‌شده در مکان‌های دور یا منابع ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌گردد.

این مثال به `externalWorkbook.xlsx` در دایرکتوری کاری نیاز دارد. برگه کاری به نام `Sheet1` باید یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 داشته باشد. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را لینک می‌کند و با استفاده از [setRange](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#setRange) دامنه A1:B4 را به یک سری و سه دسته نگاشت می‌کند. نتیجه در `Presentation_with_externalWorkbook.pptx` ذخیره می‌شود.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پارامتر `updateChartData` متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) کنترل می‌کند که آیا کتاب‌کار بارگذاری شود یا خیر.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روز می‌شود. داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روز نمی‌شوند، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روز می‌شود.

مثال زیر یک URL جایگزین را با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شود و ارائه بدون بارگذاری کتاب‌کار در دسترس ذخیره می‌گردد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **دریافت مسیر کتاب‌کار منبع داده خارجی یک نمودار**

برای شناسایی کتاب‌کاری که به یک نمودار لینک شده است، ابتدا بررسی کنید که آیا نمودار از منبع داده خارجی استفاده می‌کند یا خیر. اگر چنین باشد، می‌توانید مسیر کتاب‌کار را با انجام مراحل زیر دریافت کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
1. اولین اسلاید را با اندیس صفر مبنا دسترسی پیدا کنید.
1. اطمینان حاصل کنید که اولین شکل یک نمودار است.
1. نوع منبع داده نمودار را بخوانید.
1. اگر منبع یک کتاب‌کار خارجی باشد، مسیر آن را بخوانید.

این مثال `externalWorkbook.pptx` را که در مثال قبلی ایجاد شده، باز می‌کند و اولین شکل در اولین اسلاید را بررسی می‌کند. اگر یک نمودار لینک‌شده به کتاب‌کار خارجی باشد، [getExternalWorkbookPath](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را در `Result.pptx` ذخیره می‌کند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همانند تغییرات در کتاب‌کارهای داخلی ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا رخ می‌دهد.

این مثال به `presentation.pptx` که یک نمودار به عنوان اولین شکل در اولین اسلاید دارد و یک کتاب‌کار خارجی قابل دسترسی نیاز دارد، نیاز دارد. مقدار نقطه داده اول در سری اول را به 100 تنظیم می‌کند و ارائه را در `presentation_out.pptx` ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی را به‌روز کند؛ بنابراین برای حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **بازیابی کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که در دسترس نیست یا گم شده استفاده می‌کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/) ایجاد کنید، [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) را فراخوانی کنید و قبل از باز کردن ارائه، [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) را به `true` تنظیم کنید.

مثال جاوااسکریپت زیر `presentation.pptx` را که اولین شکل در اولین اسلید باید یک نمودار اشاره‌گر به کتاب‌کار خارجی غیرقابل دستیابی باشد، باز می‌کند و داده‌های بازیابی‌شده را از طریق [Chart.getChartData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/#getChartData) و [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی می‌یابد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا تغییر دهید.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک استثنا می‌اندازد. فقط زمانی که استفاده از داده‌های کش‌شده نمودار یک گزینه قابل قبول باشد، بازیابی را فعال کنید، زیرا کش ممکن است شامل تغییرات انجام‌شده در کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **سؤالات متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به کتاب‌کار خارجی یا تعبیه‌شده لینک دارد؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#getDataSourceType) و [path to an external workbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را خوانده و مطمئن شوید که فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابه‌جایی کتاب‌کار ممکن است نیاز به به‌روزرسانی لینک داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/به اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به عنوان منبع داده خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای دور از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) را ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبانی‌شده از سلول می‌تواند فایل XLSX محلی مرتبط را نیز به‌روز کند. اگر کتاب‌کار اصلی باید بدون تغییر بماند، از یک کپی آن استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شود چه باید کرد؟**

Aspose.Slides هنگام لینک کردن رمز عبور را قبول نمی‌کند. یک روش معمول این است که پیش از آن‌را محافظت حذف کنید یا یک نسخه بدون رمز (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/java/)) تهیه کنید و به آن لینک دهید.

**آیا امکان دارد چندین نمودار به یک کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس خواهد شد.