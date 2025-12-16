---
title: إضافة توقيعات رقمية إلى العروض التقديمية على Android
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/androidjava/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- سلطة شهادات
- شهادة PFX
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية توقيع ملفات PowerPoint و OpenDocument رقمياً باستخدام Aspose.Slides لـ Android. احمِ عروضك خلال ثوانٍ باستخدام أمثلة كود Java واضحة."
---

**شهادة رقمية** تُستخدم لإنشاء عرض باوربوينت محمي بكلمة مرور، معلمة بأنه تم إنشاؤه من قبِل مؤسسة أو شخص معين. يمكن الحصول على الشهادة الرقمية عن طريق التواصل مع مؤسسة مُخَولة - سلطة شهادات. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض عبر ملف -> معلومات -> حماية العرض:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

قد يحتوي العرض على أكثر من توقيع رقمي. بعد إضافة التوقيع الرقمي إلى العرض، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

لتوقيع العرض أو التحقق من صحة توقيعات العرض، تُوفر **Aspose.Slides API** الواجهة [**IDigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignature)، الواجهة [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignatureCollection) والطريقة [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--) . حاليًا، يتم دعم التوقيعات الرقمية لتنسيق PPTX فقط.
## **إضافة توقيع رقمي من شهادة PFX**
يوضح عينة الشيفرة أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. افتح ملف PFX ومرّر كلمة مرور PFX إلى كائن [**DigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/DigitalSignature) .
2. أضف التوقيع المُنشأ إلى كائن العرض.
```java
// فتح ملف العرض التقديمي
Presentation pres = new Presentation();
try {
    // إنشاء كائن DigitalSignature باستخدام ملف PFX وكلمة مرور PFX
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // تعليق على توقيع رقمي جديد
    signature.setComments("Aspose.Slides digital signing test.");

    // إضافة توقيع رقمي إلى العرض التقديمي
    pres.getDigitalSignatures().add(signature);

    // حفظ العرض التقديمي
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


الآن يمكن التحقق مما إذا كان العرض موقّعًا رقمياً ولم يتم تعديلّه:
```java
// فتح العرض التقديمي
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // التحقق مما إذا كانت جميع التوقيعات الرقمية صالحة
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتكررة**

**هل يمكنني إزالة التوقيعات الموجودة من ملف؟**

نعم. تدعم مجموعة التوقيعات الرقمية [إزالة العناصر الفردية](https://reference.aspose.com/slides/androidjava/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) و[مسحها بالكامل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/digitalsignaturecollection/#clear--) ; بعد حفظ الملف، لن يحتوي العرض على أي توقيعات.

**هل يصبح الملف "للقراءة فقط" بعد التوقيع؟**

لا. يحافظ التوقيع على النزاهة والملكية لكنه لا يمنع التعديلات. لتقييد التحرير، اجمعه مع ["للقراءة فقط" أو كلمة مرور](/slides/ar/androidjava/password-protected-presentation/).

**هل سيظهر التوقيع بشكل صحيح في إصدارات مختلفة من PowerPoint؟**

تم إنشاء التوقيع لحاوية OOXML (PPTX). الإصدارات الحديثة من PowerPoint التي تدعم توقيعات OOXML تعرض حالة هذه التوقيعات بشكل صحيح.