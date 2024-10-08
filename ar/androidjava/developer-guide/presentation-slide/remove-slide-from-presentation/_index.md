---
title: إزالة الشريحة من العرض التقديمي
type: docs
weight: 30
url: /ar/androidjava/remove-slide-from-presentation/
keywords: "إزالة شريحة, حذف شريحة, PowerPoint, عرض تقديمي, Java, Aspose.Slides"
description: "إزالة الشريحة من PowerPoint بالمرجع أو الفهرس في Java"

---

إذا أصبحت شريحة (أو محتوياتها) غير ضرورية، يمكنك حذفها. تقدم Aspose.Slides فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) التي تحتوي على [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/)، وهي مستودع لجميع الشرائح في عرض تقديمي. باستخدام المؤشرات (المرجع أو الفهرس) لكائن [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) المعروف، يمكنك تحديد الشريحة التي تريد إزالتها.

## **إزالة الشريحة بالمرجع**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. احصل على مرجع الشريحة التي تريد إزالتها من خلال معرّفها أو فهرسها.
1. قم بإزالة الشريحة المذكورة من العرض التقديمي.
1. احفظ العرض التقديمي المعدل.

يوضح لك هذا الرمز البرمجي بلغة Java كيفية إزالة شريحة من خلال مرجعها:

```java
// Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("demo.pptx");
try {
    // Accesses a slide through its index in the slides collection
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Removes a slide through its reference
    pres.getSlides().remove(slide);
    
    // Saves the modified presentation
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **إزالة الشريحة حسب الفهرس**

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. قم بإزالة الشريحة من العرض التقديمي من خلال موضع فهرسها.
1. احفظ العرض التقديمي المعدل.

يوضح لك هذا الرمز البرمجي بلغة Java كيفية إزالة شريحة من خلال فهرسها:

```java
// Instantiates a Presentation object that represents a presentation file
Presentation pres = new Presentation("demo.pptx");
try {
    // Removes a slide through its slide index
    pres.getSlides().removeAt(0);
    
    // Saves the modified presentation
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **إزالة شريحة التخطيط غير المستخدمة**

تقدم Aspose.Slides طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (من فئة [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) للسماح لك بحذف الشرائح التخطيط غير المرغوب فيها وغير المستخدمة. يوضح لك هذا الرمز البرمجي بلغة Java كيفية إزالة شريحة تخطيط من عرض تقديمي في PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة الشريحة الرئيسية غير المستخدمة**

تقدم Aspose.Slides طريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من فئة [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/)) للسماح لك بحذف الشرائح الرئيسية غير المرغوب فيها وغير المستخدمة. يوضح لك هذا الرمز البرمجي بلغة Java كيفية إزالة شريحة رئيسية من عرض تقديمي في PowerPoint:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```