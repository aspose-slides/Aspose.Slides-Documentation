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
- 핸드아웃
- 노트
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "전문적인 모양을 위해 PowerPoint 및 OpenDocument 프레젠테이션에 머리글과 바닥글을 추가하고 맞춤 설정하려면 Aspose.Slides for .NET을 사용하세요."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 머리글 및 바닥글 설정을 관리할 수 있습니다. 머리글과 바닥글은 프레젠테이션 마스터 수준에서 처리되며, API는 바닥글 텍스트 설정, 바닥글 가시성 변경 및 마스터 노트 슬라이드의 머리글 텍스트 업데이트를 위한 메서드를 제공합니다.

핸드아웃 및 노트 슬라이드에 대해서도 머리글과 바닥글을 관리할 수 있습니다. 여기에는 노트 마스터, 모든 하위 노트 슬라이드 또는 개별 노트 슬라이드에 대한 머리글, 바닥글, 슬라이드 번호 및 날짜‑시간 자리표시자의 가시성 및 텍스트를 변경하는 것이 포함됩니다.

## **머리글 및 바닥글 텍스트 관리**

특정 슬라이드의 노트를 아래 예시와 같이 업데이트할 수 있습니다:

```c#
// 프레젠테이션 로드
Presentation pres = new Presentation("headerTest.pptx");

// 바닥글 설정
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// 머리글 접근 및 업데이트
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
    UpdateHeaderFooterText(masterNotesSlide);
}

// 프레젠테이션 저장
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```

```c#
// 머리글/바닥글 텍스트를 설정하는 메서드
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```

## **핸드아웃 및 노트 슬라이드에서 머리글 및 바닥글 관리**

Aspose.Slides for .NET는 핸드아웃 및 노트 슬라이드에서 머리글과 바닥글을 지원합니다. 아래 단계를 따르세요:

- 비디오가 포함된 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation)를 로드합니다.
- 노트 마스터 및 모든 노트 슬라이드에 대한 머리글 및 바닥글 설정을 변경합니다.
- 마스터 노트 슬라이드와 모든 하위 바닥글 자리표시자를 보이게 설정합니다.
- 마스터 노트 슬라이드와 모든 하위 날짜 및 시간 자리표시자를 보이게 설정합니다.
- 첫 번째 노트 슬라이드에만 머리글 및 바닥글 설정을 변경합니다.
- 노트 슬라이드의 머리글 자리표시자를 보이게 설정합니다.
- 노트 슬라이드 머리글 자리표시자에 텍스트를 설정합니다.
- 노트 슬라이드 날짜‑시간 자리표시자에 텍스트를 설정합니다.
- 수정된 프레젠테이션 파일을 저장합니다.

아래 예제에 코드 스니펫이 제공됩니다.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// 노트 마스터 및 모든 노트 슬라이드에 대한 머리글 및 바닥글 설정 변경
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // 마스터 노트 슬라이드와 모든 하위 Footer 자리표시자를 표시하도록 설정
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // 마스터 노트 슬라이드와 모든 하위 Header 자리표시자를 표시하도록 설정
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // 마스터 노트 슬라이드와 모든 하위 SlideNumber 자리표시자를 표시하도록 설정
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // 마스터 노트 슬라이드와 모든 하위 Date 및 time 자리표시자를 표시하도록 설정

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // 마스터 노트 슬라이드와 모든 하위 Header 자리표시자에 텍스트 설정
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // 마스터 노트 슬라이드와 모든 하위 Footer 자리표시자에 텍스트 설정
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // 마스터 노트 슬라이드와 모든 하위 Date 및 time 자리표시자에 텍스트 설정
	}

	// 첫 번째 노트 슬라이드에만 머리글 및 바닥글 설정 변경
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // 이 노트 슬라이드의 Header 자리표시자를 표시하도록 설정

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // 이 노트 슬라이드의 Footer 자리표시자를 표시하도록 설정

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // 이 노트 슬라이드의 SlideNumber 자리표시자를 표시하도록 설정

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // 이 노트 슬라이드의 Date-time 자리표시자를 표시하도록 설정

		headerFooterManager.SetHeaderText("New header text"); // 노트 슬라이드 Header 자리표시자에 텍스트 설정
		headerFooterManager.SetFooterText("New footer text"); // 노트 슬라이드 Footer 자리표시자에 텍스트 설정
		headerFooterManager.SetDateTimeText("New date and time text"); // 노트 슬라이드 Date-time 자리표시자에 텍스트 설정
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
        
 }
```

## **FAQ**

**일반 슬라이드에 "머리글"을 추가할 수 있나요?**

PowerPoint에서 "Header"는 노트와 핸드아웃에만 존재합니다; 일반 슬라이드에서는 지원되는 요소가 바닥글, 날짜/시간, 슬라이드 번호뿐입니다. Aspose.Slides에서도 동일한 제한이 적용됩니다: 머리글은 Notes/Handout에만 존재하고, 슬라이드에서는 Footer/DateTime/SlideNumber만 지원됩니다.

**레이아웃에 바닥글 영역이 없으면 가시성을 "켜" 수 있나요?**

예. 헤더/바닥글 관리자를 통해 가시성을 확인하고 필요하면 활성화하세요. 이러한 API 지시자와 메서드는 자리표시자가 없거나 숨겨진 경우를 위해 설계되었습니다.

**슬라이드 번호를 1이 아닌 다른 값에서 시작하려면 어떻게 해야 하나요?**

프레젠테이션의 [first slide number](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/firstslidenumber/)을 설정합니다; 이후 모든 번호가 다시 계산됩니다. 예를 들어 0이나 10부터 시작할 수 있으며, 제목 슬라이드에서는 번호를 숨길 수 있습니다.

**PDF/이미지/HTML로 내보낼 때 머리글/바닥글은 어떻게 되나요?**

머리글과 바닥글은 프레젠테이션의 일반 텍스트 요소로 렌더링됩니다. 즉, 해당 요소가 슬라이드/노트 페이지에 표시되어 있다면 출력 형식에서도 다른 콘텐츠와 함께 나타납니다.