---
title: C++ でプレゼンテーション プロパティを管理する
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/cpp/presentation-properties/
keywords:
- PowerPoint プロパティ
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- 組み込みプロパティ
- カスタムプロパティ
- 高度なプロパティ
- プロパティの管理
- プロパティの変更
- ドキュメント メタデータ
- メタデータの編集
- 校正言語
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でプレゼンテーション プロパティを完全に管理し、PowerPoint および OpenDocument ファイルの検索、ブランド化、ワークフローを効率化します。"
---

## **プレゼンテーション プロパティへのアクセス**

以前に説明したように、Aspose.Slides for C++ は **Built-in** と **Custom** の 2 種類のドキュメント プロパティをサポートしています。そのため、開発者は Aspose.Slides for C++ API を使用して両方の種類のプロパティにアクセスできます。Aspose.Slides for C++ は、プレゼンテーション ファイルに関連付けられたドキュメント プロパティを表すクラス [IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties) を提供し、[Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) メソッドで取得できます。開発者は **Presentation** オブジェクトが公開する [get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) メソッドを使用して、以下のようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

{{% alert color="primary" %}} 
**Application** および **Producer** フィールドには値を設定できません。これらのフィールドには Aspose Ltd. と Aspose.Slides for C++ x.x.x が表示されますのでご注意ください。
{{% /alert %}} 

Microsoft PowerPoint では、プレゼンテーション ファイルにプロパティを追加する機能が提供されています。これらのドキュメント プロパティにより、ドキュメント（プレゼンテーション ファイル）とともに有用な情報を保存できます。ドキュメント プロパティは次の 2 種類があります。

- システム定義（Built-in）プロパティ
- ユーザー定義（Custom）プロパティ

**Built-in** プロパティには、ドキュメント タイトル、作成者名、統計情報など、ドキュメントに関する一般的な情報が含まれます。**Custom** プロパティは、ユーザーが **Name/Value** ペアとして定義するもので、名前と値の両方がユーザーによって決定されます。Aspose.Slides for C++ を使用すると、組み込みプロパティとカスタム プロパティの値にアクセスおよび変更できます。Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。Office アイコンをクリックし、**Prepare | Properties | Advanced Properties** のメニュー項目を選択するだけです。**Advanced Properties** を選択すると、PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。**Properties Dialog** には、**General、Summary、Statistics、Contents、Custom** など多数のタブページがあり、PowerPoint ファイルに関連するさまざまな情報を構成できます。**Custom** タブは、PowerPoint ファイルのカスタム プロパティを管理するために使用されます。

## **組み込みプロパティへのアクセス**

**IDocumentProperties** オブジェクトが公開するこれらのプロパティには、**Creator(Author)**、**Description**、**KeyWords**、**Created**（作成日）、**Modified**（変更日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（異なるプロデューサー間で共有されているか？）、**PresentationFormat**、**Subject**、**Title** があります。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **組み込みプロパティの変更**

組み込みプロパティの変更は、アクセスと同じくらい簡単です。任意のプロパティに文字列値を割り当てるだけで、プロパティの値が変更されます。以下の例では、プレゼンテーション ファイルの組み込みドキュメント プロパティをどのように変更できるかを示しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **カスタム プレゼンテーション プロパティの追加**

Aspose.Slides for C++ は、プレゼンテーション ドキュメント プロパティにカスタム値を追加することも可能です。以下の例は、プレゼンテーションにカスタム プロパティを設定する方法を示しています。
``` cpp
// Presentation クラスをインスタンス化
auto presentation = System::MakeObject<Presentation>();

// ドキュメント プロパティを取得
auto documentProperties = presentation->get_DocumentProperties();

// カスタム プロパティを追加
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// 特定のインデックスのプロパティ名を取得
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// 選択したプロパティを削除
documentProperties->RemoveCustomProperty(getPropertyName);

// プレゼンテーションを保存
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```


## **カスタム プロパティの取得と変更**

Aspose.Slides for C++ は、カスタム プロパティの値にアクセスすることもできます。以下の例は、プレゼンテーションのカスタム プロパティすべてにアクセスし、変更する方法を示しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **校正言語の設定**

Aspose.Slides は、[PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) クラスが公開する [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) プロパティを使用して、PowerPoint ドキュメントの校正言語を設定できます。校正言語は、PowerPoint のスペルと文法がチェックされる対象言語です。

この C++ コードは、PowerPoint の校正言語を設定する方法を示しています。
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```


## **デフォルト言語の設定**

この C++ コードは、PowerPoint プレゼンテーション全体のデフォルト言語を設定する方法を示しています。
```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Adds a new rectangle shape with text
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Checks the first portion language
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **ライブ例**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) のオンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法をご確認ください。

[![PowerPoint メタデータの表示と編集](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***よくある質問**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、特定のプロパティが許可する場合は、その値を変更したり空に設定したりできます。

**既に存在するカスタム プロパティを追加するとどうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前に削除したりチェックしたりする必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーションを完全に読み込まずにプロパティにアクセスできますか？**

はい、[PresentationFactory](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/) クラスの `GetPresentationInfo` メソッドを使用してプレゼンテーションを完全に読み込まずにプロパティにアクセスできます。その後、[IPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/) インターフェイスが提供する `ReadDocumentProperties` メソッドを利用してプロパティを効率的に読み取り、メモリ使用量を削減しパフォーマンスを向上させます。