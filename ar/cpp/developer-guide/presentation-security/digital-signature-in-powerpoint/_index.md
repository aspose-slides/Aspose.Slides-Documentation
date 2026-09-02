---
title: "إضافة توقيعات رقمية إلى العروض التقديمية بلغة C++"
linktitle: "التوقيع الرقمي"
type: docs
weight: 10
url: /ar/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "تعلم كيفية توقيع عروض PPTX الموجودة باستخدام شهادات PFX واستخدام Aspose.Slides للغة C++ للتحقق من التواقيع الرقمية أو إزالتها."
---
## **نظرة عامة**

تساعد التوقيع الرقمي المستلم على تحديد من قام بالتوقيع على العرض التقديمي وما إذا كان المحتوى الموقع قد تغير. هناك ثلاثة مفاهيم أمان ذات صلة مهمة هنا:

- **الشهادة الرقمية** هي اعتماد إلكتروني يربط هوية بمفتاح عام. يمكن لسلطة شهادة موثوقة (CA) إصدار شهادة، أو يمكن للمؤسسة استخدام شهادة self‑signed للعمليات الداخلية.
- **التوقيع الرقمي** يُنشأ من محتوى العرض ومفتاح خاص لحامل الشهادة. يمكن بعد ذلك استخدام المفتاح العام للشهادة للتحقق من التوقيع. يوفر التوقيع دليلًا على الأصل والنزاهة؛ ولا يقوم بتشفير العرض.
- **حماية كلمة المرور** تتحكم فيما إذا كان المستخدم يستطيع فتح أو تعديل العرض. وهي منفصلة عن التوقيع الرقمي وتُوصف في [العروض المحمية بكلمة مرور](/cpp/password-protected-presentation/).

يوفر PowerPoint أمر **Add a Digital Signature** ضمن **File > Info > Protect Presentation**.

![قائمة PowerPoint Protect Presentation مع تمييز Add a Digital Signature](add-digital-signature-in-powerpoint.png)

بعد فتح عرض موقع، يمكن لـ PowerPoint عرض إشعار بحالة التوقيع.

![إشعار PowerPoint يوضح أن العرض يحتوي على توقيعات صالحة](digital-signature-status-in-powerpoint.png)

تُظهر Aspose.Slides التواقيع عبر [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_digitalsignatures/)، الذي يُعيد [IDigitalSignatureCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignaturecollection/) التي تُنفذ عناصرها [IDigitalSignature](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignature/). يمكن للعرض أن يحتوي على عدة توقيعات.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا بملف PKCS#12 وعادة ما يُعطى امتدادًا `.pfx` أو `.p12`، يمكن أن يحتوي على شهادة X.509، ومفتاحها الخاص، وسلسلة الشهادات. المفتاح الخاص هو ما يسمح للحامل بإنشاء توقيع. الشهادة بدون مفتاح خاص متاح لا يمكن استخدامها لتوقيع عرض.

كلمة مرور PFX تحمي حزمة الشهادة والمفتاح الخاص. إنها **ليس** كلمة مرور لفتح أو تحرير العرض. لا تقم بارتكاب ملفات PFX أو كلمات مرورها إلى نظام التحكم بالمصدر. في بيئة الإنتاج، حدّ من الوصول إلى ملف الشهادة واحصل على كلمة المرور من مخزن أسرار أو مصدر تكوين محمي آخر. الأمثلة أدناه تستخدم متغيّر بيئة فقط لتجنب تضمين كلمة المرور في الشيفرة.

## **إضافة توقيع رقمي إلى عرض تقديمي**

لتوقيع سير عمل عرض حقيقي، حمّل ملف PPTX موجود، أنشئ [DigitalSignature](https://reference.aspose.com/slides/ar/cpp/aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة العرض، واحفظه كملف PPTX.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

حفظ النتيجة باسم جديد يحافظ على ملف المصدر غير الموقع. قيمة [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignature/set_comments/) تصف غرض التوقيع؛ وهي ليست عنصرًا أمنيًا.

## **التحقق من صحة التواقيع الرقمية**

عند تحميل ملف PPTX موقع، افحص كل عنصر تُرجعه [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_digitalsignatures/). طريقة [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignature/get_isvalid/) تشير ما إذا كان التوقيع المدمج صالحًا لمحتوى العرض الحالي.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

غالبًا ما يعني نتيجة غير صالحة أن محتوى العرض الموقع أو بيانات التوقيع تغيرت بعد التوقيع، أو أن الملف تالف. إزالة كل توقيع ينتج عرضًا غير موقع، لذا فحص صلاحية العناصر فقط ليس كافيًا: يجب على سير عمل حسّاس للأمان أيضًا التحقق من وجود العدد المتوقع من التواقيع وهويات الموقعين المتوقعة.

يجب ألا يُعامل نتيجة الصلاحية كقرار نهائي بموثوقية الشهادة. بناءً على سياسة الأمان الخاصة بك، قد يحتاج تطبيقك أيضًا إلى بناء والتحقق من سلسلة شهادات X.509، والتحقق من تواريخ صلاحية الشهادة وحالة الإبطال، وتأكيد الموضوع أو البصمة المتوقعة، والتحقق من استخدام المفتاح، وتقييم ختم زمني موثوق. قيمة [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignature/get_signtime/) وحدها ليست دليلًا من سلطة توقيت موثوقة.

## **إزالة التواقيع الرقمية**

إزالة التواقيع تغير حالة أمان العرض. المثال التالي يحمل ملف PPTX موقع، يزيل جميع التواقيع باستخدام [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignaturecollection/clear/)، ويحفظ نسخة غير موقعة.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

لإزالة توقيع واحد فقط، استدعِ [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignaturecollection/removeat/) مع فهرسه الصفري. احفظ إلى ملف جديد إلا إذا كان استبدال الأصل الموقع جزءًا صريحًا من سير العمل الخاص بك.

## **التحرير واعتبارات التنسيق**

- لا يجعل التوقيع العرض للقراءة فقط. لا يزال بإمكان المستخدمين والتطبيقات تحرير الملف، لكن التغييرات على المحتوى الموقع عادةً ما تُبطِل التوقيع الموجود.
- أكمل جميع التعديلات المقصودة قبل التوقيع. إذا كان لابد من تغيير العرض، احفظ النسخة المعدلة ووقع تلك النسخة مرة أخرى.
- احتفظ بالمخرج النهائي بصيغة PPTX. تحويل عرض موقع إلى صيغة أخرى لا ينقل توقيع PPTX الأصلي كتوقيع صالح للملف المحوَّل.
- اعتبر المفتاح الخاص بالشهادة حساسًا. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يستطيع إنشاء تواقيع تبدو وكأنها صادرة من حامل الشهادة.
- احتفظ بالمصدر غير الموقع أو نسخة خاضعة للسيطرة عندما تتطلب سياسة احتفاظ المستندات ذلك.

## **الأسئلة المتكررة**

**هل التوقيع الرقمي يشفّر العرض التقديمي؟**

لا. يوفر التوقيع الرقمي دليلًا عن الأصل والنزاهة، لكن محتوى العرض يظل قابلًا للقراءة ما لم يتم تطبيق تشفير منفصل. استخدم [حماية كلمة المرور](/cpp/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفسها كلمة مرور العرض؟**

لا. كلمة مرور PFX تفتح المفتاح الخاص المخزن في حزمة الشهادة. ولا تتحكم في من يمكنه فتح أو تحرير ملف PPTX.

**هل يمكنني استخدام شهادة self‑signed؟**

تقنيًا، يمكن استخدام شهادة self‑signed عندما تتضمن مفتاحًا خاصًا متاحًا. لن يثق المستلم بها تلقائيًا، ما لم تُضاف الشهادة صراحة إلى بيئته الموثوقة. عادةً ما تستخدم سير عمل عامة أو عابرة للمؤسسات شهادة صادرة عن CA موثوق.

**ما الذي يجعل التوقيع غير صالح؟**

تغيير محتوى العرض الموقع أو بيانات التوقيع بعد التوقيع قد يبطل التوقيع. قد يتسبب تلف الملف أيضًا في فشل التحقق. إذا أُزيلت جميع التواقيع، يصبح العرض غير موقع بدلاً من احتوائه على توقيع غير صالح.

**هل يعني التوقيع الصالح أنني يجب أن أثق بالموقع؟**

ليس ذلك بحد ذاته. سلامة التوقيع وثقة الموقع قرارات منفصلة. ينبغي لسياسة التحقق في الإنتاج أيضًا فحص سلسلة الشهادات، فترة الصلاحية، حالة الإبطال، الهوية المتوقعة، استخدام المفتاح، وأي متطلبات للوقت الموثوق.

**ماذا يحدث إذا انتهت صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض، لكنه يؤثر على تقييم موثوقية الشهادة. ما إذا كان التوقيع ما زال مقبولًا يعتمد على سياستك وما إذا كان هناك ختم زمني موثوق يثبت أن التوقيع تم أثناء صلاحية الشهادة. لا تعتمد على وقت التوقيع المعروض وحده كختم زمني موثوق.

**هل يمكن تحرير عرض موقع؟**

نعم. لا يقوم التوقيع بتقفل الملف. عادةً ما تجعل التحرير محتوى موقع التوقيع غير صالح، لذا أكمل العرض أولًا ووقع النسخة النهائية.

**هل يمكن للعرض أن يحتوي على أكثر من توقيع واحد؟**

نعم. أضف كل توقيع إلى المجموعة التي تُرجعها [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_digitalsignatures/) قبل الحفظ. أثناء التحقق، افحص كل توقيع وتأكد من وجود جميع الموقعين المطلوبين.

**ما صيغ العروض التي تدعم هذه العمليات؟**

يدعم Aspose.Slides عمليات التوقيع الرقمي الموضحة هنا فقط لتنسيق PPTX. صيغ PPT وOpenDocument للعرض غير مدعومة بواسطة واجهة برمجة التطبيقات هذه.

**هل يمكنني إزالة توقيع دون التأثير على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو مسح المجموعة بالكامل ثم حفظ العرض. يظل محتوى الشرائح متاحًا، لكن الملف المحفوظ لن يحمل دليل التوقيع المحذوف.