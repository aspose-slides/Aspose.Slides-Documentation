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
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 PPTX, PDF, HTML, 이미지, XPS, TIFF 등 다양한 형식으로 변환합니다."
---
## **개요**

Aspose.Slides for Node.js via Java는 Microsoft PowerPoint, OpenOffice, LibreOffice 없이도 PowerPoint 및 OpenDocument 프레젠테이션을 로드하고 다양한 다른 형식으로 저장하거나 렌더링할 수 있습니다. 레거시 PPT 파일을 최신 PPTX로 변환하고, PDF·XPS와 같은 고정 레이아웃 문서로 내보내며, 슬라이드를 HTML로 게시하거나 미리보기, 썸네일, 아카이브용 이미지 파일로 렌더링할 수 있습니다.

대부분의 문서 변환은 동일한 일반 워크플로를 사용합니다: 소스 파일을 로드하고, 필요한 출력 형식을 선택한 뒤, 필요에 따라 형식별 옵션을 적용합니다. 이미지 형식의 경우 각 슬라이드를 개별적으로 렌더링한 뒤 래스터 또는 벡터 이미지로 저장합니다. 아래 링크된 전용 문서에서 각 경우에 대한 구현 세부 정보를 확인할 수 있습니다.

## **변환 시나리오 선택**

아래 문서를 참고하여 완전한 JavaScript 예제와 형식별 옵션을 확인하십시오.

| 시나리오 | 필요한 경우 | 문서 |
| --- | --- | --- |
| PPT/PPTX/ODP → PPTX | 레거시 PPT 파일을 최신 형식으로 현대화하거나, 기존 PPTX 파일을 정규화하거나, OpenDocument 프레젠테이션을 PowerPoint PPTX로 변환합니다. | [PPT를 PPTX로 변환](/slides/ko/nodejs-java/convert-ppt-to-pptx/), [ODP를 PPTX로 변환](/slides/ko/nodejs-java/convert-odp-to-pptx/), [프레젠테이션 저장](/slides/ko/nodejs-java/save-presentation/) |
| PPTX → PPT | 최신 PowerPoint 프레젠테이션을 오래된 바이너리 PPT 형식으로 저장하여 오래된 워크플로와 호환성을 유지합니다. | [PPTX를 PPT로 변환](/slides/ko/nodejs-java/convert-pptx-to-ppt/) |
| PPT/PPTX/ODP → PDF | 공유, 인쇄 또는 아카이브용으로 휴대 가능하고 검색 가능한 고정 레이아웃 문서를 생성합니다. | [PowerPoint를 PDF로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/) |
| PPT/PPTX/ODP → PDF(노트 포함) | 슬라이드 내용과 함께 발표자 노트를 내보냅니다. | [PowerPoint를 노트와 함께 PDF로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-pdf-with-notes/) |
| PPT/PPTX/ODP → HTML | 프레젠테이션을 HTML 페이지로 게시하고 이미지, 글꼴, 노트 및 반응형 레이아웃 옵션을 제어합니다. | [PowerPoint를 HTML로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-html/) |
| PPT/PPTX/ODP → HTML5 | 포맷과 상호 작용을 유지하면서 브라우저 기반 보기용 HTML5로 슬라이드를 내보냅니다. | [프레젠테이션을 HTML5로 내보내기](/slides/ko/nodejs-java/export-to-html5/) |
| PPT/PPTX/ODP → PNG | 미리보기, 썸네일 또는 웹 출력을 위해 각 슬라이드를 PNG 이미지로 렌더링합니다. | [PowerPoint를 PNG로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-png/) |
| PPT/PPTX/ODP → JPG | 슬라이드를 JPG 이미지로 렌더링하고 이미지 크기와 품질을 제어합니다. | [PowerPoint를 JPG로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-jpg/) |
| 슬라이드 → SVG | 개별 슬라이드를 확장 가능한 벡터 그래픽(SVG)으로 내보냅니다. | [슬라이드를 SVG로 렌더링](/slides/ko/nodejs-java/render-a-slide-as-an-svg-image/) |
| PPT/PPTX/ODP → XPS | 고정 레이아웃 XPS 문서를 생성합니다. | [PowerPoint를 XPS로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-xps/) |
| PPT/PPTX/ODP → TIFF | 인쇄, 스캔, 팩스 또는 아카이브 워크플로용 다중 페이지 TIFF 파일로 저장합니다. | [PowerPoint를 TIFF로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-tiff/) |
| PPT/PPTX/ODP → TIFF(노트 포함) | 슬라이드와 발표자 노트를 포함한 TIFF를 저장합니다. | [PowerPoint를 노트와 함께 TIFF로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-tiff-with-notes/) |
| PPT/PPTX → Markdown | 문서화 및 텍스트 기반 워크플로를 위해 프레젠테이션 내용을 Markdown으로 추출합니다. | [PowerPoint를 Markdown으로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-markdown/) |
| PPT/PPTX/ODP → XML | 검사, 비교, 문제 해결 또는 XML 기반 워크플로를 위해 텍스트 기반 PowerPoint XML 프레젠테이션을 생성합니다. | [PowerPoint를 XML로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-xml/) |
| PPT/PPTX → 애니메이션 GIF | 슬라이드에서 애니메이션 GIF를 생성합니다. | [PowerPoint를 애니메이션 GIF로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-animated-gif/) |
| PPT/PPTX → 비디오 | 프레젠테이션 슬라이드에서 비디오 내보내기 워크플로를 구축합니다. | [PowerPoint를 비디오로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-video/) |
| 프레젠테이션 → XAML | JavaScript 또는 Java UI 시나리오를 위해 슬라이드를 XAML로 내보냅니다. | [프레젠테이션을 XAML로 내보내기](/slides/ko/nodejs-java/export-to-xaml/) |

입력 및 출력 형식에 대한 더 넓은 목록은 [지원되는 파일 형식](/slides/ko/nodejs-java/supported-file-formats/)을 참조하십시오.

## **PowerPoint 및 OpenDocument 변환**

Aspose.Slides for Node.js via Java는 PPT, PPTX, PPS, PPSX, POT, POTX 및 ODP와 같은 일반적으로 사용되는 프레젠테이션 형식 간 변환을 지원합니다. 동일한 변환 API가 PowerPoint와 OpenDocument 파일 모두에 적용되므로, PPTX 파일을 PDF로 저장하는 워크플로는 입력 파일만 ODP로 바꾸면 그대로 사용할 수 있습니다.

ODP 파일을 변환할 때는 PowerPoint와 OpenDocument 애플리케이션이 모든 레이아웃 및 서식 기능을 정확히 동일하게 지원하지 않는다는 점을 기억하십시오. LibreOffice 또는 OpenOffice Impress에서 만든 ODP 파일인 경우, 결과물을 검토하고 형식별 지침이 필요할 때는 [OpenDocument 프레젠테이션 변환](/slides/ko/nodejs-java/convert-openoffice-odp/)에 설명된 옵션을 사용하십시오.

## **PPT를 PPTX로 변환**

PPT는 오래된 바이너리 PowerPoint 형식이고, PPTX는 최신 Office Open XML 형식입니다. Aspose.Slides for Node.js via Java는 마스터, 레이아웃, 슬라이드, 차트, 그룹화된 도형, 플레이스홀더, 텍스트 프레임, 텍스처 및 사진 채우기와 같은 복잡한 프레젠테이션 구조를 보존하면서 높은 정확도로 PPT를 PPTX로 변환합니다.

자세한 내용은 [PPT를 PPTX로 변환](/slides/ko/nodejs-java/convert-ppt-to-pptx/) 및 [PPT와 PPTX 비교](/slides/ko/nodejs-java/ppt-vs-pptx/)를 참조하십시오.

## **고정 레이아웃 내보내기**

PDF, XPS 및 TIFF는 출력이 기기마다 동일하게 보이고 프레젠테이션으로 편집되지 않아야 할 때 유용합니다. 전용 PDF, XPS, TIFF 문서에서는 규격 준수, 숨겨진 슬라이드, 노트, 이미지 품질, 압축, 픽셀 포맷 및 출력 크기를 제어하는 방법을 설명합니다.

## **HTML 및 이미지 내보내기**

HTML 및 HTML5 내보내기는 브라우저 보기, 웹 게시 및 경량 공유에 유용합니다. 이미지 내보내기는 각 슬라이드를 개별 미리보기, 썸네일 또는 래스터 자산으로 만들 때 유용합니다. 형식별 렌더링 가이드는 PNG, JPG 및 SVG 문서를 참고하십시오.

## **FAQ**

**발표를 변환하려면 Microsoft PowerPoint가 필요합니까?**

아니요. Aspose.Slides for Node.js via Java는 독립 실행형 라이브러리이며 Microsoft PowerPoint 또는 Office 자동화를 필요로 하지 않습니다.

**여러 프레젠테이션을 일괄 변환할 수 있나요?**

네. 각 프레젠테이션을 로드하고 필요한 형식으로 저장한 뒤 처리 후 프레젠테이션 객체를 폐기하십시오. 병렬 처리가 필요하면 별도의 프레젠테이션 인스턴스를 사용하고 [멀티스레딩](/slides/ko/nodejs-java/multithreading/) 가이드를 따르세요.

**선택된 슬라이드만 내보낼 수 있나요?**

네. 여러 내보내기 방법에서 슬라이드 인덱스를 전달하거나 개별 슬라이드를 렌더링할 수 있습니다. 대상 형식에 대한 전용 문서를 확인하십시오.

**PDF 또는 XPS로 내보낼 때 숨겨진 슬라이드를 포함할 수 있나요?**

네. [PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/) 및 [XPS](/slides/ko/nodejs-java/convert-powerpoint-to-xps/) 변환 문서에 설명된 숨겨진 슬라이드 내보내기 설정을 사용하십시오.

**PDF/A 출력을 생성할 수 있나요?**

네. PDF 내보내기에서는 PDF 규격 준수 설정이 제공됩니다. 자세한 내용은 [PowerPoint를 PDF로 변환](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/)을 참조하십시오.

**변환 중에 글꼴은 어떻게 처리되나요?**

Aspose.Slides는 임베드된 글꼴, 글꼴 대체 및 글꼴 교체 설정을 사용할 수 있습니다. 자세한 내용은 [임베드된 글꼴](/slides/ko/nodejs-java/embedded-font/), [대체 글꼴](/slides/ko/nodejs-java/fallback-font/), [글꼴 교체](/slides/ko/nodejs-java/font-substitution/) 문서를 확인하십시오.