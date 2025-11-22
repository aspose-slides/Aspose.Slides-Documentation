---
title: 从演示文稿形状中提取图像
type: docs
weight: 90
url: /zh/net/extracting-images-from-presentation-shapes/
keywords: "提取图像, PowerPoint, PPT, PPTX, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中从 PowerPoint 演示文稿提取图像"
---

## **从形状提取图像**

{{% alert color="primary" %}} 

图像通常会添加到形状中，且常用作幻灯片的背景。图像对象通过[IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/) 添加，该集合是[IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) 对象的集合。 

本文阐述了如何提取添加到演示文稿中的图像。 

{{% /alert %}} 

要从演示文稿中提取图像，必须先遍历每一张幻灯片，再遍历每个形状来定位图像。找到或识别出图像后，即可提取并将其保存为新文件。 XXX 
```c#
public static void Run() {

    String path = @"D:\Aspose Data\";
    // 访问演示文稿
    Presentation pres = new Presentation(path + "ExtractImages.pptx");
    Aspose.Slides.IPPImage img = null;
    Aspose.Slides.IPPImage Backimg = null;

    int slideIndex = 0;
    String ImageType = "";
    bool ifImageFound = false;
    for (int i = 0; i < pres.Slides.Count; i++)
    {

        slideIndex++;
        // 访问第一张幻灯片
        ISlide sl = pres.Slides[i];
        System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;

        // 访问第一张幻灯片 Slide sl = pres.getSlideByPosition(i);
        if (sl.Background.FillFormat.FillType == FillType.Picture)
        {
            // 获取背景图像
            Backimg = sl.Background.FillFormat.PictureFillFormat.Picture.Image;

            // 设置首选图像格式

            ImageType = Backimg.ContentType;
            ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
            Format = GetImageFormat(ImageType);

            String ImagePath = path + "BackImage_";
            Backimg.SystemImage.Save(ImagePath + "Slide_" + slideIndex.ToString() + "." + ImageType, Format);

        }
        else
        {
            if (sl.LayoutSlide.Background.FillFormat.FillType == FillType.Picture)
            {
                // 获取背景图像
                Backimg = sl.LayoutSlide.Background.FillFormat.PictureFillFormat.Picture.Image;

                // 设置首选图像格式

                ImageType = Backimg.ContentType;
                ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                Format = GetImageFormat(ImageType);

                String ImagePath = path + "BackImage_Slide_" + i;
                Backimg.SystemImage.Save(ImagePath + "LayoutSlide_" + slideIndex.ToString() + "." + ImageType, Format);

            }
        }

        for (int j = 0; j < sl.Shapes.Count; j++)
        {
            // 访问包含图像的形状
            IShape sh = sl.Shapes[j];

            if (sh is AutoShape)
            {
                AutoShape ashp = (AutoShape)sh;
                if (ashp.FillFormat.FillType == FillType.Picture)
                {
                    img = ashp.FillFormat.PictureFillFormat.Picture.Image;
                    ImageType = img.ContentType;
                    ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                    ifImageFound = true;

                }
            }

            else if (sh is PictureFrame)
            {
                IPictureFrame pf = (IPictureFrame)sh;
                if (pf.FillFormat.FillType == FillType.Picture)
                {
                    img = pf.PictureFormat.Picture.Image;
                    ImageType = img.ContentType;
                    ImageType = ImageType.Remove(0, ImageType.IndexOf("/") + 1);
                    ifImageFound = true;
                }
            }

            // 设置提取图像的首选格式
            if (ifImageFound)
            {
                Format = GetImageFormat(ImageType);
                String ImagePath = path + "Slides\\Image_";
                img.SystemImage.Save(ImagePath + "Slide_" + slideIndex.ToString() + "_Shape_" + j.ToString() + "." + ImageType, Format);
            }
            ifImageFound = false;
        }
    }
}

public static System.Drawing.Imaging.ImageFormat GetImageFormat(String ImageType)
{
    System.Drawing.Imaging.ImageFormat Format = System.Drawing.Imaging.ImageFormat.Jpeg;
    switch (ImageType)
    {
        case "jpeg":
            Format = System.Drawing.Imaging.ImageFormat.Jpeg;
            break;

        case "emf":
            Format = System.Drawing.Imaging.ImageFormat.Emf;
            break;

        case "bmp":
            Format = System.Drawing.Imaging.ImageFormat.Bmp;
            break;

        case "png":
            Format = System.Drawing.Imaging.ImageFormat.Png;
            break;

        case "wmf":
            Format = System.Drawing.Imaging.ImageFormat.Wmf;
            break;

        case "gif":
            Format = System.Drawing.Imaging.ImageFormat.Gif;
            break;

    }
    return Format;
}
```


## **常见问题**

**我能提取原始图像而不进行任何裁剪、效果或形状转换吗？**

是的。当您访问形状的图像时，获取的是演示文稿的[image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/) 中的图像对象，这意味着得到的是未裁剪或未加入样式效果的原始像素。工作流会遍历演示文稿的图像集合以及[PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) 对象，这些对象存储原始数据。

**一次保存大量图像时是否有重复相同文件的风险？**

有。如果不加区分地全部保存，可能会出现重复。演示文稿的[image collection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/) 中可能包含相同的二进制数据，只是被不同的形状或幻灯片引用。为避免重复，写入前应比较哈希值、大小或提取数据的内容。

**如何确定哪些形状与演示文稿集合中的特定图像关联？**

Aspose.Slides 不会从[PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) 到形状建立反向链接。您需要在遍历过程中手动构建映射：每当发现对某个[PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) 的引用时，记录使用该图像的形状。

**我能提取嵌入在 OLE 对象（如附件文档）中的图像吗？**

不能直接提取，因为 OLE 对象本身是一个容器。需要先提取 OLE 包本身，然后使用其他工具分析其内容。演示文稿的图片形状通过[PPImage](https://reference.aspose.com/slides/net/aspose.slides/ppimage/) 工作，而 OLE 是不同的对象类型。