---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها با استفاده از جاوا
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/java/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- ورق کاری
- منبع داده
- کتاب‌کار خارجی
- داده‌های خارجی
- کش نمودار
- بازیابی کتاب‌کار
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "Aspose.Slides برای جاوا را کشف کنید: به‌سادگی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب داده‌های نمودار استفاده کنید، به مجموعه‌ورق‌های کاری دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر یک کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کنید و وقتی کتاب‌کار در دسترس است داده‌های نمودار را ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**
Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌کارهای داده‌های نمودار (که شامل داده‌های ویرایش شده با Aspose.Cells هستند) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازماندهی شده یا ساختاری مشابه منبع داشته باشند.

این کد Java یک عملیات نمونه را نشان می‌دهد:

```java
Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب داده‌های نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. از طریق ایندکس، مرجع یک اسلاید را دریافت کنید.
1. یک نمودار حبابی با برخی داده‌ها اضافه کنید.
1. به سری‌های نمودار دسترسی پیدا کنید.
1. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.
1. ارائه را ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک سلول کتاب‌کار را به عنوان برچسب داده‌های نمودار تنظیم کنید:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// یک شیء از کلاس Presentation که نمایانگر یک فایل ارائه است را ایجاد می‌کند
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **مدیریت ورق‌های کاری**

این کد Java عملیاتی را نشان می‌دهد که در آن متد [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) برای دسترسی به مجموعه‌ورق‌های کاری استفاده می‌شود:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **مشخص کردن نوع منبع داده**

این کد Java نشان می‌دهد چگونه یک نوع برای منبع داده مشخص کنید:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تشخیص فرمت‌های کتاب‌کار تعبیه‌شده پشتیبانی‌نشده**

Aspose.Slides از فرمت کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها تعبیه شود پشتیبانی نمی‌کند. می‌توانید از متد `getEmbeddedWorkbookType` روی [IChartData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData) همراه با شمارنده [WorkbookType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/WorkbookType) برای تشخیص فرمت‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را رد کنید.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // کتاب‌کار تعبیه‌شده در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue;
        }

        // داده‌های کتاب‌کار نمودار را اینجا بخوانید یا ویرایش کنید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

{{% alert color="primary" %}} 
در [Aspose.Slides 19.4](https://docs.aspose.com/slides/fa/java/aspose-slides-for-java-19-4-release-notes/) ما پشتیبانی از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها را پیاده‌سازی کردیم.
{{% /alert %}} 

### **ایجاد یک کتاب‌کار خارجی**

با استفاده از متدهای **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یا یک کتاب‌کار خارجی را از ابتدا ایجاد کنید یا یک کتاب‌کار داخلی را به خارجی تبدیل کنید.

این کد Java فرآیند ایجاد کتاب‌کار خارجی را نشان می‌دهد:

```java
Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به عنوان منبع داده به یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (اگر جابجا شده باشد) استفاده شود.

اگرچه نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های ریموت یا منابع را ویرایش کنید، می‌توانید همچنان از چنین کتاب‌کارهایی به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی ارائه شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

این کد Java نشان می‌دهد چگونه یک کتاب‌کار خارجی تنظیم کنید:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

پارامتر `ChartData` (در زیر متد `setExternalWorkbook`) برای مشخص کردن اینکه آیا کتاب‌کار Excel بارگذاری شود یا نه استفاده می‌شود.

* وقتی مقدار `ChartData` روی `false` تنظیم شود، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود—داده‌های نمودار از کتاب‌کار مقصد بارگذاری یا به‌روزرسانی نمی‌شوند. می‌توانید از این تنظیم زمانی استفاده کنید که کتاب‌کار مقصد وجود نداشته یا در دسترس نباشد.
* وقتی مقدار `ChartData` روی `true` تنظیم شود، داده‌های نمودار از کتاب‌کار مقصد به‌روزرسانی می‌شوند.

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **دریافت مسیر کتاب‌کار منبع داده خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. از طریق ایندکس، مرجع یک اسلاید را دریافت کنید.
1. یک شیء برای شکل نمودار ایجاد کنید.
1. یک شیء برای نوع منبع (`ChartDataSourceType`) که نشان‌دهنده منبع داده نمودار است، ایجاد کنید.
1. شرط مربوطه را بر اساس این‌که نوع منبع همان نوع منبع داده کتاب‌کار خارجی باشد، مشخص کنید.

این کد Java عملیات را نشان می‌دهد:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// پرزنتیشن را ذخیره می‌کند
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را به همان شکلی که محتویات کتاب‌کارهای داخلی را تغییر می‌دهید ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این کد Java پیاده‌سازی فرآیند توضیح‌داده‌شده را نشان می‌دهد:

```java
// یک نمونه از کلاس Presentation ایجاد می‌کند
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **بازیابی کتاب‌کار از حافظه‌پنهان نمودار**

اگر یک نمودار از یک کتاب‌کار خارجی استفاده کند که گم شده یا در دسترس نباشد، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه متد [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را با مقدار `true` فراخوانی کنید.

مثال Java زیر یک ارائه را که نمودار آن به یک کتاب‌کار خارجی غیرقابل دسترس ارجاع می‌دهد باز می‌کند و داده‌های بازیابی‌شده را از طریق [IChart.getChartData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌یابد:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // داده‌های کتاب‌کار بازیابی‌شده را اینجا بخوانید یا ویرایش کنید.
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک استثنا پرتاب می‌کند. بازگرداندن فقط زمانی فعال شود که استفاده از داده‌های کش‌شده نمودار یک گزینه قابل قبول باشد، زیرا کش ممکن است تغییراتی که پس از آخرین به‌روزرسانی ارائه در کتاب‌کار خارجی انجام شده‌اند را شامل نشود.

## **سؤالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به یک کتاب‌کار خارجی یا تعبیه‌شده لینک دارد؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getDataSourceType--) و [مسیر به یک کتاب‌کار خارجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید از یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای قابلیت حمل‌پذیری پروژه مفید است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم کتاب‌کارهایی را که در منابع/اشتراک‌های شبکه‌ای قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای ریموت از Aspose.Slides پشتیبانی نمی‌شود—فقط به عنوان منبع قابل استفاده هستند.

**آیا Aspose.Slides هنگام ذخیره ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه تنها یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) را ذخیره می‌کند و برای خواندن داده از آن استفاده می‌کند. فایل خارجی هنگام ذخیره ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه باید کرد؟**

Aspose.Slides هنگام لینک کردن از رمز عبور پشتیبانی نمی‌کند. یک رویکرد متداول این است که محافظت را از پیش حذف کنید یا یک نسخهٔ رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](/cells/java/)) تهیه کنید و به آن لینک دهید.

**آیا چند نمودار می‌توانند به یک کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس خواهد شد.