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
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java で埋め込んだ Excel OLE オブジェクトを使用する際に、PPTX の予期しないチャートリサイズを修正します。サイズを一貫させるためのコード付き2つの方法を学びましょう。"
---
## **背景**

Aspose コンポーネントを使用して PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込まれた Excel グラフが、最初にアクティブ化された後に不特定のスケールにリサイズされることが確認されています。この動作により、グラフのアクティブ化前後でプレゼンテーションの見た目に顕著な差が生じます。Aspose チームは問題を詳細に調査し、解決策を見つけました。本記事では問題の原因と対応策について説明します。

[previous article](/slides/ja/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) では、Aspose.Cells for Python via Java で Excel グラフを作成し、Aspose.Slides for Python via Java で PowerPoint プレゼンテーションに OLE オブジェクトとして埋め込む方法を解説しました。[object preview issue](/slides/ja/python-java/object-preview-issue-when-adding-oleobjectframe/) に対処するため、グラフ画像をグラフの OLE オブジェクトフレームに割り当てました。出力されたプレゼンテーションで、グラフ画像を表示している OLE オブジェクトフレームをダブルクリックすると、Excel グラフがアクティブ化されます。エンドユーザーは基になる Excel ワークブックで任意の変更を行い、アクティブ化されたワークブックの外側をクリックすると対応するスライドに戻ります。ユーザーがスライドに戻ると OLE オブジェクトフレームのサイズが変わり、リサイズ率は OLE オブジェクトフレームと埋め込まれた Excel ワークブックの元々のサイズに依存します。

## **サイズ変更の原因**

Excel ワークブックは独自のウィンドウサイズを持っており、最初のアクティブ化時に元のサイズを保持しようとします。一方、OLE オブジェクトフレームにも独自のサイズがあります。Microsoft によると、Excel ワークブックがアクティブ化されると、Excel と PowerPoint がサイズを協議し、埋め込みプロセスの一部として正しい比率を維持します。Excel ウィンドウサイズと OLE オブジェクトフレームのサイズまたは位置の違いに応じて、リサイズが発生します。

## **実装ソリューション**

Aspose.Slides for Python via Java を使用して PowerPoint プレゼンテーションを作成するシナリオは 2 つあります。

**Scenario 1:** 既存のテンプレートを基にプレゼンテーションを作成する。

**Scenario 2:** ゼロからプレゼンテーションを作成する。

ここで提示する解決策は両シナリオに適用できます。すべてのアプローチの基本は同じです：**埋め込まれた OLE オブジェクトのウィンドウサイズを PowerPoint スライド上の OLE オブジェクトフレームに合わせる**ことです。以下で 2 つのアプローチを説明します。

## **第一のアプローチ**

このアプローチでは、埋め込まれた Excel ワークブックのウィンドウサイズを PowerPoint スライド上の OLE オブジェクトフレームのサイズに合わせる方法を学びます。

**Scenario 1**

テンプレートが定義されており、そのテンプレートに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス 2 にあるシェイプに、埋め込まれた Excel ワークブックを含む OLE フレームを配置したいと想定します。このシナリオでは OLE オブジェクトフレームのサイズは事前に決まっており、テンプレートのインデックス 2 のシェイプのサイズと一致しています。必要なのは、ワークブックのウィンドウサイズをそのシェイプのサイズに設定することだけです。以下のコードスニペットがその目的を果たします。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# チャートを含む Excel ワークブックをロードします。
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # ワークブックのウィンドウサイズをインチ単位で設定します (PowerPoint は 1 インチあたり 72 ポイントを使用)。
    workbook.getSettings().setWindowWidthInch(shape.getWidth() / 72.0)
    workbook.getSettings().setWindowHeightInch(shape.getHeight() / 72.0)

    # ワークブックをメモリストリームに保存します。
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 埋め込み Excel データで OLE オブジェクトフレームを作成します。
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**

ゼロからプレゼンテーションを作成し、任意のサイズの OLE オブジェクトフレームに埋め込まれた Excel ワークブックを含めたいとします。以下のコードスニペットでは、スライド上の x=0.5 インチ、y=1 インチの位置に高さ 4 インチ、幅 9.5 インチの OLE オブジェクトフレームを作成し、Excel ワークブックのウィンドウも同じサイズ（高さ 4 インチ、幅 9.5 インチ）に設定します。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# チャートを含む Excel ワークブックをロードします。
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 インチ (4 * 72)。
    desired_width = 684  # 9.5 インチ (9.5 * 72)。

    # ウィンドウを使用してチャートサイズを設定します。
    chart.setSizeWithWindow(True)

    # ワークブックのウィンドウサイズをインチ単位で設定します (PowerPoint は 1 インチあたり 72 ポイントを使用)。
    workbook.getSettings().setWindowWidthInch(desired_width / 72.0)
    workbook.getSettings().setWindowHeightInch(desired_height / 72.0)

    # ワークブックをメモリストリームに保存します。
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 埋め込み Excel データで OLE オブジェクトフレームを作成します。
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **第二のアプローチ**

このアプローチでは、埋め込まれた Excel ワークブック内のグラフのサイズを PowerPoint スライド上の OLE オブジェクトフレームのサイズに合わせる方法を学びます。この方法は、事前にグラフサイズが分かっていて変更されない場合に有用です。

**Scenario 1**

テンプレートが定義されており、そのテンプレートに基づいてプレゼンテーションを作成したいとします。テンプレートのインデックス 2 にあるシェイプに、埋め込まれた Excel ワークブックを含む OLE フレームを配置したいと想定します。このシナリオでは OLE フレームのサイズは事前に決まっており、テンプレートのインデックス 2 のシェイプのサイズと一致しています。必要なのは、ワークブック内のグラフサイズをそのシェイプのサイズに設定することだけです。以下のコードスニペットがその目的を果たします。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# チャートを含む Excel ワークブックをロードします。
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(2)

    # ウィンドウなしでチャートサイズを定義します。
    chart.setSizeWithWindow(False)

    # ピクセル単位でチャートサイズを設定します (Excel は 1 インチあたり 96 ピクセルを使用)。
    chart.getChartObject().setWidth(int((shape.getWidth() / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((shape.getHeight() / 72.0) * 96.0))

    # チャートの印刷サイズを定義します。
    chart.setPrintSize(PrintSizeType.CUSTOM)

    # ワークブックをメモリストリームに保存します。
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 埋め込み Excel データで OLE オブジェクトフレームを作成します。
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), data_info)
finally:
    presentation.dispose()
```

**Scenario 2**:

ゼロからプレゼンテーションを作成し、任意のサイズの OLE オブジェクトフレームに埋め込まれた Excel ワークブックを含めたいとします。以下のコードスニペットでは、スライド上の x=0.5 インチ、y=1 インチの位置に高さ 4 インチ、幅 9.5 インチの OLE オブジェクトフレームを作成し、対応するグラフサイズも同じ寸法（高さ 4 インチ、幅 9.5 インチ）に設定します。

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, PrintSizeType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

# チャートを含む Excel ワークブックをロードします。
workbook = Workbook("chart.xls")
chart = workbook.getWorksheets().get(0).getCharts().get(0)

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    desired_height = 288  # 4 インチ (4 * 72).
    desired_width = 684  # 9.5 インチ (9.5 * 72).

    # ウィンドウなしでチャートサイズを定義します。
    chart.setSizeWithWindow(False)

    # ピクセル単位でチャートサイズを設定します (Excel は 1 インチあたり 96 ピクセルを使用)。
    chart.getChartObject().setWidth(int((desired_width / 72.0) * 96.0))
    chart.getChartObject().setHeight(int((desired_height / 72.0) * 96.0))

    # ワークブックをメモリストリームに保存します。
    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)

    # 埋め込み Excel データで OLE オブジェクトフレームを作成します。
    workbook_data = workbook_stream.toByteArray()
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(36.0, 72.0, desired_width, desired_height, data_info)
finally:
    presentation.dispose()
```

## **結論**

グラフのサイズ変更問題を解決する方法は 2 つあります。どちらのアプローチを選択するかは要件と使用ケースに依存します。両方のアプローチは、テンプレートから作成する場合でもゼロから作成する場合でも同様に機能します。また、このソリューションでは OLE オブジェクトフレームのサイズに制限はありません。

## **FAQ**

**埋め込んだ Excel グラフは、PowerPoint でアクティブ化するとサイズが変わるのはなぜですか？**

Excel は最初にアクティブ化されたときに元のウィンドウサイズを復元しようとしますが、PowerPoint の OLE オブジェクトフレームは独自の寸法を持っています。PowerPoint と Excel がサイズを協議してアスペクト比を維持するため、リサイズが発生します。

**このリサイズ問題を完全に防ぐことはできますか？**

はい。埋め込む前に Excel ワークブックのウィンドウサイズまたはグラフサイズを OLE オブジェクトフレームのサイズと合わせれば、サイズの不一致を防げます。

**どちらのアプローチ（ウィンドウサイズ設定 vs. グラフサイズ設定）を選ぶべきですか？**

ワークブックのアスペクト比を保持し、後でリサイズを許可したい場合は **アプローチ 1（ウィンドウサイズ）** を使用してください。グラフの寸法が固定で埋め込み後に変更しない場合は **アプローチ 2（グラフサイズ）** を使用してください。

**これらの方法はテンプレートベースのプレゼンテーションと新規プレゼンテーションの両方で機能しますか？**

はい。両アプローチはテンプレートから作成したプレゼンテーションでもゼロから作成したプレゼンテーションでも同様に機能します。

**OLE オブジェクトフレームのサイズに制限はありますか？**

いいえ。ワークブックまたはグラフのサイズに適切に合わせさえすれば、任意のサイズの OLE フレームを設定できます。

**他のスプレッドシートプログラムで作成したチャートでもこの方法は使えますか？**

例は Aspose.Cells で作成した Excel チャートを対象としていますが、同様のサイズ設定オプションをサポートする OLE 互換のスプレッドシートプログラムであれば原理は同じです。

## **Related Sections**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ja/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)