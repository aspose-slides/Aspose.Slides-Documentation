---
title: Extrahovat obrázky z tvarů v prezentaci v Node.js
linktitle: Obrázek z tvaru
type: docs
weight: 100
url: /cs/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- extrahovat obrázek
- získat obrázek
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Extrahovat obrázky z tvarů v prezentacích PowerPoint a OpenDocument s Aspose.Slides pro Node.js pomocí Java - rychlé, kódem přátelské řešení."
---
## **Přehled**

Obrázky v prezentaci se mohou vyskytovat v několika typech tvarů: jako obyčejné rámečky obrázků, jako výplně obrázky aplikované na tvary, jako náhledové obrázky OLE objektů, jako miniatury video‑ nebo audio‑rámců, jako zoom obrázky nebo jako obrázky vnořené uvnitř tabulek, grafů a tvarů SmartArt. Aspose.Slides ukládá tyto obrázky do kolekce obrázků prezentace, která je zpřístupněna prostřednictvím objektů [ImageCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imagecollection/) a [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/).

Pokud potřebujete pouze exportovat všechny obrázkové zdroje vložené v prezentaci, procházejte `presentation.getImages()`. Tento článek se zaměřuje na jiný úkol: procházet tvary a najít, kde jsou na snímcích použity obrázky, aby uložené soubory mohly zachovat užitečný kontext, jako je číslo snímku, pozice tvaru a typ zdroje (rámec obrázku, výplň obrázkem, náhled média, náhled OLE nebo zoom obrázek).

{{% alert title="Tip" color="primary" %}}
Použijte [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) a jeho metodu `getBinaryData()` k zachování původních kódovaných dat obrázku a typu souboru. Použijte `getImage()`, pokud chcete normalizovat výstup do konkrétního formátu, například PNG.
{{% /alert %}}

## **Společné pomocné metody**

Níže uvedené pomocné metody zkracují příklady. `saveOriginalImage` zapisuje původní vložené bajty, vybírá bezpečnou příponu podle MIME typu a přeskočuje duplicitní binární obrázky pomocí SHA-256 hash.

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

## **Extrahovat obrázky z rámečků obrázků**

Použijte tento postup pro obrázky vložené jako samostatné objekty. Objekt [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) ukládá svůj obrázek v `getPictureFormat().getPicture().getImage()`, což vrací objekt [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/).

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

## **Extrahovat obrázky z tvarů s výplní obrázkem**

Tvary mohou používat obrázek jako výplň. Nejprve zkontrolujte typ výplně tvaru: pokud není [FillType.Picture](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/), není z výplně co extrahovat. Níže uvedený příklad pracuje s objekty [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape/) a ukládá každý obrázek jako PNG pomocí [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) a jeho metody `getImage()`.

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

## **Extrahovat náhledové obrázky z OLE objektových rámců**

Objekt [OleObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/oleobjectframe/) může mít náhradní obrázek, který PowerPoint používá jako náhled objektu na snímku. Tento obrázek je dostupný přes `getSubstitutePictureFormat().getPicture().getImage()`. Extrahováním tohoto obrázku získáte náhledový obraz, nikoli vložený obsah OLE balíčku.

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

## **Extrahovat náhledové obrázky z video rámců**

Objekt [VideoFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/) může také uložit náhledový obrázek v `getPictureFormat().getPicture().getImage()`. Jedná se o plakát nebo miniaturu zobrazenou na snímku, nikoli o rámec dekódovaný z video proudu.

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

## **Extrahovat náhledové obrázky z audio rámců**

Objekt [AudioFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/) může uložit miniaturu v `getPictureFormat().getPicture().getImage()`. Jedná se o obrázek zobrazený pro audio objekt na snímku.

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

## **Extrahovat obrázky ze zoom objektů**

Tvary [ZoomFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/zoomframe/) a [SectionZoomFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sectionzoomframe/) mohou používat vlastní obrázky. Přečtěte `getZoomImage()` ze zoom rámce.

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

## **Extrahovat obrázky ze souhrnných zoom rámců**

Objekt [SummaryZoomFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/summaryzoomframe/) je také tvarem. Jeho sekční položky mohou používat vlastní obrázky, které jsou zpřístupněny prostřednictvím metody `getZoomImage()` každé sekce souhrnného zoomu.

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

## **Extrahovat obrázky z tabulkových tvarů**

Objekt [Table](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/table/) je tvarem. Obrázky v tabulce jsou obvykle uloženy jako výplně obrázkem v buňkách tabulky.

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

## **Extrahovat obrázky z grafových tvarů**

Objekt [Chart](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/chart/) je tvarem. Níže uvedený příklad extrahuje obrázek z výplně obrázkem oblasti grafu.

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

## **Extrahovat obrázky z SmartArt tvarů**

Objekt [SmartArt](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/smartart/) je tvarem. V závislosti na rozvržení SmartArt mohou být obrázky uloženy buď ve výplních odrážek uzlů, nebo ve výplních tvarů uzlů.

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

## **Zahrnout obrázky uvnitř seskupených tvarů**

Seskupené tvary obsahují své vlastní kolekce tvarů. Sdílený pomocník `enumerateShapes` má volbu `includeGroupedShapes`. Nastavte ji na `true`, když chcete prozkoumat tvary uvnitř objektů [GroupShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/groupshape/). Níže uvedený příklad extrahuje obrázky z rámečků obrázků, tvarů s výplní obrázkem, náhledů OLE objektů, miniatur video rámců a miniatur audio rámců. Pro zahrnutí také obrázků z tabulek, grafů, SmartArt a souhrnných zoomů opakujte specializovanou logiku extrakce z předchozích sekcí při zachování stejného rekurzivního procházení tvarů.

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

## **Okrajové případy a praktické poznámky**

- **Duplicitní obrázky:** Více tvarů může odkazovat na stejný obrázek nebo na různé obrázky se stejnými bajty. Před zápisem souborů vytvořte hash dat [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) získaných pomocí `getBinaryData()`, pokud chcete jeden výstupní soubor na unikátní obrázek.
- **Originální data vs. konvertovaný výstup:** Ukládání dat [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) pomocí `getBinaryData()` zachovává vložená data JPEG, PNG, GIF, SVG, EMF nebo WMF. Ukládání obrázku vráceného metodou `getImage()` je užitečné, když potřebujete konzistentní výstupní formát.
- **Ne podporované typy výplní:** Tvary s výplní solid, gradient, pattern a bez výplně neobsahují obrázek. Před čtením `getPictureFillFormat()` zkontrolujte [FillType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/filltype/).
- **Seskupené tvary:** Kolekce tvarů na úrovni snímku neflattenuje skupiny. Rekurzivně prozkoumejte obsah [GroupShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/groupshape/) pomocí `getShapes()`, pokud je seskupený obsah relevantní.
- **Náhledy OLE objektů:** [OleObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/oleobjectframe/) může zpřístupnit náhledový obrázek přes `getSubstitutePictureFormat()`, ale tento obrázek je jen náhled na snímku. Nejedná se o vložený soubor uvnitř OLE objektu.
- **Miniatury video rámců:** [VideoFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/) může zpřístupnit náhledový obrázek přes `getPictureFormat()`, ale tento obrázek je jen plakát zobrazený na snímku. Nejedná se o extrahovaný rámec z video proudu.
- **Miniatury audio rámců:** [AudioFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/audioframe/) může zpřístupnit ikonu nebo miniaturu přes `getPictureFormat()`; nejde o vložená audio data.
- **Zoom obrázky:** Tvary slide zoom, section zoom a summary zoom mohou používat vlastní objekty [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) přes `getZoomImage()`.
- **Vnořené modely tvarů:** Objektům Table, Chart a SmartArt implementuje rozhraní [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/), ale jejich obrázky jsou často uloženy v vnořených buňkách tabulky, prvcích grafu nebo formátovacích objektech uzlů SmartArt.
- **Oříznuté nebo transformované obrázky:** Přístup k [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) vám poskytne uložený obrázkový zdroj. Nezahrnuje ořez, průhlednost, přeobarvení, rotaci nebo jiné vizuální efekty aplikované tvarem.

## **FAQ**

**Mohu extrahovat původní obrázek bez ořezu, efektů nebo transformací tvaru?**

Ano. Přistupte k objektu [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) a zapište data z `getBinaryData()` na disk. Tím se zachová původní kódovaný obrázek uložený v prezentaci, nikoli způsob, jakým je obrázek vykreslen na snímku.

**Mohu exportovat každý extrahovaný obrázek jako PNG?**

Ano. Použijte [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) a jeho metodu `getImage()`, poté zavolejte `save()` s [ImageFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/imageformat/). To převádí výstup a nemusí zachovat původní typ souboru ani vektorová data.

**Jak zabránit vícenásobnému uložení stejného obrázku?**

Vytvořte hash dat [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) získaných pomocí `getBinaryData()` a udržujte hash v množině. Pokud nový obrázek má hash, který již existuje, přeskočte jej nebo zaznamenejte další odkaz na existující výstupní soubor.

**Proč některé tvary neprodukují žádný obrázek?**

Rámečky obrázků, tvary s výplní obrázkem, OLE objektové rámce, mediální rámce, zoom rámce, tabulky, grafy a SmartArt objekty mohou odkazovat na obrázky. Některé typy tvarů exposují obrázky prostřednictvím vnořených formátovacích objektů, takže kontrola pouze `getPictureFormat()` nebo `getFillFormat()` nemusí být vždy dostatečná.

**Mohu extrahovat miniaturu zobrazenou pro video rámec?**

Ano. Použijte [VideoFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/videoframe/) a přečtěte `getPictureFormat().getPicture().getImage()`. Tím získáte plakátový obrázek uložený s video rámcem, ne rámec vygenerovaný z video souboru.

**Jak mohu určit, které tvary používají konkrétní obrázek z kolekce obrázků prezentace?**

Aspose.Slides neukládá zpětné odkazy z [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ppimage/) na tvary. Během procházení vytvořte mapu: kdykoli najdete odkaz na obrázek, zaznamenejte číslo snímku, cestu k tvaru a hash nebo položku kolekce.

**Mohu extrahovat obrázky vložené uvnitř OLE objektů, například připojené dokumenty?**

Můžete extrahovat náhled OLE objektu z [OleObjectFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/oleobjectframe/). Tento náhled však není samotný vložený dokument. Pro extrahování obrázků uvnitř vloženého souboru je třeba extrahovat OLE data a prozkoumat je pomocí nástrojů určených pro daný typ souboru.