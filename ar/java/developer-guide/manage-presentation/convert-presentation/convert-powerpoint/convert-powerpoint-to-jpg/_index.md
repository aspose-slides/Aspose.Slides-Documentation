---
title: تحويل Powerpoint إلى JPG
type: docs
weight: 60
url: /java/convert-powerpoint-to-jpg/
keywords: "تحويل PowerPoint إلى JPG, PPTX إلى JPEG, PPT إلى JPEG"
description: "تحويل PowerPoint إلى JPG: PPT إلى JPG, PPTX إلى JPG في Java"
---


## **حول تحويل PowerPoint إلى JPG**
مع [**Aspose.Slides API**](https://products.aspose.com/slides/java/) يمكنك تحويل عرض PowerPoint PPT أو PPTX إلى صورة JPG. من الممكن أيضًا تحويل PPT/PPTX إلى JPEG أو PNG أو SVG. مع هذه الميزات، من السهل تنفيذ عارض العرض التقديمي الخاص بك، وإنشاء المصغرات لكل شريحة. قد يكون هذا مفيدًا إذا كنت تريد حماية شرائح العرض التقديمي من حقوق النسخ، أو عرض العرض التقديمي في وضع القراءة فقط. تسمح Aspose.Slides بتحويل العرض التقديمي بالكامل أو شريحة معينة إلى تنسيقات الصور.

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides PowerPoint إلى صور JPG، قد ترغب في تجربة هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX إلى JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و[PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg).

{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **تحويل PowerPoint PPT/PPTX إلى JPG**
إليك الخطوات لتحويل PPT/PPTX إلى JPG:

1. قم بإنشاء مثيل من نوع [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على كائن الشريحة من نوع [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--).
3. قم بإنشاء المصغرة لكل شريحة ثم تحويلها إلى JPG. يُستخدم [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) للحصول على مصغرة لشريحة، ويعيد [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images) كائن كنتيجة. يجب استدعاء [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) من الشريحة المطلوبة من نوع [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)، وتُمرر مقاييس المصغرات الناتجة إلى الأسلوب.
4. بعد الحصول على مصغرة الشريحة، استدعِ [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) من كائن المصغرة. قم بتمرير اسم الملف الناتج وتنسيق الصورة إليه.

{{% alert color="primary" %}}

**ملاحظة**: يختلف تحويل PPT/PPTX إلى JPG عن التحويل إلى أنواع أخرى في Aspose.Slides API. بالنسبة لأنواع أخرى، عادةً ما تستخدم [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) الأسلوب، لكن هنا تحتاج إلى استخدام [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // ينشئ صورة بمقياس كامل
        IImage slideImage = sld.getImage(1f, 1f);

        // يحفظ الصورة على القرص بتنسيق JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **تحويل PowerPoint PPT/PPTX إلى JPG بأبعاد مخصصة**
لتغيير أبعاد المصغرة الناتجة وصورة JPG، يمكنك ضبط قيم *ScaleX* و*ScaleY* بتمريرها إلى [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) الأساليب:

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // يحدد الأبعاد
    int desiredX = 1200;
    int desiredY = 800;
    // يحصل على القيم المقاسة لـ X و Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // ينشئ صورة بمقياس كامل
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // يحفظ الصورة على القرص بتنسيق JPEG
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **عرض التعليقات عند حفظ العرض التقديمي كصورة**
توفر Aspose.Slides لـ Java تسهيلات تتيح لك عرض التعليقات في شرائح العرض التقديمي عندما تقوم بتحويل تلك الشرائح إلى صور. يوضح هذا الكود Java العملية:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="نصيحة" color="primary" %}}

تقدم Aspose تطبيق ويب [مجانًا](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو صور PNG إلى PNG، إنشاء [شبكات الصور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك.

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. لمزيد من المعلومات، انظر هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

## **انظر أيضًا**

انظر خيارات أخرى لتحويل PPT/PPTX إلى صورة مثل:

- [تحويل PPT/PPTX إلى SVG](/slides/java/render-a-slide-as-an-svg-image/).