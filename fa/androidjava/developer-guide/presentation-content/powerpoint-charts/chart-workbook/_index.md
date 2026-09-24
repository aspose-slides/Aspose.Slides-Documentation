---
title: مدیریت کتاب‌های کاری نمودار در ارائه‌ها بر روی اندروید
linktitle: کتاب کاری نمودار
type: docs
weight: 70
url: /fa/androidjava/chart-workbook/
keywords:
- کتاب کار نمودار
- داده نمودار
- سلول کتاب کار
- برچسب داده
- کاربرگ
- منبع داده
- کتاب کار خارجی
- داده خارجی
- کش نمودار
- بازیابی کتاب کار
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "Aspose.Slides برای اندروید با جاوا را کشف کنید: به راحتی کتاب‌های کاری نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با دفترچه‌های کاری نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های دفترچه کاری بخوانید و بنویسید، از سلول‌های دفترچه کاری به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با دفترچه‌های کاری خارجی به عنوان منابع داده برای نمودارها را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک دفترچه کاری خارجی ایجاد و اختصاص دهید، مسیر یک دفترچه کاری خارجی مرتبط با یک نمودار را بازیابی کنید و داده‌های نمودار را زمانی که دفترچه کاری در دسترس است، ویرایش کنید.

برای سلول‌های دفترچه کاری که نمایانگر داده‌های گمشده هستند، مراجعه کنید به [کنترل نمایش سلول‌های خالی](/slides/fa/androidjava/chart-series/) برای تفاوت بین یک سلول خالی و صفر، و مقایسهٔ خطی نمودار برای حالت‌های نمایش موجود.

## **خواندن و نوشتن داده‌های نمودار از دفترچه کاری**
Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) را فراهم می‌کند که به شما امکان می‌دهد دفترچه‌های کاری داده‌های نمودار (شامل داده‌های نمودار ویرایش شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل سازمان‌دهی شوند یا ساختاری مشابه منبع داشته باشند.

این کد جاوا یک عملیات نمونه را نشان می‌دهد:

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

### **تایید طرح‌بندی نمودار پس از اصلاح دفترچه کاری**

زمانی که یک دفترچه کاری جاسازی‌شده را با یک دفترچه اصلاح‌شده جایگزین می‌کنید، نمودار مجموعه‌های سری و دسته‌بندی اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود که [IChart.validateChartLayout](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChart#validateChartLayout--) با خطای out‑of‑range ایندکس شکست بخورد. قبل از نوشتن دفترچه کاری بروزرسانی‌شده به نمودار، مجموعه‌های موجود سری و دسته‌بندی را پاک کنید.

```java
// پس از اصلاح جریان کتاب کار (مثلاً با استفاده از Aspose.Cells)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// پاک‌سازی مراجع داده‌های موجود.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

پاک‌سازی مجموعه‌ها تضمین می‌کند که ساختار دادهٔ نمودار با دفترچه کاری جدید سازگار باشد و `validateChartLayout` بدون خطا تکمیل شود.

## **تنظیم سلول دفترچه کاری به عنوان برچسب داده نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک نمودار حبابی با داده‌هایی اضافه کنید.  
1. به مجموعهٔ سری‌های نمودار دسترسی پیدا کنید.  
1. سلول دفترچه کاری را به عنوان برچسب داده تنظیم کنید.  
1. ارائه را ذخیره کنید.

این کد جاوا نشان می‌دهد چگونه سلول دفترچه کاری را به عنوان برچسب دادهٔ نمودار تنظیم کنید:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// یک کلاس ارائه را که نمایانگر فایل ارائه است ایجاد می‌کند
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

این کد جاوا عملی را نشان می‌دهد که در آن متد [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) برای دسترسی به مجموعهٔ کاربرگ‌ها استفاده می‌شود:

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

این کد جاوا نشان می‌دهد چگونه یک نوع برای منبع داده مشخص کنید:

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

## **تشخیص فرمت‌های غیرقابل پشتیبانی دفترچه کاری جاسازی شده**

Aspose.Slides از فرمت دفترچه کاری باینری Excel (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود پشتیبانی نمی‌کند. می‌توانید از متد `getEmbeddedWorkbookType` در [IChartData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartData) همراه با شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/WorkbookType) برای شناسائی فرمت‌های غیرقابل پشتیبانی و گذراندن آن نمودارها استفاده کنید.

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
            // دفترچه کاری جاسازی‌شده در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue;
        }

        // Read or modify the chart workbook data here.
    }
} finally {
    presentation.dispose();
}
```

## **دفترچه کاری خارجی**

Aspose.Slides از استفاده از دفترچه‌های کاری خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد دفترچه کاری خارجی**

با استفاده از متدهای **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یک دفترچه کاری خارجی را از ابتدا ایجاد کنید یا یک دفترچه کاری داخلی را به خارجی تبدیل کنید.

این کد جاوا فرآیند ایجاد دفترچه کاری خارجی را نشان می‌دهد:

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

### **تنظیم دفترچه کاری خارجی**

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک دفترچه کاری خارجی را به یک نمودار به عنوان منبع دادهٔ آن اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر دفترچه کاری خارجی (اگر جابجا شده باشد) استفاده شود.

اگرچه نمی‌توانید داده‌های دفترچه‌های کاری ذخیره‌شده در مکان‌های دور یا منابع را مستقیماً ویرایش کنید، همچنان می‌توانید از چنین دفترچه‌هایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای یک دفترچه کاری خارجی فراهم شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

این کد جاوا نشان می‌دهد چگونه یک دفترچه کاری خارجی تنظیم کنید:

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

پارامتر `updateChartData` (در زیر متد `setExternalWorkbook`) برای تعیین اینکه آیا یک دفترچه Excel بارگذاری شود یا نه استفاده می‌شود.

* وقتی مقدار `updateChartData` روی `false` تنظیم شود، فقط مسیر دفترچه کاری به‌روزرسانی می‌شود—داده‌های نمودار بارگذاری یا به‌روزرسانی از دفترچه هدف نمی‌شوند. این تنظیم می‌تواند زمانی مفید باشد که دفترچه هدف موجود نباشد یا در دسترس نباشد.  
* وقتی مقدار `updateChartData` روی `true` تنظیم شود، داده‌های نمودار از دفترچه هدف به‌روزرسانی می‌شوند.

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

### **دریافت مسیر دفترچه کاری منبع داده خارجی یک نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.  
1. مرجع یک اسلاید را از طریق ایندکس آن دریافت کنید.  
1. یک شیء برای شکل نمودار ایجاد کنید.  
1. یک شیء برای نوع منبع (`ChartDataSourceType`) که نشان‌دهنده منبع دادهٔ نمودار است، ایجاد کنید.  
1. شرط مربوطه را بر اساس این که نوع منبع همان نوع منبع دادهٔ دفترچه کاری خارجی باشد، مشخص کنید.

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

می‌توانید داده‌های دفترچه‌های کاری خارجی را به همان شیوه‌ای که محتویات دفترچه‌های داخلی را تغییر می‌دهید، ویرایش کنید. وقتی یک دفترچه کاری خارجی قابل بارگذاری نباشد، استثنا پرتاب می‌شود.

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

### **بازیابی دفترچه کاری از کش نمودار**

اگر یک نمودار از دفترچه کاری خارجی که مفقود یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند دفترچه کاری نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/) ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه، متد [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را با مقدار `true` صدا بزنید.

مثال جاوای زیر یک ارائه را که نمودار آن به یک دفترچه کاری خارجی ناموجود ارجاع می‌دهد باز می‌کند و داده‌های بازیابی‌شده را از طریق [IChart.getChartData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌یابد:

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // داده‌های بازیابی‌شدهٔ کتاب کار را اینجا بخوانید یا اصلاح کنید.
} finally {
    presentation.dispose();
}
```

اگر دفترچه کاری خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. بازیابی را فقط زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار به عنوان راه‌حل پشتیبان قابل قبول باشد، زیرا کش ممکن است شامل تغییرات انجام‌شده بر روی دفترچه کاری خارجی پس از آخرین به‌روزرسانی ارائه نشود.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به یک دفترچه کاری خارجی یا جاسازی‌شده مرتبط است؟**  
بله. یک نمودار دارای [type of data source](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) و [path to an external workbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک دفترچه کاری خارجی باشد، می‌توانید مسیر کامل را خوانده و اطمینان حاصل کنید که یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به دفترچه‌های کاری خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی را مشخص کنید، به‌طور خودکار به مسیر مطلق تبدیل می‌شود. این برای انتقال‌پذیری پروژه مناسب است؛ اما باید بدانید که مسیر مطلق در فایل PPTX ذخیره می‌شود.

**آیا می‌توانم از دفترچه‌های کاری موجود در منابع/به‌اشتراک‌گذاری‌های شبکه استفاده کنم؟**  
بله، چنین دفترچه‌هایی می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم دفترچه‌های کاری دور از Aspose.Slides پشتیبانی نمی‌شود—آنها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیره‌سازی ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**  
خیر. ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیره‌سازی ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه باید کرد؟**  
Aspose.Slides هنگام لینک کردن رمز عبور قبول نمی‌کند. رویکرد متداول این است که قبل از لینک کردن حفاظت را حذف کنید یا یک نسخهٔ رمزگشائی‌شده (برای مثال با استفاده از [Aspose.Cells](/cells/androidjava/)) آماده کنید و به آن نسخه لینک کنید.

**آیا چندین نمودار می‌توانند به یک دفترچه کاری خارجی اشاره کنند؟**  
بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار در بارگذاری بعدی داده‌ها منعکس خواهد شد.