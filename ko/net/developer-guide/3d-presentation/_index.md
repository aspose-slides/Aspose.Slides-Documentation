---
title: .NET을 사용해 프레젠테이션에 3D 효과 생성
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/net/3d-presentation/
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
- .NET
- C#
- Aspose.Slides
description: ".NET에서 Aspose.Slides를 사용하여 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 압출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for .NET은 도형 및 텍스트에 대한 PowerPoint 스타일 3D 서식을 만들고, 편집하고, 유지하며, 렌더링할 수 있습니다. 이 문서에서는 회전, 압출, 베벨, 조명, 재질, 그라디언트 또는 그림 채우기, 그리고 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" title="Note" %}}
이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 다루지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

도형에 3D 서식을 적용하려면 [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat) 속성을 사용합니다. 이 속성은 해당 도형의 3D 장면을 제어하는 ​​[IThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat)을 노출합니다.

텍스트의 경우 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) 속성을 사용합니다. 이는 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 속성은 다음과 같습니다:

| 속성 | 제어 내용 | 사용 시점 |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) | 시점, 사전 설정 카메라 유형, 회전, 확대 및 원근. | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 사전 설정에 맞춥니다. |
| [LightRig](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/lightrig) | 조명 사전 설정, 방향 및 조명 회전. | 3D 표면에서 하이라이트와 그림자의 표시 방식을 변경합니다. |
| [Material](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/material) | 평면, 무광, 플라스틱 또는 금속과 같은 표면 재질. | 같은 형상이 더 평평하거나, 부드럽거나, 광택이 있거나, 금속처럼 보이게 함. |
| [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) | 도형이 앞면에서 뒤쪽으로 얼마나 멀리 연장되는지. | 평면 도형을 눈에 보이는 두꺼운 3D 객체로 변환합니다. |
| [ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 압출된 측면의 색상. | 깊이를 보이게 하거나 측면 색을 앞면 채우기와 맞춥니다. |
| [Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D 서식에서 사용되는 추가 3D 깊이. | 특히 베벨 및 재질 설정과 함께 도형이나 텍스트의 깊이를 미세 조정합니다. |
| [BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/beveltop) 및 [BevelBottom](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/bevelbottom) | 앞면 및 뒷면의 돌출되거나 라운드된 가장자리. | 날카로운 평면 대신 부드럽거나 몰딩된 가장자리를 추가합니다. |
| [ContourColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourcolor) 및 [ContourWidth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D 객체 주변의 외곽선. | 렌더링된 출력에서 객체 경계를 강조합니다. |

## **3D 도형 만들기**

도형이 설득력 있게 3D로 보이기 위해서는 일반적으로 네 가지 종류의 설정이 필요합니다:

- 카메라 설정 – 기본 정면 뷰에서는 압출이 숨겨질 수 있습니다.
- 조명 설정 – 조명이 면과 측면을 읽기 쉽도록 합니다.
- 재질 설정 – 표면이 빛을 어떻게 렌더링하는지 영향을 줍니다.
- 압출 또는 깊이 설정 – 평면 도형에 두께가 필요합니다.

다음 예제는 사각형을 만들고, 앞면에 텍스트를 추가한 뒤 3D 서식을 적용합니다. 카메라 회전 값은 도 단위이며, 압출 높이는 100 포인트입니다. 예제는 슬라이드를 PNG 이미지로 두 배 크기로 렌더링하고 프레젠테이션을 PPTX로 저장합니다.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
shape.TextFrame.Text = "3D";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Blue;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("shape_3d.png");

presentation.Save("shape_3d.pptx", SaveFormat.Pptx);
```

렌더링된 슬라이드 이미지는 사각형이 두꺼운 3D 블록으로 표시됩니다:

![전면에 흰색 3D 텍스트가 있는 파란색 3D 사각형 렌더링](img_01_01.png)

## **카메라로 도형 회전하기**

PowerPoint에서 3D 회전은 3-D Rotation 창에서 구성합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정한 회전값에 해당합니다.

![X, Y, Z 회전값이 강조된 PowerPoint 3D 회전 창](img_02_01.png)

Aspose.Slides에서는 [IThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/camera) 를 통해 카메라에 접근합니다. 이 예제는 사각형을 만들고, 직교 정면 뷰를 선택한 뒤 X, Y, Z 회전을 각각 20, 30, 40도로 설정합니다. 파일을 저장하지 않고 메모리에서 도형을 구성합니다:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

시청자가 객체를 보는 방식을 변경해야 할 때 카메라를 사용합니다. 이는 슬라이드상의 2D 도형 기하학을 변경하지 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 시점을 변경합니다.

### **템플릿 도형에서 카메라 방향 복사하기**

템플릿에 있는 도형과 일치시키려면 해당 도형의 [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) 사전 설정을 복사하고 [GetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/getrotation/) 으로 각도를 읽습니다. 예제는 `template.pptx`를 열어 첫 번째 슬라이드 첫 번째 도형의 카메라를 읽고 이를 두 번째 도형에 적용합니다. 두 도형 모두 이미 3D 조명을 가지고 있으며 두 번째 도형에는 명시적인 카메라 회전이 없습니다.

각도는 도 단위이며, 인덱스 `0`은 위도, 인덱스 `1`은 경도, 인덱스 `2`는 회전입니다. 이 순서대로 [SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) 에 전달합니다. 소스가 `null`을 반환하면 명시적인 회전이 없으므로 두 번째 도형의 각도를 설정하지 않습니다. `(0, 0, 0)`과 같은 명시적인 회전은 세 개의 0을 반환하므로 복사해야 합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("template.pptx");
var shapes = presentation.Slides[0].Shapes;

var sourceCamera = shapes[0].ThreeDFormat.Camera;
var destinationCamera = shapes[1].ThreeDFormat.Camera;

destinationCamera.CameraType = sourceCamera.CameraType;
var angles = sourceCamera.GetRotation();
if (angles != null)
{
    destinationCamera.SetRotation(angles[0], angles[1], angles[2]);
}

presentation.Save("camera-copy.pptx", SaveFormat.Pptx);
```

`camera-copy.pptx`를 다시 열면 두 도형이 동일한 카메라 사전 설정과 회전을 갖게 됩니다. PowerPoint에서 오른쪽 화살표는 왼쪽 사각형에서 복사된 카메라 방향을 사용합니다. 두 도형 모두 동일한 조명과 압출 깊이를 사용합니다.

![왼쪽 사각형과 오른쪽 화살표가 동일한 카메라 방향을 가지고 위와 오른쪽에서 본 모습](camera-orientation.png)

## **압출 및 깊이 추가하기**

압출은 도형을 앞면 뒤쪽으로 연장시켜 두껍게 보이게 합니다. PowerPoint에서 깊이 제어는 이 가시적인 두께를 설정하고 색상 제어는 측면 색을 설정합니다.

![PowerPoint 깊이 제어가 압출 색 및 압출 높이 속성에 매핑된 모습](img_02_02.png)

두께를 지정하려면 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 를, 측면 색을 지정하려면 [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusioncolor) 를 사용합니다. 이 예제는 사각형에 100 포인트 압출과 보라색 측면을 적용하고 카메라를 회전시켜 두께를 확인합니다. 파일을 저장하지 않고 메모리에서 도형을 구성합니다:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

[IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/depth) 속성은 3D 도형의 깊이를 설정합니다. [ExtrusionHeight](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/properties/extrusionheight) 속성은 압출 효과의 높이를 제어합니다. 위 예제에서 확인할 수 있습니다.

## **3D 효과와 함께 그라디언트 또는 그림 채우기 사용하기**

3D 서식은 도형 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 그림 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 압출 설정을 사용할 수 있습니다.

이 예제는 앞면에 파란색‑주황색 그라디언트를 적용하고 150 포인트 압출에 어두운 주황색을 적용합니다. 그라디언트 정지는 0과 100에서 시작과 끝을 표시합니다. 카메라 회전 값은 도 단위이며, 슬라이드는 두 배 크기의 PNG 이미지로 렌더링됩니다:

```csharp
using System.Drawing;
using Aspose.Slides;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.TextFrame.Text = "3D Gradient";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 64;

shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientStops.Add(0, Color.Blue);
shape.FillFormat.GradientFormat.GradientStops.Add(100, Color.Orange);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("gradient_3d.png");
```

렌더링된 결과는 앞면의 그라디언트를 유지하고 압출은 별도로 렌더링합니다:

![전면에 파란색‑주황색 그라디언트 채우기와 주황색 압출이 적용된 3D 사각형 렌더링](img_02_03.png)

그림 채우기를 사용하려면 프레젠테이션에 이미지를 추가하고 도형 채우기에 할당합니다. 이 예제는 작업 디렉터리에 `image.jpg` 파일이 존재한다는 전제하에 동작합니다. 그림을 사각형에 맞게 늘리고 150 포인트 압출을 적용하며 카메라 회전을 도 단위로 설정합니다. 파일을 저장하거나 렌더링하지 않고 메모리에서 도형을 구성합니다:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

그림은 앞면에 렌더링되고 압출은 3D 측면 표면으로 렌더링됩니다:

![전면에 사진 채우기와 주황색 압출이 적용된 3D 사각형 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용하기**

도형 3D 서식은 도형 본문에 영향을 미치고, 텍스트 3D 서식은 텍스트 프레임에 영향을 미칩니다. 이는 문자 자체에 압출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 주황색‑흰색 격자 패턴 텍스트를 만들고, 위쪽 아치를 적용한 뒤 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat) 을 통해 3D 설정을 구성합니다. 압출 높이와 깊이는 포인트 단위이며, 조명 회전은 도 단위입니다. 도형 채우기와 외곽선은 숨겨져 텍스트만 보이게 합니다. 예제는 두 배 크기의 PNG 이미지로 렌더링하고 프레젠테이션을 PPTX로 저장합니다:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const float imageScale = 2;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Text = "3D Text";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.LargeGrid;

shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 128;

var textFrameFormat = shape.TextFrame.TextFrameFormat;
textFrameFormat.Transform = TextShapeType.ArchUp;
textFrameFormat.ThreeDFormat.ExtrusionHeight = 3.5f;
textFrameFormat.ThreeDFormat.Depth = 3;
textFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;
textFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);
textFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;

using var thumbnail = slide.GetImage(imageScale, imageScale);
thumbnail.Save("text_3d.png");

presentation.Save("text_3d.pptx", SaveFormat.Pptx);
```

텍스트는 곡선형으로 압출된 3D 레터링으로 렌더링됩니다:

![아치형 WordArt 변형, 주황색 패턴 채우기 및 어두운 압출이 적용된 3D 텍스트 렌더링](img_02_05.png)

## **3D 도형에서 텍스트를 평면으로 유지하기**

텍스트를 3D 장면에서 벗어나게 유지하려면 [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/keeptextflat/) 를 [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframe/textframeformat/) 를 통해 `true` 로 설정합니다. 값이 `true`이면 텍스트가 3D 장면에서 제외됩니다. `false`이면 텍스트가 장면에 참여하여 3D 방향을 따릅니다.

이 설정은 도형의 3D 서식(카메라, 조명, 재질, 압출)을 제거하지 않으며, [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) 로 계속 구성됩니다. 또한 일반 회전과는 다릅니다. [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) 은 슬라이드 평면에서 도형을 회전시키고, [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/rotationangle/) 은 텍스트의 사용자 정의 회전을 제어합니다. 텍스트를 3D 장면에서 제외해도 이 각도들은 초기화되지 않습니다.

다음 자체 포함 예제는 텍스트가 있는 파란 사각형을 만들고 원본 옆에 복제합니다. 두 도형 모두 동일한 3D 서식을 가지고 있지만 텍스트 설정만 다릅니다: 왼쪽은 `false`, 오른쪽은 `true`. 카메라 각도는 도 단위이며 압출 높이는 40 포인트입니다. 예제는 프레젠테이션을 PPTX로 저장하고 비교 슬라이드를 두 배 크기의 PNG로 렌더링합니다:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

shape.TextFrame.Text = "Readable text";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 28;
shape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
shape.TextFrame.TextFrameFormat.AnchoringType = TextAnchorType.Center;
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.CornflowerBlue;

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(30, 30, 0);
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Flat;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
shape.ThreeDFormat.Material = MaterialPresetType.Flat;
shape.ThreeDFormat.ExtrusionHeight = 40;
shape.ThreeDFormat.ExtrusionColor.Color = Color.RoyalBlue;
shape.TextFrame.TextFrameFormat.KeepTextFlat = false;

var flatTextShape = (IAutoShape)slide.Shapes.AddClone(shape, 400, 160);
flatTextShape.TextFrame.TextFrameFormat.KeepTextFlat = true;

presentation.Save("keep_text_flat.pptx", SaveFormat.Pptx);
using var image = slide.GetImage(2, 2);
image.Save("keep_text_flat.png");
```

좌측은 KeepTextFlat이 false, 우측은 true인 나란히 배치된 3D 사각형:

![좌측은 KeepTextFlat이 false, 우측은 true인 나란히 배치된 3D 사각형](keep_text_flat.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 경우 3D 장면이 래스터화되거나 2D 결과로 출력에 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/net/convert-powerpoint-to-png/) 로 렌더링하거나, [PDF](/slides/ko/net/convert-powerpoint-to-pdf/) 로 내보내거나, [HTML](/slides/ko/net/convert-powerpoint-to-html/) 로 내보내거나, [비디오 변환](/slides/ko/net/convert-powerpoint-to-video/) 을 위한 프레임을 생성할 때 모두 적용됩니다.

다음 사항을 기억하세요:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 객체를 뷰어가 내보낸 후에 회전시킬 수 없습니다.
- 최종 외관은 카메라, 라이트 리그, 재질, 압출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 확인하려면 [도형 효과 속성](/slides/ko/net/shape-effective-properties/)을 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 렌더링되며 편집 가능한 3D 설정으로 보존되지 않습니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?**  
Aspose.Slides는 도형 및 텍스트에 대한 PowerPoint 3D 효과를 만들고 렌더링합니다. 내보낸 이미지, PDF 혹은 HTML 페이지를 인터랙티브 3D 씬으로 만들어 사용자가 회전시킬 수는 없습니다. PPTX에서는 형식이 지원되는 경우 PowerPoint에서 3D 서식을 편집할 수 있습니다.

**3D 모델과 3D 효과의 차이점은 무엇인가요?**  
3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 일반 PowerPoint 도형이나 텍스트에 적용되는 회전, 압출, 베벨, 조명 및 재질 등의 서식입니다. 이 문서는 3D 효과에 대해 다룹니다.

**눈에 보이는 3D 도형에 필요한 설정은 무엇인가요?**  
최소한 카메라 회전과 압출 또는 깊이를 설정해야 합니다. 실제로는 조명 리그와 재질도 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 좋습니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?**  
예. 도형 본문에는 [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/threedformat)를, 텍스트에는 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/properties/threedformat)를 사용합니다.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 나타나요?**  
예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환용 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 결과에는 렌더링된 모습이 포함되며 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 읽을 수 있나요?**  
예. 최종 카메라, 라이트 리그, 베벨 및 관련 3D 값을 읽으려면 [도형 효과 속성](/slides/ko/net/shape-effective-properties/)에 설명된 효과적인 서식 API를 사용하세요.