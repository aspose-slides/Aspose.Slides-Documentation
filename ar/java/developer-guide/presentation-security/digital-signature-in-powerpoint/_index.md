---
title: إضافة توقيعات رقمية إلى العروض التقديمية في جافا
linktitle: توقيع رقمي
type: docs
weight: 10
url: /ar/java/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- جهة إصدار الشهادات
- شهادة PFX
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "تعلم كيفية توقيع ملفات PowerPoint و OpenDocument رقميًا باستخدام Aspose.Slides لجافا. احم ملفات الشرائح الخاصة بك في ثوانٍ مع أمثلة شفرة واضحة."
---

**الشهادة الرقمية** تُستخدم لإنشاء عرض تقديمي PowerPoint محمي بكلمة مرور، مع علامة تم إنشاؤه من قِبل منظمة أو شخص معين. يمكن الحصول على الشهادة الرقمية عن طريق التواصل مع منظمة مُصرّح بها - هيئة إصدار الشهادات. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض عبر File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

قد يحتوي العرض على أكثر من توقيع رقمي. بعد إضافة التوقيع الرقمي إلى العرض، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

لتوقيع العرض أو التحقق من صحة توقيعات العرض، **Aspose.Slides API** توفر [**IDigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignature) interface، [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignatureCollection) interface و[**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getDigitalSignatures--) method. حاليًا، يتم دعم التوقيعات الرقمية لتنسيق PPTX فقط.

## **إضافة توقيع رقمي من شهادة PFX**
يعرض مثال الشيفرة أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. افتح ملف PFX ومرّر كلمة مرور PFX إلى كائن [**DigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/DigitalSignature) .
1. أضف التوقيع المُنشأ إلى كائن العرض.
```java
// فتح ملف العرض التقديمي
Presentation pres = new Presentation();
try {
    // إنشاء كائن DigitalSignature باستخدام ملف PFX وكلمة مرور PFX
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // تعليق توقيع رقمي جديد
    signature.setComments("Aspose.Slides digital signing test.");

    // إضافة توقيع رقمي إلى العرض
    pres.getDigitalSignatures().add(signature);

    // حفظ العرض التقديمي
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


الآن يمكن التحقق ما إذا كان العرض موقَّعًا رقميًا ولم يتم تعديله:
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


## **FAQ**

**هل يمكنني إزالة التوقيعات الموجودة من ملف؟**

نعم. تدعم مجموعة التوقيعات الرقمية [إزالة العناصر الفردية](https://reference.aspose.com/slides/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) و[مسحها بالكامل](https://reference.aspose.com/slides/java/com.aspose.slides/digitalsignaturecollection/#clear--)؛ بعد حفظ الملف، لن يحتوي العرض على أي توقيعات.

**هل يصبح الملف "للقراءة فقط" بعد التوقيع؟**

لا. يحافظ التوقيع على النزاهة والملكية لكنه لا يمنع التعديلات. لتقييد التحرير، اجمعه مع ["Read-only" أو كلمة مرور](/slides/ar/java/password-protected-presentation/).

**هل سيظهر التوقيع بشكل صحيح في إصدارات PowerPoint المختلفة؟**

يُنشأ التوقيع لحاوية OOXML (PPTX). الإصدارات الحديثة من PowerPoint التي تدعم توقيعات OOXML تُظهر حالة هذه التوقيعات بشكل صحيح.