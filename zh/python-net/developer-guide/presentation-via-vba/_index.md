---
title: 使用 Python 管理演示文稿中的 VBA 项目
linktitle: 通过 VBA 的演示文稿
type: docs
weight: 250
url: /zh/python-net/presentation-via-vba/
keywords:
- 宏
- VBA
- VBA 宏
- 添加宏
- 删除宏
- 提取宏
- 添加 VBA
- 删除 VBA
- 提取 VBA
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 通过 VBA 生成和操作 PowerPoint 与 OpenDocument 演示文稿，以简化工作流。"
---

## **概述**

本文探讨了 Aspose.Slides for Python via .NET 在 PowerPoint 演示文稿中处理宏的关键功能。该库提供了便捷的工具用于添加、删除和提取宏，使您能够自动化演示文稿的创建和修改。

使用 Aspose.Slides，您可以：

- 加快演示文稿开发——自动化常规任务可减少准备材料所需的时间。
- 确保灵活性——管理宏的能力使您能够根据特定任务和场景定制演示文稿。
- 集成数据——与外部数据源的简易集成帮助保持幻灯片内容的最新。
- 简化维护——集中式宏管理使应用更改和更新演示文稿更加容易。

本文随后提供了使用 Aspose.Slides 在 PowerPoint 中有效处理宏的实际示例。

aspose.slides.vba 命名空间提供了用于处理宏和 VBA 代码的类。[aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/)

{{% alert title="Note" color="warning" %}}
当您将包含宏的演示文稿转换为其他格式（PDF、HTML 等）时，Aspose.Slides 会忽略宏——它们不会传输到输出文件中。

当您向演示文稿添加宏或重新保存包含宏的演示文稿时，Aspose.Slides 会原样写入宏字节。

Aspose.Slides **永不** 在演示文稿中执行宏。
{{% /alert %}}

## **添加 VBA 宏**

Aspose.Slides 提供了 [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) 类，用于创建 VBA 项目（以及项目引用）并编辑现有模块。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
1. 使用 [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) 构造函数添加新的 VBA 项目。
1. 向 VBA 项目添加模块。
1. 设置模块的源代码。
1. 添加对 `<stdole>` 的引用。
1. 添加对 **Microsoft Office** 的引用。
1. 将这些引用关联到 VBA 项目。
1. 保存演示文稿。

以下 Python 代码展示了如何从头向演示文稿添加 VBA 宏：
```python
import aspose.slides as slides

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:

    # 创建一个新的 VBA 项目。
    presentation.vba_project = slides.vba.VbaProject()

    # 向 VBA 项目添加一个空模块。
    module = presentation.vba_project.modules.add_empty_module("Module")

    # 设置模块的源代码。
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # 创建对 <stdole> 的引用。
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # 创建对 Microsoft Office 的引用。
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # 将引用添加到 VBA 项目。
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # 保存演示文稿。
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```


{{% alert color="primary" %}}
您可能想尝试 **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)，这是一款用于从 PowerPoint、Excel 和 Word 文档中删除宏的免费网络应用。
{{% /alert %}}

## **删除 VBA 宏**

使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的 [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) 属性，您可以删除 VBA 宏。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
1. 访问宏模块并将其删除。
1. 保存修改后的演示文稿。

以下 Python 代码展示了如何删除 VBA 宏：
```python
import aspose.slides as slides

# 加载包含宏的演示文稿。
with slides.Presentation("VBA.pptm") as presentation:
    
    # 访问 VBA 模块。
    vba_module = presentation.vba_project.modules[0]

    # 删除 VBA 模块。
    presentation.vba_project.modules.remove(vba_module)

    # 保存演示文稿。
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```


## **提取 VBA 宏**

使用 [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) 类的 `modules` 属性，您可以访问 VBA 项目的所有模块。可使用 [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) 类提取模块属性，如名称和代码。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
1. 检查演示文稿是否包含 VBA 项目。
1. 遍历 VBA 项目中的所有模块以查看宏。

以下 Python 代码展示了如何从演示文稿中提取 VBA 宏：
```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # 检查演示文稿是否包含 VBA 项目。
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```


## **检查 VBA 项目是否受密码保护**

使用 [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) 属性，您可以判断项目属性是否受密码保护。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
1. 检查演示文稿是否包含 [VBA project](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/)。
1. 检查 VBA 项目是否受密码保护以查看其属性。
```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # 检查演示文稿是否包含 VBA 项目。
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```


## **常见问题**

**如果将演示文稿另存为 PPTX，宏会怎样？**

宏会被移除，因为 PPTX 不支持 VBA。若要保留宏，请选择 PPTM、PPSM 或 POTM。

**Aspose.Slides 能否在演示文稿中运行宏，例如刷新数据？**

不能。该库永不执行 VBA 代码；只能在 PowerPoint 中使用适当的安全设置时运行宏。

**是否支持使用与 VBA 代码关联的 ActiveX 控件？**

是的，您可以访问现有的 [ActiveX controls](/slides/zh/python-net/activex/)，修改其属性并将其移除。这在宏与 ActiveX 交互时非常有用。