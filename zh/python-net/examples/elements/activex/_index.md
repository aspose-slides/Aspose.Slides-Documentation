---
title: ActiveX
type: docs
weight: 200
url: /zh/python-net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX 控件
- 添加 ActiveX
- 访问 ActiveX
- 删除 ActiveX
- ActiveX 属性
- 代码示例
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何在 Python 中使用 Aspose.Slides 查找、编辑和删除 ActiveX 控件，并对 PowerPoint 演示文稿的属性进行更新。"
---
演示如何在演示文稿中使用 **Aspose.Slides for Python via .NET** 添加、访问、删除和配置 ActiveX 控件。

## **添加 ActiveX 控件**

插入一个新的 ActiveX 控件。

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 添加一个新的 ActiveX 控件（TextBox）。
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **访问 ActiveX 控件**

读取幻灯片上第一个 ActiveX 控件的信息。

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # 访问第一个 ActiveX 控件。
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # 打印控件名称。
            print(f"Control Name: {control.name}")
```

## **删除 ActiveX 控件**

从幻灯片中删除现有的 ActiveX 控件。

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # 删除第一个 ActiveX 控件。
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **设置 ActiveX 属性**

配置多个 ActiveX 属性。

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # 假设 Control 集合至少包含一个 Control。
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```