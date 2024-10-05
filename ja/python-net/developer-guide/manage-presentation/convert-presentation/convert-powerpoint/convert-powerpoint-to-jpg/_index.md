---
title: PythonでPowerPoint PPTをJPGに変換
linktitle: PowerPoint PPTをJPGに変換
type: docs
weight: 60
url: /python-net/convert-powerpoint-to-jpg/
keywords: "python ppt to image, PowerPointプレゼンテーションの変換, JPG, JPEG, PowerPointからJPG, PowerPointからJPEG, PPTからJPG, PPTXからJPG, PPTからJPEG, PPTXからJPEG, Python, Aspose.Slides"
description: "PythonでPowerPointをJPGに変換します。スライドをJPG画像として保存します"
---

## **PowerPointからJPGへの変換について**
[**Aspose.Slides .NET API**](https://products.aspose.com/slides/python-net/)を使用すると、PythonでPowerPoint PPTまたはPPTXプレゼンテーションをJPG画像に変換できます。また、PythonでPPT/PPTXをBMP、PNG、またはSVGに変換することも可能です。この機能を利用すると、自分自身のプレゼンテーションビューワーを実装したり、各スライドのサムネイルを作成したりするのが簡単です。これは、プレゼンテーションスライドを著作権から保護したり、読み取り専用モードでプレゼンテーションを表示したりしたい場合に便利です。Aspose.Slidesは、プレゼンテーション全体または特定のスライドを画像形式に変換することを可能にします。

{{% alert color="primary" %}} 

Aspose.SlidesがPowerPointをJPG画像に変換する方法を確認するには、これらの無料オンラインコンバーターを試してみてください：PowerPoint [PPTX to JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) と [PPT to JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **PowerPoint PPT/PPTXをJPGに変換する**
PPT/PPTXをJPGに変換する手順は以下の通りです：

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成します。
2. [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) コレクションから [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) タイプのスライドオブジェクトを取得します。
3. 各スライドのサムネイルを作成し、それをJPGに変換します。[**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) メソッドを使用してスライドのサムネイルを取得し、結果として[IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/)オブジェクトを返します。[GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)メソッドは、必要なスライドの[ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)タイプから呼び出され、結果サムネイルのスケールがメソッドに渡されます。
4. スライドのサムネイルを取得した後、サムネイルオブジェクトから[**IImage.Save(string filename, ImageFormat format)**](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/)メソッドを呼び出します。結果のファイル名と画像形式を渡します。

{{% alert color="primary" %}} 
**注**：PPT/PPTXからJPGへの変換は、Aspose.Slides .NET APIでの他のタイプへの変換とは異なります。他のタイプでは通常、[**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)メソッドを使用しますが、ここでは[**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8)メソッドが必要です。
{{% /alert %}} 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for sld in pres.slides:
    with sld.get_image(1, 1) as bmp:
        bmp.save("Slide_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

## **カスタマイズされた寸法でPowerPoint PPT/PPTXをJPGに変換する**
結果のサムネイルとJPG画像の寸法を変更するには、[**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)メソッドに渡すことで*ScaleX*と*ScaleY*の値を設定できます：

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

desiredX = 1200
desiredY = 800
scaleX = (float)(1.0 / pres.slide_size.size.width) * desiredX
scaleY = (float)(1.0 / pres.slide_size.size.height) * desiredY

for sld in pres.slides:
    with sld.get_image(scaleX, scaleY) as bmp:
        bmp.save("Slide_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

{{% alert title="ヒント" color="primary" %}}

Asposeは[無料のコラージュWebアプリ](https://products.aspose.app/slides/collage)を提供しています。このオンラインサービスを使用すると、[JPG to JPG](https://products.aspose.app/slides/collage/jpg)やPNG to PNG画像の統合、[フォトグリッド](https://products.aspose.app/slides/collage/photo-grid)の作成などができます。 

この記事で説明したのと同様の原則を使用して、画像を別の形式に変換できます。詳細については、以下のページを参照してください：画像を[JPGに変換](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/)；[JPGを画像に変換](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/)；[JPGをPNGに変換](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)、[PNGをJPGに変換](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/)；[PNGをSVGに変換](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)、[SVGをPNGに変換](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)。

{{% /alert %}}

## **関連情報**

PPT/PPTXを画像に変換する他のオプションを参照してください：

- [PPT/PPTXからSVGへの変換](/slides/python-net/render-a-slide-as-an-svg-image/)。
