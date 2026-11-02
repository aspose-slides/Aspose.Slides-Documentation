---
title: Python via Java에서 프레젠테이션 하이퍼링크 관리
linktitle: 하이퍼링크 관리
type: docs
weight: 20
url: /ko/python-java/manage-hyperlinks/
keywords:
- URL 추가
- 하이퍼링크 추가
- 하이퍼링크 만들기
- 하이퍼링크 서식 지정
- 하이퍼링크 제거
- 하이퍼링크 업데이트
- 텍스트 하이퍼링크
- 슬라이드 하이퍼링크
- 도형 하이퍼링크
- 이미지 하이퍼링크
- 비디오 하이퍼링크
- 변경 가능한 하이퍼링크
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Python via Java용 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 하이퍼링크를 추가, 서식 지정, 업데이트 및 제거하며, Python 예제를 활용합니다."
---
## **소개**

하이퍼링크는 프레젠테이션 콘텐츠를 웹사이트나 프레젠테이션 내의 위치에 연결합니다. PowerPoint에서 하이퍼링크는 일반적으로 두 가지 용도로 사용됩니다:

* 텍스트, 도형 또는 미디어 프레임에서 웹사이트를 엽니다.
* 목차와 같이 다른 슬라이드로 이동합니다.

Aspose.Slides for Python via Java를 사용하면 이러한 링크를 추가하고, 모양과 소리를 제어하고, 속성을 업데이트하고, 제거할 수 있습니다. 아래 예제에서는 개별 요소에 대한 하이퍼링크 작업 방법과 프레젠테이션, 슬라이드 또는 텍스트 프레임 수준에서 하이퍼링크에 접근하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
무료 온라인 Aspose PowerPoint 편집기로 프레젠테이션을 편집할 수도 있습니다[free online Aspose PowerPoint editor](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **URL 하이퍼링크 추가**

텍스트, 도형 또는 미디어 프레임에 웹사이트 URL을 지정할 수 있습니다. 하이퍼링크를 지정하는 요소에 따라 클릭 가능한 영역이 결정됩니다: 텍스트 부분은 선택된 텍스트에 링크되며, 도형이나 프레임은 슬라이드 객체에 링크됩니다.

프레젠테이션에 상대 하이퍼링크가 포함된 경우, [하이퍼링크 기본 관리](/slides/ko/python-java/presentation-properties/#manage-the-hyperlink-base)를 참조하여 문서 수준 기본값을 읽고, 변경하고, 지울 수 있습니다.

### **텍스트에 URL 하이퍼링크 추가**

텍스트를 웹사이트에 연결하려면 아래와 같이 텍스트 부분의 [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) 메서드에 [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/)을 전달합니다. 해당 텍스트 부분만 클릭 가능하게 됩니다.

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

도형이나 프레임을 클릭 가능하게 만들려면 해당 객체의 [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) 메서드를 호출합니다. 하이퍼링크는 텍스트 부분이 아닌 객체 자체에 속합니다.

같은 방법이 그림, 오디오 및 비디오 프레임에도 적용됩니다: 프레임에 하이퍼링크를 할당하고 필요하면 [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip)을 호출합니다.

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

내부 하이퍼링크를 사용하면 독자가 목차에서 특정 슬라이드로 이동할 수 있습니다. 다음 예제는 [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick)를 사용하여 첫 번째 슬라이드의 “Page 2” 텍스트를 두 번째 슬라이드에 연결합니다.

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

[Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/)의 [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) 메서드는 하이퍼링크가 프레젠테이션의 하이퍼링크 색상을 사용할지 텍스트 부분의 서식을 사용할지를 결정합니다. 사용자 지정 텍스트 색상을 적용하려면 [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/)을 선택하고 부분의 채우기 색을 설정합니다. 이 기능은 PowerPoint 2019에서 도입되었으며, 이전 버전에서는 적용되지 않습니다.

다음 예제는 동일한 슬라이드에 두 개의 텍스트 하이퍼링크를 추가합니다. 첫 번째는 빨간색 텍스트 채우기를 사용하고, 두 번째는 기본 하이퍼링크 색상을 유지합니다.

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

하이퍼링크를 활성화할 때 소리를 재생하거나 이미 재생 중인 소리를 중지할 수 있습니다. 다음 메서드를 사용하여 이러한 동작을 구성합니다:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) 은 하이퍼링크와 연결된 오디오를 지정합니다.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) 은 하이퍼링크를 활성화할 때 이전 소리를 중지할지 여부를 제어합니다.

#### **하이퍼링크 소리 추가**

다음 예제는 `sampleaudio.wav`를 로드하고 첫 번째 슬라이드의 버튼에 연결합니다. 버튼을 클릭하면 소리가 재생되고 다음 슬라이드로 이동합니다. 동일 슬라이드의 두 번째 도형은 클릭 시 이전 소리를 중지하지만 탐색 동작은 수행하지 않습니다.

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

다음 예제는 앞서 만든 프레젠테이션을 열고 첫 번째 도형의 하이퍼링크 오디오를 [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) 및 [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData)를 통해 메모리로 읽어들입니다.

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

### **툴팁 및 인터랙션 설정**

텍스트 또는 도형에 하이퍼링크를 할당한 후 다음 [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) 메서드를 호출할 수 있습니다:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) 은 뷰어가 링크에 대한 힌트로 표시할 수 있는 텍스트를 설정합니다.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) 은 적용 가능한 경우 상위 HTML 프레임셋 내의 대상 프레임을 지정합니다.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) 은 링크를 활성화할 때 대상이 조회된 하이퍼링크 목록에 추가되는지 여부를 제어합니다.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) 은 클릭 시 하이퍼링크가 강조 표시되는지 여부를 제어합니다.

## **프레젠테이션에서 하이퍼링크 제거**

변경하기 전에 텍스트 부분 링크를 포함한 하이퍼링크 컨테이너를 수집하려면 [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)를 사용합니다. 다음 예제는 첫 번째 슬라이드에서 두 가지 활성화 유형을 모두 제거합니다. 하나의 유형만 제거하려면 [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) 또는 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver)만 호출하면 됩니다; 클릭 동작을 제거해도 마우스 오버 대응은 제거되지 않습니다.

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

조건 없이 제거하려면 [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)가 선택된 범위에서 두 활성화 유형을 한 번에 제거합니다. 마스터, 레이아웃 및 노트에 대한 선택적 정리와 커버리지를 원한다면 [하이퍼링크 보고, 정리 및 검증](#report-sanitize-and-verify-hyperlinks)을 참조하십시오.

## **전체 하이퍼링크 인벤토리 구축**

프레젠테이션을 배포하기 전에 인터랙티브 액션과 웹 링크를 모두 인벤토리하십시오. [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)은 URL 문자열의 평면 목록이 아니라 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 및 [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/)와 같은 하이퍼링크 컨테이너를 반환합니다. 각 컨테이너에서 [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) 및 [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver)를 모두 검사하십시오. 이는 독립적이며, 동일 컨테이너가 두 동작을 모두 노출할 수 있으므로 완전한 보고서에는 컨테이너당 최대 두 행이 필요합니다.

도형 수준 하이퍼링크만 스캔하면 텍스트 부분에 연결된 링크를 놓칠 수 있습니다. 대신 적절한 범위를 쿼리하고 반환된 컨테이너를 보관하여 나중에 액션을 업데이트하거나 제거할 수 있도록 하십시오.

### **프레젠테이션, 슬라이드 및 텍스트 프레임 범위 쿼리**

[HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) 클래스는 [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries) 및 [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries)를 통해 사용할 수 있습니다. 각 범위는 동일한 쿼리를 지원합니다:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) 은 클릭 동작이 있는 컨테이너를 반환합니다.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) 은 마우스 오버 동작이 있는 컨테이너를 반환합니다.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) 은 하나이든 두 개이든 동작이 있는 컨테이너를 반환합니다.

다음 예제는 외부 클릭 링크, 파일 마우스 오버 링크, 내부 슬라이드 네비게이션, 텍스트 마우스 오버 링크 및 매크로 동작이 포함된 `hyperlink-audit-input.pptx`를 생성합니다. 이 예제는 이러한 동작을 실행하지 않습니다. 동일한 세 가지 쿼리는 모든 범위에서 작동하며, 카운트는 컨테이너 수를 나타내며 동작 총합이 아닙니다. 텍스트 프레임 범위는 포함된 도형 자체의 링크를 제외합니다.

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

이 예제에서는 프레젠테이션 및 슬라이드 쿼리가 각각 클릭 컨테이너 3개, 마우스 오버 컨테이너 2개, 그리고 어느 동작이든 포함된 컨테이너 3개를 보고합니다. 텍스트 프레임 쿼리는 각 카테고리에서 하나의 컨테이너를 보고합니다.

### **동작 및 대상 분류**

[Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType)을 사용하여 대상 해석 전에 동작을 판별합니다. [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) 값은 웹 네비게이션을 넘어서는 다양한 동작을 포함합니다:

| Values | 감사 시 의미 |
| --- | --- |
| `Hyperlink` | 외부 하이퍼링크; URL 및 스킴을 검사합니다. |
| `JumpSpecificSlide` | 특정 슬라이드로 내부 이동. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | 내장 슬라이드 쇼 탐색, 슬라이드 쇼 컨텍스트에서 해결됩니다. |
| `JumpEndShow`, `StartCustomSlideShow` | 현재 쇼를 종료하거나 사용자 정의 쇼를 시작합니다. |
| `StartMacro` | 매크로 실행. |
| `StartProgram` | 프로그램 시작. |
| `OpenFile`, `OpenPresentation` | 파일 또는 다른 프레젠테이션을 엽니다; 웹 URL과 별도로 검토합니다. |
| `StartStopMedia` | 미디어 재생을 시작하거나 중지합니다. |
| `NoAction`, `Unknown` | 네비게이션 동작 없음, 또는 검토가 필요한 인식되지 않은 동작. |

외부 대상은 [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl)에서, 특정 내부 대상은 [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide)에서 읽습니다. 내부 동작 및 내장 명령에는 외부 URL이 없을 수 있으며, 빈 URL이 컨테이너에 동작이 없다는 의미는 아닙니다. 정규화된 URL과 다를 경우 [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal)으로 반환된 값을 보존하고, 가능한 경우 [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip)으로 반환된 툴팁을 포함하십시오.

### **하이퍼링크 보고, 정리 및 검증**

다음 Python 예제는 기존 프레젠테이션을 읽고(`위에서 만든 파일 사용`), `hyperlink-audit.json`을 작성한 뒤 정책을 적용하고 `hyperlink-sanitized.pptx`를 저장한 후 다시 열어 두 활성화 유형을 다시 확인합니다. 변경하기 전에 컨테이너를 수집하고 동일 컨테이너를 두 번 처리하지 않도록 참조 동일성을 사용합니다. 프레젠테이션 쿼리는 일반 슬라이드를 포함하고, 패키지 전체 인벤토리를 위해 마스터, 레이아웃, 노트 및 노트와 핸드아웃 마스터도 명시적으로 쿼리합니다.

보고서는 가능한 경우 1 기반 슬라이드 인덱스와 [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId)를 기록합니다. [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide)는 지원되는 컨테이너에 대한 소유 슬라이드를 제공합니다. 마스터, 레이아웃 및 노트는 일반 슬라이드 인덱스가 없으며 범위로 식별됩니다. 도형 컨테이너와 텍스트 부분 서식 컨테이너는 별도로 레이블이 붙으며, 다른 컨테이너 유형은 런타임 타입 이름을 유지합니다. 각 컨테이너는 보고서 로컬 ID를 받아 두 동작을 연관시킬 수 있습니다. 보고서는 동작 유형을 Java 열거형에 정의된 정수 상수로 저장합니다.

이 의도적으로 제한적인 응용 프로그램 정책은 절대 HTTPS URL과 유효한 내부 슬라이드 대상만 허용합니다. 매크로, 프로그램, 파일 동작, 기타 슬라이드 쇼 동작, 알 수 없는 동작 및 기타 URL 스킴은 거부합니다. 이러한 거부는 정책 결정이며 Aspose.Slides 안전성 판단이 아닙니다. HTTPS만으로는 신뢰를 보장하지 않으므로 호스트 허용 목록 및 기타 검사를 추가하십시오. 원본 및 정규화된 외부 URL 모두 검증됩니다. 예제는 링크를 따라가거나 동작을 실행하지 않고 메타데이터만 감사합니다.

보정 작업을 위해 컨테이너의 [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager)는 [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) 및 [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver)를 지원합니다. 여기서는 금지된 외부 클릭 링크를 고정 HTTPS 랜딩 페이지로 교체하고, 다른 금지된 클릭 및 금지된 마우스 오버 동작은 독립적으로 제거합니다. `replace_external_clicks`를 `False`로 설정하면 모든 정책 위반을 제거합니다. 배포 전에 응용 프로그램이 소유한 교체 페이지를 선택하십시오.

보고서의 내보내기 플래그는 보수적인 PDF 검토 정책을 사용합니다: 마우스 오버 동작 및 외부 링크나 특정 슬라이드 점프가 아닌 모든 것을 잠재적으로 지원되지 않음으로 표시합니다. 이는 검토 힌트이며, 기능 테스트가 아니며, 표시되지 않은 링크가 내보내기에서 살아남는다는 보장이 아닙니다. 지원되는 [PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/) 및 [HTML](/slides/ko/python-java/convert-powerpoint-to-html/) 내보내기는 동작, 내보내기 옵션 및 뷰어에 따라 하이퍼링크를 보존할 수 있습니다. 래스터 [images](/slides/ko/python-java/convert-powerpoint-to-png/) 및 [video](/slides/ko/python-java/convert-powerpoint-to-video/)는 인터랙티브 하이퍼링크를 보존할 수 없으므로 해당 출력에 대한 감사를 수행할 때 모든 동작을 표시하십시오.

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

위에서 만든 입력으로 보고서는 다섯 개의 동작 행을 포함합니다. 파일 마우스 오버 링크와 매크로 클릭은 제거되고, HTTPS 링크와 내부 슬라이드 네비게이션은 유지됩니다. 검증 결과 금지된 동작은 0개로 출력됩니다. 금지된 외부 클릭 URL을 포함한 입력은 교체 분기 또한 실행합니다. 허용된 클릭과 금지된 마우스 오버가 있는 컨테이너는 클릭 동작을 유지합니다.

이 선택적 정리는 [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)와 다릅니다. 후자는 정책과 관계없이 선택된 범위 전체에서 두 활성화 유형을 모두 제거합니다. 여기서 검증은 하이퍼링크 동작만 확인하며, 내장된 VBA 프로젝트, OLE 객체 또는 기타 활성 콘텐츠를 제거하지 않으며, 내보낸 PDF나 HTML 파일을 검증하지도 않습니다.

## **FAQ**

**섹션이나 해당 섹션의 첫 번째 슬라이드에 어떻게 연결합니까?**

PowerPoint에서 섹션은 슬라이드를 그룹화하지만, 내부 하이퍼링크는 개별 슬라이드를 대상으로 합니다. 섹션으로 이동하려면 해당 섹션의 첫 번째 슬라이드에 링크하십시오.

**마스터 슬라이드 요소에 하이퍼링크를 연결하여 모든 슬라이드에서 작동하도록 할 수 있습니까?**

예. 마스터 슬라이드 및 레이아웃 요소는 하이퍼링크를 지원합니다. 이러한 요소에 대한 링크는 해당 마스터 또는 레이아웃을 사용하는 슬라이드 쇼 중에 사용할 수 있습니다.

**PDF, HTML, 이미지 또는 비디오로 내보낼 때 하이퍼링크가 보존됩니까?**

지원되는 PDF 및 HTML 내보내기는 하이퍼링크를 보존할 수 있으며, 래스터 이미지와 비디오는 보존할 수 없습니다. 자세한 내용은 [하이퍼링크 보고, 정리 및 검증](#report-sanitize-and-verify-hyperlinks)을 참조하십시오.