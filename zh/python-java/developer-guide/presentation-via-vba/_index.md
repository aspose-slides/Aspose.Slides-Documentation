---
title: 使用 Python 在演示文稿中管理 VBA 项目
linktitle: 通过 VBA 的演示文稿
type: docs
weight: 250
url: /zh/python-java/presentation-via-vba/
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
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 通过 VBA 生成和操作 PowerPoint 与 OpenDocument 演示文稿，以简化工作流程。"
---
## **介绍**

Aspose.Slides 提供用于处理宏和 VBA 代码的类和接口。

{{% alert title="警告" color="warning" %}} 

当您将包含宏的演示文稿转换为其他文件格式（PDF、HTML 等）时，Aspose.Slides 会忽略所有宏（宏不会携带到生成的文件中）。

当您向演示文稿添加宏或重新保存包含宏的演示文稿时，Aspose.Slides 仅写入宏的字节。

Aspose.Slides **永不**运行演示文稿中的宏。

{{% /alert %}}

## **添加 VBA 宏**

Aspose.Slides 提供 [VbaProject](https://reference.aspose.com/slides/zh/python-java/aspose.slides/vbaproject/) 类，以便您创建 VBA 项目（及项目引用）并编辑现有模块。您可以使用 [VbaProject](https://reference.aspose.com/slides/zh/python-java/aspose.slides/vbaproject/) 类来管理嵌入在演示文稿中的 VBA。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例。  
1. 使用 [VbaProject](https://reference.aspose.com/slides/zh/python-java/aspose.slides/vbaproject/#vbaproject) 构造函数添加新 VBA 项目。  
1. 向 VBA 项目添加模块。  
1. 设置模块源代码。  
1. 添加对 `stdole` 的引用。  
1. 添加对 **Microsoft Office** 的引用。  
1. 将引用关联到 VBA 项目。  
1. 保存演示文稿。

以下 Python 代码展示了如何从头向演示文稿添加 VBA 宏：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # 创建一个新的 VBA 项目。
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # 添加一个空模块并设置其源代码。
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # 创建对 stdole 和 Microsoft Office 的引用。
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # 向 VBA 项目添加引用。
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # 保存演示文稿。
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="注意" %}} 

您可以试用 **Aspose** [宏移除工具](https://products.aspose.app/slides/zh/remove-macros)，这是一款免费网页版应用，用于从 PowerPoint、Excel 和 Word 文档中移除宏。

{{% /alert %}} 

## **删除 VBA 宏**

通过 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的 [getVbaProject](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getvbaproject) 方法，您可以删除 VBA 宏。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。  
1. 访问宏模块并将其删除。  
1. 保存修改后的演示文稿。

以下 Python 代码展示了如何删除 VBA 宏：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 加载包含宏的演示文稿。
presentation = Presentation("VBA.pptm")
try:
    # 访问 VBA 模块并将其删除。
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # 保存演示文稿。
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **提取 VBA 宏**

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。  
2. 检查演示文稿是否包含 VBA 项目。  
3. 遍历 VBA 项目中包含的所有模块以查看宏。

以下 Python 代码展示了如何从包含宏的演示文稿中提取 VBA 宏：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# 加载包含宏的演示文稿。
presentation = Presentation("VBA.pptm")
try:
    # 检查演示文稿是否包含 VBA 项目。
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **检查 VBA 项目是否受密码保护**

使用 [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/zh/python-java/aspose.slides/vbaproject/#ispasswordprotected) 方法，您可以确定项目属性是否受密码保护。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/) 类的实例并加载包含宏的演示文稿。  
2. 检查演示文稿是否包含 [VBA 项目](https://reference.aspose.com/slides/zh/python-java/aspose.slides/vbaproject/)。  
3. 检查 VBA 项目是否受密码保护以查看其属性。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # 检查演示文稿是否包含 VBA 项目。
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **常见问题**

**如果我将演示文稿保存为 PPTX，会发生什么？**

宏会被移除，因为 PPTX 不支持 VBA。若要保留宏，请选择 PPTM、PPSM 或 POTM。

**Aspose.Slides 能运行演示文稿中的宏，例如刷新数据吗？**

不能。库从不执行 VBA 代码；只有在 PowerPoint 中且具备相应安全设置时才可能执行。

**是否支持使用与 VBA 代码关联的 ActiveX 控件？**

是的，您可以访问现有的 [ActiveX 控件](/slides/zh/python-java/activex/)，修改其属性并将其移除。这在宏与 ActiveX 交互时非常有用。