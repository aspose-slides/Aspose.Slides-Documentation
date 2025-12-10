---
title: 备注
type: docs
weight: 240
url: /zh/net/examples/elements/elements/note/
keywords:
- 备注示例
- 添加备注幻灯片
- 访问备注幻灯片
- 删除备注幻灯片
- 更新备注文本
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 C# 中使用 Aspose.Slides 添加、读取、编辑和导出演讲者备注：格式化文本、逐页管理备注，并在 PowerPoint 和 OpenDocument 中控制可见性。"
---

展示如何使用 **Aspose.Slides for .NET** 添加、读取、删除和更新备注幻灯片。

## **添加备注幻灯片**

创建一个备注幻灯片并为其分配文本。
```csharp
static void Add_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```


## **访问备注幻灯片**

读取现有备注幻灯片中的文本。
```csharp
static void Access_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```


## **删除备注幻灯片**

删除与某个幻灯片关联的备注幻灯片。
```csharp
static void Remove_Note()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```


## **更新备注文本**

更改备注幻灯片的文本。
```csharp
static void Update_Note_Text()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```
