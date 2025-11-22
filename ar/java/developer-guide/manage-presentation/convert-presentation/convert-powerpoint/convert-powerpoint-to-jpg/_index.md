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

## هل تبحث عن محول PPT إلى JPG عبر الإنترنت؟
قبل الانتقال إلى كود Java، إذا كنت بحاجة إلى **أداة سريعة عبر الإنترنت** لتحويل PowerPoint (PPT، PPTX) إلى JPG **دون كتابة كود**، تفقد محولنا عبر الإنترنت:
[Aspose PPT to JPG Converter](https://products.aspose.app/slides/conversion/ppt-to-jpg)

إذا كنت **مطورًا يبحث عن حل برمجي**، تابع القراءة لتتعرف على كيفية تحويل شرائح PowerPoint إلى JPG باستخدام **Aspose.Slides for Java**.

## **حول تحويل PowerPoint إلى JPG**
باستخدام [**Aspose.Slides API**](https://products.aspose.com/slides/java/) يمكنك تحويل عرض PowerPoint PPT أو PPTX إلى صورة JPG. كما يمكن تحويل PPT/PPTX إلى JPEG أو PNG أو SVG. مع هذه الميزات يصبح من السهل تنفيذ عارض عرض تقديمي خاص بك، إنشاء صورة مصغرة لكل شريحة. قد يكون هذا مفيدًا إذا كنت ترغب في حماية شرائح العرض من النسخ، عرض العرض في وضع القراءة فقط. يتيح Aspose.Slides تحويل كامل العرض أو شريحة محددة إلى تنسيقات الصور.

{{% alert color="primary" %}} 
لمشاهدة كيفية تحويل Aspose.Slides لـ PowerPoint إلى صور JPG، قد ترغب في تجربة هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX إلى JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و[PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}} 

[![todo:image_alt_text](ppt-to-jpg.png)

## **تحويل PowerPoint PPT/PPTX إلى JPG**
فيما يلي الخطوات لتحويل PPT/PPTX إلى JPG:

1. إنشاء نسخة من النوع [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. احصل على كائن الشريحة من النوع [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--).
3. أنشئ الصورة المصغرة لكل شريحة ثم حوّلها إلى JPG. تُستخدم الطريقة [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-) للحصول على صورة مصغرة لشريحة، وتُعيد كائن [Images](https://reference.aspose.com/slides/java/com.aspose.slides/Images) كنتيجة. يجب استدعاء الطريقة [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) من الشريحة المطلوبة من نوع [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)، حيث يتم تمرير مقاييس الصورة المصغرة الناتجة إلى الطريقة.
4. بعد الحصول على الصورة المصغرة للشريحة، استدعِ الطريقة [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) من كائن الصورة المصغرة. مرّر اسم الملف الناتج وتنسيق الصورة إليها. 

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
لتغيير أبعاد الصورة المصغرة الناتجة وصورة JPG، يمكنك ضبط قيمتي *ScaleX* و*ScaleY* بتمريرهما إلى طرق [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getImage-float-float-):
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


## **عرض التعليقات عند حفظ العرض كصورة**
يوفر Aspose.Slides for Java ميزة تسمح لك بعرض التعليقات في شرائح العرض عند تحويل هذه الشرائح إلى صور. يوضح هذا الكود Java العملية:
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

توفر Aspose تطبيقًا ويبًا مجانيًا لإنشاء الكولاج [FREE Collage web app](https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج صور [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات الصور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك.

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. لمزيد من المعلومات، راجع هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/).

{{% /alert %}}

## الأسئلة المتكررة (FAQ)

### كيف يمكنني تحويل PowerPoint (PPT، PPTX) إلى JPG؟
يمكنك تحويل شرائح PowerPoint إلى JPG باستخدام Aspose.Slides for Java. يضمن ذلك تحويلًا عالي الجودة للصور مع التحكم الكامل في إعدادات الإخراج.

### هل يدعم هذا الأسلوب التحويل بالجملة؟
نعم، يتيح Aspose.Slides التحويل بالجملة لعدة شرائح إلى JPG في عملية واحدة.

### هل يمكنني ضبط دقة مخصصة لصورة JPG الناتجة؟
نعم، يمكنك تحديد دقة مخصصة للصورة وإعدادات الجودة باستخدام Aspose.Slides API.

### هل هناك محول PowerPoint إلى JPG متاح عبر الإنترنت؟
توفر Aspose حلولًا برمجية ومحولات عبر الإنترنت. يمكنك الاطلاع على [Aspose Online PPT to JPG Converter](https://products.aspose.app/slides/conversion/ppt-to-jpg) للتحويلات السريعة.

## **انظر أيضًا**
اطلع على خيارات أخرى لتحويل PPT/PPTX إلى صورة مثل:
- [تحويل PPT/PPTX إلى SVG](/slides/ar/java/render-a-slide-as-an-svg-image/).