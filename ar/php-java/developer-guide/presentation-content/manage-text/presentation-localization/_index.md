---
title: أتمتة توطين العروض التقديمية في PHP
linktitle: توطين العروض التقديمية
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
description: "أتمتة توطين شرائح PowerPoint وOpenDocument مع Aspose.Slides للـ PHP عبر Java، باستخدام أمثلة شفرة عملية ونصائح لتسريع النشر العالمي."
---

## **تغيير اللغة للعرض التقديمي ونص الشكل**
- إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) .
- الحصول على مرجع الشريحة باستخدام فهرسها.
- إضافة [IAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) من النوع [Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/ShapeType#Rectangle) إلى الشريحة.
- إضافة بعض النص إلى الـ TextFrame.
- [تعيين معرّف اللغة](https://reference.aspose.com/slides/php-java/aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) إلى النص.
- كتابة العرض التقديمي كملف PPTX.

تم توضيح تنفيذ الخطوات أعلاه أدناه في مثال.
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

**هل يتسبب معرّف اللغة في ترجمة النص تلقائيًا؟**

لا. [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) في Aspose.Slides يخزن اللغة لتدقيق الإملاء وتصحيح القواعد، لكنه لا يترجم أو يغيّر محتوى النص. إنه بيانات وصفية تفهمها PowerPoint للتدقيق.

**هل يؤثر معرّف اللغة على التجزيء وإدراج الفواصل خلال العرض؟**

في Aspose.Slides، [language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) مخصص للتدقيق. تعتمد جودة التجزيء وتغليف الأسطر أساسًا على توفر [الخطوط المناسبة](/slides/ar/php-java/powerpoint-fonts/) وإعدادات التخطيط/فواصل الأسطر لنظام الكتابة. لضمان عرض صحيح، احرص على توفير الخطوط المطلوبة، وتكوين [قواعد استبدال الخطوط](/slides/ar/php-java/font-substitution/)، و/أو [تضمين الخطوط](/slides/ar/php-java/embedded-font/) في العرض التقديمي.

**هل يمكنني تعيين لغات مختلفة داخل فقرة واحدة؟**

نعم. يتم تطبيق [Language ID](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId) على مستوى جزء النص، لذا يمكن لفقرة واحدة خلط لغات متعددة مع إعدادات تدقيق مميزة.