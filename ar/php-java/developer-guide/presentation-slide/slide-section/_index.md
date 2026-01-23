---
title: إدارة أقسام الشرائح في العروض باستخدام PHP
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
description: "قم بتبسيط أقسام الشرائح في PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java — قسم، أعد تسمية، ورتب لتطوير سير عمل ملفات PPTX وODP."
---

مع Aspose.Slides للـ PHP عبر Java، يمكنك تنظيم عرض PowerPoint إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح محددة.

قد ترغب في إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في العرض إلى أجزاء منطقية في هذه الحالات:

- عندما تعمل على عرض كبير مع أشخاص آخرين أو فريق—وتحتاج إلى تعيين شرائح معينة لزميل أو بعض أعضاء الفريق. 
- عندما تتعامل مع عرض يحتوي على many slides—وتكافح لإدارة أو تعديل محتواه كله دفعة واحدة.

من المثالي أن تنشئ قسمًا يضم شرائح متشابهة—الشرائح لديها شيء مشترك أو يمكن أن تكون في مجموعة بناءً على قاعدة—وتعطي القسم اسمًا يصف الشرائح بداخله. 

## **إنشاء أقسام في العروض**

لإضافة قسم يضم شرائح في عرض، توفر Aspose.Slides للـ PHP عبر Java طريقة [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/sectioncollection/#addSection) التي تسمح لك بتحديد اسم القسم الذي تنوي إنشائه والشرائح التي يبدأ منها القسم.

يعرض هذا المثال البرمجي كيفية إنشاء قسم في عرض :
```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("Section 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("Section 2", $newSlide3);// سيُنهى القسم 1 عند الشريحة newSlide2 وبعد ذلك سيبدأ القسم 2

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

يعرض هذا المثال البرمجي كيفية تغيير اسم قسم في عرض باستخدام Aspose.Slides:
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


## **FAQ**

**هل يتم حفظ الأقسام عند الحفظ بتنسيق PPT (PowerPoint 97–2003)؟**

لا. تنسيق PPT لا يدعم بيانات تعريف الأقسام، لذا يتم فقدان تجميع الأقسام عند الحفظ إلى .ppt.

**هل يمكن إخفاء قسم كامل؟**

لا. يمكن إخفاء الشرائح الفردية فقط. لا يمتلك القسم ككيان حالة "مخفية".

**هل يمكنني العثور بسرعة على قسم عبر شريحة، وعكس ذلك، على الشريحة الأولى للقسم؟**

نعم. يتم تعريف القسم بشكل فريد بواسطة شريحته البداية؛ بناءً على شريحة يمكنك تحديد القسم الذي تنتمي إليه، وبالنسبة للقسم يمكنك الوصول إلى الشريحة الأولى له.