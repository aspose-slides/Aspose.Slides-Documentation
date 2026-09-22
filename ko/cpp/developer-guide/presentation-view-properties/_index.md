---
title: C++에서 프레젠테이션 뷰 속성 검색 및 업데이트
linktitle: 뷰 속성
type: docs
weight: 80
url: /ko/cpp/presentation-view-properties/
keywords:
- 뷰 속성
- 일반 뷰
- 개요 콘텐츠
- 개요 아이콘
- 수직 스플리터 고정
- 단일 뷰
- 바 상태
- 차원 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++의 뷰 속성을 발견하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 정의하고 레이아웃, 확대 수준 및 표시 설정을 조정합니다."
---
## **소개**

일반 뷰는 세 개의 콘텐츠 영역으로 구성됩니다: 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역. 서로 다른 콘텐츠 영역의 위치와 관련된 속성들입니다. 이 정보는 애플리케이션이 뷰 상태를 파일에 저장하도록 하여, 프레젠테이션을 다시 열 때 마지막 저장 시점과 같은 상태로 뷰가 표시되게 합니다.

메서드 [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iviewproperties/get_normalviewproperties/)가 프레젠테이션의 일반 뷰 속성에 접근할 수 있도록 추가되었습니다.  

[INormalViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/inormalviewrestoredproperties/) 인터페이스와 그 파생형, [SplitterBarStateType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/splitterbarstatetype/) 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

일반 뷰 속성을 나타냅니다.

속성 **ShowOutlineIcons**는 일반 뷰 모드에서 개요 콘텐츠를 표시할 때 애플리케이션이 아이콘을 표시해야 하는지 여부를 지정합니다.

속성 **SnapVerticalSplitter**는 측면 영역이 충분히 작아질 경우 수직 분할기를 최소화된 상태로 고정할지 여부를 지정합니다.

속성 **PreferSingleView**는 사용자가 세 개의 콘텐츠 영역이 있는 표준 일반 뷰보다 전체 창을 차지하는 단일 콘텐츠 영역을 선호하는지 여부를 지정합니다. 이 옵션이 활성화되면 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

속성 **VerticalBarState**와 **HorizontalBarState**는 각각 수직 또는 수평 분할 막대가 어떤 상태로 표시되어야 하는지를 지정합니다. 수평 분할 막대는 슬라이드와 아래쪽 콘텐츠 영역을 구분하고, 수직 분할 막대는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** 및 **SplitterBarStateType.Restored**입니다.

속성 **RestoredLeft**와 **RestoredTop**은 **VerticalBarState**와 **HorizontalBarState**에 **SplitterBarStateType.Restored** 값이 적용될 때 일반 뷰의 측면 또는 상단 슬라이드 영역의 크기를 지정합니다.

## **INormalViewProperties 복원에 대하여**

일반 뷰의 슬라이드 영역(가변 복원 크기인 경우, 최소화되지도 아니고 최대화되지도 않은)의 크기를 지정합니다.

속성 **DimensionSize**는 복원된 상단(높이) 또는 복원된 좌측(너비) 영역의 슬라이드 영역 크기를 지정합니다.

속성 **AutoAdjust**는 창 크기를 조정할 때 측면 콘텐츠 영역이 새로운 크기에 맞게 자동으로 조정되어야 하는지 여부를 지정합니다.

아래 예제는 프레젠테이션의 **ViewProperties.NormalViewProperties** 속성에 접근하는 방법을 보여줍니다.

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// 프레젠테이션의 뷰 속성을 복원합니다
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **기본 확대/축소 값 설정**

Aspose.Slides for C++는 이제 프레젠테이션을 열 때 이미 확대/축소 비율이 설정된 기본 확대/축소 값을 지원합니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/)를 설정함으로써 수행할 수 있습니다. 슬라이드 뷰 속성뿐만 아니라 [get_NotesViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/get_notesviewproperties/)도 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 Aspose.Slides에서 프레젠테이션의 뷰 속성을 설정하는 예제를 살펴봅니다.

뷰 속성을 설정하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 프레젠테이션의 뷰 [Properties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/)를 설정합니다.
3. 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 슬라이드 뷰와 노트 뷰 모두에 확대 비율을 설정했습니다.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// 프레젠테이션의 뷰 속성을 설정합니다
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // 슬라이드 뷰에 대한 백분율 줌 값
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // 노트 뷰에 대한 백분율 줌 값 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **그리드 간격 설정**

[Presentation::get_ViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_viewproperties/)를 사용하여 프레젠테이션 전체에 대한 뷰 설정에 접근합니다. [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iviewproperties/get_gridspacing/) 및 [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iviewproperties/set_gridspacing/) 메서드는 기본 편집 그리드의 간격을 읽거나 변경합니다. 이 설정은 개별 슬라이드가 아니라 전체 프레젠테이션에 적용됩니다. 그리드 간격은 포인트 단위이며, 72포인트가 1인치에 해당합니다. API 문서에 명시된 대로 양의 값을 사용하세요.

다음 예제는 기존 `demo.pptx` 파일을 열어 현재 그리드 간격을 출력하고, 1/4인치 간격으로 설정한 뒤 결과를 저장합니다.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

그리드는 [drawing guides](/slides/ko/cpp/drawing-guides/)와 다릅니다. 그리드 간격은 정규 간격을 제어하고, 그리기 가이드는 개별적으로 배치된 수평 또는 수직 정렬선입니다. 그리기 가이드를 추가, 이동 또는 삭제해도 그리드 간격은 변하지 않습니다.

그리드와 그리기 가이드는 모두 편집 보조 도구이며, PDF, 이미지, SVG 또는 슬라이드 쇼에서는 슬라이드 콘텐츠로 렌더링되지 않습니다. 그리드 간격을 저장한다고 해서 편집기가 반드시 그리드를 표시하는 것은 아니며, 표시 여부는 뷰어나 편집기의 설정에 따라 달라집니다.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 보이지 않는 이유는?**  
파일에 그리드 간격이 저장되지만, 편집기가 그리드를 표시할지 여부를 제어합니다. 편집기의 그리드 표시 설정을 확인하세요.

**그리기 가이드를 삭제하면 그리드 간격이 바뀌나요?**  
아니요. 그리기 가이드와 그리드 간격은 별개의 설정이며, 가이드를 삭제해도 저장된 그리드 간격은 그대로 유지됩니다.

**프레젠테이션의 섹션별로 다른 뷰 설정을 지정할 수 있나요?**  
[View settings](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_viewproperties/)은 프레젠테이션 수준([Normal View](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/get_slideviewproperties/))에서 정의되며 섹션별로는 아닙니다. 따라서 문서가 열릴 때 전체 문서에 하나의 파라미터 집합이 적용됩니다.

**다른 사용자에게 서로 다른 뷰 상태를 미리 정의할 수 있나요?**  
아니요. 설정은 파일에 저장되고 공유됩니다. 뷰어 애플리케이션이 사용자 환경 설정을 반영할 수는 있지만, 파일 자체에는 하나의 뷰 속성 집합만 포함됩니다.

**새 프레젠테이션이 동일한 방식으로 열리도록 미리 정의된 View Properties를 템플릿에 포함할 수 있나요?**  
예, [view properties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_viewproperties/)가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 새 문서를 만들 때 동일한 초기 뷰 구성을 사용할 수 있습니다.