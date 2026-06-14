---
title: 常見問題
type: docs
weight: 340
url: /zh-hant/androidjava/faqs/
keywords:
- 常見問題
- 簡報格式
- 記憶體不足錯誤
- 投影片大小
- 抽取文字
- 取得文字
- 段落大小
- 格式化表格
- 字型
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "取得有關 Aspose.Slides for Android via Java 的常見問題解答，涵蓋 PowerPoint 與 OpenDocument 支援、安裝指南、授權、除錯等內容。"
---
## **概覽**

此常見問題集提供有關 Aspose.Slides 的常見問題的答案。它涵蓋支援的檔案格式、處理大型簡報時的例外情況、變更投影片尺寸、預覽投影片、從簡報中擷取文字、格式化表格邊框、放置圖片，以及在將簡報轉換為 PDF 或圖片時解決字型相關問題。

## **支援的檔案格式**

**問：Aspose.Slides for Android via Java 支援哪些檔案格式？**

**答**：Aspose.Slides for Android via Java 支援在[Supported File Formats](/slides/zh-hant/androidjava/supported-file-formats/)中描述的檔案格式。

## **例外情況**

**問：在載入包含圖片的大型 PPT 檔時，我收到記憶體不足的例外。Aspose.Slides 在檔案大小上有任何限制嗎？**

**答**：沒有特定的公式來計算 Aspose.Slides 支援的簡報大小。必須有足夠的空間在記憶體中容納整個簡報結構和圖片。通常，記憶體中的圖片會佔用比硬碟上更多的空間，特別是當圖片具有額外效果時。

一般而言，Aspose.Slides for Android via Java 能在具備 4 GB RAM 的伺服器上輕鬆處理約 300 MB 的簡報檔案。

## **操作投影片**

**問：我可以變更簡報中投影片的尺寸嗎？**

**答**：您可以使用由[Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/)類別所公開的 `getSlideSize` 方法來定義簡報中投影片的尺寸。

**問：是否有方法在同一簡報中定義不同尺寸的投影片？**

**答**：由於在 Microsoft PowerPoint 檔案中投影片尺寸是在簡報層級定義的，無法這樣做。

**問：Aspose.Slides for Android via Java 是否支援在保存前預覽投影片？**

**答**：您可以將簡報投影片渲染為影像，並可使用這些影像來預覽投影片。

## **操作文字**

**問：是否可以從簡報中擷取所有文字？**

**答**：Aspose.Slides for Android via Java 提供 [SlideUtil](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/slideutil/) 類別，該類別提供各種方法以擷取簡報中的全部文字。

**問：為什麼段落大小在 PC 與 Android 上不同？**

**答**：段落大小的計算基於表示給定段落的文字大小計算。文字大小的計算依賴於 PowerPoint 簡報中指定字型的度量資訊。若指定的字型缺失，系統會以最相似的字型取代，但該字型的度量資訊與原始字型不同。結果是不同系統的段落大小計算會因安裝的字型集合不同而產生差異。若要在不同作業系統上取得相同結果，必須在系統上安裝相同的字型，或在執行時如[外部字型](/slides/zh-hant/androidjava/custom-font/)所示載入。

## **格式化與圖片**

**問：如何設定表格邊框的顏色？**

**答**：您可以變更所有表格邊框的顏色或僅變更整個表格的外圍邊框。若要變更所有邊框，請使用 [ICell](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/icell/) 介面的 `getCellFormat` 方法。若要變更整個表格的外圍邊框，則需遍歷儲存格並變更外部邊框的顏色。

**問：Aspose.Slides for Android via Java 使用何種度量單位來放置圖片？**

**答**：投影片上所有形狀的座標與尺寸以點 (point) 為單位 (72 dpi)。

## **操作字型**

**問：將 PPT 轉換為 PDF 或圖片時，為什麼輸出文件的字型不同？**

**答**：此問題可能表示簡報中使用的字型在執行程式碼的作業系統上不存在。您應在作業系統上安裝這些字型，或如以下範例所示，使用 [FontsLoader](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/fontsloader/) 類別將其作為外部字型載入：
```java
String[] folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```