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
- 핸드아웃
- 노트
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "전문적인 모습을 위해 PowerPoint 및 OpenDocument 프레젠테이션에 머리글과 바닥글을 추가하고 사용자 지정하려면 C++용 Aspose.Slides를 사용하십시오."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 머리글 및 바닥글 설정을 관리할 수 있습니다. 머리글과 바닥글은 프레젠테이션 마스터 수준에서 처리되며, API는 바닥글 텍스트 설정, 바닥글 표시 여부 변경, 마스터 노트 슬라이드의 머리글 텍스트 업데이트를 위한 메서드를 제공합니다.

핸드아웃 및 노트 슬라이드에 대한 머리글 및 바닥글도 관리할 수 있습니다. 여기에는 노트 마스터, 모든 하위 노트 슬라이드 또는 개별 노트 슬라이드에 대한 머리글, 바닥글, 슬라이드 번호 및 날짜‑시간 자리표시자의 표시 여부와 텍스트를 변경하는 작업이 포함됩니다.

## **머리글 및 바닥글 텍스트 관리**

특정 슬라이드의 노트를 아래 예시와 같이 업데이트할 수 있습니다:

``` cpp
// Header/Footer 텍스트를 설정하는 함수
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// 프레젠테이션 로드
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// 바닥글 설정
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// 헤더에 접근하고 업데이트
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// 프레젠테이션 저장
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **핸드아웃 및 노트 슬라이드에서 머리글 및 바닥글 관리**
Aspose.Slides for C++는 핸드아웃 및 노트 슬라이드에서 머리글 및 바닥글을 지원합니다. 아래 단계를 따르세요:

- 비디오가 포함된 [프레젠테이션](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation)을 로드합니다.
- 노트 마스터 및 모든 노트 슬라이드에 대한 머리글 및 바닥글 설정을 변경합니다.
- 마스터 노트 슬라이드와 모든 자식 바닥글 자리표시자를 표시하도록 설정합니다.
- 마스터 노트 슬라이드와 모든 자식 날짜‑시간 자리표시자를 표시하도록 설정합니다.
- 첫 번째 노트 슬라이드에만 머리글 및 바닥글 설정을 변경합니다.
- 노트 슬라이드 머리글 자리표시자를 표시하도록 설정합니다.
- 노트 슬라이드 머리글 자리표시자에 텍스트를 설정합니다.
- 노트 슬라이드 날짜‑시간 자리표시자에 텍스트를 설정합니다.
- 수정된 프레젠테이션 파일을 씁니다.

예제에 제공된 코드 스니펫:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// 노트 마스터 및 모든 노트 슬라이드에 대한 머리글 및 바닥글 설정을 변경합니다
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// 마스터 노트 슬라이드와 모든 하위 Footer 자리표시자를 표시하도록 설정
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// 마스터 노트 슬라이드와 모든 하위 Header 자리표시자를 표시하도록 설정
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// 마스터 노트 슬라이드와 모든 하위 SlideNumber 자리표시자를 표시하도록 설정
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// 마스터 노트 슬라이드와 모든 하위 Date and time 자리표시자를 표시하도록 설정
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// 마스터 노트 슬라이드와 모든 하위 Header 자리표시자에 텍스트를 설정
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// 마스터 노트 슬라이드와 모든 하위 Footer 자리표시자에 텍스트를 설정
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// 마스터 노트 슬라이드와 모든 하위 Date and time 자리표시자에 텍스트를 설정
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// 첫 번째 노트 슬라이드에만 머리글 및 바닥글 설정을 변경합니다
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// 이 노트 슬라이드의 Header 자리표시자를 표시하도록 설정
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// 이 노트 슬라이드의 Footer 자리표시자를 표시하도록 설정
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// 이 노트 슬라이드의 SlideNumber 자리표시자를 표시하도록 설정
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// 이 노트 슬라이드의 Date-time 자리표시자를 표시하도록 설정
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// 노트 슬라이드 Header 자리표시자에 텍스트를 설정
	headerFooterManager->SetHeaderText(u"New header text");
	// 노트 슬라이드 Footer 자리표시자에 텍스트를 설정
	headerFooterManager->SetFooterText(u"New footer text");
	// 노트 슬라이드 Date-time 자리표시자에 텍스트를 설정
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **FAQ**

**일반 슬라이드에 "머리글"을 추가할 수 있나요?**

PowerPoint에서는 머리글이 노트와 핸드아웃에만 존재합니다. 일반 슬라이드에서는 바닥글, 날짜/시간, 슬라이드 번호만 지원됩니다. Aspose.Slides도 동일한 제한을 따릅니다: 머리글은 노트/핸드아웃에만, 슬라이드에서는 바닥글/날짜‑시간/슬라이드 번호만 지원됩니다.

**레이아웃에 바닥글 영역이 없는데 표시를 "켜"게 할 수 있나요?**

예, 가능합니다. 머리글/바닥글 관리자를 통해 표시 여부를 확인하고 필요하면 활성화할 수 있습니다. 자리표시자가 없거나 숨겨져 있는 경우를 위해 이러한 API 지시자와 메서드가 설계되었습니다.

**슬라이드 번호를 1이 아닌 다른 값부터 시작하려면 어떻게 해야 하나요?**

프레젠테이션의 [첫 슬라이드 번호](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/set_firstslidenumber/)를 설정하면 됩니다. 그 후 모든 번호 매기기가 재계산됩니다. 예를 들어 0이나 10부터 시작하도록 할 수 있으며, 제목 슬라이드에서는 번호를 숨길 수 있습니다.

**PDF/이미지/HTML로 내보낼 때 머리글/바닥글은 어떻게 처리되나요?**

머리글과 바닥글은 프레젠테이션의 일반 텍스트 요소로 렌더링됩니다. 즉, 슬라이드나 노트 페이지에 해당 요소가 표시되어 있으면 출력 형식에서도 다른 콘텐츠와 함께 표시됩니다.