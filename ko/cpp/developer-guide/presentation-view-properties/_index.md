---
title: C++에서 프레젠테이션 보기 속성 가져오기 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/cpp/presentation-view-properties/
keywords:
- 보기 속성
- 보통 보기
- 개요 콘텐츠
- 개요 아이콘
- 수직 분할 막대 스냅
- 단일 보기
- 막대 상태
- 차원 크기
- 자동 조정
- 기본 확대/축소
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++의 보기 속성을 활용하여 PPT, PPTX 및 ODP 슬라이드 형식을 사용자 지정하고, 레이아웃, 확대/축소 수준 및 표시 설정을 조정하세요."
---
## **소개**

보통 보기에는 슬라이드 자체, 측면 콘텐츠 영역, 하단 콘텐츠 영역의 세 가지 콘텐츠 영역이 포함됩니다. 다양한 콘텐츠 영역의 위치와 관련된 속성입니다. 이 정보는 애플리케이션이 보기 상태를 파일에 저장하도록 하여, 다시 열었을 때 프레젠테이션이 마지막으로 저장된 시점과 동일한 상태로 보이게 합니다.

프레젠테이션의 보통 보기 속성에 접근하기 위해 [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) 메서드가 추가되었습니다.

[INormalViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/inormalviewrestoredproperties/) 인터페이스와 그 파생형, [SplitterBarStateType](https://reference.aspose.com/slides/ko/cpp/aspose.slides/splitterbarstatetype/) 열거형이 추가되었습니다.

## **INormalViewProperties에 대하여**

보통 보기 속성을 나타냅니다.

속성 **ShowOutlineIcons**는 보통 보기 모드의 어떤 콘텐츠 영역에서 개요 콘텐츠를 표시할 때 아이콘을 표시할지 여부를 지정합니다.

속성 **SnapVerticalSplitter**는 측면 영역이 충분히 작을 때 수직 분할 막대가 최소화된 상태에 맞춰 움직여야 하는지 여부를 지정합니다.

속성 **PreferSingleView**는 사용자가 세 개의 콘텐츠 영역이 있는 표준 보통 보기 대신 전체 창을 차지하는 단일 콘텐츠 영역을 선호하는지 여부를 지정합니다. 활성화된 경우, 애플리케이션은 하나의 콘텐츠 영역을 전체 창에 표시하도록 선택할 수 있습니다.

속성 **VerticalBarState** 및 **HorizontalBarState**는 수평 혹은 수직 분할 막대가 표시될 상태를 지정합니다. 수평 분할 막대는 슬라이드와 슬라이드 아래의 콘텐츠 영역을 구분하고, 수직 분할 막대는 슬라이드와 측면 콘텐츠 영역을 구분합니다. 가능한 값은 **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** 및 **SplitterBarStateType.Restored** 입니다.

속성 **RestoredLeft**와 **RestoredTop**은 **VerticalBarState**와 **HorizontalBarState**에 **SplitterBarStateType.Restored** 값이 적용될 때 보통 보기의 상단 또는 측면 슬라이드 영역의 크기를 지정합니다.

## **INormalViewProperties 복원에 대하여**

보통 보기에서 영역이 가변적인 복원 크기(최소화도 최대화도 아닌)인 경우, 슬라이드 영역의 크기( RestoredTop의 자식이면 너비, RestoredLeft의 자식이면 높이)를 지정합니다.

속성 **DimensionSize**는 슬라이드 영역의 크기( restoredTop의 자식이면 너비, restoredLeft의 자식이면 높이)를 지정합니다.

속성 **AutoAdjust**는 애플리케이션 내에서 보기를 포함하는 창의 크기를 조정할 때 측면 콘텐츠 영역의 크기가 새로운 크기에 보정되어야 하는지 여부를 지정합니다.

아래 예제는 프레젠테이션에 대해 **ViewProperties.NormalViewProperties** 속성에 접근하는 방법을 보여줍니다.

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

// 프레젠테이션의 보기 속성을 복원합니다
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **기본 확대/축소 값 설정**

Aspose.Slides for C++는 이제 프레젠테이션을 열 때 확대/축소 비율이 이미 설정된 상태가 되도록 기본 확대/축소 값을 지정할 수 있습니다. 이는 프레젠테이션의 [ViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/)를 설정함으로써 수행할 수 있습니다. 슬라이드 보기 속성뿐만 아니라 [get_NotesViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/get_notesviewproperties/)도 프로그래밍 방식으로 설정할 수 있습니다. 이 항목에서는 예제를 통해 Aspose.Slides에서 프레젠테이션의 보기 속성을 설정하는 방법을 살펴봅니다.

보기 속성을 설정하려면 아래 단계를 따르세요:

1. 프레젠테이션 클래스의 인스턴스를 생성합니다.
1. 프레젠테이션의 보기 [Properties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/)를 설정합니다.
1. 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 슬라이드 보기와 노트 보기 모두에 대한 확대/축소 값을 설정했습니다.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// 프레젠테이션의 보기 속성을 설정
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // 슬라이드 보기용 백분율 줌 값
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // 노트 보기용 백분율 줌 값

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **그리드 간격 설정**

[Presentation::get_ViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_viewproperties/)를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iviewproperties/get_gridspacing/) 및 [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iviewproperties/set_gridspacing/) 메서드는 기본 편집 그리드의 간격을 읽거나 변경합니다. 이 설정은 개별 슬라이드가 아니라 전체 프레젠테이션에 적용됩니다. 그리드 간격은 포인트 단위이며, 72포인트가 1인치에 해당합니다. API 문서에서 요구하는 대로 양수 값을 사용하십시오.

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

그리드는 [drawing guides](/slides/ko/cpp/drawing-guides/)와 다릅니다. 그리드 간격은 일정한 간격을 제어하는 반면, 그리기 가이드는 개별적으로 위치가 지정된 수평 또는 수직 정렬선입니다. 그리기 가이드를 추가, 이동 또는 제거해도 그리드 간격은 변경되지 않습니다.

그리드와 그리기 가이드는 모두 편집 보조 도구이며, PDF, 이미지, SVG 또는 슬라이드 쇼에서 슬라이드 콘텐츠로 렌더링되지 않습니다. 그리드 간격을 저장한다고 해서 편집기가 그리드를 표시한다는 보장은 없으며, 표시 여부는 뷰어나 편집기의 설정에 따라 달라집니다.

## **프레젠테이션 열 때 주석 표시 또는 숨기기**

[Presentation::get_ViewProperties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_viewproperties/)를 사용하여 프레젠테이션 전체의 보기 설정에 접근합니다. [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iviewproperties/get_showcomments/) 및 [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iviewproperties/set_showcomments/)를 사용하여 PowerPoint 또는 다른 호환 편집기에서 프레젠테이션을 열 때 주석을 표시할지 여부에 대한 기본 설정을 저장합니다.

이 설정은 저장된 보기 기본 설정만 제어합니다. 주석을 추가, 제거, 편집 또는 해결하지는 않습니다. 주석을 숨겨도 내용, 작성자, 위치, 답글 및 상태는 그대로 유지됩니다. 주석 자체를 변경하는 작업은 [Presentation Comments](/slides/ko/cpp/presentation-comments/)를 참고하십시오.

다음 예제는 주석이 포함된 기존 `comments.pptx` 파일이 필요합니다. 현재 주석 표시 설정을 출력하고, 주석을 숨기도록 요청한 뒤 주석을 삭제하지 않은 새로운 PPTX 파일을 저장합니다. 또한 [IViewProperties::set_LastView](https://reference.aspose.com/slides/ko/cpp/aspose.slides/iviewproperties/set_lastview/)와 [ViewType::SlideView](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewtype/)를 사용하여 주석 표시와 함께 초기 편집 보기를 구성합니다.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

이 설정은 주석이 PDF, HTML, 이미지, 노트 또는 유인물 내보내기에 포함되는지를 결정하지 않습니다. 해당 내보내기 옵션을 별도로 구성하십시오.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 보이지 않는 이유는 무엇인가요?**  
파일에 그리드 간격은 저장되지만, 편집기가 그리드를 표시할지는 편집기가 제어합니다. 편집기의 그리드 표시 설정을 확인하십시오.

**그리기 가이드를 삭제하면 그리드 간격이 변경되나요?**  
아니오. 그리기 가이드와 그리드 간격은 별개의 설정이며, 가이드를 삭제해도 저장된 그리드 간격은 변경되지 않습니다.

**프레젠테이션의 섹션마다 다른 보기 설정을 할 수 있나요?**  
[View settings](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_viewproperties/)은 프레젠테이션 수준에서 정의되며([Normal View](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/ko/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), 섹션별로는 정의되지 않으며 프레젠테이션이 열릴 때 전체 문서에 단일 파라미터 세트가 적용됩니다.

**다른 사용자마다 서로 다른 보기 상태를 미리 정의할 수 있나요?**  
아니오. 설정은 파일에 저장되어 공유됩니다. 뷰어 애플리케이션이 사용자별 기본 설정을 반영할 수는 있지만 파일 자체에는 하나의 보기 속성 세트만 포함됩니다.

**새 프레젠테이션이 동일한 방식으로 열리도록 미리 정의된 보기 속성을 포함한 템플릿을 준비할 수 있나요?**  
예. [view properties](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_viewproperties/)가 프레젠테이션 수준에 저장되므로 템플릿에 포함시켜 두고 새 문서를 만들 때 동일한 초기 보기 구성을 적용할 수 있습니다.