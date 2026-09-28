---
title: 기능 개요
type: docs
weight: 94
url: /ko/net/features-overview/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET이 제공하는 내용을 평가하기 전에 검토하세요: 지원되는 플랫폼, 파일 형식, 슬라이드 렌더링, 그리고 생성하고 편집할 수 있는 콘텐츠."
---
## **개요**

Aspose.Slides for .NET은 PowerPoint 및 OpenDocument 프레젠테이션을 만들고, 읽고, 편집하고, 변환하고, 렌더링하는 클래스 라이브러리입니다. 자체 UI가 없으며 Microsoft PowerPoint 또는 Office가 필요하지 않아 콘솔 애플리케이션, Windows Forms와 같은 데스크톱 애플리케이션, 웹 애플리케이션 및 웹 서비스에서 사용할 수 있습니다. 이 문서는 라이브러리가 다루는 영역을 요약하고 각 영역을 설명하는 기사로 연결합니다.

## **지원 플랫폼**

Aspose.Slides for .NET은 동일한 API를 가진 두 개의 NuGet 패키지로 배포됩니다:

|**패키지**|**패키지에 포함된 빌드**|**운영 체제**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0, 및 .NET 6. .NET Framework 4.6.2 이상 또는 .NET 6 이상에서 사용합니다.|Windows. `libgdiplus` 라이브러리와 `System.Drawing.EnableUnixSupport` 스위치를 사용한 Linux 및 macOS.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. .NET 6 이상에서 사용합니다.|Windows (x86, x64), Linux (glibc 2.23 이상 x64, glibc 2.39 이상 ARM64), macOS (x64, ARM64).|

[설치](/slides/ko/net/installation/)에서는 어떤 패키지를 선택해야 하는지와 Linux에서 각 패키지가 요구하는 사항을 설명합니다. [시스템 요구 사항](/slides/ko/net/system-requirements/)에서는 지원되는 플랫폼을 자세히 나열합니다.

## **파일 형식 및 변환**

Aspose.Slides는 PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP 및 PowerPoint XML 프레젠테이션을 열고 저장합니다. PDF 및 HTML 콘텐츠를 슬라이드에 가져올 수 있으며, 프레젠테이션을 PDF, XPS, HTML, HTML5, TIFF, 애니메이션 GIF, SWF, Markdown 및 XAML 형식으로 저장합니다. [지원 파일 형식](/slides/ko/net/supported-file-formats/)에는 읽기 및 쓰기가 가능한 모든 형식과 해당 API가 나와 있습니다.

|**기능**|**설명**|
| :- | :- |
|[PPT and PPTX](/slides/ko/net/ppt-vs-pptx/)|바이너리 PowerPoint 97-2003 형식과 Office Open XML 형식을 모두 읽고 씁니다.|
|[PPT to PPTX conversion](/slides/ko/net/convert-ppt-to-pptx/)|레거시 PPT 프레젠테이션을 PPTX로 변환합니다.|
|[Portable Document Format (PDF)](/slides/ko/net/convert-powerpoint-to-pdf/)|PDF, PDF/A 및 PDF/UA 문서를 포함해 프레젠테이션을 PDF로 내보냅니다.|
|[XML Paper Specification (XPS)](/slides/ko/net/convert-powerpoint-to-xps/)|프레젠테이션을 XPS 문서로 내보냅니다.|
|[Tagged Image File Format (TIFF)](/slides/ko/net/convert-powerpoint-to-tiff/)|프레젠테이션을 TIFF 이미지로 내보냅니다.|
|[HTML](/slides/ko/net/convert-powerpoint-to-html/)|프레젠테이션을 HTML 및 HTML5로 내보냅니다.|
|[PDF and HTML import](/slides/ko/net/import-presentation/)|PDF 페이지와 HTML 콘텐츠를 슬라이드로 변환합니다.|

## **프레젠테이션 렌더링**

Aspose.Slides는 슬라이드와 개별 도형을 PNG, JPEG, BMP, GIF, TIFF, SVG 이미지로, 슬라이드를 EMF 메타파일로 렌더링합니다. 자세한 내용은 [슬라이드 이미지를 변환](/slides/ko/net/convert-slide/), [슬라이드를 SVG 이미지로 렌더링](/slides/ko/net/render-a-slide-as-an-svg-image/), 그리고 [도형 썸네일 만들기](/slides/ko/net/create-shape-thumbnails/)를 참고하세요.

## **콘텐츠 기능**

Aspose.Slides를 사용하면 프레젠테이션의 거의 모든 콘텐츠를 생성, 읽기 및 수정할 수 있습니다:

|**영역**|**가능한 작업**|
| :- | :- |
|[Slides](/slides/ko/net/presentation-slide/)|슬라이드 추가, 복제, 재정렬 및 삭제; 레이아웃 및 마스터 적용; 섹션으로 슬라이드 구성; 슬라이드 크기 변경.|
|[Design](/slides/ko/net/presentation-design/)|배경, 테마 색상, 머리글·바닥글, 글꼴 설정.|
|[Text](/slides/ko/net/manage-text/)|텍스트 프레임, 단락 및 구역 생성·편집; 글꼴, 색상, 글머리표·정렬 설정; 텍스트 찾기·바꾸기.|
|[Shapes](/slides/ko/net/powerpoint-shapes/)|AutoShape, 선, 연결선, 그룹 도형, 그림 프레임 생성; 위치·크기·선·채우기(단색, 그라디언트, 패턴) 설정; 대체 텍스트로 도형 찾기.|
|[Tables](/slides/ko/net/powerpoint-table/), [charts](/slides/ko/net/powerpoint-charts/), and [SmartArt](/slides/ko/net/powerpoint-smartart/)|표, Microsoft Office 차트, SmartArt 다이어그램 생성·편집.|
|[Media](/slides/ko/net/manage-media-files/), [OLE objects](/slides/ko/net/manage-ole/), and [ActiveX controls](/slides/ko/net/activex/)|임베드 또는 링크된 오디오·비디오 프레임 추가, OLE 객체 임베드, ActiveX 컨트롤 추가·수정·삭제.|
|[Notes](/slides/ko/net/presentation-notes/) and [comments](/slides/ko/net/presentation-comments/)|연사 노트와 검토 댓글 추가·읽기·편집.|
|[Animation](/slides/ko/net/powerpoint-animation/) and [transitions](/slides/ko/net/slide-transition/)|도형에 애니메이션 효과 적용, 슬라이드 전환 설정, 슬라이드 쇼 옵션 구성.|
|[Security](/slides/ko/net/presentation-security/)|프레젠테이션에 비밀번호로 암호화, 쓰기 보호 설정, 디지털 서명 작업.|
|[VBA macros](/slides/ko/net/presentation-via-vba/)|매크로 사용 프레젠테이션의 VBA 모듈 추가·추출·삭제.|
|[Properties](/slides/ko/net/presentation-properties/)|문서 속성 읽기·편집.|

## **FAQ**

**서버나 PC에 Microsoft PowerPoint를 설치해야 라이브러리를 사용할 수 있나요?**

아니요. PowerPoint가 필요하지 않으며, Aspose.Slides는 프레젠테이션을 만들고, 편집하고, 변환하고, 렌더링하는 독립 엔진입니다.

**멀티스레딩은 어떻게 작동하나요? 처리를 병렬화할 수 있나요?**

다른 스레드에서 서로 다른 문서를 처리하는 것은 안전합니다. 동일한 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 객체를 [다중 스레드](/slides/ko/net/multithreading/)에서 동시에 사용해서는 안 됩니다.

**파일 비밀번호 및 암호화가 지원되나요?**

예. [암호가 보호된 프레젠테이션](/slides/ko/net/password-protected-presentation/)을 열 수 있고, 열기 및 쓰기 비밀번호를 설정·제거할 수 있으며, 보호 상태를 확인할 수 있습니다.

**Linux 컨테이너에서 폰트를 신경 써야 하나요?**

예. 프레젠테이션에 사용된 폰트 또는 적절한 대체 폰트가 시스템에 설치되어 있어야 텍스트가 올바르게 렌더링됩니다. 애플리케이션에서 [폰트 디렉터리 지정](/slides/ko/net/custom-font/)도 가능합니다. [설치](/slides/ko/net/installation/)에서는 각 패키지의 Linux 전제 조건을 나열합니다.

**평가 버전에 제한이 있나요?**

예. [라이선스](/slides/ko/net/licensing/)가 없으면 Aspose.Slides는 저장하는 모든 슬라이드에 평가 워터마크를 추가하고 프레젠테이션에서 읽은 텍스트를 잘라냅니다. 전체 기능 테스트를 위한 [30일 임시 라이선스](https://purchase.aspose.com/temporary-license/)가 제공됩니다.

**프레젠테이션에 외부 형식(PDF 또는 HTML)을 가져오는 것이 지원되나요?**

예. [PDF 페이지와 HTML 콘텐츠](/slides/ko/net/import-presentation/)를 프레젠테이션에 추가하여 슬라이드로 변환할 수 있습니다.