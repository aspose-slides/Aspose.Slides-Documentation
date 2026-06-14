---
title: 在 Java 中自動化簡報本地化
linktitle: 簡報本地化
type: docs
weight: 100
url: /zh-hant/java/presentation-localization/
keywords:
- 變更語言
- 拼寫檢查
- 語言 ID
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中自動化 PowerPoint 與 OpenDocument 投影片本地化，提供實用程式碼範例與技巧，加速全球部署。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 為簡報中的文字設定 `LanguageId`。它展示了如何開啟簡報、加入帶文字的形狀、為文字段落指派語言識別碼，並將結果儲存為 PPTX 檔案。

## **更改簡報與圖形文字的語言**
- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
- 使用 Index 取得投影片的參考。
- 在投影片上加入類型為 [Rectangle](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ShapeType#Rectangle) 的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)。
- 將文字加入 TextFrame。
- 為文字設定 [Language Id](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-)。
- 將簡報儲存為 PPTX 檔案。

以下示例示範上述步驟的實作。

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

不會。Aspose.Slides 中的 [Language ID](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 只儲存用於拼寫檢查與文法校對的語言資訊，並不會翻譯或更改文字內容。它是 PowerPoint 用於校對的中繼資料。

**語言 ID 會影響渲染時的斷字與換行嗎？**

在 Aspose.Slides 中，[language ID](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 用於校對。斷字品質與換行主要取決於[適當字型](/slides/zh-hant/java/powerpoint-fonts/)的可用性，以及書寫系統的版面配置/換行設定。為確保正確渲染，請確保所需字型可用，設定[字型替代規則](/slides/zh-hant/java/font-substitution/)，或將[嵌入字型](/slides/zh-hant/java/embedded-font/)加入簡報。

**我可以在同一段落內設定不同的語言嗎？**

可以。[Language ID](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) 作用於文字段落層級，因此同一段落可混合多種語言，並使用不同的校對設定。