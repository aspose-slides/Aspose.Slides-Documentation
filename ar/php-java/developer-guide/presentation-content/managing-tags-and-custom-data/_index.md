---
title: إدارة العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/php-java/managing-tags-and-custom-data

---

## تخزين البيانات في ملفات العرض

ملفات PPTX—العناصر ذات امتداد .pptx—مخزنة بتنسيق PresentationML، وهو جزء من مواصفات Office Open XML. يحدد تنسيق Office Open XML الهيكل الخاص بالبيانات الموجودة في العروض التقديمية.

مع كون *الشريحة* واحدة من العناصر في العروض التقديمية، تحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بوجود علاقات صريحة مع العديد من الأجزاء—مثل العلامات المعرفة من قبل المستخدم—المحددة بواسطة ISO/IEC 29500.

يمكن أن توجد البيانات المخصصة (الخاصة بعرض تقديمي معين) أو المستخدم كعلامات ([ITagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ITagCollection)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICustomXmlPartCollection)).

{{% alert color="primary" %}} 

العلامات هي في الأساس قيم أزواج مفتاح-قيمة نصية.

{{% /alert %}} 

## الحصول على القيم للعلامات

في الشرائح، تتوافق علامة مع [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#getKeywords--) و[IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) الطريقتين. يُظهر لك هذا كود العينة كيفية الحصول على قيمة علامة باستخدام Aspose.Slides لـ PHP عبر Java لـ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation):

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

## إضافة علامات إلى العروض التقديمية

يسمح لك Aspose.Slides بإضافة علامات إلى العروض التقديمية. عادةً ما تتكون العلامة من عنصرين:

- اسم ك propiedad مخصص - `MyTag`
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض التقديمية بناءً على قاعدة أو خاصية معينة، فقد تستفيد من إضافة علامات إلى تلك العروض التقديمية. على سبيل المثال، إذا كنت ترغب في تصنيف أو وضع جميع العروض التقديمية من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة أمريكية شمالية ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

يظهر لك هذا كود العينة كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) باستخدام Aspose.Slides لـ PHP عبر Java:

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

أو أي [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) فردية:

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