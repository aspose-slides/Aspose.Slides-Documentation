---
title: 在 Android 上將 PowerPoint 簡報轉換為 Word 文件
linktitle: PowerPoint 轉 Word
type: docs
weight: 110
url: /zh-hant/androidjava/convert-powerpoint-to-word/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 Word
- 簡報轉 Word
- 投影片轉 Word
- PPT 轉 Word
- PPTX 轉 Word
- PowerPoint 轉 DOCX
- 簡報轉 DOCX
- 投影片轉 DOCX
- PPT 轉 DOCX
- PPTX 轉 DOCX
- PowerPoint 轉 DOC
- 簡報轉 DOC
- 投影片轉 DOC
- PPT 轉 DOC
- PPTX 轉 DOC
- 將 PPT 儲存為 DOCX
- 將 PPTX 儲存為 DOCX
- 匯出 PPT 為 DOCX
- 匯出 PPTX 為 DOCX
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 在 Java 中將 PowerPoint PPT 與 PPTX 投影片轉換為可編輯的 Word 文件，並保留精確的版面配置、圖像與格式。"
---
## **概觀**

本文提供了開發人員使用 Aspose.Slides 與 Aspose.Words 將 PowerPoint 與 OpenDocument 簡報轉換為 Word 文件的解決方案。一步步的指南將會帶領您完成轉換過程的每個階段。

## **Aspose.Slides 與 Aspose.Words**

若要將 PowerPoint 檔案（PPTX 或 PPT）轉換為 Word（DOCX 或 DOC），您需要同時使用 [Aspose.Slides for Android via Java](https://products.aspose.com/slides/zh-hant/androidjava/) 與 [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/)。

作為獨立的 API，[Aspose.Slides](https://products.aspose.app/slides) for java 提供了可從簡報中擷取文字的功能。

[Aspose.Words](https://docs.aspose.com/words/androidjava/) 是一個先進的文件處理 API，允許應用程式在不使用 Microsoft Word 的情況下生成、修改、轉換、呈現、列印檔案以及執行其他文件相關任務。

## **將 PowerPoint 轉換為 Word**

1. 下載 [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/zh-hant/java) 與 [Aspose.Words for Java](https://downloads.aspose.com/words/java) 程式庫。
2. 將 *aspose-slides-x.x-jdk16.jar* 與 *aspose-words-x.x-jdk16.jar* 加入您的 CLASSPATH。
3. 使用以下程式碼片段將 PowerPoint 轉換為 Word：

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // 產生投影片圖像作為位元組陣列串流
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // 插入投影片的文字
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```

## **常見問題**

**需要安裝哪些元件才能將 PowerPoint 與 OpenDocument 簡報轉換為 Word 文件？**

您只需將適用於 [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/zh-hant/androidjava/) 與 [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) 的相應套件加入您的專案即可。兩個程式庫皆作為獨立的 API 運作，且不需要安裝 Microsoft Office。

**是否支援所有 PowerPoint 與 OpenDocument 簡報格式？**

Aspose.Slides [支援所有簡報格式](/slides/zh-hant/androidjava/supported-file-formats/)，包括 PPT、PPTX、ODP 以及其他常見檔案類型。這確保您能處理由不同版本 Microsoft PowerPoint 建立的簡報。