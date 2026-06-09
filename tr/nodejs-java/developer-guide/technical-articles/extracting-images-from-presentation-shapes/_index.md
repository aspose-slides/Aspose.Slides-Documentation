---
title: Sunum Şekillerinden Görüntü Çıkarma Node.js'de
linktitle: Şekilden Görüntü
type: docs
weight: 100
url: /tr/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- görüntü çıkarma
- görüntü alma
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js üzerinden Java ile PowerPoint ve OpenDocument sunumlarındaki şekillerden görüntüleri çıkarın - hızlı, kod dostu bir çözüm."
---
## **Genel Bakış**

Resimler bir sunumda birkaç şekil türünde görünebilir: sıradan resim çerçeveleri olarak, şekillere uygulanan resim doldurmaları olarak, OLE nesne önizleme görüntüleri olarak, video veya ses çerçeve küçük resimleri olarak, yakınlaştırma resimleri olarak veya tablo, grafik ve SmartArt şekilleri içinde iç içe geçmiş resimler olarak. Aspose.Slides bu resimleri sunum resim koleksiyonunda saklar ve [ImageCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagecollection/) ve [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) nesneleri aracılığıyla sunar.

Yalnızca bir sunuma gömülü tüm resim kaynaklarını dışa aktarmanız gerekiyorsa, `presentation.getImages()` üzerinden yineleyin. Bu makale farklı bir göreve odaklanır: slaytlarda resimlerin nerede kullanıldığını bulmak için şekilleri dolaşmak, böylece kaydedilen dosyalar slayt numarası, şekil konumu ve kaynak türü (resim çerçevesi, doldurma resmi, medya önizlemesi, OLE önizlemesi veya yakınlaştırma resmi) gibi yararlı bağlamı tutabilir.

{{% alert title="Tip" color="primary" %}}
[PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) ve onun `getBinaryData()` metodunu kullanarak orijinal kodlanmış resim verisini ve dosya tipini koruyun. Belirli bir formata (örneğin PNG) normalleştirmek istediğinizde `getImage()` kullanın.
{{% /alert %}}

## **Paylaşılan Yardımcı Yöntemler**

Aşağıdaki yardımcı yöntemler örnekleri kısa tutar. `saveOriginalImage` orijinal gömülü baytları yazar, MIME tipinden güvenli bir uzantı seçer ve SHA-256 hash'ine göre yinelenen resim ikili verilerini atlar.

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

## **Resim Çerçevelerinden Resimleri Çıkarma**

Bu yaklaşımı bağımsız nesneler olarak eklenen resimler için kullanın. Bir [PictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) resmini `getPictureFormat().getPicture().getImage()` içinde saklar; bu da bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) nesnesi döndürür.

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

## **Resim Doldurmalı Şekillerden Resimleri Çıkarma**

Şekiller, dolguları olarak bir resim kullanabilir. Öncelikle şeklin doldurma türünü kontrol edin: eğer [FillType.Picture](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) değilse, o doldurmadan çıkarılacak bir resim yoktur. Aşağıdaki örnek [AutoShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/autoshape/) nesnelerini işler ve her resmi [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) ve onun `getImage()` metodu aracılığıyla PNG olarak kaydeder.

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

## **OLE Nesne Çerçevelerinden Önizleme Resimlerini Çıkarma**

Bir [OleObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/oleobjectframe/) bir yerine koyma resmi içerebilir; PowerPoint bunu slaytta nesnenin önizlemesi olarak kullanır. Bu resim `getSubstitutePictureFormat().getPicture().getImage()` üzerinden elde edilir. Bu resmi çıkarmak, OLE paketinin gömülü içeriklerini değil, önizleme resmini verir.

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

## **Video Çerçevelerinden Önizleme Resimlerini Çıkarma**

Bir [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) aynı zamanda `getPictureFormat().getPicture().getImage()` içinde bir önizleme resmi saklar. Bu, slaytta gösterilen poster veya küçük resimdir, video akışından çözülen bir çerçeve değildir.

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

## **Ses Çerçevelerinden Önizleme Resimlerini Çıkarma**

Bir [AudioFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/) `getPictureFormat().getPicture().getImage()` içinde bir küçük resim saklayabilir. Bu, slaytta ses nesnesi için gösterilen resimdir.

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

## **Zoom Nesnelerinden Resimleri Çıkarma**

[ZoomFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/zoomframe/) ve [SectionZoomFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/sectionzoomframe/) şekilleri özel resimler kullanabilir. Yakınlaştırma çerçevesinden `getZoomImage()` metodunu okuyun.

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

## **Özet Yakınlaştırma Çerçevelerinden Resimleri Çıkarma**

Bir [SummaryZoomFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/summaryzoomframe/) de bir şekildir. Bölüm öğeleri özel resimler kullanabilir; bu, her özet yakınlaştırma bölümünün `getZoomImage()` metodu aracılığıyla ortaya çıkar.

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

## **Tablo Şekillerinden Resimleri Çıkarma**

Bir [Table](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/table/) bir şekildir. Tablodaki resimler genellikle tablo hücrelerindeki resim doldurmaları olarak saklanır.

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

## **Grafik Şekillerinden Resimleri Çıkarma**

Bir [Chart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/) bir şekildir. Aşağıdaki örnek, grafik alanının resim doldurmasından bir resmi çıkarır.

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

## **SmartArt Şekillerinden Resimleri Çıkarma**

Bir [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartart/) nesnesi bir şekildir. SmartArt düzenine bağlı olarak, resimler düğüm madde işareti doldurmalarında veya düğüm şekillerinin doldurma formatlarında saklanabilir.

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

## **Gruplandırılmış Şekiller İçindeki Resimleri Dahil Et**

Gruplandırılmış şekiller kendi şekil koleksiyonlarını içerir. Paylaşılan `enumerateShapes` yardımcı fonksiyonunun `includeGroupedShapes` seçeneği vardır. [GroupShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/groupshape/) nesneleri içindeki şekilleri incelemek istediğinizde bunu `true` olarak ayarlayın. Aşağıdaki örnek, resim çerçevelerinden, resim doldurmalı şekillerden, OLE nesne önizlemelerinden, video çerçeve küçük resimlerinden ve ses çerçeve küçük resimlerinden resimleri çıkarır. Tablo, grafik, SmartArt ve özet yakınlaştırma resimlerini de dahil etmek için, önceki bölümlerdeki özel çıkarma mantığını aynı özyineli şekil dolaşımıyla yeniden kullanın.

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

## **Köşe Durumları ve Pratik Notlar**

- **Yinelenen resimler:** Birden fazla şekil aynı resme başvurabilir veya aynı baytlara sahip ayrı resimler olabilir. Benzersiz bir resim başına bir çıktı dosyası istiyorsanız, dosyaları yazmadan önce `getBinaryData()`'den elde edilen [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) verisini SHA‑256 hash'i ile kontrol edin.
- **Orijinal veri vs. dönüştürülmüş çıktı:** `getBinaryData()`'den [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) verisini kaydetmek gömülü JPEG, PNG, GIF, SVG, EMF veya WMF verisini korur. `getImage()` ile döndürülen resmi kaydetmek, tutarlı bir çıktı formatı (örneğin PNG) istediğinizde faydalıdır.
- **Desteklenmeyen doldurma türleri:** Katı, degrade, desen ve doldurulmayan şekiller resim doldurması içermez. `getPictureFillFormat()`'ı okumadan önce [FillType](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/filltype/) kontrol edin.
- **Gruplandırılmış şekiller:** Üst düzey slayt şekil koleksiyonu grupları düzleştirmez. Grup içeriğini `getShapes()` üzerinden özyineli olarak inceleyin, grup içeriği önemli olduğunda.
- **OLE nesne önizlemeleri:** Bir [OleObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/oleobjectframe/) `getSubstitutePictureFormat()` aracılığıyla bir önizleme resmi açabilir, ancak bu resim yalnızca slayt önizlemesidir. OLE nesnesinin içinde gömülü dosya değildir.
- **Video çerçeve küçük resimleri:** Bir [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) `getPictureFormat()` aracılığıyla bir önizleme resmi açabilir; bu resim yalnızca slaytta gösterilen posterdir, video akışından elde edilen bir çerçeve değildir.
- **Ses çerçeve küçük resimleri:** Bir [AudioFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/audioframe/) `getPictureFormat()` aracılığıyla bir simge veya küçük resim açabilir; bu, gömülü ses verisi değildir.
- **Yakınlaştırma resimleri:** Slayt yakınlaştırma, bölüm yakınlaştırma ve özet yakınlaştırma şekilleri `getZoomImage()` aracılığıyla özel [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) nesneleri kullanabilir.
- **İç içe şekil modelleri:** Tablo, grafik ve SmartArt nesneleri [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) uygular, ancak resimleri genellikle iç içe tablo hücresi, grafik öğesi veya SmartArt düğüm biçimlendirme nesnelerinde saklanır.
- **Kırpılmış veya dönüştürülmüş resimler:** [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) erişmek, saklanan resim kaynağını verir. Şeklin uyguladığı kırpma, şeffaflık, renk yeniden ayarlama, dönüşüm gibi görsel etkileri yansıtmaz.

## **SSS**

**Orijinal resmi kırpma, efektler veya şekil dönüşümleri olmadan çıkarabilir miyim?**

Evet. [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) nesnesine erişin ve `getBinaryData()`'dan elde edilen veriyi diske yazın. Bu, sunumda saklanan orijinal kodlanmış resmi korur, slaytta nasıl render edildiğiyle ilgili değildir.

**Çıkarılan her resmi PNG olarak dışa aktarabilir miyim?**

Evet. [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) ve onun `getImage()` metodunu kullanın, ardından [ImageFormat](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imageformat/) ile `save()` çağırın. Bu, çıktıyı dönüştürür ve orijinal dosya tipi veya vektör verisini korumayabilir.

**Aynı resmi birden fazla kez kaydetmekten nasıl kaçınabilirim?**

[PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) verisinin `getBinaryData()`'dan elde edilen hash'ini bir kümede tutun. Yeni bir resmin hash'i zaten mevcutsa, atlayın veya mevcut çıktı dosyasına başka bir referans kaydedin.

**Neden bazı şekiller resim üretmiyor?**

Resim çerçeveleri, resim doldurmalı şekiller, OLE nesne çerçeveleri, medya çerçeveleri, yakınlaştırma çerçeveleri, tablolar, grafikler ve SmartArt nesneleri resimlere başvurabilir. Bazı şekil türleri resimleri iç içe biçimlendirme nesneleri aracılığıyla ortaya çıkarır, bu yüzden basit bir `getPictureFormat()` veya şekil `getFillFormat()` kontrolü her zaman yeterli değildir.

**Video çerçevesi için gösterilen küçük resmi çıkarabilir miyim?**

Evet. [VideoFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/videoframe/) kullanın ve `getPictureFormat().getPicture().getImage()`'ı okuyun. Bu, video çerçevesiyle birlikte saklanan poster resmini çıkarır, video dosyasından oluşturulan bir çerçeve değildir.

**Sunum resim koleksiyonundaki belirli bir resmi hangi şekillerin kullandığını nasıl belirleyebilirim?**

Aspose.Slides, [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) nesnesinden şekillere ters bağlantılar saklamaz. Traversal sırasında bir eşleme oluşturun: bir resim referansı bulduğunuzda slayt numarasını, şekil yolunu ve resim hash'ini veya koleksiyon öğesini kaydedin.

**OLE nesneleri içinde gömülü, örneğin ekli belgeler gibi, resimleri çıkarabilir miyim?**

[OleObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/oleobjectframe/) üzerinden slayt önizleme resmini çıkarabilirsiniz. Ancak bu önizleme gömülü belge değildir. Gömülü dosyanın içindeki resimleri çıkarmak için OLE verisini ayıklayın ve ilgili dosya türü araçlarıyla inceleyin.