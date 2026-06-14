---
title: 在 PHP 中為簡報指定備援字型
linktitle: 備援字型
type: docs
weight: 10
url: /zh-hant/php-java/create-fallback-font/
keywords:
- 備援字型
- 備援規則
- 套用字型
- 替換字型
- Unicode 範圍
- 缺失字形
- 正確字形
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "透過 Java 掌握 Aspose.Slides for PHP，以在 PPT、PPTX 與 ODP 檔案中設定備援字型，確保文字在任何裝置或作業系統上皆能一致顯示。"
---
## **概觀**

Aspose.Slides 允許您為簡報的渲染和匯出操作指定備援字型。當主要字型缺少特定字元的字形時，會使用備援字型。

備援行為透過備援規則進行設定。每個規則將 Unicode 範圍與可能包含所需字形的一個或多個字型關聯起來。您可以為不同的字元範圍定義規則、在現有規則中新增或移除備援字型，並在備援字型規則集合中組織多個規則。

備援規則屬於執行時的渲染設定。它們不會修改簡報檔本身，也不會儲存在 PPTX 檔案中。

## **備援字型規則**

Aspose.Slides 支援 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontFallBackRule) 類別，用於指定套用備援字型的規則。[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontFallBackRule) 類別表示在指定的 Unicode 範圍（用於搜尋缺失的字形）與可能包含正確字形的字型清單之間的關聯：

```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # 使用多種方式可以加入字型清單：
  $fontNames = array("Segoe UI Emoji, Segoe UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```

也可以對現有的 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontFallBackRule) 物件[移除](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontfallbackrule/remove/)備援字型，或 [addFallBackFonts](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontfallbackrule/addfallbackfonts/) 以加入備援字型。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontFallBackRulesCollection) 可用於組織一系列 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontFallBackRule) 物件，當需要為多個 Unicode 範圍指定備援字型替換規則時。

{{% alert color="primary" title="另請參閱" %}} 
- [建立備援字型集合](/slides/zh-hant/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **常見問題**

**備援字型、字型取代與字型嵌入有何差異？**

備援字型僅在主要字型缺少字元時使用。[字型取代](/slides/zh-hant/php-java/font-substitution/) 會以另一個字型取代整個指定的字型。[字型嵌入](/slides/zh-hant/php-java/embedded-font/) 則將字型封裝在輸出檔案中，使接收者能如預期顯示文字。

**備援字型是在匯出為 PDF、PNG、SVG 等格式時套用，還是僅在螢幕渲染時套用？**

是的。備援會影響所有需要繪製字元但在來源字型中缺失的 [渲染與匯出操作](/slides/zh-hant/php-java/convert-presentation/)。

**設定備援會變更簡報檔本身嗎？此設定在未來開啟時會持續存在嗎？**

不會。備援規則是寫入程式碼中的執行時渲染設定，並未儲存在 .pptx 檔內，也不會在 PowerPoint 中顯示。

**作業系統（Windows、Linux、macOS）與字型目錄的設定會影響備援字型的選擇嗎？**

會。引擎會從可用的系統資料夾以及您提供的任何 [其他路徑](/slides/zh-hant/php-java/custom-font/) 中解析字型。如果字型實際上不存在，則引用該字型的規則無法生效。

**備援字型適用於 WordArt、SmartArt 與圖表嗎？**

會。當這些物件包含文字時，會使用相同的字形替代機制來渲染缺失的字元。