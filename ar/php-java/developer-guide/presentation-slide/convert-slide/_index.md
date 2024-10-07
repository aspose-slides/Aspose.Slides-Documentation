---
title: تحويل الشريحة
type: docs
weight: 35
url: /php-java/convert-slide/
keywords: 
- تحويل الشريحة إلى صورة
- تصدير الشريحة كصورة
- حفظ الشريحة كصورة
- الشريحة إلى صورة
- الشريحة إلى PNG
- الشريحة إلى JPEG
- الشريحة إلى بت ماب
- PHP
- Aspose.Slides لـ PHP عبر Java
description: "تحويل الشريحة من PowerPoint إلى صورة (بت ماب، PNG، أو JPG) في PHP"
---

Aspose.Slides لـ PHP عبر Java يتيح لك تحويل الشرائح (في العروض التقديمية) إلى صور. هذه هي تنسيقات الصور المدعومة: BMP، PNG، JPG (JPEG)، GIF، وغيرها.

لتحويل الشريحة إلى صورة، اتبع الخطوات التالية:

1. أولاً، قم بتعيين معايير التحويل وأجسام الشرائح التي ستقوم بتحويلها باستخدام:
   * واجهة [ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) أو
   * واجهة [IRenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IRenderingOptions).

2. ثانيًا، قم بتحويل الشريحة إلى صورة باستخدام طريقة [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-).

## **حول بت ماب وتنسيقات الصور الأخرى**

في Java، [Images](https://reference.aspose.com/slides/php-java/aspose.slides/Images) هو كائن يتيح لك العمل مع الصور المعرفة بواسطة بيانات البكسل. يمكنك استخدام مثيل من هذه الفئة لحفظ الصور في مجموعة واسعة من التنسيقات (JPG، PNG، إلخ).

{{% alert title="معلومات" color="info" %}}

قامت Aspose مؤخرًا بتطوير محول [Text to GIF](https://products.aspose.app/slides/text-to-gif) عبر الإنترنت.

{{% /alert %}}

## **تحويل الشرائح إلى بت ماب وحفظ الصور بتنسيق PNG**

يوضح هذا الكود PHP كيفية تحويل الشريحة الأولى من عرض تقديمي إلى كائن بت ماب ثم كيفية حفظ الصورة بتنسيق PNG:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # تحويل الشريحة الأولى في العرض التقديمي إلى كائن Images
    $slideImage = $pres->getSlides()->get_Item(0)->getImage();
    # حفظ الصورة بتنسيق PNG
    try {
      # حفظ الصورة على القرص.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

يوضح هذا الكود النموذجي كيفية تحويل الشريحة الأولى من عرض تقديمي إلى كائن بت ماب باستخدام طريقة [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-):

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # الحصول على حجم شريحة العرض
    $slideSize = new Java("java.awt.Dimension", $slideSize->getWidth(), $slideSize->getHeight());
    # إنشاء Images بحجم الشريحة
    $slideImage = $sld->getImage(new RenderingOptions(), $slideSize);
    try {
      # حفظ الصورة على القرص.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="نصيحة" color="primary" %}}

يمكنك تحويل الشريحة إلى كائن Images ثم استخدام الكائن مباشرة في مكان ما. أو يمكنك تحويل الشريحة إلى Images ثم حفظ الصورة بتنسيق JPEG أو أي تنسيق آخر تفضله.

{{% /alert %}}  

## **تحويل الشرائح إلى صور بأحجام مخصصة**

قد تحتاج إلى الحصول على صورة بحجم معين. باستخدام طريقة زائدة عن [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-)، يمكنك تحويل الشريحة إلى صورة بأبعاد محددة (طول وعرض).

يوضح هذا الكود النموذجي عملية التحويل المقترحة باستخدام طريقة [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) :

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # تحويل الشريحة الأولى في العرض التقديمي إلى بت ماب بالحجم المحدد
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(new Java("java.awt.Dimension", 1820, 1040));
    # حفظ الصورة بتنسيق JPEG
    try {
      # حفظ الصورة على القرص.
      $slideImage->save("Slide_0.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **تحويل الشرائح مع الملاحظات والتعليقات إلى صور**

بعض الشرائح تحتوي على ملاحظات وتعليقات.

توفر Aspose.Slides واجهتين - [ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) و[IRenderingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IRenderingOptions) - التي تسمح لك بالتحكم في عرض الشرائح التقديمية إلى صور. تحتوي كلتا الواجهتين على واجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions) التي تتيح لك إضافة ملاحظات وتعليقات على شريحة عندما تقوم بتحويل تلك الشريحة إلى صورة.

{{% alert title="معلومات" color="info" %}}

باستخدام واجهة [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions)، يمكنك تحديد موضع الملاحظات والتعليقات المفضل لديك في الصورة الناتجة.

{{% /alert %}} 

يُظهر هذا الكود PHP عملية التحويل لشريحة مع ملاحظات وتعليقات:

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    # إنشاء خيارات العرض
    $options = new RenderingOptions();
    # تعيين موضع الملاحظات على الصفحة
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # تعيين موضع التعليقات على الصفحة
    $options->getNotesCommentsLayouting()->setCommentsPosition(CommentsPositions::Right);
    # تعيين عرض منطقة إخراج التعليقات
    $options->getNotesCommentsLayouting()->setCommentsAreaWidth(500);
    # تعيين اللون لمنطقة التعليقات
    $options->getNotesCommentsLayouting()->setCommentsAreaColor(java("java.awt.Color")->LIGHT_GRAY);
    # تحويل الشريحة الأولى من العرض التقديمي إلى كائن بت ماب
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, 2.0, 2.0);
    # حفظ الصورة بتنسيق GIF
    try {
      $slideImage->save("Slide_Notes_Comments_0.gif", ImageFormat::Gif);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

يُظهر هذا الكود PHP عملية التحويل لشريحة مع ملاحظات باستخدام طريقة [getImage](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getImage-java.awt.Dimension-) :

```php
  $pres = new Presentation("PresentationNotes.pptx");
  try {
    # الحصول على حجم ملاحظات العرض
    $notesSize = $pres->getNotesSize()->getSize();
    # إنشاء خيارات العرض
    $options = new RenderingOptions();
    # تعيين موضع الملاحظات
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # إنشاء Images بحجم الملاحظات
    $slideImage = $pres->getSlides()->get_Item(0)->getImage($options, $notesSize);
    # حفظ الصورة بتنسيق PNG
    try {
      # حفظ الصورة على القرص.
      $slideImage->save("Slide_0.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="ملاحظة" color="warning" %}}

في أي عملية تحويل من شريحة إلى صورة، لا يمكن تعيين خاصية [NotesPositions](https://reference.aspose.com/slides/php-java/aspose.slides/INotesCommentsLayoutingOptions#setNotesPosition-int-) إلى BottomFull (لتحديد الموضع للملاحظات) لأن نص الملاحظة قد يكون كبيرًا، مما يعني أنه قد لا يناسب حجم الصورة المحدد.

{{% /alert %}}

## **تحويل الشرائح إلى صور باستخدام ITiffOptions**

تمنحك واجهة [ITiffOptions](https://reference.aspose.com/slides/php-java/aspose.slides/ITiffOptions) مزيدًا من التحكم (من حيث المعايير) في الصورة الناتجة. باستخدام هذه الواجهة، يمكنك تحديد الحجم والدقة ولوحة الألوان وغيرها من المعايير للصورة الناتجة.

يوضح هذا الكود PHP عملية تحويل حيث يتم استخدام ITiffOptions لإخراج صورة بالأبيض والأسود بدقة 300 نقطة في البوصة وحجم 2160 × 2800:

```php
  $pres = new Presentation("PresentationNotesComments.pptx");
  try {
    # الحصول على شريحة بواسطة فهرسها
    $slide = $pres->getSlides()->get_Item(0);
    # إنشاء كائن TiffOptions
    $options = new TiffOptions();
    $options->setImageSize(new Java("java.awt.Dimension", 2160, 2880));
    # تعيين الخط المستخدم في حال عدم العثور على الخط المصدر
    $options->setDefaultRegularFont("Arial Black");
    # تعيين موضع الملاحظات على الصفحة
    $options->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # تعيين تنسيق البكسل (أبيض وأسود)
    $options->setPixelFormat(ImagePixelFormat::Format1bppIndexed);
    # تعيين الدقة
    $options->setDpiX(300);
    $options->setDpiY(300);
    # تحويل الشريحة إلى كائن بت ماب
    $slideImage = $slide->getImage($options);
    # حفظ الصورة بتنسيق TIFF
    try {
      $slideImage->save("PresentationNotesComments.tiff", ImageFormat::Tiff);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="ملاحظة" color="warning" %}}

لا يتم ضمان دعم TIFF في الإصدارات التي تسبق JDK 9.

{{% /alert %}} 

## **تحويل جميع الشرائح إلى صور**

تتيح لك Aspose.Slides تحويل جميع الشرائح في عرض تقديمي واحد إلى صور. بشكل أساسي، يمكنك تحويل العرض التقديمي (بكاملها) إلى صور.

يوضح هذا الكود النموذجي كيفية تحويل جميع الشرائح في عرض تقديمي إلى صور:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # عرض تقديمي لتحويل الشرائح إلى مصفوفة صور شريحة بشريحة
    for($i = 0; $i < java_values($pres->getSlides()->size()) ; $i++) {
      # التحكم في الشرائح المخفية (لا تظهر الشرائح المخفية)
      if ($pres->getSlides()->get_Item($i)->getHidden()) {
        continue;
      }
      # تحويل الشريحة إلى كائن بت ماب
      $slideImage = $pres->getSlides()->get_Item($i)->getImage(2.0, 2.0);
      # حفظ الصورة بتنسيق PNG
      try {
        $slideImage->save("Slide_" . $i . ".png", ImageFormat::Png);
      } finally {
        if (!java_is_null($slideImage)) {
          $slideImage->dispose();
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```