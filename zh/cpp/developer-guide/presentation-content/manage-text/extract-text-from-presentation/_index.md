---
title: 从演示文稿中提取文本
type: docs
weight: 90
url: /cpp/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

开发人员需要从演示文稿中提取文本并不罕见。为此，您需要从演示文稿中所有幻灯片上的所有形状中提取文本。本文解释了如何使用 Aspose.Slides 从 Microsoft PowerPoint PPTX 演示文稿中提取文本。可以通过以下方式提取文本：

- [从一个幻灯片提取文本](/slides/cpp/extracting-text-from-the-presentation/)
- [使用 GetAllTextBoxes 方法提取文本](/slides/cpp/extracting-text-from-the-presentation/)
- [分类和快速提取文本](/slides/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **从幻灯片中提取文本**
Aspose.Slides for C++ 提供了 Aspose.Slides.Util 命名空间，其中包含 SlideUtil 类。该类公开了一些重载的静态方法，用于从演示文稿或幻灯片中提取全部文本。要从 PPTX 演示文稿中的幻灯片中提取文本，请使用由 SlideUtil 类公开的 [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df) 重载静态方法。该方法接受 Slide 对象作为参数。
执行时，Slide 方法扫描作为参数传递的幻灯片中的所有文本，并返回一个 TextFrame 对象数组。这意味着与文本相关的任何文本格式也可用。以下代码提取演示文稿中第一张幻灯片上的所有文本：

``` cpp
// 文档目录的路径。
System::String dataDir = GetDataPath();

// 实例化表示 PPTX 文件的 Presentation 类
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// 从 PPTX 的所有幻灯片中获取 ITextFrame 对象数组
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
			// 显示当前部分中的文本
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

## **从演示文稿中提取文本**
要扫描整个演示文稿中的文本，请使用由 SlideUtil 类公开的 [GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12) 静态方法。它接受两个参数：

1. 首先，是一个表示从中提取文本的 PPTX 演示文稿的 Presentation 对象。
2. 其次，是一个布尔值，确定在从演示文稿扫描文本时是否包含母版幻灯片。
   该方法返回一个包含文本格式信息的 TextFrame 对象数组。以下代码扫描演示文稿中的文本和格式信息，包括母版幻灯片。

``` cpp
// 文档目录的路径。
System::String dataDir = GetDataPath();

// 实例化表示 PPTX 文件的 Presentation 类
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// 从 PPTX 的所有幻灯片中获取 ITextFrame 对象数组
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
			// 显示当前部分中的文本
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
Presentation 类中新增了静态方法 GetPresentationText。该方法有两个重载：

``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```

TextExtractionArrangingMode 枚举参数指示组织文本结果输出的模式，可以设置为以下值：  
未排序 - 原始文本，不考虑在幻灯片上的位置  
已排序 - 文本按照幻灯片上的顺序定位

当速度至关重要时，可以使用未排序模式，它比已排序模式更快。

PresentationText 表示从演示文稿中提取的原始文本。它包含 Aspose.Slides.Util 命名空间中的 get_SlidesText() 方法，该方法返回 ISlideText 对象数组。每个对象代表相应幻灯片上的文本。ISlideText 对象具有以下方法：

get_Text() - 幻灯片形状上的文本。  
get_MasterText() - 此幻灯片的母版页面形状上的文本。  
get_LayoutText() - 此幻灯片的布局页面形状上的文本。  
get_NotesText() - 此幻灯片的备注页面形状上的文本。

还有一个实现 ISlideText 接口的 SlideText 类。

新的 API 可以如下使用：

``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```