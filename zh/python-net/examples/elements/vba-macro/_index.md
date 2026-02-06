---
title: Vba宏
type: docs
weight: 150
url: /zh/python-net/examples/elements/vba-macro/
keywords:
- VBA宏
- 添加VBA宏
- 访问VBA宏
- 删除VBA宏
- 代码示例
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "在 Python 中使用 Aspose.Slides 处理 VBA 宏：添加或编辑项目和模块，签名或删除宏，并将演示文稿保存为 PPT、PPTX 和 ODP。"
---
演示如何使用 **Aspose.Slides for Python via .NET** 添加、访问和删除 VBA 宏。

## **添加 VBA 宏**

创建一个包含 VBA 项目和简单宏模块的演示文稿。

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # 初始化 VBA 项目。
        presentation.vba_project = slides.vba.VbaProject()

        # 添加名为 "Module" 的空模块。
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **访问 VBA 宏**

检索 VBA 项目中的第一个模块。

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **删除 VBA 宏**

从 VBA 项目中删除一个模块。

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # 假设演示文稿包含 VBA 项目且至少有一个模块。
        module = presentation.vba_project.modules[0]

        # 从项目中删除该模块。
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```