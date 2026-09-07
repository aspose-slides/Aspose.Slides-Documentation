---
title: VBA 宏
type: docs
weight: 150
url: /zh/python-java/examples/elements/vba-macro/
keywords:
- 代码示例
- VBA
- 宏
- PowerPoint
- 演示文稿
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，在 PowerPoint 演示文稿中添加、访问和删除 VBA 宏，并提供清晰实用的代码示例。"
---
本文演示了如何使用 **Aspose.Slides for Python via Java** 添加、访问和删除 VBA 宏。

按照 [Installation](/slides/zh/python-java/installation/) 中的说明安装软件包。每个示例在启动 JVM 之前导入 `asposeslides`，随后在 JVM 运行后导入 API。

## **添加 VBA 宏**

创建一个包含 VBA 项目和简单宏模块的演示文稿。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')
finally:
    presentation.dispose()
```

## **访问 VBA 宏**

从 VBA 项目中检索第一个模块。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    first_module = presentation.getVbaProject().getModules().get_Item(0)
finally:
    presentation.dispose()
```

## **删除 VBA 宏**

从 VBA 项目中删除一个模块。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VbaProject

presentation = Presentation()
try:
    presentation.setVbaProject(VbaProject())

    module = presentation.getVbaProject().getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test()\n MsgBox "Hi" \nEnd Sub')

    presentation.getVbaProject().getModules().remove(module)
finally:
    presentation.dispose()
```