---
title: أتمتة تعريب العروض التقديمية في PHP
linktitle: تعريب العروض التقديمية
type: docs
weight: 100
url: /ar/php-java/presentation-localization/
keywords:
- تغيير اللغة
- التدقيق الإملائي
- معرف اللغة
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "أتمتة تعريب شرائح PowerPoint وOpenDocument باستخدام Aspose.Slides للـ PHP عبر Java، مع أمثلة كود عملية ونصائح لتسريع النشر العالمي."
---

## **تغيير اللغة لعروض تقديمية ونص الشكل**
- إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
- الحصول على مرجع الشريحة باستخدام فهرستها.
- إضافة [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) من النوع [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- إضافة بعض النص إلى TextFrame.
- [Set Language Id](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) للنص.
- حفظ العرض التقديمي كملف PPTX.

تم توضيح تنفيذ الخطوات السابقة أدناه في مثال.
```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يؤدي معرف اللغة إلى ترجمة النص تلقائيًا؟**

لا. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) في Aspose.Slides يخزن اللغة للتحقق الإملائي وإثبات القواعد، لكنه لا يترجم أو يغيّر محتوى النص. إنه بيانات وصفية يفهمها PowerPoint لأغراض التدقيق.

**هل يؤثر معرف اللغة على التجزيء وتحديد الفواصل أثناء العرض؟**

في Aspose.Slides، يُستخدم [language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) لأغراض التدقيق فقط. تعتمد جودة التجزيء وتغليف السطور أساسًا على توفر [proper fonts](/slides/ar/php-java/powerpoint-fonts/) وإعدادات تخطيط/تحديد الفواصل لنظام الكتابة. لضمان عرض صحيح، يجب توفير الخطوط المطلوبة، وتكوين [font substitution rules](/slides/ar/php-java/font-substitution/)، و/أو [embed fonts](/slides/ar/php-java/embedded-font/) في العرض التقديمي.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. يُطبق [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) على مستوى جزء النص، لذا يمكن لفقرة واحدة أن تحتوي على لغات متعددة بإعدادات تدقيق مختلفة.