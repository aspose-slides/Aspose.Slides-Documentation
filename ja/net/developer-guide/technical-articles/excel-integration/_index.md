---
title: PowerPoint プレゼンテーションに Excel データを統合する
linktitle: Excel 統合
type: docs
weight: 330
url: /ja/net/excel-integration/
keywords:
- Excel
- ワークブック
- Excel を読み取る
- Excel を統合する
- データ ソース
- 差し込み印刷
- テーブルのインポート
- Excel を PowerPoint に
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides の ExcelDataWorkbook API を使用して Excel ワークブックからデータを読み取ります。シートとセルを読み込み、値を使用してデータ駆動型 PowerPoint プレゼンテーションを生成します。"
---

## **イントロダクション**

PowerPoint プレゼンテーションは、情報を表示し伝えるための強力な手段です。Excel ワークブックと組み合わせて使用されることが多く、Excel は構造化データの優れたソースとして機能し、PowerPoint はそのデータを聴衆向けに可視化するのに優れています。

Excel と PowerPoint を組み合わせることが不可欠な実用的シナリオは多数あります。たとえば、差し込み印刷、データテーブルへの入力、レコードごとにスライドを生成するバッチスライド生成、トレーニング資料の作成、複数の Excel レポートを単一のプレゼンテーションに統合する、などがあります。

これまで、Aspose.Slides API でこれらの機能を実装するには、Aspose.Cells のようなサードパーティー ソリューションに依存する必要がありました。これらのツールは高機能ですが、基本的なデータ統合機能だけを必要とするユーザーにとっては過剰でコストがかかります。

## **仕組み**

Excel データの操作をより簡単かつスムーズにするため、Aspose.Slides は Excel ワークブックからデータを読み取り、プレゼンテーションにコンテンツをインポートするための新しいクラスを導入しました。この機能により、プレゼンテーション ワークフロー内でデータ ソースとして Excel を活用したい API ユーザーに強力な新しい可能性が開かれます。

新機能は汎用的なデータアクセス向けに設計されており、Presentation Document Object Model (DOM) には統合されていません。つまり、*Excel ファイルの編集や保存はできません* — 目的はワークブックを開き、その内容をナビゲートしてセル データを取得することだけです。

この機能の中心となるのは新しい[ExcelDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldataworkbook/)クラスです。このクラスを使ってローカル ファイルまたはストリームから Excel ワークブックをロードできます。ロード後は、位置（行・列インデックスや名前付き範囲）で特定のセルを取得できる[GetCell](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldataworkbook/getcell/)メソッドの複数のオーバーロードが利用可能です。

各[GetCell](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldataworkbook/getcell/)呼び出しは[ExcelDataCell](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldatacell/)クラスのインスタンスを返します。このオブジェクトは Excel ワークブック内の単一セルを表し、シンプルで直感的な方法でその値にアクセスできます。

#### **Excel グラフのインポート**

機能拡張の次のステップは[ExcelWorkbookImporter](https://reference.aspose.com/slides/net/aspose.slides.import/excelworkbookimporter/)クラスです。このユーティリティ クラスは、Excel ワークブックからプレゼンテーションへのコンテンツ インポート機能を提供します。指定した Excel ワークブックから選択したグラフを取得し、指定座標のシェイプ コレクションの末尾に追加する[AddChartFromWorkbook](https://reference.aspose.com/slides/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/)メソッドの複数のオーバーロードが含まれています。

要するに、これはフル スプレッドシート処理ライブラリのオーバーヘッドなしに、Excel データを読み取るための軽量でシンプルな API です。

## **コードを書いてみよう**

### **差し込み印刷シナリオの例**

以下の例では、Excel ワークブックに格納されたデータに基づいて複数のプレゼンテーションを生成するシンプルな差し込み印刷シナリオを実装します。

始めるにあたって必要なものは 2 つです。
1. データを含む Excel ワークブック

![Excel data example](example1_image0.png)

2. PowerPoint プレゼンテーション テンプレート

![PowerPoint template example](example1_image1.png)
```csharp
// 従業員データを含む Excel ワークブックをロードします。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// プレゼンテーションテンプレートをロードします。
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Excel 行をループ処理します（行 0 のヘッダーは除外）。
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // 各従業員レコードごとに新しいプレゼンテーションを作成します。
    using Presentation employeePresentation = new Presentation();

    // デフォルトの空白スライドを削除します。
    employeePresentation.Slides.RemoveAt(0);

    // テンプレートスライドを新しいプレゼンテーションにクローンします。
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // ターゲット シェイプから段落を取得します（シェイプ インデックス 1 が使用されていると想定）。
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


![Result](example1_image2.png)

### **Excel テーブルの例**

2 番目の例では、Excel テーブルからデータをコピーし、PowerPoint スライド上により視覚的に魅力的な形式で表示します。

この例では、最初の例と同じ Excel ワークブック（シンプルな従業員テーブルを含む）を再利用します。
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

// Excel ワークブックからデータを取得して PowerPoint テーブルに埋め込みます。
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// 作成したプレゼンテーションをファイルに保存します。
presentation.Save("Table.pptx", SaveFormat.Pptx);
```


![Result](example2_image0.png)

### **Excel グラフのインポート例**

この例では、前の例で使用した Excel ワークブックの最初のワークシートからグラフをインポートします。結果のプレゼンテーションでは、グラフが外部ワークブックにリンクされます。

まず、従業員テーブルに基づいて Excel ワークブックに円グラフを追加します。

![Excel Chart example](example3_image0.png)
```csharp
// 新しい PowerPoint プレゼンテーションを作成します。
using Presentation presentation = new Presentation();

// 最初のスライドのシェイプ コレクションを取得します。
IShapeCollection shapes = presentation.Slides[0].Shapes;

// ワークブックの最初のシートから名前が "Chart 1" のチャートをインポートし、シェイプ コレクションに追加します。
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// 作成したプレゼンテーションをファイルに保存します。
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```

![Result](example3_image1.png)

### **すべての Excel グラフをインポートする例**

Excel ワークブックに多数のグラフがあり、すべてをプレゼンテーションにインポートしたいと想像してください。各グラフは新しいスライドに配置されます。

以下のコードはソース Excel ファイルのすべてのワークシートを走査し、各ワークシートからグラフを抽出して、空白スライド レイアウトを使用して個別のスライドに追加します。結果のプレゼンテーションには、グラフ データのみが埋め込まれ、ワークブック全体は埋め込まれません。
```csharp
// 従業員データを含む Excel ワークブックをロードします。
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// 新しい PowerPoint プレゼンテーションを作成します。
using Presentation presentation = new Presentation();

// 空白スライドのレイアウトを取得します。
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Excel ワークブックに含まれるすべてのワークシート名を取得します。
IList<string> worksheetNames = workbook.GetWorksheetNames();
foreach (var name in worksheetNames)
{
    // ワークシート内のチャートインデックスとチャート名をマッピングする辞書を取得します。
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // 空白レイアウトを使用して新しいスライドを追加します。
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // 指定されたチャートを Excel ワークブックからスライドのシェイプ コレクションにインポートします。
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// 作成したプレゼンテーションをファイルに保存します。
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```


## **まとめ**

Aspose.Slides に直接組み込まれたこの機構により、Excel データとプレゼンテーションを一元的に操作できます。追加ライブラリや複雑な統合なしで、Excel テーブルとしてのデータと視覚的なグラフを備えたスライドを作成できます。