---
title: 将 PowerPoint 演示文稿转换为 C++ 中的 Word 文档
linktitle: PowerPoint 转 Word
type: docs
weight: 110
url: /zh/cpp/convert-powerpoint-to-word/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPT
- 转换 PPTX
- PowerPoint 转 Word
- 演示文稿 转 Word
- 幻灯片 转 Word
- PPT 转 Word
- PPTX 转 Word
- PowerPoint 转 DOCX
- 演示文稿 转 DOCX
- 幻灯片 转 DOCX
- PPT 转 DOCX
- PPTX 转 DOCX
- PowerPoint 转 DOC
- 演示文稿 转 DOC
- 幻灯片 转 DOC
- PPT 转 DOC
- PPTX 转 DOC
- 将 PPT 保存为 DOCX
- 将 PPTX 保存为 DOCX
- 导出 PPT 为 DOCX
- 导出 PPTX 为 DOCX
- C++
- Aspose.Slides
description: "在 C++ 中使用 Aspose.Slides 将 PowerPoint PPT 和 PPTX 幻灯片转换为可编辑的 Word 文档，精准保留布局、图像和格式。"
---

如果您计划以新的方式使用演示文稿（PPT 或 PPTX）中的文本内容或信息，您可能会受益于将演示文稿转换为 Word（DOC 或 DOCX）。

* 与 Microsoft PowerPoint 相比，Microsoft Word 应用在内容方面提供了更丰富的工具或功能。
* 除了 Word 的编辑功能外，您还可以受益于增强的协作、打印和共享功能。

{{% alert color="primary" %}}
您可以尝试我们的[**演示文稿转 Word 在线转换器**](https://products.aspose.app/slides/conversion/ppt-to-word)，了解从幻灯片的文本内容中可以获得的收益。
{{% /alert %}}

## **Aspose.Slides 和 Aspose.Words**

要将 PowerPoint 文件（PPTX 或 PPT）转换为 Word（DOCX 或 DOC），您需要同时拥有 [Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) 和 [Aspose.Words for C++](https://products.aspose.com/words/cpp/)。

作为独立的 API，针对 C++ 的 [Aspose.Slides](https://products.aspose.app/slides) 提供可从演示文稿中提取文本的功能。

[Aspose.Words](https://docs.aspose.com/words/cpp/) 是一个高级文档处理 API，允许应用程序在不使用 Microsoft Word 的情况下生成、修改、转换、渲染、打印文件以及执行其他文档相关任务。

## **将 PowerPoint 演示文稿转换为 Word 文档**

使用以下代码片段将 PowerPoint 转换为 Word：
```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // 生成并插入幻灯片图像
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // 插入幻灯片文本
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}
```


## **常见问题**

**需要安装哪些组件才能将 PowerPoint 和 OpenDocument 演示文稿转换为 Word 文档？**

您只需将 [Aspose.Slides for C++](https://releases.aspose.com/slides/cpp/) 和 [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) 的相应包添加到项目中。两个库均作为独立的 API 使用，无需安装 Microsoft Office。

**是否支持所有 PowerPoint 和 OpenDocument 演示文稿格式？**

Aspose.Slides [支持所有演示文稿格式](/slides/zh/cpp/supported-file-formats/)，包括 PPT、PPTX、ODP 等常见文件类型。这确保您可以处理在不同版本 Microsoft PowerPoint 中创建的演示稿。