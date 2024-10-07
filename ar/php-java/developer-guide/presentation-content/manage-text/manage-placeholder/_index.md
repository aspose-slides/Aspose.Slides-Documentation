---
title: إدارة العنصر النائب
type: docs
weight: 10
url: /php-java/manage-placeholder/
description: تغيير النص في عنصر نائب في شرائح PowerPoint باستخدام PHP. تعيين نص提示 في عنصر نائب في شرائح PowerPoint باستخدام PHP.
---

## **تغيير النص في العنصر النائب**
باستخدام [Aspose.Slides لـ PHP عبر Java](/slides/php-java/)، يمكنك العثور على العناصر النائبة وتعديلها في الشرائح داخل العروض التقديمية. يتيح لك Aspose.Slides إجراء تغييرات على النص في العنصر النائب.

**المتطلبات الأساسية**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض التقديمي في تطبيق Microsoft PowerPoint القياسي.

هذا هو كيفية استخدام Aspose.Slides لاستبدال النص في العنصر النائب في ذلك العرض التقديمي:

1. قم بإنشاء كائن من فئة [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وقم بتمرير العرض التقديمي كوسيط.
2. احصل على مرجع للشرائح من خلال فهرسها.
3. قم بتكرار الأشكال للعثور على العنصر النائب.
4. قم بتحويل شكل العنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) وغيّر النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) المرتبط بـ [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. احفظ العرض التقديمي المعدل.

يوضح كود PHP هذا كيفية تغيير النص في عنصر نائب:

```php
  # إنشاء كائن من فئة Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # التكرار عبر الأشكال للعثور على العنصر النائب
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # تغيير النص في كل عنصر نائب
        $shp->getTextFrame()->setText("هذا هو العنصر النائب");
      }
    }
    # حفظ العرض التقديمي على القرص
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين نص提示 في العنصر النائب**
تحتوي التخطيطات القياسية والمعدة مسبقًا على نصوص提示 للعنصر النائب مثل ***انقر لإضافة عنوان*** أو ***انقر لإضافة عنوان فرعي***. باستخدام Aspose.Slides، يمكنك إدراج نصوص提示 المفضلة لديك في تخطيطات العناصر النائبة.

يوضح كود PHP هذا كيفية تعيين نص提示 في العنصر النائب:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # التكرار عبر الشريحة
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint يعرض "انقر لإضافة عنوان"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "أضف عنوانًا";
        } else // إضافة عنوان فرعي
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "أضف عنوانًا فرعيًا";
        }
        $shape->getTextFrame()->setText($text);
        echo("العنصر النائب مع النص: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تعيين شفافية صورة العنصر النائب**

يتيح لك Aspose.Slides تعيين شفافية الصورة الخلفية في عنصر نائب نصي. من خلال ضبط شفافية الصورة في مثل هذا الإطار، يمكنك جعل النص أو الصورة بارزًا (اعتمادًا على ألوان النص والصورة).

يوضح كود PHP هذا كيفية تعيين الشفافية لخلفية صورة (داخل شكل):

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("قيمة الشفافية الحالية: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```