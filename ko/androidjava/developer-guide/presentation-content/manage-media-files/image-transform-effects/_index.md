---
title: Android에서 프레젠테이션의 이미지 변환 효과 관리
linktitle: 이미지 변환 효과
type: docs
weight: 11
url: /ko/androidjava/image-transform-effects/
keywords:
- 이미지 변환
- 그림 효과
- 밝기
- 대비
- 그레이스케일
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java를 사용하여 사진 프레임에 대한 이미지 변환 효과를 적용, 체인, 검사, 제거 및 검증합니다."
---
## **개요**

Aspose.Slides 은 사진 조정을 이미지 변환 작업들의 순차적인 컬렉션으로 표현합니다. 사진 프레임의 경우 프레임의 [ISlidesPicture](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islidespicture/) 를 시작점으로 하고 [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islidespicture/#getImageTransform--) 에 접근합니다. 반환된 [IImageTransformOperationCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/) 은 원본 이미지 바이트를 다시 쓰지 않고도 효과를 추가, 열거, 검사, 제거 및 전체 삭제할 수 있게 해줍니다.

이 문서는 밝기 및 대비, 색상 변환, 흐림, 투명도, 순서가 지정된 효과 체인, 유효값, 제거 및 PPTX 라운드트립 검증을 위한 전체 워크플로우를 보여줍니다.

## **효과 소유권 및 이미지 재사용 이해**

이미지 리소스와 이를 표시하는 그림은 서로 다른 객체입니다:

- [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/) 은 프레젠테이션이 소유하는 원본 이미지 데이터를 저장하거나 참조합니다.
- [ISlidesPicture](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islidespicture/) 은 그림 채우기에 속하며 이미지 리소스를 참조하면서 이미지 변환 컬렉션을 저장합니다.
- [IPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipictureframe/) 은 해당 그림 채우기, 기하학, 자르기 설정 및 기타 프레임 수준 서식을 보유하는 슬라이드 도형입니다.

따라서 이미지 변환 작업은 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/) 의 바이트를 수정하지 않습니다. 동일한 `IPPImage` 가 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) 에 한 번 이상 전달될 경우, 각 새 사진 프레임은 자체 `ISlidesPicture` 와 자체 변환 컬렉션을 받습니다. 한 프레임에 흑백을 적용해도 다른 프레임이 흑백이 되지는 않으며, 모두 동일한 임베디드 이미지 리소스를 재사용합니다.

같은 `ISlidesPicture.getImageTransform` 모델은 도형이나 슬라이드 배경과 같은 다른 그림 채우기에서도 사용됩니다. 아래 예제는 사진 프레임에 초점을 맞춥니다.

## **유효 매개변수 범위 및 단위 사용**

시연된 메서드는 다음 의미적 범위와 단위를 사용합니다. 특정 라이브러리 버전이 범위를 즉시 거부하지 않더라도 이 범위 내 값을 유지하십시오; 대상 프레젠테이션 형식은 저장 시 또는 PowerPoint 가 파일을 열 때 잘못된 데이터를 정규화, 생략 또는 거부할 수 있습니다.

| 작업 | 매개변수 | 유효 범위 및 단위 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100`에서 `100`까지, 퍼센트; `0`은 해당 구성 요소를 변경하지 않습니다. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | 숫자 매개변수가 없습니다. 알파는 변경되지 않습니다. |
| [addDuotoneEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | 어두운 픽셀과 밝은 픽셀을 위한 두 색상. `android.graphics.Color` 에 사용되는 RGB 및 알파값은 `0`에서 `255`까지입니다. |
| [addTintEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | 색조는 `0`(포함)부터 `360`(미포함)까지, 단위는 도; 양은 `-100`에서 `100`까지, 퍼센트. |
| [addHSLEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | 색조는 `0`(포함)부터 `360`(미포함)까지, 도; 채도와 명도는 `-100`에서 `100`까지, 퍼센트. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | 교체 색상은 `0`에서 `255`까지의 채널 값을 사용합니다. 기존 알파 값은 변경되지 않습니다. |
| [addBlurEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | 반경은 음수가 아니며 포인트 단위로 측정됩니다; `grow`는 흐린 콘텐츠가 원본 경계를 벗어날 수 있는지 제어하는 불리언입니다. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | 음수가 아닌 퍼센트. 일반 불투명도 스케일링은 `0`에서 `100`까지 사용합니다: `0`은 완전 투명, `100`은 기존 알파를 보존합니다. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0`에서 `100`까지, 퍼센트 불투명도. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0`에서 `100`까지, 퍼센트 알파 임계값. 이 값보다 낮은 것은 투명해지고, 이 값 이상은 불투명해집니다. |

고정 알파 변조의 경우 투명도와 불투명도는 보완 관계입니다. 예를 들어 35% 투명도는 알파 변조 값 65%에 해당합니다.

## **밝기 및 대비 적용**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) 은 [IBrightnessContrast](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibrightnesscontrast/) 작업을 반환합니다. 스칼라 설정은 작업이 생성될 때 제공됩니다. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) 은 읽기 전용 계산값을 반환하며, 이를 검사하거나 로그에 기록할 수 있습니다.

다음 예제는 밝기를 15% 증가시키고 대비를 20% 증가시킨 뒤, 임베디드 이미지를 수정하지 않고 미리 보기를 렌더링합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/brightnesscontrast/) 은 Office 2010 사진 효과 확장이며 표준 DrawingML 명도 효과보다 이식성이 낮습니다. PPTX 라운드 트립 후에도 밝기와 대비를 편집 가능하게 유지하려면 [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) 를 사용하고 파일을 다시 열어 결과를 확인하십시오. 형식 제한 섹션에서 이 구분을 자세히 설명합니다.

## **색상 변환 적용**

색상 효과는 동일한 이미지 리소스를 재사용하는 서로 다른 사진 프레임에 독립적으로 적용할 수 있습니다. 다음 예제는 다섯 개의 프레임을 만들고 흑백, 듀오톤, 색조, HSL 조정 및 색상 교체를 적용합니다.

[IDuotone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iduotone/) 은 두 개의 독립적으로 편집 가능한 색상 매개변수를 포함합니다: `color1` 은 어두운 픽셀에, `color2` 은 밝은 픽셀에 매핑됩니다. 이는 단일 스칼라 값보다 설정이 복잡한 효과의 좋은 예시입니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) 은 알파를 유지하면서 모든 픽셀 색상을 하나의 고정 색상으로 교체합니다. 이는 소스 색상을 다른 색상으로 매핑하고 두 색상 형식을 모두 노출하는 [addColorChangeEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) 와는 다릅니다.

## **흐림, 투명도 및 알파 효과 추가**

[addBlurEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) 은 알파를 포함한 모든 색상 채널에 영향을 줍니다. 흐린 가장자리가 원본 그림 경계를 넘어설 수 있으면 `grow` 를 `true` 로 설정하십시오.

균일한 투명도를 위해서는 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) 를 사용합니다. 이는 기존 알파 값을 모두 곱하므로 부분 투명 픽셀은 비례적으로 차이를 유지합니다. [addAlphaReplaceEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) 은 모든 픽셀에 하나의 알파 값을 할당하고, [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) 은 임계값에 따라 알파를 두 단계로 변환합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

매개변수가 없는 다른 알파 연산으로는 모든 비영 알파를 완전 불투명하게 만드는 [addAlphaCeilingEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), 100% 이하의 알파를 완전 투명하게 만드는 [addAlphaFloorEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), 그리고 `100% - alpha` 로 알파를 반전시키는 [addAlphaInverseEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) 가 있습니다.

## **순서가 지정된 효과 체인 구축**

각 `add...Effect` 메서드는 새 작업을 컬렉션 끝에 추가합니다. 렌더러는 컬렉션을 순서가 지정된 파이프라인으로 사용합니다: 작업 0 의 출력이 작업 1 의 입력이 되고, 이렇게 계속됩니다. 따라서 순서가 다른 동일한 작업 집합은 다른 이미지를 만들 수 있습니다.

예를 들어, 흑백 후 색조는 먼저 색 정보를 제거하고 그 다음 명도 결과에 색조를 입히며, 색조 후 흑백은 색조를 다시 제거합니다. 마찬가지로 알파 교체는 이전 작업에서 계산된 알파 값을 덮어쓸 수 있지만, 알파 변조는 그 상대적 차이를 유지합니다.

다음 예제는 네 개의 작업 체인을 만들고, PPTX 로 저장한 뒤 프레젠테이션을 다시 열어 작업 유형과 순서를 확인하고, 다시 연 결과를 렌더링합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

컬렉션은 색상, 알파 및 흐림 작업을 별도 체인으로 제한하는 호환성 매트릭스를 강제하지 않습니다. 이들은 결합될 수 있지만, 조합이 항상 유용한 것은 아닙니다. 고정 색상 교체는 이전 색상 효과가 만든 RGB 변화를 제거하고, 듀오톤 뒤의 흑백은 두 선택된 색을 제거합니다; 알파 천장, 바닥, 교체 또는 이중 레벨 작업은 이전에 만든 알파 세부 정보를 삭제할 수 있습니다. 원하는 픽셀 처리 순서에 따라 체인을 구성하고, 항목을 무순서 서식 플래그처럼 다루지 마십시오.

## **편집 가능 및 유효값 검사**

편집 가능한 작업은 `ISlidesPicture.getImageTransform` 에 저장된 객체입니다. 효과에 따라 직접 쓸 수 있는 멤버를 노출할 수 있습니다. 예를 들어, [IBlur](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iblur/) 은 쓰기 가능한 `radius` 와 `grow` 값을 노출하고, [IAlphaModulateFixed](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ialphamodulatefixed/) 은 쓰기 가능한 `amount` 를, [IAlphaBiLevel](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ialphabilevel/) 은 쓰기 가능한 `threshold` 를 노출합니다. [IDuotone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iduotone/) 과 같은 색상 효과는 변경 가능한 [IColorFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/icolorformat/) 객체를 노출합니다.

[IBrightnessContrast](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itint/), [IAlphaReplace](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ialphareplace/) 와 같은 일부 인터페이스는 생성 시 스칼라 값을 쓰기 가능한 속성으로 노출하지 않습니다. 이러한 설정을 변경하려면 작업을 제거하고 원하는 위치에 교체 작업을 추가하십시오.

`getEffective()` 가 반환하는 유효 데이터는 계산된 읽기 전용 값입니다. 테마 종속 색상을 해석하고 렌더러가 사용하는 정규화된 값을 읽는 데 유용하지만, 또 다른 편집 표면은 아닙니다. 다음 예제는 체인을 열거하고, 해당 API 가 제공하는 경우 유효값을 검사합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

그레이스케일, 알파 천장, 알파 역전과 같은 매개변수가 없는 효과도 유효 데이터 객체를 갖지만 출력할 스칼라 설정이 없습니다. 컬렉션 내 존재와 위치가 중요한 정보입니다.

## **이미지 변환 제거 또는 전체 삭제**

[**IImageTransformOperationCollection.removeAt**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) 을 사용하면 인덱스로 하나의 작업을 제거할 수 있습니다. 인덱스는 제거 후 이동하므로, 먼저 대상 작업을 찾은 뒤 열거가 끝난 뒤 제거하십시오. [**ImageTransformOperationCollection.clear**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) 를 사용하면 전체 체인을 제거합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

변환을 제거하거나 전체 삭제해도 사진 서식만 변경됩니다. 재사용되는 [IPPImage](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ippimage/) 리소스는 삭제, 재압축 또는 다른 방식으로 변경되지 않습니다.

## **프레젠테이션 형식 및 내보내기 대상 고려**

이미지 변환은 DrawingML 에서 유래되므로 효과 체인에 가장 적합한 편집 가능 형식은 PPTX 입니다. PPTX 라도 모든 작업이 동일한 이식성을 갖지는 않습니다:

- 명도, 그레이스케일, 듀오톤, 색조, HSL, 흐림 및 일반 알파 작업과 같은 표준 DrawingML 작업은 PPTX 라운드 트립에서 살아남을 확률이 가장 높습니다. 보존이 요구될 경우 항상 생성된 파일을 다시 열어 컬렉션을 검사하십시오.
- [BrightnessContrast](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/brightnesscontrast/) 은 표준 DrawingML 명도 작업이 아닌 Office 2010 확장입니다. 메모리 내 렌더링에는 사용할 수 있지만, 저장 후 PPTX 를 다시 열었을 때 편집 가능한 [IBrightnessContrast](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ibrightnesscontrast/) 로 남을 보장은 없습니다. 지속적인 밝기 및 대비 조정에는 [addLuminanceEffect](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) 를 선호하십시오.
- 이진 PPT 형식은 전체 DrawingML 효과 모델보다 오래되어 지원되지 않는 작업을 생략하거나 체인을 지원되는 부분 집합으로 축소하거나 외관을 근사화할 수 있습니다. 복잡한 편집 가능 체인의 검증 형식으로 PPT 를 사용하지 마십시오.
- PNG, JPEG, TIFF, PDF, SVG, HTML 등 시각 출력으로 렌더링하면 지원되는 체인이 렌더링된 모습에 적용됩니다. 이러한 출력은 편집 가능한 `IImageTransformOperationCollection` 을 포함하지 않으며, 래스터 형식은 결과를 픽셀로 평탄화하고 문서/벡터 내보내기는 자체 렌더링 표현을 저장합니다.
- 효과는 연결된 이미지를 자체 포함형으로 만들지 않습니다. 연결된 그림을 렌더링하려면 프레젠테이션이 로드될 때 연결된 리소스가 사용 가능해야 합니다.

여러 알파 혹은 색상 양자화 작업이 결합될 경우 일부 프레젠테이션 뷰어가 가장자리 사례를 다르게 렌더링할 수 있습니다. 중요한 출력물은 편집 가능한 라운드 트립과 최종 내보내기 형식을 모두 동일한 Aspose.Slides 버전으로 테스트하십시오.

## **FAQ**

**Do image transform effects modify the embedded image data?**

No. The operations belong to the `ISlidesPicture` used by the picture fill. The underlying `IPPImage` bytes remain unchanged.

**Will two picture frames that reuse the same image share their effects?**

No. Reusing an `IPPImage` avoids duplicate image data, but each picture frame normally has a separate `ISlidesPicture` and image transform collection.

**Can color, blur, and alpha effects be combined?**

Yes. The collection accepts them in one ordered chain. Consider what each operation does to the output of the previous one because replacement and threshold operations may discard earlier color or alpha detail.

**Why are effective values read-only?**

Effective data represents calculated values used for rendering, including resolved colors. Edit the operation stored in the transform collection where writable members exist; otherwise remove it and add a replacement with new creation parameters.

**Which format should I use to preserve a transform chain?**

Use PPTX and verify the file by reopening it. Legacy PPT cannot represent the full DrawingML effect model, and rendered export formats preserve appearance rather than editable transform operations.