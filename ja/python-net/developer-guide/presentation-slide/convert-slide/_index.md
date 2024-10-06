---
title: スライドの変換
type: docs
weight: 41
url: /ja/python-net/convert-slide/
keywords: 
- スライドを画像に変換
- スライドを画像としてエクスポート
- スライドを画像として保存
- スライドを画像に
- スライドをPNGに
- スライドをJPEGに
- スライドをビットマップに
- PHP
- Aspose.Slides for Python via .NET
description: "PythonでPowerPointスライドを画像（ビットマップ、PNG、またはJPG）に変換する"
---

Aspose.Slides for Python via .NETを使用すると、スライド（プレゼンテーション内の）を画像に変換できます。サポートされている画像フォーマットは、BMP、PNG、JPG（JPEG）、GIFなどです。

スライドを画像に変換するには、次の手順を行います：

1. まず、[ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/)インターフェースまたは
   * [IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/)インターフェースを使用して、変換パラメータと変換するスライドオブジェクトを設定します。

2. 次に、[get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)メソッドを使用してスライドを画像に変換します。

## **ビットマップおよびその他の画像フォーマットについて**

.NETでは、[Bitmap](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.bitmap?view=net-5.0)は、ピクセルデータによって定義された画像で作業するためのオブジェクトです。このクラスのインスタンスを使用して、幅広い形式（BMP、JPG、PNGなど）で画像を保存できます。

{{% alert title="情報" color="info" %}}

Asposeは最近、オンラインの[テキストからGIF](https://products.aspose.app/slides/text-to-gif)変換ツールを開発しました。

{{% /alert %}}

## **スライドをビットマップに変換し、PNG形式で画像を保存する**

このPythonコードは、プレゼンテーションの最初のスライドをビットマップオブジェクトに変換し、その後画像をPNG形式で保存する方法を示しています：

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # プレゼンテーションの最初のスライドをビットマップオブジェクトに変換
    with pres.slides[0].get_image() as bmp:
        # PNG形式で画像を保存
        bmp.save("Slide_0.png", slides.ImageFormat.PNG)
```

{{% alert title="ヒント" color="primary" %}} 

スライドをビットマップオブジェクトに変換し、そのオブジェクトをどこかで直接使用できます。また、スライドをビットマップに変換し、JPEGまたはお好みの別の形式で画像を保存することもできます。

{{% /alert %}}  

## **カスタムサイズの画像にスライドを変換する**

特定のサイズの画像が必要な場合があります。[get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)のオーバーロードを使用して、特定の寸法（長さと幅）の画像にスライドを変換できます。

このサンプルコードは、Pythonでの[get_image](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)メソッドを使用した変換を示しています：

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # プレゼンテーションの最初のスライドを指定されたサイズのビットマップに変換
    with pres.slides[0].get_image(draw.Size(1820, 1040)) as bmp:
        # JPEG形式で画像を保存
        bmp.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **ノートとコメントを含むスライドを画像に変換する**

一部のスライドにはノートやコメントが含まれています。

Aspose.Slidesは、プレゼンテーションのスライドを画像にレンダリングする制御を可能にする二つのインターフェース、[ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/)および[IRenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/irenderingoptions/)を提供します。どちらのインターフェースにも、スライドを画像に変換するときにノートやコメントを追加できる[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/)インターフェースが含まれています。

{{% alert title="情報" color="info" %}} 

[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/)インターフェースを使用すると、生成される画像におけるノートとコメントの好みの位置を指定できます。

{{% /alert %}} 

このPythonコードは、ノートとコメントを含むスライドの変換プロセスを示しています：

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("AddNotesSlideWithNotesStyle_out.pptx") as pres:
    # レンダリングオプションを作成
    options = slides.export.RenderingOptions()
                
    # ページ上のノートの位置を設定
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
                
    # ページ上のコメントの位置を設定
    options.notes_comments_layouting.comments_position = slides.export.CommentsPositions.RIGHT

    # コメント出力エリアの幅を設定
    options.notes_comments_layouting.comments_area_width = 500
                
    # コメントエリアの色を設定
    options.notes_comments_layouting.comments_area_color = draw.Color.antique_white
                
    # プレゼンテーションの最初のスライドをビットマップオブジェクトに変換
    with pres.slides[0].get_image(options, 2, 2) as bmp:
        # GIF形式で画像を保存
        bmp.save("Slide_Notes_Comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="注意" color="warning" %}} 

スライドを画像に変換するプロセスでは、[NotesPositions](https://reference.aspose.com/slides/python-net/aspose.slides.export/inotescommentslayoutingoptions/)プロパティをBottomFullに設定してはいけません（ノートの位置を指定するため）。というのも、ノートのテキストが大きい場合、指定された画像サイズに収まらない可能性があるからです。

{{% /alert %}} 

## **ITiffOptionsを使用してスライドを画像に変換する**

[ITiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/itiffoptions/)インターフェースを使用すると、生成される画像に対する制御が強化されます。このインターフェースを使用すると、サイズ、解像度、カラーパレット、その他のパラメータを指定できます。

このPythonコードは、ITiffOptionsを使用して300dpi解像度と2160 × 2800サイズの白黒画像を出力する変換プロセスを示しています：

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "Comments1.pptx") as pres:
    # インデックスによってスライドを取得
    slide = pres.slides[0]

    # TiffOptionsオブジェクトを作成
    options = slides.export.TiffOptions() 
    options.image_size = draw.Size(2160, 2880)

    # ソースフォントが見つからない場合に使用されるフォントを設定
    options.default_regular_font = "Arial Black"

    # ページ上のノートの位置を設定 
    options.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    # ピクセルフォーマットを設定（白黒）
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED

    # 解像度を設定
    options.dpi_x = 300
    options.dpi_y = 300

    # スライドをビットマップオブジェクトに変換
    with slide.get_image(options) as bmp:
        # BMP形式で画像を保存
        bmp.save("PresentationNotesComments.tiff", slides.ImageFormat.TIFF)
```

## **すべてのスライドを画像に変換する**

Aspose.Slidesは、単一のプレゼンテーション内のすべてのスライドを画像に変換することを可能にします。基本的には、プレゼンテーション全体を画像に変換することができます。

このサンプルコードは、Pythonでプレゼンテーションのすべてのスライドを画像に変換する方法を示しています：

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as pres:
    # プレゼンテーションをスライドごとに画像配列としてレンダリング
    for i in range(len(pres.slides)):
        # 非表示スライドの設定を指定（非表示スライドはレンダリングしない）
        if pres.slides[i].hidden:
            continue

        # スライドをビットマップオブジェクトに変換
        with pres.slides[i].get_image() as bmp:
            # JPEG形式で画像を保存
            bmp.save("image_{0}.jpeg".format(i), slides.ImageFormat.JPEG)
```