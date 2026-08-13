---
title: Java를 사용한 프레젠테이션의 3D 효과 만들기
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 프레젠테이션
- 3D 회전
- 3D 깊이
- 3D 돌출
- 3D 그라데이션
- 3D 텍스트
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 돌출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for Java는 도형 및 텍스트에 대한 PowerPoint 스타일 3D 서식을 만들고, 편집하고, 보존하며, 렌더링할 수 있습니다. 이 문서에서는 회전, 돌출, 베벨, 조명, 재질, 그라데이션 또는 그림 채우기, 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" %}}
이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 포함하지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

[IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/).`getThreeDFormat()`을 사용하여 도형에 3D 서식을 적용합니다. 반환된 서식 객체가 해당 도형의 3D 씬을 제어합니다.

텍스트의 경우 [ITextFrameFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`을 사용합니다. 이 메서드는 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 API 멤버는 다음과 같습니다:

| API 멤버 | 제어하는 내용 | 사용 시점 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getCamera--) | 시점, 미리 설정된 카메라 유형, 회전, 줌 및 원근. | 객체를 3D 공간에서 회전시키거나 PowerPoint 3D 회전 프리셋에 맞출 때. |
| [getLightRig](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getLightRig--) | 조명 프리셋, 방향 및 조명 회전. | 3D 표면의 하이라이트와 그림자 표시 방식을 변경할 때. |
| [getMaterial](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getMaterial--) 및 [setMaterial](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | 평면, 무광, 플라스틱, 금속 등 표면 재질. | 같은 형상이 더 평평하게, 부드럽게, 광택 있게, 또는 금속처럼 보이게 할 때. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 및 [setExtrusionHeight](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 도형이 앞면에서 뒤쪽으로 얼마나 연장되는지. | 평면 도형을 눈에 보이는 두꺼운 3D 객체로 만들 때. |
| [getExtrusionColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 돌출된 측면의 색상. | 깊이를 보이게 하거나 측면 색을 앞채우기와 맞출 때. |
| [getDepth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getDepth--) 및 [setDepth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 서식에서 사용하는 추가 3D 깊이. | 특히 베벨 및 재질 설정과 함께 도형이나 텍스트의 깊이를 미세 조정할 때. |
| [getBevelTop](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getBevelTop--) 및 [getBevelBottom](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 앞면 및 뒷면의 돌출되거나 둥근 가장자리. | 날카롭고 평평한 면 대신 부드럽거나 몰딩된 가장자리를 추가할 때. |
| [getContourColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getContourWidth--), 및 [setContourWidth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 객체 주위의 외곽선. | 렌더된 출력에서 객체 경계선을 강조할 때. |

## **3D 도형 만들기**

실제 3D처럼 보이게 하려면 도형에 네 가지 종류의 설정이 일반적으로 필요합니다:

- 카메라 설정, 기본 정면 뷰가 돌출을 가릴 수 있기 때문입니다.
- 조명 설정, 조명이 면과 측면을 읽을 수 있게 하기 때문입니다.
- 재질 설정, 표면이 빛이 렌더링되는 방식을 영향을 주기 때문입니다.
- 돌출 또는 깊이 설정, 평면 도형에 두께가 필요하기 때문입니다.

다음 예제는 사각형을 만들고 앞면에 텍스트를 추가한 뒤 3D 서식을 적용하고 프레젠테이션을 PPTX로 저장한 뒤 슬라이드를 PNG 이미지로 렌더링합니다.

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

렌더된 슬라이드 이미지는 사각형을 두꺼운 3D 블록으로 보여 줍니다:

![앞면에 흰색 3D 텍스트가 있는 파란색 3D 직사각형 렌더링](img_01_01.png)

## **카메라를 사용한 도형 회전**

PowerPoint에서 3D 회전은 3‑D Rotation 창에서 설정합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정한 회전과 대응합니다.

![X, Y, Z 회전 값이 강조된 PowerPoint 3D 회전 창](img_02_01.png)

Aspose.Slides에서는 `shape.getThreeDFormat()`이 반환하는 3D 서식을 통해 카메라 유형과 회전을 설정합니다:

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

뷰어가 객체를 보는 방식을 변경해야 할 때 카메라를 사용합니다. 이는 슬라이드상의 2D 도형 기하학을 변경하지 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용하는 3D 관점을 변경합니다.

## **돌출 및 깊이 추가**

돌출은 앞면 뒤쪽으로 연장시켜 도형을 두껍게 보이게 합니다. PowerPoint에서 깊이 제어는 이 보이는 두께를 설정하고, 색상 제어는 측면의 색을 설정합니다.

![돌출 색 및 돌출 높이 속성에 매핑된 PowerPoint 깊이 제어](img_02_02.png)

두께를 위한 돌출 높이와 측면 색을 위한 돌출 색을 설정합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

PowerPoint의 깊이 값을 직접 사용하거나 깊이를 베벨, 재질, 텍스트 효과와 결합해야 할 때 깊이 설정을 사용합니다. 많은 도형 상황에서 돌출 높이가 보이는 돌출을 직접 표현하기 때문에 더 명확한 설정입니다.

## **그라데이션 또는 이미지 채우기를 3D 효과와 함께 사용**

3D 서식은 도형 채우기와 독립적입니다. 전면에 단색, 그라데이션, 패턴 또는 그림 채우기를 적용하면서도 동일한 카메라, 조명, 재질 및 돌출 설정을 사용할 수 있습니다.

다음 예제는 도형에 그라데이션 채우기를 적용하고 측면에 더 어두운 돌출 색을 적용합니다:

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

그라데이션은 전면에 유지되고 돌출은 별도로 렌더링됩니다:

![파란색에서 주황색으로 그라데이션 채우기와 주황색 돌출이 적용된 3D 직사각형 렌더링](img_02_03.png)

대신 그림 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 도형 채우기에 할당합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

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
} finally {
    presentation.dispose();
}
```

그림은 전면에 렌더링되고, 돌출은 3D 측면 표면으로 렌더링됩니다:

![앞면에 사진 채우기와 주황색 돌출이 적용된 3D 직사각형 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 글자 자체에 돌출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 패턴 채우기가 있는 텍스트를 만들고 WordArt 변형을 적용한 뒤 [ITextFrameFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`에 3D 설정을 구성합니다:

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

텍스트는 곡선형으로 돌출된 3D 레터링으로 렌더링됩니다:

![아치형 WordArt 변형, 주황색 패턴 채우기 및 어두운 돌출이 적용된 3D 텍스트 렌더링](img_02_05.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 씬은 2D 결과로 래스터화되거나 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/java/convert-powerpoint-to-png/)로 렌더링하거나, [PDF](/slides/ko/java/convert-powerpoint-to-pdf/)로 내보내거나, [HTML](/slides/ko/java/convert-powerpoint-to-html/)로 내보내거나, [비디오 변환](/slides/ko/java/convert-powerpoint-to-video/)용 프레임을 생성할 때 적용됩니다.

주의할 점:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 객체를 내보낸 후에 뷰어가 회전시킬 수 없습니다.
- 최종 모습은 카메라, 라이트 릭, 재질, 돌출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 확인해야 하는 경우, [effective shape properties](/slides/ko/java/shape-effective-properties/)를 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 편집 가능한 3D 설정으로 보존되지 않고 렌더링됩니다.

## **FAQ**

### Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?

Aspose.Slides는 도형 및 텍스트에 대한 PowerPoint 3D 효과를 만들고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 인터랙티브 3D 씬으로 만들어 뷰어가 회전하도록 하지는 않습니다. PPTX에서는 형식이 지원되는 경우 3D 서식이 PowerPoint에서 편집 가능하게 유지됩니다.

### 3D 모델과 3D 효과의 차이는 무엇인가요?

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 일반 PowerPoint 도형이나 텍스트에 적용되는 서식으로, 회전, 돌출, 베벨, 조명 및 재질 등을 포함합니다. 이 문서는 3D 효과에 대해 다룹니다.

### 눈에 보이는 3D 도형을 만들기 위해 필요한 설정은 무엇인가요?

최소한 카메라 회전과 돌출 또는 깊이를 설정해야 합니다. 실제로는 조명 릭과 재질도 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 좋습니다.

### 도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?

예. 도형 본문에는 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/).`getThreeDFormat()`을, 텍스트에는 [ITextFrameFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`을 사용합니다.

### 이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 표시되나요?

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환용 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 출력에는 렌더된 모습이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

### 상속 및 테마 적용 후 최종 3D 값을 읽을 수 있나요?

예. 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽으려면 [Shape Effective Properties](/slides/ko/java/shape-effective-properties/)에 설명된 효과적인 서식 API를 사용하십시오.