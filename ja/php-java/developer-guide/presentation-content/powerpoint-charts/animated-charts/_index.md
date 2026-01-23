---
title: PHPでPowerPointチャートをアニメーション化
linktitle: アニメーション化されたチャート
type: docs
weight: 80
url: /ja/php-java/animated-charts/
keywords:
- チャート
- アニメーション化されたチャート
- チャートアニメーション
- チャートシリーズ
- チャートカテゴリ
- シリーズ要素
- カテゴリ要素
- エフェクトを追加
- エフェクトタイプ
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、魅力的なアニメーションチャートを作成しましょう。PPT および PPTX ファイルで動的なビジュアルを加えてプレゼンテーションを強化します — 今すぐ始めましょう。"
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java はチャート要素のアニメーションをサポートします。 **Series**、**Categories**、**Series Elements**、**Categories Elements** は [**Sequence::addEffect**](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/#addEffect) メソッドと、2 つの列挙型 [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMajorGroupingType) および [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMinorGroupingType) を使用してアニメーション化できます。

{{% /alert %}} 

## **Chart Series Animation**
チャートシリーズをアニメーション化したい場合、以下の手順に従ってコードを記述してください。

1. プレゼンテーションをロードする。
1. チャート オブジェクトへの参照を取得する。
1. シリーズをアニメーション化する。
1. プレゼンテーション ファイルを書き出す。

以下の例では、チャートシリーズをアニメーション化しています。
```php
  # プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # チャートオブジェクトの参照を取得
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # シリーズをアニメーション化
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


## **Chart Category Animation**
チャートカテゴリをアニメーション化したい場合、以下の手順に従ってコードを記述してください。

1. プレゼンテーションをロードする。
1. チャート オブジェクトへの参照を取得する。
1. カテゴリをアニメーション化する。
1. プレゼンテーション ファイルを書き出す。

以下の例では、チャートカテゴリをアニメーション化しています。
```php
  # プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
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


## **Animation in a Series Element**
シリーズ要素をアニメーション化したい場合、以下の手順に従ってコードを記述してください。

1. プレゼンテーションをロードする。
1. チャート オブジェクトへの参照を取得する。
1. シリーズ要素をアニメーション化する。
1. プレゼンテーション ファイルを書き出す。

以下の例では、シリーズ要素をアニメーション化しています。
```php
  # プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # チャートオブジェクトの参照を取得
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
    # プレゼンテーションファイルをディスクに保存
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animation in a Category Element**
カテゴリ要素をアニメーション化したい場合、以下の手順に従ってコードを記述してください。

1. プレゼンテーションをロードする。
1. チャート オブジェクトへの参照を取得する。
1. カテゴリ要素をアニメーション化する。
1. プレゼンテーション ファイルを書き出す。

以下の例では、カテゴリ要素をアニメーション化しています。
```php
  # プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
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
    # プレゼンテーションファイルをディスクに保存
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**異なる効果タイプ（例：入口、強調、終了）は、通常のシェイプと同様にチャートでもサポートされていますか？**

はい。チャートはシェイプとして扱われるため、入口、強調、終了を含む標準のアニメーション効果タイプをサポートし、スライドのタイムラインやアニメーション シーケンスを通じてフルコントロールできます。

**チャートのアニメーションをスライド遷移と組み合わせることはできますか？**

はい。[Transitions](/slides/ja/php-java/slide-transition/)はスライド全体に適用され、アニメーション効果はスライド上のオブジェクトに適用されます。両方を同じプレゼンテーションで併用し、個別に制御できます。

**PPTX に保存したときにチャートアニメーションは保持されますか？**

はい。[save to PPTX](/slides/ja/php-java/save-presentation/)すると、すべてのアニメーション効果とその順序がプレゼンテーションのネイティブ アニメーション モデルの一部として保持されます。

**既存のプレゼンテーションからチャートアニメーションを読み取り、変更することはできますか？**

はい。API はスライドのタイムライン、シーケンス、エフェクトへのアクセスを提供し、既存のチャートアニメーションを検査し、ゼロから作り直すことなく調整できます。

**Aspose.Slides を使用してチャートアニメーションを含むビデオを作成できますか？**

はい。アニメーションを保持したまま、タイミングやその他のエクスポート設定を構成して、プレゼンテーションをビデオにエクスポートすることができます。[export a presentation to video](/slides/ja/php-java/convert-powerpoint-to-video/)をご参照ください。