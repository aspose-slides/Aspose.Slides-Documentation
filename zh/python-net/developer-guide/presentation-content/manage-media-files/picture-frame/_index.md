---
title: 图片框
type: docs
weight: 10
url: /zh/python-net/picture-frame/
keywords: "添加图片框, 创建图片框, 添加图像, 创建图像, 提取图像, StretchOff 属性, 图片框格式, 图片框属性, PowerPoint 演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在Python中向PowerPoint演示文稿添加图片框"
---

图片框是一种包含图像的形状——就像是框中的一张图片。

您可以通过图片框向幻灯片添加图像。通过这种方式，您可以通过格式化图片框来格式化图像。

{{% alert  title="提示" color="primary" %}} 

Aspose 提供免费的转换器——[JPEG 转 PowerPoint](https://products.aspose.app/slides/import/jpg-to-ppt) 和 [PNG 转 PowerPoint](https://products.aspose.app/slides/import/png-to-ppt)——允许人们快速从图像创建演示文稿。 

{{% /alert %}} 

## **创建图片框**

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。 
2. 通过索引获取幻灯片的引用。 
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) 添加图像，创建 [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) 对象，以填充该形状。
4. 指定图像的宽度和高度。
5. 通过与引用幻灯片关联的形状对象暴露的 `AddPictureFrame` 方法，基于图像的宽度和高度创建 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/)。
6. 将包含图片的图片框添加到幻灯片。
7. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码向您展示如何创建一个图片框：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    # 实例化 ImageEx 类
    with open("img.jpeg", "rb") as in_file:
        image = pres.images.add_image(in_file)

        # 添加与图片等效高度和宽度的框架
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, image.width, image.height, image)

        # 对 PictureFrameEx 应用一些格式
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

        # 将 PPTX 文件写入磁盘
        pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" %}} 

图片框允许您快速基于图像创建演示幻灯片。当您将图片框与 Aspose.Slides 的保存选项结合使用时，您可以操纵输入/输出操作以将图像从一种格式转换为另一种格式。您可能希望查看这些页面：将 [图像转换为 JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/)；将 [JPG 转图像](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/)；将 [JPG 转 PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/)，将 [PNG 转 JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/)；将 [PNG 转 SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/)，将 [SVG 转 PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/)。

{{% /alert %}}

## **创建相对缩放的图片框**

通过更改图像的相对缩放，您可以创建更复杂的图片框。 

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 向演示文稿图像集合添加图像。
4. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) 添加图像，创建 [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage/) 对象。
5. 在图片框中指定图像的相对宽度和高度。
6. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码向您展示如何创建一个相对缩放的图片框：

```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation() as presentation:
    # 加载将添加到演示文稿图像集合的图像
    with open("img.jpeg", "rb") as in_file:
        image = presentation.images.add_image(in_file)

        # 向幻灯片添加图片框
        pf = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

        # 设置相对缩放宽度和高度
        pf.relative_scale_height = 0.8
        pf.relative_scale_width = 1.35

        # 保存演示文稿
        presentation.save("Adding Picture Frame with Relative Scale_out.pptx", slides.export.SaveFormat.PPTX)
```

## **从图片框中提取图像**

您可以从 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 对象中提取图像并将其保存为 PNG、JPG 和其他格式。下面的代码示例演示如何从文档 "sample.pptx" 中提取图像并保存为 PNG 格式。

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    first_slide = presentation.slides[0]
    first_shape = first_slide.shapes[0]

    if isinstance(first_shape, slides.PictureFrame):
        image = first_shape.picture_format.picture.image.image
        image.save("slide_1_shape_1.png", slides.ImageFormat.PNG)
```

## **获取图像的透明度**

Aspose.Slides 允许您获取图像的透明度。以下 Python 代码演示了该操作： 

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    pictureFrame = presentation.slides[0].shapes[0]
    imageTransform = pictureFrame.picture_format.picture.image_transform
    for effect in imageTransform:
        if type(effect) is slides.AlphaModulateFixed:
            transparencyValue = 100 - effect.amount
            print("图片透明度: " + str(transparencyValue))
```

## **图片框格式化**

Aspose.Slides 提供了许多可以应用于图片框的格式选项。使用这些选项，您可以修改图片框以满足特定要求。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) 类的实例。
2. 通过索引获取幻灯片的引用。 
3. 通过向与演示文稿对象关联的 [IImagescollection](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) 添加图像，创建 [IPPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ippimage) 对象。
4. 指定图像的宽度和高度。
5. 通过与引用幻灯片关联的 [IShapes](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection) 对象暴露的 [AddPictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/ishapecollection/) 方法，基于图像的宽度和高度创建 `PictureFrame`。
6. 将图片框（包含图片）添加到幻灯片。
7. 设置图片框的线条颜色。
8. 设置图片框的线条宽度。
9. 通过给予其正值或负值来旋转图片框。
   * 正值使图像顺时针旋转。
   * 负值使图像逆时针旋转。
10. 将图片框（包含图片）添加到幻灯片。
11. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码演示了图片框格式化过程：

```py
import aspose.slides as slides
import aspose.pydrawing as draw

# 实例化表示 PPTX 文件的 Presentation 类
with slides.Presentation() as pres:
    # 获取第一张幻灯片
    sld = pres.slides[0]

    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

         # 添加与图片等效高度和宽度的图片框
        pf = sld.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 150, imgx.width, imgx.height, imgx)

        # 对 PictureFrameEx 应用一些格式
        pf.line_format.fill_format.fill_type = slides.FillType.SOLID
        pf.line_format.fill_format.solid_fill_color.color = draw.Color.blue
        pf.line_format.width = 20
        pf.rotation = 45

    # 将 PPTX 文件写入磁盘
    pres.save("RectPicFrameFormat_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="提示" color="primary" %}}

Aspose 最近开发了一个 [免费拼贴生成器](https://products.aspose.app/slides/collage)。如果您需要 [合并 JPG/JPEG](https://products.aspose.app/slides/collage/jpg) 或 PNG 图像，或者 [从照片创建网格](https://products.aspose.app/slides/collage/photo-grid)，您可以使用此服务。

{{% /alert %}}

## **添加链接的图像**

为避免演示文稿文件大小过大，您可以通过链接添加图像（或视频），而不是将文件直接嵌入演示文稿。以下 Python 代码向您展示如何向占位符中添加图像和视频：

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapesToRemove = []

    for autoShape in presentation.slides[0].shapes:
        if autoShape.placeholder is None:
            continue
        
        if autoShape.placeholder.type == slides.PlaceholderType.PICTURE:
            pictureFrame = presentation.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE,
                    autoShape.x, autoShape.y, autoShape.width, autoShape.height, None)

            pictureFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            shapesToRemove.append(autoShape)

        elif autoShape.placeholder.type == slides.PlaceholderType.MEDIA:
            videoFrame = presentation.slides[0].shapes.add_video_frame(
                autoShape.X, autoShape.Y, autoShape.width, autoShape.height, "")

            videoFrame.picture_format.picture.link_path_long = \
                "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg"

            videoFrame.link_path_long = "https://youtu.be/t_1LYZ102RA"
            shapesToRemove.append(autoShape)

    for shape in shapesToRemove:
        presentation.slides[0].shapes.remove(shape)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **裁剪图像**

以下 Python 代码向您展示如何裁剪幻灯片上的现有图像：

``` py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # 创建新的图像对象
    newImage = presentation.images.add_image(slides.Images.from_file(imagePath))

    # 向幻灯片添加图片框
    picFrame = presentation.slides[0].shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE, 100, 100, 420, 250, newImage)

    # 裁剪图像（百分比值）
    picFrame.picture_format.crop_left = 23.6
    picFrame.picture_format.crop_right = 21.5
    picFrame.picture_format.crop_top = 3
    picFrame.picture_format.crop_bottom = 31

    # 保存结果
    presentation.save(outPptxFile, slides.export.SaveFormat.PPTX)

```

## 删除图片的裁剪区域

如果您想删除框中图像的裁剪区域，可以使用 [delete_picture_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/) 方法。该方法返回裁剪后的图像或原始图像（如果不需要裁剪）。

以下 Python 代码演示了该操作：

```python
import aspose.slides as slides

with slides.Presentation(path + "PictureFrameCrop.pptx") as pres:
    slide = pres.slides[0]

    # 获取第一张幻灯片中的 PictureFrame
    picture_frame = slides.shape[0]

    # 删除 PictureFrame 图像的裁剪区域并返回裁剪后的图像
    cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()

    # 保存结果
    pres.save(path + "PictureFrameDeleteCroppedAreas.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="注意" color="warning" %}} 

delete_picture_cropped_areas 方法将裁剪后的图像添加到演示文稿图像集合中。如果该图像仅在处理的 [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) 中使用，则此设置可以减小演示文稿的大小。否则，结果演示文稿中的图像数量将增加。

该方法在裁剪操作中将 WMF/EMF 元文件转换为光栅PNG图像。 

{{% /alert %}}

## **锁定纵横比**

如果您希望包含图像的形状在更改图像尺寸后保持其纵横比，可以使用 *aspect_ratio_locked* 属性来设置 *锁定纵横比* 设置。 

以下 Python 代码向您展示如何锁定形状的纵横比： 

```python
from aspose.slides import SlideLayoutType, Presentation, ShapeType
from aspose.pydrawing import Image

with Presentation("pres.pptx") as pres:
    layout = pres.layout_slides.get_by_type(SlideLayoutType.CUSTOM)
    emptySlide = pres.slides.add_empty_slide(layout)
    image = Image.from_file("image.png")
    presImage = pres.images.add_image(image)

    pictureFrame = emptySlide.shapes.add_picture_frame(ShapeType.RECTANGLE, 50, 150, presImage.width, presImage.height, presImage)

    # 设置形状在调整大小时保持纵横比
    pictureFrame.picture_frame_lock.aspect_ratio_locked = True
```

{{% alert title="注意" color="warning" %}} 

该 *锁定纵横比* 设置仅保留形状的纵横比，而不保留其包含的图像的纵横比。

{{% /alert %}}

## **使用 StretchOff 属性**

使用 [IPictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/ipicturefillformat/) 接口和 [PictureFillFormat](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) 类中的 `StretchOffsetLeft`、`StretchOffsetTop`、`StretchOffsetRight` 和 `StretchOffsetBottom` 属性，您可以指定填充矩形。 

当为图像指定拉伸时，源矩形按比例缩放以适应指定的填充矩形。填充矩形的每个边缘由自形状的边界框对应边缘的百分比偏移量定义。正百分比表示向内缩进，而负百分比表示向外扩展。

1. 创建 [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个矩形 `AutoShape`。 
4. 创建一张图像。
5. 设置形状的填充类型。
6. 设置形状的图片填充模式。
7. 添加设置的图像以填充该形状。
8. 指定图像从形状的边界框对应边缘的偏移量。
9. 将修改后的演示文稿写入 PPTX 文件。

以下 Python 代码演示了使用 StretchOff 属性的过程：

```py
import aspose.slides as slides

# 实例化表示 PPTX 文件的 Prseetation 类
with slides.Presentation() as pres:

    # 获取第一张幻灯片
    slide = pres.slides[0]

    # 实例化 ImageEx 类
    with open("img.jpeg", "rb") as in_file:
        imgx = pres.images.add_image(in_file)

        # 添加与图片等效高度和宽度的图片框
        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

        # 设置形状的填充类型
        shape.fill_format.fill_type = slides.FillType.PICTURE

        # 设置形状的图片填充模式
        shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH

        # 设置图像以填充该形状
        shape.fill_format.picture_fill_format.picture.image = imgx

        # 指定图像从形状的边界框对应边缘的偏移量
        shape.fill_format.picture_fill_format.stretch_offset_left = 25
        shape.fill_format.picture_fill_format.stretch_offset_right = 25
        shape.fill_format.picture_fill_format.stretch_offset_top = -20
        shape.fill_format.picture_fill_format.stretch_offset_bottom = -10
    
    # 将 PPTX 文件写入磁盘
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", slides.export.SaveFormat.PPTX)
```