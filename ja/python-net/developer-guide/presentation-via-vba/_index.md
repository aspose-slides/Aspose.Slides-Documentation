---
title: PythonでプレゼンテーションのVBAプロジェクトを管理
linktitle: VBAによるプレゼンテーション
type: docs
weight: 250
url: /ja/python-net/developer-guide/presentation-via-vba/
keywords:
- マクロ
- VBA
- VBAマクロ
- マクロを追加
- マクロを削除
- マクロを抽出
- VBAを追加
- VBAを削除
- VBAを抽出
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して VBA 経由で PowerPoint および OpenDocument のプレゼンテーションを生成・操作し、ワークフローを効率化する方法をご紹介します。"
---

## **概要**

本記事では、PowerPoint プレゼンテーション内のマクロを操作するための Aspose.Slides for Python via .NET の主な機能を検証します。ライブラリはマクロの追加、削除、抽出に便利なツールを提供し、プレゼンテーションの作成と変更を自動化できます。

Aspose.Slides を使用すると、次のことが可能です。

- プレゼンテーション開発の高速化 — ルーティン作業の自動化により資料作成に要する時間が短縮されます。
- 柔軟性の確保 — マクロ管理により、特定のタスクやシナリオに合わせてプレゼンテーションをカスタマイズできます。
- データ統合 — 外部データソースとの簡単な統合でスライド内容を常に最新に保てます。
- メンテナンスの簡素化 — 中央集権的なマクロ管理により、変更や更新が容易になります。

この記事では、PowerPoint のマクロを効果的に扱うための実用的な例も紹介します。

The [aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) namespace provides classes for working with macros and VBA code.

{{% alert title="注意" color="warning" %}}

マクロを含むプレゼンテーションを別の形式（PDF、HTML など）に変換すると、Aspose.Slides はマクロを無視します。マクロは出力ファイルに転送されません。

プレゼンテーションにマクロを追加したり、マクロを含むプレゼンテーションを再保存したりすると、Aspose.Slides はマクロバイト列をそのまま書き込みます。

Aspose.Slides はプレゼンテーション内のマクロを **決して** 実行しません。

{{% /alert %}}

## **VBAマクロの追加**

Aspose.Slides は [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) クラスを提供し、VBA プロジェクト（およびプロジェクト参照）の作成や既存モジュールの編集が可能です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) コンストラクタを使用して新しい VBA プロジェクトを追加します。
1. VBA プロジェクトにモジュールを追加します。
1. モジュールのソースコードを設定します。
1. `<stdole>` への参照を追加します。
1. **Microsoft Office** への参照を追加します。
1. 参照を VBA プロジェクトに関連付けます。
1. プレゼンテーションを保存します。

以下の Python コードは、プレゼンテーションに VBA マクロを一から追加する方法を示しています。

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

**Aspose** の無料ウェブアプリ、[Macro Remover](https://products.aspose.app/slides/remove-macros) を試して、PowerPoint、Excel、Word ドキュメントからマクロを削除できます。

{{% /alert %}}

## **VBAマクロの削除**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスの [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) プロパティを使用すると、VBA マクロを削除できます。

1. マクロを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. マクロモジュールにアクセスし、削除します。
1. 変更後のプレゼンテーションを保存します。

以下の Python コードは、VBA マクロを削除する方法を示しています。

```python
import aspose.slides as slides

# マクロを含むプレゼンテーションを読み込みます。
with slides.Presentation("VBA.pptm") as presentation:
    
    # VBA モジュールにアクセスします。
    vba_module = presentation.vba_project.modules[0]

    # VBA モジュールを削除します。
    presentation.vba_project.modules.remove(vba_module)

    # プレゼンテーションを保存します。
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBAマクロの抽出**

[VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) クラスの `modules` プロパティを使用すると、VBA プロジェクト内のすべてのモジュールにアクセスできます。[VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) クラスを使用して、モジュール名やコードなどのプロパティを抽出できます。

1. マクロを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. プレゼンテーションに VBA プロジェクトが含まれているか確認します。
1. VBA プロジェクト内のすべてのモジュールをループしてマクロを表示します。

以下の Python コードは、プレゼンテーションから VBA マクロを抽出する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # プレゼンテーションに VBA プロジェクトが含まれているか確認します。
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **VBAプロジェクトがパスワード保護されているか確認する**

[VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) プロパティを使用すると、プロジェクトのプロパティがパスワード保護されているかどうかを判定できます。

1. マクロを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. VBA プロジェクトが含まれているか確認します。
1. パスワード保護されているかチェックし、プロパティを表示します。

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # プレゼンテーションに VBA プロジェクトが含まれているか確認します。
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **よくある質問**

**プレゼンテーションを PPTX 形式で保存した場合、マクロはどうなりますか？**

PPTX は VBA をサポートしていないため、マクロは削除されます。マクロを保持したい場合は PPTM、PPSM、または POTM を選択してください。

**Aspose.Slides はプレゼンテーション内でマクロを実行してデータを更新するなどできますか？**

いいえ。ライブラリは VBA コードを実行しません。実行は PowerPoint 側で、適切なセキュリティ設定が必要です。

**VBA コードにリンクされた ActiveX コントロールの操作はサポートされていますか？**

はい。既存の [ActiveX コントロール](/slides/ja/python-net/activex/) にアクセスし、プロパティを変更したり削除したりできます。これはマクロが ActiveX と連携するシナリオで便利です。