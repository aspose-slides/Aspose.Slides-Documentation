---
title: التوقيع الرقمي في PowerPoint
type: docs
weight: 10
url: /ar/nodejs-java/digital-signature-in-powerpoint/
keywords: "شهادة التوقيع الرقمي، سلطة الشهادات"
description: "إضافة شهادة التوقيع الرقمي وسلطة الشهادات إلى عرض PowerPoint باستخدام Aspose.Slides."
---

**Digital certificate** تُستخدم لإنشاء عرض تقديمي محمي بكلمة مرور في PowerPoint، مع علامة أنه تم إنشاؤه من قبل منظمة أو شخص معين. يمكن الحصول على شهادة رقمية بالتواصل مع منظمة معتمدة – سلطة شهادات. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض عبر ملف -> معلومات -> حماية العرض:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

قد يحتوي العرض على أكثر من توقيع رقمي واحد. بعد إضافة التوقيع الرقمي إلى العرض، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

لتوقيع العرض أو التحقق من صحة توقيعات العرض، توفر **Aspose.Slides API** فئة **DigitalSignature**، فئة **DigitalSignatureCollection** وطريقة Presentation.getDigitalSignatures. حاليًا، يتم دعم التوقيعات الرقمية لتنسيق PPTX فقط.
## **إضافة توقيع رقمي من شهادة PFX**
1. افتح ملف PFX ومرّر كلمة مرور PFX إلى كائن **DigitalSignature**.
2. أضف التوقيع المُنشأ إلى كائن العرض.
```javascript
// فتح ملف العرض التقديمي
var pres = new aspose.slides.Presentation();
try {
    // إنشاء كائن DigitalSignature باستخدام ملف PFX وكلمة مرور PFX
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // إضافة تعليق إلى التوقيع الرقمي الجديد
    signature.setComments("Aspose.Slides digital signing test.");
    // إضافة توقيع رقمي إلى العرض
    pres.getDigitalSignatures().add(signature);
    // حفظ العرض التقديمي
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


الآن يمكن التحقق مما إذا كان العرض موقّعًا رقمياً ولم يتم تعديلَه:
```javascript
// فتح العرض التقديمي
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // تحقق مما إذا كانت جميع التوقيعات الرقمية صالحة
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل يمكنني إزالة التوقيعات الموجودة من ملف؟**

نعم. تدعم مجموعة التوقيعات الرقمية [إزالة العناصر الفردية](https://reference.aspose.com/slides/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) و[مسحها بالكامل](https://reference.aspose.com/slides/nodejs-java/aspose.slides/digitalsignaturecollection/clear/); بعد حفظ الملف، لن يحتوي العرض على أي توقيعات.

**هل يصبح الملف "قراءة فقط" بعد التوقيع؟**

لا. يحافظ التوقيع على النزاهة والمؤلف ولكنه لا يمنع التعديلات. لتقييد التحرير، اجمعه مع ["Read-only" أو كلمة مرور](/slides/ar/nodejs-java/password-protected-presentation/).

**هل سيظهر التوقيع بشكل صحيح في إصدارات مختلفة من PowerPoint؟**

تم إنشاء التوقيع لحاوية OOXML (PPTX). تعرض إصدارات PowerPoint الحديثة التي تدعم توقيعات OOXML حالة هذه التوقيعات بشكل صحيح.