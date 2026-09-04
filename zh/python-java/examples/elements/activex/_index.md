---
title: ActiveX
type: docs
weight: 200
url: /zh/python-java/examples/elements/activex/
keywords:
- 代码示例
- ActiveX
- ActiveX 控件
- ActiveX 属性
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 演示文稿中添加、访问、删除和配置 ActiveX 控件，并提供实用的代码示例。"
---
本文演示如何在演示文稿中添加、访问、删除和配置 ActiveX 控件，使用 **Aspose.Slides for Python via Java**。

按照[Installation](/slides/zh/python-java/installation/)中的说明安装包。每个示例在启动 JVM 之前导入 `asposeslides`，然后在 JVM 运行后导入 API。访问和删除示例使用由第一个示例创建的 `add_activex.pptm`。

## **添加 ActiveX 控件**

在第一张幻灯片上插入 Windows Media Player 控件，并将演示文稿保存为 PPTM 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 添加 Windows Media Player 控件。
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **访问 ActiveX 控件**

读取幻灯片上第一个 ActiveX 控件的名称和自动播放设置。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # 访问第一个 ActiveX 控件。
            control = slide.getControls().get_Item(0)
            print("Control Name:", control.getName())
            print("autoStart:", control.getProperties().get_Item("autoStart"))
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

## **删除 ActiveX 控件**

从幻灯片中删除第一个 ActiveX 控件并保存修改后的演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("add_activex.pptm")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getControls().size() > 0:
            # 删除第一个 ActiveX 控件。
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **设置 ActiveX 属性**

添加 Windows Media Player 控件，禁用自动播放，并隐藏其播放控制。使用[ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/zh/python-java/aspose.slides/controlpropertiescollection/#set_Item)将属性值设为字符串。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 添加 Windows Media Player 控件并配置其属性。
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```