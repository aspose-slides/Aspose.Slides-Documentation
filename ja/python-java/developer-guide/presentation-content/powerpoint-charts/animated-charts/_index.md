---
title: Python via Java で PowerPoint のチャートをアニメーション化
linktitle: アニメーション化されたチャート
type: docs
weight: 80
url: /ja/python-java/animated-charts/
keywords:
- チャート
- アニメーション化されたチャート
- チャート アニメーション
- チャート 系列
- チャート カテゴリ
- 系列 要素
- カテゴリ 要素
- エフェクト追加
- エフェクト タイプ
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Python via Java で驚くべきアニメーションチャートを作成します。PPT および PPTX ファイルで動的なビジュアルでプレゼンテーションを強化しましょう—今すぐ始めましょう。"
---
## **イントロダクション**

Aspose.Slides for Python via Java は、チャート要素のアニメーションをサポートしています。**Series**、**Categories**、**Series Elements**、**Category Elements** は、[Sequence.addEffect](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sequence/#addEffect) メソッドと 2 つの列挙体、[EffectChartMajorGroupingType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effectchartmajorgroupingtype/) と [EffectChartMinorGroupingType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/effectchartminorgroupingtype/) を使用してアニメーション化できます。

## **チャート系列のアニメーション**

チャート系列をアニメーション化したい場合は、以下の手順に従ってコードを記述してください。

1. プレゼンテーションを読み込む。
1. チャートオブジェクトへの参照を取得する。
1. 系列をアニメーション化する。
1. プレゼンテーションファイルをディスクに書き込む。

以下の例はチャート系列をアニメーション化します。この例のファイルにあるチャートは 3 系列を持つため、インデックス 0 から 2 までそれぞれ 1 つずつエフェクトが追加されます。Aspose.Slides はインデックスをチャートデータと照合しないため、存在しない系列に対して追加されたエフェクトはファイルに書き込まれますが何もアニメーションしません。自分のチャートではインデックスを系列数未満に保ってください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# プレゼンテーションをロードします。
presentation = Presentation("ExistingChart.pptx")
try:
    # チャートオブジェクトへの参照を取得します。
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # チャート要素をアニメーション化します。
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.BySeries, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 変更されたプレゼンテーションをディスクに保存します。
    presentation.save("AnimatingSeries_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **チャートカテゴリのアニメーション**

チャートカテゴリをアニメーション化したい場合は、以下の手順に従ってコードを記述してください。

1. プレゼンテーションを読み込む。
1. チャートオブジェクトへの参照を取得する。
1. カテゴリをアニメーション化する。
1. プレゼンテーションファイルをディスクに書き込む。

以下の例はチャートカテゴリをアニメーション化します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMajorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# プレゼンテーションをロードします。
presentation = Presentation("ExistingChart.pptx")
try:
    # チャートオブジェクトへの参照を取得します。
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # チャート要素をアニメーション化します。
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMajorGroupingType.ByCategory, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 変更されたプレゼンテーションをディスクに保存します。
    presentation.save("Sample_Animation_C.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **系列要素のアニメーション**

系列要素をアニメーション化したい場合は、以下の手順に従ってコードを記述してください。

1. プレゼンテーションを読み込む。
1. チャートオブジェクトへの参照を取得する。
1. 系列要素をアニメーション化する。
1. プレゼンテーションファイルをディスクに書き込む。

以下の例は系列要素をアニメーション化します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# プレゼンテーションをロードします。
presentation = Presentation("ExistingChart.pptx")
try:
    # チャートオブジェクトへの参照を取得します。
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # チャート要素をアニメーション化します。
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInSeries, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 変更されたプレゼンテーションをディスクに保存します。
    presentation.save("AnimatingSeriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **カテゴリ要素のアニメーション**

カテゴリ要素をアニメーション化したい場合は、以下の手順に従ってコードを記述してください。

1. プレゼンテーションを読み込む。
1. チャートオブジェクトへの参照を取得する。
1. カテゴリ要素をアニメーション化する。
1. プレゼンテーションファイルをディスクに書き込む。

以下の例はカテゴリ要素をアニメーション化します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectChartMinorGroupingType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

# プレゼンテーションをロードします。
presentation = Presentation("ExistingChart.pptx")
try:
    # チャートオブジェクトへの参照を取得します。
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)
    sequence = slide.getTimeline().getMainSequence()

    # チャート要素をアニメーション化します。
    sequence.addEffect(chart, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 0, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 1, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 0, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 1, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 2, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
    sequence.addEffect(chart, EffectChartMinorGroupingType.ByElementInCategory, 2, 3, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.AfterPrevious)

    # 変更されたプレゼンテーションをディスクに保存します。
    presentation.save("AnimatingCategoriesElements_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**異なるエフェクトタイプ（例：入口、強調、終了）は、通常の図形と同様にチャートでもサポートされていますか？**

はい。チャートは図形として扱われるため、入口、強調、終了などの標準的なアニメーションエフェクトタイプをサポートしており、スライドのタイムラインとアニメーションシーケンスを通じてフルコントロールできます。

**チャートのアニメーションとスライドのトランジションを組み合わせることはできますか？**

はい。[Transitions](/slides/ja/python-java/slide-transition/) はスライド全体に適用され、アニメーションエフェクトはスライド上のオブジェクトに適用されます。両方を同一プレゼンテーションで併用し、個別に制御可能です。

**PPTX に保存した際にチャートのアニメーションは保持されますか？**

はい。[save to PPTX](/slides/ja/python-java/save-presentation/) すると、すべてのアニメーションエフェクトとその順序がプレゼンテーションのネイティブアニメーションモデルの一部として保持されます。

**既存のプレゼンテーションからチャートアニメーションを読み取り、変更することはできますか？**

はい。API はスライドのタイムライン、シーケンス、エフェクトへのアクセスを提供しており、既存のチャートアニメーションを検査し、最初から作り直すことなく調整できます。

**Aspose.Slides を使用してチャートアニメーションを含むビデオを作成できますか？**

はい。[export a presentation to video](/slides/ja/python-java/convert-powerpoint-to-video/) でアニメーションを保持したままビデオにエクスポートでき、タイミングやその他のエクスポート設定を構成して、アニメーション再生を反映したクリップを作成できます。