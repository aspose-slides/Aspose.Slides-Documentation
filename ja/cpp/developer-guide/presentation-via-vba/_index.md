---
title: C++ を使用したプレゼンテーションの VBA プロジェクトの管理
linktitle: VBA によるプレゼンテーション
type: docs
weight: 250
url: /ja/cpp/presentation-via-vba/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して VBA で PowerPoint および OpenDocument のプレゼンテーションを生成および操作し、ワークフローを効率化する方法をご紹介します。"
---


Aspose.Slides.Vba 名前空間には、マクロと VBA コードの操作に使用できるクラスとインターフェイスが含まれます。

{{% alert title="Note" color="warning" %}} 

プレゼンテーションにマクロが含まれている状態で別のファイル形式（PDF、HTML など）に変換すると、Aspose.Slides はすべてのマクロを無視します（マクロは結果ファイルに引き継がれません）。

プレゼンテーションにマクロを追加したり、マクロを含むプレゼンテーションを再保存したりすると、Aspose.Slides は単にマクロのバイト列を書き込みます。

Aspose.Slides はプレゼンテーション内のマクロを **決して** 実行しません。

{{% /alert %}}

## **VBA マクロの追加**

Aspose.Slides は、VBA プロジェクト（およびプロジェクト参照）を作成し、既存のモジュールを編集できるようにするために [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project) クラスを提供します。プレゼンテーションに埋め込まれた VBA を管理するには、[IVbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.i_vba_project/) インターフェイスを使用できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成します。
1. [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) コンストラクタを使用して新しい VBA プロジェクトを追加します。
1. VbaProject にモジュールを追加します。
1. モジュールのソースコードを設定します。
1. <stdole> への参照を追加します。
1. **Microsoft Office** への参照を追加します。
1. 参照を VBA プロジェクトに関連付けます。
1. プレゼンテーションを保存します。

この C++ コードは、プレゼンテーションに VBA マクロを最初から追加する方法を示します: 
```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/AddVBAMacros_out.pptm";

// Presentation クラスのインスタンスを作成
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// 新しい VBA プロジェクトを作成
presentation->set_VbaProject(MakeObject<VbaProject>());

// VBA プロジェクトに空のモジュールを追加
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// モジュールのソースコードを設定
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// <stdole> への参照を作成
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Office への参照を作成
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// VBA プロジェクトに参照を追加
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// プレゼンテーションを保存
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```


{{% alert color="primary" %}} 

**Aspose** の [Macro Remover](https://products.aspose.app/slides/remove-macros) を確認してください。これは PowerPoint、Excel、Word 文書からマクロを削除するための無料ウェブアプリです。

{{% /alert %}} 

## **VBA マクロの削除**

[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスの下にある [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) プロパティを使用すると、VBA マクロを削除できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成し、マクロを含むプレゼンテーションをロードします。
1. マクロモジュールにアクセスして削除します。
1. 変更したプレゼンテーションを保存します。

この C++ コードは、VBA マクロを削除する方法を示します: 
```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// マクロを含むプレゼンテーションを読み込む
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Vba モジュールにアクセスして削除する
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// プレゼンテーションを保存
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```


## **VBA マクロの抽出**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスのインスタンスを作成し、マクロを含むプレゼンテーションをロードします。
2. プレゼンテーションに VBA プロジェクトが含まれているか確認します。
3. VBA プロジェクトに含まれるすべてのモジュールをループしてマクロを表示します。

この C++ コードは、マクロを含むプレゼンテーションから VBA マクロを抽出する方法を示します: 
```c++

	// ドキュメントディレクトリへのパス。
	const String templatePath = u"../templates/VBA.pptm";

	// マクロを含むプレゼンテーションを読み込む
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // プレゼンテーションに VBA プロジェクトが含まれているか確認
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```


## **VBA プロジェクトがパスワードで保護されているか確認する**

[IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) プロパティを使用すると、プロジェクトのプロパティがパスワードで保護されているかどうかを判断できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成し、マクロを含むプレゼンテーションをロードします。
2. プレゼンテーションに [VBA project](https://reference.aspose.com/slides/cpp/aspose.slides.vba/vbaproject/) が含まれているか確認します。
3. VBA プロジェクトがパスワードで保護されているか確認し、プロパティを表示します。
```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // プレゼンテーションに VBA プロジェクトが含まれているか確認します。
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```


## **FAQ**

**プレゼンテーションを PPTX として保存した場合、マクロはどうなりますか？**

PPTX は VBA をサポートしていないため、マクロは削除されます。マクロを保持したい場合は PPTM、PPSM、または POTM を選択してください。

**Aspose.Slides はプレゼンテーション内のマクロを実行して、たとえばデータを更新できますか？**

いいえ。ライブラリは VBA コードを実行しません。実行は適切なセキュリティ設定がされた PowerPoint 内でのみ可能です。

**VBA コードにリンクされた ActiveX コントロールの操作はサポートされていますか？**

はい、既存の [ActiveX controls](/slides/ja/cpp/activex/) にアクセスし、プロパティを変更したり削除したりできます。これはマクロが ActiveX と連携する場合に便利です。