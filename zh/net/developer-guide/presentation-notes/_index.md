---
title: 在 .NET 中管理演示文稿备注
linktitle: 演示文稿备注
type: docs
weight: 110
url: /zh/net/presentation-notes/
keywords:
- 备注
- 备注幻灯片
- 添加备注
- 删除备注
- 备注样式
- 主备注
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 定制演示文稿备注。无缝处理 PowerPoint 和 OpenDocument 备注，提升您的生产力。"
---
## **概述**

Aspose.Slides 支持从演示文稿中删除备注幻灯片。在本主题中，我们将介绍此功能，包括如何删除备注以及如何在演示文稿中对备注幻灯片应用样式。Aspose.Slides 允许您从任意幻灯片中删除备注，并对现有备注应用样式。开发人员可以通过以下方式删除备注：

- 从演示文稿的特定幻灯片中删除备注。
- 从演示文稿的所有幻灯片中删除备注。

若要读取或更改备注页面尺寸、切换方向以及检查导出行为，请参阅[Notes Page Size](/slides/zh/net/notes-size/)。

## **从幻灯片删除备注**
可以删除某个特定幻灯片的备注，如下例所示：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 实例化一个表示演示文稿文件的 Presentation 对象
Presentation presentation = new Presentation("AccessSlides.pptx");

// 删除第一张幻灯片的备注
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// 将演示文稿保存到磁盘
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **从所有幻灯片删除备注**
可以删除演示文稿中所有幻灯片的备注，如下例所示：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **添加备注样式**
已在 [IMasterNotesSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/imasternotesslide) 接口和 [MasterNotesSlide](https://reference.aspose.com/slides/zh/net/aspose.slides/masternotesslide) 类中分别添加了 NotesStyle 属性。此属性指定备注文本的样式。下面的示例演示了其实现。

```c#
using Aspose.Slides;

// 实例化表示演示文稿文件的 Presentation 类
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // 获取 MasterNotesSlide 文本样式
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // 设置第一层段落的符号项目符号
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // 将 PPTX 文件保存到磁盘
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **常见问题**

### 哪个 API 实体提供对特定幻灯片备注的访问？

备注通过幻灯片的备注管理器访问：幻灯片拥有一个 [NotesSlideManager](https://reference.aspose.com/slides/zh/net/aspose.slides/notesslidemanager/) 和一个返回备注对象的[property](https://reference.aspose.com/slides/zh/net/aspose.slides/notesslidemanager/notesslide/) ，如果没有备注则返回 `null`。