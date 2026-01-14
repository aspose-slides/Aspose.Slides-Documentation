---
title: إضافة توقيعات رقمية إلى العروض التقديمية في PHP
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/php-java/digital-signature-in-powerpoint/
keywords:
- التوقيع الرقمي
- الشهادة الرقمية
- سلطة الشهادة
- شهادة PFX
- PowerPoint
- OpenDocument
- العرض التقديمي
- PHP
- Aspose.Slides
description: "تعلم كيف تقوم بتوقيع ملفات PowerPoint وOpenDocument رقمياً باستخدام Aspose.Slides للـ PHP عبر Java. احمِ شرائحك في ثوانٍ مع أمثلة شفرة واضحة."
---

**الشهادة الرقمية** تُستخدم لإنشاء عرض تقديمي محمي بكلمة مرور، مع تحديد أنه تم إنشاؤه بواسطة منظمة أو شخص معين. يمكن الحصول على الشهادة الرقمية عبر التواصل مع منظمة مخولة – سلطة الشهادة. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض التقديمي عبر ملف -> معلومات -> حماية العرض التقديمي:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

قد يحتوي العرض التقديمي على أكثر من توقيع رقمي واحد. بعد إضافة التوقيع الرقمي إلى العرض التقديمي، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

لتوقيع العرض التقديمي أو التحقق من صحة توقيعات العرض، توفر **Aspose.Slides API** الفئة [**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature)، الفئة [**DigitalSignatureCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignatureCollection) والطريقة [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getDigitalSignatures). حاليًا، تدعم التوقيعات الرقمية تنسيق PPTX فقط.
## **إضافة توقيع رقمي من شهادة PFX**
يوضح عينة الشيفرة أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. فتح ملف PFX وتمرير كلمة مرور PFX إلى كائن [**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature).
2. إضافة التوقيع المُنشأ إلى كائن العرض التقديمي.
```php
  # فتح ملف العرض التقديمي
  $pres = new Presentation();
  try {
    # إنشاء كائن DigitalSignature باستخدام ملف PFX وكلمة مرور PFX
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # تعليق على توقيع رقمي جديد
    $signature->setComments("Aspose.Slides digital signing test.");
    # إضافة توقيع رقمي إلى العرض التقديمي
    $pres->getDigitalSignatures()->add($signature);
    # حفظ العرض التقديمي
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


الآن يمكن التحقق مما إذا كان العرض التقديمي موقّعًا رقميًا ولم يتم تعديله:
```php
  # فتح العرض التقديمي
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # التحقق من صحة جميع التوقيعات الرقمية
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **الأسئلة الشائعة**

**هل يمكنني إزالة التوقيعات الموجودة من ملف؟**

نعم. تدعم مجموعة التوقيعات الرقمية [إزالة العناصر الفردية](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/removeat/) و[مسحها بالكامل](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/clear/)؛ بعد حفظ الملف، لن يحتوي العرض التقديمي على أي توقيعات.

**هل يصبح الملف "للقراءة فقط" بعد التوقيع؟**

لا. يحافظ التوقيع على السلامة والملكية لكنه لا يمنع التعديلات. لتقييد التحرير، يمكن دمجه مع ["للقراءة فقط" أو كلمة مرور](/slides/ar/php-java/password-protected-presentation/).

**هل سيظهر التوقيع بشكل صحيح في إصدارات مختلفة من PowerPoint؟**

يُنشأ التوقيع لحاوية OOXML (PPTX). الإصدارات الحديثة من PowerPoint التي تدعم توقيعات OOXML تعرض حالة هذه التوقيعات بصورة صحيحة.