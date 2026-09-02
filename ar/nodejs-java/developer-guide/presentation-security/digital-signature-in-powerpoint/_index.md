---
title: إضافة التوقيعات الرقمية إلى العروض التقديمية في جافا سكريبت
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/nodejs-java/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- سلطة شهادة
- شهادة PFX
- PKCS#12
- تحقق من صحة التوقيع
- PowerPoint
- PPTX
- أمان العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعرف على كيفية توقيع العروض التقديمية بصيغة PPTX الموجودة باستخدام شهادات PFX واستخدام Aspose.Slides لـ Node.js عبر Java للتحقق من صحة التوقيعات الرقمية أو إزالتها."
---
## **نظرة عامة**

تساعد التوقيع الرقمي المستلم على تحديد من وقع العرض التقديمي وما إذا كان المحتوى الموقع قد تغير. ثلاثة مفاهيم أمنية ذات صلة مهمة هنا:

- **شهادة رقمية** هي بيانات اعتماد إلكترونية تربط هوية بمفتاح عام. يمكن لسلطة شهادات موثوقة (CA) إصدار شهادة، أو يمكن للمنظمة استخدام شهادة موقعة ذاتياً لعمليات داخلية.
- **توقيع رقمي** يتم إنشاؤه من محتوى العرض التقديمي ومفتاح خاص لحامل الشهادة. يمكن بعد ذلك استخدام المفتاح العام للشهادة للتحقق من التوقيع. يوفر التوقيع دليلًا على الأصل والنزاهة؛ ولا يشفر العرض التقديمي.
- **حماية كلمة المرور** تتحكم في ما إذا كان المستخدم يستطيع فتح أو تعديل العرض التقديمي. وهي منفصلة عن التوقيع الرقمي وتُشرح في [Password-Protected Presentations](/nodejs-java/password-protected-presentation/).

يوفر PowerPoint الأمر **Add a Digital Signature** ضمن **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

بعد فتح عرض تقديمي موقع، يمكن لـ PowerPoint عرض إشعار بحالة التوقيع.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

تُعرِّف Aspose.Slides التوقيعات عبر [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--)، والتي تُعيد مجموعة [DigitalSignatureCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignaturecollection/) تحتوي على كائنات [DigitalSignature](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignature/). يمكن للعرض التقديمي أن يحتوي على توقيعات متعددة.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا بملف PKCS#12 وغالبًا ما يُعطى امتدادًا `.pfx` أو `.p12`، يمكن أن يحتوي على شهادة X.509، مفتاحها الخاص، وسلسلة الشهادات. المفتاح الخاص هو ما يسمح للحامل بإنشاء توقيع. لا يمكن استخدام شهادة بدون مفتاح خاص متاح لتوقيع عرض تقديمي.

تحمي كلمة مرور PFX حزمة الشهادة والمفتاح الخاص. إنها **ليست** كلمة مرور لفتح أو تحرير العرض التقديمي. لا تقم بارتكاب ملفات PFX أو كلمات مرورها إلى التحكم بالمصدر. في بيئة الإنتاج، حدِّد الوصول إلى ملف الشهادة واحصل على كلمة مروره من مخزن أسرار أو مصدر تكوين محمي آخر. الأمثلة أدناه تستخدم متغيّر بيئة فقط لتجنب تضمين كلمة المرور في الشيفرة.

## **إضافة توقيع رقمي إلى عرض تقديمي**

لتوقيع سير عمل عرض تقديمي حقيقي، قم بتحميل ملف PPTX موجود، أنشئ [DigitalSignature](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة التوقيعات للعرض التقديمي، ثم احفظه كملف PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

يحافظ حفظ النتيجة باسم جديد على ملف المصدر غير الموقع. القيمة التي تُحدَّد عبر [DigitalSignature.setComments](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignature/) تصف هدف التوقيع؛ وهي ليست تحكمًا أمنيًا.

## **التحقق من صحة التوقيعات الرقمية**

عند تحميل ملف PPTX موقع، افحص كل عنصر تُعيده [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). طريقة [DigitalSignature.isValid](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignature/) تُظهر ما إذا كان التوقيع المدمج صالحًا لمحتوى العرض التقديمي الحالي.

المثال التالي يستخدم أيضًا فئة Node.js `X509Certificate` لقراءة اسم الموضوع من كل شهادة مدمجة.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

نتيجة غير صالحة تعني عادةً أن محتوى العرض التقديمي الموقع أو بيانات التوقيع تغيرت بعد التوقيع، أو أن الملف تالف. إزالة جميع التوقيعات ينتج عنها عرض تقديمي غير موقع، لذا فحص صلاحية العناصر فقط لا يكفي: يجب على سير عمل حساس للأمان أيضًا التحقق من عدد التوقيعات المتوقع وهويات الموقعين المتوقعة.

يجب عدم اعتبار نتيجة الصلاحية قرارًا نهائيًا حول الثقة بالشهادة. وفقًا لسياسة الأمان الخاصة بك، قد يحتاج تطبيقك أيضًا إلى بناء والتحقق من سلسلة شهادة X.509، فحص تواريخ صلاحية الشهادة وحالة إلغائها، تأكيد الموضوع أو البصمة المتوقعة، التحقق من استخدام المفتاح، وتقييم طابع زمني موثوق. القيمة التي تُعيدها [DigitalSignature.getSignTime](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignature/) وحدها ليست دليلًا من سلطة طابع زمني موثوقة.

## **إزالة التوقيعات الرقمية**

إزالة التوقيعات تغير حالة أمان العرض التقديمي. المثال التالي يحمل ملف PPTX موقع، يزيل جميع التوقيعات عبر [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignaturecollection/clear/)، ويحفظ نسخة غير موقعّة.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لإزالة توقيع واحد فقط، استدعِ [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) مع فهرسه الصفري. احفظ إلى ملف جديد ما لم يكن استبدال الأصل الموقع جزءًا صريحًا من سير عملك.

## **التحرير والاعتبارات التنسيقية**

- التوقيع لا يجعل العرض التقديمي للقراءة فقط. لا يزال بإمكان المستخدمين والتطبيقات تحرير الملف، لكن أي تغيّر في المحتوى الموقع عادةً ما يبطل التوقيع الموجود.
- أكمل جميع التعديلات المقصودة قبل التوقيع. إذا كان لابد من تعديل العرض، احفظ النسخة المعدلة ووقعها مرة أخرى.
- احتفظ بالمخرجات النهائية بصيغة PPTX. تحويل عرض موقع إلى صيغة أخرى لا ينقل توقيع PPTX الأصلي كتوقيع صالح للملف المحوَّل.
- عالج المفتاح الخاص بالشهادة كعنصر حساس. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يتمكن من إنشاء توقيعات تبدو كأنها صادرة من حامل الشهادة.
- احتفظ بالمصدر غير الموقع أو نسخة مُتحكم بها عندما تتطلب سياسة الاحتفاظ بالمستندات ذلك.

## **الأسئلة المتكررة**

**هل التوقيع الرقمي يشفر العرض التقديمي؟**

لا. التوقيع الرقمي يقدّم دليلًا على الأصل والنزاهة، لكن محتوى العرض يبقى قابلًا للقراءة ما لم يُطبّق تشفير منفصل. استخدم [password protection](/nodejs-java/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفسها كلمة مرور العرض التقديمي؟**

لا. كلمة مرور PFX تُفتح المفتاح الخاص المخزن في حزمة الشهادة. لا تتحكم في من يمكنه فتح أو تحرير ملف PPTX.

**هل يمكنني استخدام شهادة موقعة ذاتيًا؟**

نظريًا، يمكن استخدام شهادة موقعة ذاتيًا إذا تضمّنها مفتاح خاص متاح. لن يثق المستلمون بها تلقائيًا إلا إذا أُضيفت تلك الشهادة صراحةً إلى بيئتهم الموثوقة. عادةً ما تستخدم عمليات العمل العامة أو عبر المؤسسات شهادة صادرة عن CA موثوق.

**ما الذي يجعل التوقيع غير صالح؟**

تغيير محتوى العرض الموقع أو بيانات التوقيع بعد التوقيع قد يبطل التوقيع. يمكن أن يتسبب تلف الملف أيضًا في فشل التحقق. إذا أزيل جميع التوقيعات، يصبح العرض غير موقع وليس ملفًا يحتوي على توقيع غير صالح.

**هل يعني التوقيع الصالح أنني يجب أن أثق بالموقع؟**

ليس بمفرده. صلاحية التوقيع وثقة الموقع قرارات منفصلة. يجب أن تتحقق سياسة التحقق في الإنتاج أيضًا من سلسلة الشهادة، فترة الصلاحية، حالة الإلغاء، الهوية المتوقعة، استخدام المفتاح، وأي متطلبات طابع زمني موثوق.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض، لكنه يؤثر على تقييم ثقة الشهادة. ما إذا كان التوقيع يظل مقبولًا يعتمد على سياستك وما إذا كان طابع زمني موثوق يُثبت أن التوقيع تم أثناء صلاحية الشهادة. لا تعتمد على وقت التوقيع المعروض كطابع زمني موثوق.

**هل يمكن تحرير عرض موقع؟**

نعم. التوقيع لا يقفل الملف. عادةً ما يجعل تحرير المحتوى الموقع التوقيع الحالي غير صالح، لذا أتمم العرض أولًا ووقع المراجعة النهائية.

**هل يمكن للعرض أن يحتوي على أكثر من توقيع؟**

نعم. أضف كل توقيع إلى المجموعة التي تُعيدها [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) قبل الحفظ. أثناء التحقق، افحص كل توقيع وتأكد من وجود جميع الموقعين المطلوبين.

**ما صيغ العروض التي تدعم هذه العمليات؟**

تدعم Aspose.Slides عمليات التوقيع الرقمي الموضحة هنا فقط لصيغة PPTX. صيغ PPT وOpenDocument للعرض لا تدعمها هذه واجهة برمجة التطبيقات.

**هل يمكنني إزالة توقيع دون التأثير على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو إفراغ المجموعة بالكامل ثم حفظ العرض. يظل محتوى الشرائح متاحًا، لكن الملف المحفوظ لن يحمل دليل التوقيع المُزال.