---
title: 使用回退字体在 C++ 中渲染演示文稿
linktitle: 渲染演示文稿
type: docs
weight: 30
url: /zh/cpp/render-presentation-with-fallback-font/
keywords:
- 回退字体
- 渲染 PowerPoint
- 渲染演示文稿
- 渲染幻灯片
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中使用回退字体渲染演示文稿 – 通过一步步的 C++ 代码示例保持 PPT、PPTX 和 ODP 文本一致。"
---
## **概述**

Aspose.Slides 允许您使用回退字体规则渲染演示文稿。本文展示了如何创建回退字体规则集合、通过删除或添加回退字体来修改其规则，以及如何使用 `FontsManager::set_FontFallBackRulesCollection` 方法分配该集合。

一旦将回退字体规则集合分配给演示文稿的 `FontsManager`，这些规则将在保存、渲染和转换演示文稿等操作期间生效。示例演示了在渲染幻灯片缩略图并将其保存为 PNG 图像时如何使用已配置的规则。

## **使用回退字体规则渲染幻灯片**

以下示例包括以下步骤：

1. 我们[创建回退字体规则集合](/slides/zh/cpp/create-fallback-fonts-collection/)。
2. [Remove()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontfallbackrule/remove/) 删除一个回退字体规则并[AddFallBackFonts()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) 向另一个规则添加回退字体。
3. 将规则集合传递给[FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) 方法。
4. 使用[Presentation::Save()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/) 方法，我们可以以相同格式保存演示文稿，或以其他格式保存。将回退字体规则集合设置到 FontsManager 后，这些规则将在对演示文稿的任何操作期间生效：保存、渲染、转换等。

``` cpp
// 创建规则集合的新实例
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// 创建若干规则
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// 尝试从已加载的规则中移除回退字体 "Tahoma"
	fallBackRule->Remove(u"Tahoma");

	// 并为指定范围更新规则
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// 我们也可以从列表中移除任何现有规则
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// 分配准备好的规则列表以供使用
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// 使用已初始化的规则集合渲染缩略图并保存为 PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
了解更多关于如何在 C++ 中[将 PowerPoint 幻灯片转换为 PNG](/slides/zh/cpp/convert-powerpoint-to-png/)的信息。 
{{% /alert %}}