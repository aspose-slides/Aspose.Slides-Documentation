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
description: "在 Aspose.Slides for .NET 中使用備援字型呈現簡報 – 透過逐步 C# 程式碼範例，確保 PPT、PPTX 與 ODP 之間的文字一致性。"
---
## **概覽**

Aspose.Slides 允許您使用備援字型規則來呈現簡報。本文說明如何建立備援字型規則集合、透過移除或新增備援字型來修改規則，並將該集合指派給 `FontsManager.FontFallBackRulesCollection` 屬性。

一旦將備援字型規則集合指派給簡報的 `FontsManager`，則在儲存、呈現以及轉換簡報等操作時會套用這些規則。範例展示了在呈現投影片縮圖並將其儲存為 PNG 圖像時，如何使用已設定的規則。

## **使用備援字型規則呈現投影片**

以下範例包含這些步驟：

1. 我們[建立備援字型規則集合](/slides/zh-hant/net/create-fallback-fonts-collection/)。
1. [Remove()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontfallbackrule/methods/remove) 移除備援字型規則，並將 [AddFallBackFonts()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 新增至另一規則。
1. 將規則集合設定到 [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) 屬性。
1. 使用 [Presentation.Save()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.presentation/save/methods/4) 方法，我們可以將簡報儲存為相同格式，或轉存為其他格式。當備援字型規則集合已設定至 FontsManager 後，這些規則會在簡報的任何操作中套用：儲存、呈現、轉換等。

```c#
// 建立規則集合的新執行個體
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.Add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));
//rulesList.Add(new FontFallBackRule(...));

foreach (IFontFallBackRule fallBackRule in rulesList)
{
	// 嘗試從已加載的規則中移除備援字型 "Tahoma" from loaded rules
	fallBackRule.Remove("Tahoma");

	// 並為指定範圍更新規則
	if ((fallBackRule.RangeEndIndex >= 0x4000) && (fallBackRule.RangeStartIndex < 0x5000))
		fallBackRule.AddFallBackFonts("Verdana");
}

// 也可以從列表中移除任何現有的規則 from list
if (rulesList.Count > 0)
	rulesList.Remove(rulesList[0]);

using (Presentation pres = new Presentation("input.pptx"))
{
    // 指定已準備好的規則清單以供使用
    pres.FontsManager.FontFallBackRulesCollection = rulesList;

    // 使用已初始化的規則集合渲染縮圖並儲存為 PNG
    using (IImage image = pres.Slides[0].GetImage(1f, 1f))
    {
        image.Save("Slide_0.png", ImageFormat.Png);
    }
}
```

{{% alert color="primary" %}} 
閱讀更多關於[簡報的儲存與轉換](/slides/zh-hant/net/convert-powerpoint-to-png/)的資訊。
{{% /alert %}}