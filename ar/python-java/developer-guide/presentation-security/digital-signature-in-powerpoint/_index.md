---
title: إضافة توقيعات رقمية إلى العروض التقديمية في بايثون
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/python-java/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- سلطة شهادات
- شهادة PFX
- PKCS#12
- التحقق من التوقيع
- PowerPoint
- PPTX
- أمان العرض التقديمي
- Python
- Aspose.Slides
description: "تعلم كيف تُوقّع عروض PPTX الحالية باستخدام شهادات PFX واستخدام Aspose.Slides لبايثون عبر جافا للتحقق من التوقيعات الرقمية أو إزالتها."
---
## **نظرة عامة**

تساعد التوقيع الرقمي المستلم على تحديد من وقع العرض التقديمي وما إذا كان المحتوى الموقع قد تغير. هناك ثلاثة مفاهيم أمنية ذات صلة مهمة هنا:

- **شهادة رقمية** هي اعتماد إلكتروني يربط هوية بمفتاح عام. يمكن لسلطة شهادات موثوقة (CA) إصدار شهادة، أو يمكن للمؤسسة استخدام شهادة موقعة ذاتيًا لتدفقات العمل الداخلية.
- **توقيع رقمي** يُنشأ من محتوى العرض التقديمي ومفتاح خاص لحامل الشهادة. يمكن بعد ذلك استخدام المفتاح العام للشهادة للتحقق من التوقيع. يوفر الت签يع دليلًا على الأصل والنزاهة؛ ولا يقوم بتشفير العرض التقديمي.
- **حماية كلمة المرور** تتحكم فيما إذا كان يمكن للمستخدم فتح أو تعديل العرض التقديمي. وهي منفصلة عن التوقيع الرقمي ومُوضحّة في [Password-Protected Presentations](/slides/ar/python-java/password-protected-presentation/).

يقدم PowerPoint الأمر **Add a Digital Signature** ضمن **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

بعد فتح عرض تقديمي موقع، يمكن لـ PowerPoint عرض إشعار بحالة التوقيع.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

يسـمح Aspose.Slides بالوصول إلى التوقيعات عبر [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getDigitalSignatures)، التي تُعيد [DigitalSignatureCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/digitalsignaturecollection/) حيث أن عناصره هي كائنات من نوع [DigitalSignature](https://reference.aspose.com/slides/ar/python-java/aspose.slides/digitalsignature/). يمكن للعرض التقديمي أن يحتوي على عدة توقيعات.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا بملف PKCS#12 وعادةً ما يُعطى امتدادًا `.pfx` أو `.p12`، يمكنه أن يحتوي على شهادة X.509، ومفتاحها الخاص، وسلسلة الشهادة. المفتاح الخاص هو ما يسمح للحامل بإنشاء توقيع. لا يمكن استخدام شهادة بدون مفتاح خاص قابل للوصول لتوقيع عرض تقديمي.

كلمة مرور PFX تحمي حزمة الشهادة والمفتاح الخاص. هي **ليس** كلمة مرور لفتح أو تعديل العرض التقديمي. لا تقم بدمج ملفات PFX أو كلمات مرورها في نظام التحكم بالمصادر. في بيئة الإنتاج، قصر الوصول إلى ملف الشهادة واحصل على كلمة المرور من مخزن سري أو مصدر تكوين محمي آخر. الأمثلة أدناه تستخدم متغير بيئة فقط لتجنب تضمين كلمة المرور في الكود.

## **إضافة توقيع رقمي إلى العرض التقديمي**

لتوقيع سير عمل عرض تقديمي حقيقي، قم بتحميل ملف PPTX موجود، أنشئ [DigitalSignature](https://reference.aspose.com/slides/ar/python-java/aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة التوقيعات في العرض التقديمي، واحفظه كملف PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

حفظ النتيجة باسم جديد يحافظ على ملف المصدر غير الموقع. القيمة التي يتم تعيينها بواسطة [DigitalSignature.setComments](https://reference.aspose.com/slides/ar/python-java/aspose.slides/digitalsignature/#setComments) تصف غرض التوقيع؛ وهي ليست آلية أمان.

## **تحقق من التواقيع الرقمية**

عند تحميل ملف PPTX موقع، افحص كل عنصر تُعيده [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getDigitalSignatures). طريقة [DigitalSignature.isValid](https://reference.aspose.com/slides/ar/python-java/aspose.slides/digitalsignature/#isValid) تُظهر ما إذا كان التوقيع المضمّن صالحًا لمحتوى العرض التقديمي الحالي.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

النتيجة غير الصالحة عادةً تعني أن محتوى العرض الموقع أو بيانات التوقيع تغيرت بعد التوقيع، أو أن الملف تالف. إزالة كل توقيع ينتج عرضًا تقديميًا غير موقع، لذا فحص صلاحية العناصر فقط غير كافٍ: يجب على سير عمل حساس للأمان أيضًا التحقق من عدد التواقيع المتوقعة وهويات الموقعين المتوقعة.

لا ينبغي اعتبار نتيجة الصلاحية هذه قرارًا نهائيًا بشأن الثقة في الشهادة. بناءً على سياسة الأمان الخاصة بك، قد يحتاج التطبيق أيضًا إلى بناء والتحقق من سلسلة شهادات X.509، فحص تواريخ صلاحية الشهادة وحالة إلغائها، تأكيد الموضوع أو البصمة المتوقعة، التحقق من استخدام المفتاح، وتقييم طابع زمني موثوق. القيمة التي تُرجعها [DigitalSignature.getSignTime](https://reference.aspose.com/slides/ar/python-java/aspose.slides/digitalsignature/#getSignTime) بذاتها ليست دليلًا من سلطة طابع زمني موثوقة.

## **إزالة التواقيع الرقمية**

إزالة التواقيع تغير حالة أمان العرض التقديمي. المثال التالي يحمل ملف PPTX موقع، يزيل كل التواقيع باستخدام [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/digitalsignaturecollection/#clear)، ويحفظ نسخة غير موقعة.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

لإزالة توقيع واحد فقط، استدعِ [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/digitalsignaturecollection/#removeAt) مع فهرسه المؤسس من الصفر. احفظ إلى ملف جديد ما لم يكن استبدال الأصل الموقع جزءًا صريحًا من سير العمل.

## **اعتبارات التحرير والتنسيق**

- التوقيع لا يجعل العرض التقديمي للقراءة فقط. لا يزال بإمكان المستخدمين والتطبيقات تحرير الملف، لكن التغييرات على المحتوى الموقع عادةً ما تُلغي صلاحية التوقيع الحالي.
- أكمل جميع التعديلات المطلوبة قبل التوقيع. إذا كان يجب تغيير العرض التقديمي، احفظ العرض المعدل ووقع تلك النسخة مرة أخرى.
- حافظ على المخرجات النهائية بصيغة PPTX. تحويل عرض موقع إلى صيغة أخرى لا ينقل توقيع PPTX الأصلي كتوقيع صالح للملف المحوّل.
- عامل المفتاح الخاص بالشهادة على أنه حساس. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يتمكن من إنشاء توقيعات تظهر كأنها صادرة من حامل الشهادة.
- احتفظ بالمصدر غير الموقع أو نسخة أخرى خاضعة للضبط عندما يتطلب ذلك سياسة الاحتفاظ بالمستندات الخاصة بك.

## **الأسئلة المتكررة**

**هل التوقيع الرقمي يشفر العرض التقديمي؟**

لا. التوقيع الرقمي يقدم دليلًا حول الأصل والنزاهة، لكن محتوى العرض يبقى قابلاً للقراءة ما لم يُطبق تشفير منفصل. استخدم [password protection](/slides/ar/python-java/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفسها كلمة مرور العرض التقديمي؟**

لا. كلمة مرور PFX تفتح القفل للمفتاح الخاص المخزن في حزمة الشهادة. هي لا تتحكم في من يمكنه فتح أو تعديل ملف PPTX.

**هل يمكنني استخدام شهادة موقعة ذاتيًا؟**

من الناحية التقنية يمكن استخدام شهادة موقعة ذاتيًا عندما تتضمن مفتاحًا خاصًا يمكن الوصول إليه. إلا أن المتلقين لن يثقوا بها تلقائيًا، ما لم تُضاف تلك الشهادة صراحةً إلى بيئتهم الموثوقة. عادةً ما تستخدم سير العمل العامة أو عبر المؤسسات شهادة صادرة عن سلطة شهادات موثوقة.

**ما الذي يجعل التوقيع غير صالح؟**

تغيير محتوى العرض الموقّع أو بيانات التوقيع بعد التوقيع يمكن أن يبطل التوقيع. كما أن تلف الملف قد يسبب فشل التحقق. إذا أزيل جميع التواقيع، يصبح العرض غير موقع وليس ملفًا يحتوي على توقيع غير صالح.

**هل يعني التوقيع الصالح أني يجب أن أُوثق الموقع؟**

ليس ذلك بحد ذاته. سلامة التوقيع وثقة الموقع قرارات منفصلة. يجب أن تتحقق سياسة التحقق في الإنتاج أيضًا من سلسلة الشهادة، فترة الصلاحية، حالة الإلغاء، الهوية المتوقعة، استخدام المفتاح، وأية متطلبات لطابع زمني موثوق.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض التقديمي، لكنه يؤثر على تقييم الثقة في الشهادة. ما إذا كان التوقيع ما زال مقبولًا يعتمد على سياساتك وما إذا كان هناك طابع زمني موثوق وصالح يثبت أن التوقيع تم بينما كانت الشهادة صالحة. لا تعتمد على وقت التوقيع المعروض وحده كطابع زمني موثوق.

**هل يمكن تحرير عرض تقديمي موقع؟**

نعم. التوقيع لا يقفل الملف. عادةً ما يؤدي تحرير المحتوى الموقع إلى إبطال صلاحية التوقيع الحالي، لذا أكمل العرض أولاً ووقع النسخة النهائية.

**هل يمكن للعرض التقديمي أن يحتوي على أكثر من توقيع واحد؟**

نعم. أضف كل توقيع إلى المجموعة التي تُعيدها [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getDigitalSignatures) قبل الحفظ. أثناء التحقق، افحص كل توقيع وتأكد من وجود جميع الموقعين المطلوبين.

**ما هي صيغ العروض التقديمية التي تدعم هذه العمليات؟**

يدعم Aspose.Slides عمليات التوقيع الرقمي المذكورة هنا فقط لصيغة PPTX. صيغ PPT وOpenDocument للعرض التقديمي غير مدعومة في سير عمل هذه الواجهة البرمجية.

**هل يمكنني إزالة توقيع دون التأثير على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو مسح جميع التواقيع ثم حفظ العرض. يبقى محتوى الشرائح متاحًا، لكن الملف المحفوظ لم يعد يحمل دليل التوقيع المُزال.