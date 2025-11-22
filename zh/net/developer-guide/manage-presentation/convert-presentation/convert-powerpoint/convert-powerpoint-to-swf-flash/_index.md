---
title: 将 PowerPoint 转换为 SWF Flash
type: docs
weight: 80
url: /zh/net/convert-powerpoint-to-swf-flash/
keywords: "转换 PowerPoint, 演示文稿, PowerPoint 转 SWF, SWF flash PPT 转 SWF, PPTX 转 SWF, C#, Csharp, .NET"
description: "在 C# 或 .NET 中将 PowerPoint 演示文稿转换为 SWF Flash"
---

## **将演示文稿转换为Flash**

由[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)类公开的[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)方法可用于将整个演示文稿转换为SWF文档。您还可以通过使用[SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions)类和[INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions)接口在生成的SWF中包含批注。以下示例展示了如何使用SWFOptions类提供的选项将演示文稿转换为SWF文档。

```c#
// 实例化一个表示演示文件的 Presentation 对象
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // 保存演示文稿和笔记页面
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```


## **常见问题**

**我可以在SWF中包含隐藏幻灯片吗？**

可以。请在[SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/)中启用[ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/)选项。默认情况下，隐藏的幻灯片不会被导出。

**如何控制压缩以及最终的SWF大小？**

使用[Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/)标志（默认已启用）并调整[JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/)以在文件大小和图像保真度之间取得平衡。

**‘ViewerIncluded’ 是什么用途，何时应禁用它？**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/)会添加嵌入式播放器UI（导航控件、面板、搜索）。如果您计划使用自己的播放器或需要没有UI的裸SWF框架，请禁用它。

**如果导出机器上缺少源字体会怎样？**

Aspose.Slides将在[SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/)中使用您通过[DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/)指定的字体进行替换，以避免意外的回退。