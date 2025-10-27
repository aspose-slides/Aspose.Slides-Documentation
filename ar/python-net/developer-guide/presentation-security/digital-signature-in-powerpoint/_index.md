---
title: إضافة توقيعات رقمية إلى العروض التقديمية باستخدام Python
linktitle: التوقيع الرقمي
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
- Python
- Aspose.Slides
description: "تعرّف على كيفية توقيع ملفات PowerPoint وOpenDocument رقمياً باستخدام Aspose.Slides للغة Python عبر .NET. احمِ شرائحك في ثوانٍ مع أمثلة شفرة واضحة."
---

**الشهادة الرقمية** تُستخدم لإنشاء عرض تقديمي ببرنامج PowerPoint محمي بكلمة مرور، مع الإشارة إلى أنه تم إنشاؤه من قِبل منظمة أو شخص معين. يمكن الحصول على الشهادة الرقمية عن طريق التواصل مع منظمة معتمدة – سلطة شهادات. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض عبر **ملف → معلومات → حماية العرض**:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

قد يحتوي العرض على أكثر من توقيع رقمي. بعد إضافة التوقيع الرقمي إلى العرض، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

لتوقيع العرض أو فحص صحة توقيعاته، توفر **Aspose.Slides API** الواجهات [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/) و[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/) والخاصية [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/). حاليًا، يتم دعم التوقيعات الرقمية لتنسيق PPTX فقط.

## **إضافة توقيع رقمي من شهادة PFX**
يوضح المثال البرمجي أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. افتح ملف PFX ومرّر كلمة مرور PFX إلى كائن [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/).
2. أضف التوقيع المُنشأ إلى كائن العرض.

```py

#[TODO:Exception] RuntimeError: Proxy error(FileNotFoundException): Could not load file or assembly 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. File was not found.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Create DigitalSignature object with PFX file and PFX password 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Comment new digital signature
    signature.comments = "Aspose.Slides digital signing test."

    # Add digital signature to presentation
    pres.digital_signatures.add(signature)

    # save presentation
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

الآن يمكن التحقق مما إذا كان العرض قد تم توقيعه رقميًا ولم يتعرض لأي تعديل:

```py
# Open presentation
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Check if all digital signatures are valid
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
لا. يحافظ التوقيع على النزاهة والمؤلفين لكنه لا يمنع التعديلات. لتقييد التحرير، اجمعه مع ["قراءة فقط" أو كلمة مرور](/slides/ar/python-net/password-protected-presentation/).

**هل سيظهر التوقيع بشكل صحيح في إصدارات PowerPoint المختلفة؟**  
يُنشأ التوقيع لحاوية OOXML (PPTX). الإصدارات الحديثة من PowerPoint التي تدعم توقيعات OOXML تعرض حالة هذه التوقيعات بشكل صحيح.