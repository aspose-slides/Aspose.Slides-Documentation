---
title: Python で PowerPoint の画像管理を最適化
linktitle: 画像を管理
type: docs
weight: 10
url: /ja/python-net/image/
keywords:
- 画像を追加
- 画像を挿入
- ビットマップを追加
- 画像を置換
- 画像を置換
- Web から
- 背景
- PNG を追加
- JPG を追加
- SVG を追加
- EMF を追加
- WMF を追加
- TIFF を追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: ".NET 経由で Python 用 Aspose.Slides を使用し、PowerPoint と OpenDocument の画像管理を効率化し、パフォーマンスを最適化してワークフローを自動化します。"
---
## **概要**

画像はプレゼンテーションをより魅力的で面白くします。Microsoft PowerPoint では、ファイル、インターネット、またはその他のソースから画像をスライドに挿入できます。同様に、Aspose.Slides では、さまざまな方法で画像をスライドに追加できます。

{{% alert  title="ヒント" color="primary" %}}
Aspose は、画像からプレゼンテーションをすばやく作成できる無料コンバータ―[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt)―を提供しています。
{{% /alert %}}

{{% alert title="情報" color="info" %}}
画像をフレームオブジェクトとして追加したい場合—特にリサイズやエフェクトの適用など標準の書式設定オプションを使用する予定がある場合—は、[Python でプレゼンテーションに画像フレームを追加する](https://docs.aspose.com/slides/ja/python-net/picture-frame/) を参照してください。
{{% /alert %}}

{{% alert title="注" color="warning" %}}
画像とプレゼンテーションの入出力操作を使用して、画像形式を相互に変換できます。以下のページを参照してください: [画像を JPG に変換](https://products.aspose.com/slides/ja/python-net/conversion/image-to-jpg/); [JPG を画像に変換](https://products.aspose.com/slides/ja/python-net/conversion/jpg-to-image/); [JPG を PNG に変換](https://products.aspose.com/slides/ja/python-net/conversion/jpg-to-png/); [PNG を JPG に変換](https://products.aspose.com/slides/ja/python-net/conversion/png-to-jpg/); [PNG を SVG に変換](https://products.aspose.com/slides/ja/python-net/conversion/png-to-svg/); および [SVG を PNG に変換](https://products.aspose.com/slides/ja/python-net/conversion/svg-to-png/)。
{{% /alert %}}

Aspose.Slides は、JPEG、PNG、BMP、GIF などの一般的なフォーマットの画像を扱うことをサポートしています。

## **ローカルに保存された画像をスライドに追加**

コンピューターから 1 つまたは複数の画像をプレゼンテーションのスライドに追加できます。以下の Python の例は、スライドに画像を追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **Web から画像をスライドに追加**

スライドに追加したい画像がコンピューターにない場合、Web から直接挿入できます。

以下の Python の例は、URL から画像を取得してスライドに追加する方法を示しています。

```py
import aspose.slides as slides
from urllib.request import urlopen

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # 画像の生バイトデータをダウンロードします。
    with urlopen("[REPLACE WITH URL]") as response:
        image_data = response.read()

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドマスターに画像を追加**

スライドマスターは、下位のすべてのスライドに対してテーマやレイアウトなどの情報を保持・制御する最上位のスライドです。スライドマスターに画像を追加すると、その画像はそのマスターを使用するすべてのスライドに表示されます。

以下の Python の例は、スライドマスターに画像を追加する方法を示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    master_slide = slide.layout_slide.master_slide

    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("master_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドの背景として画像を追加**

1 つまたは複数のスライドの背景として画像を使用できます。詳細は、*[スライドの背景として画像を設定](/slides/ja/python-net/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **プレゼンテーションに SVG を追加**

SVG コンテンツは、[SvgImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/svgimage/) クラスを使用してプレゼンテーションに追加できます。生成された SVG 画像はプレゼンテーションの画像コレクションに追加でき、画像フレームの作成に使用できます。

```py
import aspose.slides as slides

svg_content = """
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>
"""

with slides.Presentation() as presentation:
    svg_image = slides.SvgImage(svg_content)
    image = presentation.images.add_image(svg_image)

    presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 20, 20, image.width, image.height, image
    )

    presentation.save("self-contained-svg.pptx", slides.export.SaveFormat.PPTX)
```

## **SVG を図形のセットに変換**

Aspose.Slides は、PowerPoint の SVG 処理方式と同様に、SVG を図形のセットに変換します。

![PowerPoint ポップアップ メニュー](img_01_01.png)

この機能は、[ShapeCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/) クラスの [add_group_shape](https://reference.aspose.com/slides/ja/python-net/aspose.slides/shapecollection/add_group_shape/) メソッドのオーバーロードによって提供され、最初の引数として [SvgImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/svgimage/) を受け取ります。

以下のサンプルコードは、SVG ファイルを図形のセットに変換する方法を示しています。

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # SVG ファイルの内容を読み込みます。
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # SvgImage オブジェクトを作成します。
        svg_image = slides.SvgImage(svg_content)

        # スライドサイズを取得します。
        slide_size = presentation.slide_size.size

        # SVG 画像を図形のグループに変換し、スライドサイズに合わせてスケーリングします。
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # プレゼンテーションを PPTX 形式で保存します。
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```

## **スライドに EMF 画像を追加**

Aspose.Slides for Python を使用すると、拡張メタファイル (EMF) 画像をプレゼンテーションに挿入できます。

以下の Python の例は、この操作を示しています。

```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```

## **画像コレクション内の画像を置換**

Aspose.Slides では、プレゼンテーションの画像コレクションに格納された画像（スライド形状が使用している画像を含む）を置換できます。このセクションでは、コレクション内の画像を更新するさまざまなアプローチを示します。API は、生のバイト データ、[IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像で画像を置換するシンプルなメソッドを提供します。

手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) クラスを使用して、画像が含まれるプレゼンテーションをロードします。
1. ファイルから新しい画像をバイト配列にロードします。
1. バイト配列を使用して対象画像を新しい画像に置換します。
1. あるいは、画像を [IImage](https://reference.aspose.com/slides/ja/python-net/aspose.slides/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置換します。
1. または、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置換します。
1. 修正したプレゼンテーションを PPTX ファイルとして保存します。

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation("sample.pptx") as presentation:

    # 最初の方法。
    image_data = read_all_bytes("image0.jpeg")
    old_image = presentation.images[0]
    old_image.replace_image(image_data)

    # 二番目の方法。
    new_image = slides.Images.from_file("image1.jpeg")
    old_image = presentation.images[1]
    old_image.replace_image(new_image)

    # 三番目の方法。
    old_image = presentation.images[2]
    old_image.replace_image(presentation.images[3])

    # プレゼンテーションをファイルに保存します。
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="情報" color="info" %}}
Aspose の無料 [テキストから GIF](https://products.aspose.app/slides/ja/text-to-gif) コンバータを使用すれば、テキストを簡単にアニメーション化し GIF に変換できます。
{{% /alert %}}

## **よくある質問**

**挿入後も元の画像解像度は保持されますか？**

はい。元のピクセルは保持されますが、最終的な見た目はスライド上で [picture](/slides/ja/python-net/picture-frame/) がどのようにスケーリングされるか、保存時に適用される圧縮によって変わります。

**多数のスライドにわたって同じロゴを一括で置換する最適な方法は何ですか？**

ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置換すれば、該当リソースを使用しているすべての要素に自動的に反映されます。

**挿入した SVG を編集可能な形状に変換できますか？**

はい。SVG を図形のグループに変換でき、その後個々のパーツは標準の形状プロパティで編集可能になります。

**複数のスライドの背景として同じ画像を一括で設定するには？**

マスタースライドまたは該当レイアウトで画像を背景として割り当てれば、そのマスター／レイアウトを使用しているスライドはすべて背景画像を継承します。

**画像が多くてプレゼンテーションが大きくなりすぎるのを防ぐには？**

同一画像を重複して使用せずに再利用し、解像度を適切に設定し、保存時に圧縮を適用し、可能な限りマスターにグラフィックを置くことでファイルサイズを抑えられます。