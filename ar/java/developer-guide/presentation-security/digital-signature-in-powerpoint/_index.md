---
title: إضافة توقيعات رقمية إلى العروض التقديمية في جافا
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/java/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- سلطة شهادة
- شهادة PFX
- PKCS#12
- تحقق من التوقيع
- PowerPoint
- PPTX
- أمان العرض التقديمي
- جافا
- Aspose.Slides
description: "تعلم كيفية توقيع عروض PPTX الموجودة باستخدام شهادات PFX واستخدام Aspose.Slides لجافا للتحقق من التوقيعات الرقمية أو إزالتها."
---
## **نظرة عامة**

التوقيع الرقمي يساعد المتلقي على تحديد من قام بتوقيع العرض التقديمي وما إذا كان المحتوى الموقع قد تغير. هناك ثلاثة مفاهيم أمنية ذات صلة مهمة هنا:

- **شهادة رقمية** هي اعتماد إلكتروني يربط هوية بمفتاح عام. يمكن لسلطة شهادة موثوقة (CA) إصدار شهادة، أو يمكن للمؤسسة استخدام شهادة ذاتية التوقيع لسير العمل الداخلي.
- **توقيع رقمي** يُنشأ من محتوى العرض التقديمي ومفتاح الخاص لحامل الشهادة. يمكن بعدها استخدام المفتاح العام للشهادة للتحقق من التوقيع. يوفر التوقيع دليلًا على المصدر والملاءمة؛ لكنه لا يشفر العرض التقديمي.
- **حماية كلمة المرور** تتحكم فيما إذا كان المستخدم يمكنه فتح أو تعديل العرض التقديمي. إنها منفصلة عن التوقيع الرقمي ومُوضحة في [العروض المحمية بكلمة مرور](/slides/ar/java/password-protected-presentation/).

يوفر PowerPoint أمر **إضافة توقيع رقمي** ضمن **ملف > معلومات > حماية العرض التقديمي**.

![قائمة حماية العرض التقديمي في PowerPoint مع تمييز إضافة توقيع رقمي](add-digital-signature-in-powerpoint.png)

بعد فتح عرض تقديمي موقع، يمكن لـ PowerPoint عرض إشعار حالة التوقيع.

![إشعار PowerPoint يوضح أن العرض التقديمي يحتوي على توقيعات صالحة](digital-signature-status-in-powerpoint.png)

تُظهر Aspose.Slides التوقيعات من خلال [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), التي تُعيد [IDigitalSignatureCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignaturecollection/), حيث تُنفّذ العناصر [IDigitalSignature](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignature/). يمكن للعرض التقديمي أن يحتوي على عدة توقيعات.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا بملف PKCS#12 وغالبًا ما يُعطى امتداد `.pfx` أو `.p12`، يمكن أن يحتوي على شهادة X.509، مفتاحها الخاص، وسلسلة الشهادات. المفتاح الخاص هو ما يسمح للحامل بإنشاء توقيع. لا يمكن استخدام شهادة بدون مفتاح خاص يمكن الوصول إليه لتوقيع عرض تقديمي.

كلمة مرور PFX تحمي حزمة الشهادة والمفتاح الخاص. هي **ليس** كلمة مرور لفتح أو تعديل العرض التقديمي. لا تُدرج ملفات PFX أو كلمات مرورها في نظام التحكم بالمصادر. في بيئة الإنتاج، قُم بتحديد وصول ملف الشهادة واحصل على كلمة المرور من مخزن أسرار أو مصدر تكوين محمي آخر. تستخدم الأمثلة أدناه متغيّر بيئة فقط لتجنب تضمين كلمة المرور في الشيفرة.

## **إضافة توقيع رقمي إلى عرض تقديمي**

لتوقيع عرض تقديمي حقيقي، احمل ملف PPTX موجود، أنشئ [DigitalSignature](https://reference.aspose.com/slides/ar/java/com.aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة العرض التقديمي، واحفظه كملف PPTX.

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

حفظ النتيجة باسم جديد يحافظ على ملف المصدر غير الموقع. القيمة التي تُعيّنها [IDigitalSignature.setComments](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) تصف غرض التوقيع؛ وهي ليست آلية أمان.

## **تحقق من التوقيعات الرقمية**

عند تحميل ملف PPTX موقع، افحص كل عنصر تُعيده [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). طريقة [IDigitalSignature.isValid](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignature/#isValid--) تُشير إلى ما إذا كان التوقيع المدمج صالحًا لمحتوى العرض التقديمي الحالي.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

عادةً ما يعني النتيجة غير الصالحة أن محتوى العرض التقديمي الموقع أو بيانات التوقيع تغيرت بعد التوقيع، أو أن الملف تالف. إزالة جميع التوقيعات ينتج عرضًا تقديميًا غير موقع، لذا فحص صلاحية العناصر فقط لا يكفي: يجب على سير عمل حساس للأمان أيضًا التحقق من وجود العدد المتوقع من التوقيعات وهويات الموقعين المتوقعة.

لا يجب اعتبار نتيجة الصلاحية هذه قرارًا كاملاً بخصوص ثقة الشهادة. بناءً على سياسة الأمان الخاصة بك، قد يحتاج تطبيقك أيضًا إلى بناء والتحقق من سلسلة شهادات X.509، فحص تواريخ صلاحية الشهادة وحالتها من الإلغاء، تأكيد الموضوع أو البصمة المتوقعة، التحقق من استخدام المفتاح، وتقييم طابع زمني موثوق. قيمة [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignature/#getSignTime--) بحد ذاتها ليست دليلًا من سلطة طابع زمني موثوقة.

## **إزالة التوقيعات الرقمية**

إزالة التوقيعات تغير حالة أمان العرض التقديمي. المثال التالي يحمل ملف PPTX موقع، يزيل جميع التوقيعات باستخدام [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignaturecollection/#clear--), ويحفظ نسخة غير موقعة.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لإزالة توقيع واحد فقط، استدعِ [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) مع فهرسه الذي يبدأ من صفر. احفظ إلى ملف جديد ما لم يكن استبدال الأصلي الموقع جزءًا صريحًا من سير عملك.

## **التحرير والاعتبارات المتعلقة بالتنسيق**

- لا يجعل التوقيع العرض التقديمي للقراءة فقط. يمكن للمستخدمين والتطبيقات تعديل الملف، لكن تغيّر المحتوى الموقع عادةً ما يُبطل التوقيع الحالي.
- أكمل جميع التعديلات المقصودة قبل التوقيع. إذا كان لابد من تغيير العرض، احفظ العرض المنقح ووقّع تلك النسخة مرة أخرى.
- احفظ الناتج النهائي بتنسيق PPTX. تحويل عرض موقع إلى تنسيق آخر لا ينقل التوقيع الأصلي للـ PPTX كتوقيع صالح للملف المحول.
- عالج المفتاح الخاص بالشهادة كقيمة حساسة. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يتمكن من إنشاء توقيعات تبدو كأنها من حامل الشهادة.
- احتفظ بالمصدر غير الموقع أو نسخة مُتحكم بها عندما تتطلب سياسة الاحتفاظ بالمستندات ذلك.

## **الأسئلة الشائعة**

**هل التوقيع الرقمي يشفر العرض التقديمي؟**

لا. التوقيع الرقمي يقدم دليلًا حول الأصل والملاءمة، لكن محتوى العرض يظل قابلاً للقراءة ما لم يُطبق تشفير منفصل. استخدم [حماية كلمة المرور](/slides/ar/java/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفس كلمة مرور العرض التقديمي؟**

لا. كلمة مرور PFX تفتح المفتاح الخاص المخزن في حزمة الشهادة. لا تتحكم في من يمكنه فتح أو تعديل ملف PPTX.

**هل يمكنني استخدام شهادة موقعة ذاتيًا؟**

من الناحية التقنية، يمكن استخدام شهادة موقعة ذاتيًا عندما تتضمن مفتاحًا خاصًا يمكن الوصول إليه. إلا أن المستلمين لن يثقوا بها تلقائيًا ما لم تُضاف تلك الشهادة صراحةً إلى بيئتهم الموثوقة. عادةً ما تستخدم سير عمل عامة أو بين المنظمات شهادة صادرة عن سلطة شهادة موثوقة.

**ما الذي يجعل التوقيع غير صالح؟**

تغيير محتوى العرض الموقع أو بيانات التوقيع بعد التوقيع يمكن أن يبطل التوقيع. كما أن فساد الملف قد يسبب فشل التحقق. إذا تمت إزالة جميع التوقيعات، يصبح العرض غير موقع بدلاً من كونه ملفًا يحتوي على توقيع غير صالح.

**هل يعني التوقيع الصالح أنني يجب أن أثق بالموقع؟**

ليس بذلك وحده. سلامة التوقيع وثقة الموقع قرارات منفصلة. يجب أن تتحقق سياسة التحقق في الإنتاج أيضًا من سلسلة الشهادة، فترة الصلاحية، حالة الإلغاء، الهوية المتوقعة، استخدام المفتاح، وأي متطلبات لطابع زمني موثوق.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض التقديمي، لكنه يؤثر على تقييم الثقة بالشهادة. ما إذا كان التوقيع ما زال مقبولًا يعتمد على سياستك وما إذا كان طابع زمني موثوق صالح يُثبت أن التوقيع حدث بينما كانت الشهادة صالحة. لا تعتمد على وقت التوقيع المعروض فقط كطابع زمني موثوق.

**هل يمكن تحرير عرض موقّع؟**

نعم. التوقيع لا يقفل الملف. عادةً ما يؤدي تحرير المحتوى الموقع إلى إبطال التوقيع الحالي، لذا أكمل العرض أولاً ووقّع النسخة النهائية.

**هل يمكن للعرض التقديمي أن يحتوي على أكثر من توقيع؟**

نعم. أضف كل توقيع إلى المجموعة التي تُعيدها [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) قبل الحفظ. أثناء التحقق، افحص كل توقيع وتأكد من وجود جميع الموقعين المطلوبين.

**ما هي صيغ العروض التقديمية التي تدعم هذه العمليات؟**

يدعم Aspose.Slides عمليات التوقيع الرقمي الموضحة هنا فقط لصيغة PPTX. ولا تُدعم صيغ PPT وOpenDocument للعرض التقديمي في سير عمل هذا API.

**هل يمكنني إزالة توقيع دون التأثير على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو مسح المجموعة بالكامل ثم حفظ العرض. يبقى محتوى الشرائح متاحًا، لكن الملف المحفوظ لا يحمل دليل التوقيع الذي تمت إزالته.