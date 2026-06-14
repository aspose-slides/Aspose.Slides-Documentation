---
title: 在 С++ 中為簡報指定備援字型
linktitle: 備援字型
type: docs
weight: 10
url: /zh-hant/cpp/create-fallback-font/
keywords:
- 備援字型
- 備援規則
- 套用字型
- 取代字型
- Unicode 範圍
- 缺少的字形
- 正確的字形
- PowerPoint
- OpenDocument
- 簡報
- С++
- Aspose.Slides
description: "精通 Aspose.Slides for С++，在 PPT、PPTX 與 ODP 檔案中設定備援字型，確保於任何裝置或作業系統上均能一致顯示文字。"
---
## **概觀**

Aspose.Slides 允許您為簡報的呈現和匯出作業指定備援字型。  
當主字型不包含特定字元的字形時，會使用備援字型。

備援行為透過備援規則設定。每個規則將 Unicode 範圍與可能含有所需字形的一個或多個字型關聯起來。您可以為不同的字元範圍定義規則、從既有規則中新增或移除備援字型，並在備援字型規則集合中組織多個規則。

備援規則是執行階段的呈現設定。它們不會修改簡報檔本身，也不會儲存在 PPTX 檔案內。

## **備援規則**

Aspose.Slides 支援 [IFontFallBackRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontfallbackrule/) 介面和 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/) 類別，以指定套用備援字型的規則。[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/) 類別表示指定的 Unicode 範圍（用於搜尋缺失的字形）與可能包含正確字形的字型清單之間的關聯：

``` cpp
uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

也可以透過 [Remove()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontfallbackrule/remove/) 移除備援字型，或將 [AddFallBackFonts()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) 新增至現有的 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/) 物件中。

當需要為多個 Unicode 範圍指定備援字型取代規則時，可使用 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrulescollection/) 來組織 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/) 物件之清單。

{{% alert color="primary" title="另請參閱" %}} 
- [建立備援字型集合](/slides/zh-hant/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **常見問題**

**備援字型、字型取代與字型嵌入有何差異？**

備援字型僅用於主字型缺少的字元。[字型取代](/slides/zh-hant/cpp/font-substitution/) 會將整個指定的字型替換為其他字型。[字型嵌入](/slides/zh-hant/cpp/embedded-font/) 將字型封裝在輸出檔案中，以便接收者能如預期般檢視文字。

**備援字型是只在螢幕渲染時套用，還是會在匯出為 PDF、PNG 或 SVG 時套用？**

是的。備援會影響所有 [呈現與匯出作業](/slides/zh-hant/cpp/convert-presentation/)，只要必須繪製但來源字型中缺少的字元，都會套用備援字型。

**設定備援會變更簡報檔本身嗎？未來開啟時此設定會持續保留嗎？**

不會。備援規則是您程式碼中的執行階段呈現設定；它們不會儲存在 .pptx 中，也不會在 PowerPoint 中顯示。

**作業系統（Windows/Linux/macOS）與字型目錄集合會影響備援字型的選擇嗎？**

會。引擎會從可用的系統資料夾以及您提供的任何 [其他路徑](/slides/zh-hant/cpp/custom-font/) 中解析字型。若字型實際上不存在，引用該字型的規則將無法生效。

**備援字型在 WordArt、SmartArt 與圖表中也會生效嗎？**

會。當這些物件包含文字時，會套用相同的字形替換機制來呈現缺失的字元。