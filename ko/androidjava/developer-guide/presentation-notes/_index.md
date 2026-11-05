---
title: Android에서 프레젠테이션 노트 관리
linktitle: 프레젠테이션 노트
type: docs
weight: 110
url: /ko/androidjava/presentation-notes/
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
- Android
- Java
- Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides로 프레젠테이션 노트를 맞춤 설정하세요. PowerPoint 및 OpenDocument 노트를 원활하게 작업하여 생산성을 높일 수 있습니다."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 노트 슬라이드를 제거하는 기능을 지원합니다. 이 항목에서는 노트를 제거하는 방법과 프레젠테이션의 노트 슬라이드에 스타일을 적용하는 방법을 포함하여 이 기능을 소개합니다. Aspose.Slides를 사용하면 모든 슬라이드에서 노트를 제거하고 기존 노트에 스타일을 적용할 수 있습니다. 개발자는 다음과 같은 방법으로 노트를 제거할 수 있습니다:

- 프레젠테이션의 특정 슬라이드에서 노트를 제거합니다.
- 프레젠테이션의 모든 슬라이드에서 노트를 제거합니다.

노트 페이지 크기를 읽거나 변경하고, 방향을 전환하며, 내보내기 동작을 확인하려면 [Notes Page Size](/slides/ko/androidjava/notes-size/)를 참조하십시오.

## **슬라이드에서 노트 제거**
특정 슬라이드의 노트는 아래 예제와 같이 제거할 수 있습니다:

```java
import com.aspose.slides.*;

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
프레젠테이션의 모든 슬라이드에 있는 노트는 아래 예제와 같이 제거할 수 있습니다:

```java
import com.aspose.slides.*;

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
[getNotesStyle](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) 메서드가 [IMasterNotesSlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IMasterNotesSlide) 인터페이스와 [MasterNotesSlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/MasterNotesSlide) 클래스에 각각 추가되었습니다. 이 속성은 노트 텍스트의 스타일을 지정합니다. 구현은 아래 예제에서 확인할 수 있습니다.

```java
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // MasterNotesSlide 텍스트 스타일을 가져옵니다
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        //첫 번째 수준 단락에 기호 글머리표를 설정합니다
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**특정 슬라이드의 노트에 액세스할 수 있는 API 엔터티는 무엇입니까?**

노트는 슬라이드의 노트 관리자를 통해 액세스합니다: 슬라이드에는 [NotesSlideManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/notesslidemanager/)가 있으며, 노트 객체를 반환하는 [메서드](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--)가 있습니다. 노트가 없으면 `null`을 반환합니다.

**라이브러리가 지원하는 PowerPoint 버전 간에 노트 지원에 차이가 있나요?**

이 라이브러리는 Microsoft PowerPoint 형식(97부터 최신 버전) 및 ODP를 폭넓게 지원합니다; 이러한 형식에서는 PowerPoint가 설치되어 있지 않아도 노트가 지원됩니다.