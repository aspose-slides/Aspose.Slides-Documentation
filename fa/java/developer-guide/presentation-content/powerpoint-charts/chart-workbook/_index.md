---
title: مدیریت کاربرگ‌های نمودار در ارائه‌ها با استفاده از Java
linktitle: کاربرگ نمودار
type: docs
weight: 70
url: /fa/java/chart-workbook/
keywords:
- کاربرگ نمودار
- داده‌های نمودار
- سلول کاربرگ
- برچسب داده
- برگ کار
- منبع داده
- کاربرگ خارجی
- داده خارجی
- کش نمودار
- بازیابی کاربرگ
- پاورپوینت
- ارائه
- Java
- Aspose.Slides
description: "Aspose.Slides برای Java را کشف کنید: به‌راحتی کاربرگ‌های نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با کاربرگ‌های نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کاربرگ بخوانید و بنویسید، از سلول‌های کاربرگ به عنوان برچسب داده‌های نمودار استفاده کنید، به مجموعه‌های برگ‌کار دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کاربرگ‌های خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. نمونه‌ها نشان می‌دهند چگونه یک کاربرگ خارجی ایجاد و اختصاص دهید، مسیر کاربرگ خارجی مرتبط با یک نمودار را بازیابی کنید و هنگام در دسترس بودن کاربرگ، داده‌های نمودار را ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از کاربرگ**
Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) را ارائه می‌دهد که به شما امکان می‌دهند کاربرگ‌های داده‌های نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازماندهی شده باشند یا ساختاری مشابه منبع داشته باشند.

این کد Java یک عملیات نمونه را نشان می‌دهد:

```java
import com.aspose.slides.*;

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

### **اعتبارسنجی چیدمان نمودار پس از تغییر کاربرگ**

هنگامی که یک کاربرگ توکار را با یک کاربرگ تغییر یافته جایگزین می‌کنید، نمودار مجموعه‌های سری و دسته‌بندی اصلی خود را حفظ می‌کند. این ناسازگاری می‌تواند باعث شود `chart.validateChartLayout()` یک `ArgumentOutOfRangeException` (پارامتر: index) پرتاب کند. برای جلوگیری از این استثناء، سری‌ها و دسته‌بندی‌های موجود را **قبل از** نوشتن کاربرگ به‌روز شده به نمودار پاک کنید.

```java
// بعد از تغییر جریان کاربرگ (مثلاً با استفاده از Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// مرجع‌های داده موجود را پاک کنید.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// کاربرگ به‌روز شده را دوباره به نمودار بنویسید.
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// اکنون اعتبارسنجی موفق است.
chart.validateChartLayout();
```

پاک‌سازی مجموعه‌ها اطمینان می‌دهد که ساختار داده‌های نمودار با کاربرگ جدید هم‌راستا باشد و `validateChartLayout()` بدون خطا اجرا شود.

## **تنظیم یک سلول کاربرگ به عنوان برچسب داده‌های نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع یک اسلاید را از طریق شاخص آن دریافت کنید.
1. یک نمودار حبابی با برخی داده‌ها اضافه کنید.
1. به سری‌های نمودار دسترسی پیدا کنید.
1. سلول کاربرگ را به عنوان برچسب داده تنظیم کنید.
1. ارائه را ذخیره کنید.

این کد Java نشان می‌دهد چگونه یک سلول کاربرگ را به عنوان برچسب داده تنظیم کنید:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// یک نمونه از کلاس Presentation که یک فایل ارائه را نشان می‌دهد، ایجاد می‌کند
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

## **مدیریت برگ‌های کار**

این کد Java عملی را نشان می‌دهد که در آن متد [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) برای دسترسی به مجموعه برگ‌ها استفاده می‌شود:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

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

## **تشخیص فرمت‌های کاربرگ توکار پشتیبانی‌نشده**

Aspose.Slides از فرمت کاربرگ باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها توکار باشد پشتیبانی نمی‌کند. می‌توانید با استفاده از متد `getEmbeddedWorkbookType` در [IChartData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData) همراه با شمارش [WorkbookType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/WorkbookType) فرمت‌های پشتیبانی‌نشده را شناسایی کرده و آن نمودارها را نادیده بگیرید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // کاربرگ توکار در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue;
        }

        // در اینجا داده‌های کاربرگ نمودار را بخوانید یا ویرایش کنید.
    }
} finally {
    presentation.dispose();
}
```

## **کاربرگ خارجی**

{{% alert color="info" %}} 
در [Aspose.Slides 19.4](https://docs.aspose.com/slides/fa/java/aspose-slides-for-java-19-4-release-notes/)، ما پشتیبانی از کاربرگ‌های خارجی را به عنوان منبع داده برای نمودارها پیاده‌سازی کرده‌ایم.
{{% /alert %}} 

### **ایجاد یک کاربرگ خارجی**

با استفاده از متدهای **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یک کاربرگ خارجی را از نو ایجاد کنید یا یک کاربرگ داخلی را به حالت خارجی درآورید.

این کد Java فرآیند ایجاد کاربرگ خارجی را نشان می‌دهد:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

### **تنظیم یک کاربرگ خارجی**

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک کاربرگ خارجی را به عنوان منبع داده یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کاربرگ خارجی (در صورت جابه‌جا شدن) استفاده شود.

اگرچه نمی‌توانید داده‌ها را در کاربرگ‌های ذخیره‌شده در مکان‌های راه دور یا منبع‌ها مستقیماً ویرایش کنید، همچنان می‌توانید از چنین کاربرگ‌هایی به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای کاربرگ خارجی فراهم شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این کد Java نشان می‌دهد چگونه یک کاربرگ خارجی تنظیم کنید:

```java
import com.aspose.slides.*;

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

پارامتر دوم (`boolean`) متد `setExternalWorkbook` برای مشخص کردن اینکه آیا یک کاربرگ اکسل بارگذاری شود یا نه استفاده می‌شود.

* زمانی که مقدار آن به `false` تنظیم شود، فقط مسیر کاربرگ به‌روز می‌شود—داده‌های نمودار بارگذاری یا به‌روز نمی‌شوند. این تنظیم می‌تواند زمانی مفید باشد که کاربرگ هدف وجود نداشته باشد یا در دسترس نباشد.
* زمانی که مقدار آن به `true` تنظیم شود، داده‌های نمودار از کاربرگ هدف به‌روز می‌شوند.

```java
import com.aspose.slides.*;

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

### **دریافت مسیر کاربرگ منبع داده خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. مرجع اسلاید را از طریق شاخص آن بگیرید.
1. یک شی برای شکل نمودار ایجاد کنید.
1. یک شی برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع داده نمودار است، ایجاد کنید.
1. شرط مربوطه را بر اساس این که نوع منبع همان نوع منبع داده کاربرگ خارجی باشد، مشخص کنید.

این کد Java عملیات را نشان می‌دهد:

```java
import com.aspose.slides.*;

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

می‌توانید داده‌های کاربرگ‌های خارجی را همانند کاربرگ‌های داخلی ویرایش کنید. وقتی یک کاربرگ خارجی بارگذاری نشود، استثنایی پرتاب می‌شود.

این کد Java پیاده‌سازی فرآیند توصیف‌شده را نشان می‌دهد:

```java
import com.aspose.slides.*;

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

### **بازیابی کاربرگ از کش نمودار**

اگر یک نمودار از یک کاربرگ خارجی که گمشده یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند کاربرگ نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه متد [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را با مقدار `true` فراخوانی کنید.

مثال Java زیر یک ارائه را که نمودار آن به یک کاربرگ خارجی در دسترس نیست اشاره دارد باز می‌کند و داده‌های بازیابی‌شده را از طریق [IChart.getChartData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌یابد:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // داده‌های کاربرگ بازیابی‌شده را در اینجا بخوانید یا ویرایش کنید.
} finally {
    presentation.dispose();
}
```

اگر کاربرگ خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. تنها زمانی که استفاده از داده‌های کش‌شده نمودار یک گزینه قابل قبول است، بازیابی را فعال کنید، زیرا کش ممکن است تغییراتی که پس از آخرین به‌روزرسانی ارائه در کاربرگ خارجی انجام شده‌اند، شامل نشود.

## **سؤالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به یک کاربرگ خارجی یا توکار لینک دارد؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getDataSourceType--) و یک [مسیر به کاربرگ خارجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کاربرگ خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کاربرگ‌های خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این برای قابلیت حمل پروژه مفید است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کاربرگ‌هایی که در منابع/به‌اشتراک‌گذاری‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کاربرگ‌هایی می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. اما ویرایش مستقیم کاربرگ‌های راه دور از Aspose.Slides پشتیبانی نمی‌شود—فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شده باشد، چه کاری باید انجام دهم؟**

Aspose.Slides هنگام لینک‌دادن رمز عبور را نمی‌پذیرد. یک رویکرد معمول این است که پیش از آن حفاظت را بردارید یا یک کپی رمزگشایی‌شده آماده کنید (مثلاً با استفاده از [Aspose.Cells](/cells/java/)) و به آن نسخه لینک دهید.

**آیا می‌توان چندین نمودار را به یک کاربرگ خارجی ارجاع داد؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل ارجاع دهند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس می‌شود.