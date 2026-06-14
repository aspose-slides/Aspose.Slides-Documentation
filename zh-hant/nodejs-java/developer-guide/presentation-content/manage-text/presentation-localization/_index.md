---
title: 在 JavaScript 中自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/nodejs-java/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 語言 ID
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides 在 JavaScript 中自動化 PowerPoint 與 OpenDocument 投影片本地化，並提供實用程式碼範例與技巧，以加速全球佈署。"
---
## **概述**

本文章說明如何使用 Aspose.Slides 為簡報中的文字設定 `LanguageId`。它展示了如何開啟簡報、加入帶文字的圖形、為文字段落指定語言識別碼，並將結果儲存為 PPTX 檔案。

## **變更簡報與圖形文字的語言**

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
- 使用索引取得投影片的參考。
- 在投影片上加入一個 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/AutoShape) 且型別為 [Rectangle](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapeType#Rectangle) 的圖形。
- 將文字加入 TextFrame。
- 為文字設定 [設定語言識別碼](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/BasePortionFormat#setLanguageId-java.lang.String-)。
- 將簡報寫入為 PPTX 檔案。

以下示例展示了上述步驟的實作。

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");
    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問答**

**語言 ID 會觸發自動文字翻譯嗎？**

不會。Aspose.Slides 中的 [setLanguageId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) 會儲存語言資訊以供拼寫檢查與文法校對使用，但不會翻譯或變更文字內容。這是 PowerPoint 用於校對的中繼資料。

**語言 ID 會影響渲染時的斷字與換行嗎？**

在 Aspose.Slides 中，[setLanguageId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) 只用於校對。斷字品質與換行主要取決於[適當的字型](/slides/zh-hant/nodejs-java/powerpoint-fonts/)是否可用以及書寫系統的版面配置/換行設定。為確保正確呈現，請確保所需字型可用、設定[字型替代規則](/slides/zh-hant/nodejs-java/font-substitution/)以及/或將[字型嵌入](/slides/zh-hant/nodejs-java/embedded-font/)至簡報中。

**我可以在同一段落中設定不同語言嗎？**

可以。[setLanguageId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) 會套用於文字段落層級，因此同一段落內可混合多種語言，並擁有各自的校對設定。