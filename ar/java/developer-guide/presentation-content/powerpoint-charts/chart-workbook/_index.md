---
title: إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام Java
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/java/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- علامة البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- مخزن المخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides للـ Java: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات العرض التقديمي الخاصة بك."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية العمل مع دفاتر العمل الخاصة بالمخططات في Aspose.Slides. توضح كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر العمل الخارجية كمصادر بيانات للمخططات. تُظهر الأمثلة كيفية إنشاء دليل عمل خارجي وتعيينه، واسترجاع مسار دفتر العمل الخارجي المرتبط بمخطط، وتحرير بيانات المخطط عندما يكون دفتر العمل متاحًا.

لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/java/chart-series/) لمعرفة الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط الخطوط لأوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) للتحكم فيما إذا كان المخطط يرسم البيانات من صفوف وأعمدة ورقة العمل المخفية. اضبطه على `true` لرسم الخلايا الظاهرة فقط، أو `false` لتضمين كل من الخلايا الظاهرة والمخفية. هذا الإعداد يتحكم في رسم المخطط؛ لا يخفى أو يظهر صفوف أو أعمدة ورقة العمل.

حمّل [hidden-source-data.pptx](hidden-source-data.pptx) وضعه في دليل العمل. يحتوي الشريحة الأولى على مخطط عمودي كأول شكل. ورقة العمل المدمجة، `Sheet1`، تحتوي على النطاق المصدر `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما ما زالت تحتوي على قيم.

| صف ورقة العمل | A: الشهر | B: التجزئة | C: الجملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى خلايا المصدر عبر [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) وقراءة [IChartDataCell.isHidden](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdatacell/#isHidden--) لتفحص حالة الإخفاء. هذه الطريقة تُبلغ عن حالة الإخفاء دون تغييرها. في هذا الملف، B2 ظاهر، B3 ينتمي إلى الصف المخفي، وC2 ينتمي إلى العمود المخفي؛ المثال يطبع `false`، `true`، و`true` على التوالي.

في هذا المثال، حدّث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المدمج باستخدام [readWorkbookStream](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#readWorkbookStream--) وأعد تحميله باستخدام [writeWorkbookStream](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). عند تضمين كل الخلايا، استخدم أيضًا [setRange](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلم غير كافٍ لتحديث بيانات المخطط المخزنة مؤقتًا وعناوين الفئات في هذا المثال.

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

            // تحديث بيانات المخطط من دفتر العمل المضمّن.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // استعادة النطاق المصدر الكامل، بما في ذلك الفئات المخفية.
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

يحفظ المثال `hidden_cells_true.pptx` بالقيم التجزئة الظاهرة فقط (10 و20)، و`hidden_cells_false.pptx` بكل القيم الست. توضح الصور أدناه وضعيتَي الرسم. الصف 3 والعمود C يظلان مخفيين في كل من دفاتر العمل المدمجة.

| الخلايا الظاهرة فقط (`true`) | كل الخلايا (`false`) |
| --- | --- |
| ![الخلايا الظاهرة فقط: قيم التجزئة 10 و20 لشهري يناير ومارس.](hidden_cells_True.png) | ![كل الخلايا: قيم التجزئة والجملة لشهري يناير، فبراير، ومارس.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) في طريقة عرض القيم المفقودة؛ لا يضيف أو يستثني بيانات المصدر المخفية. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/java/chart-series/#control-the-display-of-empty-cells) لمثال.

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides for Java طريقتي [readWorkbookStream](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#readWorkbookStream--) و[writeWorkbookStream](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) اللتين تسمحان لك بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تعديلها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو أن يكون لها بنية مماثلة للمصدر.

يفتح هذا المثال `chart.pptx`، والذي يجب أن يحتوي على مخطط كأول شكل في شريحته الأولى. يقرأ دفتر العمل المدمج إلى مصفوفة بايت، يمسح السلاسل والفئات الحالية، ويكتب نفس دفتر العمل مرة أخرى. تظل التغييرات في الذاكرة؛ لا يقوم المثال بحفظ العرض التقديمي.

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

### **التحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مدمج بآخر معدل، يحتفظ المخطط بمجموعة السلاسل والفئات الأصلية. هذا الاختلاف قد يؤدي إلى فشل [IChart.validateChartLayout](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/#validateChartLayout--) مع خطأ "فهرس خارج النطاق". امسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدث مرة أخرى إلى المخطط. يتطلب هذا المثال `chart.pptx` مع مخطط كأول شكل في شريحته الأولى. العلامة التعليقية تشير إلى مكان تحرير دفتر العمل؛ يكتب المثال دفتر العمل الأصلي مرة أخرى ويتحقق من التخطيط في الذاكرة.

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

        // تعديل بايتات دفتر العمل هنا، على سبيل المثال باستخدام Aspose.Cells.

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

يمسح حذف المجموعات مراجع البيانات القديمة قبل كتابة دفتر العمل. أعد بناء أي سلاسل أو تعيينات فئة مطلوبة لدفتر العمل المحدث قبل استخدام المخطط.

## **تعيين خلية دفتر عمل كعنوان بيانات المخطط**

يمكنك استخدام النص من خلايا دفتر العمل كعناوين بيانات المخطط. توضح الخطوات التالية كيفية ربط العناوين في مخطط الفقاع بالخلايا في دفتر بياناته.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
1. الوصول إلى الشريحة الأولى عبر الفهرس الصفري.
1. إضافة مخطط فقاعي ببيانات افتراضية.
1. الوصول إلى سلسلة المخطط.
1. تعيين خلية دفتر العمل كعنوان بيانات.
1. حفظ العرض التقديمي.

يفتح هذا المثال `chart2.pptx`، والذي يجب أن يحتوي على شريحة واحدة على الأقل، ويضيف مخطط فقاعي ببيانات افتراضية. يستخدم الخلايا A10:A12 في ورقة العمل 0 للعلامات الثلاث الأولى في السلسلة الأولى، يفعّل العناوين من الخلايا، ويحفظ النتيجة إلى `resultchart.pptx`.

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

## **إدارة أوراق العمل**

توفر طريقة [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) إمكانية الوصول إلى أوراق العمل في دفتر عمل المخطط. ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

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

## **تحديد نوع مصدر البيانات**

ينشئ هذا المثال مخططًا عموديا ثلاثي الأبعاد ببيانات افتراضية ويعيّن اسمين للسلاسل باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم حرفًا ثابتًا؛ الثاني يستخدم الخلية C1 في ورقة العمل 0. تختار تعداد [DataSourceType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/datasourcetype/) المصدر لكل اسم. تُحفظ النتيجة إلى `pres.pptx`.

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

## **الكشف عن صيغ دفاتر العمل المدمجة غير المدعومة**

لا يدعم Aspose.Slides صيغة دفتر العمل الثنائي Excel (.xlsb) التي يمكن تضمينها في بعض المخططات. يمكنك استخدام طريقة [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) على [IChartData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/) جنبًا إلى جنب مع تعداد [WorkbookType](https://reference.aspose.com/slides/ar/java/com.aspose.slides/workbooktype/) للكشف عن الصيغ غير المدعومة وتجاوز تلك المخططات. يفحص هذا المثال الأشكال في الشريحة الأولى من `sample.pptx`، يتخطى الأشكال غير المخططة، ويطبع رسالة تشخيصية لكل مخطط يحتوي على دفتر عمل .xlsb مدمج.

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

        // قراءة أو تعديل بيانات دفتر العمل للمخطط المدعومة هنا.
    }
} finally {
    presentation.dispose();
}
```

## **دفتر عمل خارجي**

يدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

استخدم [readWorkbookStream](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#readWorkbookStream--) و[setExternalWorkbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) لتصدير دفتر عمل مخطط مدمج إلى ملف وربط المخطط بذلك الدفتر الخارجي.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية، يكتب دفتر عمله إلى `externalWorkbook1.xlsx`، ويكمل كتابة الملف قبل تعيين الملف كمصدر بيانات للمخطط. يحفظ العرض التقديمي المرتبط إلى `externalWorkbook.pptx`.

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

### **تعيين دفتر عمل خارجي**

باستخدام طريقة [setExternalWorkbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) يمكنك تعيين دفتر عمل خارجي كمصدر بيانات للمخطط. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الملف).

على الرغم من أنك لا تستطيع تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدة، إلا أنه لا يزال بإمكانك استخدام such دفاتر العمل كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يتطلب هذا المثال وجود `externalWorkbook.xlsx` في دليل العمل. يجب أن تحتوي ورقة العمل المسماة `Sheet1` على اسم سلسلة في B1، أسماء فئات في A2:A4، وقيم رقمية في B2:B4. ينشئ المثال مخططًا دائريًا، يربط دفتر العمل، ويستخدم [setRange](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) لتعيين النطاق A1:B4 إلى سلسلة واحدة وثلاث فئات. يحفظ النتيجة إلى `Presentation_with_externalWorkbook.pptx`.

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

معامل `updateChartData` في طريقة [setExternalWorkbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) يتحكم فيما إذا كان يتم تحميل دفتر العمل.

* عندما تكون `updateChartData` `false`، يتم تحديث مسار دفتر العمل فقط. لا يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل المستهدف، وبالتالي يمكن أن يكون دفتر العمل غير متاح.
* عندما تكون `updateChartData` `true`، يتم تحديث بيانات المخطط من دفتر العمل المستهدف.

المثال التالي يعيّن عنوان URL نائب مع `updateChartData` مضبوطة على `false`. يحتفظ بالمخطط الدائري ببياناته الافتراضية ويحفظ العرض التقديمي دون تحميل دفتر العمل غير المتاح.

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

### **الحصول على مسار دفتر عمل المصدر الخارجي لمخطط**

لتحديد دفتر العمل المرتبط بمخطط، تحقق أولاً مما إذا كان المخطط يستخدم مصدر بيانات خارجي. إذا كان كذلك، يمكنك استرجاع مسار دفتر العمل باتباع الخطوات التالية.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/).
1. الوصول إلى الشريحة الأولى عبر الفهرس الصفري.
1. التأكد من أن الشكل الأول هو مخطط.
1. قراءة نوع مصدر بيانات المخطط.
1. إذا كان المصدر دفتر عمل خارجي، اقرأ مساره.

يفتح هذا المثال `externalWorkbook.pptx`، الذي تم إنشاؤه في المثال السابق، ويفحص الشكل الأول في الشريحة الأولى. إذا كان مخططًا مرتبطًا بدفتر عمل خارجي، يطبع المثال [getExternalWorkbookPath](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) إلى وحدة التحكم. ثم يحفظ نسخة من العرض التقديمي إلى `Result.pptx`.

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

### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تجري بها تغييرات على محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يتم إطلاق استثناء.

يتطلب هذا المثال وجود `presentation.pptx` مع مخطط كأول شكل في شريحته الأولى ودفتر عمل خارجي يمكن الوصول إليه. يعيّن قيمة الخلية للنقطة البيانات الأولى في السلسلة الأولى إلى 100 ويحفظ العرض التقديمي إلى `presentation_out.pptx`. يمكن لتحرير قيم الخلايا تحديث ملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كنت بحاجة إلى الحفاظ على دفتر العمل الأصلي.

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

### **استعادة دفتر عمل من ذاكرة التخزين المؤقت للمخطط**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متوفر، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/)، استدعِ [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)، واضبط [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) على `true` قبل فتح العرض التقديمي.

يفتح المثال التالي Java `presentation.pptx`، حيث يجب أن يكون الشكل الأول في الشريحة الأولى مخططًا يشير إلى دفتر عمل خارجي غير متوفر، ويصل إلى البيانات المستعادة عبر [IChart.getChartData](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichart/#getChartData--) و[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // قراءة أو تعديل بيانات دفتر العمل المستعاد هنا.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

إذا كان دفتر العمل الخارجي غير متوفر وتم تعطيل الاستعادة، يلقي Aspose.Slides استثناءً. فعّل الاستعادة فقط عندما يكون استخدام البيانات المخزنة مؤقتًا للمخطط هو خيار مقبول، لأن الذاكرة المؤقتة قد لا تحتوي على تغييرات أجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتكررة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبط بدفتر عمل خارجي أو مدمج؟**

نعم. للمخطط نوع مصدر بيانات [data source type](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chartdata/#getDataSourceType--) ومسار إلى دفتر عمل خارجي [path to an external workbook](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية إلى دفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتحول تلقائيًا إلى مسار مطلق. يخزن العرض التقديمي المسار المطلق في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الارتباط.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام such دفاتر العمل كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير دفاتر العمل البعيدة مباشرةً—يمكن استخدامها فقط كمصدر.

**هل يقوم Aspose.Slides باستبدال ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/ar/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). يمكن لتحرير بيانات المخطط المرتبطة بخلية أيضًا تحديث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان يجب إبقاء الأصل دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا يقبل كلمة مرور عند الربط. النهج الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](https://reference.aspose.com/cells/java/)) وربط تلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن ارتباطه الخاص. إذا أشاروا جميعًا إلى نفس الملف، سيظهر أي تحديث لذلك الملف في كل مخطط عند تحميل البيانات مرة أخرى.