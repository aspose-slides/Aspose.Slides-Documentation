---
title: إضافة توقيعات رقمية إلى العروض التقديمية في .NET
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/net/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- سلطة شهادات
- شهادة PFX
- PKCS#12
- التحقق من التوقيع
- PowerPoint
- PPTX
- أمان العرض
- .NET
- C#
- Aspose.Slides
description: "تعلم كيف تقوم بتوقيع العروض التقديمية ذات صيغة PPTX باستخدام شهادات PFX واستخدام Aspose.Slides لـ .NET للتحقق من التواقيع الرقمية أو إزالتها."
---
## **نظرة عامة**

تساعد التوقيع الرقمي المتلقي على تحديد من وقع العرض وما إذا كان المحتوى الموقع قد تغير. هناك ثلاثة مفاهيم أمان ذات صلة مهمة هنا:

- **شهادة رقمية** هي اعتماد إلكتروني يربط هوية بمفتاح عام. يمكن لسلطة شهادات موثوقة (CA) إصدار شهادة، أو يمكن للمنظمة استخدام شهادة موقعة ذاتيًا للعمليات الداخلية.
- **توقيع رقمي** يُنشأ من محتوى العرض ومفتاح الخصوصية لحامل الشهادة. يمكن بعد ذلك استخدام المفتاح العام للشهادة للتحقق من التوقيع. يوفر التوقيع دليلًا على الأصل والنزاهة؛ ولا يقوم بتشفير العرض.
- **حماية كلمة المرور** تتحكم فيما إذا كان المستخدم يستطيع فتح أو تعديل العرض. هي منفصلة عن التوقيع الرقمي وتُوصف في [Password-Protected Presentations](/net/password-protected-presentation/).

يقدم PowerPoint الأمر **Add a Digital Signature** ضمن **File > Info > Protect Presentation**.

![قائمة PowerPoint Protect Presentation مع إبراز Add a Digital Signature](add-digital-signature-in-powerpoint.png)

بعد فتح عرض موقع، يمكن لـ PowerPoint عرض إشعار بحالة التوقيع.

![إشعار PowerPoint يُظهر أن العرض يحتوي على توقيعات صالحة](digital-signature-status-in-powerpoint.png)

يُظهر Aspose.Slides التواقيع عبر [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/digitalsignatures/)، وهو [IDigitalSignatureCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/idigitalsignaturecollection/)، حيث تُنفذ العناصر [IDigitalSignature](https://reference.aspose.com/slides/ar/net/aspose.slides/idigitalsignature/). يمكن للعرض أن يحتوي على عدة توقيعات.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا بملف PKCS#12 وغالبًا ما يُعطى الامتداد `.pfx` أو `.p12`، يمكن أن يحتوي على شهادة X.509، ومفتاحها الخاص، وسلسلة الشهادات. المفتاح الخاص هو ما يسمح للمالك بإنشاء توقيع. لا يمكن استخدام شهادة بدون مفتاح خاص يمكن الوصول إليه لتوقيع عرض.

كلمة مرور PFX تحمِّـى حزمة الشهادة والمفتاح الخاص. **ليس** هي كلمة مرور لفتح أو تحرير العرض. لا تلتزم بملفات PFX أو كلمات مرورها في نظام التحكم بالمصدر. في بيئة الإنتاج، قصر الوصول إلى ملف الشهادة واحصل على كلمة مروره من مخزن أسرار أو مصدر تكوين محمي آخر. الأمثلة أدناه تستخدم متغيّر بيئة فقط لتجنب تضمين كلمة المرور في الشفرة.

## **إضافة توقيع رقمي إلى عرض**

لتوقيع سير عمل عرض حقيقي، حمّل ملف PPTX موجود، أنشئ [DigitalSignature](https://reference.aspose.com/slides/ar/net/aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة العرض، واحفظه إلى ملف PPTX.

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

يحافظ حفظ النتيجة باسم جديد على ملف المصدر غير الموقع. قيمة [DigitalSignature.Comments](https://reference.aspose.com/slides/ar/net/aspose.slides/digitalsignature/comments/) تصف هدف التوقيع؛ ليست عنصر تحكم أمني.

## **التحقق من صحة التواقيع الرقمية**

عند تحميل ملف PPTX موقع، افحص كل عنصر في [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/digitalsignatures/). خاصية [IDigitalSignature.IsValid](https://reference.aspose.com/slides/ar/net/aspose.slides/idigitalsignature/isvalid/) تشير إلى ما إذا كان التوقيع المضمّن صالحًا لمحتوى العرض الحالي.

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

عادةً ما يعني نتيجة غير صالحة أن محتوى العرض الموقع أو بيانات التوقيع تغيرت بعد التوقيع، أو أن الملف تالف. إزالة كل توقيع ينتج عرضًا غير موقع، لذا فحص صلاحية العناصر فقط لا يكفي: يجب على سير عمل حساس للأمان أيضًا التحقق من وجود عدد التواقيع المتوقعة وهويات الموقعين المتوقعة.

يجب ألا تُعامل نتيجة الصلاحية كقرار نهائي بشأن ثقة الشهادة. بناءً على سياسات الأمان الخاصة بك، قد يحتاج تطبيقك أيضًا إلى بناء والتحقق من سلسلة شهادة X.509، فحص تواريخ صلاحية الشهادة وحالة الإلغاء، تأكيد الموضوع أو البصمة المتوقعة، التحقق من استخدام المفتاح، وتقييم طابع زمني موثوق. قيمة [IDigitalSignature.SignTime](https://reference.aspose.com/slides/ar/net/aspose.slides/idigitalsignature/signtime/) بمفردها ليست دليلًا من سلطة طابع زمني موثوق.

## **إزالة التواقيع الرقمية**

إزالة التواقيع تغير حالة أمان العرض. المثال التالي يحمل ملف PPTX موقع، يزيل كل التواقيع باستخدام [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/ar/net/aspose.slides/idigitalsignaturecollection/clear/)، ويحفظ نسخة غير موقعة.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

لإزالة توقيع واحد فقط، استدعِ [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/ar/net/aspose.slides/idigitalsignaturecollection/removeat/) مع الفهرس الصفري الخاص به. احفظ إلى ملف جديد ما لم يكن استبدال الأصلي الموقع جزءًا صريحًا من سير عملك.

## **اعتبارات التحرير والتنسيق**

- التوقيع لا يجعل العرض للقراءة فقط. لا يزال بإمكان المستخدمين والتطبيقات تحرير الملف، لكن التغييرات على المحتوى الموقع عادةً ما تُبطل التوقيع القائم.
- أكمل جميع التعديلات المقصودة قبل التوقيع. إذا كان يجب تعديل العرض، احفظ النسخة المعدلة ووقع تلك المراجعة مرة أخرى.
- احتفظ بالمخرج النهائي بصيغة PPTX. تحويل عرض موقع إلى صيغة أخرى لا ينقل توقيع PPTX الأصلي كتوقيع صالح للملف المحول.
- اعتبر المفتاح الخاص للشهادة حساسًا. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يتمكن من إنشاء توقيعات تبدو وكأنها صادرة عن حامل تلك الشهادة.
- احتفظ بالمصدر غير الموقع أو نسخة مُتحكم فيها أخرى عندما تتطلب سياسة احتفاظ المستندات ذلك.

## **الأسئلة المتداولة**

**هل التوقيع الرقمي يشفر العرض؟**  
لا. يوفر التوقيع الرقمي دليلًا عن الأصل والنزاهة، لكن يبقى محتوى العرض قابلًا للقراءة ما لم يتم تطبيق تشفير منفصل. استخدم [password protection](/net/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفسها كلمة مرور العرض؟**  
لا. كلمة مرور PFX تفتح المفتاح الخاص المخزن في حزمة الشهادة. لا تتحكم في من يمكنه فتح أو تحرير ملف PPTX.

**هل يمكنني استخدام شهادة موقعة ذاتيًا؟**  
تقنيًا، يمكن استخدام شهادة موقعة ذاتيًا عندما تتضمن مفتاحًا خاصًا يمكن الوصول إليه. لا يثق المستقبلون بها تلقائيًا، إلا إذا أضيفت تلك الشهادة صراحةً إلى بيئتهم الموثوقة. عادةً ما تستخدم سير عمل عامة أو عبر المنظمات شهادة صادرة عن سلطة شهادات موثوقة.

**ما الذي يجعل توقيعًا غير صالح؟**  
تغيير محتوى العرض الموقع أو بيانات التوقيع بعد التوقيع يمكن أن يبطل التوقيع. تلف الملف قد يسبب فشل التحقق أيضًا. إذا أُزيلت جميع التواقيع، يصبح العرض غير موقع بدلاً من ملف يحتوي على توقيع غير صالح.

**هل يعني توقيع صالح أنني يجب أن أثق بالموقع؟**  
ليس بمفرده. سلامة التوقيع وثقة الموقع هما قراران منفصلان. يجب على سياسة التحقق في الإنتاج أيضًا فحص سلسلة الشهادة، فترة الصلاحية، حالة الإلغاء، الهوية المتوقعة، استخدام المفتاح، وأية متطلبات لطابع زمني موثوق.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**  
انتهاء صلاحية الشهادة لا يغير بايتات العرض، لكنه يؤثر على تقييم ثقة الشهادة. ما إذا كان التوقيع لا يزال مقبولًا يعتمد على سياساتك وما إذا كان طابع زمني موثوق صالح يثبت أن التوقيع تم بينما الشهادة كانت صالحة. لا تعتمد على وقت التوقيع المعروض فقط كطابع زمني موثوق.

**هل يمكن تعديل عرض موقع؟**  
نعم. التوقيع لا يقفل الملف. تحرير المحتوى الموقع عادةً ما يبطل التوقيع القائم، لذا أكمل العرض أولًا ووقع المراجعة النهائية.

**هل يمكن للعرض أن يحتوي على أكثر من توقيع واحد؟**  
نعم. أضف كل توقيع إلى [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/digitalsignatures/) قبل الحفظ. أثناء التحقق، افحص كل توقيع وتأكد من وجود جميع الموقعين المطلوبين.

**ما صيغ العروض التي تدعم هذه العمليات؟**  
دعم Aspose.Slides عمليات التوقيع الرقمي الموضحة هنا يقتصر فقط على PPTX. صيغ العرض PPT و OpenDocument غير مدعومة في سير عمل API هذا.

**هل يمكنني إزالة توقيع دون التأثير على الشرائح؟**  
نعم. يمكنك إزالة توقيع واحد أو مسح المجموعة بالكامل ثم حفظ العرض. يبقى محتوى الشرائح متاحًا، لكن الملف المحفوظ لا يحمل دليل التوقيع المُزال.