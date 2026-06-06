---
title: استخراج الصور من أشكال العرض التقديمي في Node.js
linktitle: صورة من الشكل
type: docs
weight: 100
url: /ar/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- استخراج صورة
- استرجاع صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لـ Node.js عبر Java - حل سريع وملائم للشفرة."
---
## **نظرة عامة**

يمكن أن تظهر الصور في العرض التقديمي بأشكال متعددة: كإطارات صور عادية، كملئ بالصور يُطبق على الأشكال، كصور معاينة لكائنات OLE، كصورة مصغرة لإطارات الفيديو أو الصوت، كصور تكبير، أو كصور متداخلة داخل أشكال الجداول، المخططات، وSmartArt. تقوم Aspose.Slides بتخزين هذه الصور في مجموعة صور العرض التقديمي، والتي تُعرض عبر كائنات [ImageCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imagecollection/) و[PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/).

إذا كنت بحاجة فقط لتصدير كل مورد صورة مضمّن في العرض، يمكنك التكرار عبر `presentation.getImages()`. يركز هذا المقال على مهمة مختلفة: استكشاف الأشكال للعثور على أماكن استخدام الصور في الشرائح، بحيث يمكن للملفات المحفوظة الاحتفاظ بسياق مفيد مثل رقم الشريحة، موقع الشكل، ونوع المصدر (إطار صورة، ملئ صورة، معاينة وسائط، معاينة OLE، أو صورة تكبير).

{{% alert title="Tip" color="primary" %}}
استخدم [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) وطريقة `getBinaryData()` للحفاظ على بيانات الصورة المشفرة الأصلية ونوع الملف. استخدم `getImage()` عندما تريد تحويل الإخراج إلى تنسيق محدد مثل PNG.
{{% /alert %}}

## **طرق المساعدة المشتركة**

الطرق المساعدة أدناه تجعل الأمثلة قصيرة. تقوم `saveOriginalImage` بكتابة البايتات المضمّنة الأصلية، وتختار امتدادًا آمناً من نوع MIME، وتستبعد ثنائيات الصور المتكررة عبر تجزئة SHA-256.

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

## **استخراج الصور من إطارات الصور**

استخدم هذا النهج للصور المُدرجة ككائنات مستقلة. يخزن [PictureFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pictureframe/) صورته في `getPictureFormat().getPicture().getImage()`، والتي تُعيد كائنًا من نوع [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/).

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

## **استخراج الصور من الأشكال المملوءة بالصور**

يمكن للأشكال أن تستخدم صورة كملئ لها. تحقق أولاً من نوع الملئ للشكل: إذا لم يكن [FillType.Picture](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/)، فلا توجد صورة لاستخراجها من ذلك الملئ. يتعامل المثال أدناه مع كائنات [AutoShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/autoshape/) ويحفظ كل صورة كملف PNG عبر [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) وطريقة `getImage()` الخاصة به.

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

## **استخراج صور المعاينة من إطارات كائن OLE**

يمكن أن يحتوي [OleObjectFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/oleobjectframe/) على صورة بديلة تستخدمها PowerPoint كمعاينة للكائن على الشريحة. تتوفر هذه الصورة عبر `getSubstitutePictureFormat().getPicture().getImage()`. استخراج هذه الصورة يعطيك صورة المعاينة، وليس محتويات حزمة OLE المضمّنة.

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

## **استخراج صور المعاينة من إطارات الفيديو**

يمكن أن يخزن [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) أيضًا صورة معاينة في `getPictureFormat().getPicture().getImage()`. هذه هي الملصق أو الصورة المصغرة المعروضة على الشريحة، وليست إطارًا مُستخرجًا من تدفق الفيديو.

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

## **استخراج صور المعاينة من إطارات الصوت**

يمكن أن يخزن [AudioFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/) صورة مصغرة في `getPictureFormat().getPicture().getImage()`. هذه هي الصورة المعروضة لكائن الصوت على الشريحة.

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

## **استخراج الصور من كائنات التكبير**

يمكن لأشكال [ZoomFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/zoomframe/) و[SectionZoomFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sectionzoomframe/) استخدام صور مخصَّصة. اقرأ `getZoomImage()` من إطار التكبير.

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

## **استخراج الصور من إطارات التكبير المُلخَّص**

يُعد [SummaryZoomFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/summaryzoomframe/) أيضًا شكلًا. يمكن لعناصر القسم الخاصة به استخدام صور مخصَّصة، تُعرَض عبر طريقة كل قسم `getZoomImage()`.

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

## **استخراج الصور من أشكال الجداول**

يُعد [Table](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/table/) شكلًا. تُخزن الصور في جدول عادة كملئ صور في خلايا الجدول.

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

## **استخراج الصور من أشكال المخططات**

يُعد [Chart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/) شكلًا. يستخرج المثال أدناه صورة من ملئ صورة منطقة المخطط.

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

## **استخراج الصور من أشكال SmartArt**

يُعد كائن [SmartArt](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/smartart/) شكلًا. اعتمادًا على تخطيط SmartArt، قد تُخزن الصور في ملئ نقاط التعداد للعقد أو في تنسيقات ملئ أشكال العقد.

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

## **تضمين الصور داخل الأشكال المجمَّعة**

تحتوي الأشكال المجمَّعة على مجموعات أشكال خاصة بها. يحتوي المساعد المشترك `enumerateShapes` على خيار `includeGroupedShapes`. اضبطه على `true` عندما تريد فحص الأشكال داخل كائنات [GroupShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/groupshape/). يستخرج المثال أدناه الصور من إطارات الصور، الأشكال المملوءة بالصور، معاينات كائنات OLE، صور مصغرة لإطارات الفيديو، وصور مصغرة لإطارات الصوت. لتضمين صور الجداول، المخططات، SmartArt، وصور التكبير المُلخَّص أيضًا، أعد استخدام منطق الاستخراج المتخصص من الأقسام السابقة مع الحفاظ على نفس استكشاف الأشكال المتكرر.

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

## **حالات الحافة وملاحظات عملية**

- **الصور المكرّرة:** قد تشير أشكال متعددة إلى نفس الصورة أو إلى صور منفصلة ببايتات متطابقة. احسب تجزئة بيانات [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) من `getBinaryData()` قبل كتابة الملفات إذا أردت ملف إخراج واحد لكل صورة فريدة.
- **البيانات الأصلية مقابل الإخراج المحوّل:** حفظ بيانات [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) من `getBinaryData()` يحافظ على JPEG أو PNG أو GIF أو SVG أو EMF أو WMF المضمَّنة. حفظ الصورة التي تُعيدها `getImage()` مفيد عندما تريد تنسيق إخراج موحد.
- **أنواع الملئ غير المدعومة:** الأشكال الصلبة، المتدرجة، النمطية، وبدون ملئ لا تحتوي على ملئ صورة. تحقق من [FillType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/filltype/) قبل قراءة `getPictureFillFormat()`.
- **الأشكال المجمَّعة:** مجموعة الأشكال العليا في الشريحة لا تُسطّح المجموعات. افحص محتوى [GroupShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/groupshape/) بشكل متكرر عبر `getShapes()` عندما يكون محتوى المجموعات مهمًا.
- **معاينات كائن OLE:** قد يُظهر [OleObjectFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/oleobjectframe/) صورة معاينة عبر `getSubstitutePictureFormat()`, لكن هذه الصورة هي مجرد معاينة الشريحة وليس الملف المضمَّن داخل كائن OLE.
- **صور مصغرة لإطارات الفيديو:** قد يُظهر [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) صورة معاينة عبر `getPictureFormat()`, لكنها مجرد الملصق المعروض على الشريحة وليست مستخرجة من تدفق الفيديو.
- **صور مصغرة لإطارات الصوت:** قد يُظهر [AudioFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audioframe/) أيقونة أو صورة مصغرة عبر `getPictureFormat()`; ليست بيانات الصوت المضمَّنة.
- **صور التكبير:** قد تستخدم أشكال التكبير، التكبير القسم، وتكبير الملخص صورًا مخصَّصة من نوع [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) عبر `getZoomImage()`.
- **نماذج الأشكال المتداخلة:** تنفذ كائنات الجدول، المخطط، وSmartArt الواجهة [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/)، ولكن صورها غالبًا ما تُخزن في كائنات تنسيق خلية الجدول، عنصر المخطط، أو عقدة SmartArt.
- **الصور المقصوصة أو المُحوَّلة:** الحصول على [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) يزودك بمورد الصورة المخزَّن. لا يُطبق القص، الشفافية، إعادة التلوين، الدوران أو أي تأثيرات بصرية أخرى يُطبقها الشكل.

## **الأسئلة المتكررة**

**هل يمكنني استخراج الصورة الأصلية دون قص أو تأثيرات أو تحويلات شكل؟**

نعم. استدعِ كائن [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) واكتب البيانات من `getBinaryData()` إلى القرص. سيحافظ هذا على الصورة المشفرة الأصلية المخزَّنة في العرض، وليس على طريقة عرض الصورة على الشريحة.

**هل يمكنني تصدير كل صورة مُستخرجة كـ PNG؟**

نعم. استخدم [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) وطريقة `getImage()` الخاصة به، ثم استدعِ `save()` مع [ImageFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/imageformat/). سيحوّل هذا الإخراج وقد لا يحافظ على نوع الملف الأصلي أو البيانات المتجهية.

**كيف أتجنّب حفظ نفس الصورة أكثر من مرة؟**

استخدم تجزئة بيانات [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) من `getBinaryData()` واحتفظ بالتجزئات في مجموعة. إذا وجدت صورة جديدة لها تجزئة موجودة مسبقًا، فتخطها أو سجّل إشارة أخرى إلى ملف الإخراج الموجود.

**لماذا لا تُنتج بعض الأشكال صورة؟**

يمكن لإطارات الصور، الأشكال المملوءة بالصور، إطارات كائن OLE، إطارات الوسائط، إطارات التكبير، الجداول، المخططات، وكائنات SmartArt الإشارة إلى صور. بعض أنواع الأشكال تُظهر الصور عبر كائنات تنسيق متداخلة، لذا فإن فحص `getPictureFormat()` أو `getFillFormat()` فقط قد لا يكون كافيًا.

**هل يمكنني استخراج الصورة المصغرة المعروضة لإطار الفيديو؟**

نعم. استخدم [VideoFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/videoframe/) واقرأ `getPictureFormat().getPicture().getImage()`. سيستخرج هذا صورة الملصق المخزَّنة مع إطار الفيديو، وليس إطارًا مُستخرجًا من ملف الفيديو.

**كيف يمكنني تحديد الأشكال التي تستخدم صورة محددة من مجموعة صور العرض؟**

لا تخزن Aspose.Slides روابط عكسية من [PPImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/ppimage/) إلى الأشكال. قم بإنشاء خريطة أثناء الاستكشاف: كلما وجدت إشارة صورة، سجّل رقم الشريحة، مسار الشكل، وتجزئة الصورة أو رقم العنصر في المجموعة.

**هل يمكنني استخراج الصور المضمَّنة داخل كائنات OLE، مثل المستندات المرفقة؟**

يمكنك استخراج معاينة شريحة كائن OLE من خلال [OleObjectFrame](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/oleobjectframe/). ومع ذلك، هذه المعاينة ليست المستند المضمّن نفسه. لاستخراج الصور من داخل الملف المضمّن، قم باستخراج بيانات OLE وافحصها بأدوات ملائمة لنوع الملف.