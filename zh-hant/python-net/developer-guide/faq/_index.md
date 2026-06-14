---
title: 常見問題
type: docs
weight: 340
url: /zh-hant/python-net/faq/
keywords:
- 常見問題
- 簡報格式
- 記憶體不足錯誤
- 投影片大小
- 擷取文字
- 取得文字
- 段落大小
- 表格格式化
- 字型
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "取得 Aspose.Slides for Python via .NET 的常見問題答案，涵蓋 PowerPoint 與 OpenDocument 支援、安裝指引、授權資訊與疑難排解。"
---
## **概述**

此常見問題說明提供有關 Aspose.Slides 的常見問題答案。它涵蓋支援的檔案格式、處理大型簡報時的例外情況、變更投影片大小、預覽投影片、從簡報中擷取文字、格式化表格邊框、放置圖片，以及在將簡報轉換為 PDF 或圖像時解決與字型相關的問題。

## **支援的檔案格式**

**Q: Aspose.Slides for Python via .NET 支援哪些檔案格式？**

**A**: Aspose.Slides for Python via .NET 支援在 [Supported File Formats](/slides/zh-hant/python-net/supported-file-formats/) 中所述的檔案格式。

## **例外情況**

**Q: 在載入包含影像的大型 PPT 檔案時，我收到記憶體不足例外。Aspose.Slides 對檔案大小有任何限制嗎？**

**A**: 並沒有特定的公式可用於計算 Aspose.Slides 所支援的簡報大小。記憶體中應該有足夠的空間容納整個簡報結構與影像。通常，記憶體中的影像佔用的空間比硬碟上多，特別是當影像具有額外效果時。

一般而言，Aspose.Slides for Python via .NET 能在具 4 GB 記憶體的伺服器上輕鬆處理約 300 MB 大小的簡報檔案。

## **處理投影片**

**Q: 我可以變更簡報中投影片的大小嗎？**

**A**: 您可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/) 類別所提供的 `slide_size` 屬性來定義簡報中投影片的大小。

**Q: 是否有辦法在同一簡報中定義不同大小的投影片？**

**A**: 由於在 Microsoft PowerPoint 文件中，投影片的大小是於簡報層級定義的，因此無法這樣做。

**Q: Aspose.Slides for Python via .NET 是否支援在儲存前預覽投影片？**

**A**: 您可以將簡報投影片渲染成圖像，並使用這些圖像來預覽投影片。

## **處理文字**

**Q: 是否可以擷取簡報中的所有文字？**

**A**: Aspose.Slides for Python via .NET 在 `aspose.slides.util` 命名空間下提供了 [SlideUtil](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.util/slideutil/) 類別，該類別提供多種方法以擷取簡報中的全部文字。

**Q: 為什麼在 Windows 與 Linux 作業系統上段落大小會不同？**

**A**: 段落大小的計算是根據代表該段落之文字的大小來進行。文字大小的計算依賴於 PowerPoint 簡報中指定的字型度量。如果指定的字型缺失，系統會以最相似的字型替代，但此字型的度量與原始字型不同。結果是，不同系統上由於安裝的字型集合不同，段落大小的計算會產生不同的結果。若要在不同作業系統上得到相同的結果，必須在各系統上安裝相同的字型，或在執行時如同[外部字型](/slides/zh-hant/python-net/custom-font/) 那樣載入它們。

## **格式化與圖像**

**Q: 如何設定表格邊框的顏色？**

**A**: 您可以變更所有表格邊框的顏色，或僅變更整個表格的外框顏色。若要變更所有邊框，請使用來自 [Cell](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/cell/) 類別的 `cell_format` 屬性。若要變更整個表格的外框，則需遍歷儲存格並變更外側邊框的顏色。

**Q: Aspose.Slides for Python via .NET 使用什麼單位來放置圖片？**

**A**: 投影片上所有形狀的座標與大小皆以點 (points) 為單位測量，1 點等於 72 dpi。

## **處理字型**

**Q: 在將 PPT 轉換為 PDF 或圖像時，為什麼輸出文件中的字型會不同？**

**A**: 此問題可能表示簡報中使用的字型在執行程式的作業系統上不存在。您應該在作業系統上安裝該字型，或如下所示使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/fontsloader/) 類別將其作為外部字型載入：

```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```