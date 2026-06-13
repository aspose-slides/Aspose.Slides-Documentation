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
description: ".NET 환경에서 Aspose.Slides를 사용하여 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 돌출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for .NET은 도형과 텍스트에 대한 PowerPoint 스타일 3D 서식을 만들고, 편집하고, 보존하며 렌더링할 수 있습니다. 이 문서에서는 회전, 돌출, 베벨, 조명, 재질, 그라디언트 또는 이미지 채우기, 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="primary" %}}
이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 포함하지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

도형에 3D 서식을 적용하려면 [IShape.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/properties/threedformat) 속성을 사용합니다. 이 속성은 해당 도형의 3D 장면을 제어하는 ​​[IThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat)을 노출합니다.

텍스트의 경우 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/properties/threedformat) 속성을 사용합니다. 이 속성은 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 속성은 다음과 같습니다:

| 속성 | 제어 내용 | 사용 시점 |
|---|---|---|
| [Camera](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/camera) | 시점, 미리 설정된 카메라 유형, 회전, 줌 및 원근. | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 사전 설정에 맞추려면. |
| [LightRig](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/lightrig) | 조명 사전 설정, 방향 및 조명 회전. | 3D 표면의 강조 및 그림자 표시 방식을 변경합니다. |
| [Material](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/material) | 평면, 무광, 플라스틱 또는 금속과 같은 표면 재질. | 동일한 형태를 더 평평하게, 부드럽게, 광택 있게 또는 금속처럼 보이게 합니다. |
| [ExtrusionHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/extrusionheight) | 도형이 앞면으로부터 뒤쪽으로 얼마나 뻗는지. | 평면 도형을 눈에 보이는 두꺼운 3D 객체로 변환합니다. |
| [ExtrusionColor](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/extrusioncolor) | 돌출된 측면의 색상. | 깊이를 보이게 하거나 측면 색을 앞면 채우기와 일치시킵니다. |
| [Depth](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/depth) | PowerPoint 3D 서식에서 사용되는 추가 3D 깊이. | 도형이나 텍스트의 깊이를 미세 조정합니다. 특히 베벨 및 재질 설정과 함께 사용할 때. |
| [BevelTop](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/beveltop) 및 [BevelBottom](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/bevelbottom) | 앞면과 뒷면의 돌출되거나 둥근 가장자리. | 날카롭고 평평한 면 대신 부드럽거나 성형된 가장자리를 추가합니다. |
| [ContourColor](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/contourcolor) 및 [ContourWidth](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/contourwidth) | 3D 객체 주위의 외곽선. | 렌더링된 출력에서 객체 경계를 강조합니다. |

## **3D 도형 만들기**

- 카메라 설정, 기본 전면 보기가 돌출을 가릴 수 있기 때문입니다.
- 조명 설정, 조명이 면과 측면을 읽을 수 있게 만들기 때문입니다.
- 재질 설정, 표면이 빛이 렌더링되는 방식에 영향을 주기 때문입니다.
- 돌출 또는 깊이 설정, 평면 도형에 두께가 필요하기 때문입니다.

다음 예제는 사각형을 만들고, 앞면에 텍스트를 추가하고, 3D 서식을 적용하고, 프레젠테이션을 PPTX로 저장한 다음 슬라이드를 PNG 이미지로 렌더링합니다.

```csharp
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

렌더링된 슬라이드 이미지는 사각형을 두꺼운 3D 블록으로 표시합니다:

![렌더링된 파란색 3D 사각형, 앞면에 흰색 3D 텍스트](img_01_01.png)

## **카메라로 도형 회전**

PowerPoint에서 3D 회전은 3‑D 회전 창에서 구성합니다. X, Y, Z 회전값은 카메라 API를 통해 설정한 회전과 일치합니다.

![PowerPoint 3‑D 회전 창, X, Y, Z 회전값 강조 표시](img_02_01.png)

Aspose.Slides에서는 [IThreeDFormat.Camera](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/camera) 를 통해 카메라 유형과 회전을 설정합니다:

```csharp
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
```

시청자가 객체를 보는 방식을 바꿔야 할 때 카메라를 사용합니다. 이는 슬라이드의 2D 도형 기하학을 변경하지 않으며, 렌더링 시 PowerPoint와 Aspose.Slides가 사용하는 3D 관점을 변경합니다.

## **돌출 및 깊이 추가**

돌출은 앞면 뒤쪽으로 확장하여 도형을 두껍게 보이게 합니다. PowerPoint에서 깊이 제어는 이 가시적인 두께를 설정하고, 색상 제어는 측면 면의 색을 설정합니다.

![PowerPoint 깊이 제어가 돌출 색상 및 돌출 높이 속성에 매핑된 모습](img_02_02.png)

두께를 위해 [IThreeDFormat.ExtrusionHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/extrusionheight) 를, 측면 색을 위해 [IThreeDFormat.ExtrusionColor](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/extrusioncolor) 를 설정합니다:

```csharp
shape.ThreeDFormat.Camera.SetRotation(20, 30, 40);
shape.ThreeDFormat.ExtrusionHeight = 100;
shape.ThreeDFormat.ExtrusionColor.Color = Color.Purple;
```

PowerPoint의 깊이 값을 직접 사용하거나 깊이를 베벨, 재질 및 텍스트 효과와 결합해야 할 때는 [IThreeDFormat.Depth](https://reference.aspose.com/slides/ko/net/aspose.slides/ithreedformat/properties/depth) 를 사용합니다. 많은 도형 시나리오에서 `ExtrusionHeight` 가 가시적인 돌출을 직접 나타내므로 더 명확한 설정입니다.

## **3D 효과와 함께 그라디언트 또는 이미지 채우기 사용**

3D 서식은 도형 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 이미지 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 돌출 설정을 계속 사용할 수 있습니다.

다음 예제는 도형에 그라디언트 채우기를 적용하고 측면에 더 어두운 돌출 색을 적용합니다:

```csharp
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

렌더링된 출력은 앞면에 그라디언트를 유지하고 돌출을 별도로 렌더링합니다:

![렌더링된 3D 사각형, 파란색‑주황색 그라디언트 채우기와 주황색 돌출](img_02_03.png)

이미지 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 도형 채우기에 할당합니다:

```csharp
var imageData = File.ReadAllBytes("image.jpg");
var image = presentation.Images.AddImage(imageData);

shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.Picture.Image = image;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

shape.ThreeDFormat.Camera.SetRotation(10, 20, 30);
shape.ThreeDFormat.ExtrusionHeight = 150;
shape.ThreeDFormat.ExtrusionColor.Color = Color.DarkOrange;
```

이미지는 앞면에 렌더링되고, 돌출은 3D 측면 표면으로 렌더링됩니다:

![렌더링된 3D 사각형, 앞면에 사진 채우기와 주황색 돌출](img_02_04.png)

## **텍스트에 3D 서식 적용**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 문자 자체에 돌출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 유사한 효과에 유용합니다.

다음 예제는 패턴 채우기가 적용된 텍스트를 만들고, WordArt 변형을 적용하며, [ITextFrameFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat) 에 3D 설정을 구성합니다:

```csharp
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

텍스트가 아치형 WordArt 변형, 주황색 패턴 채우기 및 어두운 돌출이 적용된 3D 문자로 렌더링됩니다:

![렌더링된 3D 텍스트, 아치형 WordArt 변형, 주황색 패턴 채우기 및 어두운 돌출](img_02_05.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 장면은 2D 결과로 래스터화되거나 출력에 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/net/convert-powerpoint-to-png/), [PDF](/slides/ko/net/convert-powerpoint-to-pdf/), [HTML](/slides/ko/net/convert-powerpoint-to-html/) 로 렌더링하거나 [video conversion](/slides/ko/net/convert-powerpoint-to-video/) 을 위한 프레임을 생성할 때 모두 적용됩니다.

이 점을 기억하세요:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 내보낸 후에는 사용자가 객체를 회전할 수 없습니다.
- 최종 모양은 카메라, 라이트 릭, 재질, 돌출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 확인해야 하는 경우 [유효한 도형 속성](/slides/ko/net/shape-effective-properties/) 을 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 편집 가능한 3D 설정이 아니라 렌더링된 이미지로 제공됩니다.

## **FAQ**

**Aspose.Slides가 대화형 3D 프레젠테이션을 만들 수 있습니까?**

Aspose.Slides는 도형과 텍스트에 대한 PowerPoint 3D 효과를 생성하고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 회전시킬 수 있는 대화형 3D 씬으로 만들지는 않습니다. PPTX에서는 형식이 지원되는 경우 3D 서식이 PowerPoint에서 편집 가능하게 유지됩니다.

**3D 모델과 3D 효과의 차이점은 무엇입니까?**

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 회전, 돌출, 베벨, 조명 및 재질과 같은 일반 PowerPoint 도형이나 텍스트에 적용되는 서식입니다. 이 문서는 3D 효과에 대해 다룹니다.

**보이는 3D 도형을 만들기 위해 필요한 설정은 무엇입니까?**

최소한 카메라 회전과 돌출 또는 깊이를 설정해야 합니다. 실제로는 렌더링된 면에 명확한 하이라이트와 그림자를 제공하기 위해 라이트 릭과 재질도 설정하는 것이 좋습니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있습니까?**

예. 도형 본문에는 [IShape.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/properties/threedformat) 를, 텍스트에는 [ITextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/itextframeformat/properties/threedformat) 를 사용합니다.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 나타납니까?**

예. Aspose.Slides는 슬라이드 이미지, PDF 출력, HTML 출력 및 비디오 변환에 사용되는 프레임을 생성할 때 3D 효과를 렌더링합니다. 내보낸 출력에는 렌더링된 모양이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 확인할 수 있습니까?**

예. 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽으려면 [유효한 도형 속성](/slides/ko/net/shape-effective-properties/) 에 설명된 효과적인 서식 API를 사용하십시오.