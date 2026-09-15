---
title: Excel データを PowerPoint プレゼンテーションに統合
linktitle: Excel 統合
type: docs
weight: 330
url: /ja/python-java/excel-integration/
keywords:
- エクセル
- ワークブック
- Excel の読み取り
- Excel の統合
- データ ソース
- 差し込み印刷
- テーブルのインポート
- Excel を PowerPoint に統合
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "ExcelDataWorkbook API を使用し、Java 経由で Python 用 Aspose.Slides から Excel ワークブックのデータを読み取ります。シートとセルをロードし、取得した値を使用してデータ駆動型 PowerPoint プレゼンテーションを生成します。"
---
## **Introduction**

PowerPoint プレゼンテーションは、情報を表示し伝達するための強力な手段です。これらはしばしば Excel ブックと組み合わせて使用され、Excel は構造化データの優れたソースとなり、PowerPoint はそのデータを聴衆向けに視覚化するのが得意です。

Excel と PowerPoint を組み合わせることが不可欠な実用的なシナリオは多数あります。たとえば、差し込み印刷、データテーブルの埋め込み、レコードごとにスライドを生成する（バッチスライド生成）、トレーニング資料の作成、複数の Excel レポートを単一のプレゼンテーションに統合する、などがあります。

これまで、Aspose.Slides API でこれらの機能を実装するには、Aspose.Cells のようなサードパーティ製ソリューションに依存する必要がありました。これらのツールは堅牢ですが、基本的なデータ統合機能だけを必要とするユーザーにとっては、過度に複雑でコストがかかることがあります。

## **How It Works**

Excel データの操作をより簡単かつスムーズにするため、Aspose.Slides は Excel ワークブックからデータを読み取り、プレゼンテーションにコンテンツをインポートするための新しいクラスを導入しました。この機能により、プレゼンテーションのワークフローで Excel をデータ ソースとして活用したい API ユーザーに強力な新たな可能性が提供されます。

新機能は汎用データアクセス向けに設計されており、Presentation Document Object Model (DOM) には統合されていません。つまり、*Excel ファイルの編集や保存はできない* ことを意味し、唯一の目的はワークブックを開いてその内容をナビゲートし、セル データを取得することです。

この機能の中心となるのは新しい [ExcelDataWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/exceldataworkbook/) クラスです。このクラスを使用すると、ローカル ファイルまたはストリームから Excel ワークブックを読み込むことができます。読み込んだ後は、[ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/exceldataworkbook/#getCell) メソッドの複数のオーバーロードが提供され、位置（行・列インデックスや名前付き範囲など）で特定のセルを取得できます。

各 [ExcelDataWorkbook.getCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/exceldataworkbook/#getCell) 呼び出しは [ExcelDataCell](https://reference.aspose.com/slides/ja/python-java/aspose.slides/exceldatacell/) オブジェクトを返します。このオブジェクトは Excel ワークブック内の単一セルを表し、シンプルかつ直感的にその値にアクセスできます。

#### **Excel チャートのインポート**

機能を拡張する次のステップは、[ExcelWorkbookImporter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/excelworkbookimporter/) クラスです。このユーティリティ クラスは、Excel ワークブックからプレゼンテーションへのコンテンツインポート機能を提供します。[ExcelWorkbookImporter.addChartFromWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) メソッドの複数のオーバーロードが含まれており、指定した Excel ワークブックから選択したチャートを取得し、指定した座標で対象のシェイプ コレクションの末尾に追加できます。

#### **Excel テーブルのインポート**

[ExcelWorkbookImporter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/excelworkbookimporter/) クラスには、[ExcelWorkbookImporter.addTableFromWorkbook](https://reference.aspose.com/slides/ja/python-java/aspose.slides/excelworkbookimporter/#addTableFromWorkbook) メソッドのいくつかのオーバーロードも含まれています。これらのメソッドを使用すると、指定したワークシートから特定のセル範囲をインポートし、指定座標で対象シェイプ コレクションの末尾にテーブルとして追加できます。

要するに、Excel データを読み取るための軽量でシンプルな API です。フルスプレッドシート処理ライブラリのオーバーヘッドなしで、多くの開発者が必要とする機能を提供します。

## **コードを書いてみよう**

### **差し込み印刷シナリオ例**

以下の例では、Excel ワークブックに保存されたデータを基に�数のプレゼンテーションを生成し、シンプルな差し込み印刷シナリオを実装します。

開始するには、次の 2 つが必要です。

1. データを含む Excel ワークブック

![Excel データ例](example1_image0.png)

2. PowerPoint プレゼンテーションのテンプレート

![PowerPoint テンプレート例](example1_image1.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# 従業員データが入った Excel ワークブックをロードします。
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# プレゼンテーションテンプレートをロードします。
template_presentation = Presentation("PresentationTemplate.pptx")

try:
    # Excel の行をループします（行 0 のヘッダーは除外）。
    for row_index in range(1, 5):

        # 各従業員レコード用にプレゼンテーションを作成します。
        employee_presentation = Presentation()

        try:
            # デフォルトの空白スライドを削除します。
            employee_presentation.getSlides().removeAt(0)

            # テンプレートスライドをプレゼンテーションにクローンします。
            slide = employee_presentation.getSlides().addClone(template_presentation.getSlides().get_Item(0))

            # 対象シェイプから段落を取得します（シェイプ インデックス 1 が使用されていると仮定）。
            paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs()

            # プレースホルダーを Excel のデータで置換します。
            employee_name = str(workbook.getCell(worksheet_index, row_index, 0).getValue())
            name_portion = paragraphs.get_Item(0).getPortions().get_Item(0)
            name_portion.setText(str(name_portion.getText()).replace("{{EmployeeName}}", employee_name))

            department = str(workbook.getCell(worksheet_index, row_index, 1).getValue())
            department_portion = paragraphs.get_Item(1).getPortions().get_Item(0)
            department_portion.setText(str(department_portion.getText()).replace("{{Department}}", department))

            years_of_service = str(workbook.getCell(worksheet_index, row_index, 2).getValue())
            years_portion = paragraphs.get_Item(2).getPortions().get_Item(0)
            years_portion.setText(str(years_portion.getText()).replace("{{YearsOfService}}", years_of_service))

            # 個別ファイルにパーソナライズされたプレゼンテーションを保存します。
            employee_presentation.save(f"{employee_name} Report.pptx", SaveFormat.Pptx)
        finally:
            employee_presentation.dispose()
finally:
    template_presentation.dispose()
```

![結果](example1_image2.png)

### **Excel テーブル例**

2 番目の例では、Excel テーブルからデータをコピーし、PowerPoint スライド上でより視覚的に魅力的な形式で表示します。

この例では、シンプルな従業員テーブルを含む、最初の例と同じ Excel ワークブックを再利用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, Presentation, SaveFormat

# 従業員データが含まれる Excel ワークブックを読み込みます。
workbook = ExcelDataWorkbook("TemplateData.xlsx")
worksheet_index = 0

# PowerPoint プレゼンテーションを作成します。
presentation = Presentation()

try:
    # 最初のスライドにテーブル シェイプを追加します。
    column_widths = jpype.JArray(jpype.JDouble)([200, 200, 200])
    row_heights = jpype.JArray(jpype.JDouble)([30, 30, 30, 30, 30])
    table = presentation.getSlides().get_Item(0).getShapes().addTable(50, 200, column_widths, row_heights)

    # Excel ワークブックからデータを取得して PowerPoint のテーブルに入力します。
    for row_index in range(5):
        for column_index in range(3):
            cell_value = str(workbook.getCell(worksheet_index, row_index, column_index).getValue())
            table.getColumns().get_Item(column_index).get_Item(row_index).getTextFrame().setText(cell_value)

    # 作成したプレゼンテーションをファイルに保存します。
    presentation.save("Table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![結果](example2_image0.png)

### **Excel チャートのインポート例**

この例では、前の例で使用した Excel ワークブックの最初のワークシートからチャートをインポートします。チャートは結果のプレゼンテーションで外部ワークブックにリンクされます。

まず、従業員テーブルを基に Excel ワークブックに円グラフを追加します。

![Excel チャート例](example3_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# PowerPoint プレゼンテーションを作成します。
presentation = Presentation()
try:
    # 最初のスライドのシェイプ コレクションを取得します。
    shapes = presentation.getSlides().get_Item(0).getShapes()

    # ワークブックの最初のシートから名前が "Chart 1" のチャートをインポートし、シェイプ コレクションに追加します。
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", False)

    # 作成したプレゼンテーションをファイルに保存します。
    presentation.save("Chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![結果](example3_image1.png)

### **すべての Excel チャートのインポート例**

Excel ワークブックに多数のチャートがあり、すべてをプレゼンテーションにインポートしたいと想像してください。各チャートは新しいスライドに配置されます。

以下のコードは、元の Excel ファイルのすべてのワークシートを走査し、各ワークシートからチャートを抽出して、空白のスライド レイアウトを使用して個別のスライドに各チャートを追加します。結果のプレゼンテーションには、チャート データのみが埋め込まれ、ワークブック全体は含まれません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelDataWorkbook, ExcelWorkbookImporter, Presentation, SaveFormat, SlideLayoutType

# 従業員データが含まれる Excel ワークブックを読み込みます。
workbook = ExcelDataWorkbook("ExcelWithCharts.xlsx")

# PowerPoint プレゼンテーションを作成します。
presentation = Presentation()
try:
    # 空白スライド レイアウトを取得します。
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    # デフォルトのスライドを削除します。これにより、結果はチャートごとに 1 つのスライドが含まれます。
    presentation.getSlides().removeAt(0)

    # Excel ワークブックに含まれるすべてのワークシート名を取得します。
    worksheet_names = workbook.getWorksheetNames()

    for name in worksheet_names:
        # ワークシートのチャート インデックスをチャート名にマッピングしたマップを取得します。
        worksheet_charts = workbook.getChartsFromWorksheet(name)

        for chart in worksheet_charts:
            # 空白レイアウトを使用してスライドを追加します。
            slide = presentation.getSlides().addEmptySlide(blank_layout)

            # 指定したチャートを Excel ワークブックからスライドのシェイプ コレクションにインポートします。
            ExcelWorkbookImporter.addChartFromWorkbook(slide.getShapes(), 10, 10, workbook, name, chart.getKey(), False)

    # 作成したプレゼンテーションをファイルに保存します。
    presentation.save("Charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Excel テーブルのインポート例**

この例では、Excel ワークシートから書式設定されたテーブルを直接 PowerPoint プレゼンテーションにインポートします。

元の Excel ワークシートには、従業員データを含む書式設定済みテーブルがあります。

![Excel テーブル例](example4_image0.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExcelWorkbookImporter, Presentation, SaveFormat

# PowerPoint プレゼンテーションを作成します。
presentation = Presentation()
try:
    # 最初のスライドとそのシェイプ コレクションを取得します。
    slide = presentation.getSlides().get_Item(0)
    shapes = slide.getShapes()

    # ワークブックの最初のシートからテーブルをインポートし、シェイプ コレクションに追加します。
    ExcelWorkbookImporter.addTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5")

    # 作成したプレゼンテーションをファイルに保存します。
    presentation.save("FormattedTable.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![結果](example4_image1.png)

## **まとめ**

このメカニズムは Aspose.Slides に直接組み込まれており、Excel データとプレゼンテーションの作業を一つに統合します。追加のライブラリや複雑な統合なしで、視覚的なチャートや Excel テーブルとして提示されたデータを含むスライドを作成できます。