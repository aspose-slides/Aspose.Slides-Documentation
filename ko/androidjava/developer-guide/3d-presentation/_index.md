---
title: Android에서 프레젠테이션에 3D 효과 만들기
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/androidjava/3d-presentation/
keywords:
- 3D 파워포인트
- 3D 프레젠테이션
- 3D 회전
- 3D 깊이
- 3D 압출
- 3D 그라디언트
- 3D 텍스트
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Android에서 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 압출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for Android via Java는 도형 및 텍스트에 대한 PowerPoint 스타일 3D 서식을 만들고, 편집하고, 보존하며 렌더링할 수 있습니다. 이 문서에서는 회전, 압출, 베벨, 조명, 재질, 그라디언트 또는 그림 채우기, 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" %}}

이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 다루지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.

{{% /alert %}}

## **3D 서식 개념**

도형에 3D 서식을 적용하려면 [IShape.getThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) 메서드를 사용합니다. 이 메서드는 해당 도형의 3D 장면을 제어하는 [IThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/)을 반환합니다.

텍스트의 경우 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) 메서드를 사용합니다. 이는 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 API 멤버는 다음과 같습니다:

| API 멤버 | 제어 내용 | 사용 시점 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | 시점, 사전 설정 카메라 유형, 회전, 줌 및 원근감 | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 사전 설정에 맞출 때 |
| [getLightRig](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | 조명 사전 설정, 방향 및 빛 회전 | 3D 표면의 하이라이트와 그림자 표시 방식을 변경할 때 |
| [getMaterial](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) 및 [setMaterial](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | 평면, 무광, 플라스틱, 금속 등 표면 재질 | 같은 기하 형태를 더 평평하게, 부드럽게, 광택 있게 또는 금속처럼 보이게 할 때 |
| [getExtrusionHeight](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 및 [setExtrusionHeight](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 전면에서 뒤쪽으로 연장되는 거리 | 평면 도형을 눈에 보이는 두께가 있는 3D 객체로 만들 때 |
| [getExtrusionColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 압출된 측면의 색상 | 깊이를 보이게 하거나 전면 채우기와 색을 맞출 때 |
| [getDepth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getDepth--) 및 [setDepth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 서식에서 사용하는 추가 깊이 | 베벨 및 재질 설정과 함께 도형이나 텍스트의 깊이를 미세 조정할 때 |
| [getBevelTop](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) 및 [getBevelBottom](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | 전면 및 후면 가장자리에 적용되는 양각 또는 둥근 모서리 | 날카로운 평면 대신 부드럽거나 성형된 가장자리를 추가할 때 |
| [getContourColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), 및 [setContourWidth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 객체 주변의 외곽선 | 렌더링된 출력에서 객체 경계를 강조하고 싶을 때 |

## **3D 도형 만들기**

도형을 설득력 있게 3D로 보이게 하려면 일반적으로 다음 네 가지 설정이 필요합니다:

- 카메라 설정 – 기본 정면 뷰에서는 압출이 숨겨질 수 있습니다.
- 조명 설정 – 조명이 있어야 면과 측면이 읽히기 쉽습니다.
- 재질 설정 – 표면 재질이 빛의 렌더링 방식에 영향을 줍니다.
- 압출 또는 깊이 설정 – 평면 도형에 두께를 부여합니다.

다음 예제는 사각형을 만들고, 전면에 텍스트를 추가하고, 3D 서식을 적용한 뒤 프레젠테이션을 PPTX로 저장하고 슬라이드를 PNG 이미지로 렌더링합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

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

렌더링된 슬라이드 이미지에서 사각형이 두꺼운 3D 블록으로 표시됩니다:

![Rendered blue 3D rectangle with white 3D text on the front face](img_01_01.png)

## **카메라로 도형 회전하기**

PowerPoint에서 3‑D 회전은 3‑D 회전 창에서 설정합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정하는 회전과 동일합니다.

![PowerPoint 3-D Rotation pane with X, Y, and Z rotation values highlighted](img_02_01.png)

Aspose.Slides에서는 [IThreeDFormat.getCamera](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getCamera--)를 통해 카메라 유형과 회전을 설정합니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

카메라는 사용자가 객체를 보는 방식을 변경할 때 사용합니다. 슬라이드상의 2D 도형 기하학을 바꾸지는 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용하는 3D 시점을 변경합니다.

## **압출 및 깊이 추가하기**

압출은 전면에서 뒤쪽으로 연장되어 도형을 두껍게 보이게 합니다. PowerPoint에서 깊이 제어는 이 가시적인 두께를 설정하고, 색상 제어는 측면 색을 지정합니다.

![PowerPoint depth controls mapped to extrusion color and extrusion height properties](img_02_02.png)

두께는 [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-)로, 측면 색은 [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--)으로 설정합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

PowerPoint의 깊이 값을 직접 사용하거나 깊이를 베벨, 재질, 텍스트 효과와 결합해야 할 때는 [IThreeDFormat.setDepth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-)를 사용합니다. 대부분의 도형에서는 `setExtrusionHeight`가 가시적인 압출을 직접 나타내므로 더 명확합니다.

## **3D 효과와 함께 그라디언트 또는 그림 채우기 사용하기**

3D 서식은 도형 채우기와 독립적입니다. 전면에 단색, 그라디언트, 패턴 또는 그림 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 압출 설정을 사용할 수 있습니다.

다음 예제는 도형에 그라디언트 채우기를 적용하고 측면에 더 어두운 압출 색을 지정합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

렌더링된 결과는 전면에 그라디언트를 유지하고 압출을 별도로 렌더링합니다:

![Rendered 3D rectangle with a blue-to-orange gradient fill and orange extrusion](img_02_03.png)

그 대신 그림 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 도형 채우기로 할당합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

그림은 전면에 렌더링되고 압출은 3D 측면 표면으로 렌더링됩니다:

![Rendered 3D rectangle with a photo fill on the front face and orange extrusion](img_02_04.png)

## **텍스트에 3D 서식 적용하기**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 글자 자체에 압출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 패턴 채우기가 적용된 텍스트를 만들고 WordArt 변형을 적용한 뒤 [ITextFrameFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/)에 3D 설정을 구성합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

텍스트는 곡선형으로 압출된 3D 문자로 렌더링됩니다:

![Rendered 3D text with an arched WordArt transform, orange pattern fill, and dark extrusion](img_02_05.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 2D 결과물로 래스터화되거나 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/androidjava/convert-powerpoint-to-png/)으로 렌더링하거나, [PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/)로 내보내거나, [HTML](/slides/ko/androidjava/convert-powerpoint-to-html/)로 내보내거나, [비디오 변환](/slides/ko/androidjava/convert-powerpoint-to-video/)을 위해 프레임을 생성할 때 모두 적용됩니다.

주의할 점:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 객체를 뷰어가 내보낸 뒤 회전시킬 수 없습니다.
- 최종 모습은 카메라, 라이트 릭, 재질, 압출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 확인하려면 [effective shape properties](/slides/ko/androidjava/shape-effective-properties/)를 참조하십시오.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장하지 못합니다. 이러한 형식에서는 시각적 결과가 렌더링되어 저장되며 편집 가능한 3D 설정은 보존되지 않습니다.

## **FAQ**

### Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?

Aspose.Slides는 도형과 텍스트에 대한 PowerPoint 3D 효과를 만들고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 회전할 수 있는 인터랙티브 3D 씬으로 만들지는 않습니다. PPTX에서는 3D 서식이 지원되는 경우 PowerPoint에서 편집 가능한 상태로 유지됩니다.

### 3D 모델과 3D 효과의 차이는 무엇인가요?

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 일반 도형이나 텍스트에 적용되는 서식으로, 회전, 압출, 베벨, 조명, 재질 등이 포함됩니다. 이 문서는 3D 효과에 대해 다룹니다.

### 눈에 보이는 3D 도형을 만들기 위해 필요한 설정은 무엇인가요?

최소한 카메라 회전과 압출 또는 깊이를 설정해야 합니다. 실제로는 라이트 릭과 재질도 함께 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 좋습니다.

### 도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?

예. 도형 본문에는 [IShape.getThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getThreeDFormat--)을, 텍스트에는 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--)를 사용하십시오.

### 이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 표시되나요?

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환에 사용되는 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 결과물에는 렌더링된 모습이 포함되며 편집 가능한 3D 객체는 포함되지 않습니다.

### 상속 및 테마 설정이 적용된 최종 3D 값을 읽을 수 있나요?

예. [Shape Effective Properties](/slides/ko/androidjava/shape-effective-properties/)에 설명된 효과적인 서식 API를 사용하여 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽을 수 있습니다.