---
title: Python에서 AutoFit으로 프레젠테이션을 향상시키세요
linktitle: Autofit 설정
type: docs
weight: 30
url: /ko/python-java/manage-autofit-settings/
keywords:
- 텍스트 상자
- 자동 맞춤
- 자동 맞춤 안 함
- 텍스트 맞춤
- 텍스트 축소
- 텍스트 줄 바꿈
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

기본적으로 텍스트 상자를 추가하면 Microsoft PowerPoint는 텍스트에 맞게 도형 크기 조정 설정을 사용합니다—텍스트가 항상 맞도록 텍스트 상자의 크기를 자동으로 조정합니다.

![PowerPoint의 텍스트 상자](textbox-in-powerpoint.png)

* 텍스트 상자의 텍스트가 길어지거나 커지면 PowerPoint가 텍스트 상자를 자동으로 확대합니다—높이를 늘려 더 많은 텍스트를 담을 수 있게 합니다.
* 텍스트 상자의 텍스트가 짧아지거나 작아지면 PowerPoint가 텍스트 상자를 자동으로 축소합니다—높이를 줄여 여분의 공간을 없앱니다.

PowerPoint에서는 텍스트 상자의 자동 맞춤 동작을 제어하는 4가지 중요한 매개변수 또는 옵션이 있습니다:

* **자동 맞춤 하지 않음**
* **오버플로 시 텍스트 축소**
* **텍스트에 맞게 도형 크기 조정**
* **도형 안에서 텍스트 줄 바꿈**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Python via Java은 유사한 옵션—[TextFrameFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/) 클래스의 일부 속성—을 제공하여 프레젠테이션의 텍스트 상자에 대한 자동 맞춤 동작을 제어할 수 있습니다.

## **텍스트에 맞게 도형 크기 조정**

텍스트가 변경된 후에도 항상 상자에 맞게 하려면 **텍스트에 맞게 도형 크기 조정** 옵션을 사용해야 합니다. 이 설정을 지정하려면 [setAutofitType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setAutofitType) 메서드([TextFrameFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/) 클래스)와 함께 [Shape](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textautofittype/#Shape)를 사용하십시오.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

다음 Python 코드는 PowerPoint 프레젠테이션에서 텍스트가 항상 상자에 맞게 하도록 지정하는 방법을 보여줍니다:

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

텍스트가 길어지거나 커지면 텍스트 상자가 자동으로 높이가 증가하도록 크기가 조정되어 모든 텍스트가 들어갑니다. 텍스트가 짧아지면 그 반대가 발생합니다.

## **자동 맞춤 하지 않음**

텍스트 상자나 도형이 포함된 텍스트의 변경에 관계없이 크기를 유지하려면 **자동 맞춤 하지 않음** 옵션을 사용해야 합니다. 이 설정을 지정하려면 [setAutofitType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setAutofitType) 메서드([TextFrameFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/) 클래스)와 함께 [None](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textautofittype/#None)를 사용하십시오.

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
    text_frame_format.setAutofitType(TextAutofitType.None_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

텍스트가 상자보다 길어지면 텍스트가 밖으로 흘러나옵니다.

## **오버플로 시 텍스트 축소**

텍스트가 상자보다 길어지면 **오버플로 시 텍스트 축소** 옵션을 사용하여 텍스트 크기와 간격을 줄여 상자에 맞추도록 지정할 수 있습니다. 이 설정을 지정하려면 [setAutofitType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setAutofitType) 메서드([TextFrameFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/) 클래스)와 함께 [Normal](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textautofittype/#Normal)를 사용하십시오.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

다음 Python 코드는 PowerPoint 프레젠테이션에서 오버플로 시 텍스트를 축소하도록 지정하는 방법을 보여줍니다:

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

{{% alert title="참고" color="info" %}}
**오버플로 시 텍스트 축소** 옵션을 사용하면 텍스트가 상자보다 길어질 때만 설정이 적용됩니다. 
{{% /alert %}}

## **도형 안에서 텍스트 줄 바꿈**

텍스트가 도형의 경계(너비) 밖으로 넘어갈 때 텍스트가 해당 도형 안에서 자동으로 줄 바꿈되도록 하려면 **도형 안에서 텍스트 줄 바꿈** 매개변수를 사용해야 합니다. 이 설정을 지정하려면 [setWrapText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setWrapText) 메서드([TextFrameFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/) 클래스)와 함께 [NullableBool.True_](https://reference.aspose.com/slides/ko/python-java/aspose.slides/nullablebool/#True)를 사용하십시오.

다음 Python 코드는 PowerPoint 프레젠테이션에서 줄 바꿈 설정을 사용하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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
    text_frame_format.setWrapText(NullableBool.True_)

    presentation.save("Output-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="경고" color="warning" %}} 
[setWrapText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/textframeformat/#setWrapText) 메서드를 [NullableBool.False](https://reference.aspose.com/slides/ko/python-java/aspose.slides/nullablebool/#False)와 함께 사용하면, 텍스트가 도형의 너비보다 길어질 때 텍스트가 단일 라인으로 도형 경계를 넘어 확장됩니다.
{{% /alert %}}

## **FAQ**

**텍스트 프레임의 내부 여백이 자동 맞춤에 영향을 줍니까?**

예. 내부 여백(패딩)은 텍스트가 사용할 수 있는 영역을 줄이므로 자동 맞춤이 더 빨리 작동합니다—글꼴을 축소하거나 도형 크기를 조정합니다. 자동 맞춤을 조정하기 전에 여백을 확인하고 조정하십시오.

**자동 맞춤은 수동 및 소프트 줄 바꿈과 어떻게 상호 작용합니까?**

강제 줄 바꿈은 그대로 유지되고 자동 맞춤은 그 주변의 글꼴 크기와 간격을 조정합니다. 불필요한 줄 바꿈을 제거하면 자동 맞춤이 텍스트를 축소하는 정도를 줄일 수 있습니다.

**테마 글꼴을 변경하거나 글꼴 대체를 트리거하면 자동 맞춤 결과에 영향을 줍니까?**

예. 다른 문자 메트릭을 가진 글꼴로 대체하면 텍스트 너비/높이가 변하여 최종 글꼴 크기와 줄 바꿈이 달라질 수 있습니다. 글꼴을 변경하거나 대체한 후에는 슬라이드를 다시 확인하십시오.