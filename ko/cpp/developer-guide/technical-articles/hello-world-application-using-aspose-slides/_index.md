---
title: Aspose.Slides for C++를 사용한 Hello World 애플리케이션
type: docs
weight: 80
url: /ko/cpp/hello-world-application-using-aspose-slides/
keywords:
- 헬로 월드
- 애플리케이션
- 파워포인트
- 오픈문서
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 첫 번째 C++ 앱을 만들고, PPT, PPTX 및 ODP 프레젠테이션을 자동화할 준비가 되는 간단한 Hello World 예제입니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 간단한 **Hello World** PowerPoint 프레젠테이션을 만드는 방법을 보여줍니다. 이 예제는 새 프레젠테이션을 만들고, 첫 번째 슬라이드에 접근하고, 지정된 위치에 사각형 AutoShape을 추가하고, **Hello World** 텍스트가 포함된 텍스트 프레임을 삽입하며, 도형 및 텍스트 서식을 조정하는 방법을 설명합니다.

또한 텍스트 색상을 검은색으로 변경하여 보이게 하고, 선 색상을 흰색으로 설정해 도형 테두리를 숨기며, 도형 채우기를 제거하고, 프레젠테이션을 PPTX 파일로 저장하는 방법도 설명합니다.

## **Hello World 애플리케이션을 만드는 단계**

아래 단계에 따라 Aspose.Slides for C++ API를 사용하여 **Hello World** 애플리케이션을 만드세요:

- Presentation 클래스의 인스턴스를 생성합니다.
- Presentation을 인스턴스화할 때 생성되는 프레젠테이션의 첫 번째 슬라이드에 대한 참조를 가져옵니다.
- 슬라이드의 지정된 위치에 ShapeType이 Rectangle인 AutoShape을 추가합니다.
- Hello World를 기본 텍스트로 포함하는 TextFrame을 AutoShape에 추가합니다.
- 텍스트 색상이 기본값인 흰색이라 슬라이드 흰색 배경에서 보이지 않으므로 텍스트 색상을 검은색으로 변경합니다.
- 도형 테두리를 숨기기 위해 선 색상을 흰색으로 변경합니다.
- 도형의 기본 채우기 형식을 제거합니다.
- 마지막으로 Presentation 객체를 사용하여 프레젠테이션을 원하는 파일 형식으로 저장합니다.

위 단계들의 구현은 아래 예제에서 보여집니다.

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // 첫 번째 슬라이드를 가져옵니다
    auto slide = pres->get_Slides()->idx_get(0);

    // Rectangle 타입의 AutoShape을 추가합니다
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // Rectangle에 TextFrame을 추가합니다
    shape->AddTextFrame(u"Hello World");

    // 텍스트 색상을 검은색으로 변경합니다 (기본값은 흰색입니다)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // Rectangle의 선 색상을 흰색으로 변경합니다
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // 도형의 모든 채우기 서식을 제거합니다
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // 프레젠테이션을 디스크에 저장합니다
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```