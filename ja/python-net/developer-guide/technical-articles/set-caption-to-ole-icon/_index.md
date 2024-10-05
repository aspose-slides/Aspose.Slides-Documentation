---
title: OLEアイコンにキャプションを設定
type: docs
weight: 160
url: /python-net/set-caption-to-ole-icon/
---

新しいプロパティ **SubstitutePictureTitle** が **IOleObjectFrame** インターフェイスと **OleObjectFrame** クラスに追加されました。これにより、OLEアイコンのキャプションを取得、設定、または変更することができます。以下のコードスニペットは、Excelオブジェクトを作成し、そのキャプションを設定するサンプルを示しています。

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # スライドにOLEオブジェクトを追加
    with open("oleSourceFile.xlsx", "rb") as ole_stream:
        data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.read(), "xlsx")

    ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

    # プレゼンテーションの画像コレクションに画像を追加
    with slides.Images.from_file("oleIconFile.ico") as image:
        pp_image = presentation.images.add_image(image)

    # OLEオブジェクトのアイコンとして画像を設定
    ole_frame.is_object_icon = True
    ole_frame.substitute_picture_format.picture.image = pp_image

    # OLEアイコンにキャプションを設定
    ole_frame.substitute_picture_title = "キャプションの例"
```