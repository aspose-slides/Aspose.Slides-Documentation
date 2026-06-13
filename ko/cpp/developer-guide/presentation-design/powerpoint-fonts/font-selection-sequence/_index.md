---
title: Aspose.Slides for С++에서 폰트 선택 순서
linktitle: 폰트 선택
type: docs
weight: 80
url: /ko/cpp/font-selection-sequence/
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
- С++
- Aspose.Slides
description: "Aspose.Slides for С++가 폰트를 선택하는 방식을 확인하고, PPT, PPTX 및 ODP 파일을 선명하고 일관되게 표시합니다—지금 슬라이드를 개선하세요."
---
## **개요**

프레젠테이션이 로드되거나 렌더링되거나 다른 형식으로 변환될 때, Aspose.Slides는 프레젠테이션에 사용된 폰트가 운영 체제에 있는지 확인합니다. 필요한 폰트가 누락된 경우, Aspose.Slides는 PowerPoint가 사용할 폰트와 최대한 유사한 대체 폰트를 선택합니다.

Aspose.Slides는 먼저 운영 체제에서 선택된 폰트를 검색합니다. 폰트가 발견되면 사용됩니다. 발견되지 않으면 적절한 대체 폰트가 적용됩니다. `FontSubstRule`을 통해 폰트 대체 규칙이 정의된 경우 해당 규칙도 고려됩니다.

응용 프로그램 실행 중에 폰트를 추가하거나, 프레젠테이션에 포함된 폰트를 사용하거나, PDF 파일과 같은 출력 문서에 외부 폰트를 로드할 수도 있습니다.

## **폰트 선택**

프레젠테이션이 로드되거나 렌더링되거나 다른 형식으로 변환될 때 폰트에 적용되는 특정 규칙이 있습니다. 예를 들어 프레젠테이션(슬라이드)을 이미지로 변환하려고 할 때, 프레젠테이션의 폰트를 확인하여 선택된 폰트가 운영 체제에 존재하는지 검증합니다. 폰트가 누락된 것으로 확인되면 교체됩니다 — [**폰트 교체**](https://docs.aspose.com/slides/ko/cpp/font-replacement/) 및 [**폰트 대체**](https://docs.aspose.com/slides/ko/cpp/font-substitution/)를 참조하세요.

Aspose.Slides가 폰트를 처리할 때 따르는 절차는 다음과 같습니다:

1. Aspose.Slides는 운영 체제에서 폰트를 검색하여 프레젠테이션에서 선택된 폰트와 일치하는 폰트를 찾습니다. 
2. 선택된 폰트가 발견되면 Aspose.Slides가 이를 사용합니다. 그렇지 않으면 Aspose.Slides가 PowerPoint가 사용할 폰트와 가능한 한 가깝게 대체 폰트를 사용합니다.
3. [FontSubstRule](https://reference.aspose.com/slides/ko/cpp/aspose.slides/fontsubstrule/)을 통해 폰트 교체 규칙이 설정된 경우 적용됩니다. 

Aspose.Slides는 애플리케이션 실행 중에 폰트를 추가하고 해당 폰트를 사용할 수 있도록 허용합니다. 자세한 내용은 [**사용자 지정 폰트**](https://docs.aspose.com/slides/ko/cpp/custom-font/)를 참조하세요. 

프레젠테이션에 추가 폰트를 포함시키면 이를 [**내장 폰트**](https://docs.aspose.com/slides/ko/cpp/embedded-font/)라고 합니다.

Aspose.Slides는 *only* 출력 문서에 적용되는 폰트를 추가할 수 있게 해줍니다. 예를 들어 PDF로 변환하려는 프레젠테이션에 시스템 및 내장 폰트에 없는 폰트가 포함되어 있으면, 필요한 폰트를 **외부 폰트**로 추가하거나 로드할 수 있습니다. 

{{% alert title="Note" color="primary" %}} 
우리는 유료든 무료든 어떠한 폰트도 배포하지 않습니다. 우리의 API를 통해 외부 폰트를 로드하고 문서에 삽입할 수 있지만, 폰트 사용은 전적으로 귀하의 재량과 책임 하에 이루어집니다.
{{% /alert %}}

## **FAQ**

**프레젠테이션을 변환하기 전에 실제로 사용되는 폰트를 어떻게 파악할 수 있나요?**  

Aspose.Slides는 [font manager](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/get_fontsmanager/)를 통해 사용된 폰트를 검사할 수 있게 해 주므로, [embed](/slides/ko/cpp/embedded-font/), [replace](/slides/ko/cpp/font-replacement/), 혹은 [external sources](/slides/ko/cpp/custom-font/) 중 어떤 작업을 수행할지 결정할 수 있습니다. 이를 통해 렌더링 및 내보내기 중 원하지 않는 대체를 방지할 수 있습니다.

**운영 체제에 설치하지 않고 추가 폰트 디렉터리를 등록할 수 있나요?**  

예. [external font sources](/slides/ko/cpp/custom-font/)를 폴더나 메모리 스트림 형태로 등록하여 렌더링 및 내보내기에 사용할 수 있습니다. 이렇게 하면 호스트 시스템 폰트에 대한 종속성을 없애고 레이아웃을 예측 가능하게 유지할 수 있습니다.

**문자가 누락된 경우 부적절한 폰트로 자동 폴백되는 것을 어떻게 방지할 수 있나요?**  

미리 명시적인 [font replacement](/slides/ko/cpp/font-replacement/) 및 폰트 [fallBack rules](/slides/ko/cpp/fallback-font/)를 정의하십시오. 사용된 폰트를 분석하고 대체 폰트에 대한 우선 순위를 제어함으로써 일관된 타이포그래피를 유지하고 예기치 않은 결과를 방지할 수 있습니다.