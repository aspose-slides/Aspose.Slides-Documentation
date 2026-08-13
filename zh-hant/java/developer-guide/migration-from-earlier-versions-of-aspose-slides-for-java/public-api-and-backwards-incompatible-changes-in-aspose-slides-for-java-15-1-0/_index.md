---
title: Aspose.Slides for Java 15.1.0 的公共 API 及向後相容性破壞之變更
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
description: "檢視 Aspose.Slides for Java 中的公共 API 更新與重大變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 

此頁面列出所有[已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)類別、方法、屬性等，以及在 Aspose.Slides for Java 15.1.0 API 中引入的任何新限制與其他[更改](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/)。

{{% /alert %}} {{% alert color="info" %}} 

已知在某些圖像項目符號和 WordArt 物件中存在問題，將在 Aspose.Slides for Java 15.2.0 中修復。

{{% /alert %}} 
## **公共 API 變更**
### **已新增字體替換功能**
已新增在整個簡報中全域替換字體以及在渲染時暫時替換字體的功能。

已在 Presentation 類別中引入新方法 getFontsManager()。FontsManager 類別具有以下成員：

**IFontSubstRuleCollection getFontSubstRuleList**() 方法

此集合包含在渲染期間用於替換字體的 IFontSubstRule 實例。IFontSubstRule 具備實作 IFontData 介面的 getSourceFont() 和 getDestFont() 方法，以及允許選擇替換條件（「WhenInaccessible」或「Always」）的 getReplaceFontCondition() 方法。

**IFontData[] getFonts()** 方法可用於取得目前簡報中使用的所有字體。

**replaceFont(...)** 方法可用於在簡報中永久替換字體。

以下範例示範如何在簡報中替換字體：

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

另一個範例顯示在字體無法存取時的渲染字體替換：

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // Arial 字型將在無法存取 SomeRareFont 時使用。
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```