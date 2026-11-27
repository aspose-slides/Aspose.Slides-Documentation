---
title: تنسيق مخططات العروض التقديمية في PHP
linktitle: تنسيق المخطط
type: docs
weight: 60
url: /ar/php-java/chart-formatting/
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
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم تنسيق المخططات في Aspose.Slides لـ PHP عبر Java وارتقِ بعرض PowerPoint الخاص بك باستخدام محاور مخصصة، خطوط، تنسيقات رقمية، وحدود مخطط مستديرة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تنسيق المخططات في عروض PowerPoint باستخدام Aspose.Slides. تُظهر كيفية تخصيص العناصر الرئيسية للمخطط مثل المحاور وخطوط الشبكة والعناوين والأساطير ومنطقة الرسم وتعبئات الجدران لتحسين مظهر وقراءة بيانات المخطط.

كما توضح كيف يمكن ضبط خصائص الخط لنص المخطط، وتطبيق تنسيقات رقمية مسبقة الإعداد على بيانات المخطط، وتفعيل الزوايا المستديرة لمنطقة المخطط. تُظهر هذه الأمثلة معًا كيفية التحكم في كل من النمط البصري وتقديم البيانات للمخططات في العرض التقديمي.

للحصول على تعبئات وحدود منفصلة للفترات الصاعدة والهابطة، راجع [مثال المخطط السهمي](/slides/ar/php-java/create-chart/#create-stock-charts).

## **تنسيق كائنات المخطط**

استخدم [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) لتنسيق عناوين المخطط والمحاور وخطوط الشبكة والأساطير ومنطقة الرسم. يُنشئ هذا المثال مخطط خط مع علامات وبيانات افتراضية، ثم يطبق أنماط نص وخط منفصلة على محوري القيمة والفئة. يتم تحديد أحجام الخطوط وعرض الخطوط بالنقاط؛ وتُدوَّر تسميات الفئة بزاوية 45 درجة.

يستخدم محور القيمة [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setNumberFormat) بشكل مستقل عن الخلايا المصدرية. يمتد مقياسه من -2 إلى 15، مع فواصل رئيسية قدرها 2 وفواصل ثانوية قدرها 0.5. يجمع المثال أيضًا تنسيق النسبة المئوية مع [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setDisplayUnit) المُضبط على الآلاف، لذا قم بتكييف هذه الإعدادات وفق معنى وحجم بياناتك. يبقى السطر الأسطوري خارج منطقة الرسم لأن [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#setOverlay) يُستدعى بـ `false`. تُضبط تعبئات الجدار الخلفي والأرضية عبر [getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getBackWall) و[getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getFloor)، لكن هذه الأسطح تُظهر فقط في المخططات ثلاثية الأبعاد.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LineDashStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\TickLabelPositionType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle::DashDot);

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");

    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);

    $chart->getAxes()->getVerticalAxis()->setMaxValue(15);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);

    $valueAxisText = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $valueAxisText->setFontBold(NullableBool::True);
    $valueAxisText->setFontHeight(16);
    $valueAxisText->setFontItalic(NullableBool::True);
    $valueAxisText->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkGreen);
    $valueAxisText->setLatinFont(new FontData("Times New Roman"));

    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valueAxisTitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valueAxisTitle->setText("Primary Axis");
    $valueAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valueAxisTitle->getPortionFormat()->setFontHeight(20);
    $valueAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valueAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 128, 0));
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);

    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $categoryAxisText = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $categoryAxisText->setFontBold(NullableBool::True);
    $categoryAxisText->setFontHeight(16);
    $categoryAxisText->setFontItalic(NullableBool::True);
    $categoryAxisText->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisText->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $categoryAxisText->setLatinFont(new FontData("Arial"));

    $chart->getAxes()->getHorizontalAxis()->setTitle(true);
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");

    $categoryAxisTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $categoryAxisTitle->setText("Sample Category");
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $categoryAxisTitle->getPortionFormat()->setFontHeight(20);
    $categoryAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $categoryAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);

    $legendText = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $legendText->setFontBold(NullableBool::True);
    $legendText->setFontHeight(16);
    $legendText->setFontItalic(NullableBool::True);
    $legendText->getFillFormat()->setFillType(FillType::Solid);
    $legendText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkRed);

    $chart->getLegend()->setOverlay(false);

    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setPresetColor(PresetColor::LightCyan);

    $presentation->save("FormattedChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعيين خصائص الخط لمخطط**

قم بتعيين حجم الخط الافتراضي لنص المخطط عبر [Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getTextFormat). ينشئ المثال مخطط أعمدة مجمّع بحجم خط 20 نقطة ويُفعّل تسميات القيم للسلسلة الأولى عبر [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue). يمكن لعناصر النص ذات إعدادات الخط الصريحة أن تتجاوز إعدادات المخطط الافتراضية.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **إعادة استخدام تنسيق إطار النص لوسيلة إيضاح المخطط**

لمطابقة الأسطورية مع عنوان الشريحة، اضبط خط العنوان عبر [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) في الفقرة الأولى. استدعِ [copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyFrom) على التنسيق المُرجع من [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#getTextFormat) الخاص بالأسطورية. ينقل ذلك إعدادات إطار النص، وتنسيق الفقرة الأولى، وخصائص الخط الافتراضية لتلك الفقرة. التنسيقات التي تُطبَّق مباشرةً على أجزاء منفردة أو على فقرات لاحقة تبقى محلية للمصدر.

يستخدم المثال عنوانًا بخط Calibri بنحو 26 نقطة، غامقًا ولونًا أزرقًا داكنًا كقالب. بعد تنسيق الأسطورية، يستدعي [copyTo](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyTo) لتطبيق نفس التنسيق على تسمية توضيحية منفصلة.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LegendPositionType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\StyleType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $heading = $shapes->addAutoShape(ShapeType::Rectangle, 40, 20, 640, 40, false);
    $sourceTextFrame = $heading->addTextFrame("Quarterly sales");
    $font = $sourceTextFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $font->setLatinFont(new FontData("Calibri"));
    $font->setFontHeight(26);
    $font->setFontBold(NullableBool::True);
    $font->getFillFormat()->setFillType(FillType::Solid);
    $font->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 32, 64, 96));

    $chart = $shapes->addChart(ChartType::ClusteredColumn, 40, 75, 640, 360);
    $chart->setStyle(StyleType::Style3);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->getCell(0, 0, 1)->setValue("Retail");
    $workbook->getCell(0, 0, 2)->setValue("Online");
    $workbook->getCell(0, 0, 3)->setValue("Wholesale");
    for ($quarter = 1; $quarter <= 4; $quarter++) {
        $workbook->getCell(0, $quarter, 0)->setValue("Q" . $quarter);
    }

    $chart->setLegend(true);
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $legendFormat = $chart->getLegend()->getTextFormat();
    $legendFormat->copyFrom($sourceTextFrame);

    $caption = $shapes->addAutoShape(ShapeType::Rectangle, 40, 460, 640, 40, false);
    $captionTextFrame = $caption->addTextFrame("Sales in millions of dollars");
    $legendFormat->copyTo($captionTextFrame);

    $presentation->save("legend-formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

في العرض التقديمي المحفوظ، تتطابق الأسطورية والتسمية مع العنوان في الحجم والوزن واللون. لا تزال الأسطورية تعرض أسماء السلاسل، وتحتفظ التسمية بنصها الخاص. إذا كان هناك جزء في التسمية يملك بالفعل حجم خط صريح، فإن ذلك الحجم يأخذ الأسبقية على الخط الافتراضي المنسوخ للفقرة.

| قبل النسخ | بعد النسخ |
| --- | --- |
| ![مخطط المبيعات ربع السنوي مع تسميات أسطورة سوداء عادية وتعليق أسود](legend-formatting-before.png) | ![نفس المخطط مع تسميات أسطورة أزرق داكن أكبر وغامق وتعليق مطابقة](legend-formatting.png) |

## **تعيين تنسيق الأرقام**

استخدم [ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setPresetNumberFormat) لتطبيق تنسيق رقم مدمج على خلايا دفتر عمل المخطط. يُنشئ هذا المثال مخطط أعمدة مجمّع ببيانات افتراضية مدعومة بالخلايا، ويُطبِّق فهرس التنسيق 10 (`0.00%`) على كل خلية قيمة سلسلة. يغيّر ذلك طريقة عرض القيم في دفتر العمل دون تعديل الأرقام الأساسية؛ على سبيل المثال، يتم عرض 0.25 كـ 25.00٪. يمكن تكوين تنسيقات المحور وتسمية البيانات بصورة منفصلة.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries();

    for ($i = 0; $i < java_values($series->size()); $i++) {
        $chartSeries = $series->get_Item($i);
        $dataPoints = $chartSeries->getDataPoints();
        for ($j = 0; $j < java_values($dataPoints->size()); $j++) {
            $dataPoint = $dataPoints->get_Item($j);
            $dataPoint->getValue()->getAsCell()->setPresetNumberFormat(10); // 0.00%
        }
    }

    $presentation->save("PresetNumberFormat_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

الجدول التالي يُظهر فهارس تنسيقات الأرقام المدمجة مع صيغ Excel النموذجية للمنطقة الإنجليزية (الولايات المتحدة). قد تختلف سلاسل التنسيق الدقيقة وعرضها حسب التطبيق والمنطقة، خاصةً للعملات والتواريخ. بعض صيغ Excel تختلف أيضًا عن القيم الافتراضية في معيار OOXML، كما هو موضح في [ملاحظات تنفيذ تنسيق الأرقام من Microsoft](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| المؤشر | التنسيق |
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

## **تعيين حدود محدبة لمنطقة المخطط**

استدعِ [Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setRoundedCorners) مع `true` لجعل زوايا منطقة المخطط مستديرة. يُنشئ المثال مخطط أعمدة مجمّع ويستخدم [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) لإعطاء حدود المخطط لونًا رماديًا صلبًا ونمط خط أحادي قبل حفظ العرض التقديمي.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chart->getLineFormat()->setStyle(LineStyle::Single);
    $chart->setRoundedCorners(true);

    $presentation->save("out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تحرير توضيحات المخطط الموجودة**

يمكن أن يحتوي المخطط على أشكال مخصصة، مثل توضيح نصي يشرح حالة تقرير. يمكن الوصول إلى هذه الأشكال عبر [Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getUserShapes). المجموعة التي تُرجِعها [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) تحتوي على الأشكال المملوكة للمخطط.

مربع نص عادي يُوضع فوق المخطط ينتمي إلى الشريحة، حتى لو بدا كجزء من المخطط. يُظهر التصفح عبر [Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) المخطط والأشكال العادية في الشريحة، لكنه لا يُعدِّد الأشكال الفردية داخل المخطط. عناوين المخطط وتسمية البيانات هي عناصر مخطط منفصلة، وليست توضيحات مخصصة في هذه المجموعة.

قم بتحميل [chart-annotations.pptx](chart-annotations.pptx) وضعه في دليل العمل للتطبيق. تحتوي شريحةه الأولى على مخطط مع توضيح غير مجموعة يُظهر "Preliminary results"، وخط مملوك للمخطط، ومربع نص شريحة عادي يُظهر "Slide overlay". يجد المثال أول مخطط على تلك الشريحة ويغيّر التوضيح إلى "Final results" عندما يصبح التقرير جاهزًا للنشر. يتحقق من وجود مجموعة فارغة ولا يعدِّل سوى [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) التي تُرجِع إطار نص غير فارغ عبر [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) والنص المتوقع.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-annotations.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chartType = new JavaClass("com.aspose.slides.IChart");
    $autoShapeType = new JavaClass("com.aspose.slides.IAutoShape");
    $chart = null;
    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++) {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartType)) {
            $chart = $shape;
            break;
        }
    }

    if ($chart === null || java_values($chart->getUserShapes()->getShapes()->size()) == 0) {
        echo "No chart or chart-owned shapes found." . PHP_EOL;
        return;
    }

    $updated = false;
    $userShapes = $chart->getUserShapes()->getShapes();
    for ($i = 0; $i < java_values($userShapes->size()); $i++) {
        $shape = $userShapes->get_Item($i);
        if (java_instanceof($shape, $autoShapeType)) {
            $annotation = $shape;
            if (!java_is_null($annotation->getTextFrame()) && java_values($annotation->getTextFrame()->getText()) === "Preliminary results") {
                $annotation->getTextFrame()->setText("Final results");
                $updated = true;
                break;
            }
        }
    }

    if ($updated) {
        $presentation->save("chart-annotations-updated.pptx", SaveFormat::Pptx);
    } else {
        echo "No matching text annotation found." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

يظل الخط ومربع نص الشريحة دون تغيير. تُظهر الصور التالية الإدخال والنتيجة المحفوظة بعد إعادة الفتح:

| قبل التحرير | بعد التحرير |
| --- | --- |
| ![توضيح المخطط يقرأ النتائج الأولية](chart-annotations-before.png) | ![توضيح المخطط يقرأ النتائج النهائية](chart-annotations-after.png) |

{{% alert color="info" title="ملاحظة" %}}
يفحص المثال فقط الأشكال المملوكة للمخطط على المستوى الأعلى. إذا كان هناك توضيح داخل [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/)، فافحص مجموعة ذلك [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) أيضًا. كرِّر ذلك بصورة متداخلة للمجموعات المتداخلة، مع تطبيق نفس فحوصات النص على أشكالها الفرعية. المجموعة نفسها هي حاوية؛ لا تعاملها كصندوق نص.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تعيين تعبئات شبه شفافة للأعمدة/المناطق مع إبقاء الحدود غير شفافة؟**

نعم. تُضبط شفافية التعبئة والحدود بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، عطل مكونات التسمية غير الضرورية (مثلاً الفئات)، اضبط موضع التسمية، اعرض التسميات للنقاط المحددة فقط إذا لزم الأمر، أو غيّر التنسيق إلى "القيمة + الأسطورية".

**هل يمكنني تطبيق تعبئات تدرجية أو بنقوش على السلاسل؟**

نعم. تدعم السلاسل تعبئات صلبة، تدرجية، وبنقوش. في الممارسة العملية، استخدم التدرجات بحذر وتجنب الجمع الذي يقلل من التباين مع الشبكة والنص.