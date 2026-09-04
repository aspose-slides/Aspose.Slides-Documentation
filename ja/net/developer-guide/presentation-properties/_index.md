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
- カスタム プロパティ
- 高度なプロパティ
- プロパティの管理
- プロパティの変更
- ドキュメント メタデータ
- メタデータの編集
- 校正言語
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **概要**

Aspose.Slides for .NET は、**組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートします。これらのプロパティは、Aspose.Slides for .NET API を使用して簡単に取得および管理できます。

Aspose.Slides は、[IDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/) インターフェイスを介してプレゼンテーション ドキュメント プロパティにアクセスできます。このインターフェイスのインスタンスは、[IPresentation.DocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/documentproperties/) によって返されます。以下の例では、これらのプロパティの読み取り、変更、管理方法を示します。

{{% alert color="info" title="Note" %}}
**Application** と **Producer** フィールドは変更できません。これらのフィールドは常に「Aspose Ltd.」および「Aspose.Slides for .NET x.x.x」と表示されます。
{{% /alert %}}

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint は、プレゼンテーション ファイルにプロパティを追加する機能を提供します。これらのドキュメント プロパティにより、ファイルに付随する有用な情報を保存できます。プロパティは次の 2 種類に分類されます。

- システム定義 (組み込み) プロパティ
- ユーザー定義 (カスタム) プロパティ

**組み込み** プロパティは、ドキュメント タイトル、著者名、統計情報など、ドキュメント全般に関する情報を含みます。

**カスタム** プロパティは、ユーザーが **名前/値** のペアとして定義するもので、名前と値の両方をユーザーが指定します。

Aspose.Slides for .NET を使用すると、開発者は組み込みプロパティとカスタムプロパティの両方にアクセスし、変更できます。

Microsoft PowerPoint では、Office アイコンをクリックし、**ファイル → 情報 → プロパティ** を選択してドキュメント プロパティを管理できます。**詳細プロパティ** を選択すると、プレゼンテーション ファイルのすべてのプロパティを管理できるダイアログが表示されます。

**プロパティ** ダイアログには、**全般**、**要約**、**統計**、**内容**、**カスタム** などのタブがあります。各タブは PowerPoint ファイルに関連する特定の情報タイプの設定オプションを提供します。**カスタム** タブはユーザー定義プロパティの管理に使用されます。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

開封パスワードは通常、プレゼンテーション コンテンツとドキュメント プロパティの両方を保護します。[IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) が `false` に設定された状態で暗号化されたプレゼンテーションでは、ドキュメント プロパティは公開されたままです。アプリケーションは [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) を `true` に設定して、開封パスワードを提供せずに公開メタデータを読み取れます。

`OnlyLoadDocumentProperties` は Aspose.Slides が読み込む対象を制御するものであり、復号は行いません。プロパティが暗号化に含まれている場合、パスワードなしでの読み込みは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体が読み込まれます。

以下の例は、[IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ja/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) で読み込みモードを確認し、[IPresentation.DocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/documentproperties/) を介して組み込みプロパティを読み取ります。

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

このモードではスライド コンテンツは読み込まれません。スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは利用できません。アプリケーションは、プレゼンテーション全体のオブジェクト モデルが必要な操作を実行する前に必ず `IsOnlyDocumentPropertiesLoaded` をチェックすべきです。

{{% alert color="warning" title="Security" %}}
公開メタデータには、著者名、タイトル、サブジェクト、キーワード、会社情報、コメント、カスタム値が含まれる可能性があります。機密プロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、または文書管理システムがパスワードなしでのアクセスを特別に要求する場合にのみ、公開のままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、`OnlyLoadDocumentProperties` で読み込まれたプレゼンテーションは公開メタデータの読み取り専用です。Aspose.Slides は、そのメタデータ専用オブジェクトから変更されたプロパティを保存できません。公開プロパティは暗号化されたプレゼンテーション内の対応データと整合性を保つ必要があるため、正しい開封パスワードで完全にロードしてから更新する必要があります。

以下の例は、[LoadOptions.Password](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/password/) でプレゼンテーションを開き、公開の組み込みプロパティを更新して結果を保存します。その後、[IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/isencrypted/) を使用して暗号化が保持されていることを確認し、パスワードなしで公開メタデータを再度開いて新しい値を検証します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

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

アプリケーションがプレゼンテーション コンテンツの復号またはロードを許可されていない場合、暗号化された PPTX ファイルの公開プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティへのアクセス**

[IDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/) インターフェイスが公開するこれらのプロパティには、**Creator** (作者)、**Description**、**Keywords**、**Created** (作成日時)、**Modified** (更新日時)、**Printed** (最終印刷日時)、**LastModifiedBy**、**SharedDoc** (ドキュメントが複数のプロデューサー間で共有されているか)、**PresentationFormat**、**Subject**、**Title** などがあります。

```cs
using Aspose.Slides;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// プレゼンテーションに関連付けられた IDocumentProperties 型オブジェクトへの参照を取得します。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 組み込みプロパティを表示します。
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **組み込みプロパティの変更**

プレゼンテーション ファイルの組み込みプロパティの変更は、アクセスと同様に簡単です。任意のプロパティに文字列値を代入するだけで、プロパティの値が更新されます。以下の例では、プレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// プレゼンテーションに関連付けられた IDocumentProperties 型オブジェクトへの参照を取得します。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 組み込みプロパティを設定します。
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// プレゼンテーションをファイルに保存します。
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **カスタム プレゼンテーション プロパティの追加**

カスタム プレゼンテーション プロパティを使用すると、開発者はプレゼンテーション ファイル内に追加のメタデータや特定の情報を保存できます。Aspose.Slides は、これらのカスタム プロパティをプログラムで簡単に作成および管理できるようにします。以下の例は、プレゼンテーションにカスタム プロパティを追加する方法を示します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation();

// プレゼンテーションに関連付けられた IDocumentProperties 型オブジェクトへの参照を取得します。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// カスタム プロパティを追加します。
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// プレゼンテーションをファイルに保存します。
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **カスタム プロパティの取得と変更**

Aspose.Slides は、既存のカスタム プロパティにアクセスし、その値を簡単に変更できる機能も提供します。この機能により、正確なメタデータを維持し、ユーザー入力やビジネス ロジックに基づく動的な更新が可能になります。以下の例は、プレゼンテーション内のカスタム プロパティ値を取得および更新する方法を示します。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// プレゼンテーションに関連付けられた IDocumentProperties 型オブジェクトへの参照を取得します。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// カスタム プロパティにアクセスして変更します。
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // カスタム プロパティの名前と値を表示します。
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // カスタム プロパティの値を変更します。
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// プレゼンテーションをファイルに保存します。
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **ライブ例**

[**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/ja/metadata) のオンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法を確認してください。

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **FAQ**

**組み込みプロパティをプレゼンテーションから削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティが許可する場合は値を変更するか、空文字列に設定できます。

**既に存在するカスタム プロパティを追加した場合はどうなりますか？**

既に存在するカスタム プロパティを追加すると、その既存の値は新しい値で上書きされます。事前にプロパティを削除したりチェックしたりする必要はなく、Aspose.Slides が自動的に値を更新します。

**プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？**

はい。[PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationfactory/getpresentationinfo/) を使用し、続いて [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/readdocumentproperties/) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット別の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/net/examine-presentation/) を参照してください。

**開封パスワードなしで暗号化されたプレゼンテーションの公開プロパティを読み取れますか？**

はい。プレゼンテーションが `EncryptDocumentProperties` を `false` に設定した状態で暗号化され、`OnlyLoadDocumentProperties` を `true` にしてロードされている必要があります。

**ドキュメント プロパティのみのモードで暗号化された PPTX ファイルを更新できますか？**

いいえ。公開プロパティと暗号化されたプロパティ データは整合性を保つ必要があるため、暗号化された PPTX ファイルを更新するには正しい開封パスワードでプレゼンテーション全体をロードする必要があります。