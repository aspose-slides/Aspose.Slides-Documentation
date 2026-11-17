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
description: "Java를 통해 Android용 Aspose.Slides로 그림 프레임에 대한 이미지 변환 효과를 적용, 체인 연결, 검사, 제거 및 검증합니다."
---
## **개요**

Aspose.Slides는 그림 조정을 이미지 변환 작업의 순차 컬렉션으로 표현합니다. 그림 프레임의 경우, 프레임의 [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/)를 시작점으로 하고 [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--)에 접근합니다. 반환된 [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/)를 통해 원본 이미지 바이트를 다시 쓰지 않고도 효과를 추가, 열거, 검사, 제거 및 전체 삭제할 수 있습니다.

이 문서에서는 밝기·대비, 색상 변환, 흐림, 투명도, 순차 효과 체인, 실제값, 제거 및 PPTX 라운드트립 검증에 대한 전체 워크플로우를 보여줍니다.

## **효과 소유권 및 이미지 재사용 이해하기**

이미지 리소스와 이를 표시하는 그림은 다른 객체입니다.

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/)은 프레젠테이션이 소유하는 원본 이미지 데이터를 저장하거나 참조합니다.
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/)은 그림 채우기에 속하며 이미지 리소스를 가리키면서 이미지 변환 컬렉션을 저장합니다.
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/)은 해당 그림 채우기, 기하학, 자르기 설정 및 기타 프레임 수준 서식을 소유하는 슬라이드 도형입니다.

따라서 이미지 변환 작업은 [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/)의 바이트를 수정하지 않습니다. 동일한 `IPPImage`를 [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)에 두 번 이상 전달하면, 각 새 그림 프레임은 자체 `ISlidesPicture`와 자체 변환 컬렉션을 받습니다. 한 프레임에 그레이스케일을 적용해도 다른 프레임이 그레이스케일이 되지는 않으며, 모두 동일한 임베디드 이미지 리소스를 재사용합니다.

동일한 `ISlidesPicture.getImageTransform` 모델은 도형이나 슬라이드 배경과 같은 다른 그림 채우기에서도 사용됩니다. 아래 예시는 그림 프레임에 초점을 맞춥니다.

## **유효 파라미터 범위 및 단위 사용하기**

다음 메서드들은 아래와 같은 의미 범위와 단위를 사용합니다. 라이브러리 버전이 즉시 모든 범위 초과 값을 거부하지 않더라도, 대상 프레젠테이션 형식은 저장 시 또는 PowerPoint가 파일을 열 때 비정상 데이터를 정규화, 생략 또는 거부할 수 있으므로 이 범위 내 값을 유지하십시오.

| Operation | 매개변수 | 유효 범위 및 단위 |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100`에서 `100`까지, 백분율; `0`은 해당 요소를 변경하지 않음. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | 없음 | 숫자 파라미터가 없습니다. 알파는 변경되지 않음. |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | 어두운 픽셀과 밝은 픽셀을 위한 두 색상. `android.graphics.Color`에 사용되는 RGB 및 알파 채널 값은 `0`부터 `255`까지. |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | 색조는 `0`(포함)부터 `360`(미포함)까지, 도 단위; 양은 `-100`에서 `100`까지, 백분율. |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | 색조는 `0`(포함)부터 `360`(미포함)까지, 도 단위; 채도와 명도는 `-100`에서 `100`까지, 백분율. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | 교체 색상은 `0`부터 `255`까지의 채널 값을 사용합니다. 기존 알파 값은 변경되지 않음. |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | 반경은 음수가 아니며 포인트 단위; `grow`는 흐려진 영역이 원본 경계를 넘어설 수 있는지를 제어하는 Boolean 값. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | 음수가 아닌 백분율. 일반 불투명도 스케일링을 위해 `0`에서 `100`까지 사용: `0`은 완전 투명, `100`은 기존 알파를 보존. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0`에서 `100`까지, 백분율 불투명도. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0`에서 `100`까지, 백분율 알파 임계값. 이값보다 낮은 픽셀은 투명, 이값 이상은 불투명. |

고정 알파 변조의 경우 투명도와 불투명도는 보완 관계에 있습니다. 예를 들어 35% 투명도는 알파 변조값 65%에 해당합니다.

## **밝기와 대비 적용하기**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-)은 [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) 작업을 반환합니다. 스칼라 설정은 작업 생성 시 제공됩니다. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--)은 읽기 전용 계산값을 반환하며, 이를 검사하거나 로그에 기록할 수 있습니다.

다음 예시는 밝기를 15% 증가하고 대비를 20% 증가시킨 뒤, 임베디드 이미지를 수정하지 않고 미리보기를 렌더링합니다.

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

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/)는 Office 2010 그림 효과 확장이며 표준 DrawingML 명도 효과보다 이식성이 떨어집니다. PPTX 라운드트립 후에도 밝기·대비를 편집 가능하게 유지하려면 [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-)를 사용하고 파일을 다시 연 뒤 결과를 확인하십시오. 형식 제한 섹션에서 이 차이를 더 자세히 설명합니다.

## **색상 변환 적용하기**

색상 효과는 동일 이미지 리소스를 재사용하는 서로 다른 그림 프레임에 독립적으로 적용할 수 있습니다. 다음 예시는 다섯 개 프레임을 만들고 그레이스케일, 듀오톤, 색조, HSL 조정 및 색상 교체를 순서대로 적용합니다.

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/)은 두 개의 독립적으로 편집 가능한 색상 파라미터를 갖습니다: `color1`은 어두운 픽셀에, `color2`는 밝은 픽셀에 매핑됩니다. 이는 단일 스칼라값보다 복잡한 설정을 가진 효과의 좋은 예시입니다.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--)은 알파를 유지하면서 모든 픽셀 색상을 하나의 고정 색상으로 교체합니다. 이는 [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--)와 다르며, 후자는 하나의 소스 색상을 다른 색상으로 매핑하고 소스·대상 색상 형식을 모두 제공합니다.

### **명도 임계값 적용하기**

명도 임계값은 스캔된 페이지의 옅은 흔적을 배경과 구분하기 쉽게 합니다. [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--)은 중간 회색 음영을 유지합니다. [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-)는 명도를 검정 또는 백색으로 매핑하고, [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-)는 투명도에 임계값을 적용합니다.

명도 임계값은 0%부터 100%까지(포함) 범위이며, 임계값 이하 픽셀은 검정이 되고, 임계값 이상 픽셀은 백색이 됩니다. 임계값을 높이면 더 많은 음영이 검정으로 변합니다.

[grayscale-swatches.png](grayscale-swatches.png)를 작업 디렉터리에 다운로드하십시오. 각 레이블은 0~255 스케일의 원래 회색 레벨을 나타냅니다. 예제는 원본을 두 개 복사본과 나란히 배치하고 각 복사본의 임계값을 프레젠테이션에 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

출력 프레젠테이션을 PowerPoint에서 열어 세 프레임을 비교하십시오. 레이블 96은 명도 약 38%(96/255)이며, 20% 임계값에서 백색이 되고 60% 임계값에서 검정이 됩니다.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **흐림, 투명도 및 알파 효과 추가하기**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-)는 알파를 포함한 모든 색상 채널에 영향을 줍니다. 흐린 가장자리가 원본 그림 경계를 넘어설 수 있으면 `grow`를 `true`로 설정하십시오.

균일한 투명도를 원한다면 [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-)를 사용합니다. 이는 기존 알파 값을 모두 곱하므로 부분 투명 픽셀이 비례적으로 유지됩니다. [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-)는 모든 픽셀에 하나의 알파 값을 지정하고, [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-)는 임계값을 기준으로 알파를 두 수준으로 변환합니다.

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

파라미터가 없는 기타 알파 작업으로는 [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--)이 모든 비영 알파를 완전 불투명으로 만들고, [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--)가 100% 미만 알파를 완전 투명으로 만들며, [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--)가 알파를 `100% - alpha` 로 바꿉니다.

## **순차 효과 체인 구축하기**

각 `add...Effect` 메서드는 컬렉션 끝에 새 작업을 추가합니다. 렌더러는 컬렉션을 순차 파이프라인으로 사용합니다: 작업 0의 출력이 작업 1의 입력이 되고, 이렇게 연속됩니다. 따라서 동일한 작업이라도 순서가 바뀌면 다른 이미지가 생성될 수 있습니다.

예를 들어, 그레이스케일 뒤에 색조를 적용하면 색상 정보를 먼저 제거하고 그 후 색조가 적용됩니다. 색조 뒤에 그레이스케일을 적용하면 색조가 다시 제거됩니다. 마찬가지로 알파 교체는 이전 작업이 만든 알파 값을 덮어쓰고, 알파 변조는 상대적 차이를 유지합니다.

다음 예시는 네 개 작업으로 구성된 체인을 만들고 PPTX로 저장한 뒤 프레젠테이션을 다시 열어 작업 유형과 순서를 확인하고 재열린 결과를 렌더링합니다.

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

컬렉션은 색상, 알파 및 흐림 작업을 별도 체인으로 제한하는 호환성 매트릭스를 강제하지 않습니다. 결합은 가능하지만 항상 유용한 것은 아닙니다. 고정 색상 교체는 이전 색상 효과가 만든 RGB 변화를 제거하고, 듀오톤 뒤에 그레이스케일을 적용하면 두 선택 색상이 사라지며, 알파 천장·바닥·교체·이중 레벨 작업은 이전에 만든 알파 디테일을 버릴 수 있습니다. 원하는 픽셀 처리 순서에 따라 체인을 구성하고, 이를 무순서 서식 플래그처럼 취급하지 마십시오.


<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **편집 가능 및 실제 값 검사하기**

편집 가능한 작업은 `ISlidesPicture.getImageTransform`에 저장된 객체입니다. 효과에 따라 직접 쓰기 가능한 멤버를 노출할 수 있습니다. 예를 들어, [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/)는 쓰기 가능한 `radius`와 `grow` 값을, [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/)는 쓰기 가능한 `amount`를, [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/)는 쓰기 가능한 `threshold`를 노출합니다. [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/)과 같은 색상 효과는 변경 가능한 [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) 객체를 노출합니다.

[IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/), [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/) 등 일부 인터페이스는 생성 스칼라를 쓰기 가능한 속성으로 노출하지 않습니다. 이러한 설정을 변경하려면 작업을 제거하고 원하는 위치에 새 작업을 추가하십시오.

`getEffective()`이 반환하는 실제 데이터는 계산된 읽기 전용 값입니다. 테마 종속 색상을 해석하고 렌더러가 사용하는 정규화 값을 읽는 데 유용하지만, 또 다른 편집 표면은 아닙니다. 다음 예시는 체인을 열거하고 해당 API가 제공하는 경우 실제 값을 검사합니다.

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

그레이스케일, 알파 천장, 알파 역전과 같은 파라미터가 없는 효과도 실제 데이터 객체를 가지고 있지만 출력할 스칼라 설정이 없습니다. 컬렉션 내 존재와 위치가 중요한 정보입니다.

## **이미지 변환 제거 또는 전체 삭제하기**

[IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-)를 사용해 인덱스로 하나의 작업을 제거합니다. 인덱스는 제거 후 이동하므로 먼저 대상 작업을 찾은 뒤 열거가 끝난 후 제거하십시오. 전체 체인을 삭제하려면 [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--)를 사용합니다.

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

변환을 제거하거나 전체를 삭제해도 그림 서식만 바뀝니다. 재사용된 [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) 리소스는 삭제·재압축·변경되지 않습니다.

## **프레젠테이션 형식 및 내보내기 대상 고려하기**

이미지 변환은 DrawingML에서 시작되므로 효과 체인에 가장 적합한 편집 형식은 PPTX입니다. PPTX에서도 모든 작업이 동일한 이식성을 보장하지는 않습니다.

- 명도, 그레이스케일, 듀오톤, 색조, HSL, 블러 및 일반 알파 작업과 같은 표준 DrawingML 작업은 PPTX 라운드트립에서 살아남을 가능성이 가장 높습니다. 저장 후 반드시 파일을 다시 열어 컬렉션을 검사하십시오.
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/)는 표준 DrawingML 명도 작업이 아닌 Office 2010 확장입니다. 메모리 내 렌더링에는 사용할 수 있지만 PPTX 저장·재열기 후에도 편집 가능한 [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/)로 남는 것은 보장되지 않습니다. 지속적인 밝기·대비 조정을 위해서는 [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-)를 권장합니다.
- 이진 PPT 형식은 완전한 DrawingML 효과 모델보다 오래되었습니다. PPT로 저장하면 지원되지 않는 작업이 생략되거나 체인이 축소되거나 근사치가 적용될 수 있습니다. 복잡한 편집 체인을 검증 형식으로 PPT를 사용하지 마십시오.
- PNG, JPEG, TIFF, PDF, SVG, HTML 등 시각적 출력은 지원되는 체인을 적용해 렌더링된 모습을 출력합니다. 이러한 출력은 편집 가능한 `IImageTransformOperationCollection`을 포함하지 않으며, 래스터 형식은 결과를 픽셀로 평탄화하고 문서/벡터 내보내기는 자체 렌더링 표현을 저장합니다.
- 효과는 링크된 이미지를 자체 포함으로 만들지 않습니다. 링크된 그림을 렌더링하려면 프레젠테이션이 로드될 때 해당 리소스가 여전히 접근 가능해야 합니다.

다양한 프레젠테이션 뷰어는 특히 여러 알파·색상 양자화 작업이 결합된 경우 가장자리 사례를 다르게 렌더링할 수 있습니다. 중요한 출력에서는 편집 가능한 라운드트립과 최종 내보내기 형식을 동일한 Aspose.Slides 버전으로 테스트하십시오.

## **FAQ**

**이미지 변환 효과가 임베디드 이미지 데이터를 수정하나요?**

아니요. 작업은 그림 채우기에 사용되는 `ISlidesPicture`에 속합니다. 기본 `IPPImage` 바이트는 변경되지 않습니다.

**같은 이미지를 재사용하는 두 그림 프레임이 효과를 공유하나요?**

아니요. `IPPImage`를 재사용하면 이미지 데이터 중복을 피하지만, 각 그림 프레임은 보통 별도의 `ISlidesPicture`와 이미지 변환 컬렉션을 가집니다.

**색상, 흐림 및 알파 효과를 결합할 수 있나요?**

예. 컬렉션은 하나의 순차 체인에 모두 받아들입니다. 각 작업이 이전 작업의 출력에 어떤 영향을 미치는지 고려하십시오. 교체·임계값 작업은 이전 색상·알파 디테일을 버릴 수 있습니다.

**왜 실제 값이 읽기 전용인가요?**

실제 데이터는 렌더링에 사용되는 계산값이며, 색상 해석 등을 포함합니다. 쓰기 가능한 멤버가 있는 작업은 변환 컬렉션에 저장된 객체를 직접 편집하고, 그렇지 않은 경우에는 작업을 제거하고 새로운 생성 파라미터로 교체하십시오.

**어떤 형식이 변환 체인을 보존하는 데 가장 좋나요?**

PPTX를 사용하고 파일을 다시 열어 확인하십시오. 레거시 PPT는 전체 DrawingML 효과 모델을 표현하지 못하며, 렌더링된 내보내기 형식은 외관만 보존하고 편집 가능한 변환 작업은 포함하지 않습니다.