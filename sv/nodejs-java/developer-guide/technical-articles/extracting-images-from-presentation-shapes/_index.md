---
title: Extrahera bilder från presentationsformer i Node.js
linktitle: Bild från form
type: docs
weight: 100
url: /sv/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- extrahera bild
- hämta bild
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Extrahera bilder från former i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js via Java – snabb, kodvänlig lösning."
---
## **Översikt**

Bilder i en presentation kan visas i flera formtyper: som vanliga bildramar, som bildfyllningar som appliceras på former, som förhandsgranskningsbilder för OLE‑objekt, som miniatyrbilder för video‑ eller ljudramar, som zoom‑bilder eller som bilder inbäddade i tabell‑, diagram‑ och SmartArt‑former. Aspose.Slides lagrar dessa bilder i presentationens bildsamling, som exponeras via [ImageCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imagecollection/) och [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/)‑objekt.

Om du bara behöver exportera varje bildresurs som är inbäddad i en presentation, iterera genom `presentation.getImages()`. Den här artikeln fokuserar på en annan uppgift: att gå igenom former för att hitta var bilder används på bilderna, så att de sparade filerna kan behålla användbar kontext som bildnummer, formens position och källtyp (bildram, fyllningsbild, medie‑förhandsgranskning, OLE‑förhandsgranskning eller zoom‑bild).

{{% alert title="Tip" color="primary" %}}
Använd [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) och dess `getBinaryData()`‑metod för att bevara de ursprungliga kodade bilddata och filtypen. Använd `getImage()` när du vill normalisera utskriften till ett specifikt format, t.ex. PNG.
{{% /alert %}}

## **Gemensamma hjälpfunktioner**

Hjälpfunktionerna nedan hållar exemplen korta. `saveOriginalImage` skriver de ursprungliga inbäddade byten, väljer en säker filändelse från MIME‑typen och hoppar över duplicerade bildbinärer baserat på SHA‑256‑hash.

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

## **Extrahera bilder från bildramar**

Använd detta tillvägagångssätt för bilder som infogats som fristående objekt. En [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/) lagrar sin bild i `getPictureFormat().getPicture().getImage()`, vilket returnerar ett [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/)‑objekt.

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

## **Extrahera bilder från bildfyllda former**

Former kan använda en bild som fyllning. Kontrollera först formens fyllningstyp: om den inte är [FillType.Picture](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filltype/), finns ingen bild att extrahera från den fyllningen. Exemplet nedan hanterar [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/)‑objekt och sparar varje bild som PNG via [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) och dess `getImage()`‑metod.

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

## **Extrahera förhandsgranskningsbilder från OLE‑objekt‑ramar**

En [OleObjectFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/oleobjectframe/) kan ha en ersättningsbild som PowerPoint använder som objektets förhandsgranskning på en bild. Denna bild är tillgänglig via `getSubstitutePictureFormat().getPicture().getImage()`. Att extrahera denna bild ger dig förhandsgranskningsbilden, inte innehållet i det inbäddade OLE‑paketet.

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

## **Extrahera förhandsgranskningsbilder från video‑ramar**

En [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/) kan också lagra en förhandsgranskningsbild i `getPictureFormat().getPicture().getImage()`. Detta är affisch‑ eller miniatyrbilden som visas på bilden, inte en bildruta avkodad från videoströmmen.

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

## **Extrahera förhandsgranskningsbilder från ljudramar**

En [AudioFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/) kan lagra en miniatyrbild i `getPictureFormat().getPicture().getImage()`. Detta är bilden som visas för ljudobjektet på bilden.

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

## **Extrahera bilder från zoom‑objekt**

[ZoomFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/zoomframe/) och [SectionZoomFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sectionzoomframe/)‑former kan använda egna bilder. Läs `getZoomImage()` från zoom‑ramen.

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

## **Extrahera bilder från sammanfattnings‑zoom‑ramar**

En [SummaryZoomFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/summaryzoomframe/) är också en form. Dess avsnitt kan använda egna bilder, som exponeras via varje sammanfattnings‑zoom‑avsnitts `getZoomImage()`‑metod.

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

## **Extrahera bilder från tabell‑former**

En [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/table/) är en form. Bilder i en tabell lagras vanligtvis som bildfyllningar i tabellceller.

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

## **Extrahera bilder från diagram‑former**

En [Chart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/) är en form. Exemplet nedan extraherar en bild från diagramområdets bildfyllning.

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

## **Extrahera bilder från SmartArt‑former**

Ett [SmartArt](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/smartart/)‑objekt är en form. Beroende på SmartArt‑layouten kan bilder lagras i nodpunkts‑fyllningar eller i fyllningsformaten för nodformer.

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

## **Inkludera bilder i grupperade former**

Grupperade former innehåller sina egna formsamlingar. Den delade hjälpfunktionen `enumerateShapes` har ett alternativ `includeGroupedShapes`. Sätt det till `true` när du vill inspektera former inuti [GroupShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/groupshape/)‑objekt. Exemplet nedan extraherar bilder från bildramar, bildfyllda former, OLE‑objekt‑förhandsgranskningar, videoramar‑miniatyrer och ljudram‑miniatyrer. För att även inkludera tabell‑, diagram‑, SmartArt‑ och sammanfattnings‑zoom‑bilder, återanvänd den specialiserade extraktionslogiken från de föregående sektionerna samtidigt som du behåller samma rekursiva formtraversering.

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

## **Särskilda fall och praktiska anteckningar**

- **Duplicerade bilder:** Flera former kan referera till samma bild eller separata bilder med identiska byte. Hasha [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/)‑data från `getBinaryData()` innan du skriver filer om du vill ha en utdatafil per unik bild.
- **Originaldata vs konverterad utdata:** Att spara [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/)‑data från `getBinaryData()` bevarar den inbäddade JPEG‑, PNG‑, GIF‑, SVG‑, EMF‑ eller WMF‑data. Att spara bilden som returneras av `getImage()` är användbart när du vill ha ett enhetligt utdataformat.
- **Ej stödjade fyllningstyper:** Enkla, gradient‑, mönster‑ och ingen‑fyllning‑former innehåller ingen bildfyllning. Kontrollera [FillType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filltype/) innan du läser `getPictureFillFormat()`.
- **Grupperade former:** Den översta bildens formsamling plattar inte till grupper. Inspektera rekursivt [GroupShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/groupshape/)‑innehåll via `getShapes()` när gruppinnehåll är viktigt.
- **OLE‑objekt‑förhandsgranskningar:** En [OleObjectFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/oleobjectframe/) kan exponera en förhandsgranskningsbild via `getSubstitutePictureFormat()`, men den bilden är bara förhandsgranskning på bilden. Det är inte den inbäddade filen i OLE‑objektet.
- **Video‑ram‑miniatyrer:** En [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/) kan exponera en förhandsgranskningsbild via `getPictureFormat()`, men den bilden är bara affischen som visas på bilden. Den är inte extraherad från videoströmmen.
- **Ljud‑ram‑miniatyrer:** En [AudioFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/audioframe/) kan exponera en ikon eller miniatyrbild via `getPictureFormat()`; den är inte det inbäddade ljuddata.
- **Zoom‑bilder:** Slide‑zoom, sektion‑zoom och sammanfattnings‑zoom‑former kan använda egna [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/)‑objekt via `getZoomImage()`.
- **Nästlade formmodeller:** Tabell‑, diagram‑ och SmartArt‑objekt implementerar [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/), men deras bilder lagras ofta i inbäddade tabellceller, diagram‑element eller SmartArt‑nod‑formateringsobjekt.
- **Beskurna eller transformerade bilder:** Att komma åt [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) ger den lagrade bildresursen. Det renderar inte beskärning, transparens, omfärgning, rotation eller andra visuella effekter som appliceras av formen.

## **Vanliga frågor**

**Kan jag extrahera den ursprungliga bilden utan beskärning, effekter eller formtransformeringar?**

Ja. Åtkom [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/)‑objektet och skriv data från `getBinaryData()` till disk. Detta bevarar den ursprungliga kodade bilden som lagras i presentationen, inte hur bilden renderas på bilden.

**Kan jag exportera varje extraherad bild som PNG?**

Ja. Använd [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) och dess `getImage()`‑metod, och anropa sedan `save()` med [ImageFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/imageformat/). Detta konverterar utskriften och kan eventuellt inte bevara originalfiltypen eller vektordata.

**Hur undviker jag att spara samma bild mer än en gång?**

Använd en hash av [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/)‑data från `getBinaryData()` och behåll hasharna i en uppsättning. Om en ny bild har en hash som redan finns, hoppa över den eller registrera en annan referens till den befintliga utdatafilen.

**Varför producerar vissa former ingen bild?**

Bildramar, bildfyllda former, OLE‑objekt‑ramar, medie‑ramar, zoom‑ramar, tabeller, diagram och SmartArt‑objekt kan referera bilder. Vissa formtyper exponerar bilder via inbäddade formateringsobjekt, så en enkel kontroll av `getPictureFormat()` eller formens `getFillFormat()` är inte alltid tillräcklig.

**Kan jag extrahera miniatyrbilden som visas för en video‑ram?**

Ja. Använd [VideoFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/videoframe/) och läs `getPictureFormat().getPicture().getImage()`. Detta extraherar affisch‑bilden som lagras med video‑ramen, inte en bildruta som genereras från videofilen.

**Hur kan jag avgöra vilka former som använder en specifik bild från presentationens bildsamling?**

Aspose.Slides lagrar inte omvända länkar från [PPImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/ppimage/) till former. Bygg en mappning under traverseringen: varje gång du hittar en bildreferens, registrera bildnumret, formens sökväg och bildens hash eller samlingsobjekt.

**Kan jag extrahera bilder som är inbäddade i OLE‑objekt, t.ex. bifogade dokument?**

Du kan extrahera OLE‑objektets slide‑förhandsgranskning från [OleObjectFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/oleobjectframe/). Men den förhandsgranskningen är inte det inbäddade dokumentet självt. För att extrahera bilder från den inbäddade filen, extrahera OLE‑data och inspektera den med verktyg för den filtypen.