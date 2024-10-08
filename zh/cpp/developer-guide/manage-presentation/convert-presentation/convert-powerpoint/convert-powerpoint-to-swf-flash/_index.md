---
title: 将 PowerPoint 转换为 SWF Flash
type: docs
weight: 80
url: /cpp/convert-powerpoint-to-swf-flash/
keywords: "PPT, PPTX 转 SWF"
description: "使用 Aspose.Slides API 将 PowerPoint PPT，PPTX 转换为 SWF Flash 格式。"
---

由 [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) 类公开的 [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法可用于将整个演示文稿转换为 SWF 文档。您还可以使用 [SWFOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.swf_options) 类和 [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_notes_comments_layouting_options) 接口在生成的 SWF 中包含注释。以下示例演示了如何使用 SWFOptions 类提供的选项将演示文稿转换为 SWF 文档。

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