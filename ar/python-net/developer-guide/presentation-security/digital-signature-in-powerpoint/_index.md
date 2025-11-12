---
title: إضافة توقيعات رقمية إلى العروض التقديمية باستخدام Python
linktitle: توقيع رقمي
type: docs
weight: 10
url: /ar/python-net/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- سلطة شهادة
- شهادة PFX
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية توقيع ملفات PowerPoint وOpenDocument رقميًا باستخدام Aspose.Slides للغة Python عبر .NET. احمِ شرائحك في ثوانٍ مع أمثلة كود واضحة."
---

**شهادة رقمية** تُستخدم لإنشاء عرض تقديمي محمي بكلمة مرور، يُظهر أنه تم إنشاؤه من قِبل مؤسسة أو شخص معين. يمكن الحصول على شهادة رقمية عن طريق التواصل مع منظمة موثوقة - سلطة شهادة. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض عبر ملف -> معلومات -> حماية العرض:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

قد يحتوي العرض على أكثر من توقيع رقمي واحد. بعد إضافة التوقيع الرقمي إلى العرض، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

للتوقيع على العرض أو التحقق من صحة توقيعات العرض، توفر **واجهة برمجة تطبيقات Aspose.Slides** [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/) و[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/) و[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) الخاصية. حالياً، تُدعم التوقيعات الرقمية فقط لتنسيق PPTX.

## **إضافة توقيع رقمي من شهادة PFX**
يوضح عينة الكود أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. افتح ملف PFX ومرّر كلمة مرور PFX إلى كائن [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/).
2. أضف التوقيع الذي تم إنشاؤه إلى كائن العرض.

```py
#[TODO:Exception] RuntimeError: خطأ الوكيل (FileNotFoundException): تعذر تحميل الملف أو التجميع 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. الملف غير موجود.

import aspose.slides as slides

with slides.Presentation() as pres:
    # إنشاء كائن DigitalSignature باستخدام ملف PFX وكلمة المرور الخاصة به 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # التعليق على التوقيع الرقمي الجديد
    signature.comments = "Aspose.Slides digital signing test."

    # إضافة التوقيع الرقمي إلى العرض التقديمي
    pres.digital_signatures.add(signature)

    # حفظ العرض التقديمي
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

الآن يمكن التحقق مما إذا كان العرض قد تم توقيعه رقميًا ولم يتم تعديله:

```py
# فتح العرض التقديمي
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # التحقق مما إذا كانت جميع التوقيعات الرقمية صالحة
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **الأسئلة المتكررة**

**هل يمكنني إزالة التوقيعات الموجودة من ملف؟**

نعم. تدعم مجموعة التوقيعات الرقمية [إزالة العناصر الفردية](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/) و[مسحها بالكامل](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/); بعد حفظ الملف، لن يحتوي العرض على أي توقيعات.

**هل يصبح الملف "للقراءة فقط" بعد التوقيع؟**

لا. يحافظ التوقيع على النزاهة والملكية لكنه لا يمنع التعديلات. لتقييد التحرير، يمكن دمجه مع ["للقراءة فقط" أو كلمة مرور](/slides/ar/python-net/password-protected-presentation/).

**هل سيظهر التوقيع بشكل صحيح في إصدارات PowerPoint المختلفة؟**

تم إنشاء التوقيع لحاوية OOXML (PPTX). الإصدارات الحديثة من PowerPoint التي تدعم توقيعات OOXML تعرض حالة هذه التوقيعات بشكل صحيح.