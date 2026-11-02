---
title: إ管理خصائص العرض التقديمي في PHP
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
- تحرير البيانات التعريفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides للـ PHP عبر Java وسهل عملية البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **مقدمة**

Aspose.Slides for PHP عبر Java يدعم الخصائص **المدمجة** والخصائص **المخصصة** للمستند. استخدم هذه الخصائص لقراءة وتحديث بيانات تعريف العرض التقديمي، مثل المؤلف، العنوان، والقيم المعرفة من قبل المستخدم.

Aspose.Slides يسمح لك بالعمل مع خصائص مستندات العرض التقديمي عبر الفئة [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) . يتم إرجاع مثيل من هذه الفئة بواسطة [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). توضح الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها. تفترض أن جسر PHP/Java وملف wrapper الخاص بـ Aspose.Slides للـ PHP مهيئان.

{{% alert color="info" title="Note" %}}
Aspose.Slides يدير بيانات التعريف الخاصة بالتطبيق والمنتج عند حفظ العروض التقديمية؛ هذه الحقول تحدد البرنامج الذي أنشأ الناتج.
{{% /alert %}}

## **إدارة خصائص العرض التقديمي**

تخزن خصائص المستند معلومات وصفية جنباً إلى جنب مع محتوى العرض التقديمي. وتنقسم إلى فئتين:

- **خصائص مدمجة** تحتوي على بيانات تعريف قياسية، مثل العنوان، المؤلف، وإحصاءات المستند.
- **خصائص مخصصة** تخزن أزواج اسم/قيمة يحددها المستخدم.

Aspose.Slides for PHP عبر Java يتيح الوصول إلى كلا الفئتين. في PowerPoint، اختر **File → Info → Properties → Advanced Properties** لتفقد بيانات تعريف المستند. يجمع الحوار المعلومات في علامات تبويب مثل **Summary**، **Statistics**، **Contents**، و**Custom**. استخدم علامة تبويب **Custom** لإدارة الخصائص التي يحددها المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما يحمي كلمة مرور الفتح كل من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير عرض تقديمي بعد استدعاء [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) مع `false`، تظل خصائص المستند عامة. يمكن لتطبيق بعد ذلك استدعاء [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) مع `true` وقراءة البيانات العامة بدون توفير كلمة مرور الفتح.

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) يتحكم فيما يقوم Aspose.Slides بتحميله؛ لا يقوم بفك التشفير بأي شيء. إذا تم تضمين الخصائص في التشفير، فإن تحميلها بدون كلمة المرور سيفشل. إذا لم يكن العرض مشفراً، يتم تجاهل الخيار ويتم تحميل العرض بالكامل.

يتطلب المثال عرضاً تقديمياً مشفراً تم ترك خصائص مستنده عامة. يتحقق من وضع التحميل عبر [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) ثم يقرأ الخصائص المدمجة عبر [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/):

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

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائماً التحقق من [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) قبل تنفيذ عملية تتطلب نموذج كائن العرض الكامل.

{{% alert color="warning" title="Warning" %}}
قد تكشف البيانات العامة عن أسماء المؤلفين، العناوين، المواضيع، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة. شفر الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما تكون أنظمة الفهرسة أو التصنيف أو البحث أو إدارة المستندات تحتاج إلى الوصول إليها بدون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

بالنسبة لملف PPTX مشفر، فإن العرض الذي يتم تحميله بعد استدعاء [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) مع `true` مخصص لقراءة البيانات العامة. لا يستطيع Aspose.Slides حفظ الخصائص المعدلة من هذا الكائن الذي يقتصر على البيانات العامة لأن الخصائص العامة يجب أن تظل متناسقة مع البيانات المقابلة داخل العرض المشفر. لذلك يتطلب تحديثها كلمة مرور الفتح الصحيحة وتحميل كامل.

يتطلب المثال عرض تقديمي PPTX مشفر يحتوي على خصائص مستند عامة وكلمة مرور فتح معروفة. يفتح العرض الكامل باستخدام [LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/)، يحدّث الخصائص المدمجة العامة، ثم يحفظ النتيجة. بعد ذلك يستخدم [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) للتحقق من بقاء التشفير ويعيد فتح البيانات العامة بدون كلمة مرور للتحقق من القيم الجديدة:

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

إذا لم تسمح التطبيق بفك تشفير أو تحميل محتوى العرض، يجب التعامل مع الخصائص العامة لملف PPTX مشفر كقراءة فقط.

## **الوصول إلى الخصائص المدمجة**

الفئة [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) تكشف عن البيانات المدمجة عبر طرق getter، بما في ذلك [getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/)، [getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/)، و[getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/). يفتح هذا المثال عرضًا تقديميًا موجودًا ويطبع البيانات المخزنة إلى وحدة التحكم. القيم تعتمد على العرض المدخل؛ قد تكون بعض الحقول فارغة.

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

## **تعديل الخصائص المدمجة**

لتحديث البيانات المدمجة، استخدم طرق setter على الكائن الذي تُرجعه [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/). يفتح هذا المثال عرضًا تقديميًا موجودًا، يستدعي [setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/)، [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/)، [setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/)، [setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/)، و[setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/)، ثم يحفظ العرض المحدث باستخدام [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). يحتوي ملف PPTX المحفوظ على البيانات المدمجة الجديدة.

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

## **إدارة قاعدة الارتباط التشعبي**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) تُعيد القاعدة على مستوى المستند للارتباطات التشعبية النسبية. استخدم [DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) لتغييرها أو مسحها. هذا مفيد عند نقل عرض تقديمي وملفاته المرتبطة إلى موقع آخر. إنه منفصل عن [Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/) لارتباط تشعبي فردي: تغيير القاعدة لا يعيد كتابة عناوين الروابط المخزنة ولا يغير الوجهات المطلقة.

يتطلب المثال عرضًا يحتوي على رابط نسبي مثل `target.html` ورابط مطلق مثل `https://example.org/absolute.html`. يقرأ القاعدة الحالية، يعيّن قاعدة جديدة، ثم يحفظ ويعيد فتح العرض للتحقق من القيمة. بعد ذلك يمسح القاعدة بسلسلة فارغة ويُثبت القيمة الفارغة في ملف محفوظ منفصل. استبدل قاعدة المثال بموقع ملفاتك المرتبطة.

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

يجب أن تُظهر رسائل التحقق الثنائية القيمة `true`. مسح القاعدة يترك عناوين الروابط الفردية كما هي.

رابط نسبي إلى `target.pptx` كان يفتح `old/target.pptx` عندما كانت القاعدة تشير إلى مجلد `old`. بعد تغيير القاعدة إلى مجلد `new`، وحفظ وإعادة فتح العرض، يفتح الرابط نفسه `new/target.pptx`. الرابط المطلق استمر في فتح الملف نفسه. اختبر روابطك النسبية في PowerPoint قبل وبعد نقل العرض أو تغيير قاعدته.

## **إضافة خصائص عرض تقديمي مخصصة**

الخصائص المخصصة تخزن بيانات تعريف لا توجد لها حقل مدمج مقابل. يسمح الأسلوب [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) بتعيين قيمة باسم الخاصية. يخلق هذا المثال عرضًا تقديميًا، يضيف قيمتي نص وإصدار رقمي، ويحفظ العرض باستخدام [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/). تعيين قيمة لاسم موجود يستبدل قيمة الخاصية الحالية.

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

## **الوصول إلى الخصائص المخصصة وتعديلها**

يفتح هذا المثال عرضًا يحتوي على خصائص مخصصة ويستخدم [getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) للتمرير فوقها. [getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) يستقبل فهرسًا يبدأ من الصفر ويرجع الاسم المستخدم بواسطة [DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/). يطبع المثال كل اسم وقيمة أصلية، ويستبدل كل قيمة بسلسلة مرقمة بغض النظر عن نوعها الأصلي، ثم يحفظ التغييرات. إذا لم توجد خصائص مخصصة، فلن يقوم الحلقة بأي تغييرات.

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

جرّب التطبيق عبر الإنترنت [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) لترى كيفية العمل مع خصائص المستند باستخدام واجهة Aspose.Slides API:

[![عرض وتحرير بيانات PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها بالكامل. مع ذلك، يمكنك إما تغيير قيمها أو تعيينها كفارغة إذا سمح ذلك الخاصية المحددة.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة مسبقاً؟**

إذا أضفت خاصية مخصصة موجودة مسبقاً، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقاً، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائياً.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) ثم [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) لقراءة بيانات المستند المخزنة دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). راجع [Build a Lightweight Presentation Inventory](/slides/ar/php-java/examine-presentation/) لتفاصيل مثال التقرير الكامل والقيود الخاصة بالصيغة.

**هل يمكنني قراءة الخصائص العامة لعرض تقديمي مشفر بدون كلمة مرور الفتح؟**

نعم. يجب أن يكون العرض قد تم تشفيره بعد استدعاء [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) مع `false`، ويجب تحميله بعد استدعاء [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) مع `true`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع تحميل خصائص المستند فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة والمشفرة متناسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض بالكامل باستخدام كلمة مرور الفتح الصحيحة.