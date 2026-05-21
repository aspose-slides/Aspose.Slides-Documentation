---
title: إدارة العلامات والبيانات المخصصة في العروض باستخدام PHP
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
description: "تعلم كيفية إضافة وقراءة وتحديث وإزالة العلامات والبيانات المخصصة في Aspose.Slides للـ PHP عبر Java، مع أمثلة لعروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية عمل Aspose.Slides مع العلامات والبيانات المخصصة في عروض PowerPoint. وتُشير باختصار إلى كيفية تخزين البيانات في ملفات PPTX، وتُلاحظ أن البيانات الخاصة بالعرض يمكن أن توجد كعلامات وأجزاء XML مخصصة، وتُوصف العلامات بأنها أزواج سلسلة مفتاح‑قيمة.

كما تُظهر كيفية قراءة قيم العلامات وكيفية إضافة علامات إلى عرض تقديمي أو شريحة فردية أو شكل. بالإضافة إلى ذلك، تغطي المقالة مهام إدارة العلامات الشائعة مثل مسح جميع العلامات، وإزالة علامة حسب الاسم، واسترجاع قائمة بأسماء العلامات.

## **تخزين البيانات في ملفات العرض**

ملفات PPTX—العناصر ذات الامتداد .pptx—مخزنة بصيغة PresentationML، وهي جزء من مواصفات Office Open XML. تحدد صيغة Office Open XML هيكل البيانات الموجودة في العروض.

مع كون *الشريحة* أحد عناصر العروض، يحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بوجود علاقات صريحة إلى العديد من الأجزاء—مثل العلامات المعرفة من قبل المستخدم—المحددة في ISO/IEC 29500.

يمكن أن توجد البيانات المخصصة (الخاصة بعرض تقديمي) أو للمستخدم كعلامات ([TagCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/)) وأجزاء XML مخصصة ([CustomXmlPartCollection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/customxmlpartcollection/)).

{{% alert color="primary" %}} 

العلامات هي في الأساس قيم أزواج مفتاح‑سلسلة. 

{{% /alert %}} 

## **الحصول على قيم العلامات**

في الشرائح، تتطابق العلامة مع طريقتي [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#getKeywords) و[DocumentProperties::setKeywords()](https://reference.aspose.com/slides/ar/php-java/aspose.slides/documentproperties/#setKeywords). يُظهر هذا المثال البرمجي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides للـ PHP عبر Java لـ [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation):

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

## **إضافة العلامات إلى العروض**

يتيح لك Aspose.Slides إضافة العلامات إلى العروض. عادةً ما تتكون العلامة من عنصرين: 

- اسم الخاصية المخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا احتجت إلى تصنيف بعض العروض بناءً على قاعدة أو خاصية معينة، فقد تستفيد من إضافة العلامات إلى تلك العروض. على سبيل المثال، إذا رغبت في تجميع جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة "أمريكا الشمالية" ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقِيَم. 

هذا المثال البرمجي يُظهر كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/ar/php-java/aspose.slides/Presentation) باستخدام Aspose.Slides للـ PHP عبر Java:

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

يمكن أيضًا تعيين العلامات لـ [Slide](https://reference.aspose.com/slides/ar/php-java/aspose.slides/slide/):

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

أو لأي [Shape](https://reference.aspose.com/slides/ar/php-java/aspose.slides/shape/) فردي:

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

### **القيود**

العلامات التي تُضاف عبر مجموعة علامات البيانات المخصصة باستخدام `getCustomData()->getTags()` تُحفظ فقط داخل ملف PowerPoint. وهي **غير** مُنقولة إلى بنية علامات PDF عند تصدير العرض إلى PDF. وبالتالي، لا يمكن استرجاع المعرف المخصص المُعين كعلامة من ملف PDF المُوسوم.

**حل بديل**: يمكنك تخزين معرف مخصص في **النص البديل** للكائن (مثال، `$shape->setAlternativeText("MyId")`). بعد تصدير إلى PDF، قد يظهر النص البديل في بنية علامات PDF.

## **الأسئلة الشائعة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل بعملية واحدة؟**

نعم. يدعم [tag collection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑قيمة مرة واحدة.

**كيف أحذف علامة واحدة باستخدام اسمها دون الحاجة إلى التكرار عبر المجموعة بأكملها؟**

استخدم عملية [remove(name)](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/remove/) على [tag collection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/) لحذف العلامة وفقًا لمفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [getNamesOfTags](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/getnamesoftags/) على [tag collection](https://reference.aspose.com/slides/ar/php-java/aspose.slides/tagcollection/); يرجع مصفوفة بجميع أسماء العلامات.