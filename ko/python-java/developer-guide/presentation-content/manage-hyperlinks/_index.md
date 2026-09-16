---
title: Python via Java에서 프레젠테이션 하이퍼링크 관리
linktitle: 하이퍼링크 관리
type: docs
weight: 20
url: /ko/python-java/manage-hyperlinks/
keywords:
- URL 추가
- 하이퍼링크 추가
- 하이퍼링크 생성
- 하이퍼링크 서식 지정
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 텍스트 하이퍼링크
- 슬라이드 하이퍼링크
- 도형 하이퍼링크
- 이미지 하이퍼링크
- 비디오 하이퍼링크
- 가변 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python via Java용 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 하이퍼링크를 추가, 서식 지정, 업데이트 및 제거합니다. Python 예제를 사용합니다."
---
## **소개**

하이퍼링크는 프레젠테이션 콘텐츠를 웹사이트나 프레젠테이션 내부 위치에 연결합니다. PowerPoint에서 하이퍼링크는 일반적으로 두 가지 용도로 사용됩니다:

* 텍스트, 도형 또는 미디어 프레임에서 웹사이트를 엽니다.
* 예를 들어 목차에서 다른 슬라이드로 이동합니다.

Aspose.Slides for Python via Java를 사용하면 이러한 링크를 추가하고, 모양과 소리를 제어하고, 속성을 업데이트하며, 제거할 수 있습니다. 아래 예제에서는 개별 요소에 대한 하이퍼링크 작업 방법과 프레젠테이션, 슬라이드, 텍스트 프레임 수준에서 하이퍼링크에 접근하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
You can also edit presentations with the [free online Aspose PowerPoint editor](https://products.aspose.app/slides/ko/editor).
{{% /alert %}} 

## **URL 하이퍼링크 추가**

텍스트, 도형 또는 미디어 프레임에 웹사이트 URL을 할당할 수 있습니다. 하이퍼링크를 할당하는 요소에 따라 클릭 가능한 영역이 결정됩니다: 텍스트 부분은 선택된 텍스트에 링크를 적용하고, 도형이나 프레임은 슬라이드 객체에 링크를 적용합니다.

### **텍스트에 URL 하이퍼링크 추가**

텍스트를 웹사이트에 연결하려면 아래와 같이 텍스트 부분의 [setHyperlinkClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/#setHyperlinkClick) 메서드에 [Hyperlink](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/)을 전달합니다. 해당 텍스트 부분만 클릭 가능하게 됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **도형 및 미디어 프레임에 URL 하이퍼링크 추가**

도형이나 프레임을 클릭 가능하게 만들려면 해당 객체의 [setHyperlinkClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#setHyperlinkClick) 메서드를 호출합니다. 하이퍼링크는 객체 자체에 속하며 내부 텍스트 부분에 속하지 않습니다.

같은 방법이 그림, 오디오 및 비디오 프레임에도 적용됩니다: 프레임에 하이퍼링크를 할당하고 필요하면 [setTooltip](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#setTooltip) 메서드를 호출합니다.

다음 예제는 사각형을 클릭 가능하게 만듭니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **하이퍼링크를 사용하여 목차 만들기**

내부 하이퍼링크를 사용하면 독자가 목차에서 특정 슬라이드로 이동할 수 있습니다. 다음 예제는 [setInternalHyperlinkClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) 메서드를 사용해 첫 번째 슬라이드의 “Page 2” 텍스트를 두 번째 슬라이드에 연결합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **하이퍼링크 서식 지정**

### **색상**

[Hyperlink](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/)의 [setColorSource](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#setColorSource) 메서드는 하이퍼링크가 프레젠테이션의 하이퍼링크 색상을 사용할지 텍스트 부분의 서식을 사용할지 결정합니다. 사용자 지정 텍스트 색상을 적용하려면 [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkcolorsource/)을 선택하고 부분의 채우기 색을 설정합니다. 이 기능은 PowerPoint 2019에 도입되었으며 이전 버전에서는 적용되지 않습니다.

다음 예제는 같은 슬라이드에 두 개의 텍스트 하이퍼링크를 추가합니다. 첫 번째는 빨간색 텍스트 채우기를 사용하고, 두 번째는 기본 하이퍼링크 색상을 유지합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **소리**

하이퍼링크를 활성화할 때 소리를 재생하거나 현재 재생 중인 소리를 중지할 수 있습니다. 다음 메서드를 사용해 이러한 동작을 구성합니다:

- [Hyperlink.setSound](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#setSound) 은 하이퍼링크와 연결된 오디오를 지정합니다.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) 은 하이퍼링크를 활성화할 때 이전 소리를 중지할지 여부를 제어합니다.

#### **하이퍼링크 소리 추가**

다음 예제는 `sampleaudio.wav` 파일을 로드하고 첫 번째 슬라이드의 버튼에 연결합니다. 버튼을 클릭하면 소리가 재생되고 다음 슬라이드로 이동합니다. 동일 슬라이드의 두 번째 도형은 클릭 시 이전 소리를 중지하지만 네비게이션 동작은 수행하지 않습니다.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **하이퍼링크 소리 추출**

다음 예제는 위에서 만든 프레젠테이션을 열고 첫 번째 도형의 하이퍼링크 오디오를 [getSound](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#getSound) 및 [getBinaryData](https://reference.aspose.com/slides/ko/python-java/aspose.slides/audio/#getBinaryData) 메서드를 통해 메모리로 읽어들입니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **툴팁 및 상호 작용 설정**

텍스트 또는 도형에 하이퍼링크를 할당한 후 다음 [Hyperlink](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/) 메서드를 호출할 수 있습니다:

- [setTooltip](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#setTooltip) 은 사용자가 링크에 대한 힌트로 표시할 수 있는 텍스트를 설정합니다.
- [setTargetFrame](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#setTargetFrame) 은 해당되는 경우 부모 HTML 프레임셋 내의 대상 프레임을 지정합니다.
- [setHistory](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#setHistory) 은 링크를 활성화할 때 해당 목적지가 본 하이퍼링크 목록에 추가되는지를 제어합니다.
- [setHighlightClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#setHighlightClick) 은 클릭 시 하이퍼링크가 강조 표시되는지를 제어합니다.

## **프레젠테이션에서 하이퍼링크 제거**

변경하기 전에 텍스트 부분 링크를 포함한 하이퍼링크 컨테이너를 수집하려면 [getAnyHyperlinks](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) 메서드를 사용합니다. 다음 예제는 첫 번째 슬라이드에서 두 가지 활성화 유형을 모두 제거합니다. 하나만 제거하려면 [removeHyperlinkClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) 또는 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) 중 하나만 호출합니다; 클릭 동작을 제거해도 마우스오버 동작은 그대로 남습니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

조건 없이 모두 제거하려면 [removeAllHyperlinks](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) 메서드가 선택된 범위 내에서 두 활성화 유형을 한 번에 제거합니다. 마스터, 레이아웃 및 노트에 대한 선택적 정리를 위해서는 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)를 참조하십시오.

## **전체 하이퍼링크 인벤토리 만들기**

프레젠테이션을 배포하기 전에 인터랙티브 동작과 웹 링크를 모두 인벤토리해야 합니다. [getAnyHyperlinks](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) 메서드는 URL 문자열의 평면 목록이 아닌 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/) 및 [PortionFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/) 개체와 같은 하이퍼링크 컨테이너를 반환합니다. 각 컨테이너에서 [getHyperlinkClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getHyperlinkClick)와 [getHyperlinkMouseOver](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getHyperlinkMouseOver)를 모두 검사하십시오. 두 메서드는 독립적이며 동일 컨테이너가 두 동작을 모두 노출할 수 있으므로 전체 보고서는 컨테이너당 최대 두 행이 필요합니다.

도형 수준 하이퍼링크만 스캔하면 텍스트 부분에 첨부된 링크를 놓칠 수 있습니다. 대신 적절한 범위를 쿼리하고 반환된 컨테이너를 보관하여 나중에 동작을 업데이트하거나 제거할 수 있게 하십시오.

### **프레젠테이션, 슬라이드 및 텍스트 프레임 범위 쿼리**

[HyperlinkQueries](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkqueries/) 클래스는 [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/#getHyperlinkQueries), [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframe/#getHyperlinkQueries) 를 통해 사용할 수 있습니다. 각 범위는 동일한 쿼리를 지원합니다:

- [getHyperlinkClicks](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) 은 클릭 동작이 있는 컨테이너를 반환합니다.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) 은 마우스오버 동작이 있는 컨테이너를 반환합니다.
- [getAnyHyperlinks](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) 은 하나 또는 두 동작이 있는 컨테이너를 반환합니다.

다음 예제는 외부 클릭 링크, 파일 마우스오버 링크, 내부 슬라이드 네비게이션, 텍스트 마우스오버 링크 및 매크로 동작을 포함하는 `hyperlink-audit-input.pptx` 파일을 생성합니다. 예제는 이러한 동작을 실행하지 않습니다. 동일한 세 가지 쿼리는 모든 범위에서 작동하며, 반환된 수치는 컨테이너 수를 나타내며 동작 총합이 아닙니다. 텍스트 프레임 범위는 포함 도형 자체의 링크를 제외합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이 예제에서 프레젠테이션 및 슬라이드 쿼리는 각각 클릭 컨테이너 3개, 마우스오버 컨테이너 2개, 어느 동작이든 포함하는 컨테이너 3개를 보고합니다. 텍스트 프레임 쿼리는 각 카테고리당 컨테이너 1개를 보고합니다.

### **동작 및 대상 분류**

[Hyperlink.getActionType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#getActionType) 메서드를 사용해 동작을 해석한 후 대상을 해석하십시오. [HyperlinkActionType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkactiontype/) 값은 웹 탐색 이상의 동작을 포괄합니다:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | 외부 하이퍼링크; URL과 스킴을 검토합니다. |
| `JumpSpecificSlide` | 특정 슬라이드로 내부 이동. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 기본 제공 슬라이드쇼 네비게이션, 슬라이드쇼 컨텍스트에서 해석됩니다. |
| `JumpEndShow`, `StartCustomSlideShow` | 현재 쇼를 종료하거나 사용자 정의 쇼를 시작합니다. |
| `StartMacro` | 매크로 실행. |
| `StartProgram` | 프로그램 실행. |
| `OpenFile`, `OpenPresentation` | 파일 또는 다른 프레젠테이션 열기; 웹 URL과 별도로 검토합니다. |
| `StartStopMedia` | 미디어 재생 시작 또는 중지. |
| `NoAction`, `Unknown` | 네비게이션 동작 없음 또는 인식되지 않은 동작으로 검토 필요. |

외부 대상은 [getExternalUrl](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#getExternalUrl) 로, 특정 내부 대상은 [getTargetSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#getTargetSlide) 로 읽습니다. 내부 동작 및 기본 명령에는 외부 URL이 없을 수 있으며, 빈 URL이 컨테이너에 동작이 없음을 의미하지는 않습니다. 정규화된 URL과 다를 경우 [getExternalUrlOriginal](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) 값을 보존하고, 가능한 경우 [getTooltip](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlink/#getTooltip) 에서 반환된 툴팁도 포함하십시오.

### **하이퍼링크 보고, 정리 및 검증**

다음 Python 예제는 기존 프레젠테이션을 읽고(`위에서 만든 파일 사용`), `hyperlink-audit.json`을 작성한 뒤 정책을 적용하고 `hyperlink-sanitized.pptx`로 저장한 후 다시 열어 두 활성화 유형을 다시 확인합니다. 변경 전 컨테이너를 수집하고 레퍼런스 동등성을 사용해 동일 컨테이너를 두 번 처리하지 않도록 합니다. 프레젠테이션 쿼리는 일반 슬라이드를 대상으로 하며, 패키지 전체 인벤토리를 위해서는 마스터, 레이아웃, 노트 및 존재하는 경우 노트와 핸드아웃 마스터도 명시적으로 쿼리합니다.

보고서는 사용 가능한 경우 1부터 시작하는 슬라이드 인덱스와 [getSlideId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslide/#getSlideId)를 기록합니다. [getSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getSlide)는 지원되는 컨테이너에 대해 소유 슬라이드를 제공합니다. 마스터, 레이아웃, 노트는 일반 슬라이드 인덱스가 없으며 범위로 식별됩니다. 도형 컨테이너와 텍스트 부분 서식 컨테이너는 별도로 라벨링되며, 다른 컨테이너 유형은 런타임 타입명을 유지합니다. 각 컨테이너는 보고서 내 로컬 ID를 받아 두 동작을 연관시킬 수 있습니다. 보고서는 동작 유형을 Java 열거형에 정의된 정수 상수로 저장합니다.

이 제한적인 애플리케이션 정책은 절대 HTTPS URL과 유효한 내부 슬라이드 대상만 허용합니다. 매크로, 프로그램, 파일 동작, 기타 슬라이드쇼 동작, 알 수 없는 동작 및 기타 URL 스킴은 거부합니다. 이러한 거부는 정책 결정이며 Aspose.Slides 안전성 판단이 아닙니다. HTTPS만으로는 신뢰를 보장하지 않으니 호스트 허용 목록 등 추가 검사를 적용하십시오. 원본 및 정규화된 외부 URL 모두 검사합니다. 예제는 링크를 따라가거나 동작을 실행하지 않고 메타데이터만 감사합니다.

복구를 위해 컨테이너의 [getHyperlinkManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#getHyperlinkManager) 는 [setExternalHyperlinkClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) 및 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver) 를 지원합니다. 여기서는 금지된 외부 클릭 링크를 고정된 HTTPS 랜딩 페이지로 교체하고, 다른 금지된 클릭 및 마우스오버 동작은 각각 독립적으로 제거합니다. `replace_external_clicks` 를 `False` 로 설정하면 모든 정책 위반을 제거합니다. 배포 전에 애플리케이션이 소유한 교체 페이지를 선택하십시오.

보고서의 내보내기 플래그는 보수적인 PDF 검토 정책을 사용합니다: 마우스오버 동작 및 외부 링크나 특정 슬라이드 점프가 아닌 모든 동작을 잠재적으로 지원되지 않는 것으로 표시합니다. 이는 검토 힌트이며 기능 테스트가 아니며, 표시되지 않은 링크가 내보내기에서 살아남을 것을 보장하지도 않습니다. 지원되는 [PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/) 및 [HTML](/slides/ko/python-java/convert-powerpoint-to-html/) 내보내기는 동작과 옵션, 뷰어에 따라 하이퍼링크를 보존할 수 있습니다. 래스터 [images](/slides/ko/python-java/convert-powerpoint-to-png/)와 [video](/slides/ko/python-java/convert-powerpoint-to-video/)는 인터랙티브 하이퍼링크를 보존할 수 없으므로 해당 출력에 대한 감사 시 모든 동작을 표시하십시오.

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

위에서 만든 입력을 사용하면 보고서에 다섯 개의 동작 행이 포함됩니다. 파일 마우스오버 링크와 매크로 클릭은 제거되고, HTTPS 링크와 내부 슬라이드 네비게이션은 유지됩니다. 검증 단계에서는 금지된 동작이 0개임을 출력합니다. 금지된 외부 클릭 URL을 포함하는 입력은 교체 분기 또한 실행합니다. 허용된 클릭과 금지된 마우스오버를 동시에 가진 컨테이너는 클릭 동작을 유지합니다.

이 선택적 정리는 정책에 관계없이 선택된 범위 전체에서 두 활성화 유형을 모두 제거하는 [removeAllHyperlinks](https://reference.aspose.com/slides/ko/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) 와 차이가 있습니다. 여기서 검증은 하이퍼링크 동작만 확인하며, 포함된 VBA 프로젝트, OLE 객체 또는 기타 활성 콘텐츠를 제거하지 않으며, 내보낸 PDF 또는 HTML 파일을 검증하지도 않습니다.

## **FAQ**

**섹션이나 해당 섹션의 첫 번째 슬라이드에 어떻게 연결할 수 있나요?**

PowerPoint에서 섹션은 슬라이드를 그룹화하지만 내부 하이퍼링크는 개별 슬라이드를 대상으로 합니다. 섹션으로 이동하려면 해당 섹션의 첫 번째 슬라이드에 링크를 걸어야 합니다.

**마스터 슬라이드 요소에 하이퍼링크를 추가하면 모든 슬라이드에서 작동하나요?**

예. 마스터 슬라이드와 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 요소의 링크는 해당 마스터나 레이아웃을 사용하는 슬라이드 쇼 중에 사용할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 유지됩니까?**

지원되는 PDF와 HTML 내보내기는 하이퍼링크를 보존할 수 있지만, 래스터 이미지와 비디오는 보존할 수 없습니다. 자세한 내용은 [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)를 참조하십시오.