---
title: C++でプレゼンテーション プロパティを管理する
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
description: "Aspose.Slides for C++ でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **はじめに**

Aspose.Slides は、**組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートしています。これらのプロパティ タイプは、Aspose.Slides API を使用して簡単にアクセスおよび管理できます。

Aspose.Slides は、[IDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/idocumentproperties/) インターフェイスを介してプレゼンテーションのドキュメント プロパティを操作できます。このインターフェイスのインスタンスは、[IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_documentproperties/) によって返されます。以下の例では、これらのプロパティの読み取り、変更、および管理方法を示します。

{{% alert color="info" title="Note" %}}
※ **Application** フィールドと **Producer** フィールドには値を設定できません。これらのフィールドには Aspose Ltd. および Aspose.Slides for C++ x.x.x が表示されますのでご注意ください。
{{% /alert %}} 

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint では、プレゼンテーション ファイルにいくつかのプロパティを追加する機能が提供されています。これらのドキュメント プロパティにより、ドキュメント（プレゼンテーション ファイル）とともに有用な情報を保存できます。ドキュメント プロパティは以下の 2 種類があります。

- システム定義 (組み込み) プロパティ
- ユーザー定義 (カスタム) プロパティ

**組み込み** プロパティは、ドキュメント タイトル、著者名、ドキュメント統計情報など、ドキュメントに関する一般的な情報を含みます。**カスタム** プロパティは、ユーザーが **Name/Value** ペアとして定義するもので、名前と値の両方がユーザーによって決められます。Aspose.Slides for C++ を使用すると、開発者は組み込みプロパティとカスタムプロパティの値にアクセスして変更できます。Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。操作は、Office アイコンをクリックし、さらに **Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです。**Advanced Properties** を選択すると、PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。**Properties Dialog** では、**General、Summary、Statistics、Contents、Custom** など多数のタブページがあることが確認できます。これらのタブは、PowerPoint ファイルに関するさまざまな情報の設定を可能にします。**Custom** タブは、PowerPoint ファイルのカスタム プロパティを管理するために使用されます。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

開くパスワードは通常、プレゼンテーションのコンテンツとドキュメント プロパティの両方を保護します。プレゼンテーションが [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) に `false` を渡して暗号化された場合、ドキュメント プロパティは公開されたままになります。その後、アプリケーションは [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) に `true` を渡すことで、開くパスワードを提供せずに公開メタデータを読み取ることができます。

`set_OnlyLoadDocumentProperties` は Aspose.Slides が読み込む内容を制御しますが、復号は行いません。プロパティが暗号化に含まれている場合、パスワードなしでの読み込みは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体が読み込まれます。

以下の例は、[IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) でロード モードを確認し、その後 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentation/get_documentproperties/) で組み込みプロパティを読み取ります。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

このモードではスライドのコンテンツは読み込まれません。スライド、マスター、レイアウト、シェイプ、メディア、およびその他のプレゼンテーション オブジェクトは利用できません。完全なプレゼンテーション オブジェクト モデルが必要な操作を行う前に、必ず `get_IsOnlyDocumentPropertiesLoaded` をチェックしてください。

{{% alert color="warning" title="Warning" %}}
公開メタデータには、作者名、タイトル、サブジェクト、キーワード、会社情報、コメント、およびカスタム値が含まれる可能性があります。機密プロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、またはドキュメント管理システムがパスワードなしでアクセスする特別な要件がある場合のみ、公開したままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、`set_OnlyLoadDocumentProperties(true)` を呼び出して読み込んだプレゼンテーションは、公開メタデータの読み取りだけを目的としています。Aspose.Slides は、そのメタデータのみオブジェクトから変更されたプロパティを保存できません。公開プロパティは暗号化されたプレゼンテーション内部のデータと一貫性を保つ必要があるため、更新には正しい開くパスワードと完全なロードが必要です。

以下の例は、[LoadOptions::set_Password](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_password/) でプレゼンテーションを開き、公開組み込みプロパティを更新して結果を保存します。その後、[IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) を使用して暗号化が保持されていることを確認し、パスワードなしで公開メタデータを再度開いて新しい値を検証します。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

アプリケーションがプレゼンテーションのコンテンツを復号またはロードできない場合、暗号化された PPTX ファイルの公開プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティへのアクセス**

これらのプロパティは **IDocumentProperties** オブジェクトによって公開され、次のものが含まれます: **Creator(Author)**、**Description**、**KeyWords**、**Created**（作成日）、**Modified**（更新日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（複数の作成者間で共有されますか？）、**PresentationFormat**、**Subject**、**Title**。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **組み込みプロパティの変更**

プレゼンテーション ファイルの組み込みプロパティの変更は、アクセスと同様に簡単です。目的のプロパティに文字列値を割り当てるだけで、プロパティの値が変更されます。以下の例では、プレゼンテーション ファイルの組み込みドキュメント プロパティをどのように変更できるかを示しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **カスタム プレゼンテーション プロパティの追加**

Aspose.Slides for C++ では、開発者がプレゼンテーションのドキュメント プロパティにカスタム値を追加することも可能です。以下の例は、プレゼンテーションのカスタム プロパティを設定する方法を示しています。

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation クラスのインスタンス化
auto presentation = System::MakeObject<Presentation>();

// ドキュメント プロパティの取得
auto documentProperties = presentation->get_DocumentProperties();

// カスタム プロパティの追加
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// 特定インデックスのプロパティ名取得
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// 選択したプロパティの削除
documentProperties->RemoveCustomProperty(getPropertyName);

// プレゼンテーションの保存
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **カスタム プロパティへのアクセスと変更**

Aspose.Slides for C++ では、開発者がカスタム プロパティの値にアクセスすることも可能です。以下の例は、プレゼンテーションのすべてのカスタム プロパティにアクセスして変更する方法を示しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **校正言語の設定**

Aspose.Slides は、[LanguageId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/baseportionformat/set_languageid/) プロパティ（[PortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/portionformat/) クラスで公開）を提供し、PowerPoint ドキュメントの校正言語を設定できるようにします。校正言語とは、PowerPoint のスペルと文法がチェックされる言語のことです。

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

// テキスト付きの新しい矩形シェイプを追加します
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// 最初の部分の言語を確認します
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **ライブ例**

オンライン アプリの [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) を試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法をご確認ください：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **FAQ**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、特定のプロパティが許可する場合は、値を変更するか空文字列に設定することができます。

**既に存在するカスタムプロパティを追加した場合はどうなりますか？**

既に存在するカスタム プロパティを追加すると、その既存の値は新しい値で上書きされます。事前にプロパティを削除したり確認したりする必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？**

はい。[IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) を使用し、続いて [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例やフォーマット固有の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/cpp/examine-presentation/) を参照してください。

**暗号化されたプレゼンテーションの公開プロパティを開くパスワードなしで読み取れますか？**

はい。プレゼンテーションが `set_EncryptDocumentProperties` に `false` を渡して暗号化され、かつ `set_OnlyLoadDocumentProperties` に `true` を渡してロードされている必要があります。

**ドキュメント プロパティのみモードで暗号化された PPTX ファイルを更新できますか？**

いいえ。公開プロパティと暗号化プロパティのデータは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには、正しい開くパスワードでプレゼンテーション全体をロードする必要があります。