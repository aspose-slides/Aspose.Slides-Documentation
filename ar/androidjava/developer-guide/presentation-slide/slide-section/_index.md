---
title: قسم الشرائح
type: docs
weight: 90
url: /ar/androidjava/slide-section/
---

باستخدام Aspose.Slides لـ Android عبر Java، يمكنك تنظيم عرض PowerPoint التقديمي إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح محددة.

قد ترغب في إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في العرض التقديمي إلى أجزاء منطقية في هذه الحالات:

- عندما تعمل على عرض تقديمي كبير مع أشخاص آخرين أو فريق - وتحتاج إلى تخصيص شرائح معينة لزميل أو بعض أعضاء الفريق.
- عندما تتعامل مع عرض تقديمي يحتوي على العديد من الشرائح - وأنت تكافح لإدارة أو تحرير محتوياته مرة واحدة.

من المثالي أن تقوم بإنشاء قسم يحتوي على شرائح متشابهة - الشرائح لديها شيء مشترك أو يمكن أن توجد في مجموعة بناءً على قاعدة - ومنح القسم اسمًا يصف الشرائح بداخله.

## إنشاء أقسام في العروض التقديمية

لإضافة قسم يحتوي على شرائح في عرض تقديمي، يوفر Aspose.Slides لـ Android عبر Java طريقة [addSection()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) التي تتيح لك تحديد اسم القسم الذي تنوي إنشاؤه والشريحة التي يبدأ منها القسم.

يوضح لك هذا الكود المثال كيفية إنشاء قسم في عرض تقديمي باستخدام Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("القسم 1", newSlide1);
    ISection section2 = pres.getSections().addSection("القسم 2", newSlide3); // سيتم إنهاء section1 عند newSlide2 وبعد ذلك سيبدأ section2   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("آخر قسم فارغ");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## تغيير أسماء الأقسام

بعد إنشاء قسم في عرض PowerPoint التقديمي، قد تقرر تغيير اسمه.

يوضح لك هذا الكود المثال كيفية تغيير اسم قسم في عرض تقديمي باستخدام Java مع Aspose.Slides:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("قسم خاص بي");
} finally {
    if (pres != null) pres.dispose();
}
```