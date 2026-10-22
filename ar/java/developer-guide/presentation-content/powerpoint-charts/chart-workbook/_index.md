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
- تسمية البيانات
- ورقة عمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة مخطط مؤقتة
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides for Java: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات العرض التقديمي."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع دفاتر العمل الخاصة بالمخططات في Aspose.Slides. وتظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر العمل الخارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، استرداد مسار دفتر العمل الخارجي المرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/java/chart-series/) للحصول على الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي لأوضاع العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) للتحكم فيما إذا كان المخطط يرسم بيانات من صفوف وأعمدة ورقة العمل المخفية. اضبطه على `true` لرسم الخلايا المرئية فقط، أو على `false` لتضمين كل من الخلايا المرئية والمخفية. هذا الإعداد يتحكم في رسم المخطط؛ ولا يخفي أو يظهر صفوف أو أعمدة ورقة العمل.

العرض التوضيحي [العرض التوضيحي](hidden-source-data.pptx) يحتوي على مخطط عمودي كأول شكل في شريحته الأولى. ورقة العمل المضمّنة، `Sheet1`، تحتوي على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحتوي على قيم.

| صف ورقة العمل | A: الشهر | B: التجزئة | C: الجملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

يمكنك الوصول إلى خلايا المصدر عبر [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) وقراءة [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) لفحص حالتها المخفية. هذه الطريقة تُبلغ عن الحالة المخفية دون تغييرها. في هذا الملف، B2 مرئية، B3 تنتمي إلى الصف المخفي، وC2 تنتمي إلى العمود المخفي؛ المثال يطبع `false`، `true`، و`true` على التوالي.

في هذا المثال، قم بتحديث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المضمّن باستخدام [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) وأعد تحميله باستخدام [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). عند تضمين كل الخلايا، استخدم أيضًا [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلامة غير كافٍ لتحديث بيانات المخطط المخزنة مؤقتًا وعناوين الفئات في هذا العينة.

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
                // استعادة نطاق المصدر الكامل، بما في ذلك الفئات المخفية.
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

يحفظ المثال إصدارين من العرض: أحدهما يحتوي فقط على قيم التجزئة المرئية (10 و 20)، والآخر يحتوي على جميع القيم الستة. توضح الصور أدناه وضعا الرسم. يظل الصف 3 والعمود C مخفيين في كلا دفترَي العمل المضمنين.

| الخلايا المرئية فقط (`true`) | جميع الخلايا (`false`) |
| --- | --- |
| ![الخلايا المرئية فقط: قيم التجزئة 10 و 20 لشهري يناير ومارس.](hidden_cells_True.png) | ![جميع الخلايا: قيم التجزئة والجملة لشهري يناير وفبراير ومارس.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) في طريقة عرض القيم المفقودة؛ ولا يتضمن أو يستثني بيانات المصدر المخفية. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/java/chart-series/#control-the-display-of-empty-cells) لمثال.

## **استخراج نطاق بيانات المخطط**

قبل تحديث بيانات دفتر العمل في عرض موجود، افحص نطاقات المصدر لتحديد خلايا ورقة العمل التي يستخدمها كل مخطط. تُعيد الطريقة [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) النطاق الحالي للبيانات كصيغة مؤهلة لورقة العمل، مثل `Sheet1!$A$1:$D$5`. هنا، `Sheet1` هو اسم ورقة العمل، `!` يفصلها عن نطاق الخلايا، و`$A$1:$D$5` يحدد الخلايا من A1 إلى D5 شاملة. تشير علامات الدولار إلى مراجع صف وعمود مطلقة.

تقرأ الطريقة النطاق الحالي دون تغيير المخطط أو دفتر العمل الخاص به. إذا لم يستخدم المخطط دفتر عمل كمصدر بيانات، تُطلق `InvalidOperationException`. للمزيد، راجع [مرجع API لـ ChartData](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/).

يفتح هذا المثال عرضًا ويفحص الأشكال مباشرة على كل شريحة بحثًا عن المخططات. يطبع اسم كل مخطط ونطاق المصدر. إذا لم يستخدم المخطط دفتر عمل، يطبع رسالة ويستمر إلى المخطط التالي.

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

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides for Java الطرق [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) و[writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) التي تسمح بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات مخطط تم تعديلها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تكون منظمة بنفس الطريقة أو يجب أن يكون لها هيكل مشابه للمصدر.

يستخدم هذا المثال عرضًا يحتوي على مخطط كأول شكل في شريحته الأولى. يقرأ دفتر العمل المضمّن إلى مصفوفة بايت، يمسح السلاسل والفئات الموجودة، ثم يكتب نفس دفتر العمل مرة أخرى. تبقى التغييرات في الذاكرة؛ لا يقوم المثال بحفظ العرض.

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

عند استبدال دفتر عمل مضمّن بآخر معدل، يحتفظ المخطط بسلسلاته ومجموعات الفئات الأصلية. هذا الاختلاف قد يتسبب في فشل [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) مع خطأ "index-out-of-range". امسح السلاسل والفئات الموجودة قبل كتابة دفتر العمل المحدث مرة أخرى إلى المخطط. يستخدم هذا المثال مخططًا هو الشكل الأول على الشريحة الأولى. العلامة التعليقية توضح مكان تحرير دفتر العمل؛ المثال القابل للتنفيذ يكتب دفتر العمل الأصلي مرة أخرى ويُحقق من التخطيط في الذاكرة.

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

        // قم بتعديل بايتات دفتر العمل هنا، على سبيل المثال باستخدام Aspose.Cells.

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

يمسح حذف المجموعات مراجع البيانات القديمة قبل كتابة دفتر العمل. أعد بناء أي سلاسل أو خرائط فئات مطلوبة لدفتر العمل المحدث قبل استخدام المخطط.

## **تعيين صيغ أرقام مخصصة لخلايا دفتر العمل**

استخدم [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) للتحكم في كيفية ظهور القيم الرقمية في دفتر العمل المضمّن للمخطط. على سبيل المثال، قد يحتاج تقرير إلى عرض معدل التحويل كنسبة مئوية بأربعة منازل عشرية ومعامل بخمسة منازل عشرية. احتفظ بالقيمتين كأرقام لتظل متاحة للحسابات ورسم المخطط.

تغيّر صيغة الرقم العرض فقط، ولا تغير القيمة المخزنة. الصيغة `0.0000%` تُظهر `0.125` كـ `12.5000%`؛ ولا تستبدل الرقم المخزن بـ `12.5`. بالمثل، `0.00000` تُظهر `0.1234567` كـ `0.12346` دون تقريب القيمة المخزنة. إذا كان الصيغة المخصصة سلسلة فارغة (`""`)، تُستخدم الصيغة التي تُعيدها [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) بدلاً منها.

المثال التالي ينشئ مخططًا عموديًا ويصل إلى خلاياه عبر [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--). في ورقة العمل 0، يحتوي B2 على معدل التحويل وC2 على المعامل. كلتا الخليتين تزودان المخطط بالقيم. يُمكّن المثال أيضًا عناوين القيم المرتبطة بصيغ المصدر.

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

صيغ خلايا دفتر العمل منفصلة عن الصيغ المحددة مباشرة على محاور المخطط أو عناوين البيانات. في هذا المثال، يُظهر كل عنوان قيمة خلية المصدر لأن [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) مضبوطة على `true`، ويتبع صيغة الرقم المصدر لأن [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) مضبوطة على `true`. بعد حفظ وإعادة فتح العرض، يعرض العناوين `12.5000%` و`0.12346` كما هو موضح أدناه. يستخدم المحور الرأسي صيغة رقمية خاصة به، تم تعيينها بـ [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) كـ `0.00`، مع [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) مضبوطة على `false`.

لتنسيق عنوان بيانات بشكل مستقل، اضبط علم ربط المصدر إلى `false` وعيّن صيغة باستخدام [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). هذا لا يغيّر صيغة خلية دفتر العمل. على سبيل المثال، صيغة عنوان مستقل `0.00` تُظهر القيمة الأولى كـ `0.13`، بينما لا يزال B2 يُظهر `12.5000%`. راجع [Chart Data Labels](/slides/ar/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) لتنسيق العناوين مباشرة.

الصورة أدناه تم توليدها من العرض المحفوظ بعد إعادة فتحه:

![مخطط عمودي مع عناوين مرتبطة بالمصدر تُظهر 12.5000% و0.12346 ومحور رقمي مُنسق بشكل مستقل.](custom-cell-formats.png)

## **تعيين خلية دفتر عمل كعلامة بيانات للمخطط**

يمكنك استخدام النص من خلايا دفتر العمل كعناوين بيانات للمخطط.

يضيف هذا المثال مخطط فقاعة ببيانات افتراضية إلى الشريحة الأولى من عرض موجود. يستخدم الخلايا A10:A12 في ورقة العمل 0 للعلامات الثلاث الأولى في السلسلة الأولى، يُمكّن العناوين من الخلايا، ويحفظ العرض المحدث.

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

توفر الطريقة [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) وصولًا إلى أوراق العمل في دفتر عمل المخطط. ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل على وحدة التحكم.

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

يمكن أيضًا تخزين قيم نقاط السلسلة مباشرةً كقيم رقمية ثابتة. راجع [Set Series Values Using Numeric Literals](/slides/ar/java/chart-series/#set-series-values-using-numeric-literals) للحصول على مثال كامل يحفظها ويقرأها. نوع مصدر قيم النقاط منفصل عن تكوين دفتر العمل الداخلي أو الخارجي للمخطط؛ استخدام القيم الرقمية لا يزيل دفتر العمل المضمّن بذاته.

ينشئ هذا المثال مخططًا عموديًا ثلاثي الأبعاد ببيانات افتراضية ويعيّن اسمين للسلسلتين باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم سلسلة حرفية؛ الاسم الثاني يستخدم الخلية C1 في ورقة العمل 0. تحدد تعداد [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) المصدر لكل اسم. يحفظ المثال العرض مع أسماء السلاسل المحدثة.

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

## **اكتشاف تنسيقات دفتر العمل المضمّنة غير المدعومة**

لا تدعم Aspose.Slides تنسيق دفتر العمل الثنائي Excel (.xlsb) الذي يمكن تضمينه في بعض المخططات. يمكنك استخدام الطريقة [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) على [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) لاكتشاف التنسيقات غير المدعومة وتجاوز تلك المخططات. يفحص هذا المثال الأشكال على الشريحة الأولى من عرض موجود، يتخطى الأشكال غير المخططة، ويطبع رسالة تشخيصية لكل مخطط يحتوي على دفتر عمل .xlsb مضمّن.

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

        // قراءة أو تعديل بيانات دفتر عمل المخطط المدعومة هنا.
    }
} finally {
    presentation.dispose();
}
```

## **دفتر عمل خارجي**

يدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

استخدم [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) و[setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) لتصدير دفتر عمل مخطط مضمّن إلى ملف وربط المخطط بذلك الدفتر الخارجي.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويصدر دفتر عمله. يكمل كتابة الملف قبل تعيين دفتر العمل الخارجي كمصدر بيانات للمخطط، ثم يحفظ العرض المرتبط.

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

باستخدام الطريقة [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)، يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (إذا تم نقل الملف).

بينما لا يمكنك تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدة، لا يزال بإمكانك استخدامها كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتحول تلقائيًا إلى مسار كامل.

يستخدم هذا المثال دفتر عمل خارجي حيث تحتوي ورقة العمل المسماة `Sheet1` على اسم سلسلة في B1، أسماء فئات في A2:A4، وقيم رقمية في B2:B4. ينشئ المثال مخططًا دائريًا، يربط دفتر العمل، ويستخدم [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) لتعيين A1:B4 إلى سلسلة واحدة وثلاث فئات. يحفظ العرض مع المخطط المرتبط.

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

معامل `updateChartData` في [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) يتحكم فيما إذا كان دفتر العمل يُحمَّل.

* عندما تكون `updateChartData` `false`، يتم تحديث مسار دفتر العمل فقط. لا تُحمَّل بيانات المخطط أو تُحدَّث من دفتر العمل الهدف، لذا يمكن أن يكون دفتر العمل غير متاح.
* عندما تكون `updateChartData` `true`، تُحدَّث بيانات المخطط من دفتر العمل الهدف.

المثال التالي يعيّن عنوان URL نائب مع `updateChartData` مضبوطة على `false`. يحتفظ بالمخطط الدائري ببياناته الافتراضية ويحفظ العرض دون تحميل دفتر العمل غير المتاح.

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

### **الحصول على مسار دفتر العمل لمصدر البيانات الخارجي لمخطط**

لتحديد دفتر العمل المرتبط بمخطط، تحقق مما إذا كان المخطط يستخدم مصدر بيانات خارجي واسترد مسار دفتر العمل الخاص به.

يفحص هذا المثال الشكل الأول على الشريحة الأولى من عرض يحتوي على دفتر عمل خارجي مرتبط. إذا كان مخططًا مرتبطًا بدفتر عمل خارجي، يطبع [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) إلى وحدة التحكم. ثم يحفظ نسخة من العرض.

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

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تعدل بها محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يُرمى استثناء.

يستخدم هذا المثال مخططًا هو الشكل الأول على الشريحة الأولى ومرتبطًا بدفتر عمل خارجي يمكن الوصول إليه. يضبط القيمة المدعومة بالخلية للنقطة الأولى في السلسلة الأولى إلى 100 ويحفظ العرض المحدث. تحرير قيم الخلايا يمكن أن يحدث تحديثًا لملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كنت تحتاج إلى الحفاظ على دفتر العمل الأصلي.

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

### **استعادة دفتر عمل من ذاكرة مخزن المخطط**

إذا كان مخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض. أنشئ كائنًا من [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/)، استدعِ [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)، واضبط [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) إلى `true` قبل فتح العرض.

المثال التالي بلغة Java يستعيد بيانات دفتر العمل لمخطط هو الشكل الأول على الشريحة الأولى ويشير إلى دفتر عمل خارجي غير متاح. يصل إلى البيانات المستعادة عبر [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) و[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، تُرمى Aspose.Slides استثناء. فعّل الاستعادة فقط عندما تكون الاعتماد على بيانات المخطط المخزنة مؤقتًا مقبولًا، لأن الذاكرة قد لا تحتوي على تغييرات تم إجراؤها على دفتر العمل الخارجي بعد آخر تحديث للعرض.

## **الأسئلة المتداولة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أم مضمّن؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) و[مسار دفتر عمل خارجي](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)؛ إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتحول تلقائيًا إلى مسار مطلق. يخزن العرض المسار المطلق في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الارتباط.

**هل يمكن استخدام دفاتر عمل موجودة على موارد/مشاركات الشبكة؟**

نعم، يمكن استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يُدعم تحرير دفاتر العمل البعيدة مباشرةً من Aspose.Slides—يمكن فقط استخدامها كمصدر.

**هل overwrites Aspose.Slides ملف XLSX الخارجي عند حفظ العرض؟**

يخزن العرض [ارتباطًا بالملف الخارجي](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). يمكن أيضًا لتعديل بيانات المخطط المدعومة بخلية أن يُحدِّث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان يجب إبقاء الأصل دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. النهج الشائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (مثلاً باستخدام [Aspose.Cells](https://reference.aspose.com/cells/java/)) وربطها بتلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. يخزن كل مخطط رابطه الخاص. إذا كان جميعها تشير إلى نفس الملف، سَتنعكس أي تحديثات لذاك الملف في كل مخطط عند تحميل البيانات مرة أخرى.