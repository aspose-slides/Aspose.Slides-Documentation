---
title: C++에서 PowerPoint 도형 서식 지정
linktitle: 도형 서식 지정
type: docs
weight: 20
url: /ko/cpp/shape-formatting/
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
- 서식 재설정
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint 도형을 서식 지정하는 방법을 배웁니다—PPT, PPTX 및 ODP 파일에 대해 정확하고 완전한 제어를 통해 채우기, 선 및 효과 스타일을 설정합니다."
---
## **소개**

PowerPoint에서 슬라이드에 도형을 추가할 수 있습니다. 도형은 선으로 구성되어 있으므로 외곽선에 효과를 수정하거나 적용하여 형식을 지정할 수 있습니다. 또한 내부를 채우는 설정을 지정하여 도형을 형식화할 수 있습니다.

![형식-도형-PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for C++는 PowerPoint에서 사용할 수 있는 동일한 옵션을 사용하여 도형을 형식화할 수 있는 인터페이스와 메서드를 제공합니다.

## **선 형식 지정**

Aspose.Slides를 사용하면 도형에 대한 사용자 정의 선 스타일을 지정할 수 있습니다. 다음 단계에 절차가 요약되어 있습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 슬라이드에 추가합니다.
1. 도형의 [line style](https://reference.aspose.com/slides/ko/cpp/aspose.slides/linestyle/)을 설정합니다.
1. 선 너비를 설정합니다.
1. 선의 [dash style](https://reference.aspose.com/slides/ko/cpp/aspose.slides/linedashstyle/)을 설정합니다.
1. 도형의 선 색상을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

다음 코드는 사각형 `AutoShape`의 형식을 지정하는 방법을 보여줍니다:

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

// 첫 번째 슬라이드를 가져옵니다.
auto slide = presentation->get_Slide(0);

// Rectangle 유형의 자동 도형을 추가합니다.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// 사각형 도형의 채우기 색상을 설정합니다.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// 사각형 선에 형식을 적용합니다.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// 사각형 선의 색상을 설정합니다.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX 파일을 디스크에 저장합니다.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

결과:

![프레젠테이션의 형식이 지정된 선](formatted-lines.png)

## **도형 선에 스케치 효과 적용**

스케치 효과는 도형 선을 손으로 그린 것처럼 보이게 합니다. 선 설정에 접근하려면 [IShape::get_LineFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_lineformat/)을 사용하고, 스케치 설정에 접근하려면 [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilineformat/get_sketchformat/)을 사용하며, [ISketchFormat::set_SketchType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isketchformat/set_sketchtype/)을 사용하여 [LineSketchType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/linesketchtype/) 열거형에서 값을 선택합니다.

다음 C++ 코드는 [LineSketchType::Curved](https://reference.aspose.com/slides/ko/cpp/aspose.slides/linesketchtype/) 효과를 적용하고, 명시적으로 할당된 값을 읽으며, [LineSketchType::None](https://reference.aspose.com/slides/ko/cpp/aspose.slides/linesketchtype/)을 사용하여 효과를 제거하는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

[ISketchFormat::get_SketchType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isketchformat/get_sketchtype/)이 반환하는 값은 도형에 직접 할당된 설정을 나타냅니다. 테마, 마스터 슬라이드 또는 레이아웃 슬라이드에서 선 형식이 상속될 수 있는 경우 [ILineFormat::GetEffective](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilineformat/geteffective/), [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/), 및 [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/)을 사용합니다. 유효 값은 상속이 해 resolved 된 후 실제 적용되는 형식을 반영합니다:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **조인 스타일 형식 지정**

다음은 세 가지 조인 유형 옵션입니다:

* Round
* Miter
* Bevel

기본적으로 PowerPoint가 두 선을 각도에서 연결할 때(예: 도형 모서리) **Round** 설정을 사용합니다. 그러나 날카로운 각을 가진 도형을 그리는 경우 **Miter** 옵션을 선호할 수 있습니다.

![프레젠테이션의 조인 스타일](join-style-powerpoint.png)

다음 C++ 코드는 위 이미지에 표시된 세 개의 사각형이 Miter, Bevel 및 Round 조인 유형 설정을 사용하여 생성되는 방법을 보여줍니다:

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

// 첫 번째 슬라이드를 가져옵니다.
auto slide = presentation->get_Slide(0);

// Rectangle 유형의 자동 도형 세 개를 추가합니다.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// 각 사각형 도형의 채우기 색상을 설정합니다.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// 선 너비를 설정합니다.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// 각 사각형 선의 색상을 설정합니다.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// 조인 스타일을 설정합니다.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// 각 사각형에 텍스트를 추가합니다.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// PPTX 파일을 디스크에 저장합니다.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **그라디언트 채우기**

PowerPoint에서 그라디언트 채우기는 도형에 연속적인 색상 혼합을 적용할 수 있는 형식 옵션입니다. 예를 들어 두 가지 이상의 색상을 적용하여 하나가 다른 색상으로 서서히 변하도록 할 수 있습니다.

다음은 Aspose.Slides를 사용하여 도형에 그라디언트 채우기를 적용하는 방법입니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 슬라이드에 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/filltype/)을 `Gradient`로 설정합니다.
1. `Add` 메서드를 사용하여 정의된 위치와 함께 원하는 두 색상을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

// 첫 번째 슬라이드를 가져옵니다.
auto slide = presentation->get_Slide(0);

// Ellipse 유형의 자동 도형을 추가합니다.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// 타원에 그라디언트 형식을 적용합니다.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// 그라디언트의 방향을 설정합니다.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// 두 개의 그라디언트 스톱을 추가합니다.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// PPTX 파일을 디스크에 저장합니다.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![그라디언트 채우기가 적용된 타원](gradient-fill.png)

## **패턴 채우기**

PowerPoint에서 패턴 채우기는 도형에 점, 줄무늬, 교차선 또는 체스보드와 같은 두 가지 색상의 디자인을 적용할 수 있는 형식 옵션입니다. 패턴의 전경색과 배경색을 사용자 정의할 수 있습니다.

Aspose.Slides는 프레젠테이션의 시각적 매력을 높이기 위해 도형에 적용할 수 있는 45개 이상의 사전 정의된 패턴 스타일을 제공합니다. 사전 정의된 패턴을 선택한 후에도 정확한 색상을 지정할 수 있습니다.

다음은 Aspose.Slides를 사용하여 도형에 패턴 채우기를 적용하는 방법입니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 슬라이드에 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/filltype/)을 `Pattern`으로 설정합니다.
1. 미리 정의된 옵션 중에서 패턴 스타일을 선택합니다.
1. 패턴의 [Background Color](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipatternformat/get_backcolor/)를 설정합니다.
1. 패턴의 [Foreground Color](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipatternformat/get_forecolor/)를 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

// 첫 번째 슬라이드를 가져옵니다.
auto slide = presentation->get_Slide(0);

// Rectangle 유형의 자동 도형을 추가합니다.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 채우기 유형을 Pattern으로 설정합니다.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// 패턴 스타일을 설정합니다.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// 패턴 배경색과 전경색을 설정합니다.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// PPTX 파일을 디스크에 저장합니다.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![패턴 채우기가 적용된 사각형](pattern-fill.png)

## **그림 채우기**

PowerPoint에서 그림 채우기는 이미지 를 도형 내부에 삽입하여 이미지 를 도형의 배경처럼 사용할 수 있는 형식 옵션입니다.

다음은 Aspose.Slides를 사용하여 도형에 그림 채우기를 적용하는 방법입니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 슬라이드에 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/filltype/)을 `Picture`로 설정합니다.
1. 그림 채우기 모드를 `Tile`(또는 다른 선호 모드)으로 설정합니다.
1. 사용하려는 이미지로부터 [IPPImage](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ippimage/) 객체를 생성합니다.
1. 이미지를 `ISlidesPicture.set_Image` 메서드에 전달합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

![연꽃 이미지](lotus.png)

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

// 첫 번째 슬라이드를 가져옵니다.
auto slide = presentation->get_Slide(0);

// Rectangle 유형의 자동 도형을 추가합니다.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// 채우기 유형을 Picture로 설정합니다.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// 그림 채우기 모드를 설정합니다.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// 이미지를 로드하고 프레젠테이션 리소스에 추가합니다.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// 그림을 설정합니다.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// PPTX 파일을 디스크에 저장합니다.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![그림 채우기가 적용된 도형](picture-fill.png)

### **텍스처로 타일 그림 사용**

타일 그림을 텍스처로 설정하고 타일링 동작을 사용자 정의하려면 [IPictureFillFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/) 인터페이스와 [PictureFillFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/picturefillformat/) 클래스의 다음 메서드를 사용할 수 있습니다:

- [set_PictureFillMode](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): 그림 채우기 모드를 `Tile` 또는 `Stretch`로 설정합니다.
- [set_TileAlignment](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): 도형 내 타일 정렬을 지정합니다.
- [set_TileFlip](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/set_tileflip/): 타일을 수평, 수직 또는 모두 뒤집을지 제어합니다.
- [set_TileOffsetX](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): 도형 원점으로부터 타일의 가로 오프셋(포인트)을 설정합니다.
- [set_TileOffsetY](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): 도형 원점으로부터 타일의 세로 오프셋(포인트)을 설정합니다.
- [set_TileScaleX](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): 타일의 가로 스케일을 백분율로 정의합니다.
- [set_TileScaleY](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): 타일의 세로 스케일을 백분율로 정의합니다.

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

// 첫 번째 슬라이드를 가져옵니다.
auto firstSlide = presentation->get_Slide(0);

// 사각형 자동 도형을 추가합니다.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// 도형의 채우기 유형을 Picture로 설정합니다.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// 이미지를 로드하고 프레젠테이션 리소스에 추가합니다.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// 이미지를 도형에 할당합니다.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// 그림 채우기 모드와 타일 속성을 구성합니다.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// PPTX 파일을 디스크에 저장합니다.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![타일 옵션](tile-options.png)

## **단색 채우기**

PowerPoint에서 단색 채우기는 도형을 단일, 균일한 색상으로 채우는 형식 옵션입니다. 이 단순 배경 색상은 그라디언트, 텍스처 또는 패턴 없이 적용됩니다.

Aspose.Slides를 사용하여 도형에 단색 채우기를 적용하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 슬라이드에 추가합니다.
1. 도형의 [FillType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/filltype/)을 `Solid`로 설정합니다.
1. 원하는 채우기 색상을 도형에 할당합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

// 첫 번째 슬라이드를 가져옵니다.
auto slide = presentation->get_Slide(0);

// Rectangle 유형의 자동 도형을 추가합니다.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 채우기 유형을 Solid로 설정합니다.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// 채우기 색상을 설정합니다.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// PPTX 파일을 디스크에 저장합니다.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![단색 채우기가 적용된 도형](solid-color-fill.png)

## **투명도 설정**

PowerPoint에서 도형에 단색, 그라디언트, 그림 또는 텍스처 채우기를 적용할 때 투명도 수준을 설정하여 채우기의 불투명도를 제어할 수 있습니다. 높은 투명도 값은 도형을 보다 투명하게 만들어 배경이나 아래 개체가 부분적으로 보이도록 합니다.

Aspose.Slides는 채우기에 사용되는 색상의 알파 값을 조정하여 투명도 수준을 설정할 수 있게 합니다. 방법은 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 슬라이드에 추가합니다.
1. [FillType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/filltype/)을 `Solid`로 설정합니다.
1. `Color`를 사용하여 투명도가 포함된 색상을 정의합니다(`alpha` 구성 요소가 투명도를 제어함).
1. 프레젠테이션을 저장합니다.

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

// 첫 번째 슬라이드를 가져옵니다.
auto slide = presentation->get_Slide(0);

// 고정형 사각형 자동 도형을 추가합니다.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 고정형 도형 위에 투명 사각형 자동 도형을 추가합니다.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// PPTX 파일을 디스크에 저장합니다.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![투명한 도형](shape-transparency.png)

## **도형 회전**

Aspose.Slides는 PowerPoint 프레젠테이션에서 도형을 회전시킬 수 있게 합니다. 이는 특정 정렬이나 디자인 요구에 맞게 시각 요소를 배치할 때 유용합니다.

슬라이드에서 도형을 회전시키려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 슬라이드에 추가합니다.
1. 도형의 회전 속성을 원하는 각도로 설정합니다.
1. 프레젠테이션을 저장합니다.

```cpp
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
auto presentation = MakeObject<Presentation>();

// 첫 번째 슬라이드를 가져옵니다.
auto slide = presentation->get_Slide(0);

// Rectangle 유형의 자동 도형을 추가합니다.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// 도형을 5도 회전시킵니다.
shape->set_Rotation(5);

// PPTX 파일을 디스크에 저장합니다.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![도형 회전](shape-rotation.png)

## **3D 베벨 효과 추가**

Aspose.Slides는 [ThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/threedformat/) 속성을 구성하여 도형에 3D 베벨 효과를 적용할 수 있게 합니다.

도형에 3D 베벨 효과를 추가하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 슬라이드에 추가합니다.
1. 도형의 [ThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/threedformat/)을 구성하여 베벨 설정을 정의합니다.
1. 프레젠테이션을 저장합니다.

```cpp
// Presentation 클래스의 인스턴스를 생성합니다.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// 슬라이드에 도형을 추가합니다.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// 도형의 ThreeDFormat 속성을 설정합니다.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// 프레젠테이션을 PPTX 파일로 저장합니다.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![3D 베벨 효과](3D-bevel-effect.png)

## **3D 회전 효과 추가**

Aspose.Slides는 [ThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/threedformat/) 속성을 구성하여 도형에 3D 회전 효과를 적용할 수 있게 합니다.

도형에 3D 회전 효과를 적용하려면:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드에 대한 참조를 가져옵니다.
1. [IAutoShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iautoshape/)을 슬라이드에 추가합니다.
1. [set_CameraType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icamera/set_cameratype/) 및 [set_LightType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilightrig/set_lighttype/)을 사용하여 3D 회전을 정의합니다.
1. 프레젠테이션을 저장합니다.

```cpp
// Presentation 클래스의 인스턴스를 생성합니다.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// 프레젠테이션을 PPTX 파일로 저장합니다.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![3D 회전 효과](3D-rotation-effect.png)

## **형식 재설정**

다음 C++ 코드는 슬라이드의 형식을 재설정하고 [LayoutSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/layoutslide/)에 있는 자리 표시자가 있는 모든 도형의 위치, 크기 및 형식을 기본 설정으로 되돌리는 방법을 보여줍니다:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // 레이아웃에 자리 표시자가 있는 슬라이드의 각 도형을 재설정합니다.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**도형 서식이 최종 프레젠테이션 파일 크기에 영향을 줍니까?**

거의 영향을 주지 않습니다. 삽입된 이미지와 미디어가 파일 용량의 대부분을 차지하고, 색상, 효과 및 그라디언트와 같은 도형 매개변수는 메타데이터로 저장되어 실질적인 크기 증가가 없습니다.

**슬라이드에서 동일한 서식을 공유하는 도형을 어떻게 감지하여 그룹화할 수 있나요?**

각 도형의 핵심 서식 속성(채우기, 선, 효과 설정)을 비교합니다. 모든 해당 값이 일치하면 스타일이 동일하다고 판단하고 논리적으로 그룹화하면 이후 스타일 관리가 간소화됩니다.

**맞춤형 도형 스타일 세트를 별도 파일에 저장하여 다른 프레젠테이션에서 재사용할 수 있나요?**

예. 원하는 스타일이 적용된 샘플 도형을 템플릿 슬라이드 덱이나 .POTX 템플릿 파일에 저장합니다. 새 프레젠테이션을 만들 때 템플릿을 열어 필요한 스타일 도형을 복제하고 필요할 때마다 해당 서식을 다시 적용하면 됩니다.