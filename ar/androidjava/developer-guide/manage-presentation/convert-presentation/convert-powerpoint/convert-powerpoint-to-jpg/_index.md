---
title: تحويل الباوربوينت إلى JPG
type: docs
weight: 60
url: /androidjava/convert-powerpoint-to-jpg/
keywords:
- تحويل عرض باوربوينت
- JPG
- JPEG
- باوربوينت إلى JPG
- باوربوينت إلى JPEG
- PPT إلى JPG
- PPTX إلى JPG
- PPT إلى JPEG
- PPTX إلى JPEG
- أندرويد
- Aspose.Slides
description: "تحويل باوربوينت إلى JPG: PPT إلى JPG، PPTX إلى JPG بلغة Java"
---

## **حول تحويل باوربوينت إلى JPG**
مع [**API Aspose.Slides**](https://products.aspose.com/slides/androidjava/) يمكنك تحويل عرض باوربوينت بصيغة PPT أو PPTX إلى صورة JPG. من الممكن أيضًا تحويل PPT/PPTX إلى JPEG، PNG أو SVG. مع هذه الميزات، يمكنك بسهولة تنفيذ عارض العروض الخاص بك، وإنشاء الصورة المصغرة لكل شريحة. قد يكون هذا مفيدًا إذا كنت ترغب في حماية شرائح العرض من حقوق الطبع والنشر، أو عرض العرض في وضع القراءة فقط. تتيح Aspose.Slides تحويل العرض بالكامل أو شريحة معينة إلى تنسيقات الصور.

{{% alert color="primary" %}} 

لرؤية كيفية تحويل Aspose.Slides باوربوينت إلى صور JPG، قد ترغب في تجربة هذه المحولات المجانية عبر الإنترنت: باوربوينت [PPTX إلى JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و [PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg).

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **تحويل باوربوينت PPT/PPTX إلى JPG**
فيما يلي خطوات تحويل PPT/PPTX إلى JPG:

1. إنشاء مثيل من نوع [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
2. الحصول على كائن الشريحة من نوع [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--).
3. إنشاء الصورة المصغرة لكل شريحة ثم تحويلها إلى JPG. يتم استخدام [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-) للحصول على صورة مصغرة من الشريحة، حيث تُرجع كائن [Images](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Images) كنتيجة. يجب استدعاء [getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) من الشريحة المطلوبة من نوع [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide)، ويتم تمرير مقاييس الصورة المصغرة الناتجة إلى الطريقة.
4. بعد الحصول على الصورة المصغرة للشريحة، قم باستدعاء [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) من كائن الصورة المصغرة. قم بتمرير اسم الملف الناتج ونوع الصورة إليه.

{{% alert color="primary" %}}

**ملاحظة**: يختلف تحويل PPT/PPTX إلى JPG عن التحويل إلى أنواع أخرى في Aspose.Slides API. بالنسبة لأنواع أخرى، عادةً ما تستخدم [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) ولكن هنا تحتاج إلى [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)).

{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // Creates a full scale image
        IImage slideImage = sld.getImage(1f, 1f);

        // Saves the image to disk in JPEG format
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

## **تحويل باوربوينت PPT/PPTX إلى JPG بأبعاد مخصصة**
لتغيير أبعاد الصورة المصغرة والصورة الناتجة، يمكنك تعيين قيم *ScaleX* و *ScaleY* عن طريق تمريرها إلى [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getImage-float-float-) الطرق:

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // Defines dimensions
    int desiredX = 1200;
    int desiredY = 800;
    // Gets scaled values of X and Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // Creates a full scale image
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // Saves the image to disk in JPEG format
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

## **عرض التعليقات عند حفظ العرض كصورة**
تقدم Aspose.Slides لنظام Android عبر Java ميزة تتيح لك عرض التعليقات في شرائح العرض عندما تقوم بتحويل هذه الشرائح إلى صور. توضح هذه الشيفرة بلغة Java العملية:

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

تقدم Aspose تطبيق ويب [مجاني للتجميع](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو صور PNG إلى PNG، وإنشاء [شبكات الصور](https://products.aspose.app/slides/collage/photo-grid)، وهكذا. 

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. لمزيد من المعلومات، انظر إلى هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/androidjava/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/androidjava/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/androidjava/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/androidjava/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/androidjava/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/androidjava/conversion/svg-to-png/).

{{% /alert %}}

## **انظر أيضًا**

انظر خيارات أخرى لتحويل PPT/PPTX إلى صورة مثل:

- [تحويل PPT/PPTX إلى SVG](/slides/androidjava/render-a-slide-as-an-svg-image/).