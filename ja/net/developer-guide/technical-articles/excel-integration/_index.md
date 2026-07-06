---
title: Excel データを PowerPoint プレゼンテーションに統合する
linktitle: Excel 統合
type: docs
weight: 330
url: /ja/net/excel-integration/
keywords:
- Excel
- ワークブック
- Excel の読み取り
- Excel の統合
- データソース
- メールマージ
- テーブルのインポート
- PowerPoint への Excel
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides の ExcelDataWorkbook API を使用して Excel ワークブックからデータを読み取ります。シートとセルをロードし、その値を使用してデータ駆動型 PowerPoint プレゼンテーションを生成します。"
---
## **はじめに**

PowerPoint プレゼンテーションは、情報を表示し伝達する強力な手段です。Excel ワークブックと組み合わせて使用されることが多く、Excel は構造化されたデータの優れたソースを提供し、PowerPoint はそのデータを視覚的に表現します。

Excel と PowerPoint を組み合わせる実用的なシナリオは多数あります。メールマージ、データテーブルの入力、レコードごとにスライドを生成するバッチスライド生成、トレーニング資料の作成、複数の Excel レポートを単一のプレゼンテーションに統合するなどが挙げられます。

これまで、Aspose.Slides API でこのような機能を実装するには、Aspose.Cells などのサードパーティ製ソリューションに依存する必要がありました。これらのツールは堅牢ですが、基本的なデータ統合機能だけを必要とするユーザーにとっては、過剰に複雑でコストがかかることがあります。

## **動作概要**

Excel データの取り扱いをより簡単かつ効率的にするため、Aspose.Slides は Excel ワークブックからデータを読み取り、プレゼンテーションにコンテンツをインポートするための新しいクラスを導入しました。この機能により、プレゼンテーションのワークフロー内で Excel をデータソースとして活用したい API ユーザーに、強力な新しい可能性が開かれます。

新機能は汎用的なデータアクセス向けに設計されており、Presentation Document Object Model (DOM) には統合されていません。つまり、*Excel ファイルの編集や保存はできません* — 主目的はワークブックを開き、その内容を走査してセルデータを取得することです。

この機能の中心にあるのは新しい [ExcelDataWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.excel/exceldataworkbook/) クラスです。このクラスを使用すると、ローカルファイルまたはストリームから Excel ワークブックをロードできます。ロード後は、[GetCell](https://reference.aspose.com/slides/ja/net/aspose.slides.excel/exceldataworkbook/getcell/) メソッドの複数のオーバーロードが提供され、行・列インデックスや名前付き範囲などの位置で特定のセルを取得できます。

[GetCell](https://reference.aspose.com/slides/ja/net/aspose.slides.excel/exceldataworkbook/getcell/) の各呼び出しは、[ExcelDataCell](https://reference.aspose.com/slides/ja/net/aspose.slides.excel/exceldatacell/) クラスのインスタンスを返します。このオブジェクトは Excel ワークブック内の単一セルを表し、シンプルで直感的な方法でその値にアクセスできます。

#### **Excel チャートのインポート**

機能拡張の次のステップは [ExcelWorkbookImporter](https://reference.aspose.com/slides/ja/net/aspose.slides.import/excelworkbookimporter/) クラスです。このユーティリティクラスは、Excel ワークブックからプレゼンテーションへコンテンツをインポートする機能を提供します。[AddChartFromWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) メソッドの複数のオーバーロードが用意されており、指定された Excel ワークブックから選択したチャートを取得し、指定座標で対象シェイプコレクションの末尾に追加できます。

#### **Excel テーブルのインポート**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/ja/net/aspose.slides.import/excelworkbookimporter/) クラスは、[AddTableFromWorkbook](https://reference.aspose.com/slides/ja/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) メソッドの複数のオーバーロードも提供します。これらのメソッドにより、指定されたワークシートから特定のセル範囲をインポートし、指定座標で対象シェイプコレクションの末尾にテーブルとして追加できます。

要するに、これは Excel データを読み取るための軽量でシンプルな API であり、フルスプレッドシート処理ライブラリのオーバーヘッドなしに多くの開発者が必要とする機能を提供します。

## **コード例**

### **メールマージシナリオ例**

以下の例では、Excel ワークブックに保存されたデータに基づいて複数のプレゼンテーションを生成するシンプルなメールマージシナリオを実装します。

開始するには次の 2 つが必要です:
1. データを含む Excel ワークブック

![Excel データ例](example1_image0.png)

2. PowerPoint プレゼンテーションテンプレート

![PowerPoint テンプレート例](example1_image1.png)

```csharp
// 社員データが入った Excel ワークブックを読み込む。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// プレゼンテーションテンプレートを読み込む。
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Excel の行をループ処理する（行 0 のヘッダーは除外）。
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // 各社員レコード用に新しいプレゼンテーションを作成する。
    using Presentation employeePresentation = new Presentation();

    // デフォルトの空白スライドを削除する。
    employeePresentation.Slides.RemoveAt(0);

    // テンプレートスライドを新しいプレゼンテーションにクローンする。
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // 対象シェイプから段落を取得する（シェイプインデックス 1 が使用されていると仮定）。
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // プレースホルダーを Excel のデータで置き換える。
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // 個別のファイルにパーソナライズされたプレゼンテーションを保存する。
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![結果](example1_image2.png)

### **Excel テーブル例**

2 番目の例では、Excel テーブルからデータをコピーし、PowerPoint スライド上により視覚的に魅力的な形式で表示します。

この例では、最初の例と同じ Excel ワークブック（シンプルな従業員テーブルを含む）を再利用します。

```csharp
// 社員データが含まれる Excel ワークブックを読み込む。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// 新しい PowerPoint プレゼンテーションを作成する。
using Presentation presentation = new Presentation();

// 最初のスライドにテーブルシェイプを追加する。
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Excel ワークブックからデータを取得して PowerPoint テーブルに埋め込む。
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// 結果のプレゼンテーションをファイルに保存する。
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![結果](example2_image0.png)

### **Excel チャートのインポート例**

この例では、前の例で使用した Excel ワークブックの最初のワークシートからチャートをインポートします。チャートは結果のプレゼンテーションで外部ワークブックにリンクされます。

まず、従業員テーブルに基づいて Excel ワークブックに円グラフを追加します。

![Excel チャート例](example3_image0.png)

```csharp
// 新しい PowerPoint プレゼンテーションを作成する。
using Presentation presentation = new Presentation();

// 最初のスライドのシェイプコレクションを取得する。
IShapeCollection shapes = presentation.Slides[0].Shapes;

// ワークブックの最初のシートから名前が "Chart 1" のチャートをインポートし、シェイプコレクションに追加する。
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// 結果のプレゼンテーションをファイルに保存する。
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![結果](example3_image1.png)

### **すべての Excel チャートのインポート例**

Excel ワークブックに多数のチャートがあり、それらすべてをプレゼンテーションにインポートしたいと想像してください。各チャートは新しいスライドに配置されます。

以下のコードは、ソース Excel ファイル内のすべてのワークシートを反復処理し、各ワークシートからチャートを抽出して、空白スライドレイアウトを使用して別々のスライドに追加します。結果のプレゼンテーションには、チャートデータのみが埋め込まれ、ワークブック全体は含まれません。

```csharp
// 社員データが含まれる Excel ワークブックを読み込む。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// 新しい PowerPoint プレゼンテーションを作成する。
using Presentation presentation = new Presentation();

// 空白スライドレイアウトを取得する。
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Excel ワークブックに含まれるすべてのワークシート名を取得する。
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // そのワークシートのチャートインデックスとチャート名をマッピングする辞書を取得する。
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // 空白レイアウトを使用して新しいスライドを追加する。
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Excel ワークブックから指定されたチャートをインポートし、スライドのシェイプコレクションに追加する。
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// 結果のプレゼンテーションをファイルに保存する。
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Excel テーブルのインポート例**

この例では、Excel ワークシートから書式設定されたテーブルを直接 PowerPoint プレゼンテーションにインポートします。

ソース Excel ワークシートには、従業員データを含む書式設定済みテーブルがあります:

![Excel テーブル例](example4_image0.png)

```csharp
// 新しい PowerPoint プレゼンテーションを作成する。
using Presentation presentation = new Presentation();

// 最初のスライドのシェイプコレクションを取得する。
IShapeCollection shapes = presentation.Slides[0].Shapes;

// ワークブックの最初のシートからテーブルをインポートし、シェイプコレクションに追加する。
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// 結果のプレゼンテーションをファイルに保存する。
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![結果](example4_image1.png)


## **まとめ**

Aspose.Slides に直接組み込まれたこの機構により、Excel データとプレゼンテーションを一元的に扱うことができます。追加のライブラリや複雑な統合なしに、視覚的なチャートや Excel テーブルとして提示されたデータを含むスライドを作成できるようになります。