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
## **はじめに**

Aspose.Slides for .NET は、**組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートしています。これらのプロパティは、Aspose.Slides for .NET API を使用して簡単に取得および管理できます。

Aspose.Slides は、[IDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/) インターフェイスを介してプレゼンテーション ドキュメント プロパティにアクセスできます。このインターフェイスのインスタンスは、[Presentation.DocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/documentproperties/) プロパティから取得されます。以下の例では、これらのプロパティの読み取り、変更、管理方法を示します。

{{% alert color="info" title="注意" %}}
Application および Producer フィールドは変更できません。これらのフィールドは常に「Aspose Ltd.」および「Aspose.Slides for .NET x.x.x」と表示されます。
{{% /alert %}}

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint には、プレゼンテーション ファイルにプロパティを追加する機能があります。これらのドキュメント プロパティにより、ファイルと一緒に有用な情報を保存できます。プロパティの種類は次のとおりです。

- システム定義（組み込み）プロパティ
- ユーザー定義（カスタム）プロパティ

**組み込み** プロパティは、文書タイトル、作成者名、文書統計情報など、文書に関する一般的な情報を含みます。

**カスタム** プロパティは、ユーザーが **名前/値** のペアとして定義します。名前も値もユーザーが指定します。

Aspose.Slides for .NET を使用すると、開発者は組み込みプロパティとカスタムプロパティの両方にアクセスして変更できます。

Microsoft PowerPoint では、Office アイコンをクリックし、**ファイル → 情報 → プロパティ** を選択してドキュメント プロパティを管理できます。**詳細プロパティ** を選ぶと、プレゼンテーション ファイルのすべてのプロパティを管理できるダイアログが表示されます。

**プロパティ** ダイアログには、**全般**、**要約**、**統計**、**内容**、**カスタム** などのタブがあります。各タブは PowerPoint ファイルに関連する特定の情報タイプの設定オプションを提供します。**カスタム** タブは、ユーザー定義プロパティの管理に使用されます。

## **組み込みプロパティへのアクセス**

[IDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/idocumentproperties/) インターフェイスで公開されているプロパティには、**Creator**（作成者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（変更日）、**Printed**（最終印刷日）、**LastModifiedBy**、**SharedDoc**（ドキュメントが別のプロデューサー間で共有されているか）、**PresentationFormat**、**Subject**、**Title** などがあります。

```cs
using Aspose.Slides;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// プレゼンテーションに関連付けられた IDocumentProperties 型のオブジェクトへの参照を取得します。
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

プレゼンテーション ファイルの組み込みプロパティの変更は、取得と同じくらい簡単です。任意のプロパティに文字列値を割り当てるだけで、プロパティの値が更新されます。以下の例では、プレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示します。

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

// Save the presentation to a file.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **カスタム プレゼンテーション プロパティの追加**

カスタム プレゼンテーション プロパティを使用すると、開発者はプレゼンテーション ファイル内に追加のメタデータや特定の情報を保存できます。Aspose.Slides は、これらのカスタム プロパティをプログラムで簡単に作成および管理できるようにします。以下の例は、プレゼンテーションにカスタム プロパティを追加する方法を示しています。

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

Aspose.Slides は、既存のカスタム プロパティにアクセスし、その値を容易に変更できる機能も提供します。この機能により、正確なメタデータの維持や、ユーザー入力やビジネス ロジックに基づく動的な更新が可能になります。以下の例は、プレゼンテーション内のカスタム プロパティの値を取得し、更新する方法を示しています。

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

Aspose.Slides API を使用してドキュメント プロパティを操作する方法を確認するには、オンライン アプリの [**PowerPoint メタデータの表示と編集**](https://products.aspose.app/slides/ja/metadata) をお試しください。

[![PowerPoint メタデータの表示と編集](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **FAQ**

**組み込みプロパティをプレゼンテーションから削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティの値を変更するか、許可されている場合は空に設定できます。

**既に存在するカスタム プロパティを追加した場合、どうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前にプロパティを削除したり確認したりする必要はなく、Aspose.Slides が自動的に値を更新します。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい。まず [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/presentationfactory/getpresentationinfo/) を使用し、次に [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentationinfo/readdocumentproperties/) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット固有の制限については、[軽量プレゼンテーション インベントリの作成](/slides/ja/net/examine-presentation/) を参照してください。