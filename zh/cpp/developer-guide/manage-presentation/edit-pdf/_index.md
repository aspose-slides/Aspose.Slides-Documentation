---
title: 在 C++ 中编辑 PDF 文档
linktitle: 编辑 PDF
type: docs
weight: 65
url: /zh/cpp/edit-pdf/
keywords:
- 编辑 PDF
- 替换 PDF 文本
- PDF 转 PPTX
- PPTX 转 PDF
- C++
- Aspose.Slides
description: "在 C++ 中通过将 PDF 导入 Aspose.Slides、替换文本并将修改后的演示文稿保存回 PDF 来编辑 PDF 文档。"
---
## **概述**

Aspose.Slides for C++ 允许您通过将 PDF 页面导入为幻灯片、修改演示文稿，然后再导出回 PDF 来编辑 PDF 内容。本文展示了一个简单的文本替换示例。演示文稿保留在内存中，因此保存中间的 PPTX 文件是可选的。

## **在 PDF 中替换文本**

使用 [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/zh/cpp/aspose.slides/slidecollection/addfrompdf/) 导入页面，使用 [Presentation::ReplaceText](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/replacetext/) 更新文本，使用 [Presentation::Save](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 导出结果。

下面的示例假设 `input.pdf` 在导入后包含可编辑的单词 “Draft”。它将该单词替换为 “Final”，并写入 `edited.pdf`。在导入前清除初始幻灯片可以防止输出中出现额外的空白页。搜索匹配大小写相同的完整单词；`nullptr` 表示不需要结果回调。

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

欲了解更多选项，请参阅 [Search and Replace Text](/slides/zh/cpp/search-and-replace-text/) 和 [Convert PowerPoint to PDF](/slides/zh/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
文本替换仅适用于导入的文本，而不适用于扫描图像中的文本。转换可能会影响布局和格式，因此请检查输出，尤其是在替换文本长度超过原始文本时。
{{% /alert %}}

## **常见问题**

**在导出 PDF 之前是否需要保存 PPTX 文件？**

不需要。您可以在内存中编辑并导出同一演示文稿。仅当您还希望在 PowerPoint 中继续编辑时才保存 PPTX 副本；请参阅 [Save Presentations](/slides/zh/cpp/save-presentation/)。

**为什么有些文本可能保持不变？**

示例要求完全匹配大小写的完整单词 “Draft”。作为图像导入的文本或分布在多个文本框中的文本可能不会匹配搜索。请检查导入的内容并针对您的文档调整搜索条件。