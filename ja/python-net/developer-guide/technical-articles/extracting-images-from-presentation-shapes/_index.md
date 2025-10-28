---
title: Python でプレゼンテーションシェイプから画像を抽出
linktitle: シェイプから画像
type: docs
weight: 90
url: /ja/python-net/extracting-images-from-presentation-shapes/
keywords:
- 画像抽出
- 画像取得
- スライド背景
- シェイプ背景
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint と OpenDocument プレゼンテーションのシェイプから画像を抽出します — 迅速でコードにやさしいソリューション。"
---

## **シェイプから画像を抽出**

{{% alert color="primary" %}} 

画像はシェイプに追加されることが多く、またスライドの背景としても頻繁に使用されます。画像オブジェクトは [IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) を介して追加され、これは [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) オブジェクトのコレクションです。 

本記事では、プレゼンテーションに追加された画像を抽出する方法を説明します。 

{{% /alert %}} 

プレゼンテーションから画像を抽出するには、まずすべてのスライドを走査し、次に各スライドのすべてのシェイプを走査して画像を特定する必要があります。画像が見つかり、または識別されたら、抽出して新しいファイルとして保存できます。 XXX 

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
    #Accessing the presentation
    
    slideIndex = 0
    image_type = ""
    ifImageFound = False
    for slide in pres.slides:
        slideIndex += 1
        #Accessing the first slide
        image_format = slides.ImageFormat.JPEG

        back_image = None
        file_name = "BackImage_Slide_{0}{1}.{2}"
        is_layout = False

        if slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Getting the back picture  
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #Getting the back picture  
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            #Setting the desired picture format 
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

**元の画像を切り抜きやエフェクト、シェイプ変形なしで抽出できますか？**

はい。シェイプの画像にアクセスすると、プレゼンテーションの [image collection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) から画像オブジェクトを取得します。つまり、切り抜きやスタイリング効果を加えていない元のピクセルです。ワークフローはプレゼンテーションの画像コレクションと [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) オブジェクトを通過し、生データを保持しています。

**多数の画像を一度に保存すると、同一ファイルが重複して保存されるリスクはありますか？**

あります。プレゼンテーションの [image collection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) には、異なるシェイプやスライドから参照されている同一のバイナリデータが含まれることがあります。重複を防ぐには、書き込み前にハッシュ、サイズ、または抽出データの内容を比較してください。

**プレゼンテーションのコレクション内の特定の画像にリンクしているシェイプをどのように特定できますか？**

Aspose.Slides では [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) からシェイプへの逆リンクは保持されていません。走査中に手動でマッピングを構築してください。 [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) への参照が見つかったら、どのシェイプがそれを使用しているかを記録します。

**OLE オブジェクト（添付ドキュメントなど）に埋め込まれた画像を抽出できますか？**

直接はできません。OLE オブジェクトはコンテナであるため、まず OLE パッケージ自体を抽出し、別途ツールで内容を解析する必要があります。プレゼンテーションの画像シェイプは [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) を介して機能しますが、OLE は別のオブジェクトタイプです。