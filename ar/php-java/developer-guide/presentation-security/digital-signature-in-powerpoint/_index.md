---
title: إضافة توقيع رقمي إلى العروض التقديمية في PHP
linktitle: التوقيع الرقمي
type: docs
weight: 10
url: /ar/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "تعلم كيف تقوم بتوقيع عروض PPTX الحالية باستخدام شهادات PFX واستخدام Aspose.Slides للـ PHP عبر Java للتحقق من التواقيع الرقمية أو إزالتها."
---
## **نظرة عامة**

تساعد التوقيع الرقمي المستقبل على تحديد من قام بتوقيع العرض التقديمي وما إذا كان المحتوى الموقع قد تغير. هناك ثلاثة مفاهيم أمنية مرتبطة مهمة هنا:

- **الشهادة الرقمية** هي اعتماد إلكتروني يربط هوية بمفتاح عام. يمكن لسلطة شهادة موثوقة (CA) إصدار شهادة، أو يمكن للمؤسسة استخدام شهادة موقعة ذاتيًا لعمليات العمل الداخلية.
- **التوقيع الرقمي** يتم إنشاؤه من محتوى العرض التقديمي ومفتاح الخصوصية الخاص بحامل الشهادة. يمكن بعد ذلك استخدام المفتاح العام للشهادة للتحقق من التوقيع. يوفر التوقيع دليلًا على الأصل والنزاهة؛ ولا يقوم بتشفير العرض التقديمي.
- **حماية كلمة المرور** تتحكم في ما إذا كان المستخدم يستطيع فتح أو تعديل العرض التقديمي. هي منفصلة عن التوقيع الرقمي وتُكتب في [العروض المحمية بكلمة مرور](/slides/ar/php-java/password-protected-presentation/).

يوفر PowerPoint أمر **Add a Digital Signature** ضمن **File > Info > Protect Presentation**.

![قائمة Protect Presentation في PowerPoint مع تمييز Add a Digital Signature](add-digital-signature-in-powerpoint.png)

بعد فتح عرض تقديمي موقع، يمكن لـ PowerPoint عرض إشعار بحالة التوقيع.

![إشعار PowerPoint يوضح أن العرض يحتوي على توقيعات صالحة](digital-signature-status-in-powerpoint.png)

تكشف Aspose.Slides التواقيع عبر [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getDigitalSignatures)، والتي تُعيد مجموعة [DigitalSignatureCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignaturecollection/) يُمثل عناصرها ككائنات [DigitalSignature](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignature/). يمكن للعرض التقديمي أن يحتوي على توقيعات متعددة.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا بملف PKCS#12 وعادةً ما يكون امتداده `.pfx` أو `.p12`، يمكن أن يحتوي على شهادة X.509، ومفتاحها الخاص، وسلسلة الشهادات. المفتاح الخاص هو ما يسمح للحامل بإنشاء توقيع. لا يمكن استخدام شهادة بدون مفتاح خاص يمكن الوصول إليه لتوقيع عرض تقديمي.

كلمة مرور PFX تحمي حزمة الشهادة والمفتاح الخاص. هي **ليس** كلمة مرور لفتح أو تحرير العرض التقديمي. لا تقم بإيداع ملفات PFX أو كلمات مرورها في نظام التحكم بالمصادر. في بيئة الإنتاج، قصر الوصول إلى ملف الشهادة واحصل على كلمة مروره من مخزن أسرار أو مصدر إعداد محمي آخر. الأمثلة أدناه تستخدم متغير بيئة فقط لتجنب تضمين كلمة المرور في الشيفرة.

## **إضافة توقيع رقمي إلى عرض تقديمي**

للتوقيع خلال سير عمل عرض تقديمي حقيقي، حمّل ملف PPTX موجود، أنشئ كائن [DigitalSignature](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة العرض التقديمي، واحفظه كملف PPTX.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

حفظ النتيجة باسم جديد يحافظ على ملف المصدر غير الموقع. القيم التي تُعيّن عبر [DigitalSignature::setComments](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignature/setcomments/) تصف هدف التوقيع؛ ولا تشكل تحكمًا أمنياً.

## **التحقق من التواقيع الرقمية**

عند تحميل ملف PPTX موقع، فحص كل عنصر تُعيده [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getDigitalSignatures). تُظهر طريقة [DigitalSignature::isValid](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignature/isvalid/) ما إذا كان التوقيع المضمّن صالحًا لمحتوى العرض الحالي.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

غالبًا ما يعني نتيجة غير صالحة أن محتوى العرض أو بيانات التوقيع تغيرت بعد التوقيع، أو أن الملف تالف. إزالة كل توقيع تُنتج عرضًا غير موقع، لذا فإن فحص صلاحية العناصر فقط لا يكفي: يجب على سير عمل حساس أمنيًا أيضًا التحقق من عدد التواقيع المتوقع وهوية الموقعين المتوقعة.

يجب ألا تُعامل نتيجة الصلاحية كقرار نهائي للثقة بالشهادة. بناءً على سياسة الأمان الخاصة بك، قد تحتاج تطبيقك أيضًا إلى بناء والتحقق من سلسلة شهادة X.509، وفحص تواريخ صلاحية الشهادة وحالة الإبطال، وتأكيد الموضوع أو البصمة المتوقعة، والتحقق من استخدام المفتاح، وتقييم الطابع الزمني الموثوق. قيمة [DigitalSignature::getSignTime](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignature/getsigntime/) وحدها ليست دليلًا من سلطة طابع زمني موثوقة.

## **إزالة التواقيع الرقمية**

إزالة التواقيع تغير حالة أمان العرض التقديمي. المثال التالي يحمل ملف PPTX موقع، يزيل جميع التواقيع عبر [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignaturecollection/clear/)، ويحفظ نسخة غير موقعة.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

لإزالة توقيع واحد فقط، استدعِ [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignaturecollection/removeat/) مع الفهرس الصفري الخاص به. احفظ إلى ملف جديد ما لم يكن الكتابة فوق الأصلي الموقع جزءًا صريحًا من سير عملك.

## **التحرير والاعتبارات التنسيقية**

- لا يجعل التوقيع العرض التقديمي للقراءة فقط. لا يزال بإمكان المستخدمين والتطبيقات تعديل الملف، لكن تغيّر المحتوى الموقع عادةً ما يبطل التوقيع الحالي.
- أكمل جميع التعديلات المقصودة قبل التوقيع. إذا كان لابد من تعديل العرض، احفظ النسخة المعدلة ووقع تلك النسخة مرة أخرى.
- احتفظ بالمخرجات النهائية بصيغة PPTX. تحويل عرض موقع إلى صيغة أخرى لا ينقل التوقيع الأصلي كتوقيع صالح للملف المحوّل.
- اعتبر المفتاح الخاص بالشهادة حسّاسًا. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يتمكن من إنشاء توقيعات تظهر كأنها صادرة من حامل الشهادة.
- احتفظ بالمصدر غير الموقع أو نسخة مدارة أخرى عندما تتطلب سياسة الاحتفاظ بالمستندات ذلك.

## **الأسئلة الشائعة**

**هل يُشفّر التوقيع الرقمي العرض التقديمي؟**

لا. يوفر التوقيع الرقمي دليلًا على الأصل والنزاهة، لكن يبقى محتوى العرض قابلًا للقراءة ما لم يُطبق تشفير منفصل. استخدم [حماية كلمة المرور](/slides/ar/php-java/password-protected-presentation/) عندما يلزم تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفسها كلمة مرور العرض التقديمي؟**

لا. كلمة مرور PFX تفتح المفتاح الخاص المخزن في حزمة الشهادة. لا تتحكم في من يمكنه فتح أو تحرير ملف PPTX.

**هل يمكنني استخدام شهادة موقعة ذاتيًا؟**

من الناحية التقنية، يمكن استخدام شهادة موقعة ذاتيًا إذا احتوت على مفتاح خاص يمكن الوصول إليه. لن يثق المستلم بها تلقائيًا إلا إذا أضيفت الشهادة صراحةً إلى بيئته الموثوقة. عادةً ما تستخدم سير عمل عامة أو عبر مؤسسات شهادة صادرة عن CA موثوق.

**ما الذي يجعل التوقيع غير صالح؟**

تغيير محتوى العرض الموقع أو بيانات التوقيع بعد التوقيع يمكن أن يبطل التوقيع. قد يتسبب فساد الملف أيضًا في فشل التحقق. إذا أزيلت كل التواقيع، يصبح العرض غير موقع وليس ملفًا يحتوي على توقيع غير صالح.

**هل يعني التوقيع الصالح أنني يجب أن أثق بالموقع؟**

ليس ذلك بحد ذاته. صلاحية التوقيع وثقة الموقع قرارات منفصلة. يجب على سياسة التحقق في الإنتاج أيضًا فحص سلسلة الشهادة، وفترة صلاحية الشهادة، وحالة الإبطال، وهوية الموقع المتوقعة، واستخدام المفتاح، وأي متطلبات طابع زمني موثوق.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض، لكنه يؤثر على تقييم ثقة الشهادة. ما إذا كان التوقيع ما زال مقبولًا يعتمد على سياستك وما إذا كان هناك طابع زمني موثوق يثبت أن التوقيع تمّ بينما الشهادة كانت صالحة. لا تعتمد على وقت التوقيع المعروض وحده كطابع زمني موثوق.

**هل يمكن تحرير عرض موقع؟**

نعم. لا يقوم التوقيع بقفل الملف. عادةً ما يجعل تحرير المحتوى الموقع التوقيع الحالي غير صالح، لذا أكمل العرض أولًا ووقع النسخة النهائية.

**هل يمكن للعرض أن يحتوي على أكثر من توقيع واحد؟**

نعم. أضف كل توقيع إلى المجموعة التي تُعيدها [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getDigitalSignatures) قبل الحفظ. أثناء التحقق، فحص كل توقيع وتأكد من وجود جميع الموقعين المطلوبين.

**ما صيغ العروض التي تدعم هذه العمليات؟**

Aspose.Slides تدعم عمليات التوقيع الرقمي الموضحة هنا فقط لملف PPTX. صيغ PPT وOpenDocument غير مدعومة عبر هذه واجهة برمجة التطبيقات.

**هل يمكنني إزالة توقيع دون التأثير على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو مسح المجموعة بالكامل ثم حفظ العرض. يبقى محتوى الشرائح متاحًا، لكن الملف المحفوظ لن يحمل دليل التوقيع الذي أُلغي.