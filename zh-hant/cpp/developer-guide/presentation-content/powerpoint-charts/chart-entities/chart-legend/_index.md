---
title: 使用 С++ 自訂簡報中的圖表圖例
linktitle: 圖例
type: docs
url: /zh-hant/cpp/chart-legend/
keywords:
- 圖表圖例
- 圖例位置
- 字型大小
- PowerPoint
- 簡報
- С++
- Aspose.Slides
description: "使用 Aspose.Slides for С++ 自訂圖表圖例，以量身打造的圖例格式化優化 PowerPoint 簡報。"
---
## **概觀**

Aspose.Slides 提供在 PowerPoint 簡報中自訂圖表圖例的選項。本文說明如何定位與調整圖例大小、設定整個圖例的字型大小，以及對單一圖例項目套用格式。

此外，FAQ 亦包含多項相關行為說明，包括使用非疊加模式讓繪圖區為圖例騰出空間、允許長圖例標籤換行或使用換行字元，以及在未明確設定文字與填充時讓圖例格式繼承簡報主題。

## **圖例定位**
若要設定圖例屬性，請依照以下步驟：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
- 取得投影片的參照。
- 在投影片上新增圖表。
- 設定圖例的屬性。
- 將簡報寫入為 PPTX 檔案。

在下面的範例中，我們為圖表圖例設定了位置與大小。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **設定圖例的字型大小**
Aspose.Slides for C++ 讓開發者能設定圖例的字型大小。請依照以下步驟：

- 實例化 Presentation 類別。
- 建立預設圖表。
- 設定字型大小。
- 設定最小軸值。
- 設定最大軸值。
- 將簡報寫入磁碟。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **設定單一圖例項目的字型大小**
Aspose.Slides for C++ 讓開發者能設定單一圖例項目的字型大小。請依照以下步驟：

- 實例化 Presentation 類別。
- 建立預設圖表。
- 取得圖例項目。
- 設定字型大小。
- 設定最小軸值。
- 設定最大軸值。
- 將簡報寫入磁碟。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **常見問題**

**我可以啟用圖例，讓圖表自動為圖例分配空間，而不是覆蓋它嗎？**

是的。使用非疊加模式（[set_Overlay(false)](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/legend/set_overlay/)）；在此情況下，繪圖區會縮小以容納圖例。

**我可以讓圖例標籤換成多行嗎？**

可以。當空間不足時，長標籤會自動換行；也支援在序列名稱中加入換行字元以強制換行。

**如何讓圖例遵循簡報主題的配色方案？**

不要為圖例或其文字設定明確的顏色、填充或字型。如此一來，圖例將會從主題繼承設定，且在變更設計時會正確更新。