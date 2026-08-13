---
title: 在 .NET 中設定後備字型集合
linktitle: 後備字型集合
type: docs
weight: 20
url: /zh-hant/net/create-fallback-fonts-collection/
keywords:
- 後備字型
- 後備規則
- 字型集合
- 設定字型
- 配置字型
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中設定後備字型集合，以確保 PowerPoint 與 OpenDocument 簡報中的文字保持一致且清晰。"
---
## **概述**

Aspose.Slides 允許您為簡報配置一組後備字型規則的集合。每個後備規則由 `FontFallBackRule` 類別表示，且可加入 `FontFallBackRulesCollection`，該集合實作 `IFontFallBackRulesCollection` 介面。  
建立集合後，您可以將其指派給簡報之 `FontsManager` 的 `FontFallBackRulesCollection` 屬性。`FontsManager` 負責管理整個簡報的字型，而每個 `Presentation` 實例都有其自己的 `FontsManager`。  
一旦 `FontsManager` 使用後備字型集合進行初始化，指定的後備字型將於簡報呈現時套用。

## **套用後備規則**

`FontFallBackRule` 類別的實例可以組織到 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontfallbackrulescollection) 中，該集合實作 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifontfallbackrulescollection) 介面。可以在集合中新增或移除規則。  

接著，可將此集合指派給 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) 屬性（屬於 [FontsManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager) 類別）。`FontsManager` 控制簡報中的字型。  

每個 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 都有一個 [FontsManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/properties/fontsmanager) 屬性，內含其自己的 `FontsManager` 類別實例。  

以下是建立後備字型規則集合並指派至特定簡報的 `FontsManager` 的範例：

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

在 `FontsManager` 使用後備字型集合初始化後，後備字型將於簡報呈現時套用。

{{% alert color="info" %}} 
閱讀更多有關 [Render Presentation with Fallback Font](/slides/zh-hant/net/render-presentation-with-fallback-font/) 的說明。 
{{% /alert %}}

## **常見問題**

### 我的後備規則會嵌入 PPTX 檔案並在儲存後於 PowerPoint 中顯示嗎？

不會。後備規則屬於執行時的呈現設定，未序列化至 PPTX，亦不會在 PowerPoint 介面中出現。

### 後備機制是否適用於 SmartArt、WordArt、圖表與表格中的文字？

是。這些物件中的所有文字皆使用相同的字形置換機制。

### Aspose 是否隨函式庫一起分發任何字型？

不會。字型需由您自行加入並使用，且風險由您自行承擔。

### 缺字型的替換/置換機制與缺字形的後備機制可以同時使用嗎？

可以。它們是同一字型解析流程中相互獨立的階段：首先引擎會解析字型可用性（[replacement](/slides/zh-hant/net/font-replacement/)/[substitution](/slides/zh-hant/net/font-substitution/)），接著後備機制會為可用字型中缺少的字形填補空缺。