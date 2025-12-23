---
title: PHP を使用してプレゼンテーションのチャート データ ラベルを管理する
linktitle: データ ラベル
type: docs
url: /ja/php-java/chart-data-label/
keywords:
- チャート
- データ ラベル
- データ精度
- パーセンテージ
- ラベル距離
- ラベル位置
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "PowerPoint プレゼンテーションで、Aspose.Slides for PHP via Java を使用してチャート データ ラベルを追加および書式設定し、より魅力的なスライドを作成する方法を学びます。"
---

チャートのデータ ラベルは、チャートのデータ系列や個々のデータ ポイントに関する詳細を示します。これにより、読者はデータ系列をすばやく識別でき、チャートの理解も容易になります。

## **チャート データ ラベルのデータ精度を設定**

この PHP コードは、チャート データ ラベルのデータ精度を設定する方法を示します。
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);
    $chart->getChartData()->getSeries()->get_Item(0)->setNumberFormatOfValues("#,##0.00");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **パーセンテージをラベルとして表示**

Aspose.Slides for PHP via Java を使用すると、表示されるチャートにパーセンテージ ラベルを設定できます。この PHP コードは、その操作を示します。
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # 最初のスライドを取得します
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);
    $series;
    $total_for_Cat = new double[$chart->getChartData()->getCategories()->size()];
    for($k = 0; $k < java_values($chart->getChartData()->getCategories()->size()) ; $k++) {
      $cat = $chart->getChartData()->getCategories()->get_Item($k);
      for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
        $total_for_Cat[$k] = $total_for_Cat[$k] + $chart->getChartData()->getSeries()->get_Item($i)->getDataPoints()->get_Item($k)->getValue()->getData();
      }
    }
    $dataPontPercent = 0.0;
    for($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()) ; $x++) {
      $series = $chart->getChartData()->getSeries()->get_Item($x);
      $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);
      for($j = 0; $j < java_values($series->getDataPoints()->size()) ; $j++) {
        $lbl = $series->getDataPoints()->get_Item($j)->getLabel();
        $dataPontPercent = $series->getDataPoints()->get_Item($j)->getValue()->getData() / $total_for_Cat[$j] * 100;
        $port = new Portion();
        $port->setText(sprintf("{0:F2} %.2f", $dataPontPercent));
        $port->getPortionFormat()->setFontHeight(8.0);
        $lbl->getTextFrameForOverriding()->setText("");
        $para = $lbl->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
        $para->getPortions()->add($port);
        $lbl->getDataLabelFormat()->setShowSeriesName(false);
        $lbl->getDataLabelFormat()->setShowPercentage(false);
        $lbl->getDataLabelFormat()->setShowLegendKey(false);
        $lbl->getDataLabelFormat()->setShowCategoryName(false);
        $lbl->getDataLabelFormat()->setShowBubbleSize(false);
      }
    }
    # チャートを含むプレゼンテーションを保存します
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **チャート データ ラベルにパーセンテージ記号を設定**

この PHP コードは、チャート データ ラベルにパーセンテージ記号を設定する方法を示します。
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # インデックスでスライドの参照を取得します
    $slide = $pres->getSlides()->get_Item(0);
    # スライド上に PercentsStackedColumn チャートを作成します
    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);
    # NumberFormatLinkedToSource を false に設定します
    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");
    $chart->getChartData()->getSeries()->clear();
    $defaultWorksheetIndex = 0;
    # チャート データのワークシートを取得します
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # 新しい系列を追加します
    $series = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 1, "Reds"), $chart->getType());
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 1, 0.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 1, 0.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 1, 0.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 1, 0.65));
    # 系列の塗りつぶし色を設定します
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # LabelFormat のプロパティを設定します
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # 新しい系列を追加します
    $series2 = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 2, "Blues"), $chart->getType());
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 2, 0.7));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 2, 0.5));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 2, 0.2));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 2, 0.35));
    # 塗りつぶしタイプと色を設定します
    $series2->getFormat()->getFill()->setFillType(FillType::Solid);
    $series2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $series2->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # プレゼンテーションをディスクに保存します
    $pres->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **軸からのラベル距離を設定**

この PHP コードは、軸からプロットされたチャートでカテゴリ軸からのラベル距離を設定する方法を示します。
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # スライドの参照を取得します
    $sld = $pres->getSlides()->get_Item(0);
    # スライドにチャートを作成します
    $ch = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    # 軸からラベルの距離を設定します
    $ch->getAxes()->getHorizontalAxis()->setLabelOffset(500);
    # プレゼンテーションを書き出します
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **ラベル位置の調整**

軸に依存しないチャート（例えば円グラフ）を作成する場合、チャートのデータ ラベルがエッジに近すぎることがあります。そのような場合、リーダー ラインが明確に表示されるようにデータ ラベルの位置を調整する必要があります。

この PHP コードは、円グラフでラベル位置を調整する方法を示します。
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();
    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition->OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **FAQ**

**密なチャートでデータ ラベルの重なりを防ぐにはどうすればよいですか？**

自動ラベル配置、リーダー ライン、フォントサイズの縮小を組み合わせます。必要に応じて、いくつかのフィールド（例: カテゴリ）を非表示にするか、極端なポイントや重要なポイントのラベルのみを表示します。

**0、負の値、または空の値に対してのみラベルを無効にするにはどうすればよいですか？**

ラベルを有効にする前にデータ ポイントをフィルタリングし、定義されたルールに従って 0、負の値、または欠損値の表示をオフにします。

**PDF/画像にエクスポートする際に一貫したラベル スタイルを確保するにはどうすればよいですか？**

フォント（ファミリ、サイズ）を明示的に設定し、フォントがレンダリング側で利用可能であることを確認してフォールバックを防ぎます。