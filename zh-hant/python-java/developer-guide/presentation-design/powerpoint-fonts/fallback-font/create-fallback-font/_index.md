---
title: 為 Python 透過 Java 的簡報指定備用字型
linktitle: 備用字型
type: docs
weight: 10
url: /zh-hant/python-java/create-fallback-font/
keywords:
- 備用字型
- 備用規則
- 套用字型
- 替換字型
- Unicode 範圍
- 缺失字形
- 正確字形
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "精通 Aspose.Slides for Python via Java，於 PPT、PPTX 與 ODP 檔案中設定備用字型，確保文字在任何裝置或作業系統上皆能一致顯示。"
---
## **概述**

Aspose.Slides 允許您為簡報的呈現和匯出作業指定備用字型。當主要字型不包含特定字元的字形時，會使用備用字型。

備用行為是透過備用規則設定的。每個規則會將 Unicode 範圍與可能包含所需字形的一個或多個字型關聯。您可以為不同字元範圍定義規則、從現有規則中新增或移除備用字型，並在備用字型規則集合中組織多個規則。

備用規則是執行時的呈現設定。它們不會修改簡報檔本身，也不會儲存在 PPTX 檔案中。

## **備用規則**

Aspose.Slides 提供 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontfallbackrule/) 類別，以指定套用備用字型的規則。此類別代表用於搜尋遺失字形的 Unicode 範圍與可能包含所需字形的字型清單之間的關聯：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule

start_unicode_index = 0x0B80
end_unicode_index = 0x0BFF

first_rule = FontFallBackRule(start_unicode_index, end_unicode_index, "Vijaya")
second_rule = FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

# 使用多種方式指定字型清單。
font_names = jpype.JArray(jpype.JString)(["Segoe UI Emoji, Segoe UI Symbol", "Arial"])

third_rule = FontFallBackRule(0x1F300, 0x1F64F, font_names)
```

您也可以使用 [remove](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontfallbackrule/#remove) 移除備用字型，或在現有的 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontfallbackrule/) 物件中使用 [addFallBackFonts](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) 新增備用字型。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontfallbackrulescollection/) 可在需要為多個 Unicode 範圍指定備用字型替換規則時，組織一系列 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/fontfallbackrule/) 物件。

{{% alert color="info" title="另見" %}} 
- [建立備用字型集合](/slides/zh-hant/python-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **常見問題**

**備用字型、字型替換與字型嵌入之間有何差異？**

備用字型僅用於主要字型缺少的字元。[字型替換](/slides/zh-hant/python-java/font-substitution/) 會將整個指定的字型替換為另一個字型。[字型嵌入](/slides/zh-hant/python-java/embedded-font/) 將字型封裝在輸出檔案內，使收件者能如預期般檢視文字。

**備用字型是在匯出（如 PDF、PNG、SVG）時套用，還是僅在螢幕呈現時使用？**

是的。備用字型會影響所有需要繪製但在來源字型中不存在的字元的[呈現與匯出作業](/slides/zh-hant/python-java/convert-presentation/)。

**設定備用字型會變更簡報檔本身嗎？此設定在未來開啟時會保持嗎？**

不會。備用規則是您程式碼中的執行時呈現設定，並不會儲存在 .pptx 檔內，也不會在 PowerPoint 中顯示。

**作業系統（Windows / Linux / macOS）以及字型目錄的設定會影響備用字型的選取嗎？**

會。引擎會從可用的系統資料夾以及您提供的任何[額外路徑](/slides/zh-hant/python-java/custom-font/)中解析字型。若字型實際不存在，則引用該字型的規則不會生效。

**備用字型適用於 WordArt、SmartArt 及圖表嗎？**

會。當這些物件包含文字時，會使用相同的字形替換機制來呈現缺失的字元。