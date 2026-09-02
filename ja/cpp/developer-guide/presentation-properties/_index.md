---
title: C++ でプレゼンテーション プロパティを管理
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/cpp/presentation-properties/
keywords:
- PowerPoint プロパティ
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- 組み込みプロパティ
- カスタム プロパティ
- 詳細プロパティ
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
description: "Aspose.Slides for C++ でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **はじめに**

Aspose.Slides は 2 種類のドキュメント プロパティをサポートしています: **Built-in** と **Custom**。これらのプロパティ タイプは、Aspose.Slides API を使用して簡単に取得および管理できます。

Aspose.Slides は、[IDocumentProperties](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_document_properties) インターフェイスを介してプレゼンテーション ドキュメント プロパティを操作できるようにします。このインターフェイスのインスタンスは、[Presentation::get_DocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_documentproperties/) メソッドによって返されます。以下の例は、これらのプロパティを読み取り、変更し、管理する方法を示しています。

{{% alert color="info" title="Note" %}}
ご注意ください、**Application** および **Producer** フィールドには値を設定できません。これらのフィールドには Aspose Ltd. と Aspose.Slides for C++ x.x.x が表示されます。
{{% /alert %}} 

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint は、プレゼンテーション ファイルにいくつかのプロパティを追加する機能を提供します。これらのドキュメント プロパティにより、ドキュメント（プレゼンテーション ファイル）と共に有用な情報を保存できます。ドキュメント プロパティは次の 2 種類があります。

- システム定義 (Built-in) プロパティ
- ユーザー定義 (Custom) プロパティ

**Built-in** プロパティは、ドキュメント タイトル、作者名、ドキュメント統計情報など、ドキュメントに関する一般情報を含みます。**Custom** プロパティは、ユーザーが **Name/Value** ペアとして定義するもので、名前と値の両方がユーザーによって決定されます。Aspose.Slides for C++ を使用すると、開発者は組み込みプロパティとカスタム プロパティの値にアクセスして変更できます。Microsoft PowerPoint 2007 は、プレゼンテーション ファイルのドキュメント プロパティの管理を可能にします。操作は、Office アイコンをクリックし、さらに **Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです。**Advanced Properties** を選択すると、PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。**Properties Dialog** では、**General, Summary, Statistics, Contents and Custom** など多数のタブ ページがあることがわかります。これらすべてのタブ ページは、PowerPoint ファイルに関連するさまざまな情報の構成を可能にします。**Custom** タブは、PowerPoint ファイルのカスタム プロパティを管理するために使用されます。

## **組み込みプロパティへのアクセス**

これらのプロパティは **IDocumentProperties** オブジェクトによって公開され、**Creator(Author)**、**Description**、**KeyWords**、**Created**（作成日）、**Modified**（最終更新日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（複数のプロデューサー間で共有されていますか？）、**PresentationFormat**、**Subject**、**Title** が含まれます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **組み込みプロパティの変更**

プレゼンテーション ファイルの組み込みプロパティの変更は、取得と同じくらい簡単です。任意のプロパティに文字列値を割り当てるだけで、プロパティ値が変更されます。以下の例では、プレゼンテーション ファイルの組み込みドキュメント プロパティをどのように変更できるかを示しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **カスタム プレゼンテーション プロパティの追加**

Aspose.Slides for C++ は、開発者がプレゼンテーション ドキュメント プロパティのカスタム値を追加することも可能にします。以下の例は、プレゼンテーションにカスタム プロパティを設定する方法を示しています。

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

## **カスタム プロパティへのアクセスと変更**

Aspose.Slides for C++ は、開発者がカスタム プロパティの値にアクセスすることも可能です。以下の例は、プレゼンテーションのすべてのカスタム プロパティにアクセスし、変更する方法を示しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **校正言語の設定**

Aspose.Slides は、PowerPoint ドキュメントの校正言語を設定できるように、[LanguageId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/baseportionformat/set_languageid/) プロパティ（[PortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/portionformat/) クラスで公開）を提供します。校正言語とは、PowerPoint のスペルと文法がチェックされる言語です。

以下の C++ コードは、PowerPoint の校正言語を設定する方法を示しています。

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
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
// 校正言語の ID を設定

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **デフォルト言語の設定**

以下の C++ コードは、PowerPoint プレゼンテーション全体のデフォルト言語を設定する方法を示しています。

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// 新しいテキスト付きの長方形シェイプを追加
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// 最初のポーションの言語をチェック
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **ライブ例**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) のオンラインアプリを試して、Aspose.Slides API を介してドキュメント プロパティを操作する方法をご確認ください：

[![PowerPoint メタデータの表示と編集](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **よくある質問**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、特定のプロパティが許可している場合は、値を変更するか空に設定することができます。

**既に存在するカスタム プロパティを追加した場合、どうなりますか？**

既に存在するカスタム プロパティを追加すると、その既存の値は新しい値で上書きされます。事前にプロパティを削除したり確認したりする必要はありません。Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？**

はい。[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) を使用し、次に [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) を使用して、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取ります。完全なレポート例とフォーマット固有の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/cpp/examine-presentation/) を参照してください。