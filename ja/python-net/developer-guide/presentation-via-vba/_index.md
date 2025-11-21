---
title: PythonでプレゼンテーションのVBAプロジェクトを管理する
linktitle: VBAによるプレゼンテーション
type: docs
weight: 250
url: /ja/python-net/presentation-via-vba/
keywords:
- マクロ
- VBA
- VBAマクロ
- マクロの追加
- マクロの削除
- マクロの抽出
- VBAの追加
- VBAの削除
- VBAの抽出
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、VBAでPowerPoint および OpenDocument プレゼンテーションを生成・操作し、作業フローを効率化する方法をご紹介します。"
---

## **概要**

この記事では、PowerPoint プレゼンテーション内のマクロを操作するための Aspose.Slides for Python via .NET の主要機能を検証します。ライブラリはマクロの追加、削除、抽出のための便利なツールを提供し、プレゼンテーションの作成や変更を自動化できます。

Aspose.Slides を使用すると、次のことが可能です：

- プレゼンテーション開発の高速化 — 定型作業の自動化により資料作成時間が短縮されます。
- 柔軟性の確保 — マクロを管理できることで、特定のタスクやシナリオに合わせてプレゼンテーションを調整できます。
- データ統合 — 外部データ ソースとのシンプルな統合により、スライド 内容を常に最新に保てます。
- メンテナンスの簡素化 — マクロを集中管理することで、変更の適用やプレゼンテーションの更新が容易になります。

本記事では、PowerPoint のマクロを効果的に操作するための Aspose.Slides の実用的な使用例も紹介します。

マクロや VBA コードを扱うクラスは、[aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) 名前空間にあります。

{{% alert title="Note" color="warning" %}}
プレゼンテーションにマクロが含まれている状態で別フォーマット（PDF、HTML など）に変換すると、Aspose.Slides はマクロを無視します。‑ 出力ファイルにはマクロが転送されません。

プレゼンテーションにマクロを追加するか、マクロを含むプレゼンテーションを再保存すると、Aspose.Slides はマクロ バイト列をそのまま書き込みます。

Aspose.Slides はプレゼンテーション内のマクロを **決して** 実行しません。
{{% /alert %}}

## **VBA マクロの追加**

Aspose.Slides は VBA プロジェクト（およびプロジェクト参照）を作成し、既存モジュールを編集するために [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) クラスを提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
1. [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) コンストラクタを使用して新規 VBA プロジェクトを追加します。  
1. VBA プロジェクトにモジュールを追加します。  
1. モジュールのソースコードを設定します。  
1. `<stdole>` への参照を追加します。  
1. **Microsoft Office** への参照を追加します。  
1. 参照を VBA プロジェクトに関連付けます。  
1. プレゼンテーションを保存します。

以下の Python コードは、プレゼンテーションにゼロから VBA マクロを追加する方法を示しています：
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:

    # 新しい VBA プロジェクトを作成します。
    presentation.vba_project = slides.vba.VbaProject()

    # VBA プロジェクトに空のモジュールを追加します。
    module = presentation.vba_project.modules.add_empty_module("Module")

    # モジュールのソースコードを設定します。
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # <stdole> への参照を作成します。
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Microsoft Office への参照を作成します。
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # 参照を VBA プロジェクトに追加します。
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # プレゼンテーションを保存します。
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```


{{% alert color="primary" %}}
**Aspose** の [Macro Remover](https://products.aspose.app/slides/remove-macros)（無料ウェブ アプリ）を試して、PowerPoint、Excel、Word ドキュメントからマクロを削除できます。
{{% /alert %}}

## **VBA マクロの削除**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスの [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) プロパティを使用して、VBA マクロを削除できます。

1. マクロを含むプレゼンテーションを読み込んで、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。  
1. マクロ モジュールにアクセスし、削除します。  
1. 変更後のプレゼンテーションを保存します。

以下の Python コードは、VBA マクロを削除する方法を示しています：
```python
import aspose.slides as slides

# マクロを含むプレゼンテーションを読み込む。
with slides.Presentation("VBA.pptm") as presentation:
    
    # VBA モジュールにアクセスする。
    vba_module = presentation.vba_project.modules[0]

    # VBA モジュールを削除する。
    presentation.vba_project.modules.remove(vba_module)

    # プレゼンテーションを保存する。
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```


## **VBA マクロの抽出**

[VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) クラスの `modules` プロパティを使用すると、VBA プロジェクト内のすべてのモジュールにアクセスできます。[VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) クラスを使って、モジュール名やコードなどのプロパティを抽出できます。

1. マクロを含むプレゼンテーションを読み込んで、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。  
1. プレゼンテーションに VBA プロジェクトが含まれているか確認します。  
1. VBA プロジェクト内のすべてのモジュールをループし、マクロを表示します。

以下の Python コードは、プレゼンテーションから VBA マクロを抽出する方法を示しています：
```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # プレゼンテーションに VBA プロジェクトが含まれているか確認する。
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```


## **VBA プロジェクトがパスワードで保護されているかの確認**

[VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) プロパティを使用すると、プロジェクトのプロパティがパスワードで保護されているかどうかを判断できます。

1. マクロを含むプレゼンテーションを読み込んで、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。  
1. [VBA プロジェクト](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) が存在するか確認します。  
1. VBA プロジェクトがパスワードで保護されているか確認し、そのプロパティを表示します。  
```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # プレゼンテーションに VBA プロジェクトが含まれているか確認する。
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```


## **FAQ**

**プレゼンテーションを PPTX 形式で保存した場合、マクロはどうなりますか？**

PPTX は VBA をサポートしていないため、マクロは削除されます。マクロを保持したい場合は PPTM、PPSM、または POTM を選択してください。

**Aspose.Slides はプレゼンテーション内のマクロを実行してデータを更新できますか？**

できません。ライブラリは VBA コードを決して実行せず、実行は PowerPoint の適切なセキュリティ設定がある場合に限られます。

**VBA コードにリンクされた ActiveX コントロールの操作はサポートされていますか？**

はい。既存の [ActiveX controls](/slides/ja/python-net/activex/) にアクセスし、プロパティを変更したり削除したりできます。これはマクロが ActiveX と連携するシナリオで便利です。