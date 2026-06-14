---
title: 常見問題
type: docs
weight: 340
url: /zh-hant/java/faqs/
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
- Java
- Aspose.Slides
description: "取得有關 Aspose.Slides for Java 的常見問題解答，涵蓋 PowerPoint 與 OpenDocument 支援、安裝指引、授權及除錯說明。"
---
## **概述**

本常見問題解答提供了有關 Aspose.Slides 的常見問題的答案。它涵蓋了支援的檔案格式、處理大型簡報時的例外情況、變更投影片尺寸、預覽投影片、從簡報中擷取文字、格式化表格邊框、放置圖片，以及在將簡報轉換為 PDF 或圖片時解決字型相關問題。

## **支援的檔案格式**

**Q:** Aspose.Slides for Java 支援哪些檔案格式？

**A:** Aspose.Slides for Java 支援在[Supported File Formats](/slides/zh-hant/java/supported-file-formats/)中描述的檔案格式。

## **例外情況**

**Q:** 在載入包含圖片的大型 PPT 檔案時，我收到記憶體不足的例外。Aspose.Slides 對檔案大小有任何限制嗎？

**A:** 沒有特定的公式可計算 Aspose.Slides 支援的簡報大小。記憶體中必須有足夠空間容納整個簡報結構與圖片。通常，記憶體中的圖片佔用的空間比硬碟上大，特別是當圖片具有額外效果時。

一般而言，Aspose.Slides for Java 能在具有 4 GB RAM 的伺服器上輕鬆處理約 300 MB 的簡報檔案。

## **操作投影片**

**Q:** 我可以變更簡報中投影片的大小嗎？

**A:** 您可以使用由[Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/)類別所提供的 `getSlideSize` 方法來定義簡報中投影片的大小。

**Q:** 有沒有辦法在簡報中定義不同大小的投影片？

**A:** 由於投影片的大小在 Microsoft PowerPoint 文件中是於簡報層級定義的，因此無法這樣做。

**Q:** Aspose.Slides for Java 是否支援在儲存前預覽投影片？

**A:** 您可以將簡報投影片渲染成圖片，並使用這些圖片來預覽投影片。

## **操作文字**

**Q:** 是否能從簡報中擷取全部文字？

**A:** Aspose.Slides for Java 提供了[SlideUtil](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/slideutil/)類別，該類別提供多種方法來擷取簡報中的全部文字。

**Q:** 為什麼段落大小在 Windows 與 Linux 作業系統上會不同？

**A:** 段落大小的計算是根據代表該段落之文字大小的計算。文字大小的計算依賴於 PowerPoint 簡報中指定的字型度量。如果指定的字型缺少，系統會以最相似的字型取代，但此字型的度量與原始字型不同。因此，在不同系統上計算段落大小時，會因已安裝的字型集合不同而得到不同結果。若要在不同作業系統上取得相同結果，需在各系統上安裝相同的字型，或在執行時以[external fonts](/slides/zh-hant/java/custom-font/)載入外部字型。

## **格式化與圖片**

**Q:** 如何設定表格邊框的顏色？

**A:** 您可以變更所有表格邊框的顏色，或僅變更整個表格的外框顏色。若要變更所有邊框，請使用來自[ICell](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/icell/)介面的 `getCellFormat` 方法。若要變更整個表格的外框，則需遍歷儲存格並變更外部邊框的顏色。

**Q:** Aspose.Slides for Java 使用什麼單位來放置圖片？

**A:** 投影片上所有圖形的座標與尺寸均以點 (points) 為單位測量，等同於 72 dpi。

## **操作字型**

**Q:** 在將 PPT 轉換為 PDF 或圖片時，為什麼輸出文件的字型會不同？

**A:** 此問題可能表示簡報中使用的字型在執行程式的作業系統上不存在。您應該在作業系統上安裝該字型，或如以下範例所示，使用[FontsLoader](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/fontsloader/)類別將其作為外部字型載入：
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```