---
title: 在 .NET 中使用備援字型呈現簡報
linktitle: 呈現簡報
type: docs
weight: 30
url: /zh-hant/net/render-presentation-with-fallback-font/
keywords:
- 備援字型
- 呈現 PowerPoint
- 呈現簡報
- 呈現投影片
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中使用備援字型呈現簡報 ─ 透過逐步 C# 程式碼範例，確保 PPT、PPTX 與 ODP 之間的文字保持一致。"
---
## **概述**

Aspose.Slides 允許您使用備援字型規則來呈現簡報。本文說明如何建立備援字型規則集合、透過移除或新增備援字型來修改其規則，並將集合指派給 `FontsManager.FontFallBackRulesCollection` 屬性。

當備援字型規則集合指派給簡報的 `FontsManager` 後，這些規則會在儲存、呈現與轉換簡報等操作中套用。範例示範了在呈現投影片縮圖並將其儲存為 PNG 圖像時，如何使用已設定的規則。

## **使用備援字型規則呈現投影片**

以下範例包含這些步驟：

1. 我們[建立備援字型規則集合](/slides/zh-hant/net/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontfallbackrule/methods/remove) 移除備援字型規則，並[AddFallBackFonts()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 新增至另一個規則。
1. 將規則集合設定為 [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) 屬性。
1. 使用 [Presentation.Save()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.presentation/save/methods/4) 方法，我們可以將簡報儲存為相同格式，或另存為其他格式。將備援字型規則集合設定給 FontsManager 後，這些規則會在任何簡報操作中套用：儲存、呈現、轉換等。

```c#
using Aspose.Slides;

// 建立規則集合的新實例
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
rulesList.Add(new FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial"));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// 嘗試從已載入的規則中移除備援字型 "Tahoma"
	fallBackRule.Remove("Tahoma");

	// 以及為指定範圍更新規則
	if ((fallBackRule.RangeEndIndex >= 0x400) && (fallBackRule.RangeStartIndex < 0x500))
		fallBackRule.AddFallBackFonts("Verdana");
}

// 亦可從清單中移除任何現有規則，保留至少一個規則以供呈現使用
if (rulesList.Count > 1)
	rulesList.Remove(rulesList[1]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // 指派已準備好的規則清單以供使用
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // 使用已初始化的規則集合渲染縮圖並保存為 PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="info" %}} 
閱讀更多關於[簡報的儲存與轉換](/slides/zh-hant/net/convert-powerpoint-to-png/)的資訊。
{{% /alert %}}