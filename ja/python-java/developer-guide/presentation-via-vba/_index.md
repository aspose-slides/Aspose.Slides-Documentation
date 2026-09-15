---
title: Python を使用したプレゼンテーションでの VBA プロジェクトの管理
linktitle: VBA を使用したプレゼンテーション
type: docs
weight: 250
url: /ja/python-java/presentation-via-vba/
keywords:
- マクロ
- VBA
- VBA マクロ
- マクロの追加
- マクロの削除
- マクロの抽出
- VBA の追加
- VBA の削除
- VBA の抽出
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して VBA 経由で PowerPoint および OpenDocument プレゼンテーションを生成および操作し、作業フローを効率化する方法を学びましょう。"
---
## **はじめに**

Aspose.Slides は、マクロおよび VBA コードを操作するためのクラスとインターフェイスを提供します。

{{% alert title="Warning" color="warning" %}} 

マクロを含むプレゼンテーションを別のファイル形式 (PDF、HTML など) に変換すると、Aspose.Slides はすべてのマクロを無視します (マクロは結果のファイルに引き継がれません)。

プレゼンテーションにマクロを追加したり、マクロを含むプレゼンテーションを再保存したりすると、Aspose.Slides は単にマクロのバイト列を書き込むだけです。

Aspose.Slides はプレゼンテーション内のマクロを **決して** 実行しません。

{{% /alert %}}

## **VBA マクロの追加**

Aspose.Slides は、VBA プロジェクト (およびプロジェクト参照) を作成し、既存のモジュールを編集できるようにするために、[VbaProject](https://reference.aspose.com/slides/ja/python-java/aspose.slides/vbaproject/) クラスを提供します。プレゼンテーションに埋め込まれた VBA を管理するには、[VbaProject](https://reference.aspose.com/slides/ja/python-java/aspose.slides/vbaproject/) クラスを使用できます。

1. [Presentation] クラスのインスタンスを作成します。
1. [VbaProject] コンストラクタを使用して新しい VBA プロジェクトを追加します。
1. VBA プロジェクトにモジュールを追加します。
1. モジュールのソースコードを設定します。
1. `stdole` への参照を追加します。
1. **Microsoft Office** への参照を追加します。
1. 参照を VBA プロジェクトに関連付けます。
1. プレゼンテーションを保存します。

この Python コードは、プレゼンテーションに VBA マクロをゼロから追加する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # 新しい VBA プロジェクトを作成します。
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # 空のモジュールを追加し、ソースコードを設定します。
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # stdole と Microsoft Office の参照を作成します。
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # VBA プロジェクトに参照を追加します。
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # プレゼンテーションを保存します。
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

無料のウェブアプリである **Aspose** の [Macro Remover](https://products.aspose.app/slides/ja/remove-macros) をご利用いただくと、PowerPoint、Excel、Word ドキュメントからマクロを削除できます。 

{{% /alert %}} 

## **VBA マクロの削除**

[Presentation] クラスの [getVbaProject](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getvbaproject) メソッドを使用すると、VBA マクロを削除できます。

1. [Presentation] クラスのインスタンスを作成し、マクロを含むプレゼンテーションをロードします。
1. マクロモジュールにアクセスしてそれを削除します。
1. 変更済みのプレゼンテーションを保存します。

この Python コードは、VBA マクロを削除する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# マクロを含むプレゼンテーションをロードします。
presentation = Presentation("VBA.pptm")
try:
    # VBA モジュールにアクセスして削除します。
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # プレゼンテーションを保存します。
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **VBA マクロの抽出**

1. [Presentation] クラスのインスタンスを作成し、マクロを含むプレゼンテーションをロードします。
2. プレゼンテーションに VBA プロジェクトが含まれているか確認します。
3. VBA プロジェクトに含まれるすべてのモジュールをループしてマクロを表示します。

この Python コードは、マクロを含むプレゼンテーションから VBA マクロを抽出する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# マクロを含むプレゼンテーションをロードします。
presentation = Presentation("VBA.pptm")
try:
    # プレゼンテーションに VBA プロジェクトが含まれているか確認します。
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **VBA プロジェクトがパスワードで保護されているかどうかの確認**

[VbaProject.isPasswordProtected](https://reference.aspose.com/slides/ja/python-java/aspose.slides/vbaproject/#ispasswordprotected) メソッドを使用すると、プロジェクトのプロパティがパスワードで保護されているかどうかを判断できます。

1. [Presentation] クラスのインスタンスを作成し、マクロを含むプレゼンテーションをロードします。
2. プレゼンテーションに [VBA project](https://reference.aspose.com/slides/ja/python-java/aspose.slides/vbaproject/) が含まれているか確認します。
3. VBA プロジェクトがパスワードで保護されているか確認し、プロパティを表示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # プレゼンテーションに VBA プロジェクトが含まれているか確認します。
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **よくある質問**

**プレゼンテーションを PPTX 形式で保存した場合、マクロはどうなりますか？**

PPTX は VBA をサポートしていないため、マクロは削除されます。マクロを保持したい場合は、PPTM、PPSM、または POTM を選択してください。

**たとえばデータを更新するなど、プレゼンテーション内のマクロを Aspose.Slides が実行できますか？**

いいえ。ライブラリは VBA コードを実行しません。実行は適切なセキュリティ設定がされた PowerPoint 内でのみ可能です。

**VBA コードにリンクされた ActiveX コントロールの操作はサポートされていますか？**

はい、既存の [ActiveX controls](/slides/ja/python-java/activex/) にアクセスし、プロパティを変更したり削除したりできます。マクロが ActiveX と連携する際に便利です。