---
title: .NET에서 PowerPoint 도형 서식 지정
linktitle: 도형 서식 지정
type: docs
weight: 20
url: /ko/net/shape-formatting/
keywords:
- 도형 서식 지정
- 선 서식 지정
- 연결 스타일 서식 지정
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
description: "Aspose.Slides를 사용하여 C#에서 PowerPoint 도형을 서식 지정하는 방법을 배우세요—PPT 및 PPTX 파일에 대해 정확하고 완전한 제어로 채우기, 선 및 효과 스타일을 설정합니다."
---
## **소개**

PowerPoint에서는 슬라이드에 도형을 추가할 수 있습니다. 도형은 선으로 구성되므로 외곽선을 수정하거나 효과를 적용하여 서식 지정할 수 있습니다. 또한 내부를 채우는 방식을 지정하여 도형을 서식 지정할 수 있습니다.

![형식-도형-PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET은 PowerPoint에서 제공되는 동일한 옵션을 사용하여 도형을 서식 지정할 수 있는 인터페이스와 속성을 제공합니다.

## **선 서식 지정**

Aspose.Slides를 사용하면 도형에 사용자 지정 선 스타일을 지정할 수 있습니다. 다음 단계가 절차를 설명합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 [line style](https://reference.aspose.com/slides/ko/net/aspose.slides/linestyle/)을 설정합니다.
1. 선 너비를 설정합니다.
1. 선의 [dash style](https://reference.aspose.com/slides/ko/net/aspose.slides/linedashstyle/)을 설정합니다.
1. 도형의 선 색을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C# 코드는 사각형 `AutoShape`의 선을 서식 지정하는 방법을 보여줍니다:

```c#
 // 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
 using (Presentation presentation = new Presentation())
 {
     // 첫 번째 슬라이드를 가져옵니다.
     ISlide slide = presentation.Slides[0];
 
     // Rectangle 유형의 자동 도형을 추가합니다.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
 
     // 사각형 도형의 채우기 색을 설정합니다.
     shape.FillFormat.FillType = FillType.NoFill;
 
     // 사각형의 선에 서식을 적용합니다.
     shape.LineFormat.Style = LineStyle.ThickThin;
     shape.LineFormat.Width = 7;
     shape.LineFormat.DashStyle = LineDashStyle.Dash;
 
     // 사각형 선의 색을 설정합니다.
     shape.LineFormat.FillFormat.FillType = FillType.Solid;
     shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
 
     // PPTX 파일을 디스크에 저장합니다.
     presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
 }
```

결과:

![프레젠테이션의 서식 지정된 선](formatted-lines.png)

## **연결 스타일 서식 지정**

다음은 세 가지 연결 유형 옵션입니다:

* Round
* Miter
* Bevel

기본적으로 PowerPoint가 두 선을 각도(예: 도형 모서리)에서 연결할 때 **Round** 설정을 사용합니다. 그러나 날카로운 각도를 가진 도형을 그리는 경우 **Miter** 옵션을 선호할 수 있습니다.

![프레젠테이션의 연결 스타일](join-style-powerpoint.png)

다음 C# 코드는 위 이미지에 표시된 세 개의 사각형이 Miter, Bevel, Round 연결 유형 설정을 사용하여 생성된 방법을 보여줍니다:

```c#
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.Slides[0];

    // Rectangle 유형의 자동 도형 세 개를 추가합니다.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // 각 사각형 도형의 채우기 색을 설정합니다.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // 선 너비를 설정합니다.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // 각 사각형 선의 색을 설정합니다.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // 연결 스타일을 설정합니다.
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

PowerPoint에서 그라디언트 채우기는 도형에 색상의 연속적인 혼합을 적용할 수 있는 서식 옵션입니다. 예를 들어 두 개 이상의 색상을 점진적으로 서로 섞이도록 적용할 수 있습니다.

Aspose.Slides를 사용하여 도형에 그라디언트 채우기를 적용하는 방법은 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)을 `Gradient`로 설정합니다.
1. [IGradientFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/igradientformat/) 인터페이스가 노출하는 그라디언트 스톱 컬렉션의 `Add` 메서드를 사용하여 두 가지 원하는 색상을 정의된 위치와 함께 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C# 코드는 타원에 그라디언트 채우기 효과를 적용하는 방법을 보여줍니다:

```c#
 // 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
 using (Presentation presentation = new Presentation())
 {
     // 첫 번째 슬라이드를 가져옵니다.
     ISlide slide = presentation.Slides[0];
 
     // Ellipse 유형의 자동 도형을 추가합니다.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
 
     // 타원에 그라디언트 서식을 적용합니다.
     shape.FillFormat.FillType = FillType.Gradient;
     shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
 
     // 그라디언트의 방향을 설정합니다.
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

PowerPoint에서 패턴 채우기는 점, 줄무늬, 교차 해시 또는 체크와 같은 두 색상 디자인을 도형에 적용할 수 있는 서식 옵션입니다. 패턴의 전경색과 배경색을 사용자 지정할 수 있습니다.

Aspose.Slides는 프레젠테이션의 시각적 매력을 높이기 위해 도형에 적용할 수 있는 45개 이상의 사전 정의된 패턴 스타일을 제공합니다. 사전 정의된 패턴을 선택한 후에도 정확한 색상을 지정할 수 있습니다.

Aspose.Slides를 사용하여 도형에 패턴 채우기를 적용하는 방법은 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)을 `Pattern`으로 설정합니다.
1. 사전 정의된 옵션 중에서 패턴 스타일을 선택합니다.
1. 패턴의 [Background Color](https://reference.aspose.com/slides/ko/net/aspose.slides/ipatternformat/backcolor/)을 설정합니다.
1. 패턴의 [Foreground Color](https://reference.aspose.com/slides/ko/net/aspose.slides/ipatternformat/forecolor/)을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C# 코드는 사각형에 패턴 채우기를 적용하는 방법을 보여줍니다:

```c#
 // 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
 using (Presentation presentation = new Presentation())
 {
     // 첫 번째 슬라이드를 가져옵니다.
     ISlide slide = presentation.Slides[0];

     // Rectangle 유형의 자동 도형을 추가합니다.
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

PowerPoint에서 그림 채우기는 이미지를 도형 내부에 삽입하여 이미지 자체를 도형 배경으로 사용하는 서식 옵션입니다.

Aspose.Slides를 사용하여 도형에 그림 채우기를 적용하는 방법은 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)을 `Picture`로 설정합니다.
1. 그림 채우기 모드를 `Tile`(또는 원하는 다른 모드)으로 설정합니다.
1. 사용할 이미지로부터 [IPPImage](https://reference.aspose.com/slides/ko/net/aspose.slides/ippimage/) 개체를 생성합니다.
1. 이 이미지를 도형의 `PictureFillFormat`의 `Picture.Image` 속성에 할당합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음은 "lotus.png" 파일을 사용한 예시입니다:

![연꽃 이미지](lotus.png)

다음 C# 코드는 그림으로 도형을 채우는 방법을 보여줍니다:

```c#
 // 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.Slides[0];

    // Rectangle 유형의 자동 도형을 추가합니다.
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

타일형 그림을 텍스처로 설정하고 타일링 동작을 사용자 지정하려면 [IPictureFillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/) 인터페이스와 [PictureFillFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/picturefillformat/) 클래스의 다음 속성을 사용할 수 있습니다:

- [PictureFillMode](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/picturefillmode/): 그림 채우기 모드를 `Tile` 또는 `Stretch`로 설정합니다.
- [TileAlignment](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/tilealignment/): 도형 내에서 타일의 정렬을 지정합니다.
- [TileFlip](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/tileflip/): 타일을 가로, 세로 또는 모두 뒤집을지 여부를 제어합니다.
- [TileOffsetX](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/tileoffsetx/): 도형 원점으로부터 타일의 수평 오프셋을 포인트 단위로 설정합니다.
- [TileOffsetY](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/tileoffsety/): 도형 원점으로부터 타일의 수직 오프셋을 포인트 단위로 설정합니다.
- [TileScaleX](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/tilescalex/): 타일의 수평 스케일을 백분율로 정의합니다.
- [TileScaleY](https://reference.aspose.com/slides/ko/net/aspose.slides/ipicturefillformat/tilescaley/): 타일의 수직 스케일을 백분율로 정의합니다.

다음 코드 샘플은 타일 그림 채우기가 적용된 사각형을 추가하고 타일 옵션을 구성하는 방법을 보여줍니다:

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

    // 그림 채우기 모드와 타일 속성을 구성합니다.
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

PowerPoint에서 단색 채우기는 도형을 단일 고른 색상으로 채우는 서식 옵션입니다. 이 배경색은 그라디언트, 텍스처 또는 패턴 없이 적용됩니다.

Aspose.Slides를 사용하여 도형에 단색 채우기를 적용하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)을 `Solid`로 설정합니다.
1. 원하는 채우기 색을 도형에 할당합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 C# 코드는 PowerPoint 슬라이드의 사각형에 단색 채우기를 적용하는 방법을 보여줍니다:

```c#
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.Slides[0];

    // Rectangle 유형의 자동 도형을 추가합니다.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 채우기 유형을 Solid로 설정합니다.
    shape.FillFormat.FillType = FillType.Solid;

    // 채우기 색을 설정합니다.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // PPTX 파일을 디스크에 저장합니다.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

결과:

![단색 채우기가 적용된 도형](solid-color-fill.png)

## **투명도 설정**

PowerPoint에서 도형에 단색, 그라디언트, 그림 또는 텍스처 채우기를 적용할 때 투명도 수준을 설정하여 채우기의 불투명도를 제어할 수 있습니다. 투명도 값이 높을수록 도형이 더 투명해져 배경이나 아래 객체가 부분적으로 보이게 됩니다.

Aspose.Slides는 채우기에 사용되는 색상의 알파 값을 조정하여 투명도 수준을 설정할 수 있게 합니다. 방법은 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. [FillType](https://reference.aspose.com/slides/ko/net/aspose.slides/filltype/)을 `Solid`로 설정합니다.
1. `Color.FromArgb(alpha, baseColor)`를 사용하여 투명도가 포함된 색을 정의합니다(`alpha` 구성 요소가 투명도를 제어합니다).
1. 프레젠테이션을 저장합니다.

다음 C# 코드는 사각형에 투명 채우기 색을 적용하는 방법을 보여줍니다:

```c#
const int alpha = 128;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.Slides[0];

    // 채워진 사각형 자동 도형을 추가합니다.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 채워진 도형 위에 투명 사각형 자동 도형을 추가합니다.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // PPTX 파일을 디스크에 저장합니다.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

결과:

![투명도가 적용된 도형](shape-transparency.png)

## **도형 회전**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 도형을 회전시킬 수 있습니다. 이는 특정 정렬이나 디자인 요구 사항에 맞게 시각 요소를 배치할 때 유용합니다.

슬라이드에서 도형을 회전시키려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 `Rotation` 속성을 원하는 각도로 설정합니다.
1. 프레젠테이션을 저장합니다.

다음 C# 코드는 도형을 5도 회전시키는 방법을 보여줍니다:

```c#
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation())
{
    // 첫 번째 슬라이드를 가져옵니다.
    ISlide slide = presentation.Slides[0];

    // Rectangle 유형의 자동 도형을 추가합니다.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // 도형을 5도 회전시킵니다.
    shape.Rotation = 5;

    // PPTX 파일을 디스크에 저장합니다.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

결과:

![도형 회전](shape-rotation.png)

## **3D 베벨 효과 추가**

Aspose.Slides를 사용하면 [ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/threedformat/) 속성을 구성하여 도형에 3D 베벨 효과를 적용할 수 있습니다.

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

Aspose.Slides를 사용하면 [ThreeDFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/threedformat/) 속성을 구성하여 도형에 3D 회전 효과를 적용할 수 있습니다.

도형에 3D 회전을 적용하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. 슬라이드에 [IAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/iautoshape/)를 추가합니다.
1. 도형의 [CameraType](https://reference.aspose.com/slides/ko/net/aspose.slides/icamera/cameratype/) 및 [LightType](https://reference.aspose.com/slides/ko/net/aspose.slides/ilightrig/lighttype/)을 설정하여 3D 회전을 정의합니다.
1. 프레젠테이션을 저장합니다.

다음 C# 코드는 도형에 3D 회전 효과를 적용하는 방법을 보여줍니다:

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

다음 C# 코드는 슬라이드의 서식을 초기화하고 [LayoutSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutslide/)에 있는 모든 자리표시자 도형의 위치, 크기 및 서식을 기본 설정으로 되돌리는 방법을 보여줍니다:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // 레이아웃에 자리표시자가 있는 슬라이드의 각 도형을 초기화합니다.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**도형 서식이 최종 프레젠테이션 파일 크기에 영향을 줍니까?**

거의 영향을 주지 않습니다. 삽입된 이미지와 미디어가 파일 용량의 대부분을 차지하고, 색상, 효과, 그라디언트와 같은 도형 매개변수는 메타데이터로 저장되어 실질적인 크기 증가가 없습니다.

**같은 서식을 가진 도형을 슬라이드에서 감지하여 그룹화하려면 어떻게 해야 하나요?**

각 도형의 핵심 서식 속성(채우기, 선, 효과)을 비교합니다. 모든 해당 값이 일치하면 스타일이 동일하다고 판단하고 논리적으로 그룹화하면 이후 스타일 관리가 간편해집니다.

**맞춤 도형 스타일 집합을 별도 파일에 저장하여 다른 프레젠테이션에서 재사용할 수 있나요?**

예 가능합니다. 원하는 스타일이 적용된 샘플 도형을 템플릿 슬라이드 또는 .POTX 템플릿 파일에 저장합니다. 새 프레젠테이션을 만들 때 템플릿을 열어 필요한 스타일 도형을 복제하고 필요한 위치에 서식을 다시 적용하면 됩니다.