---
title: JavaScript에서 프레젠테이션 배경 관리
linktitle: 슬라이드 배경
type: docs
weight: 20
url: /ko/nodejs-java/presentation-background/
keywords:
- 프레젠테이션 배경
- 슬라이드 배경
- 단색
- 그라데이션 색상
- 이미지 배경
- 배경 투명도
- 배경 속성
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 PowerPoint 및 OpenDocument 파일에서 동적인 배경을 설정하는 방법을 배우고, 프레젠테이션을 향상시키는 코드 팁을 확인하세요."
---
## **소개**

단색, 그라데이션 및 이미지는 슬라이드 배경으로 일반적으로 사용됩니다. **보통 슬라이드**(단일 슬라이드) 또는 **마스터 슬라이드**(한 번에 여러 슬라이드에 적용) 배경을 설정할 수 있습니다.

![PowerPoint background](powerpoint-background.png)

## **보통 슬라이드에 단색 배경 설정**

Aspose.Slides를 사용하면 프레젠테이션의 특정 슬라이드에 단색을 배경으로 설정할 수 있습니다(프레젠테이션이 마스터 슬라이드를 사용하더라도). 변경 사항은 선택된 슬라이드에만 적용됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/backgroundtype/)을 `OwnBackground`로 설정합니다.
3. 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/filltype/)을 `Solid`로 설정합니다.
4. [FillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/)의 [getSolidFillColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) 메서드를 사용하여 단색 배경 색을 지정합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 예제는 보통 슬라이드에 파란색 단색 배경을 설정하는 방법을 보여줍니다:

```js
// Presentation 클래스의 인스턴스를 생성합니다.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 슬라이드의 배경 색을 파란색으로 설정합니다.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // 프레젠테이션을 디스크에 저장합니다.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **마스터 슬라이드에 단색 배경 설정**

Aspose.Slides를 사용하면 프레젠테이션의 마스터 슬라이드에 단색을 배경으로 설정할 수 있습니다. 마스터 슬라이드는 모든 슬라이드의 서식을 제어하는 템플릿 역할을 하므로, 마스터 슬라이드 배경에 단색을 선택하면 모든 슬라이드에 적용됩니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 마스터 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/backgroundtype/)(`getMasters`를 통해)을 `OwnBackground`로 설정합니다.
3. 마스터 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/filltype/)을 `Solid`로 설정합니다.
4. [getSolidFillColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) 메서드를 사용하여 단색 배경 색을 지정합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 예제는 마스터 슬라이드에 녹색 단색 배경을 설정하는 방법을 보여줍니다:

```js
// Presentation 클래스의 인스턴스를 생성합니다.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // 마스터 슬라이드의 배경 색을 포레스트 그린으로 설정합니다.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // 프레젠테이션을 디스크에 저장합니다.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **슬라이드에 그라데이션 배경 설정**

그라데이션은 색상이 서서히 변하는 그래픽 효과입니다. 슬라이드 배경으로 사용할 경우 프레젠테이션을 보다 예술적이고 전문적으로 보이게 합니다. Aspose.Slides를 사용하면 슬라이드에 그라데이션 색을 배경으로 설정할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/backgroundtype/)을 `OwnBackground`로 설정합니다.
3. 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/filltype/)을 `Gradient`로 설정합니다.
4. [FillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/)의 [getGradientFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/#getGradientFormat) 메서드를 사용하여 원하는 그라데이션 설정을 구성합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 예제는 슬라이드에 그라데이션 색을 배경으로 설정하는 방법을 보여줍니다:

```js
// Presentation 클래스의 인스턴스를 생성합니다.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 배경에 그라데이션 효과를 적용합니다.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // 프레젠테이션을 디스크에 저장합니다.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **슬라이드를 이미지 배경으로 설정**

단색 및 그라데이션 채우기 외에도 Aspose.Slides를 사용하면 이미지를 슬라이드 배경으로 사용할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 슬라이드의 [BackgroundType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/backgroundtype/)을 `OwnBackground`로 설정합니다.
3. 슬라이드 배경의 [FillType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/filltype/)을 `Picture`로 설정합니다.
4. 슬라이드 배경으로 사용할 이미지를 로드합니다.
5. 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다.
6. [FillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/)의 [getPictureFillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) 메서드를 사용하여 이미지를 배경으로 지정합니다.
7. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 예제는 슬라이드에 이미지를 배경으로 설정하는 방법을 보여줍니다:

```js
// Presentation 클래스의 인스턴스를 생성합니다.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 배경 이미지 속성을 설정합니다.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // 이미지를 로드합니다.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // 이미지를 프레젠테이션의 이미지 컬렉션에 추가합니다.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // 프레젠테이션을 디스크에 저장합니다.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

다음 코드 샘플은 배경 채우기 유형을 타일링된 이미지로 설정하고 타일링 속성을 수정하는 방법을 보여줍니다:

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // 배경 채우기에 사용할 이미지를 설정합니다.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // 그림 채우기 모드를 타일로 설정하고 타일 속성을 조정합니다.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Read more: [**텍스처로 타일 이미지**](/slides/ko/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **배경 이미지 투명도 변경**

슬라이드 배경 이미지의 투명도를 조정하여 슬라이드 내용이 돋보이게 할 수 있습니다. 다음 JavaScript 코드는 슬라이드 배경 이미지의 투명도를 변경하는 방법을 보여줍니다:

```js
var transparencyValue = 30; // 예시로.

// 그림 변환 작업 컬렉션을 가져옵니다.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// 기존 고정 비율 투명도 효과를 찾습니다.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// 새 투명도 값을 설정합니다.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **슬라이드 배경 값 가져오기**

Aspose.Slides는 슬라이드의 실제 배경 값을 검색하기 위해 `BackgroundEffectiveData` 클래스를 제공합니다. 이 클래스는 실제 [FillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fillformat/) 및 [EffectFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/effectformat/)을 노출합니다.

[BaseSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/baseslide/) 클래스의 `getBackground` 메서드를 사용하면 슬라이드의 실제 배경을 얻을 수 있습니다.

다음 JavaScript 예제는 슬라이드의 실제 배경 값을 가져오는 방법을 보여줍니다:

```js
// Presentation 클래스의 인스턴스를 생성합니다.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // 마스터, 레이아웃 및 테마를 고려하여 실제 배경을 가져옵니다.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

**사용자 지정 배경을 재설정하고 테마/레이아웃 배경을 복원할 수 있나요?**

예. 슬라이드의 사용자 지정 채우기를 제거하면 배경이 해당 [레이아웃](/slides/ko/nodejs-java/slide-layout/)/[마스터](/slides/ko/nodejs-java/slide-master/) 슬라이드(즉, [테마 배경](/slides/ko/nodejs-java/presentation-theme/))에서 다시 상속됩니다.

**프레젠테이션의 테마를 나중에 변경하면 배경은 어떻게 되나요?**

슬라이드에 자체 채우기가 있으면 변경되지 않습니다. 배경이 [레이아웃](/slides/ko/nodejs-java/slide-layout/)/[마스터](/slides/ko/nodejs-java/slide-master/)에서 상속된 경우 새 테마에 맞게 업데이트됩니다.