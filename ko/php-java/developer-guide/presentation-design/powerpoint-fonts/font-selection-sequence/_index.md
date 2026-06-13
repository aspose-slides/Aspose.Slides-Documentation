---
title: Aspose.Slides for PHP에서 폰트 선택 순서
linktitle: 폰트 선택
type: docs
weight: 80
url: /ko/php-java/font-selection-sequence/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java이 폰트를 선택하는 방법을 알아보고, PPT, PPTX 및 ODP 파일을 선명하고 일관되게 표시하도록 하여 슬라이드를 지금 개선하세요."
---
## **개요**

프레젠테이션이 로드되거나 렌더링되거나 다른 형식으로 변환될 때, Aspose.Slides는 프레젠테이션에 사용된 글꼴이 운영 체제에 존재하는지 확인합니다. 필요한 글꼴이 없으면 Aspose.Slides는 PowerPoint가 사용할 글꼴에 최대한 가깝게 대체 글꼴을 선택합니다.

Aspose.Slides는 먼저 선택된 글꼴을 운영 체제에서 검색합니다. 글꼴이 발견되면 사용됩니다. 발견되지 않으면 적절한 대체 글꼴이 적용됩니다. `FontSubstRule`을 통해 글꼴 대체 규칙이 정의된 경우 해당 규칙도 고려됩니다.

응용 프로그램 실행 중에 글꼴을 추가하거나, 프레젠테이션에 포함된 글꼴을 사용하거나, PDF 파일과 같은 출력 문서용 외부 글꼴을 로드할 수도 있습니다.

## **글꼴 선택**

프레젠테이션이 로드, 렌더링 또는 다른 형식으로 변환될 때 프레젠테이션의 글꼴에 특정 규칙이 적용됩니다. 예를 들어, 프레젠테이션(슬라이드)을 이미지로 변환하려고 할 때, 선택된 글꼴이 운영 체제에 존재하는지 확인하기 위해 프레젠테이션의 글꼴이 검사됩니다. 글꼴이 없다고 확인되면 대체됩니다—[**Font Replacement**](https://docs.aspose.com/slides/ko/php-java/font-replacement/) 및 [**Font Substitution**](https://docs.aspose.com/slides/ko/php-java/font-substitution/)를 참조하세요.

Aspose.Slides가 글꼴을 처리할 때 따라가는 절차는 다음과 같습니다:

1. Aspose.Slides는 운영 체제에서 프레젠테이션이 선택한 글꼴과 일치하는 글꼴을 찾기 위해 검색합니다.  
2. 선택한 글꼴이 발견되면 Aspose.Slides가 사용합니다. 그렇지 않으면 Aspose.Slides는 PowerPoint가 사용할 글꼴에 최대한 가깝게 대체 글꼴을 사용합니다.  
3. 글꼴 대체 규칙이 [FontSubstRule](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsubstrule/)를 통해 설정된 경우 적용됩니다.

Aspose.Slides를 사용하면 Aspose 런타임에 글꼴을 추가하고 해당 글꼴을 사용할 수 있습니다. [**Custom fonts**](https://docs.aspose.com/slides/ko/php-java/custom-font/)를 참조하세요.

프레젠테이션에 추가 글꼴을 포함하면 이를 [**Embedded fonts**](https://docs.aspose.com/slides/ko/php-java/embedded-font/)라고 합니다.

Aspose.Slides를 사용하면 *오직* 출력 문서에만 적용되는 글꼴을 추가할 수 있습니다. 예를 들어, PDF로 변환하려는 프레젠테이션에 시스템 및 포함된 글꼴에 없는 글꼴이 포함되어 있다면 필요한 글꼴을 **External fonts**로 추가하거나 로드할 수 있습니다.

## **FAQ**

**변환 전에 프레젠테이션에서 실제로 사용되는 글꼴을 어떻게 확인할 수 있나요?**

Aspose.Slides는 [font manager](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/)를 통해 사용된 글꼴을 검사할 수 있게 하여, [embed](/slides/ko/php-java/embedded-font/), [replace](/slides/ko/php-java/font-replacement/), 또는 [external sources](/slides/ko/php-java/custom-font/) 중 무엇을 할지 결정할 수 있게 합니다. 이는 렌더링 및 내보내기 시 원하지 않는 대체를 방지하는 데 도움이 됩니다.

**운영 체제에 설치하지 않고 추가 글꼴 디렉터리를 추가할 수 있나요?**

예. 렌더링 및 내보내기를 위해 폴더나 메모리 스트림과 같은 [external font sources](/slides/ko/php-java/custom-font/)를 등록할 수 있습니다. 이를 통해 호스트 시스템 글꼴에 대한 종속성이 사라지고 레이아웃이 예측 가능하게 유지됩니다.

**글리프가 없을 때 부적절한 글꼴로 조용히 대체되는 것을 어떻게 방지할 수 있나요?**

미리 명시적인 [font replacement](/slides/ko/php-java/font-replacement/) 및 글꼴 [fallback rules](/slides/ko/php-java/fallback-font/)를 정의하십시오. 사용된 글꼴을 분석하고 대체 글꼴에 대한 제어된 우선 순위를 설정함으로써 일관된 타이포그래피를 보장하고 예상치 못한 결과를 방지할 수 있습니다.