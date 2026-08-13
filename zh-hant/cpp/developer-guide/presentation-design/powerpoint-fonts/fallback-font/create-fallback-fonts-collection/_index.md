---
title: 在 C++ 中配置回退字型集合
linktitle: 回退字型集合
type: docs
weight: 20
url: /zh-hant/cpp/create-fallback-fonts-collection/
keywords:
- 回退字型
- 回退規則
- 字型集合
- 配置字型
- 設定字型
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中設定回退字型集合，以確保 PowerPoint 與 OpenDocument 簡報中的文字保持一致且清晰。"
---
## **概觀**

Aspose.Slides 允許您為簡報配置一組回退字型規則。每個回退規則由 `FontFallBackRule` 類別表示，並可加入 `FontFallBackRulesCollection`，該集合實作 `IFontFallBackRulesCollection` 介面。

建立集合後，您可以使用簡報的 `FontsManager` 的 `set_FontFallBackRulesCollection` 方法將其指派。`FontsManager` 控制整個簡報的字型，而每個 `Presentation` 實例都有自己的 `FontsManager`。

當 `FontsManager` 以回退字型集合初始化後，指定的回退字型會在簡報渲染時套用。

## **應用回退規則**

[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/) 類別的實例可組織成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrulescollection/)，此集合實作 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontfallbackrulescollection/) 介面。您可以在集合中加入或移除規則。

然後，可將此集合傳遞給 [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) 方法，該方法屬於 [FontsManager](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsmanager/) 類別。FontsManager 控制簡報中的字型。

每個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 都有一個 [get_FontsManager()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_fontsmanager/) 方法，提供其專屬的 FontsManager 例項。

以下範例說明如何建立回退字型規則集合，並將其指派給特定簡報的 FontsManager：

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <DOM/Fonts/FontFallBackRulesCollection.h>
#include <DOM/IFontFallBackRule.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

在 FontsManager 使用回退字型集合初始化後，回退字型會在簡報渲染時套用。

{{% alert color="info" %}} 
閱讀更多關於如何 [Render Presentation with Fallback Font](/slides/zh-hant/cpp/render-presentation-with-fallback-font/) 的資訊。
{{% /alert %}}

## **常見問題**

### 我的回退規則會被嵌入 PPTX 檔案並在 PowerPoint 中保存後可見嗎？

不會。回退規則是執行時的渲染設定，不會序列化到 PPTX，也不會出現在 PowerPoint 的 UI 中。

### 回退規則會套用在 SmartArt、WordArt、圖表與表格中的文字嗎？

會。相同的字形替換機制會用於這些物件內的所有文字。

### Aspose 會隨函式庫一起分發字型嗎？

不會。字型需由您自行提供並自行負責管理。

### 缺字型的替換/置換與缺字形的回退可以同時使用嗎？

可以。它們是同一字型解析流程中獨立的階段：首先引擎解決字型可用性（[replacement](/slides/zh-hant/cpp/font-replacement/)/[substitution](/slides/zh-hant/cpp/font-substitution/)），然後回退為可用字型中缺失的字形填補空缺。