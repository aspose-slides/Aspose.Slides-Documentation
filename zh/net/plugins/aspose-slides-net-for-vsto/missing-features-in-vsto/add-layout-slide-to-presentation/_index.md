---
title: 将布局幻灯片添加到演示文稿
type: docs
weight: 10
url: /zh/net/add-layout-slide-to-presentation/
---

Aspose.Slides for .NET 允许开发人员在演示文稿中添加新的布局幻灯片。要添加布局幻灯片，请按照以下步骤操作：

- 创建一个 Presentation 类的实例
- 访问母版幻灯片集合
- 尝试查找现有的布局幻灯片，以查看所需的布局幻灯片是否已经在布局幻灯片集合中
- 如果所需的布局不可用，则添加新的布局幻灯片
- 使用新添加的布局幻灯片添加一个空幻灯片
- 最后，使用 Presentation 对象写入演示文稿文件。
## **示例**
``` csharp

 // 实例化表示演示文稿文件的 Presentation 类

using (Presentation p = new Presentation("Test.pptx"))

{

   // 尝试按布局幻灯片类型进行搜索

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // 演示文稿不包含某些类型布局的情况。

     // Technographics.pptx 演示文稿仅包含空白和自定义布局类型。

     // 但具有自定义类型的布局幻灯片具有不同的幻灯片名称，

     // 比如“标题”、“标题和内容”等。可以使用这些

     // 名称进行布局幻灯片选择。

     // 还可以使用占位符形状类型的集合。例如，

     // 标题幻灯片应仅具有标题占位符类型，等等。

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

  //使用添加的布局幻灯片添加空幻灯片

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //保存演示文稿

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **下载运行示例**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Adding Layout Slides/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode#content)
## **下载示例代码**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

有关更多详细信息，请访问 [将布局幻灯片添加到演示文稿](/slides/zh/net/adding-and-editing-slides/#working-with-slide-size-and-layout)。

{{% /alert %}}