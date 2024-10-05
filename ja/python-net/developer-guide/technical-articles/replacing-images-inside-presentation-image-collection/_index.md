---
title: プレゼンテーション画像コレクション内の画像を置き換える
type: docs
weight: 110
url: /python-net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for Python via .NETは、スライドシェイプに追加された画像を置き換えることを可能にします。この記事では、さまざまなアプローチを使用してプレゼンテーション画像コレクションに追加された画像を置き換える方法について説明します。

{{% /alert %}} 
## **プレゼンテーション画像コレクション内の画像の置き換え**
Aspose.Slides for Python via .NETは、プレゼンテーション画像コレクション内の画像を置き換えるためのシンプルなAPIメソッドを提供します。以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスを使用して、画像が含まれたプレゼンテーションファイルをロードします。
1. バイト配列内のファイルから画像をロードします。
1. ターゲット画像を新しい画像のバイト配列で置き換えます。
1. 2番目のアプローチでは、Imageオブジェクトに画像をロードし、ターゲット画像をロードした画像で置き換えます。
1. 3番目のアプローチでは、すでに追加された画像でプレゼンテーション画像コレクション内の画像を置き換えます。
1. 修正したプレゼンテーションをPPTXファイルとして保存します。

```py
import aspose.slides as slides

def read_all_bytes(file_name):
    with open(file_name, "rb") as stream:
        return stream.read()

#プレゼンテーションをインスタンス化
with slides.Presentation("pres.pptx") as presentation:

    #最初の方法
    data = read_all_bytes("image_0.jpeg")
    oldImage = presentation.images[0]
    oldImage.replace_image(data)

    #2番目の方法
    newImage = slides.Images.from_file("image_1.jpeg")
    oldImage = presentation.images[1]
    oldImage.replace_image(newImage)

    #3番目の方法
    oldImage = presentation.images[2]
    oldImage.replace_image(presentation.images[3])

    #プレゼンテーションを保存
    presentation.save("replace_image-out.pptx", slides.export.SaveFormat.PPTX)
```