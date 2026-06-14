---
title: 在 Java 中將 PowerPoint 簡報轉換為 Word 文件
linktitle: PowerPoint 轉 Word
type: docs
weight: 110
url: /zh-hant/java/convert-powerpoint-to-word/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Java 中將 PowerPoint PPT 和 PPTX 投影片轉換為可編輯的 Word 文件，精確保留版面配置、圖像與格式。"
---
## **概覽**

本文為開發人員提供一個使用 Aspose.Slides 與 Aspose.Words 將 PowerPoint 與 OpenDocument 簡報轉換為 Word 文件的解決方案。分步指南將引導您完成轉換過程的每個階段。

## **將 PowerPoint 轉換為 Word**

請依照下列說明將 PowerPoint 或 OpenDocument 簡報轉換為 Word 文件：

1. 下載 [Aspose.Slides for Java](https://downloads.aspose.com/slides/zh-hant/java) 與 [Aspose.Words for Java](https://downloads.aspose.com/words/java) 程式庫。
2. 將 *aspose-slides-x.x-jdk16.jar* 與 *aspose-words-x.x-jdk16.jar* 加入您的 CLASSPATH。
3. 使用以下程式碼片段將 PowerPoint 轉換為 Word：

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // 產生投影片圖像為位元組陣列串流
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

## **常見問答**

**需要安裝哪些元件才能將 PowerPoint 與 OpenDocument 簡報轉換為 Word 文件？**

您只需將 [Aspose.Slides for Java](https://releases.aspose.com/slides/zh-hant/java/) 與 [Aspose.Words for Java](https://releases.aspose.com/words/java/) 的相應套件新增至您的專案。兩個程式庫皆為獨立 API，無需安裝 Microsoft Office。

**是否支援所有 PowerPoint 與 OpenDocument 簡報格式？**

Aspose.Slides [支援所有簡報格式](/slides/zh-hant/java/supported-file-formats/)，包括 PPT、PPTX、ODP 以及其他常見檔案類型。這確保您可處理各版本 Microsoft PowerPoint 所建立的簡報。