---
title: إضافة خطوط الاتجاه إلى مخططات العروض التقديمية في PHP
linktitle: خط الاتجاه
type: docs
url: /ar/php-java/trend-line/
keywords:
- مخطط
- خط الاتجاه
- خط الاتجاه الأسي
- خط الاتجاه الخطّي
- خط الاتجاه اللوغاريتمي
- خط الاتجاه المتوسط المتحرك
- خط الاتجاه المتعدد الحدود
- خط الاتجاه القوي
- خط الاتجاه المخصص
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "أضف وخصص خطوط الاتجاه بسرعة في مخططات PowerPoint باستخدام Aspose.Slides للـ PHP عبر Java — دليل عملي لجذب جمهورك."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إضافة خطوط الاتجاه إلى مخططات العروض التقديمية باستخدام Aspose.Slides. تُظهر كيف يتم إنشاء مخطط، وإضافة خطوط اتجاه إلى سلاسل المخطط، والعمل مع عدة أنواع من خطوط الاتجاه، بما في ذلك الأسية، الخطية، اللوغاريتمية، المتوسط المتحرك، المتعدد الحدود، والقوة.

كما يصف كيفية إضافة خط مخصص إلى مخطط عن طريق إدراج شكل خط، ويتضمن أسئلة شائعة قصيرة حول قيم إظهار خط الاتجاه إلى الأمام والخلف وما إذا كانت خطوط الاتجاه تُحفظ أثناء التصدير إلى PDF أو SVG وعند تحويل المخططات إلى صور.

## **إضافة خط اتجاه**

استخدم [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) لإضافة خط اتجاه إلى سلسلة مخطط، مع اختيار نوعه باستخدام [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). يُنشئ المثال مخطط أعمدة مجمع ببيانات افتراضية ويضيف خطي اتجاه إلى كل من سلاسله الثلاثة.

يُخفي خط الاتجاه الأسي معادلته وقيمة R‑squared عبر [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) و[setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/)، بينما يكون خط الاتجاه الخطّي أحمر. يستخدم خط الاتجاه اللوغاريتمي [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) لتسمية مخصصة. يستخدم المتوسط المتحرك [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) لثلاث نقاط بيانات و[setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/) مخصص.

يملك خط الاتجاه المتعدد الحدود رتبة ثلاثة، تُحدد عبر [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/)، ويمتد فئة واحدة إلى الأمام عبر [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). يمتد خط الاتجاه القوي فئة واحدة إلى الخلف عبر [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تعيين تقاطع خط الاتجاه**

استخدم [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) لتثبيت قيمة Y لخط الاتجاه عند X = 0. يُدعم هذا الإعداد لخطوط الاتجاه الخطية، الأسية، والمتعددة الحدود.

على سبيل المثال، قد يحتاج نموذج تكلفة الإنتاج إلى البدء بتكلفة ثابتة معروفة قدرها 100، حتى عندما تشير قياسات أحجام الإنتاج غير الصفرية إلى خط أساس مختلف. بالنسبة لخط الاتجاه الخطّي، يفرض تثبيت التقاطع قيودًا على المعادلة `y = ax + b` لتصبح `b = 100`؛ يتم ضبط الانحدار على البيانات تحت هذا القيد. وهذا لا يعني ببساطة تحريك خط مُناسب بالفعل. تتحكم إعدادات تقاطع المحاور في موضع التقاء محاور المخطط، وليس في معاملات خط الاتجاه المُناسب.

ينشئ المثال التالي مخطط انتثار (XY) بأحجام إنتاج من 1 إلى 4 وتكاليف 170، 200، 230، و260. يحفظ المخطط باستخدام التقاطع التلقائي الافتراضي، ثم يضبط التقاطع على 100، ويحفظ ملف PPTX ثاني. يختلف الملفان فقط في إعداد التقاطع. يعرض خط الاتجاه معادلته ويمتد إلى الوراء حتى X = 0.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مع الحساب التلقائي، تُنتج هذه البيانات المعادلة `y = 30x + 140`. ضبط التقاطع على 100 ينتج تقريبًا `y = 43.33x + 100`: القيمة المُناسبة عند الصفر تتطابق مع الخط الأساسي المعروف، بينما لا يمر الخط بعد الآن عبر كل نقطة بيانات.

| التقاطع التلقائي | تقاطع ثابت 100 |
| --- | --- |
| ![خط اتجاه خطي بتقاطع محسوب تلقائيًا بقيمة 140](intercept-automatic.png) | ![خط اتجاه خطي بتقاطع ثابت بقيمة 100](intercept-fixed.png) |

تستخدم الصورتان نفس البيانات ومقاييس المحاور. تُمتد خطوط الاتجاه إلى الوراء حتى X = 0 لعرض تقاطعاتها.

بشكلٍ افتراضي، تُعيد [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) القيمة `NaN`، والتي تمثل تقاطعًا غير محدد بدلاً من الصفر. ثم يُحسب التقاطع تلقائيًا من البيانات.

## **إضافة خط مخصص**

الخط المخصص هو شكل يُرسم فوق المخطط بدلاً من أن يكون خط اتجاه يُحسب من بيانات السلسلة. يستخدم هذا المثال [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) لإضافة خط أفقي إلى الشريحة فوق المخطط. يُحدد موضع الخط في إحداثيات الشريحة بوحدات النقاط، بحيث يبدأ عند الحافة اليسرى للمخطط ويقع في منتصف ارتفاع المخطط. يطابق عرضه عرض المخطط. يُعطي [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) الخط لونًا أحمر صلبًا.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**ماذا تعني 'forward' و 'backward' بالنسبة لخط الاتجاه؟**

إنهما طولان لخط الاتجاه المُمتد إلى الأمام أو الخلف: بالنسبة لمخططات الانتثار (XY) — بوحدات المحور؛ بالنسبة للمخططات غير الانتشارية — بعدد الفئات. يُسمح فقط بالقيم غير السالبة.

**هل سيُحفظ خط الاتجاه عند تصدير العرض التقديمي إلى PDF أو SVG، أو عند تحويل شريحة إلى صورة؟**

نعم. تقوم Aspose.Slides بتحويل العروض التقديمية إلى [PDF](/slides/ar/php-java/convert-powerpoint-to-pdf/) أو [SVG](/slides/ar/php-java/render-a-slide-as-an-svg-image/) وتُحوِّل المخططات إلى صور؛ تُحفظ خطوط الاتجاه، كجزء من المخطط, خلال هذه العمليات. كما تتوفر طريقة لـ [تصدير صورة للمخطط](/slides/ar/php-java/create-shape-thumbnails/) نفسها.