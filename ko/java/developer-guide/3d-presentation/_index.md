---
title: Java를 사용해 프레젠테이션에 3D 효과 만들기
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/java/3d-presentation/
keywords:
- 3D 파워포인트
- 3D 프레젠테이션
- 3D 회전
- 3D 깊이
- 3D 압출
- 3D 그라디언트
- 3D 텍스트
- 파워포인트
- 프레젠테이션
- 자바
- Aspose.Slides
description: "Java와 Aspose.Slides를 사용하여 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 압출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for Java는 도형과 텍스트에 대한 PowerPoint 스타일 3D 서식을 생성, 편집, 보존 및 렌더링할 수 있습니다. 이 문서에서는 회전, 압출, 베벨, 조명, 재질, 그라디언트 또는 이미지 채우기, 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="primary" %}}
이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 포함하지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 반영합니다.
{{% /alert %}}

## **3D 서식 개념**

[IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/).`getThreeDFormat()`을 사용하여 도형에 3D 서식을 적용합니다. 반환된 서식 객체가 해당 도형의 3D 장면을 제어합니다.

텍스트의 경우, [ITextFrameFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`을 사용합니다. 이는 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 API 멤버는 다음과 같습니다:

| API 멤버 | 제어 내용 | 사용 시점 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getCamera--) | 시점, 사전 설정 카메라 유형, 회전, 줌 및 원근 | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 사전 설정에 맞추려는 경우 |
| [getLightRig](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getLightRig--) | 조명 사전 설정, 방향 및 조명 회전 | 3D 표면의 하이라이트와 그림자 표시 방식을 변경하려는 경우 |
| [getMaterial](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getMaterial--) 및 [setMaterial](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | 플랫, 매트, 플라스틱, 금속 등 표면 재질 | 동일한 기하학을 더 평평하게, 부드럽게, 광택 있게 또는 금속성으로 보이게 하려는 경우 |
| [getExtrusionHeight](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 및 [setExtrusionHeight](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 형태가 앞면으로부터 뒤쪽으로 얼마나 뻗어나가는지 | 평면 형태를 눈에 보이는 두꺼운 3D 객체로 전환하려는 경우 |
| [getExtrusionColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 압출된 면의 색상 | 깊이를 가시화하거나 측면 색을 앞면 채우기와 일치시키려는 경우 |
| [getDepth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getDepth--) 및 [setDepth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 서식에서 사용하는 추가 3D 깊이 | 형태나 텍스트의 깊이를 미세 조정하려는 경우, 특히 베벨 및 재질 설정과 함께 사용할 때 |
| [getBevelTop](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getBevelTop--) 및 [getBevelBottom](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 앞면과 뒷면의 돌출되거나 둥근 가장자리 | 날카로운 평면 대신 부드럽거나 몰딩된 가장자리를 추가하려는 경우 |
| [getContourColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getContourWidth--), 및 [setContourWidth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 객체 주변 윤곽선 | 렌더링된 출력에서 객체 경계를 강조하려는 경우 |

## **3D 도형 만들기**

도형이 설득력 있게 3D처럼 보이려면 일반적으로 다음 네 가지 설정이 필요합니다:

- 카메라 설정(기본 정면 보기에서는 압출이 보이지 않을 수 있기 때문).
- 조명 설정(조명이 면과 측면을 읽을 수 있게 함).
- 재질 설정(표면이 빛을 어떻게 반사하는지에 영향을 줌).
- 압출 또는 깊이 설정(평면 형태에 두께가 필요함).

다음 예제는 사각형을 만들고, 앞면에 텍스트를 추가한 뒤 3D 서식을 적용하고, 프레젠테이션을 PPTX로 저장하며 슬라이드를 PNG 이미지로 렌더링합니다.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

렌더링된 슬라이드 이미지는 사각형이 두꺼운 3D 블록으로 표시됩니다:

![전면에 흰색 3D 텍스트가 있는 파란색 3D 직사각형 렌더링 이미지](img_01_01.png)

## **카메라로 도형 회전하기**

PowerPoint에서 3D 회전은 3‑D Rotation 패널에서 구성합니다. X, Y, Z 회전값은 카메라 API를 통해 설정한 회전과 일치합니다.

![X, Y, Z 회전값이 강조된 PowerPoint 3-D 회전 패널](img_02_01.png)

Aspose.Slides에서는 `shape.getThreeDFormat()`이 반환한 3D 서식을 통해 카메라 유형과 회전을 설정합니다:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

시청자가 객체를 보는 방식을 변경해야 할 때 카메라를 사용합니다. 이는 슬라이드의 2D 도형 기하학을 변경하지 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 시점을 변경합니다.

## **압출 및 깊이 추가**

압출은 앞면 뒤쪽으로 형태를 확장시켜 두껍게 보이게 합니다. PowerPoint에서 깊이 제어는 이 가시적인 두께를 설정하고, 색상 제어는 측면 면의 색을 정합니다.

![PowerPoint 깊이 제어가 압출 색상 및 압출 높이 속성에 매핑된 모습](img_02_02.png)

두께를 위한 압출 높이와 측면 색을 위한 압출 색상을 설정합니다:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

PowerPoint의 깊이 값을 직접 사용하거나 깊이를 베벨, 재질, 텍스트 효과와 결합해야 할 경우 깊이 설정을 사용합니다. 많은 도형 시나리오에서는 압출 높이가 보이는 압출을 직접 표현하므로 더 명확한 설정입니다.

## **3D 효과와 함께 그라디언트 또는 이미지 채우기 사용**

3D 서식은 도형 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 이미지 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 압출 설정을 사용할 수 있습니다.

다음 예제는 도형에 그라디언트 채우기를 적용하고 측면에 어두운 압출 색을 적용합니다:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

![파란색에서 주황색으로 그라디언트 채우기와 주황색 압출이 적용된 3D 직사각형 렌더링](img_02_03.png)

이미지 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 도형 채우기에 할당합니다:

```java
java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

Color extrusionColor = new Color(255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

![전면에 사진 채우기와 주황색 압출이 적용된 3D 직사각형 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 문자 자체에 압출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 패턴 채우기가 적용된 텍스트를 만들고 WordArt 변환을 적용한 뒤 [ITextFrameFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`을 사용해 3D 설정을 구성합니다:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![호형 WordArt 변환, 주황색 패턴 채우기 및 어두운 압출이 적용된 3D 텍스트 렌더링](img_02_05.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 2D 결과로 래스터화되거나 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/java/convert-powerpoint-to-png/)으로 렌더링하거나, [PDF](/slides/ko/java/convert-powerpoint-to-pdf/)로 내보내거나, [HTML](/slides/ko/java/convert-powerpoint-to-html/)로 내보내거나, [비디오 변환](/slides/ko/java/convert-powerpoint-to-video/)용 프레임을 생성할 때도 적용됩니다.

다음 사항에 유의하세요:

- 내보낸 이미지 및 PDF는 인터랙티브하지 않으며, 내보낸 후에 사용자가 객체를 회전시킬 수 없습니다.
- 최종 모습은 카메라, 조명, 재질, 압출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 형식 값들을 확인하려면 [effective shape properties](/slides/ko/java/shape-effective-properties/)를 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 렌더링되어 저장되며, 편집 가능한 3D 설정은 유지되지 않습니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 도형과 텍스트에 대한 PowerPoint 3D 효과를 생성하고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 회전할 수 있는 인터랙티브 3D 씬으로 만들지는 않습니다. PPTX에서는 해당 형식이 지원되는 경우 3D 서식이 PowerPoint에서 편집 가능하게 유지됩니다.

**3D 모델과 3D 효과의 차이점은 무엇인가요?**

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 일반 도형이나 텍스트에 적용되는 회전, 압출, 베벨, 조명, 재질 등의 서식입니다. 본 문서는 3D 효과에 대해 다룹니다.

**가시적인 3D 도형에 필요한 설정은 무엇인가요?**

최소한 카메라 회전과 압출 또는 깊이 중 하나를 설정해야 합니다. 실제로는 조명과 재질도 함께 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 일반적입니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예. 도형 본문에는 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/).`getThreeDFormat()`을, 텍스트에는 [ITextFrameFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`을 사용합니다.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 나타나나요?**

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환용 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 결과물에는 렌더링된 모습이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 읽을 수 있나요?**

예. 최종 카메라, 조명, 베벨 및 관련 3D 값을 읽으려면 [Shape Effective Properties](/slides/ko/java/shape-effective-properties/)에 설명된 효과적인 서식 API를 사용하십시오.