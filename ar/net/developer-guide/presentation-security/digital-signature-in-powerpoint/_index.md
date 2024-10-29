---
title: التوقيع الرقمي في PowerPoint
type: docs
weight: 10
url: /ar/net/digital-signature-in-powerpoint/
keywords: "شهادة التوقيع الرقمي، جهة إصدار الشهادات، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "إضافة توقيع أو شهادة رقمية في PowerPoint. جهة إصدار الشهادات في C# أو .NET"
---


**الشهادة الرقمية** تُستخدم لإنشاء عرض PowerPoint محمي بكلمة مرور، مُعلمة كإنشاء من قبل منظمة أو شخص معين. يمكن الحصول على الشهادة الرقمية عن طريق الاتصال بمنظمة مرخصة - وهي جهة إصدار الشهادات. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض عبر ملف -> معلومات -> حماية العرض:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)


يمكن أن يحتوي العرض على أكثر من توقيع رقمي واحد. بعد إضافة التوقيع الرقمي إلى العرض، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)


لتوقيع العرض أو التحقق من صحة توقيعاته، يوفر **Aspose.Slides API** واجهة [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature) وواجهة [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection) و[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures) خاصية. حالياً، يتم دعم التوقيعات الرقمية لصيغة PPTX فقط.
## **إضافة توقيع رقمي من شهادة PFX**
توضح عينة الكود أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. افتح ملف PFX ومرر كلمة مرور PFX إلى [**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature) كائن.
1. أضف التوقيع الذي تم إنشاؤه إلى كائن العرض.

```c#
using (Presentation pres = new Presentation())
{
    // إنشاء كائن DigitalSignature مع ملف PFX وكلمة مرور PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // تعليق توقيع رقمي جديد
    signature.Comments = "اختبار التوقيع الرقمي في Aspose.Slides.";

    // إضافة التوقيع الرقمي إلى العرض
    pres.DigitalSignatures.Add(signature);

    // حفظ العرض
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```


الآن أصبح من الممكن التحقق مما إذا كان العرض قد تم توقيعه رقمياً ولم يتم تعديله:


```c#
// فتح العرض
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("التوقيعات المستخدمة لتوقيع العرض: ");

        // تحقق مما إذا كانت جميع التوقيعات الرقمية صالحة
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "صالح" : "غير صالح"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("العرض أصلي، جميع التوقيعات صالحة.");
        else
            Console.WriteLine("تم تعديل العرض منذ التوقيع.");
    }
}
```