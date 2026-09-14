---
title: Python（Java 経由）でプレゼンテーションのスライドサイズを変更
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
description: "Python（Java 経由）と Aspose.Slides を使用して、PPT、PPTX、ODP ファイルのスライドを素早くリサイズし、品質を損なうことなく任意の画面に最適化する方法を学びます。"
---
## **概要**

Aspose.Slides は、印刷と画面表示の両方に重要な、PowerPoint プレゼンテーションのスライドサイズとアスペクト比を調整するための包括的なツールを提供します。

一般的なスライドサイズと比率:

- **標準（4:3 アスペクト比）**: 古い画面やデバイスに最適です。
- **ワイドスクリーン（16:9 アスペクト比）**: 最新のプロジェクターやディスプレイに推奨されます。

プレゼンテーション全体で一貫性を保つために、すべてのスライドに同一のスライドサイズとアスペクト比が適用されます。最適な結果を得るには、作成プロセスの最初にスライドの寸法を設定し、問題を避けてください。

{{% alert color="info" title="Note" %}}
デフォルトでは、Aspose.Slides で作成されたプレゼンテーションは標準の 4:3 アスペクト比を使用します。
{{% /alert %}}

## **プレゼンテーションのスライドサイズを変更する**

このサンプルコードは、Aspose.Slides を使用して Java 経由で Python からプレゼンテーションのスライドサイズを変更する方法を示しています。

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

## **プレゼンテーションでカスタムスライドサイズを指定する**

一般的なスライドサイズ（4:3 および 16:9）が仕事に適さない場合、特定または独自のスライドサイズを使用することができます。たとえば、カスタムページレイアウトでプレゼンテーションから実サイズのスライドを印刷する場合や、特定の画面タイプでプレゼンテーションを表示する場合、カスタムサイズ設定を使用すると便利です。

このサンプルコードは、Java 経由で Python 用 Aspose.Slides を使用してプレゼンテーションのカスタムスライドサイズを指定する方法を示しています。

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

## **サイズ変更後のスライドコンテンツの処理**

プレゼンテーションのスライドサイズを変更すると、スライドのコンテンツ（画像やオブジェクトなど）が歪むことがあります。デフォルトでは、オブジェクトは新しいスライドサイズに合わせて自動的にリサイズされます。ただし、スライドサイズを変更する際に、Aspose.Slides がスライド上のコンテンツをどのように処理するかを決定する設定を指定できます。

目的や達成したいことに応じて、以下の設定のいずれかを使用できます：

- [DoNotScale](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesizescaletype/#DoNotScale)
  
  スライド上のオブジェクトをリサイズしたくない場合は、この設定を使用してください。

- [EnsureFit](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesizescaletype/#EnsureFit)
  
  小さいスライドサイズにスケールダウンし、すべてのオブジェクトがスライドに収まるように Aspose.Slides に縮小させたい場合（これによりコンテンツの欠落を防げます）、この設定を使用してください。

- [Maximize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesizescaletype/#Maximize)
  
  大きいスライドサイズに拡大し、オブジェクトを新しいスライドサイズに比例させて拡大させたい場合は、この設定を使用してください。

このサンプルコードは、プレゼンテーションのスライドサイズを変更する際に [Maximize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesizescaletype/#Maximize) 設定を使用する方法を示しています。

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

## **よくある質問**

**インチ以外の単位（例: ポイントやミリメートル）でカスタムスライドサイズを設定できますか？**

はい。Aspose.Slides は内部的にポイント単位を使用しており、1 ポイントは 1/72 インチに相当します。ミリメートルやセンチメートルなど任意の単位をポイントに変換し、変換した値でスライドの幅と高さを定義できます。

**非常に大きなカスタムスライドサイズは、レンダリング時のパフォーマンスやメモリ使用量に影響しますか？**

はい。ポイント単位のスライド寸法が大きく、レンダリングスケールが高いほど、メモリ消費が増加し、処理時間が長くなります。実用的なスライドサイズを目指し、必要に応じてレンダリングスケールを調整して目的の出力品質を得るようにしてください。

**標準外のスライドサイズを定義した後、異なるサイズのプレゼンテーションからスライドをマージできますか？**

異なるスライドサイズのままでは [merge presentations](/slides/ja/python-java/merge-presentation/) を実行できません。まず、片方のプレゼンテーションのサイズをもう一方に合わせてリサイズしてください。スライドサイズを変更する際は、[SlideSizeScaleType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesizescaletype/) オプションで既存コンテンツの処理方法を選択できます。サイズを揃えた後、書式設定を保持したままスライドをマージできます。

**スライドの個々のシェイプや特定領域のサムネイルを生成できますか？また、それらは新しいスライドサイズを考慮しますか？**

はい。Aspose.Slides は、[entire slides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getImage) および [selected shapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shape/#getImage) のサムネイルをレンダリングできます。生成された画像は現在のスライドサイズとアスペクト比を反映し、一貫したフレーミングとジオメトリを保証します。