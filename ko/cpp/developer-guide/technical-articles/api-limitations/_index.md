---
title: API 제한사항
type: docs
weight: 320
url: /ko/cpp/api-limitations/
keywords:
- API 제한사항
- 내보내기 형식
- 애플리케이션
- 프로듀서
- 문서 속성
- 메타데이터
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 제한 사항을 알아보세요: 내보내기는 PPT, PPTX, ODP 및 PDF에서 고정된 Application/Producer 메타데이터를 설정하므로 예기치 않은 문제가 없도록 통합을 계획할 수 있습니다."
---
## **개요**

Aspose.Slides를 사용하여 프레젠테이션을 만들거나 내보낼 때 특정 기술 메타데이터가 출력 파일에 기록됩니다. 이 문서에서는 PPTX 및 PDF 파일의 `Application`, `Creator`, `Producer` 메타데이터 필드와 관련된 제한 사항을 설명합니다.

## **Application 및 Producer**

Aspose.Slides for C++로 프레젠테이션을 만들거나 내보낼 때 파일에 기술 메타데이터가 기록됩니다. 두 필드가 자주 질문됩니다:

**Application**은 **PPTX** 프레젠테이션을 만든 또는 마지막으로 저장한 프로그램을 식별합니다. Aspose.Slides for C++에서는 이 값이 고정되어 있어 애플리케이션 이름 대신 라이브러리 공급업체가 표시됩니다. 이는[DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/ko/cpp/aspose.slides/documentproperties/set_nameofapplication/)을 사용하더라도 마찬가지입니다.

**Producer**는 내보내기 중 최종 파일을 생성한 렌더링 엔진을 식별합니다. **PDF** 내보내기에서는 메타데이터가 **Creator** 및 **Producer** 필드를 사용합니다. Aspose.Slides for C++에서는 이 둘 모두 고정되어 라이브러리와 해당 버전을 나타냅니다.

**제한 사항**

위 형식에 대해 API를 통해这些字段을 재정의할 수 없습니다. **PPTX**의 경우 Application 속성이 "Aspose.Slides for C++"으로 기록됩니다. **PDF**의 경우 Creator 및 Producer 속성이 "Aspose.Slides for C++ x.x.x"으로 기록됩니다. 이 동작은 설계된 것으로, 파일을 로드하거나 저장하는 방식, 그리고[DocumentProperties::set_NameOfApplication](https://reference.aspose.com/slides/ko/cpp/aspose.slides/documentproperties/set_nameofapplication/)을 사용하여 할당한 값에 관계없이 적용됩니다.