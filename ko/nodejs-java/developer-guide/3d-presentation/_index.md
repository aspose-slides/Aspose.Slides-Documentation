---
title: Node.js를 사용한 프레젠테이션에서 3D 효과 만들기
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/nodejs-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 프레젠테이션
- 3D 회전
- 3D 깊이
- 3D 압출
- 3D 그라데이션
- 3D 텍스트
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Node.js에서 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 압출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for Node.js via Java는 도형 및 텍스트에 대한 PowerPoint 스타일 3D 서식을 만들고, 편집하고, 보존하며, 렌더링할 수 있습니다. 이 문서에서는 회전, 압출, 베벨, 조명, 재질, 그라디언트 또는 사진 채우기, 그리고 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" title="Note" %}}
이 문서는 PowerPoint 도형과 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 포함하지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

[Shape.getThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getThreeDFormat) 메서드를 사용하여 도형에 3D 서식을 적용합니다. 이 메서드는 해당 도형의 3D 씬을 제어하는 [ThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/)을 반환합니다.

텍스트의 경우 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) 메서드를 사용합니다. 이 메서드는 텍스트 프레임에 3D 서식을 적용하며 도형 본체에는 적용되지 않습니다.

가장 중요한 API 멤버는 다음과 같습니다:

| API 멤버 | 제어하는 내용 | 사용 시점 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getCamera) | 시점, 미리 설정된 카메라 유형, 회전, 확대/축소 및 원근감. | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 프리셋과 일치시킬 때. |
| [getLightRig](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getLightRig) | 조명 프리셋, 방향 및 조명 회전. | 3D 표면에 하이라이트와 그림자가 어떻게 표시되는지 변경할 때. |
| [getMaterial](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getMaterial)와 [setMaterial](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#setMaterial) | 평면, 매트, 플라스틱 또는 금속과 같은 표면 재질. | 동일한 기하학을 더 평평하게, 부드럽게, 광택 있게 또는 금속처럼 보이게 할 때. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight)와 [setExtrusionHeight](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | 도형이 앞면으로부터 뒤쪽으로 얼마나 뻗어 있는지. | 평면 도형을 눈에 보이는 두께가 있는 3D 객체로 바꿀 때. |
| [getExtrusionColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | 압출된 측면의 색상. | 깊이를 보이게 하거나 앞면 채우기와 색을 맞출 때. |
| [getDepth](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getDepth)와 [setDepth](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 서식에서 사용되는 추가 3D 깊이. | 특히 베벨 및 재질 설정과 함께 도형이나 텍스트의 깊이를 미세 조정할 때. |
| [getBevelTop](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getBevelTop)와 [getBevelBottom](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | 앞면 및 뒷면 가장자리의 돌출 또는 둥근 모양. | 날카로운 평면 대신 부드럽거나 몰딩된 가장자리를 추가할 때. |
| [getContourColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getContourWidth), 그리고 [setContourWidth](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3D 객체 주변의 외곽선. | 렌더링된 출력에서 객체 경계를 강조하고 싶을 때. |

## **3D 도형 만들기**

도형이 설득력 있게 3D처럼 보이기 위해서는 일반적으로 네 가지 설정이 필요합니다:

- 카메라 설정: 기본 정면 뷰가 압출을 가릴 수 있기 때문입니다.
- 조명 설정: 조명이 면과 측면을 읽을 수 있게 하기 때문입니다.
- 재질 설정: 표면이 조명에 어떻게 렌더링되는지에 영향을 주기 때문입니다.
- 압출 또는 깊이 설정: 평면 도형에 두께가 필요하기 때문입니다.

다음 예제는 사각형을 만들고, 앞면에 텍스트를 추가한 뒤 3D 서식을 적용합니다. 카메라 회전 값은 도(degree) 단위이며, 압출 높이는 100포인트입니다. 예제는 슬라이드를 PNG 이미지로 두 배 크기로 렌더링하고 프레젠테이션을 PPTX로 저장합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

렌더링된 슬라이드 이미지에서 사각형이 두꺼운 3D 블록으로 표시됩니다:

![전면에 흰색 3D 텍스트가 있는 파란색 3D 직사각형 렌더링 이미지](img_01_01.png)

## **카메라로 도형 회전하기**

PowerPoint에서는 3‑D 회전 창에서 회전을 설정합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정하는 회전 값과 대응합니다.

![X, Y, Z 회전 값이 강조된 PowerPoint 3D 회전 패널](img_02_01.png)

Aspose.Slides에서는 [ThreeDFormat.getCamera](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getCamera)를 통해 카메라에 접근합니다. 이 예제는 사각형을 만들고, 직교 정면 뷰를 선택한 뒤 X, Y, Z 회전을 각각 20, 30, 40도로 설정합니다. 파일을 저장하지 않고 메모리에서 도형을 구성합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

카메라는 뷰어가 객체를 보는 관점을 변경할 때 사용합니다. 슬라이드의 2D 도형 기하학 자체를 바꾸지는 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 관점을 변경합니다.

## **압출 및 깊이 추가**

압출은 도형을 앞면 뒤쪽으로 확장시켜 두껍게 보이게 합니다. PowerPoint에서 깊이 제어는 이 보이는 두께를 설정하고, 색상 제어는 측면 색을 설정합니다.

![압출 색상 및 압출 높이 속성에 매핑된 PowerPoint 깊이 제어](img_02_02.png)

[ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight)로 두께를 지정하고, [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getExtrusionColor)로 측면 색을 가져옵니다. 이 예제는 사각형에 100포인트 압출을 적용하고 보라색 측면을 설정한 뒤 카메라를 회전시켜 두께를 보여줍니다. 파일을 저장하지 않고 메모리에서 도형을 구성합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

[ThreeDFormat.setDepth](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#setDepth) 메서드는 3D 도형의 깊이를 설정합니다. [setExtrusionHeight](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) 메서드는 압출 효과의 높이를 제어합니다(예제 참고).

## **3D 효과와 함께 그라디언트 또는 사진 채우기 사용**

3D 서식은 도형 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 사진 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 압출 설정을 사용할 수 있습니다.

다음 예제는 앞면에 파란색‑주황색 그라디언트를 적용하고 150포인트 압출에 어두운 주황색을 사용합니다. 그라디언트 정지는 0과 100에서 시작·끝을 표시합니다. 카메라 회전 값은 도(degree) 단위이며, 슬라이드를 PNG 이미지로 두 배 크기로 렌더링합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

렌더링된 결과는 앞면의 그라디언트를 유지하고 압출은 별도로 렌더링됩니다:

![파란색-주황색 그라디언트 채우기와 주황색 압출을 적용한 3D 직사각형 렌더링 이미지](img_02_03.png)

사진 채우기를 사용하려면 프레젠테이션에 이미지를 추가하고 도형 채우기에 할당합니다. 이 예제는 작업 디렉터리에 "image.jpg" 파일이 존재한다고 가정합니다. 사진을 사각형에 늘려 채우고, 150포인트 압출을 적용하며, 카메라 회전을 도 단위로 설정합니다. 파일을 저장하거나 렌더링하지 않고 메모리에서 도형을 구성합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

사진은 앞면에 렌더링되고, 압출은 3D 측면 표면으로 렌더링됩니다:

![전면에 사진 채우기가 적용되고 주황색 압출이 있는 3D 직사각형 렌더링 이미지](img_02_04.png)

## **텍스트에 3D 서식 적용**

도형 3D 서식은 도형 본체에 영향을 미칩니다. 텍스트 3D 서식은 텍스트 프레임에 영향을 미칩니다. 이는 글자 자체에 압출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 주황색‑흰색 격자 패턴 텍스트를 만들고, 위쪽 아치를 적용한 뒤 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat)를 통해 3D 설정을 구성합니다. 압출 높이와 깊이는 포인트 단위이며, 조명 회전은 도(degree) 단위입니다. 도형 채우기와 외곽선을 숨겨 텍스트만 보이도록 합니다. 예제는 기본 슬라이드 크기의 두 배인 PNG 이미지로 렌더링하고 프레젠테이션을 PPTX로 저장합니다:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

텍스트가 곡선형으로 압출된 3D 레터링으로 렌더링됩니다:

![아치형 WordArt 변환, 주황색 패턴 채우기 및 어두운 압출이 적용된 3D 텍스트 렌더링 이미지](img_02_05.png)

## **3D 도형에 텍스트 평면 유지**

텍스트를 3D 씬에서 제외하고 도형의 3D 외관을 유지하려면 [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframe/#getTextFrameFormat)를 통해 [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat)를 호출합니다. 값이 `true`이면 텍스트가 3D 씬에서 제외됩니다. `false`이면 텍스트가 씬에 포함되어 3D 방향을 따릅니다.

이 설정은 도형의 3D 서식을 제거하지 않습니다. 카메라, 조명, 재질 및 압출은 [Shape.getThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getThreeDFormat)으로 계속 구성됩니다. 또한 일반 회전과는 다릅니다. [Shape.setRotation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#setRotation)은 슬라이드 평면에서 도형을 회전시키고, [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#setRotationAngle)은 텍스트의 경계 상자 내에서 사용자 정의 회전을 제어합니다. 텍스트를 3D 씬에서 제외해도 이 각도들은 재설정되지 않습니다.

다음 독립형 예제는 파란 사각형에 텍스트를 추가하고 원본 옆에 복제합니다. 두 도형 모두 동일한 3D 서식을 가지지만 텍스트 설정만 다릅니다: 왼쪽은 `false`, 오른쪽은 `true`. 카메라 각도는 도(degree) 단위이며, 압출 높이는 40포인트입니다. 프레젠테이션을 PPTX로 저장하고 비교 슬라이드를 PNG로 두 배 크기로 렌더링합니다.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

왼쪽은 텍스트가 3D 방향을 따르고, 오른쪽은 평면을 유지해 더 읽기 쉽습니다. 두 사각형 모두 동일한 압출과 3D 방향을 보입니다.

![왼쪽은 3D 방향을 따르는 텍스트, 오른쪽은 평면을 유지하는 텍스트가 있는 나란히 배치된 3D 직사각형](keep_text_flat.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 유지합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 경우 3D 씬은 래스터화되거나 2D 결과로 출력에 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/nodejs-java/convert-powerpoint-to-png/)로 렌더링하거나, [PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/)로 내보내거나, [HTML](/slides/ko/nodejs-java/convert-powerpoint-to-html/)로 내보내거나, [비디오 변환](/slides/ko/nodejs-java/convert-powerpoint-to-video/)을 위한 프레임을 생성할 때 모두 적용됩니다.

다음 사항을 기억하세요:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 내보낸 후에는 뷰어가 객체를 회전시킬 수 없습니다.
- 최종 모습은 카메라, 라이트 릭, 재질, 압출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 형식 값을 확인하려면 [effective shape properties](/slides/ko/nodejs-java/shape-effective-properties/)를 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 편집 가능한 3D 설정이 아니라 렌더링된 이미지로 저장됩니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 도형과 텍스트에 대한 PowerPoint 3D 효과를 생성하고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 인터랙티브 3D 씬으로 만들지는 않으며, 뷰어가 회전할 수 없습니다. PPTX에서는 해당 형식이 지원되는 경우 PowerPoint에서 3D 서식을 편집할 수 있습니다.

**3D 모델과 3D 효과의 차이는 무엇인가요?**

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 일반 PowerPoint 도형이나 텍스트에 적용되는 서식으로, 회전, 압출, 베벨, 조명 및 재질 등이 포함됩니다. 이 문서는 3D 효과에 대해 다룹니다.

**볼 수 있는 3D 도형을 만들기 위해 필요한 설정은 무엇인가요?**

최소한 카메라 회전과 압출 또는 깊이를 설정해야 합니다. 실제로는 조명 릭과 재질도 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 좋습니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예, 도형 본체에는 [Shape.getThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getThreeDFormat)를, 텍스트에는 [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat)를 사용합니다.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 나타나요?**

예, Aspose.Slides는 슬라이드 이미지를 만들거나 PDF, HTML 출력, 비디오 변환 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 결과물에는 렌더링된 모양이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 최종 3D 값을 읽을 수 있나요?**

예, [Shape Effective Properties](/slides/ko/nodejs-java/shape-effective-properties/)에 설명된 효과적인 서식 API를 사용하여 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽을 수 있습니다.