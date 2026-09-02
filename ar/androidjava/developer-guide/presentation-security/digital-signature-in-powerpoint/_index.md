---
title: إضافة توقيعات رقمية إلى العروض على Android
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/androidjava/digital-signature-in-powerpoint/
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
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية توقيع عروض PPTX الحالية باستخدام شهادات PFX واستخدام Aspose.Slides لنظام Android عبر Java للتحقق من التوقيعات الرقمية أو إزالتها."
---
## **نظرة عامة**

تساعد التوقيع الرقمي المستلم على تحديد من قام بتوقيع العرض وما إذا كان المحتوى الموقع قد تغير. هناك ثلاثة مفاهيم أمنية ذات صلة مهمة هنا:

- شهادة **رقمية** هي اعتماد إلكتروني يربط هوية بمفتاح عام. يمكن لسلطة شهادات موثوقة (CA) إصدار شهادة، أو يمكن للمنظمة استخدام شهادة موقعة ذاتيًا لتدفقات العمل الداخلية.
- **التوقيع الرقمي** يُنشأ من محتوى العرض ومفتاح الخصوصية لحامل الشهادة. يمكن بعد ذلك استخدام المفتاح العام للشهادة للتحقق من التوقيع. يوفر التوقيع دليلًا على الأصل والنزاهة؛ ولا يقوم بتشفير العرض.
- **حماية كلمة المرور** تتحكم فيما إذا كان المستخدم يمكنه فتح أو تعديل العرض. هي منفصلة عن التوقيع الرقمي وتُشرح في [العروض المحمية بكلمة مرور](/androidjava/password-protected-presentation/).

PowerPoint يوفر أمر **Add a Digital Signature** ضمن **File > Info > Protect Presentation**.

![قائمة Protect Presentation في PowerPoint مع تمييز Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

بعد فتح عرض موقع، يمكن لPowerPoint عرض إشعار بحالة التوقيع.

![إشعار PowerPoint يوضح أن العرض يحتوي على توقيعات صالحة](digital-signature-status-in-powerpoint.png)

Aspose.Slides يعرّف التوقيعات من خلال [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--)، والذي يُعيد مجموعة [IDigitalSignatureCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigitalsignaturecollection/) تتضمن عناصر تُطبّق [IDigitalSignature](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigiticsignature/). يمكن للعرض أن يحتوي على توقيعات متعددة.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا بملف PKCS#12 وغالبًا ما يحمل امتداد `.pfx` أو `.p12`، يمكن أن يحتوي على شهادة X.509، مفتاحها الخاص، وسلسلة الشهادة. المفتاح الخاص هو ما يسمح للحامل بإنشاء توقيع. شهادة بدون مفتاح خاص متاح لا يمكن استخدامها لتوقيع عرض.

كلمة مرور PFX تحمي حزمة الشهادة والمفتاح الخاص. هي **ليس** كلمة مرور لفتح أو تحرير العرض. لا تُدمج ملفات PFX أو كلمات مرورها في نظام التحكم بالمصادر. في بيئة الإنتاج، حدّ الوصول إلى ملف الشهادة واحصل على كلمة المرور من مخزن أسرار أو مصدر تكوين محمي آخر. الأمثلة أدناه تستخدم متغيّر بيئة فقط لتجنب إدراج كلمة المرور في الشيفرة.

## **إضافة توقيع رقمي إلى عرض**

لتوقيع سير عمل عرض حقيقي، حمّل ملف PPTX موجود، أنشئ كائن [DigitalSignature](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة العرض، واحفظه كملف PPTX.

```java
import com.aspose.slides.*;

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

حفظ النتيجة باسم جديد يحافظ على الملف الأصلي غير الموقع. القيمة التي تُحدّدها الطريقة [IDigitalSignature.setComments](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) تصف هدف التوقيع؛ وهي ليست عنصر تحكم أمني.

## **التحقق من التوقيعات الرقمية**

عند تحميل ملف PPTX موقع، افحص كل عنصر تُعيده الطريقة [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). الطريقة [IDigitalSignature.isValid](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigitalsignature/#isValid--) تُظهر ما إذا كان التوقيع المدمج صالحًا لمحتوى العرض الحالي.

```java
import com.aspose.slides.*;

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

عادةً ما يعني النتيجة غير الصالحة أن محتوى العرض الموقع أو بيانات التوقيع قد تغيّرت بعد التوقيع، أو أن الملف تالف. إزالة كل توقيع تُنتج عرضًا غير موقع، لذا فحص صلاحية العناصر وحده غير كافٍ: يجب على سير عمل حساس أمني أيضًا التحقق من وجود عدد التوقيعات المتوقع وهوية المُوقعين المتوقعة.

هذه النتيجة لا يجب أن تُعامل كقرار نهائي بثقة الشهادة. بناءً على سياستك الأمنية، قد يحتاج تطبيقك أيضًا إلى بناء والتحقق من سلسلة شهادات X.509، فحص تواريخ صلاحية الشهادة وحالة الإبطال، التأكد من الموضوع أو البصمة المتوقعة، التحقق من استخدام المفتاح، وتقييم طابع زمني موثوق. قيمة [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) وحدها ليست دليلًا من سلطة طوابع زمنية موثوقة.

## **إزالة التوقيعات الرقمية**

إزالة التوقيعات تغيّر حالة أمان العرض. المثال التالي يحمل ملف PPTX موقع، يزيل كل التوقيعات باستخدام [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--)، ويحفظ نسخة غير موقعّة.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لإزالة توقيع واحد فقط، استدعِ الطريقة [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) مع فهرسها الصفري القائم. احفظ إلى ملف جديد ما لم يكن استبدال الملف الأصلي الموقع جزءًا صريحًا من سير عملك.

## **التحرير واعتبارات التنسيق**

- التوقيع لا يجعل العرض للقراءة فقط. لا يزال بإمكان المستخدمين والتطبيقات تعديل الملف، لكن أي تغيّر في المحتوى الموقع عادةً ما يبطل التوقيع الحالي.
- أكمل جميع التعديلات المطلوبة قبل التوقيع. إذا كان لابد من تعديل العرض، احفظ النسخة المعدلة ووقّع تلك النسخة مرة أخرى.
- احتفظ بالإخراج النهائي بصيغة PPTX. تحويل عرض موقع إلى صيغة أخرى لا ينقل التوقيع الأصلي ك توقيع صالح للملف المحوّل.
- عامِل المفتاح الخاص بالشهادة كأمر حساس. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يتمكن من إنشاء توقيعات تبدو كأنها صادرة من حامل تلك الشهادة.
- احتفظ بالمصدر غير الموقع أو نسخة خاضعة للرقابة عندما تتطلب سياسة الاحتفاظ بالمستندات ذلك.

## **الأسئلة المتكررة**

**هل التوقيع الرقمي يشفر العرض؟**

لا. التوقيع الرقمي يقدّم دليلًا على الأصل والنزاهة، لكن محتوى العرض يظل قابلاً للقراءة ما لم يُطبق تشفير منفصل. استخدم [حماية كلمة المرور](/androidjava/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفسها كلمة مرور العرض؟**

لا. كلمة مرور PFX تفتح المفتاح الخاص المخزن في حزمة الشهادة. لا تتحكم في من يمكنه فتح أو تحرير ملف PPTX.

**هل يمكنني استخدام شهادة موقعة ذاتيًا؟**

تقنيًا، يمكن استخدام شهادة موقعة ذاتيًا عندما تتضمن مفتاحًا خاصًا متاحًا. لكن المتلقين لن يثقوا بها تلقائيًا ما لم تُضاف تلك الشهادة صراحةً إلى بيئتهم الموثوقة. عادةً ما تستخدم سير عمل عامة أو عبر مؤسسات شهادة صادرة من سلطة شهادات موثوقة.

**ما الذي يجعل التوقيع غير صالح؟**

تغيير محتوى العرض الموقع أو بيانات التوقيع بعد التوقيع يمكن أن يبطل التوقيع. كما قد يتسبب تلف الملف في فشل التحقق. إذا أزيلت جميع التوقيعات، يصبح العرض غير موقعًا بدلًا من احتوائه على توقيع غير صالح.

**هل يعني التوقيع الصالح أنني يجب أن أثق بالموقع؟**

ليس بمفرده. سلامة التوقيع وثقة الموقع قراران منفصلان. يجب على سياسة التحقق في الإنتاج أيضًا فحص سلسلة الشهادة، فترة الصلاحية، حالة الإبطال، الهوية المتوقعة، استخدام المفتاح، وأي متطلبات طابع زمني موثوق.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض، لكنه يؤثر على تقييم ثقة الشهادة. ما إذا كان التوقيع ما يزال مقبولًا يعتمد على سياستك وما إذا كان هناك طابع زمني موثوق يثبت أن التوقيع تم حين كانت الشهادة صالحة. لا تعتمد على وقت التوقيع المعروض فقط كطابع زمني موثوق.

**هل يمكن تعديل عرض موقع؟**

نعم. التوقيع لا يقفل الملف. تعديل المحتوى الموقع عادةً ما يبطل التوقيع الحالي، لذا أكمل العرض ثم وقع المراجعة النهائية.

**هل يمكن للعرض أن يحتوي على أكثر من توقيع واحد؟**

نعم. أضف كل توقيع إلى المجموعة التي تُعيدها الطريقة [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) قبل الحفظ. أثناء التحقق، افحص كل توقيع وتأكد من وجود جميع الموقعين المطلوبين.

**ما هي صيغ العروض التي تدعم هذه العمليات؟**

Aspose.Slides يدعم عمليات التوقيع الرقمي الموضحة هنا فقط لصيغة PPTX. صيغ PPT وOpenDocument لا تدعمها واجهة برمجة التطبيقات هذه.

**هل يمكنني إزالة توقيع دون التأثير على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو مسح المجموعة بالكامل ثم حفظ العرض. يظل محتوى الشرائح متاحًا، لكن الملف المحفوظ لم يعد يحمل دليل التوقيع المُزال.