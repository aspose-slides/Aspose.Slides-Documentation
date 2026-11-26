---
title: إدارة خصائص العرض التقديمي في PHP
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/php-java/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض التقديمي
- خصائص المستند
- خصائص مدمجة
- خصائص مخصصة
- خصائص متقدمة
- إدارة الخصائص
- تعديل الخصائص
- بيانات تعريف المستند
- تحرير البيانات الوصفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides لـ PHP عبر Java وحسّن البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides for PHP عبر Java **الخصائص المدمجة** و **الخصائص المخصصة** للمستند. استخدم هذه الخصائص لقراءة وتحديث بيانات تعريف العرض التقديمي، مثل المؤلف، العنوان، والقيم المعرفة من قبل المستخدم.

يسمح لك Aspose.Slides بالعمل مع خصائص مستندات العروض التقديمية من خلال الفئة [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) class. تُرجَع نسخة من هذه الفئة بواسطة [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties). تُظهر الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها. وتفترض أن جسر PHP/Java ومغلف Aspose.Slides لـ PHP تم تهيئتهما.

{{% alert color="info" title="Note" %}}
يدير Aspose.Slides بيانات تعريف التطبيق والمنتج عند حفظ العروض التقديمية؛ تُحدد هذه الحقول البرنامج الذي أنشأ المخرجات.
{{% /alert %}}

## **إدارة خصائص العرض التقديمي**

تخزن خصائص المستند معلومات وصفية إلى جانب محتوى العرض التقديمي. وتنقسم إلى فئتين:

- **الخصائص المدمجة** تحتوي على بيانات تعريف قياسية، مثل العنوان، المؤلف، وإحصائيات المستند.
- **الخصائص المخصصة** تخزن أزواج الاسم/القيمة المعرفة من قبل المستخدم.

يوفر Aspose.Slides for PHP عبر Java إمكانية الوصول إلى كلا الفئتين. في PowerPoint، اختر **File → Info → Properties → Advanced Properties** لتفحص بيانات تعريف المستند. يقوم الحوار بتجميع المعلومات في علامات تبويب مثل **Summary** و **Statistics** و **Contents** و **Custom**. استخدم علامة تبويب **Custom** لإدارة الخصائص المعرفة من قبل المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما يحمي كلمة المرور المفتوحة كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير عرض تقديمي بعد استدعاء [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) مع القيمة `false`، تبقى خصائص المستند عامة. يمكن للتطبيق بعد ذلك استدعاء [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) مع القيمة `true` وقراءة البيانات العامة دون تقديم كلمة المرور المفتوحة.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) يتحكم فيما يقوم Aspose.Slides بتحميله؛ لا يقوم بفك تشفير أي شيء. إذا كانت الخصائص مشمولة في التشفير، فإن تحميلها بدون كلمة المرور سيفشل. إذا لم يكن العرض التقديمي مشفرًا، يتم تجاهل الخيار ويتم تحميل العرض التقديمي بالكامل.

يتطلب المثال عرض تقديمي مشفر تم ترك خصائص المستند الخاصة به عامة. يتحقق من وضع التحميل عبر [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) ثم يقرأ الخصائص المدمجة عبر [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائمًا فحص [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) قبل تنفيذ عملية تتطلب نموذج كائنات العرض الكامل.

{{% alert color="warning" title="Warning" %}}
قد تكشف البيانات الوصفية العامة عن أسماء المؤلفين، العناوين، المواضيع، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما يتطلب الفهرسة أو التصنيف أو البحث أو أنظمة إدارة المستندات الوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

بالنسبة لملف PPTX مشفر، يُقصد من العرض التقديمي الذي تم تحميله بعد استدعاء [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) مع القيمة `true` قراءة البيانات العامة. لا يمكن لـ Aspose.Slides حفظ الخصائص التي تم تغييرها من كائن يختص بالبيانات العامة فقط لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض المشفر. وبالتالي يتطلب تحديثها كلمة المرور المفتوحة الصحيحة وتحميلًا كاملًا.

يتطلب المثال عرض PPTX مشفر يحتوي على خصائص مستند عامة وكلمة مرور مفتوحة معروفة. يفتح العرض الكامل باستخدام [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword)، يُحدّث الخصائص العامة المدمجة، ويحفظ النتيجة. ثم يستخدم [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#isEncrypted) للتحقق من الحفاظ على التشفير ويعيد فتح البيانات العامة دون كلمة مرور للتحقق من القيم الجديدة:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض التقديمي، يجب أن يتعامل مع الخصائص العامة لملف PPTX مشفر على أنها للقراءة فقط.

## **الوصول إلى الخصائص المدمجة**

تُظهر الفئة [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) البيانات المدمجة من خلال أساليب getter، بما في ذلك [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getAuthor)، [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTitle)، و [getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCreatedTime). يفتح هذا المثال عرضًا تقديميًا موجودًا ويطبع البيانات المخزنة إلى وحدة التحكم. القيم تعتمد على العرض المُدخل؛ قد تكون بعض الحقول فارغة.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

### **تقرير رقم المراجعة وزمن التحرير**

للتقرير عن رقم المراجعة وإجمالي زمن التحرير لكل ملف PPTX في مجلد `presentations`، استخدم [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) لقراءة [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) الخاصة به دون تحميل الشرائح للتحرير. تُعيد واجهة PHP عبر Java زمن التحرير بالمللي ثانية. يحول المثال ذلك إلى ساعات ودقائق وثوانٍ ويشمل عدد الأيام للمدة التي تتجاوز 24 ساعة.

```php
use aspose\slides\PresentationFactory;

echo "File | RevisionNumber | TotalEditingTime\n";
foreach (new GlobIterator("presentations/*.pptx") as $file) {
    if (!$file->isFile()) {
        continue;
    }

    $info = PresentationFactory::getInstance()->getPresentationInfo($file->getRealPath());
    $properties = $info->readDocumentProperties();
    $totalSeconds = (int) (java_values($properties->getTotalEditingTime()) / 1000);
    $days = intdiv($totalSeconds, 86400);
    $time = sprintf("%02d:%02d:%02d", intdiv($totalSeconds, 3600) % 24, intdiv($totalSeconds, 60) % 60, $totalSeconds % 60);
    $editingTime = $days > 0 ? $days . "." . $time : $time;
    printf("%s | %d | %s\n", $file->getFilename(), java_values($properties->getRevisionNumber()), $editingTime);
}
```

لعرض تقديمي يحتوي على رقم مراجعة 17 وزمن تحرير مسجل قدره يوم واحد وساعتان و5 دقائق، يظهر التقرير المخرجات التالية.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[DocumentProperties::getRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getRevisionNumber) يقرأ قيمة يمكن للتطبيقات تغييرها باستخدام [DocumentProperties::setRevisionNumber](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setRevisionNumber). رقم المراجعة وحده لا يمكنه تحديد عدد مرات حفظ العرض التقديمي أو إعادة بناء تاريخ إصداراته.

[DocumentProperties::getTotalEditingTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getTotalEditingTime) يقرأ مدة التحرير المسجلة في الملف. قد يحتوي العرض التقديمي على مدة مخزنة صفر (`00:00:00`) حتى ولو أن أحداً قام بتحريره.

## **تعديل الخصائص المدمجة**

لتحديث البيانات المدمجة، استخدم أساليب setter على الكائن الذي تُرجعه [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDocumentProperties). يفتح هذا المثال عرضًا تقديميًا موجودًا، يستدعي [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setComments), و [setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setManager), ثم يحفظ العرض المحدث باستخدام [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save). يحتوي ملف PPTX المحفوظ على البيانات الجديدة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **إدارة القاعدة الأساسية للروابط التشعبية**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getHyperlinkBase) تُرجع القاعدة على مستوى المستند للروابط التشعبية النسبية. استخدم [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setHyperlinkBase) لتغييرها أو مسحها. هذا مفيد عند نقل عرض تقديمي وملفاته المرتبطة إلى موقع آخر. وهو منفصل عن [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/#getExternalUrl) الخاص بالرابط التشعبي الفردي: تغيير القاعدة لا يعيد كتابة عناوين الروابط المخزنة ولا يغيّر الوجهات المطلقة.

يتطلب المثال عرضًا تقديميًا يحتوي على رابط نسبي، مثل `target.html`، ورابط مطلق، مثل `https://example.org/absolute.html`. يقرأ القاعدة الحالية، يعيّن قاعدة جديدة، ثم يحفظ ويعيد فتح العرض للتحقق من القيمة. ثم يمسح القاعدة بسلسلة فارغة ويتحقق من القيمة الفارغة في ملف محفوظ منفصل. استبدل عنوان القاعدة في المثال بموقع ملفاتك المرتبطة.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

يجب أن تطبع رسالتا التحقق `true`. مسح القاعدة يترك عناوين الروابط التشعبية الفردية دون تغيير.

رابط نسبي إلى `target.pptx` فتح `old/target.pptx` عندما كانت القاعدة تشير إلى المجلد `old`. بعد تغيير القاعدة إلى المجلد `new`، وحفظ وإعادة فتح العرض، فتح نفس الرابط `new/target.pptx`. استمر الرابط المطلق في فتح نفس الملف. اختبر الروابط النسبية في PowerPoint قبل وبعد نقل العرض أو تغيير قاعدته.

## **إضافة خصائص عرض تقديمي مخصصة**

تخزن الخصائص المخصصة بيانات تعريف لا يوجد لها حقل مدمج مكافئ. تسمح طريقة [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item) لك بتعيين قيمة حسب اسم الخاصية. يخلق هذا المثال عرضًا تقديميًا، يضيف قيمتي نص وقيمة عددية للإصدار، ويحفظ العرض باستخدام [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save). تعيين قيمة لاسم موجود يستبدل قيمة الخاصية.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **الوصول إلى وتعديل الخصائص المخصصة**

يفتح هذا المثال عرضًا تقديميًا يحتوي على خصائص مخصصة ويستخدم [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCountOfCustomProperties) للتكرار عليها. تقبل [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getCustomPropertyName) فهرسًا يبدأ من الصفر وتُرجع الاسم المستخدم بواسطة [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#set_Item). يطبع المثال كل اسم أصلي وقيمته، يستبدل كل قيمة بسلسلة مرقمة بغض النظر عن نوعها الأصلي، ويحفظ التغييرات. إذا لم توجد خصائص مخصصة، فإن الحلقة لا تُجري أي تغييرات.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **مثال حي**

جرّب التطبيق على الإنترنت [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) لترى كيفية العمل مع خصائص المستند باستخدام Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء أساسي من العرض التقديمي ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كفارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، فستُستبدل قيمتها الموجودة بالجديدة. لا تحتاج إلى إزالة الخاصية أو فحصها مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/#getPresentationInfo) ثم [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/#readDocumentProperties) لقراءة بيانات المستند المخزنة دون إنشاء نسخة من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) . راجع [Build a Lightweight Presentation Inventory](/slides/ar/php-java/examine-presentation/) للحصول على مثال تقرير كامل والقيود الخاصة بالصيغ.

**هل يمكنني قراءة الخصائص العامة لعرض تقديمي مشفر دون كلمة المرور المفتوحة؟**

نعم. يجب أن يكون العرض التقديمي قد تم تشفيره بعد استدعاء [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) مع القيمة `false`، ويجب تحميله بعد استدعاء [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) مع القيمة `true`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع خصائص المستند فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة والمشفرة متسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض التقديمي بالكامل مع كلمة المرور المفتوحة الصحيحة.