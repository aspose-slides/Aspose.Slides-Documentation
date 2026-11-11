---
title: عرض شرائح العرض التقديمي كصور SVG في جافا سكريبت
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- الشريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- خيارات تصدير SVG
- SVG تفاعلي
- PowerPoint
- عرض تقديمي
- Node.js
- جافا سكريبت
- Aspose.Slides
description: تصدير شرائح PowerPoint كصور SVG في جافا سكريبت والتحكم في الخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides.
---
## **نظرة عامة**

SVG هو تنسيق صورة قائم على XML وقابل للتوسع يعمل بشكل جيد للنشر على الويب، وعارضات الشرائح، وسير عمل الوصولية، والمعالجة اللاحقة الآلية. تقوم Aspose.Slides for Node.js عبر Java بتصدير كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في طريقة كتابة النصوص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) عندما يجب أن يكون SVG المُصدَّر مضغوطًا، ويمكن التنبؤ به عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

إنشاء [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)، اختيار شريحة، وكتابتها إلى تدفق باستخدام [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). المثال التالي يصدر كل شريحة في عرض تقديمي كملف SVG منفصل.

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

يستخدم اسم الملف [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) بدلاً من فهرس الحلقة. يمكنك أيضًا تصدير شكل فردي باستخدام [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) عندما يحتاج عارض الشرائح أو صفحة الويب إلى ذلك الشكل فقط.

## **تكوين إخراج SVG**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) يتحكم في رسم SVG. بالنسبة لإطارات النص، يضمن [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) إطار النص في مساحة الرسم، و[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) يحدد ما إذا كان سيتم تطبيق دوران الإطار. اضبط [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) على `true` عندما يجب رسم النص بدون الحروف المتصلة.

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

## **التحكم في النصوص والخطوط**

عند تصدير الشرائح إلى SVG، يمكنك التحكم فيما إذا كان النص يبقى نصًا أو يتحول إلى رسومات متجهة، وكيفية تضمين الخطوط الخارجية أو الإشارة إليها. تساعد الخيارات التالية في موازنة الاتساق البصري، قابلية اختيار النص، واعتماد الخطوط في SVG المُصدَّر.

### **تحويل كل النص إلى متجهات**

اضبط [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) على `true` لكتابة كل نص الشريحة كرسومات متجهة. هذا يُزيل الاعتماد على الخطوط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، لكن النص لن يكون قابلًا للتحديد أو البحث كالنص داخل SVG.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) للخطوط التي تُحمَّل خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، `Embed` لتضمين بيانات الخط داخل SVG، أو `Vectorize` لرسم النص الذي يستخدم خطوطًا خارجية كرسومات فقط. تحقق من تراخيص الخط قبل تضمين الخطوط.

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

## **تقليل حجم الصور المدمجة**

استخدم [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) لتقليل دقة الصور المدمجة، [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) لحذف مناطق الصورة المقصومة، و[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) للتحكم في جودة ترميز JPEG. هذه الإعدادات تقلل حجم الملف على حساب دقة الصورة أو بيانات الصورة المحتفظ بها.

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

## **التحكم في دقة تحويل ملفات الميتا إلى نقطية**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) يحدد الحد الأدنى للدقة عند تحويل ملفات الميتا إلى نقطية أثناء تصدير SVG. استخدمه لموازنة التفاصيل وحجم الملف عندما يتم تحويل صورة EMF أو WMF إلى نقطية. لا يحدد DPI عالميًا للـ SVG ولا يجبر كل كائن في الشريحة على التحول إلى صورة نقطية.

حمّل [metafile-rasterization.pptx](metafile-rasterization.pptx)، الذي يحتوي على صورة EMF بخطوط مائلة متقاربة. المثال التالي يصدر الشريحة الأولى منه بثلاث دقات تحويل من خلال [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). جميع إعدادات التصدير الأخرى تبقى متطابقة بحيث يمكن مقارنة النتائج.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("metafile-rasterization.pptx");
try {
    for (const dpi of [72, 150, 300]) {
        const svgOptions = new slides.SVGOptions();
        svgOptions.setMetafileRasterizationDpi(dpi);
        svgOptions.setPicturesCompression(slides.PicturesCompression.Dpi330);
        svgOptions.setJpegQuality(90);

        const outputFileName = `slide-${dpi}.svg`;
        const svgStream = java.newInstanceSync("java.io.FileOutputStream", outputFileName);
        try {
            presentation.getSlides().get_Item(0).writeAsSvg(svgStream, svgOptions);
        } finally {
            svgStream.close();
        }
    }
} finally {
    presentation.dispose();
}
```

في الناتج، تحولت صورة EMF إلى ملف PNG مدمج واحد داخل كل SVG. القياسات التالية تخص العرض المرفق؛ هي ليست صيغة عامة لتحويل DPI إلى أبعاد بكسل.

| DPI لتقليب ملف الميتا إلى نقطية | أبعاد PNG المدمج | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

المقارنة أدناه تظهر نفس منطقة الصورة النقطية المدمجة بنفس حجم العرض المكبر. الخطوط المائلة تظهر بكسلة واضحة عند 72 DPI وحواف أكثر سلاسة عند دقات أعلى، بينما حجم ملف SVG يزداد. زيادة القيمة لا تحسن بالضرورة كل التفاصيل ولا تغير كل صورة مُصدَّرة.

![تفصيل خط مائل مكبر عند 72, 150, و300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) يتحكم في تقليل دقة الصورة ويمكنه إخفاء تأثير تغيير دقة تحويل ملفات الميتا إلى نقطية. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) يتحكم في جودة ترميز JPEG، وليس في دقة تحويل ملفات الميتا إلى نقطية.

## **تعيين معرّفات ثابتة للأشكال والنص**

مرّر وحدة تحكم تنسيق إلى [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) لتحديد [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) لكل شكل SVG. وحدة تحكم تعالج أيضًا نطاقات النص يمكنها تعيين قيم [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) على عناصر `tspan` النصية.

الوحدة التالية تستخدم [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/)، وهو ثابت طوال عمر الشكل، ومؤقتًا قابلًا للتكرار لنطاقات النص الخاصة به. هذا يجعل المعرفات المولدة صالحة للمعالجة اللاحقة لعرض تقديمي غير معدل.

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

في وحدة تحكم تنسيق، استدعِ [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) مع قيمة [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) لإضافة معالج حدث JavaScript إلى شكل مُصدَّر. عيّن وحدة التحكم باستخدام [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) وعرّف الدالة JavaScript في الصفحة أو مستند SVG الذي يستضيف النتيجة.

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

يمكن للصفحة المستضيفة تعريف الدالة JavaScript التي يشير إليها المعالج. تعيين المعرفات ومعالجات الأحداث يُمكّن عارضات الشرائح، تحسينات الوصولية، وسير عمل SVG التفاعلية الأخرى.

## **الأسئلة المتكررة**

**متى يجب أن أستخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) بدلاً من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

استخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) عندما يجب أن يكون كل النص مستقلاً عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) عندما يُراد تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لجعل SVG أصغر؟**

ابدأ بضغط الصور المدمجة، حذف مناطق الصور المقصومة، واختيار ملفات خطوط مرتبطة عندما يمكن للبيئة المستهدفة تقديمها. اختبر النتيجة لأن تقليل دقة الصورة، خفض جودة JPEG، وتحويل النص إلى متجهات كلٌّ له تأثيرات مختلفة على الجودة والحجم.

**هل يمكنني تعديل عناصر SVG المصدَّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر وحدة تحكم تنسيق، ثم حدد العناصر SVG المطابقة في أداة المعالجة اللاحقة أو سكريبت المتصفح الخاص بك.