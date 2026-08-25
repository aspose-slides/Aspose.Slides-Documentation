---
title: إضافة توقيعات رقمية إلى العروض التقديمية في C++
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "تعرّف على كيفية توقيع عروض PPTX موجودة باستخدام شهادات PFX واستخدام Aspose.Slides للغة C++ للتحقق من التوقيعات الرقمية أو إزالتها."
---
## **نظرة عامة**

تساعد التوقيع الرقمي المتلقي على تحديد من قام بالتوقيع على العرض وما إذا كان المحتوى الموقّع قد تغير. هناك ثلاثة مفاهيم أمنية ذات صلة مهمة هنا:

- **شهادة رقمية** هي اعتماد إلكتروني يربط هوية بمفتاح عام. يمكن لسلطة شهادات موثوقة (CA) إصدار شهادة، أو يمكن لمنظمة استخدام شهادة موقعة ذاتيًا لتدفقات العمل الداخلية.
- **توقيع رقمي** يُنشأ من محتوى العرض ومفتاح المتحفظ بالشهادة الخاص. يمكن بعد ذلك استخدام المفتاح العام للشهادة للتحقق من التوقيع. يوفر التوقيع دليلًا على الأصل والنزاهة؛ لكنه لا يشفر العرض.
- **حماية بكلمة مرور** تتحكم في إمكانية فتح أو تعديل العرض من قبل المستخدم. وهي منفصلة عن التوقيع الرقمي وتُوصف في [العروض المحمية بكلمة مرور](/slides/ar/cpp/password-protected-presentation/).

يوفر PowerPoint الأمر **Add a Digital Signature** ضمن **File > Info > Protect Presentation**.

![قائمة Protect Presentation في PowerPoint مع تمييز Add a Digital Signature](add-digital-signature-in-powerpoint.png)

بعد فتح عرض موقّع، يمكن لـ PowerPoint عرض إشعار بحالة التوقيع.

![إشعار PowerPoint يوضح أن العرض يحتوي على توقيعات صالحة](digital-signature-status-in-powerpoint.png)

تُتيح Aspose.Slides التوقيعات عبر [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_digitalsignatures/)، التي تُعيد [IDigitalSignatureCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignaturecollection/)، حيث تنفّذ عناصرها [IDigitalSignature](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignature/). يمكن للعرض أن يحتوي على توقيعات متعددة.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا بملف PKCS#12 وغالبًا ما يُعطى امتدادًا `.pfx` أو `.p12`، يمكن أن يحتوي على شهادة X.509، مفتاحها الخاص، وسلسلة الشهادات. المفتاح الخاص هو ما يسمح للمالك بإنشاء توقيع. لا يمكن استخدام شهادة بدون مفتاح خاص يمكن الوصول إليه لتوقيع عرض تقديمي.

كلمة مرور PFX تحمي حزمة الشهادة والمفتاح الخاص. هي **ليس** كلمة مرور لفتح أو تعديل العرض. لا تقم بحفظ ملفات PFX أو كلمات مرورها في نظام التحكم في المصدر. في بيئة الإنتاج، حدّ من الوصول إلى ملف الشهادة واحصل على كلمة المرور من مخزن أسرار أو مصدر تكوين محمي آخر. الأمثلة أدناه تستخدم متغيّر بيئة فقط لتجنب تضمين كلمة المرور في الشيفرة.

## **إضافة توقيع رقمي إلى عرض تقديمي**

لتوقيع سير عمل عرض تقديمي حقيقي، احمّل ملف PPTX موجود، أنشئ [DigitalSignature](https://reference.aspose.com/slides/ar/cpp/aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة التوقيعات في العرض، ثم احفظه كملف PPTX.

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

حفظ النتيجة باسم جديد يحافظ على الملف المصدر غير الموقع. قيمة [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignature/set_comments/) تصف غرض التوقيع؛ فهي ليست تحكمًا أمنيًا.

## **التحقق من صحة التوقيعات الرقمية**

عند تحميل ملف PPTX موقع، افحص كل عنصر تُعيده [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_digitalsignatures/). طريقة [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignature/get_isvalid/) تشير إلى ما إذا كان التوقيع المضمّن صالحًا لمحتوى العرض الحالي.

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

عادةً ما يعني النتيجة غير الصالحة أن محتوى العرض الموقع أو بيانات التوقيع تغيرت بعد التوقيع، أو أن الملف تضرّ. إزالة كل توقيع ينتج عرضًا غير موقع، لذا فحص صلاحية العناصر وحده غير كافٍ: يجب على سير عمل حساس أمنيًا أيضًا التحقق من وجود العدد المتوقع من التوقيعات وهويات الموقعين المتوقّعة.

يجب ألا تُعامل نتيجة الصلاحية كقرار نهائي بموثوقية الشهادة. بناءً على سياسة الأمان الخاصة بك، قد يحتاج تطبيقك أيضًا إلى بناء والتحقق من سلسلة شهادة X.509، فحص تواريخ صلاحية الشهادة وحالة الإلغاء، تأكيد الموضوع أو بصمة الشهادة المتوقعة، التحقق من استخدام المفتاح، وتقييم طابع زمني موثوق. قيمة [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignature/get_signtime/) بمفردها ليست دليلًا من سلطة طابع زمني موثوقة.

## **إزالة التوقيعات الرقمية**

إزالة التوقيعات تغير حالة أمان العرض. المثال التالي يحمل ملف PPTX موقع، يزيل كل التوقيعات باستخدام [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignaturecollection/clear/)، ثم يحفظ نسخة غير موقعّة.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

لإزالة توقيع واحد فقط، استدعِ [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idigitalsignaturecollection/removeat/) مع الفهرس الصفري الخاص به. احفظ إلى ملف جديد ما لم يكن الكتابة فوق الأصلي الموقع جزءًا صريحًا من سير عملك.

## **اعتبارات التحرير والتنسيق**

- التوقيع لا يجعل العرض للقراءة فقط. لا يزال بإمكان المستخدمين والتطبيقات تعديل الملف، لكن تغيّر المحتوى الموقع عادةً ما يبطل التوقيع الموجود.
- أكمل كل التعديلات المقصودة قبل التوقيع. إذا كان يجب تعديل العرض، احفظ النسخة المعدلة ووقّع تلك المراجعة مرة أخرى.
- احفظ المخرجات النهائية بصيغة PPTX. تحويل عرض موقع إلى صيغة أخرى لا ينقل توقيع PPTX الأصلي كتوقيع صالح للملف المحوّل.
- عامل المفتاح الخاص بالشهادة بحساسية. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يتمكن من إنشاء توقيعات تبدو كأنها صادرة عن صاحب الشهادة.
- احتفظ بالمصدر غير الموقع أو نسخة خاضعة للسيطرة عندما تتطلب سياسة الاحتفاظ بالمستندات ذلك.

## **الأسئلة المتكررة**

**هل التوقيع الرقمي يشفر العرض؟**

لا. التوقيع الرقمي يوفر دليلًا على الأصل والنزاهة، لكن محتوى العرض يظل قابلًا للقراءة ما لم يُطبق تشفير منفصل. استخدم [حماية بكلمة مرور](/slides/ar/cpp/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفسها كلمة مرور العرض؟**

لا. كلمة مرور PFX تفتح المفتاح الخاص المخزن في حزمة الشهادة. هي لا تتحكم في من يمكنه فتح أو تعديل ملف PPTX.

**هل يمكنني استخدام شهادة موقعة ذاتيًا؟**

تقنيًا، يمكن استخدام شهادة موقعة ذاتيًا عندما تتضمن مفتاحًا خاصًا يمكن الوصول إليه. إلا أن المستقبلين لن يثقوا بها تلقائيًا ما لم تُضاف تلك الشهادة صراحةً إلى بيئتهم الموثوقة. عادةً ما تستخدم سير عمل عام أو عبر مؤسسات شهادة صادرة عن سلطة شهادات موثوقة.

**ما الذي يجعل التوقيع غير صالح؟**

تغيّر محتوى العرض الموقع أو بيانات التوقيع بعد التوقيع يمكن أن يبطل التوقيع. قد يتسبب تلف الملف أيضًا في فشل التحقق. إذا أزيلت كل التوقيعات، يصبح العرض غير موقع بدلاً من أن يحتوي على توقيع غير صالح.

**هل يعني التوقيع الصالح أنني يجب أن أثق بالموقع؟**

ليس بمفرده. سلامة التوقيع وثقة الموقع قراران منفصلان. يجب على سياسة التحقق في الإنتاج أيضًا فحص سلسلة الشهادة، فترة الصلاحية، حالة الإلغاء، الهوية المتوقعة، استخدام المفتاح، وأي متطلبات طابع زمني موثوق.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض، لكنه يؤثر على تقييم الثقة بالشهادة. ما إذا كان التوقيع يظل مقبولًا يعتمد على سياستك وما إذا كان هناك طابع زمني موثوق يثبت أن التوقيع تم أثناء صلاحية الشهادة. لا تعتمد على وقت التوقيع المعروض وحده كطابع زمني موثوق.

**هل يمكن تحرير عرض موقع؟**

نعم. التوقيع لا يقفل الملف. عادةً ما يؤدي تحرير المحتوى الموقع إلى إبطال التوقيع الموجود، لذا أكمل العرض أولاً ووقّع المراجعة النهائية.

**هل يمكن للعرض أن يحتوي على أكثر من توقيع؟**

نعم. أضف كل توقيع إلى المجموعة التي تُعيدها [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_digitalsignatures/) قبل الحفظ. أثناء التحقق، افحص كل توقيع وتأكد من أن جميع الموقعين المطلوبين موجودين.

**أي صيغ عرض تدعم هذه العمليات؟**

تدعم Aspose.Slides عمليات التوقيع الرقمي الموضحة هنا فقط لصيغة PPTX. صيغ PPT وOpenDocument لا يدعمها هذا العمل البرمجي.

**هل يمكنني إزالة توقيع دون التأثير على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو مسح المجموعة بالكامل ثم حفظ العرض. يظل محتوى الشرائح متاحًا، لكن الملف المحفوظ لن يحمل دليل التوقيع المُزال.