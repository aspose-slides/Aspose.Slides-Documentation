---
title: Aspose.Slides for .NET 15.10.0 における公開 API と後方互換性のない変更
type: docs
weight: 200
url: /ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/
---

{{% alert color="primary" %}} 

このページでは、Aspose.Slides for .NET 15.10.0 API で追加または削除されたすべての [added](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) または [removed](/slides/ja/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-10-0/) クラス、メソッド、プロパティ、その他の変更をリストしています。

{{% /alert %}} 
## **公開 API の変更**
#### **メディアファイルを HTML にエクスポートするサポートのために新しい VideoPlayerHtmlController が追加されました**
新しい公開クラス VideoPlayerHtmlController が Aspose.Slides.Export 名前空間に追加されました。このクラスのインスタンスを使用すると、ユーザーは動画と音声ファイルを HTML にエクスポートできます。
VideoPlayerHtmlController コンストラクタは、次のパラメータを受け入れます:

path: 動画と音声ファイルが生成されるパス
fileName: HTML ファイルの名前

baseUri: リンクを生成するために使用される基本 URI
使用例：

``` csharp

 using (Presentation pres = new Presentation("example.pptx"))

{

    const string path = "path";

    const string fileName = "video.html";

    const string baseUri = "http://www.example.com/";

    VideoPlayerHtmlController controller = new VideoPlayerHtmlController(path: path, fileName: fileName, baseUri: baseUri);

    HtmlOptions htmlOptions = new HtmlOptions(controller);

    SVGOptions svgOptions = new SVGOptions(controller);

    htmlOptions.HtmlFormatter = HtmlFormatter.CreateCustomFormatter(controller);

    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(svgOptions);

    pres.Save(Path.Combine(path, fileName), SaveFormat.Html, htmlOptions);

}

``` 
#### **チャート シリーズ アニメーション API が追加されました**
新しい 2 つのメソッドが Aspose.Slides.Animation.ISequence インターフェースに追加されました。

``` csharp

 IEffect AddEffect(IChart chart, EffectChartMajorGroupingType type, int index, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

IEffect AddEffect(IChart chart, EffectChartMinorGroupingType type, int seriesIndex, int categoriesIndex, EffectType effectType, EffectSubtype subtype, EffectTriggerType triggerType);

``` 

これらのメソッドは、チャートの要素アニメーションをサポートすることを目的としています:
シリーズごと
カテゴリごと
シリーズ要素ごと
カテゴリ要素ごと

チャートの要素アニメーションに関連する新しい enum EffectChartMajorGroupingType と EffectChartMinorGroupingType が導入されました。

チャートにシリーズアニメーションを追加するには、次のコードを使用できます：

``` csharp

 using (Presentation pres = new Presentation(inFileName))

{

    var slide = pres.Slides[0] as Slide;

    var shapes = slide.Shapes as ShapeCollection;

    var chart = shapes[0] as IChart;

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

    pres.Save(outFileName, SaveFormat.Pptx);

}

``` 

カテゴリアニメーション：

``` csharp

 using (Presentation pres = new Presentation(inFileName))

{

    var slide = pres.Slides[0] as Slide;

    var shapes = slide.Shapes as ShapeCollection;

    var chart = shapes[0] as IChart;

    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,

        EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMajorGroupingType.ByCategory, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMajorGroupingType.ByCategory, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMajorGroupingType.ByCategory, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMajorGroupingType.ByCategory, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.Save(outFileName, SaveFormat.Pptx);

}

``` 

シリーズ要素アニメーション：

``` csharp

 using (Presentation pres = new Presentation(inFileName))

{

    var slide = pres.Slides[0] as Slide;

    var shapes = slide.Shapes as ShapeCollection;

    var chart = shapes[0] as IChart;

    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,

        EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 0, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 0, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 0, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 0, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 1, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 1, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 1, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 1, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 2, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 2, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 2, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInSeries, 2, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.Save(outFileName, SaveFormat.Pptx);

}

``` 

カテゴリ要素アニメーション：

``` csharp

 using (Presentation pres = new Presentation(inFileName))

{

    var slide = pres.Slides[0] as Slide;

    var shapes = slide.Shapes as ShapeCollection;

    var chart = shapes[0] as IChart;

    slide.Timeline.MainSequence.AddEffect(chart, EffectType.Fade, EffectSubtype.None,

        EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 0, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 0, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 0, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 0, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 1, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 1, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 1, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 1, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 2, 0,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 2, 1,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 2, 2,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    ((Sequence)slide.Timeline.MainSequence).AddEffect(chart,

        EffectChartMinorGroupingType.ByElementInCategory, 2, 3,

        EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    pres.Save(outFileName, SaveFormat.Pptx);

}

``` 
