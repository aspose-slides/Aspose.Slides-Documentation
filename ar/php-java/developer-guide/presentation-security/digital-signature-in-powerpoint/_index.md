---
title: التوقيع الرقمي في PowerPoint
type: docs
weight: 10
url: /php-java/digital-signature-in-powerpoint/
keywords: "شهادة التوقيع الرقمي، سلطة الشهادة"
description: "إضافة شهادة التوقيع الرقمي، وسلطة الشهادة في عرض PowerPoint باستخدام Aspose.Slides."
---

**الشهادة الرقمية** تُستخدم لإنشاء عرض PowerPoint محمي بكلمة مرور، مميز بأنه تم إنشاؤه بواسطة منظمة أو شخص معين. يمكن الحصول على الشهادة الرقمية من خلال الاتصال بمنظمة معتمدة - وهي سلطة الشهادة. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض من خلال ملف -> معلومات -> حماية العرض:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

يمكن أن يحتوي العرض على أكثر من توقيع رقمي واحد. بعد إضافة التوقيع الرقمي إلى العرض، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

لتوقيع العرض أو التحقق من أصالة توقيعات العرض، توفر **واجهة برمجة تطبيقات Aspose.Slides** [**IDigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignature) و[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignatureCollection) و[**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#getDigitalSignatures--) طريقة. حاليًا، يتم دعم التوقيعات الرقمية لتنسيق PPTX فقط.
## **إضافة توقيع رقمي من شهادة PFX**
توضح عينة الكود أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. افتح ملف PFX ومرر كلمة مرور PFX إلى [**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature) كائن.
1. أضف التوقيع الذي تم إنشاؤه إلى كائن العرض.

```php
  # فتح ملف العرض
  $pres = new Presentation();
  try {
    # إنشاء كائن DigitalSignature مع ملف PFX وكلمة مرور PFX
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # تعليق على التوقيع الرقمي الجديد
    $signature->setComments("اختبار التوقيع الرقمي من Aspose.Slides.");
    # إضافة التوقيع الرقمي إلى العرض
    $pres->getDigitalSignatures()->add($signature);
    # حفظ العرض
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

الآن يمكن التحقق مما إذا كان العرض قد تم توقيعه رقميًا ولم يتم تعديله:

```php
  # فتح العرض
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("التوقيعات المستخدمة لتوقيع العرض: ");
      # التحقق مما إذا كانت جميع التوقيعات الرقمية صالحة
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "صالح" : "غير صالح");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("العرض أصلي، جميع التوقيعات صالحة.");
      } else {
        echo("تم تعديل العرض منذ التوقيع.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```