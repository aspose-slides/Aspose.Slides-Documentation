---
title: Ekstrak Gambar dari Bentuk Presentasi di Node.js
linktitle: Gambar dari Bentuk
type: docs
weight: 100
url: /id/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- ekstrak gambar
- ambil gambar
- PowerPoint
- OpenDocument
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Ekstrak gambar dari bentuk dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Node.js via Java - solusi cepat dan ramah kode."
---
## **Gambaran Umum**

Gambar dalam presentasi dapat muncul dalam beberapa jenis bentuk: sebagai bingkai gambar biasa, sebagai isi gambar yang diterapkan pada bentuk, sebagai gambar pratinjau objek OLE, sebagai thumbnail bingkai video atau audio, sebagai gambar zoom, atau sebagai gambar yang tertanam di dalam bentuk tabel, diagram, dan SmartArt. Aspose.Slides menyimpan gambar‑gambar tersebut dalam koleksi gambar presentasi, yang dapat diakses melalui objek [ImageCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imagecollection/) dan [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/).

Jika Anda hanya perlu mengekspor semua sumber daya gambar yang disematkan dalam sebuah presentasi, iterasikan melalui `presentation.getImages()`. Artikel ini fokus pada tugas yang berbeda: menelusuri bentuk‑bentuk untuk menemukan di mana gambar digunakan pada slide, sehingga file yang disimpan dapat mempertahankan konteks berguna seperti nomor slide, posisi bentuk, dan tipe sumber (bingkai gambar, gambar isi, pratinjau media, pratinjau OLE, atau gambar zoom).

{{% alert title="Tip" color="primary" %}}Gunakan [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) dan metode `getBinaryData()`‑nya untuk mempertahankan data gambar yang dikodekan asli dan tipe berkasnya. Gunakan `getImage()` ketika Anda ingin menormalkan output ke format tertentu seperti PNG.{{% /alert %}}

## **Metode Pembantu Bersama**

Metode pembantu di bawah ini membuat contoh tetap singkat. `saveOriginalImage` menulis byte yang disematkan asli, memilih ekstensi yang aman dari tipe MIME, dan melewatkan duplikat biner gambar berdasarkan hash SHA‑256.

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

## **Ekstrak Gambar dari Bingkai Gambar**

Gunakan pendekatan ini untuk gambar yang disisipkan sebagai objek mandiri. Sebuah [PictureFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pictureframe/) menyimpan gambarnya dalam `getPictureFormat().getPicture().getImage()`, yang mengembalikan objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/).

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

## **Ekstrak Gambar dari Bentuk yang Diisi Gambar**

Bentuk dapat menggunakan gambar sebagai isinya. Periksa tipe isian bentuk terlebih dahulu: jika bukan [FillType.Picture](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/), tidak ada gambar yang dapat diekstrak dari isian tersebut. Contoh di bawah menangani objek [AutoShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/autoshape/) dan menyimpan setiap gambar sebagai PNG melalui [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) dan metode `getImage()`‑nya.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Objek OLE**

Sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/oleobjectframe/) dapat memiliki gambar pengganti yang digunakan PowerPoint sebagai pratinjau objek pada slide. Gambar ini tersedia melalui `getSubstitutePictureFormat().getPicture().getImage()`. Mengekstrak gambar ini memberikan Anda gambar pratinjau, bukan isi paket OLE yang disematkan.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Video**

Sebuah [VideoFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/) juga dapat menyimpan gambar pratinjau dalam `getPictureFormat().getPicture().getImage()`. Ini adalah poster atau thumbnail yang ditampilkan pada slide, bukan sebuah frame yang didekode dari aliran video.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Audio**

Sebuah [AudioFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/) dapat menyimpan thumbnail dalam `getPictureFormat().getPicture().getImage()`. Ini adalah gambar yang ditampilkan untuk objek audio pada slide.

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

## **Ekstrak Gambar dari Objek Zoom**

Bentuk [ZoomFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/zoomframe/) dan [SectionZoomFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/sectionzoomframe/) dapat menggunakan gambar kustom. Baca `getZoomImage()` dari bingkai zoom.

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

## **Ekstrak Gambar dari Bingkai Zoom Ringkasan**

Sebuah [SummaryZoomFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/summaryzoomframe/) juga merupakan bentuk. Item seksi‑nya dapat menggunakan gambar kustom, yang dapat diakses melalui metode `getZoomImage()` pada setiap seksi zoom ringkasan.

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

## **Ekstrak Gambar dari Bentuk Tabel**

Sebuah [Table](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/table/) adalah bentuk. Gambar dalam tabel biasanya disimpan sebagai isi gambar pada sel tabel.

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

## **Ekstrak Gambar dari Bentuk Diagram**

Sebuah [Chart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/chart/) adalah bentuk. Contoh di bawah mengekstrak gambar dari isi gambar area diagram.

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

## **Ekstrak Gambar dari Bentuk SmartArt**

Objek [SmartArt](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/smartart/) adalah bentuk. Bergantung pada tata letak SmartArt, gambar dapat disimpan dalam isi bulatan node atau dalam format isi bentuk node.

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

## **Sertakan Gambar di Dalam Bentuk yang Dikelompokkan**

Bentuk yang dikelompokkan memiliki koleksi bentuknya sendiri. Pembantu `enumerateShapes` bersama memiliki opsi `includeGroupedShapes`. Atur menjadi `true` ketika Anda ingin memeriksa bentuk di dalam objek [GroupShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/groupshape/). Contoh di bawah mengekstrak gambar dari bingkai gambar, bentuk yang diisi gambar, pratinjau objek OLE, thumbnail bingkai video, dan thumbnail bingkai audio. Untuk menyertakan gambar tabel, diagram, SmartArt, dan zoom ringkasan juga, gunakan kembali logika ekstraksi khusus dari bagian sebelumnya sambil mempertahankan penelusuran bentuk rekursif yang sama.

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

## **Kasus Khusus dan Catatan Praktis**

- **Gambar duplikat:** Beberapa bentuk dapat merujuk pada gambar yang sama atau gambar terpisah dengan byte yang identik. Hash data [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) dari `getBinaryData()` sebelum menulis berkas jika Anda menginginkan satu berkas output per gambar unik.  
- **Data asli vs. output yang dikonversi:** Menyimpan data [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) dari `getBinaryData()` mempertahankan data JPEG, PNG, GIF, SVG, EMF, atau WMF yang disematkan. Menyimpan gambar yang dikembalikan oleh `getImage()` berguna ketika Anda menginginkan format output yang konsisten.  
- **Tipe isi yang tidak didukung:** Bentuk solid, gradien, pola, dan tanpa isi tidak mengandung isi gambar. Periksa [FillType](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/filltype/) sebelum membaca `getPictureFillFormat()`.  
- **Bentuk yang dikelompokkan:** Koleksi bentuk slide level atas tidak meratakan grup. Periksa secara rekursif konten [GroupShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/groupshape/) melalui `getShapes()` ketika konten grup penting.  
- **Pratinjau objek OLE:** Sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/oleobjectframe/) mungkin menampilkan gambar pratinjau melalui `getSubstitutePictureFormat()`, tetapi gambar tersebut hanya pratinjau slide. Itu bukan berkas yang disematkan di dalam objek OLE.  
- **Thumbnail bingkai video:** Sebuah [VideoFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/) mungkin menampilkan gambar pratinjau melalui `getPictureFormat()`, tetapi gambar tersebut hanya poster yang ditampilkan pada slide. Itu tidak diekstrak dari aliran video.  
- **Thumbnail bingkai audio:** Sebuah [AudioFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/audioframe/) mungkin menampilkan ikon atau thumbnail melalui `getPictureFormat()`; itu bukan data audio yang disematkan.  
- **Gambar zoom:** Bentuk zoom slide, zoom seksi, dan zoom ringkasan dapat menggunakan objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) kustom melalui `getZoomImage()`.  
- **Model bentuk bersarang:** Objek tabel, diagram, dan SmartArt mengimplementasikan [Shape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/), tetapi gambar mereka sering disimpan dalam objek format sel tabel, elemen diagram, atau node SmartArt yang bersarang.  
- **Gambar yang dipotong atau ditransformasi:** Mengakses [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) memberi Anda sumber daya gambar yang disimpan. Itu tidak menerapkan pemotongan, transparansi, recoloring, rotasi, atau efek visual lain yang diterapkan oleh bentuk.

## **FAQ**

**Apakah saya dapat mengekstrak gambar asli tanpa pemotongan, efek, atau transformasi bentuk?**

Ya. Akses objek [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) dan tulis data dari `getBinaryData()` ke disk. Ini mempertahankan gambar yang dikodekan asli yang disimpan dalam presentasi, bukan cara gambar tersebut dirender pada slide.

**Apakah saya dapat mengekspor setiap gambar yang diekstrak sebagai PNG?**

Ya. Gunakan [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) dan metode `getImage()`‑nya, lalu panggil `save()` dengan [ImageFormat](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/imageformat/). Ini mengonversi output dan mungkin tidak mempertahankan tipe berkas atau data vektor asli.

**Bagaimana cara menghindari menyimpan gambar yang sama lebih dari satu kali?**

Gunakan hash data [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) dari `getBinaryData()` dan simpan hash tersebut dalam set. Jika gambar baru memiliki hash yang sudah ada, lewati atau catat referensi lain ke berkas output yang sudah ada.

**Mengapa beberapa bentuk tidak menghasilkan gambar?**

Bingkai gambar, bentuk yang diisi gambar, bingkai objek OLE, bingkai media, bingkai zoom, tabel, diagram, dan objek SmartArt dapat merujuk pada gambar. Beberapa tipe bentuk mengekspose gambar melalui objek format bersarang, sehingga pemeriksaan sederhana `getPictureFormat()` atau `getFillFormat()` pada bentuk tidak selalu cukup.

**Apakah saya dapat mengekstrak thumbnail yang ditampilkan untuk bingkai video?**

Ya. Gunakan [VideoFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/videoframe/) dan baca `getPictureFormat().getPicture().getImage()`. Ini mengekstrak gambar poster yang disimpan bersama bingkai video, bukan frame yang dihasilkan dari berkas video.

**Bagaimana cara menentukan bentuk mana yang menggunakan gambar tertentu dari koleksi gambar presentasi?**

Aspose.Slides tidak menyimpan tautan balik dari [PPImage](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ppimage/) ke bentuk. Bangun pemetaan selama penelusuran: setiap kali Anda menemukan referensi gambar, catat nomor slide, jalur bentuk, dan hash atau item koleksi gambar tersebut.

**Apakah saya dapat mengekstrak gambar yang disematkan di dalam objek OLE, seperti dokumen terlampir?**

Anda dapat mengekstrak pratinjau slide dari [OleObjectFrame](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/oleobjectframe/). Namun, pratinjau tersebut bukan dokumen yang disematkan itu sendiri. Untuk mengekstrak gambar dari dalam berkas yang disematkan, ekstrak data OLE dan periksa dengan alat yang sesuai untuk tipe berkas tersebut.