---
title: إضافة توقيعات رقمية إلى العروض التقديمية على Android
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/androidjava/digital-signature-in-powerpoint/
keywords:
- توقيع رقمي
- شهادة رقمية
- سلطة شهادة
- شهادة PFX
- PKCS#12
- تحقق من التوقيع
- PowerPoint
- PPTX
- أمان العرض
- Android
- Java
- Aspose.Slides
description: "تعرّف على كيفية توقيع العروض التقديمية بصيغة PPTX الموجودة باستخدام شهادات PFX واستخدام Aspose.Slides لنظام Android عبر Java للتحقق من التوقيعات الرقمية أو إزالتها."
---
## **نظرة عامة**

يساعد التوقيع الرقمي المستلم على تحديد من قام بتوقيع العرض وما إذا كان المحتوى الموقع قد تغير. هناك ثلاثة مفاهيم أمنية ذات صلة مهمة هنا:

- **الشهادة الرقمية** هي اعتماد إلكتروني يربط هوية بمفتاح عام. يمكن لسلطة شهادة موثوقة (CA) إصدار شهادة، أو يمكن للمؤسسة استخدام شهادة موقعة ذاتيًا للعمليات الداخلية.
- **التوقيع الرقمي** يتم إنشاؤه من محتوى العرض والمفتاح الخاص لحامل الشهادة. يمكن بعد ذلك استخدام المفتاح العام للشهادة للتحقق من التوقيع. يوفر التوقيع دليلًا على الأصل والاكتمال؛ لكنه لا يشفر العرض.
- **حماية كلمة المرور** تتحكم فيما إذا كان المستخدم يمكنه فتح أو تعديل العرض. هي منفصلة عن التوقيع الرقمي وتُوصف في [العروض المحمية بكلمة مرور](/slides/ar/androidjava/password-protected-presentation/).

يقدم PowerPoint أمر **Add a Digital Signature** ضمن **File > Info > Protect Presentation**.

![قائمة Protect Presentation في PowerPoint مع تمييز Add a Digital Signature](add-digital-signature-in-powerpoint.png)

بعد فتح عرض موقع، يمكن لـ PowerPoint عرض إشعار بحالة التوقيع.

![إشعار PowerPoint يوضح أن العرض يحتوي على توقيعات صالحة](digital-signature-status-in-powerpoint.png)

تُظهر Aspose.Slides التوقيعات عبر [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--)، الذي يُعيد [IDigitalSignatureCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigitalsignaturecollection/) التي تُنفّذ عناصرها [IDigitalSignature](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigitalsignature/). يمكن للعرض أن يحتوي على عدة توقيعات.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا بملف PKCS#12 وغالبًا ما يحمل الامتداد `.pfx` أو `.p12`، يمكن أن يحتوي على شهادة X.509، المفتاح الخاص بها، وسلسلة الشهادات. المفتاح الخاص هو ما يسمح للحامل بإنشاء توقيع. لا يمكن استخدام شهادة بدون مفتاح خاص متاح لتوقيع العرض.

كلمة مرور PFX تحمي حزمة الشهادة والمفتاح الخاص. وهي **ليست** كلمة مرور لفتح أو تحرير العرض. لا تُدرج ملفات PFX أو كلمات مرورها في نظام التحكم في الإصدارات. في بيئات الإنتاج، قُم بتقييد الوصول إلى ملف الشهادة واحصل على كلمة المرور من مخزن أسرار أو مصدر تكوين محمي آخر. الأمثلة أدناه تستخدم متغيّر بيئة فقط لتجنب تضمين كلمة المرور في الشيفرة.

## **إضافة توقيع رقمي إلى عرض**

لتوقيع تدفق عمل عرض حقيقي، قم بتحميل ملف PPTX موجود، أنشئ كائن [DigitalSignature](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة التوقيعات في العرض، واحفظه كملف PPTX.

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

حفظ النتيجة باسم جديد يحافظ على الملف المصدر غير الموقع. القيمة التي تُحددها [IDigitalSignature.setComments](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) تصف غرض التوقيع؛ فهي ليست آلية أمنية.

## **التحقق من التوقيعات الرقمية**

عند تحميل ملف PPTX موقع، فحص كل عنصر تُعيده [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). الطريقة [IDigitalSignature.isValid](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigitalsignature/#isValid--) تُشير إلى ما إذا كان التوقيع المضمن صالحًا لمحتوى العرض الحالي.

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

نتيجة غير صالحة تعني عادةً أن محتوى العرض الموقع أو بيانات التوقيع تغيرت بعد التوقيع، أو أن الملف تالف. إزالة كل التوقيعات تُنتج عرضًا غير موقع، لذا فحص صلاحية العناصر وحده غير كافٍ: يجب على تدفق العمل الحساس أمانًا أيضًا التحقق من أن العدد المتوقع من التوقيعات والهويات المتوقعة للموقعين موجودة.

يجب ألا يُعامل هذا النتيجة كقرار نهائي بثقة الشهادة. وفقًا لسياسة الأمان الخاصة بك، قد تحتاج تطبيقك أيضًا إلى بناء والتحقق من سلسلة شهادات X.509، فحص تواريخ صلاحية الشهادة وحالة الإلغاء، التأكد من الموضوع أو البصمة المتوقعة، التحقق من استخدام المفتاح، وتقييم طابع زمني موثوق. القيمة [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) بمفردها ليست دليلًا من سلطة طوابع زمنية موثوقة.

## **إزالة التوقيعات الرقمية**

إزالة التوقيعات تُغيّر حالة أمان العرض. المثال التالي يحمل ملف PPTX موقع، يزيل جميع التوقيعات باستخدام [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--)، ويحفظ نسخة غير موقعه.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

لإزالة توقيع واحد فقط، استدعِ [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) مع الفهرس الصفري الخاص به. احفظ إلى ملف جديد ما لم يكن استبدال الملف الأصلي الموقع جزءًا صريحًا من تدفق عملك.

## **اعتبارات التحرير والصياغة**

- لا يجعل التوقيع العرض للقراءة فقط. لا يزال بإمكان المستخدمين والتطبيقات تحرير الملف، لكن تغيّر المحتوى الموقع عادةً ما يُلغي التوقيع الحالي.
- أكمل جميع التعديلات المقصودة قبل التوقيع. إذا كان يجب تعديل العرض، احفظ النسخة المعدلة ووقعها مرة أخرى.
- احتفظ بالمخرج النهائي بصيغة PPTX. تحويل عرض موقع إلى صيغة أخرى لا ينقل توقيع PPTX الأصلي كتوقيع صالح للملف المحوَّل.
- اعتبر المفتاح الخاص بالشهادة حساسًا. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يتمكن من إنشاء توقيعات تبدو كأنها صادرة عن حامل الشهادة.
- احفظ المصدر غير الموقع أو نسخة مُتحكم بها عندما تتطلب سياسة الاحتفاظ بالمستندات ذلك.

## **الأسئلة الشائعة**

**هل يشفّر التوقيع الرقمي العرض؟**

لا. التوقيع الرقمي يُقدم دليلًا حول الأصل والاكتمال، لكن محتوى العرض يظل قابلًا للقراءة ما لم يتم تطبيق تشفير منفصل. استخدم [حماية كلمة المرور](/slides/ar/androidjava/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفسها كلمة مرور العرض؟**

لا. كلمة مرور PFX تُفتح المفتاح الخاص المخزن في حزمة الشهادة. وهي لا تتحكم في من يمكنه فتح أو تحرير ملف PPTX.

**هل يمكنني استخدام شهادة موقعة ذاتيًا؟**

تقنيًا، يمكن استخدام شهادة موقعة ذاتيًا إذا كانت تتضمن مفتاحًا خاصًا متاحًا. المستلمون لن يثقوا بها تلقائيًا إلا إذا تم إضافة الشهادة صراحةً إلى بيئتهم الموثوقة. عادةً ما تستخدم سير عمل عامة أو عبر مؤسسات شهادة صادرة عن CA موثوق.

**ما الذي يجعل التوقيع غير صالح؟**

تغيّر محتوى العرض الموقع أو بيانات التوقيع بعد التوقيع يمكن أن يُلغي صلاحية التوقيع. الفساد في الملف قد يتسبب أيضًا في فشل التحقق. إذا أزيلت جميع التوقيعات، يصبح العرض غير موقع وليس ملفًا يحتوي على توقيع غير صالح.

**هل يعني التوقيع الصالح أنني يجب أن أثق بالموقع؟**

ليس بمفرده. صحة التوقيع وثقة الموقع قراران منفصلان. يجب أن تتضمن سياسة التحقق في الإنتاج فحص سلسلة الشهادات، فترة الصلاحية، حالة الإلغاء، الهوية المتوقعة، استخدام المفتاح، وأي متطلبات طوابع زمنية موثوقة.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض، لكنه يؤثر على تقييم ثقة الشهادة. ما إذا كان التوقيع ما يزال مقبولًا يعتمد على سياستك وما إذا كان هناك طابع زمني موثوق يثبت أن التوقيع تم أثناء صلاحية الشهادة. لا تعتمد على وقت التوقيع المعروض فقط كطابع زمني موثوق.

**هل يمكن تحرير عرض موقع؟**

نعم. التوقيع لا يقفل الملف. عادةً ما يجعل تحرير المحتوى الموقع التوقيع الحالي غير صالح، لذا أكمل العرض أولًا ووقّع النسخة النهائية.

**هل يمكن للعرض أن يحتوي على أكثر من توقيع؟**

نعم. أضف كل توقيع إلى المجموعة التي تُعيدها [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) قبل الحفظ. أثناء التحقق، فحص كل توقيع وتأكد من وجود جميع الموقعين المطلوبين.

**ما صيغ العروض التي تدعم هذه العمليات؟**

تدعم Aspose.Slides عمليات التوقيع الرقمي الموضحة هنا فقط لصيغة PPTX. صيغ PPT وOpenDocument غير مدعومة في هذا التدفق العملي للواجهة البرمجية.

**هل يمكنني إزالة توقيع دون التأثير على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو مسح كامل المجموعة ثم حفظ العرض. تظل محتويات الشرائح موجودة، لكن الملف المحفوظ لن يحمل دليل التوقيع المُزال.