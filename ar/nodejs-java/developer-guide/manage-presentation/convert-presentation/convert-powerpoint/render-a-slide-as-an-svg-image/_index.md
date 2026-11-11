---
title: عرض شرائح العرض التقديمي كصور SVG في JavaScript
linktitle: الشريحة إلى SVG
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
- SVG تفاعلية
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تصدير شرائح PowerPoint كصور SVG في JavaScript والتحكم في الخطوط والنصوص والصور والمعرفات والأحداث باستخدام Aspose.Slides."
---
## **نظرة عامة**

SVG هو تنسيق صورة XML قابل للتوسيع يعمل جيدًا لنشر الويب، عارضات الشرائح، عمليات الوصول، ومعالجة ما بعد الإنتاج الآلية. تقوم Aspose.Slides for Node.js عبر Java بتصدير كل شريحة إلى ملف SVG منفصل وتتيح لك التحكم في كيفية كتابة النص، الخطوط، الصور، وعناصر SVG.

استخدم [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) عندما يجب أن يكون SVG المُصدَّر مضغوطًا، قابلاً للتنبؤ عبر المتصفحات، أو جاهزًا للاستخدام التفاعلي.

## **تصدير شريحة كـ SVG**

أنشئ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)، اختر شريحة، واكتبها إلى تدفق باستخدام [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). المثال التالي يصدر كل شريحة في العرض التقديمي كملف SVG منفصل.

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

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) يتحكم في رسم SVG. لإطارات النص، [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) يتضمن إطار النص في مساحة الرسم، و[SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) يحدد ما إذا كان سيتم تطبيق تدوير الإطار. اضبط [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) إلى `true` عندما يجب عرض النص دون ربط الأحرف.

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

## **التحكم في قطع نهاية الخط عند رؤوس السهام**

SVG 1.1 ليس لديه إعداد لتحديد موضع توقف الخط تحت رأس السهم. بشكل افتراضي، تقوم Aspose.Slides بتقصير الخط المُصدَّر بحيث لا يبرز ضربته عبر العلامة. استدعِ [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping) مع `true` لرسم الضربة حتى النهاية الأصلية للخط. هذا الإعداد يؤثر فقط على إخراج SVG. يبقى الخط في موضعه وطوله على الشريحة.

الرسم التوضيحي يرسم رؤوس سهام مثلثية وملماسة على خطوط عرضها 2 و10 نقاط. يصدر الشريحة نفسها مرتين، مع تغيير خيار القطع فقط.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const lineColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    let y = 40;

    for (const style of [slides.LineArrowheadStyle.Triangle, slides.LineArrowheadStyle.Diamond]) {
        for (const width of [2, 10]) {
            const line = slide.getShapes().addAutoShape(slides.ShapeType.Line, 40, y, 200, 0);
            const format = line.getLineFormat();
            format.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
            format.getFillFormat().getSolidFillColor().setColor(lineColor);
            format.setWidth(width);
            format.setEndArrowheadStyle(java.newByte(style));
            y += 50;
        }
    }

    const options = new slides.SVGOptions();
    options.setDisableLineEndCropping(false);
    const cropped = java.newInstanceSync("java.io.FileOutputStream", "cropped.svg");
    try {
        slide.writeAsSvg(cropped, options);
    } finally {
        cropped.close();
    }

    options.setDisableLineEndCropping(true);
    const uncropped = java.newInstanceSync("java.io.FileOutputStream", "uncropped.svg");
    try {
        slide.writeAsSvg(uncropped, options);
    } finally {
        uncropped.close();
    }
} finally {
    presentation.dispose();
}
```

المقارنة تُظهر رأس السهم المثلثي على الخط بعرض 10 نقاط. عند تمكين القطع، تكون القمة حادة. عند تعطيل القطع، تبرز الضربة عبر الجوانب المائلة للعلامة وتصبح النهاية مسطحة.

![مثلث 10 نقاط مكبر مع طرف حاد عندما يكون القطع مفعَّلًا ونهاية مسطحة عندما يكون القطع معطَّلًا](line-end-cropping.png)

في الخطوط الأخرى من المثال، تكون الضربة البارزة أقل وضوحًا على المثلث بعرض نقطتين. الماسة المملوءة تغطي نهاية الضربة في كلا العرضين.

## **التحكم في النص والخطوط**

عند تصدير الشرائح إلى SVG، يمكنك التحكم فيما إذا كان النص يبقى نصًا أو يتحول إلى رسومات متجهة، وكيفية تضمين الخطوط الخارجية أو الإشارة إليها. تساعدك الخيارات التالية على موازنة التناسق البصري، إمكانية اختيار النص، واعتماد الخطوط في SVG المُصدَّر.

### **تحويل كل النص إلى رسومات**

اضبط [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) إلى `true` لكتابة كل نص الشريحة كرسومات متجهة. هذا يلغي اعتماد الخطوط ويجعل النتيجة البصرية أكثر اتساقًا عبر المتصفحات، لكن النص لن يكون قابلاً للتحديد أو البحث كالنص داخل SVG.

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

### **اختر كيفية معالجة الخطوط الخارجية**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) يستخدم قيمة [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) للخطوط التي يتم تحميلها خارجيًا. اختر `AddLinksToFontFiles` للإشارة إلى ملفات خطوط منفصلة، `Embed` لتضمين بيانات الخط داخل SVG، أو `Vectorize` لرسم النص الذي يستخدم خطوطًا خارجية كرسومات. تحقق من ترخيص الخط قبل تضمين الخطوط.

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

## **تقليل حجم الصورة المضمنة**

استخدم [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) لتقليل دقة الصور المضمنة، و[SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) لحذف المناطق المقتطفة من المصدر، و[SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) للتحكم في جودة ترميز JPEG. تقلل هذه الإعدادات حجم الملف على حساب دقة الصورة أو البيانات المضمنة.

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

## **التحكم في دقة تمثيل الميتافايل**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) يحدد الحد الأدنى لدقة تمثيل الميتافايل أثناء تصدير SVG. استخدمه لموازنة التفاصيل وحجم الملف عندما يتم تمثيل صورة EMF أو WMF. لا يحدد DPI عالميًا للـ SVG ولا يجبر كل كائن على الشريحة على التحول إلى صورة نقطية.

نزّل [metafile-rasterization.pptx](metafile-rasterization.pptx)، والذي يحتوي على صورة EMF بخطوط قطرية متقاربة. المثال التالي يصدر شريحة أولى له بثلاث دقات تمثيل عبر [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). جميع إعدادات التصدير الأخرى تبقى متطابقة حتى يمكن مقارنة النتائج.

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

في النتيجة، تحولت EMF إلى PNG مضمّن في كل SVG. القياسات التالية تخص العرض المقدم؛ ليست صيغة عامة لتحويل DPI إلى أبعاد بكسل.

| دقة تمثيل الميتافايل DPI | أبعاد PNG المضمن | حجم ملف SVG (بايت) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

تُظهر المقارنة أدناه نفس المنطقة من النقطية المضمنة عند نفس حجم العرض المكبر. الخطوط القطرية تُظهر بكسلة ملحوظة عند 72 DPI وحوافًا أكثر سلاسة عند الدقات الأعلى، بينما يزداد حجم ملف SVG. زيادة القيمة لا تحسن بالضرورة كل التفاصيل أو تغير كل صورة مُصدَّرة.

![تفاصيل خط قطري مكبر عند 72، 150، و300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) يتحكم في تقليل دقة الصورة ويمكن أن يخفي تأثير تغيير دقة تمثيل الميتافايل. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) يتحكم في جودة ترميز JPEG، وليس في دقة تمثيل الميتافايل.

## **تعيين معرفات ثابتة للأشكال والنص**

مرّر وحدة تحكم التنسيق إلى [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) لضبط [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) لكل شكل SVG. يمكن لوحدة تحكم تعالج أيضًا نطاقات النص ضبط قيم [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) على عناصر `tspan` النصية.

المتحكم التالي يستخدم [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/)، وهو ثابت طوال عمر الشكل، وعدادًا قابلاً لإعادة الاستخدام لنطاقات النص. يجعل ذلك المعرفات المُولدة مناسبة لمعالجة عرض تقديمي غير معدل.

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

في وحدة تحكم التنسيق، استدعِ [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) مع قيمة [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) لإضافة معالج JavaScript إلى شكل مُصدَّر. عيّن المتحكم عبر [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) وعَرّف دالة JavaScript في الصفحة أو مستند SVG الذي يستضيف النتيجة.

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

يمكن للصفحة المستضيفة تعريف دالة JavaScript التي يشير إليها المعالج. تعيين المعرفات ومعالجات الأحداث يتيح عارضات الشرائح، تحسينات الوصول، وغيرها من سير عمل SVG التفاعلية.

## **الأسئلة الشائعة**

**متى ينبغي أن أستخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) بدلاً من [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

استخدم [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) عندما يجب أن يكون كل النص مستقلاً عن الخطوط. استخدم [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) عندما ينبغي تحويل النص الذي يستخدم خطوطًا خارجية فقط إلى رسومات.

**ما هي أفضل طريقة لجعل SVG أصغر؟**

ابدأ بضغط الصور المضمنة، حذف المناطق المقتطفة من الصورة، واختيار ملفات خطوط مرتبطة عندما تكون البيئة المستهدفة قادرة على تقديمها. اختبر النتيجة لأن تقليل دقة الصورة، خفض جودة JPEG، وتحويل النص إلى رسومات كل منها يضيف مقايضات بين الجودة والحجم.

**هل يمكنني تعديل عناصر SVG المُصدَّرة بعد التصدير؟**

نعم. عيّن المعرفات عبر وحدة تحكم التنسيق، ثم اختر العناصر المطابقة في أداة ما بعد المعالجة أو نص برمجي للمتصفح.