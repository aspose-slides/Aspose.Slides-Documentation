---
title: تحويل PPT و PPTX إلى JPG في Java
linktitle: PowerPoint إلى JPG
type: docs
weight: 60
url: /ar/java/convert-powerpoint-to-jpg/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى JPG
- العرض التقديمي إلى JPG
- الشريحة إلى JPG
- PPT إلى JPG
- PPTX إلى JPG
- حفظ PowerPoint كـ JPG
- حفظ العرض التقديمي كـ JPG
- حفظ الشريحة كـ JPG
- حفظ PPT كـ JPG
- حفظ PPTX كـ JPG
- تصدير PPT إلى JPG
- تصدير PPTX إلى JPG
- Java
- Aspose.Slides
description: "تحويل شرائح PowerPoint (PPT, PPTX) إلى صور JPG عالية الجودة في Java باستخدام Aspose.Slides for Java مع أمثلة شفرة سريعة وموثوقة."
---

## **هل تبحث عن أداة تحويل PPT إلى JPG عبر الإنترنت؟**

قبل الانتقال إلى كود Java، إذا كنت تحتاج إلى **أداة سريعة عبر الإنترنت** لتحويل PowerPoint (PPT، PPTX) إلى JPG **بدون برمجة**، اطلع على محولنا عبر الإنترنت:
[محول Aspose PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)

إذا كنت **مطورًا يبحث عن حل برمجي**، استمر في القراءة لتتعرف على كيفية تحويل شرائح PowerPoint إلى JPG باستخدام **Aspose.Slides for Java**.

## **حول تحويل PowerPoint إلى JPG**

باستخدام [**Aspose.Slides API**](https://products.aspose.com/slides/java/) يمكنك تحويل عرض PowerPoint PPT أو PPTX إلى صورة JPG. كما يمكنك تحويل PPT/PPTX إلى JPEG أو PNG أو SVG. مع هذه الميزات يصبح من السهل تنفيذ عارض العروض الخاص بك، إنشاء  الصورة المصغرة لكل شريحة. قد يكون هذا مفيدًا إذا رغبت في حماية شرائح العرض من النسخ، وعرض العرض في وضع القراءة فقط. يتيح Aspose.Slides تحويل العرض بالكامل أو شريحة معينة إلى صيغ صور.

{{% alert color="primary" %}} 
لرؤية كيفية تحويل Aspose.Slides لملفات PowerPoint إلى صور JPG، قد ترغب في تجربة هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX إلى JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و[PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **تحويل PowerPoint PPT/PPTX إلى JPG**

فيما يلي الخطوات لتحويل PPT/PPTX إلى JPG:

1. إنشاء كائن من النوع [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. الحصول على كائن الشريحة من النوع [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--).
3. إنشاء صورة مصغرة لكل شريحة ثم تحويلها إلى JPG. تُستخدم طريقة [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) للحصول على صورة مصغرة لشريحة، وتعيد كائن [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images). يجب استدعاء طريقة [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) من الشريحة المطلوبة من النوع [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)، حيث يتم تمرير مقاييس الصورة المصغرة الناتجة إلى الطريقة.
4. بعد الحصول على الصورة المصغرة للشريحة، استدعِ طريقة [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) من كائن الصورة المصغرة. قم بتمرير اسم الملف الناتج وتنسيق الصورة إليها. 

{{% alert color="primary" %}}

**ملاحظة**: يختلف تحويل PPT/PPTX إلى JPG عن التحويل إلى الأنواع الأخرى في Aspose.Slides API. بالنسبة للأنواع الأخرى، عادةً ما تستخدم طريقة [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)، ولكن هنا تحتاج إلى طريقة [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)). 

{{% /alert %}} 
```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // ينشئ صورة بمقياس كامل
        IImage slideImage = sld.getImage(1f, 1f);

        // يحفظ الصورة على القرص بصيغة JPEG
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

لتغيير أبعاد الصورة المصغرة الناتجة وصورة JPG، يمكنك تعيين قيم *ScaleX* و*ScaleY* بتمريرها إلى طرق [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-). 
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

        // يحفظ الصورة على القرص بصيغة JPEG
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


## **عرض التعليقات عند حفظ الشرائح كصور**

يوفر Aspose.Slides for Java خاصية تسمح لك بعرض التعليقات في شرائح العرض عند تحويل تلك الشرائح إلى صور. يوضح هذا الكود Java العملية:
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


{{% alert title="Tip" color="primary" %}}

Aspose تقدم [تطبيق Collage مجاني على الويب](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات الصور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

وباستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. للمزيد من المعلومات، راجع هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/), تحويل [PNG إلى JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/), تحويل [SVG إلى PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/). 

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يدعم هذه الطريقة التحويل على دفعات؟**

نعم، يسمح Aspose.Slides بالتحويل على دفعات لعدة شرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل عناصر SmartArt، الرسوم البيانية، وغيرها من الكائنات المعقدة؟**

نعم، يقوم Aspose.Slides بتصيّر كل المحتوى، بما في ذلك SmartArt، والرسوم البيانية، والجداول، والأشكال، والمزيد. ومع ذلك، قد تختلف دقة التصيّر قليلاً مقارنةً بـ PowerPoint، خاصةً عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**

Aspose.Slides نفسها لا تفرض أي قيود صارمة على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه خطأ نفاد الذاكرة عند العمل على عروض تقديمية كبيرة أو صور عالية الدقة.

## **انظر أيضًا**

اطلع على خيارات أخرى لتحويل PPT/PPTX إلى صور مثل:
- [تحويل PPT/PPTX إلى SVG](/slides/ar/java/render-a-slide-as-an-svg-image/).