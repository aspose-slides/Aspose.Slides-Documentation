---
title: PHP を使用してプレゼンテーション チャートのエラーバーをカスタマイズ
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

## **エラーバーの追加**
Aspose.Slides for PHP via Java はエラーバー値を管理するためのシンプルな API を提供します。サンプルコードはカスタム値タイプを使用する場合に適用されます。値を指定するには、シリーズの [**data points**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/) コレクション内の特定のデータ ポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 任意のスライドにバブル チャートを追加します。
1. 最初のチャート シリーズにアクセスし、エラーバー X 形式を設定します。
1. 最初のチャート シリーズにアクセスし、エラーバー Y 形式を設定します。
1. バーの値と形式を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # バブルチャートを作成します
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # エラーバーを追加し、その書式を設定します
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
    # プレゼンテーションを保存します
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **カスタム エラーバー値の追加**
Aspose.Slides for PHP via Java はカスタム エラーバー値を管理するためのシンプルな API を提供します。サンプルコードは [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/#getValueType) メソッドが **Custom** を返す場合に適用されます。値を指定するには、シリーズの [**data points**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/) コレクション内の特定のデータ ポイントの **ErrorBarCustomValues** プロパティを使用します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 任意のスライドにバブル チャートを追加します。
1. 最初のチャート シリーズにアクセスし、エラーバー X 形式を設定します。
1. 最初のチャート シリーズにアクセスし、エラーバー Y 形式を設定します。
1. チャート シリーズの個々のデータ ポイントにアクセスし、個別のシリーズ データ ポイントのエラーバー値を設定します。
1. バーの値と形式を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。
```php
  # Presentation クラスのインスタンスを作成します
  $pres = new Presentation();
  try {
    # バブルチャートを作成します
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # カスタム エラーバーを追加し、その書式を設定します
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # チャートシリーズのデータポイントにアクセスし、エラーバーの値を設定します
    # 個別のポイント
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # チャートシリーズのポイントにエラーバーを設定します
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # プレゼンテーションを保存します
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**プレゼンテーションを PDF または画像にエクスポートしたとき、エラーバーはどうなりますか？**

エラーバーはチャートの一部としてレンダリングされ、変換時にチャートの他の書式設定と同様に保持されます（互換性のあるバージョンまたはレンダラーを使用した場合）。

**エラーバーはマーカーやデータ ラベルと組み合わせて使用できますか？**

はい。エラーバーは別個の要素であり、マーカーやデータ ラベルと互換性があります。要素が重なる場合は、書式設定を調整する必要があります。

**API でエラーバーを操作するためのプロパティやクラスの一覧はどこで確認できますか？**

API リファレンスで確認できます： [ErrorBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/) クラスと、関連クラスの [ErrorBarType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbartype/) および [ErrorBarValueType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarvaluetype/)。