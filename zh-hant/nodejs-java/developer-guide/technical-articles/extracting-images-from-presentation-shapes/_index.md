---
title: 從 Node.js 中的簡報形狀擷取影像
linktitle: 形狀中的影像
type: docs
weight: 100
url: /zh-hant/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- 擷取影像
- 取得影像
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 從 PowerPoint 和 OpenDocument 簡報中擷取形狀影像 - 快速、程式碼友善的解決方案。"
---
## **概觀**

演示文稿中的影像可以出現在多種形狀類型中：普通圖片框、套用於形狀的圖片填充、OLE 物件預覽圖像、影片或音訊框的縮圖、縮放圖像，或是嵌入於表格、圖表與 SmartArt 形狀內的影像。Aspose.Slides 會將這些影像儲存在演示文稿的影像集合中，可透過 [ImageCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imagecollection/) 與 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 物件存取。

如果您只需要匯出演示文稿中嵌入的每個影像資源，只要遍歷 `presentation.getImages()` 即可。本文聚焦於另一項任務：遍歷形狀以找出投影片上使用影像的位置，藉此在儲存檔案時保留投影片編號、形狀位置與來源類型（圖片框、填充影像、媒體預覽、OLE 預覽或縮放影像）的有用上下文。

{{% alert title="Tip" color="primary" %}}使用 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 及其 `getBinaryData()` 方法可保留原始編碼影像資料與檔案類型。若想將輸出正規化為特定格式（例如 PNG），請使用 `getImage()`。{{% /alert %}}

## **共用輔助方法**

以下的輔助方法讓範例保持簡潔。`saveOriginalImage` 會寫入原始嵌入位元組、依 MIME 類型選擇安全副檔名，並藉由 SHA-256 雜湊跳過重複的影像二進位資料。

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

## **從圖片框提取圖像**

此方法適用於作為獨立物件插入的圖片。一個 [PictureFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/pictureframe/) 會在 `getPictureFormat().getPicture().getImage()` 中保存其圖片，該方法回傳一個 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 物件。

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

## **從填充圖片的形狀提取圖像**

形狀可以使用圖片作為填充。首先檢查形狀的填充類型：如果不是 [FillType.Picture](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/)，則該填充不含可提取的圖片。以下範例處理 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 物件，並透過 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 及其 `getImage()` 方法將每張影像存為 PNG。

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

## **從 OLE 物件框提取預覽圖像**

[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/oleobjectframe/) 可以有一張替代圖片，PowerPoint 會在投影片上使用此圖片作為物件的預覽。此圖像可透過 `getSubstitutePictureFormat().getPicture().getImage()` 取得。提取此圖片會得到預覽圖像，而非嵌入的 OLE 套件內容。

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

## **從影片框提取預覽圖像**

[VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 也可以在 `getPictureFormat().getPicture().getImage()` 中存放預覽圖像。這是投影片上顯示的海報或縮圖，並非從影片串流解碼的影格。

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

## **從音訊框提取預覽圖像**

[AudioFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/) 可以在 `getPictureFormat().getPicture().getImage()` 中存放縮圖。這是投影片上顯示的音訊物件圖示。

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

## **從縮放物件提取圖像**

[ZoomFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/zoomframe/) 與 [SectionZoomFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/sectionzoomframe/) 形狀可使用自訂圖像。從縮放框讀取 `getZoomImage()`。

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

## **從摘要縮放框提取圖像**

[SummaryZoomFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/summaryzoomframe/) 也是一種形狀。其段落項目可以使用自訂圖像，透過每個摘要縮放段落的 `getZoomImage()` 方法取得。

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

## **從表格形狀提取圖像**

[Table](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/table/) 為形狀。表格中的影像通常以圖片填充的方式儲存在表格儲存格內。

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

## **從圖表形狀提取圖像**

[Chart](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/chart/) 為形狀。以下範例從圖表區域的圖片填充中提取影像。

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

## **從 SmartArt 形狀提取圖像**

[SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartart/) 物件是形狀。視 SmartArt 版面配置而定，影像可能儲存在節點項目的項目符號填充或節點形狀的填充格式中。

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

## **包括群組形狀內的圖像**

群組形狀擁有自己的形狀集合。共用的 `enumerateShapes` 輔助方法提供 `includeGroupedShapes` 選項。當需要檢查 [GroupShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/groupshape/) 物件內的形狀時，將其設為 `true`。以下範例從圖片框、填充圖片的形狀、OLE 物件預覽、影片框縮圖與音訊框縮圖中提取影像。若同時想包含表格、圖表、SmartArt 以及摘要縮放的影像，請重新使用前面章節的專用提取邏輯，並維持相同的遞迴形狀遍歷方式。

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

## **邊緣情況與實務說明**

- **Duplicate images:** 多個形狀可能參考相同的影像，或是不同的影像卻擁有相同的位元組。若希望每個唯一影像只輸出一次，請在寫檔前使用 `getBinaryData()` 取得的 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 資料計算 SHA‑256 雜湊。
- **Original data vs. converted output:** 從 `getBinaryData()` 儲存 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 資料會保留嵌入的 JPEG、PNG、GIF、SVG、EMF 或 WMF 資料。若使用 `getImage()` 取得的影像再呼叫 `save()` 並指定 [ImageFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imageformat/)，則會轉換為統一的輸出格式，可能會失去原始檔案類型或向量資料。
- **Unsupported fill types:** 實心、漸層、圖案與無填充的形狀不含圖片填充。讀取 `getPictureFillFormat()` 前，請先檢查 [FillType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/filltype/)。
- **Grouped shapes:** 投影片的頂層形狀集合不會自動展開群組。當群組內容很重要時，需遞迴透過 `getShapes()` 檢查 [GroupShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/groupshape/) 內的形狀。
- **OLE object previews:** [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/oleobjectframe/) 可能透過 `getSubstitutePictureFormat()` 提供預覽圖像，但該圖像僅為投影片上的預覽，並非 OLE 物件內嵌的檔案本身。
- **Video frame thumbnails:** [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 可能透過 `getPictureFormat()` 提供預覽圖像，該圖像僅為投影片上顯示的海報，並非從影片串流中抽取的影格。
- **Audio frame thumbnails:** [AudioFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/audioframe/) 可能透過 `getPictureFormat()` 暴露圖示或縮圖；這與嵌入的音訊資料無關。
- **Zoom images:** 投影片縮放、段落縮放與摘要縮放形狀可能使用自訂的 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 物件，透過 `getZoomImage()` 取得。
- **Nested shape models:** 表格、圖表與 SmartArt 物件皆實作 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/)，但它們的影像通常儲存在嵌套的表格儲存格、圖表元件或 SmartArt 節點的格式物件內。
- **Cropped or transformed pictures:** 直接存取 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 只能取得儲存的原始影像資源，無法呈現形狀套用的裁切、透明度、重新著色、旋轉或其他視覺效果。

## **常見問題**

**我可以在不裁剪、特效或形狀變換的情況下提取原始圖像嗎？**  
可以。存取 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 物件，將 `getBinaryData()` 取得的資料寫入磁碟即可。此作法保留了演示文稿中嵌入的原始編碼影像，而非投影片上呈現的方式。

**我可以將所有提取的圖像匯出為 PNG 嗎？**  
可以。使用 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 及其 `getImage()` 方法，然後以 [ImageFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/imageformat/) 呼叫 `save()`。此會將輸出轉換為 PNG，但可能不會保留原始檔案類型或向量資料。

**如何避免多次儲存相同的圖像？**  
對 `getBinaryData()` 取得的 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 資料計算雜湊，並在集合中保留已出現的雜湊值。若新影像的雜湊已存在，則跳過或僅記錄對現有輸出檔案的另一個參照。

**為什麼某些形狀未產生圖像？**  
圖片框、填充圖片的形狀、OLE 物件框、媒體框、縮放框、表格、圖表與 SmartArt 物件都可能參考影像。但某些形狀類型的影像是透過巢狀的格式物件暴露的，單純檢查 `getPictureFormat()` 或形狀的 `getFillFormat()` 並不足以捕捉所有情況。

**我可以提取影片框顯示的縮圖嗎？**  
可以。使用 [VideoFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/videoframe/) 並讀取 `getPictureFormat().getPicture().getImage()`。此會提取與影片框一起儲存的海報圖像，而非從影片檔案產生的影格。

**我該如何判斷哪些形狀使用演示文稿圖像集合中的特定圖像？**  
Aspose.Slides 不會保存從 [PPImage](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ppimage/) 返回至形狀的反向連結。遍歷時自行建立映射：每當找到影像參考時，記錄投影片編號、形狀路徑以及影像的雜湊或集合項目。

**我可以提取嵌入 OLE 物件（如附加文件）內的圖像嗎？**  
您可以從 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/oleobjectframe/) 提取其在投影片上的預覽圖像。但該預覽圖像並非嵌入的文件本身。若要從嵌入的檔案中提取圖像，需要先將 OLE 資料解壓，然後使用相應檔案類型的工具進行檢查。