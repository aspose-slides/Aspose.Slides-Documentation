---
title: مدیریت کتاب‌های کاربرگ نمودار در ارائه‌ها با استفاده از JavaScript
linktitle: کتاب کاربرگ نمودار
type: docs
weight: 70
url: /fa/nodejs-java/chart-workbook/
keywords:
- کتاب کاربرگ نمودار
- داده‌های نمودار
- سلول کتاب کار
- برچسب داده
- ورق کاری
- منبع داده
- کتاب کاربرگ خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب کار
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides برای Node.js را از طریق Java کشف کنید: به راحتی کتاب‌های کاربرگ نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌های کاربرگ نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب کار خوانده و نوشته شود، از سلول‌های کتاب کار به عنوان برچسب‌های داده نمودار استفاده شود، به مجموعه‌های ورق‌های کاری دسترسی پیدا شود و نوع منبع داده برای مقادیر نمودار مشخص شود.

همچنین کار با کتاب‌های کاربرگ خارجی به عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب کار خارجی ایجاد و اختصاص داده شود، مسیر کتاب کار خارجی مرتبط با یک نمودار بازیابی شود و داده‌های نمودار زمانی که کتاب کار در دسترس باشد ویرایش شوند.

## **خواندن و نوشتن داده‌های نمودار از کتاب کار**

Aspose.Slides روش‌های [readWorkbookStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) و [writeWorkbookStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌های کاربرگ داده‌های نمودار (شامل داده‌های نمودار ویرایش شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان صورت سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این کد JavaScript یک عملیات نمونه را نشان می‌دهد:

```javascript
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تنظیم سلول کتاب کار به عنوان برچسب دادهٔ نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. یک نمودار حبابی با برخی داده‌ها اضافه کنید.
1. سری‌های نمودار را دسترسی پیدا کنید.
1. سلول کتاب کار را به عنوان برچسب داده تنظیم کنید.
1. ارائه را ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه یک سلول کتاب کار را به عنوان برچسب دادهٔ نمودار تنظیم کنید:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// یک کلاس ارائه را که نمایانگر یک فایل ارائه است، نمونه‌سازی می‌کند
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مدیریت ورق‌های کاری**

این کد JavaScript عملیاتی را نشان می‌دهد که در آن روش [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) برای دسترسی به مجموعهٔ ورق‌های کاری استفاده می‌شود:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **مشخص کردن نوع منبع داده**

این کد JavaScript نشان می‌دهد چگونه یک نوع برای منبع داده مشخص کنید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تشخیص قالب‌های کتاب کار جاسازی‌شدهٔ پشتیبانی نشده**

Aspose.Slides قالب کتاب کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود را پشتیبانی نمی‌کند. می‌توانید از روش `getEmbeddedWorkbookType` در [ChartData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/) به همراه شمارش [WorkbookType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/workbooktype/) برای تشخیص قالب‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را رد کنید.

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // کتاب کار جاسازی‌شده در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue;
        }

        // در اینجا داده‌های کتاب کار نمودار را خوانده یا اصلاح کنید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب کار خارجی**

Aspose.Slides کتاب‌های کاربرگ خارجی را به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد کتاب کار خارجی**

با استفاده از روش‌های **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یا یک کتاب کار خارجی را از ابتدا ایجاد کنید یا یک کتاب کار داخلی را به خارجی تبدیل کنید.

این کد JavaScript فرایند ایجاد کتاب کار خارجی را نشان می‌دهد:

```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **تنظیم کتاب کار خارجی**

با استفاده از روش **`setExternalWorkbook`** می‌توانید یک کتاب کار خارجی را به عنوان منبع دادهٔ یک نمودار اختصاص دهید. این روش همچنین می‌تواند برای به‌روزرسانی مسیر کتاب کار خارجی استفاده شود (اگر کتاب کار جابجا شده باشد).

در حالی که نمی‌توانید داده‌های موجود در کتاب‌های کار ذخیره‌شده در مکان‌ها یا منابع راه دور را ویرایش کنید، همچنان می‌توانید از این کتاب‌ها به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این کد JavaScript نشان می‌دهد چگونه یک کتاب کار خارجی تنظیم کنید:

```javascript
// یک نمونه از کلاس Presentation ایجاد می‌کند
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

پارامتر `ChartData` (در زیر روش `setExternalWorkbook`) برای تعیین اینکه آیا یک کتاب کار اکسل بارگذاری شود یا نه استفاده می‌شود.

* وقتی مقدار `ChartData` به `false` تنظیم شود، فقط مسیر کتاب کار به‌روز می‌شود — داده‌های نمودار از کتاب کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند. ممکن است بخواهید از این تنظیم در شرایطی که کتاب کار هدف وجود ندارد یا در دسترس نیست استفاده کنید.  
* وقتی مقدار `ChartData` به `true` تنظیم شود، داده‌های نمودار از کتاب کار هدف به‌روزرسانی می‌شوند.

```javascript
// یک نمونه از کلاس Presentation ایجاد می‌کند
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **دریافت مسیر کتاب کار منبع دادهٔ خارجی نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. یک شی برای شکل نمودار ایجاد کنید.
1. یک شی برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع دادهٔ نمودار است ایجاد کنید.
1. شرط مرتبط را براساس اینکه نوع منبع همان نوع منبع دادهٔ کتاب کار خارجی باشد، مشخص کنید.

این کد JavaScript عملیات را نشان می‌دهد:

```javascript
// یک نمونه از کلاس Presentation ایجاد می‌کند
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // ارائه را ذخیره می‌کند
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های موجود در کتاب‌های کار خارجی را همانند تغییر محتویات کتاب‌های کار داخلی ویرایش کنید. وقتی یک کتاب کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این کد JavaScript پیاده‌سازی فرایند توصیف‌شده را نشان می‌دهد:

```javascript
// یک نمونه از کلاس Presentation ایجاد می‌کند
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **بازیابی کتاب کار از حافظه موقت نمودار**

اگر یک نمودار از کتاب کار خارجی استفاده کند که مفقود یا در دسترس نباشد، Aspose.Slides می‌تواند کتاب کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شی [LoadOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/) ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه متد [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) را با مقدار `true` صدا بزنید.

مثال JavaScript زیر ارائه‌ای را که نمودارش به کتاب کار خارجی در دسترس نیست ارجاع می‌دهد، باز می‌کند و داده‌های بازیابی‌شده را از طریق [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی می‌یابد:

```javascript
const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // در اینجا داده‌های کتاب کار بازیابی‌شده را بخوانید یا اصلاح کنید.
} finally {
    presentation.dispose();
}
```

اگر کتاب کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنایی پرتاب می‌کند. بازیابی را فقط زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ قابل قبول باشد، زیرا ممکن است کش شامل تغییراتی که پس از آخرین به‌روزرسانی ارائه در کتاب کار خارجی انجام شده باشد، نشود.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به یک کتاب کار خارجی یا جاسازی‌شده مرتبط است؟**

بله. یک نمودار دارای یک [data source type](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) و یک [path to an external workbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) است؛ اگر منبع یک کتاب کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید که از یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌های کار خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای قابلیت حمل پروژه مفید است؛ اما باید توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم کتاب‌های کاری که در منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کتاب‌های کاری می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌های کاری از راه دور توسط Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شود چه باید کرد؟**

Aspose.Slides هنگام ایجاد لینک از رمز عبور استفاده نمی‌کند. یک راه‌حل معمول این است که پیش از لینک‌کردن محافظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](/cells/nodejs-java/)) تهیه کنید و به آن نسخه لینک کنید.

**آیا می‌توان چندین نمودار را به یک کتاب کار خارجی ارجاع داد؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها انعکاس خواهد یافت.