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
- 遺失字形
- 正確字形
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "精通 Aspose.Slides for .NET，以在 PPT、PPTX 與 ODP 檔案中設定備援字型，確保文字在任何裝置或作業系統上都能一致顯示。"
---
## **概觀**

Aspose.Slides 允許您為投影片的呈現與匯出操作指定備援字型。當主要字型未包含特定字元的字形時，會使用備援字型。

備援行為透過備援規則進行設定。每項規則會將 Unicode 範圍與一個或多個可能包含所需字形的字型關聯。您可以為不同的字元範圍定義規則、在現有規則中新增或移除備援字型，並在備援字型規則集合中組織多個規則。

備援規則屬於執行時的呈現設定。它們不會更改投影片檔本身，也不會儲存在 PPTX 檔案中。

## **備援規則**

Aspose.Slides 支援 [IFontFallBackRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iFontFallBackRule) 介面與 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/FontFallBackRule) 類別，以指定套用備援字型的規則。[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/FontFallBackRule) 類別代表指定的 Unicode 範圍（用於搜尋遺失的字形）與可能包含正確字形的字型清單之關聯：

```c#
uint startUnicodeIndex = 0x0B80;
uint endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//使用多種方式即可加入字型清單:
string[] fontNames = new string[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

也可以使用 [Remove()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ifontfallbackrule/methods/remove) 移除備援字型，或將 [AddFallBackFonts()](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontfallbackrule/methods/addfallbackfonts) 新增至現有的 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/FontFallBackRule) 物件中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontfallbackrulescollection)[ ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/fontfallbackrulescollection) 可用於組織 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/FontFallBackRule) 物件的清單，當需要為多個 Unicode 範圍指定備援字型替換規則時。

{{% alert color="primary" title="See also" %}} 
- [建立備援字型集合](/slides/zh-hant/net/create-fallback-fonts-collection/)
{{% /alert %}}

## **常見問題**

**備援字型、字型替換與字型嵌入之差異為何？**

備援字型僅在主要字型缺少特定字元時使用。[字型替換](/slides/zh-hant/net/font-substitution/) 會將整個指定的字型取代為另一個字型。[字型嵌入](/slides/zh-hant/net/embedded-font/) 則將字型打包在輸出檔案中，使收件者能如預期般檢視文字。

**備援字型是於匯出（如 PDF、PNG、SVG）時套用，還是僅在螢幕呈現時使用？**

是的。備援字型會影響所有需要繪製但原始字型中缺少字元的 [呈現與匯出操作](/slides/zh-hant/net/convert-presentation/)。

**設定備援會變更投影片檔本身嗎？此設定會在未來開啟時保留嗎？**

不會。備援規則是您程式碼中的執行時呈現設定；它們不會儲存在 .pptx 檔內，也不會出現在 PowerPoint 中。

**作業系統（Windows / Linux / macOS）以及字型目錄的設定會影響備援字型的選擇嗎？**

會。引擎會從可用的系統資料夾以及您提供的任何 [額外路徑](/slides/zh-hant/net/custom-font/) 中解析字型。如果字型實際上不存在，引用該字型的規則將無法生效。

**備援字型是否適用於 WordArt、SmartArt 與圖表？**

會。當這些物件包含文字時，會使用相同的字形替換機制來呈現缺少的字元。