---
title: "إدارة أقسام الشرائح في العروض التقديمية باستخدام جافا سكريبت"
linktitle: "قسم الشريحة"
type: docs
weight: 90
url: /ar/nodejs-java/slide-section/
keywords:
  - "إنشاء قسم"
  - "إضافة قسم"
  - "تحرير قسم"
  - "تغيير قسم"
  - "اسم القسم"
  - "استرجاع شرائح القسم"
  - "معالجة شرائح القسم"
  - PowerPoint
  - "عرض تقديمي"
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "إدارة أقسام الشرائح باستخدام Aspose.Slides لـ Node.js عبر Java: إنشاء، إعادة تسمية، إعادة ترتيب، استرجاع، ومعالجة شرائح القسم في عروض PPTX التقديمية."
---
## **المقدمة**

تقسم الأقسام الشرائح المتتالية إلى مجموعات مسماة دون تغيير محتوى الشريحة. باستخدام Aspose.Slides لـ Node.js عبر Java، يمكنك إنشاء الأقسام وإعادة ترتيبها وإعادة تسميتها وفحصها وإزالتها من خلال طريقة [Presentation.getSections](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getSections).

الأقسام مفيدة بشكل خاص عندما:

- عندما يحتاج عرض تقديمي كبير إلى تقسيمه إلى مواضيع أو فصول منطقية؛
- عندما يتم تخصيص مجموعات مختلفة من الشرائح لمتعاونين مختلفين؛
- عندما تحتاج الشرائح إلى المعالجة أو النقل أو الدمج كمجموعات.

اختر أسماء أقسام مختصرة تصف هدف الشرائح المجمعة. نظرًا لأن الأقسام جزء من بنية العرض التقديمي، استخدم واجهات برمجة تطبيقات الأقسام لتحديد العضوية بدلاً من استنتاجها من مواقع الشرائح.

## **إنشاء وإدارة الأقسام**

استخدم [SectionCollection.addSection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sectioncollection/#addSection) لإنشاء قسم عن طريق تحديد اسمه والشرائح الأولية. تقوم Aspose.Slides بتحديد الشرائح التي تنتمي إلى القسم بناءً على بنية الأقسام الحالية للعرض التقديمي.

نفس [SectionCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sectioncollection/) يتيح لك أيضًا:

- نقل قسم مع شرائحه باستخدام [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- إزالة تعريف القسم فقط باستخدام [SectionCollection.removeSection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sectioncollection/#removeSection)، مع الاحتفاظ بشرائحه;
- إزالة قسم وشريحاته باستخدام [SectionCollection.removeSectionWithWords](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides);
- إضافة قسم فارغ في النهاية باستخدام [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection).

المثال التالي ينشئ قسمين، ينقل أحدهما، يزيله مع شرائحه، ويضيف قسمًا فارغًا:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

بعد هذه العمليات، يحتوي العرض التقديمي على قسم `Introduction` مع شرائحه وقسم `Appendix` فارغ. تم إزالة قسم `Results` وشريحاته.

## **إعادة تسمية الأقسام**

لإعادة تسمية قسم، استدعِ طريقة [Section.setName](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/section/#setName). تبقى شرائح القسم وموقعه دون تغيير.

المثال التالي ينشئ قسمًا ويغيّر اسمه:

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **استرجاع الشرائح من الأقسام**

تُرجع طريقة [Presentation.getSections](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getSections) مجموعة [SectionCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sectioncollection/) يمكنك الوصول إليها بواسطة الفهرس. لكل [Section](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/section/)، استدعِ [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/section/#getSlidesListOfSection) للحصول على الشرائح التي تنتمي إليه حاليًا. تُرجع الطريقة مجموعة [SectionSlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sectionslidecollection/)، التي توفر عددًا وإمكانية الوصول عبر الفهرس.

المثال التالي ينشئ قسمين مملوءين وقسمًا فارغًا، ثم يطبع لكل قسم [name](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/section/#getName)، [identifier](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/section/#getSectionId)، [starting slide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/section/#getStartedFromSlide)، عدد الشرائح وأرقامها. يستخدم [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) لقراءة كل من الشريحة الأولى وكل شريحة في المجموعة. بالنسبة للقسم الفارغ، يكون حجم المجموعة صفرًا، يتم تخطي الوصول عبر الفهرس، ولا تقوم الحلقة بأي عمليات.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

يتم تحديد عضوية القسم بناءً على بنية الأقسام في العرض التقديمي. لا تقم بحساب نطاق القسم يدويًا من [Section.getStartedFromSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/section/#getStartedFromSlide)، فهارس الشرائح، وشريحة البداية للقسم التالي.

يمكن للتعديلات الهيكلية أن تغير كلًا من الشرائح المعادة لقسم وأرقامها. يشمل ذلك إعادة ترتيب الشرائح، استنساخ شريحة إلى قسم، نقل قسم مع شرائحه، إزالة الشرائح، وإزالة الأقسام. المثال التالي يستدعِ [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/section/#getSlidesListOfSection) بعد كل تغيير من هذا النوع بدلاً من الاعتماد على افتراضات حول حدود القسم السابقة.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

استدعِ [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/section/#getSlidesListOfSection) مرة أخرى كلما تم إعادة ترتيب الشرائح أو الأقسام، أو استنساخها، أو نقلها، أو إزالتها. يضمن ذلك أن يبقى المعالجة اللاحقة متوافقة مع بنية العرض التقديمي الحالية.

لا يحفظ تنسيق PPT (PowerPoint 97–2003) بيانات تعريف الأقسام. استخدم سير العمل هذا مع تنسيق يدعم الأقسام، مثل PPTX؛ التحويل إلى PPT يزيل بنية الأقسام المطلوبة للتكرار اللاحق.

## **الأسئلة المتكررة**

**هل يتم حفظ الأقسام عند حفظ الملف بتنسيق PPT (PowerPoint 97–2003)؟**

لا. تنسيق PPT لا يدعم بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ إلى .ppt.

**هل يمكن إخفاء قسم كامل؟**

لا. لا يمتلك القسم حالة رؤية. لإخفاء محتوياته، استدعِ [Slide.setHidden](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#setHidden) لكل شريحة في القسم.

**كيف يمكنني العثور على القسم الذي يحتوي على شريحة معينة؟**

يمكنك الوصول إلى كل قسم في المجموعة التي تُرجعها [Presentation.getSections](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getSections)، استدعِ [Section.getSlidesListOfSection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/section/#getSlidesListOfSection) لكل قسم، وقارن الشرائح المسترجعة مع الشريحة المستهدفة. بالنسبة لقسم غير فارغ، تُرجع [Section.getStartedFromSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/section/#getStartedFromSlide) شريحته الأولى؛ بالنسبة لقسم فارغ، تُرجع `null`.