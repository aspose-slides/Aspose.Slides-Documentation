---
title: VbaMacro
type: docs
weight: 150
url: /ja/python-net/examples/elements/vba-macro/
keywords:
- VBA マクロ
- VBA マクロの追加
- VBA マクロへのアクセス
- VBA マクロの削除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で VBA マクロを操作します。プロジェクトやモジュールの追加または編集、マクロへの署名または削除、そして PPT、PPTX、ODP 形式でプレゼンテーションを保存できます。"
---
**Aspose.Slides for Python via .NET** を使用して VBA マクロを追加、アクセス、削除する方法を示します。

## **VBA マクロの追加**

VBA プロジェクトとシンプルなマクロ モジュールを含むプレゼンテーションを作成します。

```py
def add_vba_macro():
    with slides.Presentation() as presentation:
        # VBA プロジェクトを初期化します。
        presentation.vba_project = slides.vba.VbaProject()

        # "Module" という名前の空のモジュールを追加します。
        module = presentation.vba_project.modules.add_empty_module("Module")
        module.source_code = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub"

        presentation.save("vba_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA マクロへのアクセス**

VBA プロジェクトから最初のモジュールを取得します。

```py
def access_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:
        first_module = presentation.vba_project.modules[0]
```

## **VBA マクロの削除**

VBA プロジェクトからモジュールを削除します。

```py
def remove_vba_macro():
    with slides.Presentation("vba_macro.pptm") as presentation:

        # プレゼンテーションに VBA プロジェクトが含まれ、少なくとも 1 つのモジュールがあると仮定します。
        module = presentation.vba_project.modules[0]

        # プロジェクトからモジュールを削除します。
        presentation.vba_project.modules.remove(module)

        presentation.save("vba_macro_removed.pptx", slides.export.SaveFormat.PPTX)
```