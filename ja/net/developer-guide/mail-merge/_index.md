---
title: メールマージでプレゼンテーションのパーソナライズを自動化する
linktitle: メールマージ
type: docs
weight: 233
url: /ja/net/mail-merge/
keywords:
- メールマージ
- プレゼンテーションのパーソナライズ
- プレゼンテーションテンプレート
- テキストプレースホルダー
- データソース
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
description: "Aspose.Slides for .NET のメールマージを使用して、データでプレゼンテーションテンプレートを埋め込み、CSV、Excel、JSON、XML ソースから個別化された PowerPoint プレゼンテーションを生成する方法を学びます。"
---
# PowerPoint プレゼンテーションのメール マージ

Aspose.Slides for .NET は、テンプレートとデータ ソースを使用して PowerPoint プレゼンテーションを自動的に生成できます。メール マージはテンプレートのプレースホルダーにデータを埋め込み、データ セットごとにテンプレート スライドを繰り返した単一のプレゼンテーション、またはデータ セットごとの個別プレゼンテーションのいずれかを作成します。

この機能は、製品カタログ、パーソナライズされたプレゼンテーション、レポート、証明書、提案書、価格表、その他構造は同じで内容が異なるドキュメントの生成に便利です。

![メール マージ: 前後](mail-merge-before-after.png)


## メール マージの仕組み

メール マージは PowerPoint プレゼンテーションをテンプレートとして使用し、データ ソースから取得した値でプレースホルダーを置換します。

![メール マージ ワークフロー](mail-merge-workflow.png)

プレースホルダーは `{{title}}` や `{{price}}` のように二重波かっこで囲まれたフィールド名です。プレースホルダーはシェイプ内のテキスト、テーブル セル、グループ化シェイプ、スピーカーノートに配置できます。

例として、テンプレート スライドに次のテキストが含まれることがあります。

- `Product: {{title}}`
- `Price: {{price}}`
- `Description: {{description}}`

データ ソースに次の値が含まれている場合:

| フィールド | 値 |
|---|---|
| title | Laptop X1 |
| price | $999 |
| description | 14-inch display, 16 GB RAM |

メール マージはプレースホルダーを対応する値に置換し、実際の製品情報が入ったスライドを生成します。

フィールド名は大文字と小文字を区別しません。したがって `{{title}}` と `{{Title}}` は同じフィールドを指します。

プレースホルダー置換時のルールは以下のとおりです。

- スライド上のプレースホルダーは、グループ化シェイプやテーブル セル、スピーカーノートを含めて置換されます。
- マスタースライドやレイアウトスライド上のプレースホルダーは置換されません。
- データ セットにフィールドが存在しないプレースホルダーは変更されずに残ります。
- 空のフィールド値はプレースホルダーを空文字列に置換します。
- 挿入されたテキストはプレースホルダーの最初の文字の書式を継承します。
- 値にプレースホルダー文字列が含まれていてはいけません。挿入されたテキストが再度処理され、別のフィールドに置換される可能性があるためです。

マージ操作中に元のテンプレート プレゼンテーションは変更されず、少なくとも 1 枚のスライドを含んでいる必要があります。

## サポートされているデータ ソース

メール マージはデータの供給方法として 2 つをサポートします。

- `IMailMergeDataSource` を使用してプログラムからデータ ソースを作成する。
- CSV、XLSX、JSON、XML ファイルまたはストリームからデータを読み取る。

データ形式は拡張子ではなく内容で判別されます。シーク不可のストリームもサポートされます。

データ ソースは少なくとも 1 つのデータ セットを含んでいる必要があります。各データ セットはテンプレートの 1 コピーに対応し、その値で埋められます。

サポートされていない形式と判定された場合は `NotSupportedException` がスローされます。形式は認識されたが要件を満たさない場合は `InvalidDataException` がスローされ、例外メッセージにエラー位置が含まれます。

### JSON

JSON データ ソースは `sets` 配列を含むルート オブジェクトを持つ必要があります。配列の各要素がデータ セットを表し、`fields` 配列を含みます。各フィールドは `name` と `value` の文字列を持ちます。

省略可能な `version` プロパティは `"1.0"`、`type` プロパティは `"text"` である必要があります。プロパティ名は大文字小文字を区別します。未定義のプロパティは無視されます。

JSON データは UTF-8 で読み取られ、BOM がある場合は UTF-16 として扱われます。

次の例は 2 つのデータ セットを含みます。

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

### XML

XML データ ソースは `template` ルート要素の中に `sets` 要素を持つ必要があります。各 `set` 要素は `field` 要素を含み、各フィールドは `name` と `value` 要素を持ちます。

空の `value` 要素は空文字列として扱われます。要素名は大文字小文字を区別します。未定義の要素やコメントは無視されます。エンコーディングは XML 宣言で決定され、DTD は使用できません。

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

### CSV

CSV データはセミコロンを値の区切り文字として使用します。

最初の行はフィールド名を含み、最初の空フィールド名で終了します。以降の各行が 1 つのデータ セットを表し、最初の空行でデータは終了します。

適用されるルール:

- 行末の欠損値は空文字列として扱われます。
- 定義されているフィールド名以降の値は無視されます。
- セミコロン、引用符、改行を含む値は引用符で囲む必要があります。
- 引用符で囲まれた値内の引用符は二重にします。
- データは UTF-8 で読み取られ、BOM がある場合は UTF-16 として扱われます。

例:

```csv
title;price;description
Laptop X1;$999;"14"" display; 16 GB RAM"
Tablet S2;$499;
```

### XLSX

XLSX データは最初のワークシートから読み取られます。

ワークシートは CSV と同じルールに従います。

- 最初の行はフィールド名を含み、最初の空セルで終了します。
- 以降の各行が 1 つのデータ セットを表します。
- データは最初の空行で終了します。
- 空セルは空文字列として扱われます。
- 数値は不変カルチャを使用して文字列に変換されます。

## 単一プレゼンテーションの作成

`MergeToSinglePresentation` メソッドは、データ セットごとにテンプレート スライドのコピーを作成し、すべてのコピーを含む 1 つのプレゼンテーションを生成します。各コピーは対応するデータで埋められます。

データ セットの順序は、結果のプレゼンテーション内のスライド グループの順序を決定します。

### ファイルからデータをマージ

次の例はテンプレートと JSON データ ファイルを読み込み、すべてのデータ セットのスライドを含む単一プレゼンテーションを作成し、結果を保存します。

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

データはストリームから読み取ることもできます。ストリームは現在の位置から読み取り、メール マージ操作によって閉じられません。

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

### コードでデータ ソースを作成

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

この例では、テンプレート スライドが 2 回繰り返されます: 1 回目はノートパソコン、2 回目はタブレット用です。プレースホルダーは各データ セットで定義された値で埋められます。

## 複数プレゼンテーションの作成

データ セットごとに別々のプレゼンテーションが必要な場合は、`MergeToMultiplePresentations` メソッドを使用します。

このメソッドはデータ セットを 1 つずつ処理し、テンプレートからプレゼンテーションを作成して現在のデータで埋め、結果のプレゼンテーションをハンドラに渡します。

ハンドラは元のデータ順序で各データ セットに対して 1 回呼び出されます。

### 各プレゼンテーションの保存

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

`args.Index` プロパティは現在のデータ セットのゼロベースインデックスを提供します。この例では `product_1.pptx` から始まる連番ファイル名を生成するために使用しています。

データはストリームからも読み取れます。

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

### データ セットの値をファイル名に使用

ハンドラは生成されたプレゼンテーションと、それを作成するために使用されたデータ セットの情報を受け取ります。データ セットの値を使用して意味のあるファイル名を構築できます。

例として、次のコードは製品名を使って各プレゼンテーションを保存します。

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

`DataSet` プロパティは現在のプレゼンテーションを埋めるために使用されたデータ セットを返します。`GetText` メソッドは指定したフィールドの値を取得し、フィールドが存在しない場合は `null` を返します。

これにより、データ値をファイル名に使用したり、出力を整理したり、ハンドラ内で追加処理を行ったりできます。

## 生成されたプレゼンテーションの取り扱い

`MergeToMultiplePresentations` は `MailMergedPresentationHandler` デリゲートを使用して各生成プレゼンテーションを処理します。

ハンドラは次の 2 つの引数を受け取ります。

- `presentation` — テンプレートから作成され、現在のデータ セットで埋められたプレゼンテーション。
- `args` — データ セットインデックスやデータ セット自体など、生成プレゼンテーションに関する情報。

生成されたプレゼンテーションはメール マージ操作によって所有され、ハンドラが返された直後に破棄されます。したがって、ハンドラ内で保存するか必要なデータをコピーし、ハンドラの外で参照したり手動で破棄したりしないでください。

ハンドラは呼び出しスレッド上で 1 つずつ実行され、データ セットの順序で処理されます。メモリには同時に 1 つの生成プレゼンテーションしか保持されないため、大規模なデータ ソースをメモリに全て保持せずに処理できます。

ハンドラ内で例外がスローされると、メール マージ操作は停止し、例外は変更されずに呼び出し元へ伝搬します。既に処理されたプレゼンテーションは影響を受けず、残りのデータ セットは処理されません。

次の例は生成プレゼンテーションを専用ディレクトリに保存します。

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

## メール マージ データの操作

`MailMergeDataSource` クラスはデータ セットの順序付けされたコレクションを表します。コードでデータを作成したり、データ セット数を確認したり、インデックスで個別データ セットにアクセスしたりできます。

### データ セット数の取得

`Count` プロパティはソース内のデータ セット数を返します。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine("Presentations to create: " + source.Count);
```

### インデックスでデータ セットにアクセス

`Item(int)` プロパティは指定したゼロベースインデックスのデータ セットへのアクセスを提供します。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

source.AddDataSet().AddText("title", "Laptop X1");
source.AddDataSet().AddText("title", "Tablet S2");

Console.WriteLine(source[1].GetText("title"));
```

この例は2番目のデータ セットのタイトルを取得します。

### テキスト フィールドの追加

`AddText` メソッドは名前付きテキスト フィールドをデータ セットに追加します。フィールド値はテンプレート内のすべての一致プレースホルダーを置換します。

```csharp
MailMergeDataSource source = new MailMergeDataSource();

IMailMergeDataSet dataSet = source.AddDataSet();
dataSet.AddText("title", "Laptop X1");
dataSet.AddText("subtitle", string.Empty);
```

空の値は結果テキストから対応するプレースホルダーを削除します。データ セットにフィールドが追加されていない場合、プレースホルダーは変更されません。

### テキスト フィールドの取得

`GetText` メソッドはフィールド名で値を取得します。フィールド名は大文字小文字を区別しません。

```csharp
IMailMergeDataSet dataSet = source[0];

string title = dataSet.GetText("title");
string price = dataSet.GetText("price");
```

フィールドが存在しないか、指定されたフィールド名が `null` の場合、`GetText` は `null` を返します。

## まとめ

Aspose.Slides for .NET のメール マージは、再利用可能なテンプレートからデータ駆動型プレゼンテーションを簡単に生成する方法を提供します。

主な利用シーン:

- データ ソースから値を取得してプレゼンテーション テンプレートに埋め込む。
- 複数のデータ セットに対してテンプレート スライドを繰り返した単一プレゼンテーションを生成する。
- データ セットごとに個別プレゼンテーションを作成する。
- CSV、XLSX、JSON、XML ファイルまたはストリームからデータを読み取る。
- コード内で直接データ ソースを構築する。
- ハンドラを使用して生成プレゼンテーションを順次処理・保存する。

再利用可能なテンプレートと構造化データを組み合わせることで、テンプレートのデザインとデータ処理ロジックを分離したまま、大量のプレゼンテーション作成を自動化できます。

## よくある質問

### 同じプレースホルダーをテンプレート内で複数回使用できますか？

はい。フィールド名が一致するプレースホルダーはすべて、現在のデータ セットの対応する値に置換されます。

### フィールド名は大文字小文字を区別しますか？

いいえ。プレースホルダーとデータ フィールド名は大文字小文字を区別しません。たとえば `{{title}}`, `{{Title}}`, `{{TITLE}}` は同じフィールドを指します。

### データ セットにフィールドが存在しない場合はどうなりますか？

プレースホルダーが参照するフィールドがデータ セットに含まれていない場合、そのプレースホルダーは生成されたプレゼンテーションで変更されずに残ります。

### フィールドの値が空の場合はどうなりますか？

空のフィールド値はプレースホルダーを空文字列に置換します。プレースホルダーのテキストは削除され、該当位置にテキストは残りません。

### プレースホルダーの書式を保持したまま置換できますか？

置換後のテキストはプレースホルダーの最初の文字の書式を継承します。マージを実行する前にテンプレートのプレースホルダーに目的の書式を設定してください。

### マスタースライドやレイアウトスライドのプレースホルダーも置換されますか？

いいえ。メール マージはスライド上のサポート対象コンテンツ（シェイプ、グループ化シェイプ、テーブル セル、スピーカーノート）にのみプレースホルダーを置換します。マスターやレイアウトスライド上のプレースホルダーは置換されません。

### テンプレート プレゼンテーションはマージ中に変更されますか？

変更されません。元のテンプレートはマージ操作によって変更されず、同じテンプレートを複数回使用できます。

### データ セットごとに個別のプレゼンテーションを生成できますか？

はい。`MergeToMultiplePresentations` を使用し、ハンドラ内で各生成プレゼンテーションを保存してください。ハンドラは各データ セットに対して順次呼び出されます。

### すべてのデータ セットを 1 つのプレゼンテーションに統合できますか？

はい。`MergeToSinglePresentation` を使用します。データ ソースの順序通りにテンプレート スライドのコピーが追加された単一の出力プレゼンテーションが作成されます。

### データ ソースをファイルに保存せずに使用できますか？

はい。コード内で `MailMergeDataSource` を作成し、データ セットとフィールドを追加して使用できます。データが既にアプリケーション内にある場合に便利です。

### データ形式はファイル拡張子で判別されますか？

いいえ。データ形式はコンテンツから検出されるため、サポート対象のデータ ソースは特定の拡張子である必要はありません。

### シークできないストリームからデータを読み取れますか？

はい。メール マージはシーク不可のストリームをサポートします。

### データ ソースが空、またはデータ セットが全くない場合はどうなりますか？

データ ソースは少なくとも 1 つのデータ セットを含んでいる必要があります。マージを開始する前に少なくとも 1 件のレコードが含まれていることを確認してください。

### データ ソースの形式が無効な場合はどうなりますか？

コンテンツがサポートされているいずれのデータ形式にも該当しない場合は `NotSupportedException` がスローされます。形式は認識されたが構文エラー等で不正な場合は `InvalidDataException` がスローされ、例外メッセージにエラー位置が含まれます。

### ハンドラが返された後に生成プレゼンテーションを使用できますか？

`MergeToMultiplePresentations` のハンドラに渡されたプレゼンテーションはメール マージによって所有され、ハンドラが戻った直後に破棄されます。ハンドラ内で保存または必要なデータをコピーし、ハンドラ外で参照したり手動で破棄したりしないでください。

### ハンドラは並列で呼び出されますか？

いいえ。生成プレゼンテーションは呼び出し元スレッド上で順次処理され、同時に保持されるプレゼンテーションは 1 つだけです。

### ハンドラ内で例外が発生した場合はどうなりますか？

マージ操作は停止し、例外は変更されずに呼び出し元へ伝搬します。既に処理されたプレゼンテーションは影響を受けず、残りのデータ セットは処理されません。

### フィールド値を使用して出力ファイル名を生成できますか？

はい。ハンドラの引数で現在のデータ セットを取得できるので、`GetText` でフィールドを取得し、各生成プレゼンテーションのファイル名を構築できます。対象環境で有効なファイル名になるよう値を調整してください。