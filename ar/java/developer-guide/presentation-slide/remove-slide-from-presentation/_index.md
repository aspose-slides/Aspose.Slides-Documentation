---
title: إزالة شريحة من العرض التقديمي
type: docs
weight: 30
url: /java/remove-slide-from-presentation/
keywords: "إزالة شريحة، حذف شريحة، باوربوينت، عرض تقديمي، جافا، Aspose.Slides"
description: "إزالة شريحة من باوربوينت بالإشارة أو الفهرس في جافا"

---

إذا أصبحت شريحة (أو محتوياتها) زائدة عن الحاجة، يمكنك حذفها. يوفر Aspose.Slides صنف [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) الذي يجسد [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/)، وهو مستودع لجميع الشرائح في العرض التقديمي. باستخدام المؤشرات (الإشارة أو الفهرس) لجسم [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) معروف، يمكنك تحديد الشريحة التي تريد إزالتها.

## **إزالة الشريحة بالإشارة**

1. أنشئ مثيلًا من صنف [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. احصل على إشارة الشريحة التي تريد إزالتها من خلال معرفها أو فهرسها.
1. قم بإزالة الشريحة المعينة من العرض التقديمي.
1. احفظ العرض التقديمي المعدل.

يوضح هذا الرمز البرمجي بلغة جافا كيفية إزالة شريحة من خلال إشارته:

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


## **إزالة الشريحة بالفهرس**

1. أنشئ مثيلًا من صنف [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. قم بإزالة الشريحة من العرض التقديمي من خلال موقع فهرسها.
1. احفظ العرض التقديمي المعدل.

يوضح هذا الرمز البرمجي بلغة جافا كيفية إزالة شريحة من خلال فهرسها:

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

يوفر Aspose.Slides طريقة [removeUnusedLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (من صنف [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) للسماح لك بحذف شرائح التخطيط غير المرغوب فيها وغير المستخدمة. يوضح هذا الرمز البرمجي بلغة جافا كيفية إزالة شريحة تخطيط من عرض تقديمي باوربوينت:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **إزالة شريحة الماستر غير المستخدمة**

يوفر Aspose.Slides طريقة [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (من صنف [Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)) للسماح لك بحذف شرائح الماستر غير المرغوب فيها وغير المستخدمة. يوضح هذا الرمز البرمجي بلغة جافا كيفية إزالة شريحة الماستر من عرض تقديمي باوربوينت:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```