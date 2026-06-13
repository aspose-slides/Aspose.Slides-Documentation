---
title: C++에서 프레젠테이션을 여러 형식으로 변환
linktitle: 프레젠테이션 변환
type: docs
weight: 70
url: /ko/cpp/convert-presentation/
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
- OpenDocument
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 PPTX, PDF, HTML, 이미지, XPS, TIFF 등으로 변환합니다."
---
## **개요**

Aspose.Slides for C++는 Microsoft PowerPoint, OpenOffice 또는 LibreOffice 없이도 PowerPoint 및 OpenDocument 프레젠테이션을 로드하고 다양한 다른 형식으로 저장하거나 렌더링할 수 있습니다. 레거시 PPT 파일을 최신 PPTX로 변환하고, PDF 및 XPS와 같은 고정 레이아웃 문서로 내보내며, 슬라이드를 HTML로 게시하거나 미리보기, 썸네일, 아카이브용 이미지 파일로 렌더링할 수 있습니다.

대부분의 문서 변환은 동일한 일반 워크플로를 사용합니다: 소스 파일을 로드하고, 필요한 출력 형식을 선택한 다음, 필요에 따라 형식별 옵션을 적용합니다. 이미지 형식에서는 각 슬라이드를 별도로 렌더링한 뒤 래스터 또는 벡터 이미지로 저장합니다. 아래 링크된 전용 문서에서 각 경우에 대한 구현 세부 정보를 확인하십시오.

## **변환 시나리오 선택**

아래 문서를 사용하면 전체 C++ 예제와 형식별 옵션을 확인할 수 있습니다.

| 시나리오 | 다음이 필요할 때 사용 | 문서 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | 레거시 PPT 파일을 현대화하고, 기존 PPTX 파일을 정규화하거나 OpenDocument 프레젠테이션을 PowerPoint PPTX로 변환합니다. | [PPT를 PPTX로 변환](/slides/ko/cpp/convert-ppt-to-pptx/), [ODP를 PPTX로 변환](/slides/ko/cpp/convert-odp-to-pptx/), [프레젠테이션 저장](/slides/ko/cpp/save-presentation/) |
| PPTX to PPT | 최신 PowerPoint 프레젠테이션을 이전 바이너리 PPT 형식으로 저장하여 오래된 워크플로와 호환됩니다. | [PPTX를 PPT로 변환](/slides/ko/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 공유, 인쇄 또는 보관을 위해 휴대용 검색 가능 고정 레이아웃 문서를 생성합니다. | [PowerPoint를 PDF로 변환](/slides/ko/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | 슬라이드 내용과 함께 발표자 메모를 내보냅니다. | [PowerPoint를 메모와 함께 PDF로 변환](/slides/ko/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | 프레젠테이션을 HTML 페이지로 게시하고 이미지, 글꼴, 메모 및 반응형 레이아웃 옵션을 제어합니다. | [PowerPoint를 HTML로 변환](/slides/ko/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | 포맷과 상호작용을 유지한 채 브라우저 기반 뷰잉을 위해 슬라이드를 HTML5로 내보냅니다. | [프레젠테이션을 HTML5로 변환](/slides/ko/cpp/export-to-html5/) |
| PPT/PPTX/ODP to PNG | 미리보기, 썸네일 또는 웹 출력을 위해 각 슬라이드를 PNG 이미지로 렌더링합니다. | [PowerPoint를 PNG로 변환](/slides/ko/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | 슬라이드를 JPG 이미지로 렌더링하고 이미지 크기와 품질을 제어합니다. | [PowerPoint를 JPG로 변환](/slides/ko/cpp/convert-powerpoint-to-jpg/) |
| Slide to SVG | 개별 슬라이드를 확장 가능한 벡터 그래픽으로 내보냅니다. | [슬라이드를 SVG로 렌더링](/slides/ko/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 고정 레이아웃 XPS 문서를 생성합니다. | [PowerPoint를 XPS로 변환](/slides/ko/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 인쇄, 스캔, 팩스 또는 보관 워크플로를 위해 프레젠테이션을 다중 페이지 TIFF 파일로 저장합니다. | [PowerPoint를 TIFF로 변환](/slides/ko/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | 슬라이드와 발표자 메모를 TIFF로 저장합니다. | [PowerPoint를 메모와 함께 TIFF로 변환](/slides/ko/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Word | 문서 스타일 출력이 필요할 때 슬라이드를 Word 문서로 변환합니다. | [PowerPoint를 Word로 변환](/slides/ko/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX to Markdown | 문서화 및 텍스트 기반 워크플로를 위해 프레젠테이션 내용을 Markdown으로 추출합니다. | [PowerPoint를 Markdown으로 변환](/slides/ko/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | 슬라이드에서 애니메이션 GIF를 생성합니다. | [PowerPoint를 애니메이션 GIF로 변환](/slides/ko/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | 프레젠테이션 슬라이드에서 비디오 내보내기 워크플로를 구축합니다. | [PowerPoint를 비디오로 변환](/slides/ko/cpp/convert-powerpoint-to-video/) |
| Presentation to XAML | C++ UI 시나리오를 위해 슬라이드를 XAML로 내보냅니다. | [프레젠테이션을 XAML로 내보내기](/slides/ko/cpp/export-to-xaml/) |

입력 및 출력 형식의 전체 목록은 [지원 파일 형식](/slides/ko/cpp/supported-file-formats/)을 참고하십시오.

## **PowerPoint 및 OpenDocument 변환**

Aspose.Slides for C++는 PPT, PPTX, PPS, PPSX, POT, POTX 및 ODP와 같은 일반적으로 사용되는 프레젠테이션 형식 간 변환을 지원합니다. 동일한 변환 API가 PowerPoint와 OpenDocument 파일에 모두 사용되므로, PPTX 파일을 PDF로 저장하는 워크플로는 입력 파일만 ODP로 변경하면 일반적으로 적용할 수 있습니다.

ODP 파일을 변환할 때는 PowerPoint와 OpenDocument 애플리케이션이 모든 레이아웃 및 서식 기능을 정확히 동일하게 지원하지 않음을 기억하십시오. ODP 파일이 LibreOffice 또는 OpenOffice Impress에서 생성된 경우 출력물을 검토하고 형식별 지침이 필요할 때 [OpenDocument 프레젠테이션 변환](/slides/ko/cpp/convert-openoffice-odp/)에 설명된 옵션을 사용하십시오.

## **PPT에서 PPTX 변환**

PPT는 오래된 바이너리 PowerPoint 형식이고, PPTX는 최신 Office Open XML 형식입니다. Aspose.Slides for C++는 마스터, 레이아웃, 슬라이드, 차트, 그룹화된 도형, 자리 표시자, 텍스트 프레임, 질감 및 그림 채우기와 같은 복잡한 프레젠테이션 구조를 보존하면서 고품질 PPT에서 PPTX로 변환을 지원합니다.

자세한 내용은 [PPT를 PPTX로 변환](/slides/ko/cpp/convert-ppt-to-pptx/)을 참고하십시오.

## **고정 레이아웃 내보내기**

출력이 장치 간에 동일하게 보이고 프레젠테이션으로 편집되지 않아야 할 때 PDF, XPS 및 TIFF가 유용합니다. 전용 PDF, XPS 및 TIFF 문서에서는 준수, 숨김 슬라이드, 메모, 이미지 품질, 압축, 픽셀 형식 및 출력 크기를 제어하는 방법을 설명합니다.

## **HTML 및 이미지 내보내기**

HTML 및 HTML5 내보내기는 브라우저 보기, 웹 게시 및 경량 공유에 유용합니다. 이미지 내보내기는 각 슬라이드를 별개의 미리보기, 썸네일 또는 래스터 자산으로 만들 때 유용합니다. 형식별 렌더링 지침은 PNG, JPG 및 SVG 문서를 참고하십시오.

## **FAQ**

**프레젠테이션 변환에 Microsoft PowerPoint가 필요합니까?**

아니요. Aspose.Slides for C++는 독립형 라이브러리이며 Microsoft PowerPoint나 Office 자동화가 필요하지 않습니다.

**여러 프레젠테이션을 배치 변환할 수 있나요?**

네. 각 프레젠테이션을 로드하고 필요한 형식으로 저장한 뒤 처리 후 프레젠테이션 객체를 해제하면 됩니다. 병렬 처리를 위해서는 별도의 프레젠테이션 인스턴스를 사용하고 [멀티스레딩](/slides/ko/cpp/multithreading/) 가이드를 따르십시오.

**선택한 슬라이드만 내보낼 수 있나요?**

네. 여러 내보내기 방법을 통해 출력 형식에 따라 슬라이드 인덱스를 전달하거나 개별 슬라이드를 렌더링할 수 있습니다. 대상 형식에 대한 전용 문서를 참고하십시오.

**PDF 또는 XPS로 내보낼 때 숨김 슬라이드를 포함할 수 있나요?**

네. [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/) 및 [XPS](/slides/ko/cpp/convert-powerpoint-to-xps/) 변환 문서에 설명된 숨김 슬라이드 내보내기 설정을 사용하십시오.

**PDF/A 출력을 생성할 수 있나요?**

네. PDF 내보내기에는 PDF 준수 설정이 제공됩니다. 자세한 내용은 [PowerPoint를 PDF로 변환](/slides/ko/cpp/convert-powerpoint-to-pdf/)을 참고하십시오.

**변환 중 글꼴은 어떻게 처리되나요?**

Aspose.Slides는 포함된 글꼴, 글꼴 대체 및 글꼴 교체 설정을 사용할 수 있습니다. 자세한 내용은 [내장 글꼴](/slides/ko/cpp/embedded-font/), [대체 글꼴](/slides/ko/cpp/fallback-font/), 및 [글꼴 대체](/slides/ko/cpp/font-substitution/)을 참고하십시오.