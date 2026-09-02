---
title: C++에서 프레젠테이션 머리글 및 바닥글 관리
linktitle: 머리글 및 바닥글
type: docs
weight: 140
url: /ko/cpp/presentation-header-and-footer/
keywords:
- 머리글
- 머리글 텍스트
- 바닥글
- 바닥글 텍스트
- 머리글 설정
- 바닥글 설정
- 유인물
- 노트
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 슬라이드, 노트 페이지 및 유인물에서 바닥글, 날짜/시간, 슬라이드 번호 및 머리글 자리표시자를 관리하는 방법을 배웁니다."
---
## **개요**

PowerPoint는 페이지 유형에 따라 서로 다른 머리글 및 바닥글 자리표시자를 사용합니다. Aspose.Slides for C++는 이러한 자리표시자의 텍스트와 가시성을 머리글/바닥글 관리자 인터페이스를 통해 제어할 수 있습니다.

사용 가능한 자리표시자는 범위에 따라 달라집니다:

| 범위 | 머리글 | 바닥글 | 날짜/시간 | 슬라이드/페이지 번호 |
|---|---|---|---|---|
| 일반 슬라이드 | 아니오 | 예 | 예 | 예 |
| 노트 마스터 | 예 | 예 | 예 | 예 |
| 노트 슬라이드 | 예 | 예 | 예 | 예 |
| 유인물 마스터 | 예 | 예 | 예 | 예 |

일반 프레젠테이션 슬라이드에는 머리글 자리표시자가 없습니다. 머리글은 노트 페이지와 유인물에 제공됩니다. 일반 슬라이드에서는 대신 바닥글, 날짜/시간 및 슬라이드 번호 자리표시자를 사용하십시오.

변경 범위는 사용 중인 관리자에 따라 달라집니다. [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideheaderfootermanager/) 인터페이스는 하나의 일반 슬라이드를 제어합니다. [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/inotesslideheaderfootermanager/) 인터페이스는 하나의 노트 슬라이드를 제어합니다. 마스터 및 레이아웃 관리자는 종속 슬라이드에 설정을 전파할 수 있으며, [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/) 인터페이스는 유인물 마스터를 제어합니다.

## **일반 슬라이드에 바닥글, 날짜/시간 및 슬라이드 번호 설정**

일반 슬라이드의 경우 기본 작업 흐름은 각 슬라이드의 머리글/바닥글 관리자에 접근하여 바닥글 및 날짜/시간 텍스트를 설정하고 필요한 자리표시자를 활성화한 다음 프레젠테이션을 저장하는 것입니다. 슬라이드 번호는 프레젠테이션에서 자동으로 생성되므로 가시성만 제어하면 됩니다.

텍스트를 설정하려면 [`SetFooterText`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootertext/) 및 [`SetDateTimeText`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimetext/)를 사용하고, 해당 자리표시자를 표시하려면 [`SetFooterVisibility`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslideheaderfootermanager/setdatetimevisibility/) 및 [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslideheaderfootermanager/setslidenumbervisibility/)를 사용하십시오.

다음 전체 예제는 모든 일반 슬라이드에 동일한 바닥글, 날짜/시간 텍스트 및 슬라이드 번호 가시성을 적용합니다:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

for (const auto& slide : System::IterateOver(presentation->get_Slides()))
{
    auto headerFooterManager = slide->get_HeaderFooterManager();

    headerFooterManager->SetFooterText(u"Company Confidential");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_slide_footers.pptx", SaveFormat::Pptx);
```

하나의 슬라이드만 업데이트해야 하는 경우 전체 슬라이드 컬렉션을 반복하는 대신 [`Presentation::get_Slide`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_slide/)을 통해 해당 슬라이드에 직접 접근하십시오.

## **노트 마스터에 머리글 및 바닥글 설정**

노트 마스터는 노트 페이지에 대한 공통 서식 및 자리표시자 동작을 정의합니다. 노트 마스터 자체만 변경하려면 [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasternotesslideheaderfootermanager/) 인터페이스를 사용하십시오.

다음 예제는 노트 마스터에 머리글, 바닥글 및 날짜/시간 텍스트를 설정하고 해당 마스터에서 지원되는 모든 자리표시자를 표시합니다:

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Notes header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Notes footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_notes_master_footers.pptx", SaveFormat::Pptx);
```

[`IMasterNotesSlideManager::get_MasterNotesSlide`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasternotesslidemanager/get_masternotesslide/) 메서드는 프레젠테이션에 노트 마스터가 포함되어 있지 않을 경우 `nullptr`을 반환합니다.

## **노트 마스터 설정을 자식 노트 슬라이드에 적용**

노트 마스터는 머리글 및 바닥글 설정을 자신과 모든 종속 노트 슬라이드에 적용할 수 있습니다. 동일한 설정을 노트 계층 전체에 적용해야 하는 경우 [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasternotesslideheaderfootermanager/)의 전용 전파 메서드를 사용하십시오.

예를 들어, [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheaderstext/) 및 [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasternotesslideheaderfootermanager/setheaderandchildheadersvisibility/)은 노트 마스터 머리글과 모든 자식 머리글을 업데이트합니다. 바닥글, 날짜/시간 및 슬라이드 번호에 대한 동등한 메서드도 제공됩니다.

```cpp
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideHeaderFooterManager.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();

if (masterNotesSlide != nullptr)
{
    auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderAndChildHeadersText(u"Notes header");
    headerFooterManager->SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager->SetFooterAndChildFootersText(u"Notes footer");
    headerFooterManager->SetFooterAndChildFootersVisibility(true);

    headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
    headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation->Save(u"presentation_with_child_notes_footers.pptx", SaveFormat::Pptx);
```

위에서 사용된 전파 메서드는 [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) 및 [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/) 입니다.

## **개별 노트 슬라이드에 머리글 및 바닥글 설정**

노트 슬라이드는 특정 일반 슬라이드에 속합니다. 해당 노트 페이지만 맞춤화하려면 그 슬라이드의 [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/inotesslideheaderfootermanager/) 인터페이스를 사용하십시오.

[`INotesSlideManager::AddNotesSlide`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/inotesslidemanager/addnotesslide/) 메서드는 현재 슬라이드에 대한 노트 슬라이드를 반환하며, 존재하지 않을 경우 새로 생성합니다. 다음 예제는 첫 번째 프레젠테이션 슬라이드와 연결된 노트 페이지를 구성합니다:

```cpp
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideHeaderFooterManager.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
auto headerFooterManager = notesSlide->get_HeaderFooterManager();

headerFooterManager->SetHeaderText(u"Header for the first notes page");
headerFooterManager->SetHeaderVisibility(true);

headerFooterManager->SetFooterText(u"Footer for the first notes page");
headerFooterManager->SetFooterVisibility(true);

headerFooterManager->SetDateTimeText(u"Date and time text");
headerFooterManager->SetDateTimeVisibility(true);

headerFooterManager->SetSlideNumberVisibility(true);

presentation->Save(u"presentation_with_custom_notes_footers.pptx", SaveFormat::Pptx);
```

먼저 노트 마스터에서 설정을 전파한 후 개별 노트 슬라이드를 변경하면, 이후 슬라이드별 설정을 통해 해당 노트 페이지를 독립적으로 맞춤화할 수 있습니다.

## **유인물 마스터에 머리글 및 바닥글 설정**

유인물 페이지는 머리글, 바닥글, 날짜/시간 및 페이지 번호 자리표시자를 위해 유인물 마스터를 사용합니다. 노트 페이지와 달리 유인물 설정은 개별 유인물 슬라이드가 아니라 유인물 마스터를 통해 관리됩니다.

[`IMasterHandoutSlideManager::get_MasterHandoutSlide`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterhandoutslidemanager/get_masterhandoutslide/)를 사용해 유인물 마스터에 접근하십시오. 마스터가 없을 경우, [`IMasterHandoutSlideManager::SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/)을 호출하여 기본 유인물 마스터를 생성하십시오.

```cpp
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideHeaderFooterManager.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto masterHandoutSlideManager = presentation->get_MasterHandoutSlideManager();
auto masterHandoutSlide = masterHandoutSlideManager->get_MasterHandoutSlide();

if (masterHandoutSlide == nullptr)
{
    masterHandoutSlide = masterHandoutSlideManager->SetDefaultMasterHandoutSlide();
}

if (masterHandoutSlide != nullptr)
{
    auto headerFooterManager = masterHandoutSlide->get_HeaderFooterManager();

    headerFooterManager->SetHeaderText(u"Handout header");
    headerFooterManager->SetHeaderVisibility(true);

    headerFooterManager->SetFooterText(u"Handout footer");
    headerFooterManager->SetFooterVisibility(true);

    headerFooterManager->SetDateTimeText(u"Date and time text");
    headerFooterManager->SetDateTimeVisibility(true);

    headerFooterManager->SetSlideNumberVisibility(true);
}

presentation->Save(u"presentation_with_handout_footers.pptx", SaveFormat::Pptx);
```

## **범위 및 상속 이해**

변경하려는 범위에 맞는 머리글/바닥글 관리자를 선택하십시오:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/islideheaderfootermanager/)는 하나의 일반 슬라이드에 대해 바닥글, 날짜/시간 및 슬라이드 번호 설정을 변경합니다.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ilayoutslideheaderfootermanager/)는 레이아웃 슬라이드를 제어하고 지원되는 설정을 종속 슬라이드에 전파할 수 있습니다.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterslideheaderfootermanager/)는 일반 슬라이드 마스터를 제어하며, 지원되는 설정을 종속 슬라이드에 전파할 수 있습니다.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasternotesslideheaderfootermanager/)는 노트 마스터를 제어하고 모든 종속 노트 슬라이드에 설정을 전파할 수 있습니다.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/inotesslideheaderfootermanager/)는 하나의 노트 슬라이드를 변경하며, 바닥글, 날짜/시간 및 슬라이드 번호 외에 머리글 자리표시자를 지원합니다.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/imasterhandoutslideheaderfootermanager/)는 유인물 마스터를 변경하며 네 가지 자리표시자 유형을 모두 지원합니다.

동일한 설정을 계층 전체에 적용해야 할 경우 마스터 또는 레이아웃에서 전파를 사용하십시오. 하나의 페이지에 대해 로컬 설정이 필요할 경우 개별 슬라이드 또는 노트 슬라이드 관리자를 사용하십시오.

## **FAQ**

**일반 슬라이드에 머리글을 추가할 수 있나요?**

아니오. PowerPoint는 일반 슬라이드에 머리글 자리표시자를 정의하지 않습니다. 일반 슬라이드에서는 바닥글, 날짜/시간 및 슬라이드 번호 자리표시자를 사용하십시오. 머리글 자리표시자는 노트 페이지와 유인물에 제공됩니다.

**바닥글, 날짜/시간 또는 슬라이드 번호 자리표시자가 보이지 않을 경우 어떻게 해야 하나요?**

해당 머리글/바닥글 관리자를 사용하여 가시성을 확인하고 필요 시 활성화하십시오. 예를 들어, [`get_IsFooterVisible`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslideheaderfootermanager/get_isfootervisible/)는 바닥글 자리표시자가 존재하는지 여부를 보고하고, [`SetFooterVisibility`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/ibaseslideheaderfootermanager/setfootervisibility/)는 그 가시성을 변경합니다.

**슬라이드 번호를 1이 아닌 값부터 시작하려면 어떻게 합니까?**

[`Presentation::set_FirstSlideNumber`](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/set_firstslidenumber/)를 사용하여 첫 슬라이드 번호를 설정하십시오. 그러면 슬라이드 번호 자리표시자는 업데이트된 번호 순서를 사용합니다.

**PDF, 이미지 또는 HTML로 내보낼 때 머리글과 바닥글은 어떻게 되나요?**

보이는 머리글 및 바닥글 요소는 출력 형식에서 프레젠테이션 내용과 함께 렌더링됩니다. 이들의 모양은 내보내는 페이지 유형 및 해당 자리표시자의 가시성 설정에 따라 달라집니다.