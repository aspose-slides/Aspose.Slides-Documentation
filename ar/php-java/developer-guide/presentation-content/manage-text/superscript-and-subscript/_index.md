---
title: النص العلوي والنص السفلي
type: docs
weight: 80
url: /php-java/superscript-and-subscript/
---

## **إدارة نص النص العلوي والنص السفلي**
يمكنك إضافة نص نص علوي ونص سفلي داخل أي جزء من الفقرة. لإضافة نص علوي أو نص سفلي في إطار نص Aspose.Slides، يجب استخدام [**setEscapement**](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setEscapement-float-) من فئة [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PortionFormat).

تُعيد هذه الخاصية أو تعين نص النص العلوي أو النص السفلي (قيمة من -100% (نص سفلي) إلى 100% (نص علوي). على سبيل المثال:

- إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
- الحصول على مرجع شريحة باستخدام فهرسها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) من نوع [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- الوصول إلى [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame) المرتبطة بـ [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape).
- مسح الفقرات الموجودة
- إنشاء كائن فقرة جديدة لحفظ النص العلوي وإضافته إلى [IParagraphs collection](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame#getParagraphs--) من [ITextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/ITextFrame).
- إنشاء كائن جزء جديد
- تعيين خاصية Escapement للجزء بين 0 إلى 100 لإضافة نص علوي. (0 يعني عدم وجود نص علوي)
- تعيين نص ما لـ [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) ثم إضافته إلى مجموعة الأجزاء في الفقرة.
- إنشاء كائن فقرة جديدة لحفظ النص السفلي وإضافته إلى مجموعة IParagraphs من ITextFrame.
- إنشاء كائن جزء جديد
- تعيين خاصية Escapement للجزء بين 0 إلى -100 لإضافة نص سفلي. (0 يعني عدم وجود نص سفلي)
- تعيين نص ما لـ [Portion](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) ثم إضافته إلى مجموعة الأجزاء في الفقرة.
- حفظ العرض التقديمي كملف PPTX.

ت implementation القيم أعلاه موضحة أدناه.

```php
  # إنشاء مثيل من فئة Presentation التي تمثل ملف PPTX
  $pres = new Presentation();
  try {
    # الحصول على الشريحة
    $slide = $pres->getSlides()->get_Item(0);
    # إنشاء مربع نص
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
    $textFrame = $shape->getTextFrame();
    $textFrame->getParagraphs()->clear();
    # إنشاء فقرة لنص علوي
    $superPar = new Paragraph();
    # إنشاء جزء بنص اعتيادي
    $portion1 = new Portion();
    $portion1->setText("SlideTitle");
    $superPar->getPortions()->add($portion1);
    # إنشاء جزء بنص علوي
    $superPortion = new Portion();
    $superPortion->getPortionFormat()->setEscapement(30);
    $superPortion->setText("TM");
    $superPar->getPortions()->add($superPortion);
    # إنشاء فقرة لنص سفلي
    $paragraph2 = new Paragraph();
    # إنشاء جزء بنص اعتيادي
    $portion2 = new Portion();
    $portion2->setText("a");
    $paragraph2->getPortions()->add($portion2);
    # إنشاء جزء بنص سفلي
    $subPortion = new Portion();
    $subPortion->getPortionFormat()->setEscapement(-25);
    $subPortion->setText("i");
    $paragraph2->getPortions()->add($subPortion);
    # إضافة الفقرات إلى مربع النص
    $textFrame->getParagraphs()->add($superPar);
    $textFrame->getParagraphs()->add($paragraph2);
    $pres->save("formatText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```