---
title: API 제한 사항
type: docs
weight: 320
url: /ko/java/api-limitations/
keywords:
- API 제한 사항
- 내보내기 형식
- 애플리케이션
- 프로듀서
- 문서 속성
- 메타데이터
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 제한 사항을 확인하세요: 내보내기 시 PPT, PPTX, ODP 및 PDF에서 고정된 Application/Producer 메타데이터가 설정되어 통합을 계획할 때 놀라움 없이 진행할 수 있습니다."
---
## **개요**

Aspose.Slides로 프레젠테이션을 만들거나 내보낼 때 특정 기술 메타데이터가 출력 파일에 기록됩니다. 이 문서에서는 PPTX 및 PDF 파일의 `Application`, `Creator`, `Producer` 메타데이터 필드와 관련된 제한 사항을 설명합니다.

## **Application 및 Producer**

Aspose.Slides for Java로 프레젠테이션을 만들거나 내보내면 파일에 일부 기술 메타데이터가 기록됩니다. 두 필드는 자주 질문을 받습니다:

**Application**은 **PPTX** 프레젠테이션을 만든 프로그램 또는 마지막으로 저장한 프로그램을 식별합니다. Aspose.Slides for Java에서는 이 값이 고정되어 라이브러리 공급자를 표시하며, [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ko/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)을 사용하더라도 앱 이름이 표시되지 않습니다.

**Producer**는 내보내기 중 최종 파일을 생성한 렌더링 엔진을 식별합니다. **PDF** 내보내기에서는 메타데이터에 **Creator**와 **Producer** 필드가 사용됩니다. Aspose.Slides for Java에서는 이 두 필드가 모두 고정되어 라이브러리와 해당 버전을 반영합니다.

**제한 사항**

위 형식에 대해 API를 통해 이 필드들을 재정의할 수 없습니다. **PPTX**의 경우 Application 속성이 "Aspose.Slides for Java"로 기록됩니다. **PDF**의 경우 Creator 및 Producer 속성이 "Aspose.Slides for Java x.x.x."로 기록됩니다. 이 동작은 설계에 의한 것이며 파일을 로드하거나 저장하는 방법, 그리고 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ko/java/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)을 사용하여 지정한 값과 무관하게 적용됩니다.