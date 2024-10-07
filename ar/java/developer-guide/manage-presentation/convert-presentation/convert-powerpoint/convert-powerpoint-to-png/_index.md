---
title: تحويل PowerPoint إلى PNG
type: docs
weight: 30
url: /java/convert-powerpoint-to-png/
keywords: PowerPoint إلى PNG, PPT إلى PNG, PPTX إلى PNG, java, Aspose.Slides for Java
description: تحويل عرض PowerPoint إلى PNG
---

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (رسومات الشبكة القابلة للنقل) ليس شائعاً مثل تنسيق JPEG (مجموعة الخبراء المشتركة للتصوير الفوتوغرافي)، لكنه لا يزال شائعاً جداً.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة والحجم ليس مشكلة، فإن PNG هو تنسيق صورة أفضل من JPEG.

{{% alert title="نصيحة" color="primary" %}} قد ترغب في الاطلاع على محولات **PowerPoint إلى PNG** المجانية من Aspose: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). إنها تطبيق مباشر للعملية الموصوفة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع هذه الخطوات:

1. قم بإنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على كائن الشريحة من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) تحت واجهة [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide).
3. استخدم طريقة [ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) للحصول على الصورة المصغرة لكل شريحة.
4. استخدم طريقة  [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) لحفظ الصورة المصغرة للشريحة بتنسيق PNG.

يعرض هذا الكود في Java كيفية تحويل عرض PowerPoint إلى PNG:

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

إذا كنت ترغب في الحصول على ملفات PNG حول مقياس معين، يمكنك تعيين القيم لـ `desiredX` و `desiredY`، التي تحدد أبعاد الصورة المصغرة الناتجة.

هذا الكود في Java يوضح العملية الموصوفة:

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

إذا كنت ترغب في الحصول على ملفات PNG حول حجم معين، يمكنك تمرير حجمي `width` و `height` المفضلين لـ `ImageSize`.

يعرض هذا الكود كيفية تحويل PowerPoint إلى PNG مع تحديد حجم الصور:

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