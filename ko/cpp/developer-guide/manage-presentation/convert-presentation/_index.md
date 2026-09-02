---
title: C++에서 여러 형식으로 프레젠테이션 변환
linktitle: 프레젠테이션 변환
type: docs
weight: 70
url: /ko/cpp/convert-presentation/
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
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 PPTX, PDF, HTML, 이미지, XPS, TIFF 등으로 변환합니다."
---
## **개요**

Aspose.Slides for C++는 Microsoft PowerPoint, OpenOffice 또는 LibreOffice 없이 PowerPoint 및 OpenDocument 프레젠테이션을 로드하고 다른 많은 형식으로 저장하거나 렌더링할 수 있습니다. 레거시 PPT 파일을 최신 PPTX로 변환하고, 프레젠테이션을 PDF 및 XPS와 같은 고정 레이아웃 문서로 내보내며, 슬라이드를 HTML로 게시하거나 미리보기, 썸네일 및 아카이브용 이미지 파일로 렌더링할 수 있습니다.

대부분의 문서 변환은 동일한 일반 워크플로를 사용합니다: 소스 파일을 로드하고, 필요한 출력 형식을 선택한 다음 필요에 따라 형식별 옵션을 적용합니다. 이미지 형식의 경우 각 슬라이드를 별도로 렌더링한 후 래스터 또는 벡터 이미지로 저장합니다. 아래 링크된 전용 기사에서 각 경우에 대한 구현 세부 정보를 확인할 수 있습니다.

## **변환 시나리오 선택**

아래 문서를 사용하면 완전한 C++ 예제와 형식별 옵션을 확인할 수 있습니다.

| 시나리오 | 필요할 때 | 문서 |
| --- | --- | --- |
| PPT/PPTX/ODP를 PPTX로 | 레거시 PPT 파일을 최신화하거나 기존 PPTX 파일을 표준화하거나 OpenDocument 프레젠테이션을 PowerPoint PPTX로 변환할 때. | [PPT를 PPTX로 변환](/slides/ko/cpp/convert-ppt-to-pptx/), [ODP를 PPTX로 변환](/slides/ko/cpp/convert-odp-to-pptx/), [프레젠테이션 저장](/slides/ko/cpp/save-presentation/) |
| PPTX를 PPT로 | 최신 PowerPoint 프레젠테이션을 오래된 이진 PPT 형식으로 저장하여 이전 워크플로와의 호환성을 유지할 때. | [PPTX를 PPT로 변환](/slides/ko/cpp/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP를 PDF로 | 공유, 인쇄 또는 아카이브용으로 휴대 가능하고 검색 가능한 고정 레이아웃 문서를 만들 때. | [PowerPoint를 PDF로 변환](/slides/ko/cpp/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP를 PDF(노트 포함)로 | 슬라이드 내용과 함께 발표자 노트를 내보낼 때. | [PowerPoint를 PDF(노트 포함)로 변환](/slides/ko/cpp/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP를 HTML로 | 프레젠테이션을 HTML 페이지로 게시하고 이미지, 글꼴, 노트 및 반응형 레이아웃 옵션을 제어할 때. | [PowerPoint를 HTML로 변환](/slides/ko/cpp/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP를 HTML5로 | 형식과 상호 작용을 유지하면서 브라우저 기반 보기용 HTML5로 슬라이드를 내보낼 때. | [프레젠테이션을 HTML5로 내보내기](/slides/ko/cpp/export-to-html5/) |
| PPT/PPTX/ODP를 PNG로 | 미리보기, 썸네일 또는 웹 출력용으로 각 슬라이드를 PNG 이미지로 렌더링할 때. | [PowerPoint를 PNG로 변환](/slides/ko/cpp/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP를 JPG로 | 슬라이드를 JPG 이미지로 렌더링하고 이미지 크기와 품질을 제어할 때. | [PowerPoint를 JPG로 변환](/slides/ko/cpp/convert-powerpoint-to-jpg/) |
| 슬라이드를 SVG로 | 개별 슬라이드를 확장 가능한 벡터 그래픽으로 내보낼 때. | [슬라이드를 SVG로 렌더링](/slides/ko/cpp/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP를 XPS로 | 고정 레이아웃 XPS 문서를 생성할 때. | [PowerPoint를 XPS로 변환](/slides/ko/cpp/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP를 TIFF로 | 인쇄, 스캔, 팩스 또는 아카이브 워크플로용 다중 페이지 TIFF 파일로 프레젠테이션을 저장할 때. | [PowerPoint를 TIFF로 변환](/slides/ko/cpp/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP를 TIFF(노트 포함)로 | 슬라이드와 발표자 노트를 함께 TIFF로 저장할 때. | [PowerPoint를 TIFF(노트 포함)로 변환](/slides/ko/cpp/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX를 Word로 | 문서 형식 출력이 필요할 때 슬라이드를 Word 문서로 변환할 때. | [PowerPoint를 Word로 변환](/slides/ko/cpp/convert-powerpoint-to-word/) |
| PPT/PPTX를 Markdown으로 | 문서화 및 텍스트 기반 워크플로를 위해 프레젠테이션 콘텐츠를 Markdown으로 추출할 때. | [PowerPoint를 Markdown으로 변환](/slides/ko/cpp/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP를 XML로 | 검사, 비교, 문제 해결 또는 XML 기반 워크플로를 위해 텍스트 기반 PowerPoint XML 프레젠테이션을 만들 때. | [PowerPoint를 XML로 변환](/slides/ko/cpp/convert-powerpoint-to-xml/) |
| PPT/PPTX를 애니메이션 GIF로 | 슬라이드에서 애니메이션 GIF를 만들 때. | [PowerPoint를 애니메이션 GIF로 변환](/slides/ko/cpp/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX를 비디오로 | 프레젠테이션 슬라이드에서 비디오 내보내기 워크플로를 구축할 때. | [PowerPoint를 비디오로 변환](/slides/ko/cpp/convert-powerpoint-to-video/) |
| 프레젠테이션을 XAML로 | C++ UI 시나리오용으로 슬라이드를 XAML로 내보낼 때. | [프레젠테이션을 XAML로 내보내기](/slides/ko/cpp/export-to-xaml/) |

입출력 형식 전체 목록은 [지원 파일 형식](/slides/ko/cpp/supported-file-formats/)을 참조하십시오.

## **PowerPoint와 OpenDocument 변환**

Aspose.Slides for C++는 PPT, PPTX, PPS, PPSX, POT, POTX 및 ODP와 같은 일반적으로 사용되는 프레젠테이션 형식 간 변환을 지원합니다. 동일한 변환 API가 PowerPoint와 OpenDocument 파일 모두에 사용되므로 PPTX 파일을 PDF로 저장하는 워크플로는 입력 파일만 ODP로 바꾸면 일반적으로 ODP 파일에도 적용할 수 있습니다.

ODP 파일을 변환할 때는 PowerPoint와 OpenDocument 애플리케이션이 모든 레이아웃 및 서식 기능을 정확히 동일하게 지원하지 않는다는 점을 기억하십시오. ODP 파일이 LibreOffice 또는 OpenOffice Impress에서 생성된 경우 출력 결과를 검토하고 형식별 안내가 필요할 때는 [OpenDocument 프레젠테이션 변환](/slides/ko/cpp/convert-openoffice-odp/)에 설명된 옵션을 사용하십시오.

## **PPT를 PPTX로 변환**

PPT는 오래된 이진 PowerPoint 형식이며, PPTX는 최신 Office Open XML 형식입니다. Aspose.Slides for C++는 마스터, 레이아웃, 슬라이드, 차트, 그룹화된 도형, 자리표시자, 텍스트 프레임, 텍스처 및 그림 채우기와 같은 복잡한 프레젠테이션 구조를 보존하면서 높은 충실도의 PPT에서 PPTX 변환을 지원합니다.

자세한 내용은 [PPT를 PPTX로 변환](/slides/ko/cpp/convert-ppt-to-pptx/)을 참조하십시오.

## **고정 레이아웃 내보내기**

PDF, XPS 및 TIFF는 출력이 장치 간에 동일하게 보이고 프레젠테이션으로 편집되지 않아야 할 때 유용합니다. 전용 PDF, XPS 및 TIFF 기사에서는 규격 준수, 숨겨진 슬라이드, 노트, 이미지 품질, 압축, 픽셀 형식 및 출력 크기를 제어하는 방법을 설명합니다.

## **HTML 및 이미지 내보내기**

HTML 및 HTML5 내보내기는 브라우저 보기, 웹 게시 및 경량 공유에 유용합니다. 이미지 내보내기는 각 슬라이드를 별도의 미리보기, 썸네일 또는 래스터 자산으로 만들어야 할 때 유용합니다. 형식별 렌더링 지침은 PNG, JPG 및 SVG 기사를 확인하십시오.

## **FAQ**

**프레젠테이션을 변환하려면 Microsoft PowerPoint가 필요합니까?**

아니요. Aspose.Slides for C++는 독립 실행형 라이브러리이며 Microsoft PowerPoint 또는 Office 자동화를 필요로 하지 않습니다.

**많은 프레젠테이션을 일괄 변환할 수 있나요?**

예. 각 프레젠테이션을 로드하고 필요한 형식으로 저장한 후 처리 후에 프레젠테이션 객체를 해제하십시오. 병렬 처리를 위해서는 별도의 프레젠테이션 인스턴스를 사용하고 [멀티스레딩](/slides/ko/cpp/multithreading/) 지침을 따르십시오.

**선택한 슬라이드만 내보낼 수 있나요?**

예. 여러 내보내기 방법에서 슬라이드 인덱스를 전달하거나 출력 형식에 따라 개별 슬라이드를 렌더링할 수 있습니다. 대상 형식에 대한 전용 기사를 확인하십시오.

**PDF 또는 XPS로 내보낼 때 숨겨진 슬라이드를 포함할 수 있나요?**

예. [PDF](/slides/ko/cpp/convert-powerpoint-to-pdf/) 및 [XPS](/slides/ko/cpp/convert-powerpoint-to-xps/) 변환 기사에 설명된 숨겨진 슬라이드 내보내기 설정을 사용하십시오.

**PDF/A 출력을 만들 수 있나요?**

예. PDF 내보내기에는 PDF 규격 준수 설정이 제공됩니다. 자세한 내용은 [PowerPoint를 PDF로 변환](/slides/ko/cpp/convert-powerpoint-to-pdf/)을 참조하십시오.

**변환 중에 글꼴은 어떻게 처리되나요?**

Aspose.Slides는 포함된 글꼴, 글꼴 대체 및 글꼴 교체 설정을 사용할 수 있습니다. 자세한 내용은 [Embedded Font](/slides/ko/cpp/embedded-font/), [Fallback Font](/slides/ko/cpp/fallback-font/) 및 [Font Substitution](/slides/ko/cpp/font-substitution/)을 확인하십시오.