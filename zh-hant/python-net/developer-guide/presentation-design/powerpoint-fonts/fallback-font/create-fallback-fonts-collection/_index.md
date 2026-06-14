---
title: 在 Python 中設定備援字型集合
linktitle: 備援字型集合
type: docs
weight: 20
url: /zh-hant/python-net/create-fallback-fonts-collection/
keywords:
- 備援字型
- 備援規則
- 字型集合
- 設定字型
- 設定字型
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "透過 .NET 在 Aspose.Slides for Python 中設定備援字型集合，以確保 PowerPoint 與 OpenDocument 簡報的文字保持一致且清晰。"
---
## **概觀**

Aspose.Slides 允許您為簡報設定備援字型規則的集合。每個備援規則皆由 `FontFallBackRule` 類別表示，且可加入 `FontFallBackRulesCollection`。

建立集合後，您可以將其指派給簡報的 `fonts_manager` 中的 `font_fall_back_rules_collection` 屬性。`fonts_manager` 會控制整個簡報的字型，每個 `Presentation` 實例都有其自己的 `FontsManager`。

一旦使用備援字型集合初始化 `FontsManager`，在簡報渲染過程中即會套用指定的備援字型。

## **套用備援規則**

`FontFallBackRule` 類別的實例可組織成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontfallbackrulescollection/)。可以在集合中新增或移除規則。

然後可以將此集合指派給 [font_fall_back_rules_collection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) 屬性，該屬性屬於 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsmanager/) 類別。FontsManager 會控制整個簡報的字型。

每個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 都有一個 [fonts_manager](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/fonts_manager/) 屬性，內含自己的 FontsManager 類別實例。

以下是一個範例，說明如何建立備援字型規則集合並指派至特定簡報的 FontsManager：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

在使用備援字型集合初始化 FontsManager 後，備援字型將於簡報渲染時套用。

{{% alert color="primary" %}} 
閱讀更多關於如何[使用備援字型渲染簡報](/slides/zh-hant/python-net/render-presentation-with-fallback-font/)。
{{% /alert %}}

## **常見問題**

**我的備援規則會嵌入 PPTX 檔案並在儲存後於 PowerPoint 中可見嗎？**

不會。備援規則是執行時的渲染設定，並不會序列化進 PPTX，亦不會出現在 PowerPoint 的使用者介面中。

**備援會套用在 SmartArt、WordArt、圖表與表格內的文字嗎？**

會。這些物件內的所有文字都使用相同的字形替代機制。

**Aspose 會隨函式庫一起分發任何字型嗎？**

不會。字型須由您自行加入並使用，相關責任亦由您自行承擔。

**缺字體的取代/替代與缺字形的備援可以同時使用嗎？**

可以。它們是同一字型解析管線的獨立階段：首先引擎解析字型可用性（[replacement](/slides/zh-hant/python-net/font-replacement/)/[substitution](/slides/zh-hant/python-net/font-substitution/)），接著備援會在可用字型中填補缺少的字形。