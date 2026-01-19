---
title: 幻灯片切换
type: docs
weight: 80
url: /zh/net/slide-transitions/
---

为了更容易理解，我们演示了使用 Aspose.Slides for .NET 来管理简单的幻灯片切换。开发人员不仅可以在幻灯片上应用不同的切换效果，还可以自定义这些切换效果的行为。要创建一个简单的幻灯片切换效果，请按照以下步骤操作：

- 创建 Presentation 类的实例
- 通过 **TransitionType** 枚举，从 Aspose.Slides for .NET 提供的切换效果中为幻灯片应用 Slide Transition Type
- 写入修改后的演示文稿文件。

## **示例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Instantiate Presentation class that represents a presentation file

using (Presentation pres = new Presentation(FileName))

{

    //Apply circle type transition on slide 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Apply comb type transition on slide 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Apply zoom type transition on slide 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Write the presentation to disk

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **下载示例代码**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **下载运行示例**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 

欲了解更多详情，请访问 [Managing Slides Transitions](/slides/zh/net/slide-transition/).

{{% /alert %}}