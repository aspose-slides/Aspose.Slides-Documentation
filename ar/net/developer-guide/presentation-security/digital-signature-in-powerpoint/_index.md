---
title: إضافة التوقيعات الرقمية إلى العروض التقديمية في .NET
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/net/digital-signature-in-powerpoint/
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
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية توقيع العروض التقديمية بصيغة PPTX باستخدام شهادات PFX واستخدام Aspose.Slides لـ .NET للتحقق من التوقيعات الرقمية أو إزالتها."
---
## **نظرة عامة**

تساعد التوقيع الرقمي المتلقي على تحديد من وقع العرض وما إذا كان المحتوى الموقع قد تغير. هناك ثلاثة مفاهيم أمنية ذات صلة مهمة هنا:

- **شهادة رقمية** هي اعتماد إلكتروني يربط هوية بمفتاح عام. يمكن لسلطة شهادات موثوقة (CA) إصدار شهادة، أو يمكن للمنظمة استخدام شهادة موقعة ذاتياً للعمليات الداخلية.
- **توقيع رقمي** يتم إنشاؤه من محتوى العرض ومفتاح الخصوصية لحامل الشهادة. يمكن بعد ذلك استخدام المفتاح العام للشهادة للتحقق من التوقيع. يوفر التوقيع دليلًا على الأصل والنزاهة؛ ولا يقوم بتشفير العرض.
- **حماية كلمة مرور** تتحكم فيما إذا كان المستخدم يستطيع فتح أو تعديل العرض. هي منفصلة عن التوقيع الرقمي وتُشرح في [عروض محمية بكلمة مرور](/slides/ar/net/password-protected-presentation/).

يقدم PowerPoint الأمر **Add a Digital Signature** ضمن **File > Info > Protect Presentation**.

![قائمة PowerPoint Protect Presentation مع إبراز Add a Digital Signature](add-digital-signature-in-powerpoint.png)

بعد فتح عرض موقع، يمكن لـ PowerPoint عرض إشعار بحالة التوقيع.

![إشعار PowerPoint يوضح أن العرض يحتوي على توقيعات صالحة](digital-signature-status-in-powerpoint.png)

تُعرِض Aspose.Slides التوقيعات عبر [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/digitalsignatures/)، وهو [IDigitalSignatureCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/idigitalsignaturecollection/) يحتوي على عناصر تُنفّذ [IDigitalSignature](https://reference.aspose.com/slides/ar/net/aspose.slides/idigitalsignature/). يمكن أن يحتوي العرض على توقيعات متعددة.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا بملف PKCS#12 وعادة ما يكون امتداده `.pfx` أو `.p12`، يمكن أن يحتوي على شهادة X.509، ومفتاحها الخاص، وسلسلة الشهادات. المفتاح الخاص هو ما يسمح لحامل الشهادة بإنشاء توقيع. لا يمكن استخدام شهادة بلا مفتاح خاص يمكن الوصول إليه لتوقيع عرض.

تحمي كلمة مرور PFX حزمة الشهادة والمفتاح الخاص. هي **ليس** كلمة مرور لفتح أو تعديل العرض. لا تُدرج ملفات PFX أو كلمات مرورها في نظام التحكم بالمصادر. في بيئة الإنتاج، قلل الوصول إلى ملف الشهادة واحصل على كلمة المرور من مخزن أسرار أو مصدر تكوين محمي آخر. الأمثلة أدناه تستخدم متغير بيئي فقط لتجنب تضمين كلمة المرور في الشيفرة.

## **إضافة توقيع رقمي إلى عرض**

لتوقيع سير عمل عرض حقيقي، حمّل ملف PPTX موجود، أنشئ [DigitalSignature](https://reference.aspose.com/slides/ar/net/aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة العرض، واحفظه كملف PPTX.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

حفظ النتيجة باسم جديد يحافظ على ملف المصدر غير الموقع. قيمة [DigitalSignature.Comments](https://reference.aspose.com/slides/ar/net/aspose.slides/digitalsignature/comments/) تصف غرض التوقيع؛ وهي ليست عنصر أمان.

## **التحقق من صحة التوقيعات الرقمية**

عند تحميل ملف PPTX موقع، افحص كل عنصر في [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/digitalsignatures/). خاصية [IDigitalSignature.IsValid](https://reference.aspose.com/slides/ar/net/aspose.slides/idigitalsignature/isvalid/) تُظهر ما إذا كان التوقيع المضمّن صالحًا لمحتوى العرض الحالي.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

نتيجة غير صالحة تعني عادةً أن محتوى العرض الموقّع أو بيانات التوقيع تغيرت بعد التوقيع، أو أن الملف تالف. إزالة كل توقيع ينتج عنه عرض غير موقع، لذا فحص صلاحية العناصر فقط لا يكفي: يجب أيضًا التحقق من عدد التوقيعات المتوقَّع وهويات الموقعين المتوقَّعة في سير عمل حساس للأمان.

يجب عدم اعتبار نتيجة الصلاحية كقرار نهائي حول موثوقية الشهادة. بناءً على سياسية الأمان لديك، قد يحتاج تطبيقك أيضًا إلى بناء والتحقق من سلسلة شهادة X.509، وفحص تواريخ صلاحية الشهادة وحالة إلغائها، وتأكيد الموضوع أو بصمة الإصبع المتوقعة، والتحقق من استعمال المفتاح، وتقييم طابع زمني موثوق. قيمة [IDigitalSignature.SignTime](https://reference.aspose.com/slides/ar/net/aspose.slides/idigitalsignature/signtime/) وحدها ليست دليلًا من سلطة طابع زمني موثوقة.

## **إزالة التوقيعات الرقمية**

إزالة التوقيعات تغير حالة أمان العرض. المثال التالي يحمل ملف PPTX موقع، يزيل كل التوقيعات باستخدام [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides/idigitalsignaturecollection/clear/)، ويحفظ نسخة غير موقّعة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

لإزالة توقيع واحد فقط، استدعِ [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/ar/net/aspose.slides/idigitalsignaturecollection/removeat/) مع فهرس الصفر‑المستند الخاص به. احفظ إلى ملف جديد ما لم يكن استبدال الملف الأصلي الموقع جزءًا صريحًا من سير عملك.

## **الاعتبارات المتعلقة بالتحرير والتنسيق**

- لا يجعل التوقيع العرض للقراءة فقط. لا يزال بإمكان المستخدمين والتطبيقات تعديل الملف، لكن التغييرات على المحتوى الموقع عادةً ما تُبطِل التوقيع الحالي.
- أكمل جميع التعديلات المقصودة قبل التوقيع. إذا كان لابد من تعديل العرض، احفظ النسخة المعدَّلة ووقّع تلك النسخة مرة أخرى.
- احتفظ بالمخرجات النهائية بتنسيق PPTX. تحويل عرض موقع إلى تنسيق آخر لا ينقل التوقيع الأصلي كتوثيق صالح للملف المحوّل.
- عُد المفتاح الخاص للشهادة كعنصر حساس. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يتمكن من إنشاء توقيعات تبدو كمستندات صادرة عن حامل الشهادة.
- احتفظ بالمصدر غير الموقع أو نسخة خاضعة للسيطرة عندما تتطلب سياسة الاحتفاظ بالمستندات ذلك.

## **الأسئلة المتكررة**

**هل التوقيع الرقمي يشفر العرض؟**

لا. يوفر التوقيع الرقمي دليلًا حول الأصل والنزاهة، لكن يبقى محتوى العرض قابلًا للقراءة ما لم يُطبق تشفير منفصل. استخدم [حماية كلمة مرور](/slides/ar/net/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفس كلمة مرور العرض؟**

لا. كلمة مرور PFX تفتح المفتاح الخاص المخزن في حزمة الشهادة. لا تتحكم في من يمكنه فتح أو تحرير ملف PPTX.

**هل يمكنني استخدام شهادة موقعة ذاتيًا؟**

ن theoretically، يمكن استخدام شهادة موقعة ذاتيًا إذا احتوت على مفتاح خاص يمكن الوصول إليه. المتلقون لن يثقوا بها تلقائيًا ما لم تُضاف تلك الشهادة صراحةً إلى بيئتهم الموثوقة. عادةً ما تستخدم سير العمل العامة أو عبر المنظمات شهادة صادرة عن سلطة شهادات موثوقة.

**ماذا يجعل التوقيع غير صالح؟**

تغيير محتوى العرض الموقّع أو بيانات التوقيع بعد التوقيع قد يبطل التوقيع. يمكن أن يتسبب الفساد في الملف أيضًا في فشل التحقق. إذا أزيلت جميع التوقيعات، يصبح العرض غير موقع بدلاً من أن يحتوي على توقيع غير صالح.

**هل يعني التوقيع الصالح أنني يجب أن أثق بالموقع؟**

ليس بمفرده. تكامل التوقيع وثقة الموقع قرارات منفصلة. يجب أن تتضمن سياسة التحقق الإنتاجية فحص سلسلة الشهادة، وفترة الصلاحية، وحالة الإلغاء، والهوية المتوقعة، واستخدام المفتاح، وأي متطلبات طابع زمني موثوق.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض، لكنه يؤثر على تقييم ثقة الشهادة. ما إذا كان التوقيع سيظل مقبولًا يعتمد على سياستك وما إذا كان هناك طابع زمني موثوق يثبت أن التوقيع تم أثناء صلاحية الشهادة. لا تعتمد على وقت التوقيع المعروض وحده كطابع زمني موثوق.

**هل يمكن تحرير عرض موقع؟**

نعم. لا يقفل التوقيع الملف. عادةً ما يجعل تحرير المحتوى الموقع التوقيع الحالي غير صالح، لذا انتهِ من العرض ثم وقّع المراجعة النهائية.

**هل يمكن للعرض أن يحتوي على أكثر من توقيع؟**

نعم. أضف كل توقيع إلى [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/digitalsignatures/) قبل الحفظ. أثناء التحقق، افحص كل توقيع وتأكد من وجود جميع الموقعين المطلوبين.

**ما هي تنسيقات العرض التي تدعم هذه العمليات؟**

يدعم Aspose.Slides عمليات التوقيع الرقمي الموضحة هنا فقط لتنسيق PPTX. لا تدعم صيغ PPT وOpenDocument لهذا السيناريو البرمجي.

**هل يمكنني إزالة توقيع دون أن يؤثر ذلك على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو مسح كامل المجموعة ثم حفظ العرض. يظل محتوى الشرائح متاحًا، لكن الملف المحفوظ لن يحمل دليل التوقيع المحذوف.