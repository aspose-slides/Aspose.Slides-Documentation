---
title: إضافة توقيعات رقمية إلى العروض التقديمية في بايثون
linktitle: توقيع رقمي
type: docs
weight: 10
url: /ar/python-net/digital-signature-in-powerpoint/
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
description: "تعلم كيفية توقيع عروض PPTX الموجودة باستخدام شهادات PFX واستخدام Aspose.Slides للبايثون عبر .NET للتحقق من التوقيعات الرقمية أو إزالتها."
---
## **نظرة عامّة**

يُساعد التوقيع الرقمي المتلقي على تحديد من وقع العرض وما إذا كان المحتوى الموقع قد تغير. هناك ثلاثة مفاهيم أمنية ذات صلة مهمة هنا:

- **الشهادة الرقمية** هي اعتماد إلكتروني يربط هوية بمفتاح عام. يمكن لسلطة شهادات موثوقة (CA) إصدار شهادة، أو يمكن للمؤسسة استخدام شهادة موقّعة ذاتياً للعمليات الداخلية.
- **التوقيع الرقمي** يُنشأ من محتوى العرض والمفتاح الخاص لحامل الشهادة. يمكن بعد ذلك استخدام المفتاح العام للشهادة للتحقق من التوقيع. يُقدّم التوقيع دليلًا على الأصل والintegrity؛ ولا يقوم بتشفير العرض.
- **حماية كلمة المرور** تتحكم في ما إذا كان المستخدم يستطيع فتح أو تعديل العرض. وهي منفصلة عن التوقيع الرقمي وتُوصف في [Password-Protected Presentations](/python-net/password-protected-presentation/).

توفر PowerPoint الأمر **Add a Digital Signature** ضمن **File > Info > Protect Presentation**.

![قائمة حماية العرض في PowerPoint مع تمييز إضافة توقيع رقمي](add-digital-signature-in-powerpoint.png)

بعد فتح عرض موقع، يمكن لـ PowerPoint عرض إشعار بحالة التوقيع.

![إشعار PowerPoint يوضح أن العرض يحتوي على توقيعات صالحة](digital-signature-status-in-powerpoint.png)

Aspose.Slides يوفّر التوقيعات عبر [Presentation.digital_signatures](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/digital_signatures/)، وهو [DigitalSignatureCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignaturecollection/) يحتوي على كائنات [DigitalSignature](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignature/). يمكن للعرض أن يحتوي على عدة توقيعات.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا بملف PKCS#12 وغالبًا ما يُعطى امتدادًا `.pfx` أو `.p12`، يمكن أن يحتوي على شهادة X.509 ومفتاحها الخاص وسلسلة الشهادات. المفتاح الخاص هو ما يسمح للحامل بإنشاء توقيع. لا يمكن استخدام شهادة بدون مفتاح خاص متاح لتوقيع العرض.

كلمة مرور PFX تحمي حزمة الشهادة والمفتاح الخاص. هي **ليست** كلمة مرور لفتح أو تحرير العرض. لا تقم بارتكاب ملفات PFX أو كلمات مرورها إلى نظام التحكم في الإصدارات. في بيئة الإنتاج، حدّ الوصول إلى ملف الشهادة واحصل على كلمة المرور من مخزن أسرار أو مصدر تكوين محمي آخر. الأمثلة أدناه تستخدم متغيّر بيئي فقط لتجنب تضمين كلمة المرور في الشيفرة.

## **إضافة توقيع رقمي إلى عرض**

لتوقيع سير عمل عرض حقيقي، قم بتحميل ملف PPTX موجود، أنشئ [DigitalSignature](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة التوقيعات في العرض، واحفظه كملف PPTX.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

حفظ النتيجة باسم جديد يحافظ على ملف المصدر غير الموقع. قيمة [DigitalSignature.comments](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignature/comments/) تصف هدف التوقيع؛ ولا تُعدّ تحكمًا أمنيًا.

## **تحقق من صحة التوقيعات الرقمية**

عند تحميل ملف PPTX موقع، افحص كل عنصر في [Presentation.digital_signatures](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/digital_signatures/). خاصية [DigitalSignature.is_valid](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignature/is_valid/) تشير إلى ما إذا كان التوقيع المضمن صالحًا لمحتوى العرض الحالي.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

نتيجة غير صالحة غالبًا ما تعني أن محتوى العرض الموقع أو بيانات التوقيع قد تغيرت بعد التوقيع، أو أن الملف تالف. إزالة كل توقيع ينتج عرضًا غير موقع، لذا فحص صلاحية العناصر فقط لا يكفي: يجب على سير عمل حساس للأمان أيضًا التحقق من العدد المتوقع للتوقيعات والهويات المتوقّعة للموقّعين.

خاصية [DigitalSignature.certificate](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignature/certificate/) تُعيد بيانات الشهادة كمصفوفة بايت. يحسب المثال بصمة SHA-256 لها حتى يتمكن التطبيق من مقارنتها بصمة شهادة موقّع متوقّع.

هذه النتيجة لا ينبغي أن تُعامل كقرار نهائي بشأن ثقة الشهادة. بناءً على سياسة الأمان لديك، قد يحتاج تطبيقك أيضًا إلى بناء والتحقق من سلسلة شهادة X.509، فحص تواريخ صلاحية الشهادة وحالة الإلغاء، التأكد من الموضوع أو البصمة المتوقّعة، التحقق من استخدام المفتاح، وتقييم طابع زمني موثوق. قيمة [DigitalSignature.sign_time](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignature/sign_time/) بحد ذاتها ليست دليلًا من سلطة طوابع زمنية موثوقة.

## **إزالة التوقيعات الرقمية**

إزالة التوقيعات تغير حالة أمان العرض. المثال التالي يحمل ملف PPTX موقع، يزيل جميع التوقيعات باستخدام [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignaturecollection/clear/)، ويحفظ نسخة غير موقّعة.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

لإزالة توقيع واحد فقط، استدعِ [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignaturecollection/remove_at/) مع فهرسه الصفري. احفظه في ملف جديد ما لم يكن الكتابة فوق الأصل الموقع جزءًا صريحًا من سير عملك.

## **التحرير واعتبارات التنسيق**

- لا يجعل التوقيع العرض للقراءة فقط. لا يزال بإمكان المستخدمين والتطبيقات تحرير الملف، لكن أي تغيير في المحتوى الموقع عادةً ما يُبطِل التوقيع القائم.
- أكمل جميع التعديلات المقصودة قبل التوقيع. إذا كان لابد من تعديل العرض، احفظ النسخة المعدلة ووقعها مرة أخرى.
- احتفظ بالإخراج النهائي بصيغة PPTX. تحويل عرض موقع إلى صيغة أخرى لا ينقل التوقيع الأصلي ك توقيع صالح للملف المحوّل.
- اعتبر المفتاح الخاص بالشهادة حساسًا. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يتمكن من إنشاء توقيعات تبدو كأنها صادرة من حامل الشهادة.
- احفظ المصدر غير الموقع أو نسخة أخرى خاضعة للسيطرة عندما تتطلب سياسة احتفاظ المستندات ذلك.

## **الأسئلة المتكررة**

**هل التوقيع الرقمي يشفر العرض؟**

لا. التوقيع الرقمي يوفر دليلًا على الأصل والintegrity، لكن محتوى العرض يظل قابلاً للقراءة ما لم يتم تطبيق تشفير منفصل. استخدم [password protection](/python-net/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفسها كلمة مرور العرض؟**

لا. كلمة مرور PFX تفتح المفتاح الخاص المخزن في حزمة الشهادة. لا تتحكم في من يمكنه فتح أو تحرير ملف PPTX.

**هل يمكنني استخدام شهادة موقّعة ذاتيًا؟**

تقنيًا، يمكن استخدام شهادة موقّعة ذاتيًا إذا احتوت على مفتاح خاص متاح. إلا أن المستلمين لن يثقوا بها تلقائيًا إلا إذا أضيفت الشهادة صراحةً إلى بيئتهم الموثوقة. غالبًا ما تُستخدم الشهادات الصادرة عن سلطة شهادات موثوقة في سير عمل عام أو عابر للمؤسسات.

**ما الذي يجعل توقيعًا غير صالح؟**

تغيير محتوى العرض الموقع أو بيانات التوقيع بعد التوقيع يمكن أن يبطل التوقيع. كذلك قد تتسبب فساد الملفات في فشل التحقق. إذا أزيلت جميع التوقيعات، يصبح العرض غير موقع وليس مجرد ملف يحتوي على توقيع غير صالح.

**هل يعني وجود توقيع صالح أنني يجب أن أثق بالموقّع؟**

ليس بمفرده. سلامة التوقيع وثقة الموقّع قرارات منفصلة. يجب على سياسة التحقق في الإنتاج أيضًا فحص سلسلة الشهادة، فترة الصلاحية، حالة الإلغاء، الهوية المتوقّعة، استخدام المفتاح، وأي متطلبات طابع زمني موثوق.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض، لكنه يؤثر على تقييم ثقة الشهادة. ما إذا كان التوقيع يظل مقبولًا يعتمد على سياستك وما إذا كان طابع زمنى موثوق يثبت أن التوقيع تم بينما كانت الشهادة صالحة. لا تعتمد على وقت التوقيع المعروض وحده كطابع زمني موثوق.

**هل يمكن تعديل عرض موقع؟**

نعم. التوقيع لا يقفل الملف. تعديل المحتوى الموقع عادةً ما يبطل التوقيع الحالي، لذا أكمل العرض أولًا ووقع النسخة النهائية.

**هل يمكن للعرض أن يحتوي على أكثر من توقيع؟**

نعم. أضف كل توقيع إلى [Presentation.digital_signatures](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/digital_signatures/) قبل الحفظ. أثناء التحقق، افحص كل توقيع وتأكد من وجود جميع الموقّعين المطلوبين.

**ما صيغ العروض التي تدعم هذه العمليات؟**

Aspose.Slides يدعم عمليات التوقيع الرقمي المذكورة هنا فقط لملفات PPTX. صيغ PPT وOpenDocument للعرض غير مدعومة من قبل هذا الـ API.

**هل يمكن إزالة توقيع دون التأثير على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو مسح المجموعة بالكامل ثم حفظ العرض. يبقى محتوى الشرائح متاحًا، لكن الملف المحفوظ لن يحمل دليل التوقيع المُزال.