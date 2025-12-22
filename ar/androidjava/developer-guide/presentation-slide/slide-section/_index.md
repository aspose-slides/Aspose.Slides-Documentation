---
title: إدارة أقسام الشرائح في العروض التقديمية على Android
linktitle: قسم الشريحة
type: docs
weight: 90
url: /ar/androidjava/slide-section/
keywords:
- إنشاء قسم
- إضافة قسم
- تعديل قسم
- تغيير قسم
- اسم القسم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تبسيط أقسام الشرائح في PowerPoint و OpenDocument باستخدام Aspose.Slides للـ Android عبر Java — تقسيم، إعادة تسمية، وإعادة ترتيب لتحسين تدفقات عمل PPTX و ODP."
---

مع Aspose.Slides للـ Android عبر Java، يمكنك تنظيم عرض PowerPoint إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح محددة.

قد ترغب في إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في عرض تقديمي إلى أجزاء منطقية في الحالات التالية:

- عند العمل على عرض تقديمي كبير مع أشخاص آخرين أو فريق—وتحتاج إلى تعيين شرائح معينة إلى زميل أو بعض أعضاء الفريق. 
- عند التعامل مع عرض تقديمي يحتوي على العديد من الشرائح—وتكافح لإدارة أو تعديل محتواه دفعة واحدة.

من الناحية المثالية، يجب أن تنشئ قسماً يضم شرائح متشابهة—الشرائح لها شيء مشترك أو يمكن أن توجد في مجموعة بناءً على قاعدة—وتمنح القسم اسمًا يصف الشرائح الموجودة داخله. 

## **إنشاء أقسام في العروض التقديمية**

لإضافة قسم سيحتوي على شرائح في عرض تقديمي، توفر Aspose.Slides للـ Android عبر Java الطريقة [addSection()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) التي تتيح لك تحديد اسم القسم الذي تنوي إنشائه والشرائح التي يبدأ منها القسم.

يظهر هذا المثال البرمجي كيفية إنشاء قسم في عرض تقديمي باستخدام Java:
```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // سيتم إنهاء القسم 1 عند newSlide2 وبعده سيبدأ القسم 2   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **تغيير أسماء الأقسام**

بعد إنشاء قسم في عرض PowerPoint، قد تقرر تغيير اسمه. 

يظهر هذا المثال البرمجي كيفية تغيير اسم القسم في عرض تقديمي باستخدام Java و Aspose.Slides:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**هل يتم الاحتفاظ بالأقسام عند الحفظ بصيغة PPT (PowerPoint 97–2003)؟**

لا. لا تدعم صيغة PPT بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ بصيغة .ppt.

**هل يمكن إخفاء قسم كامل؟**

لا. يمكن إخفاء الشرائح الفردية فقط. لا يمتلك القسم ككيان حالة "مخفي".

**هل يمكنني العثور بسرعة على قسم باستخدام شريحة، والعكس، العثور على الشريحة الأولى للقسم؟**

نعم. يتم تعريف القسم بشكل فريد بالشفرة التي يبدأ منها؛ بإعطائك شريحة يمكنك تحديد القسم الذي تنتمي إليه، ويمكنك الوصول إلى الشريحة الأولى للقسم.