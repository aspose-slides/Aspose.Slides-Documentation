---
title: Node.js에서 프레젠테이션 도형의 이미지 추출
linktitle: 도형에서 이미지
type: docs
weight: 100
url: /ko/nodejs-java/extracting-images-from-presentation-shapes/
keywords:
- 이미지 추출
- 이미지 가져오기
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 도형에서 이미지를 추출하는 빠르고 코드 친화적인 솔루션."
---
## **개요**

프레젠테이션의 이미지는 여러 형태의 도형에 나타날 수 있습니다: 일반 그림 프레임, 도형에 적용된 그림 채우기, OLE 개체 미리보기 이미지, 비디오·오디오 프레임 썸네일, 확대 이미지, 또는 표·차트·SmartArt 도형 내부에 중첩된 이미지 등입니다. Aspose.Slides는 이러한 이미지를 프레젠테이션 이미지 컬렉션에 저장하며, 이는 [ImageCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/imagecollection/) 및 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/) 객체를 통해 노출됩니다.

프레젠테이션에 포함된 모든 이미지 리소스를 내보내고자 한다면 `presentation.getImages()`를 순회하면 됩니다. 이 문서는 슬라이드 번호, 도형 위치, 소스 유형(그림 프레임, 채우기 이미지, 미디어 미리보기, OLE 미리보기 또는 확대 이미지)과 같은 유용한 컨텍스트를 유지하면서 슬라이드에서 이미지가 사용되는 위치를 찾는 작업에 중점을 둡니다.

{{% alert title="Tip" color="primary" %}}
[PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/)와 그 `getBinaryData()` 메서드를 사용하면 원본 인코딩된 이미지 데이터와 파일 형식을 보존할 수 있습니다. `getImage()`는 PNG와 같은 특정 형식으로 출력을 정규화하고자 할 때 사용합니다.
{{% /alert %}}

## **공유 도우미 메서드**

아래 도우미 메서드는 예제를 간결하게 유지합니다. `saveOriginalImage`는 원본 임베디드 바이트를 기록하고 MIME 유형으로부터 안전한 확장자를 선택하며 SHA‑256 해시로 중복 이미지 바이너리를 건너뜁니다.

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

## **그림 프레임에서 이미지 추출**

독립 개체로 삽입된 그림에 사용합니다. [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/)은 `getPictureFormat().getPicture().getImage()`를 통해 그림을 저장하며, 이는 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/) 객체를 반환합니다.

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

## **그림 채워진 도형에서 이미지 추출**

도형은 그림을 채우기로 사용할 수 있습니다. 먼저 도형의 채우기 유형을 확인하세요: [FillType.Picture](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/filltype/)가 아니라면 해당 채우기에서 추출할 그림이 없습니다. 아래 예제는 [AutoShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/autoshape/) 객체를 처리하고, 각 이미지를 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/)와 `getImage()` 메서드를 통해 PNG로 저장합니다.

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

## **OLE 개체 프레임에서 미리보기 이미지 추출**

[OleObjectFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/oleobjectframe/)는 PowerPoint가 슬라이드에서 개체의 미리보기로 사용하는 대체 그림을 가질 수 있습니다. 이 이미지는 `getSubstitutePictureFormat().getPicture().getImage()`를 통해 사용할 수 있습니다. 이 그림을 추출하면 OLE 패키지 내용이 아니라 미리보기 이미지를 얻는 것입니다.

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

## **비디오 프레임에서 미리보기 이미지 추출**

[VideoFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/)도 `getPictureFormat().getPicture().getImage()`를 통해 미리보기 이미지를 저장할 수 있습니다. 이는 슬라이드에 표시되는 포스터 혹은 썸네일이며, 비디오 스트림에서 디코딩된 프레임이 아닙니다.

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

## **오디오 프레임에서 미리보기 이미지 추출**

[AudioFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/audioframe/)는 `getPictureFormat().getPicture().getImage()`를 통해 썸네일을 저장할 수 있습니다. 이는 슬라이드에 표시되는 오디오 개체의 이미지입니다.

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

## **확대 개체에서 이미지 추출**

[ZoomFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/zoomframe/)와 [SectionZoomFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sectionzoomframe/) 도형은 사용자 지정 이미지를 사용할 수 있습니다. 확대 프레임에서 `getZoomImage()`를 읽으세요.

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

## **요약 확대 프레임에서 이미지 추출**

[SummaryZoomFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/summaryzoomframe/)도 도형이며, 각 요약 확대 섹션의 `getZoomImage()` 메서드를 통해 사용자 지정 이미지를 사용할 수 있습니다.

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

## **표 도형에서 이미지 추출**

[Table](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/table/)은 도형입니다. 표 안의 이미지는 일반적으로 셀의 그림 채우기로 저장됩니다.

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

## **차트 도형에서 이미지 추출**

[Chart](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/)도 도형입니다. 아래 예제는 차트 영역의 그림 채우기에서 이미지를 추출합니다.

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

## **SmartArt 도형에서 이미지 추출**

[SmartArt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/smartart/) 객체는 도형입니다. SmartArt 레이아웃에 따라 이미지는 노드 글머리표 채우기 또는 노드 도형의 채우기 형식에 저장될 수 있습니다.

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

## **그룹화된 도형 내부 이미지 포함**

그룹화된 도형은 자체 도형 컬렉션을 포함합니다. 공유 `enumerateShapes` 도우미는 `includeGroupedShapes` 옵션을 제공합니다. [GroupShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/groupshape/) 객체 내부의 도형을 검사하려면 이 옵션을 `true`로 설정하세요. 아래 예제는 그림 프레임, 그림 채워진 도형, OLE 개체 미리보기, 비디오 프레임 썸네일 및 오디오 프레임 썸네일에서 이미지를 추출합니다. 표, 차트, SmartArt 및 요약 확대 이미지도 포함하려면 앞섹션의 특화된 추출 로직을 재사용하면서 동일한 재귀 도형 순회를 유지하면 됩니다.

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

## **예외 상황 및 실용적인 참고사항**

- **중복 이미지:** 여러 도형이 동일 이미지를 참조하거나 바이트가 동일한 별도 이미지를 가질 수 있습니다. 고유 이미지당 하나의 출력 파일만 원한다면 `getBinaryData()`로부터 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/) 데이터를 해시한 뒤 파일을 기록하기 전에 확인하세요.
- **원본 데이터 vs 변환된 출력:** `getBinaryData()`로부터 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/) 데이터를 저장하면 임베디드 JPEG, PNG, GIF, SVG, EMF 또는 WMF 데이터를 그대로 보존합니다. `getImage()`가 반환하는 이미지를 저장하면 일관된 출력 형식(PNG 등)으로 변환할 때 유용합니다.
- **지원되지 않는 채우기 유형:** 단색, 그라디언트, 패턴 및 무채우기 도형은 그림 채우기가 포함되지 않습니다. `getPictureFillFormat()`을 읽기 전에 [FillType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/filltype/)을 확인하세요.
- **그룹화된 도형:** 최상위 슬라이드 도형 컬렉션은 그룹을 평탄화하지 않습니다. 그룹화된 내용이 중요할 경우 `getShapes()`를 통해 [GroupShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/groupshape/) 내용을 재귀적으로 검사하세요.
- **OLE 개체 미리보기:** [OleObjectFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/oleobjectframe/)는 `getSubstitutePictureFormat()`을 통해 미리보기 이미지를 제공할 수 있지만, 이는 슬라이드 미리보기일 뿐 OLE 개체 내부에 임베디드된 파일은 아닙니다.
- **비디오 프레임 썸네일:** [VideoFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/)는 `getPictureFormat()`을 통해 미리보기 이미지를 제공할 수 있지만, 이는 슬라이드에 표시되는 포스터일 뿐 비디오 스트림에서 추출된 프레임이 아닙니다.
- **오디오 프레임 썸네일:** [AudioFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/audioframe/)는 `getPictureFormat()`을 통해 아이콘 혹은 썸네일을 제공할 수 있지만, 이는 임베디드 오디오 데이터가 아닙니다.
- **확대 이미지:** 슬라이드 확대, 섹션 확대 및 요약 확대 도형은 `getZoomImage()`를 통해 사용자 지정 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/) 객체를 사용할 수 있습니다.
- **중첩 도형 모델:** 표, 차트 및 SmartArt 객체는 [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/)을 구현하지만, 이미지가 종종 중첩된 표 셀, 차트 요소 또는 SmartArt 노드 포맷 객체에 저장됩니다.
- **잘라내기 혹은 변형된 그림:** [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/)에 접근하면 저장된 이미지 리소스를 얻을 수 있지만, 도형이 적용한 잘라내기, 투명도, 색상 재조정, 회전 등 시각 효과는 반영되지 않습니다.

## **FAQ**

**자르기, 효과 또는 도형 변환 없이 원본 이미지를 추출할 수 있나요?**  
예. [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/) 객체에 접근하고 `getBinaryData()`의 데이터를 디스크에 기록하면 프레젠테이션에 저장된 원본 인코딩 이미지를 보존할 수 있으며, 슬라이드에 표시되는 방식과는 무관합니다.

**추출한 모든 이미지를 PNG로 내보낼 수 있나요?**  
예. [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/)와 그 `getImage()` 메서드를 사용한 뒤, [ImageFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/imageformat/)과 함께 `save()`를 호출하면 출력이 PNG로 변환됩니다. 이 경우 원본 파일 형식이나 벡터 데이터는 보존되지 않을 수 있습니다.

**같은 이미지를 여러 번 저장하지 않으려면 어떻게 해야 하나요?**  
`getBinaryData()`로부터 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/) 데이터의 해시를 생성하고 이를 집합에 저장합니다. 새 이미지의 해시가 이미 존재한다면 해당 이미지를 건너뛰거나 기존 출력 파일에 대한 또 다른 참조를 기록하십시오.

**왜 일부 도형에서는 이미지가 생성되지 않나요?**  
그림 프레임, 그림 채워진 도형, OLE 개체 프레임, 미디어 프레임, 확대 프레임, 표, 차트 및 SmartArt 객체는 이미지를 참조할 수 있습니다. 일부 도형 유형은 중첩된 포맷 객체를 통해 이미지를 노출하므로 단순히 `getPictureFormat()`이나 도형의 `getFillFormat()`만으로는 충분하지 않을 수 있습니다.

**비디오 프레임에 표시되는 썸네일을 추출할 수 있나요?**  
예. [VideoFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/videoframe/)를 사용하고 `getPictureFormat().getPicture().getImage()`를 읽으면 비디오 프레임과 함께 저장된 포스터 이미지를 추출할 수 있습니다. 이는 비디오 파일에서 생성된 프레임이 아니라 저장된 썸네일입니다.

**프레젠테이션 이미지 컬렉션에서 특정 이미지를 사용하는 도형을 어떻게 찾을 수 있나요?**  
Aspose.Slides는 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/)에서 도형으로의 역링크를 저장하지 않습니다. 순회 중에 매핑을 구축하세요: 이미지 참조를 찾을 때마다 슬라이드 번호, 도형 경로 및 이미지 해시 또는 컬렉션 항목을 기록합니다.

**OLE 개체 내부에 포함된 이미지(예: 첨부 문서)를 추출할 수 있나요?**  
[OleObjectFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/oleobjectframe/)에서 슬라이드 미리보기를 추출할 수 있지만, 해당 미리보기는 임베디드 문서 자체가 아닙니다. 내부 파일에서 이미지를 추출하려면 OLE 데이터를 추출한 뒤 해당 파일 유형에 맞는 도구로 검토해야 합니다.