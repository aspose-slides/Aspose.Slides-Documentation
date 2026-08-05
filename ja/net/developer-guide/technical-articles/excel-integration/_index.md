---
title: PowerPoint プレゼンテーションへの Excel データ統合
linktitle: Excel 統合
type: docs
weight: 330
url: /ja/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
keywords:
- Excel
- ワークブック
- Excel の読み取り
- Excel の統合
- データ ソース
- メール マージ
- テーブルのインポート
- Excel を PowerPoint に統合
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides の ExcelDataWorkbook API を使用して Excel ワークブックからデータを読み取ります。シートやセルをロードし、その値を利用してデータ駆動型 PowerPoint プレゼンテーションを生成します。"
---
## **はじめに**

PowerPoint プレゼンテーションは、情報を表示し伝えるための強力な手段です。これらは多くの場合、Excel ブックと組み合わせて使用され、Excel は構造化データの優れたソースとして機能し、PowerPoint はそのデータを観客向けに視覚化することに長けています。

Excel と PowerPoint を組み合わせることが不可欠な実用的なシナリオは多数あります。例えば、メール マージ、データテーブルの入力、データ レコードごとにスライドを生成する（バッチ スライド生成）、トレーニング資料の作成、複数の Excel レポートを単一のプレゼンテーションに統合する、などが挙げられます。

これまで、このような機能を Aspose.Slides API で実装するには、Aspose.Cells などのサードパーティ製ソリューションに依存する必要がありました。これらのツールは堅牢ですが、基本的なデータ統合機能だけを必要とするユーザーにとっては、過度に複雑でコストがかかる場合があります。

## **仕組み**

Excel データの操作をより簡単かつ効率的にするため、Aspose.Slides は Excel ブックからデータを読み取り、プレゼンテーションにコンテンツをインポートするための新しいクラスを導入しました。この機能により、プレゼンテーション ワークフロー内で Excel をデータソースとして活用したい API ユーザーに対して、強力な新しい可能性が開かれます。

新機能は汎用的なデータアクセス向けに設計されており、Presentation Document Object Model（DOM）には統合されていません。つまり、*Excel ファイルの編集や保存はできません* — その唯一の目的はブックを開き、内容をナビゲートしてセル データを取得することです。

この機能の中心には新しい [ExcelDataWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.excel/exceldataworkbook/) クラスがあります。このクラスを使用すると、ローカル ファイルまたはストリームから Excel ブックをロードできます。ロード後、[GetCell](https://reference.aspose.com/slides/ja/net/aspose.slides.excel/exceldataworkbook/getcell/) メソッドの複数のオーバーロードが提供され、位置（行と列のインデックスや名前付き範囲など）で特定のセルを取得できます。

[GetCell](https://reference.aspose.com/slides/ja/net/aspose.slides.excel/exceldataworkbook/getcell/) の呼び出しは、[ExcelDataCell](https://reference.aspose.com/slides/ja/net/aspose.slides.excel/exceldatacell/) クラスのインスタンスを返します。このオブジェクトは Excel ブック内の単一セルを表し、値にシンプルかつ直感的にアクセスできるようにします。

#### **Excel チャートのインポート**

機能を拡張する次のステップは [ExcelWorkbookImporter](https://reference.aspose.com/slides/ja/net/aspose.slides.import/excelworkbookimporter/) クラスです。このユーティリティ クラスは、Excel ブックからプレゼンテーションへのコンテンツ インポート機能を提供します。[AddChartFromWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) メソッドの複数のオーバーロードがあり、指定した Excel ブックから選択したチャートを取得し、指定された座標で指定されたシェイプ コレクションの末尾に追加できます。

#### **Excel テーブルのインポート**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/ja/net/aspose.slides.import/excelworkbookimporter/) クラスは、[AddTableFromWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) メソッドの複数のオーバーロードも提供します。これらのメソッドを使用すると、指定したワークシートから特定のセル範囲をインポートし、指定された座標でシェイプ コレクションの末尾にテーブルとして追加できます。

要するに、これは軽量でシンプルな Excel データ読み取り API であり、フル スプレッドシート処理ライブラリのオーバーヘッドなしに多くの開発者が必要とする機能を提供します。

## **コードを書いてみよう**

### **メール マージシナリオ例**

以下の例では、Excel ブックに保存されたデータに基づいて複数のプレゼンテーションを生成するシンプルなメール マージシナリオを実装します。

開始するには、次の 2 つが必要です：

1. データを含む Excel ブック

![Excel データ例](example1_image0.png)

2. PowerPoint プレゼンテーションのテンプレート

![PowerPoint テンプレート例](example1_image1.png)

```csharp
// 従業員データが入った Excel ワークブックをロードします。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// プレゼンテーションテンプレートをロードします。
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Excel 行をループ処理します（行 0 のヘッダーは除外）。
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // 各従業員レコード用に新しいプレゼンテーションを作成します。
    using Presentation employeePresentation = new Presentation();

    // デフォルトの空白スライドを削除します。
    employeePresentation.Slides.RemoveAt(0);

    // テンプレートスライドを新しいプレゼンテーションにクローンします。
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // 対象シェイプから段落を取得します（シェイプインデックス 1 が使用されていると想定）。
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // プレースホルダーを Excel のデータで置き換えます。
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // パーソナライズされたプレゼンテーションを別ファイルに保存します。
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![結果](example1_image2.png)

### **Excel テーブル例**

2 番目の例では、Excel テーブルからデータをコピーし、PowerPoint スライドにより視覚的に魅力的な形式で表示します。

この例では、最初の例と同じ Excel ブックを再利用します。このブックにはシンプルな従業員テーブルが含まれています。

```csharp
// 従業員データを含む Excel ワークブックをロードします。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 新しい PowerPoint プレゼンテーションを作成します。
using Presentation presentation = new Presentation();

// 最初のスライドにテーブルシェイプを追加します。
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Excel ワークブックのデータで PowerPoint テーブルを埋めます。
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// 結果のプレゼンテーションをファイルに保存します。
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![結果](example2_image0.png)

### **Excel チャートのインポート例**

この例では、前の例で使用した Excel ブックの最初のワークシートからチャートをインポートします。チャートは、結果のプレゼンテーションで外部ブックにリンクされます。

まず、従業員テーブルに基づいて Excel ブックに円グラフを追加します。

![Excel チャート例](example3_image0.png)

```csharp
// 新しい PowerPoint プレゼンテーションを作成します。
using Presentation presentation = new Presentation();

// 最初のスライドのシェイプ コレクションを取得します。
IShapeCollection shapes = presentation.Slides[0].Shapes;

// ワークブックの最初のシートから名前が「Chart 1」のチャートをインポートし、シェイプ コレクションに追加します。
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// 結果のプレゼンテーションをファイルに保存します。
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![結果](example3_image1.png)

### **すべての Excel チャートのインポート例**

Excel ブックに多数のチャートがあり、すべてをプレゼンテーションにインポートしたいと想像してください。各チャートは新しいスライドに配置されます。

以下のコードは、ソース Excel ファイル内のすべてのワークシートを順に処理し、各ワークシートからチャートを抽出して、空白のスライドレイアウトを使用して個別のスライドに追加します。結果のプレゼンテーションには、チャート データのみが埋め込まれ、ブック全体は埋め込まれません。

```csharp
// 従業員データを含む Excel ワークブックをロードします。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// 新しい PowerPoint プレゼンテーションを作成します。
using Presentation presentation = new Presentation();

// 空白のスライドレイアウトを取得します。
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Excel ワークブックに含まれるすべてのワークシート名を取得します。
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // ワークシートのチャートインデックスとチャート名をマッピングする辞書を取得します。
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // 空白レイアウトを使用して新しいスライドを追加します。
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // 指定したチャートを Excel ワークブックからスライドのシェイプ コレクションにインポートします。
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// 結果のプレゼンテーションをファイルに保存します。
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Excel テーブルのインポート例**

この例では、Excel ワークシートから書式設定されたテーブルを直接 PowerPoint プレゼンテーションにインポートします。

ソース Excel ワークシートには、従業員データを含む書式設定済みテーブルがあります：

![Excel テーブル例](example4_image0.png)

```csharp
// 新しい PowerPoint プレゼンテーションを作成します。
using Presentation presentation = new Presentation();

// 最初のスライドのシェイプ コレクションを取得します。
IShapeCollection shapes = presentation.Slides[0].Shapes;

// ワークブックの最初のシートからテーブルをインポートし、シェイプ コレクションに追加します。
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// 結果のプレゼンテーションをファイルに保存します。
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```
![結果](example4_image1.png)

## **まとめ**

この機構は Aspose.Slides に直接組み込まれており、Excel データの操作とプレゼンテーションを一元化します。追加のライブラリや複雑な統合なしに、視覚的なチャートや Excel テーブルとして提示されたデータを含むスライドを作成できます。