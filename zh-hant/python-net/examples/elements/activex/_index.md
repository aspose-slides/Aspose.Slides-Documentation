---
title: ActiveX
type: docs
weight: 200
url: /zh-hant/python-net/examples/elements/activex/
keywords:
- ActiveX
- ActiveX 控制項
- 新增 ActiveX
- 存取 ActiveX
- 移除 ActiveX
- ActiveX 屬性
- 程式碼範例
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "了解如何在 Python 中使用 Aspose.Slides 尋找、編輯與移除 ActiveX 控制項，並為 PowerPoint 簡報更新屬性。"
---
示範如何在簡報中使用 **Aspose.Slides for Python via .NET** 新增、存取、移除與設定 ActiveX 控制項。

## **新增 ActiveX 控制項**

插入新的 ActiveX 控制項。

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # 新增一個 ActiveX 控制項 (TextBox)。
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **存取 ActiveX 控制項**

讀取投影片上第一個 ActiveX 控制項的資訊。

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # 存取第一個 ActiveX 控制項。
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # 列印控制項名稱。
            print(f"Control Name: {control.name}")
```

## **移除 ActiveX 控制項**

從投影片中刪除現有的 ActiveX 控制項。

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # 移除第一個 ActiveX 控制項。
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **設定 ActiveX 屬性**

設定多個 ActiveX 屬性。

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # 假設 Control 集合至少包含一個 Control。
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```