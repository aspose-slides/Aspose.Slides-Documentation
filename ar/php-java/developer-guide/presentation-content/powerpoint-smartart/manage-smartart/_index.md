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
- الخاصية المخفية
- مخطط المنظمة
- مخطط المنظمة بالصور
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية إنشاء وتعديل SmartArt في PowerPoint باستخدام Aspose.Slides for PHP عبر Java من خلال أمثلة شفرة واضحة تُسرّع تصميم الشرائح والأتمتة."
---
## **نظرة عامة**

SmartArt هو مخطط PowerPoint مكوَّن من العقد وأشكال العقد وتخطيط. باستخدام Aspose.Slides for PHP عبر Java، يمكنك إنشاء SmartArt، وقراءة النص من عقده، وتغيير تخطيطه، وفحص العقد المخفية، وتكوين تخطيطات مخططات المنظمة، وإنشاء مخططات منظمة بالصور.

## **الحصول على النص من كائن SmartArt**

يمكن أن يحتوي عقدة SmartArt على شكل واحد أو أكثر. لقراءة النص الظاهر، قم بالتكرار عبر [SmartArt::getAllNodes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartart/#getAllNodes)، ثم اقرأ الـ [TextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/textframe/) الذي يتم إرجاعه بواسطة [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartartshape/#getTextFrame).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **تغيير نوع التخطيط لكائن SmartArt**

يتحكم تخطيط SmartArt في كيفية ترتيب العقد وربطها. المثال التالي ينشئ كائن SmartArt باستخدام قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`، ثم يغيّرها إلى القيمة `BasicProcess`، ويحفظ العرض التقديمي.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **التحقق مما إذا كانت عقدة SmartArt مخفية**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartartnode/ishidden/) يشير إلى ما إذا كانت العقدة مخفية في نموذج بيانات SmartArt. يمكن أن توجد العقد المخفية في الهيكل حتى عندما لا يعرض التخطيط المختار لها كعناصر مرئية في المخطط.

المثال التالي يضيف عقدة إلى كائن SmartArt يستخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` ويتحقق من حالة إخفاء العقدة.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الحصول على تخطيط مخطط المنظمة أو تعيينه**

بالنسبة لمخططات SmartArt التي تستخدم تخطيط مخطط المنظمة، تحدد الدالتان [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) و [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) كيفية ترتيب العقد الفرعية تحت عقدة الأصل. على سبيل المثال، يمكنك ضبط العقد الفرعية لتعلّق من اليسار أو اليمين أو كلا الجانبين، اعتمادًا على [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/organizationchartlayouttype/).

المثال التالي ينشئ مخطط منظمة ويضبط تخطيط العقدة الأولى إلى قيمة [OrganizationChartLayoutType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **إنشاء مخطط منظمة بالصور**

مخطط منظمة بالصور هو تخطيط SmartArt مصمم لمخططات التدرج الهرمي التي تتضمن نواحي للصور. استخدم قيمة [SmartArtLayoutType](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` عند إضافة كائن SmartArt إلى الشريحة.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**هل يدعم SmartArt النسخ المرآتي أو العكس للغات من اليمين إلى اليسار؟**

نعم. تُغيّر الطريقة [SmartArt::setReversed](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartart/setreversed/) اتجاه المخطط من اليسار إلى اليمين إلى اليمين إلى اليسار، أو العكس، عندما يدعم تخطيط SmartArt المختار العكس.

**كيف يمكنني نسخ SmartArt إلى نفس الشريحة أو إلى عرض تقديمي آخر مع الحفاظ على التنسيق؟**

يمكنك [استنساخ شكل SmartArt](/slides/ar/php-java/shape-manipulations/) باستخدام [ShapeCollection::addClone](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shapecollection/addclone/)، أو [استنساخ الشريحة بأكملها](/slides/ar/php-java/clone-slides/) التي تحتوي على SmartArt. كلا النهجين يحافظان على الحجم والموقع والتنسيق.

**كيف يمكنني تحويل SmartArt إلى صورة نقطية للمعاينة أو تصدير الويب؟**

[قم بتحويل الشريحة](/slides/ar/php-java/convert-powerpoint-to-png/) أو العرض التقديمي بالكامل إلى PNG أو JPEG. يتم تحويل SmartArt كجزء من الشريحة.

**كيف يمكنني العثور على كائن SmartArt محدد في الشريحة إذا كان هناك عدة كائنات؟**

حدد قيمة مميزة لـ [Shape::getAlternativeText](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getalternativetext/) أو [Shape::getName](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/getname/) على شكل SmartArt، وابحث عن تلك القيمة في [BaseSlide::getShapes](https://reference.aspose.com/slides/ar/php-java/aspose.slides/baseslide/#getShapes)، ثم تأكد أن الشكل المطابق هو [SmartArt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/smartart/).