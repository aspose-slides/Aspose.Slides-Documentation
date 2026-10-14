---
title: تحويل شرائح PowerPoint إلى PNG في JavaScript
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/nodejs-java/convert-powerpoint-to-png/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PNG
- عرض تقديمي إلى PNG
- شريحة إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- حفظ PPT كـ PNG
- حفظ PPTX كـ PNG
- تصدير PPT إلى PNG
- تصدير PPTX إلى PNG
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى صور PNG عالية الجودة في JavaScript بسرعة باستخدام Aspose.Slides لـ Node.js، مع ضمان نتائج دقيقة ومؤتمتة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل شرائح العرض إلى صور PNG باستخدام Aspose.Slides لـ Node.js عبر Java. يمكنك تحميل العروض التقديمية بتنسيقات مثل PPT و PPTX و ODP، عرض كل شريحة، وحفظها كصورة PNG منفصلة.

توضح الأمثلة أدناه طريقة العرض بالمقياس الافتراضي، زيادة المقياس، تحديد أبعاد الإخراج بالبكسل، واختيار نمط عرض التدرج.

## **تحويل PowerPoint إلى PNG**

حمّل عرضًا تقديميًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) وابدأ شرائحه عبر مجموعة [Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides). تعرض المثال كل شريحة باستخدام [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) دون معاملات لإنشاء صورة مصغرة. ثم يستدعي [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) مع [ImageFormat.Png](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imageformat/#Png) لحفظ كل شريحة معروضة كصورة PNG.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="ملاحظة" %}}
الإصدار بدون معاملات من [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) يعرض بمقياس 0.2. على سبيل المثال، شريحة مقاس 720 × 540 نقطة تُنتج صورة مصغرة بحجم 144 × 108 بكسل. للتحكم بأبعاد الإخراج، استخدم الإصدارات التي تقبل عوامل المقياس أو حجم الصورة الصريح الموضح أدناه.
{{% /alert %}}

## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

مرّر عوامل مقياس أفقية ورأسية إلى [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) للتحكم بأبعاد العرض. في هذا المثال، كلا العاملين قيمتهما 2، وبالتالي شريحة مقاس 720 × 540 نقطة تُنتج صورة بحجم 1440 × 1080 بكسل. عوامل المقياس المتساوية تحافظ على نسبة أبعاد الشريحة. تُحفظ كل صورة بصيغة PNG باستخدام [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let scaleX = 2.0;
    let scaleY = scaleX;

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **تحويل PowerPoint إلى PNG بحجم مخصص**

لتحديد أبعاد الإخراج بالبكسل، مرّر حجمًا إلى [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage) بدلاً من عوامل المقياس. يعرض هذا المثال كل شريحة بحجم 960 × 720 بكسل ويحفظ النتيجة باستخدام [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save). اختر أبعادًا تتطابق مع نسبة أبعاد الشريحة لتجنب تشويه الصورة.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let imageSize = java.newInstanceSync("java.awt.Dimension", 960, 720);

    let slideCount = presentation.getSlides().size();
    for (let index = 0; index < slideCount; index++) {
        let slide = presentation.getSlides().get_Item(index);
        let image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **اختر نمط عرض التدرج**

افترض أن شريحة تحتوي على تعبئات متدرجة، ولكن الانتقالات في صورة PNG المصدرة تبدو أخف أو مختلفة عما تراه في PowerPoint. يمكنك استخدام طريقة [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setGradientStyle) الموروثة من [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) لاختيار كيفية عرض التدرجات.

نزّل ملف [gradient-styles.pptx](gradient-styles.pptx) وضعه في دليل عمل التطبيق. الشريحة الأولى تحتوي على تدرجين خطيين: من السماوي إلى البرتقالي في الأعلى ومن الأزرق إلى الأصفر في الأسفل. كل تدرج يحتوي على نقطتي توقف، عند 0% و 100%.

المثال التالي يحمل هذا العرض ويعرض الشريحة الأولى نفسها في الوضعين باستخدام [Slide.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getImage).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("gradient-styles.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let gradientStyles = [aspose.slides.GradientStyle.Default, aspose.slides.GradientStyle.PowerPointUI];
    for (let style of gradientStyles) {
        let options = new aspose.slides.RenderingOptions();
        options.setGradientStyle(style);

        let styleName = style == aspose.slides.GradientStyle.Default ? "Default" : "PowerPointUI";
        let image = slide.getImage(options, 1.0, 1.0);
        try {
            image.save("gradient-" + styleName + ".png", aspose.slides.ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

| Default | PowerPointUI |
| --- | --- |
| ![تدرجات من السماوي إلى البرتقالي ومن الأزرق إلى الأصفر تم عرضها باستخدام Default](gradient-Default.png) | ![نفس التدرجات تم عرضها باستخدام PowerPointUI](gradient-PowerPointUI.png) |

في هذا المثال، `Default` ينتج ألوانًا وسيطة أفتح، بينما `PowerPointUI` ينتج ألوانًا وسيطة أغمق. الاختلاف يعتمد على الألوان والنقاط في التدرج.

اختر `Default` عندما يكون إخراج Aspose.Slides القياسي مناسبًا لاحتياجاتك. جرّب `PowerPointUI` عندما تكون الأولوية لمطابقة المظهر في PowerPoint. قارن كلا الإخراجين بالنتيجة المرجوة؛ لا وضعية تُفضل عالميًا على الأخرى.

## **الأسئلة الشائعة**

**كيف يمكنني تصدير شكل محدد، مثل مخطط أو صورة، بدلاً من الشريحة بأكملها؟**

يدعم Aspose.Slides [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/nodejs-java/create-shape-thumbnails/)، مما يتيح لك عرض شكل كصورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم. استخدم نسخة عرض تقديمي منفصلة لكل خيط أو عملية؛ [لا تشارك نسخة واحدة عبر الخيوط](/slides/ar/nodejs-java/multithreading/).

**ما هي قيود التقييم عند التصدير إلى PNG؟**

وضع التقييم يضيف علامة مائية إلى الصور المخرجة ويطبق [قيودًا أخرى](/slides/ar/nodejs-java/licensing/) حتى يتم تطبيق ترخيص.