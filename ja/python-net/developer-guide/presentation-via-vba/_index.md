---
title: Python でプレゼンテーションの VBA プロジェクトを管理する
linktitle: VBA を介したプレゼンテーション
type: docs
weight: 250
url: /ja/python-net/presentation-via-vba/
keywords:
- マクロ
- VBA
- VBA マクロ
- マクロを追加
- マクロを削除
- マクロを抽出
- VBA を追加
- VBA を削除
- VBA を抽出
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、VBA を介して PowerPoint および OpenDocument プレゼンテーションを生成および操作し、ワークフローを効率化する方法をご紹介します。"
---

[Aspose.Slides.Vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/)名前空間には、マクロやVBAコードを操作するためのクラスとインターフェイスが含まれています。

{{% alert title="注意" color="warning" %}} 

マクロを含むプレゼンテーションを別のファイル形式（PDF、HTMLなど）に変換すると、Aspose.Slidesはすべてのマクロを無視します（マクロは生成されたファイルに持ち込まれません）。

プレゼンテーションにマクロを追加する場合や、マクロを含むプレゼンテーションを再保存する場合、Aspose.Slidesはマクロのバイトをそのまま書き込みます。

Aspose.Slidesはプレゼンテーション内のマクロを**決して**実行しません。

{{% /alert %}}

## **VBAマクロの追加**

Aspose.Slidesは、VBAプロジェクト（およびプロジェクト参照）を作成し、既存のモジュールを編集するために[VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/)クラスを提供します。[IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/)インターフェイスを使用して、プレゼンテーションに埋め込まれたVBAを管理できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors)コンストラクタを使用して新しいVBAプロジェクトを追加します。
1. VbaProjectにモジュールを追加します。
1. モジュールのソースコードを設定します。
1. <stdole>への参照を追加します。
1. **Microsoft Office**への参照を追加します。
1. 参照をVBAプロジェクトに関連付けます。
1. プレゼンテーションを保存します。

このPythonコードは、ゼロからプレゼンテーションにVBAマクロを追加する方法を示しています：

```python
import aspose.slides as slides

# プレゼンテーションクラスのインスタンスを作成します
with slides.Presentation() as presentation:
    # 新しいVBAプロジェクトを作成します
    presentation.vba_project = slides.vba.VbaProject()

    # VBAプロジェクトに空のモジュールを追加します
    module = presentation.vba_project.modules.add_empty_module("Module")
  
    # モジュールのソースコードを設定します
    module.source_code = "Sub Test(oShape As Shape) MsgBox ""Test"" End Sub"

    # <stdole>への参照を作成します
    stdoleReference = slides.vba.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Officeへの参照を作成します
    officeReference =slides.vba.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # VBAプロジェクトに参照を追加します
    presentation.vba_project.references.add(stdoleReference)
    presentation.vba_project.references.add(officeReference)

            
    # プレゼンテーションを保存します
    presentation.save("AddVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}} 

**Aspose**の[マクロ削除ツール](https://products.aspose.app/slides/remove-macros)も確認することをお勧めします。これは、PowerPoint、Excel、Word文書からマクロを削除するための無料のWebアプリです。 

{{% /alert %}} 

## **VBAマクロの削除**

[VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/#properties)プロパティを使用すると、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスからVBAマクロを削除できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
1. マクロモジュールにアクセスし、削除します。
1. 修正されたプレゼンテーションを保存します。

このPythonコードは、VBAマクロを削除する方法を示しています：

```python
import aspose.slides as slides

# マクロを含むプレゼンテーションを読み込みます
with slides.Presentation(path + "VBA.pptm") as presentation:
    # Vbaモジュールにアクセスし、削除します  
    presentation.vba_project.modules.remove(presentation.vba_project.modules[0])

    # プレゼンテーションを保存します
    presentation.save("RemovedVBAMacros_out.pptm", slides.export.SaveFormat.PPTM)
```

## **VBAマクロの抽出**

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
2. プレゼンテーションにVBAプロジェクトが含まれているか確認します。
3. VBAプロジェクト内のすべてのモジュールをループして、マクロを表示します。

このPythonコードは、マクロを含むプレゼンテーションからVBAマクロを抽出する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation(path + "VBA.pptm") as pres:
    if pres.vba_project is not None: # プレゼンテーションにVBAプロジェクトが含まれているか確認します
        for module in pres.vba_project.modules:
            print(module.name)
            print(module.source_code)
```