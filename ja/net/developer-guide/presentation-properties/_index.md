---
title: ".NET でプレゼンテーション プロパティを管理する"
linktitle: "プレゼンテーション プロパティ"
type: docs
weight: 70
url: /ja/net/presentation-properties/
keywords:
- "PowerPoint プロパティ"
- "プレゼンテーション プロパティ"
- "ドキュメント プロパティ"
- "組み込みプロパティ"
- "カスタムプロパティ"
- "詳細プロパティ"
- "プロパティの管理"
- "プロパティの変更"
- "ドキュメント メタデータ"
- "メタデータの編集"
- "校正言語"
- "デフォルト言語"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **イントロダクション**

Aspose.Slides for .NET は **組み込み** と **カスタム** のドキュメント プロパティをサポートしています。これらのプロパティを使用して、作成者、タイトル、ユーザー定義の値など、プレゼンテーションのメタデータを読み取り、更新できます。

Aspose.Slides は、[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) インターフェイスを通じてプレゼンテーションのドキュメント プロパティを操作できます。このインターフェイスのインスタンスは、[IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) によって返されます。以下の例は、これらのプロパティを読み取り、変更し、管理する方法を示しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides はプレゼンテーションを保存する際にアプリケーションおよびプロデューサーのメタデータを管理します。これらのフィールドは、出力を作成したソフトウェアを特定します。
{{% /alert %}}

## **プレゼンテーション プロパティの管理**

ドキュメント プロパティは、プレゼンテーション コンテンツとともに記述情報を保存します。これらは 2 つのカテゴリに分類されます：

- **組み込みプロパティ** は、タイトル、作成者、ドキュメント統計などの標準メタデータを含みます。
- **カスタムプロパティ** は、ユーザー定義の名前/値のペアを格納します。

Aspose.Slides for .NET は両方のカテゴリへのアクセスを提供します。PowerPoint では、**ファイル → 情報 → プロパティ → 詳細プロパティ** を選択してドキュメント メタデータを確認します。ダイアログは情報を **概要**、**統計**、**コンテンツ**、**カスタム** などのタブにグループ化します。**カスタム** タブを使用してユーザー定義のプロパティを管理します。

## **暗号化されたプレゼンテーションからパブリック プロパティを読み取る**

オープン パスワードは通常、プレゼンテーション コンテンツとドキュメント プロパティの両方を保護します。プレゼンテーションが [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) を `false` に設定して暗号化されている場合、ドキュメント プロパティはパブリックのままです。アプリケーションはその後、[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) を `true` に設定し、オープン パスワードを提供せずにパブリック メタデータを読み取ることができます。

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) は Aspose.Slides がロードするものを制御します。暗号化は行われません。プロパティが暗号化に含まれている場合、パスワードなしでのロードは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体がロードされます。

この例は、ドキュメント プロパティがパブリックのままにされた暗号化プレゼンテーションを必要とします。[IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) でロード モードを確認し、次に [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) を通じて組み込みプロパティを読み取ります：

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

このモードでは、スライド コンテンツはロードされません。スライド、マスタ、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは利用できません。アプリケーションは、プレゼンテーション全体のオブジェクト モデルを必要とする操作を行う前に、必ず [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) を確認すべきです。

{{% alert color="warning" title="Security" %}}
パブリック メタデータは、作成者名、タイトル、テーマ、キーワード、会社情報、コメント、カスタム値を公開する可能性があります。機密性の高いプロパティはプレゼンテーションと共に暗号化してください。インデックス作成、分類、検索、またはドキュメント管理システムがパスワードなしでアクセスする特定の要件を持つ場合にのみ、パブリックのままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) でロードされたプレゼンテーションはパブリック メタデータの読み取りを目的としています。Aspose.Slides は、そのメタデータのみのオブジェクトから変更されたプロパティを保存できません。パブリック プロパティは暗号化されたプレゼンテーション内部の対応データと一貫性を保つ必要があるため、更新には正しいオープン パスワードと完全なロードが必要です。

この例は、パブリックなドキュメント プロパティを持つ暗号化 PPTX プレゼンテーションと既知のオープン パスワードを必要とします。[LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) を使用してプレゼンテーション全体を開き、パブリックな組み込みプロパティを更新して結果を保存します。その後、[IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) を使用して暗号化が維持されていることを確認し、パスワードなしでパブリック メタデータを再度開いて新しい値を検証します：

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

アプリケーションがプレゼンテーション コンテンツの復号またはロードを許可されていない場合、暗号化された PPTX ファイルのパブリック プロパティは読み取り専用として扱わなければなりません。

## **組み込みプロパティへのアクセス**

[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) インターフェイスは、[Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)、[Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/)、[CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/) などの型付きプロパティを通じて組み込みメタデータを公開します。この例は既存のプレゼンテーションを開き、保存されたメタデータをコンソールに出力します。値は入力プレゼンテーションに依存し、いくつかのフィールドは空の場合があります。

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

### **リビジョン番号と編集時間のレポート**

`presentations` フォルダー内の各 PPTX ファイルについて 1 行のレポートを作成するには、[ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) を呼び出してスライドを編集用にロードせずにその [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) を取得します。`TimeSpan` の標準 `c` 形式は、期間が 24 時間に達したときに日数を含みます。

```csharp
using System;
using System.IO;
using Aspose.Slides;

Console.WriteLine("File | RevisionNumber | TotalEditingTime");
foreach (var path in Directory.EnumerateFiles("presentations", "*.pptx"))
{
    var info = PresentationFactory.Instance.GetPresentationInfo(path);
    var properties = info.ReadDocumentProperties();
    Console.WriteLine($"{Path.GetFileName(path)} | {properties.RevisionNumber} | {properties.TotalEditingTime:c}");
}
```

記録された編集時間が 1 日 2 時間 5 分のプレゼンテーションのサンプル出力は次のとおりです：

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[RevisionNumber](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/revisionnumber/) は書き込み可能なメタデータです。その値だけではプレゼンテーションが保存された回数やバージョン履歴を特定することはできません。

[TotalEditingTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/totaleditingtime/) はファイルに記録された編集時間です。`00:00:00` の値は保存された期間がゼロであることを意味します。これがプレゼンテーションが誰も編集していないことを証明するわけではありません。

## **組み込みプロパティの変更**

組み込みメタデータを更新するには、[IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) が公開する書き込み可能プロパティに値を割り当てます。この例は既存のプレゼンテーションを開き、[Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/)、[Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/)、[Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/)、[Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/)、[Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/) を設定し、[Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) で更新されたプレゼンテーションを保存します。保存された PPTX には新しいメタデータが含まれます。

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

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) は相対ハイパーリンク用のドキュメント レベルのベースを保存します。プレゼンテーションとリンクされたファイルを別の場所に移動する際に便利です。個々のハイパーリンクの [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) とは別で、ベースを変更しても保存されたリンク アドレスは書き換えられず、絶対的な宛先も変更されません。

この例は、相対リンク（例: `target.html`）と絶対リンク（例: `https://example.org/absolute.html`）の両方を含むプレゼンテーションを必要とします。既存のベースを読み取り、新しいベース アドレスを割り当て、プレゼンテーションを保存して再度開き、値を確認します。その後、`string.Empty` でベースをクリアし、別の保存ファイルで空の値を検証します。例のベース アドレスは、リンクされたファイルの場所に置き換えてください。

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

`target.pptx` への相対リンクは、ベースが `old` フォルダーを指しているときは `old/target.pptx` を開きました。ベースを `new` フォルダーに変更し、保存してプレゼンテーションを再度開くと、同じリンクは `new/target.pptx` を開きます。絶対リンクは同じファイルを開き続けます。プレゼンテーションを移動したりベースを変更したりする前後で、PowerPoint で相対リンクをテストしてください。

## **カスタム プレゼンテーション プロパティの追加**

カスタム プロパティは、組み込みフィールドに対応しないメタデータを保存します。[IDocumentProperties インデクサー](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) を使用すると、プロパティ名で値を割り当てることができます。この例はプレゼンテーションを作成し、2 つのテキスト値と整数のバージョン値を追加し、[Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) でプレゼンテーションを保存します。既存の名前に値を割り当てると、そのプロパティの値が置き換えられます。

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

## **カスタム プロパティへのアクセスと変更**

この例はカスタム プロパティを含むプレゼンテーションを開き、[CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) を使用してそれらを列挙します。[GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) はゼロベースのインデックスを受け取り、[IDocumentProperties インデクサー](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) が使用する名前を返します。例は各元の名前と値を出力し、元の型に関係なくすべての値を番号付き文字列に置き換えて変更を保存します。カスタム プロパティがない場合、ループは何も変更しません。

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

オンライン アプリの [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) を試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法をご確認ください：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティの値を変更するか、該当プロパティが許可する場合は空に設定することは可能です。

**既に存在するカスタム プロパティを追加するとどうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。プロパティを事前に削除したり確認したりする必要はありません。Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？**

はい。[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) を使用し、続いて [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット固有の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/net/examine-presentation/) を参照してください。

**暗号化されたプレゼンテーションのパブリック プロパティをオープン パスワードなしで読み取れますか？**

はい。プレゼンテーションは [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) を `false` に設定して暗号化されており、さらに [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) を `true` に設定してロードされている必要があります。

**ドキュメント プロパティのみのモードで暗号化された PPTX ファイルを更新できますか？**

いいえ。パブリック プロパティと暗号化されたプロパティのデータは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには、正しいオープン パスワードでプレゼンテーション全体をロードする必要があります。