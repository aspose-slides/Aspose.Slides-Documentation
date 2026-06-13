---
title: JavaScript에서 프레젠테이션을 여러 형식으로 변환
linktitle: 프레젠테이션 변환
type: docs
weight: 70
url: /ko/nodejs-java/convert-presentation/
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
- 파워포인트
- 오픈도큐먼트
- Node.js
- 자바스크립트
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 PPTX, PDF, HTML, 이미지, XPS, TIFF 등으로 변환합니다."
---
## **개요**

Aspose.Slides for Node.js via Java는 Microsoft PowerPoint, OpenOffice 또는 LibreOffice 없이 PowerPoint 및 OpenDocument 프레젠테이션을 로드하고 다른 많은 형식으로 저장하거나 렌더링할 수 있습니다. 레거시 PPT 파일을 최신 PPTX로 변환하고, 프레젠테이션을 PDF 및 XPS와 같은 고정 레이아웃 문서로 내보내며, 슬라이드를 HTML로 게시하거나 미리보기, 썸네일 및 보관용 이미지 파일로 렌더링할 수 있습니다.

대부분의 문서 변환은 동일한 일반 워크플로를 사용합니다: 소스 파일을 로드하고, 필요한 출력 형식을 선택하고, 필요에 따라 형식별 옵션을 적용합니다. 이미지 형식의 경우 각 슬라이드를 개별적으로 렌더링한 뒤 래스터 또는 벡터 이미지로 저장합니다. 아래에 링크된 전용 문서에서 각 경우에 대한 구현 세부 정보를 확인할 수 있습니다.

## **변환 시나리오 선택**

아래 문서를 사용하면 완전한 JavaScript 예제와 형식별 옵션을 확인할 수 있습니다.

| 시나리오 | 필요한 경우 | 문서 |
| --- | --- | --- |
| PPT/PPTX/ODP to PPTX | 레거시 PPT 파일을 최신화하고, 기존 PPTX 파일을 정규화하거나 OpenDocument 프레젠테이션을 PowerPoint PPTX로 변환합니다. | [PPT를 PPTX로 변환](/slides/ko/nodejs-java/convert-ppt-to-pptx/), [ODP를 PPTX로 변환](/slides/ko/nodejs-java/convert-odp-to-pptx/), [프레젠테이션 저장](/slides/ko/nodejs-java/save-presentation/) |
| PPTX to PPT | 최신 PowerPoint 프레젠테이션을 이전 이진 PPT 형식으로 저장하여 오래된 워크플로와 호환됩니다. | [PPTX를 PPT로 변환](/slides/ko/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP to PDF | 공유, 인쇄 또는 보관을 위한 휴대 가능하고 검색 가능한 고정 레이아웃 문서를 생성합니다. | [PowerPoint를 PDF로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP to PDF with notes | 슬라이드 내용과 함께 발표자 노트를 내보냅니다. | [PowerPoint를 PDF(노트 포함)로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP to HTML | 프레젠테이션을 HTML 페이지로 게시하고 이미지, 폰트, 노트 및 반응형 레이아웃 옵션을 제어합니다. | [PowerPoint를 HTML로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP to HTML5 | 브라우저 기반 뷰잉을 위해 형식 및 인터랙티브를 보존한 상태로 슬라이드를 HTML5로 내보냅니다. | [프레젠테이션을 HTML5로 변환](/slides/ko/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP to PNG | 미리보기, 썸네일 또는 웹 출력용으로 각 슬라이드를 PNG 이미지로 렌더링합니다. | [PowerPoint를 PNG로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP to JPG | 슬라이드를 JPG 이미지로 렌더링하고 이미지 크기 및 품질을 제어합니다. | [PowerPoint를 JPG로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-jpg/) |
| Slide to SVG | 개별 슬라이드를 확장 가능한 벡터 그래픽(SVG)으로 내보냅니다. | [슬라이드를 SVG로 렌더링](/slides/ko/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP to XPS | 고정 레이아웃 XPS 문서를 생성합니다. | [PowerPoint를 XPS로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP to TIFF | 인쇄, 스캔, 팩스 또는 보관 워크플로를 위해 프레젠테이션을 다중 페이지 TIFF 파일로 저장합니다. | [PowerPoint를 TIFF로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP to TIFF with notes | 발표자 노트를 포함한 슬라이드를 TIFF로 저장합니다. | [PowerPoint를 TIFF(노트 포함)로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX to Markdown | 문서화 및 텍스트 기반 워크플로를 위해 프레젠테이션 내용을 Markdown으로 추출합니다. | [PowerPoint를 Markdown으로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX to animated GIF | 슬라이드에서 애니메이션 GIF를 생성합니다. | [PowerPoint를 애니메이션 GIF로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX to video | 프레젠테이션 슬라이드로부터 비디오 내보내기 워크플로를 구축합니다. | [PowerPoint를 비디오로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-video/) |
| Presentation to XAML | JavaScript 또는 Java UI 시나리오를 위해 슬라이드를 XAML로 내보냅니다. | [프레젠테이션을 XAML로 내보내기](/slides/ko/nodejs-java/export-to-xaml/) |

입출력 형식의 더 넓은 목록은 [지원되는 파일 형식](/slides/ko/nodejs-java/supported-file-formats/)을 참조하십시오.

## **PowerPoint 및 OpenDocument 변환**

Aspose.Slides for Node.js via Java는 PPT, PPTX, PPS, PPSX, POT, POTX 및 ODP와 같은 일반적으로 사용되는 프레젠테이션 형식의 변환을 지원합니다. 동일한 변환 API가 PowerPoint와 OpenDocument 파일에 모두 사용되므로, PPTX 파일을 PDF로 저장하는 워크플로는 입력 파일만 ODP로 바꾸면 보통 ODP 파일에도 적용할 수 있습니다.

ODP 파일을 변환할 때는 PowerPoint와 OpenDocument 애플리케이션이 모든 레이아웃 및 서식 기능을 정확히 동일하게 지원하지 않는다는 점을 기억하십시오. ODP 파일이 LibreOffice 또는 OpenOffice Impress에서 생성된 경우, 출력 결과를 검토하고 형식별 안내가 필요할 때 [OpenDocument 프레젠테이션 변환](/slides/ko/nodejs-java/convert-openoffice-odp/)에 설명된 옵션을 사용하십시오.

## **PPT를 PPTX로 변환**

PPT는 오래된 이진 PowerPoint 형식이며, PPTX는 최신 Office Open XML 형식입니다. Aspose.Slides for Node.js via Java는 마스터, 레이아웃, 슬라이드, 차트, 그룹화된 도형, 자리표시자, 텍스트 프레임, 텍스처 및 사진 채우기와 같은 복잡한 프레젠테이션 구조를 보존하면서 높은 충실도의 PPT→PPTX 변환을 지원합니다.

자세한 내용은 [PPT를 PPTX로 변환](/slides/ko/nodejs-java/convert-ppt-to-pptx/) 및 [PPT vs PPTX](/slides/ko/nodejs-java/ppt-vs-pptx/)를 확인하십시오.

## **고정 레이아웃 내보내기**

PDF, XPS 및 TIFF는 출력이 장치 간에 동일하게 보이고 프레젠테이션으로 편집되지 않아야 할 때 유용합니다. 전용 PDF, XPS 및 TIFF 문서에서는 규격 준수, 숨김 슬라이드, 노트, 이미지 품질, 압축, 픽셀 형식 및 출력 크기를 제어하는 방법을 설명합니다.

## **HTML 및 이미지 내보내기**

HTML 및 HTML5 내보내기는 브라우저 뷰잉, 웹 게시 및 경량 공유에 유용합니다. 이미지 내보내기는 각 슬라이드를 별도의 미리보기, 썸네일 또는 래스터 자산으로 만들어야 할 때 유용합니다. 형식별 렌더링 지침은 PNG, JPG 및 SVG 문서를 참조하십시오.

## **FAQ**

**Microsoft PowerPoint가 필요합니까?**

아니요. Aspose.Slides for Node.js via Java는 독립형 라이브러리이며 Microsoft PowerPoint나 Office 자동화를 필요로 하지 않습니다.

**여러 프레젠테이션을 배치 변환할 수 있나요?**

예. 각 프레젠테이션을 로드하고 필요한 형식으로 저장한 다음 처리 후 프레젠테이션 객체를 해제합니다. 병렬 처리를 위해서는 별도의 프레젠테이션 인스턴스를 사용하고 [멀티스레딩](/slides/ko/nodejs-java/multithreading/) 가이드를 따르십시오.

**선택한 슬라이드만 내보낼 수 있나요?**

예. 여러 내보내기 메서드에서 출력 형식에 따라 슬라이드 인덱스를 전달하거나 개별 슬라이드를 렌더링할 수 있습니다. 대상 형식에 대한 전용 문서를 확인하십시오.

**PDF 또는 XPS로 내보낼 때 숨김 슬라이드를 포함할 수 있나요?**

예. 숨김 슬라이드 내보내기 설정은 [PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/) 및 [XPS](/slides/ko/nodejs-java/convert-powerpoint-to-xps/) 변환 문서에 설명되어 있습니다.

**PDF/A 출력을 만들 수 있나요?**

예. PDF 내보내기에는 PDF 규격 준수 설정이 제공됩니다. 자세한 내용은 [PowerPoint를 PDF로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/)을 참고하십시오.

**변환 중 폰트는 어떻게 처리되나요?**

Aspose.Slides는 내장 폰트, 대체 폰트 및 폰트 대체 설정을 사용할 수 있습니다. 자세한 내용은 [내장 폰트](/slides/ko/nodejs-java/embedded-font/), [대체 폰트](/slides/ko/nodejs-java/fallback-font/) 및 [폰트 대체](/slides/ko/nodejs-java/font-substitution/)를 확인하십시오.