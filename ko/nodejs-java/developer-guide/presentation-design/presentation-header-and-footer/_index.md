---
title: JavaScript에서 프레젠테이션 머리글 및 바닥글 관리
linktitle: 머리글 및 바닥글
type: docs
weight: 140
url: /ko/nodejs-java/presentation-header-and-footer/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에 머리글과 바닥글을 추가하고 사용자 정의하여 전문적인 모습을 제공합니다."
---
## **개요**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션에서 머리글 및 바닥글 설정을 관리할 수 있습니다. 머리글과 바닥글은 프레젠테이션 마스터 수준에서 처리되며, API는 바닥글 텍스트 설정, 바닥글 가시성 변경 및 마스터 노트 슬라이드에서 머리글 텍스트 업데이트를 위한 메서드를 제공합니다.

핸드아웃 및 노트 슬라이드에 대한 머리글과 바닥글도 관리할 수 있습니다. 여기에는 노트 마스터, 모든 자식 노트 슬라이드 또는 개별 노트 슬라이드에 대한 머리글, 바닥글, 슬라이드 번호 및 날짜‑시간 자리표시자의 가시성 및 텍스트를 변경하는 것이 포함됩니다.

## **프레젠테이션에서 머리글 및 바닥글 관리**
아래 예시와 같이 특정 슬라이드의 노트를 제거할 수 있습니다:

```javascript
// 프레젠테이션 로드
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // 바닥글 설정
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // 머리글 접근 및 업데이트
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // 프레젠테이션 저장
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **핸드아웃 및 노트 슬라이드에서 머리글 및 바닥글 관리**
Java를 통한 Node.js용 Aspose.Slides는 핸드아웃 및 노트 슬라이드에서 머리글과 바닥글을 지원합니다. 아래 단계를 따라 주세요:

- 비디오가 포함된 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation)를 로드합니다.
- 노트 마스터 및 모든 노트 슬라이드에 대한 머리글 및 바닥글 설정을 변경합니다.
- 마스터 노트 슬라이드와 모든 자식 바닥글 자리표시자를 표시하도록 설정합니다.
- 마스터 노트 슬라이드와 모든 자식 날짜 및 시간 자리표시자를 표시하도록 설정합니다.
- 첫 번째 노트 슬라이드에만 머리글 및 바닥글 설정을 변경합니다.
- 노트 슬라이드 머리글 자리표시자를 표시하도록 설정합니다.
- 노트 슬라이드 머리글 자리표시자에 텍스트를 설정합니다.
- 노트 슬라이드 날짜‑시간 자리표시자에 텍스트를 설정합니다.
- 수정된 프레젠테이션 파일을 저장합니다.

아래 예제에 코드 스니펫이 제공됩니다.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // 노트 마스터와 모든 노트 슬라이드에 대한 머리글 및 바닥글 설정 변경
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// 마스터 노트 슬라이드와 모든 자식 Footer 자리표시자를 표시함
        headerFooterManager.setFooterAndChildFootersVisibility(true);// 마스터 노트 슬라이드와 모든 자식 Header 자리표시자를 표시함
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// 마스터 노트 슬라이드와 모든 자식 SlideNumber 자리표시자를 표시함
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// 마스터 노트 슬라이드와 모든 자식 날짜 및 시간 자리표시자를 표시함
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// 마스터 노트 슬라이드와 모든 자식 Header 자리표시자에 텍스트 설정
        headerFooterManager.setFooterAndChildFootersText("Footer text");// 마스터 노트 슬라이드와 모든 자식 Footer 자리표시자에 텍스트 설정
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// 마스터 노트 슬라이드와 모든 자식 날짜 및 시간 자리표시자에 텍스트 설정
    }
    // 첫 번째 노트 슬라이드에만 머리글 및 바닥글 설정 변경
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// 이 노트 슬라이드의 Header 자리표시자를 표시함
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// 이 노트 슬라이드의 Footer 자리표시자를 표시함
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// 이 노트 슬라이드의 SlideNumber 자리표시자를 표시함
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// 이 노트 슬라이드의 Date-time 자리표시자를 표시함
        headerFooterManager.setHeaderText("New header text");// 노트 슬라이드 Header 자리표시자에 텍스트 설정
        headerFooterManager.setFooterText("New footer text");// 노트 슬라이드 Footer 자리표시자에 텍스트 설정
        headerFooterManager.setDateTimeText("New date and time text");// 노트 슬라이드 Date-time 자리표시자에 텍스트 설정
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**일반 슬라이드에 "header"를 추가할 수 있나요?**

PowerPoint에서 "Header"는 노트와 핸드아웃에만 존재합니다; 일반 슬라이드에서는 지원되는 요소가 바닥글, 날짜/시간 및 슬라이드 번호뿐입니다. Aspose.Slides에서도 동일한 제한이 적용되어, 머리글은 노트/핸드아웃에만 사용 가능하고 슬라이드에서는 바닥글/DateTime/SlideNumber만 지원됩니다.

**레이아웃에 바닥글 영역이 없을 경우—가시성을 "켜" 할 수 있나요?**

예. 헤더/바닥글 관리자를 통해 가시성을 확인하고 필요하면 활성화할 수 있습니다. 이러한 API 표시기와 메서드는 자리표시자가 없거나 숨겨진 경우를 위해 설계되었습니다.

**슬라이드 번호를 1이 아닌 다른 값부터 시작하려면 어떻게 하나요?**

프레젠테이션의 [first slide number](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) 를 설정합니다; 이후 모든 번호가 재계산됩니다. 예를 들어 0이나 10부터 시작할 수 있으며, 제목 슬라이드에서는 번호를 숨길 수 있습니다.

**PDF/이미지/HTML로 내보낼 때 머리글/바닥글은 어떻게 처리되나요?**

머리글과 바닥글은 프레젠테이션의 일반 텍스트 요소로 렌더링됩니다. 즉, 해당 요소가 슬라이드/노트 페이지에 표시되어 있으면 출력 형식에서도 다른 내용과 함께 표시됩니다.