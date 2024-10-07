---
title: احصل على خلفية شريحة العرض بالكامل كصورة
type: docs
weight: 95
url: /php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- شريحة
- خلفية
- خلفية الشريحة
- الخلفية كصورة
- PowerPoint
- PPT
- PPTX
- عرض PowerPoint
- Java
- Php
- Aspose.Slides لـ PHP عبر Java
---

في عروض PowerPoint، يمكن أن تتكون خلفية الشريحة من العديد من العناصر. بالإضافة إلى الصورة المحددة كـ [خلفية الشريحة](/slides/php-java/presentation-background/)، يمكن أن تتأثر الخلفية النهائية بموضوع العرض، ونظام الألوان، والأشكال الموضوعة على الشريحة الرئيسية وشريحة التخطيط.

لا يوفر Aspose.Slides لـ PHP عبر Java طريقة بسيطة لاستخراج خلفية شريحة العرض بالكامل كصورة، ولكن يمكنك اتباع الخطوات أدناه للقيام بذلك:
1. تحميل العرض باستخدام فئة [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/).
1. الحصول على حجم الشريحة من العرض.
1. اختيار شريحة.
1. إنشاء عرض تقديمي مؤقت.
1. تعيين نفس حجم الشريحة في العرض التقديمي المؤقت.
1. استنساخ الشريحة المحددة في العرض التقديمي المؤقت.
1. حذف الأشكال من الشريحة المستنسخة.
1. تحويل الشريحة المستنسخة إلى صورة.

مثال الكود التالي يستخرج خلفية شريحة العرض بالكامل كصورة.
```php
$slideIndex = 0;
$imageScale = 1;

$presentation = new Presentation("sample.pptx");

$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item($slideIndex);

$tempPresentation = new Presentation();

$slideWidth = $slideSize->getWidth();
$slideHeight = $slideSize->getHeight();
$tempPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::DoNotScale);

$clonedSlide = $tempPresentation->getSlides()->addClone($slide);
$clonedSlide->getShapes()->clear();

$background = clonedSlide->getImage($imageScale, $imageScale);
$background->save("output->png", ImageFormat::Png);

$tempPresentation->dispose();
$presentation->dispose();
```