---
title: التوقيع الرقمي في PowerPoint
type: docs
weight: 10
url: /ar/python-net/digital-signature-in-powerpoint/
keywords: "شهادة التوقيع الرقمي، هيئة الشهادات، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "إضافة توقيع رقمي أو شهادة في PowerPoint. هيئة الشهادات في بايثون"
---


**الشهادة الرقمية** تُستخدم لإنشاء عرض PowerPoint محمي بكلمة مرور، مُعلّم كأنه تم إنشاؤه بواسطة منظمة أو شخص معين. يمكن الحصول على الشهادة الرقمية عن طريق الاتصال بمنظمة مرخصة - هيئة الشهادات. بعد تثبيت الشهادة الرقمية في النظام، يمكن استخدامها لإضافة توقيع رقمي إلى العرض عبر ملف -> معلومات -> حماية العرض:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



يمكن أن يحتوي العرض على أكثر من توقيع رقمي واحد. بعد إضافة التوقيع الرقمي إلى العرض، ستظهر رسالة خاصة في PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



لتوقيع العرض أو التحقق من صحة توقيعات العرض، توفر **واجهة برمجة تطبيقات Aspose.Slides** [**IDigitalSignature** ](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/)و [**IDigitalSignatureCollection** ](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/)و[ **IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) خاصية. حاليًا، يتم دعم التوقيعات الرقمية لصيغة PPTX فقط.
## **إضافة توقيع رقمي من شهادة PFX**
يظهر نموذج الكود أدناه كيفية إضافة توقيع رقمي من شهادة PFX:

1. افتح ملف PFX وأدخل كلمة مرور PFX إلى [**DigitalSignature** ](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/)الكائن.
1. أضف التوقيع الذي تم إنشاؤه إلى كائن العرض.

```py

#[TODO:Exception] RuntimeError: Proxy error(FileNotFoundException): Could not load file or assembly 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. File was not found.

import aspose.slides as slides

with slides.Presentation() as pres:
    # إنشاء كائن DigitalSignature مع ملف PFX وكلمة مرور PFX 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # تعليق على التوقيع الرقمي الجديد
    signature.comments = "اختبار التوقيع الرقمي لـ Aspose.Slides."

    # إضافة التوقيع الرقمي إلى العرض
    pres.digital_signatures.add(signature)

    # حفظ العرض
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```



الآن يمكن التحقق مما إذا كان العرض قد تم توقيعه رقمياً ولم يتم تعديله:



```py
# فتح العرض
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("التوقيعات التي تمت استخدامها لتوقيع العرض: ")
        # تحقق مما إذا كانت جميع التوقيعات الرقمية صالحة
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("العرض أصلي، جميع التوقيعات صالحة.")
        else:
            print("تم تعديل العرض منذ التوقيع.")
```