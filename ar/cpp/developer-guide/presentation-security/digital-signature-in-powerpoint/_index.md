---
title: إضافة توقيعات رقمية إلى العروض التقديمية في C++
linktitle: الت توقيع الرقمي
type: docs
weight: 10
url: /ar/cpp/digital-signature-in-powerpoint/
keywords:
- التوقيع الرقمي
- الشهادة الرقمية
- جهة إصدار الشهادات
- شهادة PFX
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية توقيع ملفات PowerPoint وOpenDocument رقمياً باستخدام Aspose.Slides لـ C++. احمِ شرائحك في ثوانٍ مع أمثلة شفرة واضحة."
---

**الشهادة الرقمية** تُستخدم لإنشاء عرض تقديمي PowerPoint محمي بكلمة مرور، يتم وضع علامة بأنه تم إنشاؤه بواسطة مؤسسة أو شخص معين. يمكن الحصول على الشهادة الرقمية عن طريق التواصل مع منظمة معتمدة - هيئة إصدار الشهادات. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض التقديمي عبر ملف -> معلومات -> حماية العرض التقديمي:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

العرض التقديمي قد يحتوي على أكثر من توقيع رقمي. بعد إضافة التوقيع الرقمي إلى العرض، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

لتوقيع العرض التقديمي أو التحقق من صحة توقيعاته، توفر **Aspose.Slides API** واجهة [**IDigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature) وواجهة [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection) و[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) كطريقة. حاليًا، تُدعم التوقيعات الرقمية لتنسيق PPTX فقط.
## **إضافة توقيع رقمي من شهادة PFX**
العينة البرمجية أدناه توضح كيفية إضافة توقيع رقمي من شهادة PFX:

1. افتح ملف PFX ومرّر كلمة مرور PFX إلى كائن [**DigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature).
2. أضف التوقيع المُنشأ إلى كائن العرض التقديمي.
``` cpp
auto pres = System::MakeObject<Presentation>();

// إنشاء كائن DigitalSignature بملف PFX وكلمة مرور PFX 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// إضافة تعليق إلى توقيع رقمي جديد
signature->set_Comments(u"Aspose.Slides digital signing test.");

// إضافة توقيع رقمي إلى العرض التقديمي
pres->get_DigitalSignatures()->Add(signature);

// Save presentation
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```


الآن يمكن التحقق مما إذا كان العرض التقديمي مُوقعًا رقميًا ولم يتم تعديله:
``` cpp
// فتح العرض التقديمي
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // تحقق مما إذا كانت جميع التواقيع الرقمية صالحة
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```


## **الأسئلة المتكررة**

**هل يمكنني إزالة التواقيع الموجودة من ملف؟**

نعم. تدعم مجموعة التواقيع الرقمية [إزالة العناصر الفردية](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/removeat/) و[مسحها بالكامل](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/clear/); بعد حفظ الملف، لن يحتوي العرض التقديمي على أي تواقيع.

**هل يصبح الملف "للقراءة فقط" بعد التوقيع؟**

لا. يحفظ التوقيع التكامل والملكية لكنه لا يمنع التعديلات. لتقييد التحرير، اجمعه مع ["Read-only" أو كلمة مرور](/slides/ar/cpp/password-protected-presentation/).

**هل سيظهر التوقيع بشكل صحيح في إصدارات PowerPoint المختلفة؟**

تم إنشاء التوقيع لحاوية OOXML (PPTX). تعرض إصدارات PowerPoint الحديثة التي تدعم توقيعات OOXML حالة هذه التواقيع بشكل صحيح.