---
title: إزالة الشرائح من العروض التقديمية على Android
linktitle: إزالة شريحة
type: docs
weight: 30
url: /ar/androidjava/remove-slide-from-presentation/
keywords:
- إزالة شريحة
- حذف شريحة
- إزالة شريحة غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إزالة الشرائح بسهولة من عروض PowerPoint و OpenDocument التقديمية باستخدام Aspose.Slides للـ Android. احصل على أمثلة شفرة Java واضحة وحسّن سير العمل الخاص بك."
---

إذا أصبحت الشريحة (أو محتوياتها) غير ضرورية، يمكنك حذفها. توفر Aspose.Slides فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) التي تضمّ [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/)، وهي مستودع لجميع الشرائح في العرض التقديمي. باستخدام المؤشرات (مرجع أو فهرس) لكائن [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) المعروف، يمكنك تحديد الشريحة التي تريد إزالتها.

## **إزالة شريحة باستخدام المرجع**

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الحصول على مرجع الشريحة التي تريد حذفها عبر معرّفها أو فهرسها.
1. إزالة الشريحة المشار إليها من العرض التقديمي.
1. حفظ العرض التقديمي المُعدَّل.

هذا الكود Java يوضح لك كيفية حذف شريحة عبر مرجعها:
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


## **إزالة شريحة باستخدام الفهرس**

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. إزالة الشريحة من العرض التقديمي عبر موقعها الفهرسي.
1. حفظ العرض التقديمي المُعدَّل.

هذا الكود Java يوضح لك كيفية حذف شريحة عبر فهرستها:
```java
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation pres = new Presentation("demo.pptx");
try {
    // يزيل شريحة عبر فهرس الشريحة
    pres.getSlides().removeAt(0);
    
    // يحفظ العرض التقديمي المعدل
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **إزالة شرائح التخطيط غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (من فئة [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) لتسمح لك بحذف تخطيطات الشرائح غير المرغوب فيها وغير المستخدمة. هذا الكود Java يوضح لك كيفية إزالة شريحة تخطيط من عرض PowerPoint:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **إزالة الشرائح الرئيسية غير المستخدمة**

توفر Aspose.Slides الطريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من فئة [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) لتسمح لك بحذف الشرائح الرئيسية غير المرغوب فيها وغير المستخدمة. هذا الكود Java يوضح لك كيفية إزالة شريحة رئيسية من عرض PowerPoint:
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```


## **الأسئلة الشائعة**

**ماذا يحدث لفهارس الشرائح بعد حذف شريحة؟**

بعد الحذف، تُعيد المجموعة [slidecollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/) فهرستها: كل شريحة تالية تُنقَل إلى اليسار بموقع واحد، وبالتالي تصبح أرقام الفهارس السابقة غير صحيحة. إذا كنت بحاجة إلى مرجع ثابت، استخدم معرّف الشريحة الدائم بدلاً من فهرسها.

**هل معرّف الشريحة مختلف عن فهرسها، وهل يتغيّر عند حذف الشرائح المجاورة؟**

نعم. الفهرس هو موضع الشريحة وسيتغيّر عندما تُضاف أو تُحذف شرائح. معرّف الشريحة هو معرف دائم لا يتغيّر عند حذف شرائح أخرى.

**كيف يؤثر حذف شريحة على أقسام الشرائح؟**

إذا كانت الشريحة تنتمي إلى قسم، سيصبح عدد الشرائح في ذلك القسم أقل بواحدة. هيكل القسم يبقى كما هو؛ إذا أصبح القسم فارغًا، يمكنك [إزالة أو إعادة تنظيم الأقسام](/slides/ar/androidjava/slide-section/) حسب الحاجة.

**ماذا يحدث للملاحظات والتعليقات المرفقة بالشريحة عند حذفها؟**

الملاحظات [Notes](/slides/ar/androidjava/presentation-notes/) والتعليقات [comments](/slides/ar/androidjava/presentation-comments/) مرتبطة بهذه الشريحة تُحذف مع حذف الشريحة. المحتوى على الشرائح الأخرى لا يتأثر.

**ما الفرق بين حذف الشرائح وتنظيف التخطيطات/الرؤوس غير المستخدمة؟**

الحذف يزيل الشرائح العادية المحددة من العرض. تنظيف التخطيطات/الرؤوس غير المستخدمة يزيل شرائح التخطيط أو الرؤوس التي لا يشير إليها أي شيء، مما يقلل حجم الملف دون تغيير محتوى الشرائح المتبقية. هاتان العمليتان تكملان بعضهما: عادةً احذف أولاً، ثم قم بتنظيف غير المستخدمة.