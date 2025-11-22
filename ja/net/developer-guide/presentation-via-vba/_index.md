---
title: VBA を使用したプレゼンテーション
type: docs
weight: 250
url: /ja/net/presentation-via-vba/
keywords: "マクロ, マクロ, VBA, VBA マクロ, マクロを追加, マクロを削除, VBA を追加, VBA を削除, マクロを抽出, VBA を抽出, PowerPoint マクロ, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションの VBA マクロを追加、削除、抽出します"
---

[Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) 名前空間には、マクロと VBA コードを操作するためのクラスとインターフェイスが含まれています。

{{% alert title="Note" color="warning" %}} 
マクロを含むプレゼンテーションを別のファイル形式（PDF、HTML など）に変換すると、Aspose.Slides はすべてのマクロを無視します（マクロは結果のファイルに引き継がれません）。
プレゼンテーションにマクロを追加するか、マクロを含むプレゼンテーションを再保存すると、Aspose.Slides は単にマクロのバイトを書き込みます。
Aspose.Slides はプレゼンテーション内のマクロを **決して** 実行しません。
{{% /alert %}}

## **VBA マクロの追加**

Aspose.Slides は、VBA プロジェクト（およびプロジェクト参照）を作成し、既存のモジュールを編集できるようにするために、[VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) クラスを提供します。[IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/) インターフェイスを使用して、プレゼンテーションに埋め込まれた VBA を管理できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) コンストラクタを使用して新しい VBA プロジェクトを追加します。
3. VbaProject にモジュールを追加します。
4. モジュールのソースコードを設定します。
5. <stdole> への参照を追加します。
6. **Microsoft Office** への参照を追加します。
7. 参照を VBA プロジェクトに関連付けます。
8. プレゼンテーションを保存します。

```c#
    // プレゼンテーションクラスのインスタンスを作成します
using (Presentation presentation = new Presentation())
{
    // 新しい VBA プロジェクトを作成します
    presentation.VbaProject = new VbaProject();

    // VBA プロジェクトに空のモジュールを追加します
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // モジュールのソースコードを設定します
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // <stdole> への参照を作成します
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Office への参照を作成します
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // VBA プロジェクトに参照を追加します
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // プレゼンテーションを保存します
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


{{% alert color="primary" %}} 
**Aspose** の [Macro Remover](https://products.aspose.app/slides/remove-macros) は、PowerPoint、Excel、Word ドキュメントからマクロを削除するための無料ウェブアプリです。ご確認ください。 
{{% /alert %}} 

## **VBA マクロの削除**

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスの下にある [VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/) プロパティを使用して、VBA マクロを削除できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
2. Macro モジュールにアクセスし、削除します。
3. 変更されたプレゼンテーションを保存します。

```c#
    // マクロを含むプレゼンテーションを読み込みます
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Vba モジュールにアクセスして削除します 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // プレゼンテーションを保存します
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **VBA マクロの抽出**

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
2. プレゼンテーションに VBA プロジェクトが含まれているか確認します。
3. VBA プロジェクトに含まれるすべてのモジュールをループして、マクロを表示します。

```c#
    // マクロを含むプレゼンテーションを読み込みます
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // プレゼンテーションに VBA プロジェクトが含まれているかチェックします
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```


## **VBA プロジェクトがパスワードで保護されているか確認する**

[IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) プロパティを使用して、プロジェクトのプロパティがパスワードで保護されているかどうかを判断できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
2. プレゼンテーションに [VBA project](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/) が含まれているか確認します。
3. VBA プロジェクトがパスワードで保護されているか確認し、プロパティを表示します。

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // プレゼンテーションに VBA プロジェクトが含まれているかどうかを確認します。
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```


## **FAQ**

**プレゼンテーションを PPTX として保存した場合、マクロはどうなりますか？**

PPTX は VBA をサポートしていないため、マクロは削除されます。マクロを保持したい場合は、PPTM、PPSM、または POTM を選択してください。

**Aspose.Slides はプレゼンテーション内のマクロを実行して、たとえばデータを更新できますか？**

いいえ。ライブラリは VBA コードを実行しません。実行は適切なセキュリティ設定がされた PowerPoint 内でのみ可能です。

**VBA コードにリンクされた ActiveX コントロールの操作はサポートされていますか？**

はい、既存の [ActiveX controls](/slides/ja/net/activex/) にアクセスし、プロパティを変更したり削除したりできます。これはマクロが ActiveX と連携する場合に便利です。