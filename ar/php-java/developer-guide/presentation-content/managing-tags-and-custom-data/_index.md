---
title: إدارة العلامات والبيانات المخصصة في العروض التقديمية باستخدام PHP
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/php-java/managing-tags-and-custom-data/
keywords:
- خصائص المستند
- علامة
- بيانات مخصصة
- إضافة علامة
- قيم أزواج
- PowerPoint
- عرض تقديمي
- PHP
- Aspose.Slides
description: "تعلم كيف تضيف وتقرأ وتحدث وتزيل العلامات والبيانات المخصصة في Aspose.Slides للـ PHP عبر Java، مع أمثلة لعروض PowerPoint وعروض OpenDocument."
---

## **تخزين البيانات في ملفات العروض التقديمية**

ملفات PPTX—العناصر ذات الامتداد .pptx—يتم تخزينها بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يُعرّف تنسيق Office Open XML بنية البيانات الموجودة في العروض التقديمية. 

مع اعتبار *الشريحة* واحدة من عناصر العروض التقديمية، يحتوي جزء الشريحة (*slide part*) على محتوى شريحة واحدة. يُسمح لجزء الشريحة أن يمتلك علاقات صريحة مع العديد من الأجزاء—مثل العلامات المعرفة من قبل المستخدم—المحددة وفقًا لـ ISO/IEC 29500. 

يمكن أن توجد البيانات المخصصة (الخاصة بعرض تقديمي) أو المستخدم على شكل علامات ([TagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/)) وCustomXmlParts ([CustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 

العلامات هي في الأساس قيم أزواج مفتاح‑سلسلة. 

{{% /alert %}} 

## **الحصول على قيم العلامات**

في الشرائح، تتطابق العلامة مع طريقتي [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getKeywords) و[DocumentProperties::setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setKeywords). يُظهر هذا المثال البرمجي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides للـ PHP عبر Java لـ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation):
```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **إضافة علامات إلى العروض التقديمية**

تتيح لك Aspose.Slides إضافة علامات إلى العروض التقديمية. عادةً ما تتكون العلامة من عنصرين:

- اسم الخاصية المخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض التقديمية بناءً على قاعدة أو خاصية معينة، فقد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا أردت تجميع جميع العروض من دول شمال أمريكا معًا، يمكنك إنشاء علامة “North American” ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

هذا المثال البرمجي يُظهر كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) باستخدام Aspose.Slides للـ PHP عبر Java:
```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


يمكن أيضًا تعيين العلامات لـ [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/):
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


أو لأي [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) فردي:
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. يدعم [مجموعة العلامات](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة مرةً واحدة.

**كيف أحذف علامة واحدة بحسب اسمها دون التكرار على كامل المجموعة؟**

استخدم عملية [remove(name)](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/remove/) على [مجموعة العلامات](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرداد القائمة الكاملة لأسماء العلامات لأغراض التحليل أو التصفية؟**

استخدم [getNamesOfTags](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/getnamesoftags/) على [مجموعة العلامات](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/)؛ ستعيد مصفوفة بجميع أسماء العلامات.