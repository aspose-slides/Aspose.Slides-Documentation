---
title: C++에서 프레젠테이션 노트 관리
linktitle: 프레젠테이션 노트
type: docs
weight: 110
url: /ko/cpp/presentation-notes/
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
- C++
- Aspose.Slides
description: "C++용 Aspose.Slides로 프레젠테이션 노트를 사용자 지정하세요. PowerPoint 및 OpenDocument 노트를 원활하게 작업하여 생산성을 높입니다."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 노트 슬라이드를 제거하는 기능을 지원합니다. 이 항목에서는 노트를 제거하는 방법과 프레젠테이션의 노트 슬라이드에 스타일을 적용하는 방법을 소개합니다. Aspose.Slides를 사용하면任意의 슬라이드에서 노트를 제거하고 기존 노트에 스타일을 적용할 수 있습니다. 개발자는 다음과 같은 방식으로 노트를 제거할 수 있습니다:

- 프레젠테이션의 특정 슬라이드에서 노트를 제거합니다.
- 프레젠테이션의 모든 슬라이드에서 노트를 제거합니다.

## **특정 슬라이드에서 노트 제거**
특정 슬라이드의 노트를 아래 예제와 같이 제거할 수 있습니다:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **전체 슬라이드에서 노트 제거**
프레젠테이션의 모든 슬라이드에 포함된 노트를 아래 예제와 같이 제거할 수 있습니다:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **노트 스타일 추가**
IMasterNotesSlide 인터페이스와 MasterNotesSlide 클래스에 NotesStyle 속성이 추가되었습니다. 이 속성은 노트 텍스트의 스타일을 지정합니다. 구현 예는 아래와 같습니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

**특정 슬라이드의 노트에 접근할 수 있는 API 엔터티는 무엇인가요?**

노트는 슬라이드의 노트 관리자를 통해 접근합니다: 슬라이드에는 [NotesSlideManager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/notesslidemanager/)가 있으며, 노트 객체를 반환하거나 노트가 없을 경우 `null`을 반환하는 [method](https://reference.aspose.com/slides/ko/cpp/aspose.slides/notesslidemanager/get_notesslide/)이 있습니다.

**라이브러리가 지원하는 PowerPoint 버전마다 노트 지원에 차이가 있나요?**

이 라이브러리는 Microsoft PowerPoint 포맷(97버전부터 최신 버전까지) 및 ODP를 폭넓게 지원하며, 이러한 포맷 내에서 노트를 지원합니다. 별도로 PowerPoint가 설치되어 있을 필요는 없습니다.