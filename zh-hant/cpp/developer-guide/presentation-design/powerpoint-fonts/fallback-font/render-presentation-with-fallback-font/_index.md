---
title: 在 C++ 中使用備用字型呈現簡報
linktitle: 呈現簡報
type: docs
weight: 30
url: /zh-hant/cpp/render-presentation-with-fallback-font/
keywords:
- 備用字型
- 呈現 PowerPoint
- 呈現簡報
- 呈現投影片
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中使用備用字型呈現簡報 – 透過一步一步的 C++ 程式碼範例，確保文字在 PPT、PPTX 與 ODP 之間保持一致。"
---
## **概覽**

Aspose.Slides 允許您使用備用字型規則來呈現簡報。 本篇文章說明如何建立備用字型規則集合、透過移除或新增備用字型來修改其規則，並使用 `FontsManager::set_FontFallBackRulesCollection` 方法指派該集合。

當備用字型規則集合被指派給簡報的 `FontsManager` 後，這些規則會在儲存、呈現與轉換簡報等操作中套用。 範例示範了在呈現投影片縮圖並將其儲存為 PNG 圖像時，如何使用已設定的規則。

## **使用備用字型規則呈現投影片**

以下範例包含這些步驟：

1. 我們[建立備用字型規則集合](/slides/zh-hant/cpp/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/remove/) 移除一個備用字型規則，並將[AddFallBackFonts()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/addfallbackfonts/) 套用到另一個規則。
1. 將規則集合傳遞給[FontsManager::set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) 方法。
1. 使用[Presentation::Save()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 方法，我們可以將簡報儲存為相同格式，或儲存為其他格式。 當備用字型規則集合設定至 FontsManager 後，這些規則會在簡報的任何操作（儲存、呈現、轉換等）中套用。

``` cpp
// 建立規則集合的新實例
auto rulesList = MakeObject<FontFallBackRulesCollection>();

// 建立多個規則
rulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x400), static_cast<uint32_t>(0x4FF), u"Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

for (const auto& fallBackRule : rulesList)
{
	// 嘗試從已載入的規則中移除備用字型「Tahoma」
	fallBackRule->Remove(u"Tahoma");

	// 以及為指定範圍更新規則
	if ((fallBackRule->get_RangeEndIndex() >= static_cast<uint32_t>(0x4000)) && 
		(fallBackRule->get_RangeStartIndex() < static_cast<uint32_t>(0x5000)))
	{
		fallBackRule->AddFallBackFonts(u"Verdana");
	}
}

// 也可以從列表中移除任何現有的規則
if (rulesList->get_Count() > 0)
{
	rulesList->Remove(rulesList->idx_get(0));
}

auto pres = System::MakeObject<Presentation>(u"input.pptx");
// 指派已準備好的規則清單以供使用
pres->get_FontsManager()->set_FontFallBackRulesCollection(rulesList);

// 使用已初始化的規則集合呈現縮圖並儲存為 PNG
auto image = pres->get_Slide(0)->GetImage(1.f, 1.f);
image->Save(u"Slide_0.png", ImageFormat::Png);
image->Dispose();

pres->Dispose();
```

{{% alert color="primary" %}} 
閱讀更多有關如何[將 PowerPoint 投影片轉換為 PNG (C++)](/slides/zh-hant/cpp/convert-powerpoint-to-png/)的資訊。
{{% /alert %}}