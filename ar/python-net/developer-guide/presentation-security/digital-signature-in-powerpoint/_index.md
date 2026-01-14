---
title: إضافة توقيعات رقمية إلى العروض التقديمية باستخدام بايثون
linktitle: توقيع رقمي
type: docs
weight: 10
url: /ar/python-net/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- سلطة شهادات
- شهادة PFX
- PowerPoint
- OpenDocument
- عرض تقديمي
- بايثون
- Aspose.Slides
description: "تعلم كيفية توقيع ملفات PowerPoint و OpenDocument رقميًا باستخدام Aspose.Slides للبايثون عبر .NET. احمِ شرائحك في ثوانٍ مع أمثلة شفرة واضحة."
---

**شهادة رقمية** تُستخدم لإنشاء عرض تقديمي لبرنامج PowerPoint محمي بكلمة مرور، يُشار إليه بأنه تم إنشاؤه بواسطة منظمة أو شخص معين. يمكن الحصول على الشهادة الرقمية عن طريق التواصل مع منظمة مُرخّصة - سلطة شهادات. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض التقديمي عبر File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

قد يحتوي العرض التقديمي على أكثر من توقيع رقمي. بعد إضافة التوقيع الرقمي إلى العرض التقديمي، سيظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

لتوقيع العرض التقديمي أو التحقق من صحة توقيعات العرض، يوفر **Aspose.Slides API** الفئة **[DigitalSignature](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/)**، والفئة **[DigitalSignatureCollection](https://reference.aspose.com/slides/python-net/aspose.slides/DigitalSignatureCollection/)**، والخاصية **[Presentation.digital_signatures](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/digital_signatures/)**. حاليًا، يتم دعم التوقيعات الرقمية لصيغة PPTX فقط.

## **إضافة توقيع رقمي من شهادة PFX**
يعرض المثال البرمجي أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. افتح ملف PFX ومرّر كلمة مرور PFX إلى كائن **DigitalSignature**.
2. أضف التوقيع المُنشأ إلى كائن العرض التقديمي.
```py

#[TODO:Exception] RuntimeError: Proxy error(FileNotFoundException): تعذّر تحميل الملف أو التجميع 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. الملف غير موجود.

import aspose.slides as slides

with slides.Presentation() as pres:
    # إنشاء كائن DigitalSignature باستخدام ملف PFX وكلمة مرور PFX
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # كتابة تعليق للتوقيع الرقمي الجديد
    signature.comments = "Aspose.Slides digital signing test."

    # إضافة التوقيع الرقمي إلى العرض التقديمي
    pres.digital_signatures.add(signature)

    # حفظ العرض التقديمي
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```


الآن يمكن التحقق مما إذا كان العرض التقديمي موقّعًا رقمياً ولم يتم تعديلّه:
```py
# فتح العرض التقديمي
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # التحقق من صحة جميع التواقيع الرقمية
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```


## **الأسئلة الشائعة**

**هل يمكنني إزالة التواقيع الحالية من ملف؟**

نعم. تدعم مجموعة التواقيع الرقمية [removing individual items](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/) و[clearing it entirely](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/); بعد حفظ الملف، لن يحتوي العرض التقديمي على أي توقيعات.

**هل يصبح الملف "قراءة فقط" بعد التوقيع؟**

لا. يحافظ التوقيع على النزاهة والملكية لكنه لا يمنع التعديلات. لتقييد التحرير، اجمعه مع ["Read-only" or a password](/slides/ar/python-net/password-protected-presentation/).

**هل سيظهر التوقيع بصورة صحيحة في إصدارات PowerPoint المختلفة؟**

يُنشأ التوقيع لحاوية OOXML (PPTX). تُظهر إصدارات PowerPoint الحديثة التي تدعم توقيعات OOXML حالة هذه التواقيع بشكل صحيح.