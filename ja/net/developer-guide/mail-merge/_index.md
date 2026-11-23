---
title: メール マージでプレゼンテーションのパーソナライズを自動化
linktitle: メール マージ
type: docs
weight: 233
url: /ja/net/mail-merge/
keywords:
- メール マージ
- プレゼンテーションのパーソナライズ
- プレゼンテーション テンプレート
- テキスト プレースホルダー
- データ ソース
- CSV
- Excel
- XLSX
- JSON
- XML
- データのマージ
- プレゼンテーションの生成
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET のメール マージを使用して、データでプレゼンテーションテンプレートを埋め込み、CSV、Excel、JSON、XML ソースからパーソナライズされた PowerPoint プレゼンテーションを生成する方法を学びます。"
---
## **PowerPoint プレゼンテーションのメール マージ**

Aspose.Slides for .NET を使用すると、テンプレートとデータ ソースを利用して PowerPoint プレゼンテーションを自動的に生成できます。メール マージはテンプレートのプレースホルダーにデータを埋め込み、すべてのデータ セットに対してテンプレート スライドを繰り返す単一のプレゼンテーションまたは各データ セットごとの個別プレゼンテーションのいずれかを作成します。

この機能は、製品カタログ、パーソナライズされたプレゼンテーション、レポート、証明書、提案書、価格表、その他プレゼンテーション構造は同じだが内容が変わる文書を生成する際に便利です。

![メール マージ: 前後](mail-merge-before-after.png)


## **メール マージの仕組み**

メール マージは PowerPoint プレゼンテーションをテンプレートとして使用し、データ ソースから取得した値でプレースホルダーを置き換えます。

![メール マージ ワークフロー](mail-merge-workflow.png)

プレースホルダーは `{{title}}` や `{{price}}` のように二重波かっこで囲まれたフィールド名です。プレースホルダーはテキスト シェイプ、テーブル セル、グループ化シェイプ、スピーカーノートに配置できます。

たとえば、テンプレート スライドに次のテキストが含まれている場合:

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

データ ソースに次の値が含まれているとき:

| フィールド | 値 |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

メール マージはプレースホルダーを対応する値に置き換え、実際の製品情報が記載されたスライドを生成します。

フィールド名は大文字と小文字を区別しません。そのため `{{title}}` と `{{Title}}` は同じフィールドを指します。

プレースホルダー置換時に適用される規則は次のとおりです:

- スライド上（グループ化シェイプやテーブル セル、スピーカーノートを含む）でプレースホルダーが置換されます。
- マスタースライドやレイアウトスライド上のプレースホルダーは置換されません。
- データ セットにフィールドが存在しないプレースホルダーは変更されずそのまま残ります。
- 空のフィールド値はプレースホルダーを空文字列に置き換えます。
- 挿入されたテキストはプレースホルダーの最初の文字の書式を継承します。
- 値にプレースホルダー文字列が含まれていてはいけません。挿入されたテキストが再度処理され、別のフィールドに置換される可能性があるためです。

マージ操作中にテンプレート プレゼンテーションは変更されず、少なくとも 1 枚のスライドを含んでいる必要があります。

## **サポートされているデータ ソース**

メール マージはデータ提供方法として次の 2 つをサポートします:

- `IMailMergeDataSource` を使用してプログラムからデータ ソースを作成する。
- CSV、XLSX、JSON、XML ファイルまたはストリームからデータを読み取る。

データ形式は拡張子ではなく内容で判別されます。シークをサポートしないストリームも利用可能です。

データ ソースは少なくとも 1 つのデータ セットを含む必要があります。各データ セットはテンプレートのコピーをその値で埋める対象となります。

データ内容がサポートされている形式として認識できない場合は `NotSupportedException` がスローされます。内容は認識されたが形式要件を満たさない場合は `InvalidDataException` がスローされ、例外メッセージにエラー位置が含まれます。

### **JSON**

JSON データ ソースは `sets` 配列を含むルート オブジェクトを持つ必要があります。配列の各要素がデータ セットを表し、`fields` 配列を含む必要があります。各フィールドは `name` と `value` 文字列を持ちます。

オプションの `version` プロパティは `"1.0"`、オプションの `type` プロパティは `"text"` とする必要があります。プロパティ名は大文字小文字を区別し、未知のプロパティは無視されます。

JSON データは UTF-8 として読み取られ、BOM が付いている場合は UTF-16 として読み取られます。

以下の例は 2 つのデータ セットを含みます:

```json
{
  "version": "1.0",
  "sets": [
    {
      "fields": [
        { "name": "title", "value": "Laptop X1" },
        { "name": "price", "value": "$999" }
      ]
    },
    {
      "fields": [
        { "name": "title", "value": "Tablet S2" },
        { "name": "price", "value": "$499" }
      ]
    }
  ]
}
```

### **XML**

XML データ ソースは `template` ルート要素が `sets` 要素を含む必要があります。各 `set` 要素は `field` 要素を含み、各フィールドは `name` と `value` 要素を持たなければなりません。

空の `value` 要素は空文字列として扱われます。要素名は大文字小文字を区別し、未知の要素やコメントは無視されます。エンコーディングは XML 宣言によって決定され、DTD は許可されません。

```xml
<?xml version="1.0" encoding="utf-8"?>
<template>
  <sets>
    <set>
      <field>
        <name>title</name>
        <value>Laptop X1</value>
      </field>
      <field>
        <name>price</name>
        <value>$999</value>
      </field>
    </set>
    <set>
      <field>
        <name>title</name>
        <value>Tablet S2</value>
      </field>
      <field>
        <name>price</name>
        <value>$499</value>
      </field>
    </set>
  </sets>
</template>
```

### **CSV**

CSV データはセミコロンを値区切り文字として使用します。

最初の行にはフィールド名が含まれ、最初の空フィールド名で終了します。以降の各行が 1 つのデータ セットを表し、空行が現れた時点でデータは終了します。

適用される規則:

- 行末の欠損値は空文字列として扱われます。
- 定義されたフィールド名以降の値は無視されます。
- セミコロン、引用符、改行を含む値は引用符で囲む必要があります。
- 引用符で囲まれた値内の引用符は二重にします。
- データは UTF-8 として読み取られ、BOM が付いている場合は UTF-16 として読み取られます。

例:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### **XLSX**

XLSX データは最初のワークシートから読み取られます。

ワークシートは CSV と同じ規則に従います:

- 最初の行にフィールド名があり、最初の空セルで終了します。
- 以降の各行が 1 つのデータ セットを表します。
- 空行でデータは終了します。
- 空セルは空文字列として扱われます。
- 数値は不変カルチャを使用して文字列に変換されます。

## **単一プレゼンテーションの作成**

`MergeToSinglePresentation` メソッドは、各データ セットごとにテンプレート スライドのコピーを作成し、それらをまとめた単一のプレゼンテーションを生成します。各コピーは対応するデータで埋められます。

データ セットの順序は、結果のプレゼンテーション内のスライド グループの順序を決定します。

### **ファイルからデータをマージする**

次の例はテンプレートと JSON データ ファイルを読み込み、すべてのデータ セット用スライドを含む単一プレゼンテーションを作成し、結果を保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, "products.json"))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

データはストリームからも読み取れます。ストリームは現在の位置から読み取られ、メール マージ操作によって閉じられません。

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xml"))
using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, data))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

### **コードでデータ ソースを作成する**

`MailMergeDataSource` と `MailMergeDataSet` を使用してプログラムからデータ ソースを構築できます。各レコードごとにデータ セットを追加し、`AddText` メソッドでフィールドを定義します。

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet laptop = source.AddDataSet();
laptop.AddText("title", "Laptop X1");
laptop.AddText("price", "$999");

IMailMergeDataSet tablet = source.AddDataSet();
tablet.AddText("title", "Tablet S2");
tablet.AddText("price", "$499");

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
using (IPresentation result = mailMerge.MergeToSinglePresentation(template, source))
{
    result.Save("catalog.pptx", SaveFormat.Pptx);
}
```

この例ではテンプレート スライドが 2 回繰り返されます: 1 回はノートパソコン用、もう 1 回はタブレット用です。プレースホルダーは各データ セットで定義された値で埋められます。

## **複数プレゼンテーションの作成**

各データ セットごとに個別のプレゼンテーションが必要な場合は、`MergeToMultiplePresentations` メソッドを使用します。

このメソッドはデータ セットを 1 つずつ処理し、テンプレートからプレゼンテーションを作成して現在のデータで埋め込み、結果のプレゼンテーションをハンドラに渡します。

ハンドラは元のデータ順序で各データ セットに対して 1 回呼び出されます。

### **各プレゼンテーションを保存する**

次の例は CSV ファイルからデータを読み取り、生成された各プレゼンテーションを別々のファイルとして保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.csv",
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

`args.Index` プロパティは現在のデータ セットのゼロベース インデックスを提供します。この例では `product_1.pptx` から始まる連番ファイル名を生成するために使用しています。

データはストリームからも読み取れます:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Stream data = File.OpenRead("products.xlsx"))
using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        data,
        (presentation, args) =>
        {
            presentation.Save(
                "product_" + (args.Index + 1) + ".pptx",
                SaveFormat.Pptx);
        });
}
```

### **データ セットの値を使用してファイル名を付ける**

ハンドラは生成されたプレゼンテーションと、それを作成する際に使用されたデータ セットに関する情報の両方を受け取ります。データ セットの値を使用して意味のあるファイル名を構築できます。

たとえば、次のコードは製品タイトルを使用して各プレゼンテーションを保存します:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string title = args.DataSet.GetText("title");
            string fileName = title != null
                ? title
                : "product_" + (args.Index + 1);

            presentation.Save(fileName + ".pptx", SaveFormat.Pptx);
        });
}
```

`DataSet` プロパティは現在のプレゼンテーションを埋めたデータ セットを返します。`GetText` メソッドは指定したフィールドの値を取得し、フィールドが存在しない場合は `null` を返します。

これにより、ファイル名の生成や出力の整理、ハンドラ内での追加処理にデータ値を利用できます。

## **生成されたプレゼンテーションの取り扱い**

`MergeToMultiplePresentations` は `MailMergedPresentationHandler` デリゲートを使用して各生成プレゼンテーションを処理します。

ハンドラは次の 2 つの引数を受け取ります:

- `presentation` — テンプレートから作成され、現在のデータ セットで埋め込まれたプレゼンテーション。
- `args` — データ セットのインデックスやデータ セット自体など、生成されたプレゼンテーションに関する情報。

生成されたプレゼンテーションはメール マージ操作によって所有され、ハンドラが返された直後に破棄されます。したがって、ハンドラ内で保存するか必要なデータをコピーし、ハンドラが返った後に参照を保持したり手動で破棄したりしないでください。

ハンドラは呼び出し元スレッド上で 1 回に 1 つのプレゼンテーションを順番に実行し、データ セットの順序で処理されます。この方式は同時にすべての生成プレゼンテーションをメモリに保持せずに大規模データ ソースを処理するのに適しています。

ハンドラ内で例外がスローされた場合、メール マージ操作は停止し、例外は変更されずに呼び出し元へ伝播します。すでに処理されたプレゼンテーションは影響を受けず、残りのデータ セットは処理されません。

次の例は生成されたプレゼンテーションを専用ディレクトリに保存します:

```csharp
using Aspose.Slides;
using Aspose.Slides.MailMerge;
using System.IO;

string outputFolder = "output";
Directory.CreateDirectory(outputFolder);

MailMergeProcessor mailMerge = new MailMergeProcessor();

using (Presentation template = new Presentation("template.pptx"))
{
    mailMerge.MergeToMultiplePresentations(
        template,
        "products.json",
        (presentation, args) =>
        {
            string path = Path.Combine(
                outputFolder,
                "product_" + (args.Index + 1) + ".pptx");

            presentation.Save(path, SaveFormat.Pptx);
        });
}
```

## **メール マージ データの操作**

`MailMergeDataSource` クラスはデータ セットの順序付きコレクションを表します。コードでデータを作成したり、データ セット数を確認したり、インデックスで個別のデータ セットにアクセスしたりできます。

### **データ セット数の取得**

`Count` プロパティはソース内のデータ セット数を返します。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### **インデックスによるデータ セットへのアクセス**

`Item(int)` プロパティは指定されたゼロベース インデックスのデータ セットへのアクセスを提供します。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

この例は 2 番目のデータ セットのタイトルを取得します。

### **テキスト フィールドの追加**

`AddText` メソッドはデータ セットに名前付きテキスト フィールドを追加します。フィールド値はテンプレート内のすべての一致するプレースホルダーを置換します。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

空の値は結果テキストから対応するプレースホルダーを削除します。データ セットにフィールドが追加されていない場合、プレースホルダーは変更されません。

### **テキスト フィールドの取得**

`GetText` メソッドは名前でフィールドの値を取得します。フィールド名は大文字小文字を区別しません。

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

フィールドが存在しない、または指定されたフィールド名が `null` の場合、`GetText` は `null` を返します。

## **まとめ**

Aspose.Slides for .NET のメール マージは、再利用可能なテンプレートからデータ駆動型プレゼンテーションを生成する便利な方法を提供します。

これを使用して以下を実現できます:

- データ ソースからの値でプレゼンテーション テンプレートにデータを埋め込む。
- 複数データ セット用にテンプレート スライドを繰り返した単一プレゼンテーションを生成する。
- 各データ セットごとに個別のプレゼンテーションを作成する。
- CSV、XLSX、JSON、XML ファイルまたはストリームからデータを読み取る。
- コード内で直接データ ソースを構築する。
- ハンドラを使用して生成されたプレゼンテーションを順次処理・保存する。

再利用可能なテンプレートと構造化データを組み合わせることで、テンプレート デザインとデータ処理ロジックを分離したまま大量のプレゼンテーション作成を自動化できます。

## **よくある質問**

**同じプレースホルダーをテンプレート内で複数回使用できますか？**

はい。フィールド名が一致するすべてのプレースホルダーは、現在のデータ セットから対応する値に置換されます。

**フィールド名は大文字と小文字を区別しますか？**

いいえ。プレースホルダーとデータ フィールド名は大文字小文字を区別しません。たとえば `{{title}}`、`{{Title}}`、`{{TITLE}}` は同じフィールドを指します。

**データ セットにフィールドが存在しない場合はどうなりますか？**

プレースホルダーが参照するフィールドがデータ セットに含まれていない場合、そのプレースホルダーは変更されずに残ります。

**フィールドに空の値が設定された場合はどうなりますか？**

空のフィールド値はプレースホルダーを空文字列に置換し、プレースホルダーのテキストは削除されます。

**プレースホルダーの書式を置換時に保持できますか？**

置換テキストはプレースホルダーの最初の文字の書式を継承します。マージを実行する前にテンプレート内のプレースホルダーに希望の書式を設定してください。

**マスター スライドやレイアウト スライドのプレースホルダーも置換されますか？**

いいえ。メール マージはプレゼンテーション スライド上のサポート対象コンテンツ（シェイプ、グループ化シェイプ、テーブル セル、スピーカーノート）でのみプレースホルダーを置換し、マスターやレイアウト スライド上のプレースホルダーは置換しません。

**テンプレート プレゼンテーションはマージ中に変更されますか？**

いいえ。元のテンプレートはマージ操作によって変更されません。同じテンプレートを別のデータ ソースで再利用できます。

**各データ セットごとに個別のプレゼンテーションを生成できますか？**

はい。`MergeToMultiplePresentations` を使用し、ハンドラ内で各生成プレゼンテーションを保存してください。ハンドラは各データ セットに対して順次呼び出されます。

**すべてのデータ セットを 1 つのプレゼンテーションに結合できますか？**

はい。`MergeToSinglePresentation` を使用します。これにより、データ ソースの順序に従ってテンプレート スライドのコピーが含まれる単一の出力プレゼンテーションが作成されます。

**ファイルに保存せずにデータ ソースを使用できますか？**

はい。コード内で `MailMergeDataSource` を作成し、データ セットを追加して `AddText` でフィールドを設定できます。データがアプリケーション内に既にある場合に便利です。

**データ形式はファイル拡張子で判別されますか？**

いいえ。データ形式は内容から検出されるため、サポート対象のデータ ソースは特定の拡張子である必要はありません。

**シークをサポートしないストリームからデータを読み取れますか？**

はい。メール マージはシーク不可のストリームをサポートします。

**データ ソースが空またはデータ セットがない場合はどうなりますか？**

データ ソースは少なくとも 1 つのデータ セットを含む必要があります。マージを開始する前に少なくとも 1 件のレコードが含まれていることを確認してください。

**データ ソースの形式が無効な場合はどうなりますか？**

内容がサポート対象のデータ形式として認識できない場合は `NotSupportedException` がスローされます。認識されたが形式が不正な場合は `InvalidDataException` がスローされ、例外メッセージにエラー位置が含まれます。

**ハンドラが返った後に生成プレゼンテーションを使用できますか？**

`MergeToMultiplePresentations` ハンドラに渡されたプレゼンテーションはメール マージに所有され、ハンドラが返った直後に破棄されます。ハンドラ内で保存するか必要なデータをコピーし、ハンドラが返った後に参照を保持したり手動で破棄したりしないでください。

**ハンドラは並列で呼び出されますか？**

いいえ。生成されたプレゼンテーションは呼び出し元スレッド上で順次処理され、同時に保持されるプレゼンテーションは 1 つだけです。この動作は大量データ ソースをメモリにすべて保持せずに処理するのに適しています。

**ハンドラ内で例外が発生した場合はどうなりますか？**

マージ操作は停止し、例外は変更されずに呼び出し元へ伝播します。すでに処理されたプレゼンテーションは影響を受けず、残りのデータ セットは処理されません。

**フィールド値を使用して出力ファイル名を生成できますか？**

はい。ハンドラは現在のデータ セットを引数として提供します。`GetText` でフィールドを取得し、各生成プレゼンテーションのファイル名を構築してください。対象環境で有効なファイル名になるよう値を適切にサニタイズしてください。