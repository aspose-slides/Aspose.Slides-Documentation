---
title: JavaScript를 사용하여 프레젠테이션에서 사진 프레임 관리
linktitle: 사진 프레임
type: docs
weight: 10
url: /ko/nodejs-java/picture-frame/
keywords:
- 사진 프레임
- 사진 프레임 추가
- 사진 프레임 생성
- 내장 이미지
- 연결된 이미지
- 이미지 추출
- 래스터 이미지
- SVG 이미지
- 이미지 자르기
- 잘린 영역 삭제
- 이미지 압축
- 스트레치 오프셋
- 사진 프레임 서식
- 상대 스케일
- 이미지 효과
- 종횡비
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js용 Aspose.Slides를 통해 프레젠테이션에서 사진 프레임을 만들고, 서식 지정하고, 연결하고, 자르고, 추출하며, 압축합니다."
---
## **개요**

Picture frame은 이미지를 표시하는 슬라이드 도형입니다. Aspose.Slides에서 이미지 리소스와 이를 표시하는 도형은 별개의 객체입니다. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 은 [ImageCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/imagecollection/)을 통해 포함된 이미지 리소스를 소유하고, [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/) 은 이미지의 위치, 크기, 선 서식, 회전, 자르기, 그림 효과 및 기타 프레임 수준 설정을 제어합니다.

이러한 분리는 동일한 이미지를 여러 번 표시할 때 유용합니다. 프레젠테이션에 이미지를 한 번 추가하고 반환된 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/)을 보관한 뒤 picture frame을 만들 때 해당 이미지 리소스를 사용합니다.

Picture frame은 PNG 또는 JPEG 같은 래스터 이미지와 SVG 같은 벡터 이미지를 포함할 수 있습니다. 또한 프레젠테이션에 이미지 바이트를 저장하지 않고 연결된 이미지를 참조하도록 할 수도 있습니다. 선택에 따라 이동성, 파일 크기, 추출 및 내보내기 동작이 달라지므로 서식 지정이나 최적화를 적용하기 전에 이미지가 어떻게 저장될지 결정하는 것이 좋습니다.

## **임베드된 이미지 추가 및 서식 지정**

임베드된 이미지의 경우 이미지 데이터를 프레젠테이션에 추가하고 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-)을 사용해 picture frame을 만듭니다. 이미지가 프레젠테이션 패키지의 일부가 되므로 프레젠테이션을 다른 컴퓨터로 이동해도 자체 포함됩니다.

다음 예제는 PNG 이미지를 추가하고 이미지의 원래 크기로 프레임을 만든 뒤 선 서식과 회전을 적용합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

picture frame은 표시되는 기하학을 제어합니다. 프레임 크기를 변경해도 임베드된 이미지 리소스에 저장된 원본 픽셀 차원은 변하지 않습니다. 이 구분은 나중에 이미지를 자르거나 압축할 때 중요해집니다.

## **상대 스케일 사용**

[PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/) 은 [setRelativeScaleWidth](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) 및 [setRelativeScaleHeight](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) 메서드를 통해 프레임의 상대적인 너비와 높이 스케일을 노출합니다. `1.0` 값은 원본 이미지 크기의 100%에 해당합니다. 상대 스케일은 최종 차원을 수동으로 계산하는 대신 원본 이미지 크기와의 관계를 유지해야 하는 워크플로에 유용합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

상대 스케일은 프레임의 스케일 설정만 변경하며, 임베드된 이미지를 재샘플링하거나 압축하지는 않습니다.

## **임베드 이미지와 링크 이미지**

임베드된 picture는 이미지 데이터를 프레젠테이션 내부에 저장하므로 이동성 및 예측 가능한 렌더링 측면에서 가장 안전한 선택입니다. 링크된 picture는 [Picture.setLinkPathLong](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) 메서드를 통해 외부 위치를 저장하므로 이미지 데이터를 동일한 방식으로 임베드하지 않습니다.

링크된 이미지는 PPTX에 저장되는 이미지 데이터 양을 줄일 수 있지만 외부 종속성을 도입합니다. 링크된 파일은 프레젠테이션을 열거나 렌더링하는 애플리케이션이 접근할 수 있어야 합니다. 경로가 변경되거나 파일이 이동되거나 리소스를 사용할 수 없게 되면 링크된 picture가 예상대로 표시되지 않을 수 있습니다. 이메일로 보내거나 보관하거나 격리된 환경에서 렌더링해야 하는 프레젠테이션에서는 임베드된 이미지가 보통 더 신뢰할 수 있습니다.

### **링크 이미지 추가**

다음 예제는 picture frame을 만들고 로컬 이미지 파일을 가리키도록 설정합니다. 이 예제는 이미지 링크만 다루며, 비디오 링크는 별도 미디어 워크플로이며 의도적으로 혼합되지 않았습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

외부 파일 관리가 의도된 경우에만 링크를 사용하십시오. 압축을 대체하기 위한 용도로만 사용하지 마세요. 이미지 종속성이 깨진 작은 PPTX는 보통 더 큰 자체 포함 프레젠테이션보다 유용하지 않습니다.

## **Picture Frame에서 이미지 추출**

기존 프레젠테이션에서 이미지를 추출하기 전에 해당 도형이 실제로 [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/)인지, 그리고 임베드된 이미지를 포함하고 있는지 확인하십시오. 링크된 picture frame은 동일한 방식으로 추출할 수 있는 이미지 바이트를 포함하지 않을 수 있습니다.

### **래스터 이미지 추출**

최신 이미지 API는 [IImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/)를 직접 사용합니다. 다음 예제는 슬라이드의 첫 번째 임베드된 래스터 picture를 찾아 PNG로 저장합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

[IImage.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/#save)를 통해 저장하면 추출된 이미지를 요청한 출력 형식으로 변환합니다. 프레젠테이션에 저장된 인코딩된 바이트가 필요하면 변환된 래스터 파일 대신 이미지 리소스의 바이너리 데이터를 사용하십시오.

### **SVG 이미지 추출**

SVG picture의 경우 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/)이 [SvgImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgimage/) 객체를 노출합니다. 이를 통해 SVG 데이터를 raster화하지 않고 직접 가져올 수 있습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

SVG 내용을 SVG로 유지하면 프레젠테이션 내부에 벡터 소스를 보존합니다. PNG 또는 JPEG와 같은 래스터 내보내기는 해당 벡터 내용을 픽셀로 렌더링합니다. PDF 또는 SVG 슬라이드 내보내기도 렌더링 작업이므로, 내보낸 그래픽을 원본 임베드된 SVG와 바이트 단위로 동일하게 취급해서는 안 됩니다. 원본 벡터 리소스가 필요할 때는 임베드된 [SvgImage.getSvgData](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgimage/#getSvgData--) 데이터를 사용하십시오.

## **이미지 자르기**

자르기는 프레임 내부에서 이미지의 어느 부분이 보이는지를 변경합니다. [PictureFillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/)의 자르기 값은 원본 이미지 차원의 백분율입니다. 자르기는 처음에 임베드된 이미지에서 숨겨진 픽셀을 삭제하지 않고, 표시 영역만 변경합니다.

다음 예제는 picture frame을 안전하게 찾고 자르기 값을 적용합니다:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

숨겨진 이미지 데이터가 여전히 존재하므로, 나중에 원본 픽셀을 잃지 않고 자르기 값을 변경할 수 있습니다. 파일 크기가 중요하고 복구 가능성이 덜 필요하면 다음 섹션에 설명된 대로 자른 영역을 물리적으로 제거할 수 있습니다.

## **잘린 이미지 데이터 제거**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) 메서드는 현재 자르기 사각형 외부의 이미지 데이터를 제거하고 결과 이미지 리소스를 반환합니다. 이를 통해 파일 크기를 줄일 수 있지만 파괴적인 최적화입니다: 프레젠테이션을 저장한 후에는 제거된 픽셀을 나중에 복구할 수 없습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

이 메서드는 프레젠테이션에 새 이미지 리소스를 추가할 수 있습니다. 원본 이미지가 다른 picture frame에서도 사용 중이라면 해당 프레임은 기존 리소스를 계속 필요로 하므로, 잘린 영역을 삭제해도 전체 이미지 수가 반드시 감소하는 것은 아닙니다. WMF 또는 EMF 콘텐츠를 이 메서드로 자르면 결과가 PNG로 raster화됩니다.

## **래스터 이미지 압축**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) 메서드는 picture가 표시되는 크기에 비해 래스터 이미지 해상도를 낮춥니다. 동일한 작업에서 잘린 영역을 제거할 수도 있습니다. 메서드는 이미지가 크기가 변경되었거나 잘렸을 때 `true`를, 변화가 필요 없을 때 `false`를 반환합니다.

표준 목표 해상도가 충분할 경우 미리 정의된 [PicturesCompression](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturescompression/) 값을 사용하십시오:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

특정 목표가 필요한 경우 미리 정의된 값 대신 양의 DPI 값을 직접 전달할 수 있습니다.

압축은 래스터 이미지에만 적용됩니다. SVG 및 메타파일 콘텐츠는 이 래스터 압축 워크플로로 감소되지 않습니다. 또한 낮은 해상도와 삭제된 잘린 영역은 최적화된 프레젠테이션에서 복구할 수 없음을 기억하십시오. 전역적으로 가장 낮은 DPI를 적용하기보다 실제로 보기 혹은 내보내기될 가장 큰 크기를 기준으로 목표 해상도를 선택하십시오.

## **이미지 변환 효과 관리**

밝기, 대비, 색상 변환, 블러, 알파 효과, 순차 체인, 검사, 제거 및 라운드‑트립 검증을 포함하는 전체 워크플로에 대해서는 [Image Transform Effects](/slides/ko/nodejs-java/image-transform-effects/)를 참조하십시오.

## **Picture Frame 기하학 잠금**

[PictureFrameLock](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframelock/) 설정은 picture frame에 대해 어떤 편집 작업이 비활성화되는지를 제어합니다. 예를 들어 [setAspectRatioLocked](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) 은 크기 조정 시 도형의 비율을 유지합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

잠금은 picture frame 도형에 적용됩니다. 이는 원본 이미지가 재샘플링되거나 영구적으로 동일한 종횡비로 변경된다는 것을 강제하지 않습니다.

## **StretchOffset 값 조정**

picture fill 모드가 stretch인 경우, [PictureFillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/)의 stretch‑offset 값은 picture frame 경계 상자에 상대적인 채우기 사각형을 정의합니다. 양수 백분율은 가장자리에서 안쪽으로 들어가게 하고, 음수 백분율은 바깥쪽으로 돌출시킵니다.

이는 자르기와 다릅니다. 자르기 값은 원본 이미지 중 어느 부분이 보일지를 선택하고, stretch offset은 보이는 picture fill이 늘어나는 사각형을 변경합니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

채우기 위치 지정에는 stretch offset을 사용하고, 원본 이미지 가장자리를 숨기려면 자르기 속성을 사용하십시오.

## **저장소, 파일 크기 및 내보내기 고려 사항**

이미지 저장과 picture‑frame 서식을 별도로 다룰 때 주요 트레이드오프를 관리하기가 쉬워집니다:

- **임베드 이미지**는 프레젠테이션을 자체 포함하게 하며 공유 및 서버‑사이드 렌더링에 가장 신뢰할 수 있습니다. 그러나 큰 래스터 이미지는 PPTX 크기와 메모리 사용량을 증가시킵니다.
- **링크 이미지**는 패키지 크기를 줄일 수 있지만, 프레젠테이션은 외부 파일이 지정된 경로나 위치에 계속 존재해야 합니다.
- **자르기**는 처음에는 비파괴적입니다. 숨겨진 픽셀은 잘린 영역을 명시적으로 삭제하거나 압축 중에 제거하기 전까지 임베드된 상태로 남아 있습니다.
- **압축**은 과도한 래스터 이미지의 파일 크기를 크게 줄일 수 있지만, 원본 해상도를 포기합니다. 슬라이드에 표시될 최종 크기가 알려진 후에 적용해야 합니다.
- **SVG 이미지**는 벡터 보존이 중요한 경우 SVG 그대로 유지해야 합니다. 벡터 리소스 자체가 필요할 때는 임베드된 SVG를 직접 추출하십시오. 래스터 슬라이드 내보내기는 항상 렌더링된 슬라이드를 픽셀로 변환합니다.
- **중복 이미지**는 가능한 경우 기존 [PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/) 리소스를 재사용하여 동일한 파일을 프레젠테이션 워크플로에 반복적으로 로드하지 않도록 합니다.

대형 프레젠테이션에서는 이미지 최적화를 선택적으로 수행하는 것이 가장 효과적입니다: 로고와 다이어그램은 벡터 콘텐츠로 유지하고, 사진은 실제 표시 크기에 맞게 압축하며, 나중에 편집이 필요하지 않을 경우에만 잘린 픽셀을 제거하고, 외부 링크는 의존성 관리가 배포 설계의 일부가 아닌 한 피하십시오.

## **FAQ**

**picture frame과 이미지 리소스의 차이점은 무엇인가요?**

[PPImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ppimage/)는 프레젠테이션과 연결된 이미지 리소스를 나타냅니다. [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/)은 슬라이드에 있는 도형으로, 이미지를 표시하고 크기, 회전, 자르기 값, 효과, 잠금 등 프레임 수준의 기하학 및 서식을 저장합니다.

**이미지를 임베드해야 할까요, 아니면 링크해야 할까요?**

프레젠테이션을 이동 가능하게 하거나 보관하거나 외부 리소스에 접근하지 않고 렌더링해야 하는 경우 이미지를 임베드하십시오. 이미지 파일을 PPTX 외부에 두는 것이 의도적이며 외부 위치를 신뢰성 있게 유지할 수 있는 경우에만 이미지를 링크하십시오.

**자르기가 PPTX 파일 크기를 줄이나요?**

자체적으로는 줄지 않습니다. 일반적인 자르기 설정은 원본 이미지의 일부를 숨기지만 기본 픽셀은 유지합니다. 픽셀을 영구적으로 삭제하려면 [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--)를 사용하거나 잘린 영역 제거와 함께 이미지 압축을 수행하십시오.

**압축 후 이미지 품질을 복구할 수 있나요?**

불가능합니다. 압축은 저장된 래스터 해상도를 낮추고, 잘린 영역을 제거하면 이미지 데이터가 사라집니다. 나중에 고해상도 편집이 필요할 경우 원본 이미지를 프레젠테이션 밖에 보관하십시오.

**SVG 이미지는 어떻게 처리해야 하나요?**

벡터 정확도가 중요한 경우 SVG 콘텐츠를 SVG 그대로 유지하십시오. 임베드된 [SvgImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgimage/)를 직접 추출할 수 있습니다. PNG 또는 JPEG와 같은 래스터 형식으로 슬라이드를 렌더링하면 SVG가 슬라이드 이미지의 일부로 래스터화됩니다.

**기존 슬라이드를 읽을 때 안전하지 않은 캐스트를 방지하려면 어떻게 해야 하나요?**

picture‑frame‑전용 멤버를 사용하기 전에 도형 유형을 확인하십시오. [PictureFrame](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/pictureframe/)에 대한 `java.instanceOf` 검사는 잘못된 캐스트를 방지하고 picture frame이 포함되지 않은 슬라이드를 적절히 처리할 수 있게 해줍니다.