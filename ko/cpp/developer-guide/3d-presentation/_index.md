---
title: C++를 사용하여 프레젠테이션에 3D 효과 만들기
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/cpp/3d-presentation/
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
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 돌출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for C++는 도형과 텍스트에 대해 PowerPoint 스타일의 3D 서식을 생성, 편집, 보존 및 렌더링할 수 있습니다. 이 문서에서는 회전, 돌출, 베벨, 조명, 재질, 그라디언트 또는 그림 채우기, 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" %}}
이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것이며, 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 포함하지 않습니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때 Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

[IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/) 인터페이스의 [get_ThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_threedformat/) 메서드를 사용하여 도형에 3D 서식을 적용합니다. 이 메서드는 해당 도형의 3D 씬을 제어하는 [IThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/)을 반환합니다.

텍스트의 경우, [ITextFrameFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/) 인터페이스의 [get_ThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/get_threedformat/) 메서드를 사용합니다. 이 메서드는 도형 본문이 아니라 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 메서드는 다음과 같습니다:

| 메서드 | 제어 내용 | 사용 시점 |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_camera/) | 시점, 사전 설정 카메라 유형, 회전, 줌 및 원근. | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 사전 설정에 맞출 때. |
| [get_LightRig](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_lightrig/) | 조명 사전 설정, 방향 및 조명 회전. | 3D 표면의 하이라이트와 그림자 표시 방식을 변경할 때. |
| [set_Material](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/set_material/) | 평탄, 무광, 플라스틱, 금속 등 표면 재질. | 동일한 형상을 더 평평하게, 부드럽게, 광택 있게, 혹은 금속성으로 만들 때. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | 앞면으로부터 뒤쪽으로 도형이 연장되는 거리. | 평면 도형을 눈에 보이는 두께 있는 3D 객체로 바꿀 때. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | 돌출된 면의 색상. | 깊이를 시각화하거나 앞면 채우기와 측면 색을 맞출 때. |
| [set_Depth](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D 서식에서 사용하는 추가 깊이. | 베벨 및 재질 설정과 함께 도형이나 텍스트의 깊이를 미세 조정할 때. |
| [get_BevelTop](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_beveltop/) 및 [get_BevelBottom](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | 앞면과 뒤면의 올라가 있거나 둥근 가장자리. | 날카로운 평면 대신 부드럽거나 몰딩된 가장자리를 추가할 때. |
| [get_ContourColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_contourcolor/) 및 [set_ContourWidth](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D 객체 주위의 외곽선. | 렌더링된 출력에서 객체 경계를 강조하고 싶을 때. |

## **3D 도형 만들기**

도형이 설득력 있게 3D로 보이려면 일반적으로 네 가지 설정이 필요합니다:

- 카메라 설정 – 기본 정면 보기에서는 돌출이 가려질 수 있습니다.
- 조명 설정 – 조명이 면과 측면을 읽기 쉽게 만들어 줍니다.
- 재질 설정 – 표면 재질이 빛의 렌더링 방식에 영향을 줍니다.
- 돌출 또는 깊이 설정 – 평면 도형에 두께가 필요합니다.

다음 예제는 사각형을 만들고, 앞면에 텍스트를 추가하고, 3D 서식을 적용한 뒤, 프레젠테이션을 PPTX로 저장하고, 슬라이드를 PNG 이미지로 렌더링합니다.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);
shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = System::Drawing::Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = System::Drawing::Color::get_Blue();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"shape_3d.png");
thumbnail->Dispose();

presentation->Save(u"shape_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

렌더링된 슬라이드 이미지는 두꺼운 3D 블록 형태의 사각형을 보여줍니다:

![앞면에 흰색 3D 텍스트가 있는 파란색 3D 사각형 렌더링 이미지](img_01_01.png)

## **카메라로 도형 회전시키기**

PowerPoint에서는 3-D 회전 창에서 회전을 설정합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정한 회전과 일치합니다.

![X, Y, Z 회전 값이 강조된 PowerPoint 3-D 회전 창 이미지](img_02_01.png)

Aspose.Slides에서는 [IThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/)을 통해 카메라 유형과 회전을 설정합니다:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
```

카메라는 보는 사람의 시점을 변경하고 싶을 때 사용합니다. 슬라이드상의 2D 도형 기하학 자체를 변경하지는 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 시점을 바꿉니다.

## **돌출 및 깊이 추가하기**

돌출은 앞면 뒤로 연장하여 도형을 두껍게 보이게 합니다. PowerPoint에서 깊이 컨트롤은 눈에 보이는 두께를 설정하고, 색상 컨트롤은 측면 면의 색을 지정합니다.

![돌출 색상 및 돌출 높이 속성에 매핑된 PowerPoint 깊이 컨트롤 이미지](img_02_02.png)

두께는 [set_ExtrusionHeight](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/set_extrusionheight/)로, 측면 색은 [get_ExtrusionColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_extrusioncolor/)으로 설정합니다:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = System::Drawing::Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

PowerPoint의 깊이 값을 직접 사용하거나 깊이를 베벨, 재질, 텍스트 효과와 결합해야 할 때는 [set_Depth](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/set_depth/)를 사용합니다. 많은 도형 시나리오에서 `set_ExtrusionHeight`가 눈에 보이는 돌출을 직접 표현하기 때문에 더 직관적입니다.

## **그라디언트 또는 그림 채우기와 3D 효과 결합하기**

3D 서식은 도형 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 그림 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 돌출 설정을 사용할 수 있습니다.

다음 예제는 도형에 그라디언트 채우기를 적용하고, 측면에 더 어두운 돌출 색을 지정합니다:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/ILightRig.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = System::Drawing::Color::get_Blue();
auto secondGradientColor = System::Drawing::Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"gradient_3d.png");
thumbnail->Dispose();

presentation->Dispose();
```

렌더링 결과는 앞면에 그라디언트를 유지하고 돌출은 별도로 렌더링됩니다:

![파란색에서 주황색으로 그라디언트 채워진 앞면과 주황색 돌출을 가진 3D 사각형 렌더링 이미지](img_02_03.png)

그림 채우기를 사용하려면 프레젠테이션에 이미지를 추가하고 도형 채우기로 할당합니다:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

auto imageData = System::IO::File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = System::Drawing::Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);
```

그림은 앞면에 렌더링되고, 돌출은 3D 측면 표면으로 렌더링됩니다:

![앞면에 사진 채우기가 적용되고 주황색 돌출이 있는 3D 사각형 렌더링 이미지](img_02_04.png)

## **텍스트에 3D 서식 적용하기**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 글자 자체에 돌출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 패턴 채우기가 적용된 텍스트를 만들고, WordArt 변형을 적용한 뒤, [ITextFrameFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/)에 3D 설정을 구성합니다:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

const float imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = System::Drawing::Color::get_DarkOrange();
auto backgroundColor = System::Drawing::Color::get_White();
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(foregroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(backgroundColor);
portion->get_PortionFormat()->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::LargeGrid);

shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(128.0f);

auto textFrameFormat = shape->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_Transform(TextShapeType::ArchUp);
textFrameFormat->get_ThreeDFormat()->set_ExtrusionHeight(3.5);
textFrameFormat->get_ThreeDFormat()->set_Depth(3.0);
textFrameFormat->get_ThreeDFormat()->set_Material(MaterialPresetType::Plastic);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
textFrameFormat->get_ThreeDFormat()->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);
textFrameFormat->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);

auto thumbnail = slide->GetImage(imageScale, imageScale);
thumbnail->Save(u"text_3d.png");
thumbnail->Dispose();

presentation->Save(u"text_3d.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

텍스트는 곡선형으로 돌출된 3D 문자로 렌더링됩니다:

![아치형 WordArt 변형, 주황색 패턴 채우기 및 어두운 돌출을 가진 3D 텍스트 렌더링 이미지](img_02_05.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 씬은 2D 결과물로 래스터화되거나 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/cpp/convert-powerpoint-to-png/)로 렌더링하거나, [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/)로 내보내거나, [HTML](/slides/ko/cpp/convert-powerpoint-to-html/)로 내보내거나, [비디오 변환](/slides/ko/cpp/convert-powerpoint-to-video/)을 위해 프레임을 생성할 때 모두 적용됩니다.

주의할 점:

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 내보낸 후에는 사용자가 객체를 회전시킬 수 없습니다.
- 최종 모습은 카메라, 라이트 릭, 재질, 돌출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 확인해야 하면 [효과적인 도형 속성](/slides/ko/cpp/shape-effective-properties/)을 읽으세요.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적인 결과가 렌더링될 뿐 편집 가능한 3D 설정으로 보존되지 않습니다.

## **FAQ**

### Aspose.Slides가 인터랙티브 3D 프레젠테이션을 만들 수 있나요?

Aspose.Slides는 도형과 텍스트에 대한 PowerPoint 3D 효과를 생성하고 렌더링합니다. 내보낸 이미지, PDF, HTML 페이지를 사용자가 회전시킬 수 있는 인터랙티브 3D 씬으로 만들지는 않습니다. PPTX에서는 지원되는 경우 3D 서식이 PowerPoint에서 편집 가능하게 유지됩니다.

### 3D 모델과 3D 효과의 차이는 무엇인가요?

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 일반 PowerPoint 도형이나 텍스트에 적용되는 서식으로, 회전, 돌출, 베벨, 조명, 재질 등이 포함됩니다. 이 문서는 3D 효과에 대해 다룹니다.

### 눈에 보이는 3D 도형을 만들기 위해 꼭 필요한 설정은 무엇인가요?

최소한 카메라 회전과 돌출 또는 깊이를 설정해야 합니다. 실제로는 라이트 릭과 재질도 함께 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 좋습니다.

### 도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?

예. 도형 본문에는 [IShape](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/)을, 텍스트에는 [ITextFrameFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/)을 사용합니다.

### 이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 나타나나요?

예. Aspose.Slides는 슬라이드 이미지를 만들 때, PDF 출력, HTML 출력, 비디오 변환용 프레임을 만들 때 3D 효과를 렌더링합니다. 내보낸 결과물에는 렌더링된 모습이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

### 상속 및 테마 적용 후 최종 3D 값을 읽을 수 있나요?

예. [효과적인 도형 속성](/slides/ko/cpp/shape-effective-properties/)에 설명된 효율적인 서식 API를 사용해 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽을 수 있습니다.