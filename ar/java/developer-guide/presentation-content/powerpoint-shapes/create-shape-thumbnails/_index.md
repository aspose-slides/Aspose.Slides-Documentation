---
title: إنشاء صور مصغرة للأشكال
type: docs
weight: 70
url: /java/create-shape-thumbnails/
---


## **نظرة عامة**
{{% alert color="primary" %}} 

يمكن استخدام Aspose.Slides لـ Java لإنشاء ملفات العروض التقديمية التي يت correspond فيها كل صفحة إلى شريحة. يمكن عرض الشرائح عن طريق فتح ملفات العروض التقديمية باستخدام Microsoft PowerPoint. ومع ذلك، يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض الصور. في مثل هذه الحالات، تساعد Aspose.Slides لـ Java في توليد صور مصغرة لأشكال الشرائح.

{{% /alert %}} 

في هذا الموضوع، سنوضح كيفية توليد صور مصغرة للشرائح في مواقف مختلفة:

- توليد صورة مصغرة لشكل داخل شريحة.
- توليد صورة مصغرة لشكل شريحة مع أبعاد معرفة من قبل المستخدم.
- توليد صورة مصغرة ضمن حدود مظهر الشكل.

## **توليد صور مصغرة للأشكال من الشرائح**
لتوليد صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides لـ Java، قم بالآتي:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. احصل على المرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. [احصل على صورة مصغرة الشكل](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage--) للشريحة المرجعية على المقياس الافتراضي.
1. احفظ صورة المصغرة بتنسيق الصورة الذي تفضله.

يظهر لك هذا الكود النموذجي كيفية توليد صورة مصغرة لشكل من شريحة:

```java
// instantiate a Presentation class that represents the presentation file
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // create a full scale image
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // save the image to disk in PNG format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **توليد صور مصغرة للأشكال مع عامل مقياس محدد من قبل المستخدم**
لتوليد صورة مصغرة لشكل في شريحة باستخدام Aspose.Slides لـ Java، قم بالآتي:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. احصل على المرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. [احصل على صورة مصغرة الشكل](https://reference.aspose.com/slides/java/com.aspose.slides/IShape#getImage-int-float-float-) للشريحة المرجعية مع أبعاد معرفة من قبل المستخدم.
1. احفظ صورة المصغرة بتنسيق الصورة الذي تفضله.

يظهر لك هذا الكود النموذجي كيفية توليد صورة مصغرة لشكل استنادًا إلى عامل مقياس محدد:

```java
// instantiate a Presentation class that represents the presentation file
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // create a full scale image
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // save the image to disk in PNG format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **توليد صورة مصغرة لأبعاد الشكل**
تسمح هذه الطريقة بإنشاء صور مصغرة للأشكال بتوليد صورة مصغرة ضمن حدود مظهر الشكل. تأخذ في الاعتبار جميع تأثيرات الشكل. يتم تقييد صورة الشكل المصغرة الناتجة بواسطة حدود الشريحة. لتوليد صورة مصغرة لشكل شريحة في حدود مظهره، قم بالآتي:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. احصل على المرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. احصل على صورة المصغرة للشريحة المرجعية مع حدود الشكل كمظهر.
1. احفظ صورة المصغرة بتنسيق الصورة الذي تفضله.

هذا الكود النموذجي مستند إلى الخطوات أعلاه:

```java
// instantiate a Presentation class that represents the presentation file
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // create a full scale image
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // save the image to disk in PNG format
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```