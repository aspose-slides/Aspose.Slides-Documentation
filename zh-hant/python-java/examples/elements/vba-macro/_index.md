---
title: VBA 巨集
type: docs
weight: 150
url: /zh-hant/python-java/examples/elements/vba-macro/
keywords:
- 程式碼範例
- VBA
- 巨集
- PowerPoint
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java，在 PowerPoint 簡報中新增、存取與移除 VBA 巨集，提供清晰實用的程式碼範例。"
---
本文示範如何使用 **Aspose.Slides for Python via Java** 新增、存取和移除 VBA 巨集。

請依照 [Installation](/slides/zh-hant/python-java/installation/) 中的說明安裝套件。每個範例會在啟動 JVM 之前匯入 `asposeslides`，然後在 JVM 執行時匯入 API。

## **新增 VBA 巨集**

建立包含 VBA 專案與簡易巨集模組的簡報。

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

## **存取 VBA 巨集**

從 VBA 專案中取得第一個模組。

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

## **移除 VBA 巨集**

從 VBA 專案中刪除模組。

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