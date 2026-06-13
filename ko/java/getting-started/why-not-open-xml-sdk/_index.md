---
title: Open XML SDK가 아닌 이유
type: docs
weight: 120
url: /ko/java/why-not-open-xml-sdk/
keywords:
- Open XML SDK
- 비교
- 프레젠테이션 객체 모델
- 고품질 변환
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "무료 Open XML SDK보다 Aspose.Slides가 더 나은 선택인 이유를 확인해 보세요: 기능 비교, 자동화 없는 변환, 그리고 PPT, PPTX 및 ODP에 대한 광범위한 지원을 제공합니다."
---
## **개요**

이 문서는 개발자가 프레젠테이션 문서를 작업할 때 Open XML SDK 또는 Aspose.Slides 중 어떤 것을 선택할 수 있는지 설명합니다. 여기서는 Open XML SDK를 OOXML 패키지와 그 기반 XML 요소를 조작하기 위한 라이브러리로 설명하고, Aspose.Slides를 고수준 객체 모델을 제공하고 다양한 PowerPoint 관련 작업을 지원하는 프레젠테이션 처리 라이브러리로 소개합니다.

두 옵션을 지원 형식, 프로그래밍 모델, 렌더링 및 인쇄 기능, 플랫폼 지원, 일반적인 사용 사례 측면에서 비교합니다. 또한 Open XML SDK는 기본적인 PPTX 작업이나 OOXML 요소에 직접 접근하는 경우에 적합할 수 있으며, Aspose.Slides는 여러 PowerPoint 형식 작업, 모양 복제 또는 클론, 텍스트 교체, 애니메이션 적용, 프레젠테이션을 PDF, TIFF, XPS 등으로 변환하는 복잡한 프레젠테이션 작업에 더 적합함을 명확히 합니다.

## **Open XML SDK란?**
[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)에 따르면, Open XML SDK는 다음과 같이 정의됩니다.

Open XML SDK 2.0은 Open XML 패키지와 패키지 내 기본 Open XML 스키마 요소를 조작하는 작업을 단순화합니다. Open XML SDK 2.0은 개발자가 Open XML 패키지에서 수행하는 많은 일반 작업을 캡슐화하므로 몇 줄의 코드만으로 복잡한 작업을 수행할 수 있습니다.

OOXML 문서는 본질적으로 압축된 XML 파일이며, Open XML SDK는 OOXML 문서의 내용을 강력히 타입화된 방식으로 작업할 수 있게 해 주는 클래스 모음입니다. 즉 파일을 압축 해제하여 XML을 추출하고, 해당 XML을 DOM 트리로 로드한 뒤 XML 요소와 속성을 직접 다루는 대신, Open XML SDK가 이를 수행하는 클래스를 제공합니다.

## **Aspose.Slides란?**
Aspose.Slides는 애플리케이션이 다음과 같은 프레젠테이션 처리 작업을 수행하도록 하는 클래스 라이브러리입니다.

- **Presentation** 객체 모델을 사용한 프로그래밍.
- PDF, XPS, TIFF 등 모든 주요 PowerPoint 프레젠테이션 형식 간 고품질 변환.
- PNG, JPEG, BMP 등 잘 알려진 형식 및 SVG로 슬라이드 썸네일 생성.
- 하나 또는 여러 문서를 결합하여 프레젠테이션을 처음부터 구축.
- 애니메이션, Ole 프레임, 표 추가 및 차트 생성·관리 지원.
- TextFrames, Paragraphs, Portions 수준에서 텍스트 서식을 세밀하게 제어할 수 있는 광범위한 기능 제공.

지원되는 기능에 대한 자세한 내용은 [Aspose.Slides Features](/slides/ko/java/product-overview/)를 참조하십시오.

## **Open XML SDK와 Aspose.Slides 비교**
{{% alert color="primary" %}} 

다음 표는 Open XML SDK와 Aspose.Slides의 기능을 비교합니다.

{{% /alert %}} 

|**기능 또는 기능 카테고리**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|지원되는 프레젠테이션 형식|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT에서 PPTX로 변환|No|Yes|
|<p>프레젠테이션 문서 객체 모델(DOM)을 사용한 고수준 프로그래밍:</p><p>- 텍스트 찾기 및 교체.</p><p>- 프레젠테이션에서 슬라이드 조합.</p>|No|Yes|
|문서 객체 모델을 통한 상세 프로그래밍, TextHolders, TextFrames, Paragraphs, Portions와 같은 개별 요소 및 서식에 접근.|Yes|Yes|
|XML 요소와 속성(관계 식별자, OOXML 문서의 목록 식별자 등)에 대한 저수준 직접 및 전체 접근.|Yes|No|
|<p>렌더링:</p><p>- 프레젠테이션을 PDF, PDF Notes, XPS, TIFF 이미지로 렌더링.</p><p>- 슬라이드 썸네일을 PNG, JPEG, BMP, SVG, TIFF 형식으로 렌더링.</p><p>- 이미지 해상도, 품질, 압축 및 기타 옵션 지정.</p>|No|Yes|
|지원 플랫폼|Windows, .NET|Windows, Linux,UNIX, MAC, Java, PHP, Mono|

## **결론**
{{% alert color="primary" %}} 

Open XML SDK와 Aspose.Slides는 완전히 다른 요구와 청중을 대상으로 하기 때문에 직접적인 경쟁 관계에 있지 않습니다. Open XML SDK는 OOXML 문서를 강력히 타입화된 방식으로 작업하기 위한 클래스 라이브러리이며, Aspose.Slides는 거의 모든 Microsoft PowerPoint 파일 형식을 지원하는 매우 유용한 프레젠테이션 처리 라이브러리입니다.

만약 여러분이 PPTX 문서에 대해 비교적 기본적인 프로그래밍 작업만 수행하면 된다면 Open XML SDK가 적합한 선택일 수 있습니다. Open XML SDK를 사용하면 간단한 PPTX 문서 생성, 주석·머리글/바닥글 제거, 이미지 추출 등 간단한 작업을 편리하게 수행할 수 있습니다. 일부 작업은 Open XML SDK로 가능하지만 Aspose.Slides로는 불가능합니다. 예를 들어 OOXML 문서의 XML 요소와 속성에 직접 접근해야 한다면 Open XML SDK를 사용해야 합니다. 그러나 문서에 대해 다음과 같은 복잡한 작업을 수행해야 한다면 Aspose.Slides가 최선의 옵션입니다.

- PPTX 외에 이전 PowerPoint 형식도 지원.
- 슬라이드 내 모양을 복제하거나 클론하여 객체, 스타일 및 서식을 적절히 결합.
- 서식이 있든 없든 텍스트 교체.
- 애니메이션 적용 및 모양 간 커넥터 사용.
- 문서를 PDF, TIFF 또는 XPS로 변환하여 Microsoft PowerPoint와 동일하게 표시.
- 데스크톱 및 웹 기반 환경에서 .NET 또는 Java 애플리케이션 개발.

{{% /alert %}}