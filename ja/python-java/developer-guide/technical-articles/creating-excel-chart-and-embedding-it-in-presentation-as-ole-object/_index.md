---
title: Excel チャートを作成し、OLE オブジェクトとしてプレゼンテーションに埋め込む
type: docs
weight: 30
url: /ja/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel チャート
- チャートを埋め込む
- OLE オブジェクト
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Cells for Python via Java を使用して Excel チャートを作成し、Aspose.Slides を使用して PowerPoint プレゼンテーションにワークブックを埋め込み、チャートのプレビューも含めます。"
---
## **概要**

この記事では、Aspose.Cells for Python via Java を使用して Excel の縦棒グラフを作成し、Aspose.Slides for Python via Java を使用してそのワークブックを PowerPoint プレゼンテーションに埋め込む方法を示します。埋め込まれたワークブックにはソースデータとチャートの両方が含まれます。別の PNG プレビューが、OLE オブジェクトが有効化される前にスライド上にチャートを表示します。

結果は PowerPoint のネイティブチャートではなく、埋め込まれた Excel オブジェクトです。OLE を介してワークブックを編集するには、OLE 有効化をサポートするデスクトップアプリケーションと、対応する Excel のインストールが必要です。

## **前提条件**

`aspose-cells` および `aspose-slides-java` Python パッケージと、対応する Java ランタイムをインストールします。JVM を起動する前に両パッケージをインポートし、Java ライブラリが JPype から利用できるようにします。これらのライブラリだけでプレゼンテーションを生成できるため、Microsoft Office は必須ではありません。

入力ファイルは不要です。サンプルはデータとチャートをメモリ上に作成し、`OutputChart.pptx` をカレント ワーキング ディレクトリに書き出します。評価モード以外で実行する場合は、両製品のライセンスを適用してください。

## **埋め込みの仕組み**

1. データ ワークシートとチャート シートを持つワークブックを作成します。
2. チャート シートをアクティブにして、ワークブックがチャートで開くようにします。
3. ワークブックの OLE 表示範囲を設定し、チャートを PNG にレンダリングします。
4. ワークブックをメモリ上の XLSX として保存し、そのバイト列をスライドに埋め込みます。
5. PNG を OLE オブジェクトのプレビューとして割り当て、プレゼンテーションを PPTX として保存します。

ワークブックの表示範囲とスライド上のフレームは役割が異なります。[setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) は 0 ベースの開始/終了行・列インデックスを受け取ります。一方、[ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) は上端行・左端列・下端行・右端列を指定します。サンプルでは下右端の境界として行インデックス 55、列インデックス 25 を使用していますが、これはレイアウト上の選択であり、データ行や列の数を表すものではありません。

スライドのフレームはポイント単位です。サンプルはスライド内に収め、PNG のアスペクト比を保持しながら中央揃えにしています。プレビューをスライド全体に伸ばすことはありません。

## **チャートの作成と埋め込み**

以下の完全なサンプルは、`DataSheet` に 4 行 5 列の値を入力します。各行がチャートのシリーズになります。`ChartSheet` をアクティブ シートとして選択した後にワークブックを保存します。

ワークブックは明示的に XLSX として保存され、`xlsx` 拡張子が [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) に渡されます。Java バイト配列ストリームにより、ワークブックと画像がメモリ上に保持され、Java API が要求するバイト配列が提供されます。PNG は中間のビットマップ変換なしでバイト列から直接ロードされます。[getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) を介して割り当てることで、デフォルトの OLE プレースホルダーが置き換えられます。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # チャートプレビューをレンダリングし、編集可能なワークブックを別々にシリアライズします。
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # アスペクト比を変更せずにプレビューをスライド内に収めます。
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **期待結果**

`OutputChart.pptx` には、埋め込まれた Excel ワークブックとチャート プレビューを含む 1 枚のスライドが含まれます。ワークブックには元データと 4 系列の縦棒グラフが格納されています。プレビューはスライドの中央に配置され、比例を保ったまま表示されます。

![Excel の縦棒グラフが埋め込みワークブックのプレビューとして表示される](excel-chart-ole-preview.png)

Excel が利用可能な対応デスクトップ PowerPoint 環境では、オブジェクトをダブルクリックしてアクティブ化し、埋め込まれたワークブックを編集できます。アクティブ化と編集はホスト アプリケーションの OLE サポートとセキュリティ設定に依存します。

## **FAQ**

**なぜプレビュー画像が必要ですか？**

埋め込まれたワークブックとスライド プレビューは別々のコンテンツです。デフォルトの「EMBEDDED OLE OBJECT」プレースホルダーの代わりにチャート画像を提供して、スライドにチャートを表示させます。詳しくは[Object Preview Issue when Adding OleObjectFrame](/slides/ja/python-java/object-preview-issue-when-adding-oleobjectframe/)をご覧ください。

**コードでワークブックを変更したとき、プレビューは自動的に更新されますか？**

プレビューはスナップショットとして扱います。プログラムでワークブック データを更新した場合は、チャート画像を再生成し、プレビューと埋め込みワークブック データの両方を置き換える必要があります。

**XLS 形式で保存できますか？**

はい。ワークブックを XLS 形式で保存し、埋め込みデータ拡張子として `xls` を使用します。拡張子は実際のワークブック形式と一致させる必要があり、拡張子だけを変更してもデータは変換されません。

**オブジェクトがアクティブ化された後にサイズが変わることがありますか？**

ホスト アプリケーションは、ワークブックをアクティブ化した際に OLE オブジェクトの表示を更新することがあります。ワークブックの OLE 表示範囲とスライド フレームの寸法の両方が影響します。詳細は[Working Solution for Chart Resizing in PPTX](/slides/ja/python-java/working-solution-for-chart-resizing-in-pptx/)をご参照ください。

## **関連セクション**

- [Working Solution for Chart Resizing in PPTX](/slides/ja/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/ja/python-java/object-preview-issue-when-adding-oleobjectframe/)