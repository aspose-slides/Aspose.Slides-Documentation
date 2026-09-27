---
title: C++에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/cpp/create-presentation/
keywords:
- 프레젠테이션 만들기
- 새 프레젠테이션
- PPT 만들기
- 새 PPT
- PPTX 만들기
- 새 PPTX
- ODP 만들기
- 새 ODP
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 프레젠테이션을 만들고—PPT, PPTX 및 ODP 파일을 생성하며 OpenDocument 지원을 활용하고, 프로그래밍 방식으로 저장하여 신뢰할 수 있는 결과를 얻으세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프레젠테이션을 만들고 첫 번째 슬라이드에 텍스트 상자를 추가한 후 결과를 파일로 저장하는 방법을 보여줍니다. 마지막에 포함된 간단한 FAQ에서는 형식, 템플릿, 슬라이드 크기, 단위, 메모리 사용량, 스레딩, 라이선스, 디지털 서명 및 VBA 지원에 관한 일반적인 질문을 다룹니다.

시작하기 전에 Aspose.Slides를 프로젝트에 추가하세요: Windows의 Visual Studio 프로젝트에서는 NuGet을 사용하거나 Linux에서는 CMake와 함께 ZIP 패키지를 사용합니다. [Installation](/slides/ko/cpp/installation/)을 확인하세요.

## **PowerPoint 프레젠테이션 만들기**

프레젠테이션을 만들고 첫 번째 슬라이드에 텍스트 상자를 추가하려면 다음 단계에 따라 진행하십시오:

1. 새로운 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 클래스 인스턴스를 생성합니다. 새 프레젠테이션에는 이미 빈 슬라이드가 하나 포함되어 있습니다.
2. [Presentation::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slide/) 메서드와 인덱스 0을 사용하여 해당 슬라이드를 가져옵니다.
3. [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addautoshape/) 메서드를 사용하여 사각형을 추가하고, [ITextFrame::set_Text](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/set_text/) 메서드로 텍스트를 설정합니다.
4. [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 메서드를 사용하여 프레젠테이션을 PPTX 파일로 저장합니다.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

사각형의 왼쪽 위 모서리는 슬라이드 왼쪽 가장자리에서 50포인트, 위 가장자리에서 50포인트 떨어져 있으며, 사각형의 너비는 400포인트, 높이는 100포인트입니다. 프로그램은 작업 디렉터리에 *hello.pptx* 파일을 저장하며, 이 파일에는 사각형과 텍스트가 포함된 슬라이드가 하나 있습니다. 라이선스가 없는 경우 Aspose.Slides는 저장된 모든 슬라이드에 평가용 워터마크를 추가합니다; 자세한 내용은 [Licensing](/slides/ko/cpp/licensing/)를 참조하세요.

## **FAQ**

### 새 프레젠테이션을 어떤 형식으로 저장할 수 있나요?

새 프레젠테이션은 [PPTX, PPT, 및 ODP](/slides/ko/cpp/save-presentation/) 형식으로 저장할 수 있으며, [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/ko/cpp/convert-powerpoint-to-xps/), [HTML](/slides/ko/cpp/convert-powerpoint-to-html/), [SVG](/slides/ko/cpp/render-a-slide-as-an-svg-image/), 그리고 [images](/slides/ko/cpp/convert-powerpoint-to-png/) 등으로 내보낼 수 있습니다.

### 템플릿(POTX/POTM)에서 시작하여 일반 PPTX로 저장할 수 있나요?

예. 템플릿을 로드한 후 원하는 형식으로 저장하면 됩니다; POTX/POTM/PPTM 및 유사한 형식은 [지원됩니다](/slides/ko/cpp/supported-file-formats/)。

### 프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어하나요?

[slide size](/slides/ko/cpp/slide-size/)를 설정하고(4:3 및 16:9와 같은 프리셋 또는 사용자 정의 치수 포함) 콘텐츠가 어떻게 스케일될지 선택합니다。

### 크기와 좌표는 어떤 단위로 측정되나요?

포인트 단위입니다: 1인치는 72포인트에 해당합니다。

### 매우 큰 프레젠테이션(미디어 파일이 많은 경우)의 메모리 사용량을 줄이려면 어떻게 해야 하나요?

[BLOB 관리 전략](/slides/ko/cpp/manage-blob/)을 사용하고, 임시 파일을 활용하여 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 워크플로를 선호하십시오。

### 프레젠테이션을 병렬로 생성/저장할 수 있나요?

같은 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 인스턴스를 [여러 스레드](/slides/ko/cpp/multithreading/)에서 동시에 사용할 수 없습니다. 스레드 또는 프로세스당 별도의 독립 인스턴스를 실행하십시오。

### 평가용 워터마크와 제한을 제거하려면 어떻게 해야 하나요?

프로세스당 한 번씩 [Apply a license](/slides/ko/cpp/licensing/)를 적용하십시오. 라이선스 XML은 수정되지 않아야 하며, 여러 스레드가 관여하는 경우 라이선스 설정을 동기화해야 합니다。

### 생성한 PPTX에 디지털 서명을 할 수 있나요?

예. 프레젠테이션에 대해 [Digital signatures](/slides/ko/cpp/digital-signature-in-powerpoint/) (추가 및 검증)이 지원됩니다。

### 생성된 프레젠테이션에서 매크로(VBA)를 지원하나요?

예. [create/edit VBA projects](/slides/ko/cpp/presentation-via-vba/)를 통해 VBA 프로젝트를 만들거나 편집할 수 있으며, PPTM/PPSM과 같은 매크로 사용 파일을 저장할 수 있습니다.