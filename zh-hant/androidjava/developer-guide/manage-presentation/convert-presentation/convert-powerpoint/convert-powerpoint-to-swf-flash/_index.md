---
title: 將 PowerPoint 簡報轉換為 Android 上的 SWF Flash
linktitle: PowerPoint 轉換為 SWF
type: docs
weight: 80
url: /zh-hant/androidjava/convert-powerpoint-to-swf-flash/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉換為 SWF
- 簡報轉換為 SWF
- 投影片轉換為 SWF
- PPT 轉換為 SWF
- PPTX 轉換為 SWF
- PowerPoint 轉換為 Flash
- 簡報轉換為 Flash
- 投影片轉換為 Flash
- PPT 轉換為 Flash
- PPTX 轉換為 Flash
- 將 PPT 儲存為 SWF
- 将 PPTX 儲存為 SWF
- 匯出 PPT 為 SWF
- 匯出 PPTX 為 SWF
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "在 Android 上使用 Aspose.Slides 的 Java 版將 PowerPoint (PPT/PPTX) 轉換為 SWF Flash。步驟式程式碼範例、快速高品質輸出、無需 PowerPoint 自動化。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 SWF。它展示了如何使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法將簡報另存為 SWF 檔案，以及如何使用 [SwfOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/swfoptions/) 配置匯出，包括檢視器設定和註解或備註的版面配置。

## **將 PPT(X) 轉換為 SWF**

由 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別所提供的 [Save](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 方法可用於將整個簡報轉換為 **SWF** 文件。以下範例示範如何使用 [**SWFOptions**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SwfOptions) 類別提供的選項將簡報轉換為 **SWF** 文件。您也可以使用 [**ISWFOptions**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISwfOptions) 類別和 [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) 介面在產生的 SWF 中加入註解。

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // 保存簡報
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以在 SWF 中包含隱藏投影片嗎？**

是的。使用 [SwfOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/swfoptions/) 中的 [setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) 方法即可啟用隱藏投影片。預設情況下，隱藏投影片不會被匯出。

**我該如何控制壓縮與最終的 SWF 大小？**

使用 [setCompressed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) 方法以及 [adjust JPEG quality](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) 以在檔案大小與影像品質之間取得平衡。

**'setViewerIncluded' 的用途是什麼？何時應該停用它？**

[setViewerIncluded](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) 會加入內嵌播放器 UI（導覽控制、面板、搜尋）。如果您打算使用自訂播放器或需要沒有 UI 的純粹 SWF 框架，請將其停用。

**如果匯出機器缺少來源字型會發生什麼情況？**

Aspose.Slides 會在 [SwfOptions](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/swfoptions/) 中使用您透過 [setDefaultRegularFont](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) 指定的字型來取代缺少的字型，以避免意外的備援。