---
title: 왜 Open XML SDK를 사용하지 말아야 할까
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
description: "무료 Open XML SDK보다 Aspose.Slides가 더 나은 선택인 이유를 확인하십시오: 기능 비교, 자동 변환 없이 변환, PPT, PPTX 및 ODP에 대한 광범위한 지원."
---
## **Overview**

이 문서는 개발자가 프레젠테이션 문서를 작업할 때 Open XML SDK와 Aspose.Slides 중 어떤 것을 선택할 수 있는지 설명합니다. Open XML SDK는 OOXML 패키지와 그 안에 있는 XML 요소를 조작하기 위한 라이브러리로 정의되고, Aspose.Slides는 고수준 객체 모델과 다양한 PowerPoint 관련 작업을 지원하는 프레젠테이션 처리 라이브러리로 소개됩니다.

두 옵션은 지원 형식, 프로그래밍 모델, 렌더링, 플랫폼 지원 및 일반적인 사용 사례 측면에서 비교됩니다. 또한 Open XML SDK는 기본적인 PPTX 작업이나 OOXML 요소에 직접 접근할 때 적합할 수 있고, Aspose.Slides는 여러 PowerPoint 형식 작업, 도형 복제, 텍스트 교체, 애니메이션 적용, 프레젠테이션을 PDF, TIFF, XPS 등으로 변환하는 복잡한 작업에 더 적합함을 명확히 합니다.

## **What Is Open XML SDK?**
[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk)에 따르면 Open XML SDK는 다음과 같이 정의됩니다:

Open XML SDK 2.0은 Open XML 패키지와 패키지 내부의 Open XML 스키마 요소를 조작하는 작업을 단순화합니다. Open XML SDK 2.0은 개발자가 Open XML 패키지에서 수행하는 많은 일반 작업을 캡슐화하여 몇 줄의 코드만으로 복잡한 작업을 수행할 수 있게 합니다.

OOXML 문서는 기본적으로 압축된 XML 파일이며, Open XML SDK는 OOXML 문서의 내용을 강력한 형식으로 작업할 수 있게 하는 클래스 모음입니다. 즉 파일을 압축 해제해 XML을 추출하고, 그 XML을 DOM 트리로 로드해 요소와 속성을 직접 다루는 대신, Open XML SDK가 이를 위한 클래스를 제공합니다.

## **What Is Aspose.Slides?**
Aspose.Slides는 애플리케이션이 다음과 같은 프레젠테이션 처리 작업을 수행하도록 하는 클래스 라이브러리입니다:

- **Presentation** 객체 모델을 이용한 프로그래밍.
- PDF, XPS, TIFF 등 모든 주요 PowerPoint 프레젠테이션 형식 간의 고품질 변환.
- PNG, JPEG, BMP와 같은 잘 알려진 형식으로 슬라이드 썸네일 생성 및 SVG로 슬라이드 내보내기.
- 하나 또는 여러 문서를 결합해 새 프레젠테이션을 처음부터 만들거나 빌드.
- 애니메이션, Ole 프레임, 테이블, 차트 생성 및 관리 지원.
- TextFrames, Paragraphs 및 Portions 수준에서 텍스트 서식 관리를 위한 광범위한 제어 제공.

지원되는 기능에 대한 자세한 내용은 [Aspose.Slides Features](/slides/ko/java/product-overview/)를 참조하십시오.

## **Compare Open XML SDK with Aspose.Slides**
{{% alert color="info" %}} 

다음 표는 Open XML SDK와 Aspose.Slides 기능을 비교합니다.

{{% /alert %}} 

|**Feature or Feature Category**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|지원 프레젠테이션 형식|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT를 PPTX로 변환|아니오|예|
|<p>프레젠테이션 Document Object Model(DOM) 기반 고수준 프로그래밍:</p><p>- 텍스트 찾기 및 교체.</p><p>- 프레젠테이션 내 슬라이드 조합.</p>|아니오|예|
|문서 객체 모델을 통한 상세 프로그래밍, 개별 요소 및 TextHolders, TextFrames, Paragraphs, Portions와 같은 서식에 접근.|예|예|
|OOXML 문서의 관계 식별자, 목록 식별자 등 기본 XML 요소와 속성에 대한 저수준 직접 전체 접근.|예|아니오|
|<p>렌더링:</p><p>- 프레젠테이션을 PDF, PDF 노트, XPS, TIFF 이미지로 렌더링.</p><p>- 슬라이드 썸네일을 PNG, JPEG, BMP, SVG 및 TIFF로 렌더링.</p><p>- 이미지 해상도, 품질, 압축 및 기타 옵션 지정.</p>|아니오|예|
|지원 플랫폼|Windows, .NET|Windows, Linux, UNIX, MAC, Java, PHP, Mono|

## **Conclusion**
{{% alert color="info" %}} 

Open XML SDK와 Aspose.Slides는 서로 다른 요구와 대상 고객을 다루기 때문에 직접적인 경쟁 관계에 있지 않습니다. Open XML SDK는 OOXML 문서를 강력한 형식으로 작업할 수 있게 하는 클래스 라이브러리이며, Aspose.Slides는 거의 모든 Microsoft PowerPoint 파일 형식을 지원하는 매우 유용한 프레젠테이션 처리 라이브러리입니다.

만약 수행하려는 작업이 PPTX 문서에 대한 비교적 기본적인 프로그래밍이라면 Open XML SDK가 적합한 선택일 수 있습니다. Open XML SDK를 사용하면 간단한 PPTX 문서 생성, 주석·머리글/바닥글 제거, 이미지 추출 등 간단한 작업을 편히 수행할 수 있습니다. 일부 작업은 Open XML SDK로 가능하지만 Aspose.Slides에서는 불가능합니다. 예를 들어 OOXML 문서의 XML 요소와 속성에 직접 접근해야 하는 경우 Open XML SDK를 사용해야 합니다. 그러나 문서에 대해 다음과 같은 복잡한 작업을 수행해야 한다면 Aspose.Slides가 최선의 선택입니다:

- PPTX 외에도 이전 PowerPoint 형식 지원.
- 슬라이드 내 도형을 복제하거나 클론하여 객체, 스타일 및 기타 서식을 적절히 결합.
- 서식이 있든 없든 텍스트 교체.
- 애니메이션 적용 및 도형 연결자 사용.
- 문서를 PDF, TIFF 또는 XPS로 변환하여 Microsoft PowerPoint와 동일한 결과 확보.
- 데스크톱 및 웹 기반 환경 모두에서 .NET 또는 Java 애플리케이션 개발.

{{% /alert %}}