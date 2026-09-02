---
title: 왜 Open XML SDK가 아닐까
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
description: "Aspose.Slides가 무료 Open XML SDK보다 더 나은 선택인 이유를 확인하세요: 기능 비교, 자동 변환 없는 변환, PPT, PPTX 및 ODP에 대한 폭넓은 지원."
---
## **Overview**

이 문서는 개발자가 프레젠테이션 문서를 작업할 때 Open XML SDK와 Aspose.Slides 중 어느 것을 선택할 수 있는지 설명합니다. Open XML SDK는 OOXML 패키지와 그 안에 포함된 XML 요소를 조작하기 위한 라이브러리로 소개되고, Aspose.Slides는 고수준 객체 모델을 제공하고 다양한 PowerPoint 관련 작업을 지원하는 프레젠테이션 처리 라이브러리로 제시됩니다.

이 문서는 지원되는 형식, 프로그래밍 모델, 렌더링, 플랫폼 지원 및 일반적인 사용 사례 측면에서 두 옵션을 비교합니다. 또한 Open XML SDK가 기본적인 PPTX 작업이나 OOXML 요소에 직접 접근하는 경우에 적합할 수 있는 반면, Aspose.Slides는 여러 PowerPoint 형식 작업, 모양 복제 또는 클론, 텍스트 교체, 애니메이션 적용, 프레젠테이션을 PDF, TIFF, XPS로 변환하는 등 복잡한 프레젠테이션 작업에 더 적합함을 명확히 합니다.

## **What Is Open XML SDK?**
때때로 다음과 같은 질문을 받습니다: *왜 무료 Open XML SDK 대신 Aspose 제품을 사용해야 할까요?* 

이 질문에 대해 기능과 기능성 면에서 답하기가 쉽습니다. 

[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk) 에 따르면 Open XML SDK는 다음과 같이 정의됩니다: 

> "Open XML SDK 2.0은 Open XML 패키지와 패키지 내의 기본 Open XML 스키마 요소를 조작하는 작업을 단순화합니다. Open XML SDK 2.0은 개발자가 Open XML 패키지에서 수행하는 일반적인 작업을 많이 캡슐화하여 몇 줄의 코드만으로 복잡한 작업을 수행할 수 있도록 합니다. OOXML 문서는 본질적으로 압축된 XML 파일이며 Open XML SDK는 OOXML 문서의 콘텐츠를 강력히 형식화된 방식으로 작업할 수 있게 해주는 클래스 모음입니다. 즉 파일을 압축 해제해 XML을 추출하고, 그 XML을 DOM 트리로 로드한 뒤 XML 요소와 속성을 직접 다루는 대신, Open XML SDK가 이를 수행하는 클래스를 제공합니다."

## **What Is Aspose.Slides?**
Aspose.Slides는 애플리케이션이 다음과 같은 프레젠테이션 처리 작업을 수행하도록 허용하는 클래스 라이브러리입니다: 

- 프레젠테이션 객체 모델을 사용한 프로그래밍.

- PDF, XPS, TIFF 등 모든 인기 있는 PowerPoint 프레젠테이션 형식에 대한 고품질 변환.

- PNG, JPEG, BMP와 같은 잘 알려진 형식으로 슬라이드 썸네일을 생성하고 SVG로 슬라이드를 내보내기.

- 하나 또는 여러 문서의 요소를 결합하여 프레젠테이션을 처음부터 만들기.

- 애니메이션, OLE 프레임, 표 추가 및 차트 생성·관리.

- TextFrames, Paragraphs 및 Portions 수준에서 텍스트 서식을 광범위하게 제어·관리.

  사용 가능한 기능에 대한 자세한 내용은 [Aspose.Slides Features](/slides/ko/net/product-overview/) 페이지를 참조하십시오.

## **Compare Open XML SDK with Aspose.Slides**
다음 표는 Open XML SDK와 Aspose.Slides의 기능 및 특징을 비교합니다.

|**Feature or Feature Category**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|Supported presentations formats|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|Conversion from PPT to PPTX |No|Yes|
|<p>High-level programming with a Presentation Document Object Model (DOM): </p><p>- Find and replace texts.</p><p>- Assemble slides in presentations.</p>|No|Yes|
|Detailed programming with a document object model; access to individual elements and formatting such as TextHolders, TextFrames, Paragraphs and Portions.|Yes|Yes|
|Low-level direct and full access to the underlying XML elements and attributes such as relationship identifiers, list identifiers of an OOXML document.|Yes|No|
|<p>Presentation Rendering:</p><p>- Render presentations to PDF, PDF Notes, XPS, TIFF images.</p><p>- Render slide thumbnails to PNG, JPEG, BMP, SVG and TIFF.</p><p>- Specify image resolution, quality, compression and other options.</p>|No|Yes|
|Supported platforms|Windows, .NET|Windows, Linux, Java, .NET, Mono|

## **Conclusion**
Open XML SDK와 Aspose.Slides는 다소 다른 요구를 다루고 서로 다른 청중을 대상으로 하기 때문에 직접적으로 경쟁하지 않습니다. 

{{% alert color="info" %}} 

Open XML SDK는 OOXML 문서를 강력히 형식화된 방식으로 작업할 수 있게 하는 클래스 라이브러리이며, Aspose.Slides는 거의 모든 Microsoft PowerPoint 파일 형식을 지원하는 매우 유용한 프레젠테이션 처리 라이브러리입니다. 

{{% /alert %}} 

워크플로가 PPTX 문서에 대한 기본적인 프로그래밍 작업이라면 Open XML SDK가 좋은 선택이 될 수 있습니다. Open XML SDK를 사용하면 간단한 PPTX 문서를 생성하거나 주석, 머리글/바닥글 제거, 이미지 추출 등을 수행하는 데 익숙해질 수 있습니다. 특정 작업은 Open XML SDK로 수행할 수 있지만 Aspose.Slides로는 할 수 없습니다. 예를 들어 OOXML 문서의 XML 요소와 속성에 직접 접근해야 한다면 Open XML SDK를 사용해야 합니다. 

문서에 복잡한 작업을 수행해야 한다면—다음 목록에 있는 작업과 같이—Aspose.Slides가 최선의 선택입니다. 

- 이전 PowerPoint 형식(및 PPTX 포함)과 관련된 작업.
- 슬라이드 내에서 모양을 복제하거나 클론하여 객체, 스타일 및 기타 서식 요소를 적절히 결합하는 작업.
- 서식이 있거나 없는 텍스트 교체.
- 애니메이션 적용 및 모양에 연결자 사용.
- 문서를 PDF, TIFF 또는 XPS로 변환하여 Microsoft PowerPoint가 변환한 것처럼 보이게 하기.
- 데스크톱 및 웹 기반 환경 모두에서 .NET 또는 Java 애플리케이션 개발.