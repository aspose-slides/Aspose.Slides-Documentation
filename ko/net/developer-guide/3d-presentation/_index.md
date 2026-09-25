---
title: .NET을 사용하여 프레젠테이션에 3D 효과 만들기
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/net/3d-presentation/
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
- .NET
- C#
- Aspose.Slides
description: ".NET에서 Aspose.Slides를 사용하여 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 압출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for .NET은 도형 및 텍스트에 대한 PowerPoint 스타일 3D 서식을 생성, 편집, 보존 및 렌더링할 수 있습니다. 이 문서에서는 회전, 압출, 베벨, 조명, 재질, 그라디언트 또는 그림 채우기 및 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" title="Note" %}}
이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 대해 다룹니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 포함되지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 이러한 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

도형에 3D 서식을 적용하려면 [IShape.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/properties/threedformat) 속성을 사용합니다. 이 속성은 해당 도형의 3D 장면을 제어하는 [IThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat)을 노출합니다.

텍스트의 경우 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/properties/threedformat) 속성을 사용합니다. 이는 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 속성은 다음과 같습니다:

| 속성 | 제어하는 내용 | 사용 시점 |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/camera) | 시점, 미리 설정된 카메라 유형, 회전, 확대/축소 및 원근감. | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 프리셋에 맞춥니다. |
| [LightRig](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/lightrig) | 빛 프리셋, 방향 및 빛 회전. | 3D 표면에서 하이라이트와 그림자의 표시 방식을 변경합니다. |
| [Material](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/material) | 표면 재질(예: 평면, 매트, 플라스틱 또는 금속). | 동일한 형상이 더 평평하거나 부드럽고 광택 있거나 금속처럼 보이게 합니다. |
| [ExtrusionHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/extrusionheight) | 도형이 앞면으로부터 뒤쪽으로 얼마나 연장되는지. | 평면 도형을 눈에 보이는 두꺼운 3D 객체로 변환합니다. |
| [ExtrusionColor](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 압출된 측면의 색상. | 깊이를 보이게 하거나 측면 색상을 앞면 채우기와 맞춥니다. |
| [Depth](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D 서식에서 사용되는 추가 3D 깊이. | 도형이나 텍스트의 깊이를 미세 조정합니다. 특히 베벨 및 재질 설정과 함께 사용할 때. |
| [BevelTop](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/beveltop) and [BevelBottom](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/bevelbottom) | 앞면과 뒤면의 돌출되거나 둥근 모서리. | 날카로운 평면 대신 부드럽거나 성형된 모서리를 추가합니다. |
| [ContourColor](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/contourcolor) and [ContourWidth](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D 객체 주변의 외곽선. | 렌더링된 출력에서 객체 경계를 강조합니다. |

## **3D 도형 만들기**

도형이 설득력 있게 3D처럼 보이려면 일반적으로 네 가지 종류의 설정이 필요합니다:

- 카메라 설정, 기본 전면 뷰가 압출을 가릴 수 있기 때문입니다.
- 조명 설정, 조명이 면과 측면을 읽을 수 있게 만들기 때문입니다.
- 재질 설정, 표면이 빛이 렌더링되는 방식에 영향을 주기 때문입니다.
- 압출 또는 깊이 설정, 평면 도형에 두께가 필요하기 때문입니다.

다음 예제는 직사각형을 만들고 앞면에 텍스트를 추가한 뒤 3D 서식을 적용합니다. 카메라 회전 값은도는도는도각이며, 압출 높이는 100 포인트입니다. 예제는 슬라이드를 기본 크기의 두 배인 PNG 이미지로 렌더링하고 프레젠테이션을 PPTX로 저장합니다.

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

렌더링된 슬라이드 이미지에는 직사각형이 두꺼운 3D 블록으로 표시됩니다:

![전면에 흰색 3D 텍스트가 있는 파란색 3D 직사각형 렌더링](img_01_01.png)

## **카메라로 도형 회전하기**

PowerPoint에서 3D 회전은 3‑D 회전 창에서 구성됩니다. X, Y, Z 회전 값은 카메라 API를 통해 설정한 회전과对应합니다.

![X, Y, Z 회전 값이 강조된 PowerPoint 3-D 회전 창](img_02_01.png)

Aspose.Slides에서는 [IThreeDFormat.Camera](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/camera) 를 통해 카메라에 접근합니다. 이 예제는 직사각형을 만들고 직교 전면 뷰를 선택한 뒤 X, Y, Z 회전을 각각 20°, 30°, 40° 로 설정합니다. 파일을 저장하지 않고 메모리에서 도형을 구성합니다:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

시청자가 객체를 보는 방식을 변경해야 할 때 카메라를 사용합니다. 이것은 슬라이드상의 2D 도형 기하학을 변경하지 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 시점만 변경합니다.

## **압출 및 깊이 추가**

압출은 앞면 뒤쪽으로 도형을 연장시켜 두껍게 보이게 합니다. PowerPoint에서 깊이 제어는 이 가시적인 두께를 설정하고, 색상 제어는 측면 면의 색상을 설정합니다.

![압출 색상 및 압출 높이 속성에 매핑된 PowerPoint 깊이 제어](img_02_02.png)

두께를 위해 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/extrusionheight) 를, 측면 색상을 위해 [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/extrusioncolor) 를 설정합니다. 이 예제는 직사각형에 100 포인트 압출을 적용하고 측면을 보라색으로 설정한 뒤 카메라를 회전시켜 두께를 드러냅니다. 파일을 저장하지 않고 메모리에서 도형을 구성합니다:

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

[IThreeDFormat.Depth](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/depth) 속성은 3D 도형의 깊이를 설정합니다. [ExtrusionHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/extrusionheight) 속성은 예제와 같이 압출 효과의 높이를 제어합니다.

## **3D 효과와 함께 그라디언트 또는 그림 채우기 사용**

3D 서식은 도형 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 그림 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 압출 설정을 사용할 수 있습니다.

이 예제는 앞면에 파란색‑주황색 그라디언트를 적용하고 150 포인트 압출에 어두운 주황색을 적용합니다. 그라디언트 정지는 0과 100에서 시작과 끝을 표시합니다. 카메라 회전 값은 도는도는도각이며, 슬라이드는 기본 크기의 두 배인 PNG 이미지로 렌더링됩니다:

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

렌더링된 출력은 앞면의 그라디언트를 유지하고 압출을 별도로 렌더링합니다:

![파란색에서 주황색 그라디언트 채우기와 주황색 압출이 적용된 3D 직사각형 렌더링](img_02_03.png)

그림 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 도형 채우기에 할당합니다. 이 예제는 작업 디렉터리에 "image.jpg"라는 파일이 존재한다고 가정합니다. 그림을 직사각형에 맞게 늘리고 150 포인트 압출을 적용하며 카메라 회전 값을 도는도는도각으로 설정합니다. 파일을 저장하거나 렌더링하지 않고 메모리에서 도형을 구성합니다:

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

전면에 사진 채우기가 적용되고 주황색 압출이 있는 3D 직사각형 렌더링:

![전면에 사진 채우기가 적용되고 주황색 압출이 있는 3D 직사각형 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 글자 자체에 압출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 유사한 효과에 유용합니다.

다음 예제는 주황색‑흰색 격자 패턴 텍스트를 만들고 위쪽 아치를 적용한 뒤 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/properties/threedformat) 을 통해 3D 설정을 구성합니다. 압출 높이와 깊이는 포인트 단위이며, 조명 회전은 도는도는도각입니다. 도형 채우기와 외곽선을 숨겨 텍스트만 보이게 합니다. 예제는 기본 슬라이드 크기의 두 배인 PNG 이미지로 렌더링하고 프레젠테이션을 PPTX로 저장합니다:

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

아치형 WordArt 변환, 주황색 패턴 채우기 및 어두운 압출이 적용된 3D 텍스트 렌더링:

![아치형 WordArt 변환, 주황색 패턴 채우기 및 어두운 압출이 적용된 3D 텍스트 렌더링](img_02_05.png)

## **3D 도형에서 텍스트를 평면으로 유지**

도형의 3D 외관을 유지하면서 텍스트 가독성을 확보하려면 [ITextFrameFormat.KeepTextFlat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/keeptextflat/) 를 [ITextFrame.TextFrameFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframe/textframeformat/) 를 통해 설정합니다. 값이 `true`이면 텍스트가 3D 장면에서 제외됩니다. `false`이면 텍스트가 장면에 참여하여 3D 방향을 따릅니다.

이 설정은 도형의 3D 서식을 제거하지 않습니다. 카메라, 조명, 재질 및 압출은 [IShape.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/threedformat/) 를 통해 계속 구성됩니다. 또한 일반 회전과도 다릅니다. [IShape.Rotation](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/rotation/) 은 슬라이드 평면에서 도형을 회전시키고, [ITextFrameFormat.RotationAngle](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/rotationangle/) 은 텍스트가 자신의 경계 상자 내에서 갖는 사용자 정의 회전을 제어합니다. 텍스트를 3D 장면에서 제외해도 이 각도들은 초기화되지 않습니다.

다음 자체 포함 예제는 파란색 직사각형에 텍스트를 추가하고 원본 옆에 복제합니다. 두 도형 모두 동일한 3D 서식을 가지고 있지만 텍스트 설정만 다릅니다: 왼쪽은 `false`, 오른쪽은 `true`. 카메라 각도는 도는도는도각이며, 압출 높이는 40 포인트입니다. 예제는 프레젠테이션을 PPTX로 저장하고 비교 슬라이드를 기본 크기의 두 배인 PNG로 렌더링합니다:

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

좌측은 텍스트가 3D 방향을 따릅니다. 우측은 텍스트가 평면을 유지해 읽기 쉽습니다. 두 직사각형 모두 동일한 가시적 압출 및 3D 방향을 유지합니다.

![좌측은 KeepTextFlat이 false이고, 우측은 true인 나란히 배치된 3D 직사각형](keep_text_flat.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 래스터화되거나 2D 결과로 출력에 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/net/convert-powerpoint-to-png/) 로 렌더링하거나, [PDF](/slides/ko/net/convert-powerpoint-to-pdf/) 로 내보내거나, [HTML](/slides/ko/net/convert-powerpoint-to-html/) 로 내보내거나, [비디오 변환](/slides/ko/net/convert-powerpoint-to-video/) 용 프레임을 생성할 때에도 적용됩니다.

- 내보낸 이미지와 PDF는 상호 작용할 수 없습니다. 객체를 내보낸 후에 뷰어가 회전시킬 수 없습니다.
- 최종 모습은 카메라, 라이트 릭, 재질, 압출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 확인해야 하면 [effective shape properties](/slides/ko/net/shape-effective-properties/) 를 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 렌더링되며 편집 가능한 3D 설정으로 보존되지 않습니다.

## **FAQ**

**Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 도형 및 텍스트에 대한 PowerPoint 3D 효과를 생성하고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 인터랙티브 3D 장면으로 만들지는 않으며, 뷰어가 회전시킬 수 없습니다. PPTX에서는 해당 형식이 지원되는 경우 3D 서식이 PowerPoint에서 편집 가능하게 남아 있습니다.

**3D 모델과 3D 효과의 차이점은 무엇인가요?**

3D 모델은 프레젠테이션에 삽입되는 별도 3D 객체입니다. 3D 효과는 회전, 압출, 베벨, 조명 및 재질과 같은 일반 PowerPoint 도형이나 텍스트에 적용되는 서식입니다. 이 문서는 3D 효과에 대해 다룹니다.

**가시적인 3D 도형에 필요한 설정은 무엇인가요?**

최소한 카메라 회전과 압출 또는 깊이를 설정해야 합니다. 실제로는 라이트 릭과 재질을 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 표시하는 것이 좋습니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예. 도형 본문에는 [IShape.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/properties/threedformat) 를, 텍스트에는 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/properties/threedformat) 를 사용합니다.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 표시됩니까?**

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환용 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 결과물에는 렌더링된 모습이 포함되며 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 읽을 수 있나요?**

예. [Shape Effective Properties](/slides/ko/net/shape-effective-properties/) 에서 설명된 효과적인 서식 API를 사용하여 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽을 수 있습니다.