---
title: Aspose.Slides for Java 15.1.0 的公共 API 與向後不相容變更
linktitle: Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公共 API 更新與破壞性變更，順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有[已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)的類別、方法、屬性等，以及任何新的限制和其他[變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)，這些都是在 Aspose.Slides for Java 15.1.0 API 中引入的。

{{% /alert %}} {{% alert color="primary" %}} 

已知某些圖像項目符號和 WordArt 物件存在問題，將在 Aspose.Slides for Java 15.2.0 中修復。

{{% /alert %}} 
## **公共 API 變更**
### **已新增字型替換功能**
已新增在整個簡報中全域取代字型以及在渲染期間暫時取代字型的功能。

已在 Presentation 類別中引入新方法 getFontsManager()。FontsManager 類別具有以下成員：

**IFontSubstRuleCollection getFontSubstRuleList**() method

這是用於在渲染期間替換字型的 IFontSubstRule 實例集合。IFontSubstRule 具備實作 IFontData 介面的 getSourceFont() 與 getDestFont() 方法，以及 getReplaceFontCondition() 方法，可用於選擇替換的條件（「WhenInaccessible」或「Always」）。

**IFontData[] getFonts()** method can be used to retrieve all fonts used in the current presentation.

**replaceFont(...)** methods can be used to persistently replace a font in a presentation.

以下範例示範如何在簡報中取代字型：

``` java

 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

另一個範例顯示在渲染時字型不可用時的字型替換：

``` java



Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");

IFontData sourceFont = new FontData("SomeRareFont");

IFontData destFont = new FontData("Arial");

IFontSubstRule fontSubstRule = new FontSubstRule(

sourceFont, destFont, FontSubstCondition.WhenInaccessible);

IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();

fontSubstRuleCollection.add(fontSubstRule);

pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

// 當無法使用 SomeRareFont 時，將使用 Arial 字型

pres.getSlides().get_Item(0).getThumbnail(1, 1);

```