---
title: 기능 개요
type: docs
weight: 104
url: /ko/java/features-overview/
keywords:
- 기능
- 지원 플랫폼
- 파일 형식
- 변환
- 렌더링
- 프레젠테이션 콘텐츠
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java가 제공하는 내용을 평가하기 전에 검토하십시오: 지원 플랫폼, 파일 형식, 슬라이드 렌더링 및 생성·편집할 수 있는 콘텐츠."
---
## **개요**

Aspose.Slides for Java는 PowerPoint 및 OpenDocument 프레젠테이션을 만들고, 읽고, 편집하고, 변환하고, 렌더링하기 위한 클래스 라이브러리입니다. 자체 사용자 인터페이스가 없으며 Microsoft PowerPoint 또는 Microsoft Office가 필요하지 않습니다. 이 문서는 라이브러리에서 다루는 내용의 개요를 제공하고 각 영역을 설명하는 문서에 대한 링크를 제공합니다.

## **지원 플랫폼**

Aspose.Slides for Java는 `jdk16` 분류자를 사용하여 Aspose의 Maven 저장소에 게시된 단일 JAR 파일입니다. 순수 Java로 작성되었으며 JAR에 네이티브 라이브러리가 포함되지 않고 다른 패키지에 의존하지 않습니다.

- **Java:** Java 8 이상. Aspose.Slides for Java 26.9 및 이전 버전은 Java 6 및 7에서도 실행되지만 26.10부터는 지원되지 않으며, 자세한 내용은 [26.9 릴리스 노트](https://releases.aspose.com/slides/ko/java/release-notes/2026/aspose-slides-for-java-26-9-release-notes/)를 참조하십시오.
- **운영 체제:** Windows, Linux, macOS와 같이 Java 런타임이 설치된 모든 운영 체제. Linux에서는 fontconfig 라이브러리와 최소 하나의 폰트가 설치되어 있어야 합니다.

[설치](/slides/ko/java/installation/)에서는 라이브러리를 프로젝트에 추가하는 방법과 Linux 사전 요구 사항을 안내합니다. [시스템 요구 사항](/slides/ko/java/system-requirements/)에서는 지원되는 플랫폼을 자세히 나열합니다.

## **파일 형식 및 변환**

Aspose.Slides는 PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP 및 PowerPoint XML 프레젠테이션을 열고 저장합니다. PDF와 HTML 콘텐츠를 슬라이드로 가져올 수 있으며, 프레젠테이션을 PDF, XPS, HTML, HTML5, TIFF, 애니메이션 GIF, SWF, Markdown 및 XAML 형식으로 저장합니다. [지원 파일 형식](/slides/ko/java/supported-file-formats/)에서는 각각을 읽거나 쓸 수 있는 API와 함께 모든 형식을 나열합니다.

|**기능**|**설명**|
| :- | :- |
|[PPT 및 PPTX](/slides/ko/java/ppt-vs-pptx/)|이진 PowerPoint 97-2003 형식과 Office Open XML 형식을 모두 읽고 씁니다.|
|[PPT에서 PPTX로 변환](/slides/ko/java/convert-ppt-to-pptx/)|레거시 PPT 프레젠테이션을 PPTX로 변환합니다.|
|[ODP에서 PPTX로 변환](/slides/ko/java/convert-odp-to-pptx/)|ODP, OTP 및 FODP 프레젠테이션을 열고 저장하며, ODP 프레젠테이션을 PPTX로 변환합니다.|
|[PDF](/slides/ko/java/convert-powerpoint-to-pdf/)|PDF, PDF/A 및 PDF/UA 문서를 포함하여 프레젠테이션을 PDF로 내보냅니다.|
|[XPS](/slides/ko/java/convert-powerpoint-to-xps/)|프레젠테이션을 XPS 문서로 내보냅니다.|
|[TIFF](/slides/ko/java/convert-powerpoint-to-tiff/)|슬라이드당 한 페이지씩 멀티 페이지 TIFF 이미지로 내보냅니다.|
|[HTML](/slides/ko/java/convert-powerpoint-to-html/)|프레젠테이션을 HTML 및 HTML5로 내보냅니다.|
|[PDF 및 HTML 가져오기](/slides/ko/java/import-presentation/)|PDF 페이지와 HTML 콘텐츠로부터 슬라이드를 생성합니다.|

## **프레젠테이션 렌더링**

Aspose.Slides는 슬라이드와 개별 도형을 PNG, JPEG, BMP, GIF, TIFF 및 SVG 이미지로, 슬라이드를 EMF 메타파일로 렌더링합니다. 자세한 내용은 [슬라이드 이미지를 변환](/slides/ko/java/convert-slide/), [슬라이드를 SVG 이미지로 렌더링](/slides/ko/java/render-a-slide-as-an-svg-image/), 그리고 [프레젠테이션 도형 썸네일 만들기](/slides/ko/java/create-shape-thumbnails/)를 참고하십시오.

## **콘텐츠 기능**

Aspose.Slides를 사용하면 프레젠테이션의 거의 모든 콘텐츠를 생성, 읽기 및 수정할 수 있습니다:

|**영역**|**가능한 작업**|
| :- | :- |
|[슬라이드](/slides/ko/java/presentation-slide/)|슬라이드 추가, 복제, 순서 변경 및 삭제; 레이아웃 및 마스터 적용; 섹션으로 슬라이드 구성; 슬라이드 크기 변경.|
|[디자인](/slides/ko/java/presentation-design/)|배경, 테마 색상, 머리글 및 바닥글, 글꼴 설정.|
|[텍스트](/slides/ko/java/manage-text/)|텍스트 프레임, 단락 및 구절 생성 및 편집; 글꼴, 색상, 글머리표 및 정렬 설정; 텍스트 찾기 및 바꾸기.|
|[도형](/slides/ko/java/powerpoint-shapes/)|AutoShape, 선, 연결선, 그룹 도형 및 그림 프레임 생성; 위치, 크기, 선 스타일 및 단색, 그라디언트, 패턴 채우기 설정; 대체 텍스트로 도형 찾기.|
|[표](/slides/ko/java/powerpoint-table/), [차트](/slides/ko/java/powerpoint-charts/), 및 [스마트아트](/slides/ko/java/powerpoint-smartart/)|표, Microsoft Office 차트 및 SmartArt 다이어그램 생성 및 편집.|
|[미디어](/slides/ko/java/manage-media-files/), [OLE 개체](/slides/ko/java/manage-ole/), 및 [ActiveX 컨트롤](/slides/ko/java/activex/)|내장 또는 링크된 오디오·비디오 프레임 추가, OLE 개체 삽입, ActiveX 컨트롤 추가·수정·삭제.|
|[메모](/slides/ko/java/presentation-notes/) 및 [주석](/slides/ko/java/presentation-comments/)|발표자 메모 및 검토 주석 추가, 읽기 및 편집.|
|[애니메이션](/slides/ko/java/powerpoint-animation/) 및 [전환](/slides/ko/java/slide-transition/)|도형에 애니메이션 효과 적용, 슬라이드 전환 설정, 슬라이드 쇼 옵션 구성.|
|[보안](/slides/ko/java/presentation-security/)|비밀번호로 프레젠테이션 암호화, 쓰기 보호 설정, [디지털 서명](/slides/ko/java/digital-signature-in-powerpoint/) 작업.|
|[VBA 매크로](/slides/ko/java/presentation-via-vba/)|매크로 사용 프레젠테이션에서 VBA 모듈 추가, 추출 및 삭제.|
|[속성](/slides/ko/java/presentation-properties/)|문서 속성 읽기 및 편집.|

## **FAQ**

**서버나 PC에 Microsoft PowerPoint를 설치해야 라이브러리를 사용할 수 있나요?**

아니요. PowerPoint가 필요하지 않으며, Aspose.Slides는 프레젠테이션을 만들고, 편집하고, 변환하고, 렌더링하는 독립 실행형 엔진입니다.

**멀티스레딩은 어떻게 작동하나요? 처리를 병렬화할 수 있나요?**

다른 스레드에서 다른 문서를 처리하는 것은 안전합니다. 동일한 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 객체를 [여러 스레드](/slides/ko/java/multithreading/)가 동시에 사용하면 안 됩니다.

**파일 비밀번호 및 암호화가 지원되나요?**

예. [여기](/slides/ko/java/password-protected-presentation/)에서 암호화된 프레젠테이션을 열고, 열기 및 쓰기 비밀번호를 설정·제거하며, 보호 상태를 확인할 수 있습니다.

**Linux 컨테이너에서 폰트 문제를 신경 써야 하나요?**

예. Linux에서는 fontconfig 라이브러리와 최소 하나의 폰트가 설치되어 있어야 하며, 프레젠테이션에 사용된 폰트나 적절한 대체 폰트가 설치되어 있어야 텍스트가 올바르게 렌더링됩니다. 또한 애플리케이션에서 [폰트 디렉터리 지정](/slides/ko/java/custom-font/)이 가능합니다. 자세한 내용은 [설치](/slides/ko/java/installation/#linux)를 참조하십시오.

**평가 버전에 제한이 있나요?**

예. [라이선스](/slides/ko/java/licensing/)가 없으면 Aspose.Slides는 저장되는 모든 슬라이드에 평가용 워터마크를 추가하고 API를 통해 읽은 텍스트를 잘라냅니다. 전체 기능 테스트를 위한 [30일 임시 라이선스](https://purchase.aspose.com/temporary-license/)를 제공하고 있습니다.

**프레젠테이션에 외부 형식(PDF 또는 HTML)을 가져오는 것이 지원되나요?**

예. [PDF 페이지 및 HTML 콘텐츠](/slides/ko/java/import-presentation/)를 프레젠테이션에 추가하여 슬라이드로 변환할 수 있습니다.