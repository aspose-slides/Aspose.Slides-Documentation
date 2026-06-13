---
title: مدیریت دفترکارهای نمودار در ارائه‌ها در Android
linktitle: دفترکار نمودار
type: docs
weight: 70
url: /fa/androidjava/chart-workbook/
keywords:
- دفترکار نمودار
- داده‌های نمودار
- سلول دفترکار
- برچسب داده
- کاربرگ
- منبع داده
- دفترکار خارجی
- داده خارجی
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides برای Android از طریق Java را کشف کنید: به‌راحتی دفترکارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه با دفترکارهای نمودار در Aspose.Slides کار کنیم. این نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های دفترکار بخوانید و بنویسید، از سلول‌های دفترکار به‌عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی پیدا کنید و نوع منبع داده را برای مقادیر نمودار مشخص کنید.

همچنین به کار با دفترکارهای خارجی به‌عنوان منابع داده نمودار می‌پردازد. مثال‌ها نشان می‌دهند چگونه یک دفترکار خارجی ایجاد و تخصیص دهید، مسیر یک دفترکار خارجی مرتبط با نمودار را بازیابی کنید، و داده‌های نمودار را هنگامی که دفترکار موجود است ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک دفترکار**

Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) را ارائه می‌دهد که به شما امکان می‌دهد دفترکارهای داده‌های نمودار (حاوی داده‌های نمودار ویرایش شده با Aspose.Cells) بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

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

## **تنظیم یک سلول WorkBook به‌عنوان برچسب داده نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. یک نمودار حبابی با برخی داده‌ها اضافه کنید.
1. به سری‌های نمودار دسترسی پیدا کنید.
1. سلول دفترکار را به‌عنوان برچسب داده تنظیم کنید.
1. پرزنتیشن را ذخیره کنید.

این کد Java به شما نشان می‌دهد چگونه یک سلول دفترکار را به‌عنوان برچسب داده نمودار تنظیم کنید:
```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// یک نمونه از کلاس Presentation که یک فایل ارائه را نمایندگی می‌کند
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

## **مدیریت کاربرگ‌ها**

این کد Java یک عملیاتی را نشان می‌دهد که در آن متد [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) برای دسترسی به مجموعه‌ای از کاربرگ‌ها استفاده می‌شود:
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

این کد Java به شما نشان می‌دهد چگونه نوعی برای منبع داده مشخص کنید:
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

## **تشخیص قالب‌های دفترکار توکار پشتیبانی نشده**

Aspose.Slides قالب دفترکار باینری اکسل (.xlsb) را که می‌تواند در برخی نمودارها توکار شود، پشتیبانی نمی‌کند. می‌توانید از متد `getEmbeddedWorkbookType` روی [IChartData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartData) همراه با شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/WorkbookType) برای تشخیص قالب‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را نادیده بگیرید.
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
            // دفترکار توکار در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue;
        }

        // در اینجا داده‌های دفترکار نمودار را بخوانید یا اصلاح کنید.
    }
} finally {
    presentation.dispose();
}
```

## **دفترکار خارجی**

Aspose.Slides دفترکارهای خارجی را به‌عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک دفترکار خارجی**

با استفاده از متدهای **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یک دفترکار خارجی را از صفر ایجاد کنید یا یک دفترکار داخلی را به‌صورت خارجی تبدیل کنید.

این کد Java فرآیند ایجاد دفترکار خارجی را نشان می‌دهد:
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

### **تنظیم یک دفترکار خارجی**

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک دفترکار خارجی را به‌عنوان منبع داده یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر دفترکار خارجی استفاده شود (اگر دفترکار دوم جابه‌جا شده باشد).

اگرچه نمی‌توانید داده‌های دفترکارهای ذخیره‌شده در مکان‌ها یا منابع دوردست را ویرایش کنید، همچنان می‌توانید از چنین دفترکارهایی به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای یک دفترکار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این کد Java به شما نشان می‌دهد چگونه یک دفترکار خارجی تنظیم کنید:
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

پارامتر `ChartData` (در زیر متد `setExternalWorkbook`) برای مشخص کردن اینکه آیا یک دفترکار اکسل بارگذاری می‌شود یا خیر، استفاده می‌شود.

* وقتی مقدار `ChartData` بر روی `false` تنظیم شود، تنها مسیر دفترکار به‌روز می‌شود—داده‌های نمودار از دفترکار هدف بارگذاری یا به‌روز نمی‌شوند. ممکن است بخواهید از این تنظیم زمانی استفاده کنید که دفترکار هدف وجود نداشته باشد یا در دسترس نباشد. 
* وقتی مقدار `ChartData` بر روی `true` تنظیم شود، داده‌های نمودار از دفترکار هدف به‌روز می‌شوند.

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

### **دریافت مسیر دفترکار منبع داده خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.
1. یک شی برای شکل نمودار ایجاد کنید.
1. یک شی برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع دادهٔ نمودار است، ایجاد کنید.
1. شرط مرتبط را بر اساس اینکه نوع منبع همان نوع منبع دادهٔ دفترکار خارجی باشد، مشخص کنید.

این کد Java عمل را نشان می‌دهد:
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

می‌توانید داده‌های دفترکارهای خارجی را همان‌طور که محتویات دفترکارهای داخلی را ویرایش می‌کنید، ویرایش کنید. هنگامی که یک دفترکار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این کد Java پیاده‌سازی فرآیند توصیف‌شده است:
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

## **سؤالات متداول**

**آیا می‌توانم تعیین کنم که آیا یک نمودار خاص به یک دفترکار خارجی یا توکار متصل است؟**

بله. یک نمودار دارای یک [نوع منبع داده](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) و یک [مسیر به دفترکار خارجی](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک دفترکار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید که از یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به دفترکارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای جابجایی پروژه مناسب است؛ اما توجه داشته باشید که پرزنتیشن مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از دفترکارهای واقع در منابع/اشتراک‌های شبکه استفاده کنم؟**

بله، اینگونه دفترکارها می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. با این حال، ویرایش مستقیم دفترکارهای دوردست از طریق Aspose.Slides پشتیبانی نمی‌شود—آنها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره‌سازی پرزنتیشن، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. پرزنتیشن یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ذخیره می‌کند و از آن برای خواندن داده‌ها استفاده می‌کند. خود فایل خارجی هنگام ذخیره‌سازی پرزنتیشن تغییر نمی‌کند.

**در صورتی که فایل خارجی دارای پسورد باشد، چه کار کنم؟**

Aspose.Slides هنگام لینک کردن پسوردی قبول نمی‌کند. یک روش معمول این است که قبل از آن حفاظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده تهیه کنید (به عنوان مثال با استفاده از [Aspose.Cells](/cells/androidjava/)) و به آن نسخه لینک دهید.

**آیا چندین نمودار می‌توانند به یک دفترکار خارجی ارجاع دهند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همگی به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در هر نمودار منعکس می‌شود.