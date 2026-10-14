---
title: تخصيص المخططات الدائرية في العروض التقديمية باستخدام PHP
linktitle: مخطط دائري
type: docs
url: /ar/php-java/pie-chart/
keywords:
- مخطط دائري
- إدارة المخطط
- تخصيص المخطط
- خيارات المخطط
- إعدادات المخطط
- خيارات الرسم
- لون الشريحة
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص مخططات دائرية في PHP باستخدام Aspose.Slides. تكوين المخططات الثانوية، عرض تسميات البيانات، وتطبيق ألوان شرائح تلقائية في PowerPoint."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية التعامل مع المخططات الدائرية في Aspose.Slides. وتوضح كيفية تكوين خيارات المخطط الثانوي لمخططي Pie of Pie و Bar of Pie، وكيفية تمكين تلوين الشرائح تلقائيًا لمخطط دائري قياسي.

تركز الأمثلة على مهام تخصيص المخططات مثل إضافة مخطط إلى شريحة، وضبط إعدادات السلسلة والملصقات، واستبدال بيانات المخطط الافتراضية بفئات وقيم مخصصة، وحفظ العرض التقديمي المحدث.

## **خيارات المخطط الثانوي لمخططي Pie of Pie و Bar of Pie**

يدعم Aspose.Slides للـ PHP عبر Java خيارات المخطط الثانوي لمخططي Pie of Pie و Bar of Pie. تتحكم هذه الخيارات في حجم المخطط الثانوي وكيفية تقسيم نقاط البيانات بين المخططين.

المثال التالي ينشئ مخطط Pie of Pie في عرض تقديمي جديد ويعرض قيم نقاط البيانات كملصقات. طريقة [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) تضبط حجم المخطط الثانوي إلى 149% من المخطط الرئيسي. طريقة [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) تختار التقسيم القائم على النسبة المئوية، وطريقة [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) تضبط العتبة إلى 53%.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // عرض القيم وتكوين المخطط الثانوي.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **تحديد الفئات للمخطط الثانوي**

استخدم التقسيم المخصص عندما تريد تجميع فئات معينة في المخطط الثانوي بغض النظر عن قيم النسبة المئوية لها. على سبيل المثال، قد يُظهر تقرير المبيعات الفئتين Online و Events معًا ليتسنى للقراء مقارنة هذين القنالين، على الرغم من أنهما يمثلان 35% و10% من إجمالي المبيعات.

استدعِ [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) مع [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) وحدد النقاط عبر [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). طريقة [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) في المجموعة تقبل فهرسًا يبدأ من الصفر في السلسلة؛ استخدم [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) لإضافة كائن نقطة بيانات. في هذا المثال، الفهرس 1 يختار Online، والنقطة في الفهرس 3 تختار Events. يتم إضافة Partners مؤقتًا، ثم استبعادها باستخدام [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // استبدال البيانات الافتراضية بمبيعات حسب القناة.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // تحديد Online باستخدام الفهرس الصفري الخاص به و Events باستخدام كائن نقطة البيانات.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // استبعاد Partners من الاختيار دون حذف بيانات المصدر الخاصة به.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تظهر Online (35) و Events (10) كشرائح منفصلة في المخطط الثانوي. في المخطط الرئيسي، يتم تمثيلهما بشريحة واحدة مجمعة بقيمة 45، جنبًا إلى جنب مع Retail (40) و Partners (15). إزالة Partners من الاختيار المخصص يبقِيها في المخطط الرئيسي؛ ولا يزيل الفئة أو قيمتها من بيانات المصدر للمخطط.

الصورة التالية تظهر العرض التقديمي المحفوظ في PowerPoint:

![مخطط Pie of Pie مع Online و Events في المخطط الثانوي وقيمتهما المشتركة 45 في المخطط الرئيسي](pie_of_pie_custom.png)

## **ضبط ألوان شرائح المخطط الدائري تلقائيًا**

يمكن لـ Aspose.Slides للـ PHP عبر Java تعيين ألوان مختلفة تلقائيًا لشرائح المخطط الدائري. يخلق المثال التالي مخططًا دائريًا بعنوان مركزي ويستبدل البيانات الافتراضية بثلاث فئات ربع سنوية وقيمها. طريقة [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) تعرض القيم 20 و 50 و 30 كملصقات، بينما تقوم [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) بتمكين لون مميز لكل شريحة.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // إضافة عنوان مخطط في الوسط.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // استبدال البيانات الافتراضية باستخدام ورقة العمل الأولى.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // إظهار القيم وتعيين ألوان مختلفة للشرائح.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة الشائعة**

**هل يتم دعم تنويعات Pie of Pie و Bar of Pie؟**

نعم، المكتبة [يدعم](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) مخططًا ثانويًا للمخططات الدائرية، بما في ذلك أنواع Pie of Pie و Bar of Pie.

**هل يمكنني تصدير المخطط فقط كصورة (مثلاً PNG)؟**

نعم، يمكنك [تصدير المخطط نفسه كصورة](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (مثل PNG) دون تصدير العرض التقديمي بأكمله.