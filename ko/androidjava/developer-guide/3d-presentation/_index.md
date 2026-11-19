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
description: "Android에서 Aspose.Slides를 사용하여 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 압출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for Android via Java는 도형과 텍스트에 대한 PowerPoint 스타일 3D 서식을 만들고, 편집하고, 보존하고, 렌더링할 수 있습니다. 이 문서는 회전, 압출, 베벨, 조명, 재질, 그라디언트 또는 그림 채우기, 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" title="Note" %}}

이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 포함하지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.

{{% /alert %}}

## **3D 서식 개념**

[IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) 메서드를 사용하여 도형에 3D 서식을 적용합니다. 이 메서드는 해당 도형의 3D 장면을 제어하는 [IThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/)을 반환합니다.

텍스트의 경우 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) 메서드를 사용합니다. 이는 텍스트 프레임에 3D 서식을 적용하며 도형 본문에는 적용되지 않습니다.

가장 중요한 API 멤버는 다음과 같습니다:

| API 멤버 | 제어하는 내용 | 사용 시점 |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | 시점, 사전 설정 카메라 유형, 회전, 확대/축소 및 원근감. | 3D 공간에서 개체를 회전하거나 PowerPoint 3D 회전 사전 설정에 맞출 때. |
| [getLightRig](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | 조명 사전 설정, 방향 및 조명 회전. | 3D 표면의 하이라이트와 그림자 표시 방식을 변경할 때. |
| [getMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) 및 [setMaterial](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | 평면, 무광, 플라스틱, 금속 등 표면 재질. | 동일한 기하학을 더 평평하게, 부드럽게, 광택 있게 또는 금속처럼 보이게 할 때. |
| [getExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) 및 [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | 앞면에서 뒤쪽으로 도형이 확장되는 거리. | 평면 도형을 눈에 보이는 두꺼운 3D 개체로 전환할 때. |
| [getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | 압출된 면의 색상. | 깊이를 강조하거나 앞면 채우기와 색을 맞출 때. |
| [getDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getDepth--) 및 [setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | PowerPoint 3D 서식에서 사용하는 추가 3D 깊이. | 베벨 및 재질 설정과 함께 도형이나 텍스트의 깊이를 미세 조정할 때. |
| [getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) 및 [getBevelBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | 앞면 및 뒷면 가장자리의 돌출 또는 둥근 가장자리. | 날카로운 평면 대신 부드럽거나 몰딩된 가장자리를 추가할 때. |
| [getContourColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) 및 [getContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) 및 [setContourWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | 3D 개체 주변의 외곽선. | 렌더링된 출력물에서 개체 경계를 강조할 때. |

## **3D 도형 만들기**

도형이 설득력 있게 3D처럼 보이려면 일반적으로 네 가지 설정이 필요합니다:

- 카메라 설정 – 기본 정면 보기에서는 압출이 가려질 수 있습니다.
- 조명 설정 – 조명이 면과 측면을 읽기 쉽게 합니다.
- 재질 설정 – 표면이 빛을 어떻게 반사하는지 영향을 줍니다.
- 압출 또는 깊이 설정 – 평면 도형에 두께를 부여합니다.

다음 예제는 사각형을 만들고 앞면에 텍스트를 추가한 뒤 3D 서식을 적용합니다. 카메라 회전 값은 도이며, 압출 높이는 100포인트입니다. 예제는 슬라이드를 PNG 이미지로 두 배 크기로 렌더링하고 프레젠테이션을 PPTX로 저장합니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![렌더링된 파란색 3D 사각형에 앞면에 흰색 3D 텍스트가 있음](img_01_01.png)

## **카메라로 도형 회전하기**

PowerPoint에서는 3‑D 회전 창에서 회전을 설정합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정한 회전에 해당합니다.

![PowerPoint 3‑D 회전 창에 X, Y, Z 회전 값이 강조 표시됨](img_02_01.png)

Aspose.Slides에서는 [IThreeDFormat.getCamera](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getCamera--) 를 통해 카메라에 접근합니다. 이 예제는 사각형을 만들고 직교 정면 보기를 선택한 뒤 X, Y, Z 회전을 각각 20°, 30°, 40°로 설정합니다. 파일을 저장하지 않고 메모리 내에서 도형을 구성합니다:

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

카메라는 뷰어가 개체를 보는 방식을 변경할 때 사용합니다. 슬라이드의 2D 도형 기하학을 변경하지 않으며, PowerPoint와 Aspose.Slides가 렌더링 시 사용하는 3D 시점을 변경합니다.

### **템플릿 도형에서 카메라 방향 복사하기**

템플릿 도형의 카메라 사전 설정은 [getCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getCameraType--) 로, 회전 각도는 [getRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#getRotation--) 로 읽습니다. 예제는 `template.pptx`를 열고 첫 번째 슬라이드 첫 번째 도형의 카메라 방향을 두 번째 도형에 복사합니다. 두 도형 모두 3D 조명이 설정되어 있으며 두 번째 도형에는 명시적 카메라 회전이 없습니다.

각도는 도 단위이며, 인덱스 0은 위도, 인덱스 1은 경도, 인덱스 2는 회전입니다. 이를 [setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) 에 해당 순서대로 전달합니다. 소스가 `null`을 반환하면 명시적 회전이 없는 것이므로 두 번째 도형의 각도를 설정하지 않습니다. `(0, 0, 0)` 회전은 세 개의 0을 반환하므로 복사합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`camera-copy.pptx`를 PowerPoint에서 다시 열면 오른쪽 화살표가 왼쪽 사각형과 동일한 카메라 사전 설정 및 회전을 가집니다. 두 도형 모두 동일한 조명과 압출 깊이를 사용합니다.

![왼쪽은 파란색 3D 사각형, 오른쪽은 같은 카메라 방향을 가진 오른쪽 화살표가 위에서 오른쪽으로 바라봄](camera-orientation.png)

## **압출 및 깊이 추가하기**

압출은 앞면 뒤쪽으로 도형을 확장하여 두껍게 보이게 합니다. PowerPoint에서 깊이 제어는 이 가시적인 두께를 설정하고, 색상 제어는 측면 면의 색을 설정합니다.

![PowerPoint 깊이 제어가 압출 색상 및 압출 높이 속성에 매핑됨](img_02_02.png)

[IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 으로 두께를 설정하고, [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) 로 측면 색을 가져옵니다. 이 예제는 사각형에 100포인트 압출을 적용하고 보라색 측면을 지정한 뒤 카메라를 회전시켜 두께를 보여줍니다. 파일을 저장하지 않고 메모리 내에서 도형을 구성합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

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

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) 메서드는 3D 도형의 깊이를 설정합니다. [setExtrusionHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) 메서드는 압출 효과의 높이를 제어합니다. 위 예제에서 확인할 수 있습니다.

## **그라디언트 또는 그림 채우기를 3D 효과와 함께 사용하기**

3D 서식은 도형 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 그림 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 압출 설정을 사용할 수 있습니다.

이 예제는 앞면에 파란색‑주황색 그라디언트를 적용하고 150포인트 압출에 짙은 주황색을 지정합니다. 그라디언트 정지는 0과 100에서 시작·끝을 표시합니다. 카메라 회전 값은 도 단위이며, 슬라이드를 두 배 크기의 PNG 이미지로 렌더링합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int extrusionColor = Color.rgb(255, 140, 0);
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

렌더링된 출력물은 앞면의 그라디언트를 유지하고 압출을 별도로 렌더링합니다:

![그라디언트 채우기와 주황색 압출을 가진 3D 사각형 렌더링](img_02_03.png)

그림 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 도형 채우기에 할당합니다. 이 예제는 작업 디렉터리에 `image.jpg` 파일이 존재한다는 전제이며, 그림을 사각형에 맞게 확대하고 150포인트 압출을 적용한 뒤 카메라 회전을 도 단위로 설정합니다. 파일을 저장하거나 렌더링하지 않고 메모리 내에서 도형을 구성합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
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

그림은 앞면에 렌더링되고, 압출은 3D 측면 표면으로 렌더링됩니다:

![앞면에 사진 채우기와 주황색 압출을 가진 3D 사각형 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용하기**

도형 3D 서식은 도형 본문에 영향을 줍니다. 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 문자 자체에 압출, 재질, 조명, 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 주황‑흰색 격자 패턴 텍스트를 만들고 위쪽 아치를 적용한 뒤 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) 로 3D 설정을 구성합니다. 압출 높이와 깊이는 포인트 단위이며, 조명 회전은 도 단위입니다. 도형 채우기와 외곽선은 숨겨서 텍스트만 보이게 합니다. 예제는 PNG 이미지를 두 배 슬라이드 크기로 렌더링하고 프레젠테이션을 PPTX로 저장합니다:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

텍스트는 곡선형으로 압출된 3D 글자로 렌더링됩니다:

![아치형 WordArt 변형, 주황 패턴 채우기 및 어두운 압출을 가진 3D 텍스트 렌더링](img_02_05.png)

## **3D 도형에 텍스트를 평면으로 유지하기**

텍스트를 3D 장면에서 제외하려면 [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--) 를 통해 [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) 을 호출합니다. 값이 `true`이면 텍스트가 3D 장면에서 벗어나게 되고, `false`이면 텍스트가 장면에 참여하여 3D 방향을 따릅니다.

이 설정은 도형의 3D 서식을 제거하지 않습니다: 카메라, 조명, 재질 및 압출은 [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) 로 계속 구성됩니다. 또한 일반 회전과는 다릅니다. [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) 은 슬라이드 평면에서 도형을 회전시키고, [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) 은 텍스트가 자신의 경계 상자 내에서 갖는 사용자 정의 회전을 제어합니다. 텍스트를 3D 장면에서 제외해도 이 각도들은 리셋되지 않습니다.

다음 자체 포함 예제는 파란색 사각형에 텍스트를 추가하고 원본 옆에 복제합니다. 두 도형 모두 동일한 3D 서식을 가지지만 텍스트 설정만 다릅니다: 왼쪽은 `false`, 오른쪽은 `true`. 카메라 각도는 도 단위이며, 압출 높이는 40포인트입니다. 예제는 프레젠테이션을 PPTX로 저장하고 비교 슬라이드를 두 배 크기의 PNG로 렌더링합니다.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
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

왼쪽에서는 텍스트가 3D 방향을 따르고, 오른쪽에서는 평면을 유지해 읽기 쉽습니다. 두 사각형 모두 동일한 가시적인 압출과 3D 방향을 유지합니다.

![좌우 나란히 보여지는 3D 사각형: 왼쪽은 3D 방향을 따르고 오른쪽은 평면을 유지함](keep_text_flat.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 2D 결과로 래스터화되거나 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/androidjava/convert-powerpoint-to-png/) 로 렌더링하거나, [PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/) 로 내보내거나, [HTML](/slides/ko/androidjava/convert-powerpoint-to-html/) 로 내보내거나, [비디오 변환](/slides/ko/androidjava/convert-powerpoint-to-video/) 을 위한 프레임을 생성할 때 모두 적용됩니다.

다음 사항을 기억하십시오:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 뷰어가 내보낸 후 개체를 회전할 수 없습니다.
- 최종 외관은 카메라, 라이트 릭, 재질, 압출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 형식 값을 확인하려면 [effective shape properties](/slides/ko/androidjava/shape-effective-properties/) 를 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 편집 가능한 3D 설정이 아니라 렌더링된 이미지로 저장됩니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 도형 및 텍스트에 대한 PowerPoint 3D 효과를 만들고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 뷰어가 회전할 수 있는 인터랙티브 3D 씬으로 만들지는 않습니다. PPTX에서는 해당 형식이 지원되는 경우 3D 서식이 PowerPoint에서 편집 가능하게 유지됩니다.

**3D 모델과 3D 효과의 차이점은 무엇인가요?**

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 개체입니다. 3D 효과는 회전, 압출, 베벨, 조명, 재질과 같은 일반 PowerPoint 도형이나 텍스트에 적용되는 서식입니다. 이 문서는 3D 효과에 대해 다룹니다.

**시각적인 3D 도형을 만들려면 어떤 설정이 필요합니까?**

최소한 카메라 회전과 압출 또는 깊이를 설정해야 합니다. 실제로는 라이트 릭과 재질도 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 좋습니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예. 도형 본문에는 [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) 을, 텍스트에는 [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) 을 사용합니다.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 나타납니까?**

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환용 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 결과물은 렌더링된 모습이며, 편집 가능한 3D 개체가 아닙니다.

**상속 및 테마 설정이 적용된 최종 3D 값을 읽을 수 있나요?**

예. 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽으려면 [Shape Effective Properties](/slides/ko/androidjava/shape-effective-properties/) 에 설명된 효과적인 서식 API를 사용하십시오.