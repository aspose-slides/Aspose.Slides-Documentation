---
title: .NET でプレゼンテーション プロパティを管理する
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/net/presentation-properties/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **概要**

Aspose.Slides for .NET は **組み込み** と **カスタム** ドキュメント プロパティをサポートしています。これらのプロパティを使用して、作成者、タイトル、ユーザー定義の値などのプレゼンテーション メタデータを読み取り、更新できます。

Aspose.Slides では、[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) インターフェイスを介してプレゼンテーション ドキュメント プロパティを操作できます。このインターフェイスのインスタンスは、[IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) によって返されます。以下の例は、これらのプロパティの読み取り、変更、管理方法を示しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides はプレゼンテーションの保存時にアプリケーションおよび作成者のメタデータを管理します。これらのフィールドは、出力を作成したソフトウェアを識別します。
{{% /alert %}}

## **プレゼンテーション プロパティの管理**

ドキュメント プロパティは、プレゼンテーション コンテンツと共に記述情報を保存します。2 つのカテゴリに分類されます。

- **組み込みプロパティ** は、タイトル、作成者、ドキュメント統計情報などの標準メタデータを含みます。
- **カスタムプロパティ** は、ユーザー定義の名前/値のペアを保存します。

Aspose.Slides for .NET は両方のカテゴリへのアクセスを提供します。PowerPoint では **ファイル → 情報 → プロパティ → 詳細プロパティ** を選択してドキュメント メタデータを確認できます。ダイアログは **概要**、**統計**、**コンテンツ**、**カスタム** などのタブに情報を分類します。**カスタム** タブを使用してユーザー定義プロパティを管理します。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

開くパスワードは通常、プレゼンテーション コンテンツとドキュメント プロパティの両方を保護します。[IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) が `false` に設定された暗号化プレゼンテーションでは、ドキュメント プロパティは公開されたままです。アプリケーションは [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) を `true` に設定して、開くパスワードを提供せずに公開メタデータを読み取れます。

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) は Aspose.Slides が読み込む内容を制御します；暗号化は行いません。プロパティが暗号化に含まれている場合、パスワードなしでの読み込みは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体が読み込まれます。

この例は、ドキュメント プロパティが公開された暗号化プレゼンテーションを必要とします。読み込みモードは [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) で確認し、[IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) を通じて組み込みプロパティを読み取ります。

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

このモードではスライド コンテンツは読み込まれません。スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは利用できません。アプリケーションは、プレゼンテーション全体のオブジェクト モデルが必要な操作を行う前に必ず [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) を確認すべきです。

{{% alert color="warning" title="Security" %}}
公開メタデータにより、作成者名、タイトル、主題、キーワード、会社情報、コメント、カスタム値が漏洩する可能性があります。機密プロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、またはドキュメント管理システムがパスワードなしでアクセスする明確な要件がある場合にのみ、公開のままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルで、[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) で読み込まれたプレゼンテーションは公開メタデータの読み取りを目的としています。Aspose.Slides はそのメタデータだけのオブジェクトから変更されたプロパティを保存できません。公開プロパティは暗号化されたプレゼンテーション内の対応データと整合性を保つ必要があるため、正しい開くパスワードで完全にロードする必要があります。

この例は、公開ドキュメント プロパティを持つ暗号化 PPTX プレゼンテーションと既知の開くパスワードを前提とします。[LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) でプレゼンテーション全体を開き、公開の組み込みプロパティを更新し、結果を保存します。その後、[IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) で暗号化が保持されていることを確認し、パスワードなしで公開メタデータを再度開いて新しい値を検証します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

アプリケーションがプレゼンテーション コンテンツの復号やロードを許可されていない場合、暗号化 PPTX ファイルの公開プロパティは読み取り専用として扱わなければなりません。

## **組み込みプロパティへのアクセス**

[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) インターフェイスは、[Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)、[Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/)、[CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/) などの型付きプロパティを通じて組み込みメタデータを公開します。この例は既存のプレゼンテーションを開き、保存されたメタデータをコンソールに出力します。値は入力プレゼンテーションに依存し、フィールドが空の場合もあります。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

## **組み込みプロパティの変更**

組み込みメタデータを更新するには、[IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) が公開する書き込み可能プロパティに値を代入します。この例は既存のプレゼンテーションを開き、[Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)、[Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/)、[Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/)、[Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/)、[Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/) を設定し、[Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) で更新されたプレゼンテーションを保存します。保存された PPTX には新しいメタデータが含まれます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **ハイパーリンク ベースの管理**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) は、相対ハイパーリンク用のドキュメント レベルのベースを保存します。プレゼンテーションとリンクされたファイルを別の場所に移動する際に便利です。これは個々のハイパーリンクの [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) とは別で、ベースを変更しても保存されたリンク アドレスや絶対先は書き換えられません。

この例は、`target.html` のような相対リンクと `https://example.org/absolute.html` のような絶対リンクの両方を含むプレゼンテーションを前提とします。既存のベースを読み取り、新しいベース アドレスを割り当て、保存して再度プレゼンテーションを開き値を確認します。続いて `string.Empty` でベースをクリアし、別ファイルで空の値を検証します。例のベース アドレスはリンクされたファイルの場所に置き換えてください。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

2 つの検証メッセージは `True` と出力されるはずです。ベースをクリアしても個々のハイパーリンク アドレスはそのまま残ります。

相対リンク `target.pptx` はベースが `old` フォルダーを指していたとき `old/target.pptx` を開きました。ベースを `new` フォルダーに変更し、保存して再度プレゼンテーションを開くと同じリンクは `new/target.pptx` を開きます。絶対リンクは同じファイルを開き続けます。プレゼンテーションを移動したりベースを変更したりする前後で、PowerPoint で相対リンクをテストしてください。

## **カスタム プレゼンテーション プロパティの追加**

カスタム プロパティは、組み込みフィールドに対応しないメタデータを保存します。[IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) を使用すると、プロパティ名で値を割り当てられます。この例はプレゼンテーションを作成し、テキスト値 2 つと整数のバージョン値を追加し、[Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) で保存します。既存の名前に値を割り当てるとそのプロパティの値は置き換えられます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **カスタム プロパティのアクセスと変更**

この例はカスタム プロパティを含むプレゼンテーションを開き、[CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) を使用して列挙します。[GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) は 0 ベースのインデックスを受け取り、[IDocumentProperties indexer](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) が使用する名前を返します。例は各元の名前と値を出力し、元の型に関係なく番号付き文字列に置き換えて変更を保存します。カスタム プロパティが存在しない場合、ループは何も変更しません。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **ライブ例**

[**PowerPoint メタデータの表示と編集**](https://products.aspose.app/slides/metadata) オンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法を確認してください。

[![PowerPoint メタデータの表示と編集](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **よくある質問**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティが許可する場合は値を変更するか、空文字列に設定できます。

**既に存在するカスタムプロパティを追加した場合はどうなりますか？**

既に存在するカスタムプロパティを追加すると、その既存の値は新しい値で上書きされます。事前にプロパティを削除したりチェックしたりする必要はありません。Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーション全体をロードせずにプロパティへアクセスできますか？**

はい。[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) を使用し、続いて [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) で [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット別の制限については [軽量プレゼンテーション インベントリの作成](/slides/ja/net/examine-presentation/) を参照してください。

**開くパスワードなしで暗号化されたプレゼンテーションの公開プロパティを読み取れますか？**

はい。プレゼンテーションが [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) を `false` に設定して暗号化されており、かつ [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) が `true` に設定されている必要があります。

**ドキュメント プロパティだけのモードで暗号化された PPTX ファイルを更新できますか？**

できません。公開プロパティと暗号化されたプロパティ データは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには正しい開くパスワードで完全にロードする必要があります。