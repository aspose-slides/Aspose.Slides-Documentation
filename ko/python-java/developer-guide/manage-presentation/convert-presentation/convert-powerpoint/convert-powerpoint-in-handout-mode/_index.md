---
title: 핸드아웃 모드에서 Python을 사용하여 PowerPoint 프레젠테이션 변환
linktitle: 핸드아웃 모드
type: docs
weight: 150
url: /ko/python-java/convert-powerpoint-in-handout-mode/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 핸드아웃 모드
- 핸드아웃
- PPT
- PPTX
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python을 통해 Java에서 PowerPoint 프레젠테이션을 핸드아웃으로 변환합니다. 페이지당 여러 슬라이드를 배열하고 Aspose.Slides를 사용하여 PDF로 내보냅니다."
---
## **Introduction**

Aspose.Slides for Python via Java을 사용하면 핸드아웃 모드로 프레젠테이션을 내보낼 수 있으며, 여러 슬라이드를 한 페이지에 배열할 수 있습니다. 이는 회의, 세미나 및 유사한 행사에서 프레젠테이션 자료를 인쇄할 때 유용합니다.

레이아웃은 [setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 메서드를 통해 구성합니다. 핸드아웃 레이아웃은 [PdfOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/), 및 [TiffOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/)에서 지원됩니다. 레이아웃 및 표시 설정을 지정하려면 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/handoutlayoutingoptions/) 객체를 사용하십시오.

내보내기 전에 핸드아웃 페이지 크기와 방향을 설정하려면 [Notes Page Size](/slides/ko/python-java/notes-size/)를 참조하십시오.

## **Handout Mode Export**

핸드아웃 모드로 프레젠테이션을 내보내려면 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/handoutlayoutingoptions/) 인스턴스를 만들고 이를 대상 내보내기 옵션에 [setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions)로 할당합니다.

다음 예제는 `sample.pptx`를 로드하고 가로 순서로 페이지당 네 개의 슬라이드를 포함하여 PDF로 내보냅니다. 슬라이드 번호와 슬라이드 주변의 프레임을 포함하고 주석은 제외합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# 프레젠테이션을 로드합니다.
presentation = Presentation("sample.pptx")
try:
    # 핸드아웃 레이아웃을 구성합니다.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # 선택한 레이아웃으로 프레젠테이션을 PDF로 내보냅니다.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="경고" %}}
핸드아웃 레이아웃 설정은 PDF, HTML, TIFF 및 렌더링 이미지와 같은 지원되는 출력 형식에 적용됩니다. 원본 프레젠테이션의 슬라이드 순서를 변경하지는 않습니다.
{{% /alert %}}

## **FAQ**

**핸드아웃 모드에서 페이지당 최대 몇 개의 슬라이드 썸네일을 표시할 수 있나요?**

Aspose.Slides는 페이지당 최대 아홉 개의 썸네일을 지원합니다. [HandoutType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/handouttype/) 사전 설정을 사용하면 페이지당 한 개, 두 개, 세 개, 네 개, 여섯 개 또는 아홉 개의 슬라이드를 선택할 수 있습니다. 네 개, 여섯 개, 아홉 개 슬라이드 사전 설정은 가로 및 세로 순서를 모두 제공합니다.

**페이지당 다섯 개 또는 여덟 개와 같은 사용자 정의 그리드를 정의할 수 있나요?**

아니요. 썸네일의 수와 순서는 미리 정의된 [HandoutType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/handouttype/) 값에 의해 제어됩니다. 이러한 핸드아웃 레이아웃 설정으로 임의의 그리드는 지원되지 않습니다.

**핸드아웃 출력에 숨김 슬라이드를 포함할 수 있나요?**

예. 대상 형식의 내보내기 설정에서 숨김 슬라이드를 활성화하십시오. PDF의 경우 저장하기 전에 [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) 메서드를 `True`와 함께 호출하십시오.