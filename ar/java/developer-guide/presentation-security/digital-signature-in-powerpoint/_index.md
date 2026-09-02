---
title: إضافة توقيعات رقمية للعروض في جافا
linktitle: توقيع رقمي
type: docs
weight: 10
url: /ar/java/digital-signature-in-powerpoint/
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
- جافا
- Aspose.Slides
description: "تعرف على كيفية توقيع عروض PPTX الحالية باستخدام شهادات PFX واستخدام Aspose.Slides لجافا للتحقق من أو إزالة التوقيعات الرقمية."
---
## **نظرة عامة**

تساعد التوقيع الرقمي المتلقي على معرفة من قام بتوقيع العرض وما إذا كان المحتوى الموقع قد تغير. هناك ثلاثة مفاهيم أمنية مرتبطة مهمة هنا:

- **الشهادة الرقمية** هي اعتماد إلكتروني يربط هوية بمفتاح عام. يمكن لسلطة شهادات موثوقة (CA) إصدار شهادة، أو يمكن للمؤسسة استخدام شهادة موقعة ذاتيًا لعمليات داخلية.
- **التوقيع الرقمي** يتم إنشاؤه من محتوى العرض والمفتاح الخاص لحامل الشهادة. يمكن بعد ذلك استخدام المفتاح العام للشهادة للتحقق من التوقيع. يوفر التوقيع دليلًا على الأصل والنزاهة؛ ولا يقوم بتشفير العرض.
- **حماية كلمة المرور** تتحكم فيما إذا كان المستخدم يستطيع فتح أو تعديل العرض. هي منفصلة عن التوقيع الرقمي وتُشرح في [العروض المحمية بكلمة مرور](/java/password-protected-presentation/).

توفر PowerPoint الأمر **Add a Digital Signature** تحت **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

بعد فتح عرض موقع، يمكن لـ PowerPoint عرض إشعار بحالة التوقيع.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

تُظهر Aspose.Slides التوقيعات من خلال [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getDigitalSignatures--)، والتي تُعيد [IDigitalSignatureCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignaturecollection/) يُطبق عناصره [IDigitalSignature](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignature/). يمكن للعرض أن يحتوي على توقيعات متعددة.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا بملف PKCS#12 وغالبًا ما يُعطى امتدادًا `.pfx` أو `.p12`، يمكن أن يحتوي على شهادة X.509، مفتاحها الخاص، وسلسلة الشهادات. المفتاح الخاص هو ما يسمح للحامل بإنشاء توقيع. لا يمكن استخدام شهادة بدون مفتاح خاص متاح لتوقيع عرض.

كلمة مرور PFX تحمي حزمة الشهادة والمفتاح الخاص. هي **لا** كلمة مرور لفتح أو تعديل العرض. لا تلتزم بملفات PFX أو كلمات مرورها في نظام التحكم بالمصادر. في الإنتاج، قُم بتقييد الوصول إلى ملف الشهادة واحصل على كلمة المرور من مخزن أسرار أو مصدر تكوين محمي آخر. الأمثلة أدناه تستخدم متغير بيئي فقط لتجنب تضمين كلمة المرور في الشيفرة.

## **إضافة توقيع رقمي إلى عرض**

لتوقيع سير عمل عرض حقيقي، حمل ملف PPTX موجود، أنشئ [DigitalSignature](https://reference.aspose.com/slides/ar/java/com.aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة التوقيعات في العرض، واحفظه كملف PPTX.

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

حفظ النتيجة باسم جديد يحافظ على ملف المصدر غير الموقع. القيمة التي تُحددها [IDigitalSignature.setComments](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) تصف هدف التوقيع؛ ليست آلية أمان.

## **التحقق من التوقيعات الرقمية**

عند تحميل ملف PPTX موقع، افحص كل عنصر تُعيده [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). تشير طريقة [IDigitalSignature.isValid](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignature/#isValid--) إلى ما إذا كان التوقيع المضمن صالحًا لمحتوى العرض الحالي.

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

النتيجة غير الصالحة عادةً تعني أن محتوى العرض الموقع أو بيانات التوقيع تغيرت بعد التوقيع، أو أن الملف تالف. إزالة كل توقيع ينتج عرضًا غير موقع، لذا فحص صلاحية العناصر فقط لا يكفي: يجب على سير عمل حساس أمنيًا أيضًا التحقق من وجود العدد المتوقع من التوقيعات وهويات المواقع المتوقعة.

يجب ألا يُعامل هذا نتيجة الصلاحية كقرار نهائي للثقة بالشهادة. بناءً على سياسة الأمان الخاصة بك، قد يحتاج تطبيقك أيضًا إلى بناء والتحقق من سلسلة شهادة X.509، فحص تواريخ صلاحية الشهادة وحالة إلغاءها، تأكيد الموضوع أو البصمة المتوقعة، التحقق من استخدام المفتاح، وتقييم ط timestamp موثوق. القيمة التي تُرجعها [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignature/#getSignTime--) بحد ذاتها ليست دليلًا من سلطة ط timestamp موثوقة.

## **إزالة التوقيعات الرقمية**

إزالة التوقيعات تغير حالة أمان العرض. يحمّل المثال التالي ملف PPTX موقع، يزيل جميع التوقيعات باستخدام [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignaturecollection/#clear--)، ويحفظ نسخة غير موقع.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لإزالة توقيع واحد فقط، استدعِ [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ar/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) مع فهرسه صفر‑أساسي. احفظ إلى ملف جديد ما لم يكن استبدال الأصلي الموقع جزءًا صريحًا من سير عملك.

## **التحرير واعتبارات الصيغة**

- لا يجعل التوقيع العرض للقراءة فقط. لا يزال بإمكان المستخدمين والتطبيقات تعديل الملف، لكن تغيّر المحتوى الموقع عادةً يبطل التوقيع الحالي.
- أكمل جميع التعديلات المقصودة قبل التوقيع. إذا كان لابد من تغيير العرض، احفظ النسخة المعدلة ووقّع تلك المراجعة مرة أخرى.
- احفظ الناتج النهائي بصيغة PPTX. تحويل عرض موقع إلى صيغة أخرى لا ينقل التوقيع الأصلي كـ توقيع صالح للملف المحول.
- اعتبر المفتاح الخاص بالشهادة حساسًا. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يتمكن من إنشاء توقيعات تبدو كأنها صادرة من حامل الشهادة.
- احتفظ بالمصدر غير الموقع أو نسخة خاضعة للرقابة عندما تتطلب سياسة الاحتفاظ بالمستندات ذلك.

## **الأسئلة المتكررة**

**هل التوقيع الرقمي يشفر العرض؟**

لا. يوفر التوقيع الرقمي دليلًا على الأصل والنزاهة، لكن يبقى محتوى العرض قابلًا للقراءة ما لم يتم تطبيق تشفير منفصل. استخدم [حماية كلمة المرور](/java/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفسها كلمة مرور العرض؟**

لا. كلمة مرور PFX تفتح المفتاح الخاص المخزن في حزمة الشهادة. لا تتحكم في من يمكنه فتح أو تحرير ملف PPTX.

**هل يمكنني استخدام شهادة موقعة ذاتيًا؟**

نعم، من الناحية التقنية يمكن استخدام شهادة موقعة ذاتيًا عندما تتضمن مفتاحًا خاصًا متاحًا. لكن المستقبلين لن يثقوا بها تلقائيًا ما لم تُضاف تلك الشهادة صراحةً إلى بيئتهم الموثوقة. عادةً ما تستخدم سير عمل عامة أو بين مؤسسات شهادة صادرة عن CA موثوق.

**ما الذي يجعل التوقيع غير صالح؟**

تغيير محتوى العرض الموقع أو بيانات التوقيع بعد التوقيع يمكن أن يبطل التوقيع. قد يسبب الفساد في الملف أيضًا فشل التحقق. إذا أزيلت جميع التوقيعات، يصبح العرض غير موقع بدلاً من كونه يحتوي على توقيع غير صالح.

**هل يعني التوقيع الصالح أنني يجب أن أثق بالموقع؟**

ليس بمفرده. تعتبر سلامة التوقيع وثقة الموقع قرارين منفصلين. يجب على سياسة التحقق في الإنتاج أن تشمل أيضًا فحص سلسلة الشهادة، فترة الصلاحية، حالة الإلغاء، الهوية المتوقعة، استخدام المفتاح، وأي متطلبات ط timestamp موثوقة.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض، لكنه يؤثر على تقييم الثقة بالشهادة. ما إذا كان التوقيع ما يزال مقبولًا يعتمد على سياستك وما إذا كان هناك ط timestamp موثوق يثبت أن التوقيع تم بينما كانت الشهادة صالحة. لا تعتمد على وقت التوقيع المعروض وحده كط timestamp موثوق.

**هل يمكن تعديل عرض موقع؟**

نعم. التوقيع لا يقفل الملف. عادةً ما يجعل تعديل المحتوى الموقع التوقيع الحالي غير صالح، لذا أكمل العرض أولًا ووقّع المراجعة النهائية.

**هل يمكن للعرض أن يحتوي على أكثر من توقيع؟**

نعم. أضف كل توقيع إلى المجموعة التي تُعيدها [IPresentation.getDigitalSignatures] قبل الحفظ. أثناء التحقق، افحص كل توقيع وتأكد من وجود جميع المواقع المطلوبة.

**ما صيغ العرض التي تدعم هذه العمليات؟**

تدعم Aspose.Slides عمليات التوقيع الرقمي الموضحة هنا فقط لصيغة PPTX. صيغ PPT وOpenDocument غير مدعومة في هذا التدفق البرمجي.

**هل يمكنني إزالة توقيع دون التأثير على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو إفراغ المجموعة بالكامل ثم حفظ العرض. يظل محتوى الشرائح متاحًا، لكن الملف المُحفظ لن يحمل دليل التوقيع المزال.