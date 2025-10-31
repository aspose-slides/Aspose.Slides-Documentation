---
title: 使用Python管理演示文稿中的VBA项目
linktitle: 通过VBA的演示文稿
type: docs
weight: 250
url: /zh/python-net/presentation-via-vba/
keywords:
- 宏
- VBA
- VBA宏
- 添加宏
- 删除宏
- 提取宏
- 添加VBA
- 删除VBA
- 提取VBA
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 通过 VBA 生成和操作 PowerPoint 与 OpenDocument 演示文稿，以简化工作流程。"
---

## **概述**

本文探讨了 Aspose.Slides for Python via .NET 在 PowerPoint 演示文稿中处理宏的主要功能。该库提供了便捷的添加、删除和提取宏的工具，使您能够自动化演示文稿的创建和修改。

- 加速演示文稿开发——例行任务的自动化降低了准备材料所需的时间。
- 确保灵活性——管理宏的能力使您能够根据特定任务和场景定制演示文稿。
- 集成数据——与外部数据源的简单集成有助于保持幻灯片内容的最新。
- 简化维护——集中式宏管理使得更容易应用更改和更新演示文稿。

本文随后提供了使用 Aspose.Slides 高效处理 PowerPoint 中宏的实用示例。

命名空间 [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) 提供了用于处理宏和 VBA 代码的类。

{{% alert title="注意" color="warning" %}}
当您将包含宏的演示文稿转换为其他格式（PDF、HTML 等）时，Aspose.Slides 会忽略宏——它们不会转移到输出文件中。

当您向演示文稿添加宏或重新保存包含宏的演示文稿时，Aspose.Slides 会原样写入宏字节。

Aspose.Slides **永不** 执行演示文稿中的宏。
{{% /alert %}}

## **添加 VBA 宏**

Aspose.Slides 提供了 [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) 类，用于创建 VBA 项目（及项目引用）并编辑现有模块。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 使用 [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) 构造函数添加新的 VBA 项目。
3. 向 VBA 项目添加模块。
4. 设置模块的源代码。
5. 添加对 `<stdole>` 的引用。
6. 添加对 **Microsoft Office** 的引用。
7. 将这些引用关联到 VBA 项目。
8. 保存演示文稿。

下面的 Python 代码演示了如何从头向演示文稿添加 VBA 宏：

```python
import aspose.slides as slides

# 创建 Presentation 类的实例。
with slides.Presentation() as presentation:

    # 创建新的 VBA 项目。
    presentation.vba_project = slides.vba.VbaProject()

    # 向 VBA 项目添加空模块。
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
您可能想尝试 **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros)，这是一款免费网络应用，可从 PowerPoint、Excel 和 Word 文档中删除宏。
{{% /alert %}}

## **删除 VBA 宏**

使用 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的 [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) 属性，您可以删除 VBA 宏。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
2. 访问宏模块并将其删除。
3. 保存修改后的演示文稿。

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

使用 [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) 类的 `modules` 属性，您可以访问 VBA 项目的所有模块。 [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) 类可用于提取模块属性，如名称和代码。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
2. 检查演示文稿是否包含 VBA 项目。
3. 遍历 VBA 项目中的所有模块以查看宏。

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

使用 [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) 属性，您可以确定项目属性是否受密码保护。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。
2. 检查演示文稿是否包含 [VBA 项目](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/)。
3. 检查 VBA 项目是否受密码保护以查看其属性。

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # 检查演示文稿是否包含 VBA 项目。
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **常见问题**

**如果我将演示文稿另存为 PPTX，会怎样？**

宏将被删除，因为 PPTX 不支持 VBA。要保留宏，请选择 PPTM、PPSM 或 POTM。

**Aspose.Slides 能在演示文稿中运行宏，例如刷新数据吗？**

不能。该库永不执行 VBA 代码；只有在 PowerPoint 中且安全设置合适时才可能执行。

**是否支持使用与 VBA 代码关联的 ActiveX 控件？**

是的，您可以访问现有的 [ActiveX controls](/slides/zh/python-net/activex/)，修改其属性并将其删除。这在宏与 ActiveX 交互时非常有用。