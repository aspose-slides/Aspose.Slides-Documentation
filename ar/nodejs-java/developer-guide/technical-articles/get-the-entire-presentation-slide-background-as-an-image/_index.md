---
title: الحصول على خلفية الشريحة الكاملة في العرض التقديمي كصورة
type: docs
weight: 95
url: /ar/nodejs-java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- شريحة
- خلفية
- خلفية الشريحة
- خلفية إلى صورة
- PowerPoint
- PPT
- PPTX
- عرض PowerPoint
- Node
- JavaScript
- Aspose.Slides for Node.js via Java
---

## **الحصول على خلفية الشريحة بالكامل**

في عروض PowerPoint التقديمية، قد تتكون خلفية الشريحة من عناصر عديدة. بالإضافة إلى الصورة المحددة كـ[خلفية الشريحة](/slides/ar/nodejs-java/presentation-background/)، يمكن أن يتأثر الخلفية النهائية بموضوع العرض، مخطط الألوان، والأشكال الموضوعة على الشريحة الرئيسية وشريحة التخطيط.

لا توفر Aspose.Slides لـ Node.js عبر Java طريقة بسيطة لاستخراج خلفية الشريحة الكاملة في العرض التقديمي كصورة، لكن يمكنك اتباع الخطوات أدناه للقيام بذلك:
1. حمّل العرض التقديمي باستخدام الفئة[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. احصل على حجم الشريحة من العرض التقديمي.
3. اختر شريحة.
4. أنشئ عرض تقديمي مؤقت.
5. حدد نفس حجم الشريحة في العرض التقديمي المؤقت.
6. انسخ الشريحة المحددة إلى العرض التقديمي المؤقت.
7. احذف الأشكال من الشريحة المنسوخة.
8. حوّل الشريحة المنسوخة إلى صورة.

مثال الشيفرة التالي يستخرج خلفية الشريحة الكاملة في العرض التقديمي كصورة.
```javascript
var slideIndex = 0;
var imageScale = 1;
var presentation = new aspose.slides.Presentation("sample.pptx");
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);
var tempPresentation = new aspose.slides.Presentation();
var slideWidth = slideSize.getWidth();
var slideHeight = slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();
var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", aspose.slides.ImageFormat.Png);
tempPresentation.dispose();
presentation.dispose();
```


## **الأسئلة الشائعة**

**هل سيتم الحفاظ على التدرجات المعقدة أو القوام أو التعبئات الصورية من الشريحة الرئيسية في صورة الخلفية الناتجة؟**

نعم. تقوم Aspose.Slides بتصوير التدرجات، والصور، والقوام المُعرّفة على الشريحة أو التخطيط أو الشريحة الرئيسية. إذا كنت بحاجة إلى عزل المظهر عن الشرائح الرئيسية الموروثة، ف[قم بتعيين خلفية خاصة](/slides/ar/nodejs-java/presentation-background/) على الشريحة الحالية قبل التصدير.

**هل يمكنني إضافة علامة مائية إلى صورة الخلفية الناتجة قبل حفظها؟**

نعم. يمكنك[إضافة علامة مائية](/slides/ar/nodejs-java/watermark/) كشكل أو صورة على نسخة[عمل من الشريحة](/slides/ar/nodejs-java/clone-slides/)(موضوعة خلف المحتوى الآخر) ثم تصديرها. هذا يتيح لك إنشاء صورة خلفية مدمجة مع العلامة المائية.

**هل يمكنني الحصول على الخلفية لتخطيط أو شريحة رئيسية محددة دون ربطها بشريحة موجودة؟**

نعم. احصل على الشريحة الرئيسية أو التخطيط المطلوب، وطبّقه على[شريحة مؤقتة](/slides/ar/nodejs-java/clone-slides/) بالحجم المطلوب، ثم صدّر تلك الشريحة للحصول على الخلفية المستمدة من ذلك التخطيط أو الشريحة الرئيسية.

**هل هناك قيود ترخيص تؤثر على تصدير الصورة؟**

ميزات التصيير متاحة بالكامل مع[رخصة صالحة](/slides/ar/nodejs-java/licensing/). في وضع التقييم، قد يحتوي الناتج على قيود مثل العلامة المائية. فعل الرخصة مرة واحدة لكل عملية قبل تشغيل عمليات التصدير الجماعية.