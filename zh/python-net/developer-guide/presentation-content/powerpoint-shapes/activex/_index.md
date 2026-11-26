---
title: 在演示文稿中使用 Python 管理 ActiveX 控件
linktitle: ActiveX
type: docs
weight: 80
url: /zh/python-net/activex/
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
description: "使用 Aspose.Slides for Python via .NET 编辑 ActiveX 文本框和按钮，更新控件预览，并在 PowerPoint 演示文稿中重复使用 Windows Media Player 控件。"
---
## **介绍**

ActiveX 控件为 PowerPoint 幻灯片提供交互式元素，例如文本框、命令按钮和媒体播放器。Aspose.Slides for Python via .NET 通过 [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/) 公开幻灯片的控件。使用此集合来编辑控件、在幻灯片上移动它或将其删除。

## **列出 ActiveX 控件及其存储属性**

要检查不熟悉的模板，请以读取模式打开并遍历每张幻灯片上的控件。示例报告幻灯片编号、控件名称、[class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/)以及 [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties) 中的每个键值对。它在不激活控件、调用事件或宏、更改数值或保存文件的情况下读取演示文稿。

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
```

`ActiveX.pptm` 的选定输出显示了一个文本框和一个命令按钮。

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

空属性集合显示为 `[]`。对于使用二进制存储的控件，`properties` 可能返回 `None`，显示为 `Properties unavailable`。如果只需要名称，请在检查 `None` 之后使用 [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/)。报告列出了演示文稿中可用的属性。控件在运行时可能支持其他属性。

## **修改 ActiveX 控件**

示例假设宏启用的演示文稿的第一张幻灯片上有一个名为 `TextBox1` 的文本框和一个名为 `CommandButton1` 的命令按钮。它使用 [控件属性集合](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) 来更改文本框的值和按钮的标题。每个控件还有 PowerPoint 在激活前可以显示的静态预览。为每个控件提供显示其更新后文本和外观的 PNG。示例通过 [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/) 分配这些图像。

示例通过更改其 [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/) 将第一张幻灯片上的每个控件下移 100 点。它以 PPTM 格式保存编辑后的演示文稿，然后使用 [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) 保存第二个副本，其中该幻灯片的所有 ActiveX 控件均已移除。

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **添加 ActiveX 媒体播放器控件**

要重用已经配置好的 Windows Media Player 控件，请使用第一张幻灯片包含名为 `WindowsMediaPlayer1` 的播放器的模板。[SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) 将整张幻灯片复制到新演示文稿中。示例在其 [属性集合](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) 中设置播放器的 `URL`，并将克隆的幻灯片保存为输出中的唯一幻灯片。视频保持为外部文件，请选择播放器在播放期间能够访问的路径。

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **常见问题**

**Aspose.Slides 能否在不运行它们的情况下保留 ActiveX 控件？**

是的。Aspose.Slides 可以读取并保存控件，包括它们的属性和位置，而无需激活它们。

**ActiveX 控件与 OLE 对象有何区别？**

ActiveX 控件允许用户与幻灯片交互，例如输入文本或单击按钮。[OLE object](/slides/zh/python-net/manage-ole/) 使幻灯片能够包含或链接到由其他应用程序管理的内容，例如 Excel 工作表。

**使用 Aspose.Slides 保存演示文稿后，ActiveX 事件仍会触发 VBA 宏吗？**

将演示文稿保存为宏启用的格式（如 PPTM）以保留其 VBA 项目。当 Windows 版 PowerPoint 的安全设置同时允许 ActiveX 控件和宏时，它可以运行现有的事件处理程序。