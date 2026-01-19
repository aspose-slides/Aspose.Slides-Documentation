---
title: 将布局幻灯片添加到演示文稿
type: docs
weight: 10
url: /zh/net/add-layout-slide-to-presentation/
---

Aspose.Slides for .NET 允许开发人员在演示文稿中添加新的布局幻灯片。要添加布局幻灯片，请按照以下步骤操作：

- 创建 Presentation 类的实例
- 访问母版幻灯片集合
- 尝试查找现有的布局幻灯片，以确定所需的布局是否已在布局幻灯片集合中存在
- 如果所需布局不存在，则添加新的布局幻灯片
- 使用新添加的布局幻灯片添加空白幻灯片
- 最后，使用 Presentation 对象写入演示文稿文件。

## **示例**
``` csharp

 //Instantiate Presentation class that represents the presentation file

using (Presentation p = new Presentation("Test.pptx"))

{

   // Try to search by layout slide type

   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

   ILayoutSlide layoutSlide =

   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

   layoutSlides.GetByType(SlideLayoutType.Title);

   if (layoutSlide == null)

   {

     // The situation when a presentation doesn't contain some type of layouts.

     // Technographics.pptx presentation only contains Blank and Custom layout types.

     // But layout slides with Custom types has different slide names,

     // like "Title", "Title and Content", etc. And it is possible to use these

     // names for layout slide selection.

     // Also it is possible to use the set of placeholder shape types. For example,

     // Title slide should have only Title pleceholder type, etc.

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

  //Adding empty slide with added layout slide

  p.Slides.InsertEmptySlide(0, layoutSlide);

  //Save presentation

  p.Save("Output.pptx", SaveFormat.Pptx);

}


``` 
## **下载运行示例**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **下载示例代码**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
欲了解更多详情，请访问[在 .NET 中应用或更改幻灯片布局](/slides/zh/net/slide-layout/)。
{{% /alert %}}