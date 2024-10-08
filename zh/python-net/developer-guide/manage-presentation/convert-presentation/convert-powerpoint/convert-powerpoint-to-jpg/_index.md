---
title: 在 Python 中将 PowerPoint PPT 转换为 JPG
linktitle: 在 Python 中将 PowerPoint PPT 转换为 JPG
type: docs
weight: 60
url: /python-net/convert-powerpoint-to-jpg/
keywords: "python ppt 转换为图像, 转换 PowerPoint 演示文稿, JPG, JPEG, PowerPoint 转换为 JPG, PowerPoint 转换为 JPEG, PPT 转换为 JPG, PPTX 转换为 JPG, PPT 转换为 JPEG, PPTX 转换为 JPEG, Python, Aspose.Slides"
description: "在 Python 中将 PowerPoint 转换为 JPG。将幻灯片保存为 JPG 图像"
---

## **关于 PowerPoint 转 JPG 转换**
使用 [**Aspose.Slides .NET API**](https://products.aspose.com/slides/python-net/) ，您可以在 Python 中将 PowerPoint PPT 或 PPTX 演示文稿转换为 JPG 图像。还可以在 Python 中将 PPT/PPTX 转换为 BMP、PNG 或 SVG。通过这些功能，您可以轻松实现自己的演示文稿查看器，为每个幻灯片创建缩略图。如果您想保护演示文稿幻灯片免于版权，或以只读模式展示演示文稿，这可能会很有用。Aspose.Slides 允许将整个演示文稿或特定幻灯片转换为图像格式。

{{% alert color="primary" %}} 

要查看 Aspose.Slides 如何将 PowerPoint 转换为 JPG 图像，您可能想尝试这些免费在线转换器：PowerPoint [PPTX 转 JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) 和 [PPT 转 JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg)。 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **将 PowerPoint PPT/PPTX 转换为 JPG**
以下是将 PPT/PPTX 转换为 JPG 的步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 从 [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 集合中获取 [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 类型的幻灯片对象。
3. 创建每个幻灯片的缩略图，然后将其转换为 JPG。使用 [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 方法获取幻灯片的缩略图，它返回 [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) 对象作为结果。 [GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 方法必须从所需的 [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 类型的幻灯片调用，缩略图的缩放比例传递到该方法中。
4. 获取幻灯片缩略图后，从缩略图对象调用 [**IImage.Save(string filename, ImageFormat format)**](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) 方法。将生成的文件名和图像格式传递给它。 

{{% alert color="primary" %}} 
**注意**：PPT/PPTX 转 JPG 转换与 Aspose.Slides .NET API 中的其他类型转换不同。对于其他类型，您通常使用 [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) 方法，但在这里您需要 [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8) 方法。
{{% /alert %}} 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for sld in pres.slides:
    with sld.get_image(1, 1) as bmp:
        bmp.save("Slide_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

## **使用自定义尺寸将 PowerPoint PPT/PPTX 转换为 JPG**
要更改生成的缩略图和 JPG 图像的尺寸，您可以通过将 *ScaleX* 和 *ScaleY* 值传递给 [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) 方法来设置它们：

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

{{% alert title="提示" color="primary" %}}

Aspose 提供了一个 [免费拼贴网页应用](https://products.aspose.app/slides/collage)。使用此在线服务，您可以合并 [JPG 到 JPG](https://products.aspose.app/slides/collage/jpg) 或 PNG 到 PNG 图像，创建 [照片网格](https://products.aspose.app/slides/collage/photo-grid) 等。

利用本文中描述的相同原理，您可以将图像从一种格式转换为另一种格式。有关更多信息，请查看以下页面：转换 [图像到 JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/); 转换 [JPG 到图像](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/); 转换 [JPG 到 PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)，转换 [PNG 到 JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/); 转换 [PNG 到 SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)，转换 [SVG 到 PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)。

{{% /alert %}}

## **另请参见**

查看将 PPT/PPTX 转换为图像的其他选项，例如：

- [PPT/PPTX 转 SVG 转换](/slides/python-net/render-a-slide-as-an-svg-image/)。