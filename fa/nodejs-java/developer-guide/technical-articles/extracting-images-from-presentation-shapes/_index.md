---
title: استخراج تصاویر از اشکال ارائه در Node.js
linktitle: تصویر از شکل
type: docs
weight: 100
url: /fa/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- استخراج تصویر
- بازیابی تصویر
- پاورپوینت
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "تصاویر را از اشکال در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Node.js via Java استخراج کنید - راه‌حل سریع و مناسب برای کدنویسی."
---
## **مرور کلی**

تصاویر در یک ارائه می‌توانند در چند نوع شکل ظاهر شوند: به‌عنوان قاب‌های تصویر معمولی، به‌عنوان پرکننده تصویر در شکل‌ها، به‌عنوان پیش‌نمایش شیء OLE، به‌عنوان تصویر بندانگشتی فریم ویدیو یا صدا، به‌عنوان تصویر زوم، یا به‌عنوان تصاویری که در داخل اشکال جدول، نمودار و SmartArt تو در تو هستند. Aspose.Slides این تصاویر را در مجموعهٔ تصویر ارائه ذخیره می‌کند که از طریق اشیاء [ImageCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagecollection/) و [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) در دسترس است.

اگر فقط نیاز به استخراج تمام منابع تصویری تعبیه‌شده در یک ارائه دارید، می‌توانید از `presentation.getImages()` استفاده کنید. این مقاله بر یک کار متفاوت تمرکز دارد: پیمایش اشکال برای یافتن مکان‌های استفادهٔ تصاویر در اسلایدها، به‑طوری که فایل‌های ذخیره‌شده بتوانند زمینهٔ مفیدی مانند شماره اسلاید، موقعیت شکل و نوع منبع (قاب تصویر، تصویر پرکننده، پیش‌نمایش رسانه، پیش‌نمایش OLE یا تصویر زوم) را نگه دارند.

{{% alert title="نکته" color="primary" %}}
از [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) و متد `getBinaryData()` آن برای حفظ دادهٔ تصویری کدگذاری‌شدهٔ اصلی و نوع فایل استفاده کنید. هنگام نیاز به نرمال‌سازی خروجی به فرمتی خاص مانند PNG، از `getImage()` بهره ببرید.
{{% /alert %}}

## **متدهای کمکی مشترک**

متدهای کمکی زیر مثال‌ها را کوتاه نگه می‌دارند. `saveOriginalImage` بایت‌های تعبیه‌شدهٔ اصلی را می‌نویسد، پسوند امنی را از نوع MIME انتخاب می‌کند و باینری‌های تصویر تکراری را بر پایهٔ هش SHA‑256 حذف می‌کند.

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

## **استخراج تصاویر از قاب‌های تصویر**

از این روش برای تصاویری که به‌عنوان اشیاء مستقل وارد می‌شوند، استفاده کنید. یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) تصویر خود را در `getPictureFormat().getPicture().getImage()` ذخیره می‌کند که یک شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) برمی‌گرداند.

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

## **استخراج تصاویر از اشکال پرشده با تصویر**

اشکال می‌توانند یک تصویر را به‌عنوان پرکنندهٔ خود استفاده کنند. ابتدا نوع پرکنندهٔ شکل را بررسی کنید: اگر برابر با [FillType.Picture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) نباشد، تصویری برای استخراج وجود ندارد. مثال زیر اشیاء [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) را پردازش کرده و هر تصویر را به‌صورت PNG از طریق [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) و متد `getImage()` ذخیره می‌کند.

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

## **استخراج پیش‌نمایش‌ها از چارچوب‌های شیء OLE**

یک [OleObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/oleobjectframe/) می‌تواند تصویر جایگزینی داشته باشد که PowerPoint به‌عنوان پیش‌نمایش شیء در اسلاید استفاده می‌کند. این تصویر از طریق `getSubstitutePictureFormat().getPicture().getImage()` در دسترس است. استخراج این تصویر باعث می‌شود پیش‌نمایش را دریافت کنید، نه محتوای بستهٔ OLE تعبیه‌شده.

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

## **استخراج پیش‌نمایش‌ها از فریم‌های ویدیو**

یک [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) نیز می‌تواند تصویر پیش‌نمایش را در `getPictureFormat().getPicture().getImage()` ذخیره کند. این تصویر پوستر یا بندانگشتیی است که روی اسلاید نمایش داده می‌شود، نه فریمی که از جریان ویدیو استخراج شده است.

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

## **استخراج پیش‌نمایش‌ها از فریم‌های صدا**

یک [AudioFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/) می‌تواند یک بندانگشتی را در `getPictureFormat().getPicture().getImage()` ذخیره کند. این تصویر نمایانگر شیء صوتی در اسلاید است.

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

## **استخراج تصاویر از اشیاء زوم**

اشکال [ZoomFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/zoomframe/) و [SectionZoomFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sectionzoomframe/) می‌توانند از تصاویر سفارشی استفاده کنند. برای دریافت تصویر، `getZoomImage()` را از فریم زوم بخوانید.

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

## **استخراج تصاویر از فریم‌های زوم خلاصه**

یک [SummaryZoomFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/summaryzoomframe/) نیز یک شکل است. بخش‌های آن می‌توانند تصاویر سفارشی داشته باشند که از طریق متد `getZoomImage()` هر بخش زوم خلاصه در دسترس است.

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

## **استخراج تصاویر از اشکال جدول**

یک [Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/table/) یک شکل است. تصاویر در جدول معمولاً به‌صورت پرکنندهٔ تصویر در سلول‌های جدول ذخیره می‌شوند.

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

## **استخراج تصاویر از اشکال نمودار**

یک [Chart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/) یک شکل است. مثال زیر تصویری را از پرکنندهٔ تصویر ناحیهٔ نمودار استخراج می‌کند.

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

## **استخراج تصاویر از اشکال SmartArt**

یک شیء [SmartArt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/smartart/) یک شکل است. بسته به طرح‌بندی SmartArt، تصاویر ممکن است در پرکنندهٔ گلوله‌های گره یا در فرمت پرکنندهٔ اشکال گره ذخیره شوند.

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

## **شامل کردن تصاویر داخل اشکال گروهی**

اشکال گروهی مجموعهٔ اشکال خود را دارند. متد کمکی مشترک `enumerateShapes` گزینهٔ `includeGroupedShapes` دارد. هنگامی که می‌خواهید اشکال داخل اشیاء [GroupShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/groupshape/) را بررسی کنید، این گزینه را به `true` تنظیم کنید. مثال زیر تصاویر را از قاب‌های تصویر، اشکال پرشده با تصویر، پیش‌نمایش‌های شیء OLE، بندانگشت‌های فریم ویدیو و بندانگشت‌های فریم صدا استخراج می‌کند. برای شامل کردن تصاویر جدول، نمودار، SmartArt و زوم خلاصه نیز، منطق استخراج تخصصی بخش‌های قبلی را بازاستفاده کنید و همان پیمایش بازگشتی شکل‌ها را حفظ کنید.

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

## **موارد خاص و نکات عملی**

- **تصاویر تکراری:** چندین شکل ممکن است به یک تصویر اشاره کنند یا تصاویر جداگانه‌ای با بایت‌های یکسان داشته باشند. قبل از نوشتن فایل‌ها، دادهٔ [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) را با `getBinaryData()` هش کنید تا یک فایل خروجی برای هر تصویر یکتا داشته باشید.
- **دادهٔ اصلی در مقابل خروجی تبدیل‌شده:** ذخیرهٔ دادهٔ [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) از `getBinaryData()` داده‌های JPEG, PNG, GIF, SVG, EMF یا WMF تعبیه‌شده را حفظ می‌کند. ذخیرهٔ تصویری که توسط `getImage()` برگردانده می‌شود زمانی مفید است که بخواهید خروجی همگونی مانند PNG داشته باشید.
- **انواع پرکنندهٔ پشتیبانی‌نشده:** اشکال با پرکنندهٔ ثابت، گرادیان، الگو یا بدون پرکننده تصویری ندارند. قبل از خواندن `getPictureFillFormat()` نوع پرکننده را با [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) بررسی کنید.
- **اشکال گروهی:** مجموعهٔ اشکال سطح بالای اسلاید گروه‌ها را平展 نمی‌کند. برای بررسی محتوای [GroupShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/groupshape/) به‌صورت بازگشتی از `getShapes()` استفاده کنید زمانی که محتواهای گروهی مهم هستند.
- **پیش‌نمایش‌های شیء OLE:** یک [OleObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/oleobjectframe/) ممکن است تصویر پیش‌نمایشی از طریق `getSubstitutePictureFormat()` ارائه دهد، اما این تصویر فقط پیش‌نمایش اسلاید است و نه فایل تعبیه‌شده داخل شیء OLE.
- **بندانگشت‌های فریم ویدیو:** یک [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) ممکن است تصویر پیش‌نمایش را از طریق `getPictureFormat()` ارائه کند؛ این تصویر تنها پوستر نمایش داده‌شده روی اسلاید است و نه فریم استخراج‌شده از جریان ویدیو.
- **بندانگشت‌های فریم صدا:** یک [AudioFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audioframe/) ممکن است یک نماد یا بندانگشت را از طریق `getPictureFormat()` ارائه دهد؛ این تصویر دادهٔ صوتی تعبیه‌شده را نشان نمی‌دهد.
- **تصاویر زوم:** اشکال زوم اسلاید، زوم بخش و زوم خلاصه می‌توانند از اشیاء سفارشی [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) از طریق `getZoomImage()` استفاده کنند.
- **مدل‌های شکل تو در تو:** اشیاء جدول، نمودار و SmartArt از [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) پیروی می‌کنند، اما تصاویر آن‌ها اغلب در قالب‌های تو در توی سلول جدول، عنصر نمودار یا نود SmartArt ذخیره می‌شوند.
- **تصاویر برش‌خورده یا تبدیل‌شده:** دسترسی به [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) منبع تصویر ذخیره‌شده را می‌دهد. این کار برش، شفافیت، تغییر رنگ، چرخش یا سایر اثرات بصری اعمال‌شده توسط شکل را رندر نمی‌کند.

## **سوالات متداول**

**آیا می‌توانم تصویر اصلی را بدون برش، اثرات یا تبدیل‌های شکلی استخراج کنم؟**

بله. شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) را دریافت کنید و دادهٔ `getBinaryData()` را بر روی دیسک بنویسید. این کار تصویر کدگذاری‌شدهٔ اصلی ذخیره‌شده در ارائه را حفظ می‌کند، نه نحوهٔ رندر تصویر روی اسلاید.

**آیا می‌توانم هر تصویر استخراج‌شده را به PNG صادر کنم؟**

بله. از [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) و متد `getImage()` آن استفاده کنید و سپس با [ImageFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imageformat/) `save()` کنید. این کار خروجی را به فرمتی دیگر تبدیل می‌کند و ممکن است نوع فایل یا دادهٔ برداری اصلی را حفظ نکند.

**چگونه از ذخیرهٔ مجدد یک تصویر جلوگیری کنم؟**

هشی از دادهٔ [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) با `getBinaryData()` محاسبه کنید و هاش‌ها را در یک مجموعه نگه دارید. اگر تصویری جدید هشی داشته باشد که قبلاً وجود دارد، آن را نادیده بگیرید یا یک ارجاع دیگر به فایل خروجی موجود ثبت کنید.

**چرا برخی اشکال تصویر تولید نمی‌کنند؟**

قاب‌های تصویر، اشکال پرشده با تصویر، فریم‌های شیء OLE، فریم‌های رسانه‌ای، فریم‌های زوم، جداول، نمودارها و اشیاء SmartArt می‌توانند به تصاویر ارجاع دهند. برخی انواع شکل‌ها تصویر را از طریق اشیاء قالب‌بندی تو در تو ارائه می‌دهند، بنابراین بررسی سادهٔ `getPictureFormat()` یا `getFillFormat()` شکل کافی نیست.

**آیا می‌توانم بندانگشتی نشان داده‌شده برای یک فریم ویدیو را استخراج کنم؟**

بله. از [VideoFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/videoframe/) استفاده کنید و `getPictureFormat().getPicture().getImage()` را بخوانید. این کار تصویر پوستر ذخیره‌شده همراه فریم ویدیو را استخراج می‌کند، نه فریمی که از فایل ویدیو تولید شده است.

**چگونه می‌توانم تعیین کنم کدام اشکال از یک تصویر خاص در مجموعهٔ تصاویر ارائه استفاده می‌کنند؟**

Aspose.Slides لینک معکوسی از [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) به اشکال ذخیره نمی‌کند. در طول پیمایش یک نگاشتی بسازید: هر زمان که به یک ارجاع تصویر برخوردید، شماره اسلاید، مسیر شکل و هش یا شاخص مجموعهٔ تصویر را ثبت کنید.

**آیا می‌توانم تصاویر تعبیه‌شده داخل اشیاء OLE را استخراج کنم، مثلاً اسناد پیوست‌شده؟**

می‌توانید پیش‌نمایش اسلاید شیء OLE را از [OleObjectFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/oleobjectframe/) استخراج کنید. اما این پیش‌نمایش همان سند تعبیه‌شده نیست. برای استخراج تصاویر از داخل فایل تعبیه‌شده، دادهٔ OLE را استخراج کنید و با ابزارهای مربوط به نوع فایل آن بررسی نمایید.