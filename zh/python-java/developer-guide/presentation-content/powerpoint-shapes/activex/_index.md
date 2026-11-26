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
description: "编辑 ActiveX 文本框和按钮，更新控件预览，并在 PowerPoint 演示文稿中使用 Aspose.Slides for Python via Java 复用 Windows Media Player 控件。"
---
## **介绍**

ActiveX 控件为 PowerPoint 幻灯片提供交互元素，例如文本框、命令按钮和媒体播放器。Aspose.Slides for Python via Java 通过 [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls) 公开幻灯片的控件。使用此集合编辑控件、在幻灯片上移动或删除它。

## **列出 ActiveX 控件及其存储属性**

要检查不熟悉的模板，打开它进行读取并遍历每张幻灯片上的控件。示例报告幻灯片编号、控件名称、[getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId)以及 [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) 中的每个键值对。它读取演示文稿时不会激活控件、调用事件或宏、更改值或保存文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

从 `ActiveX.pptm` 选取的输出显示了一个文本框和一个命令按钮。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空的属性集合显示为 `[]`。对于使用二进制存储的控件，[getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) 可能返回 `None`，显示为 `Properties unavailable`。如果只需要名称，请在确认集合可用后使用 [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties)。报告列出了演示文稿中可用的属性。控件在运行时可能支持额外的属性。

## **修改 ActiveX 控件**

示例假设宏启用的演示文稿的第一页包含名为 `TextBox1` 的文本框和名为 `CommandButton1` 的命令按钮。它使用 [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) 更改文本框的值和按钮的标题。每个控件还有 PowerPoint 在激活前可以显示的静态预览。为每个控件提供显示其更新文本和外观的 PNG。示例通过 [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat) 为这些图片赋值。

示例通过使用 [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame) 将第一张幻灯片上的所有控件向下移动 100 点。它以 PPTM 格式保存编辑后的演示文稿，然后使用 [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) 保存第二个副本，其中已从该幻灯片移除所有 ActiveX 控件。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **添加 ActiveX 媒体播放器控件**

要复用已配置的 Windows Media Player 控件，请使用第一张幻灯片包含名为 `WindowsMediaPlayer1` 的播放器的模板。[SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) 将整张幻灯片复制到新演示文稿中。示例在其 [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) 中设置播放器的 `URL`，并将克隆的幻灯片保存为输出中的唯一幻灯片。视频保持外部状态，因此请选择播放器在播放时可以访问的路径。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **常见问题**

**Aspose.Slides 能在不运行它们的情况下保留 ActiveX 控件吗？**

可以。Aspose.Slides 可以读取并保存控件，包括它们的属性和位置，而无需激活它们。

**ActiveX 控件与 OLE 对象有何区别？**

ActiveX 控件允许用户与幻灯片交互，例如输入文本或点击按钮。一个 [OLE object](/slides/zh/python-java/manage-ole/) 让幻灯片包含或链接到由其他应用程序管理的内容，例如 Excel 工作表。

**在使用 Aspose.Slides 保存演示文稿后，ActiveX 事件仍会触发 VBA 宏吗？**

请将演示文稿保存为 PPTM 等宏启用格式以保留其 VBA 项目。当 Windows 版 PowerPoint 的安全设置同时允许 ActiveX 控件和宏时，PowerPoint 可以运行现有的事件处理程序。