---
title: जावास्क्रिप्ट में प्रस्तुती स्लाइड्स को SVG छवियों के रूप में रेंडर करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint से SVG
- प्रस्तुति से SVG
- स्लाइड से SVG
- PPT से SVG
- PPTX से SVG
- SVG निर्यात विकल्प
- इंटरएक्टिव SVG
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावास्क्रिप्ट में PowerPoint स्लाइड्स को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट्स, टेक्स्ट, इमेजेज, IDs, और इवेंट्स को नियंत्रित करें।"
---
## **अवलोकन**

SVG एक स्केलेबल XML-आधारित इमेज फ़ॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर्स, अभिगम्यता कार्यप्रवाहों और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides for Node.js via Java प्रत्येक स्लाइड को अलग‑अलग SVG फ़ाइल में निर्यात करता है और आपको टेक्स्ट, फ़ॉन्ट, चित्र और SVG तत्वों के लेखन को नियंत्रित करने देता है।

Use [SVGOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/) when the exported SVG must be compact, predictable across browsers, or ready for interactive use.

## **एक स्लाइड को SVG के रूप में निर्यात करें**

Create a [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/), select a slide, and write it to a stream with [Slide.writeAsSvg](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/writeassvg/). The following example exports every slide in a presentation as a separate SVG file.

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

The filename uses [Slide.getSlideNumber](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/getslidenumber/) rather than the loop index. You can also export an individual shape with [Shape.writeAsSvg](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/writeassvg/) when a slide viewer or web page needs only that shape.

## **SVG आउटपुट को कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/) SVG रेंडरिंग को नियंत्रित करता है। टेक्स्ट फ़्रेम के लिए, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/setuseframesize/) रेंडरिंग क्षेत्र में टेक्स्ट फ़्रेम को शामिल करता है, और [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) निर्धारित करता है कि फ़्रेम रोटेशन लागू हो या नहीं। जब टेक्स्ट को बिना लिगेचर के रेंडर करना हो, तब [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) को `true` सेट करें।

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

## **टेक्स्ट और फ़ॉन्ट्स को नियंत्रित करें**

### **सभी टेक्स्ट को वेक्टराइज़ करें**

[SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) को `true` सेट करें ताकि सभी स्लाइड टेक्स्ट को वेक्टर ग्राफ़िक्स के रूप में लिखा जाए। इससे फ़ॉन्ट निर्भरताएँ समाप्त हो जाती हैं और दृश्य परिणाम ब्राउज़रों में अधिक सुसंगत बनता है, लेकिन टेक्स्ट अब SVG टेक्स्ट के रूप में चयन योग्य या खोज योग्य नहीं रहता।

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

### **बाहरी फ़ॉन्ट्स को कैसे संभालना है चुनें**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) बाहरी रूप से लोड किए गए फ़ॉन्ट्स के लिए एक [SvgExternalFontsHandling](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgexternalfontshandling/) मान का उपयोग करता है। `AddLinksToFontFiles` चुनें ताकि अलग फ़ॉन्ट फ़ाइलों को संदर्भित किया जा सके, `Embed` चुनें ताकि फ़ॉन्ट डेटा को SVG में शामिल किया जा सके, या `Vectorize` चुनें ताकि केवल बाहरी फ़ॉन्ट्स वाले टेक्स्ट को ग्राफ़िक्स के रूप में रेंडर किया जाए। फ़ॉन्ट एम्बेड करने से पहले फ़ॉन्ट लाइसेंसिंग की पुष्टि करें।

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

## **एंबेडेड इमेज का आकार घटाएँ**

Use [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) to reduce the resolution of embedded pictures, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) to omit cropped source areas, and [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/setjpegquality/) to control JPEG encoding quality. These settings reduce file size at the cost of image fidelity or retained image data.

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

## **Shapes और टेक्स्ट के लिए स्थिर IDs असाइन करें**

Pass a formatting controller to [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) to set [SvgShape.setId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgshape/setid/) for each SVG shape. A controller that also handles text spans can set [SvgTSpan.setId](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgtspan/setid/) values on text `tspan` elements.

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

## **SVG इवेंट हैंडलर्स जोड़ें**

In a formatting controller, call [SvgShape.setEventHandler](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgshape/seteventhandler/) with a [SvgEvent](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgevent/) value to add a JavaScript event handler to an exported shape. Assign the controller with [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) and define the JavaScript function in the page or SVG document that hosts the result.

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

The host page can define the JavaScript function referenced by the handler. Assigning IDs and event handlers enables slide viewers, accessibility enhancements, and other interactive SVG workflows.

## **FAQ**

**जब मैं [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) का उपयोग [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgexternalfontshandling/) की बजाय करना चाहिए?**

[SVGOptions.setVectorizeText] का उपयोग तब करें जब सभी टेक्स्ट को फ़ॉन्ट्स से स्वतंत्र होना चाहिए। [SvgExternalFontsHandling.Vectorize] का उपयोग तब करें जब केवल बाहरी फ़ॉन्ट्स वाले टेक्स्ट को ग्राफिक्स में परिवर्तित किया जाना चाहिए।

**SVG को छोटा करने का सबसे अच्छा तरीका क्या है?**

सबसे पहले एंबेडेड चित्रों को संकुचित करें, क्रॉप किए गए छवि क्षेत्रों को हटाएँ, और लक्षित वातावरण में उपलब्ध होने पर लिंक्ड फ़ॉन्ट फ़ाइलें चुनें। परिणाम का परीक्षण करें क्योंकि कम छवि रिज़ॉल्यूशन, कम JPEG गुणवत्ता, और वेक्टराइज़्ड टेक्स्ट प्रत्येक का गुणवत्ता और आकार में अलग ट्रेड‑ऑफ़ होता है।

**क्या मैं निर्यातित SVG तत्वों को निर्यात के बाद संशोधित कर सकता हूँ?**

हाँ। फ़ॉर्मेटिंग कंट्रोलर के माध्यम से IDs असाइन करें, फिर अपने पोस्ट‑प्रोसेसिंग टूल या ब्राउज़र स्क्रिप्ट में मिलते‑जुलते SVG तत्वों को चुनें।