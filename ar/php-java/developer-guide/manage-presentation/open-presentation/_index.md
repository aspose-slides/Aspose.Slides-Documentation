---
title: فتح العروض التقديمية في PHP
linktitle: فتح عرض تقديمي
type: docs
weight: 20
url: /ar/php-java/open-presentation/
keywords:
- فتح PowerPoint
- فتح عرض تقديمي
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل عرض تقديمي
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض محمي
- عرض كبير
- مورد خارجي
- كائن ثنائي
- PHP
- Aspose.Slides
description: "تعلم كيف تفتح عروض PowerPoint وOpenDocument في PHP، وتوفير كلمات مرور للفتح، والتحكم في تحميل الموارد، وتقليل استهلاك الذاكرة باستخدام Aspose.Slides for PHP عبر Java."
---
## **المقدمة**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/ar/php-java/) يمكنه تحميل عروض PowerPoint وOpenDocument من الملفات وتدفقات البيانات. بعد تحميل العرض، يمكنك فحص هيكليته، تعديل الشرائح، إدارة الموارد، وحفظه بالصيغ الأصلية أو بصيغة مدعومة أخرى.

يمكن تخصيص سلوك التحميل عبر الفئة [LoadOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/) . على سبيل المثال، يمكنك توفير كلمة مرور للفتح، إبقاء الكائنات الثنائية الكبيرة خارج ذاكرة Java heap، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المضمّنة.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، مرّر مسار ملفه إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) . حرّر العرض بعد الاستخدام لتصريف مقابض الملفات والبيانات المؤقتة وغيرها من الموارد على الفور.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **فتح العروض المحمية بكلمة مرور**

كلمة المرور المشفرة تحمي محتوى العرض. لتحميل العرض بالكامل، مرّر كلمة المرور الصحيحة إلى [LoadOptions::setPassword](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setPassword) وقدم الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) . سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

لعمليات اكتشاف كلمة المرور، والتحقق، وسير عمل التشفير، انظر [Password-Protect Presentations](/slides/ar/php-java/password-protected-presentation/). إذا تم حفظ عرض مشفر عمداً بخصائص مستند عامة، يمكن قراءة تلك الخصائص بدون كلمة مرور؛ انظر [Manage Presentation Properties](/slides/ar/php-java/presentation-properties/).

## **فتح عروض تقديمية كبيرة**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) تُعيد خيارات تتحكم في طريقة معالجة Aspose.Slides للكائنات الثنائية الضخمة مثل الصور، والصوت، والفيديو. يمكنك إبقاء ملف المصدر مقفلاً، السماح بالملفات المؤقتة، وتقييد كمية بيانات BLOB المحتفظ بها في الذاكرة.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="ملاحظة" %}}
مع [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، يبقى ملف المصدر مقفلاً حتى يتم تحرير كائن العرض. لا تقم بنقل أو استبدال أو حذف ملف المصدر بينما يكون هذا الكائن حياً.

قد تقوم Aspose.Slides بنسخ محتويات تدفق الإدخال أثناء تحميله. بالنسبة للعروض الكبيرة، غالباً ما يكون مسار الملف أكثر كفاءة من التدفق. راجع [Manage BLOBs](/slides/ar/php-java/manage-blob/) للحصول على مزيد من خيارات التخزين وإدارة الذاكرة.
{{% /alert %}}

## **التحكم في الموارد الخارجية**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) تقبل تنفيذًا لواجهة Java [IResourceLoadingCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iresourceloadingcallback/) عبر جسر PHP/Java. يمكن للـ callback تزويد بيانات بديلة، إعادة توجيه مورد، استخدام المحمّل الافتراضي، أو تخطّي المورد. يكون هذا مفيدًا عندما تحتوي العروض على صور خارجية يجب حلّها وفقًا لقواعد الأمان أو التخزين الخاصة بالتطبيق.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **تحميل العروض بدون كائنات ثنائية مضمّنة**

قد يحتوي العرض على بيانات ثنائية مضمّنة لا تحتاجها التطبيق أو لا تريد الاحتفاظ بها. تشمل الأمثلة:

- مشاريع VBA، متاحة عبر [Presentation::getVbaProject](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getVbaProject)؛
- بيانات OLE مضمّنة، متاحة عبر [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/ar/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData)؛
- بيانات التحكم ActiveX، متاحة عبر [Control::getActiveXControlBinary](https://reference.aspose.com/slides/ar/php-java/aspose.slides/control/#getActiveXControlBinary) .

حدد [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) إلى `true` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض المُحمَّل لتثبيت النتيجة المُنقاة.

هذا الخيار يقلل من التعرض للحمولات المضمّنة غير المرغوبة، لكنه ليس نظام اكتشاف برامج ضارة أو تنقية محتوى كامل.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن الملف معيَّب ولا يمكن فتحه؟**  
ترمي Aspose.Slides استثناءً يتعلّق بالتحليل أو الصيغة أثناء التحميل. عالج هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**  
يمكن للعرض أن يظل يُحمَّل، لكن قد تُستبدل الخطوط أثناء العرض أو التصدير. يمكنك [configure font substitution](/slides/ar/php-java/font-substitution/) أو [provide custom fonts](/slides/ar/php-java/custom-font/) لجعل المخرجات أكثر توقعًا.

**هل يقوم تحميل العرض أيضًا بتحميل وسائطه المضمَّنة؟**  
تصبح ملفات الصوت والفيديو المضمّنة متاحة عبر نموذج كائن العرض. تُحلّ الموارد الخارجية وفق سلوك تحميل الموارد المُكوَّن وقد تكون غير متوفرة إذا تعذر الوصول إلى مواقعها.