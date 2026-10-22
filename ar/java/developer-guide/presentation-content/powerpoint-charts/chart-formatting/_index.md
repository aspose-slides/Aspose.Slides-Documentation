---
title: تنسيق مخططات العرض التقديمي في Java
linktitle: تنسيق المخطط
type: docs
weight: 60
url: /ar/java/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخطط
- كيان المخطط
- خصائص المخطط
- إعدادات المخطط
- خيارات المخطط
- خصائص الخط
- حدود مستديرة
- PowerPoint
- العرض التقديمي
- Java
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides for Java وارتقِ بعرض PowerPoint التقديمي الخاص بك باستخدام محاور مخصصة، خطوط، صيغ عددية، وحدود مخطط مستديرة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تنسيق المخططات في عروض PowerPoint باستخدام Aspose.Slides. تُظهر كيفية تخصيص العناصر الرئيسية للمخطط مثل المحاور، خطوط الشبكة، العناوين، وسائط الإيضاح، منطقة الرسم، وتعبئات الجدران لتحسين مظهر البيانات وقابليتها للقراءة.

كما تُظهر كيفية تعيين خصائص الخط لنص المخطط، وتطبيق صيغ رقمية مُعدة مسبقًا على بيانات المخطط، وتمكين الزوايا المستديرة لمنطقة المخطط. معًا، توضح هذه الأمثلة كيفية التحكم في كل من النمط البصري وعرض البيانات للمخططات في العرض.

## **تنسيق كيانات المخطط**

استخدم [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) لتنسيق عناوين المخطط، والمحاور، وخطوط الشبكة، ووسائط الإيضاح، ومنطقة الرسم. ينشئ هذا المثال مخططًا خطيًا مع علامات وبيانات افتراضية، ثم يطبق أنماط نصية وخطية منفصلة على محوري القيمة والفئة. يتم تحديد أحجام الخطوط وعرض الخطوط بالنقاط؛ تُدوَّر تسميات الفئات بزاوية 45 درجة.

يستخدم محور القيمة الدالة [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) بشكل مستقل عن الخلايا المصدرية. يمتد مقياسه من -2 إلى 15، مع فواصل رئيسية قدرها 2 وفواصل فرعية قدرها 0.5. يجمع المثال أيضًا تنسيق النسبة المئوية مع الدالة [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) المضبوطة على الآلاف، لذا يجب تعديل هذه الإعدادات لتتناسب مع معنى وحجم بياناتك. يبقى وسائط الإيضاح خارج منطقة الرسم لأن الدالة [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) تُستدعى مع `false`. يتم تكوين تعبئات الجدار الخلفي والأرضية عبر الدالتين [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) و [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--)، لكن هذه الأسطح تكون مرئية فقط في المخططات ثلاثية الأبعاد.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(new Color(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين خصائص الخط للمخطط**

قم بتعيين حجم الخط الافتراضي لنص المخطط عبر [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--). يُنشئ المثال مخطط أعمدة مُجمع بخط بحجم 20 نقطة ويفعل تسميات القيم للسلسلة الأولى عبر [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). يمكن لعناصر النص التي لديها إعدادات خط صريحة خاصة بها تجاوز الإعداد الافتراضي للمخطط.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تعيين الصيغة الرقمية**

استخدم الدالة [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) لتطبيق صيغة رقمية مدمجة على خلايا دفتر عمل المخطط. يُنشئ هذا المثال مخطط أعمدة مُجمع ببيانات افتراضية مدعومة بالخلايا ويطبق مؤشر الصيغة 10 (`0.00%`) على كل خلية قيمة للسلسلة. يغيّر هذا طريقة عرض القيم في دفتر العمل دون تغيير الأرقام الأساسية؛ على سبيل المثال، يتم عرض 0.25 كـ 25.00%. يمكن تكوين صيغ المحور وتسميات البيانات بشكل منفصل.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

القائمة التالية تعرض فهارس صيغ الأرقام المدمجة مع صيغ Excel النموذجية للغة الإنجليزية (الولايات المتحدة). قد تختلف سلاسل الصيغ وعرضها حسب التطبيق واللغة، خاصةً بالنسبة للعملات والتواريخ. تختلف بعض صيغ Excel أيضًا عن القيم الافتراضية في معيار OOXML، كما هو موضح في [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| الفهرس | الصيغة |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **تعيين حدود مستديرة لمنطقة المخطط**

استدعي الدالة [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) مع `true` لتقوّيم زوايا منطقة المخطط. يُنشئ المثال مخطط أعمدة مُجمع ويستخدم [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) لإعطاء حدودها لونًا رماديًا صلبًا ونمط خط واحد قبل حفظ العرض.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تحرير تعليقات المخطط الموجودة**

يمكن للمخطط أن يحتوي على أشكال مخصصة، مثل تعليقة نصية تشرح حالة التقرير. يمكن الوصول إلى هذه الأشكال عبر [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--)، المذكورة أيضًا تحت [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) في مرجع API للمخطط. المجموعة التي تُرجعها الدالة [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) تحتوي على الأشكال المملوكة للمخطط.

مربع النص العادي الموضوع فوق مخطط ينتمي إلى الشريحة، حتى وإن بدا كجزء من المخطط. يؤدي التكرار عبر [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) إلى العثور على المخطط والأشكال العادية في الشريحة، لكنه لا يسرد الأشكال الفردية داخل المخطط. عناوين المخطط وتسميات البيانات هي عناصر مخطط منفصلة، ليست تعليقات مخصصة في هذه المجموعة.

قم بتحميل [chart-annotations.pptx](chart-annotations.pptx) وضعه في دليل العمل الخاص بالتطبيق. يحتوي شريحته الأولى على مخطط مع تعليقة غير مُجمعة تحمل النص "النتائج الأولية"، وخط مملوك للمخطط، ومربع نص عادي في الشريحة يحمل النص "تراكب الشريحة". يجد المثال أول مخطط على تلك الشريحة ويغيّر التعليقة إلى "النتائج النهائية" عندما يكون التقرير جاهزًا للنشر. يتحقق من كون المجموعة فارغة ولا يقوم بتحرير سوى [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) ذات إطار نص غير فارغ يُرجعه [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) والنص المتوقع.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

يظل الخط ومربع النص في الشريحة دون تغيير. توضح الصور التالية الإدخال والنتيجة المحفوظة والمفتوحة مرة أخرى:

| قبل التحرير | بعد التحرير |
| --- | --- |
| ![تعليقة مخطط تقول النتائج الأولية](chart-annotations-before.png) | ![تعليقة مخطط تقول النتائج النهائية](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
يفحص المثال فقط الأشكال المملوكة للمخطط على المستوى الأعلى. إذا كان التعليق داخل [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/)، فافحص مجموعة [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) الخاصة بذلك التجمع كذلك. كرر ذلك بشكل متكرر للمجموعات المتداخلة، مطبقًا نفس فحوصات النص على الأشكال الفرعية. التجمع نفسه هو حاوية؛ لا تعامله كمربع نص.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تعيين تعبئات شبه شفافة للأعمدة/المناطق مع الحفاظ على الحدود غير شفافة؟**

نعم. يتم تكوين شفافية التعبئة والحدود بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصوير الكثيف.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

يمكن تقليل حجم الخط، أو تعطيل مكونات التسمية غير الضرورية (مثل الفئات)، أو تعديل موضع التسمية، أو إظهار التسميات فقط للنقاط المحددة إذا لزم الأمر، أو تغيير الصيغة إلى "القيمة + وسائط الإيضاح".

**هل يمكنني تطبيق تعبئات تدرجية أو نمطية على السلاسل؟**

نعم. تدعم السلاسل تعبئات صلبة، وتدرجية، ونمطية. في الممارسة العملية، يُنصح باستخدام التدرجات بحذر وتجنب الجمع بينها ما يقلل التباين مع الشبكة والنص.