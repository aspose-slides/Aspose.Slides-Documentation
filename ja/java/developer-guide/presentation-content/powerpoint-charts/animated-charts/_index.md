---
title: JavaでPowerPointチャートをアニメーション化
linktitle: アニメーション化されたチャート
type: docs
weight: 80
url: /ja/java/animated-charts/
keywords:
- チャート
- アニメーション化されたチャート
- チャート アニメーション
- チャートシリーズ
- チャートカテゴリ
- シリーズ要素
- カテゴリ要素
- エフェクトを追加
- エフェクトタイプ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java で驚くほど魅力的なアニメーションチャートを作成しましょう。PPT と PPTX ファイルで動的なビジュアルを加えてプレゼンテーションを強化します——今すぐ始めましょう。"
---

{{% alert color="primary" %}} 

Aspose.Slides for Java はチャート要素のアニメーションをサポートしています。**Series**、**Categories**、**Series Elements**、**Categories Elements** は [**ISequence**.**addEffect**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) メソッドと、2つの列挙体 [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMajorGroupingType) と [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMinorGroupingType) を使用してアニメーション化できます。

{{% /alert %}} 

## **チャートシリーズのアニメーション**
チャートシリーズをアニメーションさせたい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションをロードします。
1. チャート オブジェクトへの参照を取得します。
1. シリーズをアニメーションさせます。
1. プレゼンテーション ファイルをディスクに書き出します。

以下の例では、チャートシリーズをアニメーションさせました。
```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを生成
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // チャートオブジェクトへの参照を取得
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // シリーズをアニメーション化
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 0,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 1,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 2,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.BySeries, 3,
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 変更したプレゼンテーションをディスクに保存
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **チャートカテゴリのアニメーション**
チャートカテゴリをアニメーションさせたい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションをロードします。
1. チャート オブジェクトへの参照を取得します。
1. カテゴリをアニメーションさせます。
1. プレゼンテーション ファイルをディスクに書き出します。

以下の例では、チャートカテゴリをアニメーションさせました。
```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None,
            EffectTriggerType.AfterPrevious);

    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart,
            EffectChartMajorGroupingType.ByCategory, 0, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 1, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 2, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    
    ((Sequence) slide.getTimeline().getMainSequence()).addEffect(chart, 
            EffectChartMajorGroupingType.ByCategory, 3, 
            EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.save("Sample_Animation_C.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **シリーズ要素のアニメーション**
シリーズ要素をアニメーションさせたい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションをロードします。
1. チャート オブジェクトへの参照を取得します。
1. シリーズ要素をアニメーションさせます。
1. プレゼンテーション ファイルをディスクに書き出します。

以下の例では、シリーズ要素をアニメーションさせました。
```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // チャートオブジェクトへの参照を取得
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // シリーズ要素をアニメーション化
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // プレゼンテーションファイルを書き出し 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **カテゴリ要素のアニメーション**
カテゴリ要素をアニメーションさせたい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションをロードします。
1. チャート オブジェクトへの参照を取得します。
1. カテゴリ要素をアニメーションさせます。
1. プレゼンテーション ファイルをディスクに書き出します。

以下の例では、カテゴリ要素をアニメーションさせました。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを生成
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // チャートオブジェクトへの参照を取得
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // カテゴリ要素をアニメーション化
    slide.getTimeline().getMainSequence().addEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.getTimeline().getMainSequence()).addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 
            2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // プレゼンテーション ファイルを書き出し
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**異なる効果タイプ（例: 入場、強調、退出）は、通常の図形と同様にチャートでもサポートされていますか？**

はい。チャートは図形として扱われるため、入場、強調、退出を含む標準のアニメーション効果タイプがすべてサポートされており、スライドのタイムラインおよびアニメーション シーケンスで完全に制御できます。

**チャート アニメーションとスライド遷移を組み合わせることはできますか？**

はい。[Transitions](/slides/ja/java/slide-transition/) はスライド全体に適用され、アニメーション効果はスライド上のオブジェクトに適用されます。両方を同一プレゼンテーションで併用し、個別に制御できます。

**PPTX に保存したときにチャート アニメーションは保持されますか？**

はい。[save to PPTX](/slides/ja/java/save-presentation/) を実行すると、すべてのアニメーション効果とその順序がプレゼンテーションのネイティブ アニメーション モデルの一部として保持されます。

**既存のプレゼンテーションからチャート アニメーションを読み取って変更できますか？**

はい。API はスライド タイムライン、シーケンス、エフェクトへのアクセスを提供し、既存のチャート アニメーションを検査して、最初からやり直すことなく調整できます。

**Aspose.Slides を使用してチャート アニメーションを含むビデオを作成できますか？**

はい。[export a presentation to video](/slides/ja/java/convert-powerpoint-to-video/) でプレゼンテーションをビデオにエクスポートすると、アニメーションが保持され、タイミングやその他のエクスポート設定を構成して、アニメーション再生を反映したクリップを生成できます。