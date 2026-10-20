---
title: إنشاء مخططات Excel وتضمينها في العروض التقديمية ككائنات OLE
type: docs
weight: 30
url: /ar/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- مخطط Excel
- تضمين مخطط
- كائن OLE
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء مخطط Excel باستخدام Aspose.Cells for PHP عبر Java وتضمين المصنف في عرض PowerPoint باستخدام Aspose.Slides for PHP عبر Java، بما في ذلك معاينة للمخطط."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء مخطط عمودي في Excel باستخدام Aspose.Cells for PHP عبر Java وإدراج مصنفه داخل عرض تقديمي PowerPoint باستخدام Aspose.Slides for PHP عبر Java. يحتوي المصنف المضمن على كل من البيانات المصدر والمخطط. يتم عرض صورة PNG منفصلة للمخطط على الشريحة قبل تنشيط كائن OLE.

النتيجة هي كائن Excel مدمج، وليس مخطط PowerPoint أصلي. يتطلب تحرير المصنف عبر OLE تطبيق سطح مكتب يدعم تنشيط OLE وتثبيت Excel متوافق.

## **المتطلبات المسبقة**

قم بتكوين Aspose.Cells for PHP عبر Java وAspose.Slides for PHP عبر Java باستخدام نفس مثيل جسر PHP/Java. حمّل كلًّا من أغطية PHP واجعل مكتبات Java الخاصة بالمنتجين متاحة للجسر. لا يلزم وجود Microsoft Office لتوليد العرض التقديمي باستخدام هذه المكتبات.

لا توجد ملفات إدخال مطلوبة: يقوم المثال بإنشاء البيانات والمخطط في الذاكرة، ثم يكتب `OutputChart.pptx` إلى دليل العمل الحالي. قم بتطبيق التراخيص لكلا المنتجين عند التشغيل خارج وضع التقييم.

## **كيفية عمل الإدراج**

1. إنشاء مصنف يحتوي على ورقة بيانات وورقة مخطط.  
1. جعل ورقة المخطط نشطة حتى تُفتح المصنف على المخطط.  
1. تعيين نطاق عرض OLE للمصنف وتصدير المخطط إلى PNG.  
1. حفظ المصنف كملف XLSX في الذاكرة وإدراج تلك البايتات في شريحة.  
1. تعيين PNG كمعاينة كائن OLE وحفظ العرض التقديمي كملف PPTX.

نطاق عرض المصنف والإطار على الشريحة لهما أدوار مختلفة. [WorksheetCollection::setOleSize](https://reference.aspose.com/cells/php/aspose.cells/worksheetcollection/#setolesize) يأخذ مؤشرات الصف والعمود التي تبدأ من الصفر. [ChartCollection::add](https://reference.aspose.com/cells/php/aspose.cells/chartcollection/#add) بدلاً من ذلك يأخذ الصف الأعلى، العمود الأيسر، الصف الأسفل، والعمود الأيمن. يستخدم المثال مؤشر الصف 55 ومؤشر العمود 25 كحدود سفلية يمنى؛ هذه القيم اختيارات تخطيطية، ليست عدد صفوف أو أعمدة البيانات.

يستخدم إطار الشريحة الوحدات النقطية. يضبط المثال الإطار داخل الشريحة ويُوسّطها مع الحفاظ على نسبة أبعاد PNG، بدلاً من تمديد المعاينة لملء الشريحة.

## **إنشاء وإدراج المخطط**

يعرض المثال الكامل التالي ملء `DataSheet` بأربع صفوف وخمس أعمدة من القيم. يصبح كل صف سلسلة مخطط. يتم اختيار `ChartSheet` كورقة نشطة قبل حفظ المصنف.

يتم حفظ المصنف صراحةً كملف XLSX، مطابقة الامتداد `xlsx` الممرّ إلى [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/). تُحوَّل النتائج العددية من Java باستخدام `java_values` قبل أن تقوم PHP بالعمليات الحسابية، بينما تظل البيانات الثنائية في مصفوفات البايت الخاصة بـ Java. يتم تحميل PNG مباشرةً من بايتاته دون تحويل إلى صورة بيانية وسيطة. استبدال الصورة الافتراضية لكائن OLE يتم عبر [OleObjectFrame::getSubstitutePictureFormat](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat).

```php
<?php
use aspose\cells\ChartType;
use aspose\cells\ImageOrPrintOptions;
use aspose\cells\ImageType;
use aspose\cells\SaveFormat as CellsSaveFormat;
use aspose\cells\SheetType;
use aspose\cells\Workbook;
use aspose\slides\Images;
use aspose\slides\OleEmbeddedDataInfo;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use Java as JavaObject;

$workbook = new Workbook();
try {
    $dataSheet = $workbook->getWorksheets()->get(0);
    $dataSheet->setName("DataSheet");
    $values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];
    foreach ($values as $row => $rowValues) {
        foreach ($rowValues as $column => $value) {
            $dataSheet->getCells()->get($row, $column)->putValue($value);
        }
    }

    $chartSheetIndex = java_values($workbook->getWorksheets()->add(SheetType::CHART));
    $chartSheet = $workbook->getWorksheets()->get($chartSheetIndex);
    $chartSheet->setName("ChartSheet");
    $lastChartRow = 55;
    $lastChartColumn = 25;
    $chartIndex = java_values($chartSheet->getCharts()->add(ChartType::COLUMN, 0, 0, $lastChartRow, $lastChartColumn));
    $chart = $chartSheet->getCharts()->get($chartIndex);
    for ($row = 1; $row <= count($values); $row++) {
        $chart->getNSeries()->add("DataSheet!A" . $row . ":E" . $row, false);
    }
    $workbook->getWorksheets()->setActiveSheetIndex($chartSheetIndex);
    $workbook->getWorksheets()->setOleSize(0, $lastChartRow, 0, $lastChartColumn);

    // احتفظ بملف PNG وملف XLSX كمصفوفات بايت Java عند تمريرهما إلى Slides.
    $imageOptions = new ImageOrPrintOptions();
    $imageOptions->setImageType(ImageType::PNG);
    $chartImageStream = new JavaObject("java.io.ByteArrayOutputStream");
    $chart->toImage($chartImageStream, $imageOptions);
    $chartImageBytes = $chartImageStream->toByteArray();

    $workbookStream = new JavaObject("java.io.ByteArrayOutputStream");
    $workbook->save($workbookStream, CellsSaveFormat::XLSX);
    $workbookBytes = $workbookStream->toByteArray();

    $chartImage = Images::fromData($chartImageBytes);
    try {
        $presentation = new Presentation();
        try {
            $slide = $presentation->getSlides()->get_Item(0);
            $slideWidth = java_values($presentation->getSlideSize()->getSize()->getWidth());
            $slideHeight = java_values($presentation->getSlideSize()->getSize()->getHeight());
            $imageWidth = java_values($chartImage->getWidth());
            $imageHeight = java_values($chartImage->getHeight());

            // ضبط وتوسيط المعاينة مع الحفاظ على نسبة أبعادها.
            $scale = min($slideWidth / $imageWidth, $slideHeight / $imageHeight);
            $frameWidth = $imageWidth * $scale;
            $frameHeight = $imageHeight * $scale;
            $frameX = ($slideWidth - $frameWidth) / 2;
            $frameY = ($slideHeight - $frameHeight) / 2;

            $embeddedData = new OleEmbeddedDataInfo($workbookBytes, "xlsx");
            $oleFrame = $slide->getShapes()->addOleObjectFrame($frameX, $frameY, $frameWidth, $frameHeight, $embeddedData);
            $previewImage = $presentation->getImages()->addImage($chartImage);
            $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($previewImage);
            $presentation->save("OutputChart.pptx", SaveFormat::Pptx);
        } finally {
            $presentation->dispose();
        }
    } finally {
        $chartImage->dispose();
    }
} finally {
    $workbook->dispose();
}
```

## **النتيجة المتوقعة**

`OutputChart.pptx` يحتوي على شريحة واحدة مع مصنف Excel مدمج ومعاينة مخطط. يحتوي المصنف على البيانات الأصلية ومخطط عمودي بأربع سلاسل. المعاينة مُوسَّطة على الشريحة وتحتفظ بنسبها.

![مخطط عمودي في Excel يُعرض كمعاينة لمصنف مدمج](excel-chart-ole-preview.png)

في بيئة سطح مكتب PowerPoint متوافقة مع توفر Excel، انقر مزدوجًا على الكائن لتنشيطه وتحرير المصنف المدمج. يعتمد التنشيط والتحرير على دعم OLE وإعدادات الأمان في التطبيق المضيف.

## **الأسئلة المتكررة**

**لماذا تحتاج إلى صورة معاينة؟**

المصنف المدمج ومعاينة الشريحة منفصلتان. قدِّم صورة للمخطط حتى تُظهر الشريحة المخطط بدلًا من العنصر النائب الافتراضي “EMBEDDED OLE OBJECT”. راجع [Object Preview Issue when Adding OleObjectFrame](/slides/ar/php-java/object-preview-issue-when-adding-oleobjectframe/).

**هل يتم تحديث المعاينة تلقائيًا عند تغيير المصنف في الشيفرة؟**

اعتبر المعاينة لقطة ثابتة. عند تحديث بيانات المصنف برمجيًا، أعد إنشاء صورة المخطط واستبدل المعاينة وكذلك بيانات المصنف المدمج.

**هل يمكنني استخدام XLS بدلًا من XLSX؟**

نعم. احفظ المصنف بصيغة XLS واستخدم `xls` كامتداد للبيانات المضمنة. يجب أن يتطابق الامتداد مع تنسيق المصنف الفعلي؛ تغيير الامتداد فقط لا يحول البيانات.

**لماذا قد يتغير حجم الكائن بعد التنشيط؟**

يمكن للتطبيق المضيف تحديث عرض كائن OLE عند تنشيط المصنف. يؤثر كلٌ من نطاق عرض OLE للمصنف وأبعاد إطار الشريحة. راجع [Working Solution for Chart Resizing in PPTX](/slides/ar/java/working-solution-for-chart-resizing-in-pptx/).

## **الأقسام ذات الصلة**

- [Working Solution for Chart Resizing in PPTX](/slides/ar/java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/ar/php-java/object-preview-issue-when-adding-oleobjectframe/)
- [Manage OLE Objects](/slides/ar/php-java/manage-ole/)