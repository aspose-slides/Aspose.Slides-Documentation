---
title: .NET에서 PowerPoint 도형 서식 지정
linktitle: 도형 서식 지정
type: docs
weight: 20
url: /ko/net/shape-formatting/
keywords:
- 도형 서식 지정
- 선 서식 지정
- 스케치 효과
- 스케치 도형 선
- 조인 스타일 서식 지정
- 그라디언트 채우기
- 패턴 채우기
- 그림 채우기
- 텍스처 채우기
- 단색 채우기
- 도형 투명도
- 도형 회전
- 3D 베벨 효과
- 3D 회전 효과
- 서식 초기화
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C#에서 PowerPoint 도형을 형식 지정하는 방법을 배웁니다—PPT 및 PPTX 파일에 대해 채우기, 선 및 효과 스타일을 정확하고 완전하게 제어합니다."
---
## **소개**

PowerPoint에서는 슬라이드에 도형을 추가할 수 있습니다. 도형은 선으로 구성되어 있기 때문에 외곽선에 대한 효과를 수정하거나 적용하여 서식 지정할 수 있습니다. 또한 내부를 채우는 방식을 제어하는 설정을 지정하여 도형을 서식 지정할 수 있습니다.

![PowerPoint 형식 지정 모양](format-shape-powerpoint.png)

Aspose.Slides for .NET은 PowerPoint에서 사용할 수 있는 동일한 옵션을 사용하여 도형을 서식 지정할 수 있는 인터페이스와 속성을 제공합니다.

## **선 서식 지정**

Aspose.Slides를 사용하면 도형에 사용자 지정 선 스타일을 지정할 수 있습니다. 절차는 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 [line style](https://reference.aspose.com/slides/ko/net/aspose.slides/linestyle/)을 설정합니다.
1. 선 너비를 지정합니다.
1. 선의 [dash style](https://reference.aspose.com/slides/ko/net/aspose.slides/linedashstyle/)을 설정합니다.
1. 도형의 선 색상을 지정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C# 코드는 사각형 `AutoShape`의 선을 서식 지정하는 예시를 보여줍니다:

```c#
 // 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
 using (Presentation presentation = new Presentation())
 {
     // 첫 번째 슬라이드를 가져옵니다.
     ISlide slide = presentation.Slides[0];

     // Rectangle 타입의 자동 도형을 추가합니다.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

     // 사각형 도형의 채우기 색상을 설정합니다.
     shape.FillFormat.FillType = FillType.NoFill;

     // 사각형의 선에 서식을 적용합니다.
     shape.LineFormat.Style = LineStyle.ThickThin;
     shape.LineFormat.Width = 7;
     shape.LineFormat.DashStyle = LineDashStyle.Dash;

     // 사각형 선의 색상을 설정합니다.
     shape.LineFormat.FillFormat.FillType = FillType.Solid;
     shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

     // PPTX 파일을 디스크에 저장합니다.
     presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
 }
```

결과:

![프레젠테이션의 서식 지정된 선](formatted-lines.png)

## **도형 선에 스케치 효과 적용**

스케치 효과는 도형 선을 손으로 그린 것처럼 보이게 합니다. [IShape.LineFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ishape/lineformat/)을 사용해 선 설정에 접근하고, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ilineformat/sketchformat/)을 사용해 스케치 설정에 접근하며, [ISketchFormat.SketchType](https://reference.aspose.com/slides/ko/net/aspose.slides/isketchformat/sketchtype/)을 사용해 [LineSketchType](https://reference.aspose.com/slides/ko/net/aspose.slides/linesketchtype/) 열거형 값 중 하나를 선택합니다.

다음 C# 코드는 [LineSketchType.Curved](https://reference.aspose.com/slides/ko/net/aspose.slides/linesketchtype/) 효과를 적용하고, 명시적으로 할당된 값을 읽으며, [LineSketchType.None](https://reference.aspose.com/slides/ko/net/aspose.slides/linesketchtype/)으로 효과를 제거하는 방법을 보여줍니다:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

`ISketchFormat.SketchType`이 반환하는 값은 도형에 직접 할당된 설정을 나타냅니다. 테마, 마스터 슬라이드 또는 레이아웃 슬라이드에서 선 서식이 상속될 수 있는 경우, [ILineFormat.GetEffective](https://reference.aspose.com/slides/ko/net/aspose.slides/ilineformat/geteffective/)을 사용하고, [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ilineformateffectivedata/sketchformat/)에 접근한 뒤, [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/ko/net/aspose.slides/isketchformateffectivedata/sketchtype/)을 읽습니다. 효과적인 값은 상속이 해결된 후 실제 적용된 서식을 반영합니다:

```csharp
using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **조인 스타일 서식 지정**

다음은 세 가지 조인 유형 옵션입니다:

* Round
* Miter
* Bevel

PowerPoint가 두 선을 각도(예: 도형의 모서리)에서 연결할 때 기본값은 **Round** 설정입니다. 그러나 뾰족한 각도가 있는 도형을 그릴 때는 **Miter** 옵션을 선호할 수 있습니다.

![프레젠테이션의 조인 스타일](join-style-powerpoint.png)

다음 C# 코드는 위 이미지에 표시된 세 개의 사각형이 Miter, Bevel, Round 조인 유형 설정을 사용하여 생성된 방법을 보여줍니다:

```c#
 // 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
 using (Presentation presentation = new Presentation())
 {
     // 첫 번째 슬라이드를 가져옵니다.
     ISlide slide = presentation.Slides[0];

     // Rectangle 타입의 자동 도형 세 개를 추가합니다.
     IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
     IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
     IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

     // 각 사각형 도형의 채우기 색상을 설정합니다.
     shape1.FillFormat.FillType = FillType.Solid;
     shape1.FillFormat.SolidFillColor.Color = Color.Black;
     shape2.FillFormat.FillType = FillType.Solid;
     shape2.FillFormat.SolidFillColor.Color = Color.Black;
     shape3.FillFormat.FillType = FillType.Solid;
     shape3.FillFormat.SolidFillColor.Color = Color.Black;

     // 선의 너비를 설정합니다.
     shape1.LineFormat.Width = 15;
     shape2.LineFormat.Width = 15;
     shape3.LineFormat.Width = 15;

     // 각 사각형 선의 색상을 설정합니다.
     shape1.LineFormat.FillFormat.FillType = FillType.Solid;
     shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
     shape2.LineFormat.FillFormat.FillType = FillType.Solid;
     shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
     shape3.LineFormat.FillFormat.FillType = FillType.Solid;
     shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

     // 조인 스타일을 설정합니다.
     shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
     shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
     shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

     // 각 사각형에 텍스트를 추가합니다.
     shape1.TextFrame.Text = "Miter Join Style";
     shape2.TextFrame.Text = "Bevel Join Style";
     shape3.TextFrame.Text = "Round Join Style";

     // PPTX 파일을 디스크에 저장합니다.
     presentation.Save("join_styles.pptx", SaveFormat.Pptx);
 }
```

## **그라디언트 채우기**

PowerPoint에서 그라디언트 채우기는 도형에 연속적인 색상 블렌드를 적용하는 서식 옵션입니다. 예를 들어, 두 가지 이상의 색상을 사용해 한 색상이 점차 다른 색상으로 사라지도록 할 수 있습니다.

Aspose.Slides를 사용해 도형에 그라디언트 채우기를 적용하는 방법은 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)을 `Gradient`로 설정합니다.
1. [IGradientFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/igradientformat/) 인터페이스가 제공하는 그라디언트 스톱 컬렉션의 `Add` 메서드를 사용해 정의된 위치와 함께 두 가지 선호 색상을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C# 코드는 타원에 그라디언트 채우기 효과를 적용하는 예시를 보여줍니다:

```c#
 // 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
 using (Presentation presentation = new Presentation())
 {
     // 첫 번째 슬라이드를 가져옵니다.
     ISlide slide = presentation.Slides[0];

     // Ellipse 타입의 자동 도형을 추가합니다.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

     // 타원에 그라디언트 서식을 적용합니다.
     shape.FillFormat.FillType = FillType.Gradient;
     shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

     // 그라디언트 방향을 설정합니다.
     shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

     // 두 개의 그라디언트 스톱을 추가합니다.
     shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
     shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

     // PPTX 파일을 디스크에 저장합니다.
     presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
 }
```

결과:

![그라디언트 채우기가 적용된 타원](gradient-fill.png)

## **패턴 채우기**

PowerPoint에서 패턴 채우기는 두 가지 색상의 디자인(점, 줄무늬, 교차 해시, 체스보드 등)을 도형에 적용할 수 있는 서식 옵션입니다. 패턴의 전경색과 배경색을 사용자 지정할 수 있습니다.

Aspose.Slides는 45개 이상의 사전 정의된 패턴 스타일을 제공하므로 프레젠테이션의 시각적 매력을 높일 수 있습니다. 사전 정의된 패턴을 선택한 후에도 정확한 색상을 지정할 수 있습니다.

Aspose.Slides를 사용해 도형에 패턴 채우기를 적용하는 방법은 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)을 `Pattern`으로 설정합니다.
1. 사전 정의된 옵션 중에서 패턴 스타일을 선택합니다.
1. 패턴의 [Background Color](https://reference.aspose.com/slides/ko/net/aspose.slides/ipatternformat/backcolor/)을 설정합니다.
1. 패턴의 [Foreground Color](https://reference.aspose.com/slides/ko/net/aspose.slides/ipatternformat/forecolor/)을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C# 코드는 사각형에 패턴 채우기를 적용하는 예시를 보여줍니다:

```c#
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.Slides[0];

    // Rectangle 타입의 자동 도형을 추가합니다.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 채우기 유형을 Pattern으로 설정합니다.
    shape.FillFormat.FillType = FillType.Pattern;

    // 패턴 스타일을 설정합니다.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // 패턴 배경색과 전경색을 설정합니다.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // PPTX 파일을 디스크에 저장합니다.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

결과:

![패턴 채우기가 적용된 사각형](pattern-fill.png)

## **그림 채우기**

PowerPoint에서 그림 채우기는 이미지 파일을 도형 내부에 삽입하여 도형 배경으로 사용하는 서식 옵션입니다.

Aspose.Slides를 사용해 도형에 그림 채우기를 적용하는 방법은 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)을 `Picture`로 설정합니다.
1. 그림 채우기 모드를 `Tile`(또는 원하는 다른 모드)으로 설정합니다.
1. 사용하려는 이미지를 기반으로 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 객체를 생성합니다.
1. 이 이미지를 도형의 `PictureFillFormat`에 있는 `Picture.Image` 속성에 할당합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음은 "lotus.png" 파일을 사용한 예시입니다:

![연꽃 그림](lotus.png)

다음 C# 코드는 그림을 사용해 도형을 채우는 방법을 보여줍니다:

```c#
 // 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
 using (Presentation presentation = new Presentation())
 {
     // 첫 번째 슬라이드를 가져옵니다.
     ISlide slide = presentation.Slides[0];
 
     // Rectangle 타입의 자동 도형을 추가합니다.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
 
     // 채우기 유형을 Picture로 설정합니다.
     shape.FillFormat.FillType = FillType.Picture;
 
     // 그림 채우기 모드를 설정합니다.
     shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;
 
     // 이미지를 로드하고 프레젠테이션 리소스에 추가합니다.
     IImage image = Images.FromFile("lotus.png");
     IPPImage presentationImage = presentation.Images.AddImage(image);
     image.Dispose();
 
     // 그림을 설정합니다.
     shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;
 
     // PPTX 파일을 디스크에 저장합니다.
     presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
 }
```

결과:

![그림 채우기가 적용된 도형](picture-fill.png)

### **텍스처로 타일 그림 사용**

타일 그림을 텍스처로 설정하고 타일링 동작을 사용자 지정하려면 [IPictureFillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/) 인터페이스와 [PictureFillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillformat/) 클래스의 다음 속성을 사용할 수 있습니다:

- [PictureFillMode](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/picturefillmode/): 그림 채우기 모드를 `Tile` 또는 `Stretch`로 설정합니다.
- [TileAlignment](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/tilealignment/): 도형 내에서 타일의 정렬을 지정합니다.
- [TileFlip](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/tileflip/): 타일을 수평, 수직 혹은 둘 다 뒤집을지 제어합니다.
- [TileOffsetX](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/tileoffsetx/): 도형 원점에서 타일의 수평 오프셋(포인트)을 설정합니다.
- [TileOffsetY](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/tileoffsety/): 도형 원점에서 타일의 수직 오프셋(포인트)을 설정합니다.
- [TileScaleX](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/tilescalex/): 타일의 수평 스케일을 백분율로 정의합니다.
- [TileScaleY](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/tilescaley/): 타일의 수직 스케일을 백분율로 정의합니다.

다음 코드 샘플은 타일 그림 채우기가 적용된 사각형 도형을 추가하고 타일 옵션을 구성하는 방법을 보여줍니다:

```c#
 // 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
 using (Presentation presentation = new Presentation())
 {
     // 첫 번째 슬라이드를 가져옵니다.
     ISlide firstSlide = presentation.Slides[0];

     // 사각형 자동 도형을 추가합니다.
     IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

     // 도형의 채우기 유형을 Picture로 설정합니다.
     shape.FillFormat.FillType = FillType.Picture;

     // 이미지를 로드하고 프레젠테이션 리소스에 추가합니다.
     IPPImage presentationImage;
     using (IImage sourceImage = Images.FromFile("lotus.png"))
         presentationImage = presentation.Images.AddImage(sourceImage);

     // 이미지를 도형에 할당합니다.
     IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
     pictureFillFormat.Picture.Image = presentationImage;

     // 그림 채우기 모드와 타일링 속성을 구성합니다.
     pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
     pictureFillFormat.TileOffsetX = -32;
     pictureFillFormat.TileOffsetY = -32;
     pictureFillFormat.TileScaleX = 50;
     pictureFillFormat.TileScaleY = 50;
     pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
     pictureFillFormat.TileFlip = TileFlip.FlipBoth;

     // PPTX 파일을 디스크에 저장합니다.
     presentation.Save("tile.pptx", SaveFormat.Pptx);
 }
```

결과:

![타일 옵션](tile-options.png)

## **단색 채우기**

PowerPoint에서 단색 채우기는 도형을 하나의 균일한 색상으로 채우는 서식 옵션입니다. 그라디언트, 텍스처 또는 패턴 없이 단순한 배경 색상이 적용됩니다.

Aspose.Slides를 사용해 도형에 단색 채우기를 적용하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)을 `Solid`로 설정합니다.
1. 원하는 채우기 색상을 도형에 지정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C# 코드는 PowerPoint 슬라이드의 사각형에 단색 채우기를 적용하는 예시를 보여줍니다:

```c#
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.Slides[0];

    // Rectangle 타입의 자동 도형을 추가합니다.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 채우기 유형을 Solid으로 설정합니다.
    shape.FillFormat.FillType = FillType.Solid;

    // 채우기 색상을 설정합니다.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // PPTX 파일을 디스크에 저장합니다.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

결과:

![단색 채우기가 적용된 도형](solid-color-fill.png)

## **투명도 설정**

PowerPoint에서 도형에 단색, 그라디언트, 그림 또는 텍스처 채우기를 적용할 때 투명도 수준을 설정해 채우기의 불투명도를 조절할 수 있습니다. 투명도 값이 높을수록 도형이 더 투명해져 배경이나 아래 객체가 부분적으로 보이게 됩니다.

Aspose.Slides에서는 채우기에 사용되는 색상의 알파 값을 조정하여 투명도 수준을 설정합니다. 방법은 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)을 `Solid`로 설정합니다.
1. `Color.FromArgb(alpha, baseColor)`를 사용해 투명도가 포함된 색상을 정의합니다(알파값이 투명도를 제어합니다).
1. 프레젠테이션을 저장합니다.

다음 C# 코드는 사각형에 투명 채우기 색상을 적용하는 예시를 보여줍니다:

```c#
const int alpha = 128;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.Slides[0];

    // 채우기된 사각형 자동 도형을 추가합니다.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 채워진 사각형 위에 투명한 사각형 자동 도형을 추가합니다.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // PPTX 파일을 디스크에 저장합니다.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

결과:

![투명한 도형](shape-transparency.png)

## **도형 회전**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 도형을 회전시킬 수 있습니다. 이는 특정 정렬이나 디자인 요구에 맞게 시각 요소를 배치할 때 유용합니다.

슬라이드에서 도형을 회전하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 `Rotation` 속성을 원하는 각도로 설정합니다.
1. 프레젠테이션을 저장합니다.

다음 C# 코드는 도형을 5도 회전시키는 예시를 보여줍니다:

```c#
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.Slides[0];

    // Rectangle 타입의 자동 도형을 추가합니다.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 도형을 5도 회전합니다.
    shape.Rotation = 5;

    // PPTX 파일을 디스크에 저장합니다.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

결과:

![도형 회전](shape-rotation.png)

## **3D 베벨 효과 추가**

Aspose.Slides는 도형의 [ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/threedformat/) 속성을 구성하여 3D 베벨 효과를 적용할 수 있게 합니다.

도형에 3D 베벨 효과를 추가하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 [ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/threedformat/)을 구성하여 베벨 설정을 정의합니다.
1. 프레젠테이션을 저장합니다.

다음 C# 코드는 도형에 3D 베벨 효과를 적용하는 방법을 보여줍니다:

```c#
// Presentation 클래스의 인스턴스를 생성합니다.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // 슬라이드에 도형을 추가합니다.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;

    // 도형의 ThreeDFormat 속성을 설정합니다.
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

    // 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
}
```

결과:

![3D 베벨 효과](3D-bevel-effect.png)

## **3D 회전 효과 추가**

Aspose.Slides는 도형의 [ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/threedformat/) 속성을 구성하여 3D 회전 효과를 적용할 수 있게 합니다.

도형에 3D 회전을 적용하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 [CameraType](https://reference.aspose.com/slides/ko/net/aspose.slides/icamera/cameratype/)과 [LightType](https://reference.aspose.com/slides/ko/net/aspose.slides/ilightrig/lighttype/)을 설정해 3D 회전을 정의합니다.
1. 프레젠테이션을 저장합니다.

다음 C# 코드는 도형에 3D 회전 효과를 적용하는 예시를 보여줍니다:

```c#
// Presentation 클래스의 인스턴스를 생성합니다.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // 프레젠테이션을 PPTX 파일로 저장합니다.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

결과:

![3D 회전 효과](3D-rotation-effect.png)

## **서식 초기화**

다음 C# 코드는 슬라이드의 서식을 초기화하고 [LayoutSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutslide/)에 있는 플레이스홀더가 포함된 모든 도형의 위치, 크기 및 서식을 기본값으로 되돌리는 방법을 보여줍니다:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 레이아웃에 플레이스홀더가 있는 슬라이드의 각 도형을 초기화합니다.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**도형 서식이 최종 프레젠테이션 파일 크기에 영향을 줍니까?**

거의 영향을 주지 않습니다. 삽입된 이미지와 미디어가 파일 용량의 대부분을 차지하고, 색상, 효과, 그라디언트와 같은 도형 매개변수는 메타데이터로 저장되어 실질적인 크기 증가가 거의 없습니다.

**같은 서식을 공유하는 도형을 어떻게 찾아서 그룹화할 수 있나요?**

각 도형의 핵심 서식 속성(채우기, 선, 효과 설정)을 비교합니다. 모든 해당 값이 일치하면 스타일이 동일하다고 판단하고 논리적으로 그룹화하면 이후 스타일 관리가 쉬워집니다.

**맞춤 도형 스타일 세트를 별도 파일에 저장해 다른 프레젠테이션에서 재사용할 수 있나요?**

가능합니다. 원하는 스타일이 적용된 샘플 도형을 템플릿 슬라이드나 .POTX 템플릿 파일에 저장합니다. 새 프레젠테이션을 만들 때 템플릿을 열고 필요한 스타일의 도형을 복제한 뒤, 원하는 위치에 서식을 다시 적용하면 됩니다.