---
title: Python으로 핸드아웃 모드에서 프레젠테이션 변환
linktitle: 핸드아웃 모드
type: docs
weight: 150
url: /ko/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 핸드아웃 모드
- 핸드아웃
- PowerPoint
- 프레젠테이션
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Python을 사용하여 프레젠테이션을 핸드아웃으로 변환합니다. 페이지당 슬라이드 수를 설정하고, 메모를 유지하며, Aspose.Slides로 PDF 또는 이미지로 내보내고, 샘플 코드와 함께 제공합니다. 무료로 사용해 보세요."
---
## **소개**

Aspose.Slides는 프레젠테이션을 다양한 형식으로 변환할 수 있는 기능을 제공하며, Handout 모드에서 인쇄용 핸드아웃을 만들 수도 있습니다. 이 모드를 사용하면 여러 슬라이드를 한 페이지에 어떻게 배치할지 구성할 수 있어 회의, 세미나 및 기타 행사에 유용합니다. `slides_layout_options` 속성을 [PdfOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmloptions/), 및 [TiffOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/) 클래스에 설정하여 이 모드를 활성화할 수 있습니다.

## **핸드아웃 모드 내보내기**

Handout 모드를 구성하려면 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/handoutlayoutingoptions/) 객체를 사용합니다. 이 객체는 한 페이지에 배치되는 슬라이드 수 및 기타 표시 매개변수를 결정합니다.

다음은 Handout 모드에서 프레젠테이션을 PDF로 변환하는 코드 예제입니다.

```py
# 프레젠테이션을 로드합니다.
with slides.Presentation("sample.pptx") as presentation:

    # 내보내기 옵션을 설정합니다.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 한 페이지에 가로로 4개의 슬라이드
    slides_layout_options.print_slide_numbers = True                                 # 슬라이드 번호를 인쇄합니다
    slides_layout_options.print_frame_slide = True                                   # 슬라이드 주변에 프레임을 인쇄합니다
    slides_layout_options.print_comments = False                                     # 주석 없음

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # 선택한 레이아웃으로 프레젠테이션을 PDF로 내보냅니다.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
`slides_layout_options` 속성은 PDF, HTML, TIFF와 같은 특정 출력 형식 및 이미지로 렌더링할 때만 사용할 수 있습니다.
{{% /alert %}} 

## **FAQ**

**Handout 모드에서 페이지당 최대 슬라이드 썸네일 수는 얼마입니까?**

Aspose.Slides는 가로 또는 세로 정렬이 가능한 페이지당 최대 9개의 썸네일을 지원하며, 프리셋은 1, 2, 3, 4(가로/세로), 6(가로/세로), 9(가로/세로)입니다. 자세한 내용은 [presets](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/handouttype/)를 참조하십시오.

**5개 또는 8개 슬라이드와 같은 맞춤형 그리드를 정의할 수 있나요?**

아니요. 썸네일의 수와 정렬은 [HandoutType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/handouttype/) 열거형에 의해 엄격히 제어되며, 임의 레이아웃은 지원되지 않습니다.

**Handout 출력에 숨겨진 슬라이드를 포함할 수 있나요?**

예. 대상 형식의 내보내기 설정에서 `show_hidden_slides` 옵션을 활성화하면 됩니다. 예시: [PdfOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/htmloptions/), 또는 [TiffOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/).