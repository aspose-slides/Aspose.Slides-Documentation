---
title: JavaScript에서 PowerPoint 도형 서식 지정
linktitle: 도형 서식 지정
type: docs
weight: 20
url: /ko/nodejs-java/shape-formatting/
keywords:
- 도형 서식 지정
- 선 서식 지정
- 스케치 효과
- 스케치 도형 선
- 조인 스타일 서식 지정
- 그라데이션 채우기
- 패턴 채우기
- 그림 채우기
- 텍스처 채우기
- 단색 채우기
- 도형 투명도
- 흑백 도형 렌더링
- 그레이스케일 도형 렌더링
- 도형 회전
- 3D 베벨 효과
- 3D 회전 효과
- 서식 초기화
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides를 사용하여 JavaScript에서 PowerPoint 도형을 서식 지정합니다—PPT, PPTX 및 ODP 파일에 대해 정확하고 완전한 제어로 채우기, 선 및 효과 스타일을 설정합니다."
---
## **소개**

PowerPoint에서는 슬라이드에 도형을 추가할 수 있습니다. 도형은 선으로 구성되어 있기 때문에 외곽선을 수정하거나 효과를 적용하여 서식을 지정할 수 있습니다. 또한 내부를 채우는 방식을 제어하는 설정을 지정하여 도형을 서식 지정할 수 있습니다.

![PowerPoint에서 도형 서식 지정](format-shape-powerpoint.png)

Java를 사용하는 Node.js용 Aspose.Slides는 PowerPoint에서 제공되는 동일한 옵션을 사용하여 도형을 서식 지정할 수 있는 클래스와 메서드를 제공합니다.

## **선 서식 지정**

Aspose.Slides를 사용하면 도형에 사용자 지정 선 스타일을 지정할 수 있습니다. 다음 단계가 절차를 설명합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 AutoShape를 추가합니다.
1. 도형의 선 스타일을 설정합니다.
1. 선 너비를 설정합니다.
1. 선의 대시 스타일을 설정합니다.
1. 도형의 선 색을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 사각형 `AutoShape`를 서식 지정하는 방법을 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle 유형의 자동 도형을 추가합니다.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // 사각형 도형에서 채우기를 제거합니다.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // 사각형 선에 서식을 적용합니다.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // 사각형 선의 색상을 설정합니다.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

결과:

![프레젠테이션에서 서식 지정된 선](formatted-lines.png)

## **도형 선에 스케치 효과 적용**

스케치 효과는 도형 선을 손으로 그린 것처럼 보이게 합니다. [Shape.getLineFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/)을 사용하여 선 설정에 접근하고, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/lineformat/)을 사용하여 스케치 설정에 접근하며, [SketchFormat.setSketchType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sketchformat/)을 사용하여 [LineSketchType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/linesketchtype/) 열거형에서 값을 선택합니다.

다음 JavaScript 코드는 [LineSketchType.Curved](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/linesketchtype/) 효과를 적용하고, 명시적으로 할당된 값을 읽으며, [LineSketchType.None](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/linesketchtype/)을 사용하여 효과를 제거하는 방법을 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // 도형의 선 서식 및 스케치 서식에 접근합니다.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // 스케치 효과를 적용합니다.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // 도형에 직접 할당된 스케치 효과를 읽습니다.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // 스케치 효과를 제거합니다.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

[SketchFormat.getSketchType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/sketchformat/)이 반환하는 값은 도형에 직접 할당된 설정을 나타냅니다. 선 서식이 테마, 마스터 슬라이드 또는 레이아웃 슬라이드에서 상속될 수 있는 경우 [LineFormat.getEffective](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/lineformat/)을 사용하고, 반환된 객체에서 `getSketchFormat`을 호출한 다음 `getSketchType` 메서드를 호출합니다. 유효값은 상속이 해결된 후 실제 적용된 서식을 반영합니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **조인 스타일 서식 지정**

다음은 세 가지 조인 타입 옵션입니다:

* 라운드
* 마이터
* 베벨

기본적으로 PowerPoint가 두 선을 각도로 연결할 때(예: 도형의 모서리) **라운드** 설정을 사용합니다. 그러나 날카로운 각도의 도형을 그리는 경우 **마이터** 옵션을 선호할 수 있습니다.

![프레젠테이션의 조인 스타일](join-style-powerpoint.png)

다음 JavaScript 코드는 위 이미지에 표시된 세 개의 사각형이 마이터, 베벨, 라운드 조인 타입 설정을 사용하여 어떻게 생성되었는지 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle 유형의 자동 도형 세 개를 추가합니다.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // 각 사각형 도형의 채우기 색상을 설정합니다.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // 선 너비를 설정합니다.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // 각 사각형 선의 색상을 설정합니다.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // 조인 스타일을 설정합니다.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // 각 사각형에 텍스트를 추가합니다.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **그라데이션 채우기**

PowerPoint에서 그라데이션 채우기는 도형에 연속적인 색상 혼합을 적용할 수 있는 서식 옵션입니다. 예를 들어, 두 개 이상의 색상을 적용하여 하나가 점차 다른 색상으로 흐르게 할 수 있습니다.

Aspose.Slides를 사용하여 도형에 그라데이션 채우기를 적용하는 방법은 다음과 같습니다:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 AutoShape를 추가합니다.
1. 도형의 FillType을 `Gradient`로 설정합니다.
1. [GradientFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/gradientformat/) 클래스가 제공하는 그라데이션 스톱 컬렉션의 `add` 메서드를 사용하여 정의된 위치와 함께 원하는 두 색상을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 타원에 그라데이션 채우기 효과를 적용하는 방법을 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    let slide = presentation.getSlides().get_Item(0);

    // Ellipse 유형의 자동 도형을 추가합니다.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // 타원에 그라데이션 서식을 적용합니다.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // 그라데이션 방향을 설정합니다.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // 두 개의 그라데이션 스톱을 추가합니다.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![그라데이션 채우기 적용된 타원](gradient-fill.png)

## **패턴 채우기**

PowerPoint에서 패턴 채우기는 도형에 두 가지 색상의 디자인(점, 줄무늬, 교차선, 체크 등)을 적용할 수 있는 서식 옵션입니다. 패턴의 전경색과 배경색을 사용자 지정 색상으로 선택할 수 있습니다.

Aspose.Slides는 프레젠테이션의 시각적 매력을 높이기 위해 도형에 적용할 수 있는 45가지 이상의 사전 정의된 패턴 스타일을 제공합니다. 사전 정의된 패턴을 선택한 후에도 사용할 정확한 색상을 지정할 수 있습니다.

Aspose.Slides를 사용하여 도형에 패턴 채우기를 적용하는 방법은 다음과 같습니다:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 AutoShape를 추가합니다.
1. 도형의 FillType을 `Pattern`으로 설정합니다.
1. 사전 정의된 옵션 중에서 패턴 스타일을 선택합니다.
1. 패턴의 배경 색상을 설정합니다.
1. 패턴의 전경 색상을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 사각형에 패턴 채우기를 적용하는 방법을 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle 유형의 자동 도형을 추가합니다.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 채우기 유형을 Pattern으로 설정합니다.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // 패턴 스타일을 설정합니다.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // 패턴 배경색과 전경색을 설정합니다.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![패턴 채우기 적용된 사각형](pattern-fill.png)

## **그림 채우기**

PowerPoint에서 그림 채우기는 이미지를 도형 내부에 삽입하여 도형의 배경으로 사용하는 서식 옵션입니다.

Aspose.Slides를 사용하여 도형에 그림 채우기를 적용하는 방법은 다음과 같습니다:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 AutoShape를 추가합니다.
1. 도형의 FillType을 `Picture`로 설정합니다.
1. 그림 채우기 모드를 `Tile`(또는 다른 선호 모드)으로 설정합니다.
1. 사용하려는 이미지에서 PPImage 객체를 생성합니다.
1. `ISlidesPicture.setImage` 메서드에 이미지를 전달합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

"lotus.png" 파일에 다음과 같은 그림이 있다고 가정합니다:

![연꽃 그림](lotus.png)

다음 JavaScript 코드는 그림으로 도형을 채우는 방법을 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle 유형의 자동 도형을 추가합니다.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // 채우기 유형을 Picture로 설정합니다.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // 그림 채우기 모드를 설정합니다.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // 이미지를 로드하고 프레젠테이션 리소스에 추가합니다.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // 그림을 설정합니다.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![그림 채우기 적용된 도형](picture-fill.png)

### **텍스처로 타일 그림 사용**

타일 그림을 텍스처로 설정하고 타일링 동작을 사용자 지정하려면 [PictureFillFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/) 클래스의 다음 메서드를 사용할 수 있습니다:

- `setPictureFillMode`(https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): 그림 채우기 모드(`Tile` 또는 `Stretch`)를 설정합니다.
- `setTileAlignment`(https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): 도형 내 타일의 정렬을 지정합니다.
- `setTileFlip`(https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): 타일을 가로, 세로 또는 모두 뒤집을지 제어합니다.
- `setTileOffsetX`(https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): 도형의 원점으로부터 타일의 가로 오프셋(포인트)을 설정합니다.
- `setTileOffsetY`(https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): 도형의 원점으로부터 타일의 세로 오프셋(포인트)을 설정합니다.
- `setTileScaleX`(https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): 타일의 가로 스케일을 백분율로 정의합니다.
- `setTileScaleY`(https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): 타일의 세로 스케일을 백분율로 정의합니다.

다음 코드 예제는 타일 그림 채우기가 적용된 사각형 도형을 추가하고 타일 옵션을 구성하는 방법을 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    let firstSlide = presentation.getSlides().get_Item(0);

    // 사각형 자동 도형을 추가합니다.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // 도형의 채우기 유형을 Picture로 설정합니다.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // 이미지를 로드하고 프레젠테이션 리소스에 추가합니다.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // 이미지를 도형에 할당합니다.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // 그림 채우기 모드와 타일링 속성을 구성합니다.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![타일 옵션](tile-options.png)

## **단색 채우기**

PowerPoint에서 단색 채우기는 도형을 하나의 동일한 색으로 채우는 서식 옵션입니다. 이 단순한 배경 색은 그라데이션, 텍스처 또는 패턴 없이 적용됩니다.

Aspose.Slides를 사용하여 도형에 단색 채우기를 적용하려면 다음 단계에 따르세요:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 AutoShape를 추가합니다.
1. 도형의 FillType을 `Solid`로 설정합니다.
1. 도형에 원하는 채우기 색을 지정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 JavaScript 코드는 PowerPoint 슬라이드의 사각형에 단색 채우기를 적용하는 방법을 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle 유형의 자동 도형을 추가합니다.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 채우기 유형을 Solid로 설정합니다.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // 채우기 색상을 설정합니다.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![단색 채우기 적용된 도형](solid-color-fill.png)

## **투명도 설정**

PowerPoint에서 도형에 단색, 그라데이션, 그림 또는 텍스처 채우기를 적용할 때, 채우기의 불투명도를 제어하기 위해 투명도 수준을 설정할 수 있습니다. 투명도 값이 높을수록 도형이 더 투명해져 배경이나 아래 개체가 부분적으로 보이게 됩니다.

Aspose.Slides는 채우기에 사용되는 색상의 알파 값을 조정하여 투명도 수준을 설정할 수 있습니다. 방법은 다음과 같습니다:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 AutoShape를 추가합니다.
1. FillType을 `Solid`로 설정합니다.
1. `Color`를 사용하여 투명도가 있는 색을 정의합니다(`alpha` 구성 요소가 투명도를 제어합니다).
1. 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 사각형에 투명 채우기 색상을 적용하는 방법을 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    let slide = presentation.getSlides().get_Item(0);

    // 단색 사각형 자동 도형을 추가합니다.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 단색 도형 위에 투명한 사각형 자동 도형을 추가합니다.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![투명한 도형](shape-transparency.png)

## **도형 회전**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 도형을 회전시킬 수 있습니다. 이는 특정 정렬이나 디자인 요구에 맞게 시각 요소를 배치할 때 유용합니다.

슬라이드에서 도형을 회전시키려면 다음 단계에 따르세요:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 AutoShape를 추가합니다.
1. 도형의 회전 속성을 원하는 각도로 설정합니다.
1. 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 도형을 5도 회전하는 방법을 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
let presentation = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드를 가져옵니다.
    let slide = presentation.getSlides().get_Item(0);

    // Rectangle 유형의 자동 도형을 추가합니다.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // 도형을 5도 회전시킵니다.
    shape.setRotation(5);

    // PPTX 파일을 디스크에 저장합니다.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![도형 회전](shape-rotation.png)

## **3D 베벨 효과 추가**

Aspose.Slides는 도형의 [ThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/) 속성을 구성하여 3D 베벨 효과를 적용할 수 있습니다.

도형에 3D 베벨 효과를 추가하려면 다음 단계에 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 AutoShape를 추가합니다.
1. 도형의 [ThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/)을 구성하여 베벨 설정을 정의합니다.
1. 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 도형에 3D 베벨 효과를 적용하는 방법을 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Presentation 클래스의 인스턴스를 생성합니다.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // 슬라이드에 도형을 추가합니다.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // 도형의 ThreeDFormat 속성을 설정합니다.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![3D 베벨 효과](3D-bevel-effect.png)

## **3D 회전 효과 추가**

Aspose.Slides는 도형의 [ThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/) 속성을 구성하여 3D 회전 효과를 적용할 수 있습니다.

도형에 3D 회전을 적용하려면:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 AutoShape를 추가합니다.
1. [setCameraType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/camera/#setCameraType) 및 [setLightType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/lightrig/#setLightType)를 사용하여 3D 회전을 정의합니다.
1. 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 도형에 3D 회전 효과를 적용하는 방법을 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Presentation 클래스의 인스턴스를 생성합니다.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![3D 회전 효과](3D-rotation-effect.png)

## **도형의 흑백 렌더링 제어**

[Shape.setBlackWhiteMode](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) 메서드는 프레젠테이션을 흑백 모드로 보거나 처리할 때 개별 도형이 어떻게 렌더링되는지를 지정합니다. 이 메서드 자체가 흑백 표시를 활성화하지 않으며, 일반 색상 모드에서 도형의 채우기, 선 또는 기타 서식을 변경하지도 않습니다.

[BlackWhiteMode](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/blackwhitemode/) 열거형의 값을 사용하여 원하는 동작을 선택합니다. 예를 들어 `Automatic`은 렌더링 애플리케이션이 변환을 선택하도록 하고, `Gray`와 `LightGray`는 회색을 사용하며, `BlackWhite`는 검은색과 흰색만 사용하고, `Black`과 `White`는 단일 색을 강제하고, `Color`는 일반 색상을 유지하며, `Hidden`은 흑백 모드에서 도형을 생략합니다. `NotDefined`는 도형 수준 모드가 지정되지 않았음을 의미합니다.

다음 JavaScript 코드는 컬러 도형을 생성하고 흑백 표시 모드에서 회색으로 보이게 합니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // 컬러 모드에서는 주황색 채우기를 유지하고, 흑백 모드에서는 회색으로 렌더링합니다.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

일반 색상 모드에서는 사각형이 주황색 채우기를 유지합니다. 흑백 표시 워크플로에서는 모드가 `Gray`로 설정되어 있기 때문에 회색으로 표시됩니다. 이를 통해 전체 색상 슬라이드를 유지하면서 인쇄, 미리보기 또는 프레젠테이션의 흑백 표시 설정을 반영하는 기타 워크플로에 대해 별도의 외관을 정의할 수 있습니다.

## **서식 초기화**

다음 JavaScript 코드는 슬라이드의 서식을 초기화하고 [LayoutSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/layoutslide/)에 있는 모든 자리표시자 도형의 위치, 크기 및 서식을 기본 설정으로 되돌리는 방법을 보여줍니다:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // 레이아웃에 자리 표시자가 있는 슬라이드의 각 도형을 초기화합니다.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**도형 서식이 최종 프레젠테이션 파일 크기에 영향을 줍니까?**

거의 영향을 주지 않습니다. 삽입된 이미지와 미디어가 파일 용량의 대부분을 차지하며, 색상, 효과, 그라데이션과 같은 도형 매개변수는 메타데이터로 저장되어 실질적인 추가 용량을 거의 차지하지 않습니다.

**슬라이드에서 동일한 서식을 공유하는 도형을 어떻게 감지하여 그룹화할 수 있나요?**

각 도형의 핵심 서식 속성(채우기, 선, 효과 설정)을 비교합니다. 모든 해당 값이 일치하면 스타일을 동일하게 간주하고 논리적으로 해당 도형들을 그룹화하면 이후 스타일 관리를 간소화할 수 있습니다.

**맞춤 도형 스타일 집합을 별도 파일에 저장하여 다른 프레젠테이션에서 재사용할 수 있나요?**

예. 원하는 스타일이 적용된 샘플 도형을 템플릿 슬라이드 파일이나 .POTX 템플릿 파일에 저장합니다. 새 프레젠테이션을 만들 때 템플릿을 열어 필요한 스타일 도형을 복제하고, 필요한 곳마다 해당 서식을 다시 적용하면 됩니다.