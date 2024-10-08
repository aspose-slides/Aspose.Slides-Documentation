---
title: 将布局幻灯片添加到演示文稿
type: docs
weight: 20
url: /net/add-layout-slides-to-presentation/
---

Aspose.Slides for .NET 允许开发人员在演示文稿中添加新的布局幻灯片。要添加布局幻灯片，请按照以下步骤操作：

- 创建一个 Presentation 类的实例
- 访问主幻灯片集合
- 尝试查找现有的布局幻灯片，以查看所需的布局滑块是否已经在布局幻灯片集合中
- 如果所需的布局不可用，请添加新的布局幻灯片
- 使用新添加的布局幻灯片添加空幻灯片
- 最后，使用 Presentation 对象写入演示文稿文件
## **示例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//实例化表示演示文稿文件的 Presentation 类

using (Presentation p = new Presentation(FileName))

{

    // 尝试按布局幻灯片类型进行搜索

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // 演示文稿不包含某种布局的情况。

        // Technographics.pptx 演示文稿仅包含空白和自定义布局类型。

        // 但是具有自定义类型的布局幻灯片具有不同的幻灯片名称，

        // 如“标题”，“标题和内容”等。可以使用这些

        // 名称进行布局幻灯片选择。

        // 还可以使用一组占位符形状类型。例如，

        // 标题幻灯片仅应具有标题占位符类型，等等。

        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)

        {

            if (titleAndObjectLayoutSlide.Name == "Title and Object")

            {

                layoutSlide = titleAndObjectLayoutSlide;

                break;

            }

        }

        if (layoutSlide == null)

        {

            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)

            {

                if (titleLayoutSlide.Name == "Title")

                {

                    layoutSlide = titleLayoutSlide;

                    break;

                }

            }

            if (layoutSlide == null)

            {

                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);

                if (layoutSlide == null)

                {

                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");

                }

            }

        }

    }

    //添加带有添加的布局幻灯片的空幻灯片 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //保存演示文稿    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **下载运行示例**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 

有关更多详细信息，请访问 [将布局幻灯片添加到演示文稿](/slides/net/adding-and-editing-slides/#working-with-slide-size-and-layout)。

{{% /alert %}}