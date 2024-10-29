---
title: التوقيع الرقمي في PowerPoint
type: docs
weight: 10
url: /ar/cpp/digital-signature-in-powerpoint/
keywords: "شهادة التوقيع الرقمي، هيئة الشهادات"
description: "إضافة شهادة توقيع رقمي، هيئة الشهادات إلى عرض PowerPoint التقديمي باستخدام Aspose.Slides."
---

**الشهادة الرقمية** تُستخدم لإنشاء عرض PowerPoint محمي بكلمة مرور، يُحدد بأنه تم إنشاؤه من قبل منظمة أو شخص معين. يمكن الحصول على الشهادة الرقمية من خلال الاتصال بمنظمة مرخصة - هيئة الشهادات. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض التقديمي عبر ملف -> معلومات -> حماية العرض التقديمي:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

قد يحتوي العرض التقديمي على أكثر من توقيع رقمي واحد. بعد إضافة التوقيع الرقمي إلى العرض التقديمي، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

لتوقيع العرض التقديمي أو التحقق من صحة توقيعات العرض التقديمي، يوفر **Aspose.Slides API** واجهة [**IDigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature) وواجهة [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection) وطريقة [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1). حالياً، تُدعم التوقيعات الرقمية فقط لامتداد PPTX.
## **إضافة توقيع رقمي من شهادة PFX**
توضح عينة الكود أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. افتح ملف PFX ومرر كلمة مرور PFX إلى كائن [**DigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature).
2. أضف التوقيع الذي تم إنشاؤه إلى كائن العرض التقديمي.

``` cpp
auto pres = System::MakeObject<Presentation>();

// إنشاء كائن DigitalSignature مع ملف PFX وكلمة مرور PFX 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// تعليق على التوقيع الرقمي الجديد
signature->set_Comments(u"اختبار التوقيع الرقمي لـ Aspose.Slides.");

// إضافة التوقيع الرقمي إلى العرض التقديمي
pres->get_DigitalSignatures()->Add(signature);

// حفظ العرض التقديمي
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

الآن من الممكن التحقق مما إذا كان العرض التقديمي قد تم توقيعه رقميًا ولم يتم تعديله:

``` cpp
// فتح العرض التقديمي
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"التوقيعات المستخدمة لتوقيع العرض التقديمي: ");

    // تحقق مما إذا كانت جميع التوقيعات الرقمية صالحة
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"صالح") : System::String(u"غير صالح")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"العرض التقديمي أصيل، جميع التوقيعات صالحة.");
    }
    else
    {
        Console::WriteLine(u"تم تعديل العرض التقديمي منذ التوقيع.");
    }
}
```