---
title: 常見問題
type: docs
weight: 340
url: /zh-hant/cpp/faqs/
keywords:
- 常見問題
- 簡報格式
- 記憶體不足錯誤
- 投影片大小
- 擷取文字
- 取得文字
- 段落大小
- 格式化表格
- 字型
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "取得 Aspose.Slides for C++ 常見問題的答案，涵蓋 PowerPoint 與 OpenDocument 支援、安裝指導、授權資訊與疑難排解。"
---
## **概述**

本常見問題解答提供有關 Aspose.Slides 的常見問題的答案。它涵蓋了支援的檔案格式、處理大檔案簡報時的例外情況、變更投影片尺寸、投影片預覽、從簡報中擷取文字、格式化表格邊框、放置圖片，以及在將簡報轉換為 PDF 或影像時的字型相關問題的解決方案。

## **支援的檔案格式**

**Q: Aspose.Slides for C++ 支援哪些檔案格式？**

**A**: Aspose.Slides for C++ 支援在[Supported File Formats](/slides/zh-hant/cpp/supported-file-formats/)中描述的檔案格式。

## **例外**

**Q: 在載入含有圖片的大型 PPT 檔案時發生記憶體不足例外。Aspose.Slides 在檔案大小方面有任何限制嗎？**

**A**: Aspose.Slides 並沒有特定的公式來計算其支援的簡報大小。記憶體中必須有足夠的空間容納整個簡報結構與圖片。通常，記憶體中的圖片佔用的空間會比硬碟上更大，特別是當圖片具有額外效果時。

一般而言，Aspose.Slides for C++ 在具備 4 GB RAM 的伺服器上可以輕鬆處理約 300 MB 左右的簡報檔案。

## **使用投影片**

**Q: 我可以變更簡報中投影片的尺寸嗎？**

**A**: 您可以使用由[Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/)類別所提供的 `get_SlideSize` 方法來定義簡報中投影片的尺寸。

**Q: 是否有辦法在同一簡報中定義尺寸不同的投影片？**

**A**: 由於投影片的尺寸是在 Microsoft PowerPoint 文件的簡報層級上定義的，因此無法這樣做。

**Q: Aspose.Slides for C++ 是否支援在儲存前預覽投影片？**

**A**: 您可以將簡報投影片渲染為影像，並使用這些影像來預覽投影片。

## **使用文字**

**Q: 是否可以從簡報中擷取所有文字？**

**A**: Aspose.Slides for C++ 在 `Aspose::Slides::Util` 命名空間下提供了 [SlideUtil](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.util/slideutil/) 類別，該類別提供多種方法來擷取簡報中的全部文字。

**Q: 為什麼在 Windows 與 Linux 作業系統上段落大小會不同？**

**A**: 段落大小的計算是根據代表該段落的文字大小來計算的。文字大小的計算依賴於 PowerPoint 簡報中所指定字型的度量。如果指定的字型缺失，系統會以最相似的字型取代，但此字型的度量與原字型不同。因此，在不同系統上計算段落大小會因已安裝的字型集合不同而得到不同的結果。若要在不同作業系統上獲得相同的結果，需在各系統上安裝相同的字型，或在執行時如同 [external fonts](/slides/zh-hant/cpp/custom-font/) 所示載入外部字型。

## **格式化與圖片**

**Q: 如何設定表格邊框的顏色？**

**A**: 您可以變更所有表格邊框的顏色，或僅變更整個表格的外框顏色。若要變更所有邊框，請使用來自 [ICell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/icell/) 介面的 `get_CellFormat` 方法。若要變更整個表格的外框，則需要遍歷儲存格並變更外部邊框的顏色。

**Q: Aspose.Slides for C++ 使用何種度量單位來放置圖片？**

**A**: 投影片上所有圖形的座標與尺寸皆以點 (points) 為單位測量，等同於 72 dpi。

## **使用字型**

**Q: 在將 PPT 轉換為 PDF 或影像時，為什麼輸出文件的字型會不同？**

**A**: 此問題可能表示簡報中使用的字型在執行程式的作業系統上缺失。您應該在作業系統上安裝該字型，或如下使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/fontsloader/) 類別將其作為外部字型載入：
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```