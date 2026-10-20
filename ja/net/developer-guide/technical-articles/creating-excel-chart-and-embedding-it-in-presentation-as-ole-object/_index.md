---
title: Excel チャートを作成し、OLE オブジェクトとしてプレゼンテーションに埋め込む
type: docs
weight: 50
url: /ja/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel チャート
- チャートの埋め込み
- OLE オブジェクト
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Cells for .NET を使用して Excel チャートを作成し、Aspose.Slides を使用してブックを PowerPoint プレゼンテーションに埋め込み、チャートのプレビューも含めます。"
---
## **概要**

この記事では、Aspose.Cells for .NET を使用して Excel の縦棒グラフを作成し、Aspose.Slides for .NET を使用してそのブックを PowerPoint プレゼンテーションに埋め込む方法を示します。埋め込まれたブックには、ソース データとグラフの両方が含まれます。OLE オブジェクトがアクティブになる前に、スライド上にチャートを表示する PNG プレビューが別途表示されます。結果として得られるのは、ネイティブの PowerPoint グラフではなく、埋め込み Excel オブジェクトです。OLE 経由でブックを編集するには、OLE アクティベーションに対応したデスクトップ アプリケーションと、適切な Excel がインストールされている必要があります。

## **前提条件**

C# プロジェクトに Aspose.Cells for .NET と Aspose.Slides for .NET の参照を追加します。このサンプルはトップレベルステートメントを使用し、C# 9 以降が必要です。これらのライブラリを使用してプレゼンテーションを生成するために Microsoft Office は必要ありません。入力ファイルは不要です。サンプルはメモリ上でデータとチャートを作成し、`OutputChart.pptx` を現在の作業ディレクトリに書き込みます。評価モード以外で実行する場合は、両製品のライセンスを適用してください。

## **埋め込みの仕組み**

1. データ ワークシートとチャート シートを持つブックを作成します。
1. ブックがチャートで開くように、チャート シートをアクティブにします。
1. ブックの OLE 表示範囲を設定し、チャートを PNG にレンダリングします。
1. ブックをメモリ上で XLSX として保存し、そのバイト列をスライドに埋め込みます。
1. PNG を OLE オブジェクトのプレビューとして割り当て、プレゼンテーションを PPTX として保存します。

ブックの表示範囲とスライド上のフレームは異なる役割を持ちます。[SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) はゼロベースの開始/終了行と列のインデックスを受け取ります。[ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) は代わりに上端行、左端列、下端行、右端列を受け取ります。この例では、右下の境界として行インデックス 55 と列インデックス 25 を使用しています；これらの値はレイアウト上の選択であり、データ行や列の数を示すものではありません。スライドのフレームはポイント単位です。この例では、スライド内に収めて中心に配置し、PNG のアスペクト比を保持します。プレビューをスライド全体に伸ばすことはありません。

## **チャートの作成と埋め込み**

以下の完全なサンプルは、`DataSheet` に 4 行 5 列の値を設定します。各行がチャート系列になります。ブックを保存する前に、`ChartSheet` をアクティブ シートとして選択します。ブックは明示的に XLSX として保存され、[OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/) に渡された `xlsx` 拡張子と一致します。PNG は中間のビットマップ変換を行わずにストリームから直接読み込まれます。[SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) を使用して割り当てることで、デフォルトの OLE プレースホルダーが置き換えられます。

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// チャートのプレビューをレンダリングし、編集可能なブックを別々にシリアライズします。
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **期待される結果**

`OutputChart.pptx` には、埋め込み Excel ブックとチャート プレビューが含まれるスライドが 1 枚あります。ブックには元のデータと 4 系列の縦棒グラフが含まれます。プレビューはスライドの中央に配置され、比例を保ったまま表示されます。

![埋め込みブックのプレビューとして表示された Excel 縦棒グラフ](excel-chart-ole-preview.png)

Excel が利用可能な対応デスクトップ PowerPoint 環境では、オブジェクトをダブルクリックして埋め込みブックをアクティブ化および編集できます。アクティブ化と編集は、ホスト アプリケーションの OLE サポートとセキュリティ設定に依存します。

## **よくある質問**

**プレビュー画像が必要な理由は何ですか？**  
埋め込みブックとそのスライド プレビューは別々のコンテンツです。デフォルトの "EMBEDDED OLE OBJECT" プレースホルダーの代わりにチャート画像を提供すると、スライドにチャートが表示されます。[OleObjectFrame を追加する際のオブジェクト プレビューの問題](/slides/ja/net/object-preview-issue-when-adding-oleobjectframe/)

**コードでブックを変更したときにプレビューは自動的に更新されますか？**  
プレビューはスナップショットとして扱ってください。プログラムでブックのデータを更新する場合は、チャート画像を再生成し、プレビューと埋め込みブック データの両方を置き換える必要があります。

**XLS を使用できますか、XLSX の代わりに？**  
はい。ブックを XLS 形式で保存し、埋め込みデータの拡張子として `xls` を使用します。拡張子は実際のブック形式と一致する必要があり、拡張子だけを変更してもデータは変換されません。

**アクティブ化後にオブジェクトのサイズが変わるのはなぜですか？**  
ホスト アプリケーションは、ブックをアクティブ化する際に OLE オブジェクトの表示を更新することがあります。ブックの OLE 表示範囲とスライド フレームのサイズの両方が影響します。[PPTX におけるチャートサイズ変更の実装例](/slides/ja/net/working-solution-for-chart-resizing-in-pptx/)

## **関連セクション**

- [PPTX におけるチャートサイズ変更の実装例](/slides/ja/net/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame を追加する際のオブジェクト プレビューの問題](/slides/ja/net/object-preview-issue-when-adding-oleobjectframe/)
- [PowerPoint アドインで OLE オブジェクトを自動的に更新](/slides/ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)