---
title: إدارة أقسام الشرائح في العروض التقديمية على Android
linktitle: قسم الشريحة
type: docs
weight: 90
url: /ar/androidjava/slide-section/
keywords:
- إنشاء قسم
- إضافة قسم
- تحرير قسم
- تغيير قسم
- اسم القسم
- استرجاع شرائح القسم
- معالجة شرائح القسم
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة أقسام الشرائح باستخدام Aspose.Slides لنظام Android عبر Java: إنشاء، إعادة تسمية، إعادة ترتيب، استرجاع، ومعالجة شرائح الأقسام في عروض PPTX التقديمية."
---
## **المقدمة**

تنظم الأقسام الشرائح المتتالية في مجموعات مسماة دون تغيير محتوى الشريحة. باستخدام Aspose.Slides لنظام Android عبر Java، يمكنك إنشاء الأقسام وإعادة ترتيبها وإعادة تسميتها وفحصها وإزالتها عبر طريقة [Presentation.getSections](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSections--) .

تكون الأقسام مفيدة بشكل خاص عندما:

- يحتاج عرض تقديمي كبير إلى تقسيمه إلى موضوعات أو فصول منطقية؛
- يتم تخصيص مجموعات مختلفة من الشرائح لمساهمين مختلفين؛
- تحتاج الشرائح إلى المعالجة أو النقل أو الدمج كمجموعات.

اختر أسماء أقسام مختصرة تصف هدف الشرائح المجمعة. نظرًا لأن الأقسام هي جزء من بنية العرض التقديمي، استخدم واجهات برمجة التطبيقات الخاصة بالأقسام لتحديد العضوية بدلاً من اشتقاقها من مواضع الشرائح.

## **إنشاء وإدارة الأقسام**

استخدم [ISectionCollection.addSection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) لإنشاء قسم عن طريق تحديد اسمه والشريحة البادئة. تقوم Aspose.Slides بتحديد الشرائح التي تنتمي إلى القسم بناءً على بنية الأقسام الحالية للعرض التقديمي.

يتيح لك نفس [ISectionCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isectioncollection/) أيضًا:

- نقل قسم مع شرائحه باستخدام [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-);
- إزالة تعريف القسم فقط باستخدام [ISectionCollection.removeSection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-)، مع الحفاظ على شرائحه؛
- إزالة قسم وشرائحه باستخدام [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-);
- إضافة قسم فارغ في النهاية باستخدام [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-).

المثال التالي ينشئ قسمين، ينقل أحدهما، يزيله مع شرائحه، ويضيف قسمًا فارغًا في النهاية:

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

بعد هذه العمليات، يحتوي العرض التقديمي على قسم `Introduction` مع شرائحه وقسم فارغ `Appendix`. تم إزالة قسم `Results` وشرائحه.

## **إعادة تسمية الأقسام**

لإعادة تسمية قسم، استدعِ طريقة [ISection.setName](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isection/#setName-java.lang.String-) الخاصة به. تبقى شرائح القسم وموقعه دون تغيير.

المثال التالي ينشئ قسمًا ويغيّر اسمه:

```java
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **استخراج الشرائح من الأقسام**

طريقة [Presentation.getSections](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSections--) تُعيد كائنًا من نوع [ISectionCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isectioncollection/) يمكنك التنقل خلاله. لكل [ISection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isection/)، استدعِ [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) للحصول على الشرائح التي تنتمي إليه حاليًا. تُعيد الطريقة كائنًا من نوع [ISectionSlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isectionslidecollection/)، الذي يوفر عددًا، وصولًا بالمؤشر، وتكرارًا.

المثال التالي ينشئ قسمين مملوءين وقسمًا فارغًا، ثم يطبع لكل قسم [الاسم](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isection/#getName--)، [المعرف](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isection/#getSectionId--)، [الشريحة البادئة](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isection/#getStartedFromSlide--)، عدد الشرائح، وأرقام الشرائح. يستخدم [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isectionslidecollection/#get_Item-int-) لقراءة الشريحة الأولى وجملة `for` المحسّنة لمعالجة كل شريحة. بالنسبة للقسم الفارغ، يكون حجم المجموعة المعادة صفرًا، لا تُستدعى الطريقة، ولا يؤدي التكرار إلى تنفيذ أي عمليات.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

تُحدد عضوية القسم بواسطة بنية الأقسام في العرض التقديمي. لا تحسب نطاق القسم يدويًا من خلال [ISection.getStartedFromSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isection/#getStartedFromSlide--)، فهارس الشرائح، وشريحة البداية للقسم التالي.

يمكن لتعديلات البنية أن تغير كلًا من الشرائح التي تُعاد للقسم وأرقام شرائحه. يشمل ذلك إعادة ترتيب الشرائح، استنساخ شريحة في قسم، نقل قسم مع شُرائحه، إزالة الشرائح، وإزالة الأقسام. المثال التالي يستدعي [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) بعد كل تغيير من هذا النوع بدلاً من الاعتماد على افتراضات حول حدود القسم السابقة.

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

استدعِ [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) مرة أخرى كلما تم إعادة ترتيب الشرائح أو الأقسام، أو استنساخها، أو نقلها، أو إزالتها. هذا يضمن بقاء المعالجة اللاحقة متوافقة مع بنية العرض التقديمي الحالية.

تنسيق PPT (PowerPoint 97–2003) لا يحافظ على بيانات تعريف الأقسام. استخدم سير العمل هذا مع تنسيق يدعم الأقسام، مثل PPTX؛ التحويل إلى PPT يزيل بنية الأقسام المطلوبة للتكرار لاحقًا.

## **الأسئلة المتكررة**

**هل يتم حفظ الأقسام عند الحفظ بتنسيق PPT (PowerPoint 97–2003)؟**

لا. تنسيق PPT لا يدعم بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ إلى .ppt.

**هل يمكن إخفاء قسم كامل؟**

لا. لا يملك القسم حالة إظهار/إخفاء. لإخفاء محتوياته، استدعِ [ISlide.setHidden](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#setHidden-boolean-) لكل شريحة في القسم.

**كيف يمكنني العثور على القسم الذي يحتوي على شريحة معينة؟**

قم بالتنقل عبر المجموعة التي تُعيدها [Presentation.getSections](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSections--)، استدعِ [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) لكل قسم، وقارن الشرائح المعادة بالشفرة المستهدفة. بالنسبة لقسم غير فارغ، تُعيد [ISection.getStartedFromSlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/isection/#getStartedFromSlide--) شريحته الأولى؛ بالنسبة لقسم فارغ، تُعيد `null`.