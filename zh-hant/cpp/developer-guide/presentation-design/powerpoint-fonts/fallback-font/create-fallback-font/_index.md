---
title: 在 C++ 中為簡報指定備援字體
linktitle: 備援字體
type: docs
weight: 10
url: /zh-hant/cpp/create-fallback-font/
keywords:
- 備援字體
- 備援規則
- 套用字體
- 替換字體
- Unicode 範圍
- 缺少的字形
- 正確的字形
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "精通 Aspose.Slides for C++，在 PPT、PPTX 與 ODP 檔案中設定備援字體，確保在任何裝置或作業系統上文字顯示一致。"
---
## **概觀**

Aspose.Slides 允許您為簡報的渲染與匯出操作指定備援字體。當主要字體未包含特定字元的字形時，會使用備援字體。

備援行為透過備援規則進行設定。每個規則會將 Unicode 範圍與一個或多個可能包含所需字形的字體關聯起來。您可以為不同的字元範圍定義規則、在現有規則中新增或移除備援字體，並在備援字體規則集合中組織多個規則。

備援規則是執行期間的渲染設定。它們不會修改簡報檔本身，也不會儲存於 PPTX 檔案中。

## **備援規則**

Aspose.Slides 支援 [IFontFallBackRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontfallbackrule/) 介面與 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/) 類別，以指定套用備援字體的規則。[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/) 類別代表指定的 Unicode 範圍（用於搜尋缺少的字形）與可能包含正確字形的字體清單之間的關聯：

``` cpp
#include <DOM/Fonts/FontFallBackRule.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

uint32_t startUnicodeIndex = 0x0B80;
uint32_t endUnicodeIndex = 0x0BFF;

auto firstRule = MakeObject<FontFallBackRule>(startUnicodeIndex, endUnicodeIndex, u"Vijaya");
auto secondRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic");

// Using multiple ways you can add fonts list:
auto fontNames = MakeArray<String>({ u"Segoe UI Emoji, Segoe UI Symbol", u"Arial" });

auto thirdRule = MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x1F300), static_cast<uint32_t>(0x1F64F), fontNames);
```

也可以使用 [Remove()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontfallbackrule/remove/) 移除備援字體，或將 [AddFallBackFonts()](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ifontfallbackrule/addfallbackfonts/) 新增至現有的 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/) 物件。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrulescollection/) 可用於組織一系列 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontfallbackrule/) 物件，當需要為多個 Unicode 範圍指定備援字體替換規則時。

{{% alert color="info" title="另見" %}} 
- [建立備援字體集合](/slides/zh-hant/cpp/create-fallback-fonts-collection/)
{{% /alert %}}

## **常見問題**

### 備援字體、字體取代與字體嵌入之差異為何？

備援字體僅在主要字體缺少特定字元時使用。[字體取代](/slides/zh-hant/cpp/font-substitution/) 會將整個指定的字體換成另一個字體。[字體嵌入](/slides/zh-hant/cpp/embedded-font/) 則將字體封裝在輸出檔案中，使接收者能如預期顯示文字。

### 備援字體是否僅在畫面渲染時套用，還是會影響 PDF、PNG、SVG 等匯出？

會。備援會影響所有需要繪製但來源字體中不存在該字元的 [渲染與匯出操作](/slides/zh-hant/cpp/convert-presentation/)。

### 設定備援會修改簡報檔本身嗎？設定會在未來開啟時保留嗎？

不會。備援規則是您程式碼中的執行期間渲染設定，並不會儲存在 .pptx 檔案中，也不會出現在 PowerPoint 中。

### 作業系統 (Windows/Linux/macOS) 與字體目錄集合會影響備援字體的選擇嗎？

會。引擎會從系統可用的資料夾以及您提供的任何 [其他路徑](/slides/zh-hant/cpp/custom-font/) 中解析字體。如果字體實際上不存在，引用該字體的規則將無法生效。

### 備援是否適用於 WordArt、SmartArt 與圖表？

會。當這些物件包含文字時，會套用相同的字形取代機制來渲染缺少的字元。