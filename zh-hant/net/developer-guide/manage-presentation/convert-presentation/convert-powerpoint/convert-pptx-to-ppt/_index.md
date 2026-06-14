---
title: 在 .NET 中將 PPTX 轉換為 PPT
linktitle: PPTX 轉換為 PPT
type: docs
weight: 21
url: /zh-hant/net/convert-pptx-to-ppt/
keywords:
- 轉換 PowerPoint
- 轉換 簡報
- 轉換 投影片
- 轉換 PPTX
- PPTX 轉換為 PPT
- 將 PPTX 儲存為 PPT
- 匯出 PPTX 為 PPT
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 輕鬆將 PPTX 轉換為 PPT——確保與 PowerPoint 格式的無縫相容性，同時保留簡報的版面配置與品質。"
---
## **概述**

本文說明如何使用 C# 將 PowerPoint 簡報的 PPTX 格式轉換為 PPT 格式。以下主題將討論。

- 使用 C# 將 PPTX 轉換為 PPT

## **在 .NET 中將 PPTX 轉換為 PPT**

若要取得 C# 範例程式碼將 PPTX 轉換為 PPT，請參閱以下章節 [將 PPTX 轉換為 PPT](#convert-pptx-to-ppt)。它僅會載入 PPTX 檔案並以 PPT 格式儲存。透過指定不同的儲存格式，您也可以將 PPTX 檔案儲存為多種其他格式，例如 PDF、XPS、ODP、HTML 等，相關說明請參考以下文章。

- [在 .NET 中將 PPTX 轉換為 PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)
- [在 .NET 中將 PPTX 轉換為 XPS](/slides/zh-hant/net/convert-powerpoint-to-xps/)
- [在 .NET 中將 PPTX 轉換為 HTML](/slides/zh-hant/net/convert-powerpoint-to-html/)
- [在 .NET 中將 PPTX 轉換為 ODP](/slides/zh-hant/net/save-presentation/)
- [在 .NET 中將 PPTX 轉換為 PNG](/slides/zh-hant/net/convert-powerpoint-to-png/)

## **將 PPTX 轉換為 PPT**
要將 PPTX 轉換為 PPT，只需將檔案名稱和儲存格式傳遞給 [**儲存**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/save/) 方法，該方法屬於 [**Presentation**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別。以下 C# 程式碼範例使用預設選項將簡報從 PPTX 轉換為 PPT。

```c#
// 建立一個代表 PPTX 檔案的 Presentation 物件
Presentation pres = new Presentation("presentation.pptx");

// 將 PPTX 簡報儲存為 PPT 格式
pres.Save("presentation.ppt", SaveFormat.Ppt);
```

## **常見問題**

**將 PPTX 的所有效果和功能在儲存為舊版 PPT（97–2003）格式時是否都能保留？**

並非總是如此。PPT 格式缺乏某些較新的功能（例如特定的效果、物件和行為），因此在轉換過程中可能會被簡化或轉為點陣圖。

**我可以只將選取的投影片轉換為 PPT，而不是整份簡報嗎？**

直接儲存會針對整份簡報。若要轉換特定投影片，請先建立只包含這些投影片的新簡報，然後將其儲存為 PPT；或者使用支援逐張投影片轉換參數的服務或 API。

**是否支援受密碼保護的簡報？**

是的。您可以偵測檔案是否受保護、使用密碼開啟，此外亦可為儲存的 PPT [設定保護/加密設定](/slides/zh-hant/net/password-protected-presentation/)。