---
title: Python で PowerPoint スライドを PNG に変換
linktitle: PowerPoint を PNG に変換
type: docs
weight: 30
url: /ja/python-java/convert-powerpoint-to-png/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を PNG に変換
- プレゼンテーションを PNG に変換
- スライドを PNG に変換
- PPT を PNG に変換
- PPTX を PNG に変換
- PPT を PNG として保存
- PPTX を PNG として保存
- PPT を PNG にエクスポート
- PPTX を PNG にエクスポート
- Python
- Java
- Aspose.Slides
description: "Python（via Java）で PowerPoint スライドを PNG 画像に変換します。カスタムスケールまたは正確な画像サイズで PPT、PPTX、ODP プレゼンテーションをエクスポートします。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用してプレゼンテーションスライドを PNG 画像に変換する方法を説明します。PPT、PPTX、ODP などの形式のプレゼンテーションを読み込み、各スライドをレンダリングし、個別の PNG 画像として保存できます。

以下の例では、デフォルトのスケールでのレンダリング、スケールの拡大、ピクセル単位で出力サイズを指定する方法、およびグラデーション描画スタイルの選択を示します。

## **PowerPoint を PNG に変換**

プレゼンテーションは [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスで読み込み、[Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) コレクションを介してスライドにアクセスします。例では、パラメータなしで [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) を使用して各スライドをサムネイルとしてレンダリングします。その後、[IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) を [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) とともに呼び出し、レンダリングされた各スライドを PNG 画像として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
パラメータなしの [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) オーバーロードはスケール 0.2 でレンダリングします。たとえば、720 × 540 ポイントのスライドは 144 × 108 ピクセルのサムネイルを生成します。出力サイズを制御するには、以下に示すスケール係数を使用したオーバーロードまたは明示的な画像サイズを使用してください。
{{% /alert %}}

## **カスタム寸法で PowerPoint を PNG に変換**

水平および垂直のスケール係数を [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) に渡して、レンダリングサイズを制御します。この例では両方の係数が 2 で、720 × 540 ポイントのスライドは 1440 × 1080 ピクセルの画像を生成します。スケール係数を等しくすると、スライドのアスペクト比が維持されます。各レンダリング画像は PNG 形式で保存されます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **カスタムサイズで PowerPoint を PNG に変換**

ピクセル単位で出力サイズを指定するには、スケール係数の代わりにサイズを [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) に渡します。この例では、すべてのスライドを 960 × 720 ピクセルでレンダリングし、結果を PNG 形式で保存します。画像が伸びるのを防ぐため、スライドのアスペクト比に合わせたサイズを選択してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **グラデーション描画スタイルの選択**

スライドにグラデーション塗りが含まれているが、エクスポートされた PNG の遷移が PowerPoint で見えるものよりも明るくなる、あるいは異なる場合があります。そのような場合、[RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) が継承する [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) メソッドを使用して、グラデーションの描画方法を選択できます。

[gradient‑styles.pptx](gradient-styles.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置します。最初のスライドには 2 つの線形グラデーションがあり、上部はシアンからオレンジ、下部は青から黄へと変化します。各グラデーションは 0% と 100% の 2 つのストップを持ちます。

以下の例では、このプレゼンテーションを読み込み、[Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) を使用して同じ最初のスライドを両モードでレンダリングします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

以下の画像は同じスライドの出力を示し、各画像に両方のグラデーションが含まれています。

| Default | PowerPointUI |
| --- | --- |
| ![Default でレンダリングされたシアンからオレンジ、青から黄へのグラデーション](gradient-Default.png) | ![PowerPointUI でレンダリングされた同じグラデーション](gradient-PowerPointUI.png) |

この例では、`Default` は中間色が明るくなり、`PowerPointUI` は中間色が暗くなります。差異はグラデーションの色とストップに依存します。

`Default` を選択すると、標準の Aspose.Slides の出力が要件に合致します。PowerPoint の外観と一致させることが優先であれば `PowerPointUI` を試してください。両方の出力を目的の結果と比較し、どちらのモードが常に優れているというわけではありません。

## **よくある質問**

**スライド全体ではなく、チャートや画像などの特定のシェイプをエクスポートするにはどうすればよいですか？**

Aspose.Slides は [個々のシェイプ用サムネイルの生成](/slides/ja/python-java/create-shape-thumbnails/) をサポートしており、シェイプを PNG 画像としてレンダリングできます。

**サーバーでの並列変換はサポートされていますか？**

はい。各スレッドまたはプロセスごとに別々のプレゼンテーション インスタンスを使用してください；[スレッド間で単一インスタンスを共有しないでください](/slides/ja/python-java/multithreading/)。

**PNG へのエクスポート時の評価版の制限は何ですか？**

評価モードでは、出力画像に透かしが追加され、[その他の制限](/slides/ja/python-java/licensing/) がライセンスが適用されるまで適用されます。