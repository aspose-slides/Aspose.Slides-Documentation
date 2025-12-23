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
description: "تعلم كيفية إضافة، قراءة، تحديث، وإزالة العلامات والبيانات المخصصة في Aspose.Slides للـ PHP عبر Java، مع أمثلة لعروض PowerPoint وعروض OpenDocument."
---

## **تخزين البيانات في ملفات العرض**

ملفات PPTX—العناصر ذات الامتداد .pptx—تُخزن بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد تنسيق Office Open XML الهيكل للبيانات الموجودة في العروض التقديمية. 

مع كون *slide* أحد العناصر في العروض التقديمية، يحتوي *slide part* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بأن يكون له علاقات صريحة مع العديد من الأجزاء—مثل العلامات المعرفة من قبل المستخدم—المعرفة وفقًا لـ ISO/IEC 29500. 

يمكن أن توجد البيانات المخصصة (الخاصة بعرض تقديمي) أو للمستخدم كعلامات ([ITagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ITagCollection)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 
العلامات هي أساسًا قيم أزواج مفتاح-سلسلة. 
{{% /alert %}} 

## **الحصول على قيم العلامات**

في الشرائح، تتطابق علامة مع طريقتي [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#getKeywords--) و[IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) . تُظهر لك عينة الشيفرة كيفية الحصول على قيمة علامة باستخدام Aspose.Slides للـ PHP عبر Java لـ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation):
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

Aspose.Slides يتيح لك إضافة علامات إلى العروض التقديمية. عادةً ما تتكون العلامة من عنصرين:
- اسم الخاصية المخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا احتجت إلى تصنيف بعض العروض التقديمية بناءً على قاعدة أو خاصية معينة، فقد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا أردت تصنيف أو تجميع جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة أمريكا الشمالية ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

تُظهر لك عينة الشيفرة كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) باستخدام Aspose.Slides للـ PHP عبر Java:
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


يمكن أيضًا تعيين العلامات لـ [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide):
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


أو لأي [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) فردي:
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


## **الأسئلة الشائعة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. تدعم [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة مرة واحدة.

**كيف أحذف علامة واحدة باسمها دون التكرار عبر المجموعة كاملة؟**

استخدم عملية [Remove(name)](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/remove/) على [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استخراج القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [getNamesOfTags](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/getnamesoftags/) على [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/); تُعيد مصفوفة بجميع أسماء العلامات.