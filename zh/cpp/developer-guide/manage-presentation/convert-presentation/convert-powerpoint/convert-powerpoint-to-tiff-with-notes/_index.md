---
title: 将 PowerPoint 转换为带备注的 TIFF
type: docs
weight: 100
url: /cpp/convert-powerpoint-to-tiff-with-notes/
keywords: "将 PowerPoint 转换为带备注的 TIFF"
description: "在 Aspose.Slides 中将 PowerPoint 转换为带备注的 TIFF。"
---

TIFF 是 Aspose.Slides for C++ 支持的一种广泛使用的图像格式，可以将带备注的 PowerPoint PPT 和 PPTX 演示文稿转换为图像。您还可以在备注幻灯片视图中生成幻灯片缩略图。Presentation 类暴露的 [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法可用于将整个演示文稿在备注幻灯片视图中转换为 TIFF。使用 Aspose.Slides for C++ 将 Microsoft PowerPoint 演示文稿保存为 TIFF 备注只需两行代码。您只需打开演示文稿并将其保存为 TIFF 备注。您还可以为单个幻灯片在备注幻灯片视图中生成幻灯片缩略图。下面的代码片段将示例演示文稿更新为备注幻灯片视图中的 TIFF 图像，如下所示：

``` cpp
// 文档目录的路径。
System::String dataDir = GetDataPath();

// 实例化一个表示演示文稿文件的 Presentation 对象
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

// 将演示文稿保存为 TIFF 备注
presentation->Save(dataDir + u"Notes_In_Tiff_out.tiff", SaveFormat::Tiff);
```

{{% alert title="提示" color="primary" %}}

您可能想查看 Aspose [免费的 PowerPoint 转海报转换器](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)。

{{% /alert %}}