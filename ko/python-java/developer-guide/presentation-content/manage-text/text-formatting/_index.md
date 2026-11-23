---
title: Python via Java를 사용한 프레젠테이션 텍스트 포맷
linktitle: 텍스트 서식 지정
type: docs
weight: 50
url: /ko/python-java/text-formatting/
keywords:
- 단락 정렬
- 텍스트 스타일
- 텍스트 배경
- 텍스트 투명도
- 문자 간격
- 글꼴 속성
- 글꼴 패밀리
- 텍스트 회전
- 회전 각도
- 텍스트 프레임
- 줄 간격
- 자동 맞춤 속성
- 텍스트 프레임 앵커
- 텍스트 탭
- 기본 언어
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트를 포맷하고 스타일을 지정합니다. 글꼴, 색상, 정렬 등을 사용자 지정합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 텍스트를 서식 지정하는 방법을 보여줍니다. 배경 색상, 투명도, 문자 간격, 글꼴 속성, 회전, 단락 간격, 자동 맞춤 동작, 텍스트 앵커링, 탭 정지 및 언어 설정을 다룹니다.

특히 명시되지 않은 경우 예제는 [sample.pptx](sample.pptx)를 사용합니다. 첫 번째 슬라이드의 첫 번째 도형은 텍스트 상자이며, 첫 번째 단락에는 아래에 표시된 텍스트가 포함됩니다. 슬라이드와 도형 인덱스는 0부터 시작합니다. 굵게 표시된 부분을 선택하는 예제는 상속된 굵게 서식을 포함한 실제 서식을 사용합니다:

![샘플 텍스트](sample_text.png)

텍스트 검색 및 교체를 보려면 [텍스트 검색 및 교체](/slides/ko/python-java/search-and-replace-text/)를 참조하십시오.

## **텍스트 배경 색 지정**

단락에 대한 기본 강조 색을 설정하려면 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat)를 사용하고, 개별 텍스트 부분에 대해서는 [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor)를 사용합니다.

다음 예제는 첫 번째 단락에 대한 기본값으로 연한 회색 강조를 설정합니다. 개별 부분에 대한 명시적인 강조 색은 이 기본값보다 우선합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 전체 단락에 대한 강조 색상을 설정합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![회색 단락](gray_paragraph.png)

아래 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**의 배경 색을 설정하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 텍스트 부분에 대한 강조 색상을 설정합니다.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![회색 텍스트 부분](gray_text_portions.png)

## **텍스트 단락 정렬**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment)를 사용하여 텍스트 프레임 내에서 단락 정렬을 설정합니다. 값은 가운데, 왼쪽 정렬, 오른쪽 정렬, 양쪽 맞춤 등일 수 있습니다.

다음 코드 예제는 단락을 **가운데**에 정렬하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 단락의 정렬을 중앙으로 설정합니다.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![정렬된 단락](aligned_paragraph.png)

## **줄 내에서 글꼴 정렬**

[ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment)를 사용하여 한 줄 내에서 서로 다른 글꼴 크기의 텍스트 부분을 수직으로 정렬합니다. 이 설정은 전체 단락에 적용되며 각 줄의 정렬을 제어합니다.

다음 자체 포함 예제는 한 슬라이드에 네 개의 레이블이 있는 텍스트 상자를 생성합니다. 각 단락은 18, 36, 54 포인트의 동일한 텍스트를 포함하며, 서로 다른 글꼴 정렬을 적용합니다. Arial을 사용하고 자동 맞춤과 줄바꿈을 비활성화하며 텍스트 프레임을 한 줄에 충분히 크게 유지합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![Baseline, Top, Center, Bottom 글꼴 정렬 비교 (혼합 글꼴 크기)](font_alignment.png)

글꼴 정렬은 글꼴 메트릭을 사용하므로 개별 문자들의 시각적 가장자리가 정확히 맞지 않을 수 있습니다. 이 예제는 대문자와 하강자를 포함하여 baseline과 bottom 정렬 차이를 보여줍니다. 글꼴 가용성 및 대체, 사용된 문자, 그리고 글꼴 크기 차이가 결과에 영향을 줍니다. 프레임 크기, 여백, 줄 간격, 줄바꿈 및 자동 맞춤도 레이아웃에 영향을 미치므로 모드를 비교할 때 동일한 글꼴 및 레이아웃 설정을 사용하십시오.

이 설정은 수평 단락 정렬을 제어하는 [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment)와 도형 내부에서 텍스트 블록을 수직으로 배치하는 [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType)와 다릅니다. [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement)으로 서프스크립트와 서브스크립트를 적용하면 단락 줄에 대한 글꼴 정렬을 설정하는 대신 각 부분을 baseline에 대해 이동시킵니다.

## **텍스트 투명도 설정**

텍스트 투명도는 [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat)에 할당된 색상의 알파 구성 요소를 통해 제어됩니다. 아래 예제에서 `alpha = 50`은 0–255 스케일의 ARGB 알파 채널 값이며, 투명도 비율이 아닙니다.

아래 코드 예제는 **전체 단락**에 투명도를 적용하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 텍스트의 채우기 색상을 투명 색상으로 설정합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![투명한 단락](transparent_paragraph.png)

다음 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**에 투명도를 적용하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 텍스트 부분의 투명도를 설정합니다.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![투명한 텍스트 부분](transparent_text_portions.png)

## **텍스트 문자 간격 설정**

[BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing)를 사용하여 텍스트 상자 내 문자 간격을 늘리거나 줄입니다. 예제에서는 3 포인트 간격을 추가하며, 음수 값은 텍스트를 압축합니다.

다음 Python 코드는 **전체 단락**의 문자 간격을 확대하는 방법을 보여줍니다:

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 참고: 문자 간격을 압축하려면 음수 값을 사용하십시오.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # 문자 간격을 확대합니다.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![단락의 문자 간격](character_spacing_in_paragraph.png)

아래 코드 예제는 **굵은 글꼴을 가진 텍스트 부분**의 문자 간격을 확대하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 참고: 문자 간격을 압축하려면 음수 값을 사용하세요.
            portion.getPortionFormat().setSpacing(3) # 문자 간격을 확대합니다.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![텍스트 부분의 문자 간격](character_spacing_in_text_portions.png)

### **특정 글꼴에 대한 Kerning 비활성화**

일부 경우 Aspose.Slides가 렌더링한 텍스트가 PowerPoint에서 동일한 텍스트보다 약간 더 조여 보일 수 있습니다. 이는 PowerPoint가 특정 글꼴에 대한 kerning 데이터를 무시할 수 있기 때문이며, 글꼴에 유효한 kerning 정보가 있더라도 PowerPoint 설정에서 kerning이 활성화되어 있어도 발생합니다.

이러한 경우 PowerPoint와 더 가까운 출력을 얻으려면 영향을 받는 글꼴을 사용하는 텍스트 부분에 대해 kerning을 비활성화할 수 있습니다. 실제 글꼴 크기보다 큰 값을 갖도록 [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize)를 설정합니다. 이 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "presentation.pptx"가 필요합니다. 상속된 글꼴을 포함한 실제 글꼴 이름을 확인하고 Roboto를 사용하는 부분에 대해 100포인트 임계값을 설정합니다. 이는 100포인트 이하의 글꼴 크기를 사용하는 일치하는 부분에 대한 kerning을 비활성화합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

임계값 이하의 일치 텍스트에 대해 이 설정은 kerning을 방지하고 해당 PowerPoint 전용 동작에 영향을 받는 글꼴에 대해 Aspose.Slides 렌더링을 PowerPoint 시각 출력과 맞추는 데 도움이 될 수 있습니다.

## **텍스트 글꼴 속성 관리**

글꼴 속성은 [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat)를 통해 단락 수준에서 설정하거나 [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/)을 통해 개별 부분에서 설정할 수 있습니다.

다음 예제는 첫 번째 단락의 기본 글꼴을 12포인트 Times New Roman에 굵게, 기울임, 점선 밑줄 서식으로 설정합니다. 개별 부분에 대한 명시적인 서식은 이러한 기본값보다 우선합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # 단락에 대한 글꼴 속성을 설정합니다.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![단락의 글꼴 속성](font_properties_for_paragraph.png)

다음 예제는 효과적인 서식이 굵게인 부분에 13포인트 Times New Roman, 기울임 및 점선 밑줄을 적용합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # 텍스트 부분에 대한 글꼴 속성을 설정합니다.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![텍스트 부분의 글꼴 속성](font_properties_for_text_portions.png)

## **텍스트 높이 정규화 제어**

템플릿 타이포그래피를 재현하거나 문자 높이 차이를 조사할 때 [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight)를 사용합니다. PowerPoint에서 정규화를 활성화하면 텍스트 부분 내에서 개별 문자를 수직으로 늘이거나 압축하여 눈에 보이는 높이를 균일하게 만들지만, 서로 다른 글꼴에 대해 텍스트 높이가 동일해진다는 보장은 없습니다.

속성을 [NullableBool.True_ or False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/)로 설정하여 정규화를 명시적으로 활성화하거나 비활성화합니다. `NullableBool.NotDefined`는 로컬 설정을 지정하지 않으므로 해당 부분이 예를 들어 단락의 [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat)에서 값을 상속받도록 합니다. 이는 `False`와 동일한 의미가 아닙니다. [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective)를 사용하고 반환된 효과적인 서식에서 `getNormaliseHeight`를 읽어 결정된 Boolean 값을 얻으십시오.

다음 자체 포함 예제는 **Arial**이 설치되어 있어야 합니다. 54포인트로 동일한 대문자, 소문자, 하강자 및 억음 문자를 포함하는 두 개의 텍스트 블록을 생성합니다. 두 단락 모두 기본적으로 정규화를 활성화합니다. 상단 부분은 명시적으로 비활성화하고, 하단 부분은 상속받습니다. 프레임 크기, 여백 및 단락 간격은 동일하며, 비교 일관성을 위해 줄바꿈 및 자동 맞춤을 비활성화합니다. 예제는 `False: False`와 `NotDefined: True`를 출력한 뒤 "text_height_normalization.pptx"를 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

아래 비교는 저장된 프레젠테이션에서 내보낸 것입니다. 상단 행은 정규화가 비활성화(`False`)된 상태이며, 하단 행은 활성화된 설정을 상속(`NotDefined` → `True`)합니다. 이 모습을 재현하려면 Arial이 설치되어 있어야 합니다.

![Arial 54포인트 텍스트 (위는 정규화 비활성화, 아래는 정규화 상속됨)](text_height_normalization.png)

정규화는 할당된 [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight) 값을 변경하지 않고 문자 높이를 변경합니다. 단락 [setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin)는 줄 간격을 제어하고, 텍스트 프레임 [setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType)은 텍스트 또는 컨테이너가 맞추도록 조정하는 방식을 제어합니다. 이러한 설정은 서로 다른 목적을 가지며 전체 레이아웃에 독립적으로 영향을 줄 수 있습니다. 단락 서식 및 상속에 대한 자세한 내용은 [Manage Paragraph](/slides/ko/python-java/manage-paragraph/)를 참조하십시오.

## **취소선 적용 및 제거**

텍스트 부분에 [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType)을 사용하면 원본 텍스트를 삭제하지 않고도 수정, 취소된 용어 또는 이전 가격을 표시할 수 있습니다. 텍스트에 한 줄 또는 두 줄을 그으려면 [TextStrikethroughType.Single or Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/)으로 설정합니다.

취소선을 제거하려면 [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None)를 전달합니다. 이는 주변 서식이 취소선을 지정하더라도 효과를 명시적으로 비활성화합니다. 반면에 [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined)는 로컬 설정을 정의되지 않게 하여 예를 들어 단락에서 서식을 상속받도록 합니다. 이는 취소선이 제거된다는 보장을 제공하지 않습니다. 결과 서식(상속 값 포함)을 확인하려면 [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective)를 사용하십시오.

다음 자체 포함 예제는 세 가지 가격 비교를 생성합니다. 각 단락은 레이블, 이전 가격, 현재 가격에 대해 별도 부분을 가지고 있어 이전 가격에만 영향을 줍니다. 첫 번째 행은 취소선을 적용한 뒤 제거하고, 다른 행은 각각 단일 및 이중 취소선을 유지합니다. 이 설정을 변경하면 텍스트와 다른 서식(예: 굵게 표시된 이전 가격)이 보존됩니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # 취소선을 적용한 다음 첫 번째 이전 가격에서 명시적으로 제거합니다.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과(위에서 아래 순서): 취소선 없음, 단일 취소선, 이중 취소선.

![취소선 없는 이전 가격, 단일 취소선, 이중 취소선](strikethrough.png)

## **텍스트 회전 설정**

[TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType)를 사용하여 도형 내에 미리 정의된 텍스트 방향을 설정합니다.

다음 코드 예제는 도형의 텍스트 방향을 [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/)으로 설정하는데, 이는 텍스트를 **시계 반대 방향으로 90도** 회전시킵니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![텍스트 회전](text_rotation.png)

## **세로 텍스트에서 숫자를 나란히 표시**

세로 일본어 레이블에서 두 자리 수의 숫자를 나란히 유지하려면 두 숫자를 하나의 텍스트 부분에 넣고 해당 부분에 [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKumimoji)를 호출합니다. 이 예제의 두 레이블은 모두 [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/#EastAsianVertical)과 40포인트 MS Gothic을 사용합니다. 숫자에 대한 [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) 설정만 다릅니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Portion, Presentation, SaveFormat, ShapeType, TextVerticalType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    font = FontData("MS Gothic")

    for x, kumimoji in [(120, NullableBool.True_), (360, NullableBool.False_)]:
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        frame = label.addTextFrame("")
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical)

        paragraph = frame.getParagraphs().get_Item(0)
        default_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        default_format.setLatinFont(font)
        default_format.setEastAsianFont(font)
        default_format.setFontHeight(40)
        default_format.getFillFormat().setFillType(FillType.Solid)
        default_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        digits = Portion("12")
        digits.getPortionFormat().setKumimoji(kumimoji)
        
        portions = paragraph.getPortions()
        portions.clear()
        portions.add(Portion("令和"))
        portions.add(digits)
        portions.add(Portion("年"))

    presentation.save("vertical_date.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

PowerPoint에서 왼쪽 레이블(`True`)은 和와 年 사이에 숫자가 직립 상태로 나란히 표시됩니다. 오른쪽 레이블(`False`)은 숫자 쌍이 시계 방향으로 90도 회전합니다. 주변 일본어 문자는 두 레이블 모두 직립 상태로 유지됩니다.

![PowerPoint에서 세로 날짜 레이블 비교: 왼쪽은 수직 숫자, 오른쪽은 회전된 숫자](vertical_date.png)

## **텍스트 프레임 사용자 정의 회전 설정**

[TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle)를 사용하여 [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/)에 대한 사용자 정의 회전 각도를 설정합니다.

아래 코드 예제는 도형 내부에서 텍스트 프레임을 시계 방향으로 3도 회전시킵니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![사용자 정의 텍스트 회전](custom_text_rotation.png)

## **단락 줄 간격 설정**

Aspose.Slides는 단락 간격을 제어하기 위해 [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore), [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin)를 제공합니다. 이러한 속성은 다음과 같이 사용됩니다:

* 양수 값을 사용하면 줄 높이의 백분율로 줄 간격을 지정합니다.
* 음수 값을 사용하면 포인트 단위로 줄 간격을 지정합니다.

다음 예제는 첫 번째 단락의 내부 간격을 줄 높이의 200%(두 배 간격)로 설정합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![단락 내 줄 간격](line_spacing.png)

## **줄 바꿈 제어**

좁은 텍스트 블록 및 라틴어와 동아시아어 텍스트가 혼합된 프레젠테이션에서 단락 줄 바꿈 규칙이 유용합니다. 다음 메서드는 [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/)에 속하므로 전체 단락에 적용됩니다:

* [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) 은 라틴어 줄 바꿈 규칙을 제어합니다. 혼합 텍스트에서는 이를 변경하면 인접한 동아시아 텍스트와 구두점이 감싸지는 위치도 바뀔 수 있습니다.
* [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) 은 줄 시작·끝 문자 제한을 포함한 동아시아줄 바꿈 규칙을 제어합니다.

이 규칙은 텍스트 프레임 내 자동 줄바꿈을 활성화하는 [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText)를 대체하지 않습니다. 줄바꿈이 발생할 때 레이아웃에 영향을 주지만, 줄바꿈 문자 자체를 삽입하지는 않습니다. 명시적인 줄바꿈은 가용 너비와 무관하게 단락 내에 새 줄을 강제로 삽입합니다.

다음 자체 포함 예제는 중국어와 라틴어 텍스트가 포함된 좁은 텍스트 블록을 생성합니다. 두 줄 바꿈 옵션을 명시적으로 설정하고 "line_breaking.pptx"로 저장합니다. 각각의 규칙을 실험하려면 다른 설정은 그대로 두고 해당 값을 변경하십시오. 예제는 24포인트 Arial과 SimSun을 사용하고 프레임 폭을 160포인트, 텍스트 프레임 가로 여백을 0으로 설정합니다. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType)은 [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/)으로 호출되어 텍스트 크기와 프레임 크기가 고정됩니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **붙어 있는 구두점 제어**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation)을 사용하면 해당 구두점이 다음 줄을 차지하지 않고 텍스트 라인의 오른쪽 끝을 넘어 확장될 수 있습니다. 이는 전체 단락에 적용되며 매달린 들여쓰기와는 다릅니다.

다음 자체 포함 예제는 100포인트 너비 텍스트 프레임에서 붙어 있는 구두점을 활성화하고 "hanging_punctuation.pptx"로 저장합니다. 24포인트 Arial과 가로 여백 0을 사용하면 마지막 마침표가 "sentence" 뒤에 남아 오른쪽 텍스트 가장자리를 넘어갑니다. [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/)로 속성을 설정하여 비교할 수 있습니다: 이 설정에서는 마침표가 별도 줄에 배치됩니다. 가용 너비를 고정하기 위해 줄바꿈은 활성화하고 자동 맞춤은 비활성화했습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

모든 구두점이 매달릴 수 있는 것은 아닙니다. 위의 [글꼴 및 레이아웃 조건](#control-line-breaking)도 이 비교에 적용됩니다: 글꼴, 가용 너비, 여백 또는 자동 맞춤 설정을 변경하면 눈에 보이는 차이가 사라질 수 있습니다.

## **텍스트 프레임 자동 맞춤 유형 설정**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType)는 텍스트가 컨테이너 경계를 초과할 때 텍스트가 어떻게 동작할지를 결정합니다. 텍스트가 축소, 넘침, 또는 도형이 자동으로 크기 조정되는지를 제어하려면 이를 사용합니다. 다음 예제는 도형을 텍스트에 맞게 크기를 조정하도록 구성하고 결과를 "autofit_type.pptx"로 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

자동 줄바꿈 후 줄 수를 세고 텍스트 또는 도형 너비가 결과에 어떻게 영향을 주는지 보려면 [Count Rendered Lines](/slides/ko/python-java/manage-paragraph/)를 참조하십시오. 줄 수만으로는 텍스트가 컨테이너를 초과했는지 여부를 판단할 수 없습니다.

## **텍스트 프레임 앵커 설정**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType)는 텍스트가 도형 내부에서 수직으로 어떻게 배치되는지를 정의합니다(예: 위쪽, 가운데, 아래쪽). 다음 예제는 첫 번째 도형의 텍스트를 아래쪽에 고정하고 결과를 "text_anchor.pptx"로 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **텍스트 탭 설정**

[ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize)와 [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs)를 사용하여 단락의 탭 정지를 구성합니다. 다음 예제는 기본 탭 간격을 100포인트로 설정하고 30포인트에 왼쪽 정렬 탭 정지를 추가합니다. 이러한 설정은 탭 문자를 포함하는 텍스트에 영향을 줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

결과:

![단락 탭](paragraph_tabs.png)

## **교정 언어 설정**

Aspose.Slides는 [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId)를 제공하여 텍스트 부분에 대한 교정 언어를 설정할 수 있습니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사에 사용되는 언어를 결정합니다.

다음 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "presentation.pptx"와 최소 하나의 단락이 필요합니다. 첫 번째 단락의 내용을 "1。"으로 교체하고, 글꼴을 SimSun으로 설정한 뒤, 간체 중국어 교정 언어(`zh-CN`)를 할당합니다. 결과를 "proofing_language.pptx"로 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # 교정 언어의 Id를 설정합니다.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **언어 메타데이터 복사**

템플릿에서 다국어 텍스트를 복사할 때 [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId)와 [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId)를 모두 보존합니다. 다음 자체 포함 예제는 미국 영어를 기본 언어로, 프랑스어를 대체 언어로 하는 소스 부분을 만들고 텍스트와 식별자를 새 프레젠테이션의 부분에 복사합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # 소스에 대체 언어가 없으면, None이 대상 값을 지웁니다.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

대체 언어가 없는 소스를 시도하려면 `"fr-FR"` 할당을 생략하십시오. 그러면 대체 식별자는 `None`이 되며, 동일한 복사 문은 목적지에 이전에 대체 언어가 할당되어 있더라도 기본 값을 도입하지 않고 그 부재를 유지합니다.

이러한 식별자는 언어 메타데이터로 저장됩니다. 이를 보존한다고 해서 PowerPoint가 맞춤법 또는 문법 검사를 위해 선택하는 사전이 결정되는 것은 아닙니다.

## **기본 언어 설정**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage)을 사용하여 프레젠테이션을 로드하거나 생성할 때 생성되는 텍스트의 기본 언어를 정의합니다. 다음 예제는 기본 텍스트 언어를 미국 영어로 설정한 프레젠테이션을 만들고, 텍스트 상자를 추가한 뒤 첫 번째 텍스트 부분에 대해 `en-US`를 출력합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # 텍스트가 있는 사각형 도형을 추가합니다.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # 첫 번째 부분의 언어를 확인합니다.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **기본 텍스트 스타일 설정**

프레젠테이션 수준에서 기본 텍스트 서식을 적용하려면 [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle)를 사용합니다.

다음 예제는 새 프레젠테이션의 최상위 단락에 대해 14포인트 굵은 글꼴을 기본값으로 설정하고 이를 "default_text_style.pptx"로 저장합니다. 텍스트는 보다 구체적인 서식이 이를 덮어쓰지 않는 한 이러한 기본값을 상속할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # 최상위 레벨 단락 서식을 가져옵니다.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **전체 대문자 효과가 적용된 텍스트 추출**

PowerPoint에서 **All Caps** 글꼴 효과를 적용하면 원래 소문자로 입력된 텍스트도 슬라이드에 대문자로 표시됩니다. Aspose.Slides로 이러한 텍스트 부분을 검색하면 라이브러리는 입력된 그대로의 텍스트를 반환합니다. 표시된 텍스트와 일치시키려면 [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/)을 확인하고 값이 `All`인 경우 반환된 문자열을 대문자로 변환하십시오.

이 예제는 첫 번째 슬라이드의 첫 번째 도형이 텍스트 상자인 "sample2.pptx"가 필요합니다. 첫 번째 단락의 첫 번째 부분에는 All Caps 효과가 적용된 "Hello, Aspose!"가 포함되어 있으며 아래에 표시됩니다.

![전체 대문자 효과](all_caps_effect.png)

아래 코드 예제는 **All Caps** 효과가 적용된 텍스트를 추출하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

출력:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**슬라이드의 표에서 텍스트를 수정하려면 어떻게 해야 하나요?**

슬라이드의 표에서 텍스트를 수정하려면 [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/)을 사용하십시오. 셀을 반복하면서 각 셀을 [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame)으로 업데이트하고, [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat)을 통해 단락 서식을 조정합니다.

**PowerPoint 슬라이드의 텍스트에 그라디언트 색을 적용하려면 어떻게 해야 하나요?**

텍스트에 그라디언트 색을 적용하려면 [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat)를 사용합니다. [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType)을 [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/)로 설정하고, 그라디언트 스톱, 방향 및 투명도를 구성하십시오.