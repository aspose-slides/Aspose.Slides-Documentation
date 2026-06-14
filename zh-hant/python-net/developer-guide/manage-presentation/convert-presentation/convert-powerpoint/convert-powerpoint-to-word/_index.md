---
title: 在 Python 中將 PowerPoint 簡報轉換為 Word 文件
linktitle: PowerPoint 轉 Word
type: docs
weight: 110
url: /zh-hant/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint 轉 DOCX
- OpenDocument 轉 DOCX
- 簡報 轉 DOCX
- 投影片 轉 DOCX
- PPT 轉 DOCX
- PPTX 轉 DOCX
- ODP 轉 DOCX
- PowerPoint 轉 DOC
- OpenDocument 轉 DOC
- 簡報 轉 DOC
- 投影片 轉 DOC
- PPT 轉 DOC
- PPTX 轉 DOC
- ODP 轉 DOC
- PowerPoint 轉 Word
- OpenDocument 轉 Word
- 簡報 轉 Word
- 投影片 轉 Word
- PPT 轉 Word
- PPTX 轉 Word
- ODP 轉 Word
- 轉換 PowerPoint
- 轉換 OpenDocument
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- 轉換 PPTX
- 轉換 ODP
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 輕鬆將 PowerPoint 與 OpenDocument 簡報轉換為 Word 文件。我們的逐步指南附有 Python 範例程式碼，為希望精簡文件工作流程的開發人員提供解決方案。"
---
## **概述**

本篇說明提供開發人員一套使用 Aspose.Slides for Python via .NET 以及 Aspose.Words for Python via .NET，將 PowerPoint 與 OpenDocument 簡報轉換為 Word 文件的解決方案。逐步指南會帶您完成轉換過程的每個階段。

## **將簡報轉換為 Word 文件**

請依照下列說明將 PowerPoint 或 OpenDocument 簡報轉換為 Word 文件：

1. 實例化 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別並載入簡報檔案。  
2. 實例化 [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) 與 [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) 類別以產生 Word 文件。  
3. 使用 [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) 屬性將 Word 文件的頁面大小設定為與簡報相同。  
4. 使用 [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/) 屬性設定 Word 文件的邊界。  
5. 透過 [Presentation.slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/slides/zh-hant/) 屬性逐一處理簡報的所有投影片。  
   - 使用 [Slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/) 類別的 `get_image` 方法產生投影片影像，並儲存至記憶體串流。  
   - 使用 [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) 類別的 `insert_image` 方法將投影片影像加入 Word 文件。  
6. 將 Word 文件儲存為檔案。

假設我們有一個名為「sample.pptx」的簡報，其內容如下：

![PowerPoint presentation](PowerPoint.png)

以下 Python 程式碼示範如何將 PowerPoint 簡報轉換為 Word 文件：

```py
import aspose.slides as slides
import aspose.words as words

# 載入簡報檔案。
with slides.Presentation("sample.pptx") as presentation:

    # 建立 Document 與 DocumentBuilder 物件。
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # 設定 Word 文件的頁面大小。
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # 設定 Word 文件的邊界。
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # 逐一處理所有簡報投影片。
    for slide in presentation.slides:

        # 產生投影片影像並儲存至記憶體串流。
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # 將投影片影像加入 Word 文件。
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # 儲存 Word 文件至檔案。
    document.save("output.docx")
```

轉換結果：

![Word document](Word.png)

{{% alert color="primary" %}} 

試試我們的 [**Online PPT to Word Converter**](https://products.aspose.app/slides/zh-hant/conversion/ppt-to-word) ，了解將 PowerPoint 與 OpenDocument 簡報轉換為 Word 文件能為您帶來的效益。 

{{% /alert %}}

## **常見問題**

**需要安裝哪些元件才能將 PowerPoint 與 OpenDocument 簡報轉換為 Word 文件？**

只需在 Python 專案中加入 [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) 與 [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) 的相應套件即可。兩個套件皆為獨立的 API，無需安裝 Microsoft Office。

**是否支援所有 PowerPoint 與 OpenDocument 簡報格式？**

Aspose.Slides for Python .NET [支援所有簡報格式](/slides/zh-hant/python-net/supported-file-formats/)，包括 PPT、PPTX、ODP 以及其他常見檔案類型。這確保您能處理以各種 Microsoft PowerPoint 版本建立的簡報。