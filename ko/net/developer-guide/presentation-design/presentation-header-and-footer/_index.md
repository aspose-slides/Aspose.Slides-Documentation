---
title: .NET에서 프레젠테이션 머리글 및 바닥글 관리
linktitle: 머리글 및 바닥글
type: docs
weight: 140
url: /ko/net/presentation-header-and-footer/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 슬라이드, 노트 페이지 및 유인물의 바닥글, 날짜/시간, 슬라이드 번호 및 머리글 자리표시자를 관리하는 방법을 배웁니다."
---
## **개요**

PowerPoint는 페이지 유형에 따라 다른 머리글 및 바닥글 자리표시자를 사용합니다. Aspose.Slides for .NET은 이러한 자리표시자의 텍스트와 가시성을 머리글/바닥글 관리자 인터페이스를 통해 제어할 수 있습니다.

사용 가능한 자리표시자는 범위에 따라 달라집니다:

| 범위 | 머리글 | 바닥글 | 날짜/시간 | 슬라이드/페이지 번호 |
|---|---|---|---|---|
| 일반 슬라이드 | 없음 | 있음 | 있음 | 있음 |
| 노트 마스터 | 있음 | 있음 | 있음 | 있음 |
| 노트 슬라이드 | 있음 | 있음 | 있음 | 있음 |
| 유인물 마스터 | 있음 | 있음 | 있음 | 있음 |

일반 프레젠테이션 슬라이드에는 머리글 자리표시자가 없습니다. 머리글은 노트 페이지와 유인물에서 사용할 수 있습니다. 일반 슬라이드에서는 바닥글, 날짜/시간 및 슬라이드 번호 자리표시자를 대신 사용하십시오.

변경의 범위는 사용하는 관리자에 따라 다릅니다. [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/net/aspose.slides/islideheaderfootermanager/) 인터페이스는 하나의 일반 슬라이드를 제어합니다. [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/net/aspose.slides/inotesslideheaderfootermanager/) 인터페이스는 하나의 노트 슬라이드를 제어합니다. 마스터 및 레이아웃 관리자는 종속 슬라이드에 설정을 전파할 수 있으며, [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterhandoutslideheaderfootermanager/) 인터페이스는 유인물 마스터를 제어합니다.

## **일반 슬라이드에 바닥글, 날짜/시간 및 슬라이드 번호 설정**

일반 슬라이드의 기본 워크플로는 각 슬라이드의 머리글/바닥글 관리자에 접근하여 바닥글 및 날짜/시간 텍스트를 설정하고 필요한 자리표시자를 활성화한 다음 프레젠테이션을 저장하는 것입니다. 슬라이드 번호는 프레젠테이션에 의해 자동으로 생성되므로 가시성만 제어하면 됩니다.

텍스트를 설정하려면 [`SetFooterText`](https://reference.aspose.com/slides/ko/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) 및 [`SetDateTimeText`](https://reference.aspose.com/slides/ko/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/)를 사용하고, 해당 자리표시자를 표시하려면 [`SetFooterVisibility`](https://reference.aspose.com/slides/ko/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/ko/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) 및 [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/ko/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/)를 사용하십시오.

다음은 모든 일반 슬라이드에 동일한 바닥글, 날짜/시간 텍스트 및 슬라이드 번호 가시성을 적용하는 전체 예제입니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

하나의 슬라이드만 업데이트해야 하는 경우 전체 컬렉션을 반복하지 말고 [`Slides`](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/slides/ko/) 컬렉션을 통해 해당 슬라이드에 직접 접근하십시오.

## **노트 마스터에 머리글 및 바닥글 설정**

노트 마스터는 노트 페이지에 대한 공통 서식 및 자리표시자 동작을 정의합니다. 노트 마스터 자체만 변경하려면 [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/net/aspose.slides/imasternotesslideheaderfootermanager/) 인터페이스를 사용하십시오.

다음 예제는 노트 마스터에 머리글, 바닥글 및 날짜/시간 텍스트를 설정하고 해당 마스터에서 지원되는 모든 자리표시자를 표시합니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

프레젠테이션에 노트 마스터가 포함되지 않은 경우 [`MasterNotesSlide`](https://reference.aspose.com/slides/ko/net/aspose.slides/imasternotesslidemanager/masternotesslide/) 속성은 `null`을 반환합니다.

## **노트 마스터 설정을 하위 노트 슬라이드에 적용**

노트 마스터는 자체 및 모든 종속 노트 슬라이드에 머리글 및 바닥글 설정을 적용할 수 있습니다. 동일한 설정을 노트 계층 전체에 적용해야 할 때는 [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/net/aspose.slides/imasternotesslideheaderfootermanager/)의 전용 전파 메서드를 사용하십시오.

예를 들어 [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/ko/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) 및 [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/ko/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/)는 노트 마스터 머리글과 모든 하위 머리글을 업데이트합니다. 바닥글, 날짜/시간 및 슬라이드 번호에 대해서도 동일한 메서드가 제공됩니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

위에서 사용된 전파 메서드는 [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/ko/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/ko/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/ko/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/ko/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/), 및 [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/ko/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/)입니다.

## **개별 노트 슬라이드에 머리글 및 바닥글 설정**

노트 슬라이드는 특정 일반 슬라이드에 속합니다. 해당 노트 페이지만 사용자 지정하려면 [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/net/aspose.slides/inotesslideheaderfootermanager/) 인터페이스를 사용하십시오.

[`AddNotesSlide`](https://reference.aspose.com/slides/ko/net/aspose.slides/inotesslidemanager/addnotesslide/) 메서드는 현재 슬라이드에 대한 노트 슬라이드를 반환하며, 존재하지 않을 경우 새로 생성합니다. 다음 예제는 첫 번째 프레젠테이션 슬라이드와 연결된 노트 페이지를 구성합니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

먼저 노트 마스터에서 설정을 전파한 다음 개별 노트 슬라이드를 변경하면, 후자의 슬라이드별 설정을 통해 해당 노트 페이지를 독립적으로 사용자 지정할 수 있습니다.

## **유인물 마스터에 머리글 및 바닥글 설정**

유인물 페이지는 머리글, 바닥글, 날짜/시간 및 페이지 번호 자리표시자를 위해 유인물 마스터를 사용합니다. 노트 페이지와 달리 유인물 설정은 개별 유인물 슬라이드가 아니라 유인물 마스터를 통해 관리됩니다.

유인물 마스터에 접근하려면 [`MasterHandoutSlide`](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) 속성을 사용하십시오. 마스터가 없을 경우 [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/)을 호출하여 기본 유인물 마스터를 생성합니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **범위 및 상속 이해**

변경하려는 범위에 맞는 머리글/바닥글 관리자를 선택하십시오:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/net/aspose.slides/islideheaderfootermanager/) 은 하나의 일반 슬라이드에 대한 바닥글, 날짜/시간 및 슬라이드 번호 설정을 변경합니다.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/net/aspose.slides/ilayoutslideheaderfootermanager/) 은 레이아웃 슬라이드를 제어하고 지원되는 설정을 종속 슬라이드에 전파할 수 있습니다.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslideheaderfootermanager/) 은 일반 슬라이드 마스터를 제어하고 지원되는 설정을 종속 슬라이드에 전파합니다.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/net/aspose.slides/imasternotesslideheaderfootermanager/) 은 노트 마스터를 제어하고 모든 종속 노트 슬라이드에 설정을 전파합니다.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/net/aspose.slides/inotesslideheaderfootermanager/) 은 하나의 노트 슬라이드를 변경하며, 바닥글, 날짜/시간 및 슬라이드 번호 외에 머리글 자리표시자를 지원합니다.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterhandoutslideheaderfootermanager/) 은 유인물 마스터를 변경하고 네 가지 자리표시자 유형을 모두 지원합니다.

같은 설정이 계층 전체에 적용되어야 하는 경우 마스터 또는 레이아웃에서 전파하십시오. 개별 페이지에 로컬 설정이 필요한 경우 개별 슬라이드 또는 노트‑슬라이드 관리자를 사용하십시오.

## **FAQ**

**일반 슬라이드에 머리글을 추가할 수 있나요?**

아니요. PowerPoint는 일반 슬라이드에 머리글 자리표시자를 정의하지 않습니다. 일반 슬라이드에서는 바닥글, 날짜/시간 및 슬라이드 번호 자리표시자를 사용하십시오. 머리글 자리표시자는 노트 페이지와 유인물에서 사용할 수 있습니다.

**바닥글, 날짜/시간 또는 슬라이드 번호 자리표시자가 보이지 않으면 어떻게 하나요?**

해당 머리글/바닥글 관리자를 사용하여 가시성을 확인하고 필요에 따라 활성화하십시오. 예를 들어 [`IsFooterVisible`](https://reference.aspose.com/slides/ko/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) 은 바닥글 자리표시자가 존재하는지 여부를 보고하고, [`SetFooterVisibility`](https://reference.aspose.com/slides/ko/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) 은 가시성을 변경합니다.

**슬라이드 번호를 1이 아닌 다른 값부터 시작하려면 어떻게 하나요?**

프레젠테이션의 [`FirstSlideNumber`](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/firstslidenumber/) 속성을 설정하십시오. 그러면 슬라이드 번호 자리표시자는 업데이트된 번호 순서를 사용합니다.

**PDF, 이미지 또는 HTML로 내보낼 때 머리글과 바닥글은 어떻게 되나요?**

보이는 머리글 및 바닥글 요소는 출력 형식의 나머지 프레젠테이션 내용과 함께 렌더링됩니다. 표시 여부는 내보내는 페이지 유형과 해당 자리표시자 가시성 설정에 따라 달라집니다.