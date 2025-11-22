---
title: التوقيع الرقمي في PowerPoint
type: docs
weight: 10
url: /ar/net/digital-signature-in-powerpoint/
keywords: "شهادة التوقيع الرقمي, سلطة الشهادات, عرض تقديمي PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "إضافة توقيع رقمي أو شهادة في PowerPoint. سلطة الشهادات في C# أو .NET"
---

**شهادة رقمية** تُستخدم لإنشاء عرض تقديمي powerpoint محمي بكلمة مرور، معلمة على أنه تم إنشاؤه من قبل منظمة أو شخص معين. يمكن الحصول على الشهادة الرقمية عن طريق الاتصال بمنظمة معتمدة - سلطة شهادات. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض التقديمي عبر File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

قد يحتوي العرض التقديمي على أكثر من توقيع رقمي. بعد إضافة التوقيع الرقمي إلى العرض التقديمي، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

لتوقيع العرض التقديمي أو التحقق من أصالة توقيعات العرض التقديمي، توفر **Aspose.Slides API** [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature) الواجهة، [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection) الواجهة و[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures) الخاصية. حالياً، يتم دعم التوقيعات الرقمية لتنسيق PPTX فقط.
## **إضافة توقيع رقمي من شهادة PFX**
يوضح عينة الشيفرة أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. افتح ملف PFX ومرّر كلمة مرور PFX إلى كائن [**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature).
1. أضف التوقيع المُنشأ إلى كائن العرض التقديمي.
```c#
using (Presentation pres = new Presentation())
{
    // إنشاء كائن DigitalSignature باستخدام ملف PFX وكلمة مرور PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // التعليق على توقيع رقمي جديد
    signature.Comments = "Aspose.Slides digital signing test.";

    // إضافة توقيع رقمي إلى العرض التقديمي
    pres.DigitalSignatures.Add(signature);

    // حفظ العرض التقديمي
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```


الآن يمكن التحقق مما إذا كان العرض التقديمي موقّعاً رقمياً ولم يتم تعديلّه:
```c#
// فتح العرض التقديمي
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // تحقق مما إذا كانت جميع التوقيعات الرقمية صالحة
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


## **الأسئلة الشائعة**

**هل يمكنني إزالة التوقيعات الموجودة من ملف؟**

نعم. تدعم مجموعة التوقيعات الرقمية [إزالة العناصر الفردية](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/removeat/) و[مسحها بالكامل](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/clear/); بعد حفظ الملف، لن يحتوي العرض التقديمي على أي توقيعات.

**هل يصبح الملف "للقراءة فقط" بعد التوقيع؟**

لا. يحافظ التوقيع على النزاهة والملكية ولكنه لا يمنع التعديلات. لتقييد التحرير، اجمعه مع ["Read-only" أو كلمة مرور](/slides/ar/net/password-protected-presentation/).

**هل سيظهر التوقيع بشكل صحيح في إصدارات مختلفة من PowerPoint؟**

تم إنشاء التوقيع لحاوية OOXML (PPTX). تعرض إصدارات PowerPoint الحديثة التي تدعم توقيعات OOXML حالة هذه التوقيعات بشكل صحيح.