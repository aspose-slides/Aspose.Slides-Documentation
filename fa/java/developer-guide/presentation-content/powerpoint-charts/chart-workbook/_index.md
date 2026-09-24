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
- داده خارجی
- کش نمودار
- بازیابی کتاب‌کار
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "Aspose.Slides برای جاوا را کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنیم. این مقاله نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار خوانده و نوشت، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کرد، به مجموعه‌های شیت‌ها دسترسی داشت و نوع منبع داده برای مقادیر نمودار را مشخص کرد.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص داد، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کرد و داده‌های نمودار را هنگامی که کتاب‌کار در دسترس است، ویرایش کرد.

برای سلول‌های کتاب‌کاری که نمایانگر داده‌های گمشده هستند، به [Control the Display of Empty Cells](/slides/fa/java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر و مقایسه نمایش خطی حالت‌های نمایش موجود را ببینید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**
Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌کارهای داده نمودار (شامل داده‌های نمودار ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **Note** این داده‌ها باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

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

زمانی که یک کتاب‌کار تعبیه‌شده را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار سری‌ها و مجموعه‌های دسته‌بندی اصلی خود را حفظ می‌کند. این ناسازگاری می‌تواند باعث شود متد [IChart.validateChartLayout](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#validateChartLayout--) یک `ArgumentOutOfRangeException` (پارامتر: index) پرتاب کند. برای جلوگیری از این استثنا، قبل از نوشتن کتاب‌کار به‌روزرسانی‌شده به نمودار، سری‌ها و دسته‌بندی‌های موجود را **قبل از** نوشتن پاک کنید.

```java
// پس از اصلاح جریان کتاب‌کار (مثلاً با استفاده از Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// پاک‌سازی ارجاعات داده‌های موجود.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

پاک‌سازی مجموعه‌ها اطمینان می‌دهد که ساختار داده‌های نمودار با کتاب‌کار جدید هم‌راستا می‌شود و `validateChartLayout` بدون خطا کامل می‌شود.

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب داده نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.  
2. مرجع اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک نمودار حبابی (Bubble) با برخی داده‌ها اضافه کنید.  
4. به سری‌های نمودار دسترسی پیدا کنید.  
5. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.  
6. ارائه را ذخیره کنید.

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// یک نمونه از کلاس ارائه که یک فایل ارائه را نمایندگی می‌کند
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

## **مدیریت شیت‌ها**

این کد Java یک عملیاتی را نشان می‌دهد که در آن متد [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) برای دسترسی به مجموعه شیت‌ها استفاده می‌شود:

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

## **تشخیص فرمت‌های پشتیبانی‌نشده کتاب‌کارهای تعبیه‌شده**

Aspose.Slides از فرمت کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها تعبیه شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد `getEmbeddedWorkbookType` روی [IChartData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IChartData) همراه با شمارنده [WorkbookType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/WorkbookType) فرمت‌های پشتیبانی‌نشده را تشخیص داده و آن نمودارها را نادیده بگیرید.

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
            // کتاب‌کار تعبیه‌شده در قالب .xlsb است که پشتیبانی نمی‌شود.
            continue;
        }

        // در اینجا می‌توانید داده‌های کتاب‌کار نمودار را بخوانید یا اصلاح کنید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

با استفاده از متدهای **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را از ابتدا ایجاد کنید یا یک کتاب‌کار داخلی را به حالت خارجی درآورید.

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

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به عنوان منبع داده به یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورتی که منتقل شده باشد) استفاده شود.

در حالی که نمی‌توانید داده‌های کتاب‌کارهای ذخیره‌شده در مکان‌های راه دور یا منابع را ویرایش کنید، همچنان می‌توانید از این کتاب‌کارها به عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی ارائه شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

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

پارامتر دوم (`boolean`) متد `setExternalWorkbook` برای تعیین این‌که آیا کتاب‌کار Excel بارگذاری شود یا نه، استفاده می‌شود.

* وقتی مقدار آن به `false` تنظیم شود، تنها مسیر کتاب‌کار به‌روزرسانی می‌شود—داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند. این تنظیم را می‌توانید زمانی استفاده کنید که کتاب‌کار هدف وجود نداشته باشد یا در دسترس نباشد.  
* وقتی مقدار آن به `true` تنظیم شود، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

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
2. مرجع اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک شیء برای شکل نمودار ایجاد کنید.  
4. یک شیء برای نوع منبع (`ChartDataSourceType`) که نمایانگر منبع داده نمودار است، ایجاد کنید.  
5. شرط مرتبط را بر اساس این‌که نوع منبع همان نوع منبع داده کتاب‌کار خارجی باشد، مشخص کنید.

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

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همانند ویرایش کتاب‌کارهای داخلی تغییر دهید. هنگامی که یک کتاب‌کار خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

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

### **بازیابی کتاب‌کار از حافظه کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که گم شده یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه، متد [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را با مقدار `true` فراخوانی کنید.

مثال زیر یک ارائه را باز می‌کند که نمودار آن به یک کتاب‌کار خارجی در دسترس نیست ارجاع می‌دهد و داده‌های بازیابی‌شده را از طریق [IChart.getChartData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌یابد:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // خواندن یا اصلاح داده‌های کتاب‌کار بازیابی‌شده در اینجا.
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides یک استثنا پرتاب می‌کند. بازیابی را تنها وقتی فعال کنید که استفاده از داده‌های کش‌شده نمودار یک گزینه قابل قبول باشد، زیرا کش ممکن است تغییراتی که پس از آخرین به‌روزرسانی ارائه در کتاب‌کار خارجی اعمال شده‌اند را شامل نشود.

## **سوالات متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به یک کتاب‌کار خارجی یا تعبیه‌شده لینک دارد؟**  
بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getDataSourceType--) و [مسیر به کتاب‌کار خارجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را خوانده و تأیید کنید که فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی را مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. این کار برای قابلیت حمل پروژه مفید است؛ اما توجه داشته باشید که مسیر مطلق در فایل PPTX ذخیره می‌شود.

**آیا می‌توانم از کتاب‌کارهای موجود در منابع/به‌اشتراک‌گذاری‌های شبکه استفاده کنم؟**  
بله، می‌توان از چنین کتاب‌کارهایی به عنوان منبع داده خارجی استفاده کرد. با این حال، ویرایش مستقیم کتاب‌کارهای راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود؛ آنها فقط به عنوان منبع قابل استفاده هستند.

**آیا Aspose.Slides هنگام ذخیره‌سازی ارائه فایل XLSX خارجی را بازنویسی می‌کند؟**  
خیر. ارائه تنها یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیره ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شده باشد، چه کاری باید انجام دهم؟**  
Aspose.Slides هنگام لینک‌دادن رمز عبور را قبول نمی‌کند. راه معمول این است که پیش از لینک‌دادن حفاظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده تهیه کنید (مثلاً با استفاده از [Aspose.Cells](/cells/java/)) و به آن نسخه لینک دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی اشاره کنند؟**  
بله. هر نمودار لینک خودش را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در بارگذاری بعدی داده‌ها در هر نمودار بازتاب خواهد یافت.