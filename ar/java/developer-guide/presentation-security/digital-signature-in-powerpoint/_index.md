---
title: التوقيع الرقمي في PowerPoint
type: docs
weight: 10
url: /ar/java/digital-signature-in-powerpoint/
keywords: "شهادة التوقيع الرقمي، سلطة التصديق"
description: "إضافة شهادة التوقيع الرقمي وسلطة التصديق إلى عرض PowerPoint باستخدام Aspose.Slides."
---


**الشهادة الرقمية** تُستخدم لإنشاء عرض PowerPoint محمي بكلمة مرور، مُعلمة كُمنشأة بواسطة منظمة معينة أو شخص معين. يمكن الحصول على الشهادة الرقمية من خلال الاتصال بمنظمة مخولة - سلطة التصديق. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي للعرض عبر ملف -> معلومات -> حماية العرض:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



يمكن أن يحتوي العرض على أكثر من توقيع رقمي واحد. بعد إضافة التوقيع الرقمي إلى العرض، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



للتوقيع على العرض أو التحقق من مصداقية توقيعات العرض، يوفر **Aspose.Slides API** واجهة [**IDigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignature) وواجهة [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignatureCollection) وطريقة [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getDigitalSignatures--) . حالياً، يتم دعم التوقيعات الرقمية لصيغة PPTX فقط.
## **إضافة توقيع رقمي من شهادة PFX**
توضح عينة الكود أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. افتح ملف PFX ومرر كلمة مرور PFX إلى كائن [**DigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/DigitalSignature).
1. أضف التوقيع الذي تم إنشاؤه إلى كائن العرض.

```java
// فتح ملف العرض
Presentation pres = new Presentation();
try {
    // إنشاء كائن DigitalSignature باستخدام ملف PFX وكلمة مرور PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // تعليق التوقيع الرقمي الجديد
    signature.setComments("اختبار التوقيع الرقمي لـ Aspose.Slides.");

    // إضافة التوقيع الرقمي إلى العرض
    pres.getDigitalSignatures().add(signature);

    // حفظ العرض
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

الآن من الممكن التحقق مما إذا كان العرض قد تم توقيعه رقمياً ولم يتم تعديله:

```java
// فتح العرض
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("التوقيعات المستخدمة لتوقيع العرض: ");

        // التحقق مما إذا كانت جميع التوقيعات الرقمية صالحة
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "صالح" : "غير صالح"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("العرض أصلي، جميع التوقيعات صالحة.");
        else
            System.out.println("تم تعديل العرض منذ التوقيع.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```