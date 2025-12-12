---
title: تحويل شرائح PowerPoint إلى PNG على Android
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/androidjava/convert-powerpoint-to-png/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PNG
- العرض التقديمي إلى PNG
- الشريحة إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- حفظ PPT كـ PNG
- حفظ PPTX كـ PNG
- تصدير PPT إلى PNG
- تصدير PPTX إلى PNG
- Android
- Java
- Aspose.Slides
description: "قم بتحويل عروض PowerPoint إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides لنظام Android عبر Java، مما يضمن نتائج دقيقة وآلية."
---

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (Portable Network Graphics) ليس شائعًا كما JPEG (Joint Photographic Experts Group)، لكنه لا يزال شائعًا جدًا.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة ولا تكون الحجم مشكلة، فإن PNG هو تنسيق صورة أفضل من JPEG.

{{% alert title="Tip" color="primary" %}} قد ترغب في تجربة محولات Aspose المجانية **PowerPoint إلى PNG**: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). إنها تطبيق مباشر للعملية الموضحة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء مثيل للفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. احصل على كائن الشريحة من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) تحت واجهة [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide).
3. استخدم طريقة [ISlide.getImage()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) للحصول على صورة مصغرة لكل شريحة.
4. استخدم طريقة [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) لحفظ الصورة المصغرة للشفرة بتنسيق PNG.

يعرض لك هذا الكود بلغة Java كيفية تحويل عرض PowerPoint إلى PNG:
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

إذا كنت ترغب في الحصول على ملفات PNG بحجم معين، يمكنك ضبط القيم `desiredX` و `desiredY`، التي تحدد أبعاد الصورة المصغرة الناتجة.

يعرض لك هذا الكود بلغة Java العملية الموصوفة:
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

إذا كنت ترغب في الحصول على ملفات PNG بحجم معين، يمكنك تمرير القيم المفضلة `width` و `height` لـ `ImageSize`.

يعرض لك هذا الكود كيفية تحويل PowerPoint إلى PNG مع تحديد حجم الصور:
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


## **الأسئلة الشائعة**

**كيف يمكنني تصدير شكل محدد فقط (مثل مخطط أو صورة) بدلاً من الشريحة بالكامل؟**  
يدعم Aspose.Slides [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/androidjava/create-shape-thumbnails/); يمكنك تحويل الشكل إلى صورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**  
نعم، لكن [لا تشارك](/slides/ar/androidjava/multithreading/) مثيل عرض واحد بين الخيوط. استخدم مثيلًا منفصلًا لكل خيط أو عملية.

**ما هي قيود النسخة التجريبية عند التصدير إلى PNG؟**  
يضيف وضع التقييم علامة مائية إلى صور الإخراج ويفرض [قيودًا أخرى](/slides/ar/androidjava/licensing/) حتى يتم تطبيق ترخيص.