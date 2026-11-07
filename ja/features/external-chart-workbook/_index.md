---
title: 外部ブックにチャートをリンク
description: チャート データを外部ブックにリンクし、更新します。
type: docs
url: /ja/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **概要**

プレゼンテーションにすべてのソース データを埋め込むのではなく、外部ブックにチャートをポイントします。ブックのパスを設定し、そのファイルからチャートを更新するかどうかを選択できます。保存されたチャートはキャッシュされた表示データも保持できます。

## **使用例**

この C# の例は Aspose.Slides for .NET を使用しています。North = 55、South = 40 の有効な売上ブックを作成し、出力ファイルの横に sales.xlsx として書き込みます。チャートの North 値を 20 にリセットし、次にチャートをブックの絶対パスにリンクして更新します：North が再び 55 に戻ります。明示的な範囲はヘッダーと 2 行のデータをカバーします。リンクされたチャートを再度開くか更新する際は sales.xlsx を利用可能に保持してください。プレゼンテーションはこの外部ファイルを埋め込みません。入力ファイルは不要です。*external-chart-workbook.pptx* と *external-chart-workbook.png* を保存します。ライブラリは[インストール ガイド](/slides/ja/net/installation/) を使用してインストールします。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **FAQ**

### **リンクされたファイルが存在しない場合、すべてのキャッシュ値を読み取れますか？**

Aspose.Slides for .NET 26.11 は、リンクされたブックを開かずに[保存されたチャート値を直接読み取る](/slides/ja/net/chart-workbook/#read-cached-chart-values-without-a-workbook)ことができます。これには、通常の値、X/Y 値、バブル サイズ、およびそれらのキャッシュが存在する場合のカテゴリ 値が含まれます。キャッシュ データは存在しないか古くなることがあり、完全なブックではありません。ソースからの更新には、利用可能な対応ブックが依然として必要です。他の SDK やバージョンについては、対応するチャート ガイドを確認してください。

### **外部ブックが移動された場合どうなりますか？**

チャートの外部ブック パスを新しい場所に更新し、プレゼンテーションが処理されるすべての場所でそのファイルを利用可能にしてください。ファイルが存在しない場合、完全なデータアクセス操作のためにキャッシュ データに依存しないでください。

### **リンク時にキャッシュされたチャート データを更新するかどうか選択できますか？**

はい。リンクを設定するときにチャート データを更新するかどうか選択できます。更新には利用可能な対応ブックが必要です。更新をスキップすると、ファイルから新しい値を読み取らずにリンクが記録されます。

## **ガイド**

- [ .NET でのプレゼンテーションにおけるチャート ブックの管理](/slides/ja/net/chart-workbook/)

関連機能: [データで編集可能なチャートを埋める](/slides/ja/features/chart-data-binding/).