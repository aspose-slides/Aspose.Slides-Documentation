---
title: تنسيق مخططات العروض التقديمية في Java
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
- حد مدور
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides للـ Java وارتقِ بعرض PowerPoint الخاص بك باستخدام محاور مخصصة، خطوط، تنسيقات رقمية، وحدود مخطط مدورة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تنسيق المخططات في عروض PowerPoint باستخدام Aspose.Slides. تُظهر كيفية تخصيص عناصر المخطط الرئيسية مثل المحاور، خطوط الشبكة، العناوين، الأساطير، منطقة الرسم، وتعبئة الجدران لتحسين مظهر البيانات وقابليتها للقراءة.

كما توضح كيفية تعيين خصائص الخط للنص داخل المخطط، تطبيق تنسيقات رقمية مسبقة على بيانات المخطط، وتمكين الزوايا المدورة لمنطقة المخطط. تُظهر هذه الأمثلة معاً كيفية التحكم في كلٍ من الأسلوب البصري وعرض البيانات للمخططات في العرض.

للتعبئات والحدود المنفصلة للفترات الصاعدة والهابطة، راجع [مثال مخطط الأسهم](/slides/ar/java/create-chart/#create-stock-charts).

## **تنسيق كيانات المخطط**

استخدم [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) لتنسيق عناوين المخطط، المحاور، خطوط الشبكة، الأساطير، ومنطقة الرسم. يخلق هذا المثال مخطط خط مع علامات وبيانات افتراضية، ثم يطبق أنماط نص وخط منفصلة على محور القيم ومحور الفئات. يتم تحديد أحجام الخطوط وعرض الخطوط بالنقاط؛ يتم تدوير تسميات الفئات بزاوية 45 درجة.

يستخدم محور القيم [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) بشكل مستقل عن الخلايا المصدر. يمتد مقياسه من -2 إلى 15، مع فواصل رئيسية بمقدار 2 وفواصل فرعية بمقدار 0.5. يجمع المثال أيضًا تنسيق النسبة المئوية مع [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) المعين إلى الآلاف، لذا عدّل هذه الإعدادات وفقًا لمعنى وحجم بياناتك. يبقى الأسطورة خارج منطقة الرسم لأن [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) يُستدعى بـ `false`. يتم تكوين تعبئة الجدار الخلفي والأرضية عبر [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) و[getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--)، لكن هذه الأسطح تكون مرئية فقط في المخططات ثلاثية الأبعاد.

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

## **تعيين خصائص الخط لمخطط**

عيّن حجم الخط الافتراضي لنص المخطط عبر [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--). يُنشئ المثال مخطط أعمدة متراكم بحجم خط 20 نقطة ويُمكّن تسميات القيم للسلسلة الأولى عبر [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). يمكن لعناصر النص ذات إعدادات الخط الصريحة الخاصة بها أن تتجاوز الإعداد الافتراضي للمخطط.

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

## **إعادة استخدام تنسيق إطار النص لأسطورة المخطط**

لمطابقة أسطورة مع عنوان الشريحة، عيّن خط العنوان عبر [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) في الفقرة الأولى. استدِع [copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) على التنسيق الذي تُرجعه أسطورة المخطط عبر [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iformattedtextcontainer/#getTextFormat--). ينسخ ذلك إعدادات إطار النص، وتنسيق الفقرة الأولى، وخصائص الخط الافتراضية لتلك الفقرة. يظل التنسيق المطبق مباشرة على أجزاء فردية أو على فقرات لاحقة محليًا للمصدر.

يستخدم المثال عنوانًا غامقًا بحجم 26 نقطة من خط Calibri باللون البحري كنموذج. بعد تنسيق الأسطورة، يستدِع [copyTo](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) لتطبيق نفس التنسيق على توضيح منفصل.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(new Color(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

في العرض المحفوظ، تتطابق الأسطورة والتوضيح مع العنوان في الحجم والوزن واللون. لا تزال الأسطورة تعرض أسماء السلاسل، بينما يحتفظ التوضيح بنصه الخاص. إذا كان هناك جزء في التوضيح له حجم خط صريح بالفعل، فإن ذلك الحجم يعلو على الخط الافتراضي المنسوخ.

| قبل النسخ | بعد النسخ |
| --- | --- |
| ![مخطط مبيعات ربع السنة مع تسميات أسطورة سوداء عادية وتوضيح أسود](legend-formatting-before.png) | ![نفس المخطط مع تسميات أسطورة زرقاء داكنة أكبر وغامقة وتوضيح مطابق](legend-formatting.png) |

## **تعيين التنسيق الرقمي**

استخدم [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) لتطبيق تنسيق رقم مدمج على خلايا دفتر عمل المخطط. يُنشئ هذا المثال مخطط أعمدة متراكم ببيانات افتراضية مدعومة بالخلايا، ويطبق مؤشر التنسيق 10 (`0.00%`) على خلية قيمة كل سلسلة. يغيّر ذلك طريقة عرض القيم في دفتر العمل دون تعديل الأرقام الأساسية؛ على سبيل المثال، تُعرض 0.25 كـ 25.00%. يمكن تكوين تنسيقات المحور وتنسيقات تسميات البيانات بشكل منفصل.

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

الجدول التالي يُدرج مؤشرات تنسيقات الأرقام المدمجة مع أمثلة تنسيقات Excel للغة الإنجليزية (الولايات المتحدة). قد تختلف سلاسل التنسيق وعرضها حسب التطبيق واللغة، خاصةً للعملات والتواريخ. بعض تنسيقات Excel تختلف أيضًا عن القيم الافتراضية في معيار OOXML، كما هو موضح في [ملاحظات تنفيذ تنسيق الأرقام من Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| الفهرس | التنسيق |
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

## **تعيين حدود مدورة لمنطقة المخطط**

استدعِ [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) بـ `true` لتقويس زوايا منطقة المخطط. يخلق المثال مخطط أعمدة متراكم ويستخدم [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) لتعيين حد صلب رمادي ونمط خط أحادي قبل حفظ العرض.

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

يمكن للمخطط أن يحتوي على أشكال مخصصة، مثل تعليق نصي يشرح حالة تقرير. الوصول إلى هذه الأشكال يتم عبر [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--)، المُدرج أيضاً تحت [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) في مرجع API للمخطط. المجموعة التي تُرجعها [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) تحتوي على الأشكال المملوكة للمخطط.

مربع نص عادي موضوع فوق المخطط ينتمي إلى الشريحة، حتى وإن بدا كجزء من المخطط. عندما يتم تجوال [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) يتم العثور على المخطط وأشكال الشريحة العادية، لكن لا يتم تعداد الأشكال الفردية داخل المخطط. عناوين المخطط وتسميات البيانات هي عناصر مخطط منفصلة، ليست تعليقات مخصصة في هذه المجموعة.

حمّل [chart-annotations.pptx](chart-annotations.pptx) وضعه في دليل العمل للتطبيق. تحتوي شريحته الأولى على مخطط مع تعليق غير مجمع مكتوب «Preliminary results»، وخط مملوك للمخطط، ومربع نص شريحة عادي مكتوب «Slide overlay». يجد المثال المخطط الأول على تلك الشريحة ويغير التعليق إلى «Final results» عندما يصبح التقرير جاهزًا للنشر. يتحقق من وجود مجموعة فارغة ويُعدّل فقط [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) الذي يحتوي على إطار نص غير فارغ تُرجعه [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) والنص المتوقع.

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

يبقى الخط والمربع النصي على الشريحة دون تغيير. تُظهر الصور التالية المدخل والنتيجة المحفوظة المفتوحة مجددًا:

| قبل التعديل | بعد التعديل |
| --- | --- |
| ![تعليق مخطط يقرأ Preliminary results](chart-annotations-before.png) | ![تعليق مخطط يقرأ Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
يفحص المثال فقط الأشكال المملوكة للمخطط على المستوى الأعلى. إذا كان التعليق داخل [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/)، فافحص مجموعة [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) الخاصة بذلك أيضًا. كرر ذلك بشكل متكرر للمجموعات المتداخلة، مطبقًا نفس فحوصات النص على الأشكال الفرعية. المجموعة نفسها حاوية؛ لا تُعاملها كصندوق نص.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تعيين تعبئات شبه شفافة للأعمدة/المناطق مع الحفاظ على حد غير شفاف؟**

نعم. يتم تكوين شفافية التعبئة والحد بشكل منفصل. وهذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، عطل المكونات غير الضرورية للتسمية (مثل الفئات)، اضبط موضع التسمية، أظهر التسميات فقط للنقاط المختارة إذا لزم الأمر، أو غيّر التنسيق إلى «القيمة + الأسطورة».

**هل يمكنني تطبيق تعبئات تدرجية أو نمطية للسلاسل؟**

نعم. تدعم السلاسل تعبئات صلبة، تدرجية، ونمطية. في الممارسة العملية، استخدم التدرجات بحذر وتجنب التركيبات التي تقلل التباين مع الشبكة والنص.