---
title: Java를 사용한 프레젠테이션에서 3D 효과 만들기
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/java/3d-presentation/
keywords:
- 3D 파워포인트
- 3D 프레젠테이션
- 3D 회전
- 3D 깊이
- 3D 돌출
- 3D 그라디언트
- 3D 텍스트
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 돌출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for Java는 도형과 텍스트에 대해 PowerPoint 스타일의 3D 서식을 만들고, 편집하고, 보존하며, 렌더링할 수 있습니다. 이 문서에서는 회전, 돌출, 베벨, 조명, 재질, 그라디언트 또는 그림 채우기, 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" title="Note" %}}
이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 포함하지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

[IShape.getThreeDFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getThreeDFormat--) 메서드를 사용하여 도형에 3D 서식을 적용합니다. 이 메서드는 해당 도형의 3D 장면을 제어하는 [IThreeDFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/)을 반환합니다.

텍스트의 경우 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) 메서드를 사용합니다. 이는 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 API 멤버는 다음과 같습니다:

| API 멤버 | 제어하는 내용 | 사용 시점 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getCamera--) | 시점, 사전 설정 카메라 유형, 회전, 줌 및 원근. | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 사전 설정과 일치시킵니다. |
| [getLightRig](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getLightRig--) | 조명 사전 설정, 방향 및 조명 회전. | 3D 표면의 하이라이트와 그림자 표시 방식을 변경합니다. |
| [getMaterial](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getMaterial--) 및 [setMaterial](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | 평면, 무광, 플라스틱, 금속 등 표면 재질. | 동일한 기하학을 더 평평하게, 부드럽게, 광택 있게 또는 금속처럼 보이게 합니다. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 및 [setExtrusionHeight](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 도형이 전면에서 뒤쪽으로 얼마나 멀리 확장되는지. | 평면 도형을 눈에 보이는 두꺼운 3D 객체로 전환합니다. |
| [getExtrusionColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 돌출된 면의 색상. | 깊이를 가시화하거나 전면 채우기와 색을 맞춥니다. |
| [getDepth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getDepth--) 및 [setDepth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 서식에서 사용되는 추가 깊이. | 베벨 및 재질 설정과 함께 도형이나 텍스트의 깊이를 미세 조정합니다. |
| [getBevelTop](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getBevelTop--) 및 [getBevelBottom](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | 전면 및 후면 가장자리의 돌출 또는 둥근 모양. | 날카로운 평면 대신 부드럽거나 몰딩된 가장자리를 추가합니다. |
| [getContourColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getContourColor--) 및 [getContourWidth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getContourWidth--) 및 [setContourWidth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 객체 주변의 외곽선. | 렌더링된 출력에서 객체 경계를 강조합니다. |

## **3D 도형 만들기**

도형이 설득력 있게 3D로 보이려면 일반적으로 네 가지 설정이 필요합니다:

- 카메라 설정: 기본 전면 뷰가 돌출을 숨길 수 있기 때문입니다.
- 조명 설정: 조명이 면과 측면을 읽기 쉽게 만들기 때문입니다.
- 재질 설정: 표면이 빛에 어떻게 반응하는지를 결정하기 때문입니다.
- 돌출 또는 깊이 설정: 평면 도형에 두께가 필요하기 때문입니다.

다음 예제는 사각형을 만들고 전면에 텍스트를 추가한 뒤 3D 서식을 적용합니다. 카메라 회전 값은 도이며, 돌출 높이는 100 포인트입니다. 예제는 슬라이드를 PNG 이미지로 두 배 크기로 렌더링하고 프레젠테이션을 PPTX로 저장합니다.

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

렌더링된 슬라이드 이미지는 사각형이 두꺼운 3D 블록으로 표시됩니다:

![전면에 흰색 3D 텍스트가 있는 파란색 3D 직사각형 렌더링](img_01_01.png)

## **카메라를 사용해 도형 회전하기**

PowerPoint에서 3D 회전은 3‑D 회전 창에서 구성합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정하는 회전과 대응합니다.

![X, Y, Z 회전 값이 강조된 PowerPoint 3‑D 회전 창](img_02_01.png)

Aspose.Slides에서는 [IThreeDFormat.getCamera](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getCamera--)을 통해 카메라에 접근합니다. 이 예제는 사각형을 만들고 정사영 전면 뷰를 선택한 뒤 X, Y, Z 회전을 각각 20°, 30°, 40°로 설정합니다. 파일을 저장하지 않고 메모리 내에서 도형을 구성합니다:

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

카메라는 뷰어가 객체를 보는 방식을 변경할 때 사용합니다. 슬라이드상의 2D 도형 기하학을 바꾸지는 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 시점을 변경합니다.

## **돌출 및 깊이 추가하기**

돌출은 전면에서 뒤쪽으로 확장되어 도형을 두껍게 보이게 합니다. PowerPoint에서 깊이 컨트롤은 이 가시적인 두께를 설정하고, 색상 컨트롤은 측면 면의 색을 설정합니다.

![돌출 색상 및 돌출 높이 속성에 매핑된 PowerPoint 깊이 컨트롤](img_02_02.png)

[IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-)을 사용해 두께를 설정하고, [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#getExtrusionColor--)을 사용해 측면 색을 가져옵니다. 이 예제는 사각형에 100 포인트 돌출을 적용하고 보라색 측면을 지정한 뒤 카메라를 회전해 두께를 확인합니다. 파일을 저장하지 않고 메모리 내에서 도형을 구성합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setDepth-double-) 메서드는 3D 도형의 깊이를 설정합니다. [setExtrusionHeight](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 메서드는 돌출 효과의 높이를 제어합니다(예제 참조).

## **그라디언트 또는 그림 채우기와 3D 효과 결합하기**

3D 서식은 도형 채우기와 독립적입니다. 전면에 단색, 그라디언트, 패턴 또는 그림 채우기를 적용하면서도 동일한 카메라, 조명, 재질 및 돌출 설정을 사용할 수 있습니다.

이 예제는 전면에 파란색‑주황색 그라디언트를 적용하고 150 포인트 돌출에 짙은 주황색을 적용합니다. 그라디언트 정지는 0과 100에서 시작과 끝을 나타냅니다. 카메라 회전 값은 도이며, 슬라이드는 두 배 크기의 PNG 이미지로 렌더링됩니다:

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

렌더링된 출력은 전면의 그라디언트를 유지하고 돌출은 별도로 렌더링합니다:

![파란색‑주황색 그라디언트 채우기와 주황색 돌출이 있는 3D 직사각형 렌더링](img_02_03.png)

그림 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 도형 채우기에 할당합니다. 이 예제는 작업 디렉터리에 "image.jpg"라는 파일이 존재한다고 가정합니다. 그림을 사각형에 맞게 늘리고 150 포인트 돌출을 적용하며 카메라 회전을 도 단위로 설정합니다. 파일을 저장하거나 렌더링하지 않고 메모리 내에서 도형을 구성합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

그림은 전면에 렌더링되고, 돌출은 3D 측면 표면으로 렌더링됩니다:

![전면에 사진 채우기가 있는 3D 직사각형과 주황색 돌출 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용하기**

도형 3D 서식은 도형 본문에 영향을 줍니다. 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 문자 자체에 돌출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 주황색‑흰색 격자 패턴 텍스트를 만들고 위쪽 아치를 적용한 뒤 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#getThreeDFormat--)를 통해 3D 설정을 구성합니다. 돌출 높이와 깊이는 포인트 단위이며, 조명 회전은 도 단위입니다. 도형 채우기와 외곽선은 숨겨져 텍스트만 표시됩니다. 예제는 기본 슬라이드 크기의 두 배인 PNG 이미지로 렌더링하고 프레젠테이션을 PPTX로 저장합니다:

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

텍스트는 곡선형으로 돌출된 3D 문자로 렌더링됩니다:

![아치형 WordArt 변형, 주황색 패턴 채우기와 짙은 돌출이 적용된 3D 텍스트 렌더링](img_02_05.png)

## **3D 도형 위에 텍스트를 평면으로 유지하기**

텍스트를 읽기 쉽도록 하면서 도형의 3D 모습을 유지하려면 [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-)을 [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/#getTextFrameFormat--)를 통해 호출합니다. 값이 `true`이면 텍스트가 3D 장면에서 제외됩니다. `false`이면 텍스트가 장면에 참여하여 3D 방향을 따릅니다.

이 설정은 도형의 3D 서식을 제거하지 않습니다: 카메라, 조명, 재질 및 돌출은 [IShape.getThreeDFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getThreeDFormat--)을 통해 계속 구성됩니다. 또한 일반 회전과도 다릅니다. [IShape.setRotation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#setRotation-float-)은 슬라이드 평면에서 도형을 회전시키고, [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-)은 텍스트의 경계 상자 내 사용자 정의 회전을 제어합니다. 텍스트를 3D 장면에서 제외해도 이 각도들은 리셋되지 않습니다.

다음 자체 포함 예제는 파란색 사각형에 텍스트를 추가하고 원본 옆에 복제본을 만듭니다. 두 도형 모두 동일한 3D 서식을 가지지만 텍스트 설정만 다릅니다: 왼쪽은 `false`, 오른쪽은 `true`. 카메라 각도는 도이며, 돌출 높이는 40 포인트입니다. 예제는 프레젠테이션을 PPTX로 저장하고 비교 슬라이드를 두 배 크기의 PNG로 렌더링합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

왼쪽에서는 텍스트가 3D 방향을 따르고, 오른쪽에서는 평면을 유지해 읽기 쉽습니다. 두 사각형 모두 동일한 가시적인 돌출과 3D 방향을 유지합니다.

![좌우 나란히 배치된 3D 직사각형: 왼쪽은 텍스트가 3D 방향을 따르고, 오른쪽은 평면을 유지](keep_text_flat.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 래스터화되어 2D 결과물로 출력에 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/java/convert-powerpoint-to-png/)로 렌더링하거나, [PDF](/slides/ko/java/convert-powerpoint-to-pdf/)로 내보내거나, [HTML](/slides/ko/java/convert-powerpoint-to-html/)로 내보내거나, [비디오 변환](/slides/ko/java/convert-powerpoint-to-video/)을 위한 프레임을 생성할 때 모두 적용됩니다.

다음 사항을 기억하세요:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 내보낸 후 사용자가 객체를 회전시킬 수 없습니다.
- 최종 모습은 카메라, 라이트 릭, 재질, 돌출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 확인해야 하면 [유효 도형 속성](/slides/ko/java/shape-effective-properties/)을 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 편집 가능한 3D 설정이 아니라 렌더링된 이미지로 저장됩니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 도형과 텍스트에 대한 PowerPoint 3D 효과를 만들고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 인터랙티브 3D 씬으로 만들어 사용자가 회전시킬 수 있게 하지는 않습니다. PPTX에서는 형식이 지원하는 경우 3D 서식이 PowerPoint에서 편집 가능하게 유지됩니다.

**3D 모델과 3D 효과의 차이는 무엇인가요?**

3D 모델은 프레젠테이션에 삽입된 별도 3D 객체입니다. 3D 효과는 도형이나 텍스트에 적용되는 서식이며, 회전, 돌출, 베벨, 조명 및 재질 등을 포함합니다. 이 문서는 3D 효과에 대해서만 다룹니다.

**가시적인 3D 도형을 만들기 위해 필요한 설정은 무엇인가요?**

최소한 카메라 회전과 돌출 또는 깊이를 설정해야 합니다. 실제로는 라이트 릭과 재질도 설정해 렌더링된 면에 명확한 하이라이트와 그림자를 제공합니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예, 도형 본문에는 [IShape.getThreeDFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getThreeDFormat--)를, 텍스트에는 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframeformat/#getThreeDFormat--)를 사용합니다.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 나타나나요?**

예, Aspose.Slides는 슬라이드 이미지를 생성하고, PDF 출력, HTML 출력 및 비디오 변환을 위한 프레임을 만들 때 3D 효과를 렌더링합니다. 내보낸 출력에는 렌더링된 모습이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 최종 3D 값을 읽을 수 있나요?**

예, [도형 유효 속성](/slides/ko/java/shape-effective-properties/)에 설명된 유효 서식 API를 사용해 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽을 수 있습니다.