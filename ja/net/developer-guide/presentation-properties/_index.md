---
title: C#でPowerPointプレゼンテーションのプロパティを管理する
linktitle: プレゼンテーションプロパティ
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
- プロパティへのアクセス
- プロパティの変更
- プロパティの管理
- ドキュメント メタデータ
- メタデータの編集
- 校正言語
- PowerPoint
- プレゼンテーション
- C#
- Csharp
- Aspose.Slides for .NET
description: "C#でAspose.Slides for .NETを使用してPowerPointドキュメントプロパティを簡単に管理、読み取り、編集する方法を学びましょう。生産性を向上させ、ワークフローを自動化できます！"
---

## **概要**

Aspose.Slides for .NET は、**組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートしています。これらのプロパティは、Aspose.Slides for .NET API を使用して簡単にアクセスおよび管理できます。

ドキュメント プロパティを扱うために、Aspose.Slides は [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) インターフェイスを提供しており、[Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/documentproperties/) プロパティから取得できます。開発者は `Presentation` オブジェクトの [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) インターフェイスを利用して、以下の例に示すようにプレゼンテーション プロパティをシームレスに読み取り、変更、管理できます。

{{% alert color="primary" %}} 
Application と Producer のフィールドは変更できません。これらのフィールドは常に「Aspose Ltd.」および「Aspose.Slides for .NET x.x.x」と表示されます。
{{% /alert %}} 

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint には、プレゼンテーション ファイルにプロパティを追加する機能があります。これらのドキュメント プロパティにより、ファイルに有用な情報を保存できます。ドキュメント プロパティには次の 2 種類があります。

- システム定義（組み込み）プロパティ
- ユーザー定義（カスタム）プロパティ

**組み込み** プロパティは、文書タイトル、作者名、文書統計情報など、文書に関する一般的な情報を含みます。

**カスタム** プロパティは、ユーザーが **名前/値** のペアとして定義するもので、名前と値はユーザーが指定します。

Aspose.Slides for .NET を使用すると、開発者は組み込みプロパティとカスタムプロパティの両方にアクセスして変更できます。

Microsoft PowerPoint では、Office アイコンをクリックし、**ファイル → 情報 → プロパティ** を選択することでドキュメント プロパティを管理できます。**詳細プロパティ** を選ぶと、プレゼンテーション ファイルのすべてのドキュメント プロパティを管理できるダイアログが表示されます。

**プロパティ** ダイアログには **全般、概要、統計、コンテンツ、カスタム** などのタブがあります。各タブは PowerPoint ファイルに関する特定の情報の設定オプションを提供します。**カスタム** タブはユーザー定義プロパティの管理に使用されます。

## **組み込みプロパティへのアクセス**

[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) インターフェイスで公開されているこれらのプロパティには、**Creator**（作者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（変更日）、**Printed**（最終印刷日）、**LastModifiedBy**、**SharedDoc**（ドキュメントが複数のプロデューサー間で共有されているか） 、**PresentationFormat**、**Subject**、**Title** などがあります。
```cs
// プレゼンテーション ファイルを表す Presentation クラスをインスタンス化します。
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Display the Built-in properties.
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

プレゼンテーション ファイルの組み込みプロパティの変更は、アクセスと同様に簡単です。任意のプロパティに文字列値を代入すれば、そのプロパティの値が更新されます。以下の例では、プレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示します。
```cs
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

カスタム プレゼンテーション プロパティを使用すると、開発者はプレゼンテーション ファイル内に追加のメタデータや特定の情報を保存できます。Aspose.Slides は、これらのカスタム プロパティをプログラムで作成および管理する機能を提供します。以下の例は、プレゼンテーションにカスタム プロパティを追加する方法を示しています。
```cs
// Presentation クラスをインスタンス化します。
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


## **カスタムプロパティの取得と変更**

Aspose.Slides は、既存のカスタム プロパティにアクセスし、その値を簡単に変更することも可能です。この機能により、正確なメタデータを維持し、ユーザー入力やビジネス ロジックに基づく動的な更新がサポートされます。以下の例は、プレゼンテーション内のカスタム プロパティ値を取得および更新する方法を示しています。
```cs
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// Get a reference to the object of type IDocumentProperties associated with the presentation.
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

Aspose.Slides API を使用したドキュメント プロパティの操作方法を確認するには、オンライン アプリ **[View & Edit PowerPoint Metadata](https://products.aspose.app/slides/metadata)** をお試しください。

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***よくある質問**

**組み込みプロパティをプレゼンテーションから削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、許可されているプロパティであれば、値を変更したり空文字列に設定したりできます。

**既に存在するカスタムプロパティを追加した場合、どうなりますか？**

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。事前に削除やチェックを行う必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい、可能です。`PresentationFactory` クラスの [GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) メソッドを使用し、取得した `IPresentationInfo` インターフェイスの [ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/) メソッドでプロパティを効率的に読み取ることで、メモリ使用量を抑え、パフォーマンスを向上させることができます。