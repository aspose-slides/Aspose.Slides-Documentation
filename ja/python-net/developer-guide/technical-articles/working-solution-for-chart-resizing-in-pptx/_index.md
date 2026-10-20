---
title: PPTX におけるチャートサイズ変更の実践的解決策
type: docs
weight: 60
url: /ja/python-net/working-solution-for-chart-resizing-in-pptx/
keywords:
- チャートリサイズ
- Excel チャート
- OLE オブジェクト
- チャート埋め込み
- PowerPoint
- プレゼンテーション
- Python via .NET
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して埋め込まれた Excel OLE オブジェクトで PPTX の予期しないチャートサイズ変更を修正します。チャートと OLE フレームのサイズを一致させるために、固定のチャート寸法を設定します。"
---
## **概要**

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel チャートは、最初にアクティブ化された後にサイズが変わることがあります。これにより、アクティブ化前後でチャートの外観に顕著な違いが生じることがあります。本記事では、サイズ変更が発生する理由を説明し、固定チャート寸法を OLE フレームに合わせることでそれを防止する方法を示します。

[プレゼンテーションに Excel チャートを作成し OLE オブジェクトとして埋め込む](/slides/ja/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) では、Aspose.Cells for Python via .NET を使用して Excel チャートを作成し、Aspose.Slides for Python via .NET を使用して PowerPoint プレゼンテーションに埋め込む方法を説明しました。[オブジェクト プレビューの問題](/slides/ja/python-net/object-preview-issue-when-adding-oleobjectframe/) に対処するため、チャート画像をチャートの OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、チャート画像が表示された OLE オブジェクトフレームをダブルクリックすると、Excel チャートがアクティブ化されます。ユーザーは埋め込まれた Excel ワークブックを編集でき、アクティブ化されたワークブックの外側をクリックするとスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わり、リサイズ係数は OLE オブジェクトフレームと埋め込まれた Excel ワークブックの元のサイズに応じて変わります。

## **サイズ変更の原因**

埋め込まれた Excel ワークブックは独自のウィンドウサイズを持ち、オブジェクトが最初にアクティブ化されたときに Excel はそのサイズを保持しようとします。スライド上の OLE フレームは別個に定義されたサイズです。Excel ワークブックがアクティブ化されると、Excel と PowerPoint は埋め込みプロセスの一環としてオブジェクトのサイズと比率を維持するためにサイズ調整を行います。そのため、ワークブックウィンドウと OLE フレームの差異がオブジェクトのリサイズを引き起こすことがあります。

## **動作するソリューション**

チャートサイズをスライド上の OLE フレームに合わせ、チャートの寸法をワークブックウィンドウから独立させます。このソリューションは新規プレゼンテーションまたは既存のテンプレートのいずれでも機能します。

この例では Aspose.Cells for Python via .NET と Aspose.Slides for Python via .NET が必要です。アクティブなチャート シートにシンプルな縦棒グラフを作成し、ワークブックを XLS 形式で埋め込みます。チャートのプレビュー画像は割り当てられません。チャートは PowerPoint で OLE オブジェクトがアクティブ化されたときに表示されます。

この例では、左端から 0.5 インチ、上端から 1 インチの位置に 9.5 × 4 インチの OLE フレームを配置した新規プレゼンテーションを作成します。スライドの座標とサイズはポイント単位（1 インチあたり 72 ポイント）です。既存のプレゼンテーションについては、[テンプレートの使用](#use-a-template) を参照してください。

## **固定チャートサイズの設定**

[size_with_window](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/size_with_window/) を false に設定して、チャートの寸法をワークブックウィンドウから独立させます。[chart_object](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/chart_object/) の寸法は [width](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/width/) と [height](https://reference.aspose.com/cells/python-net/aspose.cells.drawing/shape/height/) で設定し、1 インチあたり 96 ピクセルでポイントをピクセルに変換します。684 × 288 ポイントのフレームは 912 × 384 ピクセルのチャートに相当します。[print_size](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chart/print_size/) を [PrintSizeType](https://reference.aspose.com/cells/python-net/aspose.cells/printsizetype/) の CUSTOM 値に設定します。この例では [add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/add_ole_object_frame/) でワークブックを埋め込み、9.5 × 4 インチの OLE フレームでプレゼンテーションを保存します。

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "Data"
data_sheet.cells.get("A1").put_value(10)
data_sheet.cells.get("A2").put_value(20)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, 20, 10)
chart = chart_sheet.charts[chart_index]
chart.n_series.add("Data!A1:A2", True)
workbook.worksheets.active_sheet_index = chart_sheet_index

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # スライドの座標とサイズはポイント単位です（1 インチあたり 72 ポイント）。
    width = 684.0  # 9.5 インチ。
    height = 288.0  # 4 インチ。

    chart.size_with_window = False
    # ポイントを 1 インチあたり 96 ピクセルとしてチャートのピクセルに変換します。
    chart.chart_object.width = int(width / 72 * 96)
    chart.chart_object.height = int(height / 72 * 96)
    chart.print_size = cells.PrintSizeType.CUSTOM

    with io.BytesIO() as workbook_stream:
        workbook.save(workbook_stream, cells.SaveFormat.EXCEL_97_TO_2003)
        data_info = slides.dom.ole.OleEmbeddedDataInfo(workbook_stream.getvalue(), "xls")
        slide.shapes.add_ole_object_frame(36, 72, width, height, data_info)

    presentation.save("chart-fixed-size.pptx", slides.export.SaveFormat.PPTX)
```

## **テンプレートの使用**

既存のプレゼンテーションでもサイズ計算ロジックは同じです。例を適用するには：

1. 空のプレゼンテーションを作成する代わりにテンプレート プレゼンテーションを読み込みます。
1. 最初のスライドに少なくとも 3 つのシェイプがあることを確認し、インデックス 2 のシェイプをプレースホルダーとして使用します。
1. 固定値の 684 と 288 の代わりにそのシェイプからフレームの幅と高さを取得します。サイズ計算は変更しません。
1. 固定座標の 36 と 72 の代わりにプレースホルダーの位置に OLE フレームを追加します。
1. プレゼンテーションを保存する前にプレースホルダーを削除します。

## **よくある質問**

**PowerPoint でアクティブ化した後、埋め込まれた Excel チャートのサイズが変わるのはなぜですか？**  
Excel は最初にアクティブ化されたときに元のウィンドウサイズを復元しようとしますが、PowerPoint の OLE オブジェクトフレームは独自のサイズを持っています。PowerPoint と Excel がアスペクト比を維持しながらサイズを調整するため、リサイズが発生します。

**チャートと OLE フレームのサイズを一致させるにはどうすればよいですか？**  
チャートの固定寸法を OLE フレームに合わせ、埋め込む前にカスタムのチャート印刷サイズを設定します。上記の例に必要な設定と単位変換が示されています。

**ワークブックウィンドウのサイズを合わせるだけで十分ですか？**  
ワークブックウィンドウのサイズを合わせるだけでは、アクティブ化後に OLE フレームのサイズが変わるのを確実に防げません。例に示すように固定チャート寸法を使用してください。

**このソリューションはテンプレートベースのプレゼンテーションと新規プレゼンテーションの両方で機能しますか？**  
はい。テンプレートを使用する場合はプレースホルダーの寸法と位置を使用し、新規プレゼンテーションの場合はフレームの寸法と位置を直接指定します。

**他のスプレッドシートプログラムで作成したチャートでもこの例を使用できますか？**  
この例は Aspose.Cells で作成した Excel ワークブックを使用しています。他のスプレッドシートプログラムでのアクティブ化動作は示していません。

## **関連セクション**

- [プレゼンテーションに Excel チャートを作成し OLE オブジェクトとして埋め込む](/slides/ja/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [PowerPoint アドインを使用して OLE オブジェクトを自動的に更新](/slides/ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)