---
title: PHPでプレゼンテーションチャートをフォーマットする
linktitle: チャートの書式設定
type: docs
weight: 60
url: /ja/php-java/chart-formatting/
keywords:
- チャートをフォーマット
- チャート書式設定
- チャートエンティティ
- チャートプロパティ
- チャート設定
- チャートオプション
- フォントプロパティ
- 角丸境界線
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java のチャート書式設定を学び、プロフェッショナルで目を引くスタイルで PowerPoint プレゼンテーションを向上させましょう。"
---

## **Format Chart Entities**
Aspose.Slides for PHP via Java では、開発者はスライドにカスタム チャートをゼロから追加できます。本記事では、チャートのカテゴリ軸と値軸を含むさまざまなチャート エンティティの書式設定方法を説明します。

Aspose.Slides for PHP via Java は、さまざまなチャート エンティティを管理し、カスタム値で書式設定するためのシンプルな API を提供します。

1. [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. 任意のタイプ（この例では ChartType::LineWithMarkers）でデフォルト データを持つチャートを追加します。
1. チャートの値軸にアクセスし、次のプロパティを設定します。
   1. 値軸メジャー グリッド線の **Line format** を設定
   1. 値軸マイナー グリッド線の **Line format** を設定
   1. 値軸の **Number Format** を設定
   1. 値軸の **Min, Max, Major and Minor units** を設定
   1. 値軸データの **Text Properties** を設定
   1. 値軸の **Title** を設定
   1. 値軸の **Line Format** を設定
1. チャートのカテゴリ軸にアクセスし、次のプロパティを設定します。
   1. カテゴリ軸メジャー グリッド線の **Line format** を設定
   1. カテゴリ軸マイナー グリッド線の **Line format** を設定
   1. カテゴリ軸データの **Text Properties** を設定
   1. カテゴリ軸の **Title** を設定
   1. カテゴリ軸の **Label Positioning** を設定
   1. カテゴリ軸ラベルの **Rotation Angle** を設定
1. チャートの凡例にアクセスし、**Text Properties** を設定します。
1. チャートの凡例がチャートと重ならないように表示します。
1. チャートの **Secondary Value Axis** にアクセスし、次のプロパティを設定します。
   1. セカンダリ **Value Axis** を有効化
   1. セカンダリ値軸の **Line Format** を設定
   1. セカンダリ値軸の **Number Format** を設定
   1. セカンダリ値軸の **Min, Max, Major and Minor units** を設定
1. セカンダリ値軸に最初のチャート系列をプロットします。
1. チャートの裏壁の塗りつぶし色を設定します。
1. チャートのプロット領域の塗りつぶし色を設定します。
1. 変更したプレゼンテーションを PPTX ファイルに書き込みます
```php
  # Presentation クラスのインスタンスを作成する
  $pres = new Presentation();
  try {
    # 最初のスライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # サンプルチャートを追加する
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);
    # チャートタイトルを設定する
    $chart->hasTitle();
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # 値軸の主要グリッド線の形式を設定する
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    # 値軸の補助グリッド線の形式を設定する
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # 値軸の数値形式を設定する
    $chart->getAxes()->getVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");
    # チャートの最大・最小値を設定する
    $chart->getAxes()->getVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getVerticalAxis()->setMaxValue(15.0);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2.0);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);
    # 値軸のテキストプロパティを設定する
    $txtVal = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $txtVal->setFontBold(NullableBool::True);
    $txtVal->setFontHeight(16);
    $txtVal->setFontItalic(NullableBool::True);
    $txtVal->getFillFormat()->setFillType(FillType::Solid);
    $txtVal->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkGreen));
    $txtVal->setLatinFont(new FontData("Times New Roman"));
    # 値軸のタイトルを設定する
    $chart->getAxes()->getVerticalAxis()->hasTitle();
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valtitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valtitle->setText("Primary Axis");
    $valtitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valtitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valtitle->getPortionFormat()->setFontHeight(20);
    $valtitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valtitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # カテゴリ軸の主要グリッド線の形式を設定する
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    # カテゴリ軸の補助グリッド線の形式を設定する
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);
    # カテゴリ軸のテキストプロパティを設定する
    $txtCat = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $txtCat->setFontBold(NullableBool::True);
    $txtCat->setFontHeight(16);
    $txtCat->setFontItalic(NullableBool::True);
    $txtCat->getFillFormat()->setFillType(FillType::Solid);
    $txtCat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $txtCat->setLatinFont(new FontData("Arial"));
    # カテゴリのタイトルを設定する
    $chart->getAxes()->getHorizontalAxis()->hasTitle();
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");
    $catTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $catTitle->setText("Sample Category");
    $catTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $catTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $catTitle->getPortionFormat()->setFontHeight(20);
    $catTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $catTitle->getPortionFormat()->setFontItalic(NullableBool::True);
    # カテゴリ軸ラベルの位置を設定する
    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    # カテゴリ軸ラベルの回転角度を設定する
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);
    # 凡例のテキストプロパティを設定する
    $txtleg = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $txtleg->setFontBold(NullableBool::True);
    $txtleg->setFontHeight(16);
    $txtleg->setFontItalic(NullableBool::True);
    $txtleg->getFillFormat()->setFillType(FillType::Solid);
    $txtleg->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->DarkRed));
    # チャートと重ならないように凡例を表示する
    $chart->getLegend()->setOverlay(true);
    # chart.ChartData.Series[0].PlotOnSecondAxis=true;
    $chart->getChartData()->getSeries()->get_Item(0)->setPlotOnSecondAxis(true);
    # 二次値軸を設定する
    $chart->getAxes()->getSecondaryVerticalAxis()->isVisible();
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setStyle(LineStyle->ThickBetweenThin);
    $chart->getAxes()->getSecondaryVerticalAxis()->getFormat()->getLine()->setWidth(20);
    # 二次値軸の数値形式を設定する
    $chart->getAxes()->getSecondaryVerticalAxis()->isNumberFormatLinkedToSource();
    $chart->getAxes()->getSecondaryVerticalAxis()->setDisplayUnit(DisplayUnitType::Hundreds);
    $chart->getAxes()->getSecondaryVerticalAxis()->setNumberFormat("0.0%");
    # チャートの最大・最小値を設定する
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMajorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMaxValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinorUnit();
    $chart->getAxes()->getSecondaryVerticalAxis()->isAutomaticMinValue();
    $chart->getAxes()->getSecondaryVerticalAxis()->setMaxValue(20.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinValue(-5.0);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getSecondaryVerticalAxis()->setMajorUnit(2.0);
    # チャートの背面壁の色を設定する
    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # プロット領域の色を設定する
    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->LightCyan));
    # プレゼンテーションを保存する
    $pres->save("FormattedChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Set Font Properties for a Chart**
Aspose.Slides for PHP via Java は、チャートのフォント関連プロパティの設定をサポートします。以下の手順でチャートのフォントプロパティを設定してください。

- [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスのオブジェクトをインスタンス化します。
- スライドにチャートを追加します。
- フォントの高さを設定します。
- 変更したプレゼンテーションを保存します。

以下にサンプル例を示します。
```php
  # Presentation クラスのインスタンスを作成する
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


## **Set the Numeric Format**
Aspose.Slides for PHP via Java は、チャート データの書式設定を管理するシンプルな API を提供します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. 任意のタイプ（この例では **ChartType::ClusteredColumn**）でデフォルト データを持つチャートを追加します。
1. 可能なプリセット値から事前設定の数値書式を設定します。
1. 各チャート系列のチャート データ セルを走査し、チャート データの数値書式を設定します。
1. プレゼンテーションを保存します。
1. カスタム数値書式を設定します。
1. 各チャート系列内のチャート データ セルを走査し、異なるチャート データ数値書式を設定します。
1. プレゼンテーションを保存します。
```php
  # Presentation クラスのインスタンスを作成する
  $pres = new Presentation();
  try {
    # 最初のプレゼンテーション スライドにアクセスする
    $slide = $pres->getSlides()->get_Item(0);
    # デフォルトのクラスター化カラム チャートを追加する
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    # チャート系列コレクションにアクセスする
    $series = $chart->getChartData()->getSeries();
    # すべてのチャート系列を走査する
    foreach($series as $ser) {
      # 系列内のすべてのデータセルを走査する
      foreach($ser->getDataPoints() as $cell) {
        # 数値形式を設定する
        $cell->getValue()->getAsCell()->setPresetNumberFormat(10);// 0.00%

      }
    }
    # プレゼンテーションを保存する
    $pres->save("PresetNumberFormat.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


使用できる事前設定の数値書式とそのインデックスは以下のとおりです。

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
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
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Set Chart Area Rounded Borders**
Aspose.Slides for PHP via Java は、チャート領域の設定をサポートします。メソッド [**hasRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasroundedcorners/) と [**setRoundedCorners**](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setroundedcorners/) が [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/Chart) クラスに追加されました。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのオブジェクトをインスタンス化します。
1. スライドにチャートを追加します。
1. チャートの塗りつぶしタイプと塗りつぶし色を設定します。
1. 角丸プロパティを True に設定します。
1. 変更したプレゼンテーションを保存します。

以下にサンプル例を示します。 
```php
  # Presentation クラスのインスタンスを作成する
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


## **FAQ**

**列やエリアの塗りつぶしを半透明にし、枠線は不透明のままにできますか？**

はい。塗りつぶしの透明度と輪郭は別々に設定できます。これは、グリッドやデータが密集した可視化で可読性を向上させるのに役立ちます。

**ラベルが重なる場合、どう対処すればよいですか？**

フォントサイズを小さくする、不要なラベル要素（例: カテゴリ）を無効にする、ラベルのオフセット/位置を設定する、必要に応じて選択ポイントのみラベルを表示する、または「値＋凡例」形式に切り替えるなどの方法があります。

**系列にグラデーションやパターンの塗りつぶしを適用できますか？**

はい。ソリッド塗りつぶしと同様に、グラデーションやパターン塗りつぶしも利用可能です。実務ではグラデーションの使用は控えめにし、グリッドやテキストとのコントラストが低下する組み合わせは避けてください。