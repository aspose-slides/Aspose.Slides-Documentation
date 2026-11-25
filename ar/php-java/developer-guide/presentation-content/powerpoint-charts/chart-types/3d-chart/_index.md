---
title: تخصيص المخططات ثلاثية الأبعاد في العروض التقديمية باستخدام PHP
linktitle: مخطط ثلاثي الأبعاد
type: docs
url: /ar/php-java/3d-chart/
keywords:
- مخطط ثلاثي الأبعاد
- دوران
- عمق
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء مخططات ثلاثية الأبعاد في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ PHP عبر Java. ضبط الدوران، نسب الارتفاع، عمق المخطط، والمسافات بين السلاسل مع أمثلة PHP."
---
## **نظرة عامة**

يتيح لك Aspose.Slides for PHP via Java تخصيص عرض مخطط ثلاثي الأبعاد عبر طريقة [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D). تظهر هذه المقالة كيفية ضبط الدوران، نسب الارتفاع، العمق، المحاور ذات الزاوية القائمة، والمسافات بين السلاسل، ثم حفظ العرض التقديمي بصيغة PPTX.

## **تعيين الدوران والعمق لمخطط ثلاثي الأبعاد**

يوضح المثال أدناه كيفية إنشاء [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) واستخدام [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) لإضافة مخطط عمودي ثلاثي الأبعاد مكدس إلى الشريحة الأولى. يقوم باستبدال السلاسل والفئات الافتراضية بسلسلتين يحتوي كل منهما على ثلاث قيم. يحدد فهرس ورقة العمل `0` ورقة البيانات الأولى للمخطط؛ الصف `0` يحتوي على أسماء السلاسل، والعمود `0` يحتوي على تسميات الفئات.

تضبط طريقتا [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) و[setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) دوران المخطط إلى 40 و270 درجة على التوالي. تقوم [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) بتعيين عمقه إلى 150٪ من عرضه، بينما تُفعّل [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) المحاور ذات الزاوية القائمة بدلاً من المنظور. يحتوي العرض التقديمي الناتج على المخطط المملوء بهذه إعدادات العرض الثلاثي الأبعاد.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $values = [[20, 50, 30], [30, 10, 60]];

    for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, 0, "Category " . ($categoryIndex + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
    }

    for ($seriesIndex = 0; $seriesIndex < 2; $seriesIndex++) {
        $seriesCell = $workbook->getCell($worksheetIndex, 0, $seriesIndex + 1, "Series " . ($seriesIndex + 1));
        $series = $chart->getChartData()->getSeries()->add($seriesCell, $chart->getType());

        for ($categoryIndex = 0; $categoryIndex < 3; $categoryIndex++) {
            $valueCell = $workbook->getCell($worksheetIndex, $categoryIndex + 1, $seriesIndex + 1, $values[$seriesIndex][$categoryIndex]);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
        }
    }

    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(270);
    $chart->getRotation3D()->setDepthPercents(150);

    $presentation->save("Rotation3D_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تطبيق تعبئة صورة على سطح المخطط الثلاثي الأبعاد**

يمكنك ملء [side wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getsidewall/)، [back wall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getbackwall/)، و[floor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getfloor/) لمخطط ثلاثي الأبعاد بشكل مستقل. اضبط نوع تعبئة السطح عبر [fill type](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) إلى `Picture` وعيّن صورة. اضبط كلًا من [picture fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/setpicturefillmode/) ونوع الصورة الخاص بالسطح عبر [picture type](https://reference.aspose.com/slides/php-java/aspose.slides/chartwall/setpicturetype/) إلى `Stretch` لتناسب نسخة واحدة من الصورة عبر السطح.

احفظ [arrow.png](arrow.png) بجوار سكريبت PHP. يقوم المثال بتدوير المخطط وزيادة القيمة القصوى على المحور العمودي بحيث يكون الأرضية مرئية بين الأعمدة. ثم ينسخ الشريحة مرتين ويطبق السهم على سطح مختلف في كل شريحة. تحتفظ جميع المخططات الثلاثة بنفس البيانات وزاوية العرض والخلفية.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\PictureType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 20, 30, 680, 480);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setRotationX(40);
    $chart->getRotation3D()->setRotationY(30);
    
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->setAutomaticMaxValue(false);
    $verticalAxis->setMaxValue(24);

    $backSlide = $presentation->getSlides()->addClone($slide);
    $floorSlide = $presentation->getSlides()->addClone($slide);
    $backChart = $backSlide->getShapes()->get_Item(0);
    $floorChart = $floorSlide->getShapes()->get_Item(0);

    $image = Images::fromFile(__DIR__ . "/arrow.png");
    try {
        $arrow = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $surfaces = [$chart->getSideWall(), $backChart->getBackWall(), $floorChart->getFloor()];
    foreach ($surfaces as $surface) {
        $fill = $surface->getFormat()->getFill();
        $fill->setFillType(FillType::Picture);
        $pictureFill = $fill->getPictureFillFormat();
        $pictureFill->getPicture()->setImage($arrow);
        $pictureFill->setPictureFillMode(PictureFillMode::Stretch);
        $surface->setPictureType(PictureType::Stretch);
    }

    $presentation->save(__DIR__ . "/chart-surfaces.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

يظهر Microsoft PowerPoint الشرائح الثلاث كما يلي.

| الجدار الجانبي | الجدار الخلفي | الأرضية |
| --- | --- | --- |
| ![سهم يشير إلى داخل المخطط على الجدار الجانبي](side-wall.png) | ![سهم يشير إلى اليمين عبر الجدار الخلفي](back-wall.png) | ![سهم يشير إلى اليمين عبر الأرضية بين الأعمدة](floor.png) |

## **ضبط نسب الارتفاع لمخطط ثلاثي الأبعاد**

استخدم [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) لتعيين ارتفاع المخطط الثلاثي الأبعاد كنسبة مئوية من عرضه. يغيّر هذا نسب المشهد الثلاثي الأبعاد دون تغيير حجم كائن المخطط على الشريحة.

ينشئ المثال التالي مخطط [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) بالبيانات الافتراضية: ثلاث سلاسل وأربع فئات. يحفظ ثلاث عروض تقديمية بنسب ارتفاع 50٪، 100٪، و200٪. يظل موضع المخطط وعرضه وارتفاعه ثابتًا. البيانات، الدوران، العمق، تباعد السلاسل، والتنسيق هي نفسها في جميع الملفات الثلاثة؛ فقط تتغير نسبة الارتفاع.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 460);
    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setRightAngleAxes(true);
    $chart->getRotation3D()->setDepthPercents(100);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setGapDepth(150);

    foreach ([50, 100, 200] as $heightPercent) {
        $chart->getRotation3D()->setHeightPercents($heightPercent);
        $presentation->save("chart_height_" . $heightPercent . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

الصور التالية توضح نفس إعدادات الارتفاع في المثال المكافئ لـ .NET وتم تصديرها باستخدام Microsoft PowerPoint. النسبة المئوية الأصغر تنتج مشهدًا أكثر تسطحًا، بينما النسبة الأكبر تنتج مشهدًا أطول داخل نفس كائن المخطط. قد يقوم PowerPoint أيضًا بتعديل فواصل علامات المحور ومواقع التسميات لتناسب المشهد.

| الارتفاع: 50٪ | الارتفاع: 100٪ | الارتفاع: 200٪ |
| --- | --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بارتفاع 50٪ من عرضه](height_percent_50.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع 100٪ من عرضه](height_percent_100.png) | ![مخطط عمودي ثلاثي الأبعاد بارتفاع 200٪ من عرضه](height_percent_200.png) |

تتحكم هذه الطرق في جوانب مختلفة من المخطط:

| الطريقة | التأثير |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | ارتفاع المشهد الثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | ارتفاع كائن المخطط على الشريحة بالنقاط. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | عمق المشهد الثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | التباعد بين السلاسل على محور العمق كنسبة مئوية من عرض العلامة. |

تؤثر إعدادات الارتفاع على مخططات الأعمدة والأشرطة الثلاثية الأبعاد، بما فيها المتغيرات الأسطوانية والمخروطية والهرمية، بالإضافة إلى مخططات الخطوط والمساحات والدوائر السطحية الثلاثية الأبعاد. المقارنة أعلاه تستخدم النوع `Column3D` المُؤكد. لا يغيّر هذا الإعداد مظهر مخطط `ClusteredColumn` ثنائي الأبعاد أو مخطط `BubbleWith3D`؛ هذه الأسماء هي أعضاء في فئة [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). للحصول على إعدادات مظهر أخرى للمخطط، راجع [Chart Formatting](/slides/ar/php-java/chart-formatting/).

## **ضبط الفجوة بين السلاسل**

استخدم [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) للتحكم في المسافة بين سلاسل البيانات على محور العمق في مخطط ثلاثي الأبعاد، معبرًا عنها كنسبة مئوية من عرض العلامة. استخدم قيمًا من **0 إلى 500** بما في ذلك: `0` يزيل الفجوة، بينما القيم الأكبر تزيد التباعد. مع عمق مخطط ثابت، زيادة الفجوة تجعل العلامات أرفع على محور العمق.

الوصول إلى المجموعة يتم عبر [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). ينطبق الإعداد على كل سلسلة في تلك المجموعة، وليس فقط السلسلة المستخدمة للوصول إليها. تُعيد [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) فجوة العمق وتعكس إعداد المجموعة الأصل.

يؤثر هذا الإعداد على مخططات الأعمدة والأشرطة الثلاثية الأبعاد، بما فيها المتغيرات الأسطوانية والمخروطية والهرمية، بالإضافة إلى مخططات الخطوط والمساحات الثلاثية الأبعاد. يعتمد المظهر على ما إذا كانت السلاسل مرتبة في العمق، أو مجمعة، أو مكدسة. للمقارنة الواضحة بين الفجوات بين السلاسل المنفصلة، استخدم `ChartType::Column3D` من فئة [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

تتحكم هذه الطرق في جوانب مختلفة من المخطط:

| الطريقة | التأثير |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | التباعد بين السلاسل على محور العمق كنسبة مئوية من عرض العلامة. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | التباعد بين مجموعات الأعمدة أو الأشرطة المتجاورة كنسبة مئوية من عرض العمود أو الشريط. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | العمق العام للمخطط كنسبة مئوية من عرض المخطط. |

المثال التالي المستقل يستخدم البيانات الافتراضية للمخطط، التي تحتوي على ثلاث سلاسل وأربع فئات. يحفظ عرضين تقديميين ببيانات، دوران، عرض الفجوة، وعمق المخطط متطابقة؛ فقط تتغير فجوة العمق.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 40, 30, 620, 230);

    $chart->getRotation3D()->setRotationX(20);
    $chart->getRotation3D()->setRotationY(30);
    $chart->getRotation3D()->setDepthPercents(100);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $group = $series->getParentSeriesGroup();
    $group->setGapWidth(150);

    foreach ([0, 500] as $gapDepth) {
        $group->setGapDepth($gapDepth);

        $fileName = "series_gap_depth_" . $gapDepth . ".pptx";
        $presentation->save($fileName, SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

الصور التالية توضح نفس إعدادات فجوة العمق في المثال المكافئ لـ .NET وتم تصديرها باستخدام Microsoft PowerPoint.

| فجوة العمق: 0٪ | فجوة العمق: 500٪ |
| --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بدون فجوة بين السلاسل على محور العمق](gap_depth_0.png) | ![مخطط عمودي ثلاثي الأبعاد بفجوة 500٪ بين السلاسل على محور العمق](gap_depth_500.png) |

## **تغيير نوع السلسلة الثلاثية الأبعاد وشكل الشريط**

في مخطط أسطواني مُجَمَّع، تبدأ السلسلة الأولى بشكل شريط أسطواني. يطبع المثال القيم العددية التي تعيدها [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) و[ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) قبل وبعد كل تغيير. تُظهر الجدول أسماء الثوابت المقابلة.

```php
use aspose\slides\ChartShapeType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setType(ChartType::ClusteredCone);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $series->setBar3DShape(ChartShapeType::Box);
    echo $series->getType(), " | ", $series->getBar3DShape(), PHP_EOL;

    $presentation->save("series_shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| التغيير للسلسلة الأولى | نوع السلسلة | شكل الشريط |
| --- | --- | --- |
| إنشاء المخطط | `ClusteredCylinder` | `Cylinder` |
| تعيين نوع السلسلة إلى `ClusteredCone` | `ClusteredCone` | `Cone` |
| تعيين شكل الشريط إلى `Box` | `ClusteredColumn3D` | `Box` |

ضبط الشكل إلى `Box` يغيّر أيضًا نوع السلسلة إلى `ClusteredColumn3D`. إذا كان كودك يتفرّع بناءً على نوع السلسلة، استدعِ [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) بعد تغيير الشكل. القيمة المخزنة مؤقتًا قبل التعيين ستظل تختار الفرع `ClusteredCone`.

![مقارنة PowerPoint تُظهر السلسلة الأولى كاسطوانات، مخاريط، وأعمدة مستطيلة من اليسار إلى اليمين](series-shapes.png)

## **FAQ**

**ما هي أنواع المخططات التي تدعم وضع 3D في Aspose.Slides؟**

يدعم Aspose.Slides المتنوعات الثلاثية الأبعاد لمخططات الأعمدة، بما فيها Column 3D وClustered Column 3D وStacked Column 3D و100% Stacked Column 3D، بالإضافة إلى الأنواع الثلاثية المرتبطة التي تُظهرها فئة [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). للحصول على قائمة دقيقة ومحدثة، راجع أعضاء فئة [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) في مرجع API للإصدار المُثبت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة عبر [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) أو [تصيير الشريحة بالكامل](/slides/ar/php-java/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة نقطية أو تريد تضمين المخطط في مستندات، لوحات معلومات، أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى أداء إنشاء وعرض المخططات الثلاثية الأبعاد الكبيرة؟**

يعتمد الأداء على حجم البيانات وتعقيد الرسوم. للحصول على أفضل النتائج، قلل من تأثيرات 3D إلى الحد الأدنى، وتجنب القوام الثقيلة على الجدران ومنطقة الرسم، واقصر عدد نقاط البيانات لكل سلسلة عندما يكون ذلك ممكنًا، وقم بالتصيير إلى مخرجات بالحجم المناسب (الدقة والأبعاد) لتتناسب مع العرض المستهدف أو متطلبات الطباعة.