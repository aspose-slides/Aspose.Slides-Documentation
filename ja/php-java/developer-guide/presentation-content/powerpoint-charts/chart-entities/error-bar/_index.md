---
title: エラーバー
type: docs
url: /ja/php-java/error-bar/
---

## **エラーバーの追加**
Aspose.Slides for PHP via Javaは、エラーバーの値を管理するためのシンプルなAPIを提供します。サンプルコードは、カスタム値タイプを使用する場合に適用されます。値を指定するには、シリーズの[**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection)コレクション内の特定のデータポイントの**ErrorBarCustomValues**プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 希望のスライドにバブルチャートを追加します。
1. 最初のチャートシリーズにアクセスし、エラーバーX形式を設定します。
1. 最初のチャートシリーズにアクセスし、エラーバーY形式を設定します。
1. バーの値と形式を設定します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # バブルチャートを作成
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # エラーバーを追加し、その形式を設定
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
Aspose.Slides for PHP via Javaは、カスタムエラーバーの値を管理するためのシンプルなAPIを提供します。サンプルコードは、[**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/IErrorBarsFormat#getValue--)プロパティが**Custom**に等しい場合に適用されます。値を指定するには、シリーズの[**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection)コレクション内の特定のデータポイントの**ErrorBarCustomValues**プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成します。
1. 希望のスライドにバブルチャートを追加します。
1. 最初のチャートシリーズにアクセスし、エラーバーX形式を設定します。
1. 最初のチャートシリーズにアクセスし、エラーバーY形式を設定します。
1. チャートシリーズの個別のデータポイントにアクセスし、個別のシリーズデータポイントのエラーバー値を設定します。
1. バーの値と形式を設定します。
1. 修正したプレゼンテーションをPPTXファイルに書き込みます。

```php
  # Presentationクラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # バブルチャートを作成
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # カスタムエラーバーを追加し、その形式を設定
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # チャートシリーズのデータポイントにアクセスし、エラーバーの値を設定
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # チャートシリーズのポイントに対してエラーバーを設定
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