---
title: 在 C++ 中將 PPTX 轉換為 PPT
linktitle: PPTX 轉 PPT
type: docs
weight: 21
url: /zh-hant/cpp/convert-pptx-to-ppt/
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
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 輕鬆將 PPTX 轉換為 PPT——確保與 PowerPoint 格式的無縫相容，同時保留簡報的版面配置與品質。"
---
## **概述**

本文說明如何使用 C++ 將 PowerPoint 簡報的 PPTX 格式轉換為 PPT 格式。以下主題已涵蓋。

- 使用 C++ 將 PPTX 轉換為 PPT

## **使用 C++ 將 PPTX 轉換為 PPT**

若要取得 C++ 範例程式碼將 PPTX 轉換為 PPT，請參閱下方的區段，即 [Convert PPTX to PPT](#convert-pptx-to-ppt)。它僅會載入 PPTX 檔案並儲存為 PPT 格式。透過指定不同的儲存格式，您也可以將 PPTX 檔案儲存為許多其他格式，如 PDF、XPS、ODP、HTML 等，詳見以下文章。

- [使用 C++ 將 PPTX 轉換為 PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)
- [使用 C++ 將 PPTX 轉換為 XPS](/slides/zh-hant/cpp/convert-powerpoint-to-xps/)
- [使用 C++ 將 PPTX 轉換為 HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/)
- [使用 C++ 將 PPTX 轉換為 ODP](/slides/zh-hant/cpp/save-presentation/)
- [使用 C++ 將 PPTX 轉換為 PNG](/slides/zh-hant/cpp/convert-powerpoint-to-png/)

## **將 PPTX 轉換為 PPT**
要將 PPTX 轉換為 PPT，只需將檔名與儲存格式傳遞給 [**Presentation**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation/) 類別的 **Save** 方法。以下 C++ 程式碼範例使用預設選項將 Presentation 從 PPTX 轉換為 PPT。

```cpp
// 載入 PPTX。
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// 以 PPT 格式儲存。
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **常見問題**

**將 PPTX 的所有效果與功能儲存為舊版 PPT (97–2003) 格式時，是否會全部保留？**

不一定。PPT 格式缺乏某些較新的功能（例如特定效果、物件和行為），因此在轉換過程中，功能可能會被簡化或轉為點陣圖。

**我可以只將選取的投影片轉換為 PPT，而不是整個簡報嗎？**

直接儲存會針對整份簡報。若要轉換特定投影片，請建立僅包含該投影片的新簡報並將其儲存為 PPT；或者使用支援逐投影片轉換參數的服務或 API。

**是否支援受密碼保護的簡報？**

是的。您可以偵測檔案是否受保護、使用密碼開啟，亦可為儲存的 PPT [設定保護/加密設定](/slides/zh-hant/cpp/password-protected-presentation/)。