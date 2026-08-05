---
title: 在 C++ 中為簡報圖表加入趨勢線
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
- 冪次趨勢線
- 自訂趨勢線
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "快速在 PowerPoint 圖表中加入並自訂趨勢線，使用 Aspose.Slides for C++ — 實用指南，助您吸引觀眾。"
---
## **概述**

本文說明如何使用 Aspose.Slides 為簡報圖表加入趨勢線。示範如何建立圖表、為圖表系列加入趨勢線，以及使用多種趨勢線類型，包括指數、線性、對數、移動平均、多項式與冪次。

同時說明如何透過插入線條形狀為圖表加入自訂線，並提供關於前向與後向趨勢線投射值、趨勢線在匯出為 PDF 或 SVG 以及將圖表渲染為影像時是否會被保留的簡短 FAQ。

## **新增趨勢線**
Aspose.Slides for C++ 提供簡易的 API 來管理圖表的各種趨勢線：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別的實例。
1. 依索引取得投影片的參照。
1. 使用預設資料加入任意類型的圖表（本例使用 ChartType.ClusteredColumn）。
1. 為第 1 系列的圖表加入指數趨勢線。
1. 為第 1 系列的圖表加入線性趨勢線。
1. 為第 2 系列的圖表加入對數趨勢線。
1. 為第 2 系列的圖表加入移動平均趨勢線。
1. 為第 3 系列的圖表加入多項式趨勢線。
1. 為第 3 系列的圖表加入冪次趨勢線。
1. 將修改後的簡報寫入 PPTX 檔案。

以下程式碼示範如何建立含趨勢線的圖表。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **新增自訂線**
Aspose.Slides for C++ 提供簡易的 API 在圖表中加入自訂線。若要在簡報的特定投影片上加入一條簡單的直線，請依照下列步驟操作：

- 建立 Presentation 類別的實例
- 依索引取得投影片的參照
- 使用 Shapes 物件的 AddChart 方法建立新圖表
- 使用 Shapes 物件的 AddAutoShape 方法加入類型為 Line 的 AutoShape
- 設定形狀線條的顏色
- 將修改後的簡報寫入 PPTX 檔案

以下程式碼示範如何建立含自訂線的圖表。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**「前向」與「後向」在趨勢線中代表什麼意思？**

它們指的是趨勢線向前或向後投射的長度：對散佈圖（XY）而言，以座標軸單位表示；對非散佈圖而言，以類別數量表示。僅允許非負值。

**在將簡報匯出為 PDF 或 SVG，或將投影片渲染為影像時，趨勢線會被保留嗎？**

會。Aspose.Slides 可以將簡報轉換為 [PDF](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/zh-hant/cpp/render-a-slide-as-an-svg-image/) 並將圖表渲染為影像；作為圖表一部分的趨勢線在這些操作中會被保留。亦提供方法可直接 [export an image of the chart](/slides/zh-hant/cpp/create-shape-thumbnails/)。