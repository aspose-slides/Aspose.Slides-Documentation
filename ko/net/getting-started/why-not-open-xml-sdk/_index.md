---
title: Open XML SDK를 사용하지 않는 이유
type: docs
weight: 180
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
description: "무료 Open XML SDK보다 Aspose.Slides가 더 나은 선택인 이유를 확인하십시오: 기능 비교, 자동화 없는 변환, PPT, PPTX 및 ODP에 대한 폭넓은 지원."
---
## **개요**

이 문서는 개발자가 프레젠테이션 문서 작업을 위해 Open XML SDK와 Aspose.Slides 중 어느 것을 선택할 수 있는지를 설명합니다. Open XML SDK는 OOXML 패키지와 그 안의 XML 요소를 조작하기 위한 라이브러리로, Aspose.Slides는 높은 수준의 객체 모델과 다양한 PowerPoint 관련 작업을 지원하는 프레젠테이션 처리 라이브러리로 소개됩니다.

이 문서는 지원 형식, 프로그래밍 모델, 렌더링, 플랫폼 지원 및 일반적인 사용 사례 측면에서 두 옵션을 비교합니다. 또한 Open XML SDK가 기본적인 PPTX 작업이나 OOXML 요소에 직접 접근하는 경우에 적합할 수 있는 반면, Aspose.Slides는 여러 PowerPoint 형식 작업, 도형 복사·클론, 텍스트 교체, 애니메이션 적용, 프레젠테이션을 PDF, TIFF, XPS 등으로 변환하는 복잡한 작업에 더 적합함을 명확히 합니다.

## **Open XML SDK란?**
때때로 다음과 같은 질문을 받습니다: *왜 무료인 Open XML SDK 대신 Aspose 제품을 사용해야 할까요?*

우리는 기능과 차별성을 기준으로 이 질문에 답하기 쉽습니다.

[MSDN Library](https://learn.microsoft.com/en-us/office/open-xml/open-xml-sdk)에 따르면 Open XML SDK는 다음과 같이 정의됩니다:

> "Open XML SDK 2.0은 Open XML 패키지와 패키지 내의 기본 Open XML 스키마 요소를 조작하는 작업을 단순화합니다. Open XML SDK 2.0은 개발자가 Open XML 패키지에서 수행하는 많은 일반 작업을 캡슐화하여 몇 줄의 코드만으로 복잡한 작업을 수행할 수 있도록 합니다. OOXML 문서는 본질적으로 압축된 XML 파일이며 Open XML SDK는 OOXML 문서의 내용을 강력한 형식으로 작업할 수 있게 해 주는 클래스 모음입니다. 즉 파일을 압축 해제해 XML을 추출하고 DOM 트리로 로드한 뒤 XML 요소와 속성을 직접 다루는 대신, Open XML SDK가 그 작업을 수행하는 클래스를 제공합니다."

## **Aspose.Slides란?**
Aspose.Slides는 애플리케이션이 다음과 같은 프레젠테이션 처리 작업을 수행하도록 하는 클래스 라이브러리입니다:

- 프레젠테이션 객체 모델을 이용한 프로그래밍.
- PDF, XPS, TIFF 등 모든 주요 PowerPoint 형식에 대한 고품질 변환.
- PNG, JPEG, BMP와 같은 잘 알려진 형식으로 슬라이드 썸네일 생성 및 SVG로 슬라이드 내보내기.
- 하나 이상의 문서에서 요소를 결합하거나 처음부터 프레젠테이션을 작성.
- 애니메이션, OLE 프레임, 테이블 추가 및 차트 생성·관리.
- TextFrames, Paragraphs 및 Portions 수준에서 텍스트 서식을 광범위하게 제어·관리.

사용 가능한 기능에 대한 자세한 내용은 [Aspose.Slides Features](/slides/ko/net/product-overview/) 페이지를 참조하십시오.

## **Open XML SDK와 Aspose.Slides 비교**
다음 표는 Open XML SDK 기능과 Aspose.Slides 기능을 비교합니다.

|**기능 또는 기능 카테고리**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|지원 프레젠테이션 형식|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT → PPTX 변환|No|Yes|
|<p>프레젠테이션 문서 객체 모델(DOM)을 통한 고수준 프로그래밍:</p><p>- 텍스트 찾기 및 교체.</p><p>- 프레젠테이션에서 슬라이드 조합.</p>|No|Yes|
|문서 객체 모델을 통한 세부 프로그래밍; TextHolders, TextFrames, Paragraphs, Portions와 같은 개별 요소 및 서식에 접근.|Yes|Yes|
|관계 식별자, OOXML 문서의 목록 식별자 등 기본 XML 요소 및 속성에 대한 저수준 직접 전체 접근.|Yes|No|
|<p>프레젠테이션 렌더링:</p><p>- PDF, PDF Notes, XPS, TIFF 이미지로 렌더링.</p><p>- PNG, JPEG, BMP, SVG, TIFF 형식으로 슬라이드 썸네일 렌더링.</p><p>- 이미지 해상도, 품질, 압축 및 기타 옵션 지정.</p>|No|Yes|
|지원 플랫폼|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **결론**
Open XML SDK와 Aspose.Slides는 직접적인 경쟁 관계가 아니며, 서로 매우 다른 요구를 충족하고 대상 고객도 다릅니다.

{{% alert color="info" title="Note" %}}
Open XML SDK는 OOXML 문서를 강력한 형식으로 작업할 수 있게 해 주는 클래스 라이브러리이며, Aspose.Slides는 거의 모든 Microsoft PowerPoint 파일 형식을 폭넓게 지원하는 매우 유용한 프레젠테이션 처리 라이브러리입니다.
{{% /alert %}}

워크플로가 PPTX 문서에 대한 기본적인 프로그래밍 작업이면 Open XML SDK가 좋은 선택일 수 있습니다. Open XML SDK를 사용하면 간단한 PPTX 문서 생성, 주석·머리글/바닥글 제거, 이미지 추출 등 간단한 작업을 편하게 수행할 수 있습니다. 특정 작업은 Open XML SDK로 수행할 수 있지만 Aspose.Slides로는 수행할 수 없습니다. 예를 들어 OOXML 문서의 XML 요소와 속성에 직접 접근해야 한다면 Open XML SDK를 사용해야 합니다.

문서에서 복잡한 작업을 수행해야 하는 경우(아래 목록과 같은 작업) Aspose.Slides가 최선의 선택입니다.

- 이전 PowerPoint 형식(및 PPTX 포함) 작업.
- 슬라이드 내 도형을 복사·클론하면서 객체, 스타일 및 기타 서식 요소를 적절히 결합.
- 서식이 있거나 없는 텍스트 교체.
- 애니메이션 적용 및 도형 연결자 사용.
- 문서를 PDF, TIFF, XPS로 변환해 Microsoft PowerPoint와 동일한 결과 얻기.
- 데스크톱 및 웹 기반 환경 모두에서 .NET 또는 Java 애플리케이션 개발.