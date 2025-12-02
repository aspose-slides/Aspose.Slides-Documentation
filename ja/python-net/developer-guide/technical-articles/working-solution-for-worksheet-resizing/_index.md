---
title: ワークシートのリサイズに対する実装ソリューション
type: docs
weight: 40
url: /ja/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- プレビュー画像
- 画像リサイズ
- Excel
- ワークシート
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "プレゼンテーションにおける Excel ワークシート OLE のリサイズを修正します。オブジェクトフレームを一貫させるための 2 つの方法—フレームをスケールするかシートをスケールするか—を PPT と PPTX 形式で提供します。"
---

{{% alert color="primary" %}} 

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel ワークシートは、最初のアクティベート後に不明なスケールにリサイズされることが確認されています。この動作により、OLE オブジェクトのアクティベート前後でプレゼンテーションに目立つ視覚的差異が生じます。本記事ではこの問題を詳細に調査し、解決策を提示しています。

{{% /alert %}} 

## **背景**

この記事[OLE の管理](/slides/ja/python-net/manage-ole/)では、Aspose.Slides for Python via .NET を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。[オブジェクト プレビューの問題](/slides/ja/python-net/object-preview-issue-when-adding-oleobjectframe/)に対処するため、選択したワークシート領域の画像を OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示している OLE オブジェクトフレームをダブルクリックすると、Excel ブックがアクティブになります。エンドユーザーは実際の Excel ブックに任意の変更を加え、アクティブ化された Excel ブックの外をクリックしてスライドに戻ることができます。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わります。リサイズ係数は OLE オブジェクトフレームと埋め込まれた Excel ブックのサイズに応じて変わります。

## **リサイズの原因**

Excel ブックは独自のウィンドウサイズを持っているため、最初のアクティベート時に元のサイズを保持しようとします。一方、OLE オブジェクトフレームは独自のサイズがあります。Microsoft によれば、Excel ブックがアクティブになると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一部として正しい比率を保つようにします。リサイズは、Excel ウィンドウサイズと OLE オブジェクトフレームのサイズおよび位置の差異に基づいて発生します。

## **実装ソリューション**

リサイズ効果を回避するために、2 つの解決策があります。

- PowerPoint プレゼンテーションで OLE フレームのサイズをスケーリングし、OLE フレーム内の希望する行数と列数の高さと幅に合わせる。
- OLE フレームのサイズを一定に保ち、対象となる行と列のサイズをスケーリングして選択した OLE フレームサイズに収める。

### **OLE フレームサイズのスケーリング**

このアプローチでは、埋め込まれた Excel ワークブックの OLE フレームサイズを、Excel ワークシート内の対象行と列の合計サイズに合わせる方法を学びます。

テンプレートの Excel シートがあり、それを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、まずブック内の対象行と列の合計行高さおよび列幅に基づいて OLE オブジェクトフレームのサイズを計算します。次に、計算された値で OLE フレームのサイズを設定します。PowerPoint で OLE フレームに表示される赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行と列の必要な部分の画像も取得し、それを OLE フレーム画像として設定します。
```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # PowerPoint で OLE オブジェクトとしてブック ファイルを使用する際の表示サイズを設定します。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # OLE 画像の幅と高さをポイント単位で取得します。
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # 変更されたブックを使用する必要があります。
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # プレゼンテーションのリソースに OLE 画像を追加します。
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # OLE オブジェクト フレームを作成します。
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


### **セル範囲サイズのスケーリング**

このアプローチでは、対象となる行の高さと列の幅をスケーリングして、カスタム OLE フレームサイズに合わせる方法を学びます。

テンプレートの Excel シートがあり、それを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、OLE フレームのサイズを設定し、OLE フレーム領域に含まれる行と列のサイズをスケーリングします。その後、変更を適用するためにブックをストリームに保存し、OLE フレームに追加するためにバイト配列に変換します。PowerPoint の OLE フレームで赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行と列の必要な部分の画像も取得し、それを OLE フレーム画像として設定します。
```py
# <param name="width">セル範囲の期待される幅（ポイント単位）。</param>
# <param name="height">セル範囲の期待される高さ（ポイント単位）。</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

```py
def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # PowerPoint で OLE オブジェクトとしてブック ファイルを使用する際の表示サイズを設定します。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # フレームサイズに合わせてセル範囲のサイズをスケーリングします。
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # 変更されたブックを使用する必要があります。
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # プレゼンテーションのリソースに OLE 画像を追加します。
            ole_image = presentation.images.add_image(image_stream)

            # OLE オブジェクト フレームを作成します。
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **結論**

{{% alert color="primary" %}}

ワークシートのリサイズ問題を解決するために 2 つのアプローチがあります。適切なアプローチの選択は、具体的な要件と使用ケースに依存します。テンプレートから作成する場合でも、ゼロから作成する場合でも、両方のアプローチは同様に機能します。さらに、このソリューションでは OLE オブジェクトフレームのサイズに制限はありません。

{{% /alert %}}