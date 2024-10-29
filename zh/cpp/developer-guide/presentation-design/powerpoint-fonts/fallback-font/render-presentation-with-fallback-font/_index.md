---
title: 使用回退字体渲染演示文稿
type: docs
weight: 30
url: /zh/cpp/render-presentation-with-fallback-font/
keywords: 
- 回退字体
- 渲染 PowerPoint
- PowerPoint
- 演示文稿
- C++
- Aspose.Slides for C++
description: "在 C++ 中使用回退字体渲染 PowerPoint"
---

以下示例包含这些步骤：

1. 我们 [创建回退字体规则集合](/slides/zh/cpp/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#aaf12e563d822f6e05e27732a837bcf33) 一个回退字体规则并 [AddFallBackFonts()](https://reference.aspose.com/slides/cpp/class/aspose.slides.font_fall_back_rule#a030268631ae616b775bdb6df8accf42c) 添加到另一个规则。
1. 将规则集合设置为 [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/cpp/class/aspose.slides.fonts_manager#a375fc71abd64891a39673751d127d924) 属性。
1. 使用 [Presentation::Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法，我们可以以相同格式保存演示文稿，或以另一种格式保存。在将回退字体规则集合设置为 FontsManager 后，这些规则在对演示文稿的任何操作中应用：保存、渲染、转换等。

``` cpp
// 创建规则集合的新实例
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// 创建多个规则
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// 尝试从已加载的规则中移除回退字体 "Tahoma"
	fallBackRule->Remove(u"Tahoma");

	// 更新指定范围的规则
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// 我们还可以从列表中移除任何现有规则
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// 为使用分配准备好的规则列表
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// 使用初始化的规则集合渲染缩略图并保存为 PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```


{{% alert color="primary" %}} 
阅读更多关于 [演示文稿中的保存和转换](/slides/zh/cpp/creating-saving-and-converting-a-presentation/)。
{{% /alert %}}