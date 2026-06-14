---
title: 將 PowerPoint 簡報轉換為 JavaScript 中的 SWF Flash
linktitle: PowerPoint 轉 SWF
type: docs
weight: 80
url: /zh-hant/nodejs-java/convert-powerpoint-to-swf-flash/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 SWF
- 簡報 轉 SWF
- 投影片 轉 SWF
- PPT 轉 SWF
- PPTX 轉 SWF
- PowerPoint 轉 Flash
- 簡報 轉 Flash
- 投影片 轉 Flash
- PPT 轉 Flash
- PPTX 轉 Flash
- 儲存 PPT 為 SWF
- 儲存 PPTX 為 SWF
- 匯出 PPT 為 SWF
- 匯出 PPTX 為 SWF
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js 將 PowerPoint (PPT/PPTX) 轉換為 SWF Flash。逐步程式碼範例、快速高品質輸出，無需 PowerPoint 自動化。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 SWF。它展示了如何使用 [Presentation.save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/#save) 方法將簡報另存為 SWF 檔案，以及如何使用 [SwfOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/swfoptions/) 配置匯出，包括檢視器設定與註釋或備註的版面配置。

## **轉換 PPT(X) 為 SWF**

由 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation) 類別提供的 [save](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) 方法可用於將整個簡報轉換為 **SWF** 文件。以下範例示範如何使用 [**SWFOptions**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SwfOptions) 類別提供的選項將簡報轉換為 **SWF** 文件。您也可以使用 [**SWFOptions**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SwfOptions) 類別和 [**NotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/NotesCommentsLayoutingOptions) 類別將註解包含在產生的 SWF 中。

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // 儲存簡報
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常見問題**

**我可以在 SWF 中包含隱藏投影片嗎？**

是的。請在 [SwfOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/swfoptions/) 中使用 [setShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) 方法。預設情況下，隱藏的投影片不會被匯出。

**我如何控制壓縮與最終的 SWF 大小？**

使用 [setCompressed](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/swfoptions/setcompressed/) 方法和 [setJpegQuality](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/swfoptions/setjpegquality/) 來平衡檔案大小與影像品質。

**'setViewerIncluded' 的用途是什麼？何時應使用它？**

[setViewerIncluded](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) 會加入嵌入式播放器 UI（導航控制、面板、搜尋）。如果您打算使用自己的播放器或需要沒有 UI 的純粹 SWF 框架，請使用此設定。

**如果在匯出機器上缺少來源字型會發生什麼情況？**

Aspose.Slides 會在 [SwfOptions](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/swfoptions/) 中使用您透過 [setDefaultRegularFont](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) 指定的字型來取代缺失的字型，以避免意外的備用字型。