---
title: إدارة أقسام الشرائح في العروض التقديمية باستخدام جافا
linktitle: قسم الشريحة
type: docs
weight: 90
url: /ar/java/slide-section/
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
  - Java
  - Aspose.Slides
description: "إدارة أقسام الشرائح باستخدام Aspose.Slides for Java: إنشاء، إعادة تسمية، إعادة ترتيب، استرجاع، ومعالجة شرائح الأقسام في عروض PPTX التقديمية."
---
## **المقدمة**

تنظم الأقسام الشرائح المتتالية في مجموعات مُسمَّاة دون تغيير محتوى الشريحة. باستخدام Aspose.Slides for Java، يمكنك إنشاء الأقسام وإعادة ترتيبها وإعادة تسميتها وفحصها وإزالتها عبر طريقة [Presentation.getSections](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSections--) .

الأقسام تكون مفيدة بشكل خاص عندما:

- يحتاج عرض تقديمي كبير إلى تقسيمه إلى مواضيع أو فصول منطقية؛
- تُعيَّن مجموعات مختلفة من الشرائح إلى متعاونين مختلفين؛
- تحتاج الشرائح إلى المعالجة أو النقل أو الدمج كمجموعات.

اختر أسماء أقسام مختصرة تصف قصد الشرائح المجمعة. لأن الأقسام جزء من بنية العرض، استخدم واجهات برمجة التطبيقات الخاصة بالأقسام لتحديد العضوية بدلاً من استنتاجها من مواقع الشرائح.

## **إنشاء وإدارة الأقسام**

استخدم [ISectionCollection.addSection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) لإنشاء قسم بتحديد اسمه والشريحة البداية. يحدد Aspose.Slides الشرائح التي تنتمي إلى القسم بناءً على بنية الأقسام الحالية للعرض.

تتيح لك نفس [ISectionCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isectioncollection/) أيضًا:

- نقل قسم مع شرائحه باستخدام [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-) ;
- إزالة تعريف القسم فقط باستخدام [ISectionCollection.removeSection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-)، مع إبقاء شرائحه;
- إزالة قسم وشرائحه باستخدام [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-) ;
- إضافة قسم فارغ في النهاية باستخدام [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-) .

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

بعد هذه العمليات، يحتوي العرض على قسم `Introduction` مع شرائحه وقسم فارغ `Appendix`. تم إزالة قسم `Results` وشرائحه.

## **إعادة تسمية الأقسام**

لإعادة تسمية قسم، استدعِ طريقة [ISection.setName](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isection/#setName-java.lang.String-) الخاصة به. تبقى شرائح القسم وموقعه دون تغيير.

المثال التالي ينشئ قسمًا ويغيّر اسمه:

```java
import com.aspose.slides.ISection;
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

## **استرجاع الشرائح من الأقسام**

طريقة [Presentation.getSections](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSections--) تُعيد [ISectionCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isectioncollection/) يمكنك التنقل خلالها. لكل [ISection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isection/)، استدعِ [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isection/#getSlidesListOfSection--) للحصول على الشرائح التي تنتمي إليه حاليًا. تُعيد الطريقة [ISectionSlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isectionslidecollection/)، التي توفر عددًا، وصولًا مفهرسًا، وتكرارًا.

المثال التالي ينشئ قسمين مملوءين وقسمًا فارغًا، ثم يطبع لكل قسم [الاسم](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isection/#getName--)، [المعرِّف](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isection/#getSectionId--)، [الشريحة البداية](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isection/#getStartedFromSlide--)، عدد الشرائح، وأرقام الشرائح. يستخدم [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) لقراءة الشريحة الأولى وجملة `for` المعززة لمعالجة كل شريحة. بالنسبة للقسم الفارغ، يكون حجم المجموعة صفرًا، لا تُستدعى الطريقة، ولا يؤدي التكرار إلى أي عملية.

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

عضوية القسم تُحدد بواسطة بنية أقسام العرض. لا تحسب نطاق القسم يدويًا باستخدام [ISection.getStartedFromSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isection/#getStartedFromSlide--)، فهارس الشرائح، وشريحة البداية للقسم التالي.

التعديلات الهيكلية يمكن أن تغير كلًا من الشرائح المعادة للقسم وأرقام شرائحها. يشمل ذلك إعادة ترتيب الشرائح، استنساخ شريحة داخل قسم، نقل قسم مع شرائحه، إزالة شرائح، وإزالة أقسام. المثال التالي يستدعي [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isection/#getSlidesListOfSection--) بعد كل تغيير من هذا النوع بدلاً من الاعتماد على افتراضات حول حدود القسم السابقة.

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

استدعِ [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isection/#getSlidesListOfSection--) مرة أخرى كلما أُعيد ترتيب الشرائح أو الأقسام، أو استُنست، أو نُقلت، أو أُزيلت. هذا يحافظ على انسجام المعالجة اللاحقة مع بنية العرض الحالية.

تنسيق PPT (PowerPoint 97–2003) لا يحافظ على بيانات تعريف الأقسام. استخدم سير العمل هذا مع تنسيق يدعم الأقسام، مثل PPTX؛ تحويل العرض إلى PPT يُزيل بنية الأقسام المطلوبة للتكرار لاحقًا.

## **الأسئلة المتداولة**

**هل تُحفظ الأقسام عند حفظ العرض بتنسيق PPT (PowerPoint 97–2003)؟**

لا. تنسيق PPT لا يدعم بيانات تعريف الأقسام، لذا تُفقد تجميعات الأقسام عند حفظ الملف بامتداد .ppt.

**هل يمكن "إخفاء" قسم كامل؟**

لا. لا يحتوي القسم على حالة رؤية. لإخفاء محتوياته، استدعِ [ISlide.setHidden](https://reference.aspose.com/slides/ar/java/com.aspose.slides/islide/#setHidden-boolean-) لكل شريحة داخل القسم.

**كيف يمكنني العثور على القسم الذي يحتوي على شريحة معينة؟**

تنقّ بص عبر المجموعة التي تُعيدها [Presentation.getSections](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSections--)، استدعِ [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isection/#getSlidesListOfSection--) لكل قسم، وقارن الشرائح المسترجعة مع الشريحة الهدف. بالنسبة لقسم غير فارغ، تُعيد [ISection.getStartedFromSlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/isection/#getStartedFromSlide--) شريحته الأولى؛ بالنسبة لقسم فارغ، تُعيد `null`.