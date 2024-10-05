---
title: PowerPointをPNGに変換
type: docs
weight: 30
url: /python-net/convert-powerpoint-to-png/
keywords: PowerPointをPNGに, PPTをPNGに, PPTXをPNGに, Python, Aspose.Slides for Python via .NET
description: PowerPointプレゼンテーションをPNGに変換
---

## **PowerPointからPNGへの変換について**

PNG（ポータブルネットワークグラフィックス）形式はJPEG（ジョイントフォトグラフィックエクスパーツグループ）ほど普及していませんが、依然として非常に人気があります。

**使用例:** 複雑な画像を持っていて、サイズが問題でない場合、PNGはJPEGよりも優れた画像形式です。

{{% alert title="ヒント" color="primary" %}} Asposeの無料の**PowerPointからPNGコンバータ**をチェックしてみてください: [PPTXをPNGに](https://products.aspose.app/slides/conversion/pptx-to-png) と [PPTをPNGに](https://products.aspose.app/slides/conversion/ppt-to-png)。これはこのページに記載されたプロセスの実装です。 {{% /alert %}}

## **PowerPointをPNGに変換**

次の手順に従います:

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスをインスタンス化します。
2. [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)インターフェースの下にある[Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)コレクションからスライドオブジェクトを取得します。
3. [ISlide.GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)メソッドを使用して、各スライドのサムネイルを取得します。
4. [IPresentation.SaveMethod(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)メソッドを使用して、スライドサムネイルをPNG形式で保存します。

このPythonコードは、PowerPointプレゼンテーションをPNGに変換する方法を示しています:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image() as image:
        image.save("slide_{i}.png".format(i = index), slides.ImageFormat.PNG)
```

## **カスタム寸法でPowerPointをPNGに変換**

特定のスケールに合わせたPNGファイルを取得したい場合は、結果のサムネイルの寸法を決定する`desiredX`と`desiredY`の値を設定できます。

このPythonコードは、説明した操作を示しています:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

scaleX = 2
scaleY = 2
for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(scaleX, scaleY) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```

## **カスタムサイズでPowerPointをPNGに変換**

特定のサイズに合わせたPNGファイルを取得したい場合は、`ImageSize`のために好みの`width`と`height`の引数を渡すことができます。

このコードは、画像のサイズを指定しながらPowerPointをPNGに変換する方法を示しています:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

size = drawing.Size(960, 720)

for index in range(pres.slides.length):
    slide = pres.slides[index]
    with slide.get_image(size) as image:
        image.save("slide_{index}.png".format(index=index), slides.ImageFormat.PNG)
```