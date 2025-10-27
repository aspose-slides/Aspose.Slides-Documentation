---
title: PythonでプレゼンテーションのVBAプロジェクトを管理する
linktitle: VBAによるプレゼンテーション
type: docs
weight: 250
url: /ja/python-net/presentation-via-vba/
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
description: "Aspose.Slides for Python via .NET を使用して VBA 経由で PowerPoint および OpenDocument プレゼンテーションを生成・操作し、ワークフローを効率化する方法を紹介します。"
---

## **概要**

本稿では、PowerPoint プレゼンテーションにおけるマクロ操作に関する Aspose.Slides for Python via .NET の主な機能を解説します。ライブラリはマクロの追加、削除、抽出を容易にするツールを提供し、プレゼンテーションの作成と変更を自動化できます。

Aspose.Slides を使用すると、以下が可能です。

- プレゼンテーション開発の高速化 — ルーチン作業の自動化により資料作成時間が短縮されます。
- 柔軟性の確保 — マクロ管理により、特定のタスクやシナリオに合わせたプレゼンテーションの調整が可能です。
- データ統合 — 外部データ ソースとの簡単な統合で、スライド内容を常に最新に保てます。
- メンテナンスの簡素化 — マクロを一元管理することで、変更や更新が容易になります。

本稿では、PowerPoint のマクロを効果的に扱うための実用的なサンプルも紹介します。

[aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) 名前空間には、マクロや VBA コードを操作するクラスが用意されています。

{{% alert title="注意" color="warning" %}}

マクロを含むプレゼンテーションを別の形式（PDF、HTML など）に変換すると、Aspose.Slides はマクロを無視し、出力ファイルに転送されません。

マクロをプレゼンテーションに追加したり、マクロを含むプレゼンテーションを再保存したりすると、Aspose.Slides はマクロ バイト列をそのまま書き込みます。

Aspose.Slides はプレゼンテーション内のマクロを **決して** 実行しません。

{{% /alert %}}

## **VBAマクロの追加**

Aspose.Slides は [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) クラスを提供し、VBA プロジェクト（およびプロジェクト参照）の作成や既存モジュールの編集が可能です。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) コンストラクタを使用して新しい VBA プロジェクトを追加します。  
3. VBA プロジェクトにモジュールを追加します。  
4. モジュールのソース コードを設定します。  
5. `<stdole>` への参照を追加します。  
6. **Microsoft Office** への参照を追加します。  
7. 参照を VBA プロジェクトに関連付けます。  
8. プレゼンテーションを保存します。

以下の Python コードは、ゼロから VBA マクロをプレゼンテーションに追加する方法を示しています。

```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成
with slides.Presentation() as presentation:

    # 新しい VBA プロジェクトを作成
    presentation.vba_project = slides.vba.VbaProject()

    # VBA プロジェクトに空のモジュールを追加
    module = presentation.vba_project.modules.add_empty_module("Module")

    # モジュールのソースコードを設定
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # <stdole> への参照を作成
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Microsoft Office への参照を作成
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # 参照を VBA プロジェクトに追加
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # プレゼンテーションを保存
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}

無料の Web アプリ **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) を試して、PowerPoint、Excel、Word 文書からマクロを簡単に削除できます。

{{% /alert %}}

## **VBAマクロの削除**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスの [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) プロパティを使用して、VBA マクロを削除できます。

1. プレゼンテーションとマクロを含むファイルをロードし、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。  
2. マクロ モジュールにアクセスし、削除します。  
3. 変更後のプレゼンテーションを保存します。

以下の Python コードは、VBA マクロを削除する方法を示しています。

```python
import aspose.slides as slides

# マクロを含むプレゼンテーションをロード
with slides.Presentation("VBA.pptm") as presentation:
    
    # VBA モジュールにアクセス
    vba_module = presentation.vba_project.modules[0]

    # VBA モジュールを削除
    presentation.vba_project.modules.remove(vba_module)

    # プレゼンテーションを保存
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBAマクロの抽出**

[VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) クラスの `modules` プロパティを使用すると、VBA プロジェクト内のすべてのモジュールにアクセスできます。[VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) クラスを利用して、モジュール名やコードなどのプロパティを取得できます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成し、マクロを含むプレゼンテーションをロードします。  
2. プレゼンテーションに VBA プロジェクトが含まれているか確認します。  
3. VBA プロジェクト内のすべてのモジュールをループし、マクロ内容を表示します。

以下の Python コードは、プレゼンテーションから VBA マクロを抽出する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # VBA プロジェクトが含まれているか確認
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **VBAプロジェクトがパスワードで保護されているか確認する**

[VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) プロパティを使用すると、プロジェクトのプロパティがパスワードで保護されているかどうかを判定できます。

1. プレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。  
2. プレゼンテーションに [VBA プロジェクト](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) が含まれているか確認します。  
3. VBA プロジェクトがパスワードで保護されているかチェックし、プロパティを表示します。

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # VBA プロジェクトが含まれているか確認
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**プレゼンテーションを PPTX 形式で保存するとマクロはどうなりますか？**

PPTX は VBA をサポートしていないため、マクロは削除されます。マクロを残したい場合は PPTM、PPSM、または POTM を選択してください。

**Aspose.Slides はプレゼンテーション内のマクロを実行してデータを更新できますか？**

できません。ライブラリは VBA コードを決して実行せず、実行は PowerPoint の適切なセキュリティ設定下でのみ可能です。

**VBA コードにリンクされた ActiveX コントロールの操作はサポートされていますか？**

はい。既存の [ActiveX コントロール](/slides/ja/python-net/activex/) にアクセスし、プロパティの変更や削除が可能です。マクロが ActiveX と連携するシナリオで便利です。