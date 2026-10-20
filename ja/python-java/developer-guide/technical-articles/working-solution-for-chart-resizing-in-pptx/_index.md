---
title: PPTX におけるチャートリサイズの実装ソリューション
type: docs
weight: 40
url: /ja/python-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- チャートリサイズ
- Excelチャート
- OLEオブジェクト
- チャート埋め込み
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して埋め込まれた Excel OLE オブジェクトで PPTX の予期しないチャートリサイズを修正します。チャートと OLE フレームのサイズを一貫させるために、固定チャート寸法を設定します。"
---
## **背景**

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel グラフは、最初にアクティブ化された後にサイズが変わることがあります。これにより、アクティブ化前後でグラフの外観に目立つ違いが生じます。本記事では、リサイズが発生する原因と、固定されたグラフサイズを OLE フレームに合わせることでそれを防止する方法を説明します。

[Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ja/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) では、Aspose.Cells for Python via Java を使用して Excel グラフを作成し、Aspose.Slides for Python via Java を使用して PowerPoint プレゼンテーションに埋め込む方法を解説しました。[object preview issue](/slides/ja/python-java/object-preview-issue-when-adding-oleobjectframe/) に対処するため、グラフ画像をチャートの OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、グラフ画像を表示する OLE オブジェクトフレームをダブルクリックすると Excel グラフがアクティブ化されます。ユーザーは埋め込まれた Excel ブックを編集でき、アクティブ化されたブックの外側をクリックするとスライドに戻ります。ユーザーがスライドに戻る際に OLE オブジェクトフレームのサイズが変わり、リサイズ率は OLE オブジェクトフレームと埋め込まれた Excel ブックの元のサイズに依存します。

## **リサイズの原因**

埋め込まれた Excel ブックは独自のウィンドウサイズを持ち、オブジェクトが最初にアクティブ化されるときに Excel がそのサイズを保持しようとします。スライド上の OLE フレームは別個に定義されたサイズを持ちます。Excel ブックがアクティブ化されると、Excel と PowerPoint がオブジェクトのサイズを協議し、埋め込みプロセスの一部として比例を維持します。ブックウィンドウと OLE フレーム間の違いがオブジェクトのリサイズを引き起こすことがあります。

## **実装ソリューション**

チャートのサイズをスライド上の OLE フレームに合わせ、チャートの寸法をブックウィンドウとは独立させます。このソリューションは新規プレゼンテーションでも既存テンプレートでも機能します。

このサンプルは Aspose.Cells for Python via Java と Aspose.Slides for Python via Java が必要です。アクティブなチャートシートにシンプルな縦棒グラフを作成し、ブックを XLS 形式で埋め込みます。チャートプレビュー画像は割り当てず、OLE オブジェクトが PowerPoint でアクティブ化されたときにグラフが表示されます。

サンプルは左端から 0.5 インチ、上端から 1 インチの位置に、9.5 × 4 インチの OLE フレームを持つ新規プレゼンテーションを作成します。スライド座標とサイズはポイント単位（1 インチ＝72 ポイント）です。既存プレゼンテーションの場合は [Use a Template](#use-a-template) を参照してください。

## **固定チャートサイズの設定**

[setSizeWithWindow](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#sizewithwindow) を false に設定し、チャート寸法がブックウィンドウと独立するようにします。[getChartObject](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#chartobject) の寸法は [setWidth](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#width) と [setHeight](https://reference.aspose.com/cells/python-java/asposecells.api/shape/#height) で設定し、96 ピクセル／インチでポイントをピクセルに変換します：684 × 288 ポイントのフレームは 912 × 384 ピクセルのチャートに相当します。[setPrintSize](https://reference.aspose.com/cells/python-java/asposecells.api/chart/#printsize) を [PrintSizeType](https://reference.aspose.com/cells/python-java/asposecells.api/printsizetype/) の CUSTOM 値に設定します。例では [addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) でブックを埋め込み、9.5 × 4 インチの OLE フレームを持つプレゼンテーションを保存します。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import ChartType, FileFormatType, PrintSizeType, SheetType, Workbook
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("Data")
    data_sheet.getCells().get("A1").putValue(10)
    data_sheet.getCells().get("A2").putValue(20)

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, 20, 10)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add("Data!A1:A2", True)
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)

        # スライドの座標とサイズはポイント単位です（1インチ＝72ポイント）。
        width = 684.0  # 9.5 インチ。
        height = 288.0  # 4 インチ。

        chart.setSizeWithWindow(False)
        # ポイントを 96 ピクセル/インチでチャートピクセルに変換します。
        chart.getChartObject().setWidth(int(width / 72.0 * 96.0))
        chart.getChartObject().setHeight(int(height / 72.0 * 96.0))
        chart.setPrintSize(PrintSizeType.CUSTOM)

        workbook_stream = ByteArrayOutputStream()
        workbook.save(workbook_stream, FileFormatType.EXCEL_97_TO_2003)
        workbook_data = workbook_stream.toByteArray()
        data_info = OleEmbeddedDataInfo(workbook_data, "xls")
        slide.getShapes().addOleObjectFrame(36.0, 72.0, width, height, data_info)

        presentation.save("chart-fixed-size.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    workbook.dispose()
```

## **テンプレートの使用**

既存プレゼンテーションでもサイズロジックは同じです。例を適用する手順は次のとおりです。

1. 空のプレゼンテーションを作成する代わりにテンプレートプレゼンテーションを読み込む。
2. 最初のスライドに少なくとも 3 つのシェイプがあることを確認し、インデックス 2 のシェイプをプレースホルダーとして使用する。
3. 固定値 684 と 288 を使用する代わりに、そのシェイプからフレームの幅と高さを取得する。サイズ計算は変更しないままにする。
4. 固定座標 36 と 72 の代わりに、プレースホルダーの位置に OLE フレームを追加する。
5. プレゼンテーションを保存する前にプレースホルダーを削除する。

## **よくある質問**

**なぜ埋め込まれた Excel グラフは PowerPoint でアクティブ化した後にサイズが変わるのですか？**  
Excel は最初にアクティブ化されたときに元のウィンドウサイズを復元しようとしますが、PowerPoint の OLE オブジェクトフレームは独自のサイズを持っています。PowerPoint と Excel がサイズを協議してアスペクト比を維持しようとするため、リサイズが発生します。

**チャートと OLE フレームのサイズを一貫させるにはどうすればよいですか？**  
固定されたチャート寸法を OLE フレームに合わせ、埋め込む前にカスタムのチャート印刷サイズを設定します。上記の例に示した設定と単位変換を使用してください。

**ブックウィンドウのサイズを合わせるだけで十分ですか？**  
ブックウィンドウのサイズを合わせるだけでは、アクティブ化後に OLE フレームのサイズ変化を確実に防げません。例に示したように固定チャート寸法を使用してください。

**このソリューションはテンプレートベースのプレゼンテーションと新規プレゼンテーションの両方で機能しますか？**  
はい。テンプレートの場合はプレースホルダーの寸法と位置を使用し、新規プレゼンテーションの場合はフレームの寸法と位置を直接指定します。

**他のスプレッドシートプログラムで作成したチャートでもこの例を使用できますか？**  
この例は Aspose.Cells で作成した Excel ブックを使用しています。他のスプレッドシートプログラムで作成したチャートのアクティブ化動作は示していません。

## **関連セクション**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ja/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)