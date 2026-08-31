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
- ورک‌شیت
- منبع داده
- کتاب‌کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "Aspose.Slides برای جاوا را کشف کنید: به‌سادگی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهبود بخشید."
---
## **مروری کلی**

این مقاله نحوه کار با کتاب‌کارهای نمودار در Aspose.Slides را توضیح می‌دهد. روش‌های خواندن و نوشتن داده‌های نمودار از طریق جریان‌های کتاب‌کار، استفاده از سلول‌های کتاب‌کار به عنوان برچسب داده‌های نمودار، دسترسی به مجموعه‌های ورک‌شییت و تعیین نوع منبع داده برای مقادیر نمودار را نشان می‌دهد.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داده شود، مسیر کتاب‌کار خارجی مرتبط با یک نمودار بازیابی شود و داده‌های نمودار زمانی که کتاب‌کار در دسترس باشد ویرایش شود.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**
Aspose.Slides روش‌های [ReadWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) را فراهم می‌کند که به شما امکان خواندن و نوشتن کتاب‌کارهای داده نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را می‌دهد. **توجه** داشته باشید که داده‌های نمودار باید به همان صورت سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این کد جاوا نمونه‌ای از این عملیات را نشان می‌دهد:

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

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**

هنگامی که یک کتاب‌کار توکار با یک کتاب‌کار اصلاح‌شده جایگزین می‌شود، نمودار مجموعه‌های سری و دسته‌بندی اصلی خود را حفظ می‌کند. این ناسازگاری می‌تواند باعث شود متد [IChart.validateChartLayout](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#validateChartLayout--) یک `ArgumentOutOfRangeException` (پارامتر: index) را پرتاب کند. برای جلوگیری از این استثنا، پیش از نوشتن کتاب‌کار به‌روزشده به نمودار، سری‌ها و دسته‌ها را **قبل از** نوشتن پاک کنید.

```java
// پس از تغییر جریان کتاب‌کار (مثلاً با استفاده از Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// مراجع داده‌های موجود را پاک کنید.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

پاک‌سازی مجموعه‌ها تضمین می‌کند ساختار داده‌های نمودار با کتاب‌کار جدید هماهنگ باشد و `validateChartLayout` بدون خطا تکمیل شود.

## **تنظیم یک سلول کتاب‌کار به‌عنوان برچسب داده نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.  
1. مرجع اسلاید را از طریق ایندکس آن بدست آورید.  
1. یک نمودار حبابی با داده‌های اولیه اضافه کنید.  
1. به سری‌های نمودار دسترسی پیدا کنید.  
1. سلول کتاب‌کار را به‌عنوان برچسب داده تنظیم کنید.  
1. ارائه را ذخیره کنید.

این کد جاوا نشان می‌دهد چگونه یک سلول کتاب‌کار را به‌عنوان برچسب داده تنظیم کنید:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// یک کلاس ارائه را که نمایانگر یک فایل ارائه است، نمونه می‌سازد
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

## **مدیریت ورک‌شییت‌ها**

این کد جاوا عملیاتی را نشان می‌دهد که در آن متد [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) برای دسترسی به مجموعه ورک‌شییت‌ها استفاده می‌شود:

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

## **تعیین نوع منبع داده**

این کد جاوا نحوه تعیین یک نوع برای منبع داده را نشان می‌دهد:

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

## **تشخیص قالب‌های پشتیبانی‌نشده‌ی کتاب‌کارهای توکار**

Aspose.Slides از قالب کتاب‌کار باینری اکسل (.xlsb) که ممکن است در برخی نمودارها توکار شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد `getEmbeddedWorkbookType` روی [IChartData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData) همراه با enumeration [WorkbookType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/WorkbookType) قالب‌های پشتیبانی‌نشده را شناسایی کرده و آن نمودارها را نادیده بگیرید.

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

{{% alert color="info" %}} 
در [Aspose.Slides 19.4](https://docs.aspose.com/slides/fa/java/aspose-slides-for-java-19-4-release-notes/)، پشتیبانی از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها را پیاده‌سازی کردیم. 
{{% /alert %}} 

### **ایجاد یک کتاب‌کار خارجی**

با استفاده از متدهای **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را از ابتدا بسازید یا یک کتاب‌کار داخلی را به‌صورت خارجی تبدیل کنید.

این کد جاوا فرآیند ایجاد کتاب‌کار خارجی را نشان می‌دهد:

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

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به‌عنوان منبع داده یک نمودار اختصاص دهید. این متد همچنین برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورت جابه‌جایی آن) قابل استفاده است.

اگرچه نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های از راه دور یا منابع را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این کد جاوا نشان می‌دهد چگونه یک کتاب‌کار خارجی تنظیم شود:

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

پارامتر دوم (`boolean`) متد `setExternalWorkbook` برای تعیین اینکه آیا کتاب‌کار اکسل بارگذاری شود یا خیر استفاده می‌شود.

* وقتی مقدار آن `false` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود—داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند. این تنظیم زمانی مفید است که کتاب‌کار هدف موجود نباشد یا در دسترس نباشد.  
* وقتی مقدار آن `true` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

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

### **دریافت مسیر کتاب‌کار منبع داده خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.  
1. مرجع اسلاید را از طریق ایندکس آن بدست آورید.  
1. یک شی برای شکل نمودار ایجاد کنید.  
1. یک شی برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع داده نمودار است، ایجاد کنید.  
1. شرط مربوطه را بر پایهٔ هماهنگی نوع منبع با نوع منبع داده کتاب‌کار خارجی مشخص کنید.

این کد جاوا عملیات را نشان می‌دهد:

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

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همانند کتاب‌کارهای داخلی ویرایش کنید. وقتی کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این کد جاوا پیاده‌سازی فرآیند توصیف‌شده را نشان می‌دهد:

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

### **بازگرداندن کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که فقدان یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شی [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه، متد [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را با مقدار `true` فراخوانی کنید.

مثال زیر در جاوا یک ارائه را باز می‌کند که نمودار آن به کتاب‌کار خارجی در دسترس نیست و داده‌های بازگردانده‌شده را از طریق [IChart.getChartData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌دهد:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا تغییر دهید.
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازگرداندن غیرفعال باشد، Aspose.Slides یک استثنا پرتاب می‌کند. بازگرداندن فقط زمانی فعال شود که استفاده از داده‌های کش‌شده به عنوان یک روش جایگزین قابل قبول باشد، زیرا کش ممکن است تغییراتی که پس از آخرین به‌روزرسانی ارائه در کتاب‌کار خارجی انجام شده‌اند، شامل نشود.

## **پرسش‌های متداول**

**آیا می‌توانم تعیین کنم یک نمودار خاص به کتاب‌کار خارجی یا توکار لینک دارد؟**

بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getDataSourceType--) و یک [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را خوانده و اطمینان حاصل کنید که فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این ویژگی برای قابل‌حمل بودن پروژه مفید است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/به‌اشتراک‌گذاری‌های شبکه‌ای قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای راه‌دور از طریق Aspose.Slides پشتیبانی نمی‌شود—فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

خیر. ارائه فقط یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ذخیره می‌کند و برای خواندن داده از آن استفاده می‌کند. فایل خارجی هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شود چه باید انجام دهم؟**

Aspose.Slides هنگام لینک‌کردن رمز عبور را قبول نمی‌کند. روش معمول این است که پیش از استفاده protection را حذف کنید یا یک نسخهٔ رمزگشایی‌شده تهیه کنید (مثلاً با استفاده از [Aspose.Cells](/cells/java/)) و به آن نسخه لینک کنید.

**آیا می‌توان چندین نمودار را به یک کتاب‌کار خارجی ارجاع داد؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل ارجاع دهند، به‌روزرسانی آن فایل در هر نمودار در بارگذاری بعدی داده‌ها منعکس می‌شود.