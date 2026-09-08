---
title: Python via Java에서 프레젠테이션의 고급 텍스트 추출
linktitle: 텍스트 추출
type: docs
weight: 90
url: /ko/python-java/extract-text-from-presentation/
keywords:
- 텍스트 추출
- 슬라이드에서 텍스트 추출
- 프레젠테이션에서 텍스트 추출
- PowerPoint에서 텍스트 추출
- OpenDocument에서 텍스트 추출
- PPT에서 텍스트 추출
- PPTX에서 텍스트 추출
- ODP에서 텍스트 추출
- 텍스트 가져오기
- 슬라이드에서 텍스트 가져오기
- 프레젠테이션에서 텍스트 가져오기
- PowerPoint에서 텍스트 가져오기
- OpenDocument에서 텍스트 가져오기
- PPT에서 텍스트 가져오기
- PPTX에서 텍스트 가져오기
- ODP에서 텍스트 가져오기
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 �스트를 빠르게 추출하세요. 간단하고 단계별 가이드를 따라 시간을 절약하십시오."
---
## **개요**

프레젠테이션에서 텍스트를 추출하는 것은 슬라이드 콘텐츠를 다루는 개발자에게 흔하지만 필수적인 작업입니다. Microsoft PowerPoint 파일(PPT 또는 PPTX 형식)이나 OpenDocument 프레젠테이션(ODP)을 다루든, 텍스트 데이터를 액세스하고 추출하는 것은 분석, 자동화, 인덱싱 또는 콘텐츠 마이그레이션 목적에 매우 중요할 수 있습니다.

이 문서는 Aspose.Slides for Python via Java를 사용하여 PPT, PPTX 및 ODP를 포함한 다양한 프레젠테이션 형식에서 텍스트를 효율적으로 추출하는 방법에 대한 포괄적인 가이드를 제공합니다. 프레젠테이션 요소를 체계적으로 반복하면서 필요한 텍스트 콘텐츠를 정확히 가져오는 방법을 배울 수 있습니다.

## **슬라이드에서 텍스트 추출**

Aspose.Slides for Python via Java는 [SlideUtil](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideutil/) 클래스를 제공합니다. 이 클래스는 프레젠테이션이나 슬라이드에서 모든 텍스트를 추출하기 위한 여러 오버로드된 정적 메서드를 노출합니다. 프레젠테이션의 슬라이드에서 텍스트를 추출하려면 [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideutil/#getAllTextBoxes) 메서드를 사용합니다. 이 메서드는 [BaseSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/) 유형의 객체를 매개변수로 받아들입니다. 실행 시 메서드는 슬라이드 전체를 스캔하여 텍스트를 찾고, 텍스트 형식을 보존한 채 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/) 유형 객체 배열을 반환합니다.

다음 코드 스니펫은 프레젠테이션 첫 번째 슬라이드의 모든 텍스트를 추출합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **프레젠테이션에서 텍스트 추출**

전체 프레젠테이션의 텍스트를 스캔하려면 [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideutil/#getAllTextFrames) 정적 메서드를 사용합니다. 이 메서드는 [SlideUtil](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideutil/) 클래스에 노출되어 있습니다. 두 개의 매개변수를 받습니다.

1. 첫 번째는 텍스트를 추출할 PowerPoint 또는 OpenDocument 프레젠테이션을 나타내는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 객체입니다.
2. 두 번째는 프레젠테이션에서 텍스트를 스캔할 때 마스터 슬라이드를 포함시킬지 여부를 나타내는 `bool` 값입니다.

이 메서드는 텍스트 형식 정보를 포함한 [TextFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/) 유형 객체 배열을 반환합니다. 아래 코드는 마스터 슬라이드를 포함하여 프레젠테이션의 텍스트와 형식 세부 정보를 스캔합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **분류된 빠른 텍스트 추출**

[PresentationFactory](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationfactory/) 클래스 또한 프레젠테이션에서 모든 텍스트를 추출하는 메서드를 제공합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# 파일에서 텍스트를 추출합니다.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# 스트림에서 텍스트를 추출합니다.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# 로드 옵션을 사용하여 스트림에서 텍스트를 추출합니다.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textextractionarrangingmode/) 열거형 인수는 텍스트 추출 결과를 구성하는 방식을 지정하며 다음 값으로 설정할 수 있습니다:

- [Unarranged](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) - 슬라이드 상의 위치와 관계없이 원시 텍스트.
- [Arranged](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textextractionarrangingmode/#Arranged) - 슬라이드와 동일한 순서로 텍스트가 정렬됩니다.

속도가 중요한 경우에는 정렬되지 않은(Unarranged) 모드를 사용할 수 있으며, 이는 정렬된(Arranged) 모드보다 빠릅니다.

[PresentationText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationtext/)은 프레젠테이션에서 추출된 원시 텍스트를 나타냅니다. Its [getSlidesText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationtext/#getSlidesText) method returns an array of objects of type `SlideText`. Each object represents the text on the corresponding slide. The object of type `SlideText` has the following methods:

- `getText` - 슬라이드의 도형에 포함된 텍스트.
- `getMasterText` - 해당 슬라이드와 연결된 마스터 슬라이드 도형에 포함된 텍스트.
- `getLayoutText` - 해당 슬라이드와 연결된 레이아웃 슬라이드 도형에 포함된 텍스트.
- `getNotesText` - 해당 슬라이드와 연결된 노트 슬라이드 도형에 포함된 텍스트.
- `getCommentsText` - 해당 슬라이드와 연결된 주석에 포함된 텍스트.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **FAQ**

**Aspose.Slides가 대형 프레젠테이션을 텍스트 추출할 때 얼마나 빠른가요?**

Aspose.Slides는 고성능을 위해 최적화되어 있어 [대형 프레젠테이션](/slides/ko/python-java/open-presentation/)도 처리할 수 있으므로 실시간 또는 대량 처리 시나리오에 적합합니다.

**Aspose.Slides가 프레젠테이션 내 표와 차트에서 텍스트를 추출할 수 있나요?**

네. Aspose.Slides는 표와 차트 관련 객체를 포함한 많은 슬라이드 요소에서 텍스트를 추출할 수 있으므로 일반적인 프레젠테이션 구조에서 텍스트 콘텐츠에 접근하고 분석할 수 있습니다.

**프레젠테이션에서 텍스트를 추출하려면 특별한 Aspose.Slides 라이선스가 필요합니까?**

무료 체험 버전으로도 텍스트를 추출할 수 있지만, [특정 제한 사항](/slides/ko/python-java/licensing/)이 있어 슬라이드 수가 제한됩니다. 제한 없이 사용하고 더 큰 프레젠테이션을 처리하려면 정식 라이선스를 구매하는 것이 권장됩니다.