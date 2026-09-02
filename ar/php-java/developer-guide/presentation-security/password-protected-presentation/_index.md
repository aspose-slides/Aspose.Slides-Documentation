---
title: حماية عروض تقديمية بكلمة مرور في PHP
linktitle: حماية كلمة المرور
type: docs
weight: 20
url: /ar/php-java/password-protected-presentation/
keywords:
- عرض تقديمي محمي بكلمة مرور
- كلمة مرور الفتح
- تشفير PowerPoint
- فك تشفير PowerPoint
- التحقق من كلمة مرور العرض
- فحص كلمة مرور العرض
- فتح عرض مشفر
- إزالة التشفير
- PowerPoint
- PPT
- PPTX
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تشفير، اكتشاف، التحقق، فتح، وفك تشفير عروض PowerPoint PPT و PPTX المحمية بكلمة مرور في PHP باستخدام Aspose.Slides."
---
## **نظرة عامة**

كلمة مرور الفتح تقوم بتشفير العرض التقديمي. يلزم كلمة المرور الصحيحة لتحميل وعرض محتوى العرض التقديمي، وبالتالي توفر هذه الحماية السرية.

كلمة مرور الفتح تختلف عن كلمة مرور الحماية من الكتابة. الحماية من الكتابة تقيد التعديل لكنها لا تقوم بتشفير المحتوى ولا تمنع تحميل العرض التقديمي. لإدارة كلمات المرور لتعديل العروض التقديمية، راجع [Write-Protect Presentations](/slides/ar/php-java/write-protected-presentation/).

تطبق سير العمل أدناه على كل من عروض PPT و PPTX. تستخدم الأمثلة كلا الشكلين حيث يكون سلوكهما القائم على الملفات أو التدفقات مهمًا.

## **تشفير عرض تقديمي بكلمة مرور فتح**

استخدم [ProtectionManager::encrypt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#encrypt) لتعيين كلمة مرور الفتح. ثم استخدم [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) لحفظ العرض المشفر.

المثال التالي يشفر عرض PPTX:
```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **تحميل عرض مشفر**

قم بضبط [LoadOptions::setPassword](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setPassword) إلى كلمة مرور الفتح ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) عند تحميل الملف. يفشل التحميل عندما تكون كلمة مرور الفتح مطلوبة ولكن كلمة المرور المقدمة مفقودة أو غير صحيحة.
```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # العمل مع العرض المفكوك.
} finally {
    $presentation->dispose();
}
```

## **إزالة التشفير من عرض تقديمي**

حمّل العرض باستخدام كلمة مرور الفتح، استدعِ [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#removeEncryption)، واحفظ النتيجة. يمكن بعد ذلك تحميل العرض المحفوظ دون كلمة مرور.
```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **التحقق من صحة كلمة مرور الفتح قبل التحميل**

استخدم [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/#getPresentationInfo) للحصول على [PresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/) دون إنشاء نسخة كاملة من العرض. افحص [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#isPasswordProtected) قبل طلب أو التحقق من كلمة مرور. عندما تكون الحماية موجودة، تحقق من صحة القيمة المقدمة باستخدام [PresentationInfo::checkPassword](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#checkPassword).

### **سير العمل باستخدام مسار الملف**

المثال التالي يتحقق من صحة كلمة مرور الفتح لملف PPTX، يمرّر القيمة التي تم التحقق منها إلى [LoadOptions::setPassword](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setPassword)، ثم يحمل العرض الكامل:
```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **سير العمل باستخدام التدفق**

الإصدار المتعدد التدفقات من [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/#getPresentationInfo) يوفر نفس سير العمل. أعد ضبط موضع تدفق قابل للبحث قبل تحميل العرض الكامل من ذلك التدفق.

المثال التالي يستخدم ملف PPT:
```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **قيم الإرجاع للدالة checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#checkPassword) ترجع `true` فقط عندما يكون للعرض كلمة مرور فتح وتكون كلمة المرور المقدمة صحيحة. ترجع `false` في كل من الحالات التالية:
- كلمة المرور غير صحيحة.
- العرض لا يحتوي على كلمة مرور فتح.
- كلمة المرور المقدمة هي `null` أو فارغة.

السلوك نفسه للعرضين PPT و PPTX.

## **التحقق مما إذا كان العرض المحمل مشفرًا**

بعد تحميل عرض باستخدام كلمة المرور الصحيحة، فحص [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#isEncrypted) لتأكيد أن العرض الأصلي كان مشفرًا. لاكتشاف حماية كلمة مرور الفتح قبل التحميل، استخدم [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#isPasswordProtected) كما هو موضح أعلاه.
```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **توصيات الأمان**

{{% alert color="warning" title="Security" %}}
لا تقم بتسجيل كلمات مرور الفتح أو تضمينها في رسائل التشخيص. تجنّب محاولات التحقق المتكررة غير الضرورية، واحتفظ بكلمات المرور في الذاكرة فقط للمدة المطلوبة، وأعد استخدام نتيجة التحقق الناجحة عند تحميل العرض مباشرةً.
{{% /alert %}}

## **حماية عرض تقديمي بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
1. اختر أو قم بتحميل العرض التقديمي.
1. أدخل كلمة مرور لحماية العرض.
1. اختيارياً أدخل كلمة مرور منفصلة لحماية التعديل.
1. طبق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ar/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ar/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما هو الفرق بين كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

كلمة مرور الفتح تشفر العرض التقديمي وتكون مطلوبة لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من صحة كلمة مرور الفتح دون تحميل جميع الشرائح؟**

نعم. احصل على معلومات العرض، وتحقق مما إذا كانت حماية كلمة مرور الفتح موجودة، وحقق من صحة كلمة المرور قبل إنشاء نسخة كاملة من العرض.

**هل تدعم سير العمل للتحقق من كلمة المرور كلاً من PPT و PPTX؟**

نعم. اكتشاف كلمة المرور والتحقق منها عبر مسار الملف أو عبر التدفق يعمل بنفس الطريقة لكل من عروض PPT و PPTX.