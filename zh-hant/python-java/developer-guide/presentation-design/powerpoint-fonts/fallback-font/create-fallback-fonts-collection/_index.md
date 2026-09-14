---
title: 在 Python 中透過 Java 配置回退字型集合
linktitle: 回退字型集合
type: docs
weight: 20
url: /zh-hant/python-java/create-fallback-fonts-collection/
keywords:
- 回退字型
- 回退規則
- 字型集合
- 配置字型
- 設定字型
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Python via Java 中設置回退字型集合，以確保 PowerPoint 與 OpenDocument 簡報的文字保持一致且清晰。"
---
## **概述**

Aspose.Slides 允許您為簡報設定一組回退字型規則的集合。每個回退規則由 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontfallbackrule/) 類別表示，且可加入至 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontfallbackrulescollection/)。

建立集合後，您可以透過簡報的 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/) 的 [setFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) 方法將其指派。[FontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/) 控制整個簡報的字型，而每個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例都有自己的 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/)。

一旦使用回退字型集合初始化 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/)，在簡報呈現過程中就會套用指定的回退字型。

## **套用回退規則**

可以將 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontfallbackrule/) 類別的實例組織成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontfallbackrulescollection/)。您可以在集合中新增或移除規則。

然後可透過 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/) 類別的 [setFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) 方法將此集合指派，該類別控制簡報的字型。

每個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 都有一個 [getFontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getFontsManager) 方法，可回傳其自身的 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/) 類別實例。

以下範例示範如何建立回退字型規則集合並將其指派給簡報的 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/)：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, Presentation

presentation = Presentation()
try:
    fallback_rules = FontFallBackRulesCollection()

    tamil_rule = FontFallBackRule(0x0B80, 0x0BFF, "Vijaya")
    fallback_rules.add(tamil_rule)
    hiragana_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")
    fallback_rules.add(hiragana_rule)

    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)
finally:
    presentation.dispose()
```

在使用回退字型集合初始化 [FontsManager](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontsmanager/) 後，回退字型會在簡報呈現時套用。

{{% alert color="info" title="Note" %}}
閱讀更多關於如何 [以回退字型呈現簡報](/slides/zh-hant/python-java/render-presentation-with-fallback-font/) 的資訊。
{{% /alert %}}

## **常見問題**

**我的回退規則會被嵌入 PPTX 檔案並在儲存後於 PowerPoint 中可見嗎？**

不會。回退規則是執行時的呈現設定；它們不會序列化至 PPTX，也不會在 PowerPoint 的使用者介面中顯示。

**回退規則會套用於 SmartArt、WordArt、圖表和表格中的文字嗎？**

是的。這些物件中的所有文字皆使用相同的字形替換機制。

**Aspose 是否會隨函式庫一起分發任何字型？**

不會。字型須由您自行加入並使用，您自行負責。

**缺少字型的替換/替代與缺少字形的回退可以同時使用嗎？**

可以。它們是同一字型解析流程中獨立的階段：首先引擎解決字型可用性（[replacement](/slides/zh-hant/python-java/font-replacement/)/[substitution](/slides/zh-hant/python-java/font-substitution/)），接著回退會填補可用字型中缺少的字形。