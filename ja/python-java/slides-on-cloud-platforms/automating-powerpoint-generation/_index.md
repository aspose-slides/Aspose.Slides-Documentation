---
title: "Python で PowerPoint を自動生成: 動的なプレゼンテーションを簡単に作成"
linktitle: Python で PowerPoint 自動生成
type: docs
weight: 20
url: /ja/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- クラウドプラットフォーム
- クラウド統合
- PowerPoint 生成の自動化
- プログラムによるプレゼンテーション生成
- PowerPoint 自動化
- 動的スライド作成
- 自動化されたビジネスレポート
- PPT 自動化
- Python プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して PowerPoint 生成を自動化: クラウドアプリケーションでチャート、テーブル、箇条書きを含むビジネスプレゼンテーションを作成します。"
---
## **はじめに**

プレゼンテーションを手動で作成すると、コンテンツが頻繁に変わるたびに作業が繰り返しになります。週次レポート、研修資料、クライアント向けプレゼンテーションは多くの場合共通の構造を持ちますが、各配布ごとに新しいデータが必要です。

Aspose.Slides for Python via Java を使用すると、Python アプリケーションからプレゼンテーションを生成できます。データベース、API、またはアップロードされたファイルからのデータを使用して、Web ポータル、定期ジョブ、クラウドワーカーへスライド作成を統合できます。

## **Python での PowerPoint 自動化の一般的な使用例**

- **ビジネスレポートとダッシュボード:** 売上数字や業績指標をチャートやテーブルに変換します。
- **パーソナライズされた営業プレゼンテーション:** クライアント固有のデータでスライドを埋め込み、デザインの一貫性を保ちます。
- **教育コンテンツ:** 構造化された資料からレッスン、クイズ、コースサマリーを組み立てます。
- **データと AI を活用したインサイト:** 分析や自然言語処理サービスの結果をプレゼンテーションコンテンツとして使用します。
- **メディアベースのスライド:** アップロードされた画像やスクリーンショットと説明テキストを組み合わせます。
- **ドキュメントワークフロー:** 他のツールで抽出したコンテンツをプレゼンテーションのレイアウトにマッピングします。
- **開発者向けツール:** プロジェクトデータからリリースサマリー、技術概要、デモを生成します。

## **前提条件**

Python、Java、JPype、Aspose.Slides の設定は[Installation](/slides/ja/python-java/installation/) に従って行います。クラウド展開については、[Slides on Cloud Platforms](/slides/ja/python-java/slides-on-cloud-platforms/) も確認してください。

この例は固定されたビジネスデータを使用しているため、データベースや外部サービスなしで実行できます。レポートワークフローに統合する際は、これらの値をアプリケーションのデータに置き換えてください。

{{% alert color="info" title="Note" %}}
ライセンスなしで例を試すことはできますが、評価版の出力には透かしが入り、評価制限の対象となります。詳細および一時ライセンス情報は[Evaluate Aspose.Slides](/slides/ja/python-java/evaluate-aspose-slides/) を参照してください。
{{% /alert %}}

## **プレゼンテーションの作成**

以下の完全なスクリプトは、4枚のスライドを含む1つのプレゼンテーションを作成します。各ステップは同じプレゼンテーションを使用し、最終ステップで `presentation.pptx` として保存します。

### **タイトルスライドの作成**

新しい[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) の最初のスライドを使用し、タイトルレイアウトを適用します。タイトルとサブタイトルのプレースホルダーにレポートの見出しと対象者を入力します。

![タイトルスライド](slide_0.png)

### **列チャート付きスライドの追加**

空白のスライドを追加し、[ShapeCollection.addChart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addChart) でチャートを作成します。埋め込みワークブックに5つの地域と1つの売上系列を入力します。値は PowerPoint で編集可能なままです。

![チャート付きスライド](slide_1.png)

### **テーブル付きスライドの追加**

[ShapeCollection.addTable](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addTable) でテーブルを作成し、2列に指標名と値を入力します。例では、列幅と行高さのために Java の double 配列を JPype 経由で明示的に渡しています。

![テーブル付きスライド](slide_2.png)

### **箇条書き付きサマリースライドの追加**

テキストシェイプを作成し、各アクション項目ごとに[Paragraph](https://reference.aspose.com/slides/ja/python-java/aspose.slides/paragraph/) を追加します。シンボル箇条書きと黒色テキストを各段落に適用し、シェイプの塗りつぶしとアウトラインを削除します。

![サマリー付きスライド](slide_3.png)

### **プレゼンテーションの保存**

[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) を使用して PowerPoint ファイルを書き込みます。`finally` ブロックで [Presentation.dispose](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#dispose) によりプレゼンテーションを解放します。

### **完全な Python 例**

このスクリプトを書き込み可能なディレクトリに保存し、上記で構成した Python 環境で実行してください。必要な場合にのみ JVM を起動し、プロセスが終了するまで利用可能な状態に保ちます。ノートブックやサービスでの使用については、[JVM lifecycle guidance](/slides/ja/python-java/limitations-and-api-differences/#import-the-library) を参照してください。

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # タイトルスライドを作成します。
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # チャートスライドを追加します。
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # テーブルスライドを追加します。
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # サマリースライドを追加します。
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

図は Java の例に対応するスライドを示しています。外観はインストールされたフォントや評価モードにより異なる場合があります。

## **クラウドアプリケーションでの例の使用**

プレゼンテーションを作成する前にレポートデータを取得し、チャート、テーブル、テキスト生成の各ステップに渡します。ジョブごとに別々の出力パスを使用します。保存後、アプリケーションはファイルをオブジェクトストレージにアップロードするか、ダウンロードとして返すことができます。

同じワーカープロセス内のジョブ間で JVM を継続して実行し、ジョブが完了したら各プレゼンテーションを解放します。環境間の差異を減らすため、レポートデザインで必要なフォントをデプロイ時にパッケージ化してください。

## **結論**

この例は、編集可能なチャート、テーブル、テキストを使用して、Python から完全なビジネスプレゼンテーションを生成します。サンプルデータをアプリケーションデータに置き換えることで、定期レポート、クライアント向けプレゼンテーション、教育資料に同様の手法が活用できます。

## **よくある質問**

**スクリプトは Microsoft PowerPoint または Excel を必要としますか？**

必要ありません。Aspose.Slides はどちらのアプリケーションも使用せずにスライドとチャートの埋め込みワークブックを作成します。

**なぜテーブルの例で Java 配列を使用するのですか？**

基底のメソッドは Java の double 配列を受け取ります。明示的な配列にすることで、JPype を介して渡される数値型が明確になります。

**同じプレゼンテーションを PDF や ODP として保存できますか？**

はい。解放する前に、対応する [SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) の値を使って別の出力ファイル名で保存できます。形式固有の機能については [Supported File Formats](/slides/ja/python-java/supported-file-formats/) を参照してください。

**ブランドテンプレートを使用できますか？**

はい。空のプレゼンテーションを作成する代わりにテンプレートをロードし、そのテンプレートに合わせてレイアウトやプレースホルダーの選択を調整してください。サンプルは新規のデフォルトプレゼンテーションのレイアウトとプレースホルダー順序を前提としています。