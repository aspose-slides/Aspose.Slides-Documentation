---
title: C++를 사용한 프레젠테이션 3D 효과 만들기
linktitle: 3D 프레젠테이션
type: docs
weight: 232
url: /ko/cpp/3d-presentation/
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
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint 도형 및 텍스트에 3D 효과를 적용하고 렌더링합니다. 카메라, 조명, 재질, 돌출, 채우기 및 3D 텍스트를 구성합니다."
---
## **개요**

Aspose.Slides for C++는 도형 및 텍스트에 대한 PowerPoint 스타일 3D 서식을 생성, 편집, 보존 및 렌더링할 수 있습니다. 이 문서는 회전, 돌출, 베벨, 조명, 재질, 그라디언트 또는 그림 채우기, 3D 텍스트와 같은 3D 효과를 다룹니다.

{{% alert color="info" title="Note" %}}
이 문서는 PowerPoint 도형 및 텍스트에 대한 3D 서식 효과에 관한 것입니다. 독립형 3D 모델 파일을 삽입하거나 편집하는 내용은 아닙니다. 슬라이드를 이미지, PDF 또는 HTML로 내보낼 때, Aspose.Slides는 해당 3D 효과를 내보낸 2D 출력에 렌더링합니다.
{{% /alert %}}

## **3D 서식 개념**

도형에 3D 서식을 적용하려면 [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_threedformat/) 메서드를 사용합니다. 이 메서드는 해당 도형의 3D 씬을 제어하는 [IThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/)을 반환합니다.

텍스트의 경우 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/get_threedformat/) 메서드를 사용합니다. 이는 도형 본문이 아닌 텍스트 프레임에 3D 서식을 적용합니다.

가장 중요한 메서드는 다음과 같습니다:

| 메서드 | 제어 내용 | 사용 시점 |
|---|---|---|
| [get_Camera](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_camera/) | 시점, 사전 설정 카메라 유형, 회전, 줌 및 원근. | 3D 공간에서 객체를 회전하거나 PowerPoint 3D 회전 사전 설정에 맞출 때. |
| [get_LightRig](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_lightrig/) | 조명 사전 설정, 방향 및 조명 회전. | 3D 표면의 하이라이트와 그림자 모양을 변경할 때. |
| [set_Material](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/set_material/) | 표면 재질, 예: 평면, 무광, 플라스틱 또는 금속. | 같은 기하학을 더 평평하거나 부드럽게, 광택 있게 또는 금속처럼 보이게 할 때. |
| [set_ExtrusionHeight](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/set_extrusionheight/) | 도형이 앞면에서 뒤쪽으로 얼마나 연장되는지. | 평평한 도형을 눈에 보이는 두꺼운 3D 객체로 전환할 때. |
| [get_ExtrusionColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_extrusioncolor/) | 돌출된 측면의 색상. | 깊이를 보이게 하거나 측면 색을 앞면 채우기와 일치시킬 때. |
| [set_Depth](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/set_depth/) | PowerPoint 3D 서식에서 사용되는 추가 3D 깊이. | 특히 베벨 및 재질 설정과 함께 도형이나 텍스트의 깊이를 미세 조정할 때. |
| [get_BevelTop](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_beveltop/)와 [get_BevelBottom](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_bevelbottom/) | 앞면과 뒷면의 돌출되거나 둥근 가장자리. | 날카로운 평면 대신 부드럽거나 몰딩된 가장자리를 추가할 때. |
| [get_ContourColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_contourcolor/)와 [set_ContourWidth](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/set_contourwidth/) | 3D 객체 주변의 외곽선. | 렌더링된 출력에서 객체 경계를 강조하려 할 때. |

## **3D 도형 만들기**

도형이 설득력 있게 3D로 보이기 위해서는 일반적으로 네 가지 설정이 필요합니다:

- 카메라 설정, 기본 앞면 보기에서 돌출이 가려질 수 있기 때문입니다.
- 조명 설정, 조명이 면과 측면을 읽기 쉽게 만들기 때문입니다.
- 재질 설정, 표면이 조명 렌더링에 영향을 주기 때문입니다.
- 돌출 또는 깊이 설정, 평면 도형에 두께가 필요하기 때문입니다.

다음 예제는 사각형을 만들고, 앞면에 텍스트를 추가한 뒤 3D 서식을 적용합니다. 카메라 회전 값은 도이며, 돌출 높이는 100포인트입니다. 이 예제는 슬라이드를 기본 크기의 두 배인 PNG 이미지로 렌더링하고 프레젠테이션을 PPTX로 저장합니다:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_TextFrame()->set_Text(u"3D");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto frontColor = Color::get_CornflowerBlue();
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(frontColor);

auto extrusionColor = Color::get_Blue();
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

렌더링된 슬라이드 이미지에서 사각형이 두꺼운 3D 블록으로 표시됩니다:

![앞면에 흰색 3D 텍스트가 있는 파란색 3D 사각형 렌더링](img_01_01.png)

## **카메라로 도형 회전하기**

PowerPoint에서 3D 회전은 3-D 회전 패널에서 설정합니다. X, Y, Z 회전 값은 카메라 API를 통해 설정한 회전값에 해당합니다.

![X, Y, Z 회전 값이 강조 표시된 PowerPoint 3-D 회전 패널](img_02_01.png)

Aspose.Slides에서는 [IThreeDFormat::get_Camera](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_camera/)를 통해 카메라에 접근합니다. 이 예제는 사각형을 만들고, 직교 앞면 보기를 선택한 뒤 X, Y, Z 회전을 각각 20°, 30°, 40°로 설정합니다. 파일을 저장하지 않고 메모리 상에서 도형을 구성합니다:

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

presentation->Dispose();
```

뷰어가 객체를 보는 방식을 변경해야 할 때 카메라를 사용합니다. 이는 슬라이드의 2D 도형 기하학을 변경하지 않으며, PowerPoint와 Aspose.Slides가 렌더링할 때 사용되는 3D 시점을 변경합니다.

## **돌출 및 깊이 추가하기**

돌출은 앞면 뒤쪽으로 도형을 연장시켜 두껍게 보이게 합니다. PowerPoint에서 깊이 제어는 이 가시적인 두께를 설정하고, 색상 제어는 측면의 색상을 설정합니다.

![PowerPoint 깊이 제어가 돌출 색상 및 돌출 높이 속성과 매핑된 모습](img_02_02.png)

두께를 지정하려면 [IThreeDFormat::set_ExtrusionHeight](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/set_extrusionheight/)를, 측면 색을 지정하려면 [IThreeDFormat::get_ExtrusionColor](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/get_extrusioncolor/)를 사용합니다. 이 예제는 사각형에 100포인트 돌출을 주고 보라색 측면을 적용한 뒤 카메라를 회전시켜 두께를 확인합니다. 파일을 저장하지 않고 메모리 상에서 도형을 구성합니다:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 200.0f, 200.0f);

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(20.0f, 30.0f, 40.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(100.0);

auto extrusionColor = Color::get_Purple();
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

[IThreeDFormat::set_Depth](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/set_depth/) 메서드는 3D 도형의 깊이를 설정합니다. [set_ExtrusionHeight](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ithreedformat/set_extrusionheight/) 메서드는 예제와 같이 돌출 효과의 높이를 제어합니다.

## **3D 효과와 함께 그라디언트 또는 그림 채우기 사용하기**

3D 서식은 도형 채우기와 독립적입니다. 앞면에 단색, 그라디언트, 패턴 또는 그림 채우기를 적용하면서 동일한 카메라, 조명, 재질 및 돌출 설정을 사용할 수 있습니다.

다음 예제는 앞면에 파란색‑주황색 그라디언트를 적용하고 150포인트 돌출에 어두운 주황색을 적용합니다. 그라디언트 정점은 0과 100으로 시작과 끝을 표시합니다. 카메라 회전 값은 도이며, 슬라이드는 기본 크기의 두 배인 PNG 이미지로 렌더링됩니다:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);
shape->get_TextFrame()->set_Text(u"3D Gradient");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(64.0f);

auto firstGradientColor = Color::get_Blue();
auto secondGradientColor = Color::get_Orange();
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, firstGradientColor);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(100.0f, secondGradientColor);

auto extrusionColor = Color::get_DarkOrange();
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

렌더링된 결과는 앞면의 그라디언트를 유지하고 돌출을 별도로 렌더링합니다:

![파란색에서 주황색으로 그라디언트 채우기와 주황색 돌출이 적용된 3D 사각형 렌더링](img_02_03.png)

그림 채우기를 사용하려면 이미지를 프레젠테이션에 추가하고 도형 채우기에 할당합니다. 이 예제는 작업 디렉터리에 "image.jpg" 파일이 존재한다고 가정합니다. 그림을 사각형에 맞게 늘리고 150포인트 돌출을 적용하며 카메라 회전을 도 단위로 설정합니다. 파일을 저장하거나 렌더링하지 않고 메모리 상에서 도형을 구성합니다:

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/ILightRig.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
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

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

auto imageData = File::ReadAllBytes(u"image.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

shape->get_FillFormat()->set_FillType(FillType::Picture);
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

auto extrusionColor = Color::get_DarkOrange();
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(10.0f, 20.0f, 30.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(150.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(extrusionColor);

presentation->Dispose();
```

그림은 앞면에 렌더링되고 돌출은 3D 측면 표면으로 렌더링됩니다:

![앞면에 사진 채우기와 주황색 돌출이 적용된 3D 사각형 렌더링](img_02_04.png)

## **텍스트에 3D 서식 적용하기**

도형 3D 서식은 도형 본문에 영향을 주고, 텍스트 3D 서식은 텍스트 프레임에 영향을 줍니다. 이는 글자 자체에 돌출, 재질, 조명 및 카메라 설정이 필요한 WordArt와 같은 효과에 유용합니다.

다음 예제는 주황색‑흰색 격자 패턴 텍스트를 만들고 위쪽 아치를 적용한 뒤 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/get_threedformat/)을 통해 3D 설정을 구성합니다. 돌출 높이와 깊이는 포인트 단위이며, 조명 회전은 도 단위입니다. 도형 채우기와 외곽선은 숨겨져 텍스트만 보이게 합니다. 예제는 기본 슬라이드 크기의 두 배인 PNG 이미지로 렌더링하고 프레젠테이션을 PPTX로 저장합니다:

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

const auto imageScale = 2.0f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 150.0f, 250.0f, 250.0f);

shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->set_Text(u"3D Text");

auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Pattern);

auto foregroundColor = Color::get_DarkOrange();
auto backgroundColor = Color::get_White();
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

![아치형 WordArt 변형, 주황색 패턴 채우기 및 어두운 돌출이 적용된 3D 텍스트 렌더링](img_02_05.png)

## **3D 도형에서 텍스트를 평면으로 유지하기**

도형의 3D 모습을 유지하면서 텍스트를 읽기 쉽게 하려면 [ITextFrameFormat::set_KeepTextFlat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/set_keeptextflat/)를 호출합니다. 값이 `true`이면 텍스트가 3D 씬에서 제외됩니다. `false`이면 텍스트가 씬에 포함되어 3D 방향을 따릅니다.

이 설정은 [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_threedformat/)을 통해 구성된 도형의 카메라, 조명, 재질 및 돌출을 제거하지 않습니다. 일반 회전과도 다릅니다. [IShape::set_Rotation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/set_rotation/)은 슬라이드 평면에서 도형을 회전시키고, [ITextFrameFormat::set_RotationAngle](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/set_rotationangle/)은 텍스트의 경계 상자 내 맞춤 회전을 제어합니다. 텍스트를 3D 씬에서 제외한다 해도 이 각도들은 리셋되지 않습니다.

다음 독립형 예제는 텍스트가 포함된 파란 사각형을 만들고 원본 옆에 복제합니다. 두 도형 모두 동일한 3D 서식을 가지고 텍스트 설정만 다릅니다: 왼쪽은 `false`, 오른쪽은 `true`. 카메라 각도는 도이며, 돌출 높이는 40포인트입니다. 예제는 프레젠테이션을 PPTX로 저장하고 비교 슬라이드를 기본 크기의 두 배인 PNG로 렌더링합니다:

```cpp
#include <DOM/ITextFrameFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextAnchorType.h>
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 70.0f, 160.0f, 240.0f, 140.0f);

shape->get_TextFrame()->set_Text(u"Readable text");
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);
shape->get_TextFrame()->get_Paragraph(0)->get_ParagraphFormat()->set_Alignment(TextAlignment::Center);
shape->get_TextFrame()->get_TextFrameFormat()->set_AnchoringType(TextAnchorType::Center);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_CornflowerBlue());

shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(30.0f, 30.0f, 0.0f);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Flat);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);
shape->get_ThreeDFormat()->set_Material(MaterialPresetType::Flat);
shape->get_ThreeDFormat()->set_ExtrusionHeight(40.0);
shape->get_ThreeDFormat()->get_ExtrusionColor()->set_Color(Color::get_RoyalBlue());
shape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(false);

auto clonedShape = slide->get_Shapes()->AddClone(shape, 400.0f, 160.0f);
auto flatTextShape = System::ExplicitCast<IAutoShape>(clonedShape);
flatTextShape->get_TextFrame()->get_TextFrameFormat()->set_KeepTextFlat(true);

presentation->Save(u"keep_text_flat.pptx", SaveFormat::Pptx);
auto image = slide->GetImage(2.0f, 2.0f);
image->Save(u"keep_text_flat.png");
image->Dispose();
presentation->Dispose();
```

왼쪽에서는 텍스트가 3D 방향을 따릅니다. 오른쪽에서는 텍스트가 평면으로 유지되어 읽기 쉬워집니다. 두 사각형 모두 동일한 가시적인 돌출과 3D 방향을 유지합니다.

![좌측은 KeepTextFlat가 false, 우측은 true인 3D 사각형 비교](keep_text_flat.png)

## **내보내기 및 렌더링 동작**

Aspose.Slides는 PPTX와 같은 PowerPoint 형식으로 저장할 때 3D 서식을 보존합니다. 고정 레이아웃 형식으로 렌더링하거나 내보낼 때 3D 씬은 래스터화되거나 2D 결과물로 출력에 그려집니다. 이는 슬라이드를 [PNG](/slides/ko/cpp/convert-powerpoint-to-png/)로 렌더링하거나, [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/)로 내보내거나, [HTML](/slides/ko/cpp/convert-powerpoint-to-html/)로 내보내거나, [비디오 변환](/slides/ko/cpp/convert-powerpoint-to-video/)용 프레임을 생성할 때 적용됩니다.

- 내보낸 이미지와 PDF는 인터랙티브하지 않습니다. 내보낸 후 뷰어가 객체를 회전시킬 수 없습니다.
- 최종 모습은 카메라, 라이트 릭, 재질, 돌출, 채우기 및 슬라이드 스케일링의 조합에 따라 달라집니다.
- 상속되거나 테마 기반 서식 값을 확인해야 하면 [effective shape properties](/slides/ko/cpp/shape-effective-properties/)를 참고하십시오.
- 일부 출력 형식은 편집 가능한 PowerPoint 3D 서식을 저장할 수 없습니다. 이러한 형식에서는 시각적 결과가 편집 가능한 3D 설정이 아니라 렌더링된 이미지로 저장됩니다.

## **FAQ**

**Aspose.Slides가 대화형 3D 프레젠테이션을 만들 수 있나요?**

Aspose.Slides는 도형과 텍스트에 대한 PowerPoint 3D 효과를 생성하고 렌더링합니다. 내보낸 이미지, PDF 또는 HTML 페이지를 뷰어가 회전시킬 수 있는 대화형 3D 씬으로 만들지는 않습니다. PPTX에서는 해당 형식이 지원하는 경우 3D 서식이 PowerPoint에서 편집 가능하게 유지됩니다.

**3D 모델과 3D 효과의 차이점은 무엇인가요?**

3D 모델은 프레젠테이션에 삽입되는 별도의 3D 객체입니다. 3D 효과는 도형이나 텍스트에 적용되는 서식으로 회전, 돌출, 베벨, 조명, 재질 등이 포함됩니다. 이 문서는 3D 효과에 대해 다룹니다.

**보이는 3D 도형에 필요한 설정은 무엇인가요?**

최소한 카메라 회전과 돌출 또는 깊이를 설정해야 합니다. 실제 작업에서는 라이트 릭과 재질도 설정하여 렌더링된 면에 명확한 하이라이트와 그림자를 제공하는 것이 좋습니다.

**도형과 텍스트 모두에 3D 효과를 적용할 수 있나요?**

예, 도형 본문에는 [IShape::get_ThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ishape/get_threedformat/)을, 텍스트에는 [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides/itextframeformat/get_threedformat/)을 사용합니다.

**이미지, PDF, HTML 또는 비디오 프레임으로 내보낼 때 3D 효과가 나타나나요?**

예, Aspose.Slides는 슬라이드 이미지를 생성하거나 PDF, HTML 출력 및 비디오 변환용 프레임을 만들 때 3D 효과를 렌더링합니다. 내보낸 결과물에는 렌더링된 모양이 포함되며, 편집 가능한 3D 객체는 포함되지 않습니다.

**상속 및 테마 설정이 적용된 후 최종 3D 값을 읽을 수 있나요?**

예, [Shape Effective Properties](/slides/ko/cpp/shape-effective-properties/)에 설명된 효과적인 서식 API를 사용하여 최종 카메라, 라이트 릭, 베벨 및 관련 3D 값을 읽을 수 있습니다.