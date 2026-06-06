---
title: Извлечение изображений из фигур презентации в Node.js
linktitle: Изображение из фигуры
type: docs
weight: 100
url: /ru/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- извлечь изображение
- получить изображение
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Извлеките изображения из фигур в презентациях PowerPoint и OpenDocument с помощью Aspose.Slides для Node.js через Java — быстрое, удобное для кода решение."
---
## **Обзор**

Изображения в презентации могут появляться в нескольких типах фигур: как обычные рамки картинок, как заливки изображениями, применённые к фигурам, как изображения предпросмотра объектов OLE, как миниатюры видеокадров или аудиокадров, как изображения масштабирования или как изображения, вложенные в формы таблиц, диаграмм и SmartArt. Aspose.Slides сохраняет эти изображения в коллекции изображений презентации, доступной через объекты [ImageCollection](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imagecollection/) и [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/).

Если вам нужно экспортировать каждый встроенный в презентацию ресурс изображения, пройдитесь по `presentation.getImages()`. Эта статья посвящена другой задаче: обходу фигур для поиска использованных на слайдах изображений, чтобы сохраняемые файлы могли содержать полезный контекст, такой как номер слайда, позиция фигуры и тип источника (рамка картинки, заливка изображением, предпросмотр медиа, предпросмотр OLE или изображение масштабирования).

{{% alert title="Tip" color="primary" %}}
Используйте [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) и его метод `getBinaryData()`, чтобы сохранить оригинальные закодированные данные изображения и тип файла. Используйте `getImage()`, когда нужно привести вывод к определённому формату, например PNG.
{{% /alert %}}

## **Общие вспомогательные методы**

Ниже приведённые вспомогательные методы позволяют сократить примеры. `saveOriginalImage` записывает оригинальные встроенные байты, выбирает безопасное расширение из MIME‑типа и пропускает дублирующие бинарные изображения по хэшу SHA‑256.

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

## **Извлечение изображений из рамок картинок**

Используйте этот подход для картинок, вставленных как отдельные объекты. [PictureFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/pictureframe/) хранит свою картинку в `getPictureFormat().getPicture().getImage()`, что возвращает объект [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/).

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

## **Извлечение изображений из фигур, залитых картинкой**

Фигуры могут использовать картинку в качестве заливки. Сначала проверьте тип заливки фигуры: если это не [FillType.Picture](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/), изображение из этой заливки извлекать нельзя. Пример ниже обрабатывает объекты [AutoShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/autoshape/) и сохраняет каждое изображение как PNG через [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) и его метод `getImage()`.

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

## **Извлечение изображений‑предпросмотра из рамок объектов OLE**

[OleObjectFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/oleobjectframe/) может иметь заменяющую картинку, которую PowerPoint использует как предпросмотр объекта на слайде. Это изображение доступно через `getSubstitutePictureFormat().getPicture().getImage()`. Извлечение этой картинки даёт вам изображение‑предпросмотр, а не содержимое встроенного пакета OLE.

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

## **Извлечение изображений‑предпросмотра из видеокадров**

[VideoFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/) также может хранить изображение‑предпросмотр в `getPictureFormat().getPicture().getImage()`. Это постер или миниатюра, отображаемая на слайде, а не кадр, декодированный из видеопотока.

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

## **Извлечение изображений‑предпросмотра из аудиокадров**

[AudioFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/) может хранить миниатюру в `getPictureFormat().getPicture().getImage()`. Это изображение, отображаемое для аудио‑объекта на слайде.

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

## **Извлечение изображений из объектов Zoom**

[ZoomFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/zoomframe/) и [SectionZoomFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sectionzoomframe/) могут использовать пользовательские изображения. Читайте `getZoomImage()` у соответствующего Zoom‑кадра.

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

## **Извлечение изображений из Summary Zoom Frames**

[SummaryZoomFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/summaryzoomframe/) также является фигурой. Его разделы могут использовать пользовательские изображения, доступные через метод `getZoomImage()` у каждого раздела.

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

## **Извлечение изображений из фигур таблиц**

[Table](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/table/) является фигурой. Изображения в таблице обычно хранятся как заливки картинками в ячейках таблицы.

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

## **Извлечение изображений из фигур диаграмм**

[Chart](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/chart/) является фигурой. Пример ниже извлекает изображение из заливки области диаграммы.

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

## **Извлечение изображений из фигур SmartArt**

[SmartArt](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/smartart/) является фигурой. В зависимости от макета SmartArt изображения могут храниться в заливках маркеров узлов или в форматах заливки фигур узлов.

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

## **Включение изображений внутри сгруппированных фигур**

Сгруппированные фигуры содержат собственные коллекции фигур. Общий вспомогательный метод `enumerateShapes` имеет параметр `includeGroupedShapes`. Установите его в `true`, если нужно исследовать фигуры внутри объектов [GroupShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/groupshape/). Пример ниже извлекает изображения из рамок картинок, фигур, залитых картинками, предпросмотров OLE‑объектов, миниатюр видеокадров и аудиокадров. Чтобы включить также изображения из таблиц, диаграмм, SmartArt и Summary Zoom, переиспользуйте специализированную логику извлечения из предыдущих разделов, сохраняя тот же рекурсивный обход фигур.

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

## **Особые случаи и практические замечания**

- **Дублирующие изображения:** Одни и те же изображения могут использовать несколько фигур или отдельные изображения с идентичным набором байтов. Хешируйте данные [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) из `getBinaryData()` перед записью файлов, если нужен один файл на уникальное изображение.
- **Исходные данные vs. преобразованный вывод:** Сохранение данных [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) из `getBinaryData()` сохраняет встроенные JPEG, PNG, GIF, SVG, EMF или WMF. Сохранение изображения, возвращаемого `getImage()`, удобно, когда нужен единый формат вывода.
- **Неподдерживаемые типы заливок:** Сплошные, градиентные, узорчатые и беззаливочные фигуры не содержат заливки картинкой. Проверьте [FillType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/filltype/) перед чтением `getPictureFillFormat()`.
- **Сгруппированные фигуры:** Коллекция фигур верхнего уровня слайда не «разглаживает» группы. Рекурсивно исследуйте содержимое [GroupShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/groupshape/) через `getShapes()`, когда важен сгруппированный контент.
- **Предпросмотры OLE‑объектов:** [OleObjectFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/oleobjectframe/) может раскрывать изображение‑предпросмотр через `getSubstitutePictureFormat()`, но это лишь предпросмотр слайда, а не встроенный файл внутри OLE‑объекта.
- **Миниатюры видеокадров:** [VideoFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/) может раскрывать изображение‑предпросмотр через `getPictureFormat()`, но это лишь постер, отображаемый на слайде, а не кадр, извлечённый из видеопотока.
- **Миниатюры аудиокадров:** [AudioFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audioframe/) может раскрывать иконку или миниатюру через `getPictureFormat()`; это не встроенные аудиоданные.
- **Изображения масштабирования:** Фигуры slide‑zoom, section‑zoom и summary‑zoom могут использовать пользовательские объекты [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) через `getZoomImage()`.
- **Вложенные модели фигур:** Объекты Table, Chart и SmartArt реализуют [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/), но их изображения часто хранятся в вложенных объектах форматирования ячеек таблицы, элементов диаграммы или узлов SmartArt.
- **Обрезанные или преобразованные изображения:** Доступ к [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) даёт вам хранимый ресурс изображения. Он не учитывает обрезку, прозрачность, перекраску, поворот или другие визуальные эффекты, применённые фигурой.

## **FAQ**

**Могу ли я извлечь оригинальное изображение без обрезки, эффектов или трансформаций фигуры?**

Да. Обратитесь к объекту [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) и запишите данные из `getBinaryData()` на диск. Это сохраняет оригинальное закодированное изображение, хранящееся в презентации, а не способ его отображения на слайде.

**Могу ли я экспортировать каждое извлечённое изображение как PNG?**

Да. Используйте [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) и его метод `getImage()`, затем вызовите `save()` с [ImageFormat](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/imageformat/). Это преобразует вывод и может не сохранять оригинальный тип файла или векторные данные.

**Как избежать многократного сохранения одного и того же изображения?**

Хешируйте данные [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) из `getBinaryData()` и храните хеши в наборе. Если новое изображение уже имеет существующий хеш, пропустите его или запишите другую ссылку на уже сохранённый файл.

**Почему некоторые фигуры не дают изображения?**

Рамки картинок, фигуры, залитые картинкой, OLE‑рамки, медиарямки, zoom‑рамки, таблицы, диаграммы и объекты SmartArt могут ссылаться на изображения. Некоторые типы фигур раскрывают изображения через вложенные объекты форматирования, поэтому простой вызов `getPictureFormat()` или `getFillFormat()` фигуры может быть недостаточным.

**Могу ли я извлечь миниатюру, показываемую для видеокадра?**

Да. Используйте [VideoFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/videoframe/) и прочтите `getPictureFormat().getPicture().getImage()`. Это извлекает постер‑изображение, хранящееся вместе с видеокадром, а не кадр, сгенерированный из видеофайла.

**Как определить, какие фигуры используют конкретное изображение из коллекции изображений презентации?**

Aspose.Slides не хранит обратные ссылки от [PPImage](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/ppimage/) к фигурам. Постройте отображение во время обхода: каждый раз, когда находите ссылку на изображение, фиксируйте номер слайда, путь к фигуре и хеш изображения или элемент коллекции.

**Могу ли я извлечь изображения, встроенные в OLE‑объекты, например вложенные документы?**

Вы можете извлечь предпросмотр OLE‑объекта с [OleObjectFrame](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/oleobjectframe/). Однако этот предпросмотр не является самим встроенным документом. Чтобы извлечь изображения из содержимого вложенного файла, извлеките данные OLE и изучите их с помощью соответствующих инструментов.