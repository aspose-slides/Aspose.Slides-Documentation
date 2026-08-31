---
title: Open XML SDK는 왜 안 될까
type: docs
weight: 100
url: /ko/cpp/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- 비교
- 프레젠테이션 객체 모델
- 고품질 변환
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "무료 Open XML SDK보다 Aspose.Slides가 더 나은 선택인 이유를 확인하세요: 기능 비교, 자동 변환 없는 변환, PPT, PPTX 및 ODP에 대한 광범위한 지원."
---
## **개요**

이 문서는 개발자가 프레젠테이션 문서를 작업할 때 Open XML SDK 또는 Aspose.Slides를 선택할 수 있는 경우를 설명합니다. Open XML SDK는 OOXML 패키지와 해당 기반 XML 요소를 조작하기 위한 라이브러리로 설명되고, Aspose.Slides는 높은 수준의 객체 모델과 다양한 PowerPoint 관련 작업을 지원하는 프레젠테이션 처리 라이브러리로 소개됩니다.

이 문서는 지원 형식, 프로그래밍 모델, 렌더링, 플랫폼 지원 및 일반적인 사용 사례별로 두 옵션을 비교합니다. 또한 Open XML SDK가 기본적인 PPTX 작업이나 OOXML 요소에 직접 접근하는 경우에 적합할 수 있는 반면, Aspose.Slides는 여러 PowerPoint 형식 작업, 도형 복사 또는 클론, 텍스트 교체, 애니메이션 적용, 프레젠테이션을 PDF, TIFF 또는 XPS로 변환하는 등 복잡한 프레젠테이션 작업에 더 적합함을 명확히 합니다.

## **Open XML SDK란?**
우리는 종종 다음과 같은 질문을 듣습니다: 무료인 Open XML SDK 대신 왜 Aspose 제품을 사용해야 할까요? 이 질문은 기능과 기능성으로 쉽게 답할 수 있습니다. [MSDN 라이브러리](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)에 따르면 Open XML SDK는 다음과 같이 정의됩니다: Open XML SDK 2.0은 Open XML 패키지와 패키지 내의 기본 Open XML 스키마 요소를 조작하는 작업을 단순화합니다. Open XML SDK 2.0은 개발자가 Open XML 패키지에서 수행하는 많은 일반 작업을 캡슐화하므로 몇 줄의 코드만으로 복잡한 작업을 수행할 수 있습니다. OOXML 문서는 본질적으로 압축된 XML 파일이며 Open XML SDK는 OOXML 문서의 내용을 강력한 형식으로 작업할 수 있는 클래스 모음입니다. 이는 파일을 압축 해제하여 XML을 추출하고, 해당 XML을 DOM 트리로 로드한 뒤 XML 요소와 속성을 직접 다루는 대신, Open XML SDK가 이를 수행할 수 있는 클래스를 제공한다는 의미입니다.

## **Aspose.Slides란?**
Aspose.Slides는 애플리케이션이 다음과 같은 프레젠테이션 처리 작업을 수행하도록 허용하는 클래스 라이브러리입니다:

- **Presentation** 객체 모델을 이용한 프로그래밍.
- PDF 및 XPS를 포함한 모든 주요 지원 PowerPoint 프레젠테이션 형식 간의 고품질 변환.
- PNG, JPEG, BMP와 같은 널리 알려진 형식으로 슬라이드 썸네일을 생성하고 SVG로 슬라이드 내보내기 지원.
- 하나 또는 여러 문서를 결합하여 처음부터 프레젠테이션을 만들 수 있는 기능.
- 애니메이션, Ole 프레임, 표, 차트 생성 및 관리 지원.
- TextFrames, Paragraphs 및 Portions 수준에서 텍스트 서식을 관리하기 위한 광범위한 제어 기능 제공.  
자세한 기능 설명은 [Aspose.Slides 기능](/slides/ko/cpp/product-overview/)을 참조하십시오.

## **Open XML SDK와 Aspose.Slides 비교**
다음 표는 Open XML SDK와 Aspose.Slides의 기능을 비교합니다.

|**기능 또는 기능 카테고리**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Supported Presentations formats|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversion from PPT to PPTX|No|Yes|
|<p>고수준 프로그래밍을 위한 Presentation Document Object Model (DOM):</p><p>- 텍스트 찾기 및 교체.</p><p>- 프레젠테이션에서 슬라이드 조합.</p>|No|Yes|
|문서 객체 모델을 통한 상세 프로그래밍, TextHolders, TextFrames, Paragraphs 및 Portions와 같은 개별 요소와 서식에 대한 접근.|Yes|Yes|
|관계 식별자, OOXML 문서의 목록 식별자와 같은 기본 XML 요소 및 속성에 대한 저수준 직접 및 완전 접근.|Yes|No|
|<p>렌더링:</p><p>- 프레젠테이션을 PDF, PDF Notes, XPS, TIFF 이미지로 렌더링.</p><p>- 슬라이드 썸네일을 PNG, JPEG, BMP, SVG 및 TIFF로 렌더링.</p><p>- 이미지 해상도, 품질, 압축 및 기타 옵션 지정.</p>|No|Yes|

## **결론**
Open XML SDK와 Aspose.Slides는 매우 다른 요구와 대상을 다루기 때문에 정면 대결을 하지 않습니다. Open XML SDK는 OOXML 문서를 강력히 형식화된 방식으로 작업할 수 있게 해 주는 클래스 라이브러리이며, Aspose.Slides는 거의 모든 Microsoft PowerPoint 파일 형식을 광범위하게 지원하는 매우 유용한 프레젠테이션 처리 라이브러리입니다. 만약 여러분이 PPTX 문서에 대해 비교적 기본적인 프로그래밍 작업만 수행하면 된다면 Open XML SDK가 적절한 선택일 수 있습니다. Open XML SDK를 사용하면 간단한 PPTX 문서를 생성하거나 주석, 머리글/바닥글 제거, 이미지 추출 등 간단한 작업을 충분히 편리하게 수행할 수 있습니다. 일부 작업은 Open XML SDK로 달성할 수 있지만 Aspose.Slides에서는 달성할 수 없습니다. 예를 들어 OOXML 문서의 XML 요소와 속성에 직접 접근해야 한다면 Open XML SDK를 사용해야 합니다. 그러나 문서에 대해 다음과 같은 복합 작업을 수행해야 한다면 Aspose.Slides가 최선의 옵션입니다:

- PPTX 외에 이전 PowerPoint 형식도 지원.
- 슬라이드 내 도형을 복사하거나 클론하여 객체, 스타일 및 기타 서식을 적절히 결합.
- 서식이 있든 없든 텍스트 교체.
- 애니메이션 적용 및 도형 연결자 사용.
- 문서를 PDF 또는 XPS로 변환하여 Microsoft PowerPoint와 동일하게 표시.
- 데스크톱 및 콘솔 기반 환경 모두에서 C++ 애플리케이션 개발.