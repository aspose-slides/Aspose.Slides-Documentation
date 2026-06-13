---
title: Node.js में प्रस्तुति आकारों से छवियों को निकालें
linktitle: आकार से छवि
type: docs
weight: 100
url: /hi/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- छवि निकालें
- छवि प्राप्त करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में आकारों से छवियों को निकालें - तेज, कोड‑मित्र समाधान।"
---
## **概要**

एक प्रस्तुति में छवियाँ कई आकार प्रकारों में दिखाई दे सकती हैं: सामान्य चित्र फ्रेम, आकारों पर लागू चित्र भराव, OLE ऑब्जेक्ट प्रीव्यू छवियाँ, वीडियो या ऑडियो फ्रेम थंबनेल, ज़ूम छवियां, या तालिका, चार्ट और SmartArt आकारों के अंदर नेस्टेड छवियां। Aspose.Slides इन छवियों को प्रस्तुति छवि संग्रह में संग्रहीत करता है, जिसे [ImageCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imagecollection/) और [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) ऑब्जेक्ट के माध्यम से एक्सपोज़ किया गया है।

यदि आपको केवल प्रस्तुति में एम्बेडेड हर छवि संसाधन को निर्यात करना है, तो `presentation.getImages()` के माध्यम से इटररेट करें। यह लेख एक अलग कार्य पर केंद्रित है: स्लाइडों पर छवियों के उपयोग वाले आकारों को पार करके, ताकि सहेजी गई फ़ाइलें स्लाइड नंबर, आकार स्थिति और स्रोत प्रकार (चित्र फ्रेम, भराव छवि, मीडिया प्रीव्यू, OLE प्रीव्यू, या ज़ूम छवि) जैसी उपयोगी संदर्भ को रख सकें।

{{% alert title="Tip" color="primary" %}}
[PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) और उसकी `getBinaryData()` मेथड का उपयोग करके मूल एन्कोडेड छवि डेटा और फ़ाइल प्रकार को संरक्षित रखें। जब आप आउटपुट को PNG जैसे विशिष्ट फ़ॉर्मेट में सामान्यीकरण करना चाहते हैं तो `getImage()` उपयोग करें।
{{% /alert %}}

## **साझा हेल्पर मेथड्स**

नीचे दिए गए हेल्पर मेथड्स उदाहरणों को छोटा रखता है। `saveOriginalImage` मूल एम्बेडेड बाइट्स लिखता है, MIME प्रकार से एक सुरक्षित एक्सटेंशन चुनता है, और SHA-256 हैश द्वारा डुप्लिकेट छवि बाइनरी को स्किप करता है।

```javascript
const fileSystem = require("fs");
const pathModule = require("path");
const cryptoModule = require("crypto");
const asposeSlides = require("aspose.slides.via.java");

class ShapeReference {
    constructor(shape, namePart) {
        this.shape = shape;
        this.namePart = namePart;
    }
}

function saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes) {
    const imageData = image.getBinaryData();
    const imageBuffer = Buffer.from(imageData);
    const imageHash = getSha256Hash(imageBuffer);
    if (savedImageHashes.has(imageHash)) {
        return false;
    }

    savedImageHashes.add(imageHash);

    const extension = getExtensionFromContentType(image.getContentType());
    const fileName = `${fileNameBase}.${extension}`;
    const outputPath = pathModule.join(outputDirectory, fileName);
    fileSystem.writeFileSync(outputPath, imageBuffer);
    return true;
}

function saveImageAsPng(image, outputDirectory, fileNameBase) {
    const fileName = `${fileNameBase}.png`;
    const outputPath = pathModule.join(outputDirectory, fileName);

    const outputImage = image.getImage();
    try {
        outputImage.save(outputPath, asposeSlides.ImageFormat.Png);
    } finally {
        if (outputImage !== null) {
            outputImage.dispose();
        }
    }
}

function getPictureFillImage(fillFormat) {
    if (fillFormat == null || fillFormat.getFillType() !== asposeSlides.FillType.Picture) {
        return null;
    }

    return fillFormat.getPictureFillFormat().getPicture().getImage();
}

function enumerateShapes(shapes, prefix, includeGroupedShapes) {
    const shapeReferences = [];
    const shapeCount = shapes.size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        const displayIndex = shapeIndex + 1;
        const shapeNamePart = `${prefix}_shape_${displayIndex}`;
        const shapeReference = new ShapeReference(shape, shapeNamePart);
        shapeReferences.push(shapeReference);

        if (includeGroupedShapes && java.instanceOf(shape, "com.aspose.slides.GroupShape")) {
            const childShapes = shape.getShapes();
            const childReferences = enumerateShapes(childShapes, shapeNamePart, includeGroupedShapes);
            shapeReferences.push(...childReferences);
        }
    }

    return shapeReferences;
}

function getSha256Hash(data) {
    return cryptoModule.createHash("sha256").update(data).digest("hex");
}

function getExtensionFromContentType(contentType) {
    if (contentType == null || contentType.trim().length === 0) {
        return "bin";
    }

    const mediaType = contentType.split(";")[0].trim().toLowerCase();
    if (mediaType === "image/jpeg") {
        return "jpg";
    }

    if (mediaType === "image/png") {
        return "png";
    }

    if (mediaType === "image/gif") {
        return "gif";
    }

    if (mediaType === "image/bmp") {
        return "bmp";
    }

    if (mediaType === "image/tiff") {
        return "tiff";
    }

    if (mediaType === "image/x-emf" || mediaType === "image/emf") {
        return "emf";
    }

    if (mediaType === "image/x-wmf" || mediaType === "image/wmf") {
        return "wmf";
    }

    if (mediaType === "image/svg+xml") {
        return "svg";
    }

    if (mediaType.startsWith("image/")) {
        const extension = mediaType.substring("image/".length);
        return makeSafeFileNamePart(extension);
    }

    return "bin";
}

function makeSafeFileNamePart(value) {
    return value.replace(/[^A-Za-z0-9._-]/g, "_");
}
```

## **चित्र फ्रेम से छवियों को निकालें**

इस दृष्टिकोण का उपयोग स्वतंत्र ऑब्जेक्ट के रूप में डाले गए चित्रों के लिए करें। एक [PictureFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pictureframe/) अपनी चित्र को `getPictureFormat().getPicture().getImage()` में संग्रहीत करता है, जो एक [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) ऑब्जेक्ट लौटाता है।

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "extracted-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.PictureFrame")) {
                const pictureFrame = shapeReference.shape;
                const image = pictureFrame.getPictureFormat().getPicture().getImage();
                saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **चित्र-भरे आकारों से छवियों को निकालें**

आकार एक चित्र को अपने भराव के रूप में उपयोग कर सकते हैं। पहले आकार के भराव प्रकार की जाँच करें: यदि वह [FillType.Picture](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) नहीं है, तो उस भराव से निकालने के लिए कोई चित्र नहीं है। नीचे का उदाहरण [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) ऑब्जेक्ट को संभालता है और प्रत्येक छवि को PNG के रूप में [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) और उसकी `getImage()` मेथड के माध्यम से सहेजता है।

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "shape-fill-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.AutoShape")) {
                const autoShape = shapeReference.shape;
                const fillFormat = autoShape.getFillFormat();
                const image = getPictureFillImage(fillFormat);
                if (image !== null) {
                    saveImageAsPng(image, outputDirectory, shapeReference.namePart);
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **OLE ऑब्जेक्ट फ्रेम से प्रीव्यू छवियों को निकालें**

एक [OleObjectFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/oleobjectframe/) में एक प्रतिस्थापन चित्र हो सकता है जिसे PowerPoint स्लाइड पर ऑब्जेक्ट के प्रीव्यू के रूप में उपयोग करता है। यह छवि `getSubstitutePictureFormat().getPicture().getImage()` के माध्यम से उपलब्ध है। इस चित्र को निकालने से आपको प्रीव्यू छवि मिलती है, न कि एम्बेडेड OLE पैकेज की सामग्री।

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "ole-preview-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.OleObjectFrame")) {
                const oleObjectFrame = shapeReference.shape;
                const image = oleObjectFrame.getSubstitutePictureFormat().getPicture().getImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_ole_preview`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **वीडियो फ्रेम से प्रीव्यू छवियों को निकालें**

एक [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) भी `getPictureFormat().getPicture().getImage()` में एक प्रीव्यू छवि संग्रहीत कर सकता है। यह स्लाइड पर दिखाया गया पोस्टर या थंबनेल है, न कि वीडियो स्ट्रीम से डिकोड किया गया फ़्रेम।

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "video-preview-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shapeReference.shape;
                const image = videoFrame.getPictureFormat().getPicture().getImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_video_preview`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **ऑडियो फ्रेम से प्रीव्यू छवियों को निकालें**

एक [AudioFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/) `getPictureFormat().getPicture().getImage()` में एक थंबनेल संग्रहीत कर सकता है। यह स्लाइड पर ऑडियो ऑब्जेक्ट के लिए दिखाया गया चित्र है।

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "audio-preview-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.AudioFrame")) {
                const audioFrame = shapeReference.shape;
                const image = audioFrame.getPictureFormat().getPicture().getImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_audio_preview`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **ज़ूम ऑब्जेक्ट्स से छवियों को निकालें**

[ZoomFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/zoomframe/) और [SectionZoomFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/sectionzoomframe/) आकार कस्टम छवियों का उपयोग कर सकते हैं। ज़ूम फ्रेम से `getZoomImage()` पढ़ें।

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "zoom-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.ZoomFrame")) {
                const zoomFrame = shapeReference.shape;
                const image = zoomFrame.getZoomImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_zoom`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    continue;
                }
            }

            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.SectionZoomFrame")) {
                const sectionZoomFrame = shapeReference.shape;
                const image = sectionZoomFrame.getZoomImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_section_zoom`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    continue;
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **समरी ज़ूम फ्रेम्स से छवियों को निकालें**

एक [SummaryZoomFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/summaryzoomframe/) भी एक आकार है। इसके सेक्शन आइटम कस्टम छवियों का उपयोग कर सकते हैं, जो प्रत्येक समरी ज़ूम सेक्शन की `getZoomImage()` मेथड द्वारा एक्सपोज़ किया जाता है।

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "summary-zoom-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.SummaryZoomFrame")) {
                const summaryZoomFrame = shapeReference.shape;
                const summaryZoomCollection = summaryZoomFrame.getSummaryZoomCollection();
                const sectionCount = summaryZoomCollection.size();
                for (let sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++) {
                    const summaryZoomSection = summaryZoomCollection.get_Item(sectionIndex);
                    const image = summaryZoomSection.getZoomImage();
                    if (image !== null) {
                        const displayIndex = sectionIndex + 1;
                        const fileNameBase = `${shapeReference.namePart}_summary_zoom_${displayIndex}`;
                        saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **टेबल आकारों से छवियों को निकालें**

एक [Table](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/table/) एक आकार है। तालिका में छवियां आमतौर पर तालिका कोशिकाओं में चित्र भराव के रूप में संग्रहीत होती हैं।

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "table-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.Table")) {
                const table = shapeReference.shape;
                const rowCount = table.getRows().size();
                const columnCount = table.getColumns().size();
                for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
                    for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
                        const cell = table.get_Item(columnIndex, rowIndex);
                        const fillFormat = cell.getCellFormat().getFillFormat();
                        const image = getPictureFillImage(fillFormat);
                        if (image !== null) {
                            const displayRow = rowIndex + 1;
                            const displayColumn = columnIndex + 1;
                            const fileNameBase = `${shapeReference.namePart}_cell_${displayRow}_${displayColumn}`;
                            saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **चार्ट आकारों से छवियों को निकालें**

एक [Chart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/) एक आकार है। नीचे का उदाहरण चार्ट एरिया के चित्र भराव से छवि निकालता है।

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "chart-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.Chart")) {
                const chart = shapeReference.shape;
                const fillFormat = chart.getFillFormat();
                const image = getPictureFillImage(fillFormat);
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_chart_area`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **SmartArt आकारों से छवियों को निकालें**

एक [SmartArt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartart/) ऑब्जेक्ट एक आकार है। SmartArt लेआउट के अनुसार, छवियां नोड बुलेट भराव या नोड आकारों के भराव स्वरूप में संग्रहीत हो सकती हैं।

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "smartart-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.SmartArt")) {
                const smartArt = shapeReference.shape;
                const allNodes = smartArt.getAllNodes();
                const nodeCount = allNodes.size();
                for (let nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++) {
                    const node = allNodes.get_Item(nodeIndex);
                    const bulletFillFormat = node.getBulletFillFormat();
                    const bulletImage = getPictureFillImage(bulletFillFormat);
                    if (bulletImage !== null) {
                        const displayNode = nodeIndex + 1;
                        const fileNameBase = `${shapeReference.namePart}_smartart_node_${displayNode}_bullet`;
                        saveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    const nodeShapes = node.getShapes();
                    const nodeShapeCount = nodeShapes.size();
                    for (let nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++) {
                        const nodeShape = nodeShapes.get_Item(nodeShapeIndex);
                        const fillFormat = nodeShape.getFillFormat();
                        const image = getPictureFillImage(fillFormat);
                        if (image !== null) {
                            const displayNode = nodeIndex + 1;
                            const displayNodeShape = nodeShapeIndex + 1;
                            const fileNameBase = `${shapeReference.namePart}_smartart_node_${displayNode}_shape_${displayNodeShape}`;
                            saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **ग्रुप्ड आकारों के अंदर छवियों को शामिल करें**

ग्रुप्ड आकारों में अपने स्वयं के आकार संग्रह होते हैं। साझा `enumerateShapes` हेल्पर में `includeGroupedShapes` विकल्प है। जब आप [GroupShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/groupshape/) ऑब्जेक्ट्स के अंदर आकारों का निरीक्षण करना चाहते हैं, तो इसे `true` सेट करें। नीचे का उदाहरण चित्र फ्रेम, चित्र-भरे आकार, OLE ऑब्जेक्ट प्रीव्यू, वीडियो फ्रेम थंबनेल और ऑडियो फ्रेम थंबनेल से छवियों को निकालता है। तालिका, चार्ट, SmartArt और समरी ज़ूम छवियों को भी शामिल करने के लिए, पिछले अनुभागों से विशेषीकृत निष्कर्षण लॉजिक को पुन: उपयोग करते हुए समान रिकर्सिव आकार ट्रैवर्सल रखें।

```javascript
const inputPath = "sample.pptx";
const currentDirectory = process.cwd();
const outputDirectory = pathModule.join(currentDirectory, "all-shape-images");
fileSystem.mkdirSync(outputDirectory, { recursive: true });

const savedImageHashes = new Set();

const presentation = new asposeSlides.Presentation(inputPath);
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slide.getSlideNumber();
        const slidePrefix = `slide_${slideNumber}`;
        const shapes = slide.getShapes();
        const shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (const shapeReference of shapeReferences) {
            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.OleObjectFrame")) {
                const oleObjectFrame = shapeReference.shape;
                const image = oleObjectFrame.getSubstitutePictureFormat().getPicture().getImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_ole_preview`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shapeReference.shape;
                const image = videoFrame.getPictureFormat().getPicture().getImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_video_preview`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.AudioFrame")) {
                const audioFrame = shapeReference.shape;
                const image = audioFrame.getPictureFormat().getPicture().getImage();
                if (image !== null) {
                    const fileNameBase = `${shapeReference.namePart}_audio_preview`;
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.PictureFrame")) {
                const pictureFrame = shapeReference.shape;
                const image = pictureFrame.getPictureFormat().getPicture().getImage();
                saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
                continue;
            }

            if (java.instanceOf(shapeReference.shape, "com.aspose.slides.AutoShape")) {
                const autoShape = shapeReference.shape;
                const fillFormat = autoShape.getFillFormat();
                const image = getPictureFillImage(fillFormat);
                if (image !== null) {
                    saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
                }
            }
        }
    }
} finally {
    if (presentation !== null) {
        presentation.dispose();
    }
}
```

## **एज केस और व्यावहारिक नोट्स**

- **डुप्लिकेट छवियां:** कई आकार एक ही छवि का संदर्भ दे सकते हैं या समान बाइट्स वाली अलग छवियां। यदि आप प्रत्येक अनन्य छवि के लिए एक आउटपुट फ़ाइल चाहते हैं, तो फ़ाइल लिखने से पहले `getBinaryData()` से [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) डेटा का हैश बनाएं।
- **मूल डेटा बनाम परिवर्तित आउटपुट:** `getBinaryData()` से [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) डेटा को सहेजने से एम्बेडेड JPEG, PNG, GIF, SVG, EMF, या WMF डेटा संरक्षित रहता है। `getImage()` द्वारा लौटाए गए चित्र को सहेजना उपयोगी है जब आप एक सुसंगत आउटपुट फ़ॉर्मेट चाहते हैं।
- **असमर्थित भराव प्रकार:** ठोस, ग्रेडिएंट, पैटर्न, और नो-फ़िल आकारों में चित्र भराव नहीं होता। `getPictureFillFormat()` पढ़ने से पहले [FillType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/filltype/) की जाँच करें।
- **ग्रुप्ड आकार:** शीर्ष‑स्तर स्लाइड आकार संग्रह समूहों को फ्लैट नहीं करता। जब समूहित सामग्री महत्वपूर्ण हो, तो `getShapes()` के माध्यम से [GroupShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/groupshape/) सामग्री को रिकर्सिवली जाँचें।
- **OLE ऑब्जेक्ट प्रीव्यू:** एक [OleObjectFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/oleobjectframe/) `getSubstitutePictureFormat()` के माध्यम से प्रीव्यू छवि प्रदान कर सकता है, लेकिन वह केवल स्लाइड प्रीव्यू है, OLE ऑब्जेक्ट के अंदर एम्बेडेड फ़ाइल नहीं।
- **वीडियो फ्रेम थंबनेल:** एक [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) `getPictureFormat()` के माध्यम से प्रीव्यू छवि प्रदान कर सकता है, लेकिन वह केवल स्लाइड पर दिखाया गया पोस्टर है, वीडियो स्ट्रीम से नहीं निकाला गया।
- **ऑडियो फ्रेम थंबनेल:** एक [AudioFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/audioframe/) `getPictureFormat()` के माध्यम से आइकन या थंबनेल प्रदान कर सकता है; यह एम्बेडेड ऑडियो डेटा नहीं है।
- **ज़ूम छवियां:** स्लाइड ज़ूम, सेक्शन ज़ूम और समरी ज़ूम आकार कस्टम [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) ऑब्जेक्ट को `getZoomImage()` के माध्यम से उपयोग कर सकते हैं।
- **नेस्टेड आकार मॉडल:** तालिका, चार्ट और SmartArt ऑब्जेक्ट [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) को लागू करते हैं, लेकिन उनकी छवियां अक्सर नेस्टेड तालिका कोशिका, चार्ट तत्व या SmartArt नोड फ़ॉर्मेटिंग ऑब्जेक्ट में संग्रहीत होती हैं।
- **क्रॉप या ट्रांसफ़ॉर्म किए गए चित्र:** [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) तक पहुँचने से आपको संग्रहीत मूल छवि संसाधन मिलता है। यह आकार द्वारा लागू किए गए क्रॉपिंग, ट्रांसपरेंसी, री‑कलरिंग, रोटेशन या अन्य दृश्य प्रभावों को रेंडर नहीं करता।

## **FAQ**

**क्या मैं मूल छवि को बिना क्रॉपिंग, इफ़ेक्ट्स या आकार ट्रांसफ़ॉर्मेशन के निकाल सकता हूँ?**

हाँ। [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) ऑब्जेक्ट तक पहुँचें और `getBinaryData()` से डेटा को डिस्क पर लिखें। यह प्रस्तुति में संग्रहीत मूल एन्कोडेड छवि को संरक्षित करता है, न कि स्लाइड पर छवि के रेंडर होने के तरीके को।

**क्या मैं सभी निकाली गई छवियों को PNG के रूप में निर्यात कर सकता हूँ?**

हाँ। [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) और उसकी `getImage()` मेथड का उपयोग करें, फिर [ImageFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imageformat/) के साथ `save()` कॉल करें। यह आउटपुट को बदल देता है और मूल फ़ाइल प्रकार या वेक्टर डेटा को संरक्षित नहीं कर सकता।

**मैं एक ही छवि को कई बार सहेजने से कैसे बचूँ?**

`getBinaryData()` से प्राप्त [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) डेटा का हैश बनाकर उसे सेट में रखें। यदि नया छवि का हैश पहले से मौजूद है, तो उसे स्किप करें या मौजूदा आउटपुट फ़ाइल के लिए एक और रेफ़रेंस रिकॉर्ड करें।

**कुछ आकारों से छवि क्यों नहीं बनती?**

चित्र फ्रेम, चित्र‑भरे आकार, OLE ऑब्जेक्ट फ्रेम, मीडिया फ्रेम, ज़ूम फ्रेम, तालिका, चार्ट और SmartArt ऑब्जेक्ट्स छवियों को संदर्भित कर सकते हैं। कुछ आकार प्रकार नेस्टेड फ़ॉर्मेटिंग ऑब्जेक्ट्स के माध्यम से छवियां एक्सपोज़ करते हैं, इसलिए सिर्फ `getPictureFormat()` या आकार का `getFillFormat()` जांचना हमेशा पर्याप्त नहीं होता।

**क्या मैं वीडियो फ्रेम के लिए दिखाए गए थंबनेल को निकाल सकता हूँ?**

हाँ। [VideoFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/videoframe/) का उपयोग करें और `getPictureFormat().getPicture().getImage()` पढ़ें। यह वीडियो फ्रेम के साथ संग्रहीत पोस्टर छवि को निकालता है, वीडियो फ़ाइल से उत्पन्न फ़्रेम नहीं।

**मैं कैसे निर्धारित करूँ कि कौन से आकार प्रस्तुति छवि संग्रह से विशिष्ट छवि का उपयोग करते हैं?**

Aspose.Slides में [PPImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ppimage/) से आकारों की रिवर्स लिंक नहीं होती। ट्रैवर्सल के दौरान एक मैपिंग बनाएं: जब भी आप किसी छवि रेफ़रेंस को पाएँ, स्लाइड नंबर, आकार पाथ और छवि हैश या संग्रह आइटम को रिकॉर्ड करें।

**क्या मैं OLE ऑब्जेक्ट्स के भीतर एम्बेडेड छवियां, जैसे संलग्न दस्तावेज़, निकाल सकता हूँ?**

आप [OleObjectFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/oleobjectframe/) से OLE ऑब्जेक्ट का स्लाइड प्रीव्यू निकाल सकते हैं। हालांकि, वह प्रीव्यू एम्बेडेड दस्तावेज़ स्वयं नहीं है। एम्बेडेड फ़ाइल के भीतर की छवियों को निकालने के लिए OLE डेटा को एक्सट्रेक्ट करें और उस फ़ाइल प्रकार के लिए उपयुक्त टूल्स से जांचें।