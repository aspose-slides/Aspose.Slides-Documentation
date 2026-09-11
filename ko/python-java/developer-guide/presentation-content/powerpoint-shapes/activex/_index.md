---
title: Python을 사용하여 프레젠테이션에서 ActiveX 컨트롤 관리
linktitle: ActiveX
type: docs
weight: 80
url: /ko/python-java/activex/
keywords:
- ActiveX
- ActiveX 컨트롤
- ActiveX 관리
- ActiveX 추가
- ActiveX 수정
- 미디어 플레이어
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java가 ActiveX를 사용하여 PowerPoint 프레젠테이션을 자동화하고 향상시키는 방법을 배우고, 개발자에게 슬라이드에 대한 강력한 제어 기능을 제공합니다."
---
## **소개**

ActiveX 컨트롤은 프레젠테이션에서 사용됩니다. Aspose.Slides for Python via Java를 사용하면 ActiveX 컨트롤을 추가하고 관리할 수 있지만 일반 프레젠테이션 도형에 비해 다루기가 다소 까다롭습니다. Aspose.Slides는 Media Player ActiveX 컨트롤 추가를 지원합니다. ActiveX 컨트롤은 도형이 아니며 프레젠테이션의 [ShapeCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shapecollection/)에 포함되지 않습니다. 대신 별도의 [ControlCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/controlcollection/)에 포함됩니다. 이 항목에서는 해당 컨트롤을 사용하는 방법을 보여드리겠습니다.

## **슬라이드에 Media Player ActiveX 컨트롤 추가**

Media Player ActiveX 컨트롤을 추가하려면 다음을 수행합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화하고 빈 프레젠테이션을 생성합니다.
2. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)에서 대상 슬라이드에 접근합니다.
3. [ControlCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/controlcollection/)이 제공하는 [addControl](https://reference.aspose.com/slides/ko/python-java/aspose.slides/controlcollection/#addControl) 메서드를 사용해 Media Player ActiveX 컨트롤을 추가합니다.
4. Media Player ActiveX 컨트롤에 접근하고 해당 속성을 사용해 비디오 경로를 설정합니다.
5. 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계에 따라 슬라이드에 Media Player ActiveX 컨트롤을 추가하는 예제 코드입니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# 빈 프레젠테이션을 생성합니다.
presentation = Presentation()
try:
    # Media Player ActiveX 컨트롤을 추가합니다.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # 비디오 경로를 설정합니다.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # 프레젠테이션을 저장합니다.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ActiveX 컨트롤 수정**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java는 ActiveX 컨트롤 관리를 위한 구성 요소를 제공합니다. 프레젠테이션에 이미 추가된 ActiveX 컨트롤에 접근하여 해당 속성을 통해 수정하거나 삭제할 수 있습니다.
{{% /alert %}}

슬라이드에서 텍스트 상자와 단순 명령 버튼과 같은 기본 ActiveX 컨트롤을 관리하려면 다음을 수행합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스를 인스턴스화하고 ActiveX 컨트롤이 포함된 프레젠테이션을 로드합니다.
2. 인덱스로 슬라이드 참조를 얻습니다.
3. 슬라이드의 [ControlCollection](https://reference.aspose.com/slides/ko/python-java/aspose.slides/controlcollection/)에 접근합니다.
4. [Control](https://reference.aspose.com/slides/ko/python-java/aspose.slides/control/) 객체를 사용해 TextBox1 ActiveX 컨트롤에 접근합니다.
5. 텍스트, 글꼴, 글꼴 높이 및 프레임 위치를 포함한 TextBox1 ActiveX 컨트롤의 속성을 변경합니다.
6. 두 번째 ActiveX 컨트롤인 CommandButton1에 접근합니다.
7. 버튼 캡션, 글꼴 및 위치를 변경합니다.
8. ActiveX 컨트롤 프레임의 위치를 이동합니다.
9. 수정된 프레젠테이션을 PPTM 파일로 저장합니다.

위 단계에 따라 간단한 ActiveX 컨트롤을 관리하는 샘플 코드입니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# ActiveX 컨트롤이 포함된 프레젠테이션을 로드합니다.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # 첫 번째 슬라이드에 접근합니다.
        slide = presentation.getSlides().get_Item(0)

        # 텍스트 상자 텍스트를 변경합니다.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # 대체 이미지를 변경합니다. PowerPoint는 ActiveX 활성화 중에 이를 교체하므로,
            # 따라서 때때로 변경되지 않을 수 있습니다.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # 버튼 캡션을 변경합니다.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # 대체 이미지를 변경합니다.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # 컨트롤을 아래쪽으로 100 포인트 이동합니다.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # 컨트롤을 제거합니다.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides가 Python 런타임에서 실행될 수 없을 경우에도 ActiveX 컨트롤을 읽고 다시 저장할 때 보존합니까?**

예. Aspose.Slides는 이를 프레젠테이션의 일부로 취급하며 해당 속성과 프레임을 읽고 수정할 수 있습니다. 컨트롤 자체를 실행할 필요는 없습니다.

**ActiveX 컨트롤과 프레젠테이션의 OLE 객체는 어떻게 다릅니까?**

ActiveX 컨트롤은 인터랙티브하게 관리되는 컨트롤(버튼, 텍스트 박스, 미디어 플레이어)이며, [OLE](/slides/ko/python-java/manage-ole/)는 임베드된 응용 프로그램 객체(예: Excel 워크시트)를 의미합니다. 저장 및 처리 방식과 속성 모델이 다릅니다.

**파일이 Aspose.Slides에 의해 수정된 경우 ActiveX 이벤트 및 VBA 매크로가 작동합니까?**

Aspose.Slides는 기존 마크업과 메타데이터를 보존하지만, 이벤트와 매크로는 보안이 허용되는 Windows 환경의 PowerPoint에서만 실행됩니다. 이 라이브러리는 VBA를 실행하지 않습니다.