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
- موارد خارجية
- كائن ثنائي
- PHP
- Aspose.Slides
description: "تعرّف على كيفية فتح عروض PowerPoint و OpenDocument في PHP، وتوفير كلمات مرور الفتح، والتحكم في تحميل الموارد، وتقليل استهلاك الذاكرة باستخدام Aspose.Slides للـ PHP عبر Java."
---
## **مقدمة**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/ar/php-java/) يمكنه تحميل عروض PowerPoint و OpenDocument من الملفات والتدفقات. بعد تحميل العرض، يمكنك فحص بنيته، تعديل الشرائح، إدارة الموارد، وحفظه بالتنسيق الأصلي أو بأي تنسيق مدعوم آخر.

يمكن تخصيص سلوك التحميل عبر الفئة [LoadOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/). على سبيل المثال، يمكنك توفير كلمة مرور للفتح، الاحتفاظ بالكائنات الثنائية الكبيرة خارج ذاكرة Java heap، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المدمجة.

## **فتح العروض التقديمية**

بعد تحميل ملف أو تدفق، يمكنك [تحديد تنسيق العرض التقديمي الأصلي](/slides/ar/php-java/detect-presentation-source-format/) لاختيار طريقة معالجة تطبيقك له.

لفتح عرض تقديمي موجود، مرر مسار ملفه إلى منشئ [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/). حرّر (Dispose) العرض التقديمي بعد الاستخدام حتى يتم تحرير مؤشرات الملفات والبيانات المؤقتة وغيرها من الموارد بسرعة.

المثال التالي بلغة PHP يوضح كيفية فتح عرض تقديمي والحصول على عدد الشرائح:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **فتح العروض التقديمية المحمية بكلمة مرور**

كلمة مرور الفتح تشفر محتوى العرض. لتحميل العرض بالكامل، مرر كلمة المرور الصحيحة إلى [LoadOptions::setPassword](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setPassword) وقدم الخيارات إلى منشئ [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/). سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

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

للتعرف على كلمة المرور، التحقق منها، وسير عمل التشفير، راجع [Password-Protect Presentations](/slides/ar/php-java/password-protected-presentation/). إذا تم حفظ عرض مشفر مع خصائص مستند عامة، يمكن قراءة تلك الخصائص بدون كلمة مرور؛ راجع [Manage Presentation Properties](/slides/ar/php-java/presentation-properties/).

## **فتح العروض التقديمية الكبيرة**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) يُعيد خيارات تتحكم في طريقة معالجة Aspose.Slides للكائنات الثنائية الكبيرة مثل الصور والصوت والفيديو. يمكنك إبقاء ملف المصدر مقفلاً، السماح بملفات مؤقتة، وتحديد كمية بيانات BLOB المحتفظ بها في الذاكرة.

الكود التالي بلغة PHP يوضح تحميل عرض تقديمي كبير (مثلاً 2 جيجابايت):

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

{{% alert color="info" title="Note" %}}
مع [PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked)، يظل ملف المصدر مقفلاً حتى يتم تحرير كائن العرض. لا تقم بنقل أو استبدال أو حذف ملف المصدر بينما يكون هذا الكائن موجودًا.
Aspose.Slides قد ينسخ محتويات تدفق الإدخال أثناء تحميله. بالنسبة للعروض الكبيرة، يكون مسار الملف عمومًا أكثر كفاءة من التدفق. راجع [Manage BLOBs](/slides/ar/php-java/manage-blob/) لمزيد من خيارات التخزين وإدارة الذاكرة.
{{% /alert %}}

## **التحكم في الموارد الخارجية**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) يقبل تنفيذًا لواجهة Java [IResourceLoadingCallback](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iresourceloadingcallback/) عبر PHP/Java Bridge. يمكن للرد الإرجاعي توفير بيانات بديلة، إعادة توجيه مورد، استخدام المحمل الافتراضي، أو تخطي المورد. هذا مفيد عندما يحتوي العرض على صور خارجية يجب حلها وفقًا لقواعد الأمان أو التخزين الخاصة بالتطبيق.

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

## **تحميل العروض التقديمية بدون الكائنات الثنائية المدمجة**

قد يحتوي العرض على بيانات ثنائية مدمجة لا يحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. أمثلة على ذلك:

- مشاريع VBA، متاحة عبر [Presentation::getVbaProject](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getVbaProject);
- بيانات OLE مدمجة، متاحة عبر [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/ar/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- بيانات تحكم ActiveX، متاحة عبر [Control::getActiveXControlBinary](https://reference.aspose.com/slides/ar/php-java/aspose.slides/control/#getActiveXControlBinary).

ضع [LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) إلى `true` لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض المحمّل لتثبيت النتيجة المنقحة.

هذا الخيار يقلل من التعرض للحمولات المدمجة غير المرغوب فيها، لكنه ليس نظامًا كاملاً لاكتشاف البرامج الضارة أو تنقية المحتوى.

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

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

Aspose.Slides يرمي استثناءً يتعلق بالتحليل أو التنسيق أثناء التحميل. عالج هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

يمكن للعرض أن يظل يُحمل، لكن قد تستبدل الخطوط أثناء العرض أو التصدير. يمكنك [configure font substitution](/slides/ar/php-java/font-substitution/) أو [provide custom fonts](/slides/ar/php-java/custom-font/) لجعل المخرجات أكثر توقعًا.

**هل تحميل العرض يحمل أيضًا الوسائط المدمجة فيه؟**

الصوت والفيديو المدمجين يصبحان متاحين عبر نموذج كائن العرض. الموارد الخارجية تُحل وفقًا لسلوك تحميل الموارد المكوَّن وقد تكون غير متاحة إذا تعذر الوصول إلى مواقعها.