---
title: PHP を使用してプレゼンテーションのチャート軸をカスタマイズする
linktitle: チャート軸
type: docs
url: /ja/php-java/chart-axis/
keywords:
- チャート軸
- 垂直軸
- 水平軸
- 軸のカスタマイズ
- 軸の操作
- 軸の管理
- 軸のプロパティ
- 最大値
- 最小値
- 軸線
- 日付形式
- 軸タイトル
- 軸の位置
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "レポートや可視化のために、PowerPoint プレゼンテーションのチャート軸をカスタマイズする方法を、Java 経由で PHP 用 Aspose.Slides を使用して学びましょう。"
---

## **チャートの垂直軸の最大値を取得**
Aspose.Slides for PHP via Java を使用すると、垂直軸上の最小値と最大値を取得できます。次の手順を実行してください：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 最初のスライドにアクセスします。
1. デフォルトデータでチャートを追加します。
1. 軸上の実際の最大値を取得します。
1. 軸上の実際の最小値を取得します。
1. 軸の実際の主単位を取得します。
1. 軸の実際の副単位を取得します。
1. 軸の実際の主単位スケールを取得します。
1. 軸の実際の副単位スケールを取得します。

このサンプルコード（上記手順の実装）は、必要な値の取得方法を示しています：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # プレゼンテーションを保存します
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **軸間のデータを入れ替える**
Aspose.Slides を使用すると、軸間のデータを簡単に入れ替えることができます。垂直軸（Y 軸）のデータが水平軸（X 軸）に移動し、その逆も同様です。

この PHP コードは、チャート上で軸間のデータ入れ替えタスクを実行する方法を示しています：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # 行と列を入れ替えます
    $chart->getChartData()->switchRowColumn();
    # プレゼンテーションを保存します
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **折れ線グラフの垂直軸を無効にする**

この PHP コードは、折れ線グラフの垂直軸を非表示にする方法を示しています：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **折れ線グラフの水平軸を無効にする**

このコードは、折れ線グラフの水平軸を非表示にする方法を示しています：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **カテゴリ軸を変更する**

**CategoryAxisType** プロパティを使用して、希望するカテゴリ軸のタイプ（**date** または **text**）を指定できます。このコードは操作をデモンストレーションします：
```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **カテゴリ軸の値の日時形式を設定する**
Aspose.Slides for PHP via Java を使用すると、カテゴリ軸の値の日時形式を設定できます。この操作は PHP コードで示されています：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

```php

```


## **チャート軸タイトルの回転角度を設定する**
Aspose.Slides for PHP via Java を使用すると、チャート軸タイトルの回転角度を設定できます。この PHP コードは操作を示しています：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **カテゴリ軸または値軸の位置を設定する**
Aspose.Slides for PHP via Java を使用すると、カテゴリ軸または値軸の位置を設定できます。この PHP コードはタスクの実行方法を示しています：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **チャート値軸に単位ラベルを表示する**
Aspose.Slides for PHP via Java を使用すると、チャートの値軸に単位ラベルを表示するよう構成できます。この PHP コードは操作を示しています：
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**軸が交差する位置（軸交差点）の値はどのように設定しますか？**

軸は [crossing setting](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) を提供しています。ゼロ、最大カテゴリ/値、または特定の数値で交差させることができます。これは X 軸を上下にシフトしたり、基準線を強調したりするのに便利です。

**目盛りラベルを軸に対してどのように配置できますか（横、外側、内側）？**

[label position](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) を "cross"、"outside"、"inside" のいずれかに設定します。これにより可読性が向上し、特に小さなチャートでスペースを節約できます。