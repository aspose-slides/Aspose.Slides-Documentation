---
title: API 제한 사항
type: docs
weight: 320
url: /ko/androidjava/api-limitations/
keywords:
- API 제한
- 내보내기 형식
- 애플리케이션
- 프로듀서
- 문서 속성
- 메타데이터
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android의 제한 사항을 확인하세요: 내보내기는 PPT, PPTX, ODP, PDF에서 고정된 Application/Producer 메타데이터를 설정합니다—예상치 못한 문제가 발생하지 않도록 통합을 계획하는 데 도움이 됩니다."
---
## **Overview**

Aspose.Slides로 프레젠테이션을 만들거나 내보내면 특정 기술 메타데이터가 출력 파일에 기록됩니다. 이 문서에서는 PPTX 및 PDF 파일의 `Application`, `Creator`, `Producer` 메타데이터 필드와 관련된 제한 사항을 설명합니다.

## **Application and Producer**

Aspose.Slides for Android via Java를 사용해 프레젠테이션을 만들거나 내보낼 때 파일에 일부 기술 메타데이터가 기록됩니다. 두 개의 필드가 종종 질문을 일으킵니다:

**Application**은 **PPTX** 프레젠테이션을 생성하거나 마지막으로 저장한 프로그램을 식별합니다. Aspose.Slides for Android via Java에서는 이 값이 고정되어 있어, [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)을 사용하더라도 귀하의 앱 이름이 아니라 라이브러리 공급업체가 표시됩니다.

**Producer**는 내보내기 중 최종 파일을 생성한 렌더링 엔진을 식별합니다. **PDF** 내보내기에서는 메타데이터가 **Creator**와 **Producer** 필드를 사용합니다. Aspose.Slides for Android via Java에서는 이 두 필드가 모두 고정되어 라이브러리와 해당 버전을 나타냅니다.

## **What’s restricted**

위의 형식에 대해 API를 통해 이 필드들을 재정의할 수 없습니다. **PPTX**의 경우 Application 속성이 "Aspose.Slides for Android via Java"로 기록됩니다. **PDF**의 경우 Creator와 Producer 속성이 "Aspose.Slides for Android via Java x.x.x."(버전)으로 기록됩니다. 이 동작은 설계대로이며 파일을 어떻게 로드하거나 저장하든, 그리고 [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/documentproperties/#setNameOfApplication-java.lang.String-)으로 할당한 값과 관계없이 적용됩니다.