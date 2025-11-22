---
title: 演示文稿备注
type: docs
weight: 110
url: /zh/net/presentation-notes/
keywords: "备注, PowerPoint 备注, 添加 备注, 删除 备注, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中为 PowerPoint 演示文稿添加和删除备注"
---

Aspose.Slides 支持从演示文稿中删除备注幻灯片。在本主题中，我们将介绍此新功能——从任何演示文稿中删除备注并添加备注样式幻灯片。Aspose.Slides for .NET 提供了删除任意幻灯片备注以及为现有备注添加样式的功能。开发人员可以通过以下方式删除备注：

- 删除演示文稿中特定幻灯片的备注。
- 删除演示文稿中所有幻灯片的备注。

## **从幻灯片中删除备注**
如下面的示例所示，可删除某个特定幻灯片的备注：
```c#
// 实例化一个表示演示文稿文件的 Presentation 对象 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// 删除第一张幻灯片的备注
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// 将演示文稿保存到磁盘
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **从所有幻灯片中删除备注**
如下面的示例所示，可删除演示文稿中所有幻灯片的备注：
```c#
// 实例化一个表示演示文稿文件的 Presentation 对象 
Presentation presentation = new Presentation("AccessSlides.pptx");

// 删除所有幻灯片的备注
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// 将演示文稿保存到磁盘
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **添加 NotesStyle**
已在 [IMasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/imasternotesslide) 接口和 [MasterNotesSlide](https://reference.aspose.com/slides/net/aspose.slides/masternotesslide) 类中添加了 NotesStyle 属性。此属性指定备注文本的样式。下面的示例演示了其实现。
```c#
// 实例化表示演示文稿文件的 Presentation 类
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // 获取 MasterNotesSlide 文本样式
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //为第一级段落设置符号项目符号
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // 保存 PPTX 文件到磁盘
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```


## **常见问题**

**哪种 API 实体提供对特定幻灯片备注的访问？**

备注可通过幻灯片的备注管理器访问：幻灯片拥有一个 [NotesSlideManager](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/) ，以及一个返回备注对象的 [property](https://reference.aspose.com/slides/net/aspose.slides/notesslidemanager/notesslide/)，如果没有备注则返回 `null`。

**库支持的不同 PowerPoint 版本在备注功能上是否存在差异？**

该库面向广泛的 Microsoft PowerPoint 格式（97 版及更新版本）以及 ODP；这些格式中均支持备注，无需依赖已安装的 PowerPoint。