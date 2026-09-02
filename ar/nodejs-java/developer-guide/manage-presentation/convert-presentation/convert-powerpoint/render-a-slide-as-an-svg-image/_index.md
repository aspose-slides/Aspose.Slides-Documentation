---
title: تحويل شرائح العرض التقديمي إلى صور SVG في جافا سكريبت
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- شريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- خيارات تصدير SVG
- SVG تفاعلي
- PowerPoint
- العرض التقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في JavaScript والتحكم بالخطوط والنصوص والصور والمعرّفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة قائم على XML قابل للتوسع يعمل بشكل جيد للنشر على الويب، وعارضات الشرائح، وتدفقات العمل المتعلقة بالإتاحة، ومعالجة ما بعد الإنتاج الآلية. Aspose.Slides for Node.js عبر Java تصدر كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في كيفية كتابة النصوص والخطوط والصور وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/) عندما يجب أن يكون ملف SVG المُصدر مضغوطًا، ومتوقعًا عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/)، حدّد شريحة، واكتبها إلى تدفق باستخدام [Slide.writeAsSvg](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/writeassvg/). المثال التالي يصدر كل شريحة في العرض التقديمي كملف SVG منفصل.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const outputFileName = `slide-${slide.getSlideNumber()}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            slide.writeAsSvg(svgStream);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

يستخدم اسم الملف [Slide.getSlideNumber](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/getslidenumber/) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [Shape.writeAsSvg](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/writeassvg/) عندما يحتاج عارض الشرائح أو صفحة الويب إلى هذا الشكل فقط.

## **تكوين إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/) يتحكم في عرض SVG. بالنسبة لإطارات النص، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/setuseframesize/) تُضمّن إطار النص في منطقة العرض، وتحدد [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) ما إذا كان سيتم تطبيق دوران الإطار. اضبط [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) على `true` عندما يجب عرض النص دون ربط الحروف.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setDisableFontLigatures(true);
    svgOptions.setUseFrameSize(true);
    svgOptions.setUseFrameRotation(false);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-custom-options.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **التحكم في النص والخطوط**

### **تحويل كل النص إلى شكل متجهي**

اضبط [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) على `true` لكتابة جميع نصوص الشريحة كرسومات متجهة. هذا يُزيل الاعتماد على الخطوط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، لكن النص لن يكون قابلًا للتحديد أو البحث كنص SVG.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setVectorizeText(true);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-text.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

### **اختر طريقة معالجة الخطوط الخارجية**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) يستخدم قيمة من نوع [SvgExternalFontsHandling](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgexternalfontshandling/) للخطوط التي يتم تحميلها خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات الخطوط المنفصلة، أو `Embed` لتضمين بيانات الخط داخل SVG، أو `Vectorize` لتحويل النص الذي يستخدم خطوطًا خارجية إلى رسومات. تحقق من تراخيص الخطوط قبل تضمينها.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const linkedFontsOptions = new slides.SVGOptions();
    linkedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.AddLinksToFontFiles
    );
    const linkedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-font-links.svg"
    );
    try {
        slide.writeAsSvg(linkedFontsStream, linkedFontsOptions);
    } finally {
        linkedFontsStream.close();
    }

    const embeddedFontsOptions = new slides.SVGOptions();
    embeddedFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Embed
    );
    const embeddedFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-embedded-fonts.svg"
    );
    try {
        slide.writeAsSvg(embeddedFontsStream, embeddedFontsOptions);
    } finally {
        embeddedFontsStream.close();
    }

    const vectorizedExternalFontsOptions = new slides.SVGOptions();
    vectorizedExternalFontsOptions.setExternalFontsHandling(
        slides.SvgExternalFontsHandling.Vectorize
    );
    const vectorizedExternalFontsStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-vectorized-external-fonts.svg"
    );
    try {
        slide.writeAsSvg(vectorizedExternalFontsStream, vectorizedExternalFontsOptions);
    } finally {
        vectorizedExternalFontsStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **تقليل حجم الصور المضمنة**

استخدم [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) لتقليل دقة الصور المضمنة، و[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) لحذف المناطق المقتصّة من المصدر، و[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/setjpegquality/) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب دقة الصورة أو البيانات المحتفظ بها.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi150);
    svgOptions.setDeletePicturesCroppedAreas(true);
    svgOptions.setJpegQuality(80);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "compressed-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **تعيين معرفات ثابتة للأشكال والنص**

مرّر متحكم تنسيق إلى [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) لتعيين [SvgShape.setId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgshape/setid/) لكل شكل SVG. يمكن للمتّحكم الذي يتعامل أيضًا مع مقاطع النص تعيين قيم [SvgTSpan.setId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgtspan/setid/) على عناصر النص `tspan`.

المتحكم التالي يستخدم [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/)، وهو ثابت طوال عمر الشكل، وعدًّا قابلاً للتكرار لمقاطع نصه. هذا يجعل المعرفات المُنشأة مناسبة لمعالجة ما بعد العرض التقديمي دون تغييره.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class StableSvgIdController {
    constructor() {
        this.currentShapeId = "";
        this.textSpanIndex = 0;
    }

    formatShape(svgShape, shape) {
        this.currentShapeId = `shape-${shape.getOfficeInteropShapeId()}`;
        this.textSpanIndex = 0;
        svgShape.setId(this.currentShapeId);
    }

    formatText(svgTSpan, portion, textFrame) {
        const textSpanId = `${this.currentShapeId}-text-${this.textSpanIndex++}`;
        svgTSpan.setId(textSpanId);
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeAndTextFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            },
            formatText(svgTSpan, portion, textFrame) {
                controller.formatText(svgTSpan, portion, textFrame);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const stableSvgIdController = new StableSvgIdController();
    const controllerProxy = stableSvgIdController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync(
        "java.io.FileOutputStream",
        "slide-with-stable-ids.svg"
    );
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **إضافة معالجات أحداث SVG**

في متحكم التنسيق، استدعِ [SvgShape.setEventHandler](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgshape/seteventhandler/) مع قيمة [SvgEvent](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgevent/) لإضافة معالج حدث JavaScript إلى شكل مُصدر. عيّن المتحكم باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) وحدد دالة JavaScript في الصفحة أو مستند SVG الذي يستضيف النتيجة.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

class SvgEventController {
    formatShape(svgShape, shape) {
        if (shape.getName() === "ActionButton") {
            svgShape.setId("action-button");
            svgShape.setEventHandler(
                slides.SvgEvent.OnClick,
                "handleShapeClick(event)"
            );
        }
    }

    createProxy() {
        const controller = this;
        const interfaceName = "com.aspose.slides.ISvgShapeFormattingController";
        const proxyMethods = {
            formatShape(svgShape, shape) {
                controller.formatShape(svgShape, shape);
            }
        };
        return java.newProxy(interfaceName, proxyMethods);
    }
}

const presentation = new slides.Presentation("presentation.pptx");
try {
    const svgOptions = new slides.SVGOptions();
    const svgEventController = new SvgEventController();
    const controllerProxy = svgEventController.createProxy();
    svgOptions.setShapeFormattingController(controllerProxy);

    const slide = presentation.getSlides().get_Item(0);
    const svgStream = java.newInstanceSync("java.io.FileOutputStream", "interactive-slide.svg");
    try {
        slide.writeAsSvg(svgStream, svgOptions);
    } finally {
        svgStream.close();
    }
} finally {
    presentation.dispose();
}
```

يمكن للصفحة المضيفة تعريف دالة JavaScript المشار إليها من قبل المعالج. تعيين المعرفات ومعالجات الأحداث يتيح لعارضات الشرائح، وتعزيزات الإتاحة، وغير ذلك من تدفقات العمل التفاعلية للـ SVG.

## **الأسئلة الشائعة**

**متى يجب أن أستخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) بدلاً من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

استخدم [SVGOptions.setVectorizeText] عندما يجب أن يكون جميع النص مستقلًا عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize] عندما ينبغي تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لتقليل حجم SVG؟**

ابدأ بضغط الصور المضمنة، وحذف المناطق المقتصّة من الصور، واختيار ملفات الخطوط المرتبطة عندما تكون البيئة المستهدفة قادرة على تقديمها. اختبر النتيجة لأن تقليل دقة الصورة، وتقليل جودة JPEG، وتحويل النص إلى متجه كل منها له مقايضات مختلفة بين الجودة والحجم.

**هل يمكنني تعديل عناصر SVG المصدرة بعد التصدير؟**

نعم. قم بتعيين المعرفات عبر متحكم تنسيق، ثم اختر عناصر SVG المطابقة في أداة ما بعد المعالجة أو سكريبت المتصفح الخاص بك.