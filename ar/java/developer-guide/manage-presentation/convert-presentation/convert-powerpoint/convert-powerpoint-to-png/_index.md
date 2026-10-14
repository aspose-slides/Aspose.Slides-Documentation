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
description: "تحويل عروض PowerPoint إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides for Java، مع ضمان نتائج دقيقة ومؤتمتة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تحويل شرائح العرض إلى صور PNG باستخدام Aspose.Slides for Java. يمكنك تحميل العروض التقديمية بالصيغات مثل PPT و PPTX و ODP، وتصيير كل شريحة، وحفظها كصورة PNG منفصلة.

تظهر الأمثلة أدناه كيفية التصيير بالمقياس الافتراضي، وزيادة المقياس، وتحديد أبعاد الإخراج بالبكسل، واختيار نمط تصيير التدرج.

## **تحويل PowerPoint إلى PNG**

حمّل عرضًا تقديميًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) والوصول إلى شرائحه عبر مجموعة [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) . يُظهر المثال كل شريحة باستخدام [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) بدون معلمات لإنشاء صورة مصغرة. ثم يُستدعى [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) مع [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) لحفظ كل شريحة مُصَّورة كصورة PNG.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
طريقة التحميل بدون معلمات لـ[ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) تُصّر على مقياس 0.2. على سبيل المثال، شريحة قياسها 720 × 540 نقطة تُنتج صورة مصغرة بحجم 144 × 108 بكسل. للتحكم بأبعاد الإخراج، استخدم التحميلات بمعاملات المقياس أو بحجم صورة صريح كما هو موضح أدناه.
{{% /alert %}}

## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

مرّر عوامل المقياس الأفقية والعمودية إلى [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) للتحكم بأبعاد التصيير. في هذا المثال، كلا العاملين يساويان 2، لذا شريحة قياسها 720 × 540 نقطة تُنتج صورة بحجم 1440 × 1080 بكسل. عوامل المقياس المتساوية تحافظ على نسبة العرض إلى الارتفاع للشريحة. تُحفظ كل صورة بصيغة PNG باستخدام [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **تحويل PowerPoint إلى PNG بحجم مخصص**

لتحديد أبعاد الإخراج بالبكسل، مرّر حجمًا إلى [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) بدلاً من عوامل المقياس. يُظهر هذا المثال كل شريحة بحجم 960 × 720 بكسل ويحفظ النتيجة باستخدام [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-). اختر أبعادًا تتطابق مع نسبة عرض الشريحة لتجنب تمديد الصورة.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **اختيار نمط تصيير التدرج**

افترض أن شريحة تحتوي على تعبئة بالتدرج، لكن الانتقالات في صورة PNG المصدرة تبدو أخف أو مختلفة عما تراه في PowerPoint. يمكنك استخدام الطريقة [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) الموروثة من [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) لاختيار كيفية تصيير التدرجات.

حمّل الملف [gradient-styles.pptx](gradient-styles.pptx) وضعه في دليل العمل الخاص بالتطبيق. تحتوي شريحته الأولى على تدرجين خطيين: من السماوي إلى البرتقالي في الأعلى ومن الأزرق إلى الأصفر في الأسفل. كل تدرج يحتوي على نقطتي توقف عند 0% و100%.

المثال التالي يحمل هذا العرض ويصير الشريحة الأولى بنفس الطريقة في الوضعين باستخدام [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

تظهر الصور أدناه النتيجة من نفس الشريحة، مع وجود التدرجين في كل صورة:

| الافتراضي | PowerPointUI |
| --- | --- |
| ![التدرجات من السماوي إلى البرتقالي ومن الأزرق إلى الأصفر مُصَرة باستخدام الوضع الافتراضي](gradient-Default.png) | ![نفس التدرجات مُصَرة باستخدام PowerPointUI](gradient-PowerPointUI.png) |

في هذا المثال، ينتج `Default` ألوانًا وسيطة أكثر خفة، بينما ينتج `PowerPointUI` ألوانًا وسيطة أغمق. يعتمد الاختلاف على الألوان ونقاط التوقف في التدرج.

اختر `Default` عندما يناسبك الناتج القياسي من Aspose.Slides. جرّب `PowerPointUI` عندما تكون الأولوية هي مطابقة الشكل في PowerPoint. قارن كلا الناتجين مع النتيجة المطلوبة؛ لا أحد من الوضعين مفضل عالميًا.

## **الأسئلة المتكررة**

**كيف يمكنني تصدير شكل محدد، مثل مخطط أو صورة، بدلاً من الشريحة بأكملها؟**

يدعم Aspose.Slides [إنشاء صور مصغرة لأشكال فردية](/slides/ar/java/create-shape-thumbnails/)، مما يتيح لك تصيير شكل كصورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم. استخدم نسخة عرض تقديمية منفصلة لكل خيط أو عملية؛ [لا تشارك نسخة واحدة عبر الخيوط](/slides/ar/java/multithreading/).

**ما هي قيود التقييم عند التصدير إلى PNG؟**

يضيف وضع التقييم علامة مائية إلى الصور الناتجة ويطبّق [قيودًا أخرى](/slides/ar/java/licensing/) حتى يتم تطبيق ترخيص.