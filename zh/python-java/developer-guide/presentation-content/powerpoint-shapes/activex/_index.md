---
title: 使用 Python 管理演示文稿中的 ActiveX 控件
linktitle: ActiveX
type: docs
weight: 80
url: /zh/python-java/activex/
keywords:
- ActiveX
- ActiveX 控件
- 管理 ActiveX
- 添加 ActiveX
- 修改 ActiveX
- 媒体播放器
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via Java 如何使用 ActiveX 自动化并增强 PowerPoint 演示文稿，为开发者提供对幻灯片的强大控制能力。"
---
## **简介**

ActiveX 控件用于演示文稿。Aspose.Slides for Python via Java 允许您添加和管理 ActiveX 控件，但与普通演示形状相比，它们的管理稍显复杂。Aspose.Slides 支持添加 Media Player ActiveX 控件。请注意，ActiveX 控件不是形状；它们不是演示文稿的[ShapeCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/shapecollection/)的一部分，而是属于独立的[ControlCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/controlcollection/)。在本主题中，我们将向您展示如何使用它们。

## **向幻灯片添加 Media Player ActiveX 控件**

要添加 ActiveX Media Player 控件，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例并生成一个空白演示文稿实例。  
1. 在 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 中访问目标幻灯片。  
1. 使用 [ControlCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/controlcollection/) 所提供的 [addControl](https://reference.aspose.com/slides/zh/python-java/aspose.slides/controlcollection/#addControl) 方法添加 Media Player ActiveX 控件。  
1. 访问 Media Player ActiveX 控件并通过其属性设置视频路径。  
1. 将演示文稿另存为 PPTX 文件。

下面的示例代码基于上述步骤，演示如何向幻灯片添加 Media Player ActiveX 控件：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# 创建一个空白演示文稿。
presentation = Presentation()
try:
    # 添加 Media Player ActiveX 控件。
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # 设置视频路径。
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # 保存演示文稿。
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **修改 ActiveX 控件**

{{% alert color="info" title="注意" %}}

Aspose.Slides for Python via Java 提供用于管理 ActiveX 控件的组件。您可以在演示文稿中访问已添加的 ActiveX 控件，并通过其属性对其进行修改或删除。

{{% /alert %}}

要在幻灯片上管理如文本框和简单命令按钮等简单 ActiveX 控件，请执行以下操作：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例，并加载包含 ActiveX 控件的演示文稿。  
1. 通过索引获取幻灯片引用。  
1. 通过访问 [ControlCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/controlcollection/) 来获取幻灯片中的 ActiveX 控件。  
1. 使用 [Control](https://reference.aspose.com/slides/zh/python-java/aspose.slides/control/) 对象访问 TextBox1 ActiveX 控件。  
1. 更改 TextBox1 ActiveX 控件的属性，包括文本、字体、字体高度和框架位置。  
1. 访问名为 CommandButton1 的第二个 ActiveX 控件。  
1. 更改按钮的标题、字体和位置。  
1. 调整 ActiveX 控件框架的位置。  
1. 将修改后的演示文稿写入 PPTM 文件。

下面的示例代码基于上述步骤，演示如何管理一个简单的 ActiveX 控件：

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

# 加载带有 ActiveX 控件的演示文稿。
presentation = Presentation("ActiveX.pptm")
try:
        if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
                # 访问第一张幻灯片。
                slide = presentation.getSlides().get_Item(0)

                # 更改文本框的文本。
                control = slide.getControls().get_Item(0)

                if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
                        new_text = "Changed text"
                        control.getProperties().set_Item("Value", new_text)

                        # 更改替代图像。PowerPoint 在 ActiveX 激活期间会替换它，
                        # 因此有时可以保持不变。
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

                # 更改按钮标题。
                control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

                if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
                        new_caption = "Show MessageBox"
                        control.getProperties().set_Item("Caption", new_caption)
                        # 更改替代图像。
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

                # 将控件向下移动 100 点。
                for control in slide.getControls():
                        frame = control.getFrame()
                        new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
                        control.setFrame(new_frame)
                presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

                # 删除控件。
                presentation.getSlides().get_Item(0).getControls().clear()
                presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
        else:
                print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
        presentation.dispose()
```

## **常见问题**

**Aspose.Slides 在读取并重新保存时是否会保留无法在 Python 运行时执行的 ActiveX 控件？**

是的。Aspose.Slides 将它们视为演示文稿的一部分，可以读取/修改其属性和框架；无需执行控件本身即可保留它们。

**ActiveX 控件与演示文稿中的 OLE 对象有何区别？**

ActiveX 控件是交互式受管理的控件（按钮、文本框、媒体播放器），而 [OLE](/slides/zh/python-java/manage-ole/) 指的是嵌入的应用程序对象（例如 Excel 工作表）。它们的存储和处理方式不同，属性模型也不同。

**如果文件已被 Aspose.Slides 修改，ActiveX 事件和 VBA 宏是否仍然有效？**

Aspose.Slides 会保留现有的标记和元数据；但事件和宏仅在 Windows 上的 PowerPoint 中且安全设置允许时才会运行。该库本身不执行 VBA。