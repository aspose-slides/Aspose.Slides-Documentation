---
title: 在 C++ 中將 PowerPoint 簡報轉換為 SWF Flash
linktitle: PowerPoint 轉 SWF
type: docs
weight: 80
url: /zh-hant/cpp/convert-powerpoint-to-swf-flash/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
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
- 將 PPT 儲存為 SWF
- 將 PPTX 儲存為 SWF
- 匯出 PPT 為 SWF
- 匯出 PPTX 為 SWF
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint（PPT/PPTX）轉換為 SWF Flash。逐步程式碼範例、快速高品質輸出，無需 PowerPoint 自動化。"
---
## **概述**

本文說明如何使用 Aspose.Slides 將 PowerPoint 簡報轉換為 SWF。它展示了如何使用 [Presentation::Save](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/save/) 方法將簡報儲存為 SWF 檔案，並說明如何使用 [SwfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/swfoptions/) 來設定匯出，包括檢視器設定以及註解或備註的版面配置。

## **將簡報轉換為 Flash**

[Save](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) 方法由 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別提供，可用於將整個簡報轉換為 SWF 文件。您也可以使用 [SWFOptions](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.export.swf_options) 類別和 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/notescommentslayoutingoptions/) 類別在產生的 SWF 中包含註解。以下範例示範如何使用 SWFOptions 類別提供的選項將簡報轉換為 SWF 文件。

``` cpp
// 文件目錄的路徑。
    // 建立代表簡報檔案的 Presentation 物件
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // 儲存簡報與註解頁面
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **常見問題**

**我可以在 SWF 中包含隱藏投影片嗎？**

是。使用 [set_ShowHiddenSlides](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) 方法於 [SwfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/swfoptions/)。預設情況下，隱藏投影片不會被匯出。

**我如何控制壓縮與最終 SWF 檔案大小？**

使用 [set_Compressed](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/swfoptions/set_compressed/) 方法，並調整 [JPEG quality](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/swfoptions/set_jpegquality/) 以在檔案大小與影像品質之間取得平衡。

**‘set_ViewerIncluded’ 的用途是什麼？什麼時候應該使用它？**

[set_ViewerIncluded](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) 會加入嵌入式播放器 UI（導航控制、面板、搜尋）。如果您打算使用自訂播放器，或需要沒有 UI 的純粹 SWF 框架，請將其停用。

**如果匯出機器上缺少來源字型會發生什麼情況？**

Aspose.Slides 會使用您在 [SwfOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/swfoptions/) 中透過 [set_DefaultRegularFont](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) 指定的字型來取代缺失的字型，以避免不預期的回退。