---
title: إنشاء صورة مصغرة للأشكال
type: docs
weight: 70
url: /androidjava/create-shape-thumbnails/
---


## **نظرة عامة**
{{% alert color="primary" %}} 

يمكن استخدام Aspose.Slides لـ Android عبر Java لإنشاء ملفات تقديم حيث يتوافق كل صفحة مع شريحة. يمكن عرض الشرائح عن طريق فتح ملفات التقديم باستخدام Microsoft PowerPoint. ومع ذلك، يحتاج المطورون أحيانًا إلى عرض صور الأشكال بشكل منفصل في عارض صور. في هذه الحالات، يساعد Aspose.Slides لـ Android عبر Java في توليد صور مصغرة للأشكال في الشرائح.

{{% /alert %}} 

في هذا الموضوع، سوف نوضح كيفية توليد صور مصغرة للشرائح في حالات مختلفة:

- توليد صورة مصغرة لشكل داخل شريحة.
- توليد صورة مصغرة لشكل شريحة بأبعاد محددة من المستخدم.
- توليد صورة مصغرة في حدود مظهر الشكل.

## **توليد صور مصغرة للأشكال من الشرائح**
لتوليد صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides لـ Android عبر Java، اتبع الخطوات التالية:

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. احصل على مرجع لأي شريحة باستخدام معرّفها أو فهرسها.
1. [احصل على صورة مصغرة الشكل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage--) للشريحة المرجعية على المقياس الافتراضي.
1. احفظ صورة المصغرة في تنسيق الصورة المفضل لديك.

يوضح هذا الرمز النموذجي كيفية توليد صورة مصغرة لشكل من شريحة:

```java
// إنشاء مثيل لفئة Presentation التي تمثل ملف التقديم
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بمقياس كامل
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // حفظ الصورة على القرص بتنسيق PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **توليد صور مصغرة للأشكال مع عامل قياس محدد من المستخدم**
لتوليد صورة مصغرة لشكل شريحة باستخدام Aspose.Slides لـ Android عبر Java، اتبع الخطوات التالية:

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. احصل على مرجع لأي شريحة باستخدام معرّفها أو فهرسها.
1. [احصل على صورة مصغرة الشكل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) للشريحة المرجعية مع أبعاد محددة من المستخدم.
1. احفظ صورة المصغرة في تنسيق الصورة المفضل لديك.

يوضح هذا الرمز النموذجي كيفية توليد صورة مصغرة لشكل بناءً على عامل قياس محدد:

```java
// إنشاء مثيل لفئة Presentation التي تمثل ملف التقديم
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بمقياس كامل
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // حفظ الصورة على القرص بتنسيق PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **توليد صورة مصغرة لشكل في حدود المظهر**
تسمح هذه الطريقة بإنشاء صور مصغرة للأشكال للمطورين لإنشاء صورة مصغرة في حدود مظهر الشكل. تأخذ في الاعتبار جميع تأثيرات الشكل. يتم تقييد صورة الشكل المصغرة المنتجة بواسطة حدود الشريحة. لتوليد صورة مصغرة لشكل شريحة في حدود مظهره، اتبع الخطوات التالية:

1. أنشئ مثيل من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. احصل على مرجع لأي شريحة باستخدام معرّفها أو فهرسها.
1. احصل على صورة المصغرة للشريحة المرجعية مع حدود الشكل كمظهر.
1. احفظ صورة المصغرة في تنسيق الصورة المفضل لديك.

هذا الرمز النموذجي مستند إلى الخطوات السابقة:

```java
// إنشاء مثيل لفئة Presentation التي تمثل ملف التقديم
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // إنشاء صورة بمقياس كامل
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // حفظ الصورة على القرص بتنسيق PNG
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```