---
title: グラフの書式設定
type: docs
weight: 60
url: /ja/php-java/chart-formatting/
---

## **グラフエンティティの書式設定**
Aspose.Slides for PHP via Javaは、開発者がスライドにカスタムチャートをゼロから追加できるようにします。この記事では、グラフのカテゴリ軸と値軸を含むさまざまなグラフエンティティの書式設定方法について説明します。

Aspose.Slides for PHP via Javaは、さまざまなグラフエンティティを管理し、カスタム値を使用して書式設定するためのシンプルなAPIを提供します：

1. [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. デフォルトデータを持つ任意の望ましいタイプのチャートを追加します（この例ではChartType::LineWithMarkersを使用します）。
1. グラフの値軸にアクセスし、次のプロパティを設定します：
   1. 値軸の主グリッド線のために**線の書式**を設定する
   1. 値軸の副グリッド線のために**線の書式**を設定する
   1. 値軸のために**数値形式**を設定する
   1. 値軸の**最小、最大、主および副単位**を設定する
   1. 値軸データのために**テキストプロパティ**を設定する
   1. 値軸の**タイトル**を設定する
   1. 値軸のために**線の書式**を設定する
1. グラフのカテゴリ軸にアクセスし、次のプロパティを設定します：
   1. カテゴリ軸の主グリッド線のために**線の書式**を設定する
   1. カテゴリ軸の副グリッド線のために**線の書式**を設定する
   1. カテゴリ軸データのために**テキストプロパティ**を設定する
   1. カテゴリ軸の**タイトル**を設定する
   1. カテゴリ軸の**ラベル位置**を設定する
   1. カテゴリ軸ラベルの**回転角度**を設定する
1. グラフの凡例にアクセスし、**テキストプロパティ**を設定する
1. グラフが重ならないように図例を表示する
1. グラフの**二次値軸**にアクセスし、次のプロパティを設定します：
   1. 二次**値軸**を有効にする
   1. 二次値軸のために**線の書式**を設定する
   1. 二次値軸のために**数値形式**を設定する
   1. 二次値軸の**最小、最大、主および副単位**を設定する
1. 次に、二次値軸に最初の系列をプロットします
1. グラフの背面壁の塗りつぶし色を設定します
1. グラフのプロットエリアの塗りつぶし色を設定します
1. 修正したプレゼンテーションをPPTXファイルに書き込みます

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # サンプルチャートを追加
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # チャートタイトルを設定
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("サンプルチャート");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # 値軸の主グリッド線の書式を設定
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # 値軸の副グリッド線の書式を設定
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # 値軸の数値形式を設定
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # グラフの最大値と最小値を設定
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # 値軸のテキストプロパティを設定
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # 値軸のタイトルを設定
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("主軸");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # カテゴリ軸の主グリッド線の書式を設定
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # カテゴリ軸の副グリッド線の書式を設定
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # カテゴリ軸のテキストプロパティを設定
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # カテゴリタイトルを設定
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("サンプルカテゴリ");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # カテゴリ軸のラベル位置を設定
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # カテゴリ軸のラベル回転角度を設定
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # 凡例のテキストプロパティを設定
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # グラフが重ならないように図例を表示する
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # 二次値軸を設定
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # 二次値軸の数値形式を設定
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # グラフの最大値と最小値を設定
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # グラフの背面壁の色を設定
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # プロットエリアの色を設定
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # プレゼンテーションを保存
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **グラフのフォントプロパティを設定**
Aspose.Slides for PHP via Javaは、グラフのフォント関連プロパティを設定する機能を提供します。以下の手順に従って、グラフのフォントプロパティを設定してください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスオブジェクトをインスタンス化します。
- スライドにグラフを追加します。
- フォント高さを設定します。
- 修正したプレゼンテーションを保存します。

以下にサンプル例を示します。

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $pres->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **数値の書式を設定**
Aspose.Slides for PHP via Javaは、グラフデータの書式を管理するためのシンプルなAPIを提供します：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. デフォルトデータを持つ任意の望ましいタイプのチャートを追加します（この例では**ChartType::ClusteredColumn**を使用します）。
1. 可能なプリセット値からプリセット数値形式を設定します。
1. 各チャート系列のチャートデータセルをたどり、チャートデータの数値形式を設定します。
1. プレゼンテーションを保存します。
1. カスタム数値形式を設定します。
1. 各チャート系列のチャートデータセルをたどり、異なるチャートデータの数値形式を設定します。
1. プレゼンテーションを保存します。

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # 最初のプレゼンテーションスライドにアクセス
    $slide = $pres->getSlides()->get_Item(0);
    # デフォルトのクラスター型の棒グラフを追加
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # チャート系列コレクションにアクセス
    $series = $chart->getChartData()->getSeries();
    # 各チャート系列をたどる
    foreach($series as $ser) {
      # 系列内のすべてのデータセルをたどる
      foreach($ser->getDataPoints() as $cell) {
        # 数値形式を設定
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # プレゼンテーションを保存
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

利用可能なプリセット数値形式値とそれに対応するプリセットインデックスは以下の通りです：

|**0**|一般|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;赤$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;赤$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;赤-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;赤-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|[mm:ss.0](http://mmss.0)|
|**48**|##0.0E+00|
|**49**|@|

## **グラフエリアの丸い境界を設定**
Aspose.Slides for PHP via Javaは、グラフエリアの設定をサポートします。方法[**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#hasRoundedCorners--)および[**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/IChart#setRoundedCorners-boolean-)は、[IChart](https://reference.aspose.com/slides/php-java/aspose.slides/IChart)インターフェイスおよび[Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart)クラスに追加されました。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスオブジェクトをインスタンス化します。
1. スライドにグラフを追加します。
1. グラフの塗りつぶしタイプと色を設定します
1. 角丸プロパティをTrueに設定します。
1. 修正したプレゼンテーションを保存します。

以下にサンプル例を示します。

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->setStyle(LineStyle->Single);
    $chart->setRoundedCorners(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```