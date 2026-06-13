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
- "ورق‌کاری"
- "منبع داده"
- "کتاب‌کار خارجی"
- "داده خارجی"
- "PowerPoint"
- "ارائه"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides برای جاوا را کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار خوانده و نوشته، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های ورق‌کاری دسترسی داشته باشید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده برای نمودارها را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را دریافت کنید و داده‌های نمودار را وقتی کتاب‌کار در دسترس باشد ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**
Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) را فراهم می‌کند که به شما امکان خواندن و نوشتن کتاب‌کارهای داده نمودار (حاوی داده‌های نمودار ویرایش‌شده با Aspose.Cells) را می‌دهد. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

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

## **تنظیم یک سلول کتاب‌کار به‌عنوان برچسب داده نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک نمودار حبابی با مقداری داده اضافه کنید.  
4. به سری‌های نمودار دسترسی پیدا کنید.  
5. سلول کتاب‌کار را به‌عنوان برچسب داده تنظیم کنید.  
6. ارائه را ذخیره کنید.

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل ارائه است
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

این کد جاوا عملی را نشان می‌دهد که در آن متد [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) برای دسترسی به یک مجموعه ورق‌کاری استفاده می‌شود:

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

این کد جاوا نشان می‌دهد چگونه یک نوع برای منبع داده مشخص کنید:

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

## **شناسایی فرمت‌های کتاب‌کار توکار پشتیبانی‌نشده**

Aspose.Slides از فرمت کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها توکار شود، پشتیبانی نمی‌کند. می‌توانید از متد `getEmbeddedWorkbookType` روی [IChartData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData) همراه با enumeration [WorkbookType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/WorkbookType) برای شناسایی فرمت‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را نادیده بگیرید.

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

        // در اینجا داده‌های کتاب‌کار نمودار را بخوانید یا تغییر دهید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

{{% alert color="primary" %}} در [Aspose.Slides 19.4](https://docs.aspose.com/slides/fa/java/aspose-slides-for-java-19-4-release-notes/)، پشتیبانی از کتاب‌کارهای خارجی به‌عنوان منبع داده برای نمودارها را پیاده‌سازی کردیم. {{% /alert %}}

### **ایجاد یک کتاب‌کار خارجی**

با استفاده از متدهای **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را از ابتدا ایجاد کنید یا یک کتاب‌کار داخلی را به‌صورت خارجی تبدیل کنید.

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

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به‌عنوان منبع داده برای یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورت جابجا شدن آن) استفاده شود.

در حالی که نمی‌توانید داده‌ها را در کتاب‌کارهای ذخیره‌شده در مکان‌های راه دور یا منابع ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

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

پارامتر `ChartData` (در زیر متد `setExternalWorkbook`) برای تعیین این‌که آیا یک کتاب‌کار Excel بارگذاری شود یا خیر استفاده می‌شود.

* وقتی مقدار `ChartData` روی `false` تنظیم شود، تنها مسیر کتاب‌کار به‌روزرسانی می‌شود — داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند. می‌توانید از این تنظیم زمانی استفاده کنید که کتاب‌کار هدف وجود نداشته باشد یا در دسترس نباشد.  
* وقتی مقدار `ChartData` روی `true` تنظیم شود، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

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
2. مرجع اسلاید را از طریق شاخص آن دریافت کنید.  
3. یک شی برای شکل نمودار ایجاد کنید.  
4. یک شی برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع داده نمودار است، ایجاد کنید.  
5. شرط مربوطه را بر اساس این‌که نوع منبع همان نوع منبع داده کتاب‌کار خارجی باشد، مشخص کنید.

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

می‌توانید داده‌ها را در کتاب‌کارهای خارجی همان‌طور که در کتاب‌کارهای داخلی تغییر می‌دهید، ویرایش کنید. وقتی کتاب‌کار خارجی قابل بارگذاری نباشد، استثنا ایجاد می‌شود.

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

**آیا می‌توانم تعیین کنم که آیا یک نمودار خاص به کتاب‌کار خارجی یا توکار لینک دارد؟**  
بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getDataSourceType--) و [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید که فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی را مشخص کنید، به‌طور خودکار به مسیر مطلق تبدیل می‌شود. این امر برای قابل حمل بودن پروژه مفید است؛ البته توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهایی که روی منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**  
بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای راه دور از Aspose.Slides پشتیبانی نمی‌شود — آنها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**  
نه. ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیره ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شود، چه باید بکنم؟**  
Aspose.Slides هنگام لینک کردن رمز عبور نمی‌گیرد. رویکرد معمول این است که پیش از آن محافظت را حذف کنید یا یک نسخه رمزگشایی‌شده تهیه کنید (به‌عنوان مثال با استفاده از [Aspose.Cells](/cells/java/)) و به آن نسخه لینک کنید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی یکسان ارجاع دهند؟**  
بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در بارگذاری بعدی داده‌ها در هر نمودار منعکس می‌شود.