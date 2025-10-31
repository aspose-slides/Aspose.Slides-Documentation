---
title: "Python のプレゼンテーション シェイプから画像を抽出"
linktitle: "シェイプからの画像"
type: docs
weight: 90
url: /ja/python-net/extracting-images-from-presentation-shapes/
keywords:
- "画像を抽出"
- "画像を取得"
- "スライド背景"
- "シェイプ背景"
- "PowerPoint"
- "プレゼンテーション"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのシェイプから画像を抽出する - 迅速でコードに優しいソリューション。"
---

## **シェイプから画像を抽出**

{{% alert color="primary" %}} 

画像はシェイプに頻繁に追加され、スライドの背景としてもよく使用されます。画像オブジェクトは [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) つまり [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) オブジェクトのコレクションを通じて追加されます。 

この記事では、プレゼンテーションに追加された画像を抽出する方法を説明します。 

{{% /alert %}} 

プレゼンテーションから画像を抽出するには、まず各スライドを順に巡回し、次に各シェイプを巡回して画像を特定する必要があります。画像が見つかったら、抽出して新しいファイルとして保存できます。 XXX 

```py
import aspose.slides as slides

def get_image_format(image_type):
    return {
        "jpeg": slides.ImageFormat.JPEG,
        "emf": slides.ImageFormat.EMF,
        "bmp": slides.ImageFormat.BMP,
        "png": slides.ImageFormat.PNG,
        "wmf": slides.ImageFormat.WMF,
        "gif": slides.ImageFormat.GIF,
    }.get(image_type, slides.ImageFormat.JPEG)

with slides.Presentation("pres.pptx") as pres:
    #プレゼンテーションにアクセス
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        #最初のスライドにアクセス
        image_format = slides.ImageFormat.JPEG

        back_image = None
        file_name = "BackImage_Slide_{0}{1}.{2}"
        is_layout = False

        if slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #バック画像を取得
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #バック画像を取得
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            #目的の画像形式を設定
            image_type = back_image.content_type.split("/")[1]
            image_format = get_image_format(image_type)

            back_image.image.save(
                file_name.format("LayoutSlide_" if is_layout else "", slideIndex, image_type), 
                image_format)

        for i in range(len(slide.shapes)):
            shape = slide.shapes[i]
            shape_image = None

            if type(shape) is slides.AutoShape and shape.fill_format.fill_type == slides.FillType.PICTURE:
                shape_image = shape.fill_format.picture_fill_format.picture.image
            elif type(shape) is slides.PictureFrame:
                shape_image = shape.picture_format.picture.image

            if shape_image is not None:
                image_type = shape_image.content_type.split("/")[1]
                image_format = get_image_format(image_type)

                shape_image.image.save(
                                file_name.format("shape_"+str(i)+"_", slideIndex, image_type), 
                                image_format)
```

## **FAQ**

**画像をトリミングやエフェクト、シェイプ変換なしで元の状態で抽出できますか？**

はい。シェイプの画像にアクセスすると、プレゼンテーションの[image collection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) から画像オブジェクトが取得されます。つまり、トリミングやスタイリング効果が適用されていない元のピクセルが得られます。ワークフローはプレゼンテーションの画像コレクションと[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) オブジェクトを順に処理し、生データを保持しています。

**多数の画像を一度に保存すると、同一ファイルが重複して保存されるリスクはありますか？**

はい、すべてを無差別に保存すると重複のリスクがあります。プレゼンテーションの[image collection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) には、異なるシェイプやスライドから参照される同一バイナリデータが含まれることがあります。重複を回避するには、書き込む前にハッシュ、サイズ、または抽出データの内容を比較してください。

**プレゼンテーションのコレクションから特定の画像にリンクされているシェイプをどのように判別できますか？**

Aspose.Slides は[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) からシェイプへの逆リンクを保持していません。走査中に手動でマッピングを作成してください。[PPImage] への参照が見つかったら、どのシェイプがそれを使用しているかを記録します。

**OLE オブジェクト（添付文書など）に埋め込まれた画像を抽出できますか？**

直接はできません。OLE オブジェクトはコンテナであるためです。まず OLE パッケージ自体を抽出し、別ツールで内容を解析する必要があります。プレゼンテーションの画像シェイプは[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を通じて機能しますが、OLE は別のオブジェクトタイプです。