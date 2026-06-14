---
title: 在 Java 中為簡報指定回退字型
linktitle: 回退字型
type: docs
weight: 10
url: /zh-hant/java/create-fallback-font/
keywords:
- 回退字型
- 回退規則
- 套用字型
- 替換字型
- Unicode 範圍
- 缺失字形
- 正確字形
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "精通 Aspose.Slides for Java，以在 PPT、PPTX 和 ODP 檔案中設定回退字型，確保在任何裝置或作業系統上皆能一致顯示文字。"
---
## **概述**

Aspose.Slides 允許您為簡報呈現和匯出作業指定回退字型。當主要字型未包含特定字元的字形時，會使用回退字型。

回退行為是透過回退規則來設定。每個規則將 Unicode 範圍與一個或多個可能包含所需字形的字型關聯起來。您可以為不同的字元範圍定義規則、在現有規則中新增或移除回退字型，並在回退字型規則集合中組織多個規則。

回退規則是執行階段的呈現設定。它們不會修改簡報檔本身，也不會儲存在 PPTX 檔案中。

## **回退規則**

Aspose.Slides 支援 [IFontFallBackRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IFontFallBackRule) 介面與 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule) 類別，以指定套用回退字型的規則。[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule) 類別代表指定的 Unicode 範圍（用於搜尋缺少的字形）與可能包含正確字形的字型清單之關聯：

```java
long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//使用多種方式您可以新增字型清單:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

也可以[remove](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 回退字型或[addFallBackFonts](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 到現有的[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule) 物件中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRulesCollection) 可用來組織 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FontFallBackRule) 物件的清單，當需要為多個 Unicode 範圍指定回退字型置換規則時。

{{% alert color="primary" title="另請參閱" %}} 
- [建立回退字型集合](/slides/zh-hant/java/create-fallback-fonts-collection/)
{{% /alert %}}

## **常見問題**

**回退字型、字型替換與字型嵌入有何差異？**

回退字型僅在主要字型缺少字元時使用。[字型替換](/slides/zh-hant/java/font-substitution/) 會將整個指定的字型替換為另一個字型。[字型嵌入](/slides/zh-hant/java/embedded-font/) 將字型打包進輸出檔案，使接收者能如預期顯示文字。

**回退字型是僅在螢幕顯示時套用，還是會在 PDF、PNG、SVG 等匯出時使用？**

是的。回退會影響所有[呈現與匯出作業](/slides/zh-hant/java/convert-presentation/)，只要必須繪製但在來源字型中不存在的字元，都會套用回退字型。

**設定回退會修改簡報檔本身嗎？此設定在未來開啟時會保留嗎？**

不會。回退規則是您程式碼中的執行階段呈現設定，並不會儲存在 .pptx 檔案中，也不會在 PowerPoint 中顯示。

**作業系統 (Windows / Linux / macOS) 與字型目錄的設定會影響回退字型的選擇嗎？**

會。引擎會從系統可用的資料夾以及您提供的任何[額外路徑](/slides/zh-hant/java/custom-font/)中解析字型。如果字型實際上不存在，則引用該字型的規則不會生效。

**回退字型是否適用於 WordArt、SmartArt 與圖表？**

會。當這些物件包含文字時，會使用相同的字形替換機制來呈現缺少的字元。