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
## **はじめに**

Aspose.Slides for .NET は、**組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートしています。これらのプロパティは、Aspose.Slides for .NET API を使用して簡単にアクセスおよび管理できます。

Aspose.Slides は、[IDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/) インターフェイスを介してプレゼンテーション ドキュメント プロパティを操作できます。このインターフェイスのインスタンスは、[Presentation.DocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/documentproperties/) プロパティから取得されます。以下の例では、これらのプロパティの読み取り、変更、管理方法を示します。

{{% alert color="info" %}} 
Application フィールドと Producer フィールドは変更できません。これらのフィールドは常に「Aspose Ltd.」および「Aspose.Slides for .NET x.x.x」と表示されます。
{{% /alert %}} 

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint は、プレゼンテーション ファイルにプロパティを追加する機能を提供します。このドキュメント プロパティにより、ファイルに付随する有用な情報を保存できます。ドキュメント プロパティには次の 2 種類があります。

- システム定義（組み込み）プロパティ
- ユーザー定義（カスタム）プロパティ

**組み込み** プロパティには、ドキュメント タイトル、作成者名、統計情報など、ドキュメントに関する一般的な情報が含まれます。

**カスタム** プロパティは、ユーザーが **名前/値** のペアとして定義します。名前と値の両方をユーザーが指定します。

Aspose.Slides for .NET を使用すると、開発者は組み込みプロパティとカスタムプロパティの両方にアクセスし、変更できます。

Microsoft PowerPoint では、Office アイコンをクリックし、**ファイル → 情報 → プロパティ** を選択してドキュメント プロパティを管理できます。**詳細設定** を選んだ後に表示されるダイアログで、プレゼンテーション ファイルのすべてのドキュメント プロパティを管理できます。

**プロパティ** ダイアログには、**全般**、**概要**、**統計**、**内容**、**カスタム** などのタブがあります。各タブは、PowerPoint ファイルに関連する特定の情報タイプの設定オプションを提供します。**カスタム** タブは、ユーザー定義プロパティの管理に使用されます。

## **組み込みプロパティへのアクセス**

[IDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/) インターフェイスで公開されているこれらのプロパティには、**Creator**（作者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（更新日）、**Printed**（最終印刷日）、**LastModifiedBy**、**SharedDoc**（ドキュメントが異なるプロデューサー間で共有されているかを示す）、**PresentationFormat**、**Subject**、**Title** などがあります。

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

プレゼンテーション ファイルの組み込みプロパティの変更は、アクセスと同じくらい簡単です。目的のプロパティに文字列値を代入するだけで、プロパティの値が更新されます。以下の例では、プレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示します。

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

カスタム プレゼンテーション プロパティを使用すると、開発者はプレゼンテーション ファイル内に追加のメタデータや特定情報を保存できます。Aspose.Slides は、プログラムからこれらのカスタム プロパティを簡単に作成および管理できるようにします。以下の例では、プレゼンテーションにカスタム プロパティを追加する方法を示します。

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

## **カスタムプロパティへのアクセスと変更**

Aspose.Slides では、既存のカスタム プロパティにアクセスし、値を簡単に変更することも可能です。この機能により、正確なメタデータの維持や、ユーザー入力やビジネス ロジックに基づく動的な更新がサポートされます。以下の例は、プレゼンテーション内のカスタム プロパティの取得と更新方法を示しています。

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// プレゼンテーションに関連付けられた IDocumentProperties 型オブジェクトへの参照を取得します。
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
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

[**PowerPoint メタデータの表示と編集**](https://products.aspose.app/slides/ja/metadata) オンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法を確認してください。

[![PowerPoint メタデータの表示と編集](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## ***FAQ**

### 組み込みプロパティをプレゼンテーションから削除するにはどうすればよいですか？

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、許可されているプロパティであれば、値を変更したり空文字列に設定したりすることは可能です。

### すでに存在するカスタム プロパティを追加した場合はどうなりますか？

既に存在するカスタム プロパティを追加すると、その既存の値は新しい値で上書きされます。事前にプロパティを削除したりチェックしたりする必要はなく、Aspose.Slides が自動的に値を更新します。

### プレゼンテーションを完全に読み込まずにプロパティにアクセスできますか？

はい、[PresentationFactory](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationfactory/) クラスの `GetPresentationInfo` メソッドを使用してプレゼンテーションを完全に読み込まずにプロパティにアクセスできます。その後、[IPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/) インターフェイスが提供する `ReadDocumentProperties` メソッドを利用してプロパティを効率的に読み取り、メモリ使用量を削減しパフォーマンスを向上させることができます。