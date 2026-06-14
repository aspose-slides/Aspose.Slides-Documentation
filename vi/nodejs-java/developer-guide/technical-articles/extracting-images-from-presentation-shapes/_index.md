---
title: Trích xuất hình ảnh từ các hình dạng trong bản trình chiếu bằng Node.js
linktitle: Hình ảnh từ Hình dạng
type: docs
weight: 100
url: /vi/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- trích xuất hình ảnh
- lấy hình ảnh
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Trích xuất hình ảnh từ các hình dạng trong bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js qua Java - giải pháp nhanh, thân thiện với mã."
---
## **Tổng quan**

Hình ảnh trong một bản trình chiếu có thể xuất hiện trong nhiều loại hình dạng: dưới dạng khung ảnh thông thường, dưới dạng hình ảnh nền được áp dụng cho các hình dạng, dưới dạng hình ảnh xem trước đối tượng OLE, dưới dạng hình thu nhỏ khung video hoặc âm thanh, dưới dạng hình ảnh thu phóng, hoặc dưới dạng hình ảnh lồng trong các hình dạng bảng, biểu đồ và SmartArt. Aspose.Slides lưu trữ các hình ảnh này trong bộ sưu tập hình ảnh của bản trình chiếu, được truy cập thông qua các đối tượng [ImageCollection](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imagecollection/) và [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/).

Nếu bạn chỉ cần xuất mọi tài nguyên hình ảnh được nhúng trong bản trình chiếu, duyệt qua `presentation.getImages()`. Bài viết này tập trung vào một nhiệm vụ khác: duyệt các hình dạng để tìm nơi hình ảnh được sử dụng trên các slide, để các tệp đã lưu có thể giữ ngữ cảnh hữu ích như số slide, vị trí hình dạng và loại nguồn (khung ảnh, hình ảnh nền, xem trước media, xem trước OLE hoặc hình ảnh thu phóng).

{{% alert title="Tip" color="primary" %}}
Sử dụng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) và phương thức `getBinaryData()` của nó để bảo toàn dữ liệu hình ảnh đã mã hoá gốc và loại tệp. Sử dụng `getImage()` khi bạn muốn chuẩn hoá đầu ra sang định dạng cụ thể như PNG.
{{% /alert %}}

## **Phương thức trợ giúp chung**

Các phương thức trợ giúp dưới đây giúp các ví dụ ngắn gọn. `saveOriginalImage` ghi các byte nhúng gốc, chọn phần mở rộng an toàn từ MIME type, và bỏ qua các nhị phân hình ảnh trùng lặp bằng hàm băm SHA‑256.

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

## **Trích xuất hình ảnh từ khung ảnh**

Sử dụng cách tiếp cận này cho các ảnh được chèn dưới dạng đối tượng độc lập. Một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) lưu trữ ảnh của nó trong `getPictureFormat().getPicture().getImage()`, trả về một đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/).

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

## **Trích xuất hình ảnh từ các hình dạng được nền ảnh**

Các hình dạng có thể sử dụng hình ảnh làm nền. Kiểm tra loại nền của hình dạng trước: nếu không phải là [FillType.Picture](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/), thì không có ảnh nào để trích xuất từ nền đó. Ví dụ dưới đây xử lý các đối tượng [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape/) và lưu mỗi hình ảnh dưới dạng PNG thông qua [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) và phương thức `getImage()` của nó.

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

## **Trích xuất hình ảnh xem trước từ khung đối tượng OLE**

Một [OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/oleobjectframe/) có thể có một ảnh thay thế mà PowerPoint sử dụng làm xem trước của đối tượng trên slide. Ảnh này có sẵn qua `getSubstitutePictureFormat().getPicture().getImage()`. Trích xuất ảnh này sẽ cho bạn hình ảnh xem trước, không phải nội dung gói OLE được nhúng.

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

## **Trích xuất hình ảnh xem trước từ khung video**

Một [VideoFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/) cũng có thể lưu trữ một ảnh xem trước trong `getPictureFormat().getPicture().getImage()`. Đây là poster hoặc thumbnail hiển thị trên slide, không phải một khung được giải mã từ luồng video.

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

## **Trích xuất hình ảnh xem trước từ khung âm thanh**

Một [AudioFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/) có thể lưu trữ một thumbnail trong `getPictureFormat().getPicture().getImage()`. Đây là ảnh hiển thị cho đối tượng âm thanh trên slide.

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

## **Trích xuất hình ảnh từ đối tượng Zoom**

Các hình dạng [ZoomFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zoomframe/) và [SectionZoomFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sectionzoomframe/) có thể sử dụng ảnh tuỳ chỉnh. Đọc `getZoomImage()` từ khung zoom.

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

## **Trích xuất hình ảnh từ khung Summary Zoom**

Một [SummaryZoomFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/summaryzoomframe/) cũng là một hình dạng. Các mục phần của nó có thể sử dụng ảnh tuỳ chỉnh, được cung cấp qua phương thức `getZoomImage()` của mỗi phần tóm tắt zoom.

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

## **Trích xuất hình ảnh từ hình dạng bảng**

Một [Table](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/table/) là một hình dạng. Hình ảnh trong bảng thường được lưu dưới dạng nền ảnh trong các ô bảng.

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

## **Trích xuất hình ảnh từ hình dạng biểu đồ**

Một [Chart](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/) là một hình dạng. Ví dụ dưới đây trích xuất một hình ảnh từ nền ảnh vùng biểu đồ.

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

## **Trích xuất hình ảnh từ hình dạng SmartArt**

Một đối tượng [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartart/) là một hình dạng. Tùy thuộc vào bố cục SmartArt, hình ảnh có thể được lưu trong nền bullet của nút hoặc trong định dạng nền của các hình dạng nút.

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

## **Bao gồm hình ảnh trong các hình dạng nhóm**

Các hình dạng nhóm chứa bộ sưu tập hình dạng riêng. Trợ giúp `enumerateShapes` chung có tùy chọn `includeGroupedShapes`. Đặt giá trị `true` khi bạn muốn kiểm tra các hình dạng bên trong các đối tượng [GroupShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/groupshape/). Ví dụ dưới đây trích xuất hình ảnh từ khung ảnh, hình dạng nền ảnh, xem trước OLE, thumbnail khung video và thumbnail khung âm thanh. Để bao gồm cả hình ảnh bảng, biểu đồ, SmartArt và summary zoom, hãy tái sử dụng logic trích xuất chuyên biệt từ các phần trước trong khi giữ cùng một cách duyệt hình dạng đệ quy.

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

## **Các trường hợp đặc biệt và lưu ý thực tiễn**

- **Hình ảnh trùng lặp:** Nhiều hình dạng có thể tham chiếu cùng một hình ảnh hoặc các hình ảnh riêng biệt có cùng byte. Băm dữ liệu [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) từ `getBinaryData()` trước khi ghi tệp nếu bạn muốn một tệp đầu ra cho mỗi hình ảnh duy nhất.
- **Dữ liệu gốc vs. đầu ra đã chuyển đổi:** Lưu dữ liệu [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) từ `getBinaryData()` bảo toàn dữ liệu JPEG, PNG, GIF, SVG, EMF hoặc WMF đã nhúng. Lưu hình ảnh trả về bởi `getImage()` hữu ích khi bạn muốn định dạng đầu ra nhất quán.
- **Các loại nền không được hỗ trợ:** Các hình dạng nền đặc, gradient, pattern và không nền không chứa ảnh nền. Kiểm tra [FillType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/filltype/) trước khi đọc `getPictureFillFormat()`.
- **Hình dạng nhóm:** Bộ sưu tập hình dạng cấp trên của slide không làm phẳng các nhóm. Kiểm tra đệ quy nội dung [GroupShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/groupshape/) qua `getShapes()` khi nội dung nhóm quan trọng.
- **Xem trước đối tượng OLE:** Một [OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/oleobjectframe/) có thể cung cấp ảnh xem trước qua `getSubstitutePictureFormat()`, nhưng ảnh này chỉ là xem trước trên slide, không phải tệp nhúng bên trong đối tượng OLE.
- **Thumbnail khung video:** Một [VideoFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/) có thể cung cấp ảnh xem trước qua `getPictureFormat()`, nhưng ảnh này chỉ là poster hiển thị trên slide, không được trích xuất từ luồng video.
- **Thumbnail khung âm thanh:** Một [AudioFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audioframe/) có thể cung cấp biểu tượng hoặc thumbnail qua `getPictureFormat()`; nó không phải là dữ liệu âm thanh đã nhúng.
- **Hình ảnh zoom:** Các hình dạng zoom slide, section zoom và summary zoom có thể sử dụng các đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) tuỳ chỉnh qua `getZoomImage()`.
- **Mô hình hình dạng lồng nhau:** Các đối tượng Table, Chart và SmartArt thực thi [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/), nhưng hình ảnh của chúng thường được lưu trong ô bảng, phần tử biểu đồ hoặc đối tượng định dạng nút SmartArt.
- **Hình ảnh đã cắt hoặc biến đổi:** Truy cập [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) sẽ cho bạn tài nguyên hình ảnh đã lưu. Nó không thực hiện việc cắt, trong suốt, đổi màu, xoay hoặc các hiệu ứng hình ảnh khác được áp dụng bởi hình dạng.

## **Câu hỏi thường gặp**

**Tôi có thể trích xuất hình ảnh gốc mà không cắt, không hiệu ứng hay biến đổi hình dạng không?**

Có. Truy cập đối tượng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) và ghi dữ liệu từ `getBinaryData()` ra đĩa. Điều này bảo toàn hình ảnh đã mã hoá gốc được lưu trong bản trình chiếu, không phải cách hình ảnh được hiển thị trên slide.

**Tôi có thể xuất mọi hình ảnh đã trích xuất dưới dạng PNG không?**

Có. Sử dụng [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) và phương thức `getImage()` của nó, sau đó gọi `save()` với [ImageFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imageformat/). Điều này sẽ chuyển đổi đầu ra và có thể không bảo toàn loại tệp gốc hoặc dữ liệu vector.

**Làm sao để tránh lưu lại cùng một hình ảnh nhiều lần?**

Sử dụng hàm băm của dữ liệu [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) từ `getBinaryData()` và giữ các băm trong một tập hợp. Nếu một hình ảnh mới có băm đã tồn tại, bỏ qua nó hoặc ghi lại tham chiếu khác tới tệp đầu ra hiện có.

**Tại sao một số hình dạng không tạo ra hình ảnh?**

Khung ảnh, hình dạng nền ảnh, khung đối tượng OLE, khung media, khung zoom, bảng, biểu đồ và đối tượng SmartArt có thể tham chiếu hình ảnh. Một số loại hình dạng cung cấp hình ảnh qua các đối tượng định dạng lồng nhau, vì vậy việc chỉ kiểm tra `getPictureFormat()` hoặc `getFillFormat()` của hình dạng không luôn đủ.

**Tôi có thể trích xuất thumbnail hiển thị cho khung video không?**

Có. Sử dụng [VideoFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/videoframe/) và đọc `getPictureFormat().getPicture().getImage()`. Điều này sẽ trích xuất poster được lưu cùng với khung video, không phải một khung được tạo ra từ tệp video.

**Làm sao tôi biết hình dạng nào sử dụng một hình ảnh cụ thể từ bộ sưu tập hình ảnh của bản trình chiếu?**

Aspose.Slides không lưu trữ liên kết ngược từ [PPImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ppimage/) tới các hình dạng. Xây dựng bản đồ trong quá trình duyệt: mỗi khi tìm thấy một tham chiếu hình ảnh, ghi lại số slide, đường dẫn hình dạng và băm hoặc mục trong bộ sưu tập.

**Tôi có thể trích xuất hình ảnh được nhúng trong các đối tượng OLE, chẳng hạn như tài liệu đính kèm không?**

Bạn có thể trích xuất xem trước slide của đối tượng OLE từ [OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/oleobjectframe/). Tuy nhiên, bản xem trước này không phải là tài liệu nhúng thực sự. Để trích xuất hình ảnh bên trong tệp nhúng, cần trích xuất dữ liệu OLE và kiểm tra nó bằng các công cụ phù hợp với loại tệp đó.