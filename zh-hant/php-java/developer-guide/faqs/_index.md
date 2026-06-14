---
title: 常見問題
type: docs
weight: 340
url: /zh-hant/php-java/faqs/
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
- PHP
- Aspose.Slides
description: "取得有關 Aspose.Slides for PHP via Java 的常見問題解答，涵蓋 PowerPoint 和 OpenDocument 支援、安裝指南、授權以及故障排除。"
---
## **概述**

此常見問題集提供有關 Aspose.Slides 的常見問題的答案。它涵蓋支援的檔案格式、處理大型簡報時的例外情況、變更投影片大小、預覽投影片、從簡報中擷取文字、格式化表格邊框、放置圖片，以及在將簡報轉換為 PDF 或影像時解決字型相關問題。

## **支援的檔案格式**

**Q: Aspose.Slides for PHP via Java 支援哪些檔案格式？**

**A**: Aspose.Slides for PHP via Java 支援在 [Supported File Formats](/slides/zh-hant/php-java/supported-file-formats/) 中描述的檔案格式。

## **例外情況**

**Q: 我在載入含有圖片的大型 PPT 檔案時出現記憶體不足例外。Aspose.Slides 對檔案大小是否有限制？**

**A**: 沒有特定的公式可計算 Aspose.Slides 支援的簡報大小。只要有足夠的空間在記憶體中容納整個簡報結構與圖片即可。通常，記憶體中的圖片會佔用比硬碟更多的空間，特別是當圖片具備額外效果時。

一般而言，Aspose.Slides for PHP via Java 在具備 4 GB RAM 的伺服器上可以輕鬆處理約 300 MB 的簡報檔案。

## **操作投影片**

**Q: 我可以變更簡報中投影片的大小嗎？**

**A**: 您可以使用由 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 類別所提供的 `getSlideSize` 方法來定義簡報中投影片的大小。

**Q: 是否有辦法在簡報中定義不同大小的投影片？**

**A**: 由於在 Microsoft PowerPoint 文件中，投影片的大小是於簡報層級定義的，因此無法這麼做。

**Q: Aspose.Slides for PHP via Java 是否支援在儲存前預覽投影片？**

**A**: 您可以將簡報投影片渲染為影像，並使用這些影像來預覽投影片。

## **操作文字**

**Q: 是否能從簡報中取得所有文字？**

**A**: Aspose.Slides for PHP via Java 提供 [SlideUtil](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/slideutil/) 類別，該類別提供多種方法以從簡報中擷取全部文字。

**Q: 為什麼段落大小在 Windows 與 Linux 作業系統上會不同？**

**A**: 段落大小的計算是根據表示該段落的文字大小計算而來。文字大小的計算基於 PowerPoint 簡報中指定字型的度量。如果指定的字型缺失，系統會以最相似的字型取代，但該字型的度量與原始字型不同。因此，不同系統下的段落大小計算會因安裝的字型集合不同而產生不同結果。若要在不同作業系統上獲得相同結果，必須在各系統上安裝相同的字型，或在執行時如同 [external fonts](/slides/zh-hant/php-java/custom-font/) 那樣載入外部字型。

## **格式化與圖片**

**Q: 我該如何設定表格邊框的顏色？**

**A**: 您可以變更所有表格邊框的顏色，亦可只變更整個表格的外圍邊框。若要變更所有邊框，請使用 [Cell](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/cell/) 類別的 `getCellFormat` 方法。若要變更整個表格的外圍邊框，則需要遍歷儲存格並變更外部邊框的顏色。

**Q: Aspose.Slides for PHP via Java 在放置圖片時使用什麼單位？**

**A**: 投影片上所有圖形的座標與尺寸均以點 (points) 為單位（72 dpi）。

## **操作字型**

**Q: 在將 PPT 轉換為 PDF 或影像時，為什麼輸出文件的字型不同？**

**A**: 此問題可能表示簡報中使用的字型在執行程式的作業系統中缺失。您應在作業系統上安裝該字型，或如以下示範，使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/fontsloader/) 類別將其作為外部字型載入：
```php
$folders = ["path_to_a_folder_with_fonts"];
FontsLoader::loadExternalFonts($folders);
```