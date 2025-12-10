---
title: 在 C++ 中的高级演示文稿文本提取
linktitle: 提取文本
type: docs
weight: 90
url: /zh/cpp/extract-text-from-presentation/
keywords:
- 提取文本
- 从幻灯片提取文本
- 从演示文稿提取文本
- 从 PowerPoint 提取文本
- 从 OpenDocument 提取文本
- 从 PPT 提取文本
- 从 PPTX 提取文本
- 从 ODP 提取文本
- 检索文本
- 从幻灯片检索文本
- 从演示文稿检索文本
- 从 PowerPoint 检索文本
- 从 OpenDocument 检索文本
- 从 PPT 检索文本
- 从 PPTX 检索文本
- 从 ODP 检索文本
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 快速提取 PowerPoint 和 OpenDocument 演示文稿中的文本。遵循我们简明的分步指南，以节省时间。"
---

{{% alert color="primary" %}} 

开发人员需要从演示文稿中提取文本并不少见。为此，您需要从演示文稿中所有幻灯片的所有形状中提取文本。本文介绍了如何使用 Aspose.Slides 从 Microsoft PowerPoint PPTX 演示文稿中提取文本。文本可以通过以下方式提取：

- [从单个幻灯片提取文本](/slides/zh/cpp/extracting-text-from-the-presentation/)
- [使用 GetAllTextBoxes 方法提取文本](/slides/zh/cpp/extracting-text-from-the-presentation/)
- [分类和快速提取文本](/slides/zh/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **从幻灯片提取文本**
Aspose.Slides for C++ 提供了 Aspose.Slides.Util 命名空间，其中包含 SlideUtil 类。该类提供了多个重载的静态方法，用于从演示文稿或幻灯片中提取全部文本。要从 PPTX 演示文稿的幻灯片中提取文本，使用 SlideUtil 类公开的 [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df) 重载静态方法。此方法接受 Slide 对象作为参数。执行后，Slide 方法会扫描传入的幻灯片的全部文本，并返回一个 TextFrame 对象数组。这意味着可以获取与文本关联的任何格式信息。下面的代码片段提取了演示文稿第一张幻灯片上的所有文本：
``` cpp
// 文档目录的路径。
System::String dataDir = GetDataPath();

// 实例化表示 PPTX 文件的 Presentation 类
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// 从 PPTX 的所有幻灯片获取 ITextFrame 对象数组
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// 遍历 TextFrames 数组
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// 遍历当前 ITextFrame 中的段落
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// 遍历当前 IParagraph 中的部分
		for (const auto& port : para->get_Portions())
		{
			// 显示当前部分的文本
			Console::WriteLine(port->get_Text());

			// 显示文本的字体高度
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// 显示文本的字体名称
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```


## **从演示文稿提取文本**
要扫描整个演示文稿的文本，使用 SlideUtil 类公开的 [GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12) 静态方法。它接受两个参数：

1. 首先，一个代表要提取文本的 PPTX 演示文稿的 Presentation 对象。  
2. 其次，一个布尔值，决定在扫描演示文稿文本时是否包含母版幻灯片。  
   该方法返回一个包含文本格式信息的 TextFrame 对象数组。下面的代码扫描了演示文稿的文本及其格式信息，包括母版幻灯片。
``` cpp
// 文档目录的路径。
System::String dataDir = GetDataPath();

// 实例化表示 PPTX 文件的 Presentation 类
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// 从 PPTX 的所有幻灯片获取 ITextFrame 对象数组
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// 遍历 TextFrames 数组
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// 遍历当前 ITextFrame 中的段落
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// 遍历当前 IParagraph 中的部分
		for (const auto& port : para->get_Portions())
		{
			// 显示当前部分的文本
			Console::WriteLine(port->get_Text());

			// 显示文本的字体高度
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// 显示文本的字体名称
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```


## **分类和快速文本提取**
在 Presentation 类中添加了新的静态方法 GetPresentationText。此方法有两个重载版本：
``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```


The TextExtractionArrangingMode 枚举参数指示组织文本结果输出的模式，可设置为以下值：
Unarranged - 原始文本，不考虑在幻灯片上的位置  
Arranged - 文本按照在幻灯片上的相同顺序排列

当速度至关重要时，可使用 Unarranged 模式，它比 Arranged 模式更快。

PresentationText 表示从演示文稿提取的原始文本。它包含来自 Aspose.Slides.Util 命名空间的 get_SlidesText() 方法，该方法返回 ISlideText 对象数组。每个对象表示对应幻灯片上的文本。ISlideText 对象具有以下方法：

get_Text() - 幻灯片形状上的文本。  
get_MasterText() - 此幻灯片对应的母版页形状上的文本。  
get_LayoutText() - 此幻灯片对应的版式页形状上的文本。  
get_NotesText() - 此幻灯片对应的备注页形状上的文本。

此外，还有实现 ISlideText 接口的 SlideText 类。

新的 API 可按如下方式使用：
``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```


## **常见问题解答**

**在文本提取过程中，Aspose.Slides 处理大型演示文稿的速度如何？**
Aspose.Slides 已针对高性能进行优化，能够高效处理即使是大型演示文稿，适用于实时或批量处理场景。

**Aspose.Slides 能否从演示文稿中的表格和图表提取文本？**
是的，Aspose.Slides 完全支持从表格、图表以及其他复杂幻灯片元素中提取文本，帮助您轻松访问和分析所有文本内容。

**提取演示文稿文本是否需要特殊的 Aspose.Slides 许可证？**
您可以使用 Aspose.Slides 的免费试用版进行文本提取，但会有一定限制，例如只能处理有限数量的幻灯片。若需无限制使用并处理更大的演示文稿，建议购买完整许可证。