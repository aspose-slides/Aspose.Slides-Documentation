---
title: 在 Android 上將 PPTX 轉換為 PPT
linktitle: PPTX 轉 PPT
type: docs
weight: 21
url: /zh-hant/androidjava/convert-pptx-to-ppt/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
- 轉換 PPTX
- PPTX 轉 PPT
- 將 PPTX 儲存為 PPT
- 匯出 PPTX 為 PPT
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "輕鬆使用 Aspose.Slides for Android 透過 Java 將 PPTX 轉換為 PPT——確保與 PowerPoint 格式的無縫相容性，同時保留簡報的版面配置與品質。"
---
## **概述**

本文說明如何使用 Java 將 PowerPoint 簡報的 PPTX 格式轉換為 PPT 格式。涵蓋以下主題。

- 在 Java 中將 PPTX 轉換為 PPT

## **在 Android 上將 PPTX 轉換為 PPT**

欲取得將 PPTX 轉換為 PPT 的 Java 範例程式碼，請參閱以下章節，即[Convert PPTX to PPT](#convert-pptx-to-ppt)。它僅載入 PPTX 檔案並以 PPT 格式儲存。透過指定不同的儲存格式，您也可以將 PPTX 檔案儲存為許多其他格式，如 PDF、XPS、ODP、HTML 等，如這些文章所討論。

- [在 Android 上將 PPTX 轉換為 PDF](/slides/zh-hant/androidjava/convert-powerpoint-to-pdf/)
- [在 Android 上將 PPTX 轉換為 XPS](/slides/zh-hant/androidjava/convert-powerpoint-to-xps/)
- [在 Android 上將 PPTX 轉換為 HTML](/slides/zh-hant/androidjava/convert-powerpoint-to-html/)
- [在 Android 上將 PPTX 轉換為 ODP](/slides/zh-hant/androidjava/save-presentation/)
- [在 Android 上將 PPTX 轉換為 PNG](/slides/zh-hant/androidjava/convert-powerpoint-to-png/)

## **將 PPTX 轉換為 PPT**

要將 PPTX 轉換為 PPT，只需將檔案名稱和儲存格式傳遞給[**Presentation**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的 **Save** 方法。以下 Java 程式碼範例使用預設選項將 Presentation 從 PPTX 轉換為 PPT。

```java
// 實例化一個表示 PPTX 檔案的 Presentation 物件
Presentation presentation = new Presentation("template.pptx");

// 將簡報儲存為 PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **常見問題**

**將 PPTX 的所有效果和功能在儲存為舊版 PPT (97–2003) 格式時都能保留嗎？**

不一定。PPT 格式缺乏一些較新的功能（例如特定的效果、物件和行為），因此在轉換過程中，功能可能會被簡化或轉為點陣圖。

**我可以只將選取的投影片轉換為 PPT，而不是整個簡報嗎？**

直接儲存會針對整個簡報。若要轉換特定投影片，請建立僅包含這些投影片的新簡報並將其儲存為 PPT；或者使用支援每張投影片轉換參數的服務/API。

**支援受密碼保護的簡報嗎？**

是的。您可以偵測檔案是否受保護，以密碼開啟，並且亦可為已儲存的 PPT[設定保護/加密設定](/slides/zh-hant/androidjava/password-protected-presentation/)。