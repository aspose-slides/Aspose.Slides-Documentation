---
title: 在 Android 上為簡報指定後備字型
linktitle: 後備字型
type: docs
weight: 10
url: /zh-hant/androidjava/create-fallback-font/
keywords:
- 後備字型
- 後備規則
- 套用字型
- 替換字型
- Unicode 範圍
- 缺少字形
- 正確字形
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "精通 Aspose.Slides for Android（使用 Java）以在 PPT、PPTX 和 ODP 檔案中設定後備字型，確保在任何裝置或作業系統上文字顯示一致。"
---
## **概述**

Aspose.Slides 允許您為投影片的呈現和匯出操作指定後備字型。當主要字型未包含特定字元的字形時，會使用後備字型。

後備行為透過後備規則設定。每個規則會將 Unicode 範圍與一或多個可能包含所需字形的字型相關聯。您可以為不同的字元範圍定義規則、在現有規則中新增或移除後備字型，並將多個規則組織在後備字型規則集合中。

後備規則是執行時的呈現設定。它們不會修改投影片檔本身，也不會儲存在 PPTX 檔案內。

## **後備字型規則**

Aspose.Slides 支援 [IFontFallBackRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IFontFallBackRule) 介面與 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule) 類別，以指定套用後備字型的規則。[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule) 類別代表指定的 Unicode 範圍（用於搜尋缺少的字形）與可能包含正確字形的字型清單之間的關聯：

```java
import com.aspose.slides.*;

long startUnicodeIndex = 0x0B80;
long endUnicodeIndex = 0x0BFF;

IFontFallBackRule firstRule = new FontFallBackRule(startUnicodeIndex, endUnicodeIndex, "Vijaya");
IFontFallBackRule secondRule = new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic");

//Using multiple ways you can add fonts list:
String[] fontNames = new String[] { "Segoe UI Emoji, Segoe UI Symbol", "Arial" };

IFontFallBackRule thirdRule = new FontFallBackRule(0x1F300, 0x1F64F, fontNames);
```

也可以 [remove](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) 後備字型或 [addFallBackFonts](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 到現有的 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule) 物件。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRulesCollection) 可用於組織一系列 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule) 物件，當需要為多個 Unicode 範圍指定後備字型取代規則時。

{{% alert color="info" title="See also" %}} 
- [建立後備字型集合](/slides/zh-hant/androidjava/create-fallback-fonts-collection/)
{{% /alert %}}

## **常見問題**

### 什麼是後備字型、字型替代與字型嵌入之間的差異？

後備字型僅在主要字型中缺少某些字元時使用。[字型替代](/slides/zh-hant/androidjava/font-substitution/) 會將整個指定的字型換成另一個字型。[字型嵌入](/slides/zh-hant/androidjava/embedded-font/) 則將字型打包在輸出檔案中，使接收者能正確顯示文字。

### 後備字型是在匯出為 PDF、PNG 或 SVG 時套用，還是僅在螢幕上呈現時使用？

是的。後備會影響所有 [呈現與匯出操作](/slides/zh-hant/androidjava/convert-presentation/)，只要需要繪製但原始字型中不存在的字元，都會使用後備。

### 設定後備會改變投影片檔本身嗎？這項設定會在未來開啟時保留嗎？

不會。後備規則是您程式碼中的執行時呈現設定；它們不會儲存在 .pptx 中，也不會出現在 PowerPoint 中。

### 作業系統（Windows/Linux/macOS）以及字型目錄的設定會影響後備字型的選擇嗎？

會。引擎會從系統可用的資料夾以及您提供的任何 [額外路徑](/slides/zh-hant/androidjava/custom-font/) 中解析字型。如果字型實際上不存在，則引用該字型的規則不會生效。

### 後備字型是否適用於 WordArt、SmartArt 與圖表？

會。當這些物件包含文字時，會套用相同的字形替代機制來呈現缺失的字元。