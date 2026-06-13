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
- 3D 돌출
- 3D 그라데이션
- 3D 텍스트
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Android에서 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 돌출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for Android via Java는 도형과 텍스트에 대한 PowerPoint 스타일 3D 서식을 생성, 편집, 보존 및 렌더링할 수 있습니다. 이 문서에서는 회전, 돌출, 베벨, 조명, 재질, 그라데이션 또는 그림 채우기 및 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="primary" %}}
이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 포함하지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때, Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

도형에 3D 서식을 적용하려면 [IShape.getThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) 메서드를 사용합니다. 이 메서드는 해당 도형의 3D 장면을 제어하는 [IThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/)을 반환합니다.

텍스트의 경우 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) 메서드를 사용합니다. 이는 도형 본문이 아닌 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 API 멤버는 다음과 같습니다:

| API 멤버 | 제어하는 내용 | 사용 시기 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | 시점, 사전 설정 카메라 유형, 회전, 줌 및 원근감. | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 사전 설정과 일치시킵니다. |
| [getLightRig](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | 조명 사전 설정, 방향 및 조명 회전. | 3D 표면에 하이라이트와 그림자가 표시되는 방식을 변경합니다. |
| [getMaterial](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getMaterial--)와 [setMaterial](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | 표면 재료(예: 평면, 무광, 플라스틱 또는 금속). | 같은 형상이 더 평평하거나, 부드럽거나, 광택이 나거나, 금속처럼 보이게 합니다. |
| [getExtrusionHeight](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--)와 [setExtrusionHeight](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 도형이 전면에서 뒤쪽으로 얼마나 뻗어 있는지. | 평면 도형을 눈에 보이는 두꺼운 3D 객체로 변환합니다. |
| [getExtrusionColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 돌출된 측면의 색상. | 깊이를 보이게 하거나 측면 색을 전면 채우기와 일치시킵니다. |
| [getDepth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getDepth--)와 [setDepth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 서식에서 사용되는 추가 3D 깊이. | 도형이나 텍스트의 깊이를 미세 조정합니다. 특히 베벨 및 재질 설정과 함께 사용할 때 유용합니다. |
| [getBevelTop](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--)와 [getBevelBottom](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | 전면 및 후면에 돌출되거나 둥근 가장자리. | 날카롭고 평평한 면 대신 부드럽거나 형성된 가장자리를 추가합니다. |
| [getContourColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), 그리고 [setContourWidth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 객체 주위의 외곽선. | 렌더링된 출력에서 객체 경계를 강조합니다. |

## **3D 도형 만들기**

도형이 설득력 있게 3D처럼 보이기 위해서는 일반적으로 네 가지 설정이 필요합니다:

- 카메라 설정: 기본 정면 뷰가 돌출을 가릴 수 있기 때문입니다.
- 조명 설정: 조명이 면과 측면을 읽을 수 있게 하기 때문입니다.
- 재질 설정: 표면이 조명 렌더링에 영향을 주기 때문입니다.
- 돌출 또는 깊이 설정: 평면 도형에 두께가 필요하기 때문입니다.

다음 예제는 사각형을 만들고, 전면에 텍스트를 추가한 뒤 3D 서식을 적용하고, 프레젠테이션을 PPTX로 저장하며, 슬라이드를 PNG 이미지로 렌더링합니다.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

렌더링된 슬라이드 이미지에서는 사각형이 두꺼운 3D 블록으로 표시됩니다:

![전면에 흰색 3D 텍스트가 있는 파란색 3D 사각형 렌더링](img_01_01.png)

## **카메라로 도형 회전하기**

PowerPoint에서 3D 회전은 3-D 회전 패널에서 설정합니다. X, Y, Z 회전값은 카메라 API를 통해 설정한 회전과 대응됩니다.

![X, Y, Z 회전값이 강조된 PowerPoint 3-D 회전 패널](img_02_01.png)

Aspose.Slides에서는 [IThreeDFormat.getCamera](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getCamera--)을 사용해 카메라 유형과 회전을 설정합니다:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

뷰어가 객체를 보는 방식을 변경해야 할 때 카메라를 사용합니다. 이것은 슬라이드의 2D 도형 기하학을 변경하지 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 시점을 변경합니다.

## **돌출 및 깊이 추가**

돌출은 전면 뒤로 도형을 연장시켜 두껍게 보이게 합니다. PowerPoint에서 깊이 컨트롤은 이 가시적인 두께를 설정하고, 색상 컨트롤은 측면 색을 설정합니다.

![돌출 색 및 돌출 높이 속성에 매핑된 PowerPoint 깊이 컨트롤](img_02_02.png)

두께를 설정하려면 [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-)를, 측면 색을 설정하려면 [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--)를 사용합니다:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

PowerPoint의 깊이 값을 직접 사용하거나 깊이를 베벨, 재질, 텍스트 효과와 결합해야 할 경우 [IThreeDFormat.setDepth](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-)를 사용합니다. 많은 도형 시나리오에서 `setExtrusionHeight`가 가시적 돌출을 직접 나타내므로 더 명확한 설정입니다.

## **3D 효과와 함께 그라데이션 또는 사진 채우기 사용**

3D 서식은 도형 채우기와 독립적입니다. 전면에 단색, 그라데이션, 패턴 또는 사진 채우기를 적용하면서도 동일한 카메라, 조명, 재질 및 돌출 설정을 사용할 수 있습니다.

다음 예제는 도형에 그라데이션 채우기를 적용하고 측면에 어두운 돌출 색을 적용합니다:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

![파란색에서 주황색으로 그라데이션 채우기와 주황색 돌출이 적용된 3D 사각형 렌더링](img_02_03.png)

대신 사진 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 도형 채우기에 지정합니다:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

![전면에 사진 채우기와 주황색 돌출이 적용된 3D 사각형 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 글자 자체에 돌출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 유사한 효과에 유용합니다.

다음 예제는 패턴 채우기를 사용해 텍스트를 만들고, WordArt 변환을 적용하며, [ITextFrameFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/)에 3D 설정을 구성합니다:

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
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

![아치형 WordArt 변환, 주황색 패턴 채우기 및 어두운 돌출이 적용된 3D 텍스트 렌더링](img_02_05.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 래스터화되거나 2D 결과로 출력에 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/androidjava/convert-powerpoint-to-png/)로 렌더링하거나, [PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/)로 내보내거나, [HTML](/slides/ko/androidjava/convert-powerpoint-to-html/)로 내보내거나, [비디오 변환](/slides/ko/androidjava/convert-powerpoint-to-video/)을 위한 프레임을 생성할 때 적용됩니다.

다음 사항을 기억하십시오:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 객체는 내보낸 후에 뷰어가 회전시킬 수 없습니다.
- 최종 외관은 카메라, 라이트 릭, 재질, 돌출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 형식 값들을 확인해야 하면, [유효한 도형 속성](/slides/ko/androidjava/shape-effective-properties/)을 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 렌더링되어 편집 가능한 3D 설정으로 보존되지 않습니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있습니까?**

Aspose.Slides는 도형 및 텍스트에 대한 PowerPoint 3D 효과를 생성하고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 뷰어가 회전시킬 수 있는 인터랙티브 3D 장면으로 만들지는 않습니다. PPTX에서는 해당 형식이 지원되는 경우 PowerPoint에서 3D 서식이 편집 가능하게 유지됩니다.

**3D 모델과 3D 효과의 차이점은 무엇입니까?**

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 도형이나 텍스트에 적용되는 서식으로, 회전, 돌출, 베벨, 조명 및 재질 등이 포함됩니다. 이 문서는 3D 효과에 대해 다룹니다.

**보이는 3D 도형에 필요한 설정은 무엇입니까?**

최소한 카메라 회전과 돌출 또는 깊이 중 하나를 설정해야 합니다. 실제로는 라이트 릭과 재질도 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 좋습니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있습니까?**

예. 도형 본문에는 [IShape.getThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishape/#getThreeDFormat--)을, 텍스트에는 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--)을 사용합니다.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 나타납니까?**

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환을 위한 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 출력에는 렌더링된 외관이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 읽을 수 있습니까?**

예. [유효한 도형 속성](/slides/ko/androidjava/shape-effective-properties/)에 설명된 유효한 형식 API를 사용하여 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽을 수 있습니다.