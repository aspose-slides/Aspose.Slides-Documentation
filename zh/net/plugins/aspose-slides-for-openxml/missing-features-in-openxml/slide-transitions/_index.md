---
title: 幻灯片过渡
type: docs
weight: 80
url: /net/slide-transitions/
---

为了让您更容易理解，我们演示了如何使用 Aspose.Slides for .NET 来管理简单的幻灯片过渡。开发人员不仅可以在幻灯片上应用不同的幻灯片过渡效果，还可以自定义这些过渡效果的行为。要创建简单的幻灯片过渡效果，请遵循以下步骤：

- 创建一个 Presentation 类的实例
- 从 Aspose.Slides for .NET 提供的过渡效果中应用一种幻灯片过渡类型，通过 **TransitionType** 枚举
- 写入修改后的演示文件。
## **示例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//实例化表示演示文件的 Presentation 类

using (Presentation pres = new Presentation(FileName))

{

    //在幻灯片 1 上应用圆形类型过渡

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //在幻灯片 2 上应用组合型过渡

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //在幻灯片 3 上应用缩放型过渡

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //将演示文稿写入磁盘

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **下载示例代码**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **下载运行示例**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Managing Slides Transitions/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

有关更多详细信息，请访问 [Managing Slides Transitions](/slides/net/slide-transition/)。

{{% /alert %}}