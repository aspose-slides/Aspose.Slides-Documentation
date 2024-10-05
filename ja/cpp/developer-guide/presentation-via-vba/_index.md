---
title: VBAを使用したプレゼンテーション
type: docs
weight: 250
url: /cpp/presentation-via-vba/
keywords: "マクロ, マクロ, VBA, VBAマクロ, マクロを追加, マクロを削除, VBAを追加, VBAを削除, マクロを抽出, VBAを抽出, PowerPointマクロ, PowerPointプレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "C++でPowerPointプレゼンテーションにVBAマクロを追加、削除、抽出します"
---

[Aspose.Slides.Vba](https://reference.aspose.com/slides/cpp/namespace/aspose.slides.vba/)名前空間には、マクロおよびVBAコードを操作するためのクラスとインターフェイスが含まれています。

{{% alert title="注" color="warning" %}} 

マクロを含むプレゼンテーションを異なるファイル形式（PDF、HTMLなど）に変換すると、Aspose.Slidesはすべてのマクロを無視します（マクロは結果のファイルに持ち込まれません）。

プレゼンテーションにマクロを追加したり、マクロを含むプレゼンテーションを再保存したりすると、Aspose.Slidesは単純にマクロのバイトを記録します。

Aspose.Slidesは**決して**プレゼンテーション内のマクロを実行しません。

{{% /alert %}}

## **VBAマクロを追加**

Aspose.Slidesは、VBAプロジェクト（およびプロジェクト参照）を作成し、既存のモジュールを編集するために、[VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project)クラスを提供します。[IVbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.i_vba_project/)インターフェイスを使用して、プレゼンテーションに埋め込まれたVBAを管理できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成します。
1. [VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b)コンストラクタを使用して新しいVBAプロジェクトを追加します。
1. VbaProjectにモジュールを追加します。
1. モジュールのソースコードを設定します。
1. <stdole>への参照を追加します。
1. **Microsoft Office**への参照を追加します。
1. 参照をVBAプロジェクトに関連付けます。
1. プレゼンテーションを保存します。

このC++コードは、ゼロからプレゼンテーションにVBAマクロを追加する方法を示しています：

```c++

// ドキュメントディレクトリへのパス。
const String outPath = u"../out/AddVBAMacros_out.pptm";

// プレゼンテーションクラスのインスタンスを作成
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// 新しいVBAプロジェクトを作成
presentation->set_VbaProject(MakeObject<VbaProject>());

// VBAプロジェクトに空のモジュールを追加
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// モジュールのソースコードを設定
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// <stdole>への参照を作成
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Officeへの参照を作成
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// VBAプロジェクトに参照を追加
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// プレゼンテーションを保存
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="primary" %}} 

**Aspose**の[マクロ削除ツール](https://products.aspose.app/slides/remove-macros)を確認することをお勧めします。これはPowerPoint、Excel、Wordドキュメントからマクロを削除するための無料のウェブアプリです。 

{{% /alert %}} 

## **VBAマクロを削除**

[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスの[VbaProject](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4)プロパティを使用して、VBAマクロを削除できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
1. マクロモジュールにアクセスし、それを削除します。
1. 修正されたプレゼンテーションを保存します。

このC++コードは、VBAマクロを削除する方法を示しています： 

```c++

// ドキュメントディレクトリへのパス。
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// マクロを含むプレゼンテーションを読み込む
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Vbaモジュールにアクセスして削除します
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// プレゼンテーションを保存
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **VBAマクロを抽出**

1. [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスのインスタンスを作成し、マクロを含むプレゼンテーションを読み込みます。
2. プレゼンテーションがVBAプロジェクトを含んでいるか確認します。
3. VBAプロジェクト内のすべてのモジュールをループして、マクロを表示します。

このC++コードは、マクロを含むプレゼンテーションからVBAマクロを抽出する方法を示しています： 

```c++

// ドキュメントディレクトリへのパス。
const String templatePath = u"../templates/VBA.pptm";

// マクロを含むプレゼンテーションを読み込む
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

if (pres->get_VbaProject() != NULL) // プレゼンテーションがVBAプロジェクトを含んでいるか確認
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