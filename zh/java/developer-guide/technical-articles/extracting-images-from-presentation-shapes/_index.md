---
title: 从演示文稿形状中提取图像
linktitle: 形状中的图像
type: docs
weight: 100
url: /zh/java/extracting-images-from-presentation-shapes/
keywords:
- 提取图像
- 检索图像
- 幻灯片背景
- 形状背景
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 从 PowerPoint 和 OpenDocument 演示文稿的形状中提取图像 —— 快速、代码友好的解决方案。"
---

## **从形状中提取图像**

{{% alert color="primary" %}} 

图像通常会添加到形状中，也经常用作幻灯片的背景。图像对象是通过[IImageCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/)添加的，它是[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)对象的集合。 

本文说明如何提取添加到演示文稿中的图像。 

{{% /alert %}} 

要从演示文稿中提取图像，必须先遍历每个幻灯片，再遍历每个形状来定位图像。找到或识别图像后，就可以提取并将其保存为新文件。 
```java
    public void extractImages()
    {
        Presentation pres = new Presentation(folderPath + "ExtractImages.pptx");
        com.aspose.slides.IPPImage img = null;
        com.aspose.slides.IPPImage backImage = null;

        int slideIndex = 0;
        String imageType = "";
        boolean ifImageFound = false;
        for (int i = 0; i < pres.getSlides().size(); i++)
        {

            slideIndex++;
            //访问第一张幻灯片
            ISlide sl = pres.getSlides().get_Item(i);


            //访问第一张幻灯片 Slide sl = pres.getSlideByPosition(i);
            if (sl.getBackground().getFillFormat().getFillType() == FillType.Picture)
            {
                //获取背景图片
                backImage = sl.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                imageType = getImageTType(backImage);

                String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "." + imageType;
                //保存图片
                backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
            } else
            {
                if (sl.getLayoutSlide().getBackground().getFillFormat().getFillType() == FillType.Picture)
                {
                    //获取背景图片
                    backImage = sl.getLayoutSlide().getBackground().getFillFormat().getPictureFillFormat().getPicture().getImage();
                    imageType = getImageTType(backImage);

                    String imagePath = folderPath + "backImage_" + "LayoutSlide_" + slideIndex + "." + imageType;
                    //保存图片
                    backImage.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
            }

            for (int j = 0; j < sl.getShapes().size(); j++)
            {
                // 访问包含图像的形状
                IShape sh = sl.getShapes().get_Item(j);

                if (sh instanceof IAutoShape)
                {
                    IAutoShape ashp = (IAutoShape) sh;
                    if (ashp.getFillFormat().getFillType() == FillType.Picture)
                    {
                        img = ashp.getFillFormat().getPictureFillFormat().getPicture().getImage();
                        imageType = getImageTType(img);
                        ifImageFound = true;
                    }
                } else if (sh instanceof IPictureFrame)
                {
                    IPictureFrame pf = (IPictureFrame) sh;
                    img = pf.getPictureFormat().getPicture().getImage();
                    imageType = getImageTType(img);
                    ifImageFound = true;
                }

                //设置首选图像格式
                if (ifImageFound)
                {
                    String imagePath = folderPath + "backImage_" + "Slide_" + slideIndex + "_Shape_" + j + "." + imageType;
                    //保存图片
                    img.getImage().save(imagePath, (int) ImageFormat.getValue(ImageFormat.class, capitalize(imageType)));
                }
                ifImageFound = false;
            }
        }
    }

    private String getImageTType(IPPImage image)
    {
        String imageContentType = image.getContentType();
        imageContentType = imageContentType.substring(imageContentType.indexOf("/") + 1);
        imageContentType = imageContentType.substring(imageContentType.indexOf("-") + 1);
        return imageContentType;
    }

    private String capitalize(String str)
    {
        if (str == null || str.length() <= 1) return str;
        return str.substring(0, 1).toUpperCase() + str.substring(1);
    }
```


## **常见问题**

**我可以在不进行裁剪、特效或形状转换的情况下提取原始图像吗？**

是的。当您访问形状的图像时，会从演示文稿的[image collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--)获取图像对象，也即是未经过裁剪或样式效果的原始像素。工作流会遍历演示文稿的图像集合以及[PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/)对象，这些对象存储原始数据。

**一次性保存大量图像时是否有重复相同文件的风险？**

是的，如果不加区分地保存所有图像。演示文稿的[image collection](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--)可能包含由不同形状或幻灯片引用的相同二进制数据。为避免重复，写入之前请比较提取数据的哈希值、大小或内容。

**如何确定演示文稿集合中哪些形状链接到特定图像？**

Aspose.Slides 不会存储从[PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/)到形状的反向链接。请在遍历过程中手动构建映射：每当发现对[PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/)的引用时，记录使用该图像的形状。

**我可以提取嵌入在 OLE 对象（如附件文档）中的图像吗？**

不能直接提取，因为 OLE 对象是一个容器。需要先提取 OLE 包本身，然后使用其他工具分析其内容。演示文稿的图片形状通过[PPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ppimage/)工作；OLE 是不同的对象类型。