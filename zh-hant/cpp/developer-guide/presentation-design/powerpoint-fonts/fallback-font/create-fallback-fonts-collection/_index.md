---
title: 在 C++ 中配置備用字型集合
linktitle: 備用字型集合
type: docs
weight: 20
url: /zh-hant/cpp/create-fallback-fonts-collection/
keywords:
- 備用字型
- 備用規則
- 字型集合
- 配置字型
- 設定字型
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides 中為 C++ 設置備用字型集合，以確保 PowerPoint 和 OpenDocument 簡報中的文字保持一致且清晰。"
---
## **概觀**

Aspose.Slides 允許您為簡報配置備用字型規則的集合。每個備用規則由 `FontFallBackRule` 類別表示，可加入 `FontFallBackRulesCollection` 中，該集合實作 `IFontFallBackRulesCollection` 介面。

建立集合後，您可以使用簡報的 `FontsManager` 的 `set_FontFallBackRulesCollection` 方法將其指派。`FontsManager` 負責管理整個簡報的字型，而每個 `Presentation` 實例都有自己的 `FontsManager`。

一旦 `FontsManager` 使用備用字型集合初始化，指定的備用字型將在簡報渲染過程中套用。

## **套用備用規則**

`FontFallBackRule` 類別的實例可組織成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrulescollection/)，該集合實作 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontfallbackrulescollection/) 介面。可以在集合中新增或移除規則。

然後可將此集合傳遞給 [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) 方法，屬於 [FontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/) 類別。FontsManager 控制整個簡報的字型。

每個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 都有一個 [get_FontsManager()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_fontsmanager/) 方法，提供自己的 `FontsManager` 實例。

以下是建立備用字型規則集合並指派至特定簡報的 `FontsManager` 的範例：

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

在 `FontsManager` 使用備用字型集合初始化後，備用字型將在簡報渲染期間套用。

{{% alert color="primary" %}} 
了解更多關於 [Render Presentation with Fallback Font](/slides/zh-hant/cpp/render-presentation-with-fallback-font/) 的資訊。
{{% /alert %}}

## **常見問題**

**我的備用規則會嵌入 PPTX 檔案並在儲存後於 PowerPoint 中可見嗎？**

不會。備用規則屬於執行時的渲染設定，不會序列化至 PPTX，亦不會出現在 PowerPoint 的使用者介面中。

**備用規則是否套用於 SmartArt、WordArt、圖表與表格內的文字？**

會。相同的字形替換機制會用於這些物件內的任何文字。

**Aspose 會隨函式庫一同分發任何字型嗎？**

不會。您需要自行提供並使用字型，且需自行負責相關授權。

**缺字字型的替換/替代與缺字形的備用可以同時使用嗎？**

可以。它們是相同字型解析管線的獨立階段：首先引擎會解析字型可用性（[replacement](/slides/zh-hant/cpp/font-replacement/)/[substitution](/slides/zh-hant/cpp/font-substitution/)），然後備用機制會填補可用字型中缺少的字形。