---
title: إدارة SmartArt في عروض PowerPoint التقديمية باستخدام PHP
linktitle: إدارة SmartArt
type: docs
weight: 10
url: /ar/php-java/manage-smartart/
keywords:
- SmartArt
- نص SmartArt
- نوع التخطيط
- خاصية مخفية
- مخطط تنظيم
- مخطط تنظيم بالصور
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم بناء وتحرير SmartArt في PowerPoint باستخدام Aspose.Slides لـ PHP عبر Java باستخدام أمثلة شفرة واضحة تسرع تصميم الشرائح والأتمتة."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint يتكون من العقد وأشكال العقد وتخطيط. باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك إنشاء SmartArt، قراءة النص من عقده، تغيير تخطيطه، فحص العقد المخفية، تكوين تخطيطات مخطط التنظيم، وإنشاء مخططات تنظيمية بالصور.

## **الحصول على النص من كائن SmartArt**

يمكن لعقدة SmartArt أن تحتوي على شكل واحد أو أكثر. لقراءة النص من أشكال العقدة، قم بالتكرار عبر [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/)، ثم اقرأ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) الذي يتم إرجاعه بواسطة [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/).

يتطلب المثال عرض تقديمي يحتوي على شريحة واحدة على الأقل وكائن SmartArt كالشكل الأول في تلك الشريحة. يطبع كل إطار نص متاح إلى وحدة التحكم.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **تغيير نوع التخطيط لكائن SmartArt**

يتحكم تخطيط SmartArt في كيفية ترتيب العقد وربطها. المثال التالي ينشئ كائن SmartArt باستخدام القيمة `BasicBlockList` من [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/)، ثم يغيّره إلى القيمة `BasicProcess`، ويحفظ العرض التقديمي. يتم قياس الموقع والحجم الممررين إلى [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) بالنقاط. استخدم [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) لتغيير التخطيط.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **التحقق مما إذا كانت عقدة SmartArt مخفية**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) يشير إلى ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن توجد العقد المخفية في البنية حتى عندما لا يظهر التخطيط المحددها كعناصر مخطط مرئية.

المثال التالي يضيف عقدة إلى كائن SmartArt يستخدم القيمة `RadialCycle` من [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/). يتحقق من حالة إخفاء العقدة المضافة. يطبع رسالة إذا كانت العقدة مخفية ويحفظ المخطط.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الحصول على أو تعيين تخطيط مخطط التنظيم**

بالنسبة لمخططات SmartArt التي تستخدم تخطيط مخطط التنظيم، تحدد [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) و[SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) كيفية ترتيب العقد الفرعية تحت العقدة الأصلية. على سبيل المثال، يمكنك تعيين العقد الفرعية لتتدلى من اليسار أو اليمين أو الجانبين، اعتمادًا على [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/).

المثال التالي ينشئ مخطط تنظيم ويضبط التخطيط للعقدة الأولى على القيمة `LeftHanging` من [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/). المؤشر الصفري `0` يختار العقدة العليا الأولى؛ وتستخدم العقد الفرعية الترتيب المحدد. ثم يُحفظ العرض التقديمي المعدل.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **إنشاء مخطط تنظيم بصري**

مخطط التنظيم بالصور هو تخطيط SmartArt مصمم لمخططات الهرمية التي تتضمن عناصر نائبة للصور. استخدم القيمة `PictureOrganizationChart` من [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) عند إضافة كائن SmartArt إلى شريحة. هذا المثال يحفظ مخططًا يحتوي على عناصر نائبة للصور؛ لكنه لا يملأ هذه العناصر بالصور.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تحويل المخططات القديمة إلى مجموعات من الأشكال**

عند تحديث عرض تقديمي موجود، قد تحتاج إلى تعديل مخطط تنظيم تم إنشاؤه أصلاً في PowerPoint 97–2003. تمثل Aspose.Slides هذه المخططات القديمة ككائنات [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/). استخدم [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) لتحويل مخطط إلى مجموعة من الأشكال حتى يمكنك تعديل العناصر البصرية الفردية. راجع [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) للحصول على التفاصيل.

تضيف عملية التحويل مجموعة جديدة إلى مجموعة الأشكال دون إزالة المخطط الأصلي. بعد التحويل الناجح، احذف الأصلي باستخدام [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) لتجنب المحتوى المكرّر. قم بجمع المخططات القديمة في قائمة قبل تحويلها حتى لا يعرقل إضافة وإزالة الأشكال عملية التكرار.

المثال التالي يفتح عرض تقديمي، يبحث في كل شريحة، يحول المخططات إلى مجموعات من الأشكال، ويحفظ العرض المحدث كملف PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

العرض المحفوظ يحتوي على مجموعات الأشكال القابلة للتحرير بدلاً من المخططات القديمة التي تم تحويلها، دون بقاء المخططات الأصلية بجانبها. افتح ملف PPTX في PowerPoint لتعديل العناصر الفردية داخل كل مجموعة، مثل النص أو التعبئة أو الموقع.

## **FAQ**

**هل يدعم SmartArt عكس أو انعكاس للغات من اليمين إلى اليسار؟**

نعم. طريقة [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) تغير اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم تخطيط SmartArt المختار العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/php-java/shape-manipulations/) باستخدام [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/)، أو [استنساخ الشريحة بالكامل](/slides/ar/php-java/clone-slides/) التي تحتوي على SmartArt. كلا الطريقتين تحافظان على الحجم والموقع والتنسيق.

**كيف يمكنني عرض SmartArt كصورة نقطية للمعاينة أو التصدير للويب؟**

[عرض الشريحة](/slides/ar/php-java/convert-powerpoint-to-png/) أو العرض الكامل إلى PNG أو JPEG. يتم عرض SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt محدد في الشريحة إذا كان هناك عدة كائنات؟**

استخدم [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) أو [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) لتعيين نص بديل مميز أو اسم لت shape SmartArt، وابحث عن تلك القيمة في [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes)، ثم تحقق من أن الشكل المطابق هو [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/).