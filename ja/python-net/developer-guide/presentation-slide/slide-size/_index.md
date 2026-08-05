---
title: Python を使用したプレゼンテーションのスライドサイズの変更
linktitle: スライドサイズ
type: docs
weight: 70
url: /ja/python-net/slide-size/
keywords:
- スライドサイズ
- アスペクト比
- 標準
- ワイドスクリーン
- "4:3"
- "16:9"
- スライドサイズを設定
- スライドサイズを変更
- カスタムスライドサイズ
- 特別なスライドサイズ
- ユニークなスライドサイズ
- フルサイズスライド
- 画面タイプ
- スケールしない
- フィットを確保
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python と Aspose.Slides を使用して、PPT、PPTX、ODP ファイルのスライドをすばやくサイズ変更する方法を学び、品質を損なうことなく任意の画面向けにプレゼンテーションを最適化します。"
---
## **はじめに**

Aspose.Slides は、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供し、印刷と画面表示の両方で重要です。

一般的なスライドサイズと比率:

- **標準 (4:3 アスペクト比)**: 古い画面やデバイスに最適です。
- **ワイドスクリーン (16:9 アスペクト比)**: 現代のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つため、すべてのスライドに単一のサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーション作成プロセスの開始時にスライドの寸法を設定し、後からの問題を回避してください。

{{% alert color="primary" %}} 
デフォルトでは、Aspose.Slidesで作成されたプレゼンテーションは標準の4:3アスペクト比を使用します。
{{% /alert %}}

## **プレゼンテーションのスライドサイズを変更する**

このサンプルコードは、Python で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示しています:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## **カスタムスライドサイズを指定する**

一般的なスライドサイズ（4:3 と 16:9）が作業に適さない場合、特定または固有のスライドサイズを使用することができます。たとえば、カスタムページレイアウトでフルサイズのスライドを印刷したい場合や、特定の画面タイプでプレゼンテーションを表示したい場合、カスタムサイズ設定が有益です。

このサンプルコードは、Python から .NET 経由で Aspose.Slides を使用し、プレゼンテーションにカスタムスライドサイズを指定する方法を示しています:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 用紙サイズ
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## **サイズ変更後のスライドコンテンツの処理**

プレゼンテーションのスライドサイズを変更すると、スライドのコンテンツ（画像やオブジェクトなど）が歪むことがあります。デフォルトでは、オブジェクトは自動的に新しいスライドサイズに合わせてリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように扱うかを決定する設定を指定できます。

目的や達成したい結果に応じて、次の設定のいずれかを使用できます:

- `DO_NOT_SCALE`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `ENSURE_FIT`

  小さいスライドサイズに縮小し、すべてのオブジェクトがスライド内に収まるように自動的に縮小させたい場合は、この設定を使用します（コンテンツの欠落を防ぎます）。

- `MAXIMIZE`

  大きいスライドサイズに拡大し、オブジェクトを新しいスライドサイズに比例させて拡大したい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更するときに `MAXIMIZE` 設定を使用する方法を示しています:

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **よくある質問**

**インチ以外の単位（ポイントやミリメートルなど）でカスタムスライドサイズを設定できますか？**

はい。Aspose.Slides は内部でポイントを使用し、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、変換後の値でスライドの幅と高さを定義できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位のスライド寸法が大きく、レンダリングスケールが高いほど、メモリ消費と処理時間が増加します。実用的なスライドサイズを目指し、必要な出力品質を得るためにのみレンダリングスケールを調整してください。

**標準外のスライドサイズを定義し、サイズが異なるプレゼンテーションからスライドをマージできますか？**

サイズが異なる状態では[プレゼンテーションをマージ](/slides/ja/python-net/merge-presentation/)できません。まず、1 つのプレゼンテーションのサイズをもう一方に合わせて変更してください。スライドサイズを変更する際、既存のコンテンツの処理方法は[SlideSizeScaleType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidesizescaletype/)オプションで選択できます。サイズを揃えた後、フォーマットを保持したままスライドをマージできます。

**スライド上の個々のシェイプや特定領域のサムネイルを生成できますか？また、新しいスライドサイズを考慮しますか？**

はい。Aspose.Slides は[スライド全体](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/get_image/)だけでなく[選択したシェイプ](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shape/get_image/)のサムネイルもレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保証します。