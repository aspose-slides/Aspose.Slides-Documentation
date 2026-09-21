---
title: Python via Java でプレゼンテーションのスライドサイズを変更する
linktitle: スライドサイズ
type: docs
weight: 70
url: /ja/python-java/slide-size/
keywords:
- スライドサイズ
- アスペクト比
- 標準
- ワイドスクリーン
- 4:3
- 16:9
- スライドサイズの設定
- スライドサイズの変更
- カスタムスライドサイズ
- 特別なスライドサイズ
- ユニークなスライドサイズ
- フルサイズスライド
- 画面タイプ
- スケールしない
- フィットを保証
- 最大化
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python via Java と Aspose.Slides を使用して、PPT、PPTX、ODP ファイルのスライドを素早くリサイズし、画質を失わずに任意の画面向けにプレゼンテーションを最適化する方法を学びます。"
---
## **Introduction**

Aspose.Slides は、印刷および画面表示の両方で重要な、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。

一般的なスライドサイズと比率:

- **Standard (4:3 Aspect Ratio)**: 古い画面やデバイスに最適です。
- **Widescreen (16:9 Aspect Ratio)**: 現代のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドは単一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、プレゼンテーション作成プロセスの開始時にスライドの寸法を設定し、問題を回避してください。

{{% alert color="info" title="Note" %}}
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

ノートおよび配布資料ページは、通常のスライドとは別のサイズを持ちます。そのサイズと向きを変更するには、[Notes Page Size](/slides/ja/python-java/notes-size/) を参照してください。

## **Change the Slide Size in Presentations**

このサンプルコードは、Aspose.Slides を使用して Python via Java でプレゼンテーションのスライドサイズを変更する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Specify Custom Slide Sizes in Presentations**

一般的なスライドサイズ（4:3 および 16:9）が作業に適さない場合、特定または独自のスライドサイズを使用することを検討できます。たとえば、カスタムページレイアウトでプレゼンテーションからフルサイズのスライドを印刷する場合や、特定の画面タイプでプレゼンテーションを表示する場合に、カスタムサイズ設定が有益です。

このサンプルコードは、Aspose.Slides for Python via Java を使用してプレゼンテーションのカスタムスライドサイズを指定する方法を示しています:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Handle Slide Content After Resizing**

プレゼンテーションのスライドサイズを変更すると、スライドの内容（画像やオブジェクトなど）が歪むことがあります。デフォルトでは、オブジェクトは新しいスライドサイズに合わせて自動的にリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように扱うかを決定する設定を指定できます。

目的に応じて、以下の設定のいずれかを使用できます:

- [DoNotScale](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesizescaletype/#DoNotScale)
  
  スライド上のオブジェクトをリサイズしたくない場合にこの設定を使用します。

- [EnsureFit](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesizescaletype/#EnsureFit)
  
  小さなスライドサイズに縮小し、すべてのオブジェクトがスライドに収まるように Aspose.Slides に縮小させたい場合にこの設定を使用します（コンテンツの欠損を防ぎます）。

- [Maximize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesizescaletype/#Maximize)
  
  大きなスライドサイズに拡大し、オブジェクトを新しいスライドサイズに比例させて拡大させたい場合にこの設定を使用します。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に [Maximize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesizescaletype/#Maximize) 設定を使用する方法を示しています:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **FAQ**

**Can I set a custom slide size using units other than inches (for example, points or millimeters)?**

はい。Aspose.Slides は内部でポイントを使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、変換した値でスライドの幅と高さを定義できます。

**Will a very large custom slide size affect performance and memory usage during rendering?**

はい。ポイント単位でのスライド寸法が大きくなると、レンダリングスケールが高くなるため、メモリ使用量が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールを調整して目的の出力品質を得てください。

**Can I define one non-standard slide size and then merge slides from presentations that have different sizes?**

異なるスライドサイズのままでは [merge presentations](/slides/ja/python-java/merge-presentation/) はできません。まず、片方のプレゼンテーションのサイズをもう一方に合わせてリサイズします。スライドサイズを変更する際には、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesizescaletype/) オプションで既存コンテンツの取り扱いを選択できます。サイズを揃えた後、書式を保持したままスライドをマージできます。

**Can I generate thumbnails for individual shapes or specific regions of a slide, and will they respect the new slide size?**

はい。Aspose.Slides は、[entire slides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) と [selected shapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage) のサムネイルをレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保ちます。