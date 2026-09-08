---
title: AutoFit을 사용하여 Python에서 프레젠테이션 향상
linktitle: Autofit 설정
type: docs
weight: 30
url: /ko/python-java/manage-autofit-settings/
keywords:
- 텍스트 박스
- 자동 맞춤
- 자동 맞춤 안 함
- 텍스트 맞추기
- 텍스트 축소
- 텍스트 줄바꿈
- 도형 크기 조정
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 AutoFit 설정을 관리하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트 표시를 최적화하고 콘텐츠 가독성을 향상시키는 방법을 배웁니다."
---
## **소개**

기본적으로 텍스트 상자를 추가하면 Microsoft PowerPoint는 텍스트 상자에 대해 **Resize shape to fix text** 설정을 사용합니다—텍스트가 항상 들어가도록 자동으로 텍스트 상자의 크기를 조정합니다. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* 텍스트 상자의 텍스트가 길어지거나 커지면 PowerPoint가 자동으로 텍스트 상자를 확대(높이를 증가)시켜 더 많은 텍스트를 담을 수 있도록 합니다. 
* 텍스트 상자의 텍스트가 짧아지거나 작아지면 PowerPoint가 자동으로 텍스트 상자를 축소(높이를 감소)시켜 남는 공간을 제거합니다. 

PowerPoint에서 텍스트 상자의 자동 맞춤 동작을 제어하는 4가지 중요한 매개변수 또는 옵션은 다음과 같습니다: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java는 유사한 옵션을 제공합니다—[TextFrameFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/) 클래스 아래의 일부 속성—이를 통해 프레젠테이션에서 텍스트 상자의 자동 맞춤 동작을 제어할 수 있습니다. 

## **텍스트에 맞게 도형 크기 조정**

텍스트가 변경된 후에도 텍스트가 항상 상자에 맞도록 하려면 **Resize shape to fix text** 옵션을 사용해야 합니다. 이 설정을 지정하려면 [setAutofitType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setAutofitType) 메서드([TextFrameFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/) 클래스에서)를 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textautofittype/#Shape)와 함께 사용합니다.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

다음 Python 코드는 PowerPoint 프레젠테이션에서 텍스트가 항상 상자에 맞도록 지정하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Shape)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

텍스트가 길어지거나 커지면 텍스트 상자가 자동으로 크기가 조정(높이 증가)되어 모든 텍스트가 들어가도록 합니다. 텍스트가 짧아지면 그 반대가 발생합니다. 

## **자동 맞춤 사용 안 함**

텍스트가 변경되더라도 텍스트 상자나 도형이 크기를 유지하도록 하려면 **Do not Autofit** 옵션을 사용해야 합니다. 이 설정을 지정하려면 [setAutofitType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setAutofitType) 메서드([TextFrameFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/) 클래스에서)를 [None](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textautofittype/#None)과 함께 사용합니다. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

다음 Python 코드는 PowerPoint 프레젠테이션에서 텍스트 상자가 항상 크기를 유지하도록 지정하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.None)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

텍스트가 상자에 비해 너무 길어지면 텍스트가 밖으로 넘칩니다. 

## **Shrink Text on Overflow**

텍스트가 상자에 비해 너무 길어지면 **Shrink text on overflow** 옵션을 통해 텍스트의 크기와 간격을 줄여 상자에 맞추도록 지정할 수 있습니다. 이 설정을 지정하려면 [setAutofitType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setAutofitType) 메서드([TextFrameFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/) 클래스에서)를 [Normal](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textautofittype/#Normal)과 함께 사용합니다. 

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

다음 Python 코드는 PowerPoint 프레젠테이션에서 텍스트가 넘칠 때 축소하도록 지정하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, TextAutofitType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setAutofitType(TextAutofitType.Normal)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Note" color="info" %}}
**Shrink text on overflow** 옵션을 사용하면, 텍스트가 상자에 비해 너무 길어질 때만 설정이 적용됩니다. 
{{% /alert %}}

## **Wrap Text**

텍스트가 도형의 테두리(너비) 밖으로 넘어갈 때 텍스트를 도형 내부에서 자동으로 줄바꿈하려면 **Wrap text in shape** 매개변수를 사용해야 합니다. 이 설정을 지정하려면 [setWrapText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setWrapText) 메서드([TextFrameFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/) 클래스에서)를 [NullableBool.True](https://reference.aspose.com/slides/ko/python-java/aspose.slides/nullablebool/#True)와 함께 사용합니다. 

다음 Python 코드는 PowerPoint 프레젠테이션에서 Wrap Text 설정을 사용하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, ShapeType, Portion, FillType, NullableBool, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100)

    portion = Portion("lorem ipsum...")
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion)

    text_frame_format = auto_shape.getTextFrame().getTextFrameFormat()
    text_frame_format.setWrapText(NullableBool.True)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}} 
[setWrapText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setWrapText) 메서드를 [NullableBool.False](https://reference.aspose.com/slides/ko/python-java/aspose.slides/nullablebool/#False)와 함께 도형에 사용하면, 도형 내부 텍스트가 도형 너비보다 길어질 때 텍스트가 한 줄로 도형 경계를 넘어 확장됩니다. 
{{% /alert %}}

## **FAQ**

**텍스트 프레임의 내부 여백이 AutoFit에 영향을 줍니까?**

예. 패딩(내부 여백)은 텍스트에 사용할 수 있는 영역을 줄이므로 AutoFit이 더 일찍 작동합니다—글꼴을 줄이거나 도형 크기를 빨리 조정합니다. AutoFit을 조정하기 전에 여백을 확인하고 조정하십시오.

**AutoFit은 수동 및 부드러운 줄 바꿈과 어떻게 상호 작용합니까?**

강제 줄 바꿈은 그대로 유지되며, AutoFit은 그 주변의 글꼴 크기와 간격을 조정합니다. 불필요한 줄 바꿈을 제거하면 AutoFit이 텍스트를 축소해야 하는 정도가 감소하는 경우가 많습니다.

**테마 글꼴을 변경하거나 글꼴 대체를 적용하면 AutoFit 결과에 영향을 줍니까?**

예. 다른 글리프 메트릭을 가진 글꼴로 대체하면 텍스트의 너비/높이가 변하여 최종 글꼴 크기와 줄 바꿈에 영향을 줄 수 있습니다. 글꼴을 변경하거나 대체한 후에는 슬라이드를 다시 확인하십시오.