---
title: Aspose.Slides for Android via Java의 글꼴 선택 순서
linktitle: 글꼴 선택
type: docs
weight: 80
url: /ko/androidjava/font-selection-sequence/
keywords:
- 글꼴 선택
- 글꼴 대체
- 글꼴 교체
- 대체 규칙
- 사용 가능한 글꼴
- 누락된 글꼴
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java가 글꼴을 선택하는 방식을 확인하고, PPT, PPTX 및 ODP 파일의 선명하고 일관된 프레젠테이션을 보장합니다—지금 슬라이드를 개선하세요."
---
## **개요**

프레젠테이션이 로드되거나 렌더링되거나 다른 형식으로 변환될 때, Aspose.Slides는 프레젠테이션에서 사용된 글꼴이 운영 체제에 존재하는지 확인합니다. 필요한 글꼴이 없으면, Aspose.Slides는 PowerPoint가 사용할 글꼴에 가장 가깝도록 대체 글꼴을 선택합니다.

Aspose.Slides는 먼저 운영 체제에서 선택된 글꼴을 검색합니다. 글꼴이 발견되면 사용됩니다. 발견되지 않으면 적절한 대체 글꼴이 적용됩니다. `FontSubstRule`를 통해 글꼴 대체 규칙이 정의된 경우, 해당 규칙도 고려됩니다.

또한 애플리케이션 실행 시 글꼴을 추가하거나, 프레젠테이션에 포함된 글꼴을 사용하거나, PDF 파일과 같은 출력 문서를 위해 외부 글꼴을 로드할 수 있습니다.

## **글꼴 선택**

프레젠테이션이 로드, 렌더링, 또는 다른 형식으로 변환될 때 프레젠테이션의 글꼴에 적용되는 특정 규칙이 있습니다. 예를 들어, 프레젠테이션(슬라이드)을 이미지로 변환하려고 할 때, 선택된 글꼴이 운영 체제에 존재하는지 확인합니다. 글꼴이 없다고 확인되면 대체됩니다 — [**글꼴 교체**](https://docs.aspose.com/slides/ko/androidjava/font-replacement/)와 [**글꼴 대체**](https://docs.aspose.com/slides/ko/androidjava/font-substitution/)를 참조하십시오.

Aspose.Slides가 글꼴을 처리할 때 따르는 과정은 다음과 같습니다:

1. Aspose.Slides는 운영 체제에서 프레젠테이션이 선택한 글꼴과 일치하는 글꼴을 찾습니다.  
2. 선택한 글꼴이 발견되면 Aspose.Slides가 이를 사용합니다. 그렇지 않으면 PowerPoint가 사용할 글꼴에 가장 가깝게 대체 글꼴을 사용합니다.  
3. [FontSubstRule](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsubstrule/)를 통해 글꼴 대체 규칙이 설정된 경우 적용됩니다.

Aspose.Slides를 사용하면 애플리케이션 실행 시 글꼴을 추가하고 해당 글꼴을 사용할 수 있습니다. 자세한 내용은 [**사용자 지정 글꼴**](https://docs.aspose.com/slides/ko/androidjava/custom-font/)을 참조하십시오.

프레젠테이션에 추가 글꼴이 포함된 경우 이를 [**내장 글꼴**](https://docs.aspose.com/slides/ko/androidjava/embedded-font/)이라고 합니다.

Aspose.Slides는 *오직* 출력 문서에만 적용되는 글꼴을 추가할 수 있게 해줍니다. 예를 들어, PDF 로 변환하려는 프레젠테이션에 시스템 및 내장 글꼴에 없는 글꼴이 포함되어 있다면, 필요한 글꼴을 **외부 글꼴**로 추가하거나 로드할 수 있습니다.

{{% alert title="Note" color="primary" %}} 
우리는 유료든 무료든 어떠한 글꼴도 배포하지 않습니다. 우리의 API는 외부 글꼴을 로드하고 문서에 포함시킬 수 있도록 허용하지만, 이는 사용자의 판단과 책임 하에 수행됩니다.
{{% /alert %}}

## **FAQ**

**변환 전에 프레젠테이션에서 실제로 사용된 글꼴을 어떻게 확인할 수 있나요?**

Aspose.Slides는 [font manager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/fontsmanager/)를 통해 사용된 글꼴을 검사할 수 있게 해주므로, [내장](/slides/ko/androidjava/embedded-font/), [대체](/slides/ko/androidjava/font-replacement/), 또는 [외부 소스](/slides/ko/androidjava/custom-font/)를 선택할 수 있습니다. 이를 통해 렌더링 및 내보내기 시 원치 않는 대체를 방지할 수 있습니다.

**운영 체제에 설치하지 않고 추가 글꼴 디렉터리를 등록할 수 있나요?**

예. 렌더링 및 내보내기를 위해 폴더나 메모리 스트림과 같은 [외부 글꼴 소스](/slides/ko/androidjava/custom-font/)를 등록할 수 있습니다. 이를 통해 호스트 시스템 글꼴에 대한 의존성을 없애고 레이아웃을 예측 가능하게 유지할 수 있습니다.

**글리프가 없을 때 부적절한 글꼴로 조용히 대체되는 것을 어떻게 방지할 수 있나요?**

사전에 명시적인 [글꼴 교체](/slides/ko/androidjava/font-replacement/) 및 글꼴 [대체 글꼴 규칙](/slides/ko/androidjava/fallback-font/)을 정의하십시오. 사용된 글꼴을 분석하고 대체 글꼴에 대한 우선순위를 제어함으로써 일관된 타이포그래피를 보장하고 예상치 못한 결과를 피할 수 있습니다.