---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/nodejs-java/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده نمودار
- سلول کتاب‌کار
- برچسب داده
- ورق کاری
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازسازی کتاب‌کار
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides برای Node.js از طریق Java را کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائهٔ خود را بهینه کنید."
---
## **بررسی کلی**

این مقاله نحوه کار با کتاب‌کارهای نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه می‌توان داده‌های نمودار را از طریق جریان‌های کتاب‌کار خواند و نوشت، از سلول‌های کتاب‌کار به عنوان برچسب‌های دادهٔ نمودار استفاده کرد، به مجموعه‌های شیت دسترسی یافت و نوع منبع داده برای مقادیر نمودار را مشخص کرد.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داده شود، مسیر یک کتاب‌کار خارجی مرتبط با یک نمودار بازیابی شود و داده‌های نمودار هنگام در دسترس بودن کتاب‌کار ویرایش گردد.

برای سلول‌های کتاب‌کار که نشان‌دهندهٔ دادهٔ گمشده هستند، به [Control the Display of Empty Cells](/slides/fa/nodejs-java/chart-series/) برای تفاوت بین سلول خالی و صفر و مقایسهٔ نمودار خطی حالت‌های نمایش موجود مراجعه کنید.

## **درج داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) برای کنترل این‌که آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی شیت رسم کند یا نه استفاده کنید. مقدار `true` باعث می‌شود تنها سلول‌های قابل مشاهده رسم شوند و مقدار `false` هر دو سلول قابل مشاهده و مخفی را شامل می‌شود. این تنظیم فقط بر رسم نمودار تأثیر دارد؛ ردیف‌ها یا ستون‌های شیت را مخفی یا نمایان نمی‌کند.

[پرزنتیشن نمونه](hidden-source-data.pptx) شامل یک نمودار ستونی به عنوان اولین شکل در اولین اسلاید آن است. شیت تعبیه‌شده، `Sheet1`، بازهٔ منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها همچنان مقادیر دارند.

| سطر شیت | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی پیدا کنید و با [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#isHidden) وضعیت مخفی بودن آن‌ها را بررسی کنید. این متد وضعیت مخفی بودن را بدون تغییر آن گزارش می‌کند. در این فایل، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم رسم، دادهٔ نمودار را تازه‌سازی کنید: کتاب‌کار تعبیه‌شده را با [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) نگه داشته و با [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) مجدداً بارگذاری کنید. هنگام درج همهٔ سلول‌ها، از [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) برای بازگرداندن بازهٔ کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. تغییر تنها پرچم کافی نیست تا داده‌های کش‌شدهٔ نمونهٔ نمودار و برچسب‌های دسته تازه‌سازی شوند. مثال با تبدیل بافر Node.js به آرایهٔ بایت جاوا قبل از ارسال به متد نوشتن این کار را انجام می‌دهد.

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
                // بازهٔ منبع کامل را بازیابی کنید، شامل دسته‌های مخفی.
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

مثال دو نسخه از پرزنتیشن را ذخیره می‌کند: یکی تنها با مقادیر خرده‌فروشی قابل مشاهده (`10` و `20`) و دیگری با تمام شش مقدار. تصاویر زیر دو حالت رسم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار تعبیه‌شده مخفی می‌مانند.

| تنها سلول‌های قابل مشاهده (`true`) | همه سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی حاوی مقدار با یک سلول خالی متفاوت است. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) نحوهٔ نمایش مقادیر گمشده را کنترل می‌کند؛ این گزینه داده‌های منبع مخفی را شامل یا مستثنی نمی‌کند. برای مثال به [Control the Display of Empty Cells](/slides/fa/nodejs-java/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازیابی بازهٔ دادهٔ یک نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک پرزنتیشن موجود، بازه‌های منبع را بررسی کنید تا ببینید هر نمودار از چه سلول‌های شیتی استفاده می‌کند. متد [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getRange) بازهٔ دادهٔ فعلی را به صورت یک فرمول معیّن‌شده برای شیت برمی‌گرداند، برای مثال `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام شیت است، `!` آن را از بازهٔ سلول‌ها جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت دلار نشان‌دهندهٔ ارجاع مطلق ردیف و ستون است.

این متد بازهٔ فعلی را بدون تغییر نمودار یا کتاب‌کار می‌خواند. اگر نمودار از کتاب‌کاری به عنوان منبع داده استفاده نکند، `InvalidOperationException` پرتاب می‌کند. برای اطلاعات بیشتر به [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) مراجعه کنید.

این مثال یک پرزنتیشن را باز می‌کند و شکل‌های موجود در هر اسلاید را برای یافتن نمودارها بررسی می‌کند. نام هر نمودار و بازهٔ منبع آن را چاپ می‌کند. اگر نموداری از کتاب‌کار استفاده نکند، پیغامی چاپ می‌کند و به نمودار بعدی ادامه می‌دهد.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **خواندن و نوشتن دادهٔ نمودار از کتاب‌کار**

Aspose.Slides برای Node.js از طریق Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) و [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) را فراهم می‌کند که امکان خواندن و نوشتن کتاب‌کارهای دادهٔ نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را می‌دهد. **نکته** این است که دادهٔ نمودار باید به همان شکل سازماندهی شده باشد یا ساختاری مشابه منبع داشته باشد.

این مثال یک پرزنتیشن با یک نمودار به عنوان اولین شکل در اولین اسلاید آن را استفاده می‌کند. کتاب‌کار تعبیه‌شده را به یک آرایهٔ بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال پرزنتیشن را ذخیره نمی‌کند.

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

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**

زمانی که کتاب‌کار تعبیه‌شده را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#validateChartLayout) با خطای «اندیس خارج از محدوده» شکست بخورد. پیش از نوشتن کتاب‌کار به‌روز شده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اولین اسلاید است استفاده می‌کند. کامنت محل ویرایش کتاب‌کار را نشان می‌دهد؛ مثال اجرایی کتاب‌کار اصلی را باز می‌نویسد و چیدمان را در حافظه اعتبارسنجی می‌کند.

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

        // در اینجا بایت‌های کتاب‌کار را اصلاح کنید، برای مثال با استفاده از Aspose.Cells.

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

پاک‌سازی مجموعه‌ها قبل از نوشتن کتاب‌کار، ارجاعات داده‌های منقضی‌شده را حذف می‌کند. پیش از استفاده از نمودار، هر سری و نگاشت دسته مورد نیاز برای کتاب‌کار به‌روز شده را بازسازی کنید.

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با دادهٔ پیش‌فرض به اولین اسلاید یک پرزنتیشن موجود اضافه می‌کند. از سلول‌های A10:A12 در شیت 0 برای سه برچسب اولین سری استفاده می‌کند، برچسب‌ها از سلول‌ها فعال می‌شوند و پرزنتیشن به‌روز شده ذخیره می‌شود.

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

## **مدیریت شیت‌ها**

متد [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) دسترسی به شیت‌های موجود در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و نام هر شیت را در کنسول چاپ می‌کند.

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

این مثال یک نمودار ستونی 3D با دادهٔ پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده مختلف تنظیم می‌کند. نام اول از یک رشتهٔ متنی استفاده می‌کند؛ نام دوم از سلول C1 در شیت 0 استفاده می‌کند. شمارش [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال پرزنتیشن را با نام‌های سری به‌روز شده ذخیره می‌کند.

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

## **تشخیص قالب‌های کتاب‌کار تعبیه‌شدهٔ پشتیبانی‌نشده**

Aspose.Slides از قالب کتاب‌کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها تعبیه شود پشتیبانی نمی‌کند. می‌توانید با استفاده از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) بر روی [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) قالب‌های پشتیبانی‌نشده را شناسایی و آن نمودارها را نادیده بگیرید. این مثال شکل‌های اولین اسلاید یک پرزنتیشن موجود را بررسی می‌کند، شکل‌های غیرنموداری را صرف‌نظر می‌کند و برای هر نمودار دارای کتاب‌کار .xlsb پیغام عیب‌یابی چاپ می‌کند.

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

        // اینجا داده‌های کتاب‌کار پشتیبانی‌شدهٔ نمودار را بخوانید یا اصلاح کنید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides پشتیبانی از استفاده از کتاب‌کارهای خارجی به عنوان منبع دادهٔ نمودارها را فراهم می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) و [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) برای استخراج کتاب‌کار نمودار تعبیه‌شده به یک فایل و پیوند دادن نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را استخراج می‌کند. پس از نوشتن کامل فایل، کتاب‌کار خارجی را به عنوان منبع دادهٔ نمودار اختصاص می‌دهد و پرزنتیشن پیوندشده را ذخیره می‌کند.

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

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به عنوان منبع دادهٔ آن اختصاص دهید. این متد می‌تواند مسیر کتاب‌کار خارجی را نیز به‌روزرسانی کند (اگر کتاب‌کار جابه‌جا شده باشد).

در حالی که نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های راه دور یا منابع را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که شیت `Sheet1` آن شامل نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوند می‌دهد و با [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) بازهٔ A1:B4 را به یک سری و سه دسته اختصاص می‌دهد. پرزنتیشن با نمودار پیوندشده ذخیره می‌شود.

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

پارامتر `updateChartData` متد [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) کنترل می‌کند که آیا کتاب‌کار بارگیری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، تنها مسیر کتاب‌کار به‌روز می‌شود. دادهٔ نمودار از کتاب‌کار هدف بارگیری یا به‌روزرسانی نمی‌شود، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، دادهٔ نمودار از کتاب‌کار هدف به‌روزرسانی می‌شود.

مثال زیر یک URL جایگزین را با `updateChartData` تنظیم شده بر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شوند و پرزنتیشن بدون بارگیری کتاب‌کار در دسترس نیست ذخیره می‌شود.

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

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی کتاب‌کاری که به یک نمودار پیوند داده شده است، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را بازیابی کنید.

این مثال اولین شکل در اولین اسلاید یک پرزنتیشن با کتاب‌کار خارجی پیوندشده را بررسی می‌کند. اگر شکل یک نمودار پیوندشده به کتاب‌کار خارجی باشد، [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) را در کنسول چاپ می‌کند. سپس یک کپی از پرزنتیشن را ذخیره می‌کند.

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

### **ویرایش دادهٔ نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همان‌طور که داده‌های کتاب‌کارهای داخلی را ویرایش می‌کنید، ویرایش کنید. وقتی کتاب‌کار خارجی قابل بارگیری نباشد، استثنائی پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی قابل دسترس پیوند دارد استفاده می‌کند. مقدار نقطهٔ دادهٔ اول در سری اول را به 100 تنظیم می‌کند و پرزنتیشن به‌روز شده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوندشده را به‌روز کند؛ بنابراین اگر نیاز به حفظ کتاب‌کار اصلی داشته باشید، از یک کپی استفاده کنید.

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

اگر نموداری از یک کتاب‌کار خارجی که گم شده یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در پرزنتیشن بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) ایجاد کنید، [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) را فراخوانی کنید و [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) را قبل از باز کردن پرزنتیشن بر روی `true` تنظیم کنید.

مثال جاوااسکریپت زیر داده‌های کتاب‌کار را برای یک نمودار که اولین شکل در اولین اسلاید است و به یک کتاب‌کار خارجی در دسترس نیست ارجاع می‌دهد، بازمی‌گیرد. داده‌های بازیابیده‌شده از طریق [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getChartData) و [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی پیدا می‌شود:

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

        // در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا اصلاح کنید.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنایی پرتاب می‌کند. بازیابی را فقط زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار گزینهٔ قابل قبول باشد، زیرا کش ممکن است شامل تغییراتی که پس از آخرین به‌روزرسانی پرزنتیشن در کتاب‌کار خارجی اعمال شده باشد، نباشد.

## **سؤالات متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به یک کتاب‌کار خارجی یا تعبیه‌شده پیوند دارد؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getDataSourceType) و [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. پرزنتیشن مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابجایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که روی منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای راه‌دور از Aspose.Slides پشتیبانی نمی‌شود؛ فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره پرزنتیشن، فایل XLSX خارجی را بازنویسی می‌کند؟**

پرزنتیشن یک [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) ذخیره می‌کند. ویرایش داده‌های نمودار مبتنی بر سلول می‌تواند فایل XLSX محلی پیوندشده را نیز به‌روزرسانی کند. اگر باید کتاب‌کار اصلی دست‌نخورده بماند، از یک کپی استفاده کنید.

**اگر فایل خارجی با رمزعبور محافظت شود چه باید کرد؟**

Aspose.Slides هنگام پیوند گذرواژه‌ای نمی‌پذیرد. یک روش معمول حذف حفاظت پیش از پیوند یا آماده‌سازی یک کپی رمزگشایی‌شده (به‌عنوان مثال با [Aspose.Cells](https://reference.aspose.com/cells/java/)) و پیوند به آن کپی است.

**آیا می‌توان چندین نمودار را به یک کتاب‌کار خارجی ارجاع داد؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس می‌شود.