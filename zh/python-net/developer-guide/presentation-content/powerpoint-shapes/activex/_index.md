---
title: 管理演示文稿中的 ActiveX 控件（Python）
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
description: "了解 Aspose.Slides for Python via .NET 如何利用 ActiveX 自动化并增强 PowerPoint 演示文稿，为开发人员提供对幻灯片的强大控制。"
---

ActiveX 控件在演示文稿中使用。Aspose.Slides for Python via .NET 允许您管理 ActiveX 控件，但管理它们稍微有些棘手，并且不同于普通的演示文稿形状。从 Aspose.Slides for Python via .NET 6.9.0 开始，该组件支持管理 ActiveX 控件。目前，您可以访问演示文稿中已经添加的 ActiveX 控件，并通过其各种属性对其进行修改或删除。请记住，ActiveX 控件不是形状，也不是演示文稿的 IShapeCollection 的一部分，而是单独的 IControlCollection。本篇文章展示了如何使用它们。

## **修改 ActiveX 控件**
要在幻灯片上管理诸如文本框和简单命令按钮等简单的 ActiveX 控件，请执行以下操作：

1. 创建 Presentation 类的实例并加载其中包含 ActiveX 控件的演示文稿。
1. 通过索引获取幻灯片的引用。
1. 通过访问 IControlCollection 来获取幻灯片中的 ActiveX 控件。
1. 使用 ControlEx 对象访问 TextBox1 ActiveX 控件。
1. 更改 TextBox1 ActiveX 控件的各项属性，包括文本、字体、字体高度和框架位置。
1. 访问名为 CommandButton1 的第二个控件。
1. 更改按钮的标题、字体和位置。
1. 移动 ActiveX 控件框架的位置。
1. 将修改后的演示文稿写入 PPTX 文件。

下面的代码片段将演示文稿幻灯片上的 ActiveX 控件更新为如下所示的幻灯片。
```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# 访问包含 ActiveX 控件的演示文稿
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # 访问演示文稿中的第一张幻灯片
    slide = presentation.slides[0]

    # 更改 TextBox 文本
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # 更改替代图像。Powerpoint 将在 activeX activation 期间替换此图像，因此有时可以保持图像不变。

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # 更改按钮标题
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # 更改替代图像
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # 将 ActiveX 框向下移动 100 点
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # 保存已编辑 ActiveX 控件的演示文稿
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # 现在移除控件
    slide.controls.clear()

    # 保存已清除 ActiveX 控件的演示文稿
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **添加 ActiveX Media Player 控件**
要添加 ActiveX Media Player 控件，请执行以下步骤：

1. 创建 Presentation 类的实例并加载其中包含 Media Player ActiveX 控件的示例演示文稿。
1. 创建目标 Presentation 类的实例并生成空的演示文稿实例。
1. 将模板演示文稿中包含 Media Player ActiveX 控件的幻灯片克隆到目标 Presentation。
1. 访问目标 Presentation 中克隆的幻灯片。
1. 通过访问 IControlCollection 来获取幻灯片中的 ActiveX 控件。
1. 访问 Media Player ActiveX 控件并使用其属性设置视频路径。
1. 将演示文稿保存为 PPTX 文件。
```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation(path + "template.pptx") as presentation:

    # 创建空的演示文稿实例
    with slides.Presentation() as newPresentation:

        # 删除默认幻灯片
        newPresentation.slides.remove_at(0)

        # 克隆包含 Media Player ActiveX 控件的幻灯片
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # 访问 Media Player ActiveX 控件并设置视频路径
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # 保存演示文稿
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```


## **常见问题**

**Aspose.Slides 在读取并重新保存时，如果 ActiveX 控件无法在 Python 运行时执行，是否仍会保留这些控件？**

是的。Aspose.Slides 将它们视为演示文稿的一部分，能够读取/修改其属性和框架；并不需要执行这些控件本身即可保留它们。

**ActiveX 控件与演示文稿中的 OLE 对象有何区别？**

ActiveX 控件是交互式受管理的控件（按钮、文本框、媒体播放器），而 [OLE](/slides/zh/python-net/manage-ole/) 指的是嵌入的应用程序对象（例如 Excel 工作表）。它们的存储和处理方式不同，属性模型也不同。

**如果文件已被 Aspose.Slides 修改，ActiveX 事件和 VBA 宏还能工作吗？**

Aspose.Slides 会保留现有的标记和元数据；但是，事件和宏只能在 Windows 上的 PowerPoint 中且安全设置允许时运行。该库不会执行 VBA。