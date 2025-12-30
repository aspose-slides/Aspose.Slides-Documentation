---
title: PHP を使用したプレゼンテーション チャートでエラーバーをカスタマイズ
linktitle: エラーバー
type: docs
url: /ja/php-java/error-bar/
keywords:
- エラーバー
- カスタム値
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用してチャートにエラーバーを追加およびカスタマイズする方法を学び、PowerPoint プレゼンテーションのデータ可視化を最適化します。"
---

## **エラーバーを追加**
Aspose.Slides for PHP via Java はエラーバーの値を管理するためのシンプルな API を提供します。サンプルコードはカスタム値タイプを使用する場合に適用されます。値を指定するには、シリーズの [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection) コレクション内の特定のデータ ポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 目的のスライドにバブル チャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバー X の書式を設定します。
1. 最初のチャート系列にアクセスし、エラーバー Y の書式を設定します。
1. バーの値と書式を設定します。
1. 変更したプレゼンテーションを PPTX ファイルに書き出します。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # バブルチャートを作成
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # エラーバーを追加し、その書式を設定
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # プレゼンテーションを保存
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **カスタムエラーバー値の追加**
Aspose.Slides for PHP via Java はカスタム エラーバー値を管理するためのシンプルな API を提供します。サンプルコードは [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/IErrorBarsFormat#getValue--) プロパティが **Custom** に等しい場合に適用されます。値を指定するには、シリーズの [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection) コレクション内の特定のデータ ポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 目的のスライドにバブル チャートを追加します。
1. 最初のチャート系列にアクセスし、エラーバー X の書式を設定します。
1. 最初のチャート系列にアクセスし、エラーバー Y の書式を設定します。
1. チャート系列の個々のデータ ポイントにアクセスし、個々の系列データ ポイントのエラーバー値を設定します。
1. バーの値と書式を設定します。
1. 変更したプレゼンテーションを PPTX ファイルに書き出します。
```php
  # Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # バブルチャートを作成
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # カスタム エラーバーを追加し、その書式を設定
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # チャート系列のデータポイントにアクセスし、エラーバーの値を設定
    # 個々のポイント用
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # チャート系列ポイントのエラーバーを設定
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # プレゼンテーションを保存
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **よくある質問**

**プレゼンテーションを PDF や画像にエクスポートしたとき、エラーバーはどうなりますか？**

エラーバーはチャートの一部としてレンダリングされ、互換性のあるバージョンまたはレンダラを使用している場合、変換中もチャートの他の書式と同様に保持されます。

**エラーバーをマーカーやデータ ラベルと組み合わせることはできますか？**

はい。エラーバーは別個の要素であり、マーカーやデータ ラベルと互換性があります。要素が重なる場合は、書式を調整する必要がある場合があります。

**API でエラーバーを操作するためのプロパティやクラスの一覧はどこで確認できますか？**

API リファレンスで確認できます。[ErrorBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/) クラスと、関連クラスの [ErrorBarType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbartype/) および [ErrorBarValueType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarvaluetype/) です。