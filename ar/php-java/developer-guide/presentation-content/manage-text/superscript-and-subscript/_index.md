---
title: إدارة النص العلوي والنص السفلي في العروض التقديمية باستخدام PHP
linktitle: النص العلوي والنص السفلي
type: docs
weight: 80
url: /ar/php-java/superscript-and-subscript/
keywords:
- النص العلوي
- النص السفلي
- إضافة نص علوي
- إضافة نص سفلي
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إتقان النص العلوي والنص السفلي في Aspose.Slides لـ PHP عبر Java وتعزيز عروضك التقديمية بتنسيق نص احترافي لتحقيق أقصى تأثير."
---

## **إدارة النص العلوي والنص السفلي**
يمكنك إضافة نص علوي أو نص سفلي داخل أي جزء من الفقرة. لإضافة نص علوي أو نص سفلي في إطار نص Aspose.Slides يجب استخدام طريقة [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) الخاصة بفئة [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat).

هذه الخاصية تُعيد أو تُعيّن النص العلوي أو السفلي (القيمة من -100٪ (سفلي) إلى 100٪ (علوي)). على سبيل المثال:

- إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- الحصول على مرجع الشريحة باستخدام فهرستها.
- إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) من نوع [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- الوصول إلى [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) المرتبط بـ [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/).
- مسح الفقرات الحالية.
- إنشاء كائن فقرة جديد لحفظ النص العلوي وإضافته إلى مجموعة [IParagraphs](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParagraphs) الخاصة بـ [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).
- إنشاء كائن جزء جديد.
- تعيين خاصية Escapement للجزء بين 0 إلى 100 لإضافة النص العلوي. (0 يعني عدم وجود نص علوي)
- تعيين نص لـ [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) ثم إضافته إلى مجموعة الأجزاء في الفقرة.
- إنشاء كائن فقرة جديد لحفظ النص السفلي وإضافته إلى مجموعة IParagraphs الخاصة بـ ITextFrame.
- إنشاء كائن جزء جديد.
- تعيين خاصية Escapement للجزء بين 0 إلى -100 لإضافة النص السفلي. (0 يعني عدم وجود نص سفلي)
- تعيين نص لـ [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) ثم إضافته إلى مجموعة الأجزاء في الفقرة.
- حفظ العرض التقديمي كملف PPTX.

تُظهر الشيفرة التنفيذية للخطوات السابقة أدناه.
```php
  # إنشاء كائن من فئة Presentation تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة
    $slide = $pres->getSlides()->get_Item(0);
    # إنشاء صندوق نص
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # إنشاء فقرة للنص العلوي
    $superPar = new Paragraph();
    # إنشاء جزء بنص عادي
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # إنشاء جزء بنص علوي
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # إنشاء فقرة للنص السفلي
    $paragraph2 = new Paragraph();
    # إنشاء جزء بنص عادي
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # إنشاء جزء بنص سفلي
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # إضافة الفقرات إلى صندوق النص
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يتم الحفاظ على النص العلوي والنص السفلي عند التصدير إلى PDF أو صيغ أخرى؟**

نعم، يحتفظ Aspose.Slides بشكل صحيح بتنسيق النص العلوي والسفلي عند تصدير العروض التقديمية إلى PDF أو PPT/PPTX أو الصور أو أي صيغ مدعومة أخرى. يبقى التنسيق المتخصص سليمًا في جميع ملفات الإخراج.

**هل يمكن دمج النص العلوي والسفلي مع أنماط تنسيق أخرى مثل الغامق أو المائل؟**

نعم، يسمح Aspose.Slides بخلط أنماط النص المختلفة ضمن جزء نص واحد. يمكنك تفعيل الغامق أو المائل أو التسطير وتطبيق النص العلوي أو السفلي في الوقت نفسه عن طريق ضبط الخصائص المقابلة في [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

**هل يعمل تنسيق النص العلوي والسفلي للنص داخل الجداول أو المخططات أو SmartArt؟**

نعم، يدعم Aspose.Slides التنسيق داخل معظم الكائنات، بما في ذلك الجداول وعناصر المخططات. عند العمل مع SmartArt، تحتاج إلى الوصول إلى العناصر المناسبة (مثل [SmartArtNode](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/)) وحاويات النص الخاصة بها، ثم ضبط خصائص [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/) بصورة مماثلة.