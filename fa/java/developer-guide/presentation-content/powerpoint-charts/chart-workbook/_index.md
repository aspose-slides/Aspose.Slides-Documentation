---
title: مدیریت کاربرگ‌های نمودار در ارائه‌ها با استفاده از جاوا
linktitle: کاربرگ نمودار
type: docs
weight: 70
url: /fa/java/chart-workbook/
keywords:
- کاربرگ نمودار
- داده‌های نمودار
- سلول کاربرگ
- برچسب داده
- کاربرگ
- منبع داده
- کاربرگ خارجی
- داده خارجی
- کش نمودار
- بازیابی کاربرگ
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "Aspose.Slides for Java را کشف کنید: به آسانی کاربرگ‌های نمودار را در فرمت‌های پاورپوینت و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه با کاربرگ‌های نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کاربرگ بخوانید و بنویسید، از سلول‌های کاربرگ به عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی داشته باشید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کاربرگ‌های خارجی به‌عنوان منابع داده برای نمودارها را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کاربرگ خارجی ایجاد و اختصاص دهید، مسیر یک کاربرگ خارجی متصل به نمودار را بازیابی کنید و داده‌های نمودار را وقتی کاربرگ در دسترس باشد ویرایش کنید.

برای سلول‌های کاربرگ که نشان‌دهنده داده‌های گمشده هستند، به [کنترل نمایش سلول‌های خالی](/slides/fa/java/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر، و مقایسه یک نمودار خطی از حالت‌های نمایش موجود را ببینید.

## **گنجاندن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) برای کنترل اینکه آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی کاربرگ ترسیم می‌کند یا نه استفاده کنید. مقدار `true` را تنظیم کنید تا فقط سلول‌های قابل مشاهده ترسیم شوند، یا `false` تا هر دو سلول قابل مشاهده و مخفی شامل شوند. این تنظیم فقط ترسیم نمودار را کنترل می‌کند؛ ردیف‌ها یا ستون‌های کاربرگ را مخفی یا آشکار نمی‌کند.

فایل [hidden-source-data.pptx](hidden-source-data.pptx) را دانلود کنید و در پوشه کاری قرار دهید. اسلاید اول آن شامل یک نمودار ستونی به‌عنوان اولین شکل است. کاربرگ توکار، `Sheet1`، بازه منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها هنوز مقدار دارند.

| ردیف کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی پیدا کنید و با استفاده از [IChartDataCell.isHidden](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdatacell/#isHidden--) وضعیت مخفی بودن آن‌ها را بررسی کنید. این متد وضعیت مخفی را بدون تغییر آن گزارش می‌دهد. در این فایل، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه کنید: کاربرگ توکار را با [readWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#readWorkbookStream--) نگه دارید و با [writeWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) دوباره بارگذاری کنید. هنگام گنجاندن همه سلول‌ها، از [setRange](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) نیز استفاده کنید تا بازه کامل، شامل دستهٔ مخفی فوریه، بازگردانده شود. صرفاً تغییر پرچم برای تازه‌سازی داده‌های کش شدهٔ این نمونه و برچسب‌های دسته کافی نیست.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // داده‌های نمودار را از کاربرگ توکار تازه‌سازی کنید.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // محدودهٔ منبع کامل را بازگردانید، شامل دسته‌های مخفی.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

مثال `hidden_cells_true.pptx` را فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) ذخیره می‌کند و `hidden_cells_false.pptx` را با تمام شش مقدار ذخیره می‌کند. تصاویر زیر دو حالت ترسیم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کاربرگ توکار مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | همه سلول‌ها (`false`) |
| --- | --- |
| ![فقط سلول‌های قابل مشاهده: مقادیر خرده‌فروشی ۱۰ و ۲۰ برای ژانویه و مارس.](hidden_cells_True.png) | ![تمام سلول‌ها: مقادیر خرده‌فروشی و عمده‌فروشی برای ژانویه، فوریه و مارس.](hidden_cells_False.png) |

یک سلول مخفی که حاوی مقدار است متفاوت از یک سلول خالی است. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) نحوه نمایش مقادیر گمشده را کنترل می‌کند؛ داده‌های منبع مخفی را شامل یا مستثنی نمی‌کند. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/java/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **خواندن و نوشتن داده‌های نمودار از کاربرگ**

Aspose.Slides for Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#readWorkbookStream--) و [writeWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) را فراهم می‌کند که به شما امکان خواندن و نوشتن کاربرگ‌های داده نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را می‌دهد. **Note** داده‌های نمودار باید به همان شکل سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال `chart.pptx` را باز می‌کند که باید در اولین اسلایدش یک نمودار به‌عنوان اولین شکل داشته باشد. کاربرگ توکار را به‌صورت یک آرایه بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کاربرگ را بازنویسی می‌کند. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **اعتبارسنجی طرح‌بندی نمودار پس از تغییر کاربرگ**

هنگامی که کاربرگ توکار را با یک کاربرگ تغییر یافته جایگزین می‌کنید، نمودار مجموعه سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این ناهمسویی می‌تواند باعث شود که [IChart.validateChartLayout](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#validateChartLayout--) با خطای out‑of‑range ایندکس شکست بخورد. قبل از نوشتن کاربرگ به‌روزرسانی‌شده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال به `chart.pptx` با یک نمودار به‌عنوان اولین شکل در اولین اسلاید نیاز دارد. علامت‌گذاری‌های توضیحی نشان می‌دهند که ویرایش کاربرگ در اینجا انجام می‌شود؛ مثال قابل اجرا همان کاربرگ اصلی را بازنویسی می‌کند و طرح‌بندی را در حافظه اعتبارسنجی می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // در اینجا بایت‌های کاربرگ را اصلاح کنید، برای مثال با استفاده از Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

پاک‌سازی مجموعه‌ها مراجع داده‌های کهنه را قبل از نوشتن کاربرگ حذف می‌کند. قبل از استفاده از نمودار، هر سری و نگاشت دسته مورد نیاز برای کاربرگ به‌روزرسانی‌شده را بازسازی کنید.

## **تنظیم یک سلول کاربرگ به عنوان برچسب داده نمودار**

می‌توانید از متن سلول‌های کاربرگ به‌عنوان برچسب‌های داده نمودار استفاده کنید. مراحل زیر نشان می‌دهند چگونه برچسب‌های یک نمودار حبابی را به سلول‌های کاربرگ داده آن لینک کنید.

1. یک نمونه از کلاس [Presentation] ایجاد کنید.
2. اولین اسلاید را بر اساس ایندکس صفر‑مبنی آن دسترسی پیدا کنید.
3. یک نمودار حبابی با داده‌های پیش‌فرض اضافه کنید.
4. به مجموعه سری‌های نمودار دسترسی پیدا کنید.
5. سلول کاربرگ را به‌عنوان برچسب داده تنظیم کنید.
6. ارائه (Presentation) را ذخیره کنید.

این مثال `chart2.pptx` را باز می‌کند که باید حداقل یک اسلاید داشته باشد و یک نمودار حبابی با داده‌های پیش‌فرض اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای اولین سه برچسب در اولین سری استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌کند و نتیجه را در `resultchart.pptx` ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مدیریت کاربرگ‌ها**

متد [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) دسترسی به کاربرگ‌های موجود در یک کاربرگ نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را در کنسول چاپ می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **مشخص کردن نوع منبع داده**

این مثال یک نمودار ستونی 3D با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با استفاده از منابع داده متفاوت تنظیم می‌کند. نام اول از یک مقدار رشته‌ای استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 استفاده می‌کند. شمارش‌گر [DataSourceType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/datasourcetype/) منبع را برای هر نام انتخاب می‌کند. نتیجه در `pres.pptx` ذخیره می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تشخیص قالب‌های کاربرگ توکار پشتیبانی نشده**

Aspose.Slides از قالب کاربرگ باینری Excel (.xlsb) که می‌تواند در برخی نمودارها توکار شود، پشتیبانی نمی‌کند. می‌توانید از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) روی [IChartData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/) همراه با شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/workbooktype/) برای شناسایی قالب‌های پشتیبانی‌نشده استفاده کنید و آن نمودارها را نادیده بگیرید. این مثال اشکال موجود در اولین اسلاید `sample.pptx` را بررسی می‌کند، شکل‌های غیرنموداری را رد می‌کند و برای هر نمودار دارای کاربرگ .xlsb یک پیام تشخیصی چاپ می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // در اینجا داده‌های کاربرگ نمودار پشتیبانی‌شده را بخوانید یا اصلاح کنید.
    }
} finally {
    presentation.dispose();
}
```

## **کاربرگ خارجی**

Aspose.Slides از استفاده از کاربرگ‌های خارجی به‌عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کاربرگ خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#readWorkbookStream--) و [setExternalWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) برای استخراج یک کاربرگ نمودار توکار به یک فایل و لینک کردن نمودار به آن کاربرگ خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند، کاربرگ آن را در `externalWorkbook1.xlsx` می‌نویسد و نوشتن فایل را قبل از انتساب به عنوان منبع دادهٔ نمودار تکمیل می‌کند. ارائهٔ لینک‌شده در `externalWorkbook.pptx` ذخیره می‌شود.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **تنظیم یک کاربرگ خارجی**

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) می‌توانید یک کاربرگ خارجی را به یک نمودار به‌عنوان منبع دادهٔ آن اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کاربرگ خارجی استفاده شود (اگر کاربرگ جابه‌جا شده باشد).

اگرچه نمی‌توانید داده‌های موجود در کاربرگ‌های ذخیره‌شده در مکان‌های دوردست یا منابع را ویرایش کنید، اما همچنان می‌توانید از چنین کاربرگ‌هایی به‌عنوان منبع داده خارجی استفاده کنید. اگر مسیر نسبی برای یک کاربرگ خارجی فراهم شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال به `externalWorkbook.xlsx` در پوشه کاری نیاز دارد. کاربرگ آن که نامش `Sheet1` است باید یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 داشته باشد. مثال یک نمودار دایره‌ای ایجاد می‌کند، کاربرگ را لینک می‌کند و با استفاده از [setRange](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) بازه A1:B4 را به یک سری و سه دسته اختصاص می‌دهد. نتیجه در `Presentation_with_externalWorkbook.pptx` ذخیره می‌شود.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پارامتر `updateChartData` متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) تعیین می‌کند که آیا کاربرگ بارگذاری شود یا نه.

* وقتی `updateChartData` برابر `false` باشد، فقط مسیر کاربرگ به‌روزرسانی می‌شود. داده‌های نمودار از کاربرگ هدف بارگذاری یا به‌روز نمی‌شوند، بنابراین کاربرگ می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، داده‌های نمودار از کاربرگ هدف به‌روزرسانی می‌شوند.

مثال زیر یک URL جایگزین را با `updateChartData` برابر `false` تخصیص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شوند و ارائه بدون بارگذاری کاربرگ غیربالخصوص ذخیره می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **دریافت مسیر کاربرگ منبع داده خارجی یک نمودار**

برای شناسایی کاربرگی که به یک نمودار لینک شده است، ابتدا بررسی کنید که آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند یا نه. اگر چنین باشد، می‌توانید مسیر کاربرگ را با دنبال کردن مراحل زیر بازیابی کنید.

1. یک نمونه از کلاس [Presentation] ایجاد کنید.
2. اولین اسلاید را بر اساس ایندکس صفر‑مبنی آن دسترسی پیدا کنید.
3. بررسی کنید که اولین شکل یک نمودار است.
4. نوع منبع دادهٔ نمودار را بخوانید.
5. اگر منبع یک کاربرگ خارجی باشد، مسیر آن را بخوانید.

این مثال `externalWorkbook.pptx` را باز می‌کند که در مثال قبلی ایجاد شده بود و اولین شکل در اولین اسلاید را بررسی می‌کند. اگر یک نمودار لینک‌شده به کاربرگ خارجی باشد، مثال [getExternalWorkbookPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را در `Result.pptx` ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ویرایش داده‌های نمودار**

می‌توانید داده‌های موجود در کاربرگ‌های خارجی را همانند تغییر محتویات کاربرگ‌های داخلی ویرایش کنید. هنگامی که یک کاربرگ خارجی قابل بارگذاری نباشد، یک استثنا پرتاب می‌شود.

این مثال به `presentation.pptx` با یک نمودار به‌عنوان اولین شکل در اولین اسلاید و یک کاربرگ خارجی قابل دسترس نیاز دارد. مقدار پشتیبانی‑شده از سلول اولین نقطه داده در اولین سری را به 100 تنظیم می‌کند و ارائه را در `presentation_out.pptx` ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی لینک‌شده را به‌روز کند، بنابراین اگر لازم است کاربرگ اصلی حفظ شود، از یک کپی استفاده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **بازیابی یک کاربرگ از حافظه نهان نمودار**

اگر یک نمودار از یک کاربرگ خارجی که مفقود یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کاربرگ نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، یک شیء [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) ایجاد کنید، متد [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) را فراخوانی کنید و [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را روی `true` تنظیم کنید.

مثال زیر در جاوا `presentation.pptx` را باز می‌کند که اولین شکل در اولین اسلاید باید یک نمودار باشد که به یک کاربرگ خارجی غیربالخصوص ارجاع می‌دهد، و داده‌های بازیابی شده را از طریق [IChart.getChartData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌یابد:

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // در اینجا داده‌های کاربرگ بازیابی‌شده را بخوانید یا اصلاح کنید.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

اگر کاربرگ خارجی غیربالخصوص باشد و بازیابی غیرفعال باشد، Aspose.Slides یک استثنا پرتاب می‌کند. فقط زمانی که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ قابل قبول است، بازیابی را فعال کنید، زیرا کش ممکن است تغییرات ایجادشده در کاربرگ خارجی پس از آخرین به‌روزرسانی ارائه را شامل نشود.

## **پرسش‌های متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به یک کاربرگ خارجی یا توکار لینک شده است؟**

بله. یک نمودار دارای یک [نوع منبع داده](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getDataSourceType--) و یک [مسیر به کاربرگ خارجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کاربرگ خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کاربرگ‌های خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، لذا جابه‌جایی کاربرگ ممکن است نیاز به به‌روزرسانی لینک داشته باشد.

**آیا می‌توانم از کاربرگ‌هایی که در منابع/به‌اشتراک‌گذاری‌های شبکه‌ای قرار دارند استفاده کنم؟**

بله، چنین کاربرگ‌هایی می‌توانند به‌عنوان منبع داده خارجی استفاده شوند. با این حال، ویرایش مستقیم کاربرگ‌های دوردست از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [لینک به فایل خارجی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) را ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبان‌شده توسط سلول می‌تواند فایل XLSX محلی لینک‌شده را نیز به‌روز کند. اگر لازم است نسخه اصلی دست نخورده بماند، از یک کپی کاربرگ استفاده کنید.

**اگر فایل خارجی دارای رمز عبور باشد، چه کاری باید انجام دهم؟**

Aspose.Slides هنگام ایجاد لینک از رمز عبور حمایت نمی‌کند. رویکرد معمول این است که قبل از لینک کردن حفاظت را حذف کنید یا یک کپی رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/java/)) را تهیه کنید و به آن لینک کنید.

**آیا می‌توان چندین نمودار را به یک کاربرگ خارجی ارجاع داد؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همگی به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار بار دیگر که داده‌ها بارگذاری شوند، منعکس خواهد شد.