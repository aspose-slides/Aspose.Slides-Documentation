---
title: VBAによるプレゼンテーション
type: docs
weight: 250
url: /ja/net/presentation-via-vba/
keywords: "マクロ, マクロ, VBA, VBAマクロ, マクロを追加, マクロを削除, VBAを追加, VBAを削除, マクロを抽出, VBAを抽出, PowerPointマクロ, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションにVBAマクロを追加、削除、抽出する"
---

[Aspose.Slides.Vba](https://reference.aspose.com/slides/net/aspose.slides.vba/) 名前空間には、マクロとVBAコードを扱うためのクラスとインターフェイスが含まれています。

{{% alert title="注意" color="warning" %}} 

マクロを含むプレゼンテーションを別のファイル形式（PDF、HTMLなど）に変換する場合、Aspose.Slidesはすべてのマクロを無視します（マクロは生成されたファイルに持ち越されません）。

プレゼンテーションにマクロを追加したり、マクロを含むプレゼンテーションを再保存したりする場合、Aspose.Slidesは単にマクロのバイトを書き込みます。

Aspose.Slidesはプレゼンテーション内のマクロを**決して**実行しません。

{{% /alert %}}

## **VBAマクロの追加**

Aspose.Slidesは、VBAプロジェクトを作成（およびプロジェクト参照を追加）し、既存のモジュールを編集するために[VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/)クラスを提供しています。プレゼンテーションに埋め込まれたVBAを管理するために[IVbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/)インターフェイスを使用できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. [VbaProject](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/vbaproject/#constructor)コンストラクタを使用して新しいVBAプロジェクトを追加します。
1. VbaProjectにモジュールを追加します。
1. モジュールのソースコードを設定します。
1. <stdole>への参照を追加します。
1. **Microsoft Office**への参照を追加します。
1. 参照をVBAプロジェクトに関連付けます。
1. プレゼンテーションを保存します。

このC#コードは、プレゼンテーションにVBAマクロをゼロから追加する方法を示しています：

```c#
    // プレゼンテーションクラスのインスタンスを作成
using (Presentation presentation = new Presentation())
{
    // 新しいVBAプロジェクトを作成
    presentation.VbaProject = new VbaProject();

    // VBAプロジェクトに空のモジュールを追加
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // モジュールのソースコードを設定
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // <stdole>への参照を作成
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Officeへの参照を作成
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // VBAプロジェクトに参照を追加
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // プレゼンテーションを保存
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

**Aspose**の[マクロ削除ツール](https://products.aspose.app/slides/remove-macros)をチェックすることをお勧めします。これはPowerPoint、Excel、Word文書からマクロを削除するための無料Webアプリです。 

{{% /alert %}} 

## **VBAマクロの削除**
[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスの[VbaProject](https://reference.aspose.com/slides/net/aspose.slides/presentation/vbaproject/)プロパティを使用すると、VBAマクロを削除できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成し、マクロを含むプレゼンテーションをロードします。
1. マクロモジュールにアクセスし、それを削除します。
1. 修正されたプレゼンテーションを保存します。

このC#コードは、VBAマクロを削除する方法を示しています：

```c#
    // マクロを含むプレゼンテーションをロード
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Vbaモジュールにアクセスし、削除
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // プレゼンテーションを保存
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```


## **VBAマクロの抽出**
1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成し、マクロを含むプレゼンテーションをロードします。
2. プレゼンテーションにVBAプロジェクトが含まれているか確認します。
3. VBAプロジェクトに含まれるすべてのモジュールをループして、マクロを表示します。

このC#コードは、マクロを含むプレゼンテーションからVBAマクロを抽出する方法を示しています：

```c#
    // マクロを含むプレゼンテーションをロード
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // プレゼンテーションにVBAプロジェクトが含まれているか確認
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **VBAプロジェクトがパスワード保護されているか確認する**

[IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides.vba/ivbaproject/ispasswordprotected/)プロパティを使用すると、プロジェクトのプロパティがパスワード保護されているかどうかを確認できます。

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成し、マクロを含むプレゼンテーションをロードします。
2. プレゼンテーションに[VBAプロジェクト](https://reference.aspose.com/slides/net/aspose.slides.vba/vbaproject/)が含まれているか確認します。
3. プロジェクトのプロパティを表示するために、VBAプロジェクトがパスワードで保護されているか確認します。

このC#コードは、その操作を示しています：

```c#
using (Presentation pres = new Presentation("VBA.pptm"))
{
    if (pres.VbaProject == null) // プレゼンテーションにVBAプロジェクトが含まれているか確認
        return;

    if (pres.VbaProject.IsPasswordProtected)
    {
        Console.WriteLine("VBAプロジェクト '" + pres.VbaProject.Name +
                            "' はプロジェクトプロパティを表示するためにパスワードで保護されています。");
    }
}
```