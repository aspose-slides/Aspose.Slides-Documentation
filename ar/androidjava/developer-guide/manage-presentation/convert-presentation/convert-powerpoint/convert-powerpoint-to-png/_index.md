---
title: تحويل PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/androidjava/convert-powerpoint-to-png/
keywords: PowerPoint إلى PNG, PPT إلى PNG, PPTX إلى PNG, java, Aspose.Slides لـ Android عبر Java
description: تحويل عرض PowerPoint إلى PNG
---

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (الرسومات الشبكية القابلة للنقل) ليس شائعًا مثل JPEG (مجموعة الخبراء المشتركة في التصوير)، لكنه لا يزال شائعًا جدًا.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة والحجم ليس مشكلة، فإن PNG هو تنسيق صورة أفضل من JPEG.

{{% alert title="نصيحة" color="primary" %}} قد ترغب في تجربة **محولات PowerPoint إلى PNG** المجانية من Aspose: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). إنها تنفيذ مباشر للعملية الموضحة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

قم بمتابعة هذه الخطوات:

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. احصل على كائن الشريحة من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) تحت واجهة [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide).
3. استخدم طريقة [ISlide.getImage()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) للحصول على الصورة المصغرة لكل شريحة.
4. استخدم طريقة  [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) لحفظ الصورة المصغرة للشريحة بصيغة PNG.

هذا الكود بلغة Java يوضح لك كيفية تحويل عرض PowerPoint إلى PNG:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

إذا كنت تريد الحصول على ملفات PNG حول مقياس معين، يمكنك تعيين القيم لـ `desiredX` و `desiredY`، التي تحدد أبعاد الصورة المصغرة الناتجة.

هذا الكود بلغة Java يوضح العملية الموضحة:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحويل PowerPoint إلى PNG بحجم مخصص**

إذا كنت تريد الحصول على ملفات PNG بحجم معين، يمكنك تمرير قيمتك المفضلة لـ `width` و `height` كوسائط لـ `ImageSize`.

هذا الكود يوضح كيفية تحويل PowerPoint إلى PNG مع تحديد الحجم للصور:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```