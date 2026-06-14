---
title: 在 .NET 中將 PowerPoint 簡報轉換為 SWF Flash
linktitle: PowerPoint 轉換為 SWF
type: docs
weight: 80
url: /zh-hant/net/convert-powerpoint-to-swf-flash/
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
- 將 PPTX 儲存為 SWF
- 匯出 PPT 為 SWF
- 匯出 PPTX 為 SWF
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 .NET 中使用 Aspose.Slides 將 PowerPoint（PPT/PPTX）轉換為 SWF Flash。一步一步的 C# 程式碼範例，快速且高品質的輸出，無需 PowerPoint 自動化。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 SWF。它展示了如何使用 [Presentation.Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法將簡報另存為 SWF 檔案，以及如何使用 [SwfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/swfoptions/) 進行匯出設定，包括檢視器設定和筆記或註解的版面配置。

## **將簡報轉換為 Flash**

由 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別所提供的 [Save](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/methods/save/index) 方法可用於將整個簡報轉換為 SWF 文件。您也可以透過使用 [SWFOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/swfoptions) 類別和 [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/inotescommentslayoutingoptions) 介面，在產生的 SWF 中加入註解。以下範例示範如何使用 SWFOptions 類別提供的選項，將簡報轉換為 SWF 文件。

```c#
// 實例化一個代表簡報檔案的 Presentation 物件
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // 儲存簡報與註解頁面
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **常見問題**

**我可以在 SWF 中包含隱藏投影片嗎？**

可以。請在 [SwfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/swfoptions/) 中啟用 [ShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/swfoptions/showhiddenslides/) 選項。預設情況下，隱藏投影片不會被匯出。

**我該如何控制壓縮以及最終的 SWF 大小？**

使用 [Compressed](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/swfoptions/compressed/) 旗標（預設已啟用），並調整 [JpegQuality](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/swfoptions/jpegquality/) 以在檔案大小與影像品質之間取得平衡。

**‘ViewerIncluded’ 的作用是什麼？何時應該停用它？**

[ViewerIncluded](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/swfoptions/viewerincluded/) 會加入嵌入式播放器 UI（導覽控制、面板、搜尋）。若您打算使用自訂播放器或需要沒有 UI 的純粹 SWF 框架，請將其停用。

**如果匯出機器缺少來源字型，會發生什麼情況？**

Aspose.Slides 會在 [SwfOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveoptions/) 中使用您透過 [DefaultRegularFont](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.export/saveoptions/defaultregularfont/) 指定的字型進行替換，以避免意外的字型回退。