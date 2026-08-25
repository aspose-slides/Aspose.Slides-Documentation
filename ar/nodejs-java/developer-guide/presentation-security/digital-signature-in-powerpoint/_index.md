---
title: إضافة توقيعات رقمية إلى العروض التقديمية في JavaScript
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/nodejs-java/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- سلطة شهادات
- شهادة PFX
- PKCS#12
- تحقق من التوقيع
- PowerPoint
- PPTX
- أمان العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية توقيع عروض PPTX الموجودة باستخدام شهادات PFX واستخدام Aspose.Slides لـ Node.js عبر Java للتحقق من صحة التوقيعات الرقمية أو إزالتها."
---
## **نظرة عامة**

تساعد التوقيع الرقمي المتلقي على تحديد من قام بالتوقيع على العرض التقديمي وما إذا كان المحتوى الموقَّع قد تغير. هناك ثلاثة مفاهيم أمنية ذات صلة مهمة هنا:

- **digital certificate** هو اعتماد إلكتروني يربط هوية بمفتاح عام. يمكن لسلطة شهادات موثوقة (CA) إصدار شهادة، أو يمكن للمنظمة استخدام شهادة موقعة ذاتيًا لتدفقات العمل الداخلية.
- **digital signature** يتم إنشاؤه من محتوى العرض ومفتاح خاص لحامل الشهادة. يمكن بعد ذلك استخدام المفتاح العام للشفرة للتحقق من التوقيع. يوفر التوقيع دليلًا على الأصل والنزاهة؛ ولا يقوم بتشفير العرض.
- **Password protection** يتحكم في ما إذا كان المستخدم يمكنه فتح أو تعديل العرض التقديمي. وهو منفصل عن التوقيع الرقمي ويُوصف في [Password-Protected Presentations](/slides/ar/nodejs-java/password-protected-presentation/).

تقدم PowerPoint أمر **Add a Digital Signature** ضمن **File > Info > Protect Presentation**.

![قائمة PowerPoint Protect Presentation مع تمييز Add a Digital Signature](add-digital-signature-in-powerpoint.png)

بعد فتح عرض موقَّع، يمكن لـ PowerPoint عرض إشعار بحالة التوقيع.

![إشعار PowerPoint يفيد بأن العرض يحتوي على توقيعات صالحة](digital-signature-status-in-powerpoint.png)

تُظهر Aspose.Slides التوقيعات عبر [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--)، التي تُعيد [DigitalSignatureCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignaturecollection/) يحتوي على كائنات [DigitalSignature](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignature/). يمكن للعرض أن يحتوي على عدة توقيعات.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا باسم ملف PKCS#12 وعادةً ما يحمل الامتداد `.pfx` أو `.p12`، يمكنه أن يحتوي على شهادة X.509، ومفتاحها الخاص، وسلسلة الشهادة. المفتاح الخاص هو ما يسمح للحامل بإنشاء توقيع. لا يمكن استخدام شهادة بدون مفتاح خاص متاح لتوقيع العرض.

كلمة مرور PFX تحمي حزمة الشهادة والمفتاح الخاص. هي **ليس** كلمة مرور لفتح أو تعديل العرض. لا تقم بارتكاب ملفات PFX أو كلمات مرورها إلى نظام التحكم في المصدر. في بيئة الإنتاج، قُم بتقليل إمكانية الوصول إلى ملف الشهادة واحصل على كلمة المرور من مخزن سري أو مصدر تكوين محمي آخر. الأمثلة أدناه تستخدم متغير بيئة فقط لتجنب تضمين كلمة المرور في الشيفرة.

## **إضافة توقيع رقمي إلى عرض تقديمي**

لتوقيع تدفق عمل عرض حقيقي، قم بتحميل ملف PPTX موجود، أنشئ [DigitalSignature](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة التوقيعات للعرض، واحفظه كملف PPTX.

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

حفظ النتيجة باسم جديد يحافظ على ملف المصدر غير الموقَّع. القيمة التي تحددها [DigitalSignature.setComments](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignature/) تصف هدف التوقيع؛ ولا تشكل تحكمًا أمنيًا.

## **التحقق من صحة التوقيعات الرقمية**

عند تحميل ملف PPTX موقَّع، افحص كل عنصر تُعيده [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). طريقة [DigitalSignature.isValid](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignature/) تشير إلى ما إذا كان التوقيع المضمّن صالحًا لمحتوى العرض الحالي.

المثال التالي يستخدم أيضًا فئة Node.js `X509Certificate` لقراءة اسم الموضوع من كل شهادة مضمَّنة.

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

نتيجة غير صالحة عادةً ما تعني أن محتوى العرض الموقَّع أو بيانات التوقيع تغيرت بعد التوقيع، أو أن الملف تضرر. إزالة جميع التوقيعات ينتج عرضًا غير موقَّع، لذا فحص صلاحية العناصر وحده غير كافٍ: يجب على تدفق عمل حساس أمنيًا أيضًا التحقق من عدد التوقيعات المتوقَّعة وهويات الموقِّعين المتوقعة.

يجب عدم اعتبار نتيجة الصلاحية قرارًا نهائيًا حول الثقة بالشهادة. وفقًا لسياستك الأمنية، قد تحتاج تطبيقك إلى بناء والتحقق من سلسلة شهادات X.509، فحص تواريخ صلاحية الشهادة وحالة الإبطال، تأكيد الموضوع أو البصمة المتوقعة، التحقق من استخدام المفتاح، وتقييم طابع زمني موثوق. القيمة التي تُعيدها [DigitalSignature.getSignTime](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignature/) وحدها ليست دليلًا من سلطة طابع زمني موثوقة.

## **إزالة التوقيعات الرقمية**

إزالة التوقيعات تغير حالة أمان العرض. المثال التالي يحمل ملف PPTX موقَّع، يزيل جميع التوقيعات باستخدام [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignaturecollection/clear/)، ويحفظ نسخة غير موقَّعة.

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

لإزالة توقيع واحد فقط، استدعِ [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) مع الفهرس الصفري الخاص به. احفظ إلى ملف جديد ما لم يكن استبدال الأصلي الموقَّع جزءًا صريحًا من تدفق عملك.

## **التحرير واعتبارات التنسيق**

- لا تجعل التوقيع العرض للقراءة فقط. لا يزال بإمكان المستخدمين والتطبيقات تعديل الملف، لكن التغييرات على المحتوى الموقَّع عادةً ما تُلغي التوقيع الموجود.
- أكمل جميع التعديلات المقصودة قبل التوقيع. إذا كان لابد من تعديل العرض، احفظ النسخة المعدَّلة ووقّع تلك النسخة مرة أخرى.
- احتفظ بالمخرجات النهائية بصيغة PPTX. تحويل عرض موقَّع إلى صيغة أخرى لا ينقل التوقيع الأصلي كـ توقيع صالح للملف المحوَّل.
- اعتبر المفتاح الخاص للشهادة حساسًا. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يتمكن من إنشاء توقيعات تبدو كما لو أنها صادرة من حامل الشهادة.
- احتفظ بالمصدر غير الموقَّع أو نسخة أخرى محكومة عندما تتطلب سياسة الاحتفاظ بالمستندات ذلك.

## **الأسئلة المتكررة**

**هل التوقيع الرقمي يشفر العرض التقديمي؟**

لا. التوقيع الرقمي يوفر دليلًا على الأصل والنزاهة، لكن محتوى العرض يظل قابلًا للقراءة ما لم يتم تطبيق تشفير منفصل. استخدم [password protection](/slides/ar/nodejs-java/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفسها كلمة مرور العرض التقديمي؟**

لا. كلمة مرور PFX تفتح المفتاح الخاص المخزن داخل حزمة الشهادة. لا تتحكم في من يمكنه فتح أو تعديل ملف PPTX.

**هل يمكنني استخدام شهادة موقعة ذاتيًا؟**

تقنيًا، يمكن استخدام شهادة موقعة ذاتيًا عندما تتضمن مفتاحًا خاصًا يمكن الوصول إليه. لن يثق المستقبلون بها تلقائيًا إلا إذا أُضيفت تلك الشهادة صراحةً إلى بيئتهم الموثوقة. عادةً ما تستخدم تدفقات العمل العامة أو عبر المنظمات شهادة صادرة عن CA موثوق.

**ما الذي يجعل التوقيع غير صالح؟**

تغيير محتوى العرض الموقَّع أو بيانات التوقيع بعد التوقيع قد يجعل التوقيع غير صالح. يمكن للتلف في الملف أيضًا أن يسبب فشل التحقق. إذا أزيلت جميع التوقيعات، يصبح العرض غير موقَّع وليس ملفًا يحتوي على توقيع غير صالح.

**هل يعني التوقيع الصالح أنني يجب أن أثق بالموقع؟**

ليس بمفرده. تكامل التوقيع وثقة الموقِّع قرارات منفصلة. يجب على سياسة التحقق في الإنتاج أيضًا فحص سلسلة الشهادة، فترة الصلاحية، حالة الإبطال، الهوية المتوقعة، استخدام المفتاح، وأي متطلبات طابع زمني موثوق.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض، لكنه يؤثر على تقييم الثقة بالشهادة. ما إذا كان التوقيع لا يزال مقبولًا يعتمد على سياستك وما إذا كان طابع زمني موثوق يُثبت أن التوقيع تم أثناء صلاحية الشهادة. لا تعتمد على وقت التوقيع المعروض وحده كطابع زمني موثوق.

**هل يمكن تعديل عرض موقَّع؟**

نعم. التوقيع لا يقفل الملف. عادةً ما يجعل تعديل المحتوى الموقَّع التوقيع الحالي غير صالح، لذا أكمل العرض أولًا ووقّع النسخة النهائية.

**هل يمكن للعرض أن يحتوي على أكثر من توقيع؟**

نعم. أضف كل توقيع إلى المجموعة التي تُعيدها [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) قبل الحفظ. أثناء التحقق، افحص كل توقيع وتأكد من وجود جميع الموقِّعين المطلوبين.

**أي صيغ عروض تدعم هذه العمليات؟**

تدعم Aspose.Slides عمليات التوقيع الرقمي الموضحة هنا فقط لـ PPTX. صيغ PPT وOpenDocument لا تدعمها هذه واجهة برمجة التطبيقات.

**هل يمكنني إزالة توقيع دون التأثير على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو مسح المجموعة بالكامل ثم حفظ العرض. تبقى محتويات الشرائح متاحة، لكن الملف المحفوظ لن يحمل دليل التوقيع المُزال.