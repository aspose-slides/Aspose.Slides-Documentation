---
title: .NET을 사용한 프레젠테이션의 3D 효과 만들기
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/net/3d-presentation/
keywords:
- 3D PowerPoint
- 3D 프레젠테이션
- 3D 회전
- 3D 깊이
- 3D 돌출
- 3D 그라디언트
- 3D 텍스트
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET에서 Aspose.Slides를 사용하여 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 돌출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for .NET는 도형과 텍스트에 대해 PowerPoint 스타일의 3D 서식을 만들고, 편집하고, 보존하고, 렌더링할 수 있습니다. 이 문서에서는 회전, 돌출, 베벨, 조명, 재질, 그라디언트 또는 사진 채우기, 그리고 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" %}}
이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 별도의 3D 모델 파일을 삽입하거나 편집하는 내용은 포함되지 않습니다. 슬라이드를 이미지, PDF, HTML 등으로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

도형에 3D 서식을 적용하려면 [IShape.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/properties/threedformat) 속성을 사용합니다. 이 속성은 해당 도형에 대한 3D 장면을 제어하는 ​​[IThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat)을 노출합니다.

텍스트의 경우 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/properties/threedformat) 속성을 사용합니다. 이 속성은 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 속성은 다음과 같습니다:

| Property | 무엇을 제어합니까 | 언제 사용합니까 |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/camera) | 시점, 프리셋 카메라 유형, 회전, 줌, 원근감 | 3D 공간에서 객체를 회전시키거나 PowerPoint 3D 회전 프리셋과 일치시킬 때 |
| [LightRig](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/lightrig) | 조명 프리셋, 방향, 조명 회전 | 3D 표면의 하이라이트와 그림자 표시 방식을 변경할 때 |
| [Material](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/material) | 평면, 매트, 플라스틱, 금속 등 표면 재질 | 동일한 형상을 보다 평평하게, 부드럽게, 광택 있게 혹은 금속처럼 보이게 할 때 |
| [ExtrusionHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/extrusionheight) | 앞면으로부터 뒤쪽으로 도형이 연장되는 거리 | 평면 도형을 눈에 보이는 두께가 있는 3D 객체로 만들 때 |
| [ExtrusionColor](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 돌출된 면의 색상 | 깊이를 가시화하거나 앞면 채우기와 색을 맞출 때 |
| [Depth](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D 서식에서 사용되는 추가 깊이 | 베벨 및 재질 설정과 함께 형태나 텍스트의 깊이를 미세 조정할 때 |
| [BevelTop](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/beveltop) 및 [BevelBottom](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/bevelbottom) | 앞면과 뒷면 가장자리의 돌출 혹은 둥근 모양 | 날카로운 평면 대신 부드럽거나 몰딩된 가장자리를 추가할 때 |
| [ContourColor](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/contourcolor) 및 [ContourWidth](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D 객체 주변의 외곽선 | 렌더링된 출력에서 객체 경계를 강조할 때 |

## **3D 도형 만들기**

도형이 설득력 있게 3D로 보이려면 일반적으로 네 가지 설정이 필요합니다:

- 기본 정면 보기에서는 돌출이 가려질 수 있으므로 카메라 설정
- 조명이 면과 측면을 읽기 쉽게 만들어 주므로 조명 설정
- 표면 재질이 빛 반사 방식을 좌우하므로 재질 설정
- 평면 도형에 두께를 부여하려면 돌출 또는 깊이 설정

다음 예시는 사각형을 만들고, 앞면에 텍스트를 추가하고, 3D 서식을 적용한 뒤 프레젠테이션을 PPTX로 저장하고 슬라이드를 PNG 이미지로 렌더링합니다.

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

렌더링된 슬라이드 이미지에서는 사각형이 두꺼운 3D 블록으로 표시됩니다:

![전면에 흰색 3D 텍스트가 있는 파란색 3D 사각형 렌더링](img_01_01.png)

## **카메라로 도형 회전하기**

PowerPoint에서 3D 회전은 3‑D 회전 창에서 설정합니다. X, Y, Z 회전값은 카메라 API를 통해 설정하는 회전과 동일합니다.

![X, Y, Z 회전값이 강조된 PowerPoint 3‑D 회전 창](img_02_01.png)

Aspose.Slides에서는 [IThreeDFormat.Camera](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/camera)를 통해 카메라 유형과 회전을 설정합니다:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

카메라는 사용자가 객체를 보는 방식을 변경할 때 사용합니다. 슬라이드의 2D 도형 형상 자체는 변경되지 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 시점을 변경합니다.

## **돌출 및 깊이 추가하기**

돌출은 앞면 뒤로 도형을 연장시켜 두께가 있는 것처럼 보이게 합니다. PowerPoint에서 깊이 컨트롤은 이 가시적인 두께를 설정하고, 색상 컨트롤은 측면 면의 색을 지정합니다.

![돌출 색상 및 돌출 높이 속성과 매핑된 PowerPoint 깊이 컨트롤](img_02_02.png)

두께는 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/extrusionheight)로, 측면 색은 [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/extrusioncolor)로 설정합니다:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

PowerPoint의 깊이 값을 직접 다루거나 깊이를 베벨, 재질, 텍스트 효과와 결합해야 할 경우 [IThreeDFormat.Depth](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/depth)를 사용합니다. 많은 도형 시나리오에서는 `ExtrusionHeight`가 가시적인 돌출을 바로 표현하므로 더 명확한 설정입니다.

## **그라디언트 또는 사진 채우기를 3D 효과와 함께 사용하기**

3D 서식은 도형 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 사진 채우기를 적용하면서 동일한 카메라, 조명, 재질, 돌출 설정을 그대로 사용할 수 있습니다.

다음 예시는 도형에 그라디언트 채우기를 적용하고 측면에 더 짙은 돌출 색을 사용합니다:

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

렌더링 결과는 앞면에 그라디언트를 유지하고 돌출은 별도로 렌더링합니다:

![파란색‑주황색 그라디언트 채우기와 주황색 돌출이 있는 3D 사각형 렌더링](img_02_03.png)

사진 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 도형 채우기에 할당합니다:

```csharp
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

사진은 앞면에 렌더링되고, 돌출은 3D 측면 표면으로 렌더링됩니다:

![앞면에 사진 채우기와 주황색 돌출이 있는 3D 사각형 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용하기**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 문자 자체에 돌출, 재질, 조명, 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예시는 패턴 채우기가 적용된 텍스트를 만들고, WordArt 변형을 적용한 뒤 [ITextFrameFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat)에서 3D 설정을 구성합니다:

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

텍스트는 곡선형으로 돌출된 3D 글자로 렌더링됩니다:

![아치형 WordArt 변형, 주황색 패턴 채우기 및 어두운 돌출이 적용된 3D 텍스트 렌더링](img_02_05.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 경우 3D 장면은 2D 결과로 래스터화되거나 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/net/convert-powerpoint-to-png/)로 렌더링하거나, [PDF](/slides/ko/net/convert-powerpoint-to-pdf/)로 내보내거나, [HTML](/slides/ko/net/convert-powerpoint-to-html/)로 내보내거나, [비디오 변환](/slides/ko/net/convert-powerpoint-to-video/)을 위해 프레임을 생성할 때 모두 적용됩니다.

다음 사항을 기억하세요:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 내보낸 후 사용자가 객체를 회전시킬 수 없습니다.
- 최종 모습은 카메라, 라이트리지, 재질, 돌출, 채우기 및 슬라이드 스케일링 조합에 따라 달라집니다.
- 상속되거나 테마 기반 형식값을 확인해야 하면 [효과적 도형 속성](/slides/ko/net/shape-effective-properties/)을 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장하지 못합니다. 이러한 형식에서는 시각적 결과가 편집 가능한 3D 설정이 아니라 렌더링된 형태로 제공됩니다.

## **FAQ**

### Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?

Aspose.Slides는 도형과 텍스트에 대한 PowerPoint 3D 효과를 만들고 렌더링합니다. 내보낸 이미지, PDF, HTML 페이지를 사용자가 회전시킬 수 있는 인터랙티브 3D 씬으로 만들지는 않습니다. PPTX에서는 형식이 지원되는 경우 3D 서식이 PowerPoint에서 편집 가능하게 유지됩니다.

### 3D 모델과 3D 효과의 차이는 무엇인가요?

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 일반 PowerPoint 도형이나 텍스트에 적용되는 서식으로, 회전, 돌출, 베벨, 조명, 재질 등이 포함됩니다. 이 문서는 3D 효과에 대해 다룹니다.

### 눈에 보이는 3D 도형을 만들기 위해 필요한 설정은 무엇인가요?

최소한 카메라 회전과 돌출 또는 깊이를 설정해야 합니다. 실제로는 라이트리지와 재질도 설정해 주면 렌더링된 면에 명확한 하이라이트와 그림자가 나타납니다.

### 도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?

예. 도형 본문에는 [IShape.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/properties/threedformat)을, 텍스트에는 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/properties/threedformat)을 사용합니다.

### 이미지, PDF, HTML, 비디오 프레임으로 내보낼 때 3D 효과가 표시되나요?

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환용 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 결과물에는 렌더링된 외관이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

### 상속 및 테마 설정이 적용된 최종 3D 값을 읽을 수 있나요?

예. [Shape Effective Properties](/slides/ko/net/shape-effective-properties/)에 설명된 효과적 서식 API를 사용해 최종 카메라, 라이트리지, 베벨 및 관련 3D 값을 읽을 수 있습니다.