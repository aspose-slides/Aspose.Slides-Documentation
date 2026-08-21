---
title: C++ 프레젠테이션에서 그리기 가이드 관리
linktitle: 그리기 가이드
type: docs
weight: 85
url: /ko/cpp/drawing-guides/
keywords:
- 그리기 가이드
- 수평 가이드
- 수직 가이드
- 정렬 가이드
- 슬라이드 보기
- 마스터 슬라이드
- 레이아웃 슬라이드
- 노트 마스터
- 핸드아웃 마스터
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션에서 수평 및 수직 그리기 가이드를 추가하고, 접근하며, 삭제합니다."
---
## **개요**

그리기 가이드는 PowerPoint에서 프레젠테이션을 편집하는 동안 사용자가 형태를 일관되게 정렬하도록 돕는 조절 가능한 수평 및 수직선입니다. 이러한 가이드는 애플리케이션이 프레젠테이션을 생성하고 이후 수동으로 다듬을 때 특히 유용합니다. 애플리케이션은 작성자가 콘텐츠를 추가하거나 이동할 때 따라야 할 동일한 정렬 보조 도구를 저장할 수 있습니다.

그리기 가이드는 슬라이드 콘텐츠가 아니라 편집 보조 도구입니다. 슬라이드 쇼나 렌더링된 출력에 표시되지 않습니다. Aspose.Slides for C++는 이를 [IDrawingGuidesCollection](https://reference.aspose.com/slides/ko/cpp/aspose.slides/idrawingguidescollection/) 인터페이스를 통해 노출합니다. 가이드는 [IDrawingGuide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/idrawingguide/)로 표현되며 방향, 위치 및 색상을 가집니다.

위치는 해당 슬라이드 또는 마스터의 왼쪽 위 모서리에서부터 포인트 단위로 측정됩니다. 수직 가이드는 가로 좌표를 사용하며 보통 0부터 슬라이드 너비까지의 값을 가집니다. 수평 가이드는 세로 좌표를 사용하며 보통 0부터 슬라이드 높이까지의 값을 가집니다.

## **슬라이드 보기에서 가이드 추가**

[ICommonSlideViewProperties::get_DrawingGuides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/icommonslideviewproperties/get_drawingguides/)를 사용하여 일반 슬라이드를 편집하는 동안 표시되는 가이드를 관리합니다. [IDrawingGuidesCollection::Add](https://reference.aspose.com/slides/ko/cpp/aspose.slides/idrawingguidescollection/add/)를 호출하고 [Orientation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/orientation/) 값과 포인트 단위 위치를 지정합니다.

다음 예제는 슬라이드 중앙 오른쪽에 수직 가이드 하나와 그 아래에 수평 가이드 하나를 추가합니다:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/IViewProperties.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

guides->Add(Orientation::Vertical, slideSize.get_Width() / 2 + 12.5f);
guides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 12.5f);

presentation->Save(u"drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **그리기 가이드 액세스**

[IDrawingGuidesCollection::get_Count](https://reference.aspose.com/slides/ko/cpp/aspose.slides/idrawingguidescollection/get_count/) 메서드와 [IDrawingGuidesCollection::idx_get](https://reference.aspose.com/slides/ko/cpp/aspose.slides/idrawingguidescollection/idx_get/) 메서드는 기존 가이드에 대한 액세스를 제공합니다. [IDrawingGuide::get_Orientation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/idrawingguide/get_orientation/), [IDrawingGuide::get_Position](https://reference.aspose.com/slides/ko/cpp/aspose.slides/idrawingguide/get_position/), [IDrawingGuide::get_Color](https://reference.aspose.com/slides/ko/cpp/aspose.slides/idrawingguide/get_color/) 메서드는 가이드의 현재 속성을 반환합니다. 해당 setter 메서드를 사용하면 이러한 속성을 변경할 수 있습니다.

다음 예제는 위에서 만든 프레젠테이션의 슬라이드 보기 가이드를 읽습니다:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuide.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"drawing-guides.pptx");
auto guides = presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides();

for (int32_t index = 0; index < guides->get_Count(); index++)
{
    auto guide = guides->idx_get(index);
    System::Console::WriteLine(
        System::String::Format(
            u"Guide {0}: orientation = {1}, position = {2}, color = {3}",
            index,
            guide->get_Orientation(),
            guide->get_Position(),
            guide->get_Color()));
}

presentation->Dispose();
```

## **마스터 및 레이아웃 슬라이드에 가이드 추가**

슬라이드 마스터와 각 레이아웃 슬라이드마다 별도의 그리기 가이드 컬렉션을 가질 수 있습니다. 마스터 슬라이드에는 [IMasterSlide::get_DrawingGuides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslide/get_drawingguides/), 레이아웃 슬라이드에는 [ILayoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslide/get_drawingguides/)를 사용합니다.

다음 예제는 첫 번째 마스터 슬라이드에 수직 가이드를, 첫 번째 레이아웃 슬라이드에 수평 가이드를 추가합니다:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto masterGuides = presentation->get_Master(0)->get_DrawingGuides();
auto layoutGuides = presentation->get_LayoutSlide(0)->get_DrawingGuides();

masterGuides->Add(Orientation::Vertical, slideSize.get_Width() / 2 - 20.0f);
layoutGuides->Add(Orientation::Horizontal, slideSize.get_Height() / 2 + 20.0f);

presentation->Save(u"master-layout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **노트 및 핸드아웃 마스터에 가이드 추가**

노트 마스터와 핸드아웃 마스터도 그리기 가이드를 지원합니다. 해당 컬렉션에 접근하려면 [IMasterNotesSlide::get_DrawingGuides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasternotesslide/get_drawingguides/)와 [IMasterHandoutSlide::get_DrawingGuides](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterhandoutslide/get_drawingguides/)를 사용합니다. 프레젠테이션에 이러한 마스터 중 하나가 없으면 [IMasterNotesSlideManager::SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) 또는 [IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/)가 기본 마스터를 생성하고 반환합니다.

다음 예제는 노트 마스터에 수평 가이드를, 핸드아웃 마스터에 수직 가이드를 추가합니다:

```cpp
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/INotesSize.h>
#include <DOM/Orientation.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto notesSize = presentation->get_NotesSize()->get_Size();
auto notesMaster = presentation->get_MasterNotesSlideManager()->SetDefaultMasterNotesSlide();
auto handoutMaster = presentation->get_MasterHandoutSlideManager()->SetDefaultMasterHandoutSlide();

notesMaster->get_DrawingGuides()->Add(Orientation::Horizontal, notesSize.get_Height() / 2 + 50.0f);
handoutMaster->get_DrawingGuides()->Add(Orientation::Vertical, notesSize.get_Width() / 2 - 50.0f);

presentation->Save(u"notes-handout-drawing-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **그리기 가이드 지우기**

[IDrawingGuidesCollection::Clear](https://reference.aspose.com/slides/ko/cpp/aspose.slides/idrawingguidescollection/clear/)를 호출하면 특정 컬렉션의 모든 가이드를 제거합니다. 하나의 컬렉션을 지워도 다른 범위에 저장된 가이드에는 영향을 주지 않습니다.

다음 예제는 누락된 마스터를 생성하지 않고 슬라이드 보기 가이드와 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터, 핸드아웃 마스터의 모든 가이드를 지웁니다:

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IDrawingGuidesCollection.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation-with-guides.pptx");

presentation->get_ViewProperties()->get_SlideViewProperties()->get_DrawingGuides()->Clear();

for (auto&& masterSlide : presentation->get_Masters())
{
    masterSlide->get_DrawingGuides()->Clear();
}

for (auto&& layoutSlide : presentation->get_LayoutSlides())
{
    layoutSlide->get_DrawingGuides()->Clear();
}

auto notesMaster = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (notesMaster != nullptr)
{
    notesMaster->get_DrawingGuides()->Clear();
}

auto handoutMaster = presentation->get_MasterHandoutSlideManager()->get_MasterHandoutSlide();
if (handoutMaster != nullptr)
{
    handoutMaster->get_DrawingGuides()->Clear();
}

presentation->Save(u"presentation-without-guides.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**그리기 가이드는 슬라이드 쇼나 내보낸 이미지에 나타나요?**

아니오. 그리기 가이드는 편집을 위한 정렬 보조 도구이며 프레젠테이션 콘텐츠로 렌더링되지 않습니다.

**그리기 가이드를 개별 일반 슬라이드에 직접 추가할 수 있나요?**

일반 슬라이드의 편집 가이드는 프레젠테이션의 슬라이드 보기 속성에 저장됩니다. 슬라이드 마스터, 레이아웃 슬라이드, 노트 마스터 및 핸드아웃 마스터용 별도의 가이드 컬렉션이 제공됩니다.

**가이드 위치에 사용되는 단위는 무엇인가요?**

위치는 포인트 단위로 지정되며, 72포인트가 1인치에 해당합니다. 수직 위치는 왼쪽 가장자리에서 측정되고, 수평 위치는 위쪽 가장자리에서 측정됩니다.

**그리기 가이드를 지우면 도형이 삭제되거나 슬라이드 콘텐츠가 변경되나요?**

아니오. `Clear` 메서드는 선택된 컬렉션의 가이드만 제거합니다. 도형 및 기타 슬라이드 콘텐츠는 그대로 유지됩니다.