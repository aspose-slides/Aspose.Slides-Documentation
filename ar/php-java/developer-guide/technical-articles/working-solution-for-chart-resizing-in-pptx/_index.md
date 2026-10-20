---
title: حل عملي لإعادة تحجيم المخطط في PPTX
type: docs
weight: 40
url: /ar/php-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- إعادة تحجيم المخطط
- مخطط Excel
- كائن OLE
- تضمين المخطط
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إصلاح تغيير الحجم غير المتوقع للمخطط في PPTX عند استخدام كائنات Excel OLE المضمنة مع Aspose.Slides لـ PHP عبر Java. ضبط أبعاد المخطط ثابتة للحفاظ على تناسق أحجام المخطط وإطار OLE."
---
## **نظرة عامة**

يمكن أن تتغير أحجام مخططات Excel المدمجة ككائنات OLE في عروض PowerPoint باستخدام مكونات Aspose بعد تفعيلها لأول مرة. يمكن أن يؤدي ذلك إلى فرق ملحوظ في مظهر المخطط قبل وبعد التفعيل. تُوضح هذه المقالة سبب حدوث تغيير الحجم وتظهر كيفية منعه عن طريق مطابقة أبعاد المخطط الثابتة مع إطار OLE.

في [إنشاء مخططات Excel وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، شرحنا كيفية إنشاء مخطط Excel باستخدام Aspose.Cells for PHP via Java وتضمينه في عرض PowerPoint باستخدام Aspose.Slides for PHP via Java. لمعالجة [مشكلة معاينة الكائن](/slides/ar/php-java/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة المخطط إلى إطار كائن OLE الخاص بالمخطط. في العرض الناتج، عندما تنقر مزدوجًا على إطار كائن OLE الذي يعرض صورة المخطط، يتم تفعيل مخطط Excel. يمكن للمستخدمين تحرير دفتر العمل المضمّن ثم العودة إلى الشريحة بالنقر خارج دفتر العمل المفعَّل. يتغيير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة، وتختلف نسبة تغيير الحجم اعتمادًا على الأحجام الأصلية لكل من إطار كائن OLE ودفتر عمل Excel المضمّن.

## **سبب تغيير الحجم**

يملك دفتر العمل المضمّن أبعاد نافذة خاصة به، تحاول Excel الحفاظ عليها عند تفعيل الكائن لأول مرة. يمتلك إطار OLE على الشريحة أبعادًا معرفة بشكل مستقل. عند تفعيل دفتر العمل، تتفاوض Excel وPowerPoint على حجم الكائن للحفاظ على نسبه كجزء من عملية التضمين. لذلك يمكن للاختلافات بين نافذة دفتر العمل وإطار OLE أن تتسبب في تغيير حجم الكائن.

## **الحل العملي**

طابق حجم المخطط مع إطار OLE على الشريحة واحتفظ بأبعاد المخطط مستقلة عن نافذة دفتر العمل. يعمل هذا الحل مع عرض جديد أو قالب موجود.

يتطلب المثال Aspose.Cells for PHP via Java وAspose.Slides for PHP via Java. قم بتكوين المنتجين باستخدام نفس مثال PHP/Java Bridge، وحمِّل كلاّ الغلافين PHP، واجعل مكتبتَي Java متاحتين للجسر. لا توجد ملفات إدخال مطلوبة. ينشئ مثالًا بسيطًا لمخطط عمودي على ورقة مخطط نشطة ويضمّن دفتر العمل بصيغة XLS. لا يتم تعيين صورة معاينة للمخطط؛ يصبح المخطط مرئيًا عندما يتم تفعيل كائن OLE في PowerPoint.

ينشئ المثال عرضًا جديدًا بإطار OLE مقاسه 9.5 × 4 بوصة موضعه 0.5 بوصة من الحافة اليسرى و1 بوصة من الأعلى. إحداثيات وأبعاد الشريحة بوحدات النقاط (72 نقطة لكل بوصة). بالنسبة لعرض موجود، راجع [استخدام قالب](#use-a-template).

## **تعيين حجم مخطط ثابت**

قم بتعيين [Chart::setSizeWithWindow](https://reference.aspose.com/cells/php/aspose.cells/chart/#sizewithwindow) إلى false بحيث تكون أبعاد المخطط مستقلة عن نافذة دفتر العمل. عيّن أبعاد [Chart::getChartObject](https://reference.aspose.com/cells/php/aspose.cells/chart/#chartobject) عبر [Shape::setWidth](https://reference.aspose.com/cells/php/aspose.cells/shape/#width) و[Shape::setHeight](https://reference.aspose.com/cells/php/aspose.cells/shape/#height)، مع تحويل النقاط إلى بكسلات باستخدام 96 بكسل لكل بوصة: إطار بمقاس 684 × 288 نقطة يعادل مخططًا بمقاس 912 × 384 بكسل. عيّن [Chart::setPrintSize](https://reference.aspose.com/cells/php/aspose.cells/chart/#printsize) إلى القيمة CUSTOM من [PrintSizeType](https://reference.aspose.com/cells/php/aspose.cells/printsizetype/). يضمّن المثال دفتر العمل باستخدام [ShapeCollection::addOleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addOleObjectFrame) ويحفظ عرضًا بإطار OLE مقاسه 9.5 × 4 بوصة.

يتم تحويل القيم الرقمية في Java باستخدام `java_values` قبل استخدامها كمؤشرات PHP. تظل بايتات دفتر العمل في مصفوفة بايتات Java عند تمريرها إلى [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\FileFormatType;
use aspose\cells\PrintSizeType;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("Data");
    $dataSheet->getCells()->get("A1")->putValue(10);
    $dataSheet->getCells()->get("A2")->putValue(20);

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, 20, 10));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    $chart->getNSeries()->add("Data!A1:A2", true);
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);

    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // إحداثيات الشريحة وأبعادها بوحدات النقاط (72 نقطة لكل بوصة).
        $width = 684; // 9.5 بوصة.
        $height = 288; // 4 بوصة.

        $chart->setSizeWithWindow(false);
        // تحويل النقاط إلى بكسلات المخطط باستخدام 96 بكسل لكل بوصة.
        $chart->getChartObject()->setWidth((int)($width / 72 * 96));
        $chart->getChartObject()->setHeight((int)($height / 72 * 96));
        $chart->setPrintSize(PrintSizeType::CUSTOM);

        $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
        $workbook->save($workbookStream, FileFormatType::EXCEL_97_TO_2003);
        $workbookBytes = $workbookStream->toByteArray();
        $dataInfo = new OleEmbeddedDataInfo($workbookBytes, "xls");
        $slide->getShapes()->addOleObjectFrame(36, 72, $width, $height, $dataInfo);

        $presentation->save("chart-fixed-size.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **استخدام قالب**

منطق التحجيم هو نفسه للعرض الموجود. لتكييف المثال:

1. حمّل عرض القالب بدلاً من إنشاء عرض فارغ.  
1. تأكد من أن الشريحة الأولى تحتوي على ثلاثة أشكال على الأقل، ثم استخدم الشكل ذو الفهرس 2 كعنصر نائب.  
1. خذ عرض وإرتفاع الإطار من ذلك الشكل بدلاً من القيم الثابتة 684 و288. احتفظ بحسابات التحجيم دون تغيير.  
1. أضف إطار OLE في موضع عنصر النائب بدلاً من الإحداثيات الثابتة 36 و72.  
1. احذف عنصر النائب قبل حفظ العرض.

## **الأسئلة المتكررة**

**لماذا يتغير حجم مخطط Excel المضمّن بعد تفعيله في PowerPoint؟**

يحدث هذا لأن Excel تحاول استعادة حجم النافذة الأصلي عند التفعيل الأول، في حين أن إطار كائن OLE في PowerPoint له أبعاده الخاصة. تتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة الأبعاد، مما قد يسبب تغيير الحجم.

**كيف يمكن الحفاظ على تناسق أحجام المخطط وإطار OLE؟**

عيّن أبعاد مخطط ثابتة تتطابق مع إطار OLE واستخدم حجم طباعة مخصص للمخطط قبل تضمين دفتر العمل. يوضح المثال أعلاه الإعدادات المطلوبة وتحويل الوحدات.

**هل يكفي مطابقة حجم نافذة دفتر العمل؟**

مراجعة حجم نافذة دفتر العمل وحدها لا تمنع تغيّر حجم إطار OLE بعد التفعيل بشكل موثوق. استخدم أبعاد مخطط ثابتة كما هو موضح في المثال.

**هل يعمل هذا الحل مع العروض القائمة على القوالب والعروض الجديدة؟**

نعم. بالنسبة للقالب، استخدم أبعاد وموقع عنصر النائب. بالنسبة للعرض الجديد، حدد أبعاد الإطار وموقعه مباشرة.

**هل يمكنني استخدام هذا المثال مع مخططات تم إنشاؤها في برامج جداول بيانات أخرى؟**

يستخدم المثال دفتر عمل Excel تم إنشاؤه باستخدام Aspose.Cells. لا يوضح سلوك التفعيل لبرامج جداول بيانات أخرى.

## **الأقسام ذات الصلة**

- [إنشاء مخططات Excel وتضمينها ككائنات OLE في العروض التقديمية](/slides/ar/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)