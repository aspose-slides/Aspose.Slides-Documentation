---
title: إضافة توقيعات رقمية إلى العروض التقديمية في PHP
linktitle: توقيع رقمي
type: docs
weight: 10
url: /ar/php-java/digital-signature-in-powerpoint/
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
- PHP
- Aspose.Slides
description: "تعلم كيفية توقيع عروض PPTX موجودة باستخدام شهادات PFX واستخدام Aspose.Slides للـ PHP عبر Java للتحقق من التوقيعات الرقمية أو إزالتها."
---
## **نظرة عامة**

يساعد التوقيع الرقمي المستلم على تحديد من قام بتوقيع العرض وما إذا كان المحتوى الموقع قد تغير. هناك ثلاثة مفاهيم أمان ذات صلة مهمة هنا:

- شهادة **digital certificate** هي وثيقة إلكترونية تربط هوية بمفتاح عام. يمكن لسلطة شهادة موثوقة (CA) إصدار شهادة، أو يمكن للمؤسسة استخدام شهادة موقعة ذاتيًا لعمليات داخلية.
- التوقيع **digital signature** يُنشئ من محتوى العرض ومفتاح الخاص لصاحب الشهادة. يمكن بعد ذلك استخدام المفتاح العام للشهادة للتحقق من التوقيع. يوفر التوقيع دليلًا على الأصل والنزاهة؛ لكنه لا يشفر العرض.
- **Password protection** يتحكم فيما إذا كان المستخدم يمكنه فتح العرض أو تعديلّه. وهو منفصل عن التوقيع الرقمي ويُوضح في [Password-Protected Presentations](/php-java/password-protected-presentation/).

يوفر PowerPoint أمر **Add a Digital Signature** ضمن **File > Info > Protect Presentation**.

![قائمة حماية العرض في PowerPoint مع تظليل Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

بعد فتح عرض موقّع، يمكن لـ PowerPoint عرض إشعار بحالة التوقيع.

![إخطار PowerPoint يوضح أن العرض يحتوي على توقيعات صالحة](digital-signature-status-in-powerpoint.png)

يكشف Aspose.Slides عن التوقيعات عبر [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getDigitalSignatures)، والتي تُعيد [DigitalSignatureCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignaturecollection/) حيث تُمثَّل العناصر بواسطة كائنات [DigitalSignature](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignature/). يمكن للعرض أن يحتوي على توقيعات متعددة.

## **فهم شهادات PFX وكلمات المرور**

ملف PFX، المعروف أيضًا بملف PKCS#12 وعادةً ما يُعطى امتدادًا `.pfx` أو `.p12`، يمكنه أن يحتوي على شهادة X.509، ومفتاحها الخاص، وسلسلة الشهادات. المفتاح الخاص هو ما يسمح للمالك بإنشاء توقيع. شهادة بدون مفتاح خاص يمكن الوصول إليه لا يمكن استخدامها لتوقيع عرض.

كلمة مرور PFX تحمي حزمة الشهادة والمفتاح الخاص. وهي **ليست** كلمة مرور لفتح أو تعديل العرض. لا تقم بدمج ملفات PFX أو كلمات مرورها في نظام التحكم بالمصادر. في بيئة الإنتاج، قيد الوصول إلى ملف الشهادة واحصل على كلمة المرور من مخزن أسرار أو مصدر تكوين محمي آخر. تُظهر الأمثلة أدناه متغيّر بيئة فقط لتجنب تضمين كلمة المرور في الشيفرة.

## **إضافة توقيع رقمي إلى عرض**

لتوقيع سير عمل عرض حقيقي، حمّل ملف PPTX موجود، أنشئ [DigitalSignature](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignature/) من شهادة PFX وكلمة مرورها، أضف التوقيع إلى مجموعة العرض، واحفظه في ملف PPTX.

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

حفظ النتيجة تحت اسم جديد يحافظ على ملف المصدر غير الموقع. القيمة التي تُحددها [DigitalSignature::setComments](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignature/setcomments/) تصف هدف التوقيع؛ وهي ليست آلية أمان.

## **التحقق من التوقيعات الرقمية**

عند تحميل ملف PPTX موقع، افحص كل عنصر تُعيده [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getDigitalSignatures). طريقة [DigitalSignature::isValid](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignature/isvalid/) تشير ما إذا كان التوقيع المدمج صالحًا لمحتوى العرض الحالي.

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

نتيجة غير صالحة عادة ما تعني أن محتوى العرض الموقع أو بيانات التوقيع تغيرت بعد التوقيع، أو أن الملف تالف. إزالة كل توقيع تُنتج عرضًا غير موقع، لذا فحص صلاحية العناصر فقط لا يكفي: يجب على سير عمل حساس للأمان أيضًا التحقق من عدد التوقيعات المتوقع وهوية المُوقّعين المتوقعة.

هذه النتيجة لا ينبغي التعامل معها كقرار نهائي بشأن ثقة الشهادة. وفقًا لسياسة الأمان الخاصة بك، قد يحتاج تطبيقك أيضًا إلى بناء والتحقق من سلسلة شهادة X.509، وفحص تواريخ صلاحية الشهادة وحالتها من الإلغاء، والتأكيد على الموضوع أو بصمة الفاعل المتوقعة، والتحقق من استخدام المفتاح، وتقييم طابع زمني موثوق. القيمة التي تُرجعها [DigitalSignature::getSignTime](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignature/getsigntime/) وحدها ليست دليلًا من سلطة طابع زمني موثوقة.

## **إزالة التوقيعات الرقمية**

إزالة التوقيعات تغير حالة أمان العرض. المثال التالي يُحمِّل ملف PPTX موقع، يزيل كل التوقيعات باستخدام [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignaturecollection/clear/)، ويحفظ نسخة غير موقّعة.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

لإزالة توقيع واحد فقط، استدعِ [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/digitalsignaturecollection/removeat/) مع فهرسه الصفري. احفظ إلى ملف جديد ما لم يكن استبدال الأصلي الموقع جزءًا صريحًا من سير عملك.

## **التحرير واعتبارات الصيغة**

- التوقيع لا يجعل العرض للقراءة فقط. لا يزال بمقدور المستخدمين والتطبيقات تحرير الملف، لكن التغييرات على المحتوى الموقع تُلغي عادةً التوقيع القائم.
- أكمل كل التعديلات المقصودة قبل التوقيع. إذا كان لابد من تعديل العرض، احفظ النسخة المعدَّلة ووقّع تلك المراجعة مرة أخرى.
- حافظ على المخرجات النهائية بصيغة PPTX. تحويل عرض موقع إلى صيغة أخرى لا ينقل توقيع PPTX الأصلي كتوقيع صالح للملف المحوَّل.
- عامل المفتاح الخاص للشهادة باعتباره حساسًا. أي شخص يحصل على المفتاح الخاص وكلمة مروره قد يكون قادرًا على إنشاء توقيعات تبدو كأنها صادرة من صاحب الشهادة.
- احتفظ بالمصدر غير الموقع أو بنسخة خاضعة للسيطرة عندما تتطلب سياسة الاحتفاظ بالمستندات ذلك.

## **الأسئلة الشائعة**

**هل التوقيع الرقمي يشفر العرض؟**

لا. يقدم التوقيع الرقمي دليلًا على الأصل والنزاهة، لكن يبقى محتوى العرض قابلًا للقراءة ما لم يُطبق تشفير منفصل. استخدم [password protection](/php-java/password-protected-presentation/) عندما يجب تقييد الوصول إلى المحتوى.

**هل كلمة مرور PFX هي نفسها كلمة مرور العرض؟**

لا. كلمة مرور PFX تفتح المفتاح الخاص المخزن في حزمة الشهادة. وهي لا تتحكم في من يمكنه فتح أو تعديل ملف PPTX.

**هل يمكنني استخدام شهادة موقَّعة ذاتيًا؟**

تقنيًا، يمكن استخدام شهادة موقَّعة ذاتيًا إذا تضمنت مفتاحًا خاصًا قابلًا للوصول. المتلقون لن يثقوا بها تلقائيًا ما لم تُضافة صراحةً إلى بيئتهم الموثوقة. عادةً ما تستخدم سير عمل عامة أو عبر مؤسسات شهادة صادرة عن سلطة موثوقة.

**ما الذي يجعل التوقيع غير صالح؟**

تغيير محتوى العرض الموقع أو بيانات التوقيع بعد التوقيع يمكن أن يُلغي صلاحية التوقيع. الفساد في الملف قد يسبب أيضًا فشل التحقق. إذا أزيلت كل التوقيعات، يكون العرض غير موقع وليس ملفًا يحتوي على توقيع غير صالح.

**هل يعني التوقيع الصالح أنه يجب الثقة بالمُوقّع؟**

ليس بمفرده. صلاحية التوقيع وثقة المُوقّع قرارات منفصلة. يجب أن تتحقق سياسة التحقق في الإنتاج أيضًا من سلسلة الشهادة، فترة الصلاحية، حالة الإلغاء، الهوية المتوقعة، استخدام المفتاح، وأي متطلبات طابع زمني موثوق.

**ماذا يحدث عندما تنتهي صلاحية الشهادة؟**

انتهاء صلاحية الشهادة لا يغيّر بايتات العرض، لكنه يؤثر على تقييم ثقة الشهادة. ما إذا كان التوقيع لا يزال مقبولًا يعتمد على سياستك وما إذا كان طابع زمني موثوق يثبت أن التوقيع تم بينما كانت الشهادة صالحة. لا تعتمد على وقت التوقيع المعروض وحده كطابع زمني موثوق.

**هل يمكن تحرير عرض موقع؟**

نعم. لا يقفل التوقيع الملف. عادةً ما يجعل تحرير المحتوى الموقع التوقيع القائم غير صالح، لذا أكمل العرض أولًا ووقّع النسخة النهائية.

**هل يمكن للعرض احتواء أكثر من توقيع؟**

نعم. أضف كل توقيع إلى المجموعة التي تُعيدها [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getDigitalSignatures) قبل الحفظ. أثناء التحقق، افحص كل توقيع وتأكد من وجود جميع المُوقّعين المطلوبين.

**ما هي صيغ العرض التي تدعم هذه العمليات؟**

يدعم Aspose.Slides عمليات التوقيع الرقمي المبيَّنة هنا فقط لصيغة PPTX. صيغ PPT وOpenDocument لا تدعمها هذه واجهة برمجة تطبيقات.

**هل يمكنني إزالة توقيع دون التأثير على الشرائح؟**

نعم. يمكنك إزالة توقيع واحد أو مسح المجموعة بالكامل ثم حفظ العرض. يبقى محتوى الشرائح متاحًا، لكن الملف المحفوظ لن يحمل دليل التوقيع المُزال.