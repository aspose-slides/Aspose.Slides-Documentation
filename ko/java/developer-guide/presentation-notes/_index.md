---
title: Java에서 프레젠테이션 노트 관리
linktitle: 프레젠테이션 노트
type: docs
weight: 110
url: /ko/java/presentation-notes/
keywords:
- 노트
- 노트 슬라이드
- 노트 추가
- 노트 제거
- 노트 스타일
- 마스터 노트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 프레젠테이션 노트를 사용자 정의하십시오. PowerPoint 및 OpenDocument 노트를 원활하게 작업하여 생산성을 높이세요."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 노트 슬라이드를 제거하는 것을 지원합니다. 이 항목에서는 이 기능을 소개하며, 노트를 제거하는 방법과 프레젠테이션의 노트 슬라이드에 스타일을 적용하는 방법을 설명합니다. Aspose.Slides를 사용하면 모든 슬라이드에서 노트를 제거하고 기존 노트에 스타일을 적용할 수 있습니다. 개발자는 다음과 같은 방법으로 노트를 제거할 수 있습니다:

- 프레젠테이션의 특정 슬라이드에서 노트를 제거합니다.
- 프레젠테이션의 모든 슬라이드에서 노트를 제거합니다.

## **슬라이드에서 노트 제거**
특정 슬라이드의 노트를 아래 예제와 같이 제거할 수 있습니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 첫 번째 슬라이드의 노트를 제거합니다
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // 프레젠테이션을 디스크에 저장합니다
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **프레젠테이션에서 노트 제거**
프레젠테이션의 모든 슬라이드의 노트를 아래 예제와 같이 제거할 수 있습니다:

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // 모든 슬라이드의 노트를 제거합니다
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **노트 스타일 추가**
[getNotesStyle](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) 메서드가 [IMasterNotesSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IMasterNotesSlide) 인터페이스와 [MasterNotesSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/MasterNotesSlide) 클래스에 각각 추가되었습니다. 이 속성은 노트 텍스트의 스타일을 지정합니다. 구현은 아래 예제에서 확인할 수 있습니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlide 텍스트 스타일을 가져옵니다
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //Set 첫 번째 수준 단락에 기호 글머리표를 설정합니다
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**특정 슬라이드의 노트에 접근하는 API 엔터티는 무엇입니까?**

노트는 슬라이드의 노트 관리자를 통해 접근합니다: 슬라이드에는 [NotesSlideManager](https://reference.aspose.com/slides/ko/java/com.aspose.slides/notesslidemanager/)가 있으며, 노트 객체를 반환하거나 노트가 없을 경우 `null`을 반환하는 [메서드](https://reference.aspose.com/slides/ko/java/com.aspose.slides/notesslidemanager/#getNotesSlide--)가 있습니다.

**라이브러리가 지원하는 PowerPoint 버전별로 노트 지원에 차이가 있습니까?**

이 라이브러리는 Microsoft PowerPoint 형식(97버전부터 최신 버전) 및 ODP의 광범위한 포맷을 대상으로 하며, 이러한 형식 내에서 노트가 지원됩니다. PowerPoint가 설치되어 있을 필요는 없습니다.