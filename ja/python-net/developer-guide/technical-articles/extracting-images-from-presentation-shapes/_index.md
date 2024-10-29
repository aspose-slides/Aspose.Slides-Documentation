---
title: プレゼンテーションの図形から画像を抽出する
type: docs
weight: 90
url: /ja/python-net/extracting-images-from-presentation-shapes/
keywords: "画像を抽出, PowerPoint, PPT, PPTX, PowerPointプレゼンテーション, Python, Aspose.Slides for Python"
description: "PythonでPowerPointプレゼンテーションから画像を抽出する"
---

{{% alert color="primary" %}} 

画像はしばしば図形に追加され、またスライドの背景としても頻繁に使用されます。画像オブジェクトは[IImageCollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/)を介して追加され、これは[IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/)オブジェクトのコレクションです。

この記事では、プレゼンテーションに追加された画像を抽出する方法について説明します。

{{% /alert %}} 

プレゼンテーションから画像を抽出するには、まずすべてのスライドを通過して画像を見つける必要があります。その後、すべての図形を通過します。画像が見つかるか識別されると、画像を抽出し、新しいファイルとして保存できます。XXX 

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
            #希望の画像形式を設定 
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