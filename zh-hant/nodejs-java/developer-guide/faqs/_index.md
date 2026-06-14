---
title: 常見問題
type: docs
weight: 340
url: /zh-hant/nodejs-java/faqs/
keywords:
- 常見問題
- 簡報格式
- 記憶體不足錯誤
- 投影片尺寸
- 擷取文字
- 取得文字
- 段落大小
- 格式化表格
- 字型
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "取得有關 Aspose.Slides for Node.js via Java 的常見問題解答，內容涵蓋 PowerPoint 與 OpenDocument 支援、安裝指導、授權資訊與故障排除。"
---
## **概述**

本常見問題解答提供了關於 Aspose.Slides 的常見問題的答案。內容包括支援的檔案格式、處理大型簡報時的例外情況、變更投影片尺寸、預覽投影片、從簡報中擷取文字、格式化表格邊框、放置圖片，以及在將簡報轉換為 PDF 或影像時解決字型相關問題。

## **受支援的檔案格式**

**Q: Aspose.Slides for Node.js via Java 支援哪些檔案格式？**

**A**: Aspose.Slides for Node.js via Java 支援在[Supported File Formats](/slides/zh-hant/nodejs-java/supported-file-formats/)中描述的檔案格式。

## **例外狀況**

**Q: 在載入含有大量影像的大型 PPT 檔案時，我收到記憶體不足例外。Aspose.Slides 對檔案大小有任何限制嗎？**

**A**: Aspose.Slides 沒有特定的公式來計算支援的簡報大小。只要有足夠空間容納整個簡報結構與影像於記憶體中即可。通常，記憶體中的影像佔用的空間會比硬碟上的大，尤其是影像附加了效果時。

一般而言，Aspose.Slides for Node.js via Java 能夠在具備 4 GB RAM 的伺服器上輕鬆處理約 300 MB 大小的簡報檔案。

## **操作投影片**

**Q: 我可以變更簡報中投影片的尺寸嗎？**

**A**: 您可以使用[Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/presentation/)類別所提供的 `getSlideSize` 方法來定義簡報中投影片的尺寸。

**Q: 是否有辦法在同一簡報中定義不同尺寸的投影片？**

**A**: 由於投影片尺寸在 Microsoft PowerPoint 文件中是於簡報層級定義的，無法做到此設定。

**Q: Aspose.Slides for Node.js via Java 是否支援在儲存前預覽投影片？**

**A**: 您可以將簡報投影片渲染成影像，並使用這些影像來預覽投影片。

## **操作文字**

**Q: 是否可以從簡報中擷取所有文字？**

**A**: Aspose.Slides for Node.js via Java 提供了[SlideUtil](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideutil/)類別，該類別提供多種方法可擷取簡報中的完整文字。

**Q: 為何段落大小在 Windows 與 Linux 作業系統上會不同？**

**A**: 段落大小的計算是根據代表該段落的文字大小來進行的。文字大小的計算依賴於 PowerPoint 簡報中指定的字型度量。如果指定的字型缺失，系統會以最相似的字型取代，但該字型的度量可能與原本不同。因此，在不同系統上計算段落大小會因已安裝的字型集合而產生不同結果。若要在不同作業系統上取得相同結果，需要在各系統上安裝相同的字型，或在執行時如同[external fonts](/slides/zh-hant/nodejs-java/custom-font/)那樣載入字型。

## **格式化與影像**

**Q: 如何設定表格邊框的顏色？**

**A**: 您可以變更所有表格邊框的顏色，或僅變更整個表格的外圍邊框顏色。若要變更所有邊框，請使用來自[Cell](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/cell/)類別的 `getCellFormat` 方法。若要變更整個表格的外圍邊框，則需遍歷儲存格並變更外圍邊框的顏色。

**Q: Aspose.Slides for Node.js via Java 使用什麼單位來放置圖片？**

**A**: 投影片上所有形狀的座標與尺寸皆以點 (72 dpi) 為單位。

## **操作字型**

**Q: 在將 PPT 轉換為 PDF 或影像時，為何輸出文件中的字型不同？**

**A**: 此問題可能表示簡報中使用的字型在執行程式的作業系統上不存在。您應在作業系統上安裝該字型，或如下面範例所示使用[FontsLoader](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/fontsloader/)類別將其作為外部字型載入：
```javascript
var folders = java.newArray("java.lang.String", ["path_to_a_folder_with_fonts"]));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", folders);
```