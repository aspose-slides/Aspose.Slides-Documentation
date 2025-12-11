---
title: تحويل PPT و PPTX إلى JPG على Android
linktitle: PowerPoint إلى JPG
type: docs
weight: 60
url: /ar/androidjava/convert-powerpoint-to-jpg/
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
- Android
- Java
- Aspose.Slides
description: "تحويل شرائح PowerPoint (PPT، PPTX) إلى صور JPG عالية الجودة في Java باستخدام Aspose.Slides لنظام Android باستخدام أمثلة شفرة سريعة وموثوقة."
---

## **نظرة عامة**

يساعد تحويل عروض PowerPoint وOpenDocument إلى صور JPG في مشاركة الشرائح، تحسين الأداء، وتضمين المحتوى في المواقع الإلكترونية أو التطبيقات. يسمح Aspose.Slides for Android via Java بتحويل ملفات PPTX وPPT وODP إلى صور JPEG عالية الجودة. يشرح هذا الدليل طرق التحويل المختلفة.

مع هذه المميزات، يصبح من السهل تنفيذ عارض عروض تقديمية خاص بك وإنشاء صورة مصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا رغبت في حماية الشرائح من النسخ أو عرض العرض في وضع القراءة فقط. يتيح Aspose.Slides تحويل العرض الكامل أو شريحة معينة إلى صيغ صور.

## **تحويل شرائح العرض التقديمي إلى صور JPG**

إليك خطوات تحويل ملف PPT أو PPTX أو ODP إلى JPG:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. الحصول على كائن الشريحة من النوع [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) من المجموعة التي تُرجِعها طريقة [Presentation.getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) .
1. إنشاء صورة للشريحة باستخدام طريقة [ISlide.getImage(float, float)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) .
1. استدعاء طريقة [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) على كائن الصورة. مرّر اسم ملف الإخراج وصيغة الصورة كمعاملين.

{{% alert color="primary" %}} 
**ملاحظة:** يختلف التحويل من PPT أو PPTX أو ODP إلى JPG عن التحويل إلى صيغ أخرى في واجهة برمجة تطبيقات Aspose.Slides Android عبر Java. بالنسبة للصيغ الأخرى، عادةً ما تستخدم طريقة [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) . ومع ذلك، لتقنية JPG، عليك استخدام طريقة [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) .
{{% /alert %}} 
```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // إنشاء صورة شريحة بالمقياس المحدد.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // حفظ الصورة على القرص بصيغة JPEG.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```


## **تحويل الشرائح إلى JPG بأبعاد مخصصة**

لتغيير أبعاد صور JPG الناتجة، يمكنك تعيين حجم الصورة بتمريره إلى طريقة [ISlide.getImage(Size)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) . يتيح لك ذلك إنشاء صور بعرض وارتفاع محددين، مما يضمن أن المخرج يفي بمتطلبات الدقة ونسبة العرض إلى الارتفاع. تكون هذه المرونة مفيدة بشكل خاص عند إنشاء صور لتطبيقات الويب أو التقارير أو الوثائق، حيث تتطلب الأبعاد الدقيقة للصور.

```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // إنشاء صورة شريحة بالحجم المحدد.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // حفظ الصورة على القرص بصيغة JPEG.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```


## **عرض التعليقات عند حفظ الشرائح كصور**

يوفر Aspose.Slides for Android via Java ميزة تسمح لك بعرض التعليقات على شرائح العرض عند تحويلها إلى صور JPG. تكون هذه الوظيفة مفيدة بشكل خاص للحفاظ على الملاحظات أو الملاحظات التكميلية أو المناقشات التي يضيفها المتعاونون في عروض PowerPoint. من خلال تمكين هذا الخيار، تضمن ظهور التعليقات في الصور المولدة، مما يسهل مراجعة الملاحظات ومشاركتها دون الحاجة إلى فتح ملف العرض الأصلي.

لنفترض أن لدينا ملف عرض تقديمي اسمه "sample.pptx"، يحتوي على شريحة بها تعليقات:

![الشريحة مع التعليقات](slide_with_comments.png)

الكود التالي بلغة Java يحول الشريحة إلى صورة JPG مع الحفاظ على التعليقات:
```java
int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(Color.rgb(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // تحويل الشريحة الأولى إلى صورة.
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```


النتيجة:

![صورة JPG مع التعليقات](image_with_comments.png)

## **انظر أيضاً**

اطلع على خيارات أخرى لتحويل PPT أو PPTX أو ODP إلى صور، مثل:

- [تحويل PowerPoint إلى GIF](/slides/ar/androidjava/convert-powerpoint-to-animated-gif/)
- [تحويل PowerPoint إلى PNG](/slides/ar/androidjava/convert-powerpoint-to-png/)
- [تحويل PowerPoint إلى TIFF](/slides/ar/androidjava/convert-powerpoint-to-tiff/)
- [تحويل PowerPoint إلى SVG](/slides/ar/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
لمعرفة كيفية تحويل Aspose.Slides لعروض PowerPoint إلى صور JPG، جرّب هذه المحولات المجانية عبر الإنترنت: PowerPoint [PPTX إلى JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) و [PPT إلى JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg) . 
{{% /alert %}} 

![محول PPTX إلى JPG مجاني عبر الإنترنت](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

توفر Aspose تطبيق ويب [Collage المجاني]https://products.aspose.app/slides/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/collage/jpg) أو [PNG إلى PNG](https://products.aspose.app/slides/collage/png) وإنشاء [شبكات الصور](https://products.aspose.app/slides/collage/photo-grid)، وما إلى ذلك. 

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من صيغة إلى أخرى. لمزيد من المعلومات، راجع هذه الصفحات: تحويل [الصورة إلى JPG](https://products.aspose.com/slides/java/conversion/image-to-jpg/)؛ تحويل [JPG إلى صورة](https://products.aspose.com/slides/java/conversion/jpg-to-image/)؛ تحويل [JPG إلى PNG](https://products.aspose.com/slides/java/conversion/jpg-to-png/)؛ تحويل [PNG إلى JPG](https://products.aspose.com/slides/java/conversion/png-to-jpg/)؛ تحويل [PNG إلى SVG](https://products.aspose.com/slides/java/conversion/png-to-svg/)؛ تحويل [SVG إلى PNG](https://products.aspose.com/slides/java/conversion/svg-to-png/) .
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يدعم هذا الأسلوب التحويل الجماعي؟**

نعم، يتيح Aspose.Slides التحويل الجماعي لعدة شرائح إلى JPG في عملية واحدة.

**هل يدعم التحويل SmartArt والرسوم البيانية والكائنات المعقدة الأخرى؟**

نعم، يقوم Aspose.Slides بتصيير جميع المحتويات، بما في ذلك SmartArt والرسوم البيانية والجداول والأشكال وغيرها. قد تختلف دقة التصيير قليلًا مقارنةً بـ PowerPoint، خاصة عند استخدام خطوط مخصصة أو مفقودة.

**هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟**

لا يفرض Aspose.Slides حدودًا صارمة على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه خطأ نقص الذاكرة عند العمل على عروض تقديمية كبيرة أو صور بدقة عالية.