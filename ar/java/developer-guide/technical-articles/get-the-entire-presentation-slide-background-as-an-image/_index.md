---
title: الحصول على خلفية الشريحة بالكامل من عرض تقديمي كصورة
linktitle: خلفية الشريحة بالكامل
type: docs
weight: 95
url: /ar/java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- خلفية الشريحة
- الخلفية النهائية
- استخراج الخلفية
- الخلفية الكاملة
- تحويل الخلفية إلى صورة
- خلفية PPT
- خلفية PPTX
- خلفية ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استخراج خلفيات الشرائح الكاملة كصور من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للـ Java، لتسهيل سير العمل البصري."
---

## **الحصول على خلفية الشريحة بالكامل**

في عروض PowerPoint التقديمية، يمكن أن تتكون خلفية الشريحة من العديد من العناصر. بالإضافة إلى الصورة المحددة كـ[خلفية الشريحة](/slides/ar/java/presentation-background/)، يمكن أن يتأثر الخلفية النهائية بموضوع العرض، ونظام الألوان، والأشكال الموضوعة على الشريحة الأساسية وشريحة التخطيط.

لا توفر Aspose.Slides for Java طريقة بسيطة لاستخراج خلفية الشريحة بالكامل في العرض التقديمي كصورة، ولكن يمكنك اتباع الخطوات أدناه للقيام بذلك:
1. حمِّل العرض التقديمي باستخدام الفئة[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. احصل على حجم الشريحة من العرض التقديمي.
1. حدد شريحة.
1. أنشئ عرض تقديمي مؤقت.
1. عيّن نفس حجم الشريحة في العرض التقديمي المؤقت.
1. استنسخ الشريحة المحددة إلى العرض التقديمي المؤقت.
1. احذف الأشكال من الشريحة المستنسخة.
1. حوّل الشريحة المستنسخة إلى صورة.

المثال التالي للشفرة يَستخرج خلفية الشريحة بالكامل في العرض التقديمي كصورة.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```


## **الأسئلة الشائعة**

**هل سيتم الحفاظ على التدرجات المعقدة أو القوام أو ملء الصور من الشريحة الأساسية في صورة الخلفية الناتجة؟**

نعم. تقوم Aspose.Slides بدمج التدرجات، والملء بالصور، والملء بالقوام المعرفة على الشريحة أو التخطيط أو الأساسي. إذا كنت بحاجة إلى عزل المظهر عن الأساسيات الموروثة،[قم بتعيين خلفية خاصة](/slides/ar/java/presentation-background/) على الشريحة الحالية قبل التصدير.

**هل يمكنني إضافة علامة مائية إلى صورة الخلفية الناتجة قبل حفظها؟**

نعم. يمكنك[إضافة علامة مائية](/slides/ar/java/watermark/) كشكل أو صورة على[نسخة من الشريحة](/slides/ar/java/clone-slides/) العاملة (موضوعة خلف المحتوى الآخر) ثم التصدير. هذا يتيح لك إنشاء صورة خلفية مدمجة مع العلامة المائية.

**هل يمكنني الحصول على الخلفية لتخطيط أو أساسي معين دون ربطها بشريحة موجودة؟**

نعم. قم بالوصول إلى الأساس أو التخطيط المطلوب، ثم طبقه على[شريحة مؤقتة](/slides/ar/java/clone-slides/) بالحجم المطلوب، وصدر تلك الشريحة للحصول على الخلفية المستمدة من ذلك التخطيط أو الأساس.

**هل توجد قيود ترخيص تؤثر على تصدير الصورة؟**

ميزات العرض متاحة بالكامل مع[رخصة صالحة](/slides/ar/java/licensing/). في وضع التقييم، قد يتضمن الناتج قيودًا مثل العلامة المائية. فعّل الرخصة مرة واحدة لكل عملية قبل تشغيل عمليات التصدير الجماعية.