---
title: ワークシートのリサイズに対する実装ソリューション
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
description: "プレゼンテーションでの Excel ワークシート OLE リサイズを修正します。オブジェクトフレームを一貫させる方法は2つ—フレームをスケールするかシートをスケールするか—PPT および PPTX 形式で適用できます。"
---
{{% alert color="info" title="Note" %}}

Excel ワークシートを OLE オブジェクトとして Aspose コンポーネント経由で PowerPoint プレゼンテーションに埋め込むと、最初にアクティブ化した後にスケールが未指定の状態でリサイズされることが確認されています。この動作により、OLE オブジェクトのアクティブ化前後でプレゼンテーションに目立つ視覚的な違いが生じます。本記事ではこの問題を詳細に調査し、解決策を提示しています。

{{% /alert %}}

## **Background**

[Manage OLE](/slides/ja/python-java/manage-ole/) 記事では、Aspose.Slides for Python via Java を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を解説しました。[object preview issue](/slides/ja/python-java/object-preview-issue-when-adding-oleobjectframe/) に対処するため、選択したワークシート領域の画像を OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、ワークシート画像を表示している OLE オブジェクトフレームをダブルクリックすると Excel ブックがアクティブ化されます。エンドユーザーは実際の Excel ブックを自由に変更でき、アクティブ化された Excel ブックの外側をクリックするとスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わります。リサイズ率は OLE オブジェクトフレームのサイズと埋め込まれた Excel ブックのサイズに応じて変動します。

## **Cause of Resizing**

Excel ブックは独自のウィンドウサイズを持っているため、最初のアクティブ化時に元のサイズを保とうとします。一方、OLE オブジェクトフレームは独自のサイズを持っています。Microsoft によると、Excel ブックがアクティブ化されると、Excel と PowerPoint がサイズを交渉し、埋め込みプロセスの一部として正しい比率を維持します。リサイズは Excel ウィンドウサイズと OLE オブジェクトフレームのサイズ・位置との差異に基づいて発生します。

## **Working Solution**

リサイズ効果を回避するための 2 つの解決策があります。

- OLE フレームのサイズを、目的の行数と列数に合わせて PowerPoint プレゼンテーション内でスケーリングする。
- OLE フレームのサイズを固定し、対象となる行と列のサイズをスケーリングしてフレーム内に収める。

### **Scale the OLE Frame Size**

この方法では、埋め込まれた Excel ブックの OLE フレームサイズを、ワークシート内の対象行と列の合計サイズに合わせて設定する方法を学びます。

テンプレートの Excel シートがあり、それを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、まずブック内の対象行の高さと対象列の幅の合計に基づいて OLE オブジェクトフレームのサイズを算出します。次に、その算出値を OLE フレームのサイズとして設定します。PowerPoint の OLE フレームに表示される赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行と列の必要な部分の画像を取得し、OLE フレームの画像として設定します。

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

    # PowerPoint で OLE オブジェクトとしてブックが使用されるときの表示サイズを設定します。
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

        # 変更されたブックを使用します。
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

            # OLE オブジェクトフレームを作成します。
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

### **Scale the Cell Range Size**

この方法では、カスタム OLE フレームサイズに合わせて対象行の高さと対象列の幅をスケーリングする方法を学びます。

テンプレートの Excel シートがあり、それを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、OLE フレームのサイズを設定し、フレーム領域に含まれる行と列のサイズをスケーリングします。その後、ブックをストリームに保存して変更を適用し、OLE フレームに追加できるバイト配列に変換します。PowerPoint の OLE フレームに表示される赤い「EMBEDDED OLE OBJECT」メッセージを回避するため、ブック内の対象行と列の必要な部分の画像を取得し、OLE フレームの画像として設定します。

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
    # セル範囲の想定幅と高さはポイント単位です。
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

    # PowerPoint でブックが OLE オブジェクトとして使用されるときの表示サイズを設定します。
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # セル範囲をフレームサイズに合わせてスケーリングします。
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # 変更されたブックを使用します。
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

            # OLE オブジェクトフレームを作成します。
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

## **Conclusion**

{{% alert color="info" title="Note" %}} 

ワークシートのリサイズ問題を解決するためのアプローチは 2 つあります。適切なアプローチの選択は、具体的な要件と使用ケースに依存します。どちらのアプローチも、テンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも同様に機能します。また、このソリューションでは OLE オブジェクトフレームのサイズに制限はありません。

{{% /alert %}}

## **FAQ**

**Why does an embedded Excel worksheet change size when first activated in PowerPoint?**

Excel がアクティブ化時に元のウィンドウサイズを維持しようとする一方、PowerPoint の OLE オブジェクトフレームは独自のサイズを持っているためです。PowerPoint と Excel がサイズを交渉してアスペクト比を保つ過程でリサイズが発生します。

**Is it possible to prevent this resizing issue entirely?**

はい。OLE フレームを Excel のセル範囲サイズに合わせてスケーリングするか、セル範囲を目的の OLE フレームサイズに合わせてスケーリングすれば、不要なリサイズを防げます。

**Which scaling method should I use, OLE frame scaling or cell range scaling?**

元の Excel の行・列サイズを保持したい場合は **OLE frame scaling** を選択してください。プレゼンテーション内で固定サイズの OLE フレームを維持したい場合は **cell range scaling** を選択してください。

**Will these solutions work if my presentation is based on a template?**

はい。どちらのソリューションもテンプレートから作成したプレゼンテーションでも、ゼロから作成したプレゼンテーションでも機能します。

**Is there a limit to the size of the OLE frame when using these methods?**

いいえ。適切にスケールを設定すれば、OLE オブジェクトフレームのサイズに制限はありません。

**Is there a way to avoid the "EMBEDDED OLE OBJECT" placeholder text in PowerPoint?**

はい。対象となる Excel セル範囲のスナップショットを取得し、それを OLE フレームのプレースホルダー画像として設定すれば、デフォルトのプレースホルダー文字列をカスタムプレビュー画像に置き換えることができます。

## **Related Articles**

[Creating an Excel Chart and Embedding It in a Presentation as an OLE Object](/slides/ja/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)