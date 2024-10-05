---
title: スライド上の図形のサイズ変更
type: docs
weight: 130
url: /python-net/re-sizing-shapes-on-slide/
---

## **スライド上の図形のサイズ変更**
Aspose.Slides for Python via .NET の顧客からの最も頻繁に寄せられる質問の一つは、スライドのサイズが変更されたときにデータが切り取られないように図形のサイズをどのように変更するかということです。この短い技術的ヒントでは、その方法を示します。 

図形の位置ズレを避けるために、スライド上の各図形は新しいスライドサイズに応じて更新する必要があります。

```py
import aspose.slides as slides

#プレゼンテーションを読み込む
with slides.Presentation("pres.pptx") as presentation:
    #古いスライドサイズ
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #スライドサイズを変更する
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #新しいスライドサイズ
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width

    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #位置をサイズ変更する
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #必要に応じて図形のサイズを変更する 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

    presentation.save("Resize-1.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

スライドにテーブルがある場合、上記のコードは完璧には機能しません。その場合、テーブルの各セルはサイズを変更する必要があります。

{{% /alert %}} 

テーブル付きのスライドをリサイズする必要がある場合は、以下のコードを使用する必要があります。テーブルの幅や高さを設定することは、個々の行の高さと列の幅を変更してテーブルの高さと幅を変更する必要がある特別なケースです。

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    #古いスライドサイズ
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #スライドサイズを変更する
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #新しいスライドサイズ
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width

    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for master in presentation.masters:
        for shape in master.shapes:
            #位置をサイズ変更する
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #必要に応じて図形のサイズを変更する 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

        for layoutslide in master.layout_slides:
            for shape in layoutslide.shapes:
                #位置をサイズ変更する
                shape.height = shape.height * ratioHeight
                shape.width = shape.width * ratioWidth

                #必要に応じて図形のサイズを変更する 
                shape.y = shape.y * ratioHeight
                shape.x = shape.x * ratioWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #位置をサイズ変更する
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #必要に応じて図形のサイズを変更する 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth
            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * ratioHeight
                for col in shape.columns:
                    col.width = col.width * ratioWidth

    presentation.save("Resize-2.pptx", slides.export.SaveFormat.PPTX)
```