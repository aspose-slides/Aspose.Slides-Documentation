---
title: 在 С++ 簡報圖表中添加趨勢線
linktitle: 趨勢線
type: docs
url: /zh-hant/cpp/trend-line/
keywords:
- 圖表
- 趨勢線
- 指數趨勢線
- 線性趨勢線
- 對數趨勢線
- 移動平均趨勢線
- 多項式趨勢線
- 冪趨勢線
- 自訂趨勢線
- PowerPoint
- 簡報
- С++
- Aspose.Slides
description: "快速在 PowerPoint 圖表中使用 Aspose.Slides for С++ 添加並自訂趨勢線 — 實用指南，助您吸引觀眾。"
---
## **概述**

本文說明如何使用 Aspose.Slides 為簡報圖表添加趨勢線。它展示了如何建立圖表、為圖表系列添加趨勢線，並處理多種趨勢線類型，包括指數、線性、對數、移動平均、多項式和冪。

它同時說明如何透過插入線條形狀為圖表添加自訂線，並包含一段簡短的 FAQ，說明趨勢線的前向與後向投射值的意義，以及趨勢線在匯出為 PDF 或 SVG，或將圖表渲染為影像時是否會被保留。

## **添加趨勢線**
Aspose.Slides for C++ 提供簡易的 API 以管理圖表的不同趨勢線：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
2. 依照索引取得投影片的參照。
3. 加入具有預設資料的圖表，並使用任意所需類型（本例使用 ChartType.ClusteredColumn）。
4. 為圖表系列 1 添加指數趨勢線。
5. 為圖表系列 1 添加線性趨勢線。
6. 為圖表系列 2 添加對數趨勢線。
7. 為圖表系列 2 添加移動平均趨勢線。
8. 為圖表系列 3 添加多項式趨勢線。
9. 為圖表系列 3 添加冪趨勢線。
10. 將修改後的簡報寫入 PPTX 檔案。

以下程式碼用於建立帶有趨勢線的圖表。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **添加自訂線條**
Aspose.Slides for C++ 提供簡易的 API 以在圖表中加入自訂線條。若要在簡報的特定投影片上添加簡單的直線，請依照下列步驟操作：

- 建立 Presentation 類別的實例
- 使用索引取得投影片的參照
- 使用 Shapes 物件的 AddChart 方法建立新圖表
- 使用 Shapes 物件的 AddAutoShape 方法加入線條類型的 AutoShape
- 設定圖形線條的顏色。
- 將修改後的簡報寫入 PPTX 檔案

以下程式碼用於建立帶有自訂線條的圖表。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **常見問題**

**趨勢線的「前向」與「後向」是什麼意思？**

它們是趨勢線向前或向後延伸的長度：對於散點 (XY) 圖表，以座標軸單位表示；對於非散點圖表，以類別數量表示。僅允許非負值。

**將簡報匯出為 PDF 或 SVG，或將投影片渲染為影像時，趨勢線會被保留嗎？**

是。Aspose.Slides 會將簡報轉換為 [PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/)，並將圖表渲染為影像；作為圖表一部分的趨勢線在這些操作中會被保留。也提供了一個方法可[匯出圖表的影像](/slides/zh-hant/cpp/create-shape-thumbnails/)。