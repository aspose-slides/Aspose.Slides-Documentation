---
title: 在 Android 上配置回退字型集合
linktitle: 回退字型集合
type: docs
weight: 20
url: /zh-hant/androidjava/create-fallback-fonts-collection/
keywords:
- 回退字型
- 回退規則
- 字型集合
- 配置字型
- 設定字型
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "透過 Java 在 Aspose.Slides for Android 中設定回退字型集合，以確保 PowerPoint 與 OpenDocument 簡報中的文字保持一致且清晰。"
---
## **概述**

Aspose.Slides 允許您為簡報設定一組回退字型規則。每個回退規則由 `FontFallBackRule` 類別表示，並可加入 `FontFallBackRulesCollection`，該集合實作 `IFontFallBackRulesCollection` 介面。

建立集合後，您可以將它指派給簡報的 `FontsManager` 的 `FontFallBackRulesCollection` 屬性。`FontsManager` 負責整個簡報的字型管理，每個 `Presentation` 實例都有自己的 `FontsManager`。

當 `FontsManager` 使用回退字型集合初始化後，指定的回退字型會在簡報渲染時套用。

## **套用回退規則**

可以將 [FontFallBackRule](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRule) 類別的實例組織成 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRulesCollection)，該集合實作 [IFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IFontFallBackRulesCollection) 介面。您可以在集合中新增或移除規則。

然後可將此集合指派給 [FontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontFallBackRulesCollection) 方法的 [FontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontsManager) 類別。FontsManager 控制簡報中的字型。

每個 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 都有一個 `getFontsManager` 方法，可取得其專屬的 [FontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FontsManager) 實例。

以下是一個建立回退字型規則集合並指派給特定簡報的 [FontsManager](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#getFontsManager--) 的範例：  

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

當 FontsManager 使用回退字型集合初始化後，回退字型會在簡報渲染時套用。

{{% alert color="info" %}} 
了解更多有關[Render Presentation with Fallback Font](/slides/zh-hant/androidjava/render-presentation-with-fallback-font/)的資訊。 
{{% /alert %}}

## **常見問題**

### 我的回退規則會嵌入 PPTX 檔案並在 PowerPoint 中保存後可見嗎？

不會。回退規則屬於執行時渲染設定，並不會序列化到 PPTX 中，也不會出現在 PowerPoint 的介面上。

### 回退會套用在 SmartArt、WordArt、圖表和表格中的文字嗎？

會。相同的字形替換機制會用於這些物件中的所有文字。

### Aspose 會隨函式庫一起分發任何字型嗎？

不會。字型需由您自行加入並使用，相關責任亦由您自行承擔。

### 缺字型的取代/替換與缺字形的回退可以同時使用嗎？

可以。它們是同一字型解析流程的獨立階段：首先引擎解析字型可用性（[replacement](/slides/zh-hant/androidjava/font-replacement/)/[substitution](/slides/zh-hant/androidjava/font-substitution/)），接著回退會為可用字型中缺少的字形填補空缺。