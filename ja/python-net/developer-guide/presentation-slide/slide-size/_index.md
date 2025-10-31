---
title: Pythonでプレゼンテーションのスライドサイズを変更する
linktitle: スライドサイズ
type: docs
weight: 70
url: /ja/python-net/slide-size/
keywords:
- スライドサイズ
- アスペクト比
- 標準
- ワイドスクリーン
- 4:3
- 16:9
- スライドサイズを設定
- スライドサイズを変更
- カスタムスライドサイズ
- 特別なスライドサイズ
- ユニークスライドサイズ
- フルサイズスライド
- 画面タイプ
- スケーリングしない
- フィットを保証
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
descriptions: "PythonとAspose.Slidesを使用して、PPT、PPTX、ODP ファイルのスライドサイズを迅速に変更し、画質を損なうことなく任意の画面向けにプレゼンテーションを最適化する方法を学びます。"
---

## PowerPoint プレゼンテーションのスライドサイズ

Aspose.Slides for Python via .NET を使用すると、PowerPoint プレゼンテーションのスライドサイズやアスペクト比を変更できます。プレゼンテーションを印刷したり、画面にスライドを表示したりする場合は、スライドサイズやアスペクト比に注意する必要があります。

以下は最も一般的なスライドサイズとアスペクト比です：

- **標準 (4:3 アスペクト比)**

  プレゼンテーションが比較的古いデバイスや画面で表示・閲覧される場合は、この設定を使用するとよいでしょう。

- **ワイドスクリーン (16:9 アスペクト比)** 

  プレゼンテーションが最新のプロジェクターやディスプレイで表示される場合は、この設定を使用するとよいでしょう。

1 つのプレゼンテーションで複数のスライドサイズ設定を使用することはできません。プレゼンテーションのスライドサイズを選択すると、その設定はプレゼンテーション内のすべてのスライドに適用されます。

プレゼンテーションで特別なスライドサイズを使用したい場合は、できるだけ早い段階で設定することを強く推奨します。理想的には、プレゼンテーションの設定段階、すなわちコンテンツを追加する前に、希望するスライドサイズを指定すべきです。このようにすれば、将来的なスライドサイズ変更によるトラブルを回避できます。

{{% alert color="primary" %}} 
Aspose.Slides を使用してプレゼンテーションを作成すると、すべてのスライドは自動的に標準サイズ（4:3 アスペクト比）になります。 
{{% /alert %}} 

## プレゼンテーションのスライドサイズを変更する

このサンプルコードは、Python で Aspose.Slides を使用してプレゼンテーションのスライドサイズを変更する方法を示します。

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(slides.SlideSizeType.ON_SCREEN16X9, slides.SlideSizeScaleType.DO_NOT_SCALE)
    pres.save("pres-4x3-aspect-ratio.pptx", slides.export.SaveFormat.PPTX)
```

## プレゼンテーションでカスタムスライドサイズを指定する

一般的なスライドサイズ（4:3 と 16:9）が作業に適さない場合、特定またはユニークなスライドサイズを使用することができます。たとえば、カスタムページレイアウトでフルサイズのスライドを印刷する、または特定の画面タイプでプレゼンテーションを表示する場合、カスタムサイズ設定を使用すると便利です。

このサンプルコードは、Python で Aspose.Slides for Python via .NET を使用してプレゼンテーションのカスタムスライドサイズを指定する方法を示します。

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
    pres.slide_size.set_size(780, 540, slides.SlideSizeScaleType.DO_NOT_SCALE) # A4 用紙サイズ
    pres.save("pres-a4-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

## プレゼンテーションでスライドサイズを変更する際の問題への対処

プレゼンテーションのスライドサイズを変更すると、スライドの内容（画像やオブジェクトなど）が歪むことがあります。デフォルトでは、オブジェクトは自動的に新しいスライドサイズに合わせてリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように扱うかを決定する設定を指定できます。

目的や達成したいことに応じて、以下の設定のいずれかを使用できます：

- `DO_NOT_SCALE`

  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用します。

- `ENSURE_FIT`

  小さいスライドサイズに合わせてスケールし、すべてのオブジェクトがスライド内に収まるように Aspose.Slides に縮小させたい場合（これによりコンテンツの損失を防げます）、この設定を使用します。

- `MAXIMIZE`

  大きいスライドサイズに合わせてスケールし、オブジェクトを拡大して新しいスライドサイズに比例させたい場合は、この設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に `MAXIMIZE` 設定を使用する方法を示します。

```py
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as pres:
   pres.slide_size.set_size(slides.SlideSizeType.LEDGER, slides.SlideSizeScaleType.MAXIMIZE)
```

## **FAQ**

**インチ以外の単位（例：ポイントやミリメートル）でカスタムスライドサイズを設定できますか？**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなどの任意の単位をポイントに変換し、その変換値でスライドの幅と高さを指定できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位でスライド寸法が大きくなると、レンダリングスケールが高くなるため、メモリ消費が増加し、処理時間も長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールを調整して目的の出力品質を得るようにしてください。

**非標準のスライドサイズを定義した後、サイズが異なるプレゼンテーションからスライドをマージできますか？**

異なるスライドサイズのままでは[プレゼンテーションをマージ](/slides/ja/python-net/merge-presentation/)できません。まず、どちらかのプレゼンテーションのサイズをもう一方に合わせてリサイズします。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/python-net/aspose.slides/slidesizescaletype/) オプションで既存コンテンツの扱いを選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

**スライド内の個別のシェイプや特定領域のサムネイルを生成できますか？それらは新しいスライドサイズを反映しますか？**

はい。Aspose.Slides は[全スライド](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/)だけでなく、[選択したシェイプ](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_image/)のサムネイルもレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保証します。