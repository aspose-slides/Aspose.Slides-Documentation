---
title: Bilder aus Präsentationsformen in Node.js
linktitle: Bild aus Form
type: docs
weight: 100
url: /de/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- Bild extrahieren
- Bild abrufen
- PowerPoint
- OpenDocument
- Präsentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Node.js über Java extrahieren - schnelle, code-freundliche Lösung."
---
## **Übersicht**

Bilder in einer Präsentation können in mehreren Formtyp‑Varianten auftreten: als gewöhnliche Bildrahmen, als Bildfüllungen, die auf Formen angewendet werden, als Vorschau‑Bilder von OLE‑Objekten, als Miniaturansichten von Video‑ oder Audio‑Frames, als Zoom‑Bilder oder als in Tabellen, Diagrammen und SmartArt‑Formen eingebettete Bilder. Aspose.Slides speichert diese Bilder in der Bildsammlung der Präsentation, die über die Objekte [ImageCollection](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imagecollection/) und [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) bereitgestellt wird.

Wenn Sie nur jede in einer Präsentation eingebettete Bildressource exportieren möchten, iterieren Sie über `presentation.getImages()`. Dieser Artikel konzentriert sich auf eine andere Aufgabe: das Durchlaufen von Formen, um herauszufinden, wo Bilder auf Folien verwendet werden, sodass die gespeicherten Dateien nützliche Kontextinformationen wie die Foliennummer, die Position der Form und den Quelltyp (Bildrahmen, Füllbild, Medienvorschau, OLE‑Vorschau oder Zoom‑Bild) behalten.

{{% alert title="Tip" color="primary" %}}
Verwenden Sie [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) und seine `getBinaryData()`‑Methode, um die ursprünglich kodierten Bilddaten und den Dateityp beizubehalten. Verwenden Sie `getImage()`, wenn Sie die Ausgabe in ein bestimmtes Format wie PNG normalisieren möchten.
{{% /alert %}}

## **Gemeinsame Hilfsmethoden**

Die nachstehenden Hilfsmethoden halten die Beispiele kurz. `saveOriginalImage` schreibt die ursprünglich eingebetteten Bytes, wählt eine sichere Dateierweiterung anhand des MIME‑Typs und überspringt doppelte Bild‑Binärdaten anhand eines SHA‑256‑Hashs.

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

## **Bilder aus Bildrahmen extrahieren**

Verwenden Sie diesen Ansatz für Bilder, die als eigenständige Objekte eingefügt wurden. Ein [PictureFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/pictureframe/) speichert sein Bild in `getPictureFormat().getPicture().getImage()`, das ein [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/)‑Objekt zurückgibt.

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

## **Bilder aus bildgefüllten Formen extrahieren**

Formen können ein Bild als Füllung verwenden. Prüfen Sie zuerst den Fülltyp der Form: Wenn er nicht [FillType.Picture](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/filltype/) ist, gibt es kein Bild, das aus dieser Füllung extrahiert werden kann. Das untenstehende Beispiel behandelt [AutoShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/autoshape/)‑Objekte und speichert jedes Bild als PNG über [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) und dessen `getImage()`‑Methode.

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

## **Vorschau‑Bilder aus OLE‑Objekt‑Frames extrahieren**

Ein [OleObjectFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/oleobjectframe/) kann ein Ersatzbild besitzen, das PowerPoint als Vorschau des Objekts auf einer Folie verwendet. Dieses Bild ist über `getSubstitutePictureFormat().getPicture().getImage()` verfügbar. Das Extrahieren dieses Bildes liefert die Vorschau, nicht den eingebetteten OLE‑Paket‑Inhalt.

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

## **Vorschau‑Bilder aus Video‑Frames extrahieren**

Ein [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/) kann ebenfalls ein Vorschau‑Bild in `getPictureFormat().getPicture().getImage()` speichern. Dies ist das Poster‑ oder Miniaturbild, das auf der Folie angezeigt wird, nicht ein aus dem Videostream dekodiertes Einzelbild.

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

## **Vorschau‑Bilder aus Audio‑Frames extrahieren**

Ein [AudioFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/) kann eine Miniatur in `getPictureFormat().getPicture().getImage()` speichern. Dies ist das Bild, das für das Audio‑Objekt auf der Folie angezeigt wird.

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

## **Bilder aus Zoom‑Objekten extrahieren**

[ZoomFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/zoomframe/) und [SectionZoomFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/sectionzoomframe/)‑Formen können benutzerdefinierte Bilder verwenden. Lesen Sie `getZoomImage()` vom Zoom‑Frame.

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

## **Bilder aus Summary‑Zoom‑Frames extrahieren**

Ein [SummaryZoomFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/summaryzoomframe/) ist ebenfalls eine Form. Seine Abschnittselemente können benutzerdefinierte Bilder verwenden, die über die `getZoomImage()`‑Methode jedes Summary‑Zoom‑Abschnitts bereitgestellt werden.

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

## **Bilder aus Tabellen‑Formen extrahieren**

Eine [Table](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/table/) ist eine Form. Bilder in einer Tabelle werden normalerweise als Bildfüllungen in Tabellenzellen gespeichert.

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

## **Bilder aus Diagramm‑Formen extrahieren**

Ein [Chart](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/chart/) ist eine Form. Das untenstehende Beispiel extrahiert ein Bild aus der Bildfüllung des Diagrammbereichs.

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

## **Bilder aus SmartArt‑Formen extrahieren**

Ein [SmartArt](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/smartart/)‑Objekt ist eine Form. Je nach SmartArt‑Layout können Bilder in Aufzählungs‑Füllungen von Knoten oder in den Füllformaten von Knotenkörpern gespeichert sein.

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

## **Bilder in gruppierten Formen einbeziehen**

Gruppierte Formen enthalten eigene Formensammlungen. Der gemeinsam genutzte Hilfs‑`enumerateShapes`‑Helper verfügt über die Option `includeGroupedShapes`. Setzen Sie sie auf `true`, wenn Sie Formen innerhalb von [GroupShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/groupshape/)‑Objekten untersuchen möchten. Das untenstehende Beispiel extrahiert Bilder aus Bildrahmen, bildgefüllten Formen, OLE‑Objekt‑Vorschauen, Video‑Frame‑Miniaturansichten und Audio‑Frame‑Miniaturansichten. Um auch Tabellen-, Diagramm-, SmartArt- und Summary‑Zoom‑Bilder einzuschließen, verwenden Sie die spezialisierte Extraktionslogik aus den vorherigen Abschnitten und behalten dabei die gleiche rekursive Form‑Durchquerung bei.

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

## **Randfälle und praktische Hinweise**

- **Doppelte Bilder:** Mehrere Formen können auf dasselbe Bild verweisen oder separate Bilder mit identischen Bytes besitzen. Hashen Sie die [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/)‑Daten aus `getBinaryData()`, bevor Sie Dateien schreiben, falls Sie pro eindeutigem Bild eine Ausgabedatei möchten.
- **Originaldaten vs. konvertierte Ausgabe:** Das Speichern von [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/)‑Daten aus `getBinaryData()` bewahrt die eingebetteten JPEG‑, PNG‑, GIF‑, SVG‑, EMF‑ oder WMF‑Daten. Das Speichern des Bildes, das von `getImage()` zurückgegeben wird, ist nützlich, wenn Sie ein einheitliches Ausgabeformat wünschen.
- **Nicht unterstützte Fülltypen:** Solide, Verlauf-, Muster‑ und keine‑Füllung‑Formen enthalten keine Bildfüllung. Prüfen Sie [FillType](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/filltype/), bevor Sie `getPictureFillFormat()` lesen.
- **Gruppierte Formen:** Die oberste Formensammlung einer Folie flacht Gruppen nicht ab. Durchlaufen Sie den Inhalt von [GroupShape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/groupshape/) rekursiv über `getShapes()`, wenn gruppierter Inhalt wichtig ist.
- **OLE‑Objekt‑Vorschauen:** Ein [OleObjectFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/oleobjectframe/) kann ein Vorschau‑Bild über `getSubstitutePictureFormat()` bereitstellen, aber dieses Bild ist nur die Folien‑Vorschau. Es ist nicht die eingebettete Datei im OLE‑Objekt.
- **Video‑Frame‑Miniaturansichten:** Ein [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/) kann ein Vorschau‑Bild über `getPictureFormat()` bereitstellen, aber dieses Bild ist nur das Poster, das auf der Folie angezeigt wird. Es wird nicht aus dem Videostream extrahiert.
- **Audio‑Frame‑Miniaturansichten:** Ein [AudioFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/audioframe/) kann ein Symbol oder eine Miniatur über `getPictureFormat()` bereitstellen; es ist nicht das eingebettete Audiodaten.
- **Zoom‑Bilder:** Zoom‑, Abschnitts‑ und Summary‑Zoom‑Formen können benutzerdefinierte [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/)‑Objekte über `getZoomImage()` verwenden.
- **Verschachtelte Form‑Modelle:** Tabellen-, Diagramm- und SmartArt‑Objekte implementieren [Shape](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/shape/), aber ihre Bilder werden häufig in verschachtelten Tabellenzellen, Diagrammelementen oder SmartArt‑Knoten‑Formatierungsobjekten gespeichert.
- **Zugeschnittene oder transformierte Bilder:** Der Zugriff auf [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) liefert die gespeicherte Bildressource. Es werden keine Zuschneidungen, Transparenzen, Neu‑färbungen, Rotationen oder andere visuelle Effekte, die von der Form angewendet werden, gerendert.

## **FAQ**

**Kann ich das Originalbild ohne Zuschneiden, Effekte oder Form‑Transformationen extrahieren?**

Ja. Greifen Sie auf das [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/)‑Objekt zu und schreiben Sie die Daten aus `getBinaryData()` auf die Festplatte. Dies bewahrt das original kodierte Bild, das in der Präsentation gespeichert ist, und nicht die Art, wie das Bild auf der Folie gerendert wird.

**Kann ich jedes extrahierte Bild als PNG exportieren?**

Ja. Verwenden Sie [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) und dessen `getImage()`‑Methode und rufen Sie anschließend `save()` mit [ImageFormat](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/imageformat/) auf. Dadurch wird die Ausgabe konvertiert und der ursprüngliche Dateityp oder Vektordaten werden möglicherweise nicht erhalten.

**Wie vermeide ich, dass dasselbe Bild mehrmals gespeichert wird?**

Verwenden Sie einen Hash der [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/)‑Daten aus `getBinaryData()` und speichern Sie die Hashes in einer Menge. Wenn ein neues Bild einen bereits vorhandenen Hash hat, überspringen Sie es oder vermerken Sie eine weitere Referenz zur bestehenden Ausgabedatei.

**Warum erzeugen einige Formen kein Bild?**

Bildrahmen, bildgefüllte Formen, OLE‑Objekt‑Frames, Medien‑Frames, Zoom‑Frames, Tabellen, Diagramme und SmartArt‑Objekte können Bilder referenzieren. Einige Formtypen geben Bilder über verschachtelte Formatierungsobjekte frei, sodass eine einfache Prüfung von `getPictureFormat()` oder `getFillFormat()` nicht immer ausreicht.

**Kann ich die für einen Video‑Frame angezeigte Miniatur extrahieren?**

Ja. Verwenden Sie [VideoFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/videoframe/) und lesen Sie `getPictureFormat().getPicture().getImage()`. Dies extrahiert das Poster‑Bild, das mit dem Video‑Frame gespeichert ist, nicht ein aus der Videodatei generiertes Einzelbild.

**Wie kann ich feststellen, welche Formen ein bestimmtes Bild aus der Präsentations‑Bildsammlung verwenden?**

Aspose.Slides speichert keine Rückverweise von [PPImage](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/ppimage/) zu Formen. Bauen Sie während der Durchquerung eine Zuordnung auf: Immer wenn Sie eine Bildreferenz finden, notieren Sie die Foliennummer, den Formpfad und den Bild‑Hash oder das Sammlungs‑Element.

**Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, z. B. angehängte Dokumente?**

Sie können die Folien‑Vorschau des OLE‑Objekts aus [OleObjectFrame](https://reference.aspose.com/slides/de/nodejs-java/aspose.slides/oleobjectframe/) extrahieren. Diese Vorschau ist jedoch nicht das eingebettete Dokument selbst. Um Bilder aus der eingebetteten Datei zu extrahieren, müssen Sie die OLE‑Daten auslesen und mit geeigneten Werkzeugen für den jeweiligen Dateityp untersuchen.