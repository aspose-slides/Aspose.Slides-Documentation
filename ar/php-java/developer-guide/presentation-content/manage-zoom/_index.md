---
title: إدارة تكبير العرض التقديمي في PHP
linktitle: إدارة التكبير
type: docs
weight: 60
url: /ar/php-java/manage-zoom/
keywords:
- تكبير
- إطار تكبير
- تكبير الشريحة
- تكبير القسم
- تكبير الملخص
- إضافة تكبير
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إنشاء وتخصيص التكبير باستخدام Aspose.Slides لـ PHP عبر Java — الانتقال بين الأقسام، وإضافة الصور المصغرة والانتقالات في عروض PowerPoint."
---
## **المقدمة**

تتيح لك تكبيرات PowerPoint التنقل بين الشرائح المحددة والأقسام أثناء عرض الشرائح. باستخدام Aspose.Slides لـ PHP عبر Java، يمكنك إنشاء تكبيرات للشرائح، والأقسام، والملخص وتخصيص معايناتها، وحدودها، وانتقالاتِها.

![نظرة عامة على تكبيرات PowerPoint](overview.png)

* لتلخيص العرض التقديمي بالكامل على شريحة واحدة، استخدم [ملخص التكبير](#summary-zoom).
* لعرض الشرائح المحددة فقط، استخدم [تكبير الشريحة](#slide-zoom).
* لعرض قسم واحد فقط، استخدم [تكبير القسم](#section-zoom).

## **تكبير الشريحة**

يمكن لتكبير الشريحة أن يجعل عرضك أكثر ديناميكية، حيث يسمح لك بالتنقل بحرية بين الشرائح بأي ترتيب تختاره دون مقاطعة تدفق العرض. تكبيرات الشرائح ممتازة للعروض القصيرة التي لا تحتوي على أقسام كثيرة، ولكن يمكنك أيضًا استخدامها في سيناريوهات عرض مختلفة.

تتيح لك تكبيرات الشرائح استكشاف معلومات ذات صلة من شريحة نظرة عامة واحدة.

![اختيار الشرائح لتكبير الشريحة](slidezoomsel.png)

بالنسبة لكائنات تكبير الشريحة، توفر Aspose.Slides النوعية [ZoomImageType](https://reference.aspose.com/slides/php-java/aspose.slides/zoomimagetype/)، والفئة [ZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/zoomframe/)، والطرق في فئة [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **إنشاء إطارات تكبير**

استخدم [ShapeCollection::addZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addZoomFrame) لوضع روابط إلى شرائح فردية على شريحة نظرة عامة. يُنشئ هذا المثال شريحتين هدفيتين بخلفيات وعناوين متميزة، ثم يضيف معاينة لكل منهما إلى الشريحة الأولى ويحفظ العرض كملف PPTX. تُحدد مواضع الإطارات وأبعادها بالنقاط.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $secondSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $thirdSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());

    $secondSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $secondSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $secondSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");

    $thirdSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $thirdSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 189, 183, 107);
    $thirdSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

    $textBox = $thirdSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Third Slide");

    $overviewSlide->getShapes()->addZoomFrame(20, 20, 250, 200, $secondSlide);
    $overviewSlide->getShapes()->addZoomFrame(200, 250, 250, 200, $thirdSlide);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **إنشاء إطارات تكبير بصور مخصصة**

مرّر صورة مخصصة إلى [ShapeCollection::addZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addZoomFrame) لاستبدال المعاينة الافتراضية لشريحة الهدف. يتطلب هذا المثال صورة محلية، يتم تحميلها باستخدام [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile)، وتُضيف إلى العرض عبر [ImageCollection::addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/#addImage). يعرض الإطار الناتج تلك الصورة مع الحفاظ على الربط بالشر

حة الثانية.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $overviewSlide->getShapes()->addZoomFrame(20, 20, 300, 200, $slide, $previewImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **تنسيق إطارات التكبير**

يُخصّص هذا المثال إطارين لتكبير الشريحة. يُعيّن صورة محلية للإطار الأول عبر [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage)، ويمنح الإطار الثاني حدًا ورديًا من نقطة‑خمسة، متقطع‑نقطة‑متقطع عبر [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat). تمرير `false` إلى [ZoomObject::setShowBackground](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setShowBackground) يُخفي خلفية الإطار الثاني. تُطلب صورة محلية للمعاينة المخصصة؛ كلا الإطارين يحتفظان بأهداف الشرائح في ملف PPTX المحفوظ.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $secondSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $thirdSlide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());

    $secondSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $secondSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $secondSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);

    $textBox = $secondSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Second Slide");

    $thirdSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $thirdSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 189, 183, 107);
    $thirdSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);

    $textBox = $thirdSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 200, 500, 200);
    $textBox->getTextFrame()->setText("Third Slide");

    $firstZoomFrame = $overviewSlide->getShapes()->addZoomFrame(20, 20, 250, 200, $secondSlide);
    $secondZoomFrame = $overviewSlide->getShapes()->addZoomFrame(200, 250, 250, 200, $thirdSlide);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $firstZoomFrame->setZoomImage($previewImage);

    $secondZoomFrame->getLineFormat()->setWidth(5);
    $secondZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 105, 180);
    $secondZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($color);
    $secondZoomFrame->getLineFormat()->setDashStyle(LineDashStyle::DashDot);

    $secondZoomFrame->setShowBackground(false);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تكبير القسم**

يرتبط تكبير القسم بقسم في عرضك. استخدمه لإعادة زيارة موضوع أو لإظهار كيفية ارتباط أجزاء العرض المختلفة.

![اختيار قسم لتكبير القسم](seczoomsel.png)

بالنسبة لكائنات تكبير القسم، توفر Aspose.Slides الفئة [SectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/) والطرق في فئة [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **إنشاء إطارات تكبير القسم**

أنشئ قسمًا باستخدام [SectionCollection::addSection](https://reference.aspose.com/slides/php-java/aspose.slides/sectioncollection/#addSection)، ثم مرّر القسم المُعاد إلى [ShapeCollection::addSectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSectionZoomFrame). يضع هذا المثال تكبيرًا للقسم على الشريحة الأولى ويربطه بقسم يبدأ بشريحة ملونة. تُحدد مواضع الإطار وأبعاده بالنقاط، ويُحفظ العرض كملف PPTX.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $section = $presentation->getSections()->addSection("Section 1", $slide);
    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **إنشاء إطارات تكبير القسم بصور مخصصة**

يسمح لك التحميل الزائد للصورة في [ShapeCollection::addSectionZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSectionZoomFrame) بعرض معاينة مخصصة دون تغيير قسم الوجهة. يتطلب هذا المثال صورة محلية، تُحمَّل باستخدام [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) وتُضاف عبر [ImageCollection::addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/#addImage). يحتوي العرض المحفوظ على تكبير قسم على الشريحة الأولى مرتبط بالقسم الذي تم إنشاؤه حديثًا.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $section = $presentation->getSections()->addSection("Section 1", $slide);
    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section, $previewImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **تغيير قسم الهدف لتكبير القسم**

استخدم [SectionZoomFrame::setTargetSection](https://reference.aspose.com/slides/php-java/aspose.slides/sectionzoomframe/#setTargetSection) لإعادة توجيه تكبير قسم موجود دون إعادة إنشائه. اختر قسمًا مُعبَّأً من مجموعة [Presentation::getSections](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSections) في نفس العرض. يترك تعيين قسم فارغ الهدف الحالي دون تغيير، لذا تحقق من [Section::getSlidesListOfSection](https://reference.aspose.com/slides/php-java/aspose.slides/section/#getSlidesListOfSection) قبل التعيين. راجع [Manage Slide Sections](/slides/ar/php-java/slide-section/) لمزيد من المعلومات حول الأقسام.

السيناريو التالي يحمل ملف عرض يجب أن يحتوي على أقسام مُعبَّأة متعددة، وتكبير قسم موجود اسمه `Section navigation`، وقسم بالاسم الفريد `Results`. يبحث في جميع الشرائح عن التكبير ويجد الوجهة بالاسم بدلاً من فهرس المجموعة الذي قد يتغيّر عند إعادة ترتيب الأقسام. إذا لم تكن الأسماء فريدة، استخدم [Section::getSectionId](https://reference.aspose.com/slides/php-java/aspose.slides/section/#getSectionId) لتحديد الوجهة بدلاً من ذلك.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("section-zoom.pptx");
try {
    $zoom = null;
    $slideCount = java_values($presentation->getSlides()->size());
    for ($i = 0; $i < $slideCount; $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($j = 0; $j < $shapeCount; $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISectionZoomFrame")) && java_values($shape->getName()) === "Section navigation") {
                $zoom = $shape;
                break;
            }
        }
        if ($zoom != null) {
            break;
        }
    }

    $targetSection = null;
    $sectionCount = java_values($presentation->getSections()->size());
    for ($i = 0; $i < $sectionCount; $i++) {
        $section = $presentation->getSections()->get_Item($i);
        if (java_values($section->getName()) === "Results") {
            $targetSection = $section;
            break;
        }
    }

    if ($zoom == null || $targetSection == null) {
        echo "The section zoom or destination section was not found.", PHP_EOL;
    } else if (java_values($targetSection->getSlidesListOfSection()->size()) == 0) {
        echo "The destination section is empty.", PHP_EOL;
    } else {
        $currentSection = $zoom->getTargetSection();
        echo "Current section: " . (java_is_null($currentSection) ? "" : java_values($currentSection->getName())), PHP_EOL;
        $zoom->setTargetSection($targetSection);
        $presentation->save("section-zoom-updated.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

### **تنسيق إطارات تكبير القسم**

ينقل هذا المثال ويعيد تحجيم تكبير القسم إلى 100×75 نقطة، يُعيّن صورة محلية عبر [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage)، ويطبق حدًا بنيًا من نقطة‑2.5 متقطعة‑نقطة‑متقطعة. يفعّل [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) للعودة إلى الشريحة الأصلية بعد القسم، ويعطل [ZoomObject::setShowBackground](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setShowBackground)، ويضبط [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) على 1.5 ثانية. تُطلب صورة محلية للمعاينة المخصصة.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 154, 205, 50);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $section = $presentation->getSections()->addSection("Section 1", $slide);

    $sectionZoomFrame = $overviewSlide->getShapes()->addSectionZoomFrame(20, 20, 300, 200, $section);
    $sectionZoomFrame->setX(100);
    $sectionZoomFrame->setY(300);
    $sectionZoomFrame->setWidth(100);
    $sectionZoomFrame->setHeight(75);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $sectionZoomFrame->setZoomImage($previewImage);

    $sectionZoomFrame->setReturnToParent(true);
    $sectionZoomFrame->setShowBackground(false);

    $sectionZoomFrame->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $sectionZoomFrame->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($color);
    $sectionZoomFrame->getLineFormat()->setDashStyle(LineDashStyle::DashDot);
    $sectionZoomFrame->getLineFormat()->setWidth(2.5);

    $sectionZoomFrame->setTransitionDuration(1.5);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ملخص التكبير**

يوفر ملخص التكبير نظرة عامة على أقسام العرض. أثناء عرض الشرائح، يمكنك استخدامه للقفز إلى قسم، أو التخطي إلى الأمام، أو إعادة زيارة موضوع دون اتباع ترتيب الشرائح.

![اختيار أقسام لتكبير الملخص](sumzoomsel.png)

بالنسبة لكائنات ملخص التكبير، توفر Aspose.Slides الفئات [SummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/)، [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/)، و[SummaryZoomSectionCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/)، والطرق في فئة [ShapeCollection](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/).

### **إنشاء ملخص تكبير**

استخدم [ShapeCollection::addSummaryZoomFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSummaryZoomFrame) لإنشاء نظرة عامة على أقسام العرض. يُنشئ هذا المثال أربعة أقسام بخلفيات شرائح متميزة ويضيف ملخص تكبير إلى الشريحة الأولى. تُحدد مواضع الإطار وأبعاده بالنقاط، وتُحفظ النظرة العامة في عرض PPTX.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 127, 255, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 3", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 100, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 4", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **إضافة وإزالة قسم من ملخص التكبير**

يخزن ملخص التكبير كائناته من النوع [SummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsection/) في [SummaryZoomFrame::getSummaryZoomCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection). يُنشئ هذا المثال نظرة عامة على قسمين، يضيف قسمًا ثالثًا باستخدام [SummaryZoomSectionCollection::addSummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection)، ويزيل إدخال القسم الأول باستخدام [SummaryZoomSectionCollection::removeSummaryZoomSection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection). يترك إزالة الإدخال القسم وعرض الشرائح الخاص به دون تغيير.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $firstSection = $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 127, 255, 0);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $thirdSection = $presentation->getSections()->addSection("Section 3", $slide);

    $summaryZoomFrame->getSummaryZoomCollection()->addSummaryZoomSection($thirdSection);

    $summaryZoomFrame->getSummaryZoomCollection()->removeSummaryZoomSection($firstSection);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **تنسيق أقسام ملخص التكبير**

ينسّق هذا المثال الإدخال الأول في [SummaryZoomFrame::getSummaryZoomCollection](https://reference.aspose.com/slides/php-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) باستخدام الفهرس الصفري `0`. يتطلب صورة محلية لـ [ZoomObject::setZoomImage](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setZoomImage)، يطبق حدًا أسودًا من نقطة‑1.5 متقطعة‑نقطة‑متقطعة، ويضبط [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) على 1.5 ثانية. تمرير `false` إلى [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) يعطل العودة التلقائية إلى شريحة الملخص لهذا الإدخال.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $overviewSlide = $presentation->getSlides()->get_Item(0);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor($color);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 1", $slide);

    $slide = $presentation->getSlides()->addEmptySlide($overviewSlide->getLayoutSlide());
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    $slide->getBackground()->setType(BackgroundType::OwnBackground);

    $presentation->getSections()->addSection("Section 2", $slide);

    $summaryZoomFrame = $overviewSlide->getShapes()->addSummaryZoomFrame(150, 50, 300, 200);

    $summarySection = $summaryZoomFrame->getSummaryZoomCollection()->get_Item(0);
    $image = Images::fromFile("image.png");
    try {
        $previewImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $summarySection->setZoomImage($previewImage);
    $summarySection->setReturnToParent(false);

    $summarySection->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $summarySection->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $summarySection->getLineFormat()->setDashStyle(LineDashStyle::DashDot);
    $summarySection->getLineFormat()->setWidth(1.5);

    $summarySection->setTransitionDuration(1.5);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة المتكررة**

**هل يمكنني التحكم في العودة إلى الشريحة "الأم" بعد عرض الهدف؟**

نعم. استدعِ [ZoomObject::setReturnToParent](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setReturnToParent) مع `true` للعودة إلى الشريحة الأصلية بعد ظهور محتوى الهدف.

**هل يمكنني تعديل "السرعة" أو مدة انتقال التكبير؟**

نعم. استخدم [ZoomObject::setTransitionDuration](https://reference.aspose.com/slides/php-java/aspose.slides/zoomobject/#setTransitionDuration) للتحكم في مدة الانتقال بالثواني.

**هل هناك حدود لعدد كائنات التكبير التي يمكن أن يحتويها العرض؟**

لا توجد حدود صريحة موثقة في واجهة البرمجة. تعتمد الحدود العملية على تعقيد العرض الكلي وأداء المشاهد. يمكنك إضافة العديد من إطارات التكبير، ولكن ضع في اعتبارك حجم الملف ووقت التصيير.