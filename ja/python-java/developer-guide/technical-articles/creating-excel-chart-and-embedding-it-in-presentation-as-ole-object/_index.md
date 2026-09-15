---
title: Excelチャートを作成し、プレゼンテーションにOLEオブジェクトとして埋め込む
type: docs
weight: 30
url: /ja/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excelチャート
- チャートを埋め込む
- OLEオブジェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Pythonを使用して、Excelチャートを作成し、PowerPointおよびOpenDocumentのプレゼンテーションにOLEオブジェクトとして埋め込みます。コードサンプル付きのステップバイステップガイド。"
---
## **背景**

PowerPointでは、編集可能なチャートを使用してデータをグラフィカルに表示することが一般的です。Asposeは、Aspose.Cells for Python via Java を使用して Excel チャートの作成をサポートしており、これらのチャートは Aspose.Slides for Python via Java を介して OLE オブジェクトとして PowerPoint スライドに埋め込むことができます。本記事では、必要な手順を説明し、Aspose.Cells と Aspose.Slides を使用して Excel チャートを作成し、PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込む Python コードサンプルを提供します。

## **必要な手順**

PowerPoint スライドに Excel チャートを OLE オブジェクトとして作成し埋め込むために、以下の手順が必要です：

1. Aspose.Cells を使用して Excel チャートを作成します。
1. Aspose.Cells を使用して Excel チャートの OLE サイズを設定します。
1. Aspose.Cells を使用して Excel チャートの画像を取得します。
1. Aspose.Slides を使用して Excel チャートを PPTX プレゼンテーションに OLE オブジェクトとして埋め込みます。
1. ステップ3で取得した画像で「EMBEDDED OLE OBJECT」画像を置き換え、[object preview issue](/slides/ja/python-java/object-preview-issue-when-adding-oleobjectframe/) に対処します。
1. プレゼンテーションをディスクに PPTX 形式で保存します。

## **必要な手順の実装**

上記手順の Python 実装は以下のとおりです：

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # セル名の配列です。
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # セルデータの配列です。
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # データでセルを埋めるために新しいワークシートを追加します。
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # データシートにデータを入力します。
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # チャートシートを追加します。
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # データシートからデータ系列を使用してチャートシートにチャートを追加します。
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # チャートシートをアクティブシートとして設定します。
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # ワークブックを埋め込み OLE データとして記述します。
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# ワークブックを作成します。
workbook = Workbook()

# Excel チャートを追加します。
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# チャートの OLE サイズを設定します。
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# チャート画像を取得し、ストリームに保存します。
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# ワークブックをストリームに保存します。
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# プレゼンテーションを作成します。
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # ワークブックをスライドに追加します。
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # プレゼンテーションをディスクに保存します。
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

上記の方法で作成されたプレゼンテーションには、OLE オブジェクトフレームをダブルクリックすることでアクティブ化できる OLE オブジェクトとして Excel チャートが含まれます。

## **結論**

Aspose.Cells for Python via Java と Aspose.Slides for Python via Java を組み合わせて使用することで、Aspose.Cells がサポートする任意の Excel チャートを作成し、PowerPoint スライドに OLE オブジェクトとして埋め込むことができます。Excel チャートの OLE サイズも定義可能です。エンドユーザーは、他の OLE オブジェクトと同様に Excel チャートを編集できます。

## **関連セクション**

- [PPTX におけるチャートリサイズの実用的解決策](/slides/ja/python-java/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame を追加する際のオブジェクト プレビュー問題](/slides/ja/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **FAQ**

**Excel チャートの作成と埋め込みに使用されるライブラリはどれですか？**

Aspose.Cells for Python via Java が Excel チャートを作成し、Aspose.Slides for Python via Java がそれを PowerPoint スライドの OLE オブジェクトとして埋め込みます。

**ユーザーは埋め込まれた Excel チャートをどのように編集できますか？**

ユーザーは OLE オブジェクトフレームをダブルクリックしてチャートをアクティブ化し、他の OLE オブジェクトと同様に編集できます。

**デフォルトの OLE オブジェクト プレビューはどのように置き換えられますか？**

この例では Aspose.Cells を使用して Excel チャートの画像を取得し、それを使用して「EMBEDDED OLE OBJECT」画像を置き換えます。