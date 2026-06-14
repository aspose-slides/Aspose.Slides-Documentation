---
title: 在 PHP 中設定回退字型集合
linktitle: 回退字型集合
type: docs
weight: 20
url: /zh-hant/php-java/create-fallback-fonts-collection/
keywords:
- 回退字型
- 回退規則
- 字型集合
- 設定字型
- 建立字型
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "在 Aspose.Slides for PHP（透過 Java）中設定回退字型集合，以確保 PowerPoint 與 OpenDocument 簡報中的文字保持一致且清晰。"
---
## **概述**

Aspose.Slides 允許您為簡報設定一組字型回退規則。每個回退規則由 `FontFallBackRule` 類別表示，並可加入 `FontFallBackRulesCollection`。

建立集合後，您可以透過簡報的 `FontsManager` 的 `setFontFallBackRulesCollection` 方法指派它。`FontsManager` 控制整個簡報的字型，而每個 `Presentation` 實例都有自己的 `FontsManager`。

當 `FontsManager` 使用回退字型集合初始化後，指定的回退字型會在簡報渲染時套用。

## **套用回退規則**

[FontFallBackRule](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontFallBackRule) 類別的實例可以組成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontFallBackRulesCollection)。可以在集合中新增或移除規則。

然後可將此集合指派給 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontFallBackRulesCollection) 方法的 [FontsManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontsManager) 類別。FontsManager 控制簡報的字型。

每個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation) 皆具有 [getFontsManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation#getFontsManager) 方法，並擁有自己實例的 [FontsManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/FontsManager) 類別。

以下是建立回退字型規則集合並指派至特定簡報之 [FontsManager](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/Presentation#getFontsManager) 的範例：

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

在 FontsManager 使用回退字型集合初始化後，回退字型會在簡報渲染時套用。

{{% alert color="primary" %}} 
閱讀更多關於如何[Render Presentation with Fallback Font](/slides/zh-hant/php-java/render-presentation-with-fallback-font/)的資訊。
{{% /alert %}}

## **常見問題**

**我的回退規則會嵌入 PPTX 檔案並在儲存後於 PowerPoint 中可見嗎？**

不會。回退規則是執行時的渲染設定；它們不會序列化至 PPTX，也不會出現在 PowerPoint 的使用者介面中。

**回退會套用於 SmartArt、WordArt、圖表與表格內的文字嗎？**

會。相同的字形替換機制會用於這些物件中的任何文字。

**Aspose 會隨函式庫一起分發任何字型嗎？**

不會。字型必須由您自行加入並使用，相關責任由您自行承擔。

**缺字型的替換/替代與缺字形的回退可以同時使用嗎？**

可以。它們是同一字型解析管線的獨立階段：首先引擎會解析字型可用性（[replacement](/slides/zh-hant/php-java/font-replacement/)/[substitution](/slides/zh-hant/php-java/font-substitution/)），然後回退會填補可用字型中缺少的字形。