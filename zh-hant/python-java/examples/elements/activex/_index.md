---
title: ActiveX
type: docs
weight: 200
url: /zh-hant/python-java/examples/elements/activex/
keywords:
- 程式碼範例
- ActiveX
- ActiveX 控制項
- ActiveX 屬性
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在 PowerPoint 簡報中新增、存取、移除及設定 ActiveX 控制項，並提供實用的程式碼範例。"
---
本文示範如何在簡報中使用 **Aspose.Slides for Python via Java** 添加、存取、移除以及配置 ActiveX 控制項。

請依照[Installation](/slides/zh-hant/python-java/installation/) 中的說明安裝套件。每個範例在啟動 JVM 之前先匯入 `asposeslides`，然後在 JVM 運行後再匯入 API。存取與移除範例使用由第一個範例建立的 `add_activex.pptm`。

## **新增 ActiveX 控制項**

在第一張投影片插入 Windows Media Player 控制項，並將簡報儲存為 PPTM 檔案。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 新增 Windows Media Player 控制項。
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50)
    control.getProperties().set_Item("autoStart", "false")

    presentation.save("add_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **存取 ActiveX 控制項**

讀取投影片上第一個 ActiveX 控制項的名稱與自動播放設定。

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
            # 存取第一個 ActiveX 控制項。
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

## **移除 ActiveX 控制項**

從投影片中刪除第一個 ActiveX 控制項，並儲存已修改的簡報。

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
            # 移除第一個 ActiveX 控制項。
            slide.getControls().removeAt(0)
        else:
            print("The first slide contains no ActiveX controls.")
    else:
        print("The presentation contains no slides.")

    presentation.save("removed_activex.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **設定 ActiveX 屬性**

新增 Windows Media Player 控制項，停用自動播放，並隱藏其播放控制項。使用[ControlPropertiesCollection.set_Item](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/controlpropertiescollection/#set_Item) 以字串形式指定屬性值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # 新增 Windows Media Player 控制項並設定其屬性。
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50)
    properties = control.getProperties()
    properties.set_Item("autoStart", "false")
    properties.set_Item("uiMode", "none")

    presentation.save("set_activex_props.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```