---
title: Vba 巨集
type: docs
weight: 150
url: /zh-hant/python-net/examples/elements/vba-macro/
keywords:
- VBA 巨集
- 新增 VBA 巨集
- 存取 VBA 巨集
- 移除 VBA 巨集
- 程式碼範例
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中處理 VBA 巨集：新增或編輯專案與模組、簽署或移除巨集，並將簡報保存為 PPT、PPTX 或 ODP。"
---
說明如何使用 **Aspose.Slides for Python via .NET** 來新增、存取和移除 VBA 巨集。

## **新增 VBA 巨集**

建立包含 VBA 專案和簡單巨集模組的簡報。

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # 初始化 VBA 專案。
        presentation.vba_project = slides.vba.VbaProject()

        # 新增一個名稱為 "Module" 的空模組。
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **存取 VBA 巨集**

從 VBA 專案中取得第一個模組。

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **移除 VBA 巨集**

從 VBA 專案中刪除模組。

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # 假設簡報包含 VBA 專案且至少有一個模組。
        module = presentation.vba_project.modules[0]

        # 從專案中移除該模組。
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```