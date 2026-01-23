---
title: الحصول على خلفية الشريحة بالكامل من عرض تقديمي كصورة
linktitle: خلفية الشريحة بالكامل
type: docs
weight: 95
url: /ar/php-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- خلفية الشريحة
- الخلفية النهائية
- استخراج الخلفية
- الخلفية الكاملة
- الخلفية إلى صورة
- خلفية PPT
- خلفية PPTX
- خلفية ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- PHP
- Aspose.Slides
description: "استخراج خلفيات الشريحة بالكامل كصور من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ PHP عبر Java، مما يبسط سير العمل البصري."
---

## **الحصول على خلفية الشريحة بالكامل**

في عروض PowerPoint التقديمية، يمكن أن تتكوّن خلفية الشريحة من العديد من العناصر. بالإضافة إلى الصورة المحددة كـ[خلفية الشريحة](/slides/ar/php-java/presentation-background/)، قد تتأثر الخلفية النهائية بموضوع العرض، ونظام الألوان، والأشكال الموضوعة على الشريحة الرئيسة وشريحة التخطيط.

لا توفر مكتبة Aspose.Slides for PHP عبر Java طريقة بسيطة لاستخراج خلفية شريحة العرض التقديمي بالكامل كصورة، ولكن يمكنك اتباع الخطوات التالية للقيام بذلك:
1. حمّل العرض التقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
1. احصل على حجم الشريحة من العرض التقديمي.
1. اختر شريحة.
1. أنشئ عرضًا تقديميًا مؤقتًا.
1. اضبط نفس حجم الشريحة في العرض التقديمي المؤقت.
1. انسخ الشريحة المحددة إلى العرض التقديمي المؤقت.
1. احذف الأشكال من الشريحة المستنسخة.
1. حوّل الشريحة المستنسخة إلى صورة.

المثال البرمجي التالي يستخرج خلفية شريحة العرض التقديمي بالكامل كصورة.
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


## **الأسئلة المتكررة**

**هل سيتم حفظ التدرجات المعقدة أو القوام أو ملء الصور من شريحة رئيسية في صورة الخلفية الناتجة؟**

نعم. تقوم Aspose.Slides بتصيير التدرجات، والملء بالصور، والملء بالقوام المحددة على الشريحة أو التخطيط أو الشريحة الرئيسة. إذا كنت بحاجة إلى عزل المظهر عن الشريحة الرئيسة الموروثة، [قم بتعيين خلفية خاصة](/slides/ar/php-java/presentation-background/) على الشريحة الحالية قبل التصدير.

**هل يمكنني إضافة علامة مائية إلى صورة الخلفية الناتجة قبل حفظها؟**

نعم. يمكنك [إضافة علامة مائية](/slides/ar/php-java/watermark/) كشكل أو صورة على نسخة عمل [من الشريحة](/slides/ar/php-java/clone-slides/) (موجودة خلف المحتوى الآخر) ثم التصدير. يتيح لك ذلك إنشاء صورة خلفية مدمجة مع العلامة المائية.

**هل يمكنني الحصول على الخلفية لتصميم أو شريحة رئيسية محددة دون ربطها بشريحة موجودة؟**

نعم. قم بالوصول إلى الشريحة الرئيسة أو التخطيط المطلوب، وطبقه على [شريحة مؤقتة](/slides/ar/php-java/clone-slides/) بالحجم المطلوب، ثم صدّر تلك الشريحة للحصول على الخلفية المستمدة من ذلك التخطيط أو الشريحة الرئيسة.

**هل هناك قيود ترخيص تؤثر على تصدير الصور؟**

ميزات التصيير متاحة بالكامل مع [رخصة صالحة](/slides/ar/php-java/licensing/). في وضع التقييم، قد يتضمن الناتج قيودًا مثل علامة مائية. فعّل الرخصة مرة واحدة لكل عملية قبل تشغيل تصدير الدُفعات.