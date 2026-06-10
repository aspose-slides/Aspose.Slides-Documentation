---
title: Képek kinyerése prezentációs alakzatokból Node.js-ben
linktitle: Kép az alakzatról
type: docs
weight: 100
url: /hu/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- kép kinyerése
- kép lekérése
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Képek kinyerése PowerPoint és OpenDocument prezentációk alakzataiból az Aspose.Slides for Node.js via Java segítségével – gyors, kódbarát megoldás."
---
## **Áttekintés**

A prezentáció képei többféle alakzattípusban jelenhetnek meg: egyszerű képkeretként, alakzatokra alkalmazott képtöltésként, OLE‑objektum előnézeti képeként, videó‑ vagy hangkeret bélyegképeként, zoom képként vagy táblázat, diagram és SmartArt alakzatokba ágyazott képeként. Az Aspose.Slides ezeket a képeket a prezentáció képgyűjtésében tárolja, amely a [ImageCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imagecollection/) és a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) objektumokon keresztül érhető el.

Ha csak a prezentációba ágyazott minden képernyőforrást szeretné exportálni, iteráljon a `presentation.getImages()` felett. Ez a cikk egy másik feladatra összpontosít: alakzatok bejárása, hogy megtalálja, hol használják a képeket a diákon, így a mentett fájlok hasznos kontextust is megőriznek, például a dia számát, az alakzat pozícióját és a forrástípust (képkeret, kitöltő kép, média‑előnézet, OLE‑előnézet vagy zoom kép).

{{% alert title="Tip" color="primary" %}}
Használja a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) és annak `getBinaryData()` metódusát az eredeti kódolt képadatok és fájltípus megőrzéséhez. Használja a `getImage()` metódust, ha az outputot egy meghatározott formátumra, például PNG‑re szeretné normalizálni.
{{% /alert %}}

## **Megosztott segédfüggvények**

Az alábbi segédfüggvények röviden tartják a példákat. A `saveOriginalImage` az eredeti beágyazott bájtokat írja, a MIME‑típusról biztonságos kiterjesztést választ, és a SHA‑256 hash alapján kihagyja a duplikált képbiteket.

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

## **Képek kinyerése képkeretekből**

Ezt a megközelítést használja önálló objektumként beszúrt képekhez. Egy [PictureFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pictureframe/) a képet a `getPictureFormat().getPicture().getImage()` metódusában tárolja, amely egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) objektumot ad vissza.

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

## **Képtöltéssel kitöltött alakzatok képeinek kinyerése**

Az alakzatok képet használhatnak kitöltésükben. Először ellenőrizze az alakzat kitöltésének típusát: ha nem [FillType.Picture](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/), nincs kinyerhető kép ebből a kitöltésből. Az alábbi példa a [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumokat kezeli, és minden képet PNG‑ként ment a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) és a `getImage()` metódus segítségével.

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

## **Előnézeti képek kinyerése OLE‑objektum keretekből**

Egy [OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/oleobjectframe/) helyettesítő képet tartalmazhat, amelyet a PowerPoint az objektum előnézeteként használ a dián. Ez a kép a `getSubstitutePictureFormat().getPicture().getImage()` metóduson keresztül érhető el. Ennek a képnek a kinyerése az előnézeti képet adja, nem az OLE‑csomag beágyazott tartalmát.

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

## **Előnézeti képek kinyerése videokeretekből**

Egy [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) szintén tárolhat előnézeti képet a `getPictureFormat().getPicture().getImage()` metódusban. Ez a poszter vagy bélyegkép, amely a dián látható, nem egy a videófolyamból dekódolt keret.

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

## **Előnézeti képek kinyerése hangkeretekből**

Egy [AudioFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/) tárolhat bélyegképet a `getPictureFormat().getPicture().getImage()` metóduson keresztül. Ez a kép jelenik meg a hangobjektus mellett a dián.

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

## **Képek kinyerése zoom‑objektumokból**

A [ZoomFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zoomframe/) és a [SectionZoomFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sectionzoomframe/) alakzatok használhatnak egyéni képeket. Olvassa ki a `getZoomImage()` metódust a zoom‑keretből.

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

## **Képek kinyerése összegző zoom‑keretekből**

A [SummaryZoomFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/summaryzoomframe/) is egy alakzat. Szekcióelemei egyéni képeket használhatnak, amelyet a megfelelő összegző zoom‑szekció `getZoomImage()` metódusa biztosít.

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

## **Képek kinyerése táblázat‑alakzatokból**

A [Table](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/table/) egy alakzat. A táblázatban lévő képek általában a táblázat celláiban lévő képtöltésként vannak tárolva.

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

## **Képek kinyerése diagram‑alakzatokból**

A [Chart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/) egy alakzat. Az alábbi példa a diagramterület képtöltéséből nyer ki egy képet.

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

## **Képek kinyerése SmartArt‑alakzatokból**

Egy [SmartArt](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/smartart/) objektum alakzat. A SmartArt elrendezésétől függően a képek a csomópont golyó kitöltéseiben vagy a csomópont alakzatok kitöltési formátumaiban tárolódhatnak.

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

## **Képek bevonása csoportosított alakzatokba**

A csoportosított alakzatok saját alakzatgyűjteménnyel rendelkeznek. A megosztott `enumerateShapes` segédfüggvénynek van egy `includeGroupedShapes` beállítása. Állítsa `true`‑ra, ha a [GroupShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/groupshape/) objektumok belső alakzatait is vizsgálni szeretné. Az alábbi példa képeket nyer ki képkeretekből, képtöltéssel kitöltött alakzatokból, OLE‑objektum előnézeti képekből, videokeret bélyegképekből és hangkeret bélyegképekből. A táblázat, diagram, SmartArt és összegző zoom képek bevonásához használja újra az előző szakaszokban bemutatott speciális kinyerési logikát, miközben ugyanazt a rekurzív alakzatbejárást tartja meg.

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

## **Különleges esetek és gyakorlati megjegyzések**

- **Duplikált képek:** Több alakzat hivatkozhat ugyanarra a képre vagy különálló, azonos bájtokkal rendelkező képekre. Használja a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) adatainak SHA‑256 hash‑elését a fájlok írása előtt, ha egyedi képenként egy kimeneti fájlt szeretne.
- **Eredeti adatok vs. konvertált output:** A [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) adatainak `getBinaryData()` mentése megőrzi a beágyazott JPEG, PNG, GIF, SVG, EMF vagy WMF adatokat. A `getImage()` által visszaadott kép mentése akkor hasznos, ha egységes kimeneti formátumra, például PNG‑re van szükség.
- **Nem támogatott kitöltéstípusok:** Szilárd, színátmenetes, mintás és nincs kitöltésű alakzatok nem tartalmaznak képtöltést. Ellenőrizze a [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét, mielőtt a `getPictureFillFormat()` metódust hívná.
- **Csoportosított alakzatok:** A felső szintű dia‑alakzatgyűjtemény nem lapítja le a csoportokat. Rekurzívan vizsgálja a [GroupShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/groupshape/) tartalmát a `getShapes()` metódussal, ha a csoportosított tartalom lényeges.
- **OLE‑objektum előnézetek:** Egy [OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/oleobjectframe/) előnézeti képet adhat a `getSubstitutePictureFormat()` metódussal, de ez csak a dia‑előnézet; nem a beágyazott fájl.
- **Videokeret bélyegképek:** Egy [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) előnézeti képet adhat a `getPictureFormat()` metódussal, de ez csak a dián megjelenő poszter, nem a videófolyamból származó keret.
- **Hangkeret bélyegképek:** Egy [AudioFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/audioframe/) ikon vagy bélyegkép jelenhet meg a `getPictureFormat()` metódussal; ez nem a beágyazott hangadat.
- **Zoom‑képek:** Dia‑zoom, szekció‑zoom és összegző‑zoom alakzatok egyéni [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) objektumokat használhatnak a `getZoomImage()` metódussal.
- **Beágyazott alakzati modellek:** A táblázat, diagram és SmartArt objektumok mind [Shape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) típusúak, de képeik gyakran beágyazott táblacellák, diagram‑elemek vagy SmartArt‑csomópont formázási objektumaiban tárolódnak.
- **Vágott vagy transzformált képek:** A [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) elérése a tárolt képernyőforrást adja. Nem jeleníti meg a vágást, átlátszóságot, színezést, forgatást vagy más alakzatra alkalmazott vizuális hatásokat.

## **GYIK**

**Kivonhatom az eredeti képet vágás, effektus vagy alakzattranszformáció nélkül?**  
Igen. Hozzáférhet a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) objektumhoz, és a `getBinaryData()` adatokat lemezre írva megőrzi a prezentációban tárolt eredeti kódolt képet, nem azt, ahogyan a képet a dián megjeleníti.

**Exportálhatom az összes kinyert képet PNG‑ként?**  
Igen. Használja a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) és a `getImage()` metódusát, majd hívja a `save()`‑t a [ImageFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/imageformat/) segítségével. Ez konvertálja a kimenetet, és esetleg nem őrzi meg az eredeti fájltípust vagy vektoralapú adatot.

**Hogyan kerülhetem el ugyanazt a képet többször menteni?**  
Hash‑eljük a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) `getBinaryData()` adatát, és tároljuk a hash‑eket egy halmazban. Ha egy új kép hash‑e már létezik, ugorja át, vagy rögzítsen egy másik hivatkozást a már létező kimeneti fájlra.

**Miért nem minden alakzat ad ki képet?**  
Képkeretek, képtöltéssel kitöltött alakzatok, OLE‑objektum keretek, médiakeretek, zoom‑keretek, táblázatok, diagramok és SmartArt objektumok hivatkozhatnak képekre. Egyes alakzatok a képeket beágyazott formázási objektumokon keresztül jelenítik meg, így egy egyszerű `getPictureFormat()` vagy `getFillFormat()` ellenőrzés nem mindig elegendő.

**Kinyerhetem a videokerethez tartozó bélyegképet?**  
Igen. Használja a [VideoFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/videoframe/) objektumot, és olvassa ki a `getPictureFormat().getPicture().getImage()` metódust. Ez a videokerethez tárolt posztert adja, nem a videofájlból generált keretet.

**Meg tudom határozni, mely alakzatok használják a prezentáció képkollekciójából egy adott képet?**  
Az Aspose.Slides nem tárol visszacsatoló hivatkozásokat a [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) és az alakzatok között. A bejárás során építsen fel egy leképezést: minden képhivatkozásnál rögzítse a dia számát, az alakzat útvonalát és a kép hash‑ét vagy kollekcióelemet.

**Kinyerhetem az OLE‑objektumokba beágyazott képeket, például a csatolt dokumentumokból?**  
Kinyerheti az OLE‑objektum dia‑előnézetét a [OleObjectFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/oleobjectframe/)-ből. Azonban ez az előnézet nem a beágyazott dokumentum maga. Az OLE‑objektumon belüli képek kinyeréséhez először ki kell nyernie az OLE‑adatot, majd a megfelelő fájltípusú eszközökkel vizsgálnia kell.