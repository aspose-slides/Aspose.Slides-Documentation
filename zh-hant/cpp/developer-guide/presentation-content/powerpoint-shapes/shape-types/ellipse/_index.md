---
title: 在 C++ 中為簡報新增橢圓形
linktitle: 橢圓
type: docs
weight: 30
url: /zh-hant/cpp/ellipse/
keywords:
- 橢圓
- 形狀
- 新增橢圓
- 建立橢圓
- 繪製橢圓
- 已格式化的橢圓
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "了解如何在 Aspose.Slides for C++ 中於 PPT 與 PPTX 簡報中建立、格式化與操作橢圓形狀 — 搭配 C++ 程式範例。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在 PowerPoint 投影片中加入橢圓形狀。內容涵蓋建立簡單橢圓形、建立已格式化的橢圓形，以及將更新後的簡報儲存為 PPTX 檔案。亦會提及相關問題，例如處理橢圓的定位與尺寸、控制堆疊順序以及套用動畫效果等。

## **建立橢圓形**
在本節中，我們將向開發人員介紹如何使用 Aspose.Slides for C++ 在投影片中加入橢圓形。Aspose.Slides for C++ 提供簡易的 API，只需幾行程式碼即可繪製各種形狀。若要將簡單的橢圓形加入簡報的指定投影片，請依照以下步驟操作：

1. 建立一個 [Presentation 類別](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 的實例
1. 使用 Index 取得投影片的參考
1. 使用 IShapes 物件所公開的 AddAutoShape 方法加入類型為 Ellipse 的 AutoShape
1. 將修改後的簡報寫入為 PPTX 檔案

以下範例在第一張投影片中加入了一個橢圓形。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **建立已格式化的橢圓形**
若要在投影片中加入格式化更佳的橢圓形，請依照以下步驟操作：

1. 建立一個 [Presentation 類別](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 的實例
1. 使用 Index 取得投影片的參考
1. 使用 IShapes 物件所公開的 AddAutoShape 方法加入類型為 Ellipse 的 AutoShape
1. 將橢圓形的填滿類型設定為 Solid
1. 透過與 IShape 物件相關聯的 FillFormat 物件之 SolidFillColor.Color 屬性設定橢圓形的顏色
1. 設定橢圓形線條的顏色
1. 設定橢圓形線條的寬度
1. 將修改後的簡報寫入為 PPTX 檔案

以下範例在簡報的第一張投影片中加入了一個已格式化的橢圓形。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **常見問題**

**如何以投影片單位設定橢圓的精確位置與大小？**

座標與尺寸通常以**點 (point)** 為單位指定。為取得可預測的結果，請以投影片尺寸為基礎，先將所需的毫米或英吋換算成點，再賦值給相關屬性。

**如何將橢圓放置在其他物件之上或之下（控制堆疊順序）？**

調整物件的繪圖順序，將其移到最前面或送到最底層，即可讓橢圓覆蓋其他物件或顯示其下方的物件。

**如何為橢圓設定出現或強調的動畫效果？**

[套用](/slides/zh-hant/cpp/shape-animation/) 進場、強調或退出效果至形狀，並設定觸發條件與時序，以安排動畫的播放時機與方式。