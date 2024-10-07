---
title: عارض العروض التقديمية
type: docs
weight: 50
url: /php-java/presentation-viewer/
keywords: "عارض PPT PowerPoint"
description: "عارض PPT PowerPoint "
---

{{% alert color="primary" %}} 

يستخدم Aspose.Slides لـ PHP عبر Java لإنشاء ملفات العروض التقديمية، مكتملة بالشرائح. يمكن عرض هذه الشرائح من خلال فتح العروض التقديمية باستخدام Microsoft PowerPoint. ولكن أحيانًا، قد يحتاج المطورون أيضًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو إنشاء عارض خاص بهم للعروض التقديمية. في مثل هذه الحالات، يتيح لك Aspose.Slides لـ PHP عبر Java تصدير شريحة فردية إلى صورة. يصف هذا المقال كيفية القيام بذلك.

{{% /alert %}} 

## **مثال حي**
يمكنك تجربة [**عارض Aspose.Slides**](https://products.aspose.app/slides/viewer/) المجاني لرؤية ما يمكنك تنفيذه باستخدام واجهة برمجة تطبيقات Aspose.Slides:

[](https://products.aspose.app/slides/viewer/)

[![todo:image_alt_text](slides-viewer.png)](https://products.aspose.app/slides/viewer/)

## **إنشاء صورة SVG من شريحة**
لإنشاء صورة SVG من أي شريحة مرغوبة باستخدام Aspose.Slides لـ PHP عبر Java، يرجى اتباع الخطوات أدناه:

- إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
- الحصول على مرجع الشريحة المرغوبة باستخدام معرفها أو فهرسها.
- الحصول على صورة SVG في دفق الذاكرة.
- حفظ دفق الذاكرة إلى ملف.

```php
  # إنشاء مثيل من فئة العرض التقديمي التي تمثل ملف العرض التقديمي
  $pres = new Presentation("CreateSlidesSVGImage.pptx");
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إنشاء كائن دفق ذاكرة
    $svgStream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    # إنشاء صورة SVG للشريحة وحفظها في دفق الذاكرة
    $sld->writeAsSvg($svgStream);
    $svgStream->close();
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **إنشاء SVG مع معرفات شكل مخصصة**
يمكن استخدام Aspose.Slides لـ PHP عبر Java لإنشاء [SVG](https://docs.fileformat.com/page-description-language/svg/) من شريحة بمعرف شكل مخصص. للقيام بذلك، استخدم خاصية ID من [ISvgShape](https://reference.aspose.com/slides/php-java/aspose.slides/ISvgShape) ، التي تمثل معرف الشكل المخصص في SVG الناتج. يمكن استخدام CustomSvgShapeFormattingController لتعيين معرف الشكل.

```php

  class CustomSvgShapeFormattingController {
    private $m_shapeIndex;

    function __construct() {
      $this->m_shapeIndex = 0;
    }

    function __construct($shapeStartIndex) {
      $this->m_shapeIndex = $shapeStartIndex;
    }

    function formatShape($svgShape, $shape) {
      $svgShape->setId(sprintf("shape-%d", $m_shapeIndex++));
    }
  }

  $pres = new Presentation("pptxFileName.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "Aspose_out.svg");
    try {
      $svgOptions = new SVGOptions();
      $shapeFormattingController = java_closure(new CustomSvgShapeFormattingController(), null, java("com.aspose.slides.ISvgShapeFormattingController"));
      $svgOptions->setShapeFormattingController($shapeFormattingController);
      $pres->getSlides()->get_Item(0)->writeAsSvg($stream, $svgOptions);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

## **إنشاء صورة مصغرة للشرائح**
يساعدك Aspose.Slides لـ PHP عبر Java في إنشاء صور مصغرة للشرائح. لإنشاء الصورة المصغرة لأي شريحة مرغوبة باستخدام Aspose.Slides لـ PHP عبر Java:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. الحصول على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
1. احصل على صورة مصغرة للشريحة المشار إليها بمقياس محدد.
1. حفظ الصورة المصغرة بأي تنسيق صورة مرغوب فيه.

```php
  # إنشاء مثيل من فئة العرض التقديمي التي تمثل ملف العرض التقديمي
  $pres = new Presentation("ThumbnailFromSlide.pptx");
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # إنشاء صورة كاملة الحجم
    $slideImage = $sld->getImage(1.0, 1.0);
    # حفظ الصورة على القرص بتنسيق JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **إنشاء صورة مصغرة مع أبعاد محددة من قبل المستخدم**

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. الحصول على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
1. احصل على صورة مصغرة للشريحة المشار إليها بمقياس محدد.
1. حفظ الصورة المصغرة بأي تنسيق صورة مرغوب فيه.

```php
  # إنشاء مثيل من فئة العرض التقديمي التي تمثل ملف العرض التقديمي
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # الأبعاد المحددة من قبل المستخدم
    $desiredX = 1200;
    $desiredY = 800;
    # الحصول على القيمة المنسوبة لـ X و Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    # إنشاء صورة كاملة الحجم
    $slideImage = $sld->getImage($ScaleX, $ScaleY);
    # حفظ الصورة على القرص بتنسيق JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **إنشاء صورة مصغرة من الشريحة في عرض الشرائح الملاحظات**
لإنشاء صورة مصغرة لأي شريحة مرغوبة في عرض الشريحة الملاحظات باستخدام Aspose.Slides لـ PHP عبر Java:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) class.
1. الحصول على مرجع لأي شريحة مرغوبة باستخدام معرفها أو فهرسها.
1. احصل على صورة مصغرة للشريحة المشار إليها بمقياس محدد في عرض شريحة الملاحظات.
1. حفظ الصورة المصغرة بأي تنسيق صورة مرغوب فيه.

يؤدي جزء الكود أدناه إلى إنتاج صورة مصغرة للشريحة الأولى من عرض تقديمي في عرض شريحة الملاحظات.

```php
  # إنشاء مثيل من فئة العرض التقديمي التي تمثل ملف العرض التقديمي
  $pres = new Presentation("ThumbnailWithUserDefinedDimensions.pptx");
  try {
    # الوصول إلى الشريحة الأولى
    $sld = $pres->getSlides()->get_Item(0);
    # الأبعاد المحددة من قبل المستخدم
    $desiredX = 1200;
    $desiredY = 800;
    # الحصول على القيمة المنسوبة لـ X و Y
    $ScaleX = 1.0 / $pres->getSlideSize()->getSize()->getWidth() * $desiredX;
    $ScaleY = 1.0 / $pres->getSlideSize()->getSize()->getHeight() * $desiredY;
    $opts = new RenderingOptions();
    $opts->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomTruncated);
    # إنشاء صورة كاملة الحجم
    $slideImage = $sld->getImage($opts, $ScaleX, $ScaleY);
    # حفظ الصورة على القرص بتنسيق JPEG
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    $pres->dispose();
  }
```