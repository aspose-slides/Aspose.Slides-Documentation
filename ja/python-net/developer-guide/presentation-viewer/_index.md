---
title: プレゼンテーションビューワー
type: docs
weight: 50
url: /ja/python-net/presentation-viewer/
keywords: "PowerPointプレゼンテーションを表示、pptを表示、PPTXを表示、Python、.NET経由のAspose.Slides for Python"
description: "PythonでPowerPointプレゼンテーションを表示"
---



Aspose.Slides for Python via .NETは、スライドを含むプレゼンテーションファイルを作成するために使用されます。これらのスライドは、Microsoft PowerPointを使用してプレゼンテーションを開くことで表示できます。しかし、開発者が好きな画像ビューアでスライドを画像として表示したり、自分自身のプレゼンテーションビューワーを作成したりする必要がある場合もあります。そのような場合、Aspose.Slides for Python via .NETは、個々のスライドを画像にエクスポートすることを可能にします。この記事では、その方法を説明します。
## **ライブ例**
[**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/)の無料アプリを試して、Aspose.Slides APIで実装できることを確認できます：

![powerpoint-in-aspose-viewer](powerpoint-in-aspose-viewer.png)

## **スライドからSVG画像を生成する**
Aspose.Slides for Pythonを使用して、任意のスライドからSVG画像を生成するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
- IDまたはインデックスを使用して、目的のスライドのリファレンスを取得します。
- メモリストリームでSVG画像を取得します。
- メモリストリームをファイルに保存します。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成します
with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    # 最初のスライドにアクセスします
    sld = pres.slides[0]

    # メモリストリームオブジェクトを作成します
    with open("Aspose_out-1.svg", "wb") as svg_stream:
        # スライドのSVG画像を生成し、メモリストリームに保存します
        sld.write_as_svg(svg_stream)
```


## **カスタム形状IDを使用してSVGを生成する**
Aspose.Slides for Python via .NETを使用して、カスタム形状IDを使用してスライドから[SVG](https://docs.fileformat.com/page-description-language/svg/)を生成できます。そのためには、[ISvgShape](https://reference.aspose.com/slides/python-net/aspose.slides.export/isvgshape/)のIDプロパティを使用します。これは生成されたSVG内の形状のカスタムIDを表します。CustomSvgShapeFormattingControllerを使用して形状IDを設定できます。

```py
import aspose.slides as slides

with slides.Presentation(path + "CreateSlidesSVGImage.pptx") as pres:
    with open("Aspose_out-2.svg", "wb") as svg_stream:
        svgOptions = slides.export.SVGOptions()
        pres.slides[0].write_as_svg(svg_stream, svgOptions)
```


## **スライドのサムネイル画像を作成する**
Aspose.Slides for Python via .NETを使用すると、スライドのサムネイル画像を生成できます。Aspose.Slides for Python via .NETを使用して、任意のスライドのサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して、任意のスライドのリファレンスを取得します。
1. 指定したスケールでリファレンスされたスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成します
with slides.Presentation("pres.pptx") as pres:
    # 最初のスライドにアクセスします
    sld = pres.slides[0]

    # フルスケール画像を作成します
    with sld.get_image(1, 1) as bmp:
        # 画像をJPEG形式でディスクに保存します
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```


## **ユーザー定義寸法でサムネイルを作成する**
1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して、任意のスライドのリファレンスを取得します。
1. 指定したスケールでリファレンスされたスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成します
with slides.Presentation("pres.pptx") as pres:
    # 最初のスライドにアクセスします
    sld = pres.slides[0]

    # ユーザー定義の寸法
    desiredX = 1200
    desiredY = 800

    # XとYのスケール値を取得します
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY


    # フルスケール画像を作成します
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # 画像をJPEG形式でディスクに保存します
        bmp.save("Thumbnail2_out.jpg", slides.ImageFormat.JPEG)
```


## **ノートスライドビューのスライドからサムネイルを作成する**
Aspose.Slides for Python via .NETを使用して、ノートスライドビューで任意のスライドのサムネイルを生成するには：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. IDまたはインデックスを使用して、任意のスライドのリファレンスを取得します。
1. ノートスライドビューで指定したスケールでリファレンスされたスライドのサムネイル画像を取得します。
1. 任意の画像形式でサムネイル画像を保存します。

以下のコードスニペットは、ノートスライドビューでプレゼンテーションの最初のスライドのサムネイルを生成します。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成します
with slides.Presentation("pres.pptx") as pres:
    # 最初のスライドにアクセスします
    sld = pres.slides[0]

    # ユーザー定義の寸法
    desiredX = 1200
    desiredY = 800

    # XとYのスケール値を取得します
    ScaleX = (1.0 / pres.slide_size.size.width) * desiredX
    ScaleY = (1.0 / pres.slide_size.size.height) * desiredY

   
    # フルスケール画像を作成します                
    with sld.get_image(ScaleX, ScaleY) as bmp:
        # 画像をJPEG形式でディスクに保存します
        bmp.save("Notes_tnail_out.jpg", slides.ImageFormat.JPEG)
```