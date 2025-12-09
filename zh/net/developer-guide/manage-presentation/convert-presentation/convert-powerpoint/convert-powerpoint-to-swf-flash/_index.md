---
title: 在 .NET 中将 PowerPoint 演示文稿转换为 SWF Flash
linktitle: PowerPoint 转 SWF
type: docs
weight: 80
url: /zh/net/convert-powerpoint-to-swf-flash/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 SWF
- 演示文稿 转 SWF
- 幻灯片 转 SWF
- PPT 转 SWF
- PPTX 转 SWF
- PowerPoint 转 Flash
- 演示文稿 转 Flash
- 幻灯片 转 Flash
- PPT 转 Flash
- PPTX 转 Flash
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 将 PowerPoint (PPT/PPTX) 转换为 SWF Flash。一步一步的 C# 代码示例，快速高质量输出，无需 PowerPoint 自动化。"
---

## **将演示文稿转换为 Flash**

The [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) method exposed by [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) class can be used to convert the whole presentation into SWF document.  You can also include comments in generated SWF by using [SWFOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions) class and [INotesCommentsLayoutingOptions ](https://reference.aspose.com/slides/net/aspose.slides.export/inotescommentslayoutingoptions)interface. The following example shows how to convert a presentation into SWF document by using options provided by SWFOptions class.
```c#
// 实例化一个表示演示文稿文件的 Presentation 对象
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // 保存演示文稿和备注页面
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```


## **常见问题**

**我可以在 SWF 中包含隐藏的幻灯片吗？**

是的。在[SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/)中启用[ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/showhiddenslides/)选项。 默认情况下，隐藏的幻灯片不会被导出。

**我如何控制压缩以及最终的 SWF 大小？**

使用[Compressed](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/compressed/)标志（默认已启用），并调节[JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/jpegquality/)以在文件大小和图像质量之间取得平衡。

**'ViewerIncluded' 的作用是什么？何时应禁用它？**

[ViewerIncluded](https://reference.aspose.com/slides/net/aspose.slides.export/swfoptions/viewerincluded/)会添加嵌入式播放器 UI（导航控件、面板、搜索）。如果您计划使用自己的播放器或需要没有 UI 的纯粹 SWF 框架，请禁用它。

**如果导出机器上缺少源字体会怎样？**

Aspose.Slides 将在[SwfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/)中使用通过[DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/defaultregularfont/)指定的字体进行替换，以避免意外的回退。