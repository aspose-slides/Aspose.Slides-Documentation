---
title: 왜 Open XML SDK가 아닐까
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
description: "Aspose.Slides가 무료 Open XML SDK보다 더 나은 선택인 이유를 확인하세요: 기능 비교, 자동화 없는 변환, PPT, PPTX 및 ODP에 대한 폭넓은 지원."
---
## **개요**

이 문서는 개발자가 프레젠테이션 문서를 다룰 때 Open XML SDK 또는 Aspose.Slides 중 어느 것을 선택할 수 있는지를 설명합니다. Open XML SDK를 OOXML 패키지와 그 내부 XML 요소를 조작하는 라이브러리로 설명하고, Aspose.Slides는 고수준 객체 모델을 제공하고 다양한 PowerPoint 관련 작업을 지원하는 프레젠테이션 처리 라이브러리로 소개합니다.

이 문서는 지원되는 형식, 프로그래밍 모델, 렌더링 및 인쇄 기능, 플랫폼 지원 및 일반적인 사용 사례에 따라 두 옵션을 비교합니다. 또한 Open XML SDK가 기본적인 PPTX 작업이나 OOXML 요소에 직접 접근하는 경우에 적합할 수 있고, Aspose.Slides는 여러 PowerPoint 형식 작업, 도형 복제 또는 클론, 텍스트 교체, 애니메이션 적용 및 프레젠테이션을 PDF, TIFF 또는 XPS로 변환하는 복잡한 작업에 더 적합하다는 점을 명확히 합니다.

## **Open XML SDK란?**
우리는 종종 다음 질문을 듣습니다: 무료인 Open XML SDK 대신 Aspose 제품을 사용해야 하는 이유는 무엇인가요? 이 질문은 기능과 기능성으로 쉽게 답할 수 있습니다. According to the[MSDN Library](https://docs.microsoft.com/en-us/office/open-xml/open-xml-sdk), Open XML SDK는 다음과 같이 정의됩니다: The Open XML SDK 2.0 simplifies the task of manipulating Open XML packages and the underlying Open XML schema elements within a package. The Open XML SDK 2.0 encapsulates many common tasks that developers perform on Open XML packages, so that you can perform complex operations with just a few lines of code. OOXML documents are essentially zipped XML files and Open XML SDK is a collection of classes that allows you to work with the content of OOXML documents in a strongly-typed way. That is instead of unzipping a file to extract XML, loading that XML into a DOM tree and working with XML elements and attributes directly, Open XML SDK provides classes to do that.

## **Aspose.Slides란?**
Aspose.Slides는 응용 프로그램이 다음과 같은 프레젠테이션 처리 작업을 수행하도록 허용하는 클래스 라이브러리입니다:

- **Presentation** 객체 모델을 사용한 프로그래밍.
- PDF 및 XPS를 포함한 모든 주요 PowerPoint 프레젠테이션 형식 간 고품질 변환.
- PNG, JPEG 및 BMP와 같은 일반적인 형식과 SVG로 슬라이드 썸네일을 생성하는 기능.
- 하나 이상의 문서를 결합하거나 새로 만드는 방식으로 프레젠테이션을 구축하는 기능.
- 애니메이션, Ole Frames, 테이블, 차트 생성 및 관리 지원.
- TextFrames, Paragraphs 및 Portions 수준에서 텍스트 서식을 관리하기 위한 광범위한 제어 기능.

지원되는 기능에 대한 자세한 내용은 [Aspose.Slides Features](/slides/ko/cpp/product-overview/)를 참조하십시오.

## **Open XML SDK와 Aspose.Slides 비교**
다음 표는 Open XML SDK와 Aspose.Slides 기능을 비교합니다.

|**기능 또는 기능 카테고리**|**Open XML SDK**|**Aspose.Slides**|
| :- | :- | :- |
|지원되는 프레젠테이션 형식|PPTX|PPT, POT, PPS, PPTX, POTX, PPSX, ODP|
|PPT에서 PPTX로 변환|아니오|예|
|<p>프레젠테이션 문서 객체 모델(DOM)을 사용한 고수준 프로그래밍:</p><p>- 텍스트 찾기 및 바꾸기.</p><p>- 프레젠테이션에서 슬라이드 조합.</p>|아니오|예|
|문서 객체 모델을 통한 상세 프로그래밍, TextHolders, TextFrames, Paragraphs 및 Portions와 같은 개별 요소 및 서식에 대한 액세스.|예|예|
|관계 식별자, OOXML 문서의 목록 식별자와 같은 기본 XML 요소 및 속성에 대한 저수준 직접 전체 액세스.|예|아니오|
|<p>렌더링:</p><p>- 프레젠테이션을 PDF, PDF Notes, XPS, TIFF 이미지로 렌더링.</p><p>- 슬라이드 썸네일을 PNG, JPEG, BMP, SVG 및 TIFF로 렌더링.</p><p>- 이미지 해상도, 품질, 압축 및 기타 옵션 지정.</p>|아니오|예|

## **결론**
Open XML SDK와 Aspose.Slides는 매우 다른 요구와 대상을 다루기 때문에 정면 대결을 하지 않습니다. Open XML SDK는 OOXML 문서를 강력한 타입으로 작업할 수 있게 해 주는 클래스 라이브러리이며, Aspose.Slides는 거의 모든 Microsoft PowerPoint 파일 형식을 지원하는 매우 유용한 프레젠테이션 처리 라이브러리입니다. 만약 수행해야 할 작업이 PPTX 문서에 대한 비교적 기본적인 프로그래밍이라면 Open XML SDK가 적합한 선택일 수 있습니다. Open XML SDK를 사용하면 간단한 PPTX 문서를 생성하거나 주석, 머리글/바닥글 제거, 이미지 추출 등 간단한 작업을 편하게 수행할 수 있습니다. 일부 작업은 Open XML SDK로 가능하지만 Aspose.Slides에서는 할 수 없습니다. 예를 들어 OOXML 문서의 XML 요소와 속성에 직접 접근해야 한다면 Open XML SDK를 사용해야 합니다. 그러나 문서에 대해 다음과 같은 복합적인 작업을 수행해야 한다면 Aspose.Slides가 최선의 선택입니다:

- PPTX 외에 이전 PowerPoint 형식 지원.
- 슬라이드 내 도형을 복제하거나 클론하여 객체, 스타일 및 기타 서식을 적절히 결합.
- 서식이 있든 없든 텍스트 교체.
- 애니메이션 적용 및 도형 연결자 사용.
- 문서를 PDF 또는 XPS로 변환하여 Microsoft PowerPoint와 동일한 방식으로 표시.
- 데스크톱 및 콘솔 기반 환경 모두에서 C++ 애플리케이션 개발.