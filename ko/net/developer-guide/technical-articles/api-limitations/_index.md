---
title: 출력 메타데이터 제한 사항
type: docs
weight: 320
url: /ko/net/api-limitations/
keywords:
- API 제한
- 내보내기 형식
- 애플리케이션
- 프로듀서
- 문서 속성
- 메타데이터
- 생성기
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET은 저장된 PPTX, PDF 및 ODP 파일에 고정된 application, creator 및 producer 메타데이터를 기록합니다. 설정하는 application 이름과 무관합니다."
---
## **개요**

Aspose.Slides로 프레젠테이션을 만들거나 내보낼 때 특정 기술 메타데이터가 출력 파일에 기록됩니다. 이 문서에서는 PPTX, PDF 및 ODP 파일의 `Application`, `Creator`, `Producer`, 그리고 generator 메타데이터 필드와 관련된 제한 사항을 설명합니다.

## **Application 및 Producer**

Aspose.Slides for .NET로 프레젠테이션을 만들거나 내보낼 때 일부 기술 메타데이터가 파일에 기록됩니다. 두 필드가 종종 질문을 불러일으킵니다:

**Application**은 **PPTX** 프레젠테이션을 만든 또는 마지막으로 저장한 프로그램을 식별합니다. Aspose.Slides for .NET에서는 이 값이 고정되어 있으며, [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/ko/net/aspose.slides/documentproperties/nameofapplication/)을 설정하더라도 애플리케이션 이름이 아니라 라이브러리 이름이 표시됩니다.

**Producer**는 내보내기 중 최종 파일을 생성한 렌더링 엔진을 식별합니다. **PDF** 내보내기에서는 메타데이터가 **Creator** 및 **Producer** 필드를 사용합니다. Aspose.Slides for .NET에서는 이 두 필드가 고정되어 라이브러리와 그 버전을 나타냅니다.

**제한 사항**

위 형식에 대해 API를 통해 이러한 필드를 재정의할 수 없습니다. **PPTX**의 경우 Application 속성이 "Aspose.Slides for .NET"으로 기록됩니다. **PDF**의 경우 Creator 및 Producer 속성이 "Aspose.Slides for .NET"에 라이브러리 버전을 덧붙인 형태로 기록됩니다. **ODP**의 경우 generator 필드가 "Aspose.Slides for .NET"에 라이브러리 버전을 덧붙인 형태로 기록됩니다. 이 동작은 설계된 방식이며 파일을 로드하거나 저장하는 방법, 그리고 [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/ko/net/aspose.slides/documentproperties/nameofapplication/)에 할당된 값과 무관하게 적용됩니다.

이 제한은 **PPT** 파일에는 적용되지 않습니다. PPT 파일에서는 [DocumentProperties.NameOfApplication](https://reference.aspose.com/slides/ko/net/aspose.slides/documentproperties/nameofapplication/)에 설정한 애플리케이션 이름이 저장됩니다.