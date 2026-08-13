---
title: Aspose.Slides for .NET 15.1.0 的公開 API 及相容性破壞變更
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
description: "檢視 Aspose.Slides for .NET 中的公共 API 更新與相容性中斷變更，以順暢遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}}
此頁面列出所有 [added](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) 或 [removed](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-1-0/) 的類別、方法、屬性等，及 Aspose.Slides for .NET 15.1.0 API 所引入的其他變更。
{{% /alert %}}
## **公開 API 變更**
#### **已新增字型替換功能**
已加入在整個簡報中全域置換字型以及在渲染時暫時置換的功能。

Presentation 類別已引入新的屬性「FontsManager」。FontsManager 類別具有以下成員：

**IFontSubstRuleCollection FontSubstRuleList** 屬性

此集合包含用於在渲染期間替換字型的 IFontSubstRule 實例。IFontSubstRule 具有實作 IFontData 介面的 SourceFont 與 DestFont 屬性，以及 ReplaceFontCondition 屬性，可選擇替換條件（「WhenInaccessible」或「Always」）。

**IFontData[] GetFonts()** 方法

用於取得目前簡報中使用的所有字型。

**ReplaceFont** 方法

用於在簡報中持續性地置換字型。

以下範例示範如何在簡報中置換字型：

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


             Presentation pres = new Presentation("PresContainsArialFont.pptx");

            IFontData sourceFont = new FontData("Arial");

            IFontData destFont = new FontData("Times New Roman");

            pres.FontsManager.ReplaceFont(sourceFont, destFont);

            pres.Save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);


```

另一個範例展示在無法取得時的渲染字型替換：

``` csharp
using Aspose.Slides;


             Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

            IFontData sourceFont = new FontData("SomeRareFont");

            IFontData destFont = new FontData("Arial");

            IFontSubstRule fontSubstRule = new FontSubstRule(

                sourceFont, destFont, FontSubstCondition.WhenInaccessible);

            IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

            fontSubstRuleCollection.Add(fontSubstRule);

            pres.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

            // Arial 字型會在無法取得 SomeRareFont 時被使用

            pres.Slides[0].GetImage();

```