---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها بر روی اندروید
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/androidjava/chart-workbook/
keywords:
- کتاب‌کار نمودار
- داده‌های نمودار
- سلول کتاب‌کار
- برچسب داده
- ورق‌کار
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "Aspose.Slides برای Android را از طریق Java کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های ورق کاری دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده برای نمودارها را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی پیوست‌شده به یک نمودار را بازیابی کنید و داده‌های نمودار را زمانی که کتاب‌کار در دسترس باشد ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) را فراهم می‌کند که به شما امکان می‌دهد داده‌های کتاب‌کار نمودار (متشکل از داده‌های نمودار ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این کد جاوا یک عملیات نمونه را نشان می‌دهد:

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

## **تنظیم یک سلول WorkBook به عنوان برچسب داده نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) خلق کنید.
1. یک ارجاع به اسلاید را از طریق شاخص آن دریافت کنید.
1. یک نمودار حبابی با برخی داده‌ها اضافه کنید.
1. به سری‌های نمودار دسترسی پیدا کنید.
1. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.
1. ارائه را ذخیره کنید.

این کد جاوا به شما نشان می‌دهد چگونه یک سلول کتاب‌کار را به عنوان برچسب داده نمودار تنظیم کنید:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// یک کلاس ارائه را که نمایانگر یک فایل ارائه است، نمونه‌سازی می‌کند
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

این کد جاوا یک عملیات را نشان می‌دهد که در آن متد [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) برای دسترسی به مجموعه ورق کاری استفاده می‌شود:

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

## **مشخص‌کردن نوع منبع داده**

این کد جاوا به شما نشان می‌دهد چگونه یک نوع برای منبع داده مشخص کنید:

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

## **تشخیص فرمت‌های کتاب‌کار توکار غیرقابل پشتیبانی**

Aspose.Slides از قالب کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها توکار باشد پشتیبانی نمی‌کند. می‌توانید از متد `getEmbeddedWorkbookType` در [IChartData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartData) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/WorkbookType) استفاده کنید تا قالب‌های پشتیبانی‌نشده را شناسایی کرده و آن نمودارها را نادیده بگیرید.

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
            // کتاب‌کار توکار در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue;
        }

        // در اینجا می‌توانید داده‌های کتاب‌کار نمودار را بخوانید یا اصلاح کنید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

با استفاده از متدهای **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یا یک کتاب‌کار خارجی را از صفر ایجاد کنید یا یک کتاب‌کار داخلی را به‌صورت خارجی درآورید.

این کد جاوا فرآیند ایجاد کتاب‌کار خارجی را نشان می‌دهد:

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

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به یک نمودار به‌عنوان منبع داده آن اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورتی که جابجا شده باشد) استفاده شود.

در حالی که نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های دور یا منابع را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این کد جاوا به شما نشان می‌دهد چگونه یک کتاب‌کار خارجی تنظیم کنید:

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

پارامتر `ChartData` (در زیر متد `setExternalWorkbook`) برای مشخص کردن این‌که آیا یک کتاب‌کار اکسل بارگذاری شود یا نه استفاده می‌شود.

* وقتی مقدار `ChartData` روی `false` تنظیم شود، تنها مسیر کتاب‌کار به‌روزرسانی می‌شود—داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روز نمی‌شوند. می‌توانید از این تنظیم زمانی استفاده کنید که کتاب‌کار هدف غیرقابل دسترس یا وجود نداشته باشد.
* وقتی مقدار `ChartData` روی `true` تنظیم شود، داده‌های نمودار از کتاب‌کار هدف به‌روز می‌شوند.

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

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) بسازید.
1. یک ارجاع به اسلاید را از طریق شاخص آن دریافت کنید.
1. یک شیء برای شکل نمودار ایجاد کنید.
1. یک شیء برای نوع منبع (`ChartDataSourceType`) که نشان‌دهنده منبع داده‌ی نمودار است ایجاد کنید.
1. شرط مربوطه را بر اساس اینکه نوع منبع همان نوع منبع داده کتاب‌کار خارجی باشد، مشخص کنید.

این کد جاوا عملیات را نشان می‌دهد:

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
	
	// ارائه را ذخیره می‌کند
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همان‌طور که محتویات کتاب‌کارهای داخلی را تغییر می‌دهید، ویرایش کنید. وقتی یک کتاب‌کار خارجی بارگذاری نشود، استثنایی پرتاب می‌شود.

این کد جاوا پیاده‌سازی فرآیند توصیف‌شده است:

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

### **بازیابی کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی استفاده کند که موجود نباشد یا در دسترس نباشد، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/) ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه متد [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را با مقدار `true` فراخوانی کنید.

مثال زیر در جاوا ارائه‌ای را که نمودار آن به کتاب‌کار خارجی در دسترس نیست ارجاع می‌دهد باز می‌کند و داده‌های بازیابی‌شده را از طریق [IChart.getChartData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌یابد:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // در اینجا می‌توانید داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا اصلاح کنید.
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. تنها زمانی که استفاده از داده‌های کش‌شده نمودار قابل قبول باشد، بازیابی را فعال کنید، زیرا کش ممکن است شامل تغییرات انجام‌شده بر کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **FAQ**

**آیا می‌توانم تعیین کنم که آیا یک نمودار خاص به یک کتاب‌کار خارجی یا توکار لینک شده است؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) و یک [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای جابجایی پروژه مناسب است؛ اما باید آگاه باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهای قرار گرفته در منابع/به‌اشتراک‌گذاری‌های شبکه استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دور از Aspose.Slides پشتیبانی نمی‌شود—فقط می‌توان از آن‌ها به‌عنوان منبع استفاده کرد.

**آیا Aspose.Slides هنگام ذخیره‌سازی ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی خود هنگام ذخیره‌سازی ارائه تغییر نمی‌کند.

**در صورتی که فایل خارجی با رمز محافظت شده باشد، چه کاری باید انجام دهم؟**

Aspose.Slides هنگام لینک کردن رمز عبور را نمی‌پذیرد. رویکرد معمول حذف محافظت پیش از لینک کردن یا تهیه یک نسخهٔ رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](/cells/androidjava/)) و لینک به آن نسخه است.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی اشاره کنند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به همان فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار منعکس می‌شود.