---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌ها روی اندروید
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
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java را کشف کنید: به راحتی کتاب‌کارهای نمودار را در فرمت‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را بهینه‌سازی کنید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های داده‌های نمودار استفاده کنید، به مجموعه‌ورق‌های کار دسترسی داشته باشید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع داده نمودار را پوشش می‌دهد. نمونه‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کنید و داده‌های نمودار را زمانی که کتاب‌کار در دسترس است، ویرایش کنید.

برای سلول‌های کتاب‌کار که نمایانگر داده‌های گمشده هستند، به [کنترل نمایش سلول‌های خالی](/slides/fa/androidjava/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر و مقایسهٔ نمودار خطی حالت‌های نمایش موجود را ببینید.

## **شامل کردن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) برای کنترل این که آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی ورق‌کار ترسیم می‌کند یا نه، استفاده کنید. آن را به `true` تنظیم کنید تا فقط سلول‌های قابل مشاهده ترسیم شوند، یا به `false` تا هم سلول‌های قابل مشاهده و هم مخفی درنظر گرفته شوند. این تنظیم فقط ترسیم نمودار را کنترل می‌کند؛ ردیف‌ها یا ستون‌های ورق کار را مخفی یا نمایان نمی‌کند.

فایل [hidden-source-data.pptx](hidden-source-data.pptx) را دانلود کنید و در کتابخانهٔ کاری‌تان قرار دهید. اسلاید اول آن شامل یک نمودار ستونی به عنوان اولین شکل است. ورق‌کار توکار، `Sheet1`، بازهٔ منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها همچنان مقدار دارند.

| ردیف ورق کار | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

منابع سلول‌ها را از طریق [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی پیدا کنید و با استفاده از [IChartDataCell.isHidden](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) وضعیت مخفی بودن آن‌ها را بررسی کنید. این متد فقط وضعیت مخفی بودن را گزارش می‌کند بدون این که آن را تغییر دهد. در این فایل، B2 قابل مشاهده است، B3 به ردیف مخفی تعلق دارد و C2 به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` را چاپ می‌کند.

در این مثال، پس از تغییر تنظیم ترسیم، داده‌های نمودار را تازه کنید: کتاب‌کار توکار را با [readWorkbookStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) نگه دارید و با [writeWorkbookStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) دوباره بارگذاری کنید. هنگام شامل کردن همه سلول‌ها، از [setRange](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) نیز استفاده کنید تا بازهٔ کامل، شامل دستهٔ مخفی فوریه، بازگردانده شود. فقط تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ این نمونه کافی نیست.

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

            // داده‌های نمودار را از کتاب‌کار توکار تازه کنید.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // بازهٔ منبع کامل را، شامل دسته‌های مخفی، بازگردانید.
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

مثال `hidden_cells_true.pptx` را فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) ذخیره می‌کند و `hidden_cells_false.pptx` را با تمام شش مقدار. تصاویر زیر دو حالت ترسیم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار توکار مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | همه سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی که دارای مقدار است متفاوت از یک سلول خالی است. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) کنترل می‌کند مقادیر گمشده چگونه نمایش داده شوند؛ این مورد شامل یا مستثنی کردن داده‌های منبع مخفی نمی‌شود. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/androidjava/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides برای Android via Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) و [writeWorkbookStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) را فراهم می‌کند که به شما امکان می‌دهد کتاب‌کارهای داده‌های نمودار (شامل داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شیوه سازماندهی شوند یا ساختاری مشابه منبع داشته باشند.

این مثال `chart.pptx` را باز می‌کند که باید یک نمودار به عنوان اولین شکل در اسلاید اول داشته باشد. کتاب‌کار توکار را به یک آرایهٔ بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

### **اعتبارسنجی چیدمان نمودار پس از تغییر کتاب‌کار**

هنگامی که یک کتاب‌کار توکار را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود [IChart.validateChartLayout](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#validateChartLayout--) با خطای «index-out-of-range» شکست بخورد. قبل از نوشتن کتاب‌کار به‌روز شده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال به `chart.pptx` که شامل یک نمودار به عنوان اولین شکل در اسلاید اول است، نیاز دارد. توضیحاتی که نشان می‌دهد ویرایش کتاب‌کار کجا انجام می‌شود قرار داده شده است؛ مثال قابل اجرا کتاب‌کار اصلی را باز می‌نویسد و چیدمان را در حافظه اعتبارسنجی می‌کند.

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

        // در اینجا بایت‌های کتاب‌کار را تغییر دهید، برای مثال با استفاده از Aspose.Cells.

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

پاک‌کردن مجموعه‌ها مراجع دادهٔ منسوخ را پیش از نوشتن کتاب‌کار حذف می‌کند. قبل از استفاده از نمودار، سری‌ها و نگاشت‌های دستهٔ موردنیاز برای کتاب‌کار به‌روز شده بازسازی شوند.

## **تنظیم یک سلول کتاب‌کار به عنوان برچسب داده‌ای نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به عنوان برچسب‌های داده‌ای نمودار استفاده کنید. مراحل زیر نشان می‌دهد چگونه برچسب‌ها را در یک نمودار حبابی به سلول‌های کتاب‌کار مرتبط کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید اول را بر حسب شاخص صفر دسترسی پیدا کنید.
3. یک نمودار حبابی با داده‌های پیش‌فرض اضافه کنید.
4. به سری‌های نمودار دسترسی پیدا کنید.
5. سلول کتاب‌کار را به عنوان برچسب داده تنظیم کنید.
6. ارائه را ذخیره کنید.

این مثال `chart2.pptx` را باز می‌کند که باید حداقل یک اسلاید داشته باشد و یک نمودار حبابی با داده‌های پیش‌فرض اضافه می‌کند. از سلول‌های A10:A12 در ورق‌کار 0 برای اولین سه برچسب در سری اول استفاده می‌کند، برچسب‌ها از سلول‌ها فعال می‌شوند و نتیجه در `resultchart.pptx` ذخیره می‌شود.

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

## **مدیریت ورق‌های کار**

متد [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) دسترسی به ورق‌های کار در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند و نام هر ورق کار را در کنسول چاپ می‌کند.

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

این مثال یک نمودار ستونی سه‌بعدی با داده‌های پیش‌فرض ایجاد می‌کند و دو نام سری را با استفاده از منابع داده متفاوت تنظیم می‌کند. نام اول از یک رشتهٔ متنی استفاده می‌کند؛ نام دوم از سلول C1 در ورق‌کار 0 استفاده می‌کند. شمارندهٔ [DataSourceType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. نتیجه در `pres.pptx` ذخیره می‌شود.

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

## **تشخیص قالب‌های کتاب‌کار توکار پشتیبانی‌نشده**

Aspose.Slides قالب کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها توکار شود را پشتیبانی نمی‌کند. می‌توانید از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) روی [IChartData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/) به همراه شمارندهٔ [WorkbookType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/workbooktype/) برای تشخیص قالب‌های پشتیبانی‌نشده و پرش از آن نمودارها استفاده کنید. این مثال شکل‌های اسلاید اول `sample.pptx` را بازرسی می‌کند، اشکال غیرنمودار را نادیده می‌گیرد و برای هر نموداری که کتاب‌کار .xlsb توکار دارد، پیام تشخیصی چاپ می‌کند.

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

        // داده‌های کتاب‌کار نمودار پشتیبانی‌شده را در اینجا بخوانید یا اصلاح کنید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفادهٔ کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) و [setExternalWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) برای استخراج یک کتاب‌کار توکار نمودار به یک فایل و لینک کردن نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با داده‌های پیش‌فرض ایجاد می‌کند، کتاب‌کار آن را در `externalWorkbook1.xlsx` می‌نویسد و پس از اتمام نوشتن فایل، آن را به عنوان منبع دادهٔ نمودار انتساب می‌دهد. ارائهٔ لینک‌شده در `externalWorkbook.pptx` ذخیره می‌شود.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **تنظیم یک کتاب‌کار خارجی**

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) می‌توانید یک کتاب‌کار خارجی را به عنوان منبع دادهٔ یک نمودار انتساب دهید. این متد همچنین می‌تواند مسیر کتاب‌کار خارجی را به‌روزرسانی کند (اگر کتاب‌کار به مکان دیگری منتقل شده باشد).

اگرچه نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع را مستقیماً ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال به `externalWorkbook.xlsx` در پوشهٔ کاری نیاز دارد. ورق‌کار آن با نام `Sheet1` باید شامل یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 باشد. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را لینک می‌کند و با استفاده از [setRange](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) بازهٔ A1:B4 را به یک سری و سه دسته نگاشت می‌کند. نتیجه در `Presentation_with_externalWorkbook.pptx` ذخیره می‌شود.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پارامتر `updateChartData` متد [setExternalWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) کنترل می‌کند که آیا کتاب‌کار بارگذاری شود یا نه.

* هنگامی که `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روزرسانی می‌شود. داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روزرسانی نمی‌شوند، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* هنگامی که `updateChartData` برابر `true` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روزرسانی می‌شوند.

مثال زیر یک URL جایگزین را با `updateChartData` برابر `false` تنظیم می‌کند. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شوند و ارائه بدون بارگذاری کتاب‌کار در دسترس ذخیره می‌شود.

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

### **دریافت مسیر کتاب‌کار منبع دادهٔ خارجی یک نمودار**

برای شناسایی کتاب‌کاری که به یک نمودار لینک شده است، ابتدا بررسی کنید که آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند یا نه. اگر بله، می‌توانید مسیر کتاب‌کار را با انجام مراحل زیر بخوانید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. اسلاید اول را بر حسب شاخص صفر دسترسی پیدا کنید.
3. اطمینان حاصل کنید که اولین شکل یک نمودار است.
4. نوع منبع دادهٔ نمودار را بخوانید.
5. اگر منبع یک کتاب‌کار خارجی بود، مسیر آن را بخوانید.

این مثال `externalWorkbook.pptx` را که در مثال قبلی ایجاد شده است باز می‌کند و اولین شکل در اولین اسلاید را بررسی می‌کند. اگر یک نمودار لینک‌شده به کتاب‌کار خارجی باشد، مثال متد [getExternalWorkbookPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) را در کنسول چاپ می‌کند. سپس یک کپی از ارائه را در `Result.pptx` ذخیره می‌کند.

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

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همان‌گونه که داده‌های کتاب‌کارهای داخلی را ویرایش می‌کنید، تغییر دهید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی پرتاب می‌شود.

این مثال به `presentation.pptx` که شامل یک نمودار به عنوان اولین شکل در اسلاید اول است و یک کتاب‌کار خارجی قابل دسترسی نیاز دارد. مقدار پشتیبانی‌شده از سلول اولین نقطه داده در اولین سری را به 100 تنظیم می‌کند و ارائه را در `presentation_out.pptx` ذخیره می‌کند. ویرایش مقادیر سلول می‌تواند فایل XLSX لینک‌شدهٔ خارجی را به‌روزرسانی کند، بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

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

### **بازیابی کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که موجود نیست یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/) ایجاد کنید، متد [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) را فراخوانی کنید و قبل از باز کردن ارائه، [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را به `true` تنظیم کنید.

نمونهٔ جاوا زیر `presentation.pptx` را باز می‌کند که اولین شکل در اولین اسلاید باید یک نمودار باشد که به کتاب‌کار خارجی غیرقابل دسترس ارجاع می‌دهد، و داده‌های بازیابی‌شده را از طریق [IChart.getChartData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌یابد:

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

        // داده‌های کتاب‌کار بازیابی‌شده را در اینجا بخوانید یا اصلاح کنید.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. فقط زمانی که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ قابل قبول باشد، بازیابی را فعال کنید، زیرا کش ممکن است شامل تغییراتی که پس از آخرین به‌روزرسانی ارائه در کتاب‌کار خارجی انجام شده باشد، نباشد.

## **پرسش‌های متداول**

**آیا می‌توانم تعیین کنم که یک نمودار خاص به کتاب‌کار خارجی یا توکار لینک شده است؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) و [path to an external workbook](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا اطمینان حاصل کنید که از یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابجایی کتاب‌کار ممکن است نیاز به به‌روزرسانی لینک داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که روی منابع شبکه/به‌اشتراک‌گذاری قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای دوردست از Aspose.Slides پشتیبانی نمی‌شود؛ آن‌ها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) را ذخیره می‌کند. ویرایش داده‌های نمودار پشتیبانی‌شده توسط سلول می‌تواند فایل XLSX محلی لینک‌شده را نیز به‌روزرسانی کند. اگر باید کتاب‌کار اصلی دست نخورده بماند، از یک کپی استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه کاری باید انجام دهم؟**

Aspose.Slides هنگام لینک کردن رمز عبور را نمی‌پذیرد. یک راه معمول این است که پیش از لینک کردن محافظت را حذف کنید یا یک کپی رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/java/)) تهیه کنید و به آن لینک کنید.

**آیا چندین نمودار می‌توانند به یک کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار لینک خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر نمودار در بارگیری بعدی داده‌ها منعکس می‌شود.