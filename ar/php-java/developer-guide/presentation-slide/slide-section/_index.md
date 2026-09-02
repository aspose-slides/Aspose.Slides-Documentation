---
title: إدارة أقسام الشرائح في العروض التقديمية باستخدام PHP
linktitle: قسم الشريحة
type: docs
weight: 90
url: /ar/php-java/slide-section/
keywords:
- إنشاء قسم
- إضافة قسم
- تعديل قسم
- تغيير قسم
- اسم القسم
- استرجاع شرائح القسم
- معالجة شرائح القسم
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة أقسام الشرائح باستخدام Aspose.Slides for PHP عبر Java: إنشاء، إعادة تسمية، إعادة ترتيب، استرجاع ومعالجة شرائح القسم في عروض PPTX التقديمية."
---
## **المقدمة**

تنظم الأقسام الشرائح المتتالية في مجموعات مسماة دون تغيير محتوى الشريحة. باستخدام Aspose.Slides for PHP عبر Java، يمكنك إنشاء الأقسام وإعادة ترتيبها وإعادة تسميتها وفحصها وإزالتها من خلال طريقة [Presentation::getSections](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation/#getSections).

تكون الأقسام مفيدة بشكل خاص عندما:

- يحتاج عرض تقديمي كبير إلى تقسيمه إلى مواضيع أو فصول منطقية؛
- تُخصص مجموعات مختلفة من الشرائح لمتعاونين مختلفين؛
- تحتاج الشرائح إلى معالجة أو نقل أو دمج كمجموعات.

اختر أسماء أقسام مختصرة تصف هدف الشرائح المتجمعة. نظرًا لأن الأقسام هي جزء من بنية العرض التقديمي، استخدم واجهات برمجة تطبيقات الأقسام لتحديد العضوية بدلاً من استنتاجها من مواضع الشرائح.

## **إنشاء وإدارة الأقسام**

استخدم [SectionCollection::addSection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SectionCollection/#addSection) لإنشاء قسم عن طريق تحديد اسمه والشريحة التي يبدأ منها. تقوم Aspose.Slides بتحديد الشرائح التي تنتمي إلى القسم بناءً على بنية الأقسام الحالية في العرض.

تتيح لك نفس [SectionCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SectionCollection/) أيضًا:

- نقل قسم مع شرائحه باستخدام [SectionCollection::reorderSectionWithSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SectionCollection/#reorderSectionWithSlides)؛
- إزالة تعريف القسم فقط باستخدام [SectionCollection::removeSection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SectionCollection/#removeSection)، مع الاحتفاظ بشرائحه؛
- إزالة قسم وشراحه باستخدام [SectionCollection::removeSectionWithSlides](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SectionCollection/#removeSectionWithSlides)؛
- إضافة قسم فارغ في النهاية باستخدام [SectionCollection::appendEmptySection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SectionCollection/#appendEmptySection).

المثال التالي ينشئ قسمين، ينقل أحدهما، يزيله مع شرائحه، ويضيف قسمًا فارغًا في النهاية:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $titleSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $resultsSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $titleSlide);
    $resultsSection = $presentation->getSections()->addSection("Results", $resultsSlide);

    $presentation->getSections()->reorderSectionWithSlides($resultsSection, 0);
    $presentation->getSections()->removeSectionWithSlides($resultsSection);
    $presentation->getSections()->appendEmptySection("Appendix");
} finally {
    $presentation->dispose();
}
```

بعد هذه العمليات، يحتوي العرض التقديمي على قسم `Introduction` مع شرائحه وقسم فارغ `Appendix`. تم إزالة قسم `Results` وشرائحه.

## **إعادة تسمية الأقسام**

لإعادة تسمية قسم، استدعِ طريقة [Section::setName](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Section/#setName) الخاصة به. تظل شرائح القسم وموقعه دون تغيير.

المثال التالي ينشئ قسمًا ويغيّر اسمه:

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $section = $presentation->getSections()->addSection("Overview", $slide);
    $section->setName("Introduction");
} finally {
    $presentation->dispose();
}
```

## **استرجاع الشرائح من الأقسام**

ترجع طريقة [Presentation::getSections](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation/#getSections) كائنًا من نوع [SectionCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SectionCollection/) يمكنك معالجته حسب الفهرس. لكل [Section](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Section/)، استدعِ [Section::getSlidesListOfSection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Section/#getSlidesListOfSection) للحصول على الشرائح التي تنتمي إليه حاليًا. تُرجع الطريقة كائنًا من نوع [SectionSlideCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SectionSlideCollection/)، الذي يوفر العدد والوصول عبر الفهرس.

المثال التالي ينشئ قسمين مملوءين وقسمًا فارغًا، ثم يطبع لكل قسم [الاسم](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Section/#getName)، [المعرّف](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Section/#getSectionId)، [الشريحة البداية](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Section/#getStartedFromSlide)، عدد الشرائح، وأرقام الشرائح. يستخدم [SectionCollection::get_Item](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SectionCollection/#get_Item) و[SectionSlideCollection::get_Item](https://reference.aspose.com/slides/ar/php-java/aspose.slides/SectionSlideCollection/#get_Item) للوصول المفهرس. بالنسبة للقسم الفارغ، يكون حجم المجموعة صفرًا ولا يُستدعى `get_Item`.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);

    $presentation->getSections()->addSection("Introduction", $firstSlide);
    $presentation->getSections()->addSection("Details", $thirdSlide);
    $presentation->getSections()->appendEmptySection("Appendix");

    $sections = $presentation->getSections();
    $sectionCount = java_values($sections->size());
    for ($sectionIndex = 0; $sectionIndex < $sectionCount; $sectionIndex++) {
        $section = $sections->get_Item($sectionIndex);
        $sectionSlides = $section->getSlidesListOfSection();
        $startingSlide = java_is_null($section->getStartedFromSlide()) ? "none" : java_values($section->getStartedFromSlide()->getSlideNumber());
        $slideCount = java_values($sectionSlides->size());

        echo "Section: " . java_values($section->getName()) . PHP_EOL;
        echo "ID: " . java_values($section->getSectionId()) . PHP_EOL;
        echo "Starting slide: " . $startingSlide . PHP_EOL;
        echo "Slide count: " . $slideCount . PHP_EOL;

        if ($slideCount > 0) {
            echo "First slide via get_Item: " . java_values($sectionSlides->get_Item(0)->getSlideNumber()) . PHP_EOL;
        }

        echo "Slide numbers:";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

تُحدد عضوية القسم بناءً على بنية الأقسام في العرض التقديمي. لا تقم بحساب نطاق القسم يدويًا من [Section::getStartedFromSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Section/#getStartedFromSlide)، فهارس الشرائح، وشريحة البداية للقسم التالي.

يمكن للتحريرات الهيكلية أن تغير كلًا من الشرائح التي تُرجع للقسم وأرقامها. يشمل ذلك إعادة ترتيب الشرائح، استنساخ شريحة داخل قسم، نقل قسم مع شرائحه، إزالة الشرائح، وإزالة الأقسام. المثال التالي يستدعي [Section::getSlidesListOfSection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Section/#getSlidesListOfSection) بعد كل تغيير من هذا النوع بدلاً من الاعتماد على افتراضات حول حدود القسم السابقة.

```php
use aspose\slides\Presentation;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $thirdSlide = $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $firstSection = $presentation->getSections()->addSection("First", $firstSlide);
    $secondSection = $presentation->getSections()->addSection("Second", $thirdSlide);

    $printSectionSlides = function ($label, $section) {
        $sectionSlides = $section->getSlidesListOfSection();
        $slideCount = java_values($sectionSlides->size());
        echo $label . " (" . $slideCount . " slides):";
        for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
            $slide = $sectionSlides->get_Item($slideIndex);
            echo " " . java_values($slide->getSlideNumber());
        }
        echo PHP_EOL;
    };

    $printSectionSlides("Initially", $firstSection);

    $slidesBeforeClone = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->addClone($slidesBeforeClone->get_Item(0), $firstSection);
    $printSectionSlides("After cloning into the section", $firstSection);

    $slidesBeforeReorder = $firstSection->getSlidesListOfSection();
    $firstSectionPosition = java_values($slidesBeforeReorder->get_Item(0)->getSlideNumber()) - 1;
    $lastSlideIndex = java_values($slidesBeforeReorder->size()) - 1;
    $presentation->getSlides()->reorder($firstSectionPosition, $slidesBeforeReorder->get_Item($lastSlideIndex));
    $printSectionSlides("After reordering slides", $firstSection);

    $presentation->getSections()->reorderSectionWithSlides($firstSection, 1);
    $printSectionSlides("After moving the section", $firstSection);

    $slidesBeforeRemoval = $firstSection->getSlidesListOfSection();
    $presentation->getSlides()->remove($slidesBeforeRemoval->get_Item(0));
    $printSectionSlides("After removing a slide", $firstSection);

    $presentation->getSections()->removeSectionWithSlides($secondSection);
    $remainingSections = $presentation->getSections();
    $remainingSectionCount = java_values($remainingSections->size());
    for ($sectionIndex = 0; $sectionIndex < $remainingSectionCount; $sectionIndex++) {
        $section = $remainingSections->get_Item($sectionIndex);
        $printSectionSlides("Remaining section", $section);
    }
} finally {
    $presentation->dispose();
}
```

استدعِ [Section::getSlidesListOfSection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Section/#getSlidesListOfSection) مرة أخرى كلما أُعيد ترتيب الشرائح أو الأقسام، أو استُنسِخت، أو نُقلت، أو أُزيلت. يضمن ذلك أن تكون المعالجة اللاحقة متوافقة مع بنية العرض الحالية.

لا يحتفظ تنسيق PPT (PowerPoint 97–2003) ببيانات تعريف الأقسام. استخدم هذه العملية مع تنسيق يدعم الأقسام، مثل PPTX؛ فتحويل العرض إلى PPT يزيل بنية الأقسام المطلوبة للتكرار اللاحق.

## **الأسئلة الشائعة**

**هل تُحفظ الأقسام عند حفظ العرض بتنسيق PPT (PowerPoint 97–2003)؟**

لا. تنسيق PPT لا يدعم بيانات تعريف الأقسام، لذلك تُفقد تجميعات الأقسام عند الحفظ كملف .ppt.

**هل يمكن "إخفاء" قسم كامل؟**

لا. لا يملك القسم حالة رؤية. لإخفاء محتوياته، استدعِ [Slide::setHidden](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Slide/#setHidden) لكل شريحة في القسم.

**كيف يمكنني العثور على القسم الذي يحتوي على شريحة معينة؟**

تجوّل عبر المجموعة التي تُرجعها [Presentation::getSections](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation/#getSections)، استدعِ [Section::getSlidesListOfSection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Section/#getSlidesListOfSection) لكل قسم، وقارن الشرائح المسترجعة مع الشريحة المستهدفة. بالنسبة لقسم غير فارغ، تُرجع [Section::getStartedFromSlide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Section/#getStartedFromSlide) شريحته الأولى؛ بالنسبة لقسم فارغ، تُرجع `null`.