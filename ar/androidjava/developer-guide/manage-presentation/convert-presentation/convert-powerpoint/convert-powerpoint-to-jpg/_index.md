---
title: تحويل PPT و PPTX إلى JPG على Android
linktitle: PowerPoint إلى JPG
type: docs
weight: 60
url: /ar/androidjava/convert-powerpoint-to-jpg/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى JPG
- عرض تقديمي إلى JPG
- شريحة إلى JPG
- PPT إلى JPG
- PPTX إلى JPG
- حفظ PowerPoint كـ JPG
- حفظ عرض تقديمي كـ JPG
- حفظ شريحة كـ JPG
- حفظ PPT كـ JPG
- حفظ PPTX كـ JPG
- تصدير PPT إلى JPG
- تصدير PPTX إلى JPG
- Android
- Java
- Aspose.Slides
description: "تحويل شرائح PowerPoint (PPT, PPTX) إلى صور JPG عالية الجودة في Java باستخدام Aspose.Slides for Android مع أمثلة شفرة سريعة وموثوقة."
---
## **المقدمة**

تحويل عروض PowerPoint وOpenDocument إلى صور JPG يساعد في مشاركة الشرائح، تحسين الأداء، وتضمين المحتوى في المواقع الإلكترونية أو التطبيقات. Aspose.Slides for Android via Java يتيح لك تحويل ملفات PPTX وPPT وODP إلى صور JPEG عالية الجودة. يشرح هذا الدليل طرق التحويل المختلفة.

مع هذه الميزات، يصبح من السهل تنفيذ عارض عروضك الخاص وإنشاء صورة مصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا أردت حماية شرائح العرض من النسخ أو عرض العرض في وضع القراءة فقط. Aspose.Slides يسمح لك بتحويل العرض بالكامل أو شريحة محددة إلى صيغ صور.

## **تحويل شرائح العرض إلى صور JPG**

إليك الخطوات لتحويل ملف PPT أو PPTX أو ODP إلى JPG:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) .
2. الحصول على كائن الشريحة من النوع [ISlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/) من المجموعة التي تعيدها طريقة [Presentation.getSlides()](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#getSlides--) .
3. إنشاء صورة للشريحة باستخدام طريقة [ISlide.getImage(float, float)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#getImage-float-float-) .
4. استدعاء طريقة [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) على كائن الصورة. مرّر اسم ملف الإخراج وتنسيق الصورة كمعاملات.

{{% alert color="info" %}} 

**ملاحظة:** يختلف تحويل PPT أو PPTX أو ODP إلى JPG عن التحويل إلى صيغ أخرى في Aspose.Slides Android via Java API. بالنسبة للصيغ الأخرى، عادةً ما تستخدم طريقة [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-). ومع ذلك، لتحويل إلى JPG، تحتاج إلى استخدام طريقة [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).

{{% /alert %}} 

```java
import com.aspose.slides.*;

int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // إنشاء صورة شريحة بالمقياس المحدد.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // حفظ الصورة إلى القرص بصيغة JPEG.
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

لتغيير أبعاد صور JPG الناتجة، يمكنك تعيين حجم الصورة بتمريره إلى طريقة [ISlide.getImage(Size)](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) . يتيح لك ذلك إنشاء صور بعرض وارتفاع محددين، لضمان أن المخرجات تلبي متطلبات الدقة ونسبة الأبعاد. هذه المرونة مفيدة بشكل خاص عند إنشاء صور لتطبيقات الويب أو التقارير أو الوثائق التي تتطلب أبعادًا دقيقة للصور.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // إنشاء صورة شريحة بالحجم المحدد.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // حفظ الصورة إلى القرص بصيغة JPEG.
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

## **تصيير التعليقات عند حفظ الشرائح كصور**

Aspose.Slides for Android via Java يوفر ميزة تسمح لك بتصيير التعليقات على شرائح العرض عند تحويلها إلى صور JPG. هذه الوظيفة مفيدة للحفاظ على الملاحظات، التعليقات، أو المناقشات التي أضافها المتعاونون في عروض PowerPoint. من خلال تفعيل هذا الخيار، تضمن رؤية التعليقات في الصور المولدة، مما يسهل مراجعة ومشاركة الملاحظات دون الحاجة إلى فتح ملف العرض الأصلي.

لنفترض أن لدينا ملف عرض، "sample.pptx"، يحتوي على شريحة بها تعليقات:

![الشريحة مع التعليقات](slide_with_comments.png)

الكود التالي بلغة Java يحول الشريحة إلى صورة JPG مع الحفاظ على التعليقات:

```java
import com.aspose.slides.*;
import java.awt.Color;

int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(new Color(255, 140, 0));

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

## **المزيد**

انظر خيارات أخرى لتحويل PPT أو PPTX أو ODP إلى صور، مثل:

- [تحويل PowerPoint إلى GIF](/slides/ar/androidjava/convert-powerpoint-to-animated-gif/)
- [تحويل PowerPoint إلى PNG](/slides/ar/androidjava/convert-powerpoint-to-png/)
- [تحويل PowerPoint إلى TIFF](/slides/ar/androidjava/convert-powerpoint-to-tiff/)
- [تحويل PowerPoint إلى SVG](/slides/ar/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

لمعرفة كيفية تحويل Aspose.Slides لعروض PowerPoint إلى صور JPG، جرّب محولات الإنترنت المجانية التالية: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/ar/conversion/pptx-to-jpg) و [PPT to JPG](https://products.aspose.app/slides/ar/conversion/ppt-to-jpg). 

{{% /alert %}} 

![محول PPTX إلى JPG مجاني عبر الإنترنت](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose يقدم تطبيق ويب [مجاني لتجميع الصور](https://products.aspose.app/slides/ar/collage). باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج [JPG إلى JPG](https://products.aspose.app/slides/ar/collage/jpg) أو PNG إلى PNG، إنشاء [شبكات صور](https://products.aspose.app/slides/ar/collage/photo-grid)، وما إلى ذلك. 

باستخدام نفس المبادئ الموضحة في هذه المقالة، يمكنك تحويل الصور من صيغة إلى أخرى. لمزيد من المعلومات، راجع الصفحات التالية: تحويل [صورة إلى JPG](https://products.aspose.com/slides/ar/java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/ar/java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/ar/java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/ar/java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/ar/java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/ar/java/conversion/svg-to-png/).

{{% /alert %}}

## **الأسئلة الشائعة**

### هل تدعم هذه الطريقة التحويل الجماعي؟

نعم، Aspose.Slides يسمح بالتحويل الجماعي لعدة شرائح إلى JPG في عملية واحدة.

### هل يدعم التحويل عناصر SmartArt، المخططات، والكائنات المعقدة الأخرى؟

نعم، Aspose.Slides يصور جميع المحتويات، بما في ذلك SmartArt، المخططات، الجداول، الأشكال، وغير ذلك. ومع ذلك، قد تختلف دقة التصيير قليلًا مقارنةً بـ PowerPoint، خصوصًا عند استخدام خطوط مخصصة أو مفقودة.

### هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟

Aspose.Slides نفسه لا يفرض حدودًا صارمة على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه أخطاء نفاد الذاكرة عند العمل على عروض تقديمية كبيرة أو صور بدقة عالية.