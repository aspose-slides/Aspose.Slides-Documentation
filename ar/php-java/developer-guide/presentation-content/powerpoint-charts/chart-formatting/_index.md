---
title: تنسيق مخططات العروض التقديمية في PHP
linktitle: تنسيق المخططات
type: docs
weight: 60
url: /ar/php-java/chart-formatting/
keywords:
- تنسيق المخطط
- تنسيق المخططات
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
description: "تعلم تنسيق المخططات في Aspose.Slides للـ PHP عبر Java وارتقِ بعرض PowerPoint التقديمي الخاص بك باستخدام محاور مخصصة، خطوط، تنسيقات عددية، وحدود مخطط مستديرة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تنسيق المخططات في عروض PowerPoint باستخدام Aspose.Slides. توضح كيفية تخصيص عناصر المخطط الأساسية مثل المحاور، وخطوط الشبكة، والعناوين، والوسائط، ومنطقة الرسم، وتعبئات الجدران لتحسين مظهر وقراءة بيانات المخطط.

كما توضح كيفية ضبط خصائص الخط لنص المخطط، وتطبيق تنسيقات عددية مسبقة الإعداد على بيانات المخطط، وتمكين زوايا مستديرة لمنطقة المخطط. معًا، تُظهر هذه الأمثلة كيفية التحكم في كل من النمط البصري وعرض البيانات للمخططات في العرض التقديمي.

## **تنسيق كائنات المخطط**

استخدم [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) لتنسيق عناوين المخطط، والمحاور، وخطوط الشبكة، والوسائط، ومنطقة الرسم. يُنشئ هذا المثال مخططًا خطيًا مع علامات وبيانات افتراضية، ثم يطبق أنماط نصية وخطية منفصلة على محوري القيمة والفئة. تُحدد أحجام الخطوط وعرض الخطوط بالنقاط؛ وتُدوَّر تسميات الفئات بزاوية 45 درجة.

يستخدم المحور القيمي [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) بشكل مستقل عن خلايا المصدر. يمتد مقياسه من -2 إلى 15، مع فواصل رئيسية مقدارها 2 وفواصل فرعية مقدارها 0.5. يجمع المثال أيضًا بين تنسيق النسبة المئوية و[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) المعين إلى الآلاف، لذا اضبط هذه الإعدادات وفقًا لمعنى وحجم بياناتك. يبقى الأسطورة خارج منطقة الرسم لأن [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) يُستدعى بـ `false`. تُضبط تعبئات الجدار الخلفي والأرضية عبر [getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/) و[getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/)، ولكن هذه الأسطح تُظهر فقط في المخططات ثلاثية الأبعاد.

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

## **ضبط خصائص الخط للمخطط**

اضبط حجم الخط الافتراضي لنص المخطط عبر [Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/gettextformat/). يُنشئ المثال مخطط أعمدة مجمع بحجم خط 20 نقطة ويفعل تسمية القيم للسلسلة الأولى عبر [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/). يمكن لعناصر النص التي لديها إعدادات خط صريحة خاصة بها تجاوز الإعداد الافتراضي للمخطط.

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

## **ضبط التنسيق الرقمي**

استخدم [ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setpresetnumberformat/) لتطبيق تنسيق رقم مدمج على خلايا مصنف المخطط. يُنشئ هذا المثال مخطط أعمدة مجمع ببيانات افتراضية مدعومة بالخلايا ويطبق فهرس التنسيق 10 (`0.00%`) على كل خلية قيمة لسلسلة. يغيّر ذلك طريقة عرض القيم في المصنف دون تعديل الأرقام الأساسية؛ على سبيل المثال، يُعرض 0.25 كـ 25.00%. يمكن ضبط تنسيقات المحور وتنسيقات تسميات البيانات بصورة مستقلة.

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

القائمة التالية تُظهر فهارس تنسيقات الأعداد المدمجة مع صيغ Excel النموذجية للمنطقة الإنجليزية (الولايات المتحدة). قد تختلف سلاسل التنسيق الدقيقة وعرضها حسب التطبيق والمنطقة، خاصةً للعملات والتواريخ. بعض صيغ Excel تختلف أيضًا عن القيم الافتراضية في معيار OOXML، كما هو موضح في [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

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

## **إعداد حدود مستديرة لمنطقة المخطط**

استدعِ [Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setroundedcorners/) مع `true` لتقويس زوايا منطقة المخطط. يُنشئ المثال مخطط أعمدة مجمع ويستخدم [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) لإعطاء حدوده لونًا رماديًا صلبًا ونمط خط أحادي قبل حفظ العرض التقديمي.

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

## **تحرير تعليقات المخطط الموجودة**

يمكن للمخطط أن يحتوي على أشكال مخصصة، مثل تعليق نصي يوضح حالة تقرير. للوصول إلى هذه الأشكال، استخدم [Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getusershapes/). التجميع الذي تُعيده [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getshapes/) يحتوي على الأشكال المملوكة للمخطط.

مربع النص العادي الموضوع فوق المخطط ينتمي إلى الشريحة، حتى وإن بدا كجزء من المخطط. يُظهر التكرار عبر [Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) المخطط والأشكال العادية على الشريحة، ولكنه لا يُدرج الأشكال الفردية داخل المخطط. عناوين المخططات وتسميات البيانات هي عناصر مخطط منفصلة، ليست تعليقات مخصصة في هذا التجميع.

حمّل [chart-annotations.pptx](chart-annotations.pptx) وضعه في دليل عمل التطبيق. تحتوي شريحته الأولى على مخطط بتعليق غير مجمع يقرأ "Preliminary results"، وخط مملوك للمخطط، ومربع نص شريحة عادي يقرأ "Slide overlay". يجد المثال أول مخطط على تلك الشريحة ويغيّر التعليق إلى "Final results" عندما يصبح التقرير جاهزًا للنشر. يتحقق من أن التجميع غير فارغ ولا يُعدِّل سوى [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) التي يُعيدها [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/gettextframe/) بإطار نص غير فارغ والنص المتوقع.

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

يبقى الخط ومربع النص على الشريحة دون تغيير. تُظهر الصور التالية الإدخال والنتيجة المحفوظة المفتوحة مرة أخرى:

| قبل التحرير | بعد التحرير |
| --- | --- |
| ![تعليق مخطط يقرأ Preliminary results](chart-annotations-before.png) | ![تعليق مخطط يقرأ Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
يفحص المثال فقط الأشكال المملوكة للمخطط على المستوى الأعلى. إذا كان التعليق داخل [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/)، تحقق من تجميع هذا المجموعة عبر [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getshapes/) أيضًا. كرر ذلك بصورة متتالية للمجموعات المتداخلة، مطبقًا نفس فحوصات النص على الأشكال الفرعية. المجموعة نفسها حاوية؛ لا تعاملها كمربع نص.
{{% /alert %}}

## **FAQ**

**هل يمكنني تعيين تعبئات نصف شفافة للأعمدة/المناطق مع الحفاظ على الحد غير شفاف؟**

نعم. تُضبط شفافية التعبئة والحد الخارجي بشكل منفصل. هذا مفيد لتحسين قابلية قراءة الشبكة والبيانات في التصورات الكثيفة.

**كيف يمكنني التعامل مع تسميات البيانات عندما تتداخل؟**

قلل حجم الخط، عطل مكونات التسمية غير الضرورية (مثل الفئات)، اضبط موضع التسمية، اعرض التسمية فقط للنقاط المختارة إذا لزم الأمر، أو غيّر التنسيق إلى "القيمة + الوسيط".

**هل يمكنني تطبيق تعبئات متدرجة أو نمطية للسلاسل؟**

نعم. تدعم السلاسل تعبئات صلبة، ومتدرجة، ونمطية. في الممارسة العملية، استعمل المتدرجات باعتدال وتجنب الجمع بينهما إذا كان ذلك يقلل من التباين مع الشبكة والنص.