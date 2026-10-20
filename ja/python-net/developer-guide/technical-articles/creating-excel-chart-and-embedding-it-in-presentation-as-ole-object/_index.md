---
title: Excel チャートを作成し、プレゼンテーションに OLE オブジェクトとして埋め込む
type: docs
weight: 50
url: /ja/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel チャート
- チャートを埋め込む
- OLE オブジェクト
- PowerPoint
- プレゼンテーション
- Python
- Python via .NET
- Aspose.Slides
description: "Aspose.Cells for Python via .NET を使用して Excel チャートを作成し、Aspose.Slides を使用して PowerPoint プレゼンテーションにブックを埋め込み、チャートのプレビューも含めます。"
---
## **概要**

この記事では、Aspose.Cells for Python via .NET を使用して Excel の縦棒グラフを作成し、Aspose.Slides for Python via .NET を使用してそのブックを PowerPoint プレゼンテーションに埋め込む方法を示します。埋め込まれたブックには元データとチャートの両方が含まれます。別の PNG プレビューが、OLE オブジェクトがアクティブになる前にスライド上にチャートを表示します。

結果は埋め込み Excel オブジェクトであり、ネイティブな PowerPoint チャートではありません。OLE 経由でブックを編集するには、OLE のアクティベーションをサポートし、対応する Excel がインストールされたデスクトップアプリケーションが必要です。

## **前提条件**

Python 環境に `aspose-cells-python` と `aspose-slides` パッケージをインストールします。これらのライブラリを使用してプレゼンテーションを生成するために Microsoft Office は必要ありません。

入力ファイルは必要ありません。サンプルはメモリ内でデータとチャートを作成し、`OutputChart.pptx` をカレントディレクトリに書き出します。評価モード以外で実行する場合は、両製品のライセンスを適用してください。

## **埋め込みの仕組み**

1. データ ワークシートとチャート シートを持つワークブックを作成します。
1. チャート シートをアクティブにし、ワークブックがチャート上で開くようにします。
3. ワークブックの OLE 表示範囲を設定し、チャートを PNG にレンダリングします。
4. ワークブックをメモリ上で XLSX として保存し、そのバイト列をスライドに埋め込みます。
5. PNG を OLE オブジェクトのプレビューとして割り当て、プレゼンテーションを PPTX として保存します。

ワークブックの表示範囲とスライド上のフレームは異なる役割を持ちます。[set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) は0ベースの開始/終了行と列のインデックスを受け取ります。[ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) は代わりに上端行、左端列、下端行、右端列を受け取ります。例では下右境界として行インデックス 55 と列インデックス 25 を使用していますが、これらの値はレイアウトの選択であり、データ行や列の数を示すものではありません。

スライドのフレームはポイント単位です。例ではスライド内に収めて中央に配置し、PNG のアスペクト比を維持するようにしています。プレビューをスライド全体に引き伸ばすことはありません。

## **チャートの作成と埋め込み**

以下の完全なサンプルは、`DataSheet` に 4 行 5 列の値を入力します。各行がチャート系列となります。ワークブックを保存する前に `ChartSheet` をアクティブ シートとして選択します。

ワークブックは明示的に XLSX として保存され、[OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) に渡された `xlsx` 拡張子と一致します。PNG は中間のビットマップ変換を行わずにストリームから直接読み込まれます。[substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) を使用して割り当てることで、デフォルトの OLE プレースホルダーが置き換えられます。

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# チャートのプレビューを描画し、編集可能なブックを別々にシリアライズします。
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # プレビューをスライド内に合わせ、アスペクト比を変更しないようにします。
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **期待結果**

`OutputChart.pptx` には、埋め込み Excel ワークブックとチャート プレビューを含む 1 枚のスライドが含まれます。ワークブックには元のデータと 4 系列の縦棒グラフが含まれます。プレビューはスライドの中央に配置され、比率が保持されます。

![埋め込みワークブックのプレビューとして表示された Excel の縦棒チャート](excel-chart-ole-preview.png)

Excel が利用可能な対応デスクトップ PowerPoint 環境では、オブジェクトをダブルクリックして埋め込みワークブックをアクティブ化および編集できます。アクティブ化と編集は、ホスト アプリケーションの OLE サポートとセキュリティ設定に依存します。

## **よくある質問**

**プレビュー画像はなぜ必要ですか？**

埋め込みワークブックとスライドのプレビューは別々のコンテンツです。デフォルトの「EMBEDDED OLE OBJECT」プレースホルダーの代わりに、スライドにチャートを表示するためにチャート画像を提供します。詳しくは[OleObjectFrame を追加する際のオブジェクト プレビューの問題](/slides/ja/python-net/object-preview-issue-when-adding-oleobjectframe/) を参照してください。

**コードでワークブックを変更したとき、プレビューは自動的に更新されますか？**

プレビューはスナップショットとして扱います。プログラムでワークブックのデータを更新する場合、チャート画像を再生成し、プレビューと埋め込みワークブック データの両方を置き換える必要があります。

**XLS を XLSX の代わりに使用できますか？**

はい。ワークブックを XLS 形式で保存し、埋め込みデータの拡張子として `xls` を使用します。拡張子は実際のワークブック形式と一致している必要があり、拡張子だけを変更してもデータは変換されません。

**アクティブ化後にオブジェクトのサイズが変わるのはなぜですか？**

ホスト アプリケーションは、ワークブックをアクティブ化した際に OLE オブジェクトの表示を更新することがあります。ワークブックの OLE 表示範囲とスライドフレームの寸法の両方が影響します。詳しくは[PowerPoint プレゼンテーションで OLE オブジェクトを自動的にサイズ変更](/slides/ja/python-net/working-solution-for-worksheet-resizing/) を参照してください。

## **関連セクション**

- [PowerPoint プレゼンテーションで OLE オブジェクトを自動的にサイズ変更](/slides/ja/python-net/working-solution-for-worksheet-resizing/)
- [OleObjectFrame を追加する際のオブジェクト プレビューの問題](/slides/ja/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [OLE オブジェクトの管理](/slides/ja/python-net/manage-ole/)