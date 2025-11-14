---
title: 在 Python 中管理演示文稿中的 VBA 项目
linktitle: 通过 VBA 管理演示文稿
type: docs
weight: 250
url: /zh/python-net/presentation-via-vba/
keywords:
- 宏
- VBA
- VBA 宏
- 添加宏
- 移除宏
- 提取宏
- 添加 VBA
- 移除 VBA
- 提取 VBA
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用适用于 .NET 的 Aspose.Slides for Python 通过 VBA 生成和操作 PowerPoint 与 OpenDocument 演示文稿，从而简化工作流程。"
---

[Aspose.Slides.Vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/)命名空间包含用于处理宏和VBA代码的类和接口。

{{% alert title="注意" color="warning" %}} 

当您将包含宏的演示文稿转换为其他文件格式（PDF，HTML等）时，Aspose.Slides会忽略所有宏（宏不会被带入生成的文件中）。

当您将宏添加到演示文稿或重新保存包含宏的演示文稿时，Aspose.Slides只会写入宏的字节。

Aspose.Slides **从不** 执行演示文稿中的宏。

{{% /alert %}}

## **添加VBA宏**

Aspose.Slides提供了[VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/)类，允许您创建VBA项目（和项目引用）并编辑现有模块。您可以使用[IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/)接口来管理嵌入演示文稿中的VBA。

1. 创建[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例。
1. 使用[VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors)构造函数添加新的VBA项目。
1. 向VbaProject添加一个模块。
1. 设置模块源代码。
1. 添加对<stdole>的引用。
1. 添加对**Microsoft Office**的引用。
1. 将引用与VBA项目关联。
1. 保存演示文稿。

以下Python代码演示如何从零开始向演示文稿添加VBA宏：

```python
import aspose.slides as slides

# 创建演示文稿类的实例
with slides.Presentation() as presentation:
    # 创建一个新的VBA项目
    presentation.vba_project = slides.vba.VbaProject()

    # 向VBA项目添加一个空模块
    module = presentation.vba_project.modules.add_empty_module("Module")
  
    # 设置模块源代码
    module.source_code = "Sub Test(oShape As Shape) MsgBox ""Test"" End Sub"

    # 创建对<stdole>的引用
    stdoleReference = slides.vba.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # 创建对Office的引用
    officeReference =slides.vba.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # 向VBA项目添加引用
    presentation.vba_project.references.add(stdoleReference)
    presentation.vba_project.references.add(officeReference)

            
    # 保存演示文稿
    presentation.save("AddVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}} 

您可能想查看**Aspose**的[宏移除器](https://products.aspose.app/slides/remove-macros)，这是一个用于从PowerPoint、Excel和Word文档中移除宏的免费网络应用程序。 

{{% /alert %}} 

## **删除VBA宏**

使用[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类下的[VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.presentation/#properties)属性，您可以删除VBA宏。

1. 创建[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例并加载包含宏的演示文稿。
1. 访问宏模块并将其删除。
1. 保存修改后的演示文稿。

以下Python代码演示如何删除VBA宏：

```python
import aspose.slides as slides

# 加载包含宏的演示文稿
with slides.Presentation(path + "VBA.pptm") as presentation:
    # 访问Vba模块并将其删除  
    presentation.vba_project.modules.remove(presentation.vba_project.modules[0])

    # 保存演示文稿
    presentation.save("RemovedVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

## **提取VBA宏**

1. 创建[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)类的实例并加载包含宏的演示文稿。
2. 检查演示文稿是否包含VBA项目。
3. 循环遍历VBA项目中包含的所有模块以查看宏。

以下Python代码演示如何从包含宏的演示文稿中提取VBA宏：

```python
import aspose.slides as slides

with slides.Presentation(path + "VBA.pptm") as pres:
    if pres.vba_project is not None: # 检查演示文稿是否包含VBA项目
        for module in pres.vba_project.modules:
            print(module.name)
            print(module.source_code)
```