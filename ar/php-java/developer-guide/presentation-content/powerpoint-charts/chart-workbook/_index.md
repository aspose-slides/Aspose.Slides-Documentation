---
title: إدارة دفاتر عمل المخططات في العروض التقديمية باستخدام PHP
linktitle: دفتر عمل المخطط
type: docs
weight: 70
url: /ar/php-java/chart-workbook/
keywords:
- دفتر عمل المخطط
- بيانات المخطط
- خلية دفتر العمل
- تسمية البيانات
- ورقة العمل
- مصدر البيانات
- دفتر عمل خارجي
- بيانات خارجية
- ذاكرة مخبئ المخطط
- استعادة دفتر العمل
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "اكتشف Aspose.Slides for PHP عبر Java: إدارة دفاتر عمل المخططات بسهولة في صيغ PowerPoint وOpenDocument لتبسيط بيانات عرضك التقديمي."
---
## **نظرة عامة**

توضح هذه المقالة كيفية العمل مع دفاتر عمل المخطط في Aspose.Slides. تُظهر كيفية قراءة وكتابة بيانات المخطط عبر تدفقات دفتر العمل، واستخدام خلايا دفتر العمل كعناوين بيانات المخطط، والوصول إلى مجموعات أوراق العمل، وتحديد نوع مصدر البيانات لقيم المخطط.

كما تغطي العمل مع دفاتر عمل خارجية كمصادر بيانات للمخططات. توضح الأمثلة كيفية إنشاء وتعيين دفتر عمل خارجي، واستخراج مسار دفتر العمل الخارجي المرتبط بمخطط، وتحرير بيانات المخطط عندما يكون دفتر العمل متاحًا.

لخلايا دفتر العمل التي تمثل بيانات مفقودة، راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/php-java/chart-series/) لمعرفة الفرق بين الخلية الفارغة والصفر، ومقارنة مخطط خطي للوضعيات المتاحة للعرض.

## **تضمين البيانات من الصفوف والأعمدة المخفية**

استخدم [Chart::setPlotVisibleCellsOnly](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setplotvisiblecellsonly/) للتحكم فيما إذا كان المخطط يرسم البيانات من صفوف وأعمدة ورقة العمل المخفية. اضبطه على `true` لرسم الخلايا الظاهرة فقط، أو `false` لتضمين كل من الخلايا الظاهرة والمخفية. هذا الإعداد يتحكم في رسم المخطط؛ ولا يخفي أو يُظهر صفوف أو أعمدة ورقة العمل.

العرض التقديمي [sample presentation](hidden-source-data.pptx) يحتوي على مخطط عمودي كأول شكل في شريحته الأولى. ورقة العمل المدمجة، `Sheet1`، تحتوي على النطاق المصدر التالي، `A1:C4`. الصف 3 والعمود C مخفيان، لكن خلاياهما لا تزال تحتوي على قيم.

| صف ورقة العمل | A: الشهر | B: التجزئة | C: الجملة (عمود مخفي) |
| --- | --- | --- | --- |
| 2 | يناير | 10 | 30 |
| 3 (صف مخفي) | فبراير | 40 | 60 |
| 4 | مارس | 20 | 50 |

الوصول إلى خلايا المصدر عبر [ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/) وقراءة [ChartDataCell::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/ishidden/) لفحص حالتها المخفية. تُظهر هذه الطريقة الحالة المخفية دون تغييرها. في هذا الملف، B2 مرئية، B3 تنتمي إلى الصف المخفي، وC2 تنتمي إلى العمود المخفي؛ المثال يطبع `false`، `true`، و`true` على التوالي.

في هذا المثال، قم بتحديث بيانات المخطط بعد تغيير إعداد الرسم: احتفظ بدفتر العمل المدمج باستخدام [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) وأعد تحميله باستخدام [writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/). عند تضمين كل الخلايا، استخدم أيضاً [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) لاستعادة النطاق الكامل، بما في ذلك فئة فبراير المخفية. مجرد تغيير العلامة غير كافٍ لتحديث بيانات المخطط المخزنة مؤقتًا وتسميات الفئات في هذا المثال.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hidden-source-data.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $workbook = $chart->getChartData()->getChartDataWorkbook();
        echo "B2 hidden: " . (java_values($workbook->getCell(0, "B2")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "B3 hidden: " . (java_values($workbook->getCell(0, "B3")->isHidden()) ? "true" : "false"), PHP_EOL;
        echo "C2 hidden: " . (java_values($workbook->getCell(0, "C2")->isHidden()) ? "true" : "false"), PHP_EOL;

        $workbookData = $chart->getChartData()->readWorkbookStream();
        foreach ([true, false] as $visibleOnly) {
            $chart->setPlotVisibleCellsOnly($visibleOnly);

            // تحديث بيانات المخطط من دفتر العمل المدمج.
            $chart->getChartData()->writeWorkbookStream($workbookData);
            if (!$visibleOnly) {
                // استعادة نطاق المصدر الكامل، بما في ذلك الفئات المخفية.
                $chart->getChartData()->setRange('Sheet1!$A$1:$C$4');
            }

            $presentation->save("hidden_cells_" . ($visibleOnly ? "true" : "false") . ".pptx", SaveFormat::Pptx);
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

يحفظ المثال نسخةين من العرض التقديمي: واحدة تحتوي فقط على قيم التجزئة الظاهرة (10 و20)، وأخرى تحتوي على جميع القيم الست. توضح الصور أدناه وضعية الرسمتين. يظل الصف 3 والعمود C مخفيين في كلا دفترَي العمل المدمجين.

| الخلايا الظاهرة فقط (`true`) | كل الخلايا (`false`) |
| --- | --- |
| ![الخلايا الظاهرة فقط: قيم التجزئة 10 و 20 لشهري يناير ومارس.](hidden_cells_True.png) | ![كل الخلايا: قيم التجزئة والجملة لشهري يناير وفبراير ومارس.](hidden_cells_False.png) |

الخلية المخفية التي تحتوي على قيمة تختلف عن الخلية الفارغة. يتحكم [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) في طريقة عرض القيم المفقودة؛ ولا يضيف أو يستبعد بيانات المصدر المخفية. راجع [التحكم في عرض الخلايا الفارغة](/slides/ar/php-java/chart-series/#control-the-display-of-empty-cells) لمثال.

## **استعادة نطاق بيانات المخطط**

قبل تحديث بيانات دفتر العمل في عرض تقديمي موجود، افحص نطاقات المصدر لتحديد خلايا ورقة العمل التي يستخدمها كل مخطط. تُعيد طريقة [ChartData::getRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getrange/) النطاق الحالي كصيغة مؤهلة لورقة العمل، مثل `Sheet1!$A$1:$D$5`. هنا، `Sheet1` هو اسم ورقة العمل، `!` يفصلها عن نطاق الخلايا، و`$A$1:$D$5` يحدد الخلايا من A1 إلى D5 شاملًا. تشير علامات الدولار إلى مراجع صف وعمود مطلقة.

تقرأ الطريقة النطاق الحالي دون تغيير المخطط أو دفتر العمل الخاص به. إذا كان المخطط لا يستخدم دفتر عمل كمصدر للبيانات، فإنها تُطلق استثناء. لمزيد من المعلومات، راجع [ChartData API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/).

يفتح هذا المثال عرضًا تقديميًا ويفحص الأشكال مباشرةً في كل شريحة للبحث عن المخططات. يطبع اسم كل مخطط ونطاق المصدر. إذا لم يستخدم المخطط دفتر عمل، يطبع رسالة ويستمر إلى المخطط التالي.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
                $chart = $shape;
                try {
                    $range = $chart->getChartData()->getRange();
                    echo $chart->getName() . ": " . $range, PHP_EOL;
                } catch (JavaException $exception) {
                    if (java_instanceof($exception, new JavaClass("com.aspose.slides.exceptions.InvalidOperationException"))) {
                        echo $chart->getName() . ": The chart does not use a workbook as its data source.", PHP_EOL;
                    } else {
                        echo $chart->getName() . ": " . $exception->getMessage(), PHP_EOL;
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **قراءة وكتابة بيانات المخطط من دفتر عمل**

توفر Aspose.Slides for PHP via Java الطريقتين [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) و[writeWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/writeworkbookstream/) اللتين تسمحان لك بقراءة وكتابة دفاتر عمل بيانات المخطط (التي تحتوي على بيانات المخطط التي تم تحريرها عبر Aspose.Cells). **ملاحظة** أن بيانات المخطط يجب أن تُنظم بنفس الطريقة أو أن تكون لها بنية مشابهة للمصدر.

يستخدم هذا المثال عرضًا تقديميًا يحتوي على مخطط كأول شكل في شريحته الأولى. يقرأ دفتر العمل المدمج إلى مصفوفة بايت، يمسح السلاسل والفئات الحالية، ثم يكتب نفس دفتر العمل مرة أخرى. تظل التغييرات في الذاكرة؛ ولا يحفظ المثال العرض التقديمي.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **التحقق من تخطيط المخطط بعد تعديل دفتر العمل**

عند استبدال دفتر العمل المدمج بآخر معدل، يحتفظ المخطط بسلسلاته ومجموعات فئاته الأصلية. يمكن أن يتسبب هذا التعارض في فشل [Chart::validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) مع خطأ "index-out-of-range". قم بمسح السلاسل والفئات الحالية قبل كتابة دفتر العمل المحدث مرة أخرى إلى المخطط. يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى. العلامة التعليق تحدد مكان تحرير دفتر العمل؛ المثال القابل للتنفيذ يكتب دفتر العمل الأصلي مرة أخرى ويُصادق على التخطيط في الذاكرة.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("chart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        $workbookData = $chartData->readWorkbookStream();

        // تعديل بايتات دفتر العمل هنا، على سبيل المثال، باستخدام Aspose.Cells.

        $chartData->getSeries()->clear();
        $chartData->getCategories()->clear();

        $chartData->writeWorkbookStream($workbookData);
        $chart->validateChartLayout();
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

إزالة المجموعات تزيل المراجع القديمة للبيانات قبل كتابة دفتر العمل مرة أخرى. أعد بناء أي سلاسل أو تعيينات فئات مطلوبة لدفتر العمل المحدث قبل استخدام المخطط.

## **تعيين تنسيقات رقمية مخصصة لخلايا دفتر العمل**

استخدم [ChartDataCell::setCustomNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setcustomnumberformat/) للتحكم في طريقة ظهور القيم الرقمية في دفتر العمل المدمج للمخطط. على سبيل المثال، قد تحتاج تقرير إلى عرض معدل التحويل كنسبة مئوية بأربع منازل عشرية ومعامل بخمس منازل عشرية. احتفظ بالقيمتين كقيم رقمية لتظل متاحة للحسابات ورسم المخطط.

تنسيق الرقم يغيّر العرض فقط، لا القيمة المخزنة. التنسيق `0.0000%` يعرض `0.125` كـ `12.5000%`؛ ولا يستبدل العدد المخزن بـ `12.5`. بالمثل، `0.00000` يعرض `0.1234567` كـ `0.12346` دون تقريب القيمة المخزنة. إذا كان التنسيق المخصص سلسلة فارغة (`""`)، يُستخدم التنسيق الذي تُعيده [getPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/getpresetnumberformat/).

المثال التالي ينشئ مخططًا عموديًا ويصل إلى خلاياه عبر [getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/). في ورقة العمل 0، يحتوي B2 على معدل التحويل وC2 على المعامل. كلا الخليتين تزودان المخطط بالقيم. يُفعِّل المثال أيضًا تسميات القيم المرتبطة بتنسيقات المصدر.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 270, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
    $chart->setTitle(false);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00");
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(0);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A2", "Sample");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $percentageCell = $workbook->getCell(0, "B2", 0.125);
    $percentageCell->setCustomNumberFormat("0.0000%");
    $percentageName = $workbook->getCell(0, "B1", "Conversion rate");
    $percentageSeries = $chart->getChartData()->getSeries()->add($percentageName, $chart->getType());
    $percentageSeries->getDataPoints()->addDataPointForBarSeries($percentageCell);

    $precisionCell = $workbook->getCell(0, "C2", 0.1234567);
    $precisionCell->setCustomNumberFormat("0.00000");
    $precisionName = $workbook->getCell(0, "C1", "Coefficient");
    $precisionSeries = $chart->getChartData()->getSeries()->add($precisionName, $chart->getType());
    $precisionSeries->getDataPoints()->addDataPointForBarSeries($precisionCell);

    for ($seriesIndex = 0; $seriesIndex < java_values($chart->getChartData()->getSeries()->size()); $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $labelFormat = $series->getDataPoints()->get_Item(0)->getLabel()->getDataLabelFormat();
        $labelFormat->setShowValue(true);
        $labelFormat->setNumberFormatLinkedToSource(true);
    }

    $presentation->save("CustomCellFormats.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

تنسيقات خلايا دفتر العمل منفصلة عن التنسيقات التي تُحدّد مباشرةً على محاور المخطط أو تسميات البيانات. في هذا المثال، كل تسمية تُظهر قيمة خلية المصدر لأن [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) مضبوط على `true`، ويتبع تنسيق الرقم المصدر لأن [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) مضبوط على `true`. بعد حفظ وإعادة فتح العرض التقديمي، تُظهر التسميات `12.5000%` و`0.12346` كما هو موضح أدناه. يستخدم المحور العمودي تنسيق رقمي خاص به، يُعيّن عبر [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) كـ `0.00`، مع [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) مضبوط على `false`.

لتنسيق تسمية بيانات بشكل مستقل، عيّن علم ربط المصدر إلى `false` وطبق تنسيقًا عبر [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setnumberformat/). هذا لا يغيّر تنسيق خلية دفتر العمل. على سبيل المثال، تنسيق تسمية مستقل بـ `0.00` يعرض القيمة الأولى كـ `0.13`، بينما لا يزال B2 يعرض `12.5000%`. راجع [Chart Data Labels](/slides/ar/php-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) لتنسيق التسميات مباشرة.

الصورة أدناه تم توليدها من العرض التقديمي المحفوظ بعد إعادة فتحه:

![مخطط عمودي مع تسميات مرتبطة بالمصدر تُظهر 12.5000% و0.12346 ومحور رقمي مُنسق بشكل مستقل.](custom-cell-formats.png)

## **تعيين خلية دفتر العمل كعلامة بيانات المخطط**

يمكنك استخدام النص الموجود في خلايا دفتر العمل كعلامات بيانات للمخطط.

يضيف هذا المثال مخطط فقاعي ببيانات افتراضية إلى الشريحة الأولى من عرض تقديمي موجود. يستخدم الخلايا A10:A12 في ورقة العمل 0 للعلامات الثلاث الأولى في السلسلة الأولى، يُفعِّل العلامات من الخلايا، ويحفظ العرض التقديمي المحدّث.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Bubble, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLabelValueFromCell(true);
    $series->getLabels()->get_Item(0)->setValueFromCell($workbook->getCell(0, "A10", "Label 0 cell value"));
    $series->getLabels()->get_Item(1)->setValueFromCell($workbook->getCell(0, "A11", "Label 1 cell value"));
    $series->getLabels()->get_Item(2)->setValueFromCell($workbook->getCell(0, "A12", "Label 2 cell value"));

    $presentation->save("resultchart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **إدارة أوراق العمل**

توفر طريقة [ChartDataWorkbook::getWorksheets](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getworksheets/) الوصول إلى أوراق العمل في دفتر عمل المخطط. ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويطبع اسم كل ورقة عمل إلى وحدة التحكم.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 500);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    for ($i = 0; $i < java_values($workbook->getWorksheets()->size()); $i++) {
        echo $workbook->getWorksheets()->get_Item($i)->getName(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **تحديد نوع مصدر البيانات**

يمكن أيضًا تخزين قيم نقطة السلسلة مباشرةً كقِلَمات عددية. راجع [Set Series Values Using Numeric Literals](/slides/ar/php-java/chart-series/#set-series-values-using-numeric-literals) للحصول على مثال كامل يحفظها ويقرأها. نوع مصدر قيم النقطة منفصل عن تكوين دفتر العمل الداخلي أو الخارجي للمخطط؛ استخدام القِلَمات العددية لا يزيل دفتر العمل المدمج بحد ذاته.

هذا المثال ينشئ مخطط عمودي ثلاثي الأبعاد ببيانات افتراضية ويضبط اسمين للسلاسل باستخدام مصادر بيانات مختلفة. الاسم الأول يستخدم قِلَم نصي؛ الثاني يستخدم الخلية C1 في ورقة العمل 0. تُحدد تعداد [DataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) المصدر لكل اسم. يحفظ المثال العرض التقديمي بأسماء السلاسل المحدَّثة.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;
use aspose\slides\DataSourceType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $literalName = $chart->getChartData()->getSeries()->get_Item(0)->getName();

    $literalName->setDataSourceType(DataSourceType::StringLiterals);
    $literalName->setData("LiteralString");

    $cellName = $chart->getChartData()->getSeries()->get_Item(1)->getName();
    $nameCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, "C1", "NewCell");
    $cellName->setDataSourceType(DataSourceType::Worksheet);
    $cellName->setData($nameCell);

    $presentation->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **اكتشاف تنسيقات دفاتر العمل المدمجة غير المدعومة**

لا يدعم Aspose.Slides تنسيق دفتر العمل الثنائي Excel (.xlsb) الذي يمكن تضمينه في بعض المخططات. يمكنك استخدام طريقة `getEmbeddedWorkbookType` على [ChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/) مع تعداد [WorkbookType](https://reference.aspose.com/slides/php-java/aspose.slides/workbooktype/) لاكتشاف التنسيقات غير المدعومة وتجاوز تلك المخططات. يفحص هذا المثال الأشكال في الشريحة الأولى من عرض تقديمي موجود، يتخطى الأشكال غير المخططات، ويطبع رسالة تشخيصية لكل مخطط يحتوي على دفتر عمل .xlsb مدمج.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartDataSourceType;
use aspose\slides\WorkbookType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (!java_instanceof($shape, new JavaClass("com.aspose.slides.IChart"))) {
            continue;
        }

        $chart = $shape;
        $chartData = $chart->getChartData();
        $isInternalWorkbook = java_values($chartData->getDataSourceType()) == ChartDataSourceType::InternalWorkbook;
        $isBinaryMacro = java_values($chartData->getEmbeddedWorkbookType()) == WorkbookType::WorkbookBinaryMacro;

        if ($isInternalWorkbook && $isBinaryMacro) {
            echo "Skipping a chart with an unsupported .xlsb workbook.", PHP_EOL;
            continue;
        }

        // قراءة أو تعديل بيانات دفتر العمل للمخطط المدعومة هنا.
    }
} finally {
    $presentation->dispose();
}
```

## **دفتر عمل خارجي**

يدعم Aspose.Slides استخدام دفاتر عمل خارجية كمصدر بيانات للمخططات.

### **إنشاء دفتر عمل خارجي**

استخدم [readWorkbookStream](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/readworkbookstream/) و[setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) لتصدير دفتر عمل مخطط مدمج إلى ملف وربط المخطط بذلك الدفتر الخارجي.

ينشئ هذا المثال مخططًا دائريًا ببيانات افتراضية ويصدر دفتر عمله. يُكمل كتابة الملف قبل تعيين الدفتر الخارجي كمصدر بيانات للمخطط، ثم يحفظ العرض التقديمي المرتبط.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600);
    $workbookPath = new Java("java.io.File", "externalWorkbook1.xlsx");
    $workbookData = $chart->getChartData()->readWorkbookStream();
    try {
        $fileStream = new Java("java.io.FileOutputStream", $workbookPath);
        try {
            $fileStream->write($workbookData);
        } finally {
            $fileStream->close();
        }
        $chart->getChartData()->setExternalWorkbook($workbookPath->getAbsolutePath());
        
        $presentation->save("externalWorkbook.pptx", SaveFormat::Pptx);
    } catch (JavaException $exception) {
        echo "Could not write the external workbook: " . $exception->getMessage(), PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **تعين دفتر عمل خارجي**

باستخدام طريقة [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) يمكنك تعيين دفتر عمل خارجي لمخطط كمصدر بيانات له. يمكن أيضًا استخدام هذه الطريقة لتحديث مسار دفتر العمل الخارجي (في حال تم نقل الملف).

على الرغم من أنك لا تستطيع تحرير البيانات في دفاتر العمل المخزنة في مواقع أو موارد عن بُعد، إلا أنك لا تزال تستطيع استخدامها كمصدر بيانات خارجي. إذا تم توفير مسار نسبي لدفتر عمل خارجي، يتم تحويله تلقائيًا إلى مسار كامل.

يستخدم هذا المثال دفتر عمل خارجي تحتوي ورقة العمل المسماة `Sheet1` على اسم سلسلة في B1، أسماء فئات في A2:A4، وقيم عددية في B2:B4. ينشئ المثال مخططًا دائريًا، يربط دفتر العمل، ويستخدم [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) لتعيين A1:B4 كسلسلة واحدة وثلاث فئات. يحفظ العرض التقديمي بالمخطط المرتبط.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chartData = $chart->getChartData();
    $workbookFile = new Java("java.io.File", "externalWorkbook.xlsx");
    $workbookPath = $workbookFile->getAbsolutePath();

    $chartData->setExternalWorkbook($workbookPath);
    $chartData->setRange('Sheet1!$A$1:$B$4');

    $presentation->save("Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

معامل `updateChartData` لطريقة [setExternalWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setexternalworkbook/) يتحكم فيما إذا كان دفتر العمل محمَّلًا.

* عندما يكون `updateChartData` `false`، يتم تحديث مسار دفتر العمل فقط. لا يتم تحميل أو تحديث بيانات المخطط من دفتر العمل المستهدف، وبالتالي يمكن أن يكون دفتر العمل غير متاح.
* عندما يكون `updateChartData` `true`، يتم تحديث بيانات المخطط من دفتر العمل المستهدف.

المثال التالي يعيّن عنوان URL نائب مع `updateChartData` مضبوطًا على `false`. يحتفظ بالبيانات الافتراضية للمخطط الدائري ويحفظ العرض التقديمي دون تحميل دفتر العمل غير المتاح.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 50, 50, 400, 600, true);
    $chart->getChartData()->setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    $presentation->save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **الحصول على مسار دفتر العمل لمصدر البيانات الخارجي للمخطط**

لتحديد دفتر العمل المرتبط بمخطط، تحقق مما إذا كان المخطط يستخدم مصدر بيانات خارجي واستخرج مسار دفتر العمل.

يفحص هذا المثال الشكل الأول في الشريحة الأولى من عرض تقديمي يحتوي على دفتر عمل خارجي مرتبط. إذا كان مخططًا مرتبطًا بدفتر عمل خارجي، يطبع [getExternalWorkbookPath](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/) إلى وحدة التحكم. ثم يحفظ نسخة من العرض التقديمي.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ChartDataSourceType;

$presentation = new Presentation("externalWorkbook.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $chartData = $chart->getChartData();
        if (java_values($chartData->getDataSourceType()) == ChartDataSourceType::ExternalWorkbook) {
            echo $chartData->getExternalWorkbookPath(), PHP_EOL;
        } else {
            echo "The chart does not use an external workbook.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **تحرير بيانات المخطط**

يمكنك تحرير البيانات في دفاتر العمل الخارجية بنفس الطريقة التي تُجري بها تغييرات على محتويات دفاتر العمل الداخلية. عندما لا يمكن تحميل دفتر عمل خارجي، يُطلق استثناء.

يستخدم هذا المثال مخططًا هو الشكل الأول في الشريحة الأولى ومربوطًا بدفتر عمل خارجي يمكن الوصول إليه. يعيّن القيمة المدعومة بالخلية للنقطة الأولى في السلسلة الأولى إلى 100 ويحفظ العرض التقديمي المحدَّث. تحرير قيم الخلايا يمكن أن يحدث تحديثًا لملف XLSX الخارجي المرتبط، لذا استخدم نسخة إذا كنت بحاجة للحفاظ على دفتر العمل الأصلي.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $series = $chart->getChartData()->getSeries();
        if (java_values($series->size()) > 0 && java_values($series->get_Item(0)->getDataPoints()->size()) > 0) {
            $valueCell = $series->get_Item(0)->getDataPoints()->get_Item(0)->getValue()->getAsCell();
            if (!java_is_null($valueCell)) {
                $valueCell->setValue(100);
                $presentation->save("presentation_out.pptx", SaveFormat::Pptx);
            } else {
                echo "The first data point is not linked to a workbook cell.", PHP_EOL;
            }
        } else {
            echo "The chart has no data points to edit.", PHP_EOL;
        }
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

### **استعادة دفتر العمل من ذاكرة مخبئ المخطط**

إذا كان المخطط يستخدم دفتر عمل خارجي مفقود أو غير متاح، يمكن لـ Aspose.Slides إعادة بناء دفتر عمل المخطط من البيانات المخزنة مؤقتًا في العرض التقديمي. أنشئ [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)، استدعِ [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setspreadsheetoptions/)، واضبط [SpreadsheetOptions::setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/php-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) على `true` قبل فتح العرض التقديمي.

يستعيد مثال PHP التالي بيانات دفتر العمل لمخطط هو الشكل الأول في الشريحة الأولى ويشير إلى دفتر عمل خارجي غير متاح. يصل إلى البيانات المستعادة عبر [Chart::getChartData](https://reference.aspose.com/slides/php-java/aspose.slides/chart/getchartdata/) و[ChartData::getChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getchartdataworkbook/):

```php
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;
use aspose\slides\LoadOptions;

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setRecoverWorkbookFromChartCache(true);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shapeCount = java_values($slide->getShapes()->size());
    if ($shapeCount > 0 && java_instanceof($slide->getShapes()->get_Item(0), new JavaClass("com.aspose.slides.IChart"))) {
        $chart = $slide->getShapes()->get_Item(0);
        $recoveredWorkbook = $chart->getChartData()->getChartDataWorkbook();

        // قراءة أو تعديل بيانات دفتر العمل المسترد هنا.
    } else {
        echo "The first shape is not a chart.", PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

إذا كان دفتر العمل الخارجي غير متاح وتم تعطيل الاستعادة، يُطلق Aspose.Slides استثناء. فعّل الاستعادة فقط عندما يكون استخدام البيانات المخزنة مؤقتًا في المخطط خيارًا مقبولًا، لأن الذاكرة المؤقتة قد لا تحتوي على التغييرات التي أُجريت على دفتر العمل الخارجي بعد آخر تحديث للعرض التقديمي.

## **الأسئلة المتداولة**

**هل يمكنني تحديد ما إذا كان مخطط معين مرتبطًا بدفتر عمل خارجي أو مدمج؟**

نعم. يحتوي المخطط على [نوع مصدر البيانات](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) و[مسار إلى دفتر عمل خارجي](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/); إذا كان المصدر دفتر عمل خارجي، يمكنك قراءة المسار الكامل للتأكد من استخدام ملف خارجي.

**هل تدعم المسارات النسبية لدفاتر العمل الخارجية، وكيف تُخزن؟**

نعم. إذا حددت مسارًا نسبيًا، يتحول تلقائيًا إلى مسار مطلق. يخزن العرض التقديمي المسار المطلق في ملف PPTX، لذا قد يتطلب نقل دفتر العمل تحديث الرابط.

**هل يمكنني استخدام دفاتر عمل موجودة على موارد/مشاركات شبكة؟**

نعم، يمكن استخدام مثل هذه الدفاتر كمصدر بيانات خارجي. ومع ذلك، لا يدعم Aspose.Slides تحرير دفاتر العمل البعيد مباشرةً—يمكن استخدامها فقط كمصدر.

**هل يقوم Aspose.Slides بالكتابة فوق ملف XLSX الخارجي عند حفظ العرض التقديمي؟**

يحفظ العرض التقديمي [رابطًا إلى الملف الخارجي](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getexternalworkbookpath/). تحرير بيانات المخطط المدعومة بالخلية يمكن أن يحدث تحديثًا لملف XLSX المحلي المرتبط. استخدم نسخة من دفتر العمل إذا كان يجب الحفاظ على الأصلي دون تغيير.

**ماذا أفعل إذا كان الملف الخارجي محميًا بكلمة مرور؟**

Aspose.Slides لا تقبل كلمة مرور عند الربط. نهج شائع هو إزالة الحماية مسبقًا أو إعداد نسخة غير مشفرة (على سبيل المثال باستخدام [Aspose.Cells](https://reference.aspose.com/cells/java/)) والربط بهذه النسخة.

**هل يمكن لعدة مخططات الإشارة إلى نفس دفتر العمل الخارجي؟**

نعم. كل مخطط يخزن رابطه الخاص. إذا كانت جميعها تشير إلى الملف نفسه، فإن تحديث ذلك الملف سينعكس على كل مخطط في المرة التالية التي تُحمَّل فيها البيانات.