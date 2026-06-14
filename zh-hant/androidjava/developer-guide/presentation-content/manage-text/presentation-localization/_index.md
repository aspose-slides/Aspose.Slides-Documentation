---
title: 在 Android 上自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/androidjava/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 語言 ID
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中自動化 PowerPoint 與 OpenDocument 投影片的本地化，提供實用程式碼範例與技巧，以加快全球部署。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 為簡報中的文字設定 `LanguageId`。示範如何開啟簡報、在形狀中加入文字、將語言識別碼指派給文字區塊，並將結果儲存為 PPTX 檔案。

## **變更簡報與圖形文字的語言**
- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類的實例。
- 使用其 Index 取得投影片的參考。
- 將類型為 [Rectangle](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ShapeType#Rectangle) 的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAutoShape) 新增至投影片。
- 將文字新增至 TextFrame。
- [設定語言 ID](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) 至文字。
- 將簡報寫出為 PPTX 檔案。

以下示例演示上述步驟的實作。

```java
Presentation pres = new Presentation("test.pptx");
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.addTextFrame("Text to apply spellcheck language");

    shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLanguageId("en-EN");

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**語言 ID 會觸發自動文字翻譯嗎？**

否。[Language ID](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 在 Aspose.Slides 中用於儲存拼寫檢查與文法校對的語言，但它不會翻譯或更改文字內容。它是 PowerPoint 能理解的校對用中繼資料。

**語言 ID 會影響渲染時的斷字與換行嗎？**

在 Aspose.Slides 中，[language ID](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 用於校對。斷字品質與換列主要取決於[適當的字型](/slides/zh-hant/androidjava/powerpoint-fonts/)以及書寫系統的版面/換列設定。為確保正確渲染，請確保提供所需字型、設定[字型替代規則](/slides/zh-hant/androidjava/font-substitution/)，或將[嵌入字型](/slides/zh-hant/androidjava/embedded-font/)加入簡報。

**我可以在同一段落中設定不同語言嗎？**

是的。[Language ID](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 會在文字區塊層級套用，因此單一段落可以混合多種語言並使用不同的校對設定。