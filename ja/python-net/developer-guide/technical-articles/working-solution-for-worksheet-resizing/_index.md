---
title: ワークシートのサイズ変更に対する実装ソリューション
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
description: "プレゼンテーション内の Excel ワークシート OLE のリサイズを修正します。オブジェクト フレームを一貫させるための 2 つの方法—フレームをスケールするかシートをスケールするか—を PPT と PPTX 形式で提供します。"
---
{{% alert color="info" title="Note" %}}
Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel ワークシートは、最初にアクティブ化された後に予期せずサイズが変更されることがあります。この動作により、アクティブ化前後の OLE オブジェクト間に目立つ視覚的な違いが生じます。本記事ではこの問題を説明し、対処方法を 2 つ紹介します。
{{% /alert %}} 

## **背景**

[OLE の管理](/slides/ja/python-net/manage-ole/) 記事では、Aspose.Slides for Python via .NET を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。[オブジェクト プレビューの問題](/slides/ja/python-net/object-preview-issue-when-adding-oleobjectframe/) に対処するため、選択したワークシート領域の画像を OLE オブジェクト フレームに割り当てました。出力されたプレゼンテーションでは、ワークシート画像を表示する OLE オブジェクト フレームをダブルクリックすると Excel ブックがアクティブ化されます。エンドユーザーは実際の Excel ブックに任意の変更を加え、アクティブ化された Excel ブックの外側をクリックしてスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクト フレームのサイズが変わります。リサイズの要因は OLE オブジェクト フレームと埋め込まれた Excel ブックのサイズに応じて変わります。

## **サイズ変更の原因**

Excel ブックは独自のウィンドウサイズを持っているため、最初のアクティブ化時に元のサイズを保持しようとします。一方、OLE オブジェクト フレームは独自のサイズがあります。Microsoft によると、Excel ブックがアクティブ化されると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一部として正しい比率を維持します。リサイズは Excel ウィンドウサイズと OLE オブジェクト フレームのサイズ・位置の差異に基づいて発生します。

## **解決策**

サイズ変更の影響を回避するための 2 つの解決策があります。

- PowerPoint プレゼンテーション内の OLE フレームを、選択した行と列の合計高さと幅に合わせてスケールする。
- OLE フレームのサイズを固定したまま、選択した行と列をフレーム内に収まるようにスケールする。

### **OLE フレーム サイズのスケーリング**

このアプローチは、埋め込まれた Excel ワークシートの選択された行と列の合計高さと幅に合わせて OLE フレームのサイズを設定します。

この例では、既存の Excel ブックを読み込み、0 ベースのインデックスを使用して最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) で表示範囲を定義します。プレビューは 96 DPI でレンダリングされ、そのピクセル寸法は 1 インチあたり 72 ポイントを使用してポイントに変換されます。[ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) で、変更されたブックをその寸法のフレームに埋め込みます。プレビューは [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) を介して割り当てられ、保存されたプレゼンテーションの「EMBEDDED OLE OBJECT」プレースホルダーを置き換えます。

プレビュー ヘルパーは、[PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) を選択された範囲に設定し、余白、ヘッダー、フッターを削除します。[ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) を有効にすると、[SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) が範囲を PNG 画像としてレンダリングします。ヘルパーは画像ストリームを先頭に戻してから、プレゼンテーションで使用できるように返します。

```py
import io
import aspose.cells as cells

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

以下の完全な例は、ヘルパーとブックの埋め込みを組み合わせ、プレゼンテーションを `output.pptx` として保存します。

```py
import io
import aspose.slides as slides
import aspose.cells as cells

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

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # PowerPoint で OLE オブジェクトとして使用されるブックファイルの表示サイズを設定します。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # OLE 画像の幅と高さ（ポイント単位）を取得します。
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # 変更されたブックを使用する必要があります。
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # OLE 画像をプレゼンテーションのリソースに追加します。
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

このアプローチは、選択した行の高さと列の幅をスケーリングして、カスタム OLE フレーム サイズに合わせます。

この例では、既存の Excel ブックを読み込み、0 ベースのインデックスを使用して最初のワークシートの最初の 10 行と 13 列を選択します。[WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) が表示範囲を定義し、以下のヘルパーがその範囲を幅 400 ポイント、高さ 100 ポイントのフレームに合わせてスケーリングします。変更されたブックをストリームに保存した後、[ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) が指定されたサイズで埋め込みます。96 DPI でレンダリングされたプレビューは [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) を通じて割り当てられ、保存されたプレゼンテーションはデフォルトのプレースホルダーではなく選択されたセルを表示します。

スケーリング ヘルパーは選択範囲の幅と高さの比率を個別に計算し、列の相対幅と行の相対高さを保持します。計算された寸法をポイントからインチに変換し、[Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) と [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/) で適用します。選択範囲は幅と高さがゼロでない必要があります。

```py
import aspose.cells as cells

# <param name="width">セル範囲の幅（ポイント単位）の期待値。</param>
# <param name="height">セル範囲の高さ（ポイント単位）の期待値。</param>
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

このプレビュー ヘルパーは、[SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) を使用してリサイズされた範囲をレンダリングします。[PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) をその範囲に限定し、余白、ヘッダー、フッターを削除し、先頭に位置した PNG ストリームを返します。

```py
import io
import aspose.cells as cells

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

以下の完全な例は、ヘルパーとブックの埋め込みを組み合わせ、プレゼンテーションを `output.pptx` として保存します。

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">セル範囲の幅（ポイント単位）の期待値。</param>
# <param name="height">セル範囲の高さ（ポイント単位）の期待値。</param>
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

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # PowerPoint の OLE オブジェクトとしてブック ファイルが使用されるときの表示サイズを設定します。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # セル範囲をフレームサイズに合わせてスケーリングします。
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # 変更されたブックを使用する必要があります。
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # OLE 画像をプレゼンテーションのリソースに追加します。
            ole_image = presentation.images.add_image(image_stream)

            # OLE オブジェクト フレームを作成します。
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **結論**

{{% alert color="info" title="Note" %}}
ワークシートのサイズ変更問題を解決するためのアプローチは 2 つあります。要件とユースケースに最適なアプローチを選択してください。どちらのアプローチも、テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。さらに、このソリューションでは OLE オブジェクト フレームのサイズに制限はありません。
{{% /alert %}}

## **よくある質問**

**PowerPoint で最初にアクティブ化されたとき、埋め込まれた Excel ワークシートのサイズが変わるのはなぜですか？**

これは、Excel がアクティブ化時に元のウィンドウサイズを維持しようとする一方、PowerPoint の OLE オブジェクト フレームは独自の寸法を持つために発生します。PowerPoint と Excel がサイズを協議してアスペクト比を維持するため、リサイズが生じることがあります。

**このサイズ変更問題を完全に防止することは可能ですか？**

はい。OLE フレームを Excel のセル範囲サイズに合わせてスケーリングするか、セル範囲を目的の OLE フレームサイズに合わせてスケーリングすることで、不要なリサイズを防止できます。

**どのスケーリング方法を使用すべきですか、OLE フレームのスケーリングですか、セル範囲のスケーリングですか？**

プレゼンテーションで元の Excel の行・列サイズを維持したい場合は **OLE フレームのスケーリング** を選択してください。プレゼンテーション内で OLE フレームを固定サイズにしたい場合は **セル範囲のスケーリング** を選択してください。

**プレゼンテーションがテンプレートに基づいている場合でも、これらのソリューションは機能しますか？**

はい。両方のソリューションは、テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも機能します。

**これらの方法を使用する際、OLE フレームのサイズに制限はありますか？**

いいえ。適切にスケールを設定すれば、OLE オブジェクト フレームは任意のサイズにできます。

**PowerPoint の「EMBEDDED OLE OBJECT」プレースホルダー テキストを回避する方法はありますか？**

はい。対象の Excel セル範囲のスナップショットを取得し、それを OLE フレームのプレースホルダー画像として設定することで、デフォルトのプレースホルダーの代わりにカスタムプレビュー画像を表示できます。