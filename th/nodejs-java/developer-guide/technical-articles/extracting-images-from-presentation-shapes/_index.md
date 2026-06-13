---
title: สกัดภาพจากรูปทรงในงานนำเสนอด้วย Node.js
linktitle: ภาพจากรูปทรง
type: docs
weight: 100
url: /th/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- สกัดภาพ
- ดึงภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สกัดภาพจากรูปทรงในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java - โซลูชันที่รวดเร็วและเป็นมิตรกับโค้ด."
---
## **ภาพรวม**

Images in a presentation can appear in several shape types: as ordinary picture frames, as picture fills applied to shapes, as OLE object preview images, as video or audio frame thumbnails, as zoom images, or as images nested inside table, chart, and SmartArt shapes. Aspose.Slides stores those images in the presentation image collection, exposed through [ImageCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imagecollection/) and [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) objects.

If you only need to export every image resource embedded in a presentation, iterate through `presentation.getImages()`. This article focuses on a different task: traversing shapes to find where images are used on slides, so the saved files can keep useful context such as the slide number, shape position, and source type (picture frame, fill image, media preview, OLE preview, or zoom image).

{{% alert title="Tip" color="primary" %}}
Use [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) and its `getBinaryData()` method to preserve the original encoded image data and file type. Use `getImage()` when you want to normalize the output to a specific format such as PNG.
{{% /alert %}}

## **เมธอดช่วยเหลือที่ใช้ร่วมกัน**

The helper methods below keep the examples short. `saveOriginalImage` writes the original embedded bytes, chooses a safe extension from the MIME type, and skips duplicate image binaries by SHA‑256 hash.

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

## **สกัดภาพจากกรอบรูป**

Use this approach for pictures inserted as standalone objects. A [PictureFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/pictureframe/) stores its picture in `getPictureFormat().getPicture().getImage()`, which returns a [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) object.

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

## **สกัดภาพจากรูปทรงที่เติมด้วยรูปภาพ**

Shapes can use a picture as their fill. Check the shape's fill type first: if it is not [FillType.Picture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/), there is no picture to extract from that fill. The example below handles [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) objects and saves each image as PNG through [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) and its `getImage()` method.

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

## **สกัดภาพตัวอย่างจากกรอบอ็อบเจ็กต์ OLE**

An [OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/oleobjectframe/) can have a substitute picture that PowerPoint uses as the object's preview on a slide. This image is available through `getSubstitutePictureFormat().getPicture().getImage()`. Extracting this picture gives you the preview image, not the embedded OLE package contents.

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

## **สกัดภาพตัวอย่างจากกรอบวิดีโอ**

A [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) can also store a preview image in `getPictureFormat().getPicture().getImage()`. This is the poster or thumbnail shown on the slide, not a frame decoded from the video stream.

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

## **สกัดภาพตัวอย่างจากกรอบเสียง**

An [AudioFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/) can store a thumbnail in `getPictureFormat().getPicture().getImage()`. This is the image shown for the audio object on the slide.

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

## **สกัดภาพจากอ็อบเจ็กต์ซูม**

[ZoomFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/zoomframe/) and [SectionZoomFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sectionzoomframe/) shapes can use custom images. Read `getZoomImage()` from the zoom frame.

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

## **สกัดภาพจากกรอบซูมสรุป**

A [SummaryZoomFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/summaryzoomframe/) is also a shape. Its section items can use custom images, exposed through each summary zoom section's `getZoomImage()` method.

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

## **สกัดภาพจากรูปทรงตาราง**

A [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/table/) is a shape. Images in a table are usually stored as picture fills in table cells.

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

## **สกัดภาพจากรูปทรงแผนภูมิ**

A [Chart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/) is a shape. The example below extracts an image from the chart area's picture fill.

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

## **สกัดภาพจากรูปทรง SmartArt**

A [SmartArt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/smartart/) object is a shape. Depending on the SmartArt layout, images may be stored in node bullet fills or in the fill formats of node shapes.

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

## **รวมภาพที่อยู่ภายในรูปทรงที่จัดกลุ่ม**

Grouped shapes contain their own shape collections. The shared `enumerateShapes` helper has an `includeGroupedShapes` option. Set it to `true` when you want to inspect shapes inside [GroupShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/groupshape/) objects. The example below extracts images from picture frames, picture-filled shapes, OLE object previews, video frame thumbnails, and audio frame thumbnails. To include table, chart, SmartArt, and summary zoom images as well, reuse the specialized extraction logic from the previous sections while keeping the same recursive shape traversal.

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

## **กรณีขอบและหมายเหตุปฏิบัติ**

- **Duplicate images:** Multiple shapes may reference the same image or separate images with identical bytes. Hash [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) data from `getBinaryData()` before writing files if you want one output file per unique image.
- **Original data vs. converted output:** Saving [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) data from `getBinaryData()` preserves the embedded JPEG, PNG, GIF, SVG, EMF, or WMF data. Saving the image returned by `getImage()` is useful when you want a consistent output format.
- **Unsupported fill types:** Solid, gradient, pattern, and no-fill shapes do not contain a picture fill. Check [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) before reading `getPictureFillFormat()`.
- **Grouped shapes:** The top-level slide shape collection does not flatten groups. Recursively inspect [GroupShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/groupshape/) content through `getShapes()` when grouped content matters.
- **OLE object previews:** An [OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/oleobjectframe/) may expose a preview image through `getSubstitutePictureFormat()`, but that image is only the slide preview. It is not the embedded file inside the OLE object.
- **Video frame thumbnails:** A [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) may expose a preview image through `getPictureFormat()`, but that image is only the poster shown on the slide. It is not extracted from the video stream.
- **Audio frame thumbnails:** An [AudioFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audioframe/) may expose an icon or thumbnail through `getPictureFormat()`; it is not the embedded audio data.
- **Zoom images:** Slide zoom, section zoom, and summary zoom shapes may use custom [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) objects through `getZoomImage()`.
- **Nested shape models:** Table, chart, and SmartArt objects implement [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/), but their images are often stored in nested table cell, chart element, or SmartArt node formatting objects.
- **Cropped or transformed pictures:** Accessing [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) gives you the stored image resource. It does not render cropping, transparency, recoloring, rotation, or other visual effects applied by the shape.

## **คำถามที่พบบ่อย**

**Can I extract the original image without cropping, effects, or shape transformations?**

Yes. Access the [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) object and write the data from `getBinaryData()` to disk. This preserves the original encoded image stored in the presentation, not the way the image is rendered on the slide.

**Can I export every extracted image as PNG?**

Yes. Use [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) and its `getImage()` method, and then call `save()` with [ImageFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/imageformat/). This converts the output and may not preserve the original file type or vector data.

**How do I avoid saving the same image more than once?**

Use a hash of [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) data from `getBinaryData()` and keep the hashes in a set. If a new image has a hash that already exists, skip it or record another reference to the existing output file.

**Why do some shapes not produce an image?**

Picture frames, picture-filled shapes, OLE object frames, media frames, zoom frames, tables, charts, and SmartArt objects can reference images. Some shape types expose images through nested formatting objects, so a simple `getPictureFormat()` or shape `getFillFormat()` check is not always enough.

**Can I extract the thumbnail shown for a video frame?**

Yes. Use [VideoFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/videoframe/) and read `getPictureFormat().getPicture().getImage()`. This extracts the poster image stored with the video frame, not a frame generated from the video file.

**How can I determine which shapes use a specific image from the presentation image collection?**

Aspose.Slides does not store reverse links from [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) to shapes. Build a mapping during traversal: whenever you find an image reference, record the slide number, shape path, and image hash or collection item.

**Can I extract images embedded inside OLE objects, such as attached documents?**

You can extract the OLE object's slide preview from [OleObjectFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/oleobjectframe/). However, that preview is not the embedded document itself. To extract images from inside the embedded file, extract the OLE data and inspect it with tools for that file type.