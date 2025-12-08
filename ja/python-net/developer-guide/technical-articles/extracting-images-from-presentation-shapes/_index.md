---
title: Python でプレゼンテーションのシェイプから画像を抽出する
linktitle: シェイプからの画像
type: docs
weight: 90
url: /ja/python-net/extracting-images-from-presentation-shapes/
keywords:
- 画像抽出
- 画像取得
- スライドの背景
- シェイプの背景
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint および OpenDocument プレゼンテーションのシェイプから画像を抽出します — 手軽でコードフレンドリーなソリューションです。"
---

## **シェイプから画像を抽出する**

{{% alert color="primary" %}} 

画像はしばしばシェイプに追加され、スライドの背景としても頻繁に使用されます。画像オブジェクトは[IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/)を介して追加され、[IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)オブジェクトのコレクションです。 

このページでは、プレゼンテーションに追加された画像を抽出する方法を説明します。 

{{% /alert %}} 

プレゼンテーションから画像を抽出するには、まずすべてのスライドを走査し、次にすべてのシェイプを走査して画像を見つける必要があります。画像が見つかったら、抽出して新しいファイルとして保存できます。 XXX 
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
            #背景画像を取得  
            back_image = slide.background.fill_format.picture_fill_format.picture.image
        elif slide.layout_slide.background.fill_format.fill_type == slides.FillType.PICTURE:
            #背景画像を取得  
            back_image = slide.layout_slide.background.fill_format.picture_fill_format.picture.image
            is_layout = True

        if back_image is not None:
            #希望する画像形式を設定 
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

**Can I extract the original image without any cropping, effects, or shape transformations?**

はい。シェイプの画像にアクセスすると、プレゼンテーションの[image collection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/)から画像オブジェクトが取得されます。つまり、切り抜きやスタイル効果のない元のピクセルが得られます。ワークフローはプレゼンテーションの画像コレクションと[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)オブジェクトを通過し、元データを保持しています。

**Is there a risk of duplicating identical files when saving many images at once?**

はい、無差別に保存すると重複する可能性があります。プレゼンテーションの[image collection](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/)には、異なるシェイプやスライドから参照されている同一のバイナリデータが含まれることがあります。重複を防ぐために、書き出す前にハッシュ、サイズ、または抽出データの内容を比較してください。

**How can I determine which shapes are linked to a specific image from the presentation’s collection?**

Aspose.Slides は[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)からシェイプへの逆リンクを保持していません。走査中に手動でマッピングを作成してください。つまり、[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)への参照が見つかったときに、どのシェイプがそれを使用しているかを記録します。

**Can I extract images embedded inside OLE objects, such as attached documents?**

直接はできません。OLE オブジェクトはコンテナであり、まず OLE パッケージ自体を抽出し、別のツールで内容を解析する必要があります。プレゼンテーションの画像シェイプは[PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/)を介して機能し、OLE は別のオブジェクトタイプです。