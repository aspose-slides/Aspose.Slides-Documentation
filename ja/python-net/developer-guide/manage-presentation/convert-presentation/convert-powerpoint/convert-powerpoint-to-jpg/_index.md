---
title: PythonでPPT、PPTX、ODPをJPGに変換
linktitle: スライドをJPG画像に変換
type: docs
weight: 60
url: /ja/python-net/convert-powerpoint-to-jpg/
keywords:
- PowerPointをJPGに変換
- プレゼンテーションをJPGに変換
- スライドをJPGに変換
- PPTをJPGに変換
- PPTXをJPGに変換
- ODPをJPGに変換
- PowerPointをJPGに変換
- プレゼンテーションをJPGに変換
- スライドをJPGに変換
- PPTをJPGに変換
- PPTXをJPGに変換
- ODPをJPGに変換
- PowerPointをJPEGに変換
- プレゼンテーションをJPEGに変換
- スライドをJPEGに変換
- PPTをJPEGに変換
- PPTXをJPEGに変換
- ODPをJPEGに変換
- PowerPointをJPEGに変換
- プレゼンテーションをJPEGに変換
- スライドをJPEGに変換
- PPTをJPEGに変換
- PPTXをJPEGに変換
- ODPをJPEGに変換
- Python
- Aspose.Slides
description: "Pythonの数行のコードで、PowerPointやOpenDocumentプレゼンテーションのスライドを高品質なJPEG画像に変換する方法を学びましょう。プレゼンテーションをウェブでの利用、共有、アーカイブに最適化します。今すぐ完全なガイドをお読みください！"
---

## **概要**

PowerPoint および OpenDocument のプレゼンテーションを JPG 画像に変換すると、スライドの共有、パフォーマンスの最適化、Web サイトやアプリケーションへのコンテンツ埋め込みが容易になります。Aspose.Slides for Python を使用すると、PPTX、PPT、ODP ファイルを高品質な JPEG 画像に変換できます。本ガイドでは、さまざまな変換方法を説明します。

これらの機能を使用すれば、独自のプレゼンテーションビューアを実装したり、各スライドのサムネイルを作成したりできます。プレゼンテーションのスライドをコピーから保護したり、読み取り専用モードでプレゼンテーションをデモンストレーションしたりする場合に便利です。Aspose.Slides では、プレゼンテーション全体または特定のスライドを画像形式に変換できます。

## **プレゼンテーション スライドを JPG 画像に変換する**

PPT、PPTX、または ODP ファイルを JPG に変換する手順は次のとおりです。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) コレクションから [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) 型のスライド オブジェクトを取得します。
3. [Slide.get_image(scale_x, scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float) メソッドを使用してスライドの画像を作成します。
4. 画像オブジェクトの [IImage.save(filename, format)](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/#str-imageformat) メソッドを呼び出します。出力ファイル名と画像形式を引数として渡します。

{{% alert color="primary" %}}

**注意:** PPT、PPTX、または ODP から JPG への変換は、Aspose.Slides Python API における他の形式への変換と異なります。他の形式の場合、通常は [Presentation.save(fname, format, options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions) メソッドを使用します。ただし、JPG 変換の場合は [IImage.save(filename, format)](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/#str-imageformat) メソッドを使用する必要があります。

{{% /alert %}}
```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # 画像を JPEG 形式でディスクに保存します。
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```


## **カスタマイズされたサイズでスライドを JPG に変換する**

生成される JPG 画像のサイズを変更するには、[Slide.get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) メソッドにサイズを渡して指定します。これにより、特定の幅と高さの画像を生成でき、解像度やアスペクト比の要件を満たすことができます。この柔軟性は、Web アプリケーション、レポート、ドキュメントなど、正確な画像サイズが必要な場合に特に有用です。
```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # 指定したサイズのスライド画像を作成します。
        with slide.get_image(image_size) as thumbnail:
            # 画像を JPEG 形式でディスクに保存します。
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```


## **スライドを画像として保存するときにコメントを描画する**

Aspose.Slides for Python は、スライドを JPG 画像に変換する際にプレゼンテーションのコメントを描画できる機能を提供します。この機能は、PowerPoint プレゼンテーションに共同作業者が追加した注釈、フィードバック、議論を保持するのに特に役立ちます。このオプションを有効にすると、生成された画像にコメントが表示され、元のプレゼンテーション ファイルを開かなくてもフィードバックの確認や共有が容易になります。

例えば、コメントが含まれたスライドを持つプレゼンテーション ファイル「sample.pptx」があるとします。

![コメント付きスライド](slide_with_comments.png)

以下の Python コードは、コメントを保持したままスライドを JPG 画像に変換します。
```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # スライドコメントのオプションを設定します。
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # 最初のスライドを画像に変換します。
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```


結果:

![コメント付き JPG 画像](image_with_comments.png)

## **関連項目**

PPT、PPTX、または ODP を画像に変換する他のオプションをご覧ください。

- [PowerPoint を GIF に変換](/slides/ja/python-net/convert-powerpoint-to-animated-gif/)
- [PowerPoint を PNG に変換](/slides/ja/python-net/convert-powerpoint-to-png/)
- [PowerPoint を TIFF に変換](/slides/ja/python-net/convert-powerpoint-to-tiff/)
- [PowerPoint を SVG に変換](/slides/ja/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Aspose.Slides が PowerPoint を JPG 画像に変換する様子を確認するには、無料のオンラインコンバータをご利用ください: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) および [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 

{{% /alert %}} 

![無料オンライン PPTX to JPG コンバータ](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose は [無料の Collage Web アプリ](https://products.aspose.app/slides/collage) を提供しています。このオンラインサービスを使用して、[JPG to JPG](https://products.aspose.app/slides/collage/jpg) や PNG to PNG 画像を結合したり、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid) を作成したりできます。 

本記事で説明した同じ原則を使用すれば、画像を別の形式に変換できます。詳細は以下のページをご参照ください: 画像を JPG に変換([image to JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/))、JPG を画像に変換([JPG to image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/))、JPG を PNG に変換([JPG to PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/))、PNG を JPG に変換([PNG to JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/))、PNG を SVG に変換([PNG to SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/))、SVG を PNG に変換([SVG to PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/))。

{{% /alert %}}

## **FAQ**

**この方法はバッチ変換をサポートしていますか？**

はい、Aspose.Slides は単一の操作で複数のスライドを JPG にバッチ変換できます。

**変換は SmartArt、チャート、その他の複雑なオブジェクトをサポートしていますか？**

はい、Aspose.Slides は SmartArt、チャート、テーブル、シェイプなどすべてのコンテンツをレンダリングします。ただし、カスタム フォントや欠落フォントを使用した場合、PowerPoint と比較して若干のレンダリング精度の違いが生じることがあります。

**処理できるスライド数に制限はありますか？**

Aspose.Slides 自体はスライド数に厳格な制限を設けていません。ただし、大規模なプレゼンテーションや高解像度画像を扱う際に、メモリ不足エラーが発生する可能性があります。