---
title: 在 .NET 中為簡報指定備援字型
linktitle: 備援字型
type: docs
weight: 10
url: /zh-hant/net/create-fallback-font/
keywords:
  - 備援字型
  - 備援規則
  - 套用字型
  - 取代字型
  - Unicode 範圍
  - 缺失字形
  - 正確字形
  - PowerPoint
  - OpenDocument
  - 簡報
  - .NET
  - C#
  - Aspose.Slides
description: "精通 Aspose.Slides for .NET，設定 PPT、PPTX 與 ODP 檔案的備援字型，確保在任何裝置或作業系統上文字顯示一致。"
---
## **概述**

Aspose.Slides 允許您為簡報的呈現和匯出操作指定備援字型。當主要字型不包含特定字元的字形時，會使用備援字型。

備援行為是透過備援規則來設定。每個規則會將 Unicode 範圍與一個或多個可能包含所需字形的字型關聯起來。您可以為不同的字元範圍定義規則、從現有規則中新增或移除備援字型，並在備援字型規則集合中組織多個規則。

備援規則屬於執行時的呈現設定。它們不會修改簡報檔本身，也不會儲存在 PPTX 檔案中。

## **備援規則**

Aspose.Slides 支援 [IFontFallBackRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iFontFallBackRule) 介面和 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/FontFallBackRule) 類別，用來指定套用備援字型的規則。[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/FontFallBackRule) 類別代表在指定的 Unicode 範圍（用於搜尋缺失的字形）與可能包含正確字形的字型清單之間的關聯：

```c#
using Aspose.Slides;

uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");


//使用多種方式新增字型清單:
string[] fontNames = new string[] { "Segoe UI Emoji, Segue UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

您也可以 [Remove()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifontfallbackrule/methods/remove) 移除備援字型，或將 [AddFallBackFonts()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 新增至現有的 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/FontFallBackRule) 物件中。

可使用 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontfallbackrulescollection) 來組織 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/FontFallBackRule) 物件的清單，當需要為多個 Unicode 範圍指定備援字型替換規則時。

{{% alert color="info" title="另請參閱" %}} 
- [Create Fallback Fonts Collection](/slides/zh-hant/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **常見問題**

### 備援字型、字型替換與字型嵌入有何不同？

備援字型僅在主要字型缺少某些字元時使用。[字型替換](/slides/zh-hant/net/font-substitution/) 會將整個指定的字型替換為另一個字型。[字型嵌入](/slides/zh-hant/net/embedded-font/) 則將字型打包於輸出檔案中，使接收者能如預期般檢視文字。

### 備援字型是適用於 PDF、PNG、SVG 等匯出時，還是僅在螢幕呈現時套用？

是的。備援會影響所有在[呈現與匯出操作](/slides/zh-hant/net/convert-presentation/)中必須繪製但來源字型中缺少的字元。

### 設定備援會修改簡報檔本身嗎？此設定會在未來開啟時持續存在嗎？

不會。備援規則是您程式碼中的執行時呈現設定；它們不會儲存在 .pptx 中，也不會在 PowerPoint 中顯示。

### 作業系統（Windows/Linux/macOS）及字型目錄集合會影響備援選擇嗎？

會。引擎會從可用的系統資料夾以及您提供的任何[額外路徑](/slides/zh-hant/net/custom-font/)中解析字型。如果字型實際上不可用，則引用該字型的規則無法生效。

### 備援字型在 WordArt、SmartArt 與圖表上是否也會生效？

會。當這些物件包含文字時，會套用相同的字形替換機制來呈現缺失的字元。