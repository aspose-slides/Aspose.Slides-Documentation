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
- کاربرگ
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
description: "Aspose.Slides برای اندروید از طریق جاوا را کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه خود را به‌صورت بهینه‌سازی کنید."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه با کتاب‌کارهای نمودار در Aspose.Slides کار کنید. این مقاله نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به‌عنوان برچسب‌های داده نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی داشته باشید و نوع منبع داده برای مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به‌عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی مرتبط با یک نمودار را بازیابی کنید و داده‌های نمودار را هنگام در دسترس بودن کتاب‌کار ویرایش کنید.

برای سلول‌های کتاب‌کاری که نمایانگر داده‌های مفقود هستند، به [کنترل نمایش سلول‌های خالی](/slides/fa/androidjava/chart-series/) مراجعه کنید تا تفاوت بین یک سلول خالی و صفر، و مقایسهٔ خطی نمودار برای حالت‌های نمایش موجود را ببینید.

## **درج داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) برای کنترل اینکه آیا یک نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی کاربرگ رسم می‌کند یا نه استفاده کنید. آن را به `true` تنظیم کنید تا فقط سلول‌های قابل مشاهده رسم شوند، یا به `false` تا هر دو سلول قابل مشاهده و مخفی گنجانده شوند. این تنظیم تنها بر رسم نمودار تأثیر دارد؛ ردیف‌ها یا ستون‌های کاربرگ را مخفی یا آشکار نمی‌کند.

[نمونه ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی به‌عنوان اولین شکل در اسلاید اول است. کاربرگ جاسازی‌شده، `Sheet1`، شامل بازهٔ منبع زیر `A1:C4` است. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آنها همچنان دارای مقادیر هستند.

| سطر کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی پیدا کنید و با خواندن [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) وضعیت مخفی بودن آنها را بررسی کنید. این متد وضعیت مخفی بودن را بدون تغییر گزارش می‌دهد. در این فایل، B2 قابل مشاهده است، B3 متعلق به ردیف مخفی است و C2 متعلق به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` را چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم رسم، داده‌های نمودار را تازه کنید: کتاب‌کار جاسازی‌شده را با [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) حفظ کنید و با [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) دوباره بارگذاری کنید. هنگام گنجاندن تمام سلول‌ها، همچنین از [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) برای بازگرداندن بازهٔ کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. فقط تغییر پرچم برای تازه‌سازی داده‌های کش‌شدهٔ نمونه کافی نیست.

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

            // داده‌های نمودار را از کتاب‌کار جاسازی‌شده تازه‌سازی کنید.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // بازهٔ منبع کامل را بازگردانید، شامل دسته‌های مخفی.
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

مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20) و دیگری با تمام شش مقدار. تصاویر زیر دو حالت رسم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار جاسازی‌شده مخفی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | تمام سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی حاوی مقدار با یک سلول خالی متفاوت است. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) کنترل می‌کند مقادیر مفقود چگونه نمایش داده شوند؛ این متد منبع دادهٔ مخفی را شامل یا حذف نمی‌کند. برای مثال به [کنترل نمایش سلول‌های خالی](/slides/fa/androidjava/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازیابی بازهٔ دادهٔ یک نمودار**

قبل از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، بازه‌های منبع را بررسی کنید تا ببینید هر نمودار از چه سلول‌های کاربرگی استفاده می‌کند. متد [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) بازهٔ دادهٔ فعلی را به‌صورت فرمولی معتبر برای کاربرگ برمی‌گرداند، مانند `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام کاربرگ است، `!` آن را از بازهٔ سلولی جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را شامل می‌شود. علامت‌های دلار نشان‌دهنده ارجاع مطلق به ردیف و ستون هستند.

این متد بازهٔ فعلی را بدون تغییر نمودار یا کتاب‌کار می‌خواند. اگر نمودار از کتاب‌کاری به‌عنوان منبع داده استفاده نکند، استثنای `InvalidOperationException` پرتاب می‌شود. برای اطلاعات بیشتر، به [مرجع API ChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/) مراجعه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌های موجود در هر اسلاید را برای نمودارها بررسی می‌کند. نام هر نمودار و بازهٔ منبع آن را چاپ می‌کند. اگر نموداری از کتاب‌کار استفاده نکند، پیام مربوطه را چاپ کرده و به نمودار بعدی ادامه می‌دهد.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **خواندن و نوشتن داده‌های نمودار از یک کتاب‌کار**

Aspose.Slides for Android via Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) و [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) را فراهم می‌کند که اجازه می‌دهند کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که داده‌های نمودار باید به همان شکل یا ساختاری مشابه منبع سازمان‌دهی شوند.

این مثال از یک ارائه با یک نمودار به‌عنوان اولین شکل در اسلاید اول استفاده می‌کند. کتاب‌کار جاسازی‌شده را به یک آرایه بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه باقی می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

زمانی که یک کتاب‌کار جاسازی‌شده را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این عدم تطابق می‌تواند باعث شود که [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) با خطای «index‑out‑of‑range» شکست بخورد. پیش از نوشتن کتاب‌کار به‌روز شده به نمودار، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار استفاده می‌کند که اولین شکل در اسلاید اول است. نظرات نشان می‌دهند کجا ویرایش کتاب‌کار انجام می‌شود؛ مثال اجرایی کتاب‌کار اصلی را برمی‌گرداند و چیدمان را در حافظه اعتبارسنجی می‌کند.

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

        // در اینجا بایت‌های کتاب‌کار را تغییر دهید، به عنوان مثال با استفاده از Aspose.Cells.

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

پاک‌سازی مجموعه‌ها قبل از نوشتن کتاب‌کار، مراجع دادهٔ منقضی شده را حذف می‌کند. پیش از استفاده از نمودار، سری‌ها و نگاشت‌های دستهٔ مورد نیاز برای کتاب‌کار به‌روزرسانی‌شده را بازسازی کنید.

## **تنظیم یک سلول کتاب‌کار به‌عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به‌عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با دادهٔ پیش‌فرض به اسلاید اول یک ارائه موجود اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای سه برچسب اول در سری اول استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌سازد و ارائهٔ به‌روزرسانی‌شده را ذخیره می‌کند.

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

متد [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) دسترسی به کاربرگ‌های موجود در یک کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را در کنسول چاپ می‌کند.

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

این مثال یک نمودار ستونی 3‑بعدی با دادهٔ پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع دادهٔ متفاوت تنظیم می‌کند. نام اول از یک مقدار رشته‌ای ثابت استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 استفاده می‌کند. شمارش‌گر [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری به‌روز شده ذخیره می‌کند.

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

## **تشخیص فرمت‌های ناشناختهٔ کتاب‌کار جاسازی‌شده**

Aspose.Slides از فرمت کتاب‌کار باینری اکسل (.xlsb) که می‌تواند در برخی نمودارها جاسازی شود، پشتیبانی نمی‌کند. می‌توانید با استفاده از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) روی [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) همراه با شمارش‌گر [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) فرمت‌های پشتیبانی‌نشده را شناسایی و آن نمودارها را نادیده بگیرید. این مثال شکل‌های اسلاید اول یک ارائه موجود را بررسی می‌کند، شکل‌های غیرنموداری را نادیده می‌گیرد و برای هر نموداری که کتاب‌کار .xlsb جاسازی‌شده دارد، پیام تشخیص چاپ می‌کند.

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

        // داده‌های کتاب‌کار پشتیبانی‌شدهٔ نمودار را اینجا بخوانید یا تغییر دهید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به‌عنوان منبع دادهٔ نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) و [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) برای صادر کردن کتاب‌کار نمودار جاسازی‌شده به یک فایل و پیوند نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را صادر می‌کند. نوشتن فایل را تکمیل می‌کند قبل از اختصاص کتاب‌کار خارجی به‌عنوان منبع دادهٔ نمودار، سپس ارائهٔ پیوند‌شده را ذخیره می‌کند.

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

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) می‌توانید یک کتاب‌کار خارجی را به‌عنوان منبع دادهٔ یک نمودار اختصاص دهید. این متد همچنین می‌تواند برای به‌روزرسانی مسیر کتاب‌کار خارجی (در صورت جابجایی آن) استفاده شود.

در حالی که نمی‌توانید داده‌های موجود در کتاب‌کارهای ذخیره‌شده در مکان‌های دوردست یا منابع را ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به‌عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای یک کتاب‌کار خارجی فراهم شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از یک کتاب‌کار خارجی استفاده می‌کند که کاربرگ آن به نام `Sheet1` شامل یک نام سری در B1، نام‌های دسته در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوند می‌دهد و با استفاده از [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) بازهٔ A1:B4 را به یک سری و سه دسته نگاشت می‌کند. ارائه را با نمودار پیوندشده ذخیره می‌کند.

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

پارامتر `updateChartData` متد [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) تعیین می‌کند که آیا کتاب‌کار بارگذاری شود یا نه.

* هنگامی که `updateChartData` برابر `false` باشد، فقط مسیر کتاب‌کار به‌روز می‌شود. داده‌های نمودار از کتاب‌کار هدف بارگذاری یا به‌روز نمی‌شوند، بنابراین کتاب‌کار می‌تواند در دسترس نباشد.
* هنگامی که `updateChartData` برابر `true` باشد، داده‌های نمودار از کتاب‌کار هدف به‌روز می‌شوند.

مثال زیر یک URL ایستا را با `updateChartData` برابر `false` اختصاص می‌دهد. داده‌های پیش‌فرض نمودار دایره‌ای حفظ می‌شوند و ارائه بدون بارگذاری کتاب‌کار غیرقابل دسترس ذخیره می‌شود.

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

برای شناسایی کتاب‌کار پیوندشده به یک نمودار، بررسی کنید که آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را بازیابی کنید.

این مثال شکل اول در اسلاید اول یک ارائه با کتاب‌کار خارجی پیوندشده را بررسی می‌کند. اگر یک نمودار پیوندشده به کتاب‌کار خارجی باشد، مثال [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) را در کنسول چاپ می‌کند. سپس یک نسخهٔ کپی از ارائه را ذخیره می‌کند.

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

### **ویرایش دادهٔ نمودار**

می‌توانید داده‌های موجود در کتاب‌کارهای خارجی را همانند تغییرات در محتویات کتاب‌کارهای داخلی ویرایش کنید. وقتی یک کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی قابل دسترس پیوند دارد، استفاده می‌کند. مقدار پشتیبانی‌شده توسط سلول برای اولین نقطه داده در اولین سری را به 100 تنظیم می‌کند و ارائهٔ به‌روزرسانی‌شده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوندشده را به‌روز کند، بنابراین در صورت نیاز به حفظ کتاب‌کار اصلی، از یک کپی استفاده کنید.

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

### **بازیابی یک کتاب‌کار از کش نمودار**

اگر یک نمودار از کتاب‌کار خارجی که مفقود یا در دسترس نیست استفاده کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. قبل از باز کردن ارائه، [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) ایجاد کنید، [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) را فراخوانی کنید و [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را به `true` تنظیم کنید.

مثال جاوا زیر داده‌های کتاب‌کار را برای یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی غیرقابل دسترس ارجاع دارد، بازیابی می‌کند. داده‌های بازیابی‌شده را از طریق [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌یابد:

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

        // در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا تغییر دهید.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنایی پرتاب می‌کند. بازیابی را فقط زمانی فعال کنید که استفاده از داده‌های کش‌شدهٔ نمودار یک گزینهٔ پذیرفتنی باشد، زیرا کش ممکن است تغییرات اعمال‌شده به کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه را شامل نشود.

## **سوالات متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به یک کتاب‌کار خارجی یا جاسازی‌شده پیوند دارد؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) و [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید یک فایل خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابجایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که در منابع/اشتراک‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. اما ویرایش مستقیم کتاب‌کارهای دوردست از Aspose.Slides پشتیبانی نمی‌شود؛ آنها فقط می‌توانند به‌عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ذخیره می‌کند. ویرایش داده‌های نمودار مبتنی بر سلول می‌تواند فایل XLSX محلی پیوندشده را نیز به‌روزرسانی کند. اگر فایل اصلی باید دست‌نخورده بماند، از یک کپی کتاب‌کار استفاده کنید.

**اگر فایل خارجی با رمز عبور محافظت شده باشد چه باید کرد؟**

Aspose.Slides هنگام پیوند گرفتن رمز عبور را قبول نمی‌کند. یک رویکرد معمول این است که پیش از این محافظت را حذف کنید یا یک کپی رمزگشایی‌شده تهیه کنید (به‌عنوان مثال با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/java/)) و به آن کپی پیوند دهید.

**آیا چندین نمودار می‌توانند به همان کتاب‌کار خارجی ارجاع دهند؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همگی به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس خواهد شد.