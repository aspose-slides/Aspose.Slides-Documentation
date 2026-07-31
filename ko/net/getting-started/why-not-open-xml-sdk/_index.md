---
title: 왜 Open XML SDK가 아닌가
type: docs
weight: 50
url: /ko/net/why-not-open-xml-sdk/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/open-xml-sdk/
keywords:
- Open XML SDK
- 비교
- 프레젠테이션 객체 모델
- 고품질 변환
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "무료 Open XML SDK보다 Aspose.Slides가 더 나은 선택인 이유를 확인하십시오: 기능 비교, 자동 변환 없는 변환 및 PPT, PPTX와 ODP에 대한 폭넓은 지원을 제공합니다."
---
## **개요**

이 문서는 개발자가 프레젠테이션 문서를 작업할 때 Open XML SDK와 Aspose.Slides 중 어느 것을 선택할지에 대한 기준을 설명합니다. Open XML SDK는 OOXML 패키지와 그 내부 XML 요소를 조작하는 라이브러리로 설명하고, Aspose.Slides는 고수준 객체 모델과 다양한 PowerPoint 관련 작업을 지원하는 프레젠테이션 처리 라이브러리로 소개합니다.

이 문서는 지원 형식, 프로그래밍 모델, 렌더링 및 인쇄 기능, 플랫폼 지원, 일반 사용 사례 등을 기준으로 두 옵션을 비교합니다. 또한 Open XML SDK는 기본적인 PPTX 작업이나 OOXML 요소에 직접 접근할 때 적합할 수 있고, Aspose.Slides는 여러 PowerPoint 형식 작업, 도형 복제·클론, 텍스트 교체, 애니메이션 적용, 프레젠테이션을 PDF, TIFF, XPS 등으로 변환하는 복잡한 작업에 더 적합하다는 점을 명확히 합니다.

## **Open XML SDK란?**
때때로 다음과 같은 질문을 받습니다: *무료 Open XML SDK보다 Aspose 제품을 사용해야 하는 이유는 무엇인가요?* 

우리는 이 질문에 기능과 활용 측면에서 쉽게 답변할 수 있습니다.

[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) 에 따르면 Open XML SDK는 다음과 같이 정의됩니다:

> "Open XML SDK 2.0은 Open XML 패키지와 패키지 내부의 Open XML 스키마 요소를 조작하는 작업을 단순화합니다. Open XML SDK 2.0은 개발자가 Open XML 패키지에서 수행하는 많은 일반 작업을 캡슐화하여 몇 줄의 코드만으로 복잡한 작업을 수행할 수 있도록 합니다. OOXML 문서는 본질적으로 압축된 XML 파일이며 Open XML SDK는 OOXML 문서의 내용을 강형식으로 작업할 수 있는 클래스 컬렉션입니다. 즉 파일을 압축 해제하여 XML을 추출하고, 그 XML을 DOM 트리로 로드한 뒤 XML 요소와 속성을 직접 다루는 대신, Open XML SDK가 이를 수행할 클래스를 제공합니다."

## **Aspose.Slides란?**
Aspose.Slides는 애플리케이션이 다음과 같은 프레젠테이션 처리 작업을 수행하도록 하는 클래스 라이브러리입니다:

- 프레젠테이션 객체 모델을 활용한 프로그래밍.
- PDF, XPS, TIFF 변환 및 인쇄를 포함한 모든 인기 PowerPoint 프레젠테이션 형식에 대한 고품질 변환.
- PNG, JPEG, BMP 등 잘 알려진 형식으로 슬라이드 썸네일을 생성하고 SVG로 슬라이드 내보내기.
- 하나 또는 여러 문서의 요소를 결합하거나 처음부터 프레젠테이션을 작성.
- 애니메이션, OLE 프레임, 표, 차트 생성 및 관리.
- TextFrames, Paragraphs 및 Portions 수준에서 텍스트 서식을 광범위하게 제어 및 관리.

사용 가능한 기능에 대한 자세한 내용은 [Aspose.Slides Features](/slides/ko/net/product-overview/) 페이지를 참조하십시오.

## **Open XML SDK와 Aspose.Slides 비교**
아래 표는 Open XML SDK와 Aspose.Slides의 기능 및 특징을 비교합니다.

|**기능 또는 기능 카테고리**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|지원 프레젠테이션 형식|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT를 PPTX로 변환|No|Yes|
|<p>프레젠테이션 문서 객체 모델(DOM)을 이용한 고수준 프로그래밍:</p><p>- 텍스트 찾기 및 교체.</p><p>- 프레젠테이션 내 슬라이드 조합.</p>|No|Yes|
|문서 객체 모델을 이용한 상세 프로그래밍; TextHolders, TextFrames, Paragraphs 및 Portions와 같은 개별 요소와 서식에 접근.|Yes|Yes|
|OOXML 문서의 관계 식별자, 목록 식별자 등 기본 XML 요소와 속성에 대한 저수준 직접 및 완전 접근.|Yes|No|
|<p>렌더링 및 인쇄:</p><p>- 프레젠테이션을 PDF, PDF Notes, XPS, TIFF 이미지로 렌더링.</p><p>- 슬라이드 썸네일을 PNG, JPEG, BMP, SVG 및 TIFF로 렌더링.</p><p>- 이미지 해상도, 품질, 압축 및 기타 옵션 지정.</p><p>- .NET 인쇄 인프라를 사용해 프레젠테이션 인쇄. 구성 요소는 MS PowerPoint 인쇄 미리보기와 동일하게 인쇄하는 내장 메서드를 제공.</p>|No|Yes|
|지원 플랫폼|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **결론**
Open XML SDK와 Aspose.Slides는 직접적인 경쟁 관계에 있지 않으며, 서로 매우 다른 요구를 충족하고 대상 사용자가 다릅니다.

{{% alert color="primary" %}} 

Open XML SDK는 OOXML 문서를 강형식으로 작업할 수 있는 클래스 라이브러리이고, Aspose.Slides는 거의 모든 Microsoft PowerPoint 파일 형식을 지원하는 매우 유용한 프레젠테이션 처리 라이브러리입니다. 

{{% /alert %}} 

워크플로가 PPTX 문서에 대한 기본 프로그래밍 작업이라면 Open XML SDK가 좋은 선택이 될 수 있습니다. Open XML SDK를 사용하면 간단한 PPTX 문서 생성, 주석·머리글/바닥글 제거, 이미지 추출 등 단순 작업을 편하게 수행할 수 있습니다. 특정 작업은 Open XML SDK로 수행할 수 있지만 Aspose.Slides에서는 수행할 수 없습니다. 예를 들어 OOXML 문서의 XML 요소와 속성에 직접 접근해야 한다면 Open XML SDK를 사용해야 합니다.

문서에 대해 복잡한 작업을 수행해야 할 경우—아래 목록에 있는 작업과 같이—Aspose.Slides가 최적의 선택입니다.

- 이전 PowerPoint 형식(및 PPTX)과 관련된 작업.
- 슬라이드 내 도형을 복제·클론하면서 객체, 스타일, 기타 서식 요소를 적절히 결합하는 작업.
- 서식이 있든 없든 텍스트 교체.
- 애니메이션 적용 및 도형 연결자 사용.
- 문서를 PDF, TIFF 또는 XPS로 변환하여 Microsoft PowerPoint와 동일한 결과를 얻는 작업.
- 데스크톱 및 웹 기반 환경 모두에서 .NET 또는 Java 애플리케이션 개발.