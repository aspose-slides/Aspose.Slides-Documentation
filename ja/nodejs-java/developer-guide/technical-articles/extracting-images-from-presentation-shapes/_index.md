---
title: Node.js のプレゼンテーション形状から画像を抽出
linktitle: 形状からの画像
type: docs
weight: 100
url: /ja/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- 画像抽出
- 画像取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint と OpenDocument のプレゼンテーション内の形状から画像を抽出する - 迅速でコードフレンドリーなソリューション。"
---
## **概要**

プレゼンテーション内の画像は、さまざまな形状タイプで表示されます。普通の画像フレーム、図形に適用された画像塗りつぶし、OLE オブジェクトのプレビュー画像、ビデオまたはオーディオフレームのサムネイル、ズーム画像、またはテーブル、チャート、SmartArt 図形に埋め込まれた画像などです。Aspose.Slides はそれらの画像をプレゼンテーションの画像コレクションに保存し、[ImageCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/imagecollection/) と [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) オブジェクトで公開します。

プレゼンテーションに埋め込まれたすべての画像リソースをエクスポートしたいだけの場合は、`presentation.getImages()` を反復処理します。本記事は別のタスクに焦点を当てています。スライド上で画像が使用されている場所を形状を走査して特定し、保存したファイルにスライド番号、形状の位置、ソースタイプ（画像フレーム、塗りつぶし画像、メディアプレビュー、OLE プレビュー、またはズーム画像）といった有用なコンテキストを保持できるようにします。

{{% alert title="Tip" color="primary" %}}
[PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) とその `getBinaryData()` メソッドを使用すると、元のエンコードされた画像データとファイルタイプを保持できます。特定のフォーマット（例: PNG）に正規化した出力が必要な場合は `getImage()` を使用してください。
{{% /alert %}}

## **共有ヘルパーメソッド**

以下のヘルパーメソッドはサンプルを簡潔に保つためのものです。`saveOriginalImage` は埋め込みバイト列を書き込み、MIME タイプから安全な拡張子を選択し、SHA‑256 ハッシュで重複する画像バイナリをスキップします。

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

## **画像フレームから画像を抽出する**

単独オブジェクトとして挿入された画像にこの方法を使用します。[PictureFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/pictureframe/) は `getPictureFormat().getPicture().getImage()` で画像を保持し、[PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) オブジェクトを返します。

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

## **画像塗りつぶし形状から画像を抽出する**

形状は画像を塗りつぶしとして使用できます。まず形状の塗りつぶしタイプを確認してください。`FillType.Picture` でない場合、その塗りつぶしから抽出できる画像はありません。以下の例は [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) オブジェクトを扱い、各画像を [PPImage](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ppimage/) の `getImage()` メソッドで PNG として保存します。

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

## **OLE オブジェクトフレームからプレビュー画像を抽出する**

[OleObjectFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/oleobjectframe/) は、PowerPoint がスライド上でオブジェクトのプレビューとして使用する代替画像を持つことがあります。この画像は `getSubstitutePictureFormat().getPicture().getImage()` で取得できます。抽出される画像はプレビュー画像であり、埋め込まれた OLE パッケージの内容ではありません。

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

## **ビデオフレームからプレビュー画像を抽出する**

[VideoFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/videoframe/) も `getPictureFormat().getPicture().getImage()` でプレビュー画像を保持します。これはスライド上に表示されるポスターまたはサムネイルであり、ビデオストリームからデコードされたフレームではありません。

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

## **オーディオフレームからプレビュー画像を抽出する**

[AudioFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/audioframe/) は `getPictureFormat().getPicture().getImage()` でサムネイルを保持できます。これはスライド上のオーディオオブジェクトに表示される画像です。

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

## **ズームオブジェクトから画像を抽出する**

[ZoomFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/zoomframe/) と [SectionZoomFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/sectionzoomframe/) 形状はカスタム画像を使用できます。ズームフレームの `getZoomImage()` を読み取ります。

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

## **サマリーズームフレームから画像を抽出する**

[SummaryZoomFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/summaryzoomframe/) も形状の一種です。そのセクション項目はカスタム画像を使用でき、各サマリーズームセクションの `getZoomImage()` メソッドで取得できます。

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

## **テーブル形状から画像を抽出する**

[Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/table/) は形状です。テーブル内の画像は通常、セルの画像塗りつぶしとして保存されています。

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

## **チャート形状から画像を抽出する**

[Chart](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/chart/) は形状です。以下の例はチャート領域の画像塗りつぶしから画像を抽出します。

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

## **SmartArt 形状から画像を抽出する**

[SmartArt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartart/) オブジェクトは形状です。SmartArt のレイアウトによっては、ノードの箇条書き塗りつぶしやノード形状の塗りつぶし形式に画像が格納されることがあります。

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

## **グループ化された形状内の画像を含める**

グループ化された形状は独自の形状コレクションを持ちます。共有ヘルパー `enumerateShapes` には `includeGroupedShapes` オプションがあります。`GroupShape` オブジェクト内の形状も調査したい場合は `true` に設定してください。以下の例は画像フレーム、画像塗りつぶし形状、OLE オブジェクトプレビュー、ビデオフレームサムネイル、オーディオフレームサムネイルから画像を抽出します。テーブル、チャート、SmartArt、サマリーズームの画像も含めるには、前述の専用抽出ロジックを再利用しつつ同じ再帰的形状走査を行ってください。

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

## **エッジケースと実践的な注意点**

- **重複画像:** 複数の形状が同じ画像を参照することや、バイト列が同一の別々の画像が存在することがあります。`PPImage` の `getBinaryData()` からハッシュを取得し、ハッシュが重複している場合はファイルを書き出さないようにしてください。
- **元データと変換後出力:** `getBinaryData()` で取得した `PPImage` のデータを保存すると、埋め込まれた JPEG、PNG、GIF、SVG、EMF、WMF データが保持されます。`getImage()` が返す画像を保存すると、PNG など指定したフォーマットに統一できます。
- **サポートされない塗りつぶしタイプ:** 単色、グラデーション、パターン、無塗りつぶしの形状には画像塗りつぶしが含まれません。`FillType` を確認してから `getPictureFillFormat()` を呼び出してください。
- **グループ化された形状:** 上位レベルのスライド形状コレクションはグループを平坦化しません。`GroupShape` の `getShapes()` を再帰的に調査して、グループ化されたコンテンツが重要な場合に対応してください。
- **OLE オブジェクトプレビュー:** `OleObjectFrame` は `getSubstitutePictureFormat()` を通じてプレビュー画像を提供することがありますが、これはスライド上のプレビューであり、OLE オブジェクト内部に埋め込まれたファイルそのものではありません。
- **ビデオフレームサムネイル:** `VideoFrame` は `getPictureFormat()` を通じてプレビュー画像を提供しますが、これはスライド上に表示されるポスターであり、ビデオストリームから抽出されたフレームではありません。
- **オーディオフレームサムネイル:** `AudioFrame` は `getPictureFormat()` を通じてアイコンまたはサムネイルを提供します。これは埋め込まれたオーディオデータではありません。
- **ズーム画像:** スライドズーム、セクションズーム、サマリーズームの形状は `getZoomImage()` を介してカスタム `PPImage` オブジェクトを使用できることがあります。
- **入れ子になった形状モデル:** テーブル、チャート、SmartArt オブジェクトはすべて `Shape` を実装していますが、画像はしばしば入れ子になったテーブルセル、チャート要素、SmartArt ノードの書式設定オブジェクトに格納されています。
- **切り抜きまたは変形された画像:** `PPImage` にアクセスすると保存されている画像リソースが取得できますが、形状によって適用された切り抜き、透明度、再着色、回転、その他の視覚効果は反映されません。

## **FAQ**

**元の画像を切り抜きやエフェクト、形状変換なしで抽出できますか？**

はい。`PPImage` オブジェクトにアクセスし、`getBinaryData()` で取得したデータを書き出してください。これにより、プレゼンテーションに保存されている元のエンコード画像が保持され、スライド上のレンダリング方法は影響を受けません。

**抽出したすべての画像を PNG としてエクスポートできますか？**

はい。`PPImage` の `getImage()` メソッドを使用し、`ImageFormat` を指定して `save()` を呼び出してください。これにより出力が PNG に変換されますが、元のファイルタイプやベクターデータは保持されない可能性があります。

**同じ画像を複数回保存しないようにするには？**

`PPImage` の `getBinaryData()` からハッシュを算出し、ハッシュの集合で管理してください。新しい画像のハッシュが既に存在する場合は保存をスキップするか、既存の出力ファイルへの別参照として記録します。

**なぜ一部の形状から画像が取得できないのですか？**

画像フレーム、画像塗りつぶし形状、OLE オブジェクトフレーム、メディアフレーム、ズームフレーム、テーブル、チャート、SmartArt オブジェクトは画像を参照できますが、画像は入れ子になった書式設定オブジェクトに格納されていることがあります。そのため、単純に `getPictureFormat()` または `getFillFormat()` をチェックするだけでは不十分な場合があります。

**ビデオフレームのサムネイル画像を抽出できますか？**

はい。`VideoFrame` の `getPictureFormat().getPicture().getImage()` を読み取ってください。これにより、ビデオフレームに保存されているポスター画像が抽出されますが、ビデオファイルから生成されたフレームではありません。

**プレゼンテーション画像コレクション内の特定の画像を使用している形状を特定するには？**

Aspose.Slides は `PPImage` から形状への逆参照を保持していません。走査中にマッピングを構築し、画像が見つかったらスライド番号、形状パス、画像ハッシュまたはコレクション項目を記録してください。

**OLE オブジェクト内に埋め込まれた画像（例: 添付文書）を抽出できますか？**

`OleObjectFrame` からはスライドプレビュー画像を抽出できますが、これは埋め込まれた文書自体ではありません。埋め込みファイル内部の画像を取得したい場合は、OLE データを抽出し、対象ファイルタイプに適したツールで解析してください。