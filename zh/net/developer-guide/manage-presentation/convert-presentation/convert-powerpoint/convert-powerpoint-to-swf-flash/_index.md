---
title: 将 PowerPoint 转换为 SWF Flash
type: docs
weight: 80
url: /zh/net/convert-powerpoint-to-swf-flash/
keywords: "转换 PowerPoint, 演示文稿, PowerPoint 到 SWF, SWF flash PPT 到 SWF, PPTX 到 SWF, C#, Csharp, .NET"
description: "在 C# 或 .NET 中将 PowerPoint 演示文稿转换为 SWF Flash"
---

由 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) 类暴露的 [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) 方法可用于将整个演示文稿转换为 SWF 文档。您还可以通过使用 [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) 类和 [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions) 接口在生成的 SWF 中包含注释。以下示例演示了如何使用 SWFOptions 类提供的选项将演示文稿转换为 SWF 文档。

```c#
// 实例化表示演示文稿文件的 Presentation 对象
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;

    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // 保存演示文稿和注释页面
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```