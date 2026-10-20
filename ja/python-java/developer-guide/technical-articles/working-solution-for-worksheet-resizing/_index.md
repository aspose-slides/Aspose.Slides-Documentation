---
title: ワークシートのリサイズに対する実践的解決策
type: docs
weight: 20
url: /ja/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- プレビュー画像
- 画像リサイズ
- Excel
- ワークシート
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "プレゼンテーションでの Excel ワークシート OLE リサイズを修正します：オブジェクト フレームを一貫させるための 2 つの方法—フレームをスケーリングするかシートをスケーリングするか—PPT と PPTX 形式全体で対応。"
---
{{% alert color="info" title="Note" %}}

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel ワークシートは、最初にアクティブ化された後に予期せずサイズが変更されることがあります。この動作により、OLE オブジェクトのアクティブ化前後で目立つ視覚的な違いが生じます。本記事ではこの問題を説明し、対処方法を 2 つ紹介します。

{{% /alert %}}

## **背景**

[OLE の管理](/slides/ja/python-java/manage-ole/) 記事では、Aspose.Slides for Python via Java を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。[オブジェクト プレビューの問題](/slides/ja/python-java/object-preview-issue-when-adding-oleobjectframe/) に対処するため、選択したワークシート領域の画像を OLE オブジェクト フレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示する OLE オブジェクト フレームをダブルクリックすると Excel ブックがアクティブ化されます。エンド ユーザーは実際の Excel ブックで任意の変更を行い、アクティブ化された Excel ブックの外側をクリックしてスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクト フレームのサイズが変わります。リサイズ率は OLE オブジェクト フレームのサイズと埋め込まれた Excel ブックのサイズに依存します。

## **リサイズの原因**

Excel ブックは独自のウィンドウ サイズを持っているため、最初のアクティブ化時に元のサイズを保持しようとします。一方、OLE オブジェクト フレームは独自のサイズを持ちます。Microsoft によると、Excel ブックがアクティブ化されると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一部として正しい比率を維持します。リサイズは Excel ウィンドウ サイズと OLE オブジェクト フレームのサイズおよび位置の差異に基づいて発生します。

## **動作する解決策**

リサイズ効果を回避するための 2 つの可能な解決策があります。

- PowerPoint プレゼンテーション内の OLE フレームを、選択した行と列の合計の高さと幅に合わせてスケールする。
- OLE フレームのサイズを一定に保ち、選択した行と列をフレーム内に収まるようにスケールする。

### **OLE フレームのサイズをスケールする**

この方法は、埋め込まれた Excel ワークシートの選択した行と列の合計の高さと幅に合わせて OLE フレームのサイズを設定します。

例では既存の Excel ブックを読み込み、0 ベースのインデックスを使用して最初のシートの最初の 10 行と 13 列を選択します。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) が表示領域を定義します。プレビューは 96 DPI でレンダリングされ、そのピクセル寸法は 1 インチあたり 72 ポイントでポイントに変換されます。[ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) が変更されたブックをその寸法のフレームに埋め込みます。プレビューは [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) を通じて割り当てられ、保存されたプレゼンテーションの「EMBEDDED OLE OBJECT」プレースホルダーを置き換えます。

プレビュー ヘルパーは [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) を選択した範囲に設定し、余白、ヘッダー、フッターを除去します。[ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) を有効にし、[SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) が範囲を PNG 画像としてレンダリングします。ヘルパーは PNG 画像を含む新しい入力ストリームを返し、プレゼンテーションで使用できるように先頭に配置します。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # PowerPoint でブックが OLE オブジェクトとして使用される際の表示サイズを設定します。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # OLE 画像の幅と高さをポイント単位で取得します。
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # 変更したブックを使用します。
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # OLE 画像をプレゼンテーションのリソースに追加します。
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE オブジェクト フレームを作成します。
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **セル範囲のサイズをスケールする**

この方法は、選択した行の高さと列の幅をカスタム OLE フレーム サイズに合わせてスケールします。

例では既存の Excel ブックを読み込み、0 ベースのインデックスを使用して最初のシートの最初の 10 行と 13 列を選択します。[WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) が表示領域を定義し、scale_cell_range ヘルパーがその範囲を幅 400 ポイント、高さ 100 ポイントのフレームに収まるようにスケールします。変更されたブックをストリームに保存した後、[ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) が指定サイズで埋め込みます。96 DPI でレンダリングされたプレビューは [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) を通じて割り当てられ、保存されたプレゼンテーションはデフォルトのプレースホルダーではなく選択されたセルを表示します。

スケーリング ヘルパーは、選択範囲の幅と高さの比率を個別に計算し、列の相対幅と行の相対高さを保持します。計算された寸法はポイントからインチに変換され、[Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) と [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch) を使用して適用されます。選択範囲の幅と高さはゼロであってはなりません。

このプレビュー ヘルパーは [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) を使用してサイズ変更された範囲をレンダリングします。[PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) をその範囲に限定し、余白、ヘッダー、フッターを除去し、PNG ストリームを先頭に配置して返します。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # セル範囲の期待幅と高さはポイント単位です。
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # ブックが PowerPoint の OLE オブジェクトとして使用される際の表示サイズを設定します。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # セル範囲をフレームサイズに合わせてスケールします。
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # 変更したブックを使用します。
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # OLE 画像をプレゼンテーションのリソースに追加します。
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # OLE オブジェクト フレームを作成します。
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **結論**

{{% alert color="info" title="Note" %}} 

ワークシートのリサイズ問題を解決する方法は 2 つあります。要件や使用シーンに最適な方法を選んでください。どちらの方法も、テンプレートから作成したプレゼンテーションでもゼロから作成したプレゼンテーションでも同じように機能します。さらに、このソリューションでは OLE オブジェクト フレームのサイズに制限はありません。

{{% /alert %}}

## **FAQ**

**埋め込まれた Excel ワークシートが PowerPoint で最初にアクティブ化されたときにサイズが変わるのはなぜですか？**

Excel はアクティブ化時に元のウィンドウサイズを維持しようとし、PowerPoint の OLE オブジェクト フレームは独自の寸法を持つためです。PowerPoint と Excel がサイズを協議してアスペクト比を保つため、リサイズが発生します。

**このリサイズ問題を完全に防ぐことは可能ですか？**

はい。OLE フレームを Excel セル範囲のサイズに合わせてスケールするか、セル範囲を目的の OLE フレームサイズに合わせてスケールすれば、不要なリサイズを防止できます。

**どちらのスケーリング手法を使用すべきですか、OLE フレームのスケーリングですかセル範囲のスケーリングですか？**

元の Excel 行・列のサイズを保持したい場合は **OLE フレームのスケーリング** を選択してください。プレゼンテーションで OLE フレームのサイズを固定したい場合は **セル範囲のスケーリング** を選択してください。

**プレゼンテーションがテンプレートベースの場合でもこれらの解決策は機能しますか？**

はい。両方の解決策はテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも機能します。

**これらの方法を使用する際、OLE フレームのサイズに制限はありますか？**

いいえ。スケールを適切に設定すれば、OLE オブジェクト フレームのサイズに制限はありません。

**PowerPoint の「EMBEDDED OLE OBJECT」プレースホルダー テキストを回避する方法はありますか？**

はい。対象となる Excel セル範囲のスナップショットを取得し、それを OLE フレームのプレースホルダー画像として設定すれば、デフォルトのプレースホルダーの代わりにカスタム プレビュー画像を表示できます。

## **関連記事**

[Excel グラフを作成し、OLE オブジェクトとしてプレゼンテーションに埋め込む](/slides/ja/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[MS PowerPoint アドインを使用して OLE オブジェクトを自動的に更新する](/slides/ja/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)