---
title: PythonでプレゼンテーションのVBAプロジェクトを管理
linktitle: VBAによるプレゼンテーション
type: docs
weight: 250
url: /ja/python-net/presentation-via-vba/
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
description: "Aspose.Slides for Python via .NET を使用して VBA 経由で PowerPoint および OpenDocument プレゼンテーションを生成・操作し、ワークフローを効率化する方法をご紹介します。"
---

## **概要**

本稿では、PowerPoint プレゼンテーション内のマクロを操作するための Aspose.Slides for Python via .NET の主な機能を解説します。ライブラリは、マクロの追加、削除、抽出を簡単に行えるツールを提供し、プレゼンテーションの作成や修正を自動化できます。

Aspose.Slides を使用すると、次のことが可能です。

- プレゼンテーション開発の高速化—— 定型作業の自動化により資料作成にかかる時間を短縮します。
- 柔軟性の確保—— マクロを管理できるため、特定のタスクやシナリオに合わせてプレゼンテーションをカスタマイズできます。
- データ統合—— 外部データ ソースとの簡単な統合により、スライド内容を常に最新に保てます。
- 保守性の簡素化—— 集中管理されたマクロにより、変更の適用やプレゼンテーションの更新が容易になります。

この記事では、PowerPoint のマクロを効果的に扱うための実用的なサンプルを紹介します。

[aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) 名前空間には、マクロや VBA コードを操作するクラスが用意されています。

{{% alert title="注意" color="warning" %}}
マクロを含むプレゼンテーションを別の形式（PDF、HTML など）に変換すると、Aspose.Slides はマクロを無視します。マクロは出力ファイルに転送されません。

プレゼンテーションにマクロを追加したり、マクロを含むプレゼンテーションを再保存したりすると、Aspose.Slides はマクロ バイト列をそのまま書き込みます。

Aspose.Slides はプレゼンテーション内のマクロを **決して** 実行しません。
{{% /alert %}}

## **VBA マクロの追加**

Aspose.Slides は、[VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) クラスを提供し、VBA プロジェクト（およびプロジェクト参照）の作成や既存モジュールの編集ができます。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) コンストラクタで新しい VBA プロジェクトを追加します。  
3. VBA プロジェクトにモジュールを追加します。  
4. モジュールのソースコードを設定します。  
5. `<stdole>` への参照を追加します。  
6. **Microsoft Office** への参照を追加します。  
7. 参照を VBA プロジェクトに関連付けます。  
8. プレゼンテーションを保存します。

以下の Python コードは、ゼロから VBA マクロをプレゼンテーションに追加する方法を示しています。

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
無料の Web アプリ **Aspose** [Macro Remover](https://products.aspose.app/slides/remove-macros) を使って、PowerPoint、Excel、Word ドキュメントからマクロを削除できます。
{{% /alert %}}

## **VBA マクロの削除**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスの `vba_project` プロパティを利用すれば、VBA マクロを削除できます。

1. マクロを含むプレゼンテーションを読み込んで、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。  
2. マクロ モジュールにアクセスして削除します。  
3. 変更後のプレゼンテーションを保存します。

以下の Python コードは、VBA マクロを削除する手順を示しています。

```python
import aspose.slides as slides

# マクロを含むプレゼンテーションをロードします。
with slides.Presentation("VBA.pptm") as presentation:
    
    # VBA モジュールにアクセスします。
    vba_module = presentation.vba_project.modules[0]

    # VBA モジュールを削除します。
    presentation.vba_project.modules.remove(vba_module)

    # プレゼンテーションを保存します。
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA マクロの抽出**

[VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) クラスの `modules` プロパティを使用すると、VBA プロジェクト内のすべてのモジュールにアクセスできます。[VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) クラスを利用して、モジュール名やコードなどのプロパティを取得できます。

1. マクロを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。  
2. プレゼンテーションに VBA プロジェクトが含まれているか確認します。  
3. VBA プロジェクト内のすべてのモジュールをループし、マクロを表示します。

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

## **VBA プロジェクトがパスワードで保護されているかの確認**

[VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) プロパティを使用すると、プロジェクトのプロパティがパスワードで保護されているか判定できます。

1. マクロを含むプレゼンテーションをロードし、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) のインスタンスを作成します。  
2. VBA プロジェクトが存在するか確認します。  
3. パスワード保護されているか確認し、プロパティを表示します。

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # プレゼンテーションに VBA プロジェクトが含まれているか確認します。
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**プレゼンテーションを PPTX 形式で保存するとマクロはどうなりますか？**

PPTX は VBA をサポートしないため、マクロは削除されます。マクロを残したい場合は PPTM、PPSM、または POTM を選択してください。

**Aspose.Slides はプレゼンテーション内のマクロを実行してデータを更新できますか？**

できません。ライブラリは VBA コードを実行しません。実行は PowerPoint 側の適切なセキュリティ設定が必要です。

**VBA コードにリンクされた ActiveX コントロールの操作はサポートされていますか？**

はい。既存の [ActiveX controls](/slides/ja/python-net/activex/) にアクセスし、プロパティの変更や削除が可能です。これはマクロが ActiveX と連携するシナリオで便利です。