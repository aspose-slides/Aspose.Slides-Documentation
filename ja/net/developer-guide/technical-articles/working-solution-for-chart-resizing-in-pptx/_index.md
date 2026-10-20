---
title: PPTX のチャートリサイズに対する実用的な解決策
type: docs
weight: 60
url: /ja/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- チャート リサイズ
- Excel チャート
- OLE オブジェクト
- 埋め込みチャート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して埋め込み Excel OLE オブジェクトを利用する際に発生する PPTX の予期しないチャートリサイズを修正します。チャートと OLE フレームのサイズを一貫させるために、固定チャート寸法を設定します。"
---
## **背景**

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel チャートは、最初にアクティブ化された後にサイズが変わることがあります。これにより、アクティブ化前後でチャートの見た目に目立つ差が生じます。本記事ではリサイズが発生する原因を説明し、固定チャートサイズを OLE フレームに合わせることでそれを防ぐ方法を示します。

[Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ja/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) では、Aspose.Cells for .NET を使用して Excel チャートを作成し、Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションに埋め込む方法を説明しました。[object preview issue](/slides/ja/net/object-preview-issue-when-adding-oleobjectframe/) に対処するため、チャート画像をチャートの OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、チャート画像を表示している OLE オブジェクトフレームをダブルクリックすると Excel チャートがアクティブ化されます。ユーザーは埋め込まれた Excel ワークブックを編集でき、アクティブ化されたワークブックの外側をクリックするとスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わり、リサイズ係数は OLE オブジェクトフレームと埋め込まれた Excel ワークブックの元のサイズに依存します。

## **リサイズの原因**

埋め込まれた Excel ワークブックには独自のウィンドウ寸法があり、Excel はオブジェクトが最初にアクティブ化されたときにそのサイズを保持しようとします。スライド上の OLE フレームは別個に定義された寸法を持ちます。Excel ワークブックがアクティブ化されると、Excel と PowerPoint は埋め込みプロセスの一部としてオブジェクトのサイズと比例を保つために交渉します。ワークブックウィンドウと OLE フレームの違いがオブジェクトのリサイズを引き起こす可能性があります。

## **動作する解決策**

チャートサイズをスライド上の OLE フレームに合わせ、チャートの寸法をワークブックウィンドウから独立させます。このソリューションは新規プレゼンテーションでも既存テンプレートでも機能します。

この例は Aspose.Cells for .NET と Aspose.Slides for .NET が必要です。アクティブなチャートシートにシンプルな縦棒グラフを作成し、ブックを XLS 形式で埋め込みます。チャートプレビュー画像は割り当てず、PowerPoint で OLE オブジェクトがアクティブ化されたときにチャートが表示されます。

例では、左端から 0.5 インチ、上端から 1 インチの位置に 9.5 × 4 インチの OLE フレームを持つ新規プレゼンテーションを作成します。スライドの座標と寸法はポイント単位 (1 インチ＝72 ポイント) です。既存プレゼンテーションの場合は、[Use a Template](#use-a-template) を参照してください。

## **固定チャートサイズの設定**

[SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) を false に設定し、チャートの寸法をワークブックウィンドウから独立させます。[ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) の寸法は [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) と [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/) で設定し、96 ピクセル／インチを使用してポイントをピクセルに変換します。たとえばフレーム 684 × 288 ポイントは 912 × 384 ピクセルに相当します。[PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) を [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/) の Custom 値に設定します。例では [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) を使用してブックを埋め込み、9.5 × 4 インチの OLE フレームでプレゼンテーションを保存します。

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// スライドの座標とサイズはポイント単位です（1 インチ = 72 ポイント）。
var width = 684f; // 9.5 インチ。
var height = 288f; // 4 インチ。

chart.SizeWithWindow = false;
// ポイントをインチ当たり 96 ピクセルで計算し、チャートのピクセルに変換します。
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **テンプレートの使用**

既存プレゼンテーションでもサイズ調整ロジックは同じです。例を適用する手順は以下の通りです。

1. 空のプレゼンテーションを作成する代わりにテンプレートプレゼンテーションを読み込みます。  
2. 最初のスライドに少なくとも 3 つのシェイプがあることを確認し、インデックス 2 のシェイプをプレースホルダーとして使用します。  
3. フレームの幅と高さを固定値 684 と 288 の代わりにそのシェイプから取得します。サイズ計算はそのまま残します。  
4. 固定座標 36 と 72 の代わりにプレースホルダーの位置に OLE フレームを追加します。  
5. プレゼンテーションを保存する前にプレースホルダーを削除します。

## **FAQ**

**PowerPoint でアクティブ化した後、埋め込まれた Excel チャートのサイズが変わるのはなぜですか？**  
Excel は最初にアクティブ化されたときに元のウィンドウサイズを復元しようとしますが、PowerPoint の OLE オブジェクトフレームは独自の寸法を持っています。PowerPoint と Excel がサイズを交渉してアスペクト比を維持しようとするため、リサイズが発生します。

**チャートと OLE フレームのサイズを一貫させるにはどうすればよいですか？**  
固定チャート寸法を OLE フレームに合わせ、埋め込む前にカスタムのチャート印刷サイズを設定します。上記の例に示した設定と単位変換を使用してください。

**ワークブックウィンドウのサイズを合わせるだけで十分ですか？**  
ワークブックウィンドウのサイズを合わせるだけでは、アクティブ化後に OLE フレームのサイズが変わるのを確実に防げません。例に示したように固定チャート寸法を使用してください。

**このソリューションはテンプレートベースのプレゼンテーションと新規プレゼンテーションの両方で機能しますか？**  
はい。テンプレートを使用する場合はプレースホルダーの寸法と位置を利用し、新規プレゼンテーションの場合はフレームの寸法と位置を直接指定します。

**他のスプレッドシートプログラムで作成したチャートでもこの例を使用できますか？**  
この例は Aspose.Cells で作成した Excel ワークブックを使用しています。他のスプレッドシートプログラムでのアクティブ化動作は示していません。

## **関連セクション**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ja/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)  
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)