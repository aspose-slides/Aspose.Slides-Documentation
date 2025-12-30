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
- تحرير بيانات التعريف
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides لـ PHP عبر Java وابدأ في تحسين البحث والعلامة التجارية وتدفق العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---

{{% alert color="primary" %}} 

يوفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العروض التقديمية. تسمح هذه الخصائص المستندية بتخزين معلومات مفيدة جنبًا إلى جنب مع المستندات (ملفات العروض التقديمية). هناك نوعان من الخصائص المستندية كما يلي

- خصائص معرفة من النظام (مضمنة)
- خصائص معرفة من قبل المستخدم (مخصصة)

**المضمنة** تحتوي على معلومات عامة حول المستند مثل عنوان المستند، اسم المؤلف، إحصائيات المستند وغيرها. **المخصصة** هي تلك التي يحددها المستخدمون كأزواج **اسم/قيمة**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for PHP عبر Java، يمكن للمطورين الوصول إلى قيم الخصائص المضمنة وكذلك الخصائص المخصصة وتعديلها.

{{% /alert %}} 

## **خصائص المستند في PowerPoint**

يتيح Microsoft PowerPoint 2007 إدارة خصائص المستند لملفات العروض التقديمية. كل ما عليك فعله هو النقر على أيقونة Office ثم اختيار العنصر **Prepare | Properties | Advanced Properties** في قائمة Microsoft PowerPoint 2007 كما هو موضح أدناه:

{{% alert color="primary" %}} 

يرجى ملاحظة أنك لا يمكن تعيين قيم لحقلَي **Application** و **Producer**, لأن Aspose Ltd. و Aspose.Slides for PHP عبر Java x.x.x سيتم عرضه في هذه الحقول.

{{% /alert %}} 

|**تحديد عنصر قائمة Advanced Properties**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

بعد تحديدك لعنصر قائمة **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص المستند لملف PowerPoint كما هو موضح في الشكل أدناه:

|**حوار الخصائص**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

في **حوار الخصائص** أعلاه، يمكنك رؤية أن هناك العديد من صفحات التبويب مثل **General**, **Summary**, **Statistics**, **Contents** و **Custom**. تتيح جميع هذه الصفحات تكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. يتم استخدام تبويب **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

العمل مع خصائص المستند باستخدام Aspose.Slides for PHP عبر Java

كما وصفنا سابقًا، يدعم Aspose.Slides for PHP عبر Java نوعين من خصائص المستند، وهما الخصائص **المضمنة** والخصائص **المخصصة**. لذا يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام واجهة برمجة تطبيقات Aspose.Slides for PHP عبر Java. يوفر Aspose.Slides for PHP عبر Java فئة [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) التي تمثل خصائص المستند المرتبطة بملف عرض تقديمي من خلال خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام خاصية **IDocumentProperties** التي يقدمها كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) للوصول إلى خصائص المستند لملفات العروض التقديمية كما هو موضح أدناه:

## **الوصول إلى الخصائص المضمنة**

تشمل هذه الخصائص التي يقدمها كائن [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) ما يلي: **Creator** (المؤلف)، **Description**، **Keywords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ آخر طباعة)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل يتم مشاركة المستند بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**
```php
  # إنشاء كائن Presentation الذي يمثل العرض التقديمي
  $pres = new Presentation("Presentation.pptx");
  try {
    # إنشاء مرجع لكائن IDocumentProperties المرتبط بالعرض التقديمي
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

تعديل الخصائص المضمنة لملفات العروض التقديمية سهل بقدر الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية مرغوبة وسيتم تعديل قيمة الخاصية. في المثال أدناه، لقد أوضحنا كيف يمكن تعديل خصائص المستند المضمنة لملف العرض باستخدام Aspose.Slides for PHP عبر Java.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # إنشاء مرجع لكائن IDocumentProperties المرتبط بالعرض التقديمي
    $dp = $pres->getDocumentProperties();
    # ضبط الخصائص المدمجة
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


يقوم هذا المثال بتعديل الخصائص المضمنة للعرض التقديمي، ويمكن مشاهدة النتيجة كما هو موضح أدناه:

|**خصائص المستند المضمنة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص مستند مخصصة**

يسمح Aspose.Slides for PHP عبر Java للمطورين أيضًا بإضافة القيم المخصصة لخصائص مستند العرض التقديمي. يُظهر المثال أدناه كيفية تعيين الخصائص المخصصة لعرض تقديمي.
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


|**خصائص مستند مخصصة مضافة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى الخصائص المخصصة وتعديلها**

يسمح Aspose.Slides for PHP عبر Java للمطورين أيضًا بالوصول إلى قيم الخصائص المخصصة. يُظهر المثال أدناه كيفية الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # إنشاء مرجع لكائن DocumentProperties المرتبط بالعرض التقديمي
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


يقوم هذا المثال بتعديل الخصائص المخصصة للملف [PPTX](https://docs.fileformat.com/presentation/pptx/). تُظهر الأشكال التالية الخصائص المخصصة للعرض قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**الخصائص المخصصة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **خصائص المستند المتقدمة**

{{% alert color="primary" %}} 

تم إضافة طرق جديدة [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)، و[WriteBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) إلى [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo)، وتم تغيير منطق المحدد (setter) للخاصية [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-).

{{% /alert %}} 

تمت إضافة الطريقتين الجديدتين [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--) و[UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo). توفران وصولًا سريعًا إلى خصائص المستند وتسمحان بتغيير وتحديث الخصائص دون تحميل العرض بالكامل.

يمكن تنفيذ السيناريو النموذجي لتحميل الخصائص، تعديل قيمة ما، ثم تحديث المستند على النحو التالي:
```php
  # قراءة معلومات العرض التقديمي
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # الحصول على الخصائص الحالية
  $props = $info->readDocumentProperties();
  # تعيين القيم الجديدة لحقلي المؤلف والعنوان
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # تحديث العرض التقديمي بقيم جديدة
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

توفر Aspose.Slides الخاصية LanguageId (المعروضة بواسطة فئة PortionFormat) لتتيح لك تعيين لغة التدقيق لملف PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

يعرض هذا الكود PHP كيفية تعيين لغة التدقيق لملف PowerPoint: xxx لماذا الخاصية LanguageId مفقودة في فئة Java PortionFormat؟
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


## **تعيين اللغة الافتراضية**

يعرض هذا الكود PHP كيفية تعيين اللغة الافتراضية لملف عرض تقديمي كامل في PowerPoint:
```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");
$pres = new Presentation($loadOptions);
try {
    # يضيف شكلًا مستطيلًا جديدًا مع نص
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # يفحص لغة الجزء الأول
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
} finally {
    if (!java_is_null($pres)) {
        $pres->dispose();
    }
}
```


## **مثال حي**

جرب تطبيق [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) على الإنترنت لترى كيفية العمل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مضمنة من عرض تقديمي؟**

الخصائص المضمنة هي جزء أساسي من العرض التقديمي ولا يمكن إزالتها تمامًا. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها فارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة مسبقًا؟**

إذا أضفت خاصية مخصصة موجودة مسبقًا، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم، يمكنك الوصول إلى خصائص العرض دون تحميله بالكامل باستخدام طريقة `getPresentationInfo` من فئة [PresentationFactory](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/). ثم استخدم طريقة `readDocumentProperties` المتوفرة في فئة [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/) لقراءة الخصائص بفعالية، مما يوفر الذاكرة ويحسن الأداء.