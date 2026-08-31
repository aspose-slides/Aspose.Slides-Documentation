---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها برای Android
linktitle: کتاب‌کار نمودار
type: docs
weight: 70
url: /fa/androidjava/chart-workbook/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides برای Android را از طریق Java کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **مروری کلی**

این مقاله توضیح می‌دهد چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنیم. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های برگه‌های کاری دسترسی پیدا کنید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. نمونه‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کنید و داده‌های نمودار را هنگامی که کتاب‌کار در دسترس باشد، ویرایش کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides متدهای [ReadWorkbookStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) و [WriteWorkbookStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) را فراهم می‌کند که به شما امکان خواندن و نوشتن کتاب‌کارهای داده نمودار (حاوی داده‌های نموداری که با Aspose.Cells ویرایش شده‌اند) را می‌دهد. **توجه** داشته باشید که داده‌های نمودار باید به همان شیوه سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

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

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**

زمانی که یک کتاب‌کار جاسازی‌شده را با یک کتاب‌کار تغییر یافته جایگزین می‌کنید، نمودار مجموعه‌های سری و دسته‌بندی اولیه خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود متد [IChart.validateChartLayout](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChart#validateChartLayout--) با خطای out-of-range ایندکس شکست بخورد. قبل از نوشتن کتاب‌کار به‌روزرسانی‌شده به نمودار، سری‌ها و دسته‌بندی‌های موجود را پاک کنید.

```java
// پس از تغییر جریان کتاب‌کار (مثلاً با استفاده از Aspose.Cells)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// پاک‌سازی مراجع داده‌های موجود.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

پاک‌سازی مجموعه‌ها اطمینان می‌دهد که ساختار داده‌های نمودار با کتاب‌کار جدید سازگار باشد و باعث می‌شود `validateChartLayout` بدون خطا تکمیل شود.

## **تنظیم سلول کتاب‌کار به عنوان برچسب داده نمودار**

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) را ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک نمودار حبابی با برخی داده‌ها اضافه کنید.  
4. به سری‌های نمودار دسترسی پیدا کنید.  
5. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.  
6. ارائه را ذخیره کنید.

این کد جاوا نشان می‌دهد چگونه سلول کتاب‌کار را به عنوان برچسب داده نمودار تنظیم کنید:

```java
// یک کلاس ارائه ایجاد می‌کند که نمایانگر یک فایل ارائه است
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Instantiates a presentation class that represents a presentation file
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

## **مدیریت برگه‌های کاری**

این کد جاوا یک عملیاتی را نشان می‌دهد که در آن متد [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) برای دسترسی به مجموعه برگه‌های کاری استفاده می‌شود:

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

## **تشخیص فرمت‌های پشتیبانی‌نشده کتاب‌کارهای جاسازی‌شده**

Aspose.Slides از فرمت کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید از متد `getEmbeddedWorkbookType` روی [IChartData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IChartData) همراه با شمارشگر [WorkbookType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/WorkbookType) برای تشخیص فرمت‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را نادیده بگیرید.

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
            // کتاب‌کار جاسازی‌شده در فرمت .xlsb است که پشتیبانی نمی‌شود.
            continue;
        }

        // داده‌های کتاب‌کار نمودار را اینجا بخوانید یا اصلاح کنید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد کتاب‌کار خارجی**

با استفاده از متدهای **`readWorkbookStream`** و **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را از صفر ایجاد کنید یا یک کتاب‌کار داخلی را به خارجی تبدیل کنید.

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

### **تنظیم کتاب‌کار خارجی**

با استفاده از متد **`setExternalWorkbook`** می‌توانید یک کتاب‌کار خارجی را به یک نمودار به عنوان منبع دادهٔ آن اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورتی که جابه‌جا شده باشد) استفاده شود.

در حالی که نمی‌توانید داده‌های کتاب‌کارهایی که در مکان‌های دور یا منابع ذخیره شده‌اند را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌طور خودکار به مسیر کامل تبدیل می‌شود.

این کد جاوا نشان می‌دهد چگونه کتاب‌کار خارجی را تنظیم کنید:

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

پارامتر `updateChartData` (در زیر متد `setExternalWorkbook`) برای تعیین اینکه آیا کتاب‌کار Excel بارگذاری شود یا نه استفاده می‌شود.

* وقتی مقدار `updateChartData` روی `false` تنظیم شود، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود—داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند. می‌توانید از این تنظیم زمانی استفاده کنید که کتاب‌کار هدف وجود نداشته باشد یا در دسترس نباشد.  
* وقتی مقدار `updateChartData` روی `true` تنظیم شود، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

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

1. یک نمونه از کلاس [Presentation](https://apireference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) را ایجاد کنید.  
2. مرجع یک اسلاید را از طریق اندیس آن دریافت کنید.  
3. یک شی برای شکل نمودار ایجاد کنید.  
4. یک شی برای نوع منبع (`ChartDataSourceType`) ایجاد کنید که نشان‌دهنده منبع دادهٔ نمودار است.  
5. شرط مرتبط را بر اساس اینکه نوع منبع همان نوع منبع دادهٔ کتاب‌کار خارجی باشد، مشخص کنید.

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

می‌توانید داده‌های کتاب‌کارهای خارجی را همانند تغییر محتویات کتاب‌کارهای داخلی ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی پرتاب می‌شود.

این کد جاوا پیاده‌سازی فرایند توصیف‌شده را نشان می‌دهد:

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

### **بازیابی کتاب‌کار از حافظه‌نهار نمودار**

اگر یک نمودار از کتاب‌کار خارجی استفاده کند که موجود نباشد یا در دسترس نباشد، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/) ایجاد کنید، آن را با [SpreadsheetOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/spreadsheetoptions/) پیکربندی کنید و قبل از باز کردن ارائه متد [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را با مقدار `true` صدا بزنید.

مثال جاوای زیر یک ارائه را باز می‌کند که نمودار آن به یک کتاب‌کار خارجی غیرقابل دسترس اشاره دارد و داده‌های بازیابی‌شده را از طریق [IChart.getChartData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌کند:

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

    // در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا اصلاح کنید.
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنایی پرتاب می‌کند. بازیابی را فقط وقتی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار گزینهٔ قابل قبولی باشد، زیرا ممکن است کش شامل تغییرات انجام‌شده بر روی کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **سؤالات متداول**

**آیا می‌توانم تعیین کنم آیا یک نمودار خاص به یک کتاب‌کار خارجی یا جاسازی‌شده لینک دارد؟**  
بله. یک نمودار دارای [نوع منبع داده](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) و [مسیر به یک کتاب‌کار خارجی](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید فایل خارجی در حال استفاده است.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**  
بله. اگر مسیر نسبی را مشخص کنید، به‌طور خودکار به مسیر مطلق تبدیل می‌شود. این برای حمل‌پذیری پروژه راحت است؛ اما توجه داشته باشید که ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند.

**آیا می‌توانم از کتاب‌کارهایی که در منابع یا اشتراک‌های شبکه‌ای قرار دارند استفاده کنم؟**  
بله، چنین کتاب‌کارهایی می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای از راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود—آنها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**  
خیر. ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) را ذخیره می‌کند و برای خواندن داده‌ها از آن استفاده می‌کند. فایل خارجی هنگام ذخیرهٔ ارائه تغییر نمی‌کند.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه باید کرد؟**  
Aspose.Slides هنگام ایجاد لینک رمز عبور را قبول نمی‌کند. روش معمول این است که حفاظت را از پیش حذف کنید یا یک نسخهٔ رمزگشایی‌شده تهیه کنید (به‌عنوان مثال با استفاده از [Aspose.Cells](/cells/androidjava/)) و به آن نسخه لینک دهید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی یکسان ارجاع دهند؟**  
بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار بارگذاری بعدی داده‌ها منعکس خواهد شد.