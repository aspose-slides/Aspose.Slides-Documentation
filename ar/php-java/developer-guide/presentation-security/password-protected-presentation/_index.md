---
title: "حماية العروض بكلمة مرور في PHP"
linktitle: "حماية كلمة المرور"
type: docs
weight: 20
url: /ar/php-java/password-protected-presentation/
keywords:
- عرض محمي بكلمة مرور
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
- عرض
- PHP
- Aspose.Slides
description: "تشفير، اكتشاف، التحقق، فتح، وفك تشفير العروض المحمية بكلمة مرور PowerPoint بصيغ PPT و PPTX في PHP باستخدام Aspose.Slides."
---
## **نظرة عامة**

كلمة مرور الفتح تقوم بتشفير العرض. يجب توفير كلمة المرور الصحيحة لتحميل وعرض محتوى العرض، لذا توفر هذه الحماية السرية.

كلمة مرور الفتح تختلف عن كلمة مرور الحماية من الكتابة. حماية الكتابة تقيد التعديل لكنها لا تقوم بتشفير المحتوى أو منع تحميل العرض. لإدارة كلمات المرور لتعديل العروض، راجع [Write-Protect Presentations](/slides/ar/php-java/write-protected-presentation/).

تطبق سير العمل أدناه على كلا من عروض PPT و PPTX. تستخدم الأمثلة كلا الصيغ عندما يكون سلوكهما القائم على الملف أو التدفق مهمًا.

## **تشفير عرض باستخدام كلمة مرور الفتح**

استخدم [ProtectionManager::encrypt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#encrypt) لتعيين كلمة مرور الفتح. ثم استخدم [Presentation::save](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#save) لحفظ العرض المشفر.

المثال التالي يقوم بتشفير عرض PPTX:

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

## **اجعل خصائص المستند عامة**

بشكل افتراضي، تقوم Aspose.Slides بتضمين خصائص المستند في تشفير العرض. تتحكم طريقة [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) في هذا السلوك بشكل مستقل عن تشفير محتوى الشرائح. مرّر `false` قبل استدعاء [ProtectionManager::encrypt](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#encrypt) عندما يتعين على نظام الفهرسة أو التصنيف أو البحث أو إدارة المستندات قراءة البيانات الوصفية دون كلمة مرور الفتح.

المثال التالي ينشئ عرض PPTX مشفر مع ترك خصائص المستند المدمجة عامة:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

مرّر `false` إلى [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) لا يجعل الشرائح أو القوالب أو التخطيطات أو الأشكال أو الوسائط أو أي محتوى آخر للعرض عامًا. إنه يؤثر فقط على خصائص المستند. لقراءة تلك الخصائص دون تحميل المحتوى المشفر، راجع [Manage Presentation Properties](/slides/ar/php-java/presentation-properties/).

## **تحميل عرض مشفر**

قم بتعيين [LoadOptions::setPassword](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setPassword) إلى كلمة مرور الفتح ومرّر الخيارات إلى [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) عند تحميل الملف. سيفشل التحميل عندما تكون كلمة مرور الفتح مطلوبة لكن كلمة المرور المقدمة مفقودة أو غير صحيحة.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # العمل مع العرض المفكك تشفيره.
} finally {
    $presentation->dispose();
}
```

## **إزالة التشفير من عرض**

حمّل العرض باستخدام كلمة مرور الفتح الخاصة به، استدعِ [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#removeEncryption)، واحفظ النتيجة. يمكن بعد ذلك تحميل العرض المحفوظ دون كلمة مرور.

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

## **التحقق من كلمة مرور الفتح قبل التحميل**

استخدم [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/#getPresentationInfo) للحصول على [PresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/) دون إنشاء نسخة كاملة من العرض. تحقق من [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#isPasswordProtected) قبل طلب أو التحقق من كلمة مرور. عندما تكون الحماية موجودة، تحقق من صحة القيمة المقدمة باستخدام [PresentationInfo::checkPassword](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#checkPassword).

### **سير عمل مسار الملف**

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

### **سير عمل الدفق**

الإصدار المتعدد الدفق من [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/#getPresentationInfo) يوفر نفس سير العمل. أعد ضبط موضع الدفق القابل للبحث قبل تحميل العرض الكامل من ذلك الدفق.

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

### **قيم إرجاع checkPassword**

تُعيد [PresentationInfo::checkPassword](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#checkPassword) القيمة `true` فقط عندما يكون للعرض كلمة مرور فتح وتكون كلمة المرور المقدمة صحيحة. تُعيد `false` في كل من الحالات التالية:

- كلمة المرور غير صحيحة.
- العرض لا يحتوي على كلمة مرور فتح.
- كلمة المرور المقدمة هي `null` أو فارغة.

السلوك نفسه ينطبق على عروض PPT و PPTX.

## **التحقق مما إذا كان العرض المحمل مشفرًا**

بعد تحميل عرض باستخدام كلمة المرور الصحيحة، افحص [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#isEncrypted) لتأكيد أن العرض الأصلي كان مشفرًا. للكشف عن حماية كلمة مرور الفتح قبل التحميل، استخدم [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#isPasswordProtected) كما هو موضح أعلاه.

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

{{% alert color="warning" title="الأمان" %}}
لا تقم بتسجيل كلمات مرور الفتح أو تضمينها في رسائل التشخيص. تجنب محاولات التحقق المتكررة غير الضرورية، احتفظ بكلمات المرور في الذاكرة فقط للمدة المطلوبة، وأعد استخدام نتيجة تحقق ناجحة عند تحميل العرض مباشرةً.

قد تكشف خصائص المستند العامة عن أسماء المؤلفين، العناوين، المواضيع، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة حتى وإن كان محتوى العرض مشفرًا. قم بتشفير البيانات الوصفية الحساسة مع العرض. يجب أن يكون ترك الخصائص عامة قرارًا صريحًا يُتخذ فقط عندما يتعين على الأنظمة فهرسة أو تصنيف أو بحث أو إدارة الملف دون كلمة مرور الفتح.
{{% /alert %}}

## **حماية عرض بكلمة مرور عبر الإنترنت**

1. افتح تطبيق [Aspose.Slides Lock](https://products.aspose.app/slides/ar/lock).
2. اختر أو حمّل العرض.
3. أدخل كلمة مرور لحماية العرض.
4. اختياريًا أدخل كلمة مرور منفصلة لحماية التحرير.
5. طبق الحماية وحمّل الملف الناتج.

{{% alert color="info" title="انظر أيضًا" %}}
- [حماية العروض من الكتابة](/slides/ar/php-java/write-protected-presentation/)
- [التوقيع الرقمي في PowerPoint](/slides/ar/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **الأسئلة الشائعة**

**ما الفرق بين كلمة مرور الفتح وكلمة مرور الحماية من الكتابة؟**

كلمة مرور الفتح تقوم بتشفير العرض وتكون مطلوبة لتحميل محتواه. كلمة مرور الحماية من الكتابة تقيد التعديل دون تشفير المحتوى.

**هل يمكنني التحقق من كلمة مرور الفتح دون تحميل جميع الشرائح؟**

نعم. احصل على معلومات العرض، وتحقق مما إذا كانت حماية كلمة مرور الفتح موجودة، وصحّح كلمة المرور قبل إنشاء نسخة كاملة من العرض.

**هل يمكن للتطبيق قراءة البيانات الوصفية دون كلمة مرور الفتح؟**

نعم، ولكن فقط عندما يكون العرض مشفرًا مع تعطيل تشفير خصائص المستند. يجب على التطبيق حينئذٍ استخدام وضع التحميل الخاص بخصائص المستند فقط كما هو موضح في [Manage Presentation Properties](/slides/ar/php-java/presentation-properties/).

**هل تدعم سير عمل التحقق من كلمة المرور كلًا من PPT و PPTX؟**

نعم. اكتشاف كلمة المرور والتحقق منها بناءً على مسار الملف أو الدفق يعمل بنفس الطريقة على عروض PPT و PPTX.