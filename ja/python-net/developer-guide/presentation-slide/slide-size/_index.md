---
title: Python を使用したプレゼンテーションのスライド サイズの変更
linktitle: スライド サイズ
type: docs
weight: 70
url: /ja/python-net/slide-size/
keywords:
- スライド サイズ
- アスペクト比
- 標準
- ワイドスクリーン
- 4:3
- 16:9
- スライド サイズの設定
- スライド サイズの変更
- カスタム スライド サイズ
- 特別なスライド サイズ
- ユニーク スライド サイズ
- フルサイズ スライド
- 画面タイプ
- スケールしない
- フィットを保証
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
descriptions: "Python と Aspose.Slides を使用して PPT、PPTX、ODP ファイルのスライドを迅速にリサイズする方法を学び、品質を損なうことなくあらゆる画面向けにプレゼンテーションを最適化します。"
---

## PowerPoint プレゼンテーションのスライド サイズ

Aspose.Slides for Python via .NET を使用すると、PowerPoint プレゼンテーションのスライド サイズまたはアスペクト比を変更できます。プレゼンテーションを印刷したり、画面にスライドを表示したりする場合は、スライドのサイズやアスペクト比に注意する必要があります。

代表的なスライド サイズとアスペクト比は次のとおりです。

- **Standard (4:3 アスペクト比)**

  プレゼンテーションを比較的古いデバイスや画面で表示または閲覧する場合は、この設定を使用するとよいでしょう。

- **Widescreen (16:9 アスペクト比)**

  プレゼンテーションを最新のプロジェクターやディスプレイで表示する場合は、この設定を使用するとよいでしょう。

1 つのプレゼンテーションで複数のスライド サイズ設定を使用することはできません。プレゼンテーションのスライド サイズを選択すると、その設定はプレゼンテーション内のすべてのスライドに適用されます。

特別なスライド サイズを使用したい場合は、できるだけ早い段階で設定することを強くおすすめします。理想的には、プレゼンテーションの作成直後、すなわちコンテンツを追加する前に希望のスライド サイズを指定してください。こうすることで、将来スライド サイズを変更した際に発生する問題を回避できます。

{{% alert color="primary" %}} 
Aspose.Slides を使用してプレゼンテーションを作成すると、すべてのスライドは自動的に標準サイズ（4:3 アスペクト比）になります。
{{% /alert %}} 

## プレゼンテーションでのスライド サイズの変更

以下のサンプルコードは、Python で Aspose.Slides を使用してプレゼンテーションのスライド サイズを変更する方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```


## プレゼンテーションでカスタム スライド サイズを指定する

一般的なスライド サイズ（4:3 と 16:9）が要件に合わない場合、特定のカスタム スライド サイズを使用することができます。たとえば、カスタムページ レイアウトでフルサイズのスライドを印刷したり、特定の画面タイプでプレゼンテーションを表示したりする場合に、カスタム サイズ設定が有益です。

以下のサンプルコードは、Python で Aspose.Slides for Python via .NET を使用してプレゼンテーションにカスタム スライド サイズを指定する方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 用紙サイズ
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```


## スライド サイズ変更時の問題への対処

プレゼンテーションのスライド サイズを変更すると、スライド内のコンテンツ（画像やオブジェクトなど）が歪むことがあります。デフォルトでは、オブジェクトは新しいスライド サイズに合わせて自動的にリサイズされます。ただし、スライド サイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように処理するかを指定できます。

目的に応じて次の設定のいずれかを使用できます。

- `DO_NOT_SCALE`

  スライド上のオブジェクトをリサイズしたくない場合に使用します。

- `ENSURE_FIT`

  小さいスライド サイズに縮小し、すべてのオブジェクトがスライド内に収まるように自動的に縮小させたい（コンテンツの欠落を防ぎたい）場合に使用します。

- `MAXIMIZE`

  大きいスライド サイズに拡大し、オブジェクトを新しいサイズに比例させて拡大したい場合に使用します。

以下のサンプルコードは、プレゼンテーションのスライド サイズを変更する際に `MAXIMIZE` 設定を使用する方法を示しています。
```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```


## **FAQ**

**カスタム スライド サイズをインチ以外の単位（たとえばポイントやミリメートル）で設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなどの任意の単位をポイントに変換し、その値でスライドの幅と高さを定義できます。

**非常に大きなカスタム スライド サイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位でのスライド寸法が大きくなると、レンダリングスケールが上がり、メモリ消費と処理時間が増加します。実用的なスライド サイズを目指し、必要に応じてのみレンダリング スケールを調整して望ましい出力品質を確保してください。

**標準外のスライド サイズを 1 つ定義した後、サイズが異なるプレゼンテーションからスライドをマージできますか？**

サイズが異なる状態で [merge presentations](/slides/ja/python-net/merge-presentation/) はできません。まず、どちらかのプレゼンテーションをもう一方のサイズに合わせてリサイズします。スライド サイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) オプションで既存コンテンツの処理方法を選択できます。サイズを揃えた後は、書式を保持したままスライドをマージできます。

**スライド内の個別シェイプや特定領域のサムネイルを生成できますか？また、新しいスライド サイズを反映しますか？**

はい。Aspose.Slides は [entire slides]((https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/)) はもちろん、[selected shapes]((https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/)) のサムネイルも描画できます。生成された画像は現在のスライド サイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保ちます。