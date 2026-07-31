---
title: 在 C++ 中設定備援字型集合
linktitle: 備援字型集合
type: docs
weight: 20
url: /zh-hant/cpp/create-fallback-fonts-collection/
keywords:
- 備援字型
- 備援規則
- 字型集合
- 配置字型
- 設定字型
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中設定備援字型集合，以確保 PowerPoint 與 OpenDocument 簡報中的文字保持一致且清晰。"
---
## **概觀**

Aspose.Slides 允許您為簡報設定一組備援字型規則。每個備援規則由 `FontFallBackRule` 類別表示，並可加入 `FontFallBackRulesCollection`，該集合實作 `IFontFallBackRulesCollection` 介面。

建立集合後，您可以透過簡報的 `FontsManager` 的 `set_FontFallBackRulesCollection` 方法指派它。`FontsManager` 會控制整個簡報的字型，而每個 `Presentation` 實例都有自己的 `FontsManager`。

當 `FontsManager` 使用備援字型集合初始化後，指定的備援字型將在簡報渲染時套用。

## **套用備援規則**

[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/) 類別的實例可以組成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrulescollection/)，該集合實作 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontfallbackrulescollection/) 介面。您可以在集合中新增或移除規則。

然後將此集合傳遞給 [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) 方法，該方法屬於 [FontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/) 類別。FontsManager 控制簡報中的字型。

每個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 皆有一個 [get_FontsManager()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_fontsmanager/) 方法，提供其自己的 FontsManager 實例。

以下是一個建立備援字型規則集合並指派至特定簡報的 FontsManager 的範例：

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

當 FontsManager 使用備援字型集合初始化後，備援字型將在簡報渲染時套用。

{{% alert color="primary" %}} 
了解更多如何[Render Presentation with Fallback Font](/slides/zh-hant/cpp/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **常見問題**

**我的備援規則會嵌入 PPTX 檔案並在 PowerPoint 中保存後可見嗎？**

不會。備援規則是執行時的渲染設定，不會序列化到 PPTX 中，也不會出現在 PowerPoint 的 UI 中。

**備援會套用於 SmartArt、WordArt、圖表和表格中的文字嗎？**

會。相同的字形替換機制會用於這些物件中的任何文字。

**Aspose 會隨函式庫一起分發任何字型嗎？**

不會。字型須由您自行加入並使用，並自行負責。

**缺少字型的替換/置換與缺少字形的備援可以同時使用嗎？**

可以。它們是同一字型解析管線的獨立階段：首先引擎解析字型可用性（[replacement](/slides/zh-hant/cpp/font-replacement/)/[substitution](/slides/zh-hant/cpp/font-substitution/)），然後備援會填補可用字型中缺少的字形。