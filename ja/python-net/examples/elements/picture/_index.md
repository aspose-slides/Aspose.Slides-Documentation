---
title: 画像
type: docs
weight: 50
url: /ja/python-net/examples/elements/picture/
keywords:
- 画像
- 画像フレーム
- 画像を追加
- 画像にアクセス
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides を使用して Python で画像を操作します：挿入、置換、クロップ、圧縮、透明度とエフェクトの調整、シェイプの塗りつぶし、そして PPT、PPTX、ODP にエクスポートします。"
---
インメモリ画像から画像を挿入およびアクセスする方法を、**Aspose.Slides for Python via .NET** を使用して示します。以下の例では、メモリ内に画像を作成し、スライドに配置し、そして取得します。

## **画像を追加**

このコードはファイルから画像を読み込み、最初のスライドに画像フレームとして挿入します。

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # ファイルから画像を読み込みます。
        with open("image.png", "rb") as image_stream:
            # 画像をプレゼンテーションのリソースに追加します。
            image = presentation.images.add_image(image_stream)

        # 最初のスライドに画像を表示する画像フレームを挿入します。
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **画像にアクセス**

この例では、スライドに画像フレームが含まれていることを確認し、見つかった最初のフレームにアクセスします。

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # スライド上の最初の画像フレームにアクセスします。
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```