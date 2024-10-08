---
title: 演示文稿笔记
type: docs
weight: 110
url: /net/presentation-notes/
keywords: "笔记, PowerPoint 笔记, 添加笔记, 移除笔记, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中添加和移除 PowerPoint 演示文稿中的笔记"
---



Aspose.Slides 支持从演示文稿中移除笔记幻灯片。在本主题中，我们将介绍此新功能，即移除笔记以及从任何演示文稿中添加笔记样式幻灯片。Aspose.Slides for .NET 提供移除任何幻灯片的笔记以及为现有笔记添加样式的功能。开发人员可以通过以下方式移除笔记：

- 移除演示文稿中特定幻灯片的笔记。
- 移除演示文稿中所有幻灯片的笔记。
## **从幻灯片中移除笔记**
可以通过如下示例移除特定幻灯片的笔记：

```c#
// 实例化一个表示演示文稿文件的 Presentation 对象 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// 移除第一张幻灯片的笔记
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// 将演示文稿保存到磁盘
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **从所有幻灯片中移除笔记**
可以通过如下示例移除演示文稿中所有幻灯片的笔记：

```c#
// 实例化一个表示演示文稿文件的 Presentation 对象 
Presentation presentation = new Presentation("AccessSlides.pptx");

// 移除所有幻灯片的笔记
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// 将演示文稿保存到磁盘
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **添加笔记样式**
NotesStyle 属性已分别添加到 [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) 接口和 [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) 类。 此属性指定笔记文本的样式。实现示例如下所示。

```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // 获取 MasterNotesSlide 文本样式
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // 为第一级段落设置符号项目符号
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // 将 PPTX 文件保存到磁盘
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```