---
title: Python で PowerPoint の画像管理を最適化
linktitle: 画像を管理
type: docs
weight: 10
url: /ja/python-net/image/
keywords:
- 画像を追加
- ピクチャーを追加
- ビットマップを追加
- 画像を置き換える
- ピクチャーを置き換える
- Web から
- 背景
- PNG を追加
- JPG を追加
- SVG を追加
- EMF を追加
- WMF を追加
- TIFF を追加
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python（.NET）を使用して、PowerPoint および OpenDocument の画像管理を効率化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---

## **概要**

画像はプレゼンテーションをより魅力的で面白くします。Microsoft PowerPoint では、ファイル、インターネット、またはその他のソースから画像をスライドに挿入できます。同様に、Aspose.Slides でもさまざまな方法で画像をスライドに追加できます。

{{% alert  title="ヒント" color="primary" %}}

Aspose は無料コンバータ―、[JPEG から PowerPoint へ](https://products.aspose.app/slides/import/jpg-to-ppt) と [PNG から PowerPoint へ](https://products.aspose.app/slides/import/png-to-ppt) を提供しており、画像からすぐにプレゼンテーションを作成できます。

{{% /alert %}}

{{% alert title="情報" color="info" %}}

フレームオブジェクトとして画像を追加したい場合—特にサイズ変更やエフェクト適用などの標準フォーマット オプションを使用する予定がある場合は、[Python 用プレゼンテーションへの画像フレームの追加](https://docs.aspose.com/slides/python-net/picture-frame/) を参照してください。

{{% /alert %}}

{{% alert title="注意" color="warning" %}}

画像およびプレゼンテーションの I/O 操作を使用して、画像をフォーマット間で変換できます。次のページを参照してください: [画像を JPG に変換](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); [JPG を画像に変換](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); [JPG を PNG に変換](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/); [PNG を JPG に変換](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); [PNG を SVG に変換](https://products.aspose.com/slides/python-net/conversion/png-to-svg/); および [SVG を PNG に変換](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slides は JPEG、PNG、BMP、GIF などの一般的なフォーマットの画像の操作をサポートします。

## **ローカルに保存された画像をスライドに追加する**

コンピューター上の画像を 1 つまたは複数、プレゼンテーションのスライドに追加できます。次の Python の例は、画像をスライドに追加する方法を示しています:
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.jpeg", "rb") as image_stream:
        image = presentation.images.add_image(image_stream)
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation_with_image.pptx", slides.export.SaveFormat.PPTX)
```


## **Web からの画像をスライドに追加する**

スライドに追加したい画像がコンピューターにない場合は、Web から直接挿入できます。

次の Python の例は、URL から画像を取得してスライドに追加する方法を示しています:
```py
import aspose.slides as slides
import urllib2
import base64

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image_data = base64.b64encode(urllib2.urlopen("[REPLACE WITH URL]").read())

    image = presentation.images.add_image(image_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)
    
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


## **スライド マスターに画像を追加する**

スライド マスターは、すべての下位スライドのテーマ、レイアウトなどの情報を保持および管理する最上位のスライドです。スライド マスターに画像を追加すると、そのマスターを使用するすべてのスライドに画像が表示されます。

次の Python の例は、スライド マスターに画像を追加する方法を示しています:
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


## **画像をスライドの背景として設定する**

特定のスライドまたは複数のスライドの背景に画像を使用したい場合があります。詳細は、[スライドの背景に画像を設定する](https://docs.aspose.com/slides/python-net/presentation-background/#set-image-as-background-for-slide) を参照してください。

## **プレゼンテーションに SVG を追加する**

[add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) メソッド ( [ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) クラス) を使用して、任意の画像をプレゼンテーションに挿入できます。

SVG から画像オブジェクトを作成する手順は次のとおりです:

1. [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) を作成し、プレゼンテーションの画像コレクションに追加します。  
2. [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) から [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) オブジェクトを作成します。  
3. [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を使用して [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) オブジェクトを作成します。

次の Python サンプルは、これらの手順を使用して SVG 画像をプレゼンテーションに追加する方法を示しています:
```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # SVG ファイルの内容を読み込む。
    with open("sample.svg", "rt") as image_stream:
        svg_content = image_stream.read()
        # SvgImage オブジェクトを作成する。
        svg_image = slides.SvgImage(svg_content)

        # PPImage オブジェクトを作成する。
        pp_image = presentation.images.add_image(svg_image)

        # 新しい PictureFrame を作成する。
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 200, 100, pp_image.width, pp_image.height, pp_image)

        # プレゼンテーションを PPTX 形式で保存する。
        presentation.save("presentation_with_SVG.pptx", slides.export.SaveFormat.PPTX)
```


## **SVG を形状のセットに変換する**

Aspose.Slides は、PowerPoint の SVG 処理方式に似た方法で SVG を形状のセットに変換します。

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[ShapeCollection](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/) クラスの [add_group_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_group_shape/) メソッドのオーバーロードによって提供され、最初の引数として [SvgImage](https://reference.aspose.com/slides/python-net/aspose.slides/svgimage/) を受け取ります。

以下のサンプルコードは、SVG ファイルを形状のセットに変換する方法を示しています。
```py 
import aspose.slides as slides

with slides.Presentation() as presentation:
    # SVG ファイルの内容を読み込む。
    with open("sample.svg","rt") as image_stream:
        svg_content = image_stream.read()
        # SvgImage オブジェクトを作成する。
        svg_image = slides.SvgImage(svg_content)

        # スライドサイズを取得する。
        slide_size = presentation.slide_size.size

        # SVG 画像をシェイプのグループに変換し、スライドサイズに合わせてスケーリングする。
        presentation.slides[0].shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

        # プレゼンテーションを PPTX 形式で保存する。
        presentation.save("shapes_from_SVG.pptx", slides.export.SaveFormat.PPTX)
```


## **スライドに EMF 画像として追加する**

Aspose.Slides for Python は、Enhanced Metafile (EMF) 画像をプレゼンテーションに挿入できます。

次の Python の例は、その方法を示しています:
```py 
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    with open("image.emf", "rb") as image_stream:
        emf_image = presentation.images.add_image(image_stream)
        slide_size = presentation.slide_size.size
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, slide_size.width, slide_size.height, emf_image)
    
    presentation.save("presentation_with_EMF.pptx", slides.export.SaveFormat.PPTX)
```


## **画像コレクション内の画像を置き換える**

Aspose.Slides は、プレゼンテーションの画像コレクションに格納されている画像（スライドのシェイプで使用されているものも含む）を置き換える機能を提供します。このセクションでは、コレクション内の画像を更新するいくつかのアプローチを概説します。API は、生バイト データ、[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像で画像を置き換えるシンプルなメソッドを提供します。

手順:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスを使用して、画像が含まれるプレゼンテーションをロードします。  
2. ファイルから新しい画像をバイト配列にロードします。  
3. バイト配列を使用して対象画像を新しい画像に置き換えます。  
4. または、画像を [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置き換えます。  
5. あるいは、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置き換えます。  
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。  
```py
def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()


# プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
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

Aspose の無料 [Text to GIF](https://products.aspose.app/slides/text-to-gif) コンバータを使用すれば、テキストを簡単にアニメーション化し GIF に変換できます。

{{% /alert %}}

## **FAQ**

**画像を挿入した後、元の解像度は保持されますか？**

はい。元のピクセルは保持されますが、最終的な見た目はスライド上で [picture](/slides/ja/python-net/picture-frame/) がどのようにスケーリングされるか、保存時に適用される圧縮に依存します。

**多数のスライドにわたって同じロゴを一括で置き換える最良の方法は？**

マスタースライドまたはレイアウトにロゴを配置し、プレゼンテーションの画像コレクションで置き換えると、リソースを使用しているすべての要素に変更が自動的に反映されます。

**挿入した SVG を編集可能な形状に変換できますか？**

はい。SVG を形状のグループに変換でき、個々のパーツは標準の形状プロパティで編集可能になります。

**複数のスライドに同時に画像を背景として設定するには？**

マスタースライドまたは該当レイアウトで [画像を背景として割り当てる](/slides/ja/python-net/presentation-background/) と、そこを使用しているすべてのスライドが背景を継承します。

**多数の画像によりプレゼンテーションのサイズが膨張するのを防ぐには？**

同一画像リソースを再利用し、重複を避け、適切な解像度を選び、保存時に圧縮を適用し、繰り返し使用するグラフィックは可能な限りマスターに置くようにします。