---
title: إنشاء أو تحديث مخططات عروض PowerPoint في PHP
linktitle: إنشاء أو تحديث المخططات
type: docs
weight: 10
url: /ar/php-java/create-chart/
keywords:
- إضافة مخطط
- إنشاء مخطط
- تحرير مخطط
- تغيير مخطط
- تحديث مخطط
- مخطط مبعثر
- مخطط دائري
- مخطط خطي
- مخطط شجرة
- مخطط أسهم
- مخطط الصندوق والشارب
- مخطط قمع
- مخطط شمسية
- مخطط هيستوجرام
- مخطط رادار
- مخطط متعدد الفئات
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص المخططات في عروض PowerPoint التقديمية باستخدام Aspose.Slides للـ PHP عبر Java. إضافة، تنسيق، وتحرير المخططات مع أمثلة شفرة عملية في PHP."
---
## **نظرة عامة**

توفر هذه المقالة دليلًا شاملاً حول كيفية إنشاء وتخصيص المخططات باستخدام Aspose.Slides للـ PHP عبر Java. سوف تتعلم كيفية إضافة مخطط برمجيًا إلى شريحة، وتعبئته بالبيانات، وتطبيق خيارات تنسيق مختلفة لتتناسب مع متطلبات التصميم الخاصة بك. طوال المقالة، توضح أمثلة الأكواد التفصيلية كل خطوة، بدءًا من تهيئة العرض وكائن المخطط إلى تكوين السلاسل والمحاور والوسائط. باتباع هذا الدليل، ستحصل على فهم قوي لكيفية دمج توليد المخططات الديناميكية في تطبيقات PHP الخاصة بك، مما يبسط عملية إنشاء عروض تقديمية مدفوعة بالبيانات.

## **إنشاء مخطط**

تساعد المخططات الناس على تصور البيانات بسرعة واستخلاص رؤى قد لا تكون واضحة مباشرةً من جدول أو جدول بيانات.

**لماذا إنشاء المخططات؟**

* تجميع أو تكثيف أو تلخيص كميات كبيرة من البيانات على شريحة واحدة في عرض تقديمي؛  
* إظهار الأنماط والاتجاهات في البيانات؛  
* استنتاج اتجاه وزخم البيانات مع مرور الوقت أو بالنسبة لوحدة قياس محددة؛  
* اكتشاف القيم المتطرفة، والابتعاد، والانحرافات، والأخطاء، والبيانات غير المنطقية؛  
* التواصل أو عرض البيانات المعقدة.

في PowerPoint، يمكنك إنشاء المخططات عبر وظيفة *Insert*، التي توفر قوالب لتصميم العديد من أنواع المخططات. باستخدام Aspose.Slides، يمكنك إنشاء كل من المخططات العادية (المستندة إلى أنواع المخططات الشائعة) والمخططات المخصصة.

{{% alert color="info" title="Note" %}}
استخدم تعداد [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) في مساحة الأسماء [aspose\slides](https://reference.aspose.com/slides/php-java/aspose.slides/). القيم في هذا التعداد تتطابق مع أنواع مختلفة من المخططات.
{{% /alert %}}

### **إنشاء مخططات أعمدة مجمعة**

يستخدم هذا المثال الدالة [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) لإنشاء مخطط عمودي مجمع يقارن سلسلتين عبر ثلاث فئات. تستخدم السلسلات تعبئة حمراء وخضراء، وتوضح العلامات الفردية أسماء الفئات وأسماء السلاسل والقيم. يشير فهرس ورقة العمل 0 إلى الورقة الأولى في دفتر عمل المخطط المضمن.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $categoryCell = $workbook->getCell($worksheetIndex, 1, 0, "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 2, 0, "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 3, 0, "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 20);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 50);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 0, 0);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $series = $chart->getChartData()->getSeries()->get_Item(1);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 2, 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 2, 10);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 2, 60);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 128, 0);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $label = $series->getDataPoints()->get_Item(0)->getLabel();
    $label->getDataLabelFormat()->setShowCategoryName(true);

    $label = $series->getDataPoints()->get_Item(1)->getLabel();
    $label->getDataLabelFormat()->setShowSeriesName(true);

    $label = $series->getDataPoints()->get_Item(2)->getLabel();
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setShowSeriesName(true);
    $label->getDataLabelFormat()->setSeparator("/");

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

النتيجة:

![مخطط العمود المجمع](clustered_column_chart.png)

### **إنشاء مخططات مبعثرة**

تُستخدم مخططات التبعثر (المعروفة أيضًا بمخططات النقط أو الرسوم البيانية س-ص) عادةً للتحقق من الأنماط أو إظهار الارتباطات بين متغيرين.

استخدم مخطط تبعثر عندما:

* لديك بيانات رقمية مقترنة.  
* لديك متغيران يرتبطان جيدًا معًا.  
* ترغب في تحديد ما إذا كان المتغيران مرتبطين.  
* لديك متغير مستقل له عدة قيم للمتغير التابع.

يرسم هذا المثال مجموعتين من قيم س-ص. تستخدم السلسلة الأولى خطوطًا مستقيمة مع علامات نجمة، بينما تستخدم السلسلة الثانية خطوطًا سلسة مع علامات دائرة؛ كلاهما يستخدم حجم علامة 10، تم تكوينه باستخدام [setSize](https://reference.aspose.com/slides/php-java/aspose.slides/marker/setsize/). تتحكم طريقة [setSymbol](https://reference.aspose.com/slides/php-java/aspose.slides/marker/setsymbol/) في شكل العلامة.

```php
use aspose\slides\ChartType;
use aspose\slides\MarkerStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 20, 20, 500, 300);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, 1, 1, "Series 1");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());
    $seriesNameCell = $workbook->getCell($worksheetIndex, 1, 3, "Series 2");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $xValueCell = $workbook->getCell($worksheetIndex, 2, 1, 1);
    $yValueCell = $workbook->getCell($worksheetIndex, 2, 2, 3);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 3, 1, 2);
    $yValueCell = $workbook->getCell($worksheetIndex, 3, 2, 10);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);

    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);

    $series = $chart->getChartData()->getSeries()->get_Item(1);

    $xValueCell = $workbook->getCell($worksheetIndex, 2, 3, 5);
    $yValueCell = $workbook->getCell($worksheetIndex, 2, 4, 2);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 3, 3, 3);
    $yValueCell = $workbook->getCell($worksheetIndex, 3, 4, 1);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 4, 3, 2);
    $yValueCell = $workbook->getCell($worksheetIndex, 4, 4, 2);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 5, 3, 5);
    $yValueCell = $workbook->getCell($worksheetIndex, 5, 4, 1);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

النتيجة:

![مخطط التبعثر](scatter_chart.png)

### **إنشاء مخططات دائرية**

تُستخدم المخططات الدائرية بشكل أفضل لإظهار العلاقة بين الجزء والكل في البيانات، خاصةً عندما تحتوي البيانات على تسميات تصنيفية مع قيم رقمية. ومع ذلك، إذا كانت بياناتك تحتوي على العديد من الأجزاء أو التسميات، قد ترغب في التفكير في استخدام مخطط شريطي بدلاً من ذلك.

ينشئ هذا المثال مخططًا دائريًا يحتوي على ثلاث قيم ربع سنوية. لكل شريحة تعبئة وحدود مخصصة، وتعرض العلامات تركيبات مختلفة من القيم والنسب المئوية ومعلومات السلسلة. تُحدد طريقة [setFirstSliceAngle](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setfirstsliceangle/) الزاوية الأولية للقطعة لتبدأ عند 180 درجة.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 20, 20, 500, 300);

    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $categoryCell = $workbook->getCell(0, 1, 0, "1st Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 2, 0, "2nd Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 3, 0, "3rd Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 20);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 50);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 30);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);

    $firstSlice = $series->getDataPoints()->get_Item(0);
    $firstSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 255, 255);
    $firstSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $firstSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 128, 128, 128);
    $firstSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $firstSlice->getFormat()->getLine()->setWidth(3.0);
    $firstSlice->getFormat()->getLine()->setStyle(LineStyle::ThinThick);
    $firstSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDash);

    $secondSlice = $series->getDataPoints()->get_Item(1);
    $secondSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $secondSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $secondSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 0, 255);
    $secondSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $secondSlice->getFormat()->getLine()->setWidth(3.0);
    $secondSlice->getFormat()->getLine()->setStyle(LineStyle::Single);
    $secondSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDashDot);

    $thirdSlice = $series->getDataPoints()->get_Item(2);
    $thirdSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 127, 80);
    $thirdSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $thirdSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 0, 0);
    $thirdSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $thirdSlice->getFormat()->getLine()->setWidth(2.0);
    $thirdSlice->getFormat()->getLine()->setStyle(LineStyle::ThinThin);
    $thirdSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDashDotDot);

    $firstLabel = $series->getDataPoints()->get_Item(0)->getLabel();
    $firstLabel->getDataLabelFormat()->setShowValue(true);

    $secondLabel = $series->getDataPoints()->get_Item(1)->getLabel();
    $secondLabel->getDataLabelFormat()->setShowValue(true);
    $secondLabel->getDataLabelFormat()->setShowLegendKey(true);
    $secondLabel->getDataLabelFormat()->setShowPercentage(true);

    $thirdLabel = $series->getDataPoints()->get_Item(2)->getLabel();
    $thirdLabel->getDataLabelFormat()->setShowSeriesName(true);
    $thirdLabel->getDataLabelFormat()->setShowPercentage(true);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);

    $presentation->save("PieChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

النتيجة:

![المخطط الدائري](pie_chart.png)

لتحسين قابلية قراءة العلامات خارج الدائرة، راجع [Format Leader Lines](/slides/ar/php-java/chart-data-label/#format-leader-lines) للحصول على مثال يحدد موضع العلامات ويخصص لون الخطوط وعرضها وشفافيتها ونمطها المتقطع.

### **إنشاء مخططات خطية**

تُستخدم مخططات الخط (المعروفة أيضًا بالرسوم الخطية) بشكل أفضل في الحالات التي تريد فيها إظهار التغيرات في القيمة بمرور الوقت. باستخدام مخطط خطي، يمكنك مقارنة كمية كبيرة من البيانات في آن واحد، تتبع التغييرات والاتجاهات بمرور الوقت، تسليط الضوء على الشذوذ في سلاسل البيانات، والمزيد.

يستخدم هذا المثال الدالة [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) لإنشاء مخطط خطي مع السلسلة والفئات الافتراضية، ثم يحفظ العرض التقديمي كملف PPTX.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $lineChart = $slide->getShapes()->addChart(ChartType::Line, 20, 20, 500, 300);

    $presentation->save("lineChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

افتراضيًا، يتم ربط نقاط مخطط الخط بخطوط مستقيمة مستمرة. إذا كنت ترغب في ربط النقاط بخطوط متقطعة بدلاً من ذلك، استدعِ [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) بقيمة من [LineDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/):

```php
use aspose\slides\ChartType;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $lineChart = $slide->getShapes()->addChart(ChartType::Line, 20, 20, 500, 300);

    for ($i = 0; $i < java_values($lineChart->getChartData()->getSeries()->size()); $i++)
    {
        $series = $lineChart->getChartData()->getSeries()->get_Item($i);
        $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
}
finally
{
    $presentation->dispose();
}
```

النتيجة:

![المخطط الخطي](line_chart.png)

### **إنشاء مخططات شجرية**

تُستخدم مخططات الخريطة الشجرية بشكل أفضل لبيانات المبيعات عندما تريد إظهار الحجم النسبي لفئات البيانات وجذب الانتباه بسرعة إلى العناصر التي تسهم بشكل كبير ضمن كل فئة.

ينشئ هذا المثال خريطة شجرية تحتوي على ثمانية أوراق مُجمَّعة في أربعة سيقان وفرعين. تُعيّن طريقة [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) السيقان في المستوى التجميعي 1 والفروع في المستوى 2. تحدد القيم أحجام المستطيلات النسبية، بينما تُعرف تسميات الفئات وتسميات الأبواب المتداخلة بالهرمية.

```php
use aspose\slides\ChartType;
use aspose\slides\ParentLabelLayoutType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Treemap, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // الفرع 1
    $categoryCell = $workbook->getCell(0, "C1", "Leaf1");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");

    $categoryCell = $workbook->getCell(0, "C2", "Leaf2");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C3", "Leaf3");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");

    $categoryCell = $workbook->getCell(0, "C4", "Leaf4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    // الفرع 2
    $categoryCell = $workbook->getCell(0, "C5", "Leaf5");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");

    $categoryCell = $workbook->getCell(0, "C6", "Leaf6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C7", "Leaf7");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");

    $categoryCell = $workbook->getCell(0, "C8", "Leaf8");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $valueCell = $workbook->getCell(0, "D1", 4);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D2", 5);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D3", 3);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D4", 6);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D5", 9);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D6", 9);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D7", 4);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D8", 3);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);

    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);

    $presentation->save("Treemap.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

النتيجة:

![مخطط الشجرة](treemap_chart.png)

### **إنشاء مخططات الشلال**

يوضح مخطط الشلال كيف تُسهم التغييرات الإيجابية والسلبية في القيمة النهائية. على سبيل المثال، يمكن أن يبدأ تحليل الربح بالإيرادات، ثم يُخصم التكاليف، ويُضاف دخل آخر. تتقاطر أعمدة التغيير بين القيمة السابقة والجديدة، بينما تمتد الأعمدة الكلية من الصفر إلى القيمة المتراكمة.

| الفئة | قيمة دفتر العمل | نوع العمود |
| --- | ---: | --- |
| Revenue | 1000 | زيادة |
| Cost of sales | -400 | نقصان |
| Gross profit | 600 | مجموع وسيط |
| Operating expenses | -200 | نقصان |
| Other income | 50 | زيادة |
| Net profit | 450 | المجموع النهائي |

لتمييز نقطة على أنها مجموع وسيط أو نهائي، استدعِ طريقة [setSetAsTotal](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setsetastotal/) مع القيمة `true`. قدم المبلغ المتراكم الفعلي في خلية دفتر العمل لتلك النقطة: `600` للربح الإجمالي (`1000 - 400`) و `450` للربح الصافي (`600 - 200 + 50`). تقوم الطريقة بتمييز العمود كإجمالي؛ لا تقوم بحساب أو ملء قيمة الخلية. لا تستخدم الصفر كعنصر نائب أو تقدم تغييرًا آخر لنقطة إجمالية. تعرض العمود الإجمالي القيمة المتراكمة دون إضافتها مرة أخرى إلى القيمة المتغيرة.

ينشئ هذا المثال الكامل للـ PHP مخططًا باستخدام العنصر `Waterfall` من تعداد [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/)، يُزيل البيانات الافتراضية، ويملأ دفتر العمل المضمن. يختار فهرس ورقة العمل `0` الورقة الأولى؛ العمود A يحتوي على أسماء الفئات والعمود B يحتوي على القيم. تُضاف كل خلية قيمة باستخدام [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/adddatapointforwaterfallseries/). تُحدد مؤشرات النقاط الصفرية `2` و`5` المجموعات الوسيطة والنهائية. استدعاء [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) مع `true` يُظهر المبالغ على الأعمدة. لا يتطلب الأمر عرضًا تقديميًا أو دفتر عمل كمدخل.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Waterfall, 20, 20, 680, 200);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Profit breakdown (USD thousands)");
    $chart->getChartTitle()->setOverlay(false);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $workbook->clear($worksheetIndex);

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Profit");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Waterfall);
    $categories = [ "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" ];
    $values = [ 1000, -400, 600, -200, 50, 450 ];

    for ($i = 0; $i < count($categories); $i++)
    {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categories[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForWaterfallSeries($valueCell);
    }

    // النقطة الثالثة والسادسة تمثل إجماليات، ليست تغييرات إضافية.
    $series->getDataPoints()->get_Item(2)->setSetAsTotal(true);
    $series->getDataPoints()->get_Item(5)->setSetAsTotal(true);
    $series->setShowConnectorLines(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("WaterfallChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

استدعِ طريقة مستوى السلسلة [setShowConnectorLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setshowconnectorlines/) مع `true` لإظهار الخطوط التي تربط الأعمدة المتتالية وتسهيل تتبع القيمة المتغيرة. لإخفاء هذه الخطوط، استبدل استدعاء الطريقة في المثال بـ `$series->setShowConnectorLines(false);` قبل الحفظ. يغيّر هذا فقط رؤية الخط، وليس البيانات أو المجاميع.

يعرض العرض التقديمي المحفوظ ربحًا إجماليًا قدره 600 وربحًا صافيًا قدره 450، مع رسم كلا المجموعين من الصفر:

![مخطط شلال يُظهر الإيرادات، التكاليف، الربح الإجمالي 600، والربح الصافي 450، مع علامات القيم وخطوط الوصل](waterfall_chart.png)

### **إنشاء مخططات الأسهم**

تُستخدم مخططات الأسهم لعرض البيانات المالية مثل أسعار الفتح والارتفاع والانخفاض والإغلاق، مما يساعد في تحليل اتجاهات السوق وتقلباته. توفر رؤى أساسية حول أداء الأسهم، مما يساعد المستثمرين والمحللين على اتخاذ قرارات مستنيرة.

ينشئ هذا المثال مخططًا من نوع فتح-ارتفاع-انخفاض-إغلاق مع أربع سلاسل بالترتيب المذكور وثلاث فئات. تُفعّل طريقة [setUpDownBars](https://reference.aspose.com/slides/php-java/aspose.slides/updownbarsmanager/setupdownbars/) أشرطة الصعود/الهبوط، وتتحكم طريقة [getHiLowLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/gethilowlinesformat/) في خطوط الارتفاع‑الانخفاض التي تُظهر نطاقات الأسعار، بينما تُخفي خطوط السلاسل الفردية وشبكات الأفقية الصغرى.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::OpenHighLowClose, 20, 20, 500, 300, false);

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $categoryCell = $workbook->getCell(0, 1, 0, "A");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 2, 0, "B");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 3, 0, "C");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Open");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 2, "High");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 3, "Low");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 4, "Close");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $valueCell = $workbook->getCell(0, 1, 1, 72);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 1, 25);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 1, 38);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $valueCell = $workbook->getCell(0, 1, 2, 172);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 2, 57);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 2, 57);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $valueCell = $workbook->getCell(0, 1, 3, 12);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 3, 12);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 3, 13);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $valueCell = $workbook->getCell(0, 1, 4, 25);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 4, 38);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 4, 50);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++)
    {
        $stockSeries = $chart->getChartData()->getSeries()->get_Item($i);
        $stockSeries->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    $presentation->save("Stock-chart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

النتيجة:

![مخطط الأسهم](stock_chart.png)

### **إنشاء مخططات الصندوق والشارب**

تُستخدم مخططات الصندوق والشارب لعرض توزيع البيانات من خلال تلخيص المقاييس الإحصائية الرئيسية، مثل الوسيط والربعيات والقيم المتطرفة المحتملة. إنها مفيدة بشكل خاص في التحليل الاستكشافي للبيانات والدراسات الإحصائية لفهم التباين بسرعة وتحديد أي شذوذ.

ينشئ هذا المثال مخطط صندوق وشارب من ست قيم. تُحدد طريقة [setQuartileMethod](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setquartilemethod/) طريقة حساب الربعيات الحصرية. كما يُمكّن المثال خطوط المتوسط، وعلامات المتوسط، والنقاط الداخلية، ونقاط القيم المتطرفة.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\QuartileMethodType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::BoxAndWhisker, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A1", "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A2", "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A3", "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A4", "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A5", "Category 5");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A6", "Category 6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);

    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);

    $valueCell = $workbook->getCell(0, "B1", 15);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B2", 41);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B3", 16);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B4", 10);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B5", 23);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B6", 16);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);

    $presentation->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

### **إنشاء مخططات القمع**

تُستخدم مخططات القمع لتصور العمليات التي تشمل مراحل متسلسلة، حيث يقل حجم البيانات مع تقدمها من خطوة إلى أخرى. إنها مفيدة بشكل خاص لتحليل معدلات التحويل، وتحديد الاختناقات، وتتبع كفاءة عمليات المبيعات أو التسويق.

يستخدم هذا المثال الدالة [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) لإضافة مخطط قمع إلى الشريحة الأولى من عرض تقديمي موجود. يستبدل البيانات الافتراضية بست فئات وقيم تتراوح بين 50 و500، ثم يحفظ العرض التقديمي المحدث. يجب أن يحتوي العرض التقديمي المدخل على شريحة واحدة على الأقل.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A1", "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A2", "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A3", "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A4", "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A5", "Category 5");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A6", "Category 6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);

    $valueCell = $workbook->getCell(0, "B1", 50);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B2", 100);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B3", 200);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B4", 300);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B5", 400);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B6", 500);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);

    $presentation->save("Funnel.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

النتيجة:

![مخطط القمع](funnel_chart.png)

### **إنشاء مخططات شمسية**

تُستخدم مخططات الشمسيّة (Sunburst) لتصور البيانات الهرمية، حيث تُظهر المستويات كحلقات متداخلة. تساعد على توضيح العلاقات بين الجزء والكل وتُعد مثالية لتمثيل الفئات المتداخلة والفرعيات بصيغة واضحة ومضغوطة.

ينشئ هذا المثال مخططًا شمسياً يحتوي على ثمانية أوراق مُجَمَّعة في أربعة سيقان وفرعين. تُعطي طريقة [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) السيقان في المستوى التجميعي 1 والفروع في المستوى 2. تُحدد تسميات الفئات القطاعات، وتحدد القيم أحجامها النسبية.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Sunburst, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // الفرع 1
    $categoryCell = $workbook->getCell(0, "C1", "Leaf1");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");

    $categoryCell = $workbook->getCell(0, "C2", "Leaf2");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C3", "Leaf3");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");

    $categoryCell = $workbook->getCell(0, "C4", "Leaf4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    // الفرع 2
    $categoryCell = $workbook->getCell(0, "C5", "Leaf5");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");

    $categoryCell = $workbook->getCell(0, "C6", "Leaf6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C7", "Leaf7");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");

    $categoryCell = $workbook->getCell(0, "C8", "Leaf8");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $valueCell = $workbook->getCell(0, "D1", 4);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D2", 5);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D3", 3);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D4", 6);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D5", 9);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D6", 9);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D7", 4);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D8", 3);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);

    $presentation->save("Sunburst.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

النتيجة:

![المخطط الشمسي](sunburst_chart.png)

### **إنشاء مخططات هيستوجرام**

تُظهر مخططات الهيستوجرام كيفية توزيع القيم الرقمية عبر فترات (bins). لتقارير شهرية عن أوقات معالجة الطلبات، استخدم عرض bin موحد وع thresholds للحفاظ على استمرارية الفواصل وجعل المقارنات أسهل.

استدعِ [setAggregationType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaggregationtype/) على المحور الأفقي باستخدام وضع من [AxisAggregationType](https://reference.aspose.com/slides/php-java/aspose.slides/axisaggregationtype/). يُطبق [setBinWidth](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setbinwidth/) فقط عند اختيار `ByBinWidth`؛ ويُطبق [setNumberOfBins](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberofbins/) فقط عند اختيار `ByNumberOfBins`. استخدم `Automatic` للسماح للمخطط باختيار الفواصل.

#### **استخدام عرض فاصل ثابت**

يُجمع هذا المثال أوقات المعالجة في فواصل زمنية مدتها 10 دقائق، مع فواصل منفصلة للأوقات التي تكون ≤ 10 دقائق وتلك التي > 40 دقيقة. فعل هذه الفواصل باستخدام [setUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setunderflowbin/) و[setOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setoverflowbin/). عند توفير حدود صريحة عبر [setUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setunderflowbin/) و[setOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setoverflowbin/)، استدعِ [setAutomaticUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticunderflowbin/) و[setAutomaticOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticoverflowbin/) بالقيمة `false`.

```php
use aspose\slides\AxisAggregationType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Histogram, 20, 20, 680, 200);

    $chart->setLegend(false);
    $chart->setTitle(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
    $values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for ($i = 0; $i < count($values); $i++)
    {
        $valueCell = $workbook->getCell(0, $i, 0, $values[$i]);
        $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setAggregationType(AxisAggregationType::ByBinWidth);
    $axis->setBinWidth(10);
    $axis->setUnderflowBin(true);
    $axis->setAutomaticUnderflowBin(false);
    $axis->setUnderflowBin(10);
    $axis->setOverflowBin(true);
    $axis->setAutomaticOverflowBin(false);
    $axis->setOverflowBin(40);

    $presentation->save("Histogram-bin-width.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

يعرض العرض التقديمي في PowerPoint عدد الفواصل **3, 4, 4, 4, و 2**. تشمل الفئة السفلية القيم `5, 10, 10`، لذا فإن حدها شامل. تشمل الفئة العلوية فقط القيم `41, 50`، لذا فإن حدها حصري؛ كلا القيمتين المتساويتين لـ `40` يبقيان في الفاصل السابق. تحتوي الفواصل الداخلية على قيم أكبر من حدها الأدنى وأقل من أو تساوي حدها العلوي.

![هيستوجرام بفواصل 10 دقائق وحدود سفلية وعليا صريحة](histogram_bin_width.png)

#### **تحديد عدد الفواصل**

للحصول على مستوى ثابت من التفاصيل بدلاً من فواصل ثابتة، اطلب خمسة فواصل لنفس البيانات. يترك هذا المثال فواصل السفلية والعلوية معطلة. يحدد المخطط العرض بناءً على نطاق البيانات، لذا قد تتغير الحدود بين التقارير.

```php
use aspose\slides\AxisAggregationType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Histogram, 20, 20, 680, 200);

    $chart->setLegend(false);
    $chart->setTitle(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
    $values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for ($i = 0; $i < count($values); $i++)
    {
        $valueCell = $workbook->getCell(0, $i, 0, $values[$i]);
        $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setAggregationType(AxisAggregationType::ByNumberOfBins);
    $axis->setNumberOfBins(5);

    $presentation->save("Histogram-bin-count.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

تحمل الفواصل الخمسة عددًا **4, 4, 4, 4, و 1**. قارن هذا التوزيع مع نتيجة العرض الثابت أعلاه: قيم الإدخال متطابقة، لكن الحدود مختلفة.

![هيستوجرام بخمسة فواصل محسوبة من نفس البيانات](histogram_bin_count.png)

### **إنشاء مخططات رادار**

تُستخدم مخططات الرادار لعرض بيانات متعددة المتغيرات في صيغة ثنائية الأبعاد، مما يتيح مقارنة سهلة لعدة متغيرات في وقت واحد. إنها مفيدة بشكل خاص لتحديد الأنماط، والقوة، والضعف عبر مجموعة متعددة من مؤشرات الأداء أو السمات.

يستخدم هذا المثال الدالة [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) لإنشاء مخطط رادار مع السلسلة والفئات الافتراضية، ثم يحفظ العرض التقديمي كملف PPTX.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addChart(ChartType::Radar, 20, 20, 500, 300);

    $presentation->save("Radar-chart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

النتيجة:

![مخطط الرادار](radar_chart.png)

### **إنشاء مخططات متعددة الفئات**

تُستخدم مخططات متعددة الفئات لعرض البيانات التي تنطوي على أكثر من تجميع تصنيفي واحد، مما يتيح مقارنة القيم عبر أبعاد متعددة في آن واحد. إنها مفيدة بشكل خاص عندما تحتاج إلى تحليل الاتجاهات والعلاقات داخل مجموعات بيانات معقدة ومتعددة الطبقات.

ينشئ هذا المثال مخطط أعمدة مجمّع يحتوي على ثمان فئات مرتبة في أربعة أزواج. تُعطي طريقة [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) كل زوج تسمية مشتركة في المستوى التجميعي 1، ما ينتج محور فئات يحتوي على تسميات فردية ومجموعة.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $worksheetIndex = 0;

    $categoryCell = $workbook->getCell(0, "c2", "A");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $categoryCell = $workbook->getCell(0, "c3", "B");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c4", "C");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $categoryCell = $workbook->getCell(0, "c5", "D");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c6", "E");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $categoryCell = $workbook->getCell(0, "c7", "F");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c8", "G");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $categoryCell = $workbook->getCell(0, "c9", "H");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, "D1", "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $valueCell = $workbook->getCell($worksheetIndex, "D2", 10);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D3", 20);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D4", 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D5", 40);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D6", 50);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D7", 60);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D8", 70);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D9", 80);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

النتيجة:

![مخطط متعدد الفئات](multi_category_chart.png)

### **إنشاء مخططات الخريطة**

تُستخدم مخططات الخريطة لتصور البيانات الجغرافية عن طريق ربط المعلومات بمواقع محددة مثل الدول أو الولايات أو المدن. إنها مفيدة بشكل خاص لتحليل الاتجاهات الإقليمية، والبيانات الديموغرافية، والتوزيع المكاني بطريقة واضحة وجذابة بصريًا.

يستخدم هذا المثال الدالة [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) لإنشاء مخطط خريطة مع البيانات الجغرافية الافتراضية ويحفظه للعرض في PowerPoint.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Map, 20, 20, 500, 300);

    $presentation->save("mapChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

النتيجة:

![مخطط الخريطة](map_chart.png)

{{% alert color="info" title="Note" %}}
الصورة أعلاه تُظهر العرض التقديمي المحفوظ مفتوحًا في PowerPoint. تقوم Aspose.Slides بكتابة مخطط الخريطة وبياناته بشكل صحيح، لكنها لا ترسم مخططات الخريطة نفسها: عندما يتم تحويل شريحة تحتوي على مخطط إلى صورة أو تحويلها إلى PDF أو SVG، يصبح مساحة المخطط فارغة. الأشكال الأخرى على نفس الشريحة لا تتأثر.
{{% /alert %}}

### **إنشاء مخططات مركبة**

يُدمج مخطط مركب (أو مخطط كومبو) نوعين أو أكثر من المخططات في رسم بياني واحد. يتيح هذا المخطط إبراز، مقارنة، أو فحص الفروق بين مجموعتين أو أكثر من البيانات، مما يساعد على تحديد العلاقات بينها.

![المخطط المركب](combination_chart.png)

يجمع هذا المثال سلسلتين من الأعمدة المتجمعة مع سلسلة خطية عبر أربع فئات. تستخدم الأعمدة المحور الرأسي الأساسي، بينما تُضع طريقة [setPlotOnSecondAxis](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setplotonsecondaxis/) الخط على محور رأسي ثانوي على اليمين. تقوم الدوال المساعدة بتهيئة العنوان، والوسيلة الإيضاحية، وتسميات المحاور، وخطوط الشبكة.

```php
use aspose\slides\AxisPositionType;
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\FillType;
use aspose\slides\LegendPositionType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function createComboChart()
{
    $presentation = new Presentation();
    try
    {
        $chart = createChartWithFirstSeries($presentation->getSlides()->get_Item(0));

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    }
    finally
    {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide)
{
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $portionFormat = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $portionFormat->setFontBold(NullableBool::False);
    $portionFormat->setFontHeight(18);

    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $categoryCell = $workbook->getCell($worksheetIndex, 1, 0, "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 2, 0, "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 3, 0, "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 4, 0, "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 4.3);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 2.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 3.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 1, 4.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    return $chart;
}

function addSecondSeriesToChart($chart)
{
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 2, 2.4);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 2, 4.4);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 2, 1.8);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 2, 2.8);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
}

function addThirdSeriesToChart($chart)
{
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 3, 2.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 3, 2.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 3, 3.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 3, 5.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart)
{
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 217, 217, 217);
    $majorGridLinesFormat->getSolidFillColor()->setColor($color);
}

function setSecondaryAxesFormat($chart)
{
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle)
{
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titlePortionFormat = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $titlePortionFormat->setFontBold(NullableBool::False);
    $titlePortionFormat->setFontHeight(12);
}

createComboChart();
```

## **تحديث المخططات**

تمكّنك Aspose.Slides للـ PHP عبر Java من تحديث مخططات PowerPoint عن طريق تعديل بيانات المخطط، وتنسيقه، وتشكيله. تُبسّط هذه الوظيفة عملية إبقاء العروض التقديمية محدثة بمحتوى ديناميكي وتضمن أن المخططات تعكس البيانات الحالية والمعايير البصرية بدقة.

يقوم هذا المثال بتحديث المخطط المسمى "My chart" على الشريحة الأولى من عرض تقديمي موجود. يتطلب سلسلتين من الأعمدة تحتوي كل منهما على ثلاث نقاط بيانات، مع تسميات الفئات في العمود A وأسماء السلاسل في الصف الأول من الورقة الأولى. يستخدم المثال [getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) لتغيير خلايا دفتر العمل، يحدّث قيم السلسلة، يضيف سلسلة ثالثة، ويغيّر شكل المخطط إلى أسطوانات مجمّعة عبر [setType](https://reference.aspose.com/slides/php-java/aspose.slides/chart/settype/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$chartName = "My chart";
$chartClass = new JavaClass("com.aspose.slides.IChart");

$presentation = new Presentation("ExistingChart.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++)
    {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartClass) && $chartName === java_values($shape->getName()))
        {
            $chart = $shape;
            $worksheetIndex = 0;

            $workbook = $chart->getChartData()->getChartDataWorkbook();

            $workbook->getCell($worksheetIndex, 1, 0, "Modified Category 1");
            $workbook->getCell($worksheetIndex, 2, 0, "Modified Category 2");

            $series = $chart->getChartData()->getSeries()->get_Item(0);

            $workbook->getCell($worksheetIndex, 0, 1, "New_Series 1");
            $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
            $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
            $series->getDataPoints()->get_Item(2)->getValue()->setData(44);

            $series = $chart->getChartData()->getSeries()->get_Item(1);

            $workbook->getCell($worksheetIndex, 0, 2, "New_Series 2");
            $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
            $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
            $series->getDataPoints()->get_Item(2)->getValue()->setData(99);

            $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
            $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

            $valueCell = $workbook->getCell($worksheetIndex, 1, 3, 20);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
            $valueCell = $workbook->getCell($worksheetIndex, 2, 3, 50);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
            $valueCell = $workbook->getCell($worksheetIndex, 3, 3, 30);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);

            $chart->setType(ChartType::ClusteredCylinder);
        }
    }

    $presentation->save("AsposeChartModified.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **تحديد نطاق البيانات لمخطط**

لتفحص النطاق المستخدم بالفعل من قبل مخطط موجود، راجع [Retrieve a Chart's Data Range](/slides/ar/php-java/chart-workbook/#retrieve-a-charts-data-range).

توفر Aspose.Slides للـ PHP عبر Java المرونة لتعريف نطاق بيانات محدد من ورقة العمل كمصدر لبيانات مخططاتك. يتيح لك ذلك ربط جزء من ورقة العمل بالمخطط مباشرةً، مما يسمح لك بالتحكم في الخلايا التي تساهم في سلاسل المخطط وفئاته. نتيجةً لذلك، يمكنك بسهولة تحديث ومزامنة مخططاتك مع أحدث التغييرات في البيانات داخل ورقة العمل، لضمان أن عروض PowerPoint تعكس معلومات حديثة ودقيقة.

يستخدم هذا المثال [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) لتعيين مصدر البيانات للمخطط المسمى "My chart" على الشريحة الأولى من عرض تقديمي موجود إلى `Sheet1!A1:B4`. يجب أن يحتوي دفتر عمل المخطط على تلك الورقة ونطاق مملوء يحتوي على عنوان السلسلة في الصف الأول، وتسميات الفئات في العمود A، وثلاث قيم في العمود B.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$chartName = "My chart";
$chartClass = new JavaClass("com.aspose.slides.IChart");

$presentation = new Presentation("ExistingChart.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++)
    {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartClass) && $chartName === java_values($shape->getName()))
        {
            $chart = $shape;
            $chart->getChartData()->setRange("Sheet1!A1:B4");
        }
    }

    $presentation->save("SetDataRange.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **استخدام العلامات الافتراضية في المخططات**

عند استخدام العلامات الافتراضية في المخططات، يحصل كل سلسلة مخطط على رمز علامة افتراضي مختلف تلقائيًا.

يستخدم هذا المثال الدالة [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) لإنشاء مخطط يحتوي على سلسلتين خطيتين ووسيلة إيضاح. تُحافظ إعدادات العلامة المستخرجة عبر [getMarker](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getmarker/) على رموز العلامات المُعينة تلقائيًا. تتضمن السلسلة الأولى قيمة سلبية وقيمة مفقودة، تمثلها `null`، بينما تحتوي السلسلة الثانية على قيمة لكل فئة.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $categoryCell = $workbook->getCell(0, 1, 0, "C1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 1, 1, 24);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 2, 0, "C2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 2, 1, 23);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 3, 0, "C3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 3, 1, -10);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 4, 0, "C4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 4, 1, null);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $seriesNameCell = $workbook->getCell(0, 0, 2, "Series 2");
    $secondSeries = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $valueCell = $workbook->getCell(0, 1, 2, 30);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 2, 10);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 2, 60);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 4, 2, 40);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);

    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);

    $presentation->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **الأسئلة الشائعة**

**ما هي أنواع المخططات التي تدعمها Aspose.Slides للـ PHP عبر Java؟**

تدعم Aspose.Slides للـ PHP عبر Java مجموعة واسعة من أنواع المخططات، بما في ذلك المخططات الشريطية، الخطية، الدائرية، المساحية، المبعثرة، الهيستوجرام، الرادار، وغيرها الكثير. تُتيح لك هذه المرونة اختيار نوع المخطط الأنسب لاحتياجاتك في تصور البيانات.

**كيف يمكنني إضافة مخطط جديد إلى شريحة؟**

لإضافة مخطط، تقوم أولاً بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)، تستعرِض الشريحة المطلوبة باستخدام فهرسها، ثم تستدعي الطريقة لإضافة مخطط، مع تحديد نوع المخطط والبيانات الأولية. يدمج هذا العملية المخطط مباشرةً في العرض التقديمي.

**كيف يمكنني تحديث البيانات المعروضة في المخطط؟**

يمكنك تحديث بيانات المخطط بالوصول إلى دفتر بياناته ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/))، مسح أي سلاسل وفئات افتراضية، ثم إضافة بياناتك المخصصة. يتيح لك ذلك تحديث المخطط برمجيًا ليعكس أحدث البيانات.

**هل يمكن تخصيص مظهر المخطط؟**

نعم، توفر Aspose.Slides للـ PHP عبر Java خيارات تخصيص واسعة. يمكنك تعديل الألوان، الخطوط، العلامات، الوسائل الإيضاحية، والعناصر التنسيقية الأخرى لتكييف مظهر المخطط وفقًا لمتطلبات التصميم الخاصة بك.