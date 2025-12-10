---
title: إضافة توقيعات رقمية إلى العروض التقديمية في .NET
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/net/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- سلطة شهادات
- شهادة PFX
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرف على كيفية توقيع ملفات PowerPoint وOpenDocument رقميًا باستخدام Aspose.Slides لـ .NET. احمِ شرائحك في ثوانٍ مع أمثلة شفرة واضحة."
---

**شهادة رقمية** تُستخدم لإنشاء عرض تقديمي PowerPoint محمي بكلمة مرور، مع توضيح أنه تم إنشاؤه بواسطة منظمة أو شخص معين. يمكن الحصول على الشهادة الرقمية بالتواصل مع منظمة معتمدة – سلطة شهادات. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض عبر ملف -> معلومات -> حماية العرض:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

قد يحتوي العرض على أكثر من توقيع رقمي. بعد إضافة التوقيع الرقمي إلى العرض، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

لتوقيع العرض أو التحقق من صحة توقيعات العرض، توفر **Aspose.Slides API** الواجهة [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature) والواجهة [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection) والخاصية [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures). حاليًا، يتم دعم التوقيعات الرقمية لتنسيق PPTX فقط.

## **إضافة توقيع رقمي من شهادة PFX**
يُظهر نموذج الشيفرة أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. فتح ملف PFX وتمرير كلمة مرور PFX إلى كائن [**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature).
2. إضافة التوقيع الذي تم إنشاؤه إلى كائن العرض التقديمي.
```c#
using (Presentation pres = new Presentation())
{
    // إنشاء كائن DigitalSignature باستخدام ملف PFX وكلمة مرور PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // إضافة تعليق إلى التوقيع الرقمي الجديد
    signature.Comments = "Aspose.Slides digital signing test.";

    // إضافة توقيع رقمي إلى العرض التقديمي
    pres.DigitalSignatures.Add(signature);

    // حفظ العرض التقديمي
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```


الآن يمكن التحقق مما إذا كان العرض مُوقعًا رقمياً ولم يتم تعديله:
```c#
// فتح العرض التقديمي
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // التحقق مما إذا كانت جميع التواقيع الرقمية صالحة
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```


## **الأسئلة المتكررة**

**هل يمكنني إزالة التوقيعات الموجودة من ملف؟**

نعم. تدعم مجموعة التوقيعات الرقمية [إزالة العناصر الفردية](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/removeat/) و[مسحها بالكامل](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/clear/); بعد حفظ الملف، لن يحتوي العرض على أي توقيعات.

**هل يصبح الملف "للقراءة فقط" بعد التوقيع؟**

لا. يحافظ التوقيع على النزاهة والملكية ولكنه لا يمنع التعديلات. لتقييد التحرير، يمكن دمجه مع ["Read-only" أو كلمة مرور](/slides/ar/net/password-protected-presentation/).

**هل سيظهر التوقيع بشكل صحيح في إصدارات PowerPoint المختلفة؟**

يتم إنشاء التوقيع لحاوية OOXML (PPTX). الإصدارات الحديثة من PowerPoint التي تدعم توقيعات OOXML تعرض حالة هذه التوقيعات بشكل صحيح.