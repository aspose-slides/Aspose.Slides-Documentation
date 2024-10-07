---
title: خصائص العرض
type: docs
weight: 70
url: /php-java/presentation-properties/
---

{{% alert color="primary" %}} 

يوفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العرض. تسمح هذه الخصائص الوثائقية بتخزين معلومات مفيدة مع الوثائق (ملفات العرض). هناك نوعان من الخصائص الوثائقية كما يلي:

- الخصائص المحددة من النظام (المدمجة)
- الخصائص المعرفة من قبل المستخدم (مخصصة)

**الخصائص المدمجة** تحتوي على معلومات عامة حول الوثيقة مثل عنوان الوثيقة، اسم المؤلف، إحصائيات الوثيقة، وما إلى ذلك. **الخصائص المخصصة** هي تلك المعرفة من قبل المستخدمين كأزواج **اسم/قيمة**، حيث يتم تعريف كل من الاسم والقيمة بواسطة المستخدم. باستخدام Aspose.Slides لـ PHP عبر Java، يمكن للمطورين الوصول إلى القيم الموجودة في الخصائص المدمجة وكذلك الخصائص المخصصة وتعديلها.

{{% /alert %}} 

## **خصائص الوثيقة في PowerPoint**
يسمح Microsoft PowerPoint 2007 بإدارة الخصائص الوثائقية لملفات العرض. كل ما عليك فعله هو النقر على أيقونة Office ومن ثم اختيار **إعداد | خصائص | خصائص متقدمة** كما هو موضح أدناه:

{{% alert color="primary" %}} 

يرجى ملاحظة أنه لا يمكنك ضبط القيم ضد حقول **التطبيق** و **المنتج**، لأن Aspose Ltd. و Aspose.Slides لـ PHP عبر Java x.x.x ستظهر ضد هذه الحقول.

{{% /alert %}} 

|**اختيار عنصر قائمة الخصائص المتقدمة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
بعد اختيار عنصر قائمة **الخصائص المتقدمة**، سيظهر مربع حوار يسمح لك بإدارة الخصائص الوثائقية لملف PowerPoint كما هو موضح في الشكل أدناه:

|**مربع الحوار الخاص بالخصائص**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
في **مربع الحوار الخاص بالخصائص** أعلاه، يمكنك رؤية العديد من الصفحات مثل **عام**، **ملخص**، **إحصائيات**، **المحتويات** و **مخصصة**. تسمح جميع هذه الصفحات بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. الصفحة **المخصصة** تستخدم لإدارة الخصائص المخصصة لملفات PowerPoint.

## العمل مع الخصائص الوثائقية باستخدام Aspose.Slides لـ PHP عبر Java

كما وصفنا سابقًا، تدعم Aspose.Slides لـ PHP عبر Java نوعين من الخصائص الوثائقية، وهما الخصائص **المدمجة** و **المخصصة**. لذا، يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java. توفر Aspose.Slides لـ PHP عبر Java فئة [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) التي تمثل الخصائص الوثائقية المرتبطة بملف العرض من خلال خاصية **Presentation.DocumentProperties**.

يمكن للمطورين استخدام خاصية **IDocumentProperties** المعروضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) للوصول إلى الخصائص الوثائقية لملفات العرض كما هو موضح أدناه:

## **الوصول إلى الخصائص المدمجة**
تشمل هذه الخصائص كما هو موضح بواسطة كائن [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties): **المنشئ** (المؤلف)، **الوصف**، **الكلمات الرئيسية**، **تاريخ الإنشاء**، **تاريخ التعديل**، **تاريخ الطباعة الأخير**، **آخر تعديل بواسطة**، **الكلمات الرئيسية**، **المستند المشترك** (هل تشارك بين منتجين مختلفين؟)، **تنسيق العرض**، **الموضوع** و **العنوان**.

```php
  # إنشاء مثيل لفئة العرض التي تمثل العرض
  $pres = new Presentation("Presentation.pptx");
  try {
    # إنشاء مرجع لكائن IDocumentProperties المرتبط بالعرض
    $dp = $pres->getDocumentProperties();
    # عرض الخصائص المدمجة
    echo("الفئة : " . $dp->getCategory());
    echo("الحالة الحالية : " . $dp->getContentStatus());
    echo("تاريخ الإنشاء : " . $dp->getCreatedTime());
    echo("المؤلف : " . $dp->getAuthor());
    echo("الوصف : " . $dp->getComments());
    echo("الكلمات الرئيسية : " . $dp->getKeywords());
    echo("آخر تعديل بواسطة : " . $dp->getLastSavedBy());
    echo("المشرف : " . $dp->getManager());
    echo("تاريخ التعديل : " . $dp->getLastSavedTime());
    echo("تنسيق العرض : " . $dp->getPresentationFormat());
    echo("تاريخ الطباعة الأخير : " . $dp->getLastPrinted());
    echo("هل مشترك بين المنتجين : " . $dp->getSharedDoc());
    echo("الموضوع : " . $dp->getSubject());
    echo("العنوان : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعديل الخصائص المدمجة**
يعد تعديل الخصائص المدمجة لملفات العرض سهلاً مثل الوصول إليها. يمكنك ببساطة تعيين قيمة سلسلة لأي خاصية مرغوبة وسيتم تعديل قيمة الخاصية. في المثال المعطى أدناه، أظهرنا كيف يمكننا تعديل الخصائص الوثائقية المدمجة لملف العرض باستخدام Aspose.Slides لـ PHP عبر Java.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # إنشاء مرجع لكائن IDocumentProperties المرتبط بالعرض
    $dp = $pres->getDocumentProperties();
    # ضبط الخصائص المدمجة
    $dp->setAuthor("Aspose.Slides لـ PHP عبر Java");
    $dp->setTitle("تعديل خصائص العرض");
    $dp->setSubject("موضوع Aspose");
    $dp->setComments("وصف Aspose");
    $dp->setManager("مدير Aspose");
    # حفظ عرضك إلى ملف
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

يعدل هذا المثال الخصائص المدمجة للعروض التي يمكن عرضها كما هو موضح أدناه:

|**الخصائص الوثائقية المدمجة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **إضافة خصائص وثائقية مخصصة**
يسمح Aspose.Slides لـ PHP عبر Java أيضًا للمطورين بإضافة القيم المخصصة لخصائص الوثائق المتعلقة بالعروض. مثال موضح أدناه يظهر كيفية تعيين الخصائص المخصصة لعرض تقديمي.

```php
  $pres = new Presentation();
  try {
    # الحصول على الخصائص الوثائقية
    $dProps = $pres->getDocumentProperties();
    # إضافة خصائص مخصصة
    $dProps->set_Item("مخصص جديد", 12);
    $dProps->set_Item("اسمي", "مُدَصِّر");
    $dProps->set_Item("مخصص", 124);
    # الحصول على اسم الخاصية عند فهرس معين
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # إزالة الخاصية المختارة
    $dProps->removeCustomProperty($getPropertyName);
    # حفظ العرض
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**الخصائص الوثائقية المخصصة المضافة**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **الوصول إلى وتعديل الخصائص المخصصة**
يسمح Aspose.Slides لـ PHP عبر Java أيضًا للمطورين بالوصول إلى قيم الخصائص المخصصة. مثال موضح أدناه يظهر كيفية الوصول إلى وتعديل جميع هذه الخصائص المخصصة لعروض تقديمية.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # إنشاء مرجع لكائن DocumentProperties المرتبط بالعرض
    $dp = $pres->getDocumentProperties();
    # الوصول إلى وتعديل الخصائص المخصصة
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # عرض أسماء وقيم الخصائص المخصصة
      echo("اسم الخاصية المخصصة : " . $dp->getCustomPropertyName($i));
      echo("قيمة الخاصية المخصصة : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # تعديل قيم الخصائص المخصصة
      $dp->set_Item($dp->getCustomPropertyName($i), "قيمة جديدة " . $i + 1);
    }
    # حفظ عرضك إلى ملف
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

هذا المثال يعدل الخصائص المخصصة لـ [PPTX](https://docs.fileformat.com/presentation/pptx/) العرض. تظهر الأشكال التالية خصائص العرض المخصصة قبل وبعد التعديل:

|**الخصائص المخصصة قبل التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**الخصائص المخصصة بعد التعديل**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **الخصائص الوثائقية المتقدمة**
{{% alert color="primary" %}} 

تمت إضافة طرق جديدة [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--)، [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) و [WriteBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo)، وقد تغير منطق ضبط الخاصية [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-).

{{% /alert %}} 

تمت إضافة طريقتين جديدتين [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--) و [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) إلى واجهة [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo). توفر هذه الطرق وصولًا سريعًا إلى الخصائص الوثائقية وتسمح بتغيير وتحديث الخصائص دون تحميل العرض الكامل.

يمكن تنفيذ السيناريو النموذجي لتحميل الخصائص، وتغيير بعض القيم وتحديث الوثيقة بالطريقة التالية:

```php
  # قراءة معلومات العرض
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # الحصول على الخصائص الحالية
  $props = $info->readDocumentProperties();
  # ضبط القيم الجديدة لحقول المؤلف والعنوان
  $props->setAuthor("مؤلف جديد");
  $props->setTitle("عنوان جديد");
  # تحديث العرض بقيم جديدة
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");

```

هناك طريقة أخرى لاستخدام خصائص عرض معين كقالب لتحديث الخصائص في عروض أخرى:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("مؤلف القالب");
  $template->setTitle("عنوان القالب");
  $template->setCategory("فئة القالب");
  $template->setKeywords("الكلمة1، الكلمة2، الكلمة3");
  $template->setCompany("شركتنا");
  $template->setComments("أنشئ من القالب");
  $template->setContentType("محتوى القالب");
  $template->setSubject("موضوع القالب");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

يمكن إنشاء قالب جديد من الصفر ثم استخدامه لتحديث عدة عروض:

```php
  $template = new DocumentProperties();
  $template->setAuthor("مؤلف القالب");
  $template->setTitle("عنوان القالب");
  $template->setCategory("فئة القالب");
  $template->setKeywords("الكلمة1، الكلمة2، الكلمة3");
  $template->setCompany("شركتنا");
  $template->setComments("أنشئ من القالب");
  $template->setContentType("محتوى القالب");
  $template->setSubject("موضوع القالب");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

## **تحقق مما إذا كان العرض معدلاً أو تم إنشاؤه**
توفر Aspose.Slides لـ PHP عبر Java إمكانية التحقق مما إذا كان العرض قد تم تعديله أو إنشاؤه. المثال المعطى أدناه يوضح كيف تتحقق مما إذا كان العرض قد تم إنشاؤه أو تعديله.

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("props.pptx");
  $props = $info->readDocumentProperties();
  $app = $props->getNameOfApplication();
  $ver = $props->getAppVersion();
  echo("اسم التطبيق: " . $app);
  echo("إصدار التطبيق: " . $ver);

```

## **تعيين لغة التدقيق**

يوفر Aspose.Slides خاصية LanguageId (المعروضة بواسطة فئة PortionFormat) للسماح لك بتعيين لغة التدقيق لوثيقة PowerPoint. لغة التدقيق هي اللغة التي يتم فيها التحقق من الأخطاء الإملائية والنحوية في PowerPoint.

يوضح هذا الكود PHP كيفية تعيين لغة التدقيق لوثيقة PowerPoint: xxx لماذا لغة LanguageId مفقودة من فئة PortionFormat في Java؟

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

يوضح هذا الكود PHP كيفية تعيين اللغة الافتراضية لعرض PowerPoint كامل:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # إضافة شكل مستطيل جديد مع نص
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("نص جديد");
    # التحقق من لغة الجزء الأول
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```