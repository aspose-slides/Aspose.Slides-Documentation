---
title: C++에서 프레젠테이션 보기 속성 검색 및 업데이트
linktitle: 보기 속성
type: docs
weight: 80
url: /ko/cpp/presentation-view-properties/
keywords:
  - 보기 속성
  - 일반 보기
  - 개요 내용
  - 개요 아이콘
  - 세로 스플리터 스냅
  - 단일 보기
  - 바 상태
  - 차원 크기
  - 자동 조정
  - 기본 확대/축소
  - PowerPoint
  - OpenDocument
  - 프레젠테이션
  - C++
  - Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 일반 보기 레이아웃, 슬라이드 및 노트 확대/축소, 그리드 간격 및 주석 표시 여부를 구성합니다."
---
## **소개**

PowerPoint의 일반 보기에서는 슬라이드가 섬네일 또는 개요용 사이드 창과 아래쪽 노트 창 사이에 표시됩니다. Aspose.Slides for C++는 프레젠테이션에 저장된 편집 기본 설정을 [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/)을 통해 제공합니다. 여기에는 창 레이아웃, 확대/축소 수준, 그리드 간격 및 주석 표시 여부가 포함됩니다.

## **INormalViewProperties에 대하여**

[get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/)를 사용하여 [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/) 인터페이스에 액세스합니다. [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/)은 개요에서 슬라이드 제목 옆에 아이콘을 표시할지 여부를 제어합니다. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/)은 사용자가 사이드 창을 좁힐 때 해당 창이 최소화 상태로 스냅되도록 합니다. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/)은 전체 창에서 하나의 창만 표시하도록 하는 기본 설정을 나타냅니다.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/)은 사이드 창과 슬라이드 사이의 구분자를 제어합니다. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/)은 노트 창 위의 구분자를 제어합니다. 두 메서드 모두 `Minimized`, `Maximized`, `Restored` 중 하나의 [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) 값을 허용합니다.

## **INormalViewProperties 복원에 대하여**

구분자가 복원될 때, [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/)은 사이드 창의 저장된 크기를 제공하고, [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/)은 상단 슬라이드 영역의 저장된 크기를 제공합니다. 두 메서드는 모두 [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/)를 노출합니다. 해당 인터페이스의 [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) 메서드는 0에서 100 사이의 백분율을 받으며, [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/)은 창 크기가 변경될 때 편집기가 크기를 조정할지 여부를 제어합니다.

이 예제는 기존 프레젠테이션을 업데이트합니다. 가로 구분자를 복원하고, [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/)으로 노출되는 상단 슬라이드 영역의 크기를 자동 조정이 활성화된 상태에서 80%로 설정하며, 세로 구분자를 최대화합니다. 또한 개요 보기를 위해 [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/)을 사용하여 개요 아이콘을 활성화합니다.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **기본 확대/축소 값 설정**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/)와 [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/)는 편집기용 독립적인 확대/축소 설정을 저장합니다. 이러한 설정은 슬라이드 크기, 슬라이드 쇼 재생 또는 이미지 내보내기 해상도에 영향을 주지 않습니다.

이 예제는 기존 프레젠테이션을 열고 [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/)을 사용하여 슬라이드가 편집 창에 맞도록 자동 스케일링을 활성화합니다. 노트 페이지의 경우 자동 스케일링을 비활성화하고 [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/)을 사용하여 고정 80% 확대/축소를 설정합니다.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **그리드 간격 설정**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/)은 프레젠테이션 전체의 편집 그리드 라인 간 거리를 설정합니다. 1인치당 72포인트인 양의 포인트 값을 사용합니다. 이 예제는 기존 프레젠테이션에서 현재 간격을 출력하고, 간격을 18포인트(¼인치)로 설정하여 그리드를 저장합니다.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

그리드는 고정된 간격으로 반복됩니다. [Drawing guides](/slides/ko/cpp/drawing-guides/)는 개별 수평 또는 수직 위치를 표시합니다. 두 기능 모두 편집 보조 도구이며 이를 표시하는 편집기에서만 나타납니다. 슬라이드 쇼 및 PDF, 이미지, SVG와 같은 내보내기에서는 포함되지 않습니다.

## **프레젠테이션 열 때 주석 보이기/숨기기**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/)은 호환되는 편집기에서 프레젠테이션을 열 때 사용할 기본 설정을 저장합니다. 주석이 포함된 기존 프레젠테이션에 대해 이 예제는 현재 설정을 출력하고 주석이 숨겨진 사본을 저장합니다. 또한 [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/)을 [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/)와 함께 호출하여 사본이 슬라이드 보기로 열리도록 합니다.

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

주석을 숨겨도 텍스트, 작성자, 위치, 답글 및 상태는 유지됩니다. 주석 자체를 변경하려면 [Presentation Comments](/slides/ko/cpp/presentation-comments/)를 참조하십시오. 내보내기 설정은 PDF, HTML, 이미지, 노트 또는 유인물에 주석이 표시될지를 제어합니다.

## **FAQ**

**프레젠테이션을 다시 열었을 때 그리드가 숨겨지는 이유는 무엇입니까?**  
프레젠테이션은 그리드 간격을 저장합니다. 그리드를 보려면 편집기에서 그리드 표시를 활성화하십시오.

**그리드 간격을 변경하지 않고 그리기 가이드를 지우면 어떻습니까?**  
아니요. 가이드를 추가, 이동 또는 삭제해도 그리드 간격은 변경되지 않습니다.

**프레젠테이션의 서로 다른 섹션이 서로 다른 보기 설정을 가질 수 있나요?**  
아니요. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/)는 전체 프레젠테이션에 적용됩니다.

**다른 사용자마다 서로 다른 보기 설정을 저장할 수 있나요?**  
파일은 모든 사용자를 위한 하나의 보기 속성 집합만 저장합니다. 편집기에서는 사용자의 로컬 기본 설정을 적용할 수도 있습니다.

**템플릿에 보기 설정을 저장할 수 있나요?**  
예. 템플릿에서 만든 프레젠테이션은 템플릿에 저장된 보기 설정을 상속합니다.