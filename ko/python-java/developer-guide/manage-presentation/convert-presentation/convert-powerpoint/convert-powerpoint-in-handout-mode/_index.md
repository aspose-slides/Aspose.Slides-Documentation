---
title: Python을 사용한 핸드아웃 모드에서 PowerPoint 프레젠테이션 변환
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
description: "Python을 통해 Java에서 PowerPoint 프레젠테이션을 핸드아웃으로 변환합니다. 페이지당 여러 슬라이드를 배치하고 Aspose.Slides로 PDF에 내보냅니다."
---
## **소개**

Aspose.Slides for Python via Java을 사용하면 핸드아웃 모드로 프레젠테이션을 내보낼 수 있으며, 하나의 페이지에 여러 슬라이드를 배치합니다. 이는 회의, 세미나 및 유사한 행사에서 프레젠테이션 자료를 인쇄할 때 유용합니다.

레이아웃은 [setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) 메서드로 구성합니다. 핸드아웃 레이아웃은 [PdfOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/htmloptions/) 및 [TiffOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/)에서 지원됩니다. 레이아웃 및 표시 설정을 지정하려면 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/handoutlayoutingoptions/) 객체를 사용하십시오.

## **핸드아웃 모드 내보내기**

핸드아웃 모드로 프레젠테이션을 내보내려면 [HandoutLayoutingOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/handoutlayoutingoptions/) 인스턴스를 생성하고 [setSlidesLayoutOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions)를 사용하여 대상 내보내기 옵션에 할당합니다.

다음 예제는 `sample.pptx`를 로드하고 가로 순서로 페이지당 네 개의 슬라이드가 포함된 PDF로 내보냅니다. 슬라이드 번호와 슬라이드 주변의 프레임을 포함하고, 주석은 제외합니다.

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

{{% alert color="warning" title="Warning" %}}
핸드아웃 레이아웃 설정은 PDF, HTML, TIFF 및 렌더링된 이미지와 같은 지원되는 출력 형식에 적용됩니다. 이 설정은 원본 프레젠테이션의 슬라이드 순서를 변경하지 않습니다.
{{% /alert %}}

## **자주 묻는 질문**

**핸드아웃 모드에서 페이지당 최대 슬라이드 썸네일 수는 얼마입니까?**

Aspose.Slides는 페이지당 최대 아홉 개의 썸네일을 지원합니다. [HandoutType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/handouttype/) 사전 설정은 페이지당 1, 2, 3, 4, 6 또는 9개의 슬라이드를 제공합니다. 4, 6, 9 슬라이드 사전 설정은 가로 및 세로 순서를 지원합니다.

**페이지당 다섯 개 또는 여덟 개와 같은 사용자 정의 그리드를 정의할 수 있나요?**

아니요. 썸네일의 개수와 순서는 미리 정의된 [HandoutType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/handouttype/) 값에 의해 제어됩니다. 임의의 그리드는 이러한 핸드아웃 레이아웃 설정에서 지원되지 않습니다.

**핸드아웃 출력에 숨겨진 슬라이드를 포함할 수 있나요?**

예. 대상 형식에 대한 내보내기 설정에서 숨겨진 슬라이드를 활성화하면 됩니다. PDF의 경우, 프레젠테이션을 저장하기 전에 `True`와 함께 [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides)를 호출합니다.