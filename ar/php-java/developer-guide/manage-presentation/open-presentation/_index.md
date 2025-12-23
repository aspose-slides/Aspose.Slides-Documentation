---
title: فتح العروض التقديمية في PHP
linktitle: فتح عرض تقديمي
type: docs
weight: 20
url: /ar/php-java/open-presentation/
keywords:
- فتح PowerPoint
- فتح OpenDocument
- فتح عرض تقديمي
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل عرض تقديمي
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض تقديمي محمي
- عرض تقديمي كبير
- مورد خارجي
- كائن ثنائي
- PHP
- Aspose.Slides
description: "قم بفتح عروض PowerPoint (.pptx, .ppt) وOpenDocument (.odp) بسهولة باستخدام Aspose.Slides للـ PHP عبر Java — سريع، موثوق، كامل المميزات."
---

## **نظرة عامة**

بعيدًا عن إنشاء عروض PowerPoint من الصفر، يتيح Aspose.Slides أيضًا فتح العروض التقديمية الموجودة. بعد تحميل عرض تقديمي، يمكنك استرداد معلومات عنه، تعديل محتوى الشرائح، إضافة شرائح جديدة، حذف الشرائح الحالية، والمزيد.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، قم بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ومرر مسار الملف إلى منشئها.

تظهر مثال PHP التالي كيفية فتح عرض تقديمي والحصول على عدد الشرائح:
```php
// إنشاء كائن من الفئة Presentation وتمرير مسار الملف إلى منشئها.
$presentation = new Presentation("Sample.pptx");
try {
    // طباعة العدد الإجمالي للشرائح في العرض التقديمي.
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```


## **فتح العروض التقديمية المحمية بكلمة مرور**

عند الحاجة إلى فتح عرض تقديمي محمي بكلمة مرور، مرّر كلمة المرور عبر طريقة [setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword) في الفئة [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) لفك التشفير وتحميله. يُظهر كود PHP التالي هذه العملية:
```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // تنفيذ العمليات على العرض التقديمي المفكوك.
} finally {
    $presentation->dispose();
}
```


## **فتح العروض التقديمية الكبيرة**

يوفر Aspose.Slides خيارات—وبشكل خاص طريقة [getBlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) في الفئة [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)—لمساعدتك في تحميل عروض تقديمية كبيرة.

يوضح كود PHP التالي كيفية تحميل عرض تقديمي كبير (مثلاً 2 جيجابايت):
```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// اختر سلوك KeepLocked—ستظل ملف العرض مقفولًا طوال مدة
// نسخة الـ Presentation، لكن لا تحتاج إلى تحميلها في الذاكرة أو نسخها إلى ملف مؤقت.
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 ميجابايت

$presentation = new Presentation($filePath, $loadOptions);
try {
    // تم تحميل العرض التقديمي الكبير ويمكن استخدامه، بينما يظل استهلاك الذاكرة منخفضًا.

    // إجراء تغييرات على العرض التقديمي.
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // حفظ العرض التقديمي إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا أثناء هذه العملية.
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// لا تفعل هذا! سيتم رمي استثناء I/O لأن الملف مقفول حتى يتم التخلص من كائن العرض التقديمي.
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// من المقبول القيام بذلك هنا. لم يعد ملف المصدر مقفولًا بواسطة كائن العرض التقديمي.
unlink($filePath);
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند العمل مع التدفقات، قد يقوم Aspose.Slides بنسخ محتويات التدفق. تحميل عرض تقديمي كبير من تدفق يؤدي إلى نسخ العرض وقد يبطئ عملية التحميل. لذلك، عندما تحتاج إلى تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التدفق.

عند إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/php-java/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

يوفر Aspose.Slides الواجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) التي تتيح لك إدارة الموارد الخارجية. يعرض كود PHP التالي كيفية استخدام واجهة `IResourceLoadingCallback`:
```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // تحميل صورة بديلة.
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // تعيين عنوان URL بديل.
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // تجاوز جميع الصور الأخرى.
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```


## **تحميل العروض التقديمية دون كائنات ثنائية مضمّنة**

قد يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المضمّنة:
- مشروع VBA (يمكن الوصول إليه عبر [Presentation.getVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject));
- بيانات كائن OLE المضمّنة (يمكن الوصول إليها عبر [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- بيانات التحكم الثنائي ActiveX (يمكن الوصول إليها عبر [Control.getActiveXControlBinary](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getActiveXControlBinary)).

باستخدام طريقة [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects)، يمكنك تحميل عرض تقديمي دون أي كائنات ثنائية مضمّنة.

تُعد هذه الطريقة مفيدة لإزالة المحتوى الثنائي المحتمل أن يكون ضارًا. يُظهر كود PHP التالي كيفية تحميل عرض تقديمي دون أي محتوى ثنائي مضمّن:
```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // تنفيذ العمليات على العرض التقديمي.
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

ستحصل على استثناء أثناء التحميل يخص تحليل/تحقق من صحة الصيغة. غالباً ما تشير هذه الأخطاء إلى بنية ZIP غير صالحة أو سجلات PowerPoint مكسورة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيفتح الملف، لكن قد تستبدل الخطوط لاحقاً أثناء [rendering/export](/slides/ar/php-java/convert-presentation/). يمكنك [Configure font substitutions](/slides/ar/php-java/font-substitution/) أو [add the required fonts](/slides/ar/php-java/custom-font/) في بيئة التشغيل.

**ماذا عن الوسائط المضمّنة (فيديو/صوت) عند الفتح؟**

ستصبح متاحة كموارد للعرض. إذا تمت الإشارة إلى الوسائط عبر مسارات خارجية، تأكد من أن تلك المسارات متاحة في بيئتك؛ وإلا قد يحذفها [rendering/export](/slides/ar/php-java/convert-presentation/).