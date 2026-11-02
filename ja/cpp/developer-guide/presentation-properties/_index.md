---
title: C++ でプレゼンテーションプロパティを管理
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
description: "Aspose.Slides for C++ でプレゼンテーションプロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **はじめに**

Aspose.Slides for C++ は **組み込み** と **カスタム** のドキュメントプロパティをサポートします。これらのプロパティを使用して、作成者、タイトル、ユーザー定義の値などのプレゼンテーションメタデータを読み取りおよび更新します。

Aspose.Slides では、[IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) インターフェイスを介してプレゼンテーションのドキュメントプロパティを操作できます。このインターフェイスのインスタンスは、[IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) によって返されます。以下の例は、これらのプロパティを読み取り、変更し、管理する方法を示しています。

{{% alert color="info" title="注意" %}}
Aspose.Slides はプレゼンテーションを保存する際にアプリケーションと製作者のメタデータを管理します。これらのフィールドは出力を作成したソフトウェアを識別します。
{{% /alert %}}

## **プレゼンテーションプロパティの管理**

ドキュメントプロパティは、プレゼンテーションコンテンツとともに記述情報を格納します。これらは 2 つのカテゴリに分かれます：

- **組み込みプロパティ** はタイトル、作成者、ドキュメント統計情報などの標準メタデータを含みます。
- **カスタムプロパティ** はユーザー定義の名前/値のペアを格納します。

Aspose.Slides for C++ は両方のカテゴリへのアクセスを提供します。PowerPoint では、**ファイル → 情報 → プロパティ → 詳細プロパティ** を選択してドキュメントメタデータを確認します。ダイアログは情報を **概要**、**統計**、**コンテンツ**、**カスタム** のタブに分けます。ユーザー定義プロパティを管理するには **カスタム** タブを使用します。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

オープンパスワードは通常、プレゼンテーションのコンテンツとドキュメントプロパティの両方を保護します。プレゼンテーションが [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) に `false` を渡すことで暗号化されると、ドキュメントプロパティは公開されたままになります。その後、アプリケーションは [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) に `true` を渡すことで、オープンパスワードを提供せずに公開メタデータを読み取れます。

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) は Aspose.Slides が読み込む対象を制御します。暗号化にプロパティが含まれている場合、パスワードなしでの読み込みは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体が読み込まれます。

この例は、ドキュメントプロパティが公開された状態で暗号化されたプレゼンテーションが必要です。読み込みモードは [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) で確認し、続いて [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) を通じて組み込みプロパティを読み取ります：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

このモードではスライドのコンテンツは読み込まれません。スライド、マスター、レイアウト、シェイプ、メディア、およびその他のプレゼンテーションオブジェクトは利用できません。完全なプレゼンテーションオブジェクトモデルを必要とする操作を行う前に、必ず [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) を確認してください。

{{% alert color="warning" title="セキュリティ" %}}
公開メタデータには作成者名、タイトル、テーマ、キーワード、会社情報、コメント、カスタム値が含まれる可能性があります。機密プロパティはプレゼンテーションと共に暗号化してください。インデックス作成、分類、検索、またはドキュメント管理システムがパスワードなしでアクセスする特別な要件がある場合にのみ公開してください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルに対し、[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) に `true` を渡して読み込んだプレゼンテーションは、公開メタデータの読み取りを目的としています。Aspose.Slides はそのメタデータのみのオブジェクトから変更されたプロパティを保存できません。公開プロパティは暗号化されたプレゼンテーション内部の対応データと一貫性を保つ必要があるため、正しいオープンパスワードで完全にロードする必要があります。

この例は、公開ドキュメントプロパティを持つ暗号化 PPTX プレゼンテーションと既知のオープンパスワードが必要です。完全なプレゼンテーションを [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) で開き、公開の組み込みプロパティを更新し、結果を保存します。その後、[IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) を使用して暗号化が保持されていることを確認し、パスワードなしで公開メタデータを再度開いて新しい値を検証します：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

アプリケーションがプレゼンテーションのコンテンツを復号またはロードできない場合、暗号化された PPTX ファイルの公開プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティへのアクセス**

[IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) インターフェイスは、[get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/)、[get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/)、[get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/) などの型付きゲッターを通じて組み込みメタデータを公開します。この例は既存のプレゼンテーションを開き、保存されたメタデータをコンソールに出力します。値は入力プレゼンテーションに依存し、いくつかのフィールドは空になることがあります。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

## **組み込みプロパティの変更**

組み込みメタデータを更新するには、[IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) で取得したオブジェクトのセッターを使用します。この例は既存のプレゼンテーションを開き、[set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/)、[set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/)、[set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/)、[set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/)、[set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/) を呼び出し、[Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) で更新されたプレゼンテーションを保存します。保存された PPTX には新しいメタデータが含まれます。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **ハイパーリンクベースの管理**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) は相対ハイパーリンクのドキュメントレベルベースを取得します。プレゼンテーションとリンクされたファイルを別の場所に移動する際に便利です。これは個々のハイパーリンクの [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) とは別で、ベースを変更しても保存されたリンクアドレスや絶対的な宛先は書き換えられません。

この例は `target.html` のような相対リンクと `https://example.org/absolute.html` のような絶対リンクの両方を含むプレゼンテーションが必要です。既存のベースを読み取り、[IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/) で新しいベースアドレスを設定し、プレゼンテーションを保存して再度開き、値を確認します。その後、`u""` でベースをクリアし、別ファイルに保存して空の値を検証します。例のベースアドレスはリンクファイルの場所に置き換えてください。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

2 つの検証メッセージは `True` と出力されるはずです。ベースをクリアしても個々のハイパーリンクアドレスはそのまま残ります。

相対リンク `target.pptx` はベースが `old` フォルダーを指しているとき `old/target.pptx` を開きました。ベースを `new` フォルダーに変更して保存し、プレゼンテーションを再度開くと同じリンクは `new/target.pptx` を開きます。絶対リンクは同じファイルを開き続けます。プレゼンテーションを移動したりベースを変更したりする前後で、PowerPoint で相対リンクをテストしてください。

## **カスタムプレゼンテーションプロパティの追加**

カスタムプロパティは組み込みフィールドに対応しないメタデータを格納します。[IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) を使用すると、プロパティ名で値を割り当てられます。この例はプレゼンテーションを作成し、テキスト値 2 件と整数のバージョン値を追加し、[Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) で保存します。既存の名前に値を割り当てると、そのプロパティの値は置き換わります。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **カスタムプロパティのアクセスと変更**

この例はカスタムプロパティを含むプレゼンテーションを開き、[get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) で総数を取得して反復処理します。[GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) は 0 ベースのインデックスを受け取り、[IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) および [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) で使用される名前を返します。例は各元の名前と値を出力し、元の型に関係なく番号付き文字列に置き換えてから変更を保存します。カスタムプロパティが存在しない場合、ループは何も変更しません。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **ライブ例**

オンラインアプリの [**PowerPoint メタデータの表示と編集**](https://products.aspose.app/slides/metadata) を試して、Aspose.Slides API を使用したドキュメントプロパティの操作方法を確認してください：

[![PowerPoint メタデータの表示と編集](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **よくある質問**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可分な部分であり、完全に削除することはできません。ただし、許可されている場合は値を変更するか、空に設定することは可能です。

**既に存在するカスタムプロパティを追加した場合、どうなりますか？**

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除したり確認したりする必要はなく、Aspose.Slides が自動的に値を更新します。

**プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？**

はい。まず [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) を使用し、次に [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメントメタデータを読み取れます。完全なレポート例とフォーマット固有の制限については、[軽量プレゼンテーション在庫の構築](/slides/ja/cpp/examine-presentation/) を参照してください。

**暗号化されたプレゼンテーションの公開プロパティをオープンパスワードなしで読み取れますか？**

はい。プレゼンテーションが [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) に `false` を渡して暗号化され、かつ [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) に `true` を渡してロードされている必要があります。

**ドキュメントプロパティのみモードで暗号化された PPTX ファイルを更新できますか？**

できません。公開プロパティと暗号化されたプロパティのデータは一貫性を保つ必要があるため、正しいオープンパスワードでプレゼンテーション全体をロードしてから更新する必要があります。