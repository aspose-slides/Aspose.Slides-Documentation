---
title: 為簡報在 Python 中指定備援字型
linktitle: 備援字型
type: docs
weight: 10
url: /zh-hant/python-net/create-fallback-font/
keywords:
- 備援字型
- 備援規則
- 套用字型
- 替換字型
- Unicode 範圍
- 缺少的字形
- 正確的字形
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "透過 .NET 的 Aspose.Slides for Python，設定 PPT、PPTX 與 ODP 檔案的備援字型，確保在任何裝置或作業系統上均能一致顯示文字。"
---
## **概述**

Aspose.Slides 允許您在簡報渲染和匯出操作中指定備援字型。當主要字型不含特定字元的字形時，會使用備援字型。

備援行為透過備援規則來設定。每個規則將 Unicode 範圍與可能包含所需字形的一個或多個字型關聯。您可以為不同的字元範圍定義規則、在現有規則中新增或移除備援字型，並將多個規則組織在備援字型規則集合中。

備援規則是執行時的渲染設定。它們不會修改簡報檔本身，也不會儲存在 PPTX 檔內。

## **指定備援字型**

Aspose.Slides 支援 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/FontFallBackRule/) 類別，以指定套用備援字型的規則。[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/FontFallBackRule/) 類別代表指定的 Unicode 範圍（用於搜尋缺少的字形）與可能包含正確字形的字型清單之間的關聯：

```py
startUnicodeIndex = 0x0B80
endUnicodeIndex = 0x0BFF

firstRule = slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya")
secondRule = slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic")

#使用多種方式可以加入字型清單:
fontNames =  ["Segoe UI Emoji, Segoe UI Symbol", "Arial" ]

thirdRule = slides.FontFallBackRule(0x1F300, 0x1F64F, fontNames)
```



也可以 [remove](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontfallbackrule/remove/) 備援字型或 [add_fall_back_fonts](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontfallbackrule/add_fall_back_fonts/) 到現有的 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/FontFallBackRule/) 物件。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontfallbackrulescollection/) 可用於組織一系列 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/FontFallBackRule/) 物件，當需要為多個 Unicode 範圍指定備援字型置換規則時。

{{% alert color="primary" title="另請參閱" %}} 
- [建立備援字型集合](/slides/zh-hant/python-net/create-fallback-fonts-collection/)
{{% /alert %}}

## **常見問題**

**備援字型、字型替代與字型嵌入之間有何差異？**

備援字型僅在主要字型缺少特定字元時使用。[字型替代](/slides/zh-hant/python-net/font-substitution/) 會將整個指定的字型替換為另一個字型。[字型嵌入](/slides/zh-hant/python-net/embedded-font/) 則將字型封裝在輸出檔案中，使接收者能如預期般檢視文字。

**備援字型是否會在 PDF、PNG 或 SVG 等匯出時套用，還是僅在螢幕渲染時生效？**

會。備援會影響所有 [渲染與匯出操作](/slides/zh-hant/python-net/convert-presentation/)，只要必須繪製卻在來源字型中缺失的字元，都會使用備援字型。

**設定備援會改變簡報檔本身嗎？設定會在之後的開啟中持久保存嗎？**

不會。備援規則是您程式碼中的執行時渲染設定，並不會儲存在 .pptx 中，也不會出現在 PowerPoint 中。

**作業系統 (Windows/Linux/macOS) 以及字型目錄的設定會影響備援字型的選擇嗎？**

會。引擎會從可用的系統資料夾以及您提供的任何 [其他路徑](/slides/zh-hant/python-net/custom-font/) 中解析字型。如果字型實際上不存在，引用該字型的規則將無法生效。

**備援字型是否適用於 WordArt、SmartArt 與圖表？**

會。當這些物件包含文字時，會使用相同的字形替代機制來渲染缺少的字元。