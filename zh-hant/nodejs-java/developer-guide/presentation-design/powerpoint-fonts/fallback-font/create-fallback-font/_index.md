---
title: 在 JavaScript 中為簡報指定備用字型
linktitle: 備用字型
type: docs
weight: 10
url: /zh-hant/nodejs-java/create-fallback-font/
keywords:
- 備用字型
- 備用規則
- 套用字型
- 取代字型
- Unicode 範圍
- 缺失字形
- 正確字形
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "精通 Aspose.Slides for Node.js，在 JavaScript 中為 PPT、PPTX 和 ODP 檔案設定備用字型，確保在任何裝置或作業系統上文字顯示一致。"
---
## **概觀**

Aspose.Slides 允許您為簡報的渲染和匯出操作指定備用字型。當主要字型不包含特定字元的字形時，會使用備用字型。

備用行為是透過備用規則進行設定。每個規則會將 Unicode 範圍與一個或多個可能包含所需字形的字型關聯起來。您可以為不同的字元範圍定義規則，從現有規則中新增或移除備用字型，並將多個規則組織在備用字型規則集合中。

備用規則是執行期間的渲染設定。它們不會修改簡報檔本身，也不會儲存在 PPTX 檔案中。

## **備用規則**

Aspose.Slides 支援 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontFallBackRule) 類別，以指定套用備用字型的規則。[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontFallBackRule) 類別表示指定的 Unicode 範圍（用於搜尋缺失的字形）與可能包含正確字形的字型清單之間的關聯：

```javascript
var startUnicodeIndex = 0xb80;
var endUnicodeIndex = 0xbff;
var firstRule = new aspose.slides.FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
var secondRule = new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
// 使用多種方式可加入字型清單：
var fontNames = java.newArray("java.lang.String", ["Segoe UI Emoji, Segoe UI Symbol", "Arial"]));
var thirdRule = new aspose.slides.FontFallBackRule(0x1f300, 0x1f64f, fontNames);
```

您也可以[移除](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) 備用字型或將[addFallBackFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 加入現有的 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontFallBackRule) 物件中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontFallBackRulesCollection) 可用於組織一系列 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontFallBackRule) 物件，當需要為多個 Unicode 範圍指定備用字型置換規則時。

{{% alert color="primary" title="另請參閱" %}} 
- [建立備用字型集合](/slides/zh-hant/nodejs-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **常見問題**

**備用字型、字型取代和字型嵌入之間有何差異？**

備用字型僅在主要字型缺少字元時使用。[字型取代](/slides/zh-hant/nodejs-java/font-substitution/) 會將整個指定的字型替換為另一個字型。[字型嵌入](/slides/zh-hant/nodejs-java/embedded-font/) 會將字型打包在輸出檔案中，讓接收者能如預期顯示文字。

**備用字型是於 PDF、PNG、SVG 等匯出時套用，還是僅在螢幕渲染時套用？**

是的。備用機制會影響所有需要繪製但來源字型中缺少字元的[渲染與匯出操作](/slides/zh-hant/nodejs-java/convert-presentation/)。

**設定備用會變更簡報檔本身嗎？此設定在未來開啟時會持續存在嗎？**

否。備用規則是您程式碼中的執行期間渲染設定；它們不會儲存在 .pptx 檔案內，也不會在 PowerPoint 中顯示。

**作業系統（Windows / Linux / macOS）及字型目錄集合會影響備用字型的選擇嗎？**

會。引擎會從可用的系統資料夾以及您提供的任何[其他路徑](/slides/zh-hant/nodejs-java/custom-font/)中解析字型。如果字型實際上不存在，則引用該字型的規則不會生效。

**備用機制在 WordArt、SmartArt 與圖表中也能作用嗎？**

會。當這些物件包含文字時，會套用相同的字形取代機制以渲染缺失的字元。