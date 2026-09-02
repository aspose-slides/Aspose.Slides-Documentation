---
title: إضافة توقيعات رقمية إلى العروض التقديمية في بايثون
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/python-net/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- سلطة شهادة
- شهادة PFX
- PKCS#12
- التحقق من التوقيع
- PowerPoint
- PPTX
- أمان العرض التقديمي
- Python
- Aspose.Slides
description: "تعلم كيفية توقيع عروض PPTX الحالية باستخدام شهادات PFX واستخدام Aspose.Slides للبايثون عبر .NET للتحقق من التوقيعات الرقمية أو إزالتها."
---
## **نظرة عامة**

يساعد التوقيع الرقمي المتلقي على تحديد من قام بتوقيع العرض التقديمي وما إذا كان المحتوى الموقع قد تغير. هناك ثلاثة مفاهيم أمنية مرتبطة مهمة هنا:

- **الشهادة الرقمية** هي بيانات اعتماد إلكترونية تربط هوية بمفتاح عام. يمكن لسلطة شهادة موثوقة (CA) إصدار شهادة، أو يمكن للمؤسسة استخدام شهادة موقعة ذاتيًا لسير العمل الداخلي.
- **التوقيع الرقمي** يُنشأ من محتوى العرض التقديمي ومفتاح الخصوصية لحامل الشهادة. يمكن بعد ذلك استخدام المفتاح العام للشهادة للتحقق من التوقيع. يوفر التوقيع دليلًا على الأصل والنزاهة؛ ولا يقوم بتشفير العرض التقديمي.
- **حماية كلمة المرور** تتحكم فيما إذا كان يمكن للمستخدم فتح أو تعديل العرض التقديمي. وهي منفصلة عن التوقيع الرقمي وتُوصف في [العروض التقديمية المحمية بكلمة مرور](/slides/ar/python-net/password-protected-presentation/).

يقدم PowerPoint الأمر **Add a Digital Signature** تحت **File > Info > Protect Presentation**.

![قائمة حماية العرض التقديمي في PowerPoint مع تمييز إضافة توقيع رقمي](add-digital-signature-in-powerpoint.png)

بعد فتح عرض تقديمي موقع، يمكن لـ PowerPoint عرض إشعار بحالة التوقيع.

![إشعار PowerPoint يوضح أن العرض التقديمي يحتوي على توقيعات صالحة](digital-signature-status-in-powerpoint.png)

تُظهر Aspose.Slides التوقيعات من خلال [Presentation.digital_signatures](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/digital_signatures/)، وهو [DigitalSignatureCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignaturecollection/) يحتوي على عناصر من نوع [DigitalSignature](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignature/). يمكن للعرض التقديمي أن يحتوي على عدة توقيعات.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا باسم ملف PKCS#12 وغالبًا ما يُعطى الامتداد `.pfx` أو `.p12`، يمكن أن يحتوي على شهادة X.509 ومفتاح الخصوصية وسلسلة الشهادة. مفتاح الخصوصية هو ما يسمح للحامل بإنشاء توقيع. لا يمكن استخدام شهادة بدون مفتاح خصوصية قابل للوصول للتوقيع على عرض تقديمي.

كلمة مرور PFX تحمي حزمة الشهادة ومفتاح الخصوصية. إنها **ليست** كلمة مرور لفتح أو تعديل العرض التقديمي. لا تقم بالالتزام بملفات PFX أو كلمات مرورها في نظام التحكم بالمصدر. في بيئات الإنتاج، قلل الوصول إلى ملف الشهادة واحصل على كلمة المرور من مخزن سري أو مصدر إعداد محمي آخر. الأمثلة أدناه تستخدم متغيّر بيئة فقط لتجنب تضمين كلمة المرور في الشيفرة.

## **إضافة توقيع رقمي إلى عرض تقديمي**

لتوقيع سير عمل عرض تقديمي حقيقي، حمّل ملف PPTX موجود، أنشئ [DigitalSignature](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة التوقيعات للعرض التقديمي، واحفظه إلى ملف PPTX.

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

حفظ النتيجة باسم جديد يحافظ على الملف المصدر غير الموقع. قيمة [DigitalSignature.comments](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignature/comments/) تصف غرض التوقيع؛ وهي ليست آلية أمان.

## **التحقق من صحة التوقيعات الرقمية**

عند تحميل ملف PPTX موقع، افحص كل عنصر في [Presentation.digital_signatures](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/digital_signatures/). خاصية [DigitalSignature.is_valid](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignature/is_valid/) تُظهر ما إذا كان التوقيع المضمّن صالحًا لمحتوى العرض التقديمي الحالي.

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

غالبًا ما يعني نتيجة غير صالحة أن محتوى العرض التقديمي الموقع أو بيانات التوقيع تغيرت بعد التوقيع، أو أن الملف تالف. إزالة كل توقيع تُنتج عرضًا تقديميًا غير موقع، لذا فحص صلاحية العناصر فقط لا يكفي: يجب على سير عمل حساس للأمان أيضًا التحقق من عدد التوقيعات المتوقعة وهويات الموقِّعين المتوقعة.

خاصية [DigitalSignature.certificate](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignature/certificate/) تُعيد بيانات الشهادة كمصفوفة بايت. تحسب الأمثلة بصمة SHA-256 لها حتى يتمكن التطبيق من مقارنتها بصمة شهادة الموقّع المتوقعة.

يجب عدم اعتبار نتيجة الصلاحية هذه قرارًا نهائيًا بشأن ثقة الشهادة. بناءً على سياسات الأمان الخاصة بك، قد يحتاج تطبيقك أيضًا إلى بناء والتحقق من سلسلة شهادة X.509، وفحص تواريخ صلاحية الشهادة وحالة إلغائها، وتأكيد الموضوع أو البصمة المتوقعة، والتحقق من استخدام المفتاح، وتقييم طابع زمني موثوق. قيمة [DigitalSignature.sign_time](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignature/sign_time/) بحد ذاتها لا تُعد دليلًا من سلطة طابع زمني موثوقة.

## **إزالة التوقيعات الرقمية**

إزالة التوقيعات تغير حالة أمان العرض التقديمي. المثال التالي يحمل ملف PPTX موقع، يزيل كل التوقيعات باستخدام [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignaturecollection/clear/)، ويحفظ نسخة غير موقعة.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

لإزالة توقيع واحد فقط، استدعِ [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/ar/python-net/aspose.slides/digitalsignaturecollection/remove_at/) مع الفهرس الصفري الخاص به. احفظ إلى ملف جديد إلا إذا كان الكتاب فوق الملف الموقع الأصلي جزءًا صريحًا من سير عملك.

## **التحرير واعتبارات الصيغة**

- لا يجعل التوقيع العرض التقديمي للقراءة فقط. يمكن للمستخدمين والتطبيقات تعديل الملف، لكن تغيّر المحتوى الموقع عادةً ما يبطل التوقيع الحالي.
- أكمل جميع التعديلات المقصودة قبل التوقيع. إذا كان يجب تعديل العرض التقديمي، احفظ النسخة المعدلة ووقعها مرة أخرى.
- احتفظ بالمخرجات النهائية بصيغة PPTX. تحويل عرض تقديمي موقع إلى صيغة أخرى لا ينقل التوقيع الأصلي كـ توقيع صالح للملف المحوّل.
- عامِل مفتاح الخصوصية الخاص بالشهادة كحسّاس. أي شخص يحصل على المفتاح وكلمة مروره قد يستطيع إنشاء توقيعات تبدو كما لو أنها صادرة من حامل الشهادة.
- احتفظ بالمصدر غير الموقع أو نسخة خاضعة للسيطرة عندما تتطلب سياسة الاحتفاظ بالمستندات ذلك.

## **الأسئلة الشائعة**

**هل التوقيع الرقمي يشفر العرض التقديمي؟**

لا. يوفر التوقيع الرقمي دليلًا على الأصل والنزاهة، لكن محتوى العرض التقديمي يظل قابلًا للقراءة ما لم يُطبق تشفير منفصل. استخدم [حماية كلمة المرور](/slides/ar/python-net/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفسها كلمة مرور العرض التقديمي؟**

لا. كلمة مرور PFX تُفتح مفتاح الخصوصية المخزن في حزمة الشهادة. هي لا تتحكم بمن يمكنه فتح أو تعديل ملف PPTX.

**هل يمكنني استخدام شهادة موقعة ذاتيًا؟**

تقنيًا، يمكن استخدام شهادة موقعة ذاتيًا إذا تضمنت مفتاح خصوصية قابل للوصول. لن يثق المستلمون بها تلقائيًا إلا إذا أضيفت الشهادة صراحةً إلى بيئتهم الموثوقة. عادةً ما تستخدم سير عمل عامة أو عابرة للمنظمات شهادة صادرة عن سلطة شهادة موثوقة.

**ما الذي يجعل التوقيع غير صالح؟**

تغيّر محتوى العرض التقديمي الموقع أو بيانات التوقيع بعد التوقيع قد يبطل التوقيع. تلف الملف قد يتسبب أيضًا في فشل التحقق. إذا أزيلت جميع التوقيعات، يصبح العرض غير موقع وليس ملفًا يحتوي على توقيع غير صالح.

**هل يعني التوقيع الصالح أنني يجب أن أثق بالموقِّع؟**

ليس بمفرده. تكامل التوقيع وثقة الموقِّع هما قراران منفصلان. يجب على سياسة التحقق في الإنتاج أيضًا فحص سلسلة الشهادة، وفترة الصلاحية، وحالة الإلغاء، وهوية الموقِّع المتوقعة، واستخدام المفتاح، وأية متطلبات طابع زمني موثوق.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض التقديمي، لكنه يؤثر على تقييم ثقة الشهادة. ما إذا كان التوقيع لا يزال مقبولًا يعتمد على سياستك وما إذا كان طابع زمني موثوق يُظهر أن التوقيع تم بينما كانت الشهادة صالحة. لا تعتمد على وقت التوقيع المعروض وحده كطابع زمني موثوق.

**هل يمكن تعديل عرض تقديمي موقع؟**

نعم. لا يُقفل التوقيع الملف. تعديل المحتوى الموقع عادةً ما يُبطل التوقيع الحالي، لذا أكمل العرض أولًا ووقع المراجعة النهائية.

**هل يمكن للعرض التقديمي أن يحتوي على أكثر من توقيع؟**

نعم. أضف كل توقيع إلى [Presentation.digital_signatures](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/digital_signatures/) قبل الحفظ. أثناء التحقق، افحص كل توقيع وتأكد من أن جميع الموقِّعين المطلوبين موجودين.

**ما صيغ العروض التقديمية التي تدعم هذه العمليات؟**

تدعم Aspose.Slides عمليات التوقيع الرقمي الموصوفة هنا فقط لصيغة PPTX. صيغ PPT وOpenDocument غير مدعومة في هذا التدفق البرمجي.

**هل يمكنني إزالة توقيع دون أن يؤثر ذلك على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو مسح المجموعة بالكامل ثم حفظ العرض. يبقى محتوى الشرائح متاحًا، لكن الملف المحفوظ لن يحمل دليل التوقيع المُزال.