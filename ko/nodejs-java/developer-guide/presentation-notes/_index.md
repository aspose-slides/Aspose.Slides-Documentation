---
title: JavaScript에서 프레젠테이션 메모 관리
linktitle: 프레젠테이션 메모
type: docs
weight: 110
url: /ko/nodejs-java/presentation-notes/
keywords:
- 메모
- 메모 슬라이드
- 메모 추가
- 메모 제거
- 메모 스타일
- 마스터 메모
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 JavaScript에서 프레젠테이션 메모를 맞춤화합니다. PowerPoint 및 OpenDocument 메모를 원활하게 작업하여 생산성을 높이세요."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 메모 슬라이드를 제거하는 기능을 지원합니다. 이 항목에서는 메모를 제거하는 방법과 프레젠테이션의 메모 슬라이드에 스타일을 적용하는 방법을 소개합니다. Aspose.Slides를 사용하면 모든 슬라이드에서 메모를 제거하고 기존 메모에 스타일을 적용할 수 있습니다. 개발자는 다음과 같은 방법으로 메모를 제거할 수 있습니다:

- 프레젠테이션의 특정 슬라이드에서 메모를 제거합니다.
- 프레젠테이션의 모든 슬라이드에서 메모를 제거합니다.

## **슬라이드에서 메모 제거**
특정 슬라이드의 메모는 아래 예시와 같이 제거할 수 있습니다:

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // 첫 번째 슬라이드의 메모를 제거합니다
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **프레젠테이션에서 메모 제거**
프레젠테이션의 모든 슬라이드에서 메모는 아래 예시와 같이 제거할 수 있습니다:

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // 모든 슬라이드의 메모를 제거합니다
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **NotesStyle 추가**
[getNotesStyle](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) 메서드가 [MasterNotesSlide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/MasterNotesSlide) 클래스에 추가되었습니다. 이 속성은 메모 텍스트의 스타일을 지정합니다. 구현은 아래 예시에서 확인할 수 있습니다.

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // MasterNotesSlide 텍스트 스타일을 가져옵니다
        var notesStyle = notesMaster.getNotesStyle();
        // 첫 번째 수준 단락에 기호 글머리표를 설정합니다
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**특정 슬라이드의 메모에 접근할 수 있는 API 엔터티는 무엇입니까?**

메모는 슬라이드의 노트 관리자([NotesSlideManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/notesslidemanager/))를 통해 접근합니다. 슬라이드에는 메모 객체를 반환하는 [method](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) 또는 메모가 없을 경우 `null`을 반환하는 메서드가 있습니다.

**라이브러리가 지원하는 PowerPoint 버전 간에 메모 지원에 차이가 있습니까?**

이 라이브러리는 Microsoft PowerPoint 형식(97-버전 이상) 및 ODP 등 다양한 포맷을 대상으로 합니다. 메모는 이러한 형식에서 PowerPoint가 설치되어 있지 않아도 지원됩니다.