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
description: "在 Aspose.Slides for C++ 中使用回退字体渲染演示文稿 – 通过逐步的 C++ 代码示例，使文本在 PPT、PPTX 和 ODP 中保持一致。"
---
## **概述**

Aspose.Slides 允许您使用回退字体规则呈现演示文稿。本文展示了如何创建回退字体规则集合、通过删除或添加回退字体来修改其规则，以及如何使用 `FontsManager::set_FontFallBackRulesCollection` 方法分配该集合。

一旦将回退字体规则集合分配给演示文稿的 `FontsManager`，这些规则将在保存、渲染和转换演示文稿等操作期间生效。示例演示了在渲染幻灯片缩略图并将其保存为 PNG 图像时如何使用已配置的规则。

## **使用回退字体规则渲染幻灯片**

以下示例包括这些步骤：

1. 我们[创建回退字体规则集合](/slides/zh/cpp/create-fallback-fonts-collection/)。
2. [Remove()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontfallbackrule/remove/) 一个回退字体规则并[AddFallBackFonts()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/)到另一个规则。
3. 将规则集合传递给[FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/)方法。
4. 使用[Presentation::Save()](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/save/)方法，我们可以以相同格式保存演示文稿，或保存为其他格式。在将回退字体规则集合设置到 FontsManager 后，这些规则将在对演示文稿的任何操作中应用：保存、渲染、转换等。

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontsManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

// 创建规则集合的新实例
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// 创建多个规则
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

// 我们也可以从列表中移除任何现有的规则
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// Assigning a prepared rules list for using
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// Rendering of thumbnail with using of initialized rules collection and saving to PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", Aspose::Slides::ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="info" %}} 
了解更多关于如何在 C++ 中[将 PowerPoint 幻灯片转换为 PNG（C++）](/slides/zh/cpp/convert-powerpoint-to-png/)的信息。 
{{% /alert %}}