---
title: Wyodrębnianie obrazów z kształtów prezentacji w Node.js
linktitle: Obraz z kształtu
type: docs
weight: 100
url: /pl/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- wyodrębnić obraz
- pobrać obraz
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Wyodrębnij obrazy z kształtów w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js poprzez Java - szybkie, przyjazne rozwiązanie dla kodu."
---
## **Przegląd**

Obrazy w prezentacji mogą występować w kilku typach kształtów: jako zwykłe ramki obrazu, jako wypełnienia obrazu zastosowane do kształtów, jako podglądowe obrazy obiektów OLE, jako miniatury klatek wideo lub audio, jako obrazy powiększenia lub jako obrazy zagnieżdżone wewnątrz kształtów tabeli, wykresu i SmartArt. Aspose.Slides przechowuje te obrazy w kolekcji obrazów prezentacji, udostępnianej przez [ImageCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagecollection/) i obiekty [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/).

Jeśli potrzebujesz wyeksportować każdy zasób obrazu osadzonego w prezentacji, iteruj po `presentation.getImages()`. Ten artykuł koncentruje się na innym zadaniu: przeszukiwaniu kształtów w celu znalezienia, gdzie obrazy są używane na slajdach, aby zapisane pliki mogły zachować przydatny kontekst, taki jak numer slajdu, pozycja kształtu i typ źródła (ramka obrazu, wypełnienie obrazu, podgląd multimediów, podgląd OLE lub obraz powiększenia).

{{% alert title="Tip" color="primary" %}}
Użyj [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) i jego metody `getBinaryData()` aby zachować oryginalnie zakodowane dane obrazu i typ pliku. Użyj `getImage()`, gdy chcesz znormalizować wyjście do konkretnego formatu, takiego jak PNG.
{{% /alert %}}

## **Wspólne metody pomocnicze**

Poniższe metody pomocnicze skracają przykłady. `saveOriginalImage` zapisuje oryginalne osadzone bajty, wybiera bezpieczne rozszerzenie na podstawie typu MIME i pomija duplikaty binarne obrazu na podstawie skrótu SHA‑256.

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

## **Ekstrahowanie obrazów z ramek obrazu**

Użyj tego podejścia dla obrazów wstawionych jako samodzielne obiekty. [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) przechowuje swój obraz w `getPictureFormat().getPicture().getImage()`, co zwraca obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/).

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

## **Ekstrahowanie obrazów z kształtów wypełnionych obrazem**

Kształty mogą używać obrazu jako wypełnienia. Najpierw sprawdź typ wypełnienia kształtu: jeśli nie jest to [FillType.Picture](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/), nie ma obrazu do ekstrakcji z tego wypełnienia. Poniższy przykład obsługuje obiekty [AutoShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/autoshape/) i zapisuje każdy obraz jako PNG przy użyciu [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) i jego metody `getImage()`.

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

## **Ekstrahowanie podglądowych obrazów z ramek obiektów OLE**

[OleObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/oleobjectframe/) może mieć zastępczy obraz, którego PowerPoint używa jako podgląd obiektu na slajdzie. Ten obraz jest dostępny przez `getSubstitutePictureFormat().getPicture().getImage()`. Ekstrahowanie tego obrazu daje podgląd, a nie zawartość osadzonego pakietu OLE.

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

## **Ekstrahowanie podglądowych obrazów z ramek wideo**

[VideoFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/) może także przechowywać obraz podglądu w `getPictureFormat().getPicture().getImage()`. Jest to plakat lub miniatura wyświetlana na slajdzie, a nie klatka z dekodowanego strumienia wideo.

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

## **Ekstrahowanie podglądowych obrazów z ramek audio**

[AudioFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/) może przechowywać miniaturę w `getPictureFormat().getPicture().getImage()`. To obraz wyświetlany dla obiektu audio na slajdzie.

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

## **Ekstrahowanie obrazów z obiektów Zoom**

Kształty [ZoomFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/zoomframe/) i [SectionZoomFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sectionzoomframe/) mogą używać własnych obrazów. Odczytaj `getZoomImage()` z ramki powiększenia.

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

## **Ekstrahowanie obrazów z ramek podsumowujących Zoom**

[SummaryZoomFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/summaryzoomframe/) jest również kształtem. Jego elementy sekcji mogą używać własnych obrazów, udostępnionych przez metodę `getZoomImage()` każdego elementu sekcji podsumowującego Zoom.

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

## **Ekstrahowanie obrazów z kształtów tabel**

[Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/table/) jest kształtem. Obrazy w tabeli są zazwyczaj przechowywane jako wypełnienia obrazu w komórkach tabeli.

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

## **Ekstrahowanie obrazów z kształtów wykresów**

[Chart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/chart/) jest kształtem. Poniższy przykład ekstraktuje obraz z wypełnienia obrazu obszaru wykresu.

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

## **Ekstrahowanie obrazów z kształtów SmartArt**

[SmartArt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/smartart/) jest obiektem‑kształtem. W zależności od układu SmartArt obrazy mogą być przechowywane w wypełnieniach punktorów węzła lub w formatach wypełnienia kształtów węzła.

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

## **Dołączanie obrazów wewnątrz grupowanych kształtów**

Grupowane kształty zawierają własne kolekcje kształtów. Wspólna metoda pomocnicza `enumerateShapes` ma opcję `includeGroupedShapes`. Ustaw ją na `true`, gdy chcesz sprawdzić kształty wewnątrz obiektów [GroupShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/groupshape/). Poniższy przykład ekstraktuje obrazy z ramek obrazu, kształtów wypełnionych obrazem, podglądów obiektów OLE, miniatur klatek wideo i miniatur ramek audio. Aby dołączyć obrazy tabel, wykresów, SmartArt i podsumowujących Zoom, ponownie użyj specjalistycznej logiki ekstrakcji z poprzednich sekcji, zachowując tę samą rekurencyjną iterację kształtów.

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

## **Przypadki brzegowe i praktyczne uwagi**

- **Duplikaty obrazów:** Wiele kształtów może odwoływać się do tego samego obrazu lub do oddzielnych obrazów o identycznych bajtach. Oblicz skrót [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) danych z `getBinaryData()` przed zapisem plików, jeśli chcesz jeden plik wyjściowy na każdy unikalny obraz.
- **Dane oryginalne vs. konwertowany wynik:** Zapis danych [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) z `getBinaryData()` zachowuje osadzony JPEG, PNG, GIF, SVG, EMF lub WMF. Zapis obrazu zwróconego przez `getImage()` jest przydatny, gdy potrzebny jest spójny format wyjściowy.
- **Nieobsługiwane typy wypełnień:** Kształty o wypełnieniu stałym, gradientowym, wzorowanym lub bez wypełnienia nie zawierają obrazu wypełnienia. Sprawdź [FillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) przed odczytem `getPictureFillFormat()`.
- **Grupowane kształty:** Górna kolekcja kształtów slajdu nie spłaszcza grup. Rekurencyjnie przeglądaj zawartość [GroupShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/groupshape/) przez `getShapes()`, gdy grupowana zawartość ma znaczenie.
- **Podglądy obiektów OLE:** [OleObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/oleobjectframe/) może udostępniać obraz podglądu przez `getSubstitutePictureFormat()`, ale jest to jedynie podgląd slajdu, nie osadzony plik w obiekcie OLE.
- **Miniatury klatek wideo:** [VideoFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/) może udostępniać obraz podglądu przez `getPictureFormat()`, ale jest to jedynie plakat wyświetlany na slajdzie, nie klatka wyodrębniona ze strumienia wideo.
- **Miniatury ramek audio:** [AudioFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audioframe/) może udostępniać ikonę lub miniaturę przez `getPictureFormat()`; nie jest to osadzony dźwięk.
- **Obrazy powiększenia:** Kształty Zoom, SectionZoom i SummaryZoom mogą używać własnych obiektów [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) poprzez `getZoomImage()`.
- **Zagnieżdżone modele kształtów:** Obiekty tabel, wykresów i SmartArt implementują [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/), ale ich obrazy są często przechowywane w zagnieżdżonych obiektach formatowania komórek, elementów wykresu lub węzłów SmartArt.
- **Obrazy przycięte lub przekształcone:** Dostęp do [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) daje zasób obrazu zapisany w pliku. Nie renderuje ona przycięć, przezroczystości, przekolorowań, rotacji ani innych efektów wizualnych zastosowanych przez kształt.

## **FAQ**

**Czy mogę wyodrębnić oryginalny obraz bez przycinania, efektów lub przekształceń kształtu?**

Tak. Uzyskaj obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) i zapisz dane z `getBinaryData()` na dysk. Zachowuje to oryginalnie zakodowany obraz przechowywany w prezentacji, a nie sposób jego renderowania na slajdzie.

**Czy mogę wyeksportować każdy wyodrębniony obraz jako PNG?**

Tak. Użyj [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) i jego metody `getImage()`, a następnie wywołaj `save()` z [ImageFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imageformat/). To konwertuje wynik i może nie zachować oryginalnego typu pliku ani danych wektorowych.

**Jak uniknąć zapisywania tego samego obrazu więcej niż raz?**

Użyj skrótu danych [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) z `getBinaryData()` i przechowuj skróty w zbiorze. Jeśli nowy obraz ma już istniejący skrót, pomiń go lub zarejestruj kolejne odniesienie do istniejącego pliku wyjściowego.

**Dlaczego niektóre kształty nie generują obrazu?**

Ramki obrazu, kształty wypełnione obrazem, ramki obiektów OLE, ramki multimediów, ramki powiększenia, tabele, wykresy i obiekty SmartArt mogą odwoływać się do obrazów. Niektóre typy kształtów udostępniają obrazy poprzez zagnieżdżone obiekty formatowania, więc proste sprawdzenie `getPictureFormat()` lub `getFillFormat()` nie zawsze wystarczy.

**Czy mogę wyodrębnić miniaturę wyświetlaną dla ramki wideo?**

Tak. Użyj [VideoFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/) i odczytaj `getPictureFormat().getPicture().getImage()`. To wyodrębnia plakat przechowywany razem z ramką wideo, a nie klatkę wygenerowaną z pliku wideo.

**Jak określić, które kształty używają konkretnego obrazu z kolekcji obrazów prezentacji?**

Aspose.Slides nie przechowuje odwróconych linków od [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) do kształtów. Zbuduj mapowanie podczas traversowania: za każdym razem, gdy znajdziesz odwołanie do obrazu, zanotuj numer slajdu, ścieżkę kształtu oraz hash lub element kolekcji obrazu.

**Czy mogę wyodrębnić obrazy osadzone wewnątrz obiektów OLE, takie jak załączone dokumenty?**

Możesz wyodrębnić podgląd slajdu obiektu OLE z [OleObjectFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/oleobjectframe/). Jednak podgląd ten nie jest osadzonym dokumentem. Aby wyodrębnić obrazy z wnętrza pliku osadzonego, wyodrębnij dane OLE i przeanalizuj je odpowiednimi narzędziami dla danego typu pliku.