---
title: قسم الشريحة
type: docs
weight: 90
url: /java/slide-section/
---

مع Aspose.Slides لـ Java، يمكنك تنظيم عرض PowerPoint تقديمي إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح محددة.

قد ترغب في إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في عرض تقديمي إلى أجزاء منطقية في هذه الحالات:

- عندما تعمل على عرض تقديمي كبير مع أشخاص آخرين أو فريق—وتحتاج إلى تخصيص شرائح معينة لزميل أو بعض أعضاء الفريق.
- عندما تتعامل مع عرض تقديمي يحتوي على العديد من الشرائح—وتواجه صعوبة في إدارة أو تعديل محتوياته دفعة واحدة.

من المثالي أن تقوم بإنشاء قسم يحتوي على شرائح مشابهة—الشرائح لها شيء مشترك أو يمكن أن توجد في مجموعة بناءً على قاعدة—وتعطي القسم اسمًا يصف الشرائح بداخله.

## إنشاء أقسام في العروض التقديمية

لإضافة قسم سيحتوي على شرائح في عرض تقديمي، توفر Aspose.Slides لـ Java [addSection()](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) التي تتيح لك تحديد اسم القسم الذي تنوي إنشائه والشريحة التي يبدأ منها القسم.

يظهر لك هذا الكود العينة كيفية إنشاء قسم في عرض تقديمي باستخدام Java:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("القسم 1", newSlide1);
    ISection section2 = pres.getSections().addSection("القسم 2", newSlide3); // سينتهي section1 عند newSlide2 وبعده سيبدأ section2

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

بعد أن تقوم بإنشاء قسم في عرض PowerPoint تقديمي، قد تقرر تغيير اسمه.

يظهر لك هذا الكود العينة كيفية تغيير اسم قسم في عرض تقديمي باستخدام Java مع Aspose.Slides:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("قسمي");
} finally {
    if (pres != null) pres.dispose();
}
```