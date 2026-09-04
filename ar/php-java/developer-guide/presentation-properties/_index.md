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
- بيانات المستند الوصفية
- تحرير البيانات الوصفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides for PHP عبر Java وسهّل البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **مدمجة** و **مخصصة**. يمكن الوصول إلى كلا النوعين وإدارتهما بسهولة باستخدام Aspose.Slides API.

يسمح Aspose.Slides لك بالعمل مع خصائص مستند العرض التقديمي من خلال الفئة [DocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/) . يتم إرجاع كائن من هذه الفئة بواسطة الطريقة [Presentation::getDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getDocumentProperties). توضح الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="ملاحظة" %}}

يرجى ملاحظة أن حقلي **Application** و **AppVersion** لا يمكن تعديلهما. يقوم Aspose.Slides بإعادة كتابة هذين الحقلين في كل عملية حفظ، لذا فإن العرض المحفوظ دائماً يظهر "Aspose.Slides for PHP via Java" وإصدار المكتبة التي أنشأته. يتم تجاهل أي قيمة يتم تمريرها إلى `setNameOfApplication` عند كتابة العرض.

{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

يتيح Microsoft PowerPoint ميزة إضافة بعض الخصائص إلى ملفات العروض التقديمية. تسمح هذه الخصائص بتخزين معلومات مفيدة مع المستندات (ملفات العرض). هناك نوعان من خصائص المستند كما يلي

- خصائص معرفة بالنظام (مضمنة)
- خصائص معرفة من قبل المستخدم (مخصصة)

الخصائص **المضمنة** تحتوي على معلومات عامة عن المستند مثل عنوان المستند، اسم المؤلف، إحصائيات المستند وغيرها. الخصائص **المخصصة** هي التي يحددها المستخدم كـ **اسم/قيمة**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for PHP via Java، يمكن للمطورين الوصول إلى قيم الخصائص المدمجة وكذلك الخصائص المخصصة وتعديلها.

## **خصائص المستند في PowerPoint**

يسمح Microsoft PowerPoint 2007 بإدارة خصائص مستند ملفات العرض. كل ما عليك فعله هو النقر على أيقونة Office ثم اختيار **Prepare | Properties | Advanced Properties** كما هو موضح أدناه:

|**اختيار عنصر القائمة Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
بعد اختيار عنصر القائمة **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص مستند ملف PowerPoint كما هو موضح في الشكل أدناه:

|**حوار الخصائص**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
في **حوار الخصائص** أعلاه، يمكنك رؤية العديد من صفحات التبويب مثل **General** و **Summary** و **Statistics** و **Contents** و **Custom**. تسمح جميع صفحات التبويب هذه بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم صفحة **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

### العمل مع خصائص المستند باستخدام Aspose.Slides for PHP via Java

كما شرحنا مسبقاً أن Aspose.Slides for PHP via Java يدعم نوعين من خصائص المستند، وهما الخصائص **المدمجة** و **المخصصة**. لذلك، يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام Aspose.Slides for PHP via Java API. يوفر Aspose.Slides for PHP via Java الفئة [DocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties) التي تمثل خصائص المستند المرتبطة بملف العرض عبر خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام خاصية **DocumentProperties** التي يفرِضها كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation) للوصول إلى خصائص المستند لملفات العرض كما هو موضح أدناه:

## **قراءة الخصائص العامة من عرض مشفر**

عادةً ما يحمي كلمة مرور الفتح كلًا من محتوى العرض وخصائص المستند. عندما يتم تشفير عرض بتمرير `false` إلى الطريقة [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)، تظل خصائص المستند عامة. يمكن للتطبيق بعد ذلك تمرير `true` إلى الطريقة [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) وقراءة البيانات الوصفية العامة دون توفير كلمة مرور الفتح.

خيار تحميل خصائص المستند فقط يتحكم في ما يقوم Aspose.Slides بتحميله؛ لا يقوم بفك تشفير أي شيء. إذا كانت الخصائص مشمولة في التشفير، فستفشل عملية التحميل بدون كلمة المرور. إذا لم يكن العرض مشفراً، يتم تجاهل الخيار ويتم تحميل العرض بالكامل.

المثال التالي يتحقق من وضع التحميل عبر الطريقة [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) ثم يقرأ الخصائص المدمجة عبر الطريقة [Presentation::getDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

في هذا الوضع لا يتم تحميل محتوى الشريحة. الشرائح، الأُساتيد، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائمًا فحص [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ar/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) قبل تنفيذ عملية تتطلب نموذج كائن العرض الكامل.

{{% alert color="warning" title="تحذير" %}}
قد تكشف البيانات الوصفية العامة عن أسماء المؤلفين والعناوين والمواضيع والكلمات المفتاحية ومعلومات الشركة والتعليقات والقيم المخصصة. شفر الخصائص الحساسة مع العرض. اجعلها عامة فقط عندما تتطلب أنظمة الفهرسة أو التصنيف أو البحث أو إدارة المستندات ذلك دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض مشفر**

بالنسبة إلى ملف PPTX مشفر، فإن العرض المُحمَّل في وضع خصائص المستند فقط يهدف إلى قراءة البيانات الوصفية العامة. لا يمكن لـ Aspose.Slides حفظ الخصائص المتغيرة من ذلك الكائن لأن الخصائص العامة يجب أن تبقى متسقة مع البيانات المقابلة داخل العرض المشفر. لذلك يتطلب تحديثها كلمة مرور الفتح الصحيحة وتحميلًا كاملاً.

المثال التالي يفتح العرض باستخدام الطريقة [LoadOptions::setPassword](https://reference.aspose.com/slides/ar/php-java/aspose.slides/loadoptions/#setPassword)، يحدث الخصائص المدمجة العامة، ثم يحفظ النتيجة. بعد ذلك يستخدم الطريقة [PresentationInfo::isEncrypted](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#isEncrypted) للتحقق من بقاء التشفير، ويعيد فتح البيانات الوصفية العامة بدون كلمة مرور للتأكد من القيم الجديدة:

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
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
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
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض، يجب أن يعامل الخصائص العامة لملف PPTX المشفر كقراءة‑فقط.

## **الوصول إلى الخصائص المدمجة**

تشمل الخصائص التي تُظهرها كائن [DocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **SharedDoc** (هل يُشارك بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

```php
  # إنشاء كائن فئة Presentation الذي يمثل العرض التقديمي
  $pres = new Presentation("Presentation.pptx");
  try {
    # إنشاء إشارة إلى كائن IDocumentProperties المرتبط بالعرض التقديمي
    $dp = $pres->getDocumentProperties();
    # عرض الخصائص المدمجة
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعديل الخصائص المدمجة**

تعديل الخصائص المدمجة لملفات العرض سهل مثل الوصول إليها. يمكنك ببساطة إسناد قيمة نصية إلى أي خاصية مرغوبة وسيتم تعديل قيمة الخاصية. في المثال أدناه، عرضنا كيف يمكننا تعديل الخصائص المدمجة للمستند باستخدام Aspose.Slides for PHP via Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # إنشاء إشارة إلى كائن IDocumentProperties المرتبط بالعرض التقديمي
    $dp = $pres->getDocumentProperties();
    # تعيين الخصائص المدمجة
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # حفظ العرض التقديمي إلى ملف
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

هذا المثال يُظهر الخصائص المدمجة للعرض بعد التعديل كما هو موضح أدناه:

|**خصائص المستند المدمجة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص مستند مخصصة**

يسمح Aspose.Slides for PHP via Java أيضًا للمطورين بإضافة القيم المخصصة لخصائص مستند العرض. المثال أدناه يوضح كيفية تعيين الخصائص المخصصة للعرض.

```php
  $pres = new Presentation();
  try {
    # الحصول على خصائص المستند
    $dProps = $pres->getDocumentProperties();
    # إضافة خصائص مخصصة
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # الحصول على اسم الخاصية في الفهرس المحدد
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # إزالة الخاصية المحددة
    $dProps->removeCustomProperty($getPropertyName);
    # حفظ العرض التقديمي
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**تمت إضافة خصائص المستند المخصصة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى الخصائص المخصصة وتعديلها**

يسمح Aspose.Slides for PHP via Java للمطورين أيضًا بالوصول إلى قيم الخصائص المخصصة. المثال أدناه يوضح كيف يمكنك الوصول إلى جميع هذه الخصائص المخصصة للعرض وتعديلها.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # إنشاء إشارة إلى كائن DocumentProperties المرتبط بالعرض التقديمي
    $dp = $pres->getDocumentProperties();
    # الوصول إلى الخصائص المخصصة وتعديلها
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # عرض أسماء وقيم الخصائص المخصصة
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # تعديل قيم الخصائص المخصصة
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # حفظ العرض التقديمي إلى ملف
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

هذا المثال يوضح تعديل الخصائص المخصصة للعرض [PPTX](https://docs.fileformat.com/presentation/pptx/). توضح الأشكال التالية خصائص العرض المخصصة قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**الخصائص المخصصة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="info" title="ملاحظة" %}}

تمت إضافة الطرق الجديدة [readDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)، [updateDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) و [writeBindedPresentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) إلى الفئة [PresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo)، وتم تغيير منطق مُعين الخاصية [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#setLastSavedTime).

{{% /alert %}} 

تمت إضافة الطريقتين الجديدتين [readDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) و [updateDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) إلى الفئة [PresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo). توفران وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض بالكامل.

يمكن تنفيذ السيناريو النموذجي بتحميل الخصائص، تعديل بعض القيم، ثم تحديث المستند كما يلي:

```php
  # قراءة معلومات العرض التقديمي
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # الحصول على الخصائص الحالية
  $props = $info->readDocumentProperties();
  # تعيين القيم الجديدة لحقلي المؤلف والعنوان
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # تحديث العرض التقديمي بالقيم الجديدة
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

هناك طريقة أخرى لاستخدام خصائص عرض معين كقالب لتحديث الخصائص في عروض أخرى:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

يمكن إنشاء قالب جديد من الصفر ثم استخدامه لتحديث عدة عروض:

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **تعيين لغة التدقيق**

يوفر Aspose.Slides الخاصية LanguageId (المعروضة بواسطة فئة PortionFormat) لتسمح لك بتعيين لغة التدقيق لوثيقة PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

يعرض هذا الكود PHP كيفية تعيين لغة التدقيق لـ PowerPoint: xxx لماذا LanguageId مفقودة في فئة Java PortionFormat؟

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// تعيين معرف لغة التدقيق

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين اللغة الافتراضية**

يعرض هذا الكود PHP كيفية تعيين اللغة الافتراضية لكامل عرض PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # يضيف شكل مستطيل جديد مع نص
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # يتحقق من لغة الجزء الأول
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **مثال حي**

جرّب تطبيق [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) عبر الإنترنت لترى كيفية العمل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها فارغة إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخصية أو التحقق منها مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/) ثم [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#readDocumentProperties) لقراءة البيانات الوصفية المخزنة دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) . راجع [Build a Lightweight Presentation Inventory](/slides/ar/php-java/examine-presentation/) للحصول على مثال تقرير كامل والقيود الخاصة بكل تنسيق.

**هل يمكنني قراءة الخصائص العامة لعرض مشفر دون كلمة مرور الفتح؟**

نعم. يجب أن تكون عملية تشفير خاصية المستند قد أُلغيت قبل تشفير العرض، ويجب تحميل العرض في وضع خصائص المستند فقط.

**هل يمكنني تحديث ملف PPTX مشفر في وضع خصائص المستند فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة والمشفرة متسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض بالكامل مع كلمة مرور الفتح الصحيحة.