---
title: Android에서 프레젠테이션을 여러 형식으로 변환하기
linktitle: 프레젠테이션 변환
type: docs
weight: 70
url: /ko/androidjava/convert-presentation/
keywords:
- 프레젠테이션 변환
- 프레젠테이션 내보내기
- PPT를 PPTX로 변환
- PPTX를 PPT로 변환
- ODP를 PPTX로 변환
- PPT를 PDF로 변환
- PPTX를 PDF로 변환
- ODP를 PDF로 변환
- PPT를 HTML로 변환
- PPTX를 HTML로 변환
- ODP를 HTML로 변환
- PPT를 PNG로 변환
- PPTX를 PNG로 변환
- ODP를 PNG로 변환
- PPTX를 JPG로 변환
- ODP를 JPG로 변환
- PPT를 XPS로 변환
- PPTX를 XPS로 변환
- ODP를 XPS로 변환
- PPT를 TIFF로 변환
- PPTX를 TIFF로 변환
- ODP를 TIFF로 변환
- PowerPoint
- 오픈문서
- 안드로이드
- 자바
- Aspose.Slides
description: "Aspose.Slides for Android via Java을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 PPTX, PDF, HTML, 이미지, XPS, TIFF 등으로 변환합니다."
---
## **개요**

Aspose.Slides for Android via Java은 Microsoft PowerPoint, OpenOffice 또는 LibreOffice 없이도 PowerPoint 및 OpenDocument 프레젠테이션을 로드하고 여러 다른 형식으로 저장하거나 렌더링할 수 있습니다. 레거시 PPT 파일을 최신 PPTX로 변환하고, 프레젠테이션을 PDF 및 XPS와 같은 고정 레이아웃 문서로 내보내며, 슬라이드를 HTML로 게시하거나 미리 보기, 썸네일 및 보관을 위한 이미지 파일로 렌더링할 수 있습니다.

대부분의 문서 변환은 동일한 일반 워크플로를 사용합니다: 소스 파일을 로드하고, 필요한 출력 형식을 선택한 다음, 필요에 따라 형식별 옵션을 적용합니다. 이미지 형식의 경우 각 슬라이드가 별도로 렌더링된 후 래스터 또는 벡터 이미지로 저장됩니다. 아래에 링크된 전용 문서가 각 사례에 대한 구현 세부 정보를 제공합니다.

## **변환 시나리오 선택**

아래 문서를 사용하면 전체 Java 예제와 형식별 옵션을 확인할 수 있습니다.

| 시나리오 | 필요할 때 | 문서 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | 레거시 PPT 파일을 최신화하고, 기존 PPTX 파일을 정규화하거나 OpenDocument 프레젠테이션을 PowerPoint PPTX로 변환합니다. | [Convert PPT to PPTX](/slides/ko/androidjava/convert-ppt-to-pptx/),[Convert ODP to PPTX](/slides/ko/androidjava/convert-odp-to-pptx/),[Save Presentations](/slides/ko/androidjava/save-presentation/) |
| PPTX to PPT | 현대적인 PowerPoint 프레젠테이션을 이전 워크플로와의 호환성을 위해 오래된 이진 PPT 형식으로 저장합니다. | [Convert PPTX to PPT](/slides/ko/androidjava/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 공유, 인쇄 또는 보관을 위해 휴대 가능하고 검색 가능한 고정 레이아웃 문서를 생성합니다. | [Convert PowerPoint to PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | 슬라이드 내용과 함께 발표자 메모를 내보냅니다. | [Convert PowerPoint to PDF with Notes](/slides/ko/androidjava/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | 프레젠테이션을 HTML 페이지로 게시하고 이미지, 글꼴, 메모 및 반응형 레이아웃 옵션을 제어합니다. | [Convert PowerPoint to HTML](/slides/ko/androidjava/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | 형식과 인터랙티브를 유지한 채 브라우저 기반 뷰를 위해 슬라이드를 HTML5로 내보냅니다. | [Convert Presentations to HTML5](/slides/ko/androidjava/export-to-html5/) |
| PPT/PPTX/ODP to PNG | 미리 보기, 썸네일 또는 웹 출력을 위해 각 슬라이드를 PNG 이미지로 렌더링합니다. | [Convert PowerPoint to PNG](/slides/ko/androidjava/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | 슬라이드를 JPG 이미지로 렌더링하고 이미지 차원 및 품질을 제어합니다. | [Convert PowerPoint to JPG](/slides/ko/androidjava/convert-powerpoint-to-jpg/) |
| Slide to SVG | 개별 슬라이드를 확장 가능한 벡터 그래픽으로 내보냅니다. | [Render Slide as SVG](/slides/ko/androidjava/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 고정 레이아웃 XPS 문서를 생성합니다. | [Convert PowerPoint to XPS](/slides/ko/androidjava/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 인쇄, 스캔, 팩스 또는 보관 워크플로를 위해 프레젠테이션을 다중 페이지 TIFF 파일로 저장합니다. | [Convert PowerPoint to TIFF](/slides/ko/androidjava/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | 발표자 메모와 함께 슬라이드를 TIFF로 저장합니다. | [Convert PowerPoint to TIFF with Notes](/slides/ko/androidjava/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | 문서형 출력이 필요할 때 슬라이드를 Word 문서로 변환합니다. | [Convert PowerPoint to Word](/slides/ko/androidjava/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | 문서화 및 텍스트 기반 워크플로를 위해 프레젠테이션 내용을 Markdown으로 추출합니다. | [Convert PowerPoint to Markdown](/slides/ko/androidjava/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP to XML | 검사, 비교, 문제 해결 또는 XML 기반 워크플로를 위해 텍스트 기반 PowerPoint XML 프레젠테이션을 생성합니다. | [Convert PowerPoint to XML](/slides/ko/androidjava/convert-powerpoint-to-xml/) |
| PPT/PPTX to animated GIF | 슬라이드에서 애니메이션 GIF를 생성합니다. | [Convert PowerPoint to Animated GIF](/slides/ko/androidjava/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | 프레젠테이션 슬라이드에서 비디오 내보내기 워크플로를 구축합니다. | [Convert PowerPoint to Video](/slides/ko/androidjava/convert-powerpoint-to-video/) |
| Presentation to XAML | Android 또는 Java UI 시나리오를 위해 슬라이드를 XAML로 내보냅니다. | [Export Presentations to XAML](/slides/ko/androidjava/export-to-xaml/) |

입력 및 출력 형식의 전체 목록은 [Supported File Formats](/slides/ko/androidjava/supported-file-formats/)을 참조하십시오.

## **PowerPoint 및 OpenDocument 변환**

Aspose.Slides for Android via Java은 PPT, PPTX, PPS, PPSX, POT, POTX 및 ODP와 같은 일반적으로 사용되는 프레젠테이션 형식 간의 변환을 지원합니다. 동일한 변환 API가 PowerPoint와 OpenDocument 파일 모두에 사용되므로, PPTX 파일을 PDF로 저장하는 워크플로는 입력 파일만 ODP로 교체하면 일반적으로 ODP 파일에도 적용할 수 있습니다.

ODP 파일을 변환할 때는 PowerPoint와 OpenDocument 애플리케이션이 모든 레이아웃 및 서식 기능을 정확히 동일하게 지원하지 않음을 기억하세요. ODP 파일이 LibreOffice 또는 OpenOffice Impress에서 생성된 경우, 출력물을 검토하고 형식별 안내가 필요할 때는 [Convert OpenDocument Presentations](/slides/ko/androidjava/convert-openoffice-odp/)에 설명된 옵션을 사용하세요.

## **PPT to PPTX 변환**

PPT는 오래된 이진 PowerPoint 형식이며, PPTX는 최신 Office Open XML 형식입니다. Aspose.Slides for Android via Java은 마스터, 레이아웃, 슬라이드, 차트, 그룹화된 도형, 자리 표시자, 텍스트 프레임, 텍스처 및 이미지 채우기와 같은 복잡한 프레젠테이션 구조를 보존하면서 고품질 PPT→PPTX 변환을 지원합니다.

자세한 내용은 [Convert PPT to PPTX](/slides/ko/androidjava/convert-ppt-to-pptx/)와 [PPT vs PPTX](/slides/ko/androidjava/ppt-vs-pptx/)를 확인하세요.

## **고정 레이아웃 내보내기**

PDF, XPS 및 TIFF는 출력이 장치마다 동일하게 보이고 프레젠테이션으로 편집되지 않아야 할 때 유용합니다. 전용 PDF, XPS 및 TIFF 문서에서는 규격 준수, 숨겨진 슬라이드, 메모, 이미지 품질, 압축, 픽셀 형식 및 출력 크기를 제어하는 방법을 설명합니다.

## **HTML 및 이미지 내보내기**

HTML 및 HTML5 내보내기는 브라우저 보기, 웹 게시 및 가벼운 공유에 유용합니다. 이미지 내보내기는 각 슬라이드가 별도의 미리 보기, 썸네일 또는 래스터 자산이 되어야 할 때 필요합니다. 형식별 렌더링 안내는 PNG, JPG 및 SVG 문서를 참고하세요.

## **FAQ**

**프레젠테이션을 변환하려면 Microsoft PowerPoint가 필요합니까?**

아니오. Aspose.Slides for Android via Java는 독립 실행형 라이브러리이며 Microsoft PowerPoint 또는 Office 자동화를 필요로 하지 않습니다.

**여러 프레젠테이션을 배치 변환할 수 있습니까?**

예. 각 프레젠테이션을 로드하고 필요한 형식으로 저장한 뒤 처리 후 프레젠테이션 객체를 해제합니다. 병렬 처리를 위해서는 별도의 프레젠테이션 인스턴스를 사용하고 [multithreading](/slides/ko/androidjava/multithreading/) 가이드를 따르세요.

**선택한 슬라이드만 내보낼 수 있나요?**

예. 여러 내보내기 방법에서 출력 형식에 따라 슬라이드 인덱스를 전달하거나 개별 슬라이드를 렌더링할 수 있습니다. 해당 형식에 대한 전용 문서를 참조하세요.

**PDF 또는 XPS로 내보낼 때 숨겨진 슬라이드를 포함할 수 있나요?**

예. [PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/) 및 [XPS](/slides/ko/androidjava/convert-powerpoint-to-xps/) 변환 문서에 설명된 숨겨진 슬라이드 내보내기 설정을 사용하세요.

**PDF/A 출력물을 생성할 수 있나요?**

예. PDF 내보내기에는 PDF 호환성 설정이 제공됩니다. 자세한 내용은 [Convert PowerPoint to PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/)를 참고하세요.

**변환 중에 글꼴은 어떻게 처리되나요?**

Aspose.Slides는 내장 글꼴, 폰트 폴백 및 글꼴 대체 설정을 사용할 수 있습니다. [Embedded Font](/slides/ko/androidjava/embedded-font/), [Fallback Font](/slides/ko/androidjava/fallback-font/), [Font Substitution](/slides/ko/androidjava/font-substitution/)를 참조하세요.