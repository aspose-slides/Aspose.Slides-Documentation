---
title: "Python でプレゼンテーションのスライドサイズを変更する"
linktitle: "スライドサイズ"
type: docs
weight: 70
url: /ja/python-net/slide-size/
keywords:
- "スライドサイズ"
- "アスペクト比"
- "標準"
- "ワイドスクリーン"
- "4:3"
- "16:9"
- "スライドサイズを設定"
- "スライドサイズを変更"
- "カスタムスライドサイズ"
- "特別なスライドサイズ"
- "ユニークなスライドサイズ"
- "フルサイズスライド"
- "画面タイプ"
- "スケールしない"
- "フィットを確保"
- "最大化"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Python"
- "Aspose.Slides"
description: "Python と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドを素早くリサイズする方法を学び、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化します。"
---
## **概要**

Aspose.Slides は、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供し、印刷および画面表示の両方で重要です。

一般的なスライドサイズと比率：

- **標準 (4:3 アスペクト比)**: 古い画面やデバイスに最適です。
- **ワイドスクリーン (16:9 アスペクト比)**: 最新のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドに単一のサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーション作成プロセスの開始時にスライドの寸法を設定し、後からの問題を防ぎましょう。

{{% alert color="info" title="Note" %}}
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比が使用されます。
{{% /alert %}}

ノートページと配布資料ページは、通常のスライドとは別のサイズを持ちます。サイズと向きを変更するには、[Notes Page Size](/slides/ja/python-net/notes-size/) を参照してください。

## **プレゼンテーションのスライドサイズを変更する**

このサンプルコードは、Python で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN_16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-16x9-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **カスタムスライドサイズを指定する**

一般的なスライドサイズ（4:3 と 16:9）が作業に適さない場合、特定またはユニークなスライドサイズを使用することができます。たとえば、プレゼンテーションのスライドをカスタムページレイアウトでフルサイズ印刷したり、特定の画面タイプで表示したりする場合、カスタムサイズ設定が有益です。

このサンプルコードは、Python (.NET 経由) で Aspose.Slides を使用してプレゼンテーションにカスタムスライドサイズを指定する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 用紙サイズ
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **リサイズ後のスライドコンテンツの処理**

プレゼンテーションのスライドサイズを変更すると、スライド内のコンテンツ（画像やオブジェクトなど）が歪むことがあります。デフォルトでは、オブジェクトは新しいスライドサイズに合わせて自動的にリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように扱うかを決定する設定を指定できます。

目的に応じて、次のいずれかの設定を使用できます：

- `DO_NOT_SCALE`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `ENSURE_FIT`

  小さいスライドサイズに縮小し、すべてのオブジェクトがスライド内に収まるように（コンテンツが失われないように）自動的に縮小させたい場合は、この設定を使用します。

- `MAXIMIZE`

  大きいスライドサイズに拡大し、オブジェクトを新しいサイズに比例させて拡大したい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `MAXIMIZE` 設定を使用する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation("AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**カスタムスライドサイズをインチ以外の単位（たとえばポイントやミリメートル）で設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなどの任意の単位をポイントに変換し、変換後の値でスライドの幅と高さを定義できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位のスライド寸法が大きくなるほど、レンダリングスケールが高くなるとメモリ消費と処理時間が増加します。実用的なスライドサイズを目指し、必要な出力品質を得るためにレンダリングスケールだけを調整してください。

**標準外のスライドサイズを1つ定義し、異なるサイズのプレゼンテーションからスライドをマージできますか？**

スライドサイズが異なる状態で [merge presentations](/slides/ja/python-net/merge-presentation/) はできません。まず、片方のプレゼンテーションをもう片方に合わせてリサイズします。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidesizescaletype/) オプションで既存コンテンツの処理方法を選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

**個々のシェイプやスライドの特定領域のサムネイルを生成できますか？また、新しいスライドサイズを考慮しますか？**

はい。Aspose.Slides は [entire slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/) のサムネイルだけでなく、[selected shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_image/) のサムネイルもレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保ちます。