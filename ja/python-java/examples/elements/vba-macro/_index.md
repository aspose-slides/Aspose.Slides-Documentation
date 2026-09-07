---
title: VBA マクロ
type: docs
weight: 150
url: /ja/python-java/examples/elements/vba-macro/
keywords:
- コード例
- VBA
- マクロ
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーション内の VBA マクロを追加、アクセス、削除する方法を、明確で実用的なコード例とともに示します。"
---
この記事では、**Aspose.Slides for Python via Java** を使用して VBA マクロを追加、アクセス、削除する方法を示します。

パッケージは [Installation](/slides/ja/python-java/installation/) に記載された手順でインストールします。各例では JVM を起動する前に `asposeslides` をインポートし、JVM が実行中になったら API をインポートします。

## **VBA マクロの追加**

VBA プロジェクトとシンプルなマクロモジュールを含むプレゼンテーションを作成します。

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

## **VBA マクロへのアクセス**

VBA プロジェクトから最初のモジュールを取得します。

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

## **VBA マクロの削除**

VBA プロジェクトからモジュールを削除します。

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