---
title: 常見問題
type: docs
weight: 340
url: /zh-hant/net/faqs/
keywords:
- 常見問題
- PowerPoint
- 簡報格式
- 記憶體不足錯誤
- 投影片大小
- 擷取文字
- 取得文字
- 段落大小
- 表格格式化
- 字型
- .NET
- C#
- Aspose.Slides
description: "取得 Aspose.Slides for .NET 的常見問題解答，涵蓋 PowerPoint 與 OpenDocument 支援、安裝指南、授權資訊與故障排除。"
---
## **概覽**

本常見問題提供有關 Aspose.Slides 的常見問題答案。內容涵蓋受支援的檔案格式、處理大型簡報時的例外狀況、變更投影片尺寸、投影片預覽、從簡報中擷取文字、格式化表格框線、放置圖片，以及在將簡報轉換為 PDF 或影像時的字型相關問題的解決方案。

## **受支援的檔案格式**

**Q: Aspose.Slides for .NET 支援哪些檔案格式？**

**A**: Aspose.Slides for .NET 支援在[受支援的檔案格式](/slides/zh-hant/net/supported-file-formats/)中描述的檔案格式。

## **例外狀況**

**Q: 我在載入含有大量影像的 PPT 檔時收到 OutOfMemoryException。Aspose.Slides 在檔案大小上有任何限制嗎？**

**A**: 沒有特定的公式可計算 Aspose.Slides 支援的簡報大小。必須有足夠的記憶體空間來容納整個簡報結構與影像。通常，記憶體中的影像佔用的空間會比硬碟上的大，尤其是影像具有額外效果時。

一般而言，Aspose.Slides for .NET 能在具備 4 GB RAM 的伺服器上輕鬆處理約 300 MB 的簡報檔案。

## **操作投影片**

**Q: 我可以變更簡報中投影片的大小嗎？**

**A**: 您可以使用 `SlideSize` 屬性（由 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 類別提供）來定義簡報中投影片的大小。

**Q: 能否在同一簡報中定義不同大小的投影片？**

**A**: 由於投影片的大小是在 Microsoft PowerPoint 文件的簡報層級定義的，無法實現此功能。

**Q: Aspose.Slides for .NET 支援在儲存前預覽投影片嗎？**

**A**: 您可以將簡報投影片渲染成影像，並使用這些影像來預覽投影片。

## **操作文字**

**Q: 是否可以取得簡報中的所有文字？**

**A**: Aspose.Slides for .NET 提供位於 `Aspose.Slides.Util` 命名空間下的 [SlideUtil](https://reference.aspose.com/slides/zh-hant/net/aspose.slides.util/slideutil/) 類別，該類別提供多種方法以取得簡報的完整文字內容。

**Q: 為何在 Windows 與 Linux 作業系統上段落大小不同？**

**A**: 段落大小的計算是根據該段落文字的尺寸來決定，而文字尺寸的計算依賴於 PowerPoint 簡報中指定的字型度量。如果指定的字型缺失，系統會以最相近的字型取代，但該字型的度量與原字型不同。因此，在不同系統上計算段落大小時會因已安裝的字型集合不同而產生差異。若要在不同作業系統上獲得相同結果，必須在各系統上安裝相同的字型，或在執行時以[外部字型](/slides/zh-hant/net/custom-font/)方式載入。

## **格式化與影像**

**Q: 如何設定表格框線的顏色？**

**A**: 您可以變更所有表格框線的顏色，或僅變更整個表格外圍的框線。若要變更所有框線，請使用來自 [ICell](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/icell/) 介面的 `CellFormat` 屬性。若要變更整個表格的外框，則需遍歷儲存格並變更外圍框線的顏色。

**Q: Aspose.Slides for .NET 在放置圖片時使用什麼單位？**

**A**: 投影片上所有圖形的座標與尺寸均以點 (points) 為單位測量，亦即 72 dpi。

## **操作字型**

**Q: 在將 PPT 轉換為 PDF 或影像時，為何輸出文件的字型與原檔不同？**

**A**: 這可能表示執行程式的作業系統中缺少簡報所使用的字型。您應在作業系統中安裝該字型，或使用以下方式以外部字型方式載入：
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```