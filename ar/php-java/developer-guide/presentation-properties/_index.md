---
title: إدارة خصائص العروض التقديمية في PHP
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
- تحرير بيانات التعريف
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إتقان خصائص العروض التقديمية في Aspose.Slides لـ PHP عبر Java وتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---

{{% alert color="primary" %}} 

توفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العروض التقديمية. تسمح هذه الخصائص بتخزين معلومات مفيدة إلى جانب المستندات (ملفات العرض). هناك نوعان من خصائص المستند كما يلي

- خصائص معرفة نظاميًا (مدمجة)
- خصائص معرفة من قبل المستخدم (مخصصة)

تحتوي الخصائص **المدمجة** على معلومات عامة عن المستند مثل عنوان المستند، اسم المؤلف، إحصاءات المستند وغيرها. الخصائص **المخصصة** هي تلك التي يحددها المستخدم كأزواج **اسم/قيمة**، حيث يحدد المستخدم كلًا من الاسم والقيمة. باستخدام Aspose.Slides for PHP via Java، يمكن للمطورين الوصول إلى قيم الخصائص المدمجة وكذلك الخصائص المخصصة وتعديلها.

{{% /alert %}} 

## **خصائص المستند في PowerPoint**

تتيح Microsoft PowerPoint 2007 إدارة خصائص المستند لملفات العروض. كل ما عليك هو النقر على أيقونة Office ثم اختيار **Prepare | Properties | Advanced Properties** كما هو موضح أدناه:

{{% alert color="primary" %}} 

يرجى ملاحظة أنه لا يمكنك تعيين قيم لحقلي **Application** و **Producer**، حيث سيتم عرض Aspose Ltd. و Aspose.Slides for PHP via Java x.x.x في هذين الحقلين.

{{% /alert %}} 

|**اختيار عنصر القائمة Advanced Properties**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| ** **|
بعد اختيار عنصر القائمة **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص المستند لملف PowerPoint كما هو موضح في الشكل أدناه:

|**حوار الخصائص**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| ** **|
في **حوار الخصائص** أعلاه، يمكنك رؤية عدة صفحات تبويب مثل **General**، **Summary**، **Statistics**، **Contents** و **Custom**. تسمح جميع هذه الصفحات بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم تبويب **Custom** لإدارة الخصائص المخصصة للملفات.

### العمل مع خصائص المستند باستخدام Aspose.Slides for PHP via Java

كما وصفنا سابقًا، يدعم Aspose.Slides for PHP via Java نوعين من خصائص المستند: **المدمجة** و **المخصصة**. لذا يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام API الخاص بـ Aspose.Slides for PHP via Java. توفر Aspose.Slides for PHP via Java فئة [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties) التي تمثل خصائص المستند المرتبطة بملف العرض عبر الخاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام الخاصية **DocumentProperties** التي يطرحها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) للوصول إلى خصائص المستند للعرض كما هو موضح أدناه:

## **الوصول إلى الخصائص المدمجة**

تشمل الخصائص التي تقدمها كائن [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **SharedDoc** (هل تمت مشاركته بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.
```php
  # إنشاء كائن من فئة Presentation التي تمثل العرض التقديمي
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

تعديل الخصائص المدمجة لملفات العرض سهل كما هو الحال عند الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية ترغب فيها وسيتم تعديل قيمة الخاصية. في المثال أدناه، نوضح كيفية تعديل خصائص المستند المدمجة للملف باستخدام Aspose.Slides for PHP via Java.
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


هذا المثال يعدل الخصائص المدمجة للعرض كما هو موضح أدناه:

|**خصائص المستند المدمجة بعد التعديل**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| ** **|

## **إضافة خصائص مستند مخصصة**

يسمح Aspose.Slides for PHP via Java أيضًا للمطورين بإضافة قيم مخصصة لخصائص المستند الخاصة بالعرض. المثال أدناه يوضح كيفية ضبط الخصائص المخصصة لعرض ما.
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


|**تمت إضافة خصائص المستند المخصصة**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| ** **|

## **الوصول إلى الخصائص المخصصة وتعديلها**

يسمح Aspose.Slides for PHP via Java أيضًا للمطورين بالوصول إلى قيم الخصائص المخصصة. المثال أدناه يوضح كيفية الوصول إلى جميع هذه الخصائص المخصصة لعرض وتعديلها.
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


هذا المثال يعدل الخصائص المخصصة للـ [PPTX](https://docs.fileformat.com/presentation/pptx/) العرض. توضح الأشكال التالية خصائص العرض المخصصة قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| ** **|

|**الخصائص المخصصة بعد التعديل**|** **|
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| ** **|

## **خصائص المستند المتقدمة**

{{% alert color="primary" %}} 

تمت إضافة الطرق الجديدة [readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)، [updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) و [writeBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) إلى الفئة [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo). تم تغيير منطق مُعيّن الخاصية [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setLastSavedTime).

{{% /alert %}} 

تمت إضافة الطريقتين الجديدتين [readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) و [updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) إلى الفئة [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo). توفران وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض بأكمله.

يمكن تنفيذ السيناريو النموذجي لتحميل الخصائص، تغيير قيمة ما وتحديث المستند كما يلي:
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


## **تحديد لغة التدقيق**

توفر Aspose.Slides الخاصية LanguageId (المقدمة من فئة PortionFormat) لتسمح لك بتحديد لغة التدقيق لملف PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

يعرض هذا الكود PHP كيفية تحديد لغة التدقيق لملف PowerPoint: xxx لماذا LanguageId مفقودة من فئة Java PortionFormat؟
```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// تعيين معرف لغة التدقيق

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تحديد اللغة الافتراضية**

يعرض هذا الكود PHP كيفية تحديد اللغة الافتراضية لكامل عرض PowerPoint:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # إضافة شكل مستطيل جديد مع نص
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # التحقق من لغة الجزء الأول
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **مثال حي**

جرّب تطبيق [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) عبر الإنترنت لتستكشف كيفية العمل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مدمجة من العرض؟**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها تمامًا. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كقيمة فارغة إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث تقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض دون تحميله بالكامل؟**

نعم، يمكنك الوصول إلى خصائص العرض دون تحميله بالكامل باستخدام طريقة `getPresentationInfo` من الفئة [PresentationFactory](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/). بعد ذلك، استخدم طريقة `readDocumentProperties` المقدمة من فئة [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/) لقراءة الخصائص بكفاءة، مما يوفر الذاكرة ويحسن الأداء.