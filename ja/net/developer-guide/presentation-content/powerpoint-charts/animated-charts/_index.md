---
title: アニメーション化されたチャート
type: docs
weight: 80
url: /ja/net/animated-charts/
keywords: "チャート, チャートシリーズ, アニメーション PowerPoint プレゼンテーション, PPTX, PPT, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET での PowerPoint チャートシリーズとアニメーション"
---

Aspose.Slides for .NET はチャート要素のアニメーションをサポートしています。**Series**、**Categories**、**Series Elements**、**Categories Elements** は [**ISequence**.**AddEffect**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/methods/addeffect) メソッドと 2 つの列挙型 **EffectChartMajorGroupingType** と **EffectChartMinorGroupingType** を使用してアニメーション化できます。

## **Chart Series Animation**
チャートのシリーズをアニメーション化したい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションを読み込みます。  
1. チャート オブジェクトへの参照を取得します。  
1. シリーズをアニメーション化します。  
1. プレゼンテーション ファイルをディスクに書き出します。

以下の例では、チャートシリーズをアニメーション化しています。  
```c#
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // チャート オブジェクトへの参照を取得
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // シリーズをアニメーション化
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,
    EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 0,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 1,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 2,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,
    EffectChartMajorGroupingType.BySeries, 3,
    EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // 変更されたプレゼンテーションをディスクに保存
    presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
}
```


## **Chart Category Animation**
チャートのカテゴリをアニメーション化したい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションを読み込みます。  
1. チャート オブジェクトへの参照を取得します。  
1. カテゴリをアニメーション化します。  
1. プレゼンテーション ファイルをディスクに書き出します。

以下の例では、チャートカテゴリをアニメーション化しています。  
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // チャートオブジェクトへの参照を取得
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // カテゴリ要素をアニメーション化
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // プレゼンテーションファイルをディスクに保存
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **Animation in Series Element**
シリーズ要素をアニメーション化したい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションを読み込みます。  
1. チャート オブジェクトへの参照を取得します。  
1. シリーズ要素をアニメーション化します。  
1. プレゼンテーション ファイルをディスクに書き出します。

以下の例では、シリーズの要素をアニメーション化しました。  
```c#
 // プレゼンテーションを読み込む
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // チャートオブジェクトへの参照を取得
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // シリーズ要素をアニメーション化
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // プレゼンテーションファイルをディスクに保存
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **Animation in Category Element**
カテゴリ要素をアニメーション化したい場合は、以下の手順に従ってコードを記述します。

1. プレゼンテーションを読み込みます。  
1. チャート オブジェクトへの参照を取得します。  
1. カテゴリ要素をアニメーション化します。  
1. プレゼンテーション ファイルをディスクに書き出します。

以下の例では、カテゴリ要素をアニメーション化しました。  
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // チャートオブジェクトへの参照を取得
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // カテゴリ要素をアニメーション化
    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // プレゼンテーションファイルをディスクに保存
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Are different effect types (e.g., entrance, emphasis, exit) supported for charts like for regular shapes?**

はい。チャートはシェイプとして扱われるため、エントランス、エンファシス、エグジットなどの標準的なアニメーション効果タイプがすべてサポートされ、スライドのタイムラインとアニメーション シーケンスでフルコントロールできます。

**Can I combine chart animation with slide transitions?**

はい。[Transitions](/slides/ja/net/slide-transition/) はスライド全体に適用され、アニメーション効果はスライド上のオブジェクトに適用されます。両方を同じプレゼンテーションで組み合わせて使用でき、それぞれを個別に制御できます。

**Are chart animations preserved when saving to PPTX?**

はい。プレゼンテーションを[save to PPTX](/slides/ja/net/save-presentation/) すると、すべてのアニメーション効果とその順序がプレゼンテーションのネイティブ アニメーション モデルの一部として保持されます。

**Can I read existing chart animations from a presentation and modify them?**

はい。[API](https://reference.aspose.com/slides/net/aspose.slides.animation/) はスライドのタイムライン、シーケンス、エフェクトへのアクセスを提供し、既存のチャート アニメーションを検査し、最初から作り直すことなく変更できます。

**Can I produce a video that includes chart animations using Aspose.Slides?**

はい。プレゼンテーションを[export a presentation to video](/slides/ja/net/convert-powerpoint-to-video/) すると、アニメーションを保持したままビデオにエクスポートでき、タイミングやその他のエクスポート設定を構成して、アニメーション再生を反映したクリップを作成できます。