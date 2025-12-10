---
title: تحويل شرائح PowerPoint إلى PNG في Java
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/java/convert-powerpoint-to-png/
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
- Java
- Aspose.Slides
description: "حوّل عروض PowerPoint التقديمية إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides لـ Java، مع ضمان نتائج دقيقة ومؤتمتة."
---

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (Portable Network Graphics) ليس شائعًا كما هو JPEG (Joint Photographic Experts Group)، لكنه لا يزال شائعًا جدًا.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة ولا يعتبر الحجم مشكلة، يكون PNG تنسيق صورة أفضل من JPEG.

{{% alert title="Tip" color="primary" %}} قد ترغب في الاطلاع على محولات Aspose المجانية **PowerPoint إلى PNG**: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). إنها تنفيذ حي للعملية الموضحة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على كائن الشريحة من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) تحت الواجهة [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide).
3. استخدم طريقة [ISlide.getImage()](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) للحصول على صورة مصغرة لكل شريحة.
4. استخدم طريقة [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) لحفظ الصورة المصغرة للشفريحة بتنسيق PNG.

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

إذا كنت ترغب في الحصول على ملفات PNG بمقياس معين، يمكنك ضبط القيم لـ `desiredX` و `desiredY`، التي تحدد أبعاد الصورة المصغرة الناتجة.

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

إذا كنت ترغب في الحصول على ملفات PNG بحجم معين، يمكنك تمرير القيم المفضلة لـ `width` و `height` في `ImageSize`.

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


## **الأسئلة المتكررة**

**كيف يمكنني استخراج شكل محدد فقط (مثل مخطط أو صورة) بدلاً من الشريحة بأكملها؟**

يدعم Aspose.Slides [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/java/create-shape-thumbnails/); يمكنك تحويل شكل إلى صورة PNG.

**هل يتم دعم التحويل المتوازي على الخادم؟**

نعم، ولكن لا يجب [مشاركة](/slides/ar/java/multithreading/) نسخة واحدة من العرض عبر الخيوط. استخدم نسخة منفصلة لكل خيط أو عملية.

**ما هي قيود نسخة التجريب عند التصدير إلى PNG؟**

يضيف وضع التقييم علامة مائية إلى الصور الناتجة ويفرض [قيودًا أخرى](/slides/ar/java/licensing/) حتى يتم تطبيق ترخيص.