---
title: 在 Java 中將 PPTX 轉換為 PPT
linktitle: PPTX 轉 PPT
type: docs
weight: 21
url: /zh-hant/java/convert-pptx-to-ppt/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPTX
- PPTX 轉 PPT
- 將 PPTX 儲存為 PPT
- 匯出 PPTX 為 PPT
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 輕鬆將 PPTX 轉換為 PPT——確保與 PowerPoint 格式的無縫相容性，同時保留簡報的版面配置與品質。"
---
## **概述**

本文說明如何使用 Java 將 PowerPoint 簡報的 PPTX 格式轉換為 PPT 格式。以下主題將被討論。

- 在 Java 中將 PPTX 轉換為 PPT

## **在 Java 中將 PPTX 轉換為 PPT**

有關將 PPTX 轉換為 PPT 的 Java 示例代碼，請參閱下方段落，即 [Convert PPTX to PPT](#convert-pptx-to-ppt)。它僅載入 PPTX 檔案並以 PPT 格式儲存。透過指定不同的儲存格式，您也可以將 PPTX 檔案儲存為 PDF、XPS、ODP、HTML 等多種格式，如這些文章所討論的。

- [Convert PPTX to PDF in Java](/slides/zh-hant/java/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS in Java](/slides/zh-hant/java/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML in Java](/slides/zh-hant/java/convert-powerpoint-to-html/)
- [Convert PPTX to ODP in Java](/slides/zh-hant/java/save-presentation/)
- [Convert PPTX to PNG in Java](/slides/zh-hant/java/convert-powerpoint-to-png/)

## **將 PPTX 轉換為 PPT**
要將 PPTX 轉換為 PPT，只需將檔名和儲存格式傳遞給 [**Presentation**](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的 **Save** 方法。以下 Java 程式碼示範使用預設選項將 Presentation 從 PPTX 轉換為 PPT。

```java
// 實例化一個代表 PPTX 檔案的 Presentation 物件
Presentation presentation = new Presentation("template.pptx");

// 將簡報儲存為 PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **常見問題**

**在將 PPTX 儲存為舊版 PPT（97–2003）格式時，所有效果和功能都會保留嗎？**

並非總是如此。PPT 格式缺乏某些較新的功能（例如特定的效果、物件和行為），因此在轉換過程中可能會被簡化或轉為光柵圖像。

**我可以只將選取的投影片轉換為 PPT，而不是整個簡報嗎？**

直接儲存會針對整個簡報。若要轉換特定投影片，請先建立只包含這些投影片的新簡報，然後將其儲存為 PPT；或者使用支援逐投影片轉換參數的服務/API。

**是否支援受密碼保護的簡報？**

是的。您可以偵測檔案是否受保護，以密碼開啟，並且也能 [configure protection/encryption settings](/slides/zh-hant/java/password-protected-presentation/) 以設定儲存的 PPT 的保護/加密設定。