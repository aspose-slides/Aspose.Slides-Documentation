---
title: .NET で PowerPoint チャートをアニメーション化
linktitle: アニメーション化されたチャート
type: docs
weight: 80
url: /ja/net/animated-charts/
keywords:
- チャート
- アニメーション化チャート
- チャートアニメーション
- チャートシリーズ
- チャートカテゴリ
- シリーズ要素
- カテゴリ要素
- エフェクト追加
- エフェクトタイプ
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: " .NET と Aspose.Slides を使用して驚くほど美しいアニメーションチャートを作成しましょう。PPT および PPTX ファイルで動的なビジュアルを使用してプレゼンテーションを強化し、今すぐ始めましょう。"
---

Aspose.Slides for .NET はチャート要素のアニメーションをサポートします。**Series**、**Categories**、**Series Elements**、**Categories Elements** は [**ISequence**.**AddEffect**](https://reference.aspose.com/slides/net/aspose.slides.animation/isequence/methods/addeffect) メソッドと、2 つの列挙体 [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartmajorgroupingtype) と [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/net/aspose.slides.animation/effectchartminorgroupingtype) でアニメーション化できます。

## **チャートシリーズのアニメーション**
チャートシリーズをアニメーション化したい場合、以下の手順に従ってコードを書きます。

1. プレゼンテーションを読み込みます。
1. チャートオブジェクトの参照を取得します。
1. シリーズをアニメーション化します。
1. プレゼンテーションファイルを書き出します。

以下の例では、チャートシリーズをアニメーション化しました。
```c#
 // プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します 
 using (Presentation presentation = new Presentation("ExistingChart.pptx"))
 {
     // チャート オブジェクトの参照を取得します
     var slide = presentation.Slides[0] as Slide;
     var shapes = slide.Shapes as ShapeCollection;
     var chart = shapes[0] as IChart;

     // シリーズをアニメーション化します
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

     // 変更されたプレゼンテーションをディスクに保存します 
     presentation.Save("AnimatingSeries_out.pptx", SaveFormat.Pptx);
 }
```


## **チャートカテゴリのアニメーション**
チャートカテゴリをアニメーション化したい場合、以下の手順に従ってコードを書きます。

1. プレゼンテーションを読み込みます。
1. チャートオブジェクトの参照を取得します。
1. カテゴリをアニメーション化します。
1. プレゼンテーションファイルを書き出します。

以下の例では、チャートカテゴリをアニメーション化しました。
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // チャート オブジェクトの参照を取得します
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // カテゴリ 要素をアニメーション化します
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

    // プレゼンテーション ファイルをディスクに保存します
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **シリーズ要素のアニメーション**
シリーズ要素をアニメーション化したい場合、以下の手順に従ってコードを書きます。

1. プレゼンテーションを読み込みます。
1. チャートオブジェクトの参照を取得します。
1. シリーズ要素をアニメーション化します。
1. プレゼンテーションファイルを書き出します。

以下の例では、シリーズ要素をアニメーション化しました。
```c#
// プレゼンテーションを読み込む
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // チャートオブジェクトの参照を取得します
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // シリーズ要素をアニメーション化します
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

    // プレゼンテーションファイルをディスクに保存します
    presentation.Save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **カテゴリ要素のアニメーション**
カテゴリ要素をアニメーション化したい場合、以下の手順に従ってコードを書きます。

1. プレゼンテーションを読み込みます。
1. チャートオブジェクトの参照を取得します。
1. カテゴリ要素をアニメーション化します。
1. プレゼンテーションファイルを書き出します。

以下の例では、カテゴリ要素をアニメーション化しました。
```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // チャートオブジェクトの参照を取得します
    var slide = presentation.Slides[0] as Slide;
    var shapes = slide.Shapes as ShapeCollection;
    var chart = shapes[0] as IChart;

    // カテゴリ要素をアニメーション化します
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

    // プレゼンテーションファイルをディスクに保存します
    presentation.Save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**チャートは通常の図形と同様に、入口、強調、終了などの異なる効果タイプがサポートされていますか？**

はい。チャートは図形として扱われるため、入口、強調、終了などの標準的なアニメーション効果タイプがすべてサポートされ、スライドのタイムラインとアニメーションシーケンスを介して完全に制御できます。

**チャートのアニメーションとスライドの切り替えを組み合わせることはできますか？**

はい。[Transitions](/slides/ja/net/slide-transition/) はスライド全体に適用され、アニメーション効果はスライド上のオブジェクトに適用されます。同じプレゼンテーション内で両方を併用でき、個別に制御できます。

**PPTX に保存した場合、チャートのアニメーションは保持されますか？**

はい。[save to PPTX](/slides/ja/net/save-presentation/) を実行すると、すべてのアニメーション効果とその順序が保持されます。これはプレゼンテーションのネイティブなアニメーションモデルの一部であるためです。

**既存のプレゼンテーションからチャートのアニメーションを読み取り、変更できますか？**

はい。[API](https://reference.aspose.com/slides/net/aspose.slides.animation/) を使用すると、スライドのタイムライン、シーケンス、エフェクトにアクセスでき、既存のチャートアニメーションを確認し、すべてを最初から作り直すことなく調整できます。

**Aspose.Slides を使用して、チャートアニメーションを含むビデオを作成できますか？**

はい。[export a presentation to video](/slides/ja/net/convert-powerpoint-to-video/) を使用すれば、アニメーションを保持したままビデオにエクスポートでき、タイミングやその他のエクスポート設定を構成して、再生時のアニメーションが反映されたクリップを作成できます。