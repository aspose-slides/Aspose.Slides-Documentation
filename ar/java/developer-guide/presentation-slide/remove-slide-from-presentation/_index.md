---
title: إزالة الشرائح من العروض التقديمية في جافا
linktitle: إزالة شريحة
type: docs
weight: 30
url: /ar/java/remove-slide-from-presentation/
keywords:
- إزالة شريحة
- حذف شريحة
- إزالة شريحة غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "قم بإزالة الشرائح بسهولة من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة جافا. احصل على أمثلة شفرة واضحة وعزز سير العمل الخاص بك."
---

إذا أصبحت الشريحة (أو محتوياتها) غير ضرورية، يمكنك حذفها. توفر Aspose.Slides الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) التي تغلف [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/)، وهي مستودع لجميع الشرائح في العرض التقديمي. باستخدام المؤشرات (مرجع أو فهرس) لكائن [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) معروف، يمكنك تحديد الشريحة التي تريد إزالتها. 

## **إزالة شريحة بالمرجع**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة التي تريد إزالتها عبر معرّفها أو فهرسها.
3. إزالة الشريحة المرجعية من العرض التقديمي.
4. حفظ العرض التقديمي المعدل. 

يظهر لك هذا الكود Java كيفية إزالة شريحة عبر مرجعها:
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    // الوصول إلى شريحة عبر فهرستها في مجموعة الشرائح
    ISlide slide = pres.getSlides().get_Item(0);
    
    // إزالة شريحة عبر مرجعها
    pres.getSlides().remove(slide);
    
    // حفظ العرض التقديمي المعدل
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **إزالة شريحة بالفهرس**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
2. إزالة الشريحة من العرض التقديمي عبر موضع فهرسها.
3. حفظ العرض التقديمي المعدل. 

يظهر لك هذا الكود Java كيفية إزالة شريحة عبر فهرسها:
```java
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    // إزالة شريحة عبر فهرسها
    pres.getSlides().removeAt(0);
    
    // حفظ العرض التقديمي المعدل
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **إزالة شرائح التخطيط غير المستخدمة**

توفر Aspose.Slides طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (من الفئة [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) لتتيح لك حذف شرائح التخطيط غير المرغوب فيها وغير المستخدمة. يوضح لك هذا الكود Java كيفية إزالة شريحة تخطيط من عرض PowerPoint:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إزالة شرائح القالب غير المستخدمة**

توفر Aspose.Slides طريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من الفئة [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) لتتيح لك حذف الشرائح الرئيسية غير المرغوب فيها وغير المستخدمة. يوضح لك هذا الكود Java كيفية إزالة شريحة رئيسية من عرض PowerPoint:
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```


## **الأسئلة المتكررة**

**ماذا يحدث لأرقام فهارس الشرائح بعد حذف شريحة؟**

بعد الحذف، يُعيد [collection](https://reference.aspose.com/slides/java/com.aspose.slides/slidecollection/) فهرسة الشرائح: كل شريحة تالية تتحرك إلى اليسار بموقع واحد، لذا تصبح أرقام الفهارس السابقة غير صالحة. إذا كنت بحاجة إلى مرجع ثابت، استخدم المعرف الدائم لكل شريحة بدلاً من فهرسها.

**هل معرّف الشريحة يختلف عن فهرسها، وهل يتغير عند حذف الشرائح المجاورة؟**

نعم. الفهرس هو موقع الشريحة وسيتغير عند إضافة أو حذف الشرائح. معرّف الشريحة هو معرف دائم ولا يتغيّر عند حذف شرائح أخرى.

**كيف يؤثر حذف شريحة على أقسام الشرائح؟**

إذا كانت الشريحة جزءًا من قسم، سيحتوي ذلك القسم على شريحة أقل. يظل هيكل القسم كما هو؛ إذا أصبح القسم فارغًا، يمكنك [إزالة أو إعادة تنظيم الأقسام](/slides/ar/java/slide-section/) حسب الحاجة.

**ماذا يحدث للملاحظات والتعليقات المرفقة بشريحة عند حذفها؟**

[الملاحظات](/slides/ar/java/presentation-notes/) و[التعليقات](/slides/ar/java/presentation-comments/) مرتبطة بتلك الشريحة المحددة وتُحذف معها. لا يتأثر المحتوى في الشرائح الأخرى.

**كيف يختلف حذف الشرائح عن تنظيف التخطيطات/القوالب غير المستخدمة؟**

الحذف يزيل شرائح عادية محددة من العرض. تنظيف التخطيطات/القوالب غير المستخدمة يزيل شرائح التخطيط أو القالب التي لا يشير إليها أي شيء، مما يقلل حجم الملف دون تغيير محتوى الشرائح المتبقية. هذان الإجراءان متكاملان: عادةً احذف أولًا، ثم قم بالتنظيف.