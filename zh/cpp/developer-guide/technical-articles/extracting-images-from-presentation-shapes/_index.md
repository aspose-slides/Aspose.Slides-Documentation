---
title: 从演示文稿形状中提取图像
linktitle: 形状中的图像
type: docs
weight: 90
url: /zh/cpp/extracting-images-from-presentation-shapes/
keywords:
- 提取图像
- 检索图像
- 幻灯片背景
- 形状背景
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 从 PowerPoint 和 OpenDocument 演示文稿的形状中提取图像 —— 快速、代码友好的解决方案。"
---

## **从形状提取图像**

{{% alert color="primary" %}} 

图像通常会添加到形状中，也常用作幻灯片的背景。图像对象是通过[IImageCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) 添加的，它是[IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/)对象的集合。 

本文说明如何提取添加到演示文稿中的图像。 

{{% /alert %}} 

要从演示文稿中提取图像，必须先遍历每个幻灯片，然后遍历每个形状以定位图像。找到或识别到图像后，可将其提取并保存为新文件。 
``` cpp
void Run()
{
    System::String path = u"D:\\Aspose Data\\";
    //访问演示文稿
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(path + u"ExtractImages.pptx");
    System::SharedPtr<Aspose::Slides::IPPImage> img;
    System::SharedPtr<Aspose::Slides::IPPImage> Backimg;

    int32_t slideIndex = 0;
    System::String ImageType = u"";
    bool ifImageFound = false;
    for (int32_t i = 0; i < pres->get_Slides()->get_Count(); i++)
    {
        slideIndex++;
        //访问第一张幻灯片
        System::SharedPtr<ISlide> sl = pres->get_Slides()->idx_get(i);
        System::SharedPtr<System::Drawing::Imaging::ImageFormat> Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();

        if (sl->get_Background()->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
        {
            //获取背景图片  
            Backimg = sl->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();

            //设置所需的图片格式
            ImageType = Backimg->get_ContentType();
            ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
            Format = GetImageFormat(ImageType);

            System::String ImagePath = path + u"BackImage_";
            Backimg->get_SystemImage()->Save(ImagePath + u"Slide_" + System::Convert::ToString(slideIndex) + u"." + ImageType, Format);
        }
        else
        {
            if (sl->get_LayoutSlide()->get_Background()->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
            {
                //获取背景图片  
                Backimg = sl->get_LayoutSlide()->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();

                //设置所需的图片格式 
                ImageType = Backimg->get_ContentType();
                ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                Format = GetImageFormat(ImageType);

                System::String ImagePath = path + u"BackImage_Slide_" + i;
                Backimg->get_SystemImage()->Save(ImagePath + u"LayoutSlide_" + System::Convert::ToString(slideIndex) + u"." + ImageType, Format);
            }
        }

        for (int32_t j = 0; j < sl->get_Shapes()->get_Count(); j++)
        {
            //访问包含图像的形状
            System::SharedPtr<IShape> sh = sl->get_Shapes()->idx_get(j);

            if (System::ObjectExt::Is<AutoShape>(sh))
            {
                System::SharedPtr<AutoShape> ashp = System::ExplicitCast<Aspose::Slides::AutoShape>(sh);
                if (ashp->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
                {
                    img = ashp->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_Image();
                    ImageType = img->get_ContentType();
                    ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                    ifImageFound = true;

                }
            }
            else if (System::ObjectExt::Is<PictureFrame>(sh))
            {
                System::SharedPtr<IPictureFrame> pf = System::ExplicitCast<Aspose::Slides::IPictureFrame>(sh);
                if (pf->get_FillFormat()->get_FillType() == Aspose::Slides::FillType::Picture)
                {
                    img = pf->get_PictureFormat()->get_Picture()->get_Image();
                    ImageType = img->get_ContentType();
                    ImageType = ImageType.Remove(0, ImageType.IndexOf(u"/") + 1);
                    ifImageFound = true;
                }
            }

            //设置首选的图像格式
            if (ifImageFound)
            {
                Format = GetImageFormat(ImageType);
                System::String ImagePath = path + u"Slides\\Image_";
                img->get_SystemImage()->Save(ImagePath + u"Slide_" + System::Convert::ToString(slideIndex) + u"_Shape_" + System::Convert::ToString(j) + u"." + ImageType, Format);
            }

            ifImageFound = false;
        }
    }
}

System::SharedPtr<System::Drawing::Imaging::ImageFormat> GetImageFormat(System::String ImageType)
{
    System::SharedPtr<System::Drawing::Imaging::ImageFormat> Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();
    {
        const System::String& switch_value_0 = ImageType;
        do {
            if (switch_value_0 == u"jpeg")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Jpeg();
                break;
            }
            if (switch_value_0 == u"emf")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Emf();
                break;
            }
            if (switch_value_0 == u"bmp")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Bmp();
                break;
            }
            if (switch_value_0 == u"png")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Png();
                break;
            }
            if (switch_value_0 == u"wmf")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Wmf();
                break;
            }
            if (switch_value_0 == u"gif")
            {
                Format = System::Drawing::Imaging::ImageFormat::get_Gif();
                break;
            }
        } while (false);
    }

    return Format;
}
```


## **常见问题**

**可以在不进行任何裁剪、效果或形状转换的情况下提取原始图像吗？**

是的。当您访问形状的图像时，会从演示文稿的[图像集合](https://reference.aspose.com/slides/cpp/aspose.slides/imagecollection/)获取图像对象，这意味着获取的是未裁剪或未应用样式效果的原始像素。工作流会遍历演示文稿的图像集合和[PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/)对象，这些对象存储原始数据。

**一次性保存大量图像时是否有复制相同文件的风险？**

是的，如果不加区分地全部保存的话。演示文稿的[图像集合](https://reference.aspose.com/slides/cpp/aspose.slides/imagecollection/)可能包含由不同形状或幻灯片引用的相同二进制数据。为避免重复，在写入之前请比较提取数据的哈希值、大小或内容。

**如何确定演示文稿集合中哪些形状链接到特定图像？**

Aspose.Slides 不会存储从[PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/)到形状的反向链接。遍历时手动构建映射：每当找到对[PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/)的引用时，记录使用该图像的形状。

**我可以提取嵌入在 OLE 对象（如附件文档）中的图像吗？**

不能直接提取，因为 OLE 对象是一个容器。需要先提取 OLE 包本身，然后使用其他工具分析其内容。演示文稿的图片形状通过[PPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ppimage/)工作；OLE 则是另一种对象类型。