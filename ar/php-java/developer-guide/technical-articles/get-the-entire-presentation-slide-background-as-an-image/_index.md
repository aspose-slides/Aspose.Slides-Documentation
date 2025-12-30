---
title: الحصول على خلفية الشريحة بالكامل من العرض كصورة
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
- العرض التقديمي
- PHP
- Aspose.Slides
description: "استخراج خلفيات الشرائح الكاملة كصور من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة PHP عبر Java، مما يُبسّط سير العمل البصري."
---

## **الحصول على خلفية الشريحة بالكامل**

في عروض PowerPoint التقديمية، قد تتكون خلفية الشريحة من العديد من العناصر. بالإضافة إلى الصورة المحددة كـ[خلفية الشريحة](/slides/ar/php-java/presentation-background/)، يمكن أن يتأثر الخلفية النهائية بموضوع العرض، نظام الألوان، والأشكال الموضوعة على الشريحة الأصلية وشريحة التخطيط.

Aspose.Slides for PHP via Java لا يوفر طريقة بسيطة لاستخراج خلفية الشريحة الكاملة كصورة، لكن يمكنك اتباع الخطوات التالية للقيام بذلك:
1. قم بتحميل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/php-java/com.aspose.slides/presentation/) .
1. احصل على حجم الشريحة من العرض.
1. اختر شريحة.
1. أنشئ عرضًا مؤقتًا.
1. عيّن نفس حجم الشريحة في العرض المؤقت.
1. استنسخ الشريحة المحددة إلى العرض المؤقت.
1. احذف الأشكال من الشريحة المستنسخة.
1. حوّل الشريحة المستنسخة إلى صورة.

مثال الشيفرة التالي يستخرج خلفية الشريحة الكاملة من العرض كصورة.
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


## **الأسئلة الشائعة**

**هل سيتم الحفاظ على التدرجات المعقدة أو القوام أو تعبئة الصور من الشريحة الأصلية في صورة الخلفية الناتجة؟**

نعم. يقوم Aspose.Slides بتصيير التدرجات، والصور، وتعبئة القوام المعرفة على الشريحة أو التخطيط أو الأصل. إذا كنت بحاجة إلى عزل المظهر عن الأصول الموروثة،[قم بتعيين خلفية خاصة](/slides/ar/php-java/presentation-background/) على الشريحة الحالية قبل التصدير.

**هل يمكنني إضافة علامة مائية إلى صورة الخلفية الناتجة قبل حفظها؟**

نعم. يمكنك[إضافة علامة مائية](/slides/ar/php-java/watermark/) كشكل أو صورة على[نسخة من الشريحة](/slides/ar/php-java/clone-slides/) تعمل (توضع خلف المحتوى الآخر) ثم تصديرها. هذا يتيح لك إنشاء صورة خلفية مدمجة بالعلامة المائية.

**هل يمكنني الحصول على الخلفية لتخطيط أو أصل محدد دون ربطها بشريحة موجودة؟**

نعم. قم بالوصول إلى الأصل أو التخطيط المطلوب، وطبقه على[شريحة مؤقتة](/slides/ar/php-java/clone-slides/) بالحجم المطلوب، ثم صدّر تلك الشريحة للحصول على الخلفية المستمدة من ذلك التخطيط أو الأصل.

**هل توجد قيود ترخيص تؤثر على تصدير الصور؟**

ميزات التصيير متاحة بالكامل مع[ترخيص صالح](/slides/ar/php-java/licensing/). في وضع التقييم، قد يتضمن الإخراج قيودًا مثل العلامة المائية. فعّل الترخيص مرة واحدة لكل عملية قبل تشغيل تصديرات الدُفعة.