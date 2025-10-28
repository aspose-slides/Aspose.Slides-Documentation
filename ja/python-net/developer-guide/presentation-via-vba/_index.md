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
description: "Aspose.Slides for Python via .NET を使用して、VBAを介した PowerPoint および OpenDocument プレゼンテーションの生成と操作方法を把握し、ワークフローを効率化します。"
---

## **概要**

この記事では、PowerPoint プレゼンテーション内のマクロを操作するための Aspose.Slides for Python via .NET の主要機能を検証します。ライブラリはマクロの追加、削除、抽出のための便利なツールを提供し、プレゼンテーションの作成と変更を自動化できます。

Aspose.Slides を使用すると、次のことが可能です。

- プレゼンテーション開発の加速 – ルーティン作業の自動化により資料作成にかかる時間を短縮します。
- 柔軟性の確保 – マクロ管理により、特定のタスクやシナリオに合わせてプレゼンテーションを調整できます。
- データ統合 – 外部データ ソースとのシンプルな統合でスライド内容を最新に保ちます。
- メンテナンスの簡素化 – 集中的なマクロ管理により、変更の適用やプレゼンテーションの更新が容易になります。

この記事では、PowerPoint のマクロを効果的に扱うための Aspose.Slides の実践的な使用例も紹介します。

[aspose.slides.vba](https://reference.aspose.com/slides/python-net/aspose.slides.vba/) 名前空間は、マクロや VBA コードを操作するクラスを提供します。

{{% alert title="注" color="warning" %}}

マクロを含むプレゼンテーションを別の形式（PDF、HTML など）に変換すると、Aspose.Slides はマクロを無視します。マクロは出力ファイルに転送されません。

プレゼンテーションにマクロを追加したり、マクロを含むプレゼンテーションを再保存したりすると、Aspose.Slides はマクロ バイト列をそのまま書き込みます。

Aspose.Slides は **決して** プレゼンテーション内のマクロを実行しません。

{{% /alert %}}

## **VBA マクロの追加**

Aspose.Slides は、VBA プロジェクト（およびプロジェクト参照）を作成し、既存モジュールを編集するための [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) クラスを提供します。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. [VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/#constructors) コンストラクタを使用して新しい VBA プロジェクトを追加します。  
3. VBA プロジェクトにモジュールを追加します。  
4. モジュールのソース コードを設定します。  
5. `<stdole>` への参照を追加します。  
6. **Microsoft Office** への参照を追加します。  
7. 参照を VBA プロジェクトに関連付けます。  
8. プレゼンテーションを保存します。

以下の Python コードは、スクラッチからプレゼンテーションに VBA マクロを追加する方法を示しています。

```python
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:

    # Create a new VBA project.
    presentation.vba_project = slides.vba.VbaProject()

    # Add an empty module to the VBA project.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Set the module source code.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Create a reference to <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Create a reference to Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Add the references to the VBA project.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Save the presentation.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}

**Aspose** の無料ウェブ アプリ **[Macro Remover](https://products.aspose.app/slides/remove-macros)** を試して、PowerPoint、Excel、Word ドキュメントからマクロを削除できます。

{{% /alert %}}

## **VBA マクロの削除**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスの [vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) プロパティを使用すると、VBA マクロを削除できます。

1. マクロを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. マクロ モジュールにアクセスし、削除します。  
3. 変更されたプレゼンテーションを保存します。

以下の Python コードは、VBA マクロを削除する方法を示しています。

```python
import aspose.slides as slides

# Load the presentation that contains the macro.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Access the VBA module.
    vba_module = presentation.vba_project.modules[0]

    # Remove the VBA module.
    presentation.vba_project.modules.remove(vba_module)

    # Save the presentation.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA マクロの抽出**

[VbaProject](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) クラスの `modules` プロパティを使用すると、VBA プロジェクトのすべてのモジュールにアクセスできます。[VbaModule](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbamodule/) クラスを使って、モジュール名やコードなどのプロパティを抽出できます。

1. マクロを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. プレゼンテーションに VBA プロジェクトが含まれているか確認します。  
3. VBA プロジェクト内のすべてのモジュールをループし、マクロを表示します。

以下の Python コードは、プレゼンテーションから VBA マクロを抽出する方法を示しています。

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **VBA プロジェクトがパスワード保護されているかの確認**

[VbaProject.is_password_protected](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/is_password_protected/) プロパティを使用すると、プロジェクトのプロパティがパスワードで保護されているかどうかを判定できます。

1. マクロを含むプレゼンテーションを読み込むために、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。  
2. プレゼンテーションに [VBA プロジェクト](https://reference.aspose.com/slides/python-net/aspose.slides.vba/vbaproject/) が含まれているか確認します。  
3. パスワード保護されているかどうかを確認し、プロパティを表示します。

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Check whether the presentation contains a VBA project.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**プレゼンテーションを PPTX として保存した場合、マクロはどうなりますか？**

PPTX は VBA をサポートしていないためマクロは削除されます。マクロを保持したい場合は PPTM、PPSM、または POTM を選択してください。

**Aspose.Slides はプレゼンテーション内のマクロを実行してデータを更新できますか？**

できません。ライブラリは VBA コードを決して実行せず、実行は PowerPoint の適切なセキュリティ設定が必要です。

**VBA コードにリンクされた ActiveX コントロールの操作はサポートされていますか？**

はい。既存の [ActiveX コントロール](/slides/ja/python-net/activex/) にアクセスし、プロパティを変更したり削除したりできます。これはマクロが ActiveX と連携する場合に便利です。