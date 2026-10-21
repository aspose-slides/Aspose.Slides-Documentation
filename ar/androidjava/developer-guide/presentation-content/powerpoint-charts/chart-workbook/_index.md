---
title: إدارة دفاتر عمل المخططات في العروض التقديمية على Android
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/androidjava/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- ملصق البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- مخبئ المخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "اكتشف Aspose.Slides for Android عبر Java: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint و OpenDocument لتبسيط بيانات العرض التقديمي الخاص بك."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع دفاتر عمل المخططات في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كملصقات بيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، استرجاع مسار دفتر عمل خارجي مرتبط بمخطط، وتعديل بيانات المخطط عندما يكون دفتر العمل متاحًا.

بالنسبة لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/androidjava/chart-series/) للحصول على الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي لأنماط العرض المتاحة.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) للتحكم فيما إذا كان المخطط يرسم البيانات من صفوف وأعمدة ورقة العمل المخفية. اضبطه على `true` لرسم الخلايا الظاهرة فقط، أو `false` لتضمين كل من الخلايا الظاهرة والمخفية. هذا الإعداد يتحكم في رسم المخطط؛ لا يخفي أو يُظهر صفوف أو أعمدة ورقة العمل.

[عرض تقديمي تجريبي](hidden-source-data.pptx) يحتوي على مخطط عمودي كأول شكل في شريحته الأولى. ورقة العمل المدمجة، `Sheet1`، تحتوي على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحتوي على قيم.

| صف ورقة العمل | A: شهر | B: تجزئة | C: جملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى خلايا المصدر عبر [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) وقراءة [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) لتفقد حالة إخفائها. هذه الطريقة تُبلغ عن حالة الإخفاء دون تغييرها. في هذا الملف، B2 مرئية، B3 تنتمي إلى الصف المخفي، وC2 تنتمي إلى العمود المخفي؛ المثال يطبع `false`، `true`، و`true` على التوالي.

في هذا المثال، قم بتحديث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المدمج باستخدام [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) وأعد تحميله باستخدام [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). عند تضمين كل الخلايا، استخدم أيضًا [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلامة غير كافٍ لتحديث بيانات المخطط المخزنة مؤقتًا وتسميات الفئات في هذا المثال.

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

            // تحديث بيانات المخطط من دفتر العمل المدمج.
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

يحفظ المثال نسختين من العرض التقديمي: واحدة تتضمن فقط قيم التجزئة الظاهرة (10 و 20)، والأخرى تتضمن جميع القيم الست. توضح الصور أدناه وضعيتَي الرسم. يظل الصف 3 والعمود C مخفيين في كلٍ من دفاتر العمل المدمجة.

| الخلايا الظاهرة فقط (`true`) | جميع الخلايا (`false`) |
| --- | --- |
| ![الخلايا الظاهرة فقط: قيم التجزئة 10 و 20 لشهري يناير ومارس.](hidden_cells_True.png) | ![جميع الخلايا: قيم التجزئة والجملة لشهري يناير وفبراير ومارس.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) في طريقة عرض القيم المفقودة؛ لا يتضمن أو يستبعد البيانات المصدر المخفية. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/androidjava/chart-series/#control-the-display-of-empty-cells) للحصول على مثال.

## **استخراج نطاق بيانات المخطط**

قبل تحديث بيانات دفتر العمل في عرض تقديمي موجود، افحص النطاقات المصدر لتحديد خلايا ورقة العمل التي يستخدمها كل مخطط. تُرجع طريقة [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) النطاق الحالي للبيانات كصيغة مؤهلة للورقة، مثل `Sheet1!$A$1:$D$5`. هنا، `Sheet1` هو اسم ورقة العمل، `!` يفصلها عن نطاق الخلايا، و`$A$1:$D$5` يحدد الخلايا من A1 إلى D5 شاملة. تشير علامات الدولار إلى مراجع مطلقة للصف والعمود.

تقرأ الطريقة النطاق الحالي دون تغيير المخطط أو دفتر عمله. إذا لم يستخدم المخطط دفتر عمل كمصدر بيانات، فإنها تُطلق استثناء `InvalidOperationException`. لمزيد من المعلومات، راجع [مرجع API لبيانات المخطط](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

يفتح هذا المثال عرض تقديمي ويفحص الأشكال مباشرةً على كل شريحة للعثور على المخططات. يطبع اسم كل مخطط ونطاقه المصدر. إذا لم يستخدم المخطط دفتر عمل، يطبع رسالة ويستمر إلى المخطط التالي.

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

يوفر Aspose.Slides for Android via Java طريقتي [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) و[writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) التي تسمح بقراءة وكتابة دفاتر عمل بيانات المخطط (المحتوية على بيانات مخطط تم تحريرها باستخدام Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب تنظيمها بنفس الطريقة أو أن تكون لها بنية مشابهة للمصدر.

يستخدم هذا المثال عرض تقديمي به مخطط كأول شكل في شريحته الأولى. يقرأ دفتر العمل المدمج إلى مصفوفة بايت، يمسّح السلاسل والفئات الحالية، ثم يكتب نفس دفتر العمل مرة أخرى. تبقى التغييرات في الذاكرة؛ لا يقوم المثال بحفظ العرض التقديمي.

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

### **تحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر عمل مدمج بآخر معدل، يحتفظ المخطط بسلاسل الفئات ومجموعات الفئات الأصلية. قد يتسبب هذا الاختلاف في فشل [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) مع خطأ "index-out-of-range". امسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدث إلى المخطط. يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى. تشير التعليقات إلى مكان تحرير دفتر العمل؛ يكتب المثال القابل للتنفيذ دفتر العمل الأصلي مرة أخرى ويُحقق من التخطيط في الذاكرة.

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

        // عدل بايتات دفتر العمل هنا، على سبيل المثال باستخدام Aspose.Cells.

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

إزالة المجموعات تُزيل مراجع البيانات القديمة قبل كتابة دفتر العمل مرة أخرى. أعد بناء أي سلاسل وفئات مطلوبة للدفتر المحدث قبل استخدام المخطط.

## **تعيين تنسيقات أرقام مخصصة لخلايا دفتر العمل**

استخدم [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) للتحكم في كيفية ظهور القيم الرقمية في دفتر عمل المخطط المدمج. على سبيل المثال، قد يتطلب تقرير معدل تحويل يُعرض كنسبة مئوية بأربع منازل عشرية ومعامل يُعرض بخمس منازل عشرية. احتفظ بالقيمتين كرقمين لتبقى متاحة للحسابات ورسم المخطط.

تغيّر تنسيق الرقم العرض، وليس القيمة المخزنة. يعرض التنسيق `0.0000%` القيمة `0.125` كـ `12.5000%`؛ لا يستبدل الرقم المخزن بـ `12.5`. بالمثل، يعرض `0.00000` القيمة `0.1234567` كـ `0.12346` دون تقريب القيمة المخزنة. إذا كان التنسيق المخصص سلسلة فارغة (`""`)، يُستخدم التنسيق الذي تُرجعه [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) بدلًا من ذلك.

يُنشئ المثال التالي مخططًا عموديًا ويصل إلى خلاياه عبر [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--). في ورقة العمل 0، يحتوي B2 على معدل التحويل وC2 على المعامل. كلا الخليتين تزودان المخطط بالقيم. يُمكّن المثال أيضًا ملصقات القيم المرتبطة بتنسيقات المصدر.

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

تنسيقات خلايا دفتر العمل منفصلة عن التنسيقات المحددة مباشرةً على محاور المخطط أو ملصقات البيانات. في هذا المثال، كل ملصق يعرض قيمة خليته المصدر لأن [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) مضبوط على `true`، ويتبع تنسيق الرقم المصدر لأن [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) مضبوط على `true`. بعد حفظ وإعادة فتح العرض التقديمي، تُظهر الملصقات `12.5000%` و`0.12346` كما هو موضح أدناه. يستخدم المحور الرأسي تنسيقًا رقميًا خاصًا به، محددًا بـ [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) كـ `0.00`، مع ضبط [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) إلى `false`.

لتنسيق ملصق بيانات بشكل مستقل، ضع علامة ربط المصدر إلى `false` وعين تنسيقًا بـ [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). لا يغيّر هذا تنسيق خلية دفتر العمل. على سبيل المثال، تنسيق ملصق مستقل بـ `0.00` يعرض القيمة الأولى كـ `0.13`، بينما ما يزال B2 يعرض `12.5000%`. راجع [ملصقات بيانات المخطط](/slides/ar/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) للتنسيق المباشر للملصق.

الصورة أدناه تم استخراجها من العرض التقديمي المحفوظ بعد إعادة فتحه:

![مخطط عمودي مع ملصقات مرتبطة بالمصدر تُظهر 12.5000% و0.12346 ومحور رقمي مُنسق بشكل مستقل.](custom-cell-formats.png)

## **تعيين خلية دفتر عمل كملصق بيانات للمخطط**

يمكنك استخدام النص من خلايا دفتر العمل كملصقات بيانات للمخطط.

يضيف هذا المثال مخطط فقاعات ببيانات افتراضية إلى الشريحة الأولى من عرض تقديمي موجود. يستخدم الخلايا A10:A12 في ورقة العمل 0 للملصقات الثلاثة الأولى في السلسلة الأولى، يمكّن الملصقات من الخلايا، ويحفظ العرض التقديمي المحدث.

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

توفر طريقة [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) إمكانية الوصول إلى أوراق العمل في دفتر عمل المخطط. يُنشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

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

يُنشئ هذا المثال مخططًا عموديًا ثلاثي الأبعاد ببيانات افتراضية ويحدد اسمي سلسلتين باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم قيمة نصية صريحة؛ الثاني يستخدم الخلية C1 في ورقة العمل 0. يحدِّد تعداد [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) المصدر لكل اسم. يحفظ المثال العرض التقديمي بأسماء السلاسل المحدثة.

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

## **اكتشاف تنسيقات دفاتر عمل مدمجة غير مدعومة**

لا يدعم Aspose.Slides تنسيق دفتر عمل Excel الثنائي (.xlsb) الذي يمكن تضمينه في بعض المخططات. يمكنك استخدام طريقة [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) على [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) لاكتشاف التنسيقات غير المدعومة وتجاوز تلك المخططات. يفحص هذا المثال الأشكال في الشريحة الأولى من عرض تقديمي موجود، يتخطى الأشكال غير المخططة، ويطبع رسالة تشخيصية لكل مخطط يحتوي على دفتر عمل .xlsb مدمج.

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

استخدم [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) و[setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) لتصدير دفتر عمل مخطط مدمج إلى ملف وربط المخطط بذلك الدفتر الخارجي.

يُنشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويصدر دفتر عمله. يُكمل عملية كتابة الملف قبل تعيين دفتر العمل الخارجي كمصدر بيانات للمخطط، ثم يحفظ العرض التقديمي المرتبط.

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

### **تعيين دفتر عمل خارجي**

باستخدام طريقة [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)، يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (في حال تم نقل الملف).

على الرغم من عدم إمكانية تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد بعيدة، يمكنك الاستمرار في استخدام هذه الدفاتر كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يستخدم هذا المثال دفتر عمل خارجي حيث تحتوي ورقة العمل المسماة `Sheet1` على اسم سلسلة في B1، أسماء فئات في A2:A4، وقيم رقمية في B2:B4. يُنشئ المثال مخططًا دائريًا، يربط الدفتر، ويستخدم [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) لتعيين A1:B4 كسلسلة واحدة وثلاث فئات. يحفظ العرض التقديمي بالمخطط المرتبط.

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

تتحكم معلمة `updateChartData` لطريقة [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) فيما إذا كان يتم تحميل دفتر العمل.

* عندما تكون `updateChartData` `false`، يتم تحديث مسار دفتر العمل فقط. لا يتم تحميل بيانات المخطط أو تحديثها من دفتر العمل الهدف، لذا يمكن أن يكون دفتر العمل غير متاح.
* عندما تكون `updateChartData` `true`، يتم تحديث بيانات المخطط من دفتر العمل الهدف.

يعين المثال التالي عنوان URL نائب مع ضبط `updateChartData` إلى `false`. يحتفظ بالبيانات الافتراضية للمخطط الدائري ويحفظ العرض التقديمي دون تحميل دفتر العمل غير المتاح.

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

### **الحصول على مسار دفتر العمل المصدر الخارجي لمخطط**

لتحديد دفتر العمل المرتبط بمخطط، تحقق مما إذا كان المخطط يستخدم مصدر بيانات خارجي واستخرج مسار دفتر العمل.

يفحص هذا المثال الشكل الأول في الشريحة الأولى من عرض تقديمي يحتوي على دفتر عمل خارجي مرتبط. إذا كان مخططًا مرتبطًا بدفتر عمل خارجي، يطبع [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) إلى وحدة التحكم. ثم يحفظ نسخة من العرض التقديمي.

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

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تجري بها تغييرات على محتويات الدفاتر الداخلية. عند عدم القدرة على تحميل دفتر عمل خارجي، يتم إطلاق استثناء.

يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى ومربوطًا بدفتر عمل خارجي متاح. يضبط قيمة النقطة البيانية الأولى في السلسلة الأولى إلى 100 ويحفظ العرض التقديمي المحدث. يمكن لتعديل قيم الخلايا تحديث ملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كنت تحتاج إلى الحفاظ على دفتر العمل الأصلي.

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

### **استعادة دفتر عمل من ذاكرة مخطط مؤقتة**

إذا كان مخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)، استدعِ [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)، واضبط [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) على `true` قبل فتح العرض التقديمي.

يعيد مثال Java التالي استعادة بيانات دفتر العمل لمخطط هو الشكل الأول في الشريحة الأولى ويشير إلى دفتر عمل خارجي غير متاح. يصل إلى البيانات المستعادة عبر [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) و[IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، يطلق Aspose.Slides استثناء. فعّل الاستعادة فقط عندما تكون استخدام البيانات المخزنة مؤقتًا للمخطط خيارًا مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد تحديث العرض التقديمي آخر مرة.

## **الأسئلة الشائعة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبط بدفتر عمل خارجي أو مدمج؟**

نعم. يمتلك المخطط [نوع مصدر البيانات](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف يتم تخزينها؟**

نعم. إذا حددت مسارًا نسبيًا، يتم تحويله تلقائيًا إلى مسار مطلق. يخزن العرض التقديمي المسار المطلق في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الرابط.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكية؟**

نعم، يمكن استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم تحرير دفاتر العمل البعيدة مباشرةً من Aspose.Slides—يمكن استخدامها فقط كمصدر.

**هل تقوم Aspose.Slides باستبدال ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

يخزن العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). يمكن لتحرير بيانات المخطط المدعومة بخلايا أيضًا تحديث ملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان من الضروري الحفاظ على الأصل دون تعديل.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

لا تقبل Aspose.Slides كلمة مرور عند الربط. عادةً ما يُزال الحماية مسبقًا أو يُجهَّز نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](https://reference.aspose.com/cells/java/)) وربط تلك النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. يخزن كل مخطط رابطه الخاص. إذا أشاروا جميعًا إلى نفس الملف، فإن تحديث ذلك الملف سينعكس على كل مخطط في المرة التالية التي تُحمَّل فيها البيانات.