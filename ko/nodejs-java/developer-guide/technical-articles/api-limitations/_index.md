---
title: API 제한 사항
type: docs
weight: 320
url: /ko/nodejs-java/api-limitations/
keywords:
- API 제한 사항
- 내보내기 형식
- 응용 프로그램
- 제작자
- 문서 속성
- 메타데이터
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js의 제한 사항을 확인하세요: 내보내기는 PPT, PPTX, ODP 및 PDF에서 고정된 Application/Producer 메타데이터를 설정합니다 - 예기치 않은 문제가 발생하지 않도록 통합을 계획하는 데 도움이 됩니다."
---
## **개요**

Aspose.Slides로 프레젠테이션을 만들거나 내보낼 때, 특정 기술 메타데이터가 출력 파일에 기록됩니다. 이 문서에서는 PPTX 및 PDF 파일의 `Application`, `Creator`, `Producer` 메타데이터 필드와 관련된 제한 사항을 설명합니다.

## **Application 및 Producer**

Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션을 만들거나 내보낼 때, 일부 기술 메타데이터가 파일에 기록됩니다. 두 개의 필드가 자주 질문을 받습니다:

**Application**은 **PPTX** 프레젠테이션을 만든 프로그램 또는 마지막으로 저장한 프로그램을 식별합니다. Aspose.Slides for Node.js via Java에서는 이 값이 고정되어 라이브러리 공급업체를 표시하며, [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/setnameofapplication/)을 사용하더라도 앱 이름이 표시되지 않습니다.

**Producer**는 내보내기 중 최종 파일을 생성한 렌더링 엔진을 식별합니다. **PDF** 내보내기에서는 메타데이터가 **Creator**와 **Producer** 필드를 사용합니다. Aspose.Slides for Node.js via Java에서는 이 두 필드가 고정되어 라이브러리와 해당 버전을 반영합니다.

**제한 사항**

위의 형식에 대해 API를 통해 이러한 필드를 재정의할 수 없습니다. **PPTX**의 경우 Application 속성은 "Aspose.Slides for Node.js via Java"로 기록됩니다. **PDF**의 경우 Creator와 Producer 속성은 "Aspose.Slides for Node.js via Java x.x.x." 로 기록됩니다. 이 동작은 설계상의 의도이며, 파일을 로드하거나 저장하는 방법, 그리고 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/setnameofapplication/)을 사용하여 할당한 값에 관계없이 적용됩니다.