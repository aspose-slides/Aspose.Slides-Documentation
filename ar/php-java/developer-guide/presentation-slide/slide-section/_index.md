---
title: قسم الشريحة
type: docs
weight: 90
url: /php-java/slide-section/
---

مع Aspose.Slides لـ PHP عبر Java، يمكنك تنظيم عرض PowerPoint التقديمي إلى أقسام. يمكنك إنشاء أقسام تحتوي على شرائح محددة.

قد ترغب في إنشاء أقسام واستخدامها لتنظيم أو تقسيم الشرائح في عرض تقديمي إلى أجزاء منطقية في هذه الحالات:

- عندما تعمل على عرض تقديمي كبير مع أشخاص آخرين أو فريق—وتحتاج إلى تخصيص شرائح معينة لزميل أو بعض أعضاء الفريق. 
- عندما تتعامل مع عرض تقديمي يحتوي على العديد من الشرائح—وتكافح لإدارة أو تحرير محتوياته في مرة واحدة.

من المثالي أن تقوم بإنشاء قسم يحتوي على شرائح مماثلة—حيث تحتوي الشرائح على شيء مشترك أو يمكن أن توجد في مجموعة بناءً على قاعدة—وتعطي القسم اسمًا يصف الشرائح بداخله.

## إنشاء أقسام في العروض التقديمية

لإضافة قسم يحتوي على شرائح في عرض تقديمي، يوفر Aspose.Slides لـ PHP عبر Java طريقة [addSection()](https://reference.aspose.com/slides/php-java/aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) التي تتيح لك تحديد اسم القسم الذي تنوي إنشاؤه و الشريحة التي يبدأ منها القسم.

يظهر لك هذا الكود المثال كيفية إنشاء قسم في عرض تقديمي:

```php
  $pres = new Presentation();
  try {
    $defaultSlide = $pres->getSlides()->get_Item(0);
    $newSlide1 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide2 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide3 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $newSlide4 = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->get_Item(0));
    $section1 = $pres->getSections()->addSection("القسم 1", $newSlide1);
    $section2 = $pres->getSections()->addSection("القسم 2", $newSlide3);// سيتم إنهاء section1 عند newSlide2 وبعدها سيبدأ section2

    $pres->save("pres-sections.pptx", SaveFormat::Pptx);
    $pres->getSections()->reorderSectionWithSlides($section2, 0);
    $pres->save("pres-sections-moved.pptx", SaveFormat::Pptx);
    $pres->getSections()->removeSectionWithSlides($section2);
    $pres->getSections()->appendEmptySection("آخر قسم فارغ");
    $pres->save("pres-section-with-empty.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## تغيير أسماء الأقسام

بعد إنشاء قسم في عرض PowerPoint التقديمي، قد تقرر تغيير اسمه.

يظهر لك هذا الكود المثال كيفية تغيير اسم قسم في عرض تقديمي باستخدام Aspose.Slides:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $section = $pres->getSections()->get_Item(0);
    $section->setName("القسم الخاص بي");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```