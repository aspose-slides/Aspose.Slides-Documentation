---
title: الحصول على خلفية الشريحة الكاملة من العرض كصورة
linktitle: الخلفية الكاملة للشريحة
type: docs
weight: 95
url: /ar/androidjava/get-the-entire-presentation-slide-background-as-an-image/
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
- عرض
- Android
- Java
- Aspose.Slides
description: "استخراج خلفيات الشريحة الكاملة كصور من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لنظام Android عبر Java، لتبسيط سير العمل البصري."
---

## **الحصول على خلفية الشريحة الكاملة**

في عروض PowerPoint التقديمية، يمكن أن تتكون خلفية الشريحة من العديد من العناصر. بالإضافة إلى الصورة التي تم تعيينها كـ [خلفية الشريحة](/slides/ar/androidjava/presentation-background/)، قد يتأثر الخلفية النهائية بموضوع العرض، نظام الألوان، والأشكال الموجودة على شريحة القالب وشريحة التخطيط.

Aspose.Slides for Android via Java لا يوفر طريقة بسيطة لاستخراج خلفية شريحة العرض بالكامل كصورة، لكن يمكنك اتباع الخطوات أدناه للقيام بذلك:
1. قم بتحميل العرض باستخدام الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. احصل على حجم الشريحة من العرض.
1. اختر شريحة.
1. أنشئ عرضًا مؤقتًا.
1. عيّن نفس حجم الشريحة في العرض المؤقت.
1. استنسخ الشريحة المختارة إلى العرض المؤقت.
1. احذف الأشكال من الشريحة المستنسخة.
1. حوّل الشريحة المستنسخة إلى صورة.

مثال الشيفرة التالي يستخرج خلفية الشريحة الكاملة في العرض كصورة.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```


## **الأسئلة المتكررة**

**هل سيتم الحفاظ على التدرجات المعقدة أو القوام أو تعبئات الصور من شريحة القالب في صورة الخلفية الناتجة؟**

نعم. يقوم Aspose.Slides بتصيير تعبئات التدرج والصورة والقوام المحددة على الشريحة أو التخطيط أو القالب. إذا كنت بحاجة إلى عزل الشكل عن القوالب الموروثة، فإنك يمكنك [تعيين خلفية خاصة](/slides/ar/androidjava/presentation-background/) على الشريحة الحالية قبل التصدير.

**هل يمكنني إضافة علامة مائية إلى صورة الخلفية الناتجة قبل حفظها؟**

نعم. يمكنك [إضافة علامة مائية](/slides/ar/androidjava/watermark/) كشكل أو صورة على نسخة [عملية من الشريحة](/slides/ar/androidjava/clone-slides/) (موضوعة خلف المحتوى الآخر) ثم التصدير. هذا يتيح لك إنشاء صورة خلفية مدموجة مع العلامة المائية.

**هل يمكنني الحصول على الخلفية لتخطيط أو قالب محدد دون ربطها بشريحة موجودة؟**

نعم. يمكن الوصول إلى القالب أو التخطيط المطلوب، تطبيقه على [شريحة مؤقتة](/slides/ar/androidjava/clone-slides/) بالحجم المطلوب، ثم تصدير تلك الشريحة للحصول على الخلفية المستمدة من ذلك التخطيط أو القالب.

**هل توجد قيود ترخيص تؤثر على تصدير الصور؟**

ميزات التصيير متاحة بالكامل مع [ترخيص صالح](/slides/ar/androidjava/licensing/). في وضع التقييم، قد يتضمن الناتج قيودًا مثل العلامة المائية. قم بتنشيط الترخيص مرة واحدة لكل عملية قبل تشغيل صادرات الدُفعات.