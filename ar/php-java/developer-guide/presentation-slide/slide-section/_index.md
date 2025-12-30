---
title: إدارة أقسام الشرائح في العروض التقديمية باستخدام PHP
linktitle: قسم الشريحة
type: docs
weight: 90
url: /ar/php-java/slide-section/
keywords:
- إنشاء قسم
- إضافة قسم
- تحرير قسم
- تغيير قسم
- اسم القسم
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "ابسط أقسام الشرائح في PowerPoint و OpenDocument باستخدام Aspose.Slides for PHP عبر Java — قسّم، أعد تسميتها، وأعد ترتيبها لتحسين سير عمل ملفات PPTX و ODP."
---

مع Aspose.Slides for PHP عبر Java، يمكنك تنظيم عرض PowerPoint إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح معينة.

قد ترغب في إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في عرض تقديمي إلى أجزاء منطقية في الحالات التالية:

- عندما تعمل على عرض تقديمي كبير مع أشخاص آخرين أو فريق—وتحتاج إلى تخصيص شرائح معينة لزميل أو لبعض أعضاء الفريق. 
- عندما تتعامل مع عرض تقديمي يحتوي على عدد كبير من الشرائح—وتكافح لإدارة أو تحرير محتوياته دفعة واحدة.

من المثالي أن تنشئ قسماً يضم شرائح متشابهة—الشرائح لها شيء مشترك أو يمكن أن تتواجد في مجموعة بناءً على قاعدة—وتعطي القسم اسماً يصف الشرائح الموجودة داخله. 

## **إنشاء أقسام في العروض التقديمية**

لإضافة قسم سيحتوي على شرائح في العرض التقديمي، توفر Aspose.Slides for PHP عبر Java طريقة [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) التي تسمح لك بتحديد اسم القسم الذي تنوي إنشائه والشريحة التي يبدأ منها القسم.

يظهر هذا المثال الشيفرة كيفية إنشاء قسم في عرض تقديمي :
```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// سيتم إنهاء section1 عند newSlide2 وبعد ذلك سيبدأ section2

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("Last empty section");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تغيير أسماء الأقسام**

بعد إنشاء قسم في عرض PowerPoint، قد تقرر تغيير اسمه. 

يظهر هذا المثال الشيفرة كيفية تغيير اسم القسم في عرض تقديمي باستخدام Aspose.Slides:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("My section");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة المتكررة**

**هل يتم الحفاظ على الأقسام عند حفظ الملف بصيغة PPT (PowerPoint 97–2003)؟**

لا. لا تدعم صيغة PPT بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ إلى .ppt.

**هل يمكن إخفاء قسم كامل؟**

لا. لا يمكن إخفاء سوى الشرائح الفردية. القسم ككيان ليس له حالة “مخفية”.

**هل يمكنني العثور بسرعة على قسم بناءً على شريحة، والعكس، الحصول على الشريحة الأولى للقسم؟**

نعم. يتم تعريف القسم بشكل فريد بشريحته الابتدائية؛ بناءً على شريحة يمكنك تحديد القسم الذي تنتمي إليه، ومن خلال القسم يمكنك الوصول إلى شريحته الأولى.