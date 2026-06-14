---
title: 使用備援字型在 JavaScript 中渲染簡報
linktitle: 渲染簡報
type: docs
weight: 30
url: /zh-hant/nodejs-java/render-presentation-with-fallback-font/
keywords:
- 備援字型
- 渲染 PowerPoint
- 渲染簡報
- 渲染投影片
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "在 Aspose.Slides for Node.js 中使用備援字型渲染簡報 – 透過逐步 JavaScript 程式碼範例，確保 PPT、PPTX 與 ODP 的文字保持一致。"
---
## **概述**

Aspose.Slides 允許您使用備援字型規則來渲染簡報。本文章說明如何建立備援字型規則集合、透過移除或新增備援字型來修改其規則，並使用 `FontsManager.setFontFallBackRulesCollection` 方法指派該集合。

將備援字型規則集合指派給簡報的 `FontsManager` 後，這些規則會在儲存、渲染與轉換簡報等操作期間套用。範例示範了在渲染投影片縮圖並將其儲存為 PNG 圖像時，如何使用已配置的規則。

## **使用備援字型規則渲染投影片**

1. 我們[建立備援字型規則集合](/slides/zh-hant/nodejs-java/create-fallback-fonts-collection/)。
2. [移除](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) 一個備援字型規則，並將[addFallBackFonts](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 加入另一個規則。
3. 將規則集合設定給 [getFontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) 方法。
4. 使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) 方法，我們可以以相同格式儲存簡報，或以其他格式儲存。將備援字型規則集合設定給 [FontsManager](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/FontsManager) 後，這些規則會在對簡報的任何操作期間套用：儲存、渲染、轉換等。

```javascript
// 建立規則集合的新實例
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// 建立多個規則
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // 嘗試從已載入的規則中移除備援字型「Tahoma」
    fallBackRule.remove("Tahoma");
    // 並為指定範圍更新規則
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// 也可以從清單中移除任何現有的規則
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // 指派已準備好的規則清單以供使用
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // 使用已初始化的規則集合渲染縮圖並儲存為 JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // 將影像以 JPEG 格式儲存至磁碟
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
了解更多有關如何在 JavaScript 中 [將 PPT 和 PPTX 轉換為 JPG](/slides/zh-hant/nodejs-java/convert-powerpoint-to-jpg/)。
{{% /alert %}}