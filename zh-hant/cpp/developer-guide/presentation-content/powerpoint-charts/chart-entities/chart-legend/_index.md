---
title: 使用 C++ 在簡報中自訂圖表圖例
linktitle: 圖表圖例
type: docs
url: /zh-hant/cpp/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 自訂圖表圖例，透過量身打造的圖例格式化來優化 PowerPoint 簡報。"
---
## **概觀**

Aspose.Slides 提供在 PowerPoint 簡報中自訂圖表圖例的選項。本文說明如何定位與調整圖例大小、設定整個圖例的字型大小，以及對單一圖例項目套用格式。

此外，還在常見問題中討論了相關行為，包括使用非覆蓋模式讓繪圖區域為圖例騰出空間、允許長圖例標籤自動換行或使用換行字元、以及在未設定明確文字與填充時讓圖例格式繼承簡報主題。

## **圖例定位**
設定圖例屬性。請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
- 取得投影片的參照。
- 在投影片上新增圖表。
- 設定圖例的屬性。
- 將簡報寫入為 PPTX 檔案。

在下方範例中，我們已為圖表圖例設定了位置和大小。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}


## **設定圖例的字型大小**
Aspose.Slides for C++ 讓開發人員可以設定圖例的字型大小。請依照以下步驟操作：

- 實例化 Presentation 類別。
- 建立預設圖表。
- 設定字型大小。
- 設定最小軸值。
- 設定最大軸值。
- 將簡報寫入磁碟。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}




## **設定單一圖例項目的字型大小**
Aspose.Slides for C++ 讓開發人員可以設定單一圖例項目的字型大小。請依照以下步驟操作：

- 實例化 Presentation 類別。
- 建立預設圖表。
- 取得圖例項目。
- 設定字型大小。
- 設定最小軸值。
- 設定最大軸值。
- 將簡報寫入磁碟。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **常見問題**

**是否可以啟用圖例，使圖表自動為其分配空間，而不是覆蓋？**

可以。使用非覆蓋模式（[set_Overlay(false)](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/legend/set_overlay/)）；此情況下，繪圖區域會縮小以容納圖例。

**是否可以製作多行圖例標籤？**

可以。當空間不足時，長標籤會自動換行；亦支援在系列名稱中使用換行字元強制換行。

**如何讓圖例遵循簡報主題的色彩方案？**

不要為圖例或其文字設定明確的顏色、填充或字型。如此它們會從主題繼承，且在主題變更時會正確更新。