---
title: Aspose.Slides for .NET 15.1.0 的公共 API 與向後不相容變更
linktitle: Aspose.Slides for .NET 15.1.0
type: docs
weight: 130
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢閱 Aspose.Slides for .NET 的公共 API 更新與破壞性變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有已[新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)或[移除](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/)的類別、方法、屬性等，以及隨 Aspose.Slides for .NET 15.1.0 API 所引入的其他變更。

{{% /alert %}} 
## **Public API 變更**
#### **已新增字型替代功能**
已加入在簡報中全域取代字型以及在渲染時暫時取代字型的功能。

已在 Presentation 類別中引入新屬性 **"FontsManager"**。FontsManager 類別具有以下成員：

**IFontSubstRuleCollection FontSubstRuleList** 屬性

此集合包含用於在渲染期間替換字型的 IFontSubstRule 實例。IFontSubstRule 具備實作 IFontData 介面的 SourceFont 與 DestFont 屬性，並有 ReplaceFontCondition 屬性，可選擇替換條件（「WhenInaccessible」或「Always」）。

**IFontData[] GetFonts()** 方法

用於取得目前簡報中使用的所有字型。

**ReplaceFont** 方法

用於在簡報中永久取代字型。

以下範例說明如何在簡報中取代字型：

``` csharp

             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


``` 

另一個範例展示在無法存取時的渲染字型替代：

``` csharp

             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial 字體將在 SomeRareFont 無法存取時使用。

            pres.Slides[0].GetThumbnail();
```