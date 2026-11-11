---
title: JavaScript में प्रस्तुति स्लाइड को SVG छवियों के रूप में रेंडर करें
linktitle: स्लाइड से SVG
type: docs
weight: 50
url: /hi/nodejs-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint से SVG
- प्रेजेंटेशन को SVG
- स्लाइड को SVG
- PPT से SVG
- PPTX से SVG
- SVG निर्यात विकल्प
- इंटरैक्टिव SVG
- PowerPoint
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript में PowerPoint स्लाइड को SVG छवियों के रूप में निर्यात करें और Aspose.Slides के साथ फ़ॉन्ट, टेक्स्ट, इमेज, आईडी और इवेंट को नियंत्रित करें।"
---
## **परिचय**

SVG एक स्केलेबल XML-आधारित इमेज फ़ॉर्मेट है जो वेब प्रकाशन, स्लाइड व्यूअर्स, सुलभता वर्कफ़्लो और स्वचालित पोस्ट‑प्रोसेसिंग के लिए उपयुक्त है। Aspose.Slides for Node.js via Java प्रत्येक स्लाइड को एक अलग SVG फ़ाइल में निर्यात करता है और आपको नियंत्रित करने की अनुमति देता है कि टेक्स्ट, फ़ॉन्ट, चित्र और SVG तत्व कैसे लिखे जाएँ।

Use [SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) when the exported SVG must be compact, predictable across browsers, or ready for interactive use.

## **स्लाइड को SVG के रूप में निर्यात करें**

Create a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), select a slide, and write it to a stream with [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). The following example exports every slide in a presentation as a separate SVG file.

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

The filename uses [Slide.getSlideNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/getslidenumber/) rather than the loop index. You can also export an individual shape with [Shape.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) when a slide viewer or web page needs only that shape.

## **SVG आउटपुट कॉन्फ़िगर करें**

[SVGOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) controls SVG rendering. For text frames, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframesize/) includes the text frame in the rendering area, and [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setuseframerotation/) determines whether the frame rotation is applied. Set [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableFontLigatures) to `true` when text must be rendered without ligatures.

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

## **तीर-छोर पर लाइन-एंड क्रॉपिंग को नियंत्रित करें**

SVG 1.1 में मार्कर इनसेट सेटिंग नहीं है जिससे लाइन को तीर-छोर के नीचे कहाँ रुकना चाहिए यह निर्दिष्ट किया जा सके। डिफ़ॉल्ट रूप से, Aspose.Slides निर्यातित लाइन को छोटा कर देता है ताकि उसका स्ट्रोक मार्कर के भीतर न protrude करे। [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/#setDisableLineEndCropping) को `true` के साथ कॉल करें ताकि स्ट्रोक मूल एन्डपॉइंट तक पूरी तरह खींचा जाए। यह सेटिंग केवल SVG आउटपुट को प्रभावित करती है। स्लाइड पर लाइन की स्थिति और लंबाई अपरिवर्तित रहती है।

The example draws triangle and diamond arrowheads on lines 2 and 10 points wide. It exports the same slide twice, changing only the cropping option.

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

The comparison shows the triangular arrowhead on the 10-point line. With cropping enabled, the tip is sharp. With cropping disabled, the stroke protrudes through the sloping sides of the marker and leaves a flat end.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

In the other lines from the example, the protruding stroke is less visible on the 2-point triangle. The filled diamond covers the end of the stroke at both widths.

## **पाठ और फ़ॉन्ट को नियंत्रित करें**

When exporting slides to SVG, you can control whether text remains as text or is converted to vector graphics, and how external fonts are included or referenced. The following options help you balance visual consistency, text selection, and font dependencies in the exported SVG.

### **सभी पाठ को वेक्टराइज़ करें**

Set [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) to `true` to write all slide text as vector graphics. This eliminates font dependencies and makes the visual result more consistent across browsers, but the text is no longer selectable or searchable as SVG text.

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

### **बाहरी फ़ॉन्ट को कैसे संभालें चुनें**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setexternalfontshandling/) uses a [SvgExternalFontsHandling](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) value for fonts that are loaded externally. Choose `AddLinksToFontFiles` to reference separate font files, `Embed` to include font data in the SVG, or `Vectorize` to render only text that uses external fonts as graphics. Verify font licensing before embedding fonts.

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

## **एम्बेडेड छवि का आकार घटाएँ**

Use [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) to reduce the resolution of embedded pictures, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setdeletepicturescroppedareas/) to omit cropped source areas, and [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) to control JPEG encoding quality. These settings reduce file size at the cost of image fidelity or retained image data.

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

## **मेटाफाइल रास्टराइज़ेशन रेजोल्यूशन को नियंत्रित करें**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setmetafilerasterizationdpi/) sets the lower resolution limit for rasterizing metafiles during SVG export. Use it to balance detail and file size when an EMF or WMF image is rasterized. It does not define a global DPI for the SVG or force every object on the slide to become a raster image.

Download [metafile-rasterization.pptx](metafile-rasterization.pptx), which contains an EMF image with closely spaced diagonal lines. The following example exports its first slide at three rasterization resolutions through [Slide.writeAsSvg](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/writeassvg/). All other export settings remain identical so that the results can be compared.

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

In the output, the EMF became one embedded PNG in each SVG. The following measurements are for the supplied presentation; they are not a general formula for converting DPI to pixel dimensions.

| Metafile rasterization DPI | Embedded PNG dimensions | SVG file size (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

The comparison below shows the same area of the embedded raster at the same enlarged display size. The diagonal lines show visible pixelation at 72 DPI and smoother edges at higher resolutions, while the SVG file grows. Increasing the value does not necessarily improve every detail or change every exported image.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setpicturescompression/) controls image resolution reduction and can mask the effect of changing the metafile rasterization resolution. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setjpegquality/) controls JPEG encoding quality, not metafile rasterization resolution.

## **शेप्स और टेक्स्ट को स्थिर आईडी असाइन करें**

Pass a formatting controller to [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) to set [SvgShape.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/setid/) for each SVG shape. A controller that also handles text spans can set [SvgTSpan.setId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgtspan/setid/) values on text `tspan` elements.

The following controller uses [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/), which is stable for the lifetime of the shape, and a repeatable counter for its text spans. This makes the generated IDs suitable for post-processing an unchanged presentation.

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

## **SVG ईवेंट हैंडलर्स जोड़ें**

In a formatting controller, call [SvgShape.setEventHandler](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/seteventhandler/) with a [SvgEvent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgevent/) value to add a JavaScript event handler to an exported shape. Assign the controller with [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setshapeformattingcontroller/) and define the JavaScript function in the page or SVG document that hosts the result.

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

**When should I use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) instead of [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/)?**

Use [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/setvectorizetext/) when all text must be independent of fonts. Use [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgexternalfontshandling/) when only text that uses external fonts should be converted to graphics.

**What is the best way to make an SVG smaller?**

Start by compressing embedded pictures, deleting cropped image areas, and choosing linked font files when the target environment can serve them. Test the result because lower image resolution, lower JPEG quality, and vectorized text each have different quality and size tradeoffs.

**Can I modify exported SVG elements after export?**

Yes. Assign IDs through a formatting controller, then select the matching SVG elements in your post-processing tool or browser script.