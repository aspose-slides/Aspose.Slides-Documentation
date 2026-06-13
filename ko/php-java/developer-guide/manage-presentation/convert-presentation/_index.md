---
title: PHP에서 프레젠테이션을 여러 형식으로 변환
linktitle: 프레젠테이션 변환
type: docs
weight: 70
url: /ko/php-java/convert-presentation/
keywords:
- 프레젠테이션 변환
- 프레젠테이션 내보내기
- PPT에서 PPTX로
- PPTX에서 PPT로
- ODP에서 PPTX로
- PPT에서 PDF로
- PPTX에서 PDF로
- ODP에서 PDF로
- PPT에서 HTML로
- PPTX에서 HTML로
- ODP에서 HTML로
- PPT에서 PNG로
- PPTX에서 PNG로
- ODP에서 PNG로
- PPTX에서 JPG로
- ODP에서 JPG로
- PPT에서 XPS로
- PPTX에서 XPS로
- ODP에서 XPS로
- PPT에서 TIFF로
- PPTX에서 TIFF로
- ODP에서 TIFF로
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: Aspose.Slides for PHP via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 PPTX, PDF, HTML, 이미지, XPS, TIFF 등 다양한 형식으로 변환합니다.
---
## **개요**

Aspose.Slides for PHP via Java는 Microsoft PowerPoint, OpenOffice 또는 LibreOffice 없이도 PowerPoint 및 OpenDocument 프레젠테이션을 로드하고 다양한 다른 형식으로 저장하거나 렌더링할 수 있습니다. 레거시 PPT 파일을 최신 PPTX로 변환하고, 프레젠테이션을 PDF 및 XPS와 같은 고정 레이아웃 문서로 내보내며, 슬라이드를 HTML로 게시하거나, 미리보기, 썸네일 및 보관용 이미지 파일로 렌더링할 수 있습니다.

대부분의 문서 변환은 동일한 일반 워크플로를 사용합니다: 원본 파일을 로드하고, 필요한 출력 형식을 선택한 뒤, 필요에 따라 형식별 옵션을 적용합니다. 이미지 형식의 경우 각 슬라이드를 별도로 렌더링한 후 래스터 또는 벡터 이미지로 저장합니다. 아래 링크된 전용 문서에서 각 사례에 대한 구현 세부 사항을 확인할 수 있습니다.

## **변환 시나리오 선택**

| 시나리오 | 필요할 때 | 문서 |
| --- | --- | --- |
| PPT/PPTX/ODP를 PPTX로 변환 | 레거시 PPT 파일을 최신화하고, 기존 PPTX 파일을 정규화하거나, OpenDocument 프레젠테이션을 PowerPoint PPTX 로 변환합니다. | [PPT를 PPTX로 변환](/slides/ko/php-java/convert-ppt-to-pptx/), [ODP를 PPTX로 변환](/slides/ko/php-java/convert-odp-to-pptx/), [프레젠테이션 저장](/slides/ko/php-java/save-presentation/) |
| PPTX를 PPT로 변환 | 현대적인 PowerPoint 프레젠테이션을 이전 워크플로와 호환되도록 오래된 바이너리 PPT 형식으로 저장합니다. | [PPTX를 PPT로 변환](/slides/ko/php-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP를 PDF로 변환 | 공유, 인쇄 또는 보관을 위한 휴대 가능하고 검색 가능하며 고정 레이아웃 문서를 생성합니다. | [PowerPoint를 PDF로 변환](/slides/ko/php-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP를 노트와 함께 PDF로 변환 | 슬라이드 내용과 함께 발표자 노트를 내보냅니다. | [PowerPoint를 노트와 함께 PDF로 변환](/slides/ko/php-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP를 HTML로 변환 | 프레젠테이션을 HTML 페이지로 게시하고 이미지, 글꼴, 노트 및 반응형 레이아웃 옵션을 제어합니다. | [PowerPoint를 HTML로 변환](/slides/ko/php-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP를 HTML5로 변환 | 형식과 대화성을 유지한 채 브라우저 기반 보기용으로 슬라이드를 HTML5 로 내보냅니다. | [프레젠테이션을 HTML5로 변환](/slides/ko/php-java/export-to-html5/) |
| PPT/PPTX/ODP를 PNG로 변환 | 미리보기, 썸네일 또는 웹 출력을 위해 각 슬라이드를 PNG 이미지로 렌더링합니다. | [PowerPoint를 PNG로 변환](/slides/ko/php-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP를 JPG로 변환 | 슬라이드를 JPG 이미지로 렌더링하고 이미지 크기 및 품질을 제어합니다. | [PowerPoint를 JPG로 변환](/slides/ko/php-java/convert-powerpoint-to-jpg/) |
| 슬라이드를 SVG로 변환 | 개별 슬라이드를 확대 가능한 벡터 그래픽(SVG)으로 내보냅니다. | [슬라이드를 SVG로 렌더링](/slides/ko/php-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP를 XPS로 변환 | 고정 레이아웃 XPS 문서를 생성합니다. | [PowerPoint를 XPS로 변환](/slides/ko/php-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP를 TIFF로 변환 | 프레젠테이션을 인쇄, 스캔, 팩스 또는 보관 워크플로를 위한 다중 페이지 TIFF 파일로 저장합니다. | [PowerPoint를 TIFF로 변환](/slides/ko/php-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP를 노트와 함께 TIFF로 변환 | 발표자 노트가 포함된 슬라이드를 TIFF로 저장합니다. | [PowerPoint를 노트와 함께 TIFF로 변환](/slides/ko/php-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX를 Markdown으로 변환 | 문서화 및 텍스트 기반 워크플로를 위해 프레젠테이션 내용을 Markdown으로 추출합니다. | [PowerPoint를 Markdown으로 변환](/slides/ko/php-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX를 애니메이션 GIF로 변환 | 슬라이드로부터 애니메이션 GIF를 생성합니다. | [PowerPoint를 애니메이션 GIF로 변환](/slides/ko/php-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX를 비디오로 변환 | 프레젠테이션 슬라이드에서 비디오 내보내기 워크플로를 구축합니다. | [PowerPoint를 비디오로 변환](/slides/ko/php-java/convert-powerpoint-to-video/) |
| 프레젠테이션을 XAML로 변환 | PHP 또는 Java UI 시나리오를 위해 슬라이드를 XAML로 내보냅니다. | [프레젠테이션을 XAML로 내보내기](/slides/ko/php-java/export-to-xaml/) |

입력 및 출력 형식의 더 많은 목록은 [지원되는 파일 형식](/slides/ko/php-java/supported-file-formats/)를 참조하십시오.

## **PowerPoint 및 OpenDocument 변환**

Aspose.Slides for PHP via Java는 PPT, PPTX, PPS, PPSX, POT, POTX 및 ODP와 같은 일반적으로 사용되는 프레젠테이션 형식 간 변환을 지원합니다. 동일한 변환 API가 PowerPoint와 OpenDocument 파일에 모두 적용되므로, PPTX 파일을 PDF로 저장하는 워크플로는 일반적으로 입력 파일만 ODP로 변경하면 ODP 파일에도 적용할 수 있습니다.

ODP 파일을 변환할 때는 PowerPoint와 OpenDocument 응용 프로그램이 모든 레이아웃 및 서식 기능을 완전히 동일하게 지원하지 않음을 기억하십시오. ODP 파일이 LibreOffice 또는 OpenOffice Impress에서 생성된 경우, 출력 결과를 검토하고 형식별 지침이 필요할 때 [OpenDocument 프레젠테이션 변환](/slides/ko/php-java/convert-openoffice-odp/)에 설명된 옵션을 사용하십시오.

## **PPT에서 PPTX로 변환**

PPT는 오래된 바이너리 PowerPoint 형식이며, PPTX는 최신 Office Open XML 형식입니다. Aspose.Slides for PHP via Java는 마스터, 레이아웃, 슬라이드, 차트, 그룹화된 도형, 자리 표시자, 텍스트 프레임, 텍스처 및 사진 채우기와 같은 복잡한 프레젠테이션 구조를 보존하면서 고품질 PPT를 PPTX로 변환하는 것을 지원합니다.

자세한 내용은 [PPT를 PPTX로 변환](/slides/ko/php-java/convert-ppt-to-pptx/) 및 [PPT와 PPTX 비교](/slides/ko/php-java/ppt-vs-pptx/)를 참조하십시오.

## **고정 레이아웃 내보내기**

PDF, XPS 및 TIFF는 출력이 장치 간에 동일하게 보이고 프레젠테이션으로 편집되지 않아야 할 때 유용합니다. 전용 PDF, XPS, TIFF 문서에서는 규격 준수, 숨김 슬라이드, 노트, 이미지 품질, 압축, 픽셀 형식 및 출력 크기를 제어하는 방법을 설명합니다.

## **HTML 및 이미지 내보내기**

HTML 및 HTML5 내보내기는 브라우저 보기, 웹 게시 및 경량 공유에 유용합니다. 이미지 내보내기는 각 슬라이드를 개별 미리보기, 썸네일 또는 래스터 자산으로 변환해야 할 때 유용합니다. 형식별 렌더링 지침은 PNG, JPG 및 SVG 문서를 참고하십시오.

## **FAQ**

**프레젠테이션을 변환하려면 Microsoft PowerPoint가 필요합니까?**

아니요. Aspose.Slides for PHP via Java는 독립형 라이브러리이며 Microsoft PowerPoint 또는 Office 자동화가 필요하지 않습니다.

**여러 프레젠테이션을 일괄 변환할 수 있나요?**

예. 각 프레젠테이션을 로드하고 필요한 형식으로 저장한 뒤 처리 후 프레젠테이션 객체를 해제합니다. 병렬 처리를 위해서는 별도의 프레젠테이션 인스턴스를 사용하고 [멀티스레딩](/slides/ko/php-java/multithreading/) 가이드를 따르십시오.

**선택한 슬라이드만 내보낼 수 있나요?**

예. 출력 형식에 따라 슬라이드 인덱스를 전달하거나 개별 슬라이드를 렌더링할 수 있는 여러 내보내기 방법이 있습니다. 대상 형식에 대한 전용 문서를 확인하십시오.

**PDF 또는 XPS로 내보낼 때 숨겨진 슬라이드를 포함할 수 있나요?**

예. [PDF](/slides/ko/php-java/convert-powerpoint-to-pdf/) 및 [XPS](/slides/ko/php-java/convert-powerpoint-to-xps/) 변환 문서에 설명된 숨겨진 슬라이드 내보내기 설정을 사용하십시오.

**PDF/A 출력을 생성할 수 있나요?**

예. PDF 내보내기를 위한 PDF 준수 설정이 제공됩니다. 자세한 내용은 [PowerPoint를 PDF로 변환](/slides/ko/php-java/convert-powerpoint-to-pdf/)를 참조하십시오.

**변환 중에 글꼴은 어떻게 처리됩니까?**

Aspose.Slides는 포함된 글꼴, 글꼴 대체 및 글꼴 교체 설정을 사용할 수 있습니다. [내장 글꼴](/slides/ko/php-java/embedded-font/), [대체 글꼴](/slides/ko/php-java/fallback-font/), 및 [글꼴 교체](/slides/ko/php-java/font-substitution/)을 확인하십시오.