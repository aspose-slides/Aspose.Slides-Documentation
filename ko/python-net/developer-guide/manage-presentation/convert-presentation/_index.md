---
title: 파이썬에서 프레젠테이션을 여러 형식으로 변환
linktitle: 프레젠테이션 변환
type: docs
weight: 70
url: /ko/python-net/convert-presentation/
keywords:
- 프레젠테이션 변환
- 프레젠테이션 내보내기
- PPT를 PPTX로
- PPTX를 PPT로
- ODP를 PPTX로
- PPT를 PDF로
- PPTX를 PDF로
- ODP를 PDF로
- PPT를 HTML로
- PPTX를 HTML로
- ODP를 HTML로
- PPT를 PNG로
- PPTX를 PNG로
- ODP를 PNG로
- PPTX를 JPG로
- ODP를 JPG로
- PPT를 XPS로
- PPTX를 XPS로
- ODP를 XPS로
- PPT를 TIFF로
- PPTX를 TIFF로
- ODP를 TIFF로
- 파워포인트
- 오픈문서
- 파이썬
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 PPTX, PDF, HTML, 이미지, XPS, TIFF 등 다양한 형식으로 변환합니다."
---
## **개요**

Aspose.Slides for Python via .NET은 Microsoft PowerPoint, OpenOffice 또는 LibreOffice 없이도 PowerPoint 및 OpenDocument 프레젠테이션을 로드하고 다양한 다른 형식으로 저장하거나 렌더링할 수 있습니다. 레거시 PPT 파일을 최신 PPTX로 변환하거나, PDF 및 XPS와 같은 고정 레이아웃 문서로 내보내고, 슬라이드를 HTML로 게시하거나, 미리보기, 썸네일 및 보관을 위해 슬라이드를 이미지 파일로 렌더링할 수 있습니다.

대부분의 문서 변환은 동일한 일반적인 워크플로를 사용합니다: 소스 파일을 로드하고, 원하는 출력 형식을 선택한 다음 필요에 따라 형식별 옵션을 적용합니다. 이미지 형식의 경우 각 슬라이드를 별도로 렌더링한 후 래스터 또는 벡터 이미지로 저장합니다. 아래에 연결된 전용 문서에서 각 경우에 대한 구현 세부 정보를 확인하십시오.

## **변환 시나리오 선택**

아래 문서를 사용하여 완전한 Python 예제와 형식별 옵션을 확인하십시오.

| 시나리오 | 필요할 때 | 문서 |
| --- | --- | --- |
| PPT/PPTX/ODP → PPTX | 레거시 PPT 파일을 최신화하거나, 기존 PPTX 파일을 정규화하거나, OpenDocument 프레젠테이션을 PowerPoint PPTX로 변환할 때. | [Convert PPT to PPTX](/slides/ko/python-net/convert-ppt-to-pptx/), [Convert ODP to PPTX](/slides/ko/python-net/convert-odp-to-pptx/), [Save Presentations](/slides/ko/python-net/save-presentation/) |
| PPTX → PPT | 최신 PowerPoint 프레젠테이션을 이전 이진 PPT 형식으로 저장하여 오래된 워크플로와 호환성을 유지하고자 할 때. | [Convert PPTX to PPT](/slides/ko/python-net/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP → PDF | 공유, 인쇄 또는 보관을 위해 휴대 가능하고 검색 가능한 고정 레이아웃 문서를 만들고자 할 때. | [Convert PowerPoint to PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP → PDF (노트 포함) | 슬라이드 내용과 함께 발표자 노트를 내보낼 때. | [Convert PowerPoint to PDF with Notes](/slides/ko/python-net/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP → HTML | 프레젠테이션을 HTML 페이지로 게시하고 이미지, 글꼴, 노트 및 반응형 레이아웃 옵션을 제어하고자 할 때. | [Convert PowerPoint to HTML](/slides/ko/python-net/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP → HTML5 | 서식과 인터랙티브를 유지한 채 브라우저 기반 보기용 HTML5로 슬라이드를 내보낼 때. | [Convert Presentations to HTML5](/slides/ko/python-net/export-to-html5/) |
| PPT/PPTX/ODP → PNG | 미리보기, 썸네일 또는 웹 출력용으로 각 슬라이드를 PNG 이미지로 렌더링할 때. | [Convert PowerPoint to PNG](/slides/ko/python-net/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP → JPG | 슬라이드를 JPG 이미지로 렌더링하고 이미지 크기와 품질을 제어하고자 할 때. | [Convert PowerPoint to JPG](/slides/ko/python-net/convert-powerpoint-to-jpg/) |
| 슬라이드 → SVG | 개별 슬라이드를 확장 가능한 벡터 그래픽으로 내보낼 때. | [Render Slide as SVG](/slides/ko/python-net/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP → XPS | 고정 레이아웃 XPS 문서를 생성하고자 할 때. | [Convert PowerPoint to XPS](/slides/ko/python-net/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP → TIFF | 인쇄, 스캔, 팩스 또는 보관 워크플로를 위해 프레젠테이션을 다중 페이지 TIFF 파일로 저장할 때. | [Convert PowerPoint to TIFF](/slides/ko/python-net/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP → TIFF (노트 포함) | 슬라이드와 발표자 노트를 함께 TIFF 형식으로 저장하고자 할 때. | [Convert PowerPoint to TIFF with Notes](/slides/ko/python-net/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX/ODP → Word | 문서 스타일 출력이 필요할 때 슬라이드를 Word 문서로 변환하고자 할 때. | [Convert PowerPoint to Word](/slides/ko/python-net/convert-powerpoint-to-word/) |
| PPT/PPTX/ODP → Markdown | 프레젠테이션 내용을 문서화 및 텍스트 기반 워크플로를 위해 Markdown으로 추출하고자 할 때. | [Convert PowerPoint to Markdown](/slides/ko/python-net/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP → 애니메이션 GIF | 슬라이드로부터 애니메이션 GIF를 만들고자 할 때. | [Convert PowerPoint to Animated GIF](/slides/ko/python-net/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX/ODP → 비디오 | 프레젠테이션 슬라이드에서 비디오 내보내기 워크플로를 구축하고자 할 때. | [Convert PowerPoint to Video](/slides/ko/python-net/convert-powerpoint-to-video/) |
| 프레젠테이션 → XAML | Python 또는 .NET UI 시나리오를 위해 슬라이드를 XAML로 내보낼 때. | [Export Presentations to XAML](/slides/ko/python-net/export-to-xaml/) |

입출력 형식 전체 목록은 [Supported File Formats](/slides/ko/python-net/supported-file-formats/)를 참조하십시오.

## **PowerPoint 및 OpenDocument 변환**

Aspose.Slides for Python via .NET은 PPT, PPTX, PPS, PPSX, POT, POTX 및 ODP와 같은 일반적으로 사용되는 프레젠테이션 형식 간 변환을 지원합니다. 동일한 변환 API가 PowerPoint와 OpenDocument 파일 모두에 사용되므로, PPTX 파일을 PDF로 저장하는 워크플로는 입력 파일만 ODP로 교체하면 일반적으로 적용됩니다.

ODP 파일을 변환할 때는 PowerPoint와 OpenDocument 애플리케이션이 모든 레이아웃 및 서식 기능을 정확히 동일하게 지원하지는 못한다는 점을 기억하십시오. LibreOffice 또는 OpenOffice Impress에서 ODP 파일을 만든 경우, 출력을 검토하고 형식별 안내가 필요할 때는 [Convert OpenDocument Presentations](/slides/ko/python-net/convert-openoffice-odp/)에서 설명한 옵션을 사용하십시오.

## **PPT → PPTX 변환**

PPT는 오래된 이진 PowerPoint 형식이고, PPTX는 최신 Office Open XML 형식입니다. Aspose.Slides for Python via .NET은 마스터, 레이아웃, 슬라이드, 차트, 그룹화된 도형, 플레이스홀더, 텍스트 프레임, 텍스처 및 그림 채우기와 같은 복잡한 프레젠테이션 구조를 보존하면서 고충실도 PPT → PPTX 변환을 지원합니다.

자세한 내용은 [Convert PPT to PPTX](/slides/ko/python-net/convert-ppt-to-pptx/)와 [PPT vs PPTX](/slides/ko/python-net/ppt-vs-pptx/)를 참고하십시오.

## **고정 레이아웃 내보내기**

PDF, XPS 및 TIFF는 출력이 장치마다 동일하게 보이고 프레젠테이션으로 편집되지 않아야 할 때 유용합니다. 전용 PDF, XPS 및 TIFF 문서에서는 규격 준수, 숨김 슬라이드, 노트, 이미지 품질, 압축, 픽셀 포맷 및 출력 크기를 제어하는 방법을 설명합니다.

## **HTML 및 이미지 내보내기**

HTML 및 HTML5 내보내기는 브라우저 보기, 웹 게시 및 경량 공유에 유용합니다. 이미지 내보내기는 각 슬라이드를 별도의 미리보기, 썸네일 또는 래스터 자산으로 만들 때 유용합니다. PNG, JPG 및 SVG 문서에서 형식별 렌더링 가이드를 확인하십시오.

## **FAQ**

**프레젠테이션을 변환하려면 Microsoft PowerPoint가 필요합니까?**

아니요. Aspose.Slides for Python via .NET은 독립 실행형 라이브러리이며 Microsoft PowerPoint 또는 Office 자동화를 필요로 하지 않습니다.

**많은 프레젠테이션을 일괄 변환할 수 있나요?**

예. 각 프레젠테이션을 로드하고, 필요한 형식으로 저장한 뒤 처리 후 프레젠테이션 객체를 해제하면 됩니다. 병렬 처리를 위해서는 별도의 프레젠테이션 인스턴스를 사용하고 [multithreading](/slides/ko/python-net/multithreading/) 안내를 따르십시오.

**선택된 슬라이드만 내보낼 수 있나요?**

예. 여러 내보내기 메서드가 슬라이드 인덱스를 전달하거나 개별 슬라이드를 렌더링하도록 지원합니다. 대상 형식에 대한 전용 문서를 확인하십시오.

**PDF 또는 XPS로 내보낼 때 숨김 슬라이드를 포함할 수 있나요?**

예. 숨김 슬라이드 내보내기 설정은 [PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/)와 [XPS](/slides/ko/python-net/convert-powerpoint-to-xps/) 변환 문서에 설명되어 있습니다.

**PDF/A 출력이 가능한가요?**

예. PDF 내보내기에서 규격 준수 설정을 사용할 수 있습니다. 자세한 내용은 [Convert PowerPoint to PDF](/slides/ko/python-net/convert-powerpoint-to-pdf/)를 참고하십시오.

**변환 중에 글꼴은 어떻게 처리되나요?**

Aspose.Slides는 임베디드 글꼴, 글꼴 대체 및 글꼴 교체 설정을 지원합니다. 자세한 내용은 [Embedded Font](/slides/ko/python-net/embedded-font/), [Fallback Font](/slides/ko/python-net/fallback-font/) 및 [Font Substitution](/slides/ko/python-net/font-substitution/)을 확인하십시오.