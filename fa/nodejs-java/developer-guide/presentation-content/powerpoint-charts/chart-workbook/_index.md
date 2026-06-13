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
- شیت‌کار
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides برای Node.js را از طریق Java کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **نمای کلی**

این مقاله نحوه کار با کتاب‌های کار نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار خوانده و نوشت، از سلول‌های کتاب‌کار به عنوان برچسب داده‌های نمودار استفاده کرد، به مجموعه‌های شیت‌ها دسترسی داشت و نوع منبع داده برای مقادیر نمودار را مشخص کرد.

همچنین کار با کتاب‌های کار خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داد، مسیر یک کتاب‌کار خارجی پیوست به نمودار را بازیابی کرد و داده‌های نمودار را زمانی که کتاب‌کار در دسترس است، ویرایش کرد.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides متدهای [readWorkbookStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) و [writeWorkbookStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌کارهای داده نمودار (حاوی داده‌های ویرایش شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

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

## **تنظیم سلول کتاب‌کار به عنوان برچسب داده نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک نمودار حبابی با برخی داده‌ها اضافه کنید.
4. به سری‌های نمودار دسترسی پیدا کنید.
5. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.
6. ارائه را ذخیره کنید.

این کد JavaScript نشان می‌دهد چگونه سلول کتاب‌کار را به عنوان برچسب داده نمودار تنظیم کنید:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند
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

## **مدیریت شیت‌ها**

این کد JavaScript عملی را نشان می‌دهد که در آن متد [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) برای دسترسی به مجموعه شیت‌ها استفاده می‌شود:

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

این کد JavaScript نشان می‌دهد چگونه برای یک منبع داده نوعی را مشخص کنید:

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

## **تشخیص فرمت‌های کتاب‌کار تعبیه‌شده که پشتیبانی نمی‌شوند**

Aspose.Slides فرمت کتاب‌کار باینری اکسل (.xlsb) را که می‌تواند در برخی نمودارها تعبیه شود، پشتیبانی نمی‌کند. می‌توانید از متد `getEmbeddedWorkbookType` در [ChartData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/) همراه با شمارنده [WorkbookType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/workbooktype/) برای تشخیص فرمت‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را نادیده بگیرید.

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
            // کتاب‌کار توکار در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue;
        }

        // داده‌های کتاب‌کار نمودار را اینجا بخوانید یا تغییر دهید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides کتاب‌کارهای خارجی را به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد کتاب‌کار خارجی**

با استفاده از متدهای **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یا یک کتاب‌کار خارجی را از صفر ایجاد کنید یا یک کتاب‌کار داخلی را به صورت خارجی تبدیل کنید.

این کد JavaScript فرآیند ایجاد کتاب‌کار خارجی را نشان می‌دهد:

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

### **تنظیم کتاب‌کار خارجی**

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به‌عنوان منبع داده یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورت جابجا شدن آن) استفاده شود.

در حالی که نمی‌توانید داده‌های کتاب‌کارهای ذخیره‌شده در مکان‌های دور یا منابع را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

این کد JavaScript نشان می‌دهد چگونه کتاب‌کار خارجی تنظیم شود:

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

پارامتر `ChartData` (در زیر متد `setExternalWorkbook`) برای مشخص کردن این‌که آیا کتاب‌کار Excel بارگذاری شود یا نه استفاده می‌شود.

* هنگامی که مقدار `ChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود—داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند. می‌توانید از این تنظیم زمانی استفاده کنید که کتاب‌کار هدف وجود نداشته باشد یا در دسترس نباشد.
* هنگامی که مقدار `ChartData` برابر `true` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

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

### **دریافت مسیر کتاب‌کار منبع داده خارجی نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید.
2. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
3. یک شی برای شکل نمودار ایجاد کنید.
4. یک شی برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع داده نمودار است، ایجاد کنید.
5. شرط مربوطه را بر اساس این که نوع منبع همانند نوع منبع داده کتاب‌کار خارجی باشد، مشخص کنید.

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

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همانند تغییر محتویات کتاب‌کارهای داخلی ویرایش کنید. وقتی کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این کد JavaScript پیاده‌سازی فرآیند توصیف‌شده را نشان می‌دهد:

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

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به کتاب‌کار خارجی یا تعبیه‌شده لینک دارد؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) و [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید از فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شود و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌طور خودکار به مسیر مطلق تبدیل می‌شود. این برای جابجایی پروژه مفید است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/به‌اشتراک‌گذاری‌های شبکه‌ای قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دور از Aspose.Slides پشتیبانی نمی‌شود—فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره ارائه فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیره ارائه تغییر نمی‌کند.

**اگر فایل خارجی دارای رمز عبور باشد باید چه کنم؟**

Aspose.Slides هنگام لینک کردن رمز عبور را قبول نمی‌کند. یک راه معمول این است که پیش از لینک کردن حفاظت را حذف کنید یا یک نسخه رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](/cells/nodejs-java/)) آماده کنید و به آن لینک کنید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی اشاره کنند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار منعکس می‌شود.