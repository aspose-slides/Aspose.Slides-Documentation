---
title: إضافة توقيعات رقمية إلى العروض التقديمية في PHP
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/php-java/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- سلطة شهادات
- شهادة PFX
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيفية توقيع ملفات PowerPoint وOpenDocument رقمياً باستخدام Aspose.Slides للـ PHP عبر Java. احمِ شرائحك في ثوانٍ مع أمثلة شفرة واضحة."
---

**شهادة رقمية** تُستخدم لإنشاء عرض تقديمي لبرنامج PowerPoint محمي بكلمة مرور، معلمة على أنه تم إنشاؤه بواسطة منظمة أو شخص معين. يمكن الحصول على شهادة رقمية عن طريق الاتصال بمنظمة مُعتمدة - سلطة شهادات. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض عبر File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

قد يحتوي العرض على أكثر من توقيع رقمي واحد. بعد إضافة التوقيع الرقمي إلى العرض، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

لتوقيع العرض أو للتحقق من صحة توقيعات العرض، يوفر **Aspose.Slides API** واجهة [**IDigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignature) وواجهة [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignatureCollection) وطريقة [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#getDigitalSignatures--) . حاليًا، يتم دعم التوقيعات الرقمية لتنسيق PPTX فقط.

## **إضافة توقيع رقمي من شهادة PFX**
يوضح عينة الشيفرة أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. افتح ملف PFX ومرّر كلمة مرور PFX إلى كائن [**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature).
2. أضف التوقيع المُنشأ إلى كائن العرض.
```php
  # فتح ملف العرض التقديمي
  $pres = new Presentation();
  try {
    # إنشاء كائن DigitalSignature باستخدام ملف PFX وكلمة مرور PFX
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # إضافة تعليق إلى التوقيع الرقمي الجديد
    $signature->setComments("Aspose.Slides digital signing test.");
    # إضافة توقيع رقمي إلى العرض التقديمي
    $pres->getDigitalSignatures()->add($signature);
    # حفظ العرض التقديمي
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


الآن يمكن التحقق مما إذا كان العرض موقعًا رقميًا ولم يتم تعديلّه:
```php
  # فتح العرض التقديمي
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # التحقق مما إذا كانت جميع التواقيع الرقمية صالحة
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


## **الأسئلة المتكررة**

**هل يمكنني إزالة التوقيعات الموجودة من ملف؟**

نعم. تدعم مجموعة التوقيعات الرقمية [removing individual items](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/removeat/) و[clearing it entirely](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/clear/)؛ بعد حفظ الملف، لن يحتوي العرض على أي توقيعات.

**هل يصبح الملف "للقراءة فقط" بعد التوقيع؟**

لا. التوقيع يحافظ على النزاهة والملكية ولكنه لا يمنع التعديلات. لتقييد التعديل، اجمعه مع ["Read-only" or a password](/slides/ar/php-java/password-protected-presentation/).

**هل سيظهر التوقيع بشكل صحيح في إصدارات مختلفة من PowerPoint؟**

التوقيع مُصمم لحاوية OOXML (PPTX). الإصدارات الحديثة من PowerPoint التي تدعم توقيعات OOXML تعرض حالة هذه التوقيعات بشكل صحيح.