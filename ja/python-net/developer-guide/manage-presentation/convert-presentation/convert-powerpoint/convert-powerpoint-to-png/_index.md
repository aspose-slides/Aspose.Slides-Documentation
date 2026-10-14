---
title: Python で PowerPoint スライドを PNG に変換
linktitle: PowerPoint から PNG へ
type: docs
weight: 30
url: /ja/python-net/convert-powerpoint-to-png/
keywords:
- PowerPoint を PNG に変換
- プレゼンテーションを PNG に変換
- スライドを PNG に変換
- PPT を PNG に変換
- PPTX を PNG に変換
- ODP を PNG に変換
- PowerPoint から PNG へ
- プレゼンテーションから PNG へ
- スライドから PNG へ
- PPT から PNG へ
- PPTX から PNG へ
- ODP から PNG へ
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument のプレゼンテーションを高品質な PNG 画像に迅速に変換し、正確で自動化された結果を保証します。"
---
## **概要**

この記事では、Aspose.Slides for Python via .NET を使用してプレゼンテーションスライドを PNG 画像に変換する方法を説明します。PPT、PPTX、ODP などの形式のプレゼンテーションを読み込み、各スライドをレンダリングし、個別の PNG 画像として保存できます。

以下の例では、デフォルトのスケールでのレンダリング、スケールの拡大、ピクセル単位での出力サイズ指定、グラデーションレンダリングスタイルの選択を示しています。

## **PowerPoint を PNG に変換**

[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスでプレゼンテーションを読み込み、[slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) コレクションを介してスライドにアクセスします。例では、パラメーターなしで [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) を呼び出してサムネイルを作成し、各スライドをレンダリングします。その後、[IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) に [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) を指定して、各レンダリングされたスライドを PNG 画像として保存します。

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
パラメーターなしの [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) オーバーロードはスケール 0.2 でレンダリングします。たとえば、720 × 540 ポイントのスライドは 144 × 108 ピクセルのサムネイルを生成します。出力サイズを制御するには、以下に示すスケールファクターを使用するオーバーロードまたは明示的な画像サイズを使用してください。
{{% /alert %}}

## **カスタム サイズで PowerPoint を PNG に変換**

水平および垂直のスケールファクターを [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) に渡して、レンダリングされたサイズを制御します。この例では、両方のファクターが 2 であるため、720 × 540 ポイントのスライドは 1440 × 1080 ピクセルの画像になります。スケールファクターが等しいとスライドのアスペクト比が保たれます。各画像は [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) で PNG 形式で保存されます。

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **カスタム サイズで PowerPoint を PNG に変換**

出力サイズをピクセル単位で指定するには、スケールファクターの代わりにサイズを [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) に渡します。この例では、すべてのスライドを 960 × 720 ピクセルでレンダリングし、結果を [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) で保存します。画像の伸びを防ぐため、スライドのアスペクト比に合わせたサイズを選択してください。

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **グラデーションレンダリングスタイルの選択**

スライドにグラデーション塗りが含まれているが、エクスポートされた PNG のグラデーションが PowerPoint で見えるものよりも明るくなる、または異なる場合があります。そのような場合は、[RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) の [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) プロパティを使用して、グラデーションのレンダリング方法を選択できます。

[gradient-styles.pptx](gradient-styles.pptx) をダウンロードし、アプリケーションの作業ディレクトリに配置します。最初のスライドには、上部がシアンからオレンジへの線形グラデーション、下部が青から黄への線形グラデーションの2つが含まれています。各グラデーションは 0% と 100% の2つのストップを持ちます。

以下の例では、このプレゼンテーションを読み込み、[Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) を使用して同じ最初のスライドを両方のモードでレンダリングします。

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

| デフォルト | PowerPointUI |
| --- | --- |
| ![デフォルトでレンダリングされたシアンからオレンジ、青から黄へのグラデーション](gradient-Default.png) | ![PowerPointUI でレンダリングされた同じグラデーション](gradient-PowerPointUI.png) |

この例では、`DEFAULT` は中間色が明るくなり、`POWER_POINT_UI` は中間色が暗くなります。差異はグラデーションの色とストップに依存します。

標準の Aspose.Slides 出力が目的に合う場合は `DEFAULT` を選択してください。PowerPoint の外観と一致させることが優先事項の場合は `POWER_POINT_UI` を試してください。両方の出力を意図した結果と比較してみてください。どちらのモードが常に優れているということはありません。

## **FAQ**

**スライド全体ではなく、チャートや画像など特定のシェイプをエクスポートするにはどうすればよいですか？**

Aspose.Slides は [個々のシェイプのサムネイル生成](/slides/ja/python-net/create-shape-thumbnails/) をサポートしており、シェイプを PNG 画像としてレンダリングできます。

**サーバー上での並列変換はサポートされていますか？**

はい。各スレッドまたはプロセスごとに個別のプレゼンテーション インスタンスを使用してください；[スレッド間で単一のインスタンスを共有しない](/slides/ja/python-net/multithreading/)。

**PNG へエクスポートする際の評価版の制限は何ですか？**

評価モードでは、出力画像に透かしが追加され、ライセンスを適用するまで [その他の制限](/slides/ja/python-net/licensing/) が適用されます。