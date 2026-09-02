---
title: "إدارة خصائص العرض التقديمي في PHP"
linktitle: "خصائص العرض التقديمي"
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
- بيانات وصفية للمستند
- تحرير البيانات الوصفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إتقان خصائص العرض التقديمي في Aspose.Slides للـ PHP عبر Java وتبسيط البحث والتميز وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---
## **المقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **مضمنة** و **مخصصة**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتهما بسهولة باستخدام API الخاص بـ Aspose.Slides.

يتيح Aspose.Slides لك العمل مع خصائص مستند العرض التقديمي عبر الفئة [DocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/) . يتم إرجاع كائن من هذه الفئة بواسطة الطريقة [Presentation::getDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/#getDocumentProperties) . توضح الأمثلة التالية كيفية قراءة وتعديل وإدارة هذه الخصائص.

{{% alert color="info" title="Note" %}}
يرجى ملاحظة أن حقلي **Application** و **AppVersion** لا يمكن تعديلهما. يقوم Aspose.Slides بإعادة كتابتهما في كل عملية حفظ، لذلك دائمًا ما يُظهر العرض المحفوظ "Aspose.Slides for PHP via Java" وإصدار المكتبة التي أنشأته. أي قيمة تُمرّر إلى `setNameOfApplication` تُهمل عند كتابة العرض.
{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

يوفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العروض التقديمية. تسمح هذه الخصائص المستندية بتخزين بعض المعلومات المفيدة جنبًا إلى جنب مع المستندات (ملفات العروض). هناك نوعان من خصائص المستند كما يلي:

- خصائص معرفة بالنظام (مضمنة)
- خصائص معرفة من قبل المستخدم (مخصصة)

تحتوي الخصائص **المضمنة** على معلومات عامة حول المستند مثل عنوان المستند، اسم المؤلف، إحصاءات المستند، وما إلى ذلك. أما الخصائص **المخصصة** فهي تلك التي يُعرّفها المستخدمون كأزواج **اسم/قيمة**، حيث يتم تحديد كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for PHP via Java، يمكن للمطورين الوصول إلى قيم الخصائص المضمنة وكذلك الخصائص المخصصة وتعديلها.

## **خصائص المستند في PowerPoint**

يسمح Microsoft PowerPoint 2007 بإدارة خصائص المستند لملفات العروض التقديمية. كل ما عليك فعله هو النقر على أيقونة Office ثم اختيار **Prepare | Properties | Advanced Properties** في Microsoft PowerPoint 2007 كما هو موضح أدناه:

|**تحديد عنصر القائمة Advanced Properties**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
بعد اختيار عنصر القائمة **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص المستند لملف PowerPoint كما هو موضح في الشكل أدناه:

|**حوار الخصائص**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
في **حوار الخصائص** أعلاه، يمكنك أن ترى العديد من علامات التبويب مثل **General** و **Summary** و **Statistics** و **Contents** و **Custom**. تسمح جميع هذه العلامات بتكوين معلومات مختلفة متعلقة بملفات PowerPoint. تُستخدم علامة **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

### العمل مع خصائص المستند باستخدام Aspose.Slides for PHP via Java

كما أوضحنا سابقًا، يدعم Aspose.Slides for PHP via Java نوعين من خصائص المستند، وهما الخصائص **المضمنة** و **المخصصة**. لذا يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام API الخاص بـ Aspose.Slides for PHP via Java. يوفر Aspose.Slides for PHP via Java الفئة [DocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties) التي تمثل خصائص المستند المرتبطة بملف عرض تقديمي عبر خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام خاصية **DocumentProperties** التي يطرحها كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation) للوصول إلى خصائص المستند لملفات العروض التقديمية كما هو موضح أدناه:

## **الوصول إلى الخصائص المضمنة**

تتضمن الخصائص التي تُظهرها كائن [DocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **SharedDoc** (هل هو مشترك بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

```php
  # إنشاء كائن من الفئة Presentation الذي يمثل العرض التقديمي
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

## **تعديل الخصائص المضمنة**

تعديل الخصائص المضمنة لملفات العروض التقديمية سهل كما هو الحال في الوصول إليها. يمكنك ببساطة إسناد قيمة نصية إلى أي خاصية مرغوبة وستُعدَّل قيمة الخاصية. في المثال أدناه، أبرزنا كيفية تعديل خصائص المستند المضمنة لملف العرض باستخدام Aspose.Slides for PHP via Java.

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
    # حفظ العرض التقديمي في ملف
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

يُظهر هذا المثال الخصائص المضمنة للعرض بعد تعديلها كما هو موضح أدناه:

|**خصائص المستند المضمنة بعد التعديل**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص مستند مخصصة**

يسمح Aspose.Slides for PHP via Java للمطورين أيضًا بإضافة قيم مخصصة لخصائص مستند العرض التقديمي. يُظهر المثال أدناه كيفية تعيين الخصائص المخصصة للعرض.

```php
  $pres = new Presentation();
  try {
    # الحصول على خصائص المستند
    $dProps = $pres->getDocumentProperties();
    # إضافة خصائص مخصصة
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # الحصول على اسم الخاصية عند فهرس معين
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

|**تم إضافة خصائص مستند مخصصة**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى الخصائص المخصصة وتعديلها**

يسمح Aspose.Slides for PHP via Java للمطورين أيضًا بالوصول إلى قيم الخصائص المخصصة. يُظهر المثال أدناه كيفية الوصول إلى جميع هذه الخصائص المخصصة للعرض وتعديلها.

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
    # حفظ العرض التقديمي في ملف
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

يُعدل هذا المثال الخصائص المخصصة للعرض التقديمي [PPTX](https://docs.fileformat.com/presentation/pptx/). تُظهر الأشكال التالية خصائص العرض المخصصة قبل وبعد التعديل:

|**الخصائص المخصّصة قبل التعديل**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**الخصائص المخصّصة بعد التعديل**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="info" title="Note" %}}
تمت إضافة طرق جديدة هي [readDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)، [updateDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) و [writeBindedPresentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) إلى الفئة [PresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo). تم تغيير منطق مُعيّن الخاصية [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#setLastSavedTime).
{{% /alert %}} 

أضيفت الطريقتان الجديدتان [readDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) و [updateDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) إلى الفئة [PresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/PresentationInfo). توفران وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض بالكامل.

يمكن تنفيذ السيناريو النموذجي بتحميل الخصائص، تغيير بعض القيم وتحديث المستند بالطريقة التالية:

```php
  # قراءة معلومات العرض التقديمي
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # الحصول على الخصائص الحالية
  $props = $info->readDocumentProperties();
  # تعيين القيم الجديدة لحقل المؤلف والعنوان
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # تحديث العرض التقديمي بالقيم الجديدة
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

هناك طريقة أخرى لاستخدام خصائص عرض تقديمي معين كقالب لتحديث الخصائص في عروض تقديمية أخرى:

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

يمكن إنشاء قالب جديد من الصفر ثم استخدامه لتحديث عدة عروض تقديمية:

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

يوفر Aspose.Slides الخاصية LanguageId (المُطلقة من فئة PortionFormat) لتسمح لك بتعيين لغة التدقيق لملف PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

يعرض هذا الشيفرة PHP كيفية تعيين لغة التدقيق لملف PowerPoint: xxx لماذا LanguageId مفقودة من فئة Java PortionFormat؟

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

تعرض هذه الشيفرة PHP كيفية تعيين اللغة الافتراضية لكامل عرض PowerPoint:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # أضف شكل مستطيل جديد مع نص
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # يفحص لغة المقطع الأول
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **مثال حي**

جرّب التطبيق الإلكتروني [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) لرؤية كيفية العمل مع خصائص المستند عبر API الخاص بـ Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مضمّنة من العرض التقديمي؟**

الخصائص المضمّنة جزء أساسي من العرض ولا يمكن إزالتها تمامًا. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها فارغة إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة مسبقًا، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقًا، حيث يقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationfactory/) ثم [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentationinfo/#readDocumentProperties) لقراءة البيانات الوصفية للمستند المخزنة دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/presentation/) . راجع [Build a Lightweight Presentation Inventory](/slides/ar/php-java/examine-presentation/) للحصول على مثال تقارير كامل والقيود الخاصة بكل تنسيق.