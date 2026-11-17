---
title: JavaScript로 프레젠테이션의 이미지 변환 효과 관리
linktitle: 이미지 변환 효과
type: docs
weight: 11
url: /ko/nodejs-java/image-transform-effects/
keywords:
- 이미지 변환
- 그림 효과
- 밝기
- 대비
- 회색조
- 듀오톤
- 색조
- HSL
- 색상 교체
- 흐림
- 투명도
- 알파 효과
- 효과 체인
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 Java로 그림 프레임에 대한 이미지 변환 효과를 적용하고, 체인으로 연결하고, 검사하고, 제거하며, 검증합니다."
---
## **개요**

Aspose.Slides는 사진 조정을 이미지 변환 작업의 순서가 지정된 컬렉션으로 나타냅니다. 그림 프레임의 경우 프레임의 [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)에서 시작하여 [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)에 접근합니다. 반환된 [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)을 사용하면 원본 이미지 바이트를 다시 쓰지 않고도 효과를 추가, 열거, 검사, 제거 및 모두 삭제할 수 있습니다.

이 문서에서는 밝기와 대비, 색상 변환, 흐림, 투명도, 순차 효과 체인, 유효값, 제거 및 PPTX 라운드 트립 검증에 대한 전체 워크플로를 보여줍니다.

## **효과 소유권 및 이미지 재사용 이해**

이미지 리소스와 이를 표시하는 그림은 서로 다른 객체입니다:

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)은 프레젠테이션이 소유하는 원본 이미지 데이터를 저장하거나 참조합니다.
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)은 그림 채우기에 속하며 이미지 리소스를 가리키면서 이미지 변환 컬렉션을 저장합니다.
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/)은 해당 그림 채우기, 기하학, 자르기 설정 및 기타 프레임 수준 서식을 소유하는 슬라이드 도형입니다.

따라서 이미지 변환 작업은 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)의 바이트를 수정하지 않습니다. 동일한 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)를 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/)에 여러 번 전달하면 각각의 새 그림 프레임이 자체 [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)와 자체 변환 컬렉션을 받습니다. 한 프레임에 회색조를 적용한다고 해서 다른 프레임이 회색조가 되지는 않으며, 모든 프레임이 동일한 임베디드 이미지 리소스를 재사용합니다.

동일한 [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) 모델은 도형 또는 슬라이드 배경과 같은 다른 그림 채우기에서도 사용됩니다. 아래 예시는 그림 프레임에 초점을 맞춥니다.

## **유효 매개변수 범위 및 단위 사용**

시연된 메서드는 다음과 같은 의미 범위와 단위를 사용합니다. 특정 라이브러리 버전이 모든 범위 외 값을 즉시 거부하지 않더라도 이러한 범위 내 값을 유지하십시오. 대상 프레젠테이션 형식은 저장 시 또는 PowerPoint가 파일을 열 때 잘못된 데이터를 정규화, 누락 또는 거부할 수 있습니다.

| Operation | Parameters | Valid range and unit |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100`부터 `100`까지, 퍼센트; `0`은 해당 구성 요소를 변경하지 않음. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | 숫자 매개변수 없음. 알파는 변경되지 않음. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | 어두운 픽셀과 밝은 픽셀을 위한 두 색상. `java.awt.Color`의 RGB 및 알파 채널은 `0`부터 `255`까지 사용. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | 색조는 `0`(포함)부터 `360`(미포함)까지, 도 단위; 양은 `-100`부터 `100`까지, 퍼센트. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | 색조는 `0`(포함)부터 `360`(미포함)까지, 도 단위; 채도와 휘도는 `-100`부터 `100`까지, 퍼센트. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | 교체 색상은 `0`부터 `255`까지의 채널 값을 사용. 기존 알파 값은 변경되지 않음. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | 반경은 음수가 아니며 포인트 단위; `grow`는 흐린 내용이 원본 경계를 벗어날 수 있는지 제어하는 Boolean. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | 음수가 아닌 퍼센트. 일반 불투명도 스케일링에는 `0`부터 `100`까지 사용: `0`은 완전 투명, `100`은 기존 알파를 유지. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0`부터 `100`까지, 퍼센트 불투명도. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0`부터 `100`까지, 퍼센트 알파 임계값. 임계값 이하인 경우 투명해지고, 임계값 이상인 경우 불투명해짐. |

고정 알파 변조의 경우 투명도와 불투명도는 상보 관계입니다. 예를 들어 35% 투명도는 알파 변조 값 65%에 해당합니다.

## **밝기와 대비 적용**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)은 [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 작업을 반환합니다. 스칼라 설정은 작업 생성 시 제공됩니다. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)은 검사하거나 로그에 기록할 수 있는 계산된 읽기 전용 값을 반환합니다.

다음 예시는 밝기를 15%, 대비를 20% 증가시킨 다음, 임베디드 이미지를 수정하지 않고 미리보기를 렌더링합니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)은 Office 2010 그림 효과 확장 기능이며 표준 DrawingML 휘도 효과보다 이식성이 떨어집니다. PPTX 라운드 트립 후에도 밝기와 대비를 편집 가능하게 유지해야 하면 [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)를 사용하고 파일을 다시 연 후 결과를 확인하십시오. 형식 제한 섹션에서 이 차이에 대해 자세히 설명합니다.

## **색상 변환 적용**

색상 효과는 동일한 이미지 리소스를 재사용하는 서로 다른 그림 프레임에 독립적으로 적용할 수 있습니다. 아래 예시는 다섯 개 프레임을 만들고 회색조, 듀오톤, 색조, HSL 조정 및 색상 교체를 적용합니다.

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/)은 두 개의 독립적으로 편집 가능한 색상 매개변수를 갖습니다: `color1`은 어두운 픽셀에, `color2`는 밝은 픽셀에 매핑됩니다. 이는 단일 스칼라 값보다 설정이 더 복잡한 효과의 유용한 예시입니다.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)는 알파를 보존하면서 모든 픽셀의 색상을 고정 색상으로 교체합니다. 이는 하나의 원본 색상을 다른 색상으로 매핑하고 원본 및 대상 색상 형식을 모두 노출하는 [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)와 다릅니다.

### **휘도 임계값 적용**

휘도 임계값은 스캔한 페이지의 희미한 표식을 배경과 구분하기 쉽게 합니다. [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)는 중간 회색 음영을 유지합니다. [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)는 휘도를 검정 또는 흰색으로 매핑하고, [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)는 불투명도에 임계값을 적용합니다.

휘도 임계값은 0%에서 100%까지(포함)이며, 임계값 이하의 픽셀은 검정이 되고, 임계값 이상은 흰색이 됩니다. 임계값을 높이면 더 많은 음영이 검정으로 변합니다.

[grayscale-swatches.png](grayscale-swatches.png)를 작업 디렉터리에 다운로드하십시오. 각 레이블은 0~255 스케일의 원본 회색 수준을 나타냅니다. 예시는 원본을 두 개의 복사본과 나란히 배치하고 각 복사본의 임계값을 프레젠테이션에 저장합니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

PowerPoint에서 출력 프레젠테이션을 열어 세 프레임을 비교하십시오. 레이블이 96인 스와치는 휘도가 약 38%(96/255)이며, 20% 임계값에서 흰색이 되고 60% 임계값에서 검정이 됩니다.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **흐림, 투명도 및 알파 효과 추가**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)은 알파를 포함한 모든 색상 채널에 영향을 줍니다. 흐린 가장자리가 원본 이미지 경계를 넘어설 수 있는 경우 `grow`를 `true`로 설정하십시오.

균일한 투명도를 위해서는 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)를 사용하십시오. 이 효과는 기존 알파 값을 모두 곱하므로 부분 투명 픽셀은 비례적으로 차이를 유지합니다. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)는 모든 픽셀에 단일 알파 값을 할당합니다. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)는 임계값을 기반으로 알파를 두 수준으로 변환합니다.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

파라미터가 없는 기타 알파 작업에는 [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)가 포함되는데, 이는 0이 아닌 모든 알파를 완전 불투명하게 만들고, [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)는 100% 미만의 모든 알파를 완전 투명하게 만들며, [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)는 알파를 `100% - alpha`로 변경합니다.

## **순서가 지정된 효과 체인 구축**

모든 `add...Effect` 메서드는 컬렉션 끝에 새 작업을 추가합니다. 렌더러는 컬렉션을 순서가 지정된 파이프라인으로 사용합니다: 작업 0의 출력이 작업 1의 입력이 되고, 이렇게 이어집니다. 따라서 동일한 작업이라도 순서를 바꾸면 다른 이미지를 생성할 수 있습니다.

예를 들어, 회색조 뒤에 색조를 적용하면 먼저 색상 정보를 제거한 뒤 휘도 결과에 색상을 입히고, 색조 뒤에 회색조를 적용하면 색조가 다시 제거됩니다. 마찬가지로 알파 교체는 이전 작업에서 계산된 알파 값을 덮어쓸 수 있으며, 알파 변조는 상대적 차이를 유지합니다.

다음 예시는 네 개 작업으로 구성된 체인을 만들고 PPTX로 저장한 뒤 프레젠테이션을 다시 열어 작업 유형과 순서를 확인하고 다시 연 결과를 렌더링합니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

컬렉션은 색상, 알파 및 흐림 작업을 별도 체인으로 제한하는 호환성 매트릭스를 강제하지 않습니다. 이들을 결합할 수 있지만 조합이 항상 유용한 것은 아닙니다. 고정 색상 교체는 이전 색상 효과가 만든 RGB 변화를 제거하고, 듀오톤 뒤에 회색조를 적용하면 두 선택된 색상이 사라지며, 알파 천장, 바닥, 교체 또는 이레벨 작업은 이전에 만든 알파 세부 정보를 삭제할 수 있습니다. 원하는 픽셀 처리 순서에 따라 체인을 구성하고, 항목을 무순서 서식 플래그처럼 다루지 마십시오.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **편집 가능한 값 및 유효값 검사**

편집 가능한 작업은 [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)에 저장된 객체입니다. 효과에 따라 직접 쓸 수 있는 멤버를 노출할 수 있습니다. 예를 들어, [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/)은 쓰기 가능한 `radius`와 `grow` 값을 노출하고, [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/)은 쓰기 가능한 `amount`를, [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/)은 쓰기 가능한 `threshold`를 노출합니다. [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/)과 같은 색상 효과는 변경 가능한 [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) 객체를 노출합니다.

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/), [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/)와 같은 일부 작업은 생성 스칼라를 쓰기 가능한 속성으로 노출하지 않습니다. 이러한 설정을 변경하려면 작업을 제거하고 필요한 위치에 교체 작업을 추가하십시오.

`getEffective()`으로 반환되는 유효 데이터는 계산된 읽기 전용 값입니다. 테마 의존 색상을 해석하고 렌더러가 사용하는 정규화된 값을 읽는 데 유용하지만, 별도의 편집 인터페이스는 아닙니다. 다음 예시는 체인을 열거하고 해당 API가 제공하는 경우 유효값을 검사합니다:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

그레이스케일, 알파 천장, 알파 역전과 같은 파라미터가 없는 효과도 유효‑데이터 객체를 갖지만 인쇄할 스칼라 설정은 없습니다. 컬렉션 내에서의 존재와 위치가 중요한 정보입니다.

## **이미지 변환 제거 또는 모두 삭제**

[ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)을 사용하여 인덱스로 하나의 작업을 제거하십시오. 인덱스는 제거 후 이동하므로 먼저 대상 작업을 찾아 열거 후 제거하십시오. [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)을 사용하면 전체 체인을 삭제할 수 있습니다.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

변환을 제거하거나 모두 삭제해도 그림 서식만 변경됩니다. 재사용되는 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 리소스는 삭제, 재압축 또는 기타 방식으로 변경되지 않습니다.

## **프레젠테이션 형식 및 내보내기 대상 고려**

이미지 변환은 DrawingML에서 시작되므로 효과 체인에 가장 적합한 편집 가능한 형식은 PPTX입니다. PPTX에서도 모든 작업이 동일한 이식성을 보장하는 것은 아닙니다:

- 휘도, 회색조, 듀오톤, 색조, HSL, 흐림 및 일반 알파 작업과 같은 표준 DrawingML 작업은 PPTX 라운드 트립에서 가장 잘 살아남을 가능성이 높습니다. 보존이 요구될 경우 생성된 파일을 항상 다시 열어 컬렉션을 확인하십시오.
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/)은 표준 DrawingML 휘도 작업이 아니라 Office 2010 확장 기능입니다. 메모리 내 렌더링에는 사용할 수 있지만 저장 후 PPTX를 다시 열었을 때 편집 가능한 [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) 작업으로 유지된다는 보장은 없습니다. 지속적인 밝기 및 대비 조정에는 [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)를 우선 사용하십시오.
- 이진 PPT 형식은 전체 DrawingML 효과 모델보다 오래되었습니다. PPT로 저장하면 지원되지 않는 작업이 누락되거나 체인이 지원되는 하위 집합으로 축소되거나 외관이 근사화될 수 있습니다. 복잡한 편집 가능한 체인의 검증 형식으로 PPT를 사용하지 마십시오.
- PNG, JPEG, TIFF, PDF, SVG, HTML 등 시각적 출력 형식은 지원되는 체인을 렌더링된 모습에 적용합니다. 이러한 출력에는 편집 가능한 [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/)이 포함되지 않으며, 래스터 형식은 결과를 픽셀로 평탄화하고 문서/벡터 내보내기는 자체 렌더링 표현을 저장합니다.
- 효과는 연결된 이미지를 자체 포함형으로 만들지 않습니다. 연결된 그림을 렌더링하려면 프레젠테이션을 로드할 때 연결된 리소스가 사용 가능해야 합니다.

여러 알파 또는 색상-양자화 작업을 결합하면 가장자리 사례를 다르게 렌더링할 수 있습니다. 중요한 출력의 경우 실제 프로덕션에 사용되는 동일한 Aspose.Slides 버전으로 편집 가능한 라운드 트립과 최종 내보내기 형식을 모두 테스트하십시오.

## **FAQ**

**이미지 변환 효과가 임베디드 이미지 데이터를 수정합니까?**

아닙니다. 작업은 그림 채우기에 사용되는 [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)에 속합니다. 기본 [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) 바이트는 변경되지 않습니다.

**같은 이미지를 재사용하는 두 그림 프레임이 효과를 공유합니까?**

아닙니다. [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/)를 재사용하면 이미지 데이터 중복을 방지하지만, 각 그림 프레임은 일반적으로 별도의 [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/)와 이미지 변환 컬렉션을 가집니다.

**색상, 흐림 및 알파 효과를 결합할 수 있습니까?**

예. 컬렉션은 하나의 순서가 지정된 체인 안에 이를 수용합니다. 교체 및 임계값 작업은 이전 색상이나 알파 세부 정보를 삭제할 수 있으므로 각 작업이 이전 작업의 출력에 어떤 영향을 미치는지 고려하십시오.

**왜 유효값은 읽기 전용입니까?**

유효 데이터는 렌더링에 사용되는 계산된 값(해결된 색상 포함)을 나타냅니다. 쓰기 가능한 멤버가 있는 경우 변환 컬렉션에 저장된 작업을 편집하고, 그렇지 않으면 해당 작업을 제거하고 새 생성 매개변수로 교체하십시오.

**어떤 형식을 사용해야 변환 체인을 보존할 수 있습니까?**

PPTX를 사용하고 파일을 다시 열어 확인하십시오. 레거시 PPT는 전체 DrawingML 효과 모델을 표현할 수 없으며, 렌더링된 내보내기 형식은 편집 가능한 변환 작업이 아니라 외관만을 보존합니다.