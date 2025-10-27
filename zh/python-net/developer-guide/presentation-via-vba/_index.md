---
title: 使用 Python 管理演示文稿中的 VBA 项目
linktitle: 通过 VBA 的演示文稿
type: docs
weight: 250
url: /zh/python-net/developer-guide/presentation-via-vba/
keywords:
- macro
- VBA
- VBA macro
- add macro
- remove macro
- extract macro
- add VBA
- remove VBA
- extract VBA
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 通过 VBA 生成和操作 PowerPoint 与 OpenDocument 演示文稿，以简化工作流。"
---

## **概述**

本文探讨了 Aspose.Slides for Python via .NET 在 PowerPoint 演示文稿中处理宏的主要功能。该库提供了便捷的工具用于添加、移除和提取宏，使您能够自动化演示文稿的创建和修改。

使用 Aspose.Slides，您可以：

- 加速演示文稿开发——自动化日常任务可减少准备材料的时间。
- 确保灵活性——管理宏的能力让您可以根据特定任务和场景定制演示文稿。
- 集成数据——简易地与外部数据源集成，保持幻灯片内容的最新。
- 简化维护——集中式的宏管理使更改和更新演示文稿更为便捷。

本文随后提供了使用 Aspose.Slides 高效处理 PowerPoint 宏的实际示例。

[aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) 命名空间提供了用于处理宏和 VBA 代码的类。

{{% alert title="注意" color="warning" %}}

当您将包含宏的演示文稿转换为其他格式（PDF、HTML 等）时，Aspose.Slides 会忽略这些宏——它们不会写入输出文件。

当您向演示文稿添加宏或重新保存包含宏的演示文稿时，Aspose.Slides 会原样写入宏字节。

Aspose.Slides **永不** 在演示文稿中执行宏。

{{% /alert %}}

## **添加 VBA 宏**

Aspose.Slides 提供了 [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) 类，用于创建 VBA 项目（及项目引用）以及编辑现有模块。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。  
2. 使用 [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) 构造函数添加一个新 VBA 项目。  
3. 向 VBA 项目添加一个模块。  
4. 设置模块的源代码。  
5. 添加对 `<stdole>` 的引用。  
6. 添加对 **Microsoft Office** 的引用。  
7. 将这些引用关联到 VBA 项目。  
8. 保存演示文稿。

以下 Python 代码演示了如何从零添加 VBA 宏到演示文稿：

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Create a new VBA project.
    presentation.vba_project = slides.vba.VbaProject()

    # Add an empty module to the VBA project.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Set the module source code.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Create a reference to <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Create a reference to Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Add the references to the VBA project.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Save the presentation.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}

您可以尝试 **Aspose** 的 [宏移除工具](https://products.aspose.app/slides/remove-macros)，这是一款免费网页版应用，可从 PowerPoint、Excel 和 Word 文档中移除宏。

{{% /alert %}}

## **移除 VBA 宏**

通过 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的 [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) 属性，您可以移除 VBA 宏。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。  
2. 访问宏模块并将其移除。  
3. 保存修改后的演示文稿。

以下 Python 代码演示了如何移除 VBA 宏：

```python
import aspose.slides as slides

# Load the presentation that contains the macro.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Access the VBA module.
    vba_module = presentation.vba_project.modules[0]

    # Remove the VBA module.
    presentation.vba_project.modules.remove(vba_module)

    # Save the presentation.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **提取 VBA 宏**

使用 [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) 类的 `modules` 属性，您可以访问 VBA 项目的所有模块。利用 [VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) 类可以提取模块属性，如名称和代码。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。  
2. 检查演示文稿是否包含 VBA 项目。  
3. 遍历 VBA 项目中的所有模块，以查看宏内容。

以下 Python 代码演示了如何从演示文稿中提取 VBA 宏：

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **检查 VBA 项目是否受密码保护**

通过 [VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) 属性，您可以判断项目属性是否受到密码保护。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。  
2. 检查演示文稿是否包含 [VBA 项目](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/)。  
3. 检查该 VBA 项目是否受密码保护，以查看其属性。

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **常见问题**

**如果我将演示文稿另存为 PPTX，会发生什么？**

宏会被移除，因为 PPTX 不支持 VBA。若需保留宏，请选择 PPTM、PPSM 或 POTM。

**Aspose.Slides 能在演示文稿中运行宏，例如刷新数据吗？**

不能。该库永不执行 VBA 代码；只有在 PowerPoint 中并且安全设置允许时才可能执行。

**是否支持操作与 VBA 代码关联的 ActiveX 控件？**

是的，您可以访问现有的 [ActiveX 控件](/slides/zh/python-net/activex/)、修改其属性并将其移除。这在宏与 ActiveX 交互时非常有用。