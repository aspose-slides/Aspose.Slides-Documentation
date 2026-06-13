---
title: Java에서 프레젠테이션 머리글 및 바닥글 관리
linktitle: 머리글 및 바닥글
type: docs
weight: 140
url: /ko/java/presentation-header-and-footer/
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
- Java
- Aspose.Slides
description: "전문적인 외관을 위해 PowerPoint 및 OpenDocument 프레젠테이션에 머리글과 바닥글을 추가하고 사용자 정의하려면 Aspose.Slides for Java를 사용하세요."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 머리글 및 바닥글 설정을 관리할 수 있습니다. 머리글과 바닥글은 프레젠테이션 마스터 수준에서 처리되며, API는 바닥글 텍스트 설정, 바닥글 표시 여부 변경, 마스터 노트 슬라이드에서 머리글 텍스트 업데이트를 위한 메서드를 제공합니다.

핸드아웃 및 노트 슬라이드에 대한 머리글 및 바닥글도 관리할 수 있습니다. 여기에는 노트 마스터, 모든 하위 노트 슬라이드 또는 개별 노트 슬라이드에 대한 머리글, 바닥글, 슬라이드 번호 및 날짜‑시간 자리 표시자의 표시 여부와 텍스트를 변경하는 것이 포함됩니다.

## **프레젠테이션에서 머리글 및 바닥글 관리**
아래 예와 같이 특정 슬라이드의 노트를 제거할 수 있습니다:

```java
// 프레젠테이션 로드
Presentation pres = new Presentation("headerTest.pptx");
try {
    // 바닥글 설정
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // 머리글에 접근 및 업데이트
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // 프레젠테이션 저장
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// 머리글/바닥글 텍스트를 설정하는 메서드
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **핸드아웃 및 노트 슬라이드에서 머리글 및 바닥글 관리**
Aspose.Slides for Java는 핸드아웃 및 노트 슬라이드에서 머리글 및 바닥글을 지원합니다. 아래 단계에 따라 진행하십시오:

- 비디오가 포함된 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation)을 로드합니다.
- 노트 마스터와 모든 노트 슬라이드에 대한 머리글 및 바닥글 설정을 변경합니다.
- 마스터 노트 슬라이드와 모든 하위 바닥글 자리 표시자를 표시하도록 설정합니다.
- 마스터 노트 슬라이드와 모든 하위 날짜 및 시간 자리 표시자를 표시하도록 설정합니다.
- 첫 번째 노트 슬라이드에만 머리글 및 바닥글 설정을 변경합니다.
- 노트 슬라이드의 머리글 자리 표시자를 표시하도록 설정합니다.
- 노트 슬라이드 머리글 자리 표시자에 텍스트를 설정합니다.
- 노트 슬라이드 날짜‑시간 자리 표시자에 텍스트를 설정합니다.
- 수정된 프레젠테이션 파일을 저장합니다.

아래 예제에 코드 스니펫이 제공됩니다.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // 노트 마스터 및 모든 노트 슬라이드에 대한 머리글 및 바닥글 설정 변경
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // 마스터 노트 슬라이드와 모든 하위 Footer 자리 표시자를 보이게 함
        headerFooterManager.setFooterAndChildFootersVisibility(true); // 마스터 노트 슬라이드와 모든 하위 Header 자리 표시자를 보이게 함
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // 마스터 노트 슬라이드와 모든 하위 SlideNumber 자리 표시자를 보이게 함
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // 마스터 노트 슬라이드와 모든 하위 날짜 및 시간 자리 표시자를 보이게 함

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // 마스터 노트 슬라이드와 모든 하위 Header 자리 표시자에 텍스트 설정
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // 마스터 노트 슬라이드와 모든 하위 Footer 자리 표시자에 텍스트 설정
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // 마스터 노트 슬라이드와 모든 하위 날짜 및 시간 자리 표시자에 텍스트 설정
    }

    // 첫 번째 노트 슬라이드에만 머리글 및 바닥글 설정 변경
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // 이 노트 슬라이드의 Header 자리 표시자를 보이게 함

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // 이 노트 슬라이드의 Footer 자리 표시자를 보이게 함

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // 이 노트 슬라이드의 SlideNumber 자리 표시자를 보이게 함

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // 이 노트 슬라이드의 Date-time 자리 표시자를 보이게 함

        headerFooterManager.setHeaderText("New header text"); // 노트 슬라이드 Header 자리 표시자에 텍스트 설정
        headerFooterManager.setFooterText("New footer text"); // 노트 슬라이드 Footer 자리 표시자에 텍스트 설정
        headerFooterManager.setDateTimeText("New date and time text"); // 노트 슬라이드 Date-time 자리 표시자에 텍스트 설정
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**일반 슬라이드에 "머리글"을 추가할 수 있나요?**

PowerPoint에서는 "머리글"이 노트와 핸드아웃에만 존재합니다. 일반 슬라이드에서는 지원되는 요소가 바닥글, 날짜/시간 및 슬라이드 번호뿐입니다. Aspose.Slides에서도 동일한 제한이 적용되어 머리글은 노트/핸드아웃에만 사용할 수 있으며, 슬라이드에서는 바닥글/날짜‑시간/슬라이드 번호만 지원됩니다.

**레이아웃에 바닥글 영역이 없으면—표시를 "켜" 할 수 있나요?**

예. 헤더/바닥글 관리자를 통해 표시 여부를 확인하고 필요에 따라 활성화하면 됩니다. 이러한 API 지시자와 메서드는 자리 표시자가 없거나 숨겨진 경우를 처리하도록 설계되었습니다.

**슬라이드 번호를 1이 아닌 다른 값으로 시작하려면 어떻게 해야 하나요?**

프레젠테이션의 [first slide number](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-)를 설정합니다. 이후 모든 번호가 다시 계산됩니다. 예를 들어 0이나 10부터 시작하도록 지정하고, 제목 슬라이드에서는 번호를 숨길 수 있습니다.

**PDF/이미지/HTML로 내보낼 때 머리글/바닥글은 어떻게 처리되나요?**

머리글과 바닥글은 프레젠테이션의 일반 텍스트 요소로 렌더링됩니다. 즉, 해당 요소가 슬라이드·노트 페이지에 표시되어 있으면 출력 형식에서도 다른 콘텐츠와 함께 나타납니다.