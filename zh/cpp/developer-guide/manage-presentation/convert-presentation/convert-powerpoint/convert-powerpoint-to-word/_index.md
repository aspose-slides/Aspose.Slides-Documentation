---
title: 将 PowerPoint 转换为 Word
type: docs
weight: 110
url: /cpp/convert-powerpoint-to-word/
keywords: "将 PowerPoint, PPT, PPTX, 演示文稿, Word, DOCX, DOC, PPTX 转换为 DOCX, PPT 转换为 DOC, PPTX 转换为 DOC, PPT 转换为 DOCX, C++, Aspose.Slides"
description: "在 C++ 中将 PowerPoint 演示文稿转换为 Word"
---

如果您计划以新的方式使用演示文稿（PPT 或 PPTX）中的文本内容或信息，您可能会受益于将演示文稿转换为 Word（DOC 或 DOCX）。

* 与 Microsoft PowerPoint 相比，Microsoft Word 应用程序更具备用于内容的工具或功能。
* 除了 Word 中的编辑功能外，您还可以受益于增强的协作、打印和共享功能。

{{% alert color="primary" %}} 

您可能想尝试我们的 [**演示文稿到 Word 在线转换器**](https://products.aspose.app/slides/conversion/ppt-to-word)，看看您从幻灯片的文本内容中可以获得哪些好处。

{{% /alert %}} 

### **Aspose.Slides 和 Aspose.Words**

要将 PowerPoint 文件（PPTX 或 PPT）转换为 Word（DOCX 或 DOCX），您需要同时使用 [Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) 和 [Aspose.Words for C++](https://products.aspose.com/words/cpp/)。

作为独立的 API，[Aspose.Slides](https://products.aspose.app/slides) for C++ 提供允许您从演示文稿中提取文本的函数。

[Aspose.Words](https://docs.aspose.com/words/cpp/) 是一个先进的文档处理 API，允许应用程序生成、修改、转换、渲染、打印文件，并执行其他与文档相关的任务，而无需使用 Microsoft Word。

## **将 PowerPoint 转换为 Word**

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

    // 插入幻灯片的文本
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