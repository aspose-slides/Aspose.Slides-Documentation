---
title: Android で PowerPoint チャートをアニメーション化
linktitle: アニメーション化されたチャート
type: docs
weight: 80
url: /ja/androidjava/animated-charts/
keywords:
- チャート
- アニメーション化されたチャート
- チャートのアニメーション
- チャートシリーズ
- チャートカテゴリ
- シリーズ要素
- カテゴリ要素
- エフェクトを追加
- エフェクトタイプ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して Java で驚くほど美しいアニメーションチャートを作成しましょう。PPT および PPTX ファイルで動的なビジュアルを活用し、プレゼンテーションを強化します—今すぐ始めましょう。"
---

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java はチャート要素のアニメーションをサポートしています。**Series**、**Categories**、**Series Elements**、**Categories Elements** は [**ISequence**.**addEffect**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) メソッドと、2つの列挙型 [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectChartMajorGroupingType) および [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/EffectChartMinorGroupingType) を使用してアニメーション化できます。

{{% /alert %}} 

## **チャートシリーズ アニメーション**
チャートシリーズをアニメーション化する場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションをロードします。
2. チャートオブジェクトの参照を取得します。
3. シリーズをアニメーション化します。
4. プレゼンテーションファイルをディスクに書き出します。

以下の例では、チャートシリーズをアニメーション化しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // チャート オブジェクトの参照を取得します
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // シリーズをアニメーション化します
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

    // 変更されたプレゼンテーションをディスクに保存します
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **チャートカテゴリ アニメーション**
チャートカテゴリをアニメーション化する場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションをロードします。
2. チャートオブジェクトの参照を取得します。
3. カテゴリをアニメーション化します。
4. プレゼンテーションファイルをディスクに書き出します。

以下の例では、チャートカテゴリをアニメーション化しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
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
シリーズ要素をアニメーション化する場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションをロードします。
2. チャートオブジェクトの参照を取得します。
3. シリーズ要素をアニメーション化します。
4. プレゼンテーションファイルをディスクに書き出します。

以下の例では、シリーズの要素をアニメーション化しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // チャート オブジェクトの参照を取得
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
            1, 2, EffectType.Appear, EffectSubtype.No

ne, EffectTriggerType.AfterPrevious);
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

    // プレゼンテーション ファイルをディスクに書き込む 
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **カテゴリ要素のアニメーション**
カテゴリ要素をアニメーション化する場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションをロードします。
2. チャートオブジェクトの参照を取得します。
3. カテゴリ要素をアニメーション化します。
4. プレゼンテーションファイルをディスクに書き出します。

以下の例では、カテゴリ要素をアニメーション化しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // チャート オブジェクトの参照を取得
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

    // プレゼンテーション ファイルをディスクに書き込む
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**異なる効果タイプ（例：入口、強調、退出）は、通常の図形と同様にチャートでもサポートされていますか？**

はい。チャートは図形として扱われるため、入口、強調、退出を含む標準のアニメーション効果タイプがすべてサポートされ、スライドのタイムラインとアニメーションシーケンスで完全に制御できます。

**チャートのアニメーションとスライド遷移を組み合わせることはできますか？**

はい。[Transitions](/slides/ja/androidjava/slide-transition/) はスライド全体に適用され、アニメーション効果はスライド上のオブジェクトに適用されます。両方を同じプレゼンテーションで併用でき、それぞれを独立して制御できます。

**PPTX に保存するとチャートアニメーションは保持されますか？**

はい。[save to PPTX](/slides/ja/androidjava/save-presentation/) を実行すると、すべてのアニメーション効果とその順序がプレゼンテーションのネイティブなアニメーションモデルの一部として保持されます。

**既存のチャートアニメーションを読み取って変更できますか？**

はい。API はスライドのタイムライン、シーケンス、および効果へのアクセスを提供し、既存のチャートアニメーションを検査し、すべてを最初から作り直すことなく調整できます。

**Aspose.Slides を使用してチャートアニメーションを含むビデオを作成できますか？**

はい。アニメーションを保持したままプレゼンテーションをビデオに[エクスポート](/slides/ja/androidjava/convert-powerpoint-to-video/)でき、タイミングやその他のエクスポート設定を構成して、アニメーション再生を反映したクリップを生成できます。