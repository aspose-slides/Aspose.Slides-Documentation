---
title: Afbeeldingen extraheren uit presentatievormen in Node.js
linktitle: Afbeelding uit Vorm
type: docs
weight: 100
url: /nl/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- afbeelding extraheren
- afbeelding ophalen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Afbeeldingen extraheren uit vormen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Node.js via Java - snelle, code-vriendelijke oplossing."
---
## **Overzicht**

Afbeeldingen in een presentatie kunnen in verschillende vormtypen voorkomen: als gewone afbeeldingsframes, als afbeeldingsvullingen die op vormen worden toegepast, als voorbeeldafbeeldingen van OLE‑objecten, als miniaturen van video‑ of audio‑frames, als zoom‑afbeeldingen, of als afbeeldingen die genesteld zijn in tabel‑, grafiek‑ en SmartArt‑vormen. Aspose.Slides slaat die afbeeldingen op in de afbeeldingscollectie van de presentatie, toegankelijk via de objecten [ImageCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imagecollection/) en [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) .

Als u alleen elke in een presentatie ingesloten afbeeldingsbron wilt exporteren, doorloop dan `presentation.getImages()`. Dit artikel richt zich op een andere taak: vormen doorlopen om te ontdekken waar afbeeldingen op dia's worden gebruikt, zodat de opgeslagen bestanden nuttige context behouden zoals het dia‑nummer, de positie van de vorm en het brontype (afbeeldingsframe, vulafbeelding, media‑preview, OLE‑preview of zoom‑afbeelding).

{{% alert title="Tip" color="primary" %}}
Gebruik [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) en de methode `getBinaryData()` om de oorspronkelijk gecodeerde afbeeldingsdata en bestandstype te behouden. Gebruik `getImage()` wanneer u de uitvoer wilt normaliseren naar een specifiek formaat zoals PNG.
{{% /alert %}}

## **Gedeelde helper‑methoden**

De helper‑methoden hieronder houden de voorbeelden kort. `saveOriginalImage` schrijft de oorspronkelijk ingebedde bytes, kiest een veilige extensie op basis van het MIME‑type, en slaat dubbele afbeeldings‑binaire bestanden over op basis van een SHA‑256‑hash.

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

## **Afbeeldingen extraheren uit picture‑frames**

Gebruik deze benadering voor afbeeldingen die als losse objecten zijn ingevoegd. Een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) slaat zijn afbeelding op in `getPictureFormat().getPicture().getImage()`, wat een [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) object retourneert.

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

## **Afbeeldingen extraheren uit picture‑gevulde vormen**

Vormen kunnen een afbeelding gebruiken als vulling. Controleer eerst het vultype van de vorm: als het geen [FillType.Picture](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) is, is er geen afbeelding om uit die vulling te extraheren. Het onderstaande voorbeeld behandelt [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) objecten en slaat elke afbeelding op als PNG via [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) en zijn `getImage()`‑methode.

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

## **Voorbeeldafbeeldingen extraheren uit OLE‑objectframes**

Een [OleObjectFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/oleobjectframe/) kan een vervangende afbeelding hebben die PowerPoint gebruikt als preview van het object op een dia. Deze afbeelding is beschikbaar via `getSubstitutePictureFormat().getPicture().getImage()`. Het extraheren van deze afbeelding levert de preview‑afbeelding op, niet de ingesloten OLE‑pakketinhoud.

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

## **Voorbeeldafbeeldingen extraheren uit video‑frames**

Een [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/) kan ook een preview‑afbeelding opslaan in `getPictureFormat().getPicture().getImage()`. Dit is de poster‑ of miniatuurafbeelding die op de dia wordt getoond, niet een frame dat uit de videostream is gedecodeerd.

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

## **Voorbeeldafbeeldingen extraheren uit audio‑frames**

Een [AudioFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/) kan een miniatuur opslaan in `getPictureFormat().getPicture().getImage()`. Dit is de afbeelding die voor het audio‑object op de dia wordt weergegeven.

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

## **Afbeeldingen extraheren uit zoom‑objecten**

[ZoomFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/zoomframe/) en [SectionZoomFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/sectionzoomframe/) vormen kunnen aangepaste afbeeldingen gebruiken. Lees `getZoomImage()` van het zoom‑frame.

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

## **Afbeeldingen extraheren uit samenvattende zoom‑frames**

Een [SummaryZoomFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/summaryzoomframe/) is eveneens een vorm. De sectie‑items kunnen aangepaste afbeeldingen gebruiken, toegankelijk via de `getZoomImage()`‑methode van elke samenvattende zoom‑sectie.

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

## **Afbeeldingen extraheren uit tabel‑vormen**

Een [Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/table/) is een vorm. Afbeeldingen in een tabel worden meestal opgeslagen als afbeeldingsvullingen in tabelcellen.

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

## **Afbeeldingen extraheren uit grafiek‑vormen**

Een [Chart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/) is een vorm. Het voorbeeld hieronder haalt een afbeelding uit de afbeeldingsvulling van het grafiekgebied.

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

## **Afbeeldingen extraheren uit SmartArt‑vormen**

Een [SmartArt](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/smartart/) object is een vorm. Afhankelijk van de SmartArt‑lay-out kunnen afbeeldingen worden opgeslagen in de vullingen van knooppunt‑bullets of in de vulformaten van knooppunt‑vormen.

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

## **Afbeeldingen opnemen in gegroepeerde vormen**

Gegroepeerde vormen bevatten hun eigen vormcollecties. De gedeelde helper `enumerateShapes` heeft een optie `includeGroupedShapes`. Zet deze op `true` wanneer u vormen binnen [GroupShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/groupshape/) objecten wilt inspecteren. Het voorbeeld hieronder extraheert afbeeldingen uit picture‑frames, picture‑gevulde vormen, OLE‑objectpreviews, video‑frame‑miniaturen en audio‑frame‑miniaturen. Om ook tabel‑, grafiek‑, SmartArt‑ en samenvattende zoom‑afbeeldingen op te nemen, hergebruik de gespecialiseerde extractielogica uit de vorige secties terwijl u dezelfde recursieve vormtraversal behoudt.

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

## **Randgevallen en praktische notities**

- **Dubbele afbeeldingen:** Meerdere vormen kunnen naar dezelfde afbeelding verwijzen of naar verschillende afbeeldingen met identieke bytes. Hash de [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) data van `getBinaryData()` voordat u bestanden schrijft als u één uitvoerbestand per unieke afbeelding wilt.
- **Originele data vs. geconverteerde output:** Het opslaan van [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) data via `getBinaryData()` behoudt de ingebedde JPEG-, PNG-, GIF-, SVG-, EMF- of WMF‑data. Het opslaan van de afbeelding die wordt geretourneerd door `getImage()` is nuttig wanneer u een consistente uitvoerindeling wilt.
- **Niet‑ondersteunde vultypes:** Vlakke, verloop-, patroon- en geen‑vulling vormen bevatten geen afbeeldingsvulling. Controleer [FillType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/filltype/) voordat u `getPictureFillFormat()` leest.
- **Gegroepeerde vormen:** De bovenliggende dia‑vormcollectie maakt groepen niet plat. Inspecteer recursief de inhoud van [GroupShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/groupshape/) via `getShapes()` wanneer gegroepeerde inhoud van belang is.
- **OLE‑objectpreviews:** Een [OleObjectFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/oleobjectframe/) kan een preview‑afbeelding blootleggen via `getSubstitutePictureFormat()`, maar die afbeelding is alleen de dia‑preview. Het is niet het ingesloten bestand binnen het OLE‑object.
- **Video‑frame‑miniaturen:** Een [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/) kan een preview‑afbeelding tonen via `getPictureFormat()`, maar die afbeelding is alleen de poster die op de dia wordt weergegeven. Het wordt niet uit de videostream geëxtraheerd.
- **Audio‑frame‑miniaturen:** Een [AudioFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/audioframe/) kan een pictogram of miniatuur tonen via `getPictureFormat()`; het is niet de ingesloten audio‑data.
- **Zoom‑afbeeldingen:** Dia‑zoom, sectie‑zoom en samenvattende zoom‑vormen kunnen aangepaste [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) objecten gebruiken via `getZoomImage()`.
- **Geneste vormmodellen:** Tabel‑, grafiek‑ en SmartArt‑objecten implementeren [Shape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/), maar hun afbeeldingen worden vaak opgeslagen in geneste tabelcellen, grafiekelementen of SmartArt‑knooppunt‑formatteerobjecten.
- **Bijsneden of getransformeerde afbeeldingen:** Toegang tot [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) levert de opgeslagen afbeeldingsresource. Het rendert geen bijsnijden, transparantie, verkleuring, rotatie of andere visuele effecten die door de vorm zijn toegepast.

## **FAQ**

**Kan ik de originele afbeelding extraheren zonder bijsnijden, effecten of vormtransformaties?**

Ja. Gebruik het [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) object en schrijf de data van `getBinaryData()` naar schijf. Dit behoudt de oorspronkelijk gecodeerde afbeelding die in de presentatie is opgeslagen, niet de manier waarop de afbeelding op de dia wordt gerenderd.

**Kan ik elke geëxtraheerde afbeelding exporteren als PNG?**

Ja. Gebruik [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) en zijn `getImage()`‑methode, en roep vervolgens `save()` aan met [ImageFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/imageformat/). Dit converteert de uitvoer en behoudt mogelijk niet het oorspronkelijke bestandstype of vectorgegevens.

**Hoe kan ik vermijden dat dezelfde afbeelding meer dan één keer wordt opgeslagen?**

Gebruik een hash van de [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) data van `getBinaryData()` en bewaar de hashes in een set. Als een nieuwe afbeelding een hash heeft die al bestaat, sla die dan over of noteer een extra verwijzing naar het bestaande uitvoerbestand.

**Waarom produceren sommige vormen geen afbeelding?**

Picture frames, picture‑gevulde vormen, OLE‑objectframes, media‑frames, zoom‑frames, tabellen, grafieken en SmartArt‑objecten kunnen naar afbeeldingen verwijzen. Sommige vormtypen exposeren afbeeldingen via geneste opmaakobjecten, zodat een eenvoudige controle op `getPictureFormat()` of `getFillFormat()` niet altijd voldoende is.

**Kan ik de miniatuur die wordt getoond voor een video‑frame extraheren?**

Ja. Gebruik [VideoFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/videoframe/) en lees `getPictureFormat().getPicture().getImage()`. Dit extraheert de poster‑afbeelding die bij het video‑frame is opgeslagen, niet een frame gegenereerd uit het videobestand.

**Hoe kan ik bepalen welke vormen een specifieke afbeelding uit de presentatie‑afbeeldingscollectie gebruiken?**

Aspose.Slides slaat geen omgekeerde koppelingen op van [PPImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ppimage/) naar vormen. Bouw tijdens de traversie een mapping op: wanneer u een afbeeldingsreferentie vindt, noteer het dia‑nummer, het vormpad en de afbeeldings‑hash of collectie‑item.

**Kan ik afbeeldingen extraheren die zijn ingebed in OLE‑objecten, zoals bijgevoegde documenten?**

U kunt de slide‑preview van het OLE‑object extraheren via [OleObjectFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/oleobjectframe/). Die preview is echter niet het ingebedde document zelf. Om afbeeldingen uit het ingebedde bestand te extraheren, moet u de OLE‑data extraheren en deze inspecteren met tools voor dat bestandstype.