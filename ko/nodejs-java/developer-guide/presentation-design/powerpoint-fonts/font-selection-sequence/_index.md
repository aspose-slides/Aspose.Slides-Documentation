---
title: Node.js용 Aspose.Slides(Java)에서 폰트 선택 순서
linktitle: 폰트 선택
type: docs
weight: 80
url: /ko/nodejs-java/font-selection-sequence/
keywords:
- 폰트 선택
- 폰트 대체
- 폰트 교체
- 대체 규칙
- 사용 가능한 폰트
- 누락된 폰트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java가 폰트를 선택하는 방식을 확인하고, PPT, PPTX 및 ODP 파일을 선명하고 일관되게 표시하도록 하여 지금 바로 슬라이드를 개선하세요."
---
## **개요**

프레젠테이션이 로드되거나 렌더링되거나 다른 형식으로 변환될 때, Aspose.Slides는 프레젠테이션에서 사용된 폰트가 운영 체제에 존재하는지 확인합니다. 필요한 폰트가 없으면 Aspose.Slides는 PowerPoint가 사용할 폰트와 가능한 한 가깝게 대체 폰트를 선택합니다.

Aspose.Slides는 먼저 운영 체제에서 선택된 폰트를 검색합니다. 폰트를 찾으면 이를 사용하고, 찾지 못하면 적절한 대체 폰트를 적용합니다. `FontSubstRule`을 통해 폰트 대체 규칙이 정의된 경우 해당 규칙도 고려됩니다.

응용 프로그램 실행 중에 폰트를 추가하거나, 프레젠테이션에 포함된 폰트를 사용하거나, PDF 파일과 같은 출력 문서를 위해 외부 폰트를 로드할 수도 있습니다.

## **폰트 선택**

프레젠테이션이 로드, 렌더링 또는 다른 형식으로 변환될 때 적용되는 특정 규칙이 있습니다. 예를 들어 프레젠테이션(슬라이드)을 이미지로 변환하려고 할 때, 프레젠테이션의 폰트가 운영 체제에 존재하는지 확인합니다. 폰트가 없다고 확인되면 대체됩니다 — [**폰트 교체**](https://docs.aspose.com/slides/ko/nodejs-java/font-replacement/) 및 [**폰트 대체**](https://docs.aspose.com/slides/ko/nodejs-java/font-substitution/)를 참조하십시오.

Aspose.Slides가 폰트를 처리하는 과정은 다음과 같습니다:

1. Aspose.Slides는 운영 체제에서 프레젠테이션이 선택한 폰트와 일치하는 폰트를 찾습니다. 
2. 선택한 폰트를 찾으면 Aspose.Slides가 이를 사용합니다. 찾지 못하면 PowerPoint가 사용할 폰트와 가장 가깝게 대체 폰트를 사용합니다.
3. [FontSubstRule](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/fontsubstrule/)을 통해 폰트 대체 규칙이 설정된 경우 적용됩니다.

Aspose.Slides를 사용하면 응용 프로그램 실행 중에 폰트를 추가하고 이를 사용할 수 있습니다. 자세한 내용은 [**사용자 정의 폰트**](https://docs.aspose.com/slides/ko/nodejs-java/custom-font/)를 참조하십시오.

프레젠테이션에 추가된 폰트는 [**내장 폰트**](https://docs.aspose.com/slides/ko/nodejs-java/embedded-font/)라고 합니다.

Aspose.Slides는 *오직* 출력 문서에만 적용되는 폰트를 추가할 수 있도록 지원합니다. 예를 들어 PDF로 변환하려는 프레젠테이션에 시스템 및 내장 폰트에 없는 폰트가 포함되어 있는 경우, 필요한 폰트를 **외부 폰트**로 추가하거나 로드할 수 있습니다. 

{{% alert title="Note" color="primary" %}} 
저희는 유료든 무료든 어떠한 폰트도 배포하지 않습니다. API를 통해 외부 폰트를 로드하고 문서에 내장할 수 있지만, 폰트 사용은 전적으로 고객님의 재량과 책임하에 이루어집니다.
{{% /alert %}}

## **FAQ**

**변환 전에 프레젠테이션에서 실제로 사용되는 폰트를 어떻게 확인할 수 있나요?**

Aspose.Slides는 [폰트 관리자](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/getfontsmanager/)를 통해 사용된 폰트를 검사할 수 있게 하므로, [내장](/slides/ko/nodejs-java/embedded-font/), [교체](/slides/ko/nodejs-java/font-replacement/), 또는 [외부 소스](/slides/ko/nodejs-java/custom-font/)를 추가할지 결정할 수 있습니다. 이를 통해 렌더링 및 내보내기 시 원치 않는 대체를 방지할 수 있습니다.

**운영 체제에 설치하지 않고 추가 폰트 디렉터리를 등록할 수 있나요?**

네. 렌더링 및 내보내기를 위해 폴더나 메모리 스트림과 같은 [외부 폰트 소스](/slides/ko/nodejs-java/custom-font/)를 등록할 수 있습니다. 이렇게 하면 호스트 시스템 폰트에 대한 의존성을 제거하고 레이아웃을 예측 가능하게 유지할 수 있습니다.

**문자글리프가 없을 때 부적절한 폰트로 조용히 대체되는 것을 어떻게 방지하나요?**

사전에 명시적인 [폰트 교체](/slides/ko/nodejs-java/font-replacement/) 및 폰트 [fallback 규칙](/slides/ko/nodejs-java/fallback-font/)을 정의하십시오. 사용된 폰트를 분석하고 대체 폰트에 대한 우선순위를 제어함으로써 일관된 타이포그래피를 보장하고 예상치 못한 결과를 방지할 수 있습니다.