---
title: Estrai Immagini dalle Forme della Presentazione in Node.js
linktitle: Immagine da Forma
type: docs
weight: 100
url: /it/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- estrarre immagine
- recuperare immagine
- PowerPoint
- OpenDocument
- presentazione
- Node.js
- JavaScript
- Aspose.Slides
description: "Estrai immagini dalle forme nelle presentazioni PowerPoint e OpenDocument con Aspose.Slides per Node.js via Java - soluzione rapida e adatta al codice."
---
## **Panoramica**

Le immagini in una presentazione possono apparire in diversi tipi di forma: come normali riquadri immagine, come riempimenti immagine applicati alle forme, come immagini di anteprima di oggetti OLE, come miniature di fotogrammi video o audio, come immagini zoom o come immagini nidificate all'interno di tabelle, grafici e forme SmartArt. Aspose.Slides memorizza tali immagini nella raccolta di immagini della presentazione, esposta tramite gli oggetti [ImageCollection](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imagecollection/) e [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/).

Se hai solo bisogno di esportare ogni risorsa immagine incorporata in una presentazione, itera su `presentation.getImages()`. Questo articolo si concentra su un compito diverso: attraversare le forme per trovare dove le immagini sono utilizzate nelle diapositive, così i file salvati possono conservare contesto utile come il numero della diapositiva, la posizione della forma e il tipo di origine (riquadri immagine, immagine di riempimento, anteprima multimediale, anteprima OLE o immagine zoom).

{{% alert title="Tip" color="primary" %}}
Usa [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) e il suo metodo `getBinaryData()` per preservare i dati immagine codificati originali e il tipo di file. Usa `getImage()` quando vuoi normalizzare l'output in un formato specifico come PNG.
{{% /alert %}}

## **Metodi di Helper Condivisi**

I metodi helper di seguito mantengono gli esempi brevi. `saveOriginalImage` scrive i byte originali incorporati, sceglie un'estensione sicura dal tipo MIME e ignora i binari immagine duplicati tramite hash SHA-256.

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

## **Estrai Immagini dai Riquadri Immagine**

Utilizza questo approccio per le immagini inserite come oggetti autonomi. Un [PictureFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/pictureframe/) memorizza la sua immagine in `getPictureFormat().getPicture().getImage()`, che restituisce un oggetto [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/).

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

## **Estrai Immagini da Forme Riempite con Immagine**

Le forme possono utilizzare un'immagine come riempimento. Controlla prima il tipo di riempimento della forma: se non è [FillType.Picture](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/), non c'è alcuna immagine da estrarre da quel riempimento. L'esempio seguente gestisce gli oggetti [AutoShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/autoshape/) e salva ogni immagine come PNG tramite [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) e il suo metodo `getImage()`.

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

## **Estrai Immagini di Anteprima da Riquadri Oggetto OLE**

Un [OleObjectFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/oleobjectframe/) può avere un'immagine sostitutiva che PowerPoint utilizza come anteprima dell'oggetto sulla diapositiva. Questa immagine è disponibile tramite `getSubstitutePictureFormat().getPicture().getImage()`. Estrarre questa immagine fornisce l'anteprima, non il contenuto del pacchetto OLE incorporato.

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

## **Estrai Immagini di Anteprima da Fotogrammi Video**

Un [VideoFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/) può anche memorizzare un'immagine di anteprima in `getPictureFormat().getPicture().getImage()`. Questa è la locandina o miniatura mostrata sulla diapositiva, non un fotogramma decodificato dal flusso video.

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

## **Estrai Immagini di Anteprima da Fotogrammi Audio**

Un [AudioFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/) può memorizzare una miniatura in `getPictureFormat().getPicture().getImage()`. Questa è l'immagine mostrata per l'oggetto audio sulla diapositiva.

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

## **Estrai Immagini da Oggetti Zoom**

[ZoomFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/zoomframe/) e [SectionZoomFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/sectionzoomframe/) possono utilizzare immagini personalizzate. Leggi `getZoomImage()` dal riquadro zoom.

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

## **Estrai Immagini da Riquadri Zoom Riepilogo**

Un [SummaryZoomFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/summaryzoomframe/) è anch'esso una forma. I suoi elementi di sezione possono utilizzare immagini personalizzate, esposte tramite il metodo `getZoomImage()` di ciascuna sezione zoom di riepilogo.

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

## **Estrai Immagini da Forme Tabella**

Una [Table](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/table/) è una forma. Le immagini in una tabella sono solitamente memorizzate come riempimenti immagine nelle celle della tabella.

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

## **Estrai Immagini da Forme Grafico**

Un [Chart](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/chart/) è una forma. L'esempio seguente estrae un'immagine dal riempimento immagine dell'area del grafico.

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

## **Estrai Immagini da Forme SmartArt**

Un oggetto [SmartArt](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/smartart/) è una forma. A seconda del layout di SmartArt, le immagini possono essere memorizzate nei riempimenti dei punti elenco dei nodi o nei formati di riempimento delle forme dei nodi.

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

## **Includi Immagini all'Interno di Forme Raggruppate**

Le forme raggruppate contengono le proprie raccolte di forme. L'helper condiviso `enumerateShapes` dispone di un'opzione `includeGroupedShapes`. Impostala su `true` quando vuoi esaminare le forme all'interno di oggetti [GroupShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/groupshape/). L'esempio seguente estrae immagini da riquadri immagine, forme riempite con immagine, anteprime di oggetti OLE, miniature di fotogrammi video e miniature di fotogrammi audio. Per includere anche immagini di tabelle, grafici, SmartArt e zoom riepilogo, riutilizza la logica di estrazione specializzata dalle sezioni precedenti mantenendo la stessa traversata ricorsiva delle forme.

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

## **Casi Limite e Note Pratiche**

- **Immagini duplicate:** più forme possono fare riferimento alla stessa immagine o a immagini separate con byte identici. Esegui l'hash dei dati [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) tramite `getBinaryData()` prima di scrivere i file se desideri un file di output per ogni immagine unica.
- **Dati originali vs. output convertito:** salvare i dati [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) da `getBinaryData()` preserva i dati JPEG, PNG, GIF, SVG, EMF o WMF incorporati. Salvare l'immagine restituita da `getImage()` è utile quando vuoi un formato di output coerente.
- **Tipi di riempimento non supportati:** forme solide, con gradiente, pattern o senza riempimento non contengono un riempimento immagine. Controlla [FillType](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/filltype/) prima di leggere `getPictureFillFormat()`.
- **Forme raggruppate:** la raccolta di forme della diapositiva di livello superiore non appiattisce i gruppi. Ispeziona ricorsivamente il contenuto di [GroupShape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/groupshape/) tramite `getShapes()` quando il contenuto raggruppato è importante.
- **Anteprime oggetti OLE:** un [OleObjectFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/oleobjectframe/) può esporre un'immagine di anteprima tramite `getSubstitutePictureFormat()`, ma quell'immagine è solo l'anteprima della diapositiva. Non è il file incorporato all'interno dell'oggetto OLE.
- **Miniature fotogrammi video:** un [VideoFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/) può esporre un'immagine di anteprima tramite `getPictureFormat()`, ma quell'immagine è solo il poster mostrato sulla diapositiva. Non è estratta dal flusso video.
- **Miniature fotogrammi audio:** un [AudioFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/audioframe/) può esporre un'icona o miniatura tramite `getPictureFormat()`; non sono i dati audio incorporati.
- **Immagini zoom:** le forme di zoom diapositiva, zoom sezione e zoom riepilogo possono utilizzare oggetti [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) personalizzati tramite `getZoomImage()`.
- **Modelli di forme nidificate:** oggetti tabella, grafico e SmartArt implementano [Shape](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/shape/), ma le loro immagini sono spesso memorizzate in oggetti di formattazione nidificati di celle, elementi del grafico o nodi SmartArt.
- **Immagini ritagliate o trasformate:** accedere a [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) ti fornisce la risorsa immagine memorizzata. Non rende il ritaglio, la trasparenza, la recolorizzazione, la rotazione o altri effetti visivi applicati dalla forma.

## **FAQ**

**Posso estrarre l'immagine originale senza ritagli, effetti o trasformazioni della forma?**

Sì. Accedi all'oggetto [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) e scrivi i dati restituiti da `getBinaryData()` su disco. Questo preserva l'immagine codificata originale memorizzata nella presentazione, non il modo in cui l'immagine viene renderizzata sulla diapositiva.

**Posso esportare ogni immagine estratta come PNG?**

Sì. Usa [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) e il suo metodo `getImage()`, quindi chiama `save()` con [ImageFormat](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/imageformat/). Questo converte l'output e potrebbe non preservare il tipo di file originale o i dati vettoriali.

**Come evito di salvare la stessa immagine più di una volta?**

Usa un hash dei dati [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) ottenuti da `getBinaryData()` e tieni gli hash in un set. Se una nuova immagine ha un hash già presente, salta il salvataggio o registra un altro riferimento al file di output esistente.

**Perché alcune forme non producono un'immagine?**

Riquadri immagine, forme riempite con immagine, riquadri oggetto OLE, riquadri multimediali, riquadri zoom, tabelle, grafici e oggetti SmartArt possono fare riferimento a immagini. Alcuni tipi di forma espongono immagini attraverso oggetti di formattazione nidificati, quindi un semplice controllo `getPictureFormat()` o `getFillFormat()` della forma non è sempre sufficiente.

**Posso estrarre la miniatura mostrata per un fotogramma video?**

Sì. Usa [VideoFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/videoframe/) e leggi `getPictureFormat().getPicture().getImage()`. Questo estrae l'immagine poster memorizzata con il fotogramma video, non un fotogramma generato dal file video.

**Come posso determinare quali forme utilizzano una specifica immagine dalla raccolta di immagini della presentazione?**

Aspose.Slides non memorizza collegamenti inversi da [PPImage](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/ppimage/) a forme. Costruisci una mappatura durante la traversata: ogni volta che trovi un riferimento a un'immagine, registra il numero della diapositiva, il percorso della forma e l'hash o l'elemento della raccolta.

**Posso estrarre le immagini incorporate all'interno di oggetti OLE, come documenti allegati?**

Puoi estrarre l'anteprima della diapositiva dell'oggetto OLE da [OleObjectFrame](https://reference.aspose.com/slides/it/nodejs-java/aspose.slides/oleobjectframe/). Tuttavia, quell'anteprima non è il documento incorporato stesso. Per estrarre immagini da all'interno del file incorporato, estrai i dati OLE e analizzali con gli strumenti appropriati per quel tipo di file.