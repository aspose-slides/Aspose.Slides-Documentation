---
title: JavaでPowerPointチャートをアニメーション化
linktitle: アニメーション化されたチャート
type: docs
weight: 80
url: /ja/java/animated-charts/
keywords:
- チャート
- アニメーション化されたチャート
- チャートアニメーション
- チャート系列
- チャートカテゴリ
- 系列要素
- カテゴリ要素
- エフェクトを追加
- エフェクトタイプ
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java で魅力的なアニメーションチャートを作成します。PPT および PPTX ファイルで動的なビジュアルでプレゼンテーションを強化し、今すぐ開始しましょう。"
---

{{% alert color="primary" %}} 

Aspose.Slides for Java はチャート要素のアニメーションをサポートしています。 **Series**、**Categories**、**Series Elements**、**Categories Elements** は [**ISequence**.**addEffect**](https://reference.aspose.com/slides/java/com.aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) メソッドと、2 つの列挙型 [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMajorGroupingType) と [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/java/com.aspose.slides/EffectChartMinorGroupingType) を使用してアニメーション化できます。

{{% /alert %}} 

## **チャート系列アニメーション**
チャート系列をアニメーション化したい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションを読み込みます。
1. チャートオブジェクトの参照を取得します。
1. 系列をアニメーション化します。
1. プレゼンテーションファイルをディスクに書き込みます。

以下の例では、チャート系列をアニメーション化しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // チャート オブジェクトの参照を取得
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0);

    // 系列をアニメーション化
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

    // 変更されたプレゼンテーションをディスクに保存
    pres.save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **チャートカテゴリアニメーション**
チャートカテゴリをアニメーション化したい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションを読み込みます。
1. チャートオブジェクトの参照を取得します。
1. カテゴリをアニメーション化します。
1. プレゼンテーションファイルをディスクに書き込みます。

以下の例では、チャートカテゴリをアニメーション化しています。
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShapeCollection shapes = slide.getShapes();
    IChart chart = (IChart) shapes.get_Item(0");

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


## **系列要素のアニメーション**
系列要素をアニメーション化したい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションを読み込みます。
1. チャートオブジェクトの参照を取得します。
1. 系列要素をアニメーション化します。
1. プレゼンテーションファイルをディスクに書き込みます。

以下の例では、系列の要素をアニメーション化しています。
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

    // プレゼンテーション ファイルをディスクに保存
    pres.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **カテゴリ要素のアニメーション**
カテゴリ要素をアニメーション化したい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションを読み込みます。
1. チャートオブジェクトの参照を取得します。
1. カテゴリ要素をアニメーション化します。
1. プレゼンテーションファイルをディスクに書き込みます。

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

    // プレゼンテーション ファイルをディスクに保存
    pres.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**異なる効果タイプ（例：開始、強調、終了）は、通常の図形と同様にチャートでもサポートされていますか？**

はい。チャートは図形として扱われるため、開始、強調、終了を含む標準のアニメーション効果タイプをサポートしており、スライドのタイムラインやアニメーションシーケンスを通じてフルコントロールが可能です。

**チャートのアニメーションとスライド遷移を組み合わせることはできますか？**

はい。[Transitions](/slides/ja/java/slide-transition/) はスライド全体に適用され、アニメーション効果はスライド上のオブジェクトに適用されます。両方を同一のプレゼンテーションで併用し、個別に制御できます。

**PPTX に保存したときにチャートアニメーションは保持されますか？**

はい。[save to PPTX](/slides/ja/java/save-presentation/) を使用して保存すると、すべてのアニメーション効果とその順序がプレゼンテーションのネイティブなアニメーションモデルの一部として保持されます。

**既存のプレゼンテーションからチャートアニメーションを読み取り、修正できますか？**

はい。API はスライドのタイムライン、シーケンス、エフェクトへのアクセスを提供し、既存のチャートアニメーションを検査し、最初から作り直すことなく調整できます。

**Aspose.Slides を使用してチャートアニメーションを含むビデオを作成できますか？**

はい。[export a presentation to video](/slides/ja/java/convert-powerpoint-to-video/) でアニメーションを保持したままビデオにエクスポートでき、タイミングやその他のエクスポート設定を構成して、アニメーション再生を反映したクリップを生成できます。