---
title: إدارة أقسام الشرائح في العروض التقديمية باستخدام Java
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
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "بسّط أقسام الشرائح في PowerPoint وOpenDocument باستخدام Aspose.Slides for Java — قسّمها, أعد تسميتها, وأعد ترتيبها لتحسين سير عمل ملفات PPTX وODP."
---

مع Aspose.Slides for Java، يمكنك تنظيم عرض PowerPoint إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح محددة. 

قد ترغب في إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في عرض تقديمي إلى أجزاء منطقية في الحالات التالية:

- عندما تعمل على عرض تقديمي كبير مع أشخاص آخرين أو فريق — وتحتاج إلى تعيين شرائح معينة لزميل أو لبعض أفراد الفريق. 
- عندما تتعامل مع عرض تقديمي يحتوي على العديد من الشرائح — وتواجه صعوبة في إدارة أو تحرير محتوياته دفعة واحدة.

من المثالي إنشاء قسم يضم شرائح مماثلة — تكون للشرائح شيء مشترك أو يمكن أن تكون في مجموعة بناءً على قاعدة — وإعطاء القسم اسمًا يصف الشرائح التي يحتويها. 

## **إنشاء أقسام في العروض التقديمية**

لإضافة قسم سيحتوي على شرائح في عرض تقديمي، توفر Aspose.Slides for Java طريقة [addSection()](https://reference.aspose.com/slides/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) التي تسمح لك بتحديد اسم القسم الذي تريد إنشاءه والشفرة التي يبدأ منها القسم. 

هذا المثال يوضح كيفية إنشاء قسم في عرض تقديمي باستخدام Java:
```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // سيتم إنهاء القسم 1 عند newSlide2 وبعدها سيبدأ القسم 2

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

هذا المثال يوضح كيفية تغيير اسم قسم في عرض تقديمي باستخدام Java وAspose.Slides:
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

**هل يتم الحفاظ على الأقسام عند الحفظ بتنسيق PPT (PowerPoint 97–2003)؟**

لا. لا يدعم تنسيق PPT بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ إلى .ppt.

**هل يمكن إخفاء القسم بأكمله؟**

لا. يمكن إخفاء الشرائح الفردية فقط. لا يوجد حالة "مخفي" للقسم ككيان.

**هل يمكنني العثور بسرعة على قسم عبر شريحة، والعكس، الحصول على أول شريحة في القسم؟**

نعم. يُعرَّف القسم بشكل فريد بواسطة الشريحة البداية؛ بناءً على شريحة يمكنك تحديد القسم الذي تنتمي إليه، وللقسم يمكنك الوصول إلى شريحته الأولى.