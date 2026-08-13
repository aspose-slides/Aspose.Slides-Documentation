---
title: 在 C++ 中使用備援字型呈現簡報
linktitle: 呈現簡報
type: docs
weight: 30
url: /zh-hant/cpp/render-presentation-with-fallback-font/
keywords:
- 備援字型
- 呈現 PowerPoint
- 呈現簡報
- 呈現投影片
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中使用備援字型呈現簡報 – 透過逐步的 C++ 程式碼範例，確保 PPT、PPTX 與 ODP 之間的文字保持一致。"
---
## **概述**

Aspose.Slides 允許您使用備援字型規則來呈現簡報。本篇文章說明如何建立備援字型規則集合、透過移除或新增備援字型來修改規則，並使用 `FontsManager::set_FontFallBackRulesCollection` 方法指派該集合。

將備援字型規則集合指派給簡報的 `FontsManager` 後，這些規則會在儲存、呈現以及轉換簡報等操作期間套用。範例示範了在呈現投影片縮圖並將其儲存為 PNG 影像時，如何使用已配置的規則。

## **使用備援字型規則呈現投影片**

以下範例包含以下步驟：

1. 我們 [建立備援字型規則集合](/slides/zh-hant/cpp/create-fallback-fonts-collection/)。
2. [Remove()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/remove/) 一個備援字型規則，並 [AddFallBackFonts()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) 到另一個規則。
3. 將規則集合傳遞給 [FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) 方法。
4. 使用 [Presentation::Save()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 方法，我們可以將簡報儲存為相同格式，或儲存為其他格式。將備援字型規則集合設定給 FontsManager 後，這些規則會在對簡報的任何操作中套用：儲存、呈現、轉換等。

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

// 建立規則集合的新實例
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// 建立多個規則
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// 嘗試從已載入的規則中移除備援字型 "Tahoma"
	fallBackRule->Remove(u"Tahoma");

	// 並更新指定範圍的規則
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) &&
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// 也可以從清單中移除任何現有規則
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
了解更多有關如何在 C++ 中[將 PowerPoint 投影片轉換為 PNG](/slides/zh-hant/cpp/convert-powerpoint-to-png/)。
{{% /alert %}}