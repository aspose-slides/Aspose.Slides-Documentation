---
title: تحويل شرائح PowerPoint إلى PNG على Android
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/androidjava/convert-powerpoint-to-png/
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
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides لنظام Android عبر Java، مع ضمان نتائج دقيقة ومؤتمتة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية تحويل شرائح العرض إلى صور PNG باستخدام Aspose.Slides لنظام Android عبر Java. يمكنك تحميل العروض التقديمية بتنسيقات مثل PPT و PPTX و ODP، عرض كل شريحة، وحفظها كصورة PNG منفصلة.

تظهر الأمثلة أدناه كيفية العرض بالمقياس الافتراضي، وزيادة المقياس، وتحديد أبعاد الإخراج بالبكسل، واختيار نمط عرض التدرج.

## **تحويل PowerPoint إلى PNG**

حمّل عرضًا تقديميًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)، وابدأ الوصول إلى شرائحه عبر مجموعة [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) . تقوم الأمثلة بعرض كل شريحة باستخدام [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) دون معلمات لإنشاء صورة مصغرة. ثم يتم استدعاء [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) مع [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) لحفظ كل شريحة معروضة كصورة PNG.

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
الإصدار بدون معلمات من [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) يُظهر بالمقياس 0.2. على سبيل المثال، شريحة قياسها 720 × 540 نقطة ينتج صورة مصغرة بحجم 144 × 108 بكسل. للتحكم في أبعاد الإخراج، استخدم الإصدارات ذات عوامل المقياس أو حجم الصورة الصريح الموضح أدناه.
{{% /alert %}}

## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

مرّر عوامل المقياس الأفقية والعمودية إلى [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) للتحكم في أبعاد العرض. في هذا المثال، كلا العاملين يساويان 2، لذا شريحة قياسها 720 × 540 نقطة ينتج صورة بحجم 1440 × 1080 بكسل. عوامل المقياس المتساوية تحافظ على نسبة أبعاد الشريحة. تُحفظ كل صورة بتنسيق PNG باستخدام [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-).

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

## **تحويل PowerPoint إلى PNG بالحجم المخصص**

لتحديد أبعاد الإخراج بالبكسل، مرّر حجمًا إلى [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) بدلاً من عوامل المقياس. يقوم هذا المثال بعرض كل شريحة بحجم 960 × 720 بكسل ويحفظ النتيجة باستخدام [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). اختر أبعادًا تتطابق مع نسبة أبعاد الشريحة لتفادي تمدد الصورة.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

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

## **اختيار نمط عرض التدرج**

افترض أن الشريحة تحتوي على تدرجات ملونة، لكن الانتقالات في ملف PNG المُصدّر تبدو أخف أو مختلفة عما تراه في PowerPoint. يمكنك استخدام طريقة [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) الموروثة من [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) لاختيار كيفية عرض التدرجات.

قم بتنزيل [gradient-styles.pptx](gradient-styles.pptx) وضعه في دليل عمل التطبيق. الشريحة الأولى فيه تحتوي على تدرجين خطيين: من السيان إلى البرتقالي في الأعلى ومن الأزرق إلى الأصفر في الأسفل. كل تدرج لديه نقطتا توقف عند 0% و 100%.

المثال التالي يحمل هذا العرض ويعرض الشريحة الأولى نفسها في كلا الوضعين باستخدام [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-).

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

تظهر الصور أدناه ناتج الشريحة نفسها، مع كِلَّى التدرجين في كل صورة:

| افتراضي | PowerPointUI |
| --- | --- |
| ![التدرجات من سيان إلى برتقالي وأزرق إلى أصفر معروضة باستخدام الافتراضي](gradient-Default.png) | ![نفس التدرجات معروضة باستخدام PowerPointUI](gradient-PowerPointUI.png) |

في هذا المثال، ينتج `Default` ألوانًا وسيطة أفتح، بينما ينتج `PowerPointUI` ألوانًا وسيطة أغمق. يعتمد الاختلاف على الألوان ونقاط التوقف في التدرج.

اختر `Default` عندما يكون إخراج Aspose.Slides القياسي مناسبًا لاحتياجاتك. جرّب `PowerPointUI` عندما تكون أولويتك مطابقة المظهر في PowerPoint. قارن كلا الإخراجين بالنتيجة المطلوبة؛ لا يُفضل أي وضع بشكل عام.

## **الأسئلة المتكررة**

**كيف يمكنني تصدير شكل معين، مثل مخطط أو صورة، بدلاً من الشريحة كاملة؟**

يدعم Aspose.Slides [إنشاء صور مصغرة لأشكال فردية](/slides/ar/androidjava/create-shape-thumbnails/)، مما يتيح لك عرض شكل كصورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم. استخدم نسخة عرض تقديمي منفصلة لكل خيط أو عملية؛ [لا تشارك نسخة واحدة عبر الخيوط](/slides/ar/androidjava/multithreading/).

**ما هي قيود التقييم عند التصدير إلى PNG؟**

يضيف وضع التقييم علامة مائية إلى الصور الناتجة ويطبق [قيودًا أخرى](/slides/ar/androidjava/licensing/) حتى يتم تطبيق الترخيص.