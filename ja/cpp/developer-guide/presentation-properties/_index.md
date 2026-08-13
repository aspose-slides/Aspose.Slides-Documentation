---
title: C++ でプレゼンテーション プロパティを管理する
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/cpp/presentation-properties/
keywords:
- PowerPoint プロパティ
- プレゼンテーション プロパティ
- 文書プロパティ
- 組み込みプロパティ
- カスタムプロパティ
- 高度なプロパティ
- プロパティの管理
- プロパティの変更
- 文書メタデータ
- メタデータの編集
- 校正言語
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **はじめに**

Aspose.Slides は文書プロパティを 2 種類サポートしています：**組み込み** と **カスタム**。これらのプロパティタイプは、Aspose.Slides API を使用して簡単にアクセスおよび管理できます。

Aspose.Slides は、[IDocumentProperties](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_document_properties) インターフェイスを介してプレゼンテーションの文書プロパティを操作できます。このインターフェイスのインスタンスは、[Presentation::get_DocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_documentproperties/) メソッドによって返されます。以下の例は、これらのプロパティの読み取り、変更、管理方法を示しています。

{{% alert color="info" %}} 
注意: **Application** および **Producer** フィールドの値は設定できません。これらのフィールドには Aspose Ltd. と Aspose.Slides for C++ x.x.x が表示されます。
{{% /alert %}} 

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint はプレゼンテーション ファイルにプロパティを追加する機能を提供しています。これらの文書プロパティにより、ドキュメント（プレゼンテーション ファイル）と共に有用な情報を保存できます。文書プロパティは次の 2 種類があります。

- システム定義 (組み込み) プロパティ
- ユーザー定義 (カスタム) プロパティ

**組み込み** プロパティは、文書タイトル、作成者名、文書統計情報など、文書に関する一般的な情報を含みます。**カスタム** プロパティは、ユーザーが **Name/Value** のペアとして定義するもので、名前と値の両方がユーザーによって決められます。Aspose.Slides for C++ を使用すると、開発者は組み込みプロパティとカスタムプロパティの値にアクセスし、変更できます。Microsoft PowerPoint 2007 では、プレゼンテーション ファイルの文書プロパティを管理できます。操作手順は、Office アイコンをクリックし、さらに **Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです。**Advanced Properties** を選択すると、PowerPoint ファイルの文書プロパティを管理できるダイアログが表示されます。**Properties Dialog** では、**General, Summary, Statistics, Contents, Custom** など多数のタブページがあり、PowerPoint ファイルに関連するさまざまな情報を設定できます。**Custom** タブは、PowerPoint ファイルのカスタムプロパティを管理するために使用されます。

## **組み込みプロパティへのアクセス**

**IDocumentProperties** オブジェクトで公開されているプロパティは、**Creator(Author)**、**Description**、**KeyWords**、**Created**（作成日）、**Modified**（変更日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（異なるプロデューサー間で共有されているか？）、**PresentationFormat**、**Subject**、**Title** です。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **組み込みプロパティの変更**

プレゼンテーション ファイルの組み込みプロパティの変更は、アクセスと同様に簡単です。任意のプロパティに文字列値を割り当てるだけで、プロパティの値が変更されます。以下の例では、プレゼンテーション ファイルの組み込み文書プロパティをどのように変更できるかを示しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **カスタム プレゼンテーション プロパティの追加**

Aspose.Slides for C++ は、プレゼンテーションの文書プロパティにカスタム値を追加することも可能です。以下の例は、プレゼンテーションにカスタムプロパティを設定する方法を示しています。

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation クラスのインスタンスを作成
auto presentation = System::MakeObject<Presentation>();

// 文書プロパティを取得
auto documentProperties = presentation->get_DocumentProperties();

// カスタムプロパティを追加
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

Aspose.Slides for C++ は、カスタムプロパティの値にアクセスすることも可能です。以下の例は、プレゼンテーションのすべてのカスタムプロパティにアクセスし、変更する方法を示しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **校正言語の設定**

Aspose.Slides は、[LanguageId](https://reference.aspose.com/slides/ja/cpp/aspose.slides.baseportionformat/set_languageid/) プロパティ（[PortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/portionformat/) クラスで公開）を提供し、PowerPoint 文書の校正言語を設定できます。校正言語は、PowerPoint のスペルや文法がチェックされる言語です。

この C++ コードは、PowerPoint の校正言語を設定する方法を示しています。

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

## **既定言語の設定**

この C++ コードは、PowerPoint プレゼンテーション全体の既定言語を設定する方法を示しています。

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

// テキスト付きの新しい長方形シェイプを追加
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Checks the first portion language
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **ライブ例**

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) のオンライン アプリを試して、Aspose.Slides API を使用した文書プロパティの操作方法をご覧ください。

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## ***よくある質問**

### プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、特定のプロパティが許可している場合は、その値を変更するか、空に設定することができます。

### すでに存在するカスタムプロパティを追加した場合はどうなりますか？

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除したり確認したりする必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

### プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？

はい、[PresentationFactory](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentationfactory/) クラスの `GetPresentationInfo` メソッドを使用してプレゼンテーションを完全にロードせずにプロパティにアクセスできます。その後、[IPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/) インターフェイスが提供する `ReadDocumentProperties` メソッドを利用してプロパティを効率的に読み取り、メモリ使用量を削減しパフォーマンスを向上させます。