---
title: PHPでPowerPointチャートをアニメーション化
linktitle: アニメーション化されたチャート
type: docs
weight: 80
url: /ja/php-java/animated-charts/
keywords:
- チャート
- アニメーションチャート
- チャートアニメーション
- チャートシリーズ
- チャートカテゴリ
- シリーズ要素
- カテゴリ要素
- エフェクト追加
- エフェクトタイプ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、見事なアニメーションチャートを作成しましょう。PPT と PPTX ファイルで動的なビジュアルを加えてプレゼンテーションを強化し、今すぐ始めましょう。"
---

{{% alert color="primary" %}} 
Aspose.Slides for PHP via Java はチャート要素のアニメーションをサポートします。**Series**、**Categories**、**Series Elements**、**Categories Elements** は [**ISequence**.**addEffect**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) メソッドと、2つの列挙型 [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMajorGroupingType) と [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMinorGroupingType) を使用してアニメーション化できます。
{{% /alert %}} 

## **チャートシリーズ アニメーション**
チャートのシリーズをアニメーション化したい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションをロードします。
1. チャートオブジェクトの参照を取得します。
1. シリーズをアニメーション化します。
1. プレゼンテーションファイルをディスクに書き出します。

以下の例では、チャートのシリーズをアニメーション化しています。
```php
  # プレゼンテーションファイルを表す Presentation クラスのインスタンス化
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # チャートオブジェクトの参照を取得
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # シリーズをアニメート
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # 変更されたプレゼンテーションをディスクに保存
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **チャートカテゴリ アニメーション**
チャートのカテゴリをアニメーション化したい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションをロードします。
1. チャートオブジェクトの参照を取得します。
1. カテゴリをアニメーション化します。
1. プレゼンテーションファイルをディスクに書き出します。

以下の例では、チャートのカテゴリをアニメーション化しています。
```php
  # プレゼンテーションファイルを表す Presentation クラスのインスタンス化
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **シリーズ要素のアニメーション**
シリーズ要素をアニメーション化したい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションをロードします。
1. チャートオブジェクトの参照を取得します。
1. シリーズ要素をアニメーション化します。
1. プレゼンテーションファイルをディスクに書き出します。

以下の例では、シリーズの要素をアニメーション化しています。
```php
  # プレゼンテーション ファイルを表す Presentation クラスをインスタンス化
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # チャート オブジェクトの参照を取得
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # シリーズ要素をアニメーション化
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # プレゼンテーション ファイルをディスクに書き込む
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **カテゴリ要素のアニメーション**
カテゴリ要素をアニメーション化したい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションをロードします。
1. チャートオブジェクトの参照を取得します。
1. カテゴリ要素をアニメーション化します。
1. プレゼンテーションファイルをディスクに書き出します。

以下の例では、カテゴリ要素をアニメーション化しています。
```php
  # プレゼンテーションファイルを表す Presentation クラスをインスタンス化
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # チャートオブジェクトの参照を取得
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # カテゴリ要素をアニメーション化
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # プレゼンテーションファイルをディスクに書き込む
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**チャートは通常のシェイプと同様に、エントランス、エンファシス、エグジットなどの異なるエフェクトタイプがサポートされていますか？**

はい。チャートはシェイプとして扱われるため、エントランス、エンファシス、エグジットなどの標準的なアニメーション効果タイプがサポートされており、スライドのタイムラインとアニメーションシーケンスを通じてフルコントロールできます。

**チャートのアニメーションとスライド遷移を組み合わせることはできますか？**

はい。[Transitions](/slides/ja/php-java/slide-transition/) はスライド全体に適用され、アニメーション効果はスライド上のオブジェクトに適用されます。両方を同じプレゼンテーション内で併用し、個別に制御することが可能です。

**PPTX に保存した際にチャートのアニメーションは保持されますか？**

はい。[save to PPTX](/slides/ja/php-java/save-presentation/) を実行すると、すべてのアニメーション効果と順序が保持されます。これはプレゼンテーションのネイティブなアニメーションモデルの一部であるためです。

**既存のプレゼンテーションからチャートのアニメーションを読み取り、変更することはできますか？**

はい。API はスライドのタイムライン、シーケンス、エフェクトへのアクセスを提供しており、既存のチャートアニメーションを検査し、ゼロから作り直すことなく調整できます。

**Aspose.Slides を使用して、チャートアニメーションを含むビデオを作成できますか？**

はい。[export a presentation to video](/slides/ja/php-java/convert-powerpoint-to-video/) を使用して、アニメーションを保持したままビデオにエクスポートできます。タイミングやその他のエクスポート設定を構成することで、生成されたクリップはアニメーション再生を反映します。