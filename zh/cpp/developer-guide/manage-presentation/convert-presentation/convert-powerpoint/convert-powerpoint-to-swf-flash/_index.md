---
title: 在 C++ 中将 PowerPoint 演示文稿转换为 SWF Flash
linktitle: PowerPoint 转 SWF
type: docs
weight: 80
url: /zh/cpp/convert-powerpoint-to-swf-flash/
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
- 将 PPT 保存为 SWF
- 将 PPTX 保存为 SWF
- 导出 PPT 为 SWF
- 导出 PPTX 为 SWF
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中将 PowerPoint (PPT/PPTX) 转换为 SWF Flash。提供一步一步的代码示例，快速高质量输出，无需 PowerPoint 自动化。"
---

## **将演示文稿转换为 Flash**

[Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法由 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类公开，可用于将整个演示文稿转换为 SWF 文档。您还可以通过使用 [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) 类和 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) 类在生成的 SWF 中包含批注。下面的示例展示了如何使用 SWFOptions 类提供的选项将演示文稿转换为 SWF 文档。

``` cpp
// 文档目录的路径。
    System::String dataDir = GetDataPath();

    // 实例化一个表示演示文稿文件的 Presentation 对象
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // 保存演示文稿和备注页面
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```


## **常见问题**

**我可以在 SWF 中包含隐藏幻灯片吗？**

是的。请使用 [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) 方法在 [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) 中进行设置。默认情况下，隐藏幻灯片不会被导出。

**我如何控制压缩和最终的 SWF 大小？**

使用 [set_Compressed](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_compressed/) 方法并调整 [JPEG quality](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_jpegquality/) 以在文件大小和图像质量之间取得平衡。

**‘set_ViewerIncluded’ 是做什么的，何时应使用它？**

[set_ViewerIncluded](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) 会添加嵌入式播放器 UI（导航控件、面板、搜索）。如果您计划使用自己的播放器或需要一个不带 UI 的纯 SWF 框架，请将其禁用。

**如果导出机器上缺少源字体会怎样？**

Aspose.Slides 将使用您在 [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) 中指定的字体在 [SwfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/swfoptions/) 中进行替代，以避免意外的回退。