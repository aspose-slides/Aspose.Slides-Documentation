---
title: 在 .NET 中設定回退字型集合
linktitle: 回退字型集合
type: docs
weight: 20
url: /zh-hant/net/create-fallback-fonts-collection/
keywords:
- 回退字型
- 回退規則
- 字型集合
- 設定字型
- 設置字型
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中設定回退字型集合，以確保 PowerPoint 與 OpenDocument 簡報中的文字保持一致且清晰。"
---
## **Overview**

Aspose.Slides 允許您為簡報配置一組回退字型規則。每個回退規則由 `FontFallBackRule` 類別表示，並可加入 `FontFallBackRulesCollection`，該集合實作 `IFontFallBackRulesCollection` 介面。

建立集合後，您可以將其指派給簡報的 `FontsManager` 中的 `FontFallBackRulesCollection` 屬性。`FontsManager` 負責整個簡報的字型管理，而每個 `Presentation` 實例都有其自己的 `FontsManager`。

一旦使用回退字型集合初始化 `FontsManager`，指定的回退字型會在簡報渲染過程中套用。

## **套用回退規則**

[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/FontFallBackRule) 類別的實例可以組織成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontfallbackrulescollection)，該集合實作 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifontfallbackrulescollection) 介面。您可以在集合中新增或移除規則。

然後可以將此集合指派給 [FontFallBackRulesCollection ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection) 屬性，該屬性屬於 [FontsManager](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontsmanager) 類別。FontsManager 控制整個簡報的字型。

每個 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 都具有一個 [FontsManager ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/properties/fontsmanager) 屬性，內含其自己的 FontsManager 類別實例。

以下範例說明如何建立回退字型規則集合並指派至特定簡報的 FontsManager：

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

在使用回退字型集合初始化 FontsManager 後，回退字型會在簡報渲染期間套用。

{{% alert color="primary" %}} 
閱讀更多有關如何 [Render Presentation with Fallback Font](/slides/zh-hant/net/render-presentation-with-fallback-font/) 的資訊。
{{% /alert %}}

## **常見問題**

**我的回退規則會被嵌入 PPTX 檔案並在儲存後於 PowerPoint 中可見嗎？**

不會。回退規則是執行時的渲染設定，不會序列化至 PPTX，也不會在 PowerPoint 的介面中顯示。

**回退規則是否適用於 SmartArt、WordArt、圖表和表格內的文字？**

會。這些物件中的所有文字皆使用相同的字形替換機制。

**Aspose 是否隨函式庫一併分發任何字型？**

不會。字型需由您自行加入與使用，風險與責任由您自行承擔。

**缺字型的替換/替代與缺字形的回退可以同時使用嗎？**

可以。它們是同一字型解析流程中獨立的階段：首先引擎解析字型可用性（[replacement](/slides/zh-hant/net/font-replacement/)/[substitution](/slides/zh-hant/net/font-substitution/)），然後回退機制會為可用字型中缺少的字形填補空缺。