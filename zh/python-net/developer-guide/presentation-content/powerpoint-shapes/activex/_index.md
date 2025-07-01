---
title: 在 Python 中管理演示文稿中的 ActiveX 控件
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
description: "了解 Aspose.Slides for Python 如何利用 ActiveX 自动化并增强 PowerPoint 演示文稿，为开发者提供强大的幻灯片控制能力。"
---

ActiveX 控件用于演示文稿中。Aspose.Slides for Python via .NET 允许您管理 ActiveX 控件，但管理起来比普通演示形状要复杂且不同。从 Aspose.Slides for Python via .NET 6.9.0 开始，该组件支持管理 ActiveX 控件。此时，您可以访问已添加到演示文稿中的 ActiveX 控件，并通过其各种属性进行修改或删除。请记住，ActiveX 控件不是形状，并且不属于演示文稿的 IShapeCollection，而是单独的 IControlCollection。本文展示了如何与它们一起工作。
## **修改 ActiveX 控件**
要管理幻灯片上的简单 ActiveX 控件，例如文本框和简单命令按钮：

1. 创建 Presentation 类的实例并加载包含 ActiveX 控件的演示文稿。
1. 通过索引获取幻灯片引用。
1. 通过访问 IControlCollection 来访问幻灯片中的 ActiveX 控件。
1. 使用 ControlEx 对象访问 TextBox1 ActiveX 控件。
1. 更改 TextBox1 ActiveX 控件的不同属性，包括文本、字体、字体高度和框架位置。
1. 访问第二个访问控件 CommandButton1。
1. 更改按钮标题、字体和位置。
1. 移动 ActiveX 控件框架的位置。
1. 将修改后的演示文稿写入 PPTX 文件。

下面的代码片段更新演示文稿幻灯片上的 ActiveX 控件，如下所示。

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
        newText = "修改后的文本"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # 更换替代图像。Powerpoint将在 ActiveX 激活期间替换此图像，因此有时可以保持图像不变。

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
        newCaption = "消息框"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # 更换替代
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
    
    # 将 ActiveX 框架向下移动 100 个点
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

    # 保存带有编辑过的 ActiveX 控件的演示文稿
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # 现在移除控件
    slide.controls.clear()

    # 保存清除 ActiveX 控件的演示文稿
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```


## **添加 ActiveX 媒体播放器控件**
要添加 ActiveX 媒体播放器控件，请执行以下步骤：

1. 创建 Presentation 类的实例，并加载包含媒体播放器 ActiveX 控件的示例演示文稿。
1. 创建目标 Presentation 类的实例，并生成空演示文稿实例。
1. 将模板演示文稿中带有媒体播放器 ActiveX 控件的幻灯片克隆到目标 Presentation。
1. 访问目标 Presentation 中的克隆幻灯片。
1. 通过访问 IControlCollection 获取幻灯片上的 ActiveX 控件。
1. 访问媒体播放器 ActiveX 控件并使用其属性设置视频路径。
1. 将演示文稿保存为 PPTX 文件。

```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation(path + "template.pptx") as presentation:

    # 创建空演示文稿实例
    with slides.Presentation() as newPresentation:

        # 移除默认幻灯片
        newPresentation.slides.remove_at(0)

        # 克隆带有媒体播放器 ActiveX 控件的幻灯片
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # 访问媒体播放器 ActiveX 控件并设置视频路径
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # 保存演示文稿
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```