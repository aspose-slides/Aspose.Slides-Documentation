---
title: قسم الشريحة
type: docs
weight: 90
url: /ar/nodejs-java/slide-section/
---

باستخدام Aspose.Slides لـ Node.js عبر Java، يمكنك تنظيم عرض PowerPoint إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح محددة.

قد ترغب في إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في عرض تقديمي إلى أجزاء منطقية في الحالات التالية:

- عندما تعمل على عرض تقديمي كبير مع أشخاص آخرين أو فريق—وتحتاج إلى تخصيص شرائح معينة لزميل أو بعض أعضاء الفريق.  
- عندما تتعامل مع عرض تقديمي يحتوي على العديد من الشرائح—وتجد صعوبة في إدارة أو تعديل محتوياته دفعة واحدة.

مثاليًا، يجب عليك إنشاء قسم يضم شرائح متشابهة—الشرائح ذات صلة أو يمكن تجميعها بناءً على قاعدة—وتسمية هذا القسم بحيث يصف الشرائح الموجودة داخله. 

## **Creating Sections in Presentations**

لإضافة قسم يضم شرائح في عرض تقديمي، يوفر Aspose.Slides لـ Node.js عبر Java الطريقة [addSection()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) التي تسمح لك بتحديد اسم القسم الذي تريد إنشاؤه والشرائح التي يبدأ منها القسم.

يوضح لك هذا المثال البرمجي كيفية إنشاء قسم في عرض تقديمي باستخدام JavaScript:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 ستنتهي عند newSlide2 وبعدها سيبدأ section2
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Changing the Names of Sections**

بعد إنشاء قسم في عرض PowerPoint، قد تقرر تغيير اسمه.  

يوضح لك هذا المثال البرمجي كيفية تغيير اسم القسم في عرض تقديمي باستخدام JavaScript و Aspose.Slides:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**هل يتم الحفاظ على الأقسام عند الحفظ بتنسيق PPT (PowerPoint 97–2003)؟**

لا. لا يدعم تنسيق PPT بيانات تعريف الأقسام، لذلك يتم فقدان تجميع الأقسام عند الحفظ بصيغة .ppt.

**هل يمكن إخفاء قسم كامل؟**

لا. يمكن إخفاء الشرائح الفردية فقط. لا يمتلك القسم ككيان حالة "مخفى".

**هل يمكنني العثور سريعًا على قسم عبر شريحة، وعلى العكس، الشريحة الأولى في القسم؟**

نعم. يتم تعريف القسم بشكل فريد من خلال شريحته الأولى؛ بناءً على شريحة يمكنك تحديد القسم الذي تنتمي إليه، وبالنسبة للقسم يمكنك الوصول إلى شريحته الأولى.