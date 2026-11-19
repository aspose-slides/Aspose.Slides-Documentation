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
description: "إنشاء مخططات ثلاثية الأبعاد في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ PHP عبر Java. ضبط الدوران، نسب الارتفاع، عمق المخطط، والمسافات بين السلاسل باستخدام أمثلة PHP."
---
## **نظرة عامة**

Aspose.Slides for PHP via Java يتيح لك تخصيص عرض المخطط ثلاثي الأبعاد من خلال طريقة [Chart::getRotation3D](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getRotation3D) . تظهر هذه المقالة كيفية تعديل الدوران، نسب الارتفاع، العمق، المحاور القائمة على الزوايا القائمة، والمسافات بين السلاسل، ثم حفظ العرض التقديمي بتنسيق PPTX.

## **تعيين الدوران والعمق لمخطط ثلاثي الأبعاد**

يقوم المثال أدناه بإنشاء [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ويستخدم [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) لإضافة مخطط عمود ثلاثي الأبعاد مكدس إلى الشريحة الأولى. يستبدل السلاسل والفئات الافتراضية بسلسلتين تحتوي كل منهما على ثلاثة قيم. يُحدِّد فهرس ورقة العمل `0` ورقة البيانات الأولى للمخطط؛ الصف `0` يحتوي على أسماء السلاسل، والعمود `0` يحتوي على تسميات الفئات.

تُحدد طُرُق [setRotationX](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationX) و[setRotationY](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRotationY) دوران المخطط إلى 40 و270 درجة على التوالي. تقوم [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) بتعيين عمقه إلى 150٪ من عرضه، بينما تُفعّل [setRightAngleAxes](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setRightAngleAxes) المحاور القائمة على الزوايا القائمة بدلاً من المنظور. يحتوي العرض التقديمي الناتج على المخطط المملوء بهذه إعدادات العرض ثلاثية الأبعاد.

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

## **ضبط نسب الارتفاع لمخطط ثلاثي الأبعاد**

استخدم [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) لتعيين ارتفاع المخطط ثلاثي الأبعاد كنسبة مئوية من عرضه. هذا يغيّر نسب المشهد ثلاثي الأبعاد دون تعديل حجم كائن المخطط على الشريحة.

ينشئ المثال التالي مخططًا [Column3D](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) بالبيانات الافتراضية: ثلاث سلاسل وأربع فئات. يحفظ ثلاث عروض تقديمية بنسب ارتفاع 50٪، 100٪، و200٪. يبقى موضع المخطط وعرضه وارتفاعه ثابتًا. البيانات، والدوران، والعمق، والمسافات بين السلاسل، والتنسيق هي نفسها في جميع الملفات الثلاثة؛ فقط نسبة الارتفاع هي التي تتغير.

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

توضح الصور التالية نفس إعدادات الارتفاع في المثال المكافئ لـ .NET وتم تصديرها باستخدام Microsoft PowerPoint. النسبة الصغيرة تنتج مشهدًا مسطحًا، بينما النسبة الكبيرة تنتج مشهدًا أعلى داخل نفس كائن المخطط. قد يقوم PowerPoint أيضًا بضبط فواصل علامات المحور ووضع التسميات لتناسب المشهد.

| الارتفاع: 50٪ | الارتفاع: 100٪ | الارتفاع: 200٪ |
| --- | --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد مع ارتفاع محدد إلى 50٪ من عرضه](height_percent_50.png) | ![مخطط عمودي ثلاثي الأبعاد مع ارتفاع محدد إلى 100٪ من عرضه](height_percent_100.png) | ![مخطط عمودي ثلاثي الأبعاد مع ارتفاع محدد إلى 200٪ من عرضه](height_percent_200.png) |

تتحكم هذه الطُرُق في جوانب مختلفة من المخطط:

| طريقة | تأثير |
| --- | --- |
| [Rotation3D::setHeightPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setHeightPercents) | ارتفاع المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [Chart::setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setHeight) | ارتفاع كائن المخطط على الشريحة، بالنقاط. |
| [Rotation3D::setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | عمق المشهد ثلاثي الأبعاد كنسبة مئوية من عرضه. |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |

تؤثر إعدادات الارتفاع على المخططات العمودية والشريطية ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، وكذلك المخططات الخطية، المساحية، الدائرية، وسطحية ثلاثية الأبعاد. المقارنة أعلاه تستخدم النوع `Column3D` المؤكد. لا يغيّر الإعداد مظهر مخطط `ClusteredColumn` ثنائي الأبعاد أو مخطط `BubbleWith3D`؛ هذه الأسماء هي أعضاء فئة [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). للحصول على إعدادات مظهر أخرى للمخططات، راجع [Chart Formatting](/slides/ar/php-java/chart-formatting/).

## **ضبط الفجوة بين السلاسل**

استخدم [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) للتحكم في المسافة بين سلاسل البيانات على محور العمق في مخطط ثلاثي الأبعاد، معبرًا عنها كنسبة مئوية من عرض العلامة. استخدم قيمًا من **0 إلى 500** شاملًا: `0` يزيل الفجوة، بينما القيم الأكبر تزيد المسافة. مع عمق مخطط ثابت، زيادة الفجوة تجعل العلامات أرق على محور العمق.

الوصول إلى المجموعة يتم عبر [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup). يُطبق الإعداد على كل سلسلة في تلك المجموعة، وليس فقط على السلسلة المستخدمة للوصول إليها. تُعيد [ChartSeries::getGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getGapDepth) فجوة العمق وتعكس إعداد المجموعة الأصل.

هذا الإعداد يؤثر على المخططات العمودية والشريطية ثلاثية الأبعاد، بما في ذلك المتغيرات الأسطوانية، المخروطية، والهرمية، وكذلك المخططات الخطية والمساحية ثلاثية الأبعاد. يعتمد المظهر على ما إذا كانت السلاسل مرتبة في العمق، أو مجمعة، أو مكدسة. لإجراء مقارنة واضحة للفجوات بين السلاسل المنفصلة، استخدم `ChartType::Column3D` من فئة [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/).

تتحكم هذه الطُرُق في جوانب مختلفة من المخطط:

| طريقة | تأثير |
| --- | --- |
| [ChartSeriesGroup::setGapDepth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapDepth) | المسافة بين السلاسل على محور العمق، كنسبة مئوية من عرض العلامة. |
| [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) | المسافة بين مجموعات الأعمدة أو الأشرطة المتجاورة، كنسبة مئوية من عرض العمود أو الشريط. |
| [setDepthPercents](https://reference.aspose.com/slides/php-java/aspose.slides/rotation3d/#setDepthPercents) | عمق المخطط الإجمالي، كنسبة مئوية من عرض المخطط. |

يستخدم المثال المستقل التالي بيانات المخطط الافتراضية، التي تحتوي على ثلاث سلاسل وأربع فئات. يحفظ عرضين تقديميين ببيانات ودوران وعرض فجوة وعمق مخطط متطابقة؛ فقط فجوة العمق هي التي تتغير.

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

توضح الصور التالية نفس إعدادات فجوة العمق في المثال المكافئ لـ .NET وتم تصديرها باستخدام Microsoft PowerPoint.

| فجوة العمق: 0٪ | فجوة العمق: 500٪ |
| --- | --- |
| ![مخطط عمودي ثلاثي الأبعاد بدون فجوة بين السلاسل على محور العمق](gap_depth_0.png) | ![مخطط عمودي ثلاثي الأبعاد بفجوة 500٪ بين السلاسل على محور العمق](gap_depth_500.png) |

## **تغيير نوع السلسلة ثلاثية الأبعاد وشكل الشريط**

في مخطط أسطواني مجمع، تبدأ السلسلة الأولى بشكل شريط أسطواني. يطبع المثال القيم العددية التي تُعيدها [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) و[ChartSeries::getBar3DShape](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getbar3dshape/) قبل وبعد كل تغيير. تُظهر الجدول أسماء الثوابت المقابلة.

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

| التغيير على السلسلة الأولى | نوع السلسلة | شكل الشريط |
| --- | --- | --- |
| إنشاء المخطط | `ClusteredCylinder` | `Cylinder` |
| تعيين نوع السلسلة إلى `ClusteredCone` | `ClusteredCone` | `Cone` |
| تعيين شكل الشريط إلى `Box` | `ClusteredColumn3D` | `Box` |

تغيير الشكل إلى `Box` يغيّر أيضًا نوع السلسلة إلى `ClusteredColumn3D`. إذا كان كودك يتفرع بناءً على نوع السلسلة، استدعِ [ChartSeries::getType](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/gettype/) بعد تغيير الشكل. القيمة المخزنة مؤقتًا قبل التعيين ستختار فرع `ClusteredCone` ما زال.

![مقارنة PowerPoint تُظهر السلسلة الأولى كأسطوانات، مخاريط، وأعمدة مستطيلة من اليسار إلى اليمين](series-shapes.png)

## **الأسئلة الشائعة**

**ما هي أنواع المخططات التي تدعم الوضع ثلاثي الأبعاد في Aspose.Slides؟**

يدعم Aspose.Slides المتغيرات ثلاثية الأبعاد لمخططات الأعمدة، بما في ذلك Column 3D، Clustered Column 3D، Stacked Column 3D، و100% Stacked Column 3D، إلى جانب الأنواع ثلاثية الأبعاد المرتبطة المعروضة عبر فئة [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/). للحصول على قائمة دقيقة ومحدثة، راجع أعضاء [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) في مرجع الـ API للإصدار المثبت لديك.

**هل يمكنني الحصول على صورة نقطية لمخطط ثلاثي الأبعاد لتقرير أو للويب؟**

نعم. يمكنك تصدير المخطط إلى صورة باستخدام [Shape::getImage](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) أو [render the entire slide](/slides/ar/php-java/convert-powerpoint-to-png/) إلى صيغ مثل PNG أو JPEG. هذا مفيد عندما تحتاج إلى معاينة نقطية أو تريد تضمين المخطط في مستندات أو لوحات معلومات أو صفحات ويب دون الحاجة إلى PowerPoint.

**ما مدى أداء بناء وعرض المخططات ثلاثية الأبعاد الكبيرة؟**

الأداء يعتمد على حجم البيانات وتعقيد الصورة. للحصول على أفضل النتائج، حافظ على تقليل التأثيرات ثلاثية الأبعاد، تجنّب القوام الثقيلة على الجدران ومناطق الرسم، حدد عدد نقاط البيانات لكل سلسلة قدر الإمكان، وقم بالعرض إلى مخرج بالحجم المناسب (الدقة والأبعاد) ليناسب شاشة العرض أو احتياجات الطباعة المستهدفة.