---
title: مدیریت کتاب‌کارهای نمودار در ارائه‌های Android
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
- پاورپوینت
- ارائه
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides برای Android via Java را کشف کنید: به‌راحتی کتاب‌کارهای نمودار را در قالب‌های PowerPoint و OpenDocument مدیریت کنید تا داده‌های ارائه‌تان را بهینه سازید."
---
## **نمای کلی**

این مقاله نحوه کار با کتاب‌کارهای نمودار در Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه داده‌های نمودار را از طریق جریان‌های کتاب‌کار بخوانید و بنویسید، از سلول‌های کتاب‌کار به عنوان برچسب‌های دادهٔ نمودار استفاده کنید، به مجموعه‌های کاربرگ دسترسی پیدا کنید و نوع منبع دادهٔ مقادیر نمودار را مشخص کنید.

همچنین کار با کتاب‌کارهای خارجی به عنوان منابع دادهٔ نمودار را پوشش می‌دهد. مثال‌ها نشان می‌دهند چگونه یک کتاب‌کار خارجی ایجاد و اختصاص دهید، مسیر کتاب‌کار خارجی پیوست‌شده به یک نمودار را بازیابی کنید و هنگام موجود بودن کتاب‌کار دادهٔ نمودار را ویرایش کنید.

برای سلول‌های کتاب‌کاری که دادهٔ مفقود را نشان می‌دهند، به مقاله [Control the Display of Empty Cells](/slides/fa/androidjava/chart-series/) برای تفاوت بین یک سلول خالی و صفر و مقایسهٔ نمودار خطی حالت‌های نمایش موجود مراجعه کنید.

## **شامل کردن داده‌ها از ردیف‌ها و ستون‌های مخفی**

از [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) برای کنترل این‌که آیا نمودار داده‌ها را از ردیف‌ها و ستون‌های مخفی کاربرگ ترسیم می‌کند یا نه استفاده کنید. مقدار `true` را تنظیم کنید تا فقط سلول‌های قابل مشاهده ترسیم شوند، یا `false` تا هر دو سلول قابل مشاهده و مخفی شامل شوند. این تنظیم تنها بر ترسیم نمودار تاثیر دارد؛ ردیف‌ها یا ستون‌های کاربرگ را مخفی یا آشکار نمی‌کند.

[نمونهٔ ارائه](hidden-source-data.pptx) شامل یک نمودار ستونی به عنوان اولین شکل در اسلاید اول است. کاربرگ تعبیه‌شده، `Sheet1`، محدوده منبع زیر را دارد: `A1:C4`. ردیف 3 و ستون C مخفی هستند، اما سلول‌های آن‌ها همچنان مقادیر دارند.

| ردیف کاربرگ | A: ماه | B: خرده‌فروشی | C: عمده‌فروشی (ستون مخفی) |
| --- | --- | --- | --- |
| 2 | ژانویه | 10 | 30 |
| 3 (ردیف مخفی) | فوریه | 40 | 60 |
| 4 | مارس | 20 | 50 |

به سلول‌های منبع از طریق [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی پیدا کنید و با خواندن [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) وضعیت مخفی بودن آن‌ها را بررسی کنید. این متد وضعیت مخفی بودن را بدون تغییر آن گزارش می‌دهد. در این فایل، B2 قابل مشاهده است، B3 به ردیف مخفی تعلق دارد و C2 به ستون مخفی؛ مثال به ترتیب `false`، `true` و `true` چاپ می‌کند.

برای این مثال، پس از تغییر تنظیم ترسیم، دادهٔ نمودار را تازه کنید: کتاب‌کار تعبیه‌شده را با [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) حفظ کنید و با [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) مجدداً بارگذاری کنید. هنگام شامل کردن تمام سلول‌ها، همچنین از [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) برای بازگرداندن محدوده کامل، شامل دستهٔ مخفی فوریه، استفاده کنید. تنها تغییر پرچم برای تازه‌سازی دادهٔ کش‌شدهٔ این نمونه کافی نیست.

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

            // داده‌های نمودار را از کتاب‌کار تعبیه‌شده تازه کنید.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // محدودهٔ منبع کامل را بازیابی کنید، شامل دسته‌های مخفی.
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

مثال دو نسخه از ارائه را ذخیره می‌کند: یکی فقط با مقادیر خرده‌فروشی قابل مشاهده (10 و 20)، و دیگری با همهٔ شش مقدار. تصاویر زیر دو حالت ترسیم را نشان می‌دهند. ردیف 3 و ستون C در هر دو کتاب‌کار تعبیه‌شده مخفی باقی می‌مانند.

| فقط سلول‌های قابل مشاهده (`true`) | همهٔ سلول‌ها (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

یک سلول مخفی که دارای مقدار است متفاوت از یک سلول خالی است. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) کنترل می‌کند مقادیر مفقود چگونه نمایش داده شوند؛ این متد منبع دادهٔ مخفی را شامل یا حذف نمی‌کند. برای مثال به [Control the Display of Empty Cells](/slides/fa/androidjava/chart-series/#control-the-display-of-empty-cells) مراجعه کنید.

## **بازیابی محدودهٔ دادهٔ یک نمودار**

پیش از به‌روزرسانی داده‌های کتاب‌کار در یک ارائهٔ موجود، محدوده‌های منبع را بررسی کنید تا تشخیص دهید هر نمودار از کدام سلول‌های کاربرگ استفاده می‌کند. متد [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) محدودهٔ فعلی داده را به صورت یک فرمول مش qualified کاربرگ برمی‌گرداند، مثل `Sheet1!$A$1:$D$5`. در اینجا، `Sheet1` نام کاربرگ است، `!` آن را از محدوده سلول‌ها جدا می‌کند و `$A$1:$D$5` سلول‌های A1 تا D5 را به صورت شامل می‌سازد. علامت دلار نشان‌دهندهٔ ارجاع مطلق به ردیف و ستون است.

این متد محدودهٔ فعلی را بدون تغییر نمودار یا کتاب‌کار می‌خواند. اگر نمودار از کتاب‌کاری به عنوان منبع داده استفاده نکند، `InvalidOperationException` پرتاب می‌شود. برای اطلاعات بیشتر، به [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/) نگاه کنید.

این مثال یک ارائه را باز می‌کند و شکل‌ها را مستقیماً در هر اسلاید برای نمودارها بررسی می‌کند. نام هر نمودار و محدودهٔ منبع آن را چاپ می‌کند. اگر نمودار از کتاب‌کار استفاده نکند، پیغامی چاپ می‌کند و به نمودار بعدی ادامه می‌دهد.

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

## **خواندن و نوشتن دادهٔ نمودار از یک کتاب‌کار**

Aspose.Slides for Android via Java متدهای [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) و [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) را فراهم می‌کند که به شما اجازه می‌دهد کتاب‌کارهای دادهٔ نمودار (حاوی داده‌های ویرایش‌شده با Aspose.Cells) را بخوانید و بنویسید. **توجه** داشته باشید که دادهٔ نمودار باید به همان شکل سازماندهی شده باشد یا ساختاری مشابه منبع داشته باشد.

این مثال از یک ارائه با یک نمودار به عنوان اولین شکل در اسلاید اول استفاده می‌کند. کتاب‌کار تعبیه‌شده را به یک آرایهٔ بایت می‌خواند، سری‌ها و دسته‌های موجود را پاک می‌کند و همان کتاب‌کار را دوباره می‌نویسد. تغییرات در حافظه می‌مانند؛ مثال ارائه را ذخیره نمی‌کند.

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

هنگامی که کتاب‌کار تعبیه‌شده را با یک کتاب‌کار اصلاح‌شده جایگزین می‌کنید، نمودار مجموعهٔ سری‌ها و دسته‌های اصلی خود را حفظ می‌کند. این ناهماهنگی می‌تواند باعث شود [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) با خطای «index-out-of-range» شکست بخورد. قبل از نوشتن کتاب‌کار به‌روزرسانی‌شده، سری‌ها و دسته‌های موجود را پاک کنید. این مثال از یک نمودار که اولین شکل در اسلاید اول است استفاده می‌کند. نظرات نشان می‌دهند که ویرایش کتاب‌کار در کجا انجام می‌شود؛ مثال قابل اجرا کتاب‌کار اصلی را برمی‌گرداند و چیدمان را در حافظه اعتبارسنجی می‌کند.

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

پاک‌کردن مجموعه‌ها قبل از نوشتن کتاب‌کار، ارجاعات دادهٔ منسوخ را حذف می‌کند. قبل از استفاده از نمودار، هر سری و نگاشت دستهٔ مورد نیاز را برای کتاب‌کار به‌روزرسانی‌شده بازسازی کنید.

## **انتخاب نحوهٔ ذخیرهٔ برچسب‌های دسته**

قبل از افزودن برچسب‌ها، بر روی مجموعهٔ دستهٔ خالی متد [IChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategorycollection/#setUseCells-boolean-) را فراخوانی کنید. از سلول‌های کاربرگ برای برچسب‌هایی که به دادهٔ کتاب‌کار ارجاع می‌دهند یا سلسله‌مراتبی مثل فصول سال تشکیل می‌شوند استفاده کنید. برای برچسب‌های تک‌سطح که نیازی به ارجاع به سلول ندارند، از مقدارهای رشته‌ای استفاده کنید. این تنظیم فقط بر دسته‌ها اعمال می‌شود. هر دو نمودار در مثال از سلول‌های کاربرگ برای مقادیر عددی سری‌ها استفاده می‌کنند.

مثال دو نمودار ستونی ایجاد می‌کند و حالت ذخیره‌سازی را به همراه `Q1 Q2 Q3 Q4` برای هر کدام چاپ می‌کند. برای برچسب‌های مبتنی بر کاربرگ، [IChartCategory.getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/#getAsCell--) سلول پایه را برمی‌گرداند و [IChartDataCell.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getValue--) برچسب آن را می‌دهد. برای برچسب‌های ثابت، مقدار رشته‌ای را مستقیماً با [IChartCategory.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/#getValue--) بخوانید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    for (boolean useCells : new boolean[] {true, false}) {
        int x = useCells ? 20 : 360;
        IChart chart = shapes.addChart(ChartType.ClusteredColumn, x, 20, 320, 250);
        IChartData data = chart.getChartData();
        data.getSeries().clear();
        IChartCategoryCollection categories = data.getCategories();
        categories.clear();
        categories.setUseCells(useCells);

        IChartDataWorkbook workbook = data.getChartDataWorkbook();
        IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
        IChartSeries series = data.getSeries().add(seriesName, chart.getType());
        for (int row = 1; row <= 4; row++) {
            String label = "Q" + row;
            if (useCells) {
                IChartDataCell labelCell = workbook.getCell(0, row, 0, label);
                categories.add(labelCell);
            } else {
                categories.add(label);
            }

            IChartDataCell valueCell = workbook.getCell(0, row, 1, row * 10);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        System.out.print("UseCells = " + categories.getUseCells() + ":");
        for (IChartCategory category : categories) {
            Object label = categories.getUseCells() ? category.getAsCell().getValue() : category.getValue();
            System.out.print(" " + label);
        }
        System.out.println();
    }

    presentation.save("category-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم قالب عددی سفارشی برای سلول‌های کتاب‌کار**

از [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) برای کنترل نحوهٔ نمایش مقادیر عددی در کتاب‌کار تعبیه‌شدهٔ نمودار استفاده کنید. برای مثال، یک گزارش ممکن است نیاز داشته باشد نرخ تبدیل به صورت درصد با چهار رقم اعشار و یک ضریب با پنج رقم اعشار نمایش داده شود. هر دو مقدار را عددی نگه دارید تا برای محاسبات و ترسیم نمودار در دسترس باشند.

قالب عددی فقط نمایش را تغییر می‌دهد، نه مقدار ذخیره‌شده. قالب `0.0000%` مقدار `0.125` را به صورت `12.5000%` نشان می‌دهد؛ مقدار ذخیره‌شده به `12.5` تبدیل نمی‌شود. به‌طور مشابه، `0.00000` مقدار `0.1234567` را به `0.12346` نمایش می‌دهد بدون اینکه مقدار ذخیره‌شده رند شود. اگر قالب سفارشی رشتهٔ خالی (`""`) باشد، قالبی که توسط [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) برگردانده می‌شود استفاده می‌شود.

مثال زیر یک نمودار ستونی ایجاد می‌کند و سلول‌های آن را از طریق [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) می‌دسترس‌کند. در کاربرگ 0، B2 شامل نرخ تبدیل و C2 شامل ضریب است. هر دو سلول مقدارهای نمودار را فراهم می‌کنند. مثال همچنین برچسب‌های مقدار را که به قالب‌های منبع پیوست شده‌اند فعال می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

قالب‌های سلول کتاب‌کار جدا از قالب‌های تنظیم‌شده مستقیم بر محورها یا برچسب‌های داده هستند. در این مثال، هر برچسب مقدار سلول منبع خود را نشان می‌دهد چون [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) روی `true` تنظیم شده و به قالب عددی منبع لینک شده چون [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) نیز روی `true` است. پس از ذخیره و بازگشایی ارائه، برچسب‌ها `12.5000%` و `0.12346` را نشان می‌دهند، همان‌طور که در زیر می‌بینید. محور عمودی قالب عددی خود را دارد که با [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) به `0.00` تنظیم شده و [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) روی `false` است.

برای قالب‌بندی مستقل یک برچسب داده، پرچم لینک به منبع آن را روی `false` بگذارید و با [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) قالبی اختصاص دهید. این کار قالب سلول کتاب‌کار را تغییر نمی‌دهد. برای مثال، قالب مستقل `0.00` مقدار اول را به `0.13` نشان می‌دهد، در حالی که B2 هنوز `12.5000%` است. برای قالب‌بندی مستقیم برچسب‌ها به [Chart Data Labels](/slides/fa/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) مراجعه کنید.

تصویر زیر پس از بازگشایی ارائه ذخیره‌شده رندر شده است:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **تخصیص یک سلول کتاب‌کار به عنوان برچسب دادهٔ نمودار**

می‌توانید از متن سلول‌های کتاب‌کار به عنوان برچسب‌های دادهٔ نمودار استفاده کنید.

این مثال یک نمودار حبابی با دادهٔ پیش‌فرض به اسلاید اول یک ارائهٔ موجود اضافه می‌کند. از سلول‌های A10:A12 در کاربرگ 0 برای اولین سه برچسب در اولین سری استفاده می‌کند، برچسب‌ها را از سلول‌ها فعال می‌کند و ارائه بروز‌رسانی‌شده را ذخیره می‌کند.

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

متد [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) دسترسی به کاربرگ‌های موجود در کتاب‌کار نمودار را فراهم می‌کند. این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و نام هر کاربرگ را در کنسول چاپ می‌کند.

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

مقادیر نقطهٔ سری می‌توانند مستقیماً به عنوان عددهای ثابت ذخیره شوند. برای مثال کامل که آنها را ذخیره و می‌خواند، به [Set Series Values Using Numeric Literals](/slides/fa/androidjava/chart-series/#set-series-values-using-numeric-literals) مراجعه کنید. نوع منبع مقادیر نقطه‌ای جدا از پیکربندی کتاب‌کار داخلی یا خارجی نمودار است؛ استفاده از عددهای ثابت به تنهایی کتاب‌کار تعبیه‌شده را حذف نمی‌کند.

این مثال یک نمودار ستونی 3‑بعدی با دادهٔ پیش‌فرض ایجاد می‌کند و دو نام سری را با منابع داده متفاوت تنظیم می‌کند. نام اول از یک عدد ثابت رشته‌ای استفاده می‌کند؛ نام دوم از سلول C1 در کاربرگ 0 می‌گیرد. شمارش [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) منبع هر نام را انتخاب می‌کند. مثال ارائه را با نام‌های سری بروز‌رسانی‌شده ذخیره می‌کند.

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

## **تشخیص قالب‌های کتاب‌کار تعبیه‌شدهٔ پشتیبانی‌نشده**

Aspose.Slides قالب کتاب‌کار باینری Excel (.xlsb) که می‌تواند در برخی نمودارها تعبیه شود را پشتیبانی نمی‌کند. می‌توانید با استفاده از متد [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) روی [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) به همراه شمارش [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) قالب‌های پشتیبانی‌نشده را شناسایی و آن نمودارها را نادیده بگیرید. این مثال شکل‌های اسلاید اول یک ارائهٔ موجود را بررسی می‌کند، اشکال غیرنمودار را رد می‌کند و برای هر نموداری که کتاب‌کار .xlsb تعبیه‌شده دارد، پیام تشخیص می‌دهد.

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

        // در اینجا داده‌های کتاب‌کار نمودار پشتیبانی‌شده را بخوانید یا اصلاح کنید.
    }
} finally {
    presentation.dispose();
}
```

## **کتاب‌کار خارجی**

Aspose.Slides از استفاده از کتاب‌کارهای خارجی به عنوان منبع داده برای نمودارها پشتیبانی می‌کند.

### **ایجاد یک کتاب‌کار خارجی**

از [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) و [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) برای خروجی‌گیری کتاب‌کار تعبیه‌شدهٔ نمودار به یک فایل و پیوست نمودار به آن کتاب‌کار خارجی استفاده کنید.

این مثال یک نمودار دایره‌ای با دادهٔ پیش‌فرض ایجاد می‌کند و کتاب‌کار آن را صادر می‌کند. پس از نوشتن کامل فایل، کتاب‌کار خارجی را به‌عنوان منبع دادهٔ نمودار اختصاص می‌دهد و ارائهٔ پیوست‌شده را ذخیره می‌کند.

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

با استفاده از متد [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) می‌توانید یک کتاب‌کار خارجی را به یک نمودار به عنوان منبع دادهٔ آن تخصیص دهید. این متد همچنین برای به‌روزرسانی مسیر کتاب‌کار خارجی (اگر جابجا شده باشد) قابل استفاده است.

در حالی که نمی‌توانید داده‌ها را در کتاب‌کارهایی که در مکان‌های راه دور یا منابع ذخیره شده‌اند ویرایش کنید، همچنان می‌توانید از چنین کتاب‌کارهایی به عنوان منبع دادهٔ خارجی استفاده کنید. اگر مسیر نسبی برای کتاب‌کار خارجی ارائه شود، به‌صورت خودکار به مسیر کامل تبدیل می‌شود.

این مثال از کتاب‌کار خارجی استفاده می‌کند که کاربرگ آن با نام `Sheet1` شامل نام سری در B1، نام دسته‌ها در A2:A4 و مقادیر عددی در B2:B4 است. مثال یک نمودار دایره‌ای ایجاد می‌کند، کتاب‌کار را پیوست می‌کند و با استفاده از [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) محدودهٔ A1:B4 را به یک سری و سه دسته اختصاص می‌دهد. ارائه با نمودار پیوست‌شده ذخیره می‌شود.

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

* وقتی `updateChartData` برابر `false` باشد، تنها مسیر کتاب‌کار به‌روزرسانی می‌شود. دادهٔ نمودار از کتاب‌کار هدف بارگذاری یا به‌روز نمی‌شود، به همین دلیل کتاب‌کار می‌تواند در دسترس نباشد.
* وقتی `updateChartData` برابر `true` باشد، دادهٔ نمودار از کتاب‌کار هدف به‌روز می‌شود.

مثال زیر یک URL به عنوان جایگزین با `updateChartData` برابر `false` اختصاص می‌دهد. دادهٔ پیش‌فرض نمودار دایره‌ای حفظ می‌شود و ارائه بدون بارگذاری کتاب‌کار در دسترس ذخیره می‌شود.

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

برای شناسایی کتاب‌کاری که به یک نمودار پیوست شده است، بررسی کنید آیا نمودار از منبع دادهٔ خارجی استفاده می‌کند و مسیر کتاب‌کار آن را بازیابی کنید.

این مثال اولین شکل در اسلاید اول یک ارائه با کتاب‌کار خارجی پیوست‌شده را بررسی می‌کند. اگر این شکل یک نمودار پیوست‌شده به کتاب‌کار خارجی باشد، متد [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) را در کنسول چاپ می‌کند. سپس یک نسخهٔ پشتیبان از ارائه ذخیره می‌شود.

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

می‌توانید داده‌های کتاب‌کارهای خارجی را همانند کتاب‌کارهای داخلی ویرایش کنید. وقتی کتاب‌کار خارجی قابل بارگذاری نباشد، استثنایی پرتاب می‌شود.

این مثال از یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی قابل دسترسی پیوست شده است استفاده می‌کند. مقدار نقطهٔ دادهٔ اول در سری اول را به 100 تنظیم می‌کند و ارائه بروز‌رسانی‌شده را ذخیره می‌کند. ویرایش مقادیر سلولی می‌تواند فایل XLSX خارجی پیوست‌شده را به‌روز کند، بنابراین برای حفظ کتاب‌کار اصلی از یک کپی استفاده کنید.

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

اگر یک نمودار از کتاب‌کار خارجی که موجود یا در دسترس نیست استفاده می‌کند، Aspose.Slides می‌تواند کتاب‌کار نمودار را از داده‌های کش‌شده در ارائه بازسازی کند. یک [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) ایجاد کنید، با فراخوانی [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)، و [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) را روی `true` قبل از باز کردن ارائه تنظیم کنید.

مثال زیر در جاوا کتاب‌کار داده‌ها را برای یک نمودار که اولین شکل در اسلاید اول است و به یک کتاب‌کار خارجی غیرقابل دسترسی اشاره دارد، بازیابی می‌کند. داده‌های بازیابی‌شده از طریق [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) و [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) دسترسی می‌شود:

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

        // در اینجا داده‌های کتاب‌کار بازیابی‌شده را بخوانید یا اصلاح کنید.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

اگر کتاب‌کار خارجی در دسترس نباشد و بازیابی غیرفعال باشد، Aspose.Slides استثنا پرتاب می‌کند. فقط زمانی که استفاده از داده‌های کش‌شدهٔ نمودار به‌عنوان یک گزینهٔ بازگشتی قابل قبول است، بازیابی را فعال کنید، زیرا کش ممکن است شامل تغییرات اعمال‌شده به کتاب‌کار خارجی پس از آخرین به‌روزرسانی ارائه نباشد.

## **پرسش‌های متداول**

**آیا می‌توانم تشخیص دهم که یک نمودار خاص به کتاب‌کار خارجی یا تعبیه‌شده پیوست شده است؟**

بله. یک نمودار دارای [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) و [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) است؛ اگر منبع یک کتاب‌کار خارجی باشد، می‌توانید مسیر کامل را بخوانید تا مطمئن شوید فایلی خارجی استفاده می‌شود.

**آیا مسیرهای نسبی به کتاب‌کارهای خارجی پشتیبانی می‌شوند و چگونه ذخیره می‌شوند؟**

بله. اگر مسیر نسبی مشخص کنید، به‌صورت خودکار به مسیر مطلق تبدیل می‌شود. ارائه مسیر مطلق را در فایل PPTX ذخیره می‌کند، بنابراین جابجایی کتاب‌کار ممکن است نیاز به به‌روزرسانی پیوند داشته باشد.

**آیا می‌توانم از کتاب‌کارهایی که بر روی منابع/اشتراک‌های شبکه قرار دارند استفاده کنم؟**

بله، چنین کتاب‌کارهایی می‌توانند به‌عنوان منبع دادهٔ خارجی استفاده شوند. با این حال، ویرایش مستقیم کتاب‌کارهای راه دور از طریق Aspose.Slides پشتیبانی نمی‌شود—آنها فقط می‌توانند به عنوان منبع استفاده شوند.

**آیا Aspose.Slides هنگام ذخیرهٔ ارائه، فایل XLSX خارجی را بازنویسی می‌کند؟**

ارائه یک [link to the external file](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ذخیره می‌کند. ویرایش داده‌های نمودار مبتنی بر سلول می‌تواند فایل XLSX محلی پیوست‌شده را نیز به‌روز کند. اگر نسخهٔ اصلی باید دست‌نخورده بماند، از یک کپی کتاب‌کار استفاده کنید.

**اگر فایل خارجی رمز عبور داشته باشد چه کار باید کرد؟**

Aspose.Slides هنگام پیوست‌کردن رمز عبور نمی‌گیرد. یک روش معمول این است که پیش از پیوست‌کردن حفاظت را حذف کنید یا یک نسخهٔ رمزگشایی‌شده (مثلاً با استفاده از [Aspose.Cells](https://reference.aspose.com/cells/java/)) تهیه کنید و به آن نسخه لینک دهید.

**آیا می‌توان چندین نمودار را به همان کتاب‌کار خارجی ارجاع داد؟**

بله. هر نمودار پیوند خود را ذخیره می‌کند. اگر همه به یک فایل اشاره کنند، به‌روزرسانی آن فایل در هر بار بارگذاری داده‌ها در تمام نمودارها منعکس خواهد شد.