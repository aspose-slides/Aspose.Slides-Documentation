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
- 3D 그라디언트
- 3D 텍스트
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Node.js에서 PowerPoint 모양 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 압출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for Node.js via Java은 모양 및 텍스트에 대한 PowerPoint 스타일 3D 서식을 생성, 편집, 보존 및 렌더링할 수 있습니다. 이 문서는 회전, 압출, 베벨, 조명, 재질, 그라디언트 또는 그림 채우기, 그리고 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="primary" %}}
이 문서는 PowerPoint 모양 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 아닙니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

Use [Shape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/).`getThreeDFormat()`를 사용하여 모양에 3D 서식을 적용합니다. 반환된 [ThreeDFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/) 객체는 해당 모양의 3D 장면을 제어합니다.

For text, use [TextFrameFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/).`getThreeDFormat()`. This applies 3D formatting to the text frame instead of the shape body.

가장 중요한 API 멤버는 다음과 같습니다:

| API 멤버 | 제어하는 내용 | 사용 시점 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getCamera) | 시점, 미리 설정된 카메라 유형, 회전, 확대/축소 및 원근감. | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 프리셋에 맞춥니다. |
| [getLightRig](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getLightRig) | 조명 프리셋, 방향 및 조명 회전. | 3D 표면의 하이라이트와 그림자 표시 방식을 변경합니다. |
| [getMaterial](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#setMaterial) | 평면, 무광, 플라스틱, 금속 등의 표면 재질. | 동일한 기하학을 더 평평하게, 부드럽게, 광택 있게 또는 금속처럼 보이게 합니다. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | 모양이 앞면에서 뒤쪽으로 얼마나 확장되는지. | 평면 모양을 눈에 보이는 두꺼운 3D 객체로 전환합니다. |
| [getExtrusionColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | 압출된 측면의 색상. | 깊이를 보이게 하거나 측면 색상을 앞면 채우기와 조정합니다. |
| [getDepth](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#setDepth) | PowerPoint 3D 서식에서 사용되는 추가 3D 깊이. | 모양이나 텍스트의 깊이를 미세 조정합니다, 특히 베벨 및 재질 설정과 함께 사용할 때. |
| [getBevelTop](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | 앞면 및 뒷면의 돌출 또는 둥근 가장자리. | 날카로운 평면 대신 부드럽거나 성형된 가장자리를 추가합니다. |
| [getContourColor](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/threedformat/#setContourWidth) | 3D 객체 주변의 외곽선. | 렌더링된 출력에서 객체 경계를 강조합니다. |

## **3D 모양 만들기**

모양이 설득력 있게 3D로 보이려면 일반적으로 네 가지 설정이 필요합니다:

- 카메라 설정, 기본 정면 뷰가 압출을 숨길 수 있기 때문입니다.
- 조명 설정, 조명이 면과 측면을 읽을 수 있게 하기 때문입니다.
- 재질 설정, 표면이 조명 렌더링 방식에 영향을 주기 때문입니다.
- 압출 또는 깊이 설정, 평면 모양에 두께가 필요하기 때문입니다.

The following example creates a rectangle, adds text to its front face, applies 3D formatting, saves the presentation as PPTX, and renders the slide to a PNG image.

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(blueColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(blueColor);

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

렌더링된 슬라이드 이미지가 사각형을 두꺼운 3D 블록으로 보여줍니다:

![앞면에 흰색 3D 텍스트가 있는 파란색 3D 사각형 렌더링](img_01_01.png)

## **카메라를 사용한 모양 회전**

PowerPoint에서는 3‑D Rotation 창에서 3D 회전을 구성합니다. X, Y, Z 회전값은 카메라 API를 통해 설정한 회전과 대응됩니다.

![X, Y, Z 회전 값이 강조 표시된 PowerPoint 3D 회전 창](img_02_01.png)

In Aspose.Slides, set the camera type and rotation through the 3D format returned by `shape.getThreeDFormat()`:

```javascript
shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

뷰어가 객체를 보는 방식을 바꾸어야 할 때 카메라를 사용합니다. 이것은 슬라이드상의 2D 모양 기하학을 변경하지 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 시점을 변경합니다.

## **압출 및 깊이 추가**

압출은 앞면 뒤로 모양을 연장시켜 두껍게 보이게 합니다. PowerPoint에서 깊이 컨트롤은 이 가시적인 두께를 설정하고, 색상 컨트롤은 측면 색상을 설정합니다.

![압출 색상 및 압출 높이 속성에 매핑된 PowerPoint 깊이 컨트롤](img_02_02.png)

두께를 위한 압출 높이와 측면 색상을 위한 압출 색상을 설정합니다:

```javascript
const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

PowerPoint의 깊이 값을 직접 다루거나 깊이를 베벨, 재질 및 텍스트 효과와 결합해야 할 때 깊이 설정을 사용합니다. 많은 모양 상황에서 압출 높이가 가시적인 압출을 직접 표현하므로 더 명확한 설정입니다.

## **그라디언트 또는 그림 채우기를 3D 효과와 함께 사용하기**

3D 서식은 모양 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 그림 채우기를 적용하면서도 동일한 카메라, 조명, 재질 및 압출 설정을 사용할 수 있습니다.

이 예제는 모양에 그라디언트 채우기를 적용하고 측면에 어두운 압출 색을 적용합니다:

```javascript
const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");
    const orangeColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, blueColor);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);

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

그라디언트가 앞면에 유지되고 압출이 별도로 렌더링됩니다:

![파란색-오렌지 그라디언트 채우기와 오렌지 압출이 있는 3D 사각형 렌더링](img_02_03.png)

그 대신 그림 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 모양 채우기에 지정합니다:

```javascript
const sourceImage = aspose.slides.Images.fromFile("image.jpg");
let presentationImage;
try {
    presentationImage = presentation.getImages().addImage(sourceImage);
} finally {
    sourceImage.dispose();
}

shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(presentationImage);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(darkOrangeColor);
```

그림이 앞면에 렌더링되고 압출은 3D 측면 표면으로 렌더링됩니다:

![앞면에 사진 채우기와 오렌지 압출이 있는 3D 사각형 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용**

Shape 3D 서식은 모양 본문에 영향을 주고, Text 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 글자 자체에 압출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

The following example creates text with a pattern fill, applies a WordArt transform, and configures 3D settings on [TextFrameFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/textframeformat/):

```javascript
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
    const darkOrangeColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    const whiteColor = java.getStaticFieldValue("java.awt.Color", "WHITE");
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrangeColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(whiteColor);
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

![활아치형 WordArt 변환, 오렌지 패턴 채우기 및 어두운 압출이 적용된 3D 텍스트 렌더링](img_02_05.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 래스터화되거나 2D 결과물로 출력에 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/nodejs-java/convert-powerpoint-to-png/)로 렌더링하거나, [PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/)로 내보내거나, [HTML](/slides/ko/nodejs-java/convert-powerpoint-to-html/)로 내보내거나, [video conversion](/slides/ko/nodejs-java/convert-powerpoint-to-video/)용 프레임을 생성할 때 모두 적용됩니다.

아래 사항을 기억하세요:

- 내보낸 이미지와 PDF는 대화형이 아닙니다. 객체는 내보낸 후 뷰어에 의해 회전될 수 없습니다.
- 최종 모습은 카메라, 라이트 rig, 재질, 압출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 확인하려면 [effective shape properties](/slides/ko/nodejs-java/shape-effective-properties/)을 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 편집 가능한 3D 설정으로 보존되지 않고 렌더링됩니다.

## **FAQ**

**Aspose.Slides가 대화형 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 모양 및 텍스트에 대한 PowerPoint 3D 효과를 생성하고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 뷰어가 회전할 수 있는 대화형 3D 씬으로 만들지는 않습니다. PPTX에서는 해당 형식이 지원되는 경우 PowerPoint에서 3D 서식이 편집 가능하게 유지됩니다.

**3D 모델과 3D 효과의 차이는 무엇인가요?**

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 회전, 압출, 베벨, 조명 및 재질과 같은 일반 PowerPoint 모양이나 텍스트에 적용되는 서식입니다. 이 문서는 3D 효과에 대해 다룹니다.

**보이는 3D 모양을 만들기 위해 필요한 설정은 무엇인가요?**

최소한 카메라 회전과 압출 또는 깊이 중 하나를 설정해야 합니다. 실무에서는 라이트 rig와 재질까지 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 일반적입니다.

**모양과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예. Shape(`getThreeDFormat()`)를 모양 본문에, TextFrameFormat(`getThreeDFormat()`)를 텍스트에 사용하면 됩니다.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 나타나나요?**

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환에 사용되는 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 결과물에는 렌더링된 외관이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 읽을 수 있나요?**

예. 최종 카메라, 라이트 rig, 베벨 및 관련 3D 값을 읽으려면 [Shape Effective Properties](/slides/ko/nodejs-java/shape-effective-properties/)에 설명된 효과적인 서식 API를 사용하십시오.