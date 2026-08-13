---
title: 在 Java 中為簡報指定備援字型
linktitle: 備援字型
type: docs
weight: 10
url: /zh-hant/java/create-fallback-font/
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
- Java
- Aspose.Slides
description: "精通 Aspose.Slides for Java，設定 PPT、PPTX 與 ODP 檔案的備援字型，確保在任何設備或作業系統上均能一致顯示文字。"
---
## **概觀**

Aspose.Slides 允許您為簡報的渲染和匯出操作指定備援字型。當主要字型未包含特定字元的字形時，會使用備援字型。

備援行為透過備援規則來設定。每條規則將 Unicode 範圍與可能包含所需字形的一個或多個字型關聯起來。您可以為不同字元範圍定義規則、在現有規則中新增或移除備援字型，並將多條規則組織在備援字型規則集合中。

備援規則是執行期的渲染設定。它們不會修改簡報檔本身，也不會儲存在 PPTX 檔內。

## **備援規則**

Aspose.Slides 支援 [IFontFallBackRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IFontFallBackRule) 介面和 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule) 類別，以指定套用備援字型的規則。[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule) 類別 表示指定的 Unicode 範圍（用於搜尋缺少的字形）與可能包含正確字形的字型清單之間的關聯：

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//使用多種方式可以新增字型清單:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

也可以 [remove](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 備援字型或 [addFallBackFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 到現有的 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule) 物件。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRulesCollection) 可用於組織一系列的 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule) 物件，當需要為多個 Unicode 範圍指定備援字型取代規則時。

{{% alert color="info" title="另請參閱" %}} 
- [Create Fallback Fonts Collection](/slides/zh-hant/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **常見問答**

### 備援字型、字型替換與字型嵌入有何不同？

備援字型僅在主要字型缺少字元時使用。[字型替換](/slides/zh-hant/java/font-substitution/) 會將整個指定的字型替換為另一個字型。[字型嵌入](/slides/zh-hant/java/embedded-font/) 則會將字型打包到輸出檔案中，讓接收者能如預期顯示文字。

### 備援字型是只在畫面上渲染時使用，還是也會在 PDF、PNG、SVG 等匯出時套用？

會。備援會影響所有需要繪製但來源字型不存在字形的 [渲染與匯出操作](/slides/zh-hant/java/convert-presentation/)。

### 設定備援會修改簡報檔本身嗎？此設定會在未來開啟時保留嗎？

不會。備援規則是您程式碼中的執行期渲染設定；它們不會儲存在 .pptx 中，也不會在 PowerPoint 中顯示。

### 作業系統 (Windows/Linux/macOS) 與字型目錄集合會影響備援選擇嗎？

會。引擎會從系統可用的資料夾以及您提供的任何 [額外路徑](/slides/zh-hant/java/custom-font/) 中解析字型。如果字型實際上不存在，引用該字型的規則將無法生效。

### 備援字型會對 WordArt、SmartArt 與圖表起作用嗎？

會。當這些物件包含文字時，會套用相同的字形替換機制來渲染缺少的字元。