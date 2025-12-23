---
title: إدارة عناصر النائب في العرض التقديمي باستخدام PHP
linktitle: إدارة عناصر النائب
type: docs
weight: 10
url: /ar/php-java/manage-placeholder/
keywords:
- عنصر نائب
- عنصر نائب نصي
- عنصر نائب صورة
- عنصر نائب مخطط
- نص إرشادي
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "إدارة عناصر النائب بسهولة في Aspose.Slides لـ PHP عبر Java: استبدال النص، تخصيص النصوص الإرشادية وتعيين شفافية الصورة في PowerPoint وOpenDocument."
---

## **تغيير النص في عنصر نائب**
باستخدام [Aspose.Slides لـ PHP عبر Java](/slides/ar/php-java/)، يمكنك العثور على عناصر نائب وتعديلها على الشرائح في العروض التقديمية. يسمح Aspose.Slides لك بإجراء تغييرات على النص داخل عنصر نائب.

**المتطلبات المسبقة**: تحتاج إلى عرض تقديمي يحتوي على عنصر نائب. يمكنك إنشاء مثل هذا العرض في تطبيق Microsoft PowerPoint القياسي.

إليك الطريقة التي تستخدم بها Aspose.Slides لاستبدال النص في عنصر نائب في ذلك العرض:

1. إنشاء كائن من الفئة [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) وتمرير العرض التقديمي كمعامل.
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. التمرّ عبر الأشكال للعثور على عنصر نائب.
4. تحويل نوع شكل عنصر النائب إلى [`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape) وتغيير النص باستخدام [`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame) المرتبط بـ[`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape).
5. حفظ العرض التقديمي المعدَّل.

هذا الكود PHP يوضح كيفية تغيير النص في عنصر نائب:
```php
  # ينشئ كائنًا من فئة Presentation
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # يتنقل عبر الأشكال للعثور على العنصر النائب
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # يغيّر النص في كل عنصر نائب
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # يحفظ العرض التقديمي إلى القرص
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين نص إرشادي في عنصر نائب**
تحتوي القوالب القياسية والمُعدة مسبقًا على نصوص إرشادية لعناصر النائب مثل ***انقر لإضافة عنوان*** أو ***انقر لإضافة عنوان فرعي***. باستخدام Aspose.Slides، يمكنك إدراج نصوص إرشادية مفضلة لديك في تخطيطات عناصر النائب.

هذا الكود PHP يوضح كيفية تعيين النص الإرشادي في عنصر نائب:
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # يتنقل عبر الشريحة
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint يعرض "انقر لإضافة عنوان"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // يضيف عنوانًا فرعيًا
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **تعيين شفافية صورة عنصر نائب**

يسمح Aspose.Slides لك بتعيين شفافية صورة الخلفية في عنصر نائب نصي. من خلال تعديل شفافية الصورة داخل هذا الإطار، يمكنك إبراز النص أو الصورة (اعتمادًا على ألوان النص والصورة).

هذا الكود PHP يوضح كيفية تعيين شفافية خلفية الصورة (داخل شكل):
```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**ما هو عنصر نائب أساسي، وكيف يختلف عن الشكل المحلي على الشريحة؟**

عنصر نائب أساسي هو الشكل الأصلي الموجود في تخطيط أو ماستر تُورّث منه أشكال الشريحة—النوع، الموقع، وبعض التنسيق يأتي منه. الشكل المحلي يكون مستقلاً؛ إذا لم يكن هناك عنصر نائب أساسي، لا يُطبق الوراثة.

**كيف يمكنني تحديث جميع العناوين أو الشروحات عبر العرض التقديمي دون المرور على كل شريحة؟**

قم بتعديل عنصر نائب المقابل في التخطيط أو الماستر. الشرائح التي تعتمد على تلك التخطيطات/الماستر ستورّث التغيير تلقائيًا.

**كيف أتحكم في عناصر النائب القياسية للترويسة/التذييل—التاريخ والوقت، رقم الشريحة، ونص التذييل؟**

استخدم مديرات HeaderFooter في النطاق المناسب (الشرائح العادية، التخطيطات، الماستر، الملاحظات/النشرات) لتفعيل أو إلغاء تفعيل تلك العناصر وتعيين محتواها.