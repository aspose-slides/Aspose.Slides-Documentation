---
title: 在 Python via Java 中將 PowerPoint 簡報轉換為 Word 文件
linktitle: PowerPoint 轉 Word
type: docs
weight: 110
url: /zh-hant/python-java/convert-powerpoint-to-word/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- PowerPoint 轉 Word
- 簡報轉 Word
- PPT 轉 Word
- PPTX 轉 Word
- ODP 轉 Word
- PowerPoint 轉 DOCX
- PPT 轉 DOCX
- PPTX 轉 DOCX
- PowerPoint 轉 DOC
- 將 PPT 儲存為 DOCX
- 將 PPTX 儲存為 DOCX
- 匯出 PPT 成 DOCX
- 匯出 PPTX 成 DOCX
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 與 Aspose.Words，在 Python via Java 中將 PowerPoint 與 OpenDocument 簡報轉換為 Word，將投影片影像與可編輯文字結合。"
---
## **概述**

本文說明如何使用 Aspose.Slides for Python via Java 搭配 Aspose.Words for Java，將 PowerPoint 與 OpenDocument 投影片轉換為 Word 文件。Aspose.Slides 會渲染每張投影片並讀取其文字，而 Aspose.Words 透過 JPype 建立 Word 文件。無需安裝 Microsoft Office。

產生的文件會先放置投影片影像，然後接著放置從該投影片之頂層自動形狀擷取的可編輯文字。影像保留投影片的視覺外觀；單獨的形狀、圖表與表格不會轉換成可編輯的 Word 物件。擷取的文字不會保留原始的文字格式或位置。

## **將 PowerPoint 轉換為 Word**

1. 安裝 [Aspose.Slides for Python via Java](/slides/zh-hant/python-java/installation/) 並安裝相容的 Java 執行環境。
2. 下載 [Aspose.Words for Java](https://releases.aspose.com/words/java/)。將其主要 JAR 檔案放在腳本旁的 `lib` 目錄中，並重新命名為 `aspose-words.jar`，或自行調整範例中的路徑以符合下載的檔案。
3. 將輸入投影片 `sample.pptx` 放置於工作目錄中。`lib/aspose-words.jar` 的路徑亦相對於該目錄。
4. 執行以下 Python 程式碼以建立 `output.docx`。

範例使用 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 讀取來源，並以 [Slide.getImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slide/#getImage) 進行投影片渲染。接著使用 Aspose.Words 的 [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) 將影像與文字插入 Word 文件。

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # 將投影片影像調整至文字區域的寬度，保持其長寬比。
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # 將頂層自動形狀（含文字方塊）的純文字附加。
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

每張投影片會從新的一頁開始。過長的擷取文字或異常高的投影片影像可能需要額外的頁面。程式碼僅在投影片之間加入分頁符，並在 `finally` 區塊中釋放投影片與渲染的影像。JVM 會在同一個 Python 行程中保持可供後續轉換使用。

## **常見問題**

**需要哪些函式庫？**

使用 Aspose.Slides for Python via Java、JPype、相容的 Java 執行環境，以及 Aspose.Words for Java。兩個 Aspose 函式庫都在同一個 JVM 中執行。Aspose.Slides 處理投影片，Aspose.Words 負責寫入 Word 文件。

**除了 PPTX，還可以轉換 PPT 與 ODP 檔案嗎？**

可以。將 `sample.pptx` 替換為 PPT 或 ODP 檔案。請參閱 [Supported File Formats](/slides/zh-hant/python-java/supported-file-formats/) 了解投影片的輸入格式支援情況。

**所有投影片內容都能在 Word 中編輯嗎？**

不能。每張投影片皆以靜態影像插入，並在下方加入頂層自動形狀的純文字。群組內、表格、SmartArt、圖表以及投影片備註中的文字不會被此範例擷取。動畫與過場效果亦不會在 Word 文件中重現。

**可以儲存為 DOC 而不是 DOCX 嗎？**

可以。將輸出檔名改為 `output.doc` 即可。使用此儲存重載時，Aspose.Words 會根據檔案副檔名自動選擇輸出格式。