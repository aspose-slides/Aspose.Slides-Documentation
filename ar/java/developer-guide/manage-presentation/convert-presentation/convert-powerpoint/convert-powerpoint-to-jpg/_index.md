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
description: "تحويل شرائح PowerPoint (PPT، PPTX) إلى صور JPG عالية الجودة في Java باستخدام Aspose.Slides for Java مع أمثلة شفرة سريعة وموثوقة."
---
## **المقدمة**

يُسهم تحويل عروض PowerPoint وOpenDocument إلى صور JPG في مشاركة الشرائح، تحسين الأداء، وتضمين المحتوى في المواقع الإلكترونية أو التطبيقات. يتيح Aspose.Slides تحويل ملفات PPTX وPPT وODP إلى صور JPEG عالية الجودة. يشرح هذا الدليل طرق التحويل المختلفة.

مع هذه الميزات، يصبح من السهل تنفيذ عارض العروض الخاص بك وإنشاء صورة مصغرة لكل شريحة. قد يكون ذلك مفيدًا إذا كنت ترغب في حماية الشرائح من النسخ أو عرض العرض في وضع القراءة فقط. يتيح Aspose.Slides تحويل العرض الكامل أو شريحة محددة إلى صيغ صور.

## **تحويل PowerPoint PPT/PPTX إلى JPG**

فيما يلي خطوات تحويل PPT/PPTX إلى JPG:

1. إنشاء كائن من النوع [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
2. الحصول على كائن الشريحة من النوع [ISlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlide) من مجموعة [Presentation.getSlides()](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getSlides--).
3. إنشاء الصورة المصغرة لكل شريحة ثم تحويلها إلى JPG. تُستخدم طريقة [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlide#getImage-float-float-) للحصول على صورة مصغرة للشريحة، وتُعيد كائن [Images](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Images) كنتيجة. يجب استدعاء طريقة [getImage](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) من الشريحة المطلوبة من النوع [ISlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlide)، وتُمرّر مقاييس الصورة المصغرة الناتجة إلى الطريقة.
4. بعد الحصول على صورة الشريحة المصغرة، استدعِ طريقة [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) من كائن الصورة المصغرة. مرّر اسم الملف الناتج وصيغة الصورة إليها.

{{% alert color="info" %}}
**ملاحظة**: يختلف تحويل PPT/PPTX إلى JPG عن التحويل إلى أنواع أخرى في واجهة Aspose.Slides API. بالنسبة للأنواع الأخرى، عادةً ما تستخدم طريقة [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)، ولكن هنا تحتاج إلى طريقة [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)).
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // ينشئ صورة بالحجم الكامل
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

لتغيير أبعاد الصورة المصغرة الناتجة وصورة JPG، يمكنك ضبط قيم *ScaleX* و*ScaleY* بتمريرهما إلى طرق [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlide#getImage-float-float-).

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // يحدد الأبعاد
    int desiredX = 1200;
    int desiredY = 800;
    // يحصل على القيم المُقاسة لـ X و Y
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // ينشئ صورة بالحجم الكامل
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

## **إظهار التعليقات عند حفظ الشرائح كصور**

يوفر Aspose.Slides for Java إمكانية تسمح لك بعرض التعليقات في شرائح العرض عند تحويل هذه الشرائح إلى صور. يوضح هذا الكود Java العملية:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);
    notesOptions.setCommentsPosition(CommentsPositions.Right);
    notesOptions.setCommentsAreaWidth(200);

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

{{% alert title="Tip" color="info" %}}
توفر Aspose تطبيق ويب [تطبيق الويب المجاني Collage](https://products.aspose.app/slides/ar/collage) مجانًا. باستخدام هذه الخدمة عبر الإنترنت، يمكنك دمج صور [JPG إلى JPG](https://products.aspose.app/slides/ar/collage/jpg) أو PNG إلى PNG، وإنشاء [شبكات الصور](https://products.aspose.app/slides/ar/collage/photo-grid)، وما إلى ذلك.

باستخدام نفس المبادئ الواردة في هذه المقالة، يمكنك تحويل الصور من تنسيق إلى آخر. لمزيد من المعلومات، راجع هذه الصفحات: تحويل [صورة إلى JPG](https://products.aspose.com/slides/ar/java/conversion/image-to-jpg/); تحويل [JPG إلى صورة](https://products.aspose.com/slides/ar/java/conversion/jpg-to-image/); تحويل [JPG إلى PNG](https://products.aspose.com/slides/ar/java/conversion/jpg-to-png/)، تحويل [PNG إلى JPG](https://products.aspose.com/slides/ar/java/conversion/png-to-jpg/); تحويل [PNG إلى SVG](https://products.aspose.com/slides/ar/java/conversion/png-to-svg/)، تحويل [SVG إلى PNG](https://products.aspose.com/slides/ar/java/conversion/svg-to-png/).
{{% /alert %}}

## **الأسئلة المتكررة**

### هل تدعم هذه الطريقة التحويل على دفعات؟

نعم، يتيح Aspose.Slides التحويل على دفعات لعدة شرائح إلى JPG في عملية واحدة.

### هل يدعم التحويل SmartArt والرسوم البيانية وغيرها من الكائنات المعقدة؟

نعم، يقوم Aspose.Slides بعرض جميع المحتويات، بما في ذلك SmartArt والرسوم البيانية والجداول والأشكال والمزيد. ومع ذلك، قد يختلف دقة العرض قليلاً مقارنةً بـ PowerPoint، خاصةً عند استخدام خطوط مخصصة أو مفقودة.

### هل هناك أي قيود على عدد الشرائح التي يمكن معالجتها؟

لا يفرض Aspose.Slides نفسه أي حدود صارمة على عدد الشرائح التي يمكنك معالجتها. ومع ذلك، قد تواجه خطأ نفاد الذاكرة عند العمل على عروض تقديمية كبيرة أو صور ذات دقة عالية.

## **انظر أيضًا**

انظر خيارات أخرى لتحويل PPT/PPTX إلى صورة مثل:

- [تحويل PPT/PPTX إلى SVG](/slides/ar/java/render-a-slide-as-an-svg-image/).