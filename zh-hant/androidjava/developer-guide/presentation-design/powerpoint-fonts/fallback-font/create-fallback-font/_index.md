---
title: 為 Android 上的簡報指定備援字型
linktitle: 備援字型
type: docs
weight: 10
url: /zh-hant/androidjava/create-fallback-font/
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
- Android
- Java
- Aspose.Slides
description: "透過 Java 為 Android 上的 Aspose.Slides 設定 PPT、PPTX 與 ODP 檔案的備援字型，確保在任何裝置或作業系統上文字顯示一致。"
---
## **概觀**

Aspose.Slides 允許您為簡報的呈現和匯出作業指定備援字型。當主要字型未包含特定字元的字形時，會使用備援字型。

備援行為透過備援規則進行設定。每個規則會將 Unicode 範圍與一個或多個可能包含所需字形的字型關聯起來。您可以為不同的字元範圍定義規則、從現有規則中新增或移除備援字型，並在備援字型規則集合中組織多個規則。

備援規則屬於執行時的呈現設定。它們不會修改簡報檔本身，也不會儲存在 PPTX 檔案內。

## **備援規則**

Aspose.Slides 支援 [IFontFallBackRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IFontFallBackRule) 介面及 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule) 類別，以指定套用備援字型的規則。[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule) 類別代表特定 Unicode 範圍（用於搜尋遺失的字形）與可能包含正確字形的字型清單之間的關聯：

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

您也可以 [remove](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 移除備援字型，或 [addFallBackFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 新增備援字型至現有的 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule) 物件中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRulesCollection) 可用於組織一系列 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule) 物件，當需要為多個 Unicode 範圍指定備援字型替換規則時。

{{% alert color="primary" title="另請參閱" %}} 
- [建立備援字型集合](/slides/zh-hant/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **常見問題**

**備援字型、字型代換與字型嵌入有何差異？**

備援字型僅在主要字型缺少字元時使用。[Font substitution](/slides/zh-hant/androidjava/font-substitution/) 會將整個指定的字型取代為另一個字型。[Font embedding](/slides/zh-hant/androidjava/embedded-font/) 則將字型打包至輸出檔案中，讓接收者能如預期顯示文字。

**備援字型是在匯出為 PDF、PNG 或 SVG 時套用，還是只在螢幕呈現時使用？**

是的。備援會影響所有在 [rendering and export operations](/slides/zh-hant/androidjava/convert-presentation/) 中需要繪製但來源字型缺少的字元。

**設定備援會改變簡報檔本身嗎？此設定在未來開啟時會保留嗎？**

不會。備援規則是您程式碼中的執行時呈現設定；它們不會儲存在 .pptx 檔案內，也不會在 PowerPoint 中顯示。

**作業系統（Windows/Linux/macOS）與字型目錄的設定會影響備援選擇嗎？**

會。引擎會從可用的系統資料夾以及您提供的 [additional paths](/slides/zh-hant/androidjava/custom-font/) 中解析字型。若字型實際上不存在，引用該字型的規則將無法生效。

**備援字型是否適用於 WordArt、SmartArt 與圖表？**

會。當這些物件包含文字時，會使用相同的字形代換機制來描繪缺失的字元。