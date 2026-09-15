---
title: API 제한
type: docs
weight: 320
url: /ko/python-java/api-limitations/
keywords:
- API 제한
- 내보내기 형식
- 응용 프로그램
- 프로듀서
- 문서 속성
- 메타데이터
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java의 제한 사항에 대해 알아보세요: PPTX 및 PDF 파일에서 고정된 Application, Creator 및 Producer 메타데이터."
---
## **개요**

프레젠테이션을 Aspose.Slides로 만들거나 내보낼 때 특정 기술 메타데이터가 출력 파일에 기록됩니다. 이 문서에서는 PPTX 및 PDF 파일의 `Application`, `Creator`, `Producer` 메타데이터 필드와 관련된 제한 사항을 설명합니다.

## **Application 및 Producer**

Aspose.Slides for Python via Java로 프레젠테이션을 만들거나 내보낼 때 일부 기술 메타데이터가 파일에 기록됩니다. 두 필드는 종종 질문을 일으킵니다:

**Application**은 **PPTX** 프레젠테이션을 만든 또는 마지막으로 저장한 프로그램을 식별합니다. Aspose.Slides for Python via Java에서는 이 값이 고정되어 있으며, [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#setnameofapplication)을 사용하더라도 애플리케이션 이름 대신 라이브러리 공급업체가 표시됩니다.

**Producer**는 내보내기 중 최종 파일을 생성한 렌더링 엔진을 식별합니다. **PDF** 내보내기에서는 메타데이터가 **Creator**와 **Producer** 필드를 사용합니다. Aspose.Slides for Python via Java에서는 이 두 필드가 고정되어 있으며 라이브러리와 해당 버전을 반영합니다.

**제한 사항**

위 형식에 대해 API를 통해 이러한 필드를 재정의할 수 없습니다. **PPTX**의 경우 Application 속성이 "Aspose.Slides for Java"로 기록됩니다. **PDF**의 경우 Creator와 Producer 속성이 "Aspose.Slides for Java x.x.x."로 기록됩니다. 이 동작은 설계된 대로이며 파일을 로드하거나 저장하는 방식, 그리고 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#setnameofapplication)으로 지정한 값에 관계없이 적용됩니다.

## **FAQ**

**PPTX 파일에서 Application 값을 내 애플리케이션 이름으로 교체할 수 있나요?**

아니오. 이 값은 고정되어 있으며, [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#setnameofapplication)을 사용하더라도 변경할 수 없습니다.

**PDF 내보내기에서 Creator와 Producer 필드를 재정의할 수 있나요?**

아니오. 두 필드는 고정되어 있으며, 프레젠테이션을 로드하거나 저장하는 방식과 관계없이 라이브러리와 해당 버전을 반영합니다.