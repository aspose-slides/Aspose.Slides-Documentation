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
description: "با Aspose.Slides برای Node.js از طریق Java، به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های دادهٔ نمودار استفاده کنید، به مجموعهٔ برگه‌های کاری دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را تعیین کنید.

همچنین نحوهٔ کار با کتاب‌کارهای خارجی به عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را دریافت کنید، و دادهٔ نمودار را زمانی که کتاب‌کار در دسترس باشد ویرایش کنید.

## **خواندن و نوشتن دادهٔ نمودار از کتاب‌کار**

Aspose.Slides متدهای [readWorkbookStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) و [writeWorkbookStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) را فراهم می‌کند که امکان خواندن و نوشتن کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را می‌دهد. **توجه** داشته باشید که دادهٔ نمودار باید به همان شیوه سازماندهی شود یا ساختاری مشابه منبع داشته باشد.

این کد JavaScript یک عملیات نمونه را نشان می‌دهد:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **اعتبارسنجی چیدمان نمودار پس از اصلاح کتاب‌کار**

وقتی کتاب‌کار توکار را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار سری‌ها و مجموعهٔ دسته‌بندی‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود متد [Chart.validateChartLayout](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Chart#validateChartLayout--) با خطای «index‑out‑of‑range» مواجه شود. قبل از نوشتن کتاب‌کار به‌روزشده به نمودار، سری‌ها و دسته‌ها را پاک کنید.

```javascript
// پس از اصلاح جریان کتاب‌کار (مثلاً با استفاده از Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// حذف مراجع داده‌های موجود.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

پاک کردن این مجموعه‌ها اطمینان می‌دهد که ساختار دادهٔ نمودار با کتاب‌کار جدید سازگار است و `validateChartLayout` بدون خطا اجرا می‌شود.

## **تنظیم سلول کتاب‌کار به عنوان برچسب دادهٔ نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.  
2. از طریق اندیس، مرجع یک اسلاید را دریافت کنید.  
3. یک نمودار حبابی با برخی داده‌ها اضافه کنید.  
4. به سری‌های نمودار دسترسی پیدا کنید.  
5. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.  
6. ارائه را ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه سلول کتاب‌کار را به عنوان برچسب دادهٔ نمودار تنظیم کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
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

## **مدیریت برگه‌های کاری**

این کد JavaScript عملیاتی را نشان می‌دهد که در آن از متد [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) برای دسترسی به مجموعهٔ برگه‌های کاری استفاده می‌شود:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **مشخص‌کردن نوع منبع داده**

این کد JavaScript نشان می‌دهد چگونه برای یک منبع داده نوعی را تعیین کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **تشخیص قالب‌های کتاب‌کار توکار پشتیبانی‌نشده**

Aspose.Slides از قالب کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها توکار باشد، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد `getEmbeddedWorkbookType` روی [ChartData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/) و به‌همراه شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/workbooktype/) قالب‌های پشتیبانی‌نشده را شناسایی کرده و آن نمودارها را نادیده بگیرید.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
            // کتاب‌کار توکار در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue;
        }

        // داده‌های کتاب‌کار نمودار را در اینجا بخوانید یا اصلاح کنید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد کتاب‌کار خارجی**

با استفاده از متدهای **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یا یک کتاب‌کار خارجی از صفر ایجاد کنید یا یک کتاب‌کار داخلی را به‌صورت خارجی درآورید.

این کد JavaScript فرآیند ایجاد کتاب‌کار خارجی را نشان می‌دهد:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // متد readWorkbookStream بایت‌های کتاب‌کار را به‌صورت یک Buffer از Node بر می‌گرداند.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **تنظیم کتاب‌کار خارجی**

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورت جابه‌جا شدن) مورد استفاده قرار گیرد.

در حالی که نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع را ویرایش کنید، همچنان می‌توانید از این کتاب‌کارها به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این کد JavaScript نشان می‌دهد چگونه کتاب‌کار خارجی را تنظیم کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

پارامتر دوم متد `setExternalWorkbook`، `updateChartData`، مشخص می‌کند که آیا کتاب‌کار Excel بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود—دادهٔ نمودار بارگذاری یا به‌روز نمی‌شود. این تنظیم را وقتی که کتاب‌کار هدف موجود نیست یا در دسترس نیست، می‌توان استفاده کرد.  
* وقتی `updateChartData` برابر `true` باشد، دادهٔ نمودار از کتاب‌کار هدف به‌روز می‌شود.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.  
2. از طریق اندیس، مرجع یک اسلاید را دریافت کنید.  
3. یک شیء برای شکل نمودار ایجاد کنید.  
4. یک شیء برای نوع منبع (`ChartDataSourceType`) که منبع دادهٔ نمودار را نشان می‌دهد، ایجاد کنید.  
5. شرط مرتبط را بر اساس این که نوع منبع همان نوع منبع دادهٔ کتاب‌کار خارجی باشد، مشخص کنید.

این کد JavaScript عملیات را نشان می‌دهد:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **ویرایش دادهٔ نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همان‌گونه که محتویات کتاب‌کارهای داخلی را تغییر می‌دهید، ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی پرتاب می‌شود.

این کد JavaScript پیاده‌سازی فرآیند توصیف‌شده را نشان می‌دهد:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **بازیابی کتاب‌کار از حافظهٔ نهان نمودار**

اگر یک نمودار از کتاب‌کار خارجی استفاده می‌کند که گم شده یا در دسترس نیست، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازیابی کند. یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/) ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/spreadsheetoptions/) پیکربندی کنید، و قبل از باز کردن ارائه متد [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) را با مقدار `true` صدا بزنید.

مثال JavaScript زیر یک ارائه که مرجع کتاب‌کار خارجی غیرقابل دسترس دارد باز می‌کند و داده‌های بازیابی‌شده را از طریق [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) دسترسی می‌یابد:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // داده‌های کتاب‌کار بازیابی‌شده را در اینجا بخوانید یا اصلاح کنید.
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنایی پرتاب می‌کند. فقط زمانی که استفاده از داده‌های کش‌شدهٔ نمودار گزینهٔ مقبولی باشد، بازیابی را فعال کنید؛ زیرا ممکن است کش شامل تغییراتی که پس از آخرین به‌روزرسانی ارائه در کتاب‌کار خارجی انجام شده باشد، نباشد.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به کتاب‌کار خارجی یا توکار لینک شده است؟**

بله. یک نمودار دارای یک [data source type](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) و یک [path to an external workbook](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا از استفاده از فایل خارجی اطمینان حاصل کنید.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این امر برای قابلیت حمل پروژه مفید است؛ اما باید بدانید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهایی که در منابع شبکه/به‌اشتراک‌گذاری قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای دوردست از طریق Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شده باشد باید چه کاری انجام دهم؟**

Aspose.Slides هنگام لینک کردن رمز عبور را نمی‌پذیرد. یک روش معمول این است که پیش از لینک کردن حفاظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده تهیه کنید (به‌عنوان مثال با استفاده از [Aspose.Cells](/cells/nodejs-java/)) و به آن نسخه لینک کنید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی اشاره کنند؟**

بله. هر نمودار لینک خودش را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار بازتاب خواهد یافت.