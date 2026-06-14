---
title: 在 C++ 中向簡報新增矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh-hant/cpp/rectangle/
keywords:
- 新增矩形
- 建立矩形
- 矩形形狀
- 簡單矩形
- 格式化矩形
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 添加矩形，提升您的 PowerPoint 簡報——輕鬆以程式方式設計和修改形狀。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 向 PowerPoint 投影片中新增矩形形狀。內容涵蓋建立簡單矩形、建立格式化矩形，以及將更新後的簡報儲存為 PPTX 檔案。

## **建立簡單矩形**
如同先前的主題，此篇同樣是說明新增形狀，而本次討論的形狀是 Rectangle。本文說明開發人員如何使用 Aspose.Slides for C++ 在投影片中新增簡單或格式化矩形。若要在簡報的選定投影片中加入簡單矩形，請依照下列步驟操作：

1. 建立 [Presentation 類別](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 的實例。
1. 使用 Index 取得投影片的參考。
1. 使用 IShapes 物件提供的 AddAutoShape 方法，新增一個 Rectangle 類型的 IAutoShape。
1. 將修改後的簡報寫入為 PPTX 檔案。

在下方示例中，我們已在簡報的第一張投影片加入一個簡單矩形。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **建立格式化矩形**
若要在投影片中加入格式化矩形，請依照下列步驟操作：

1. 建立 [Presentation 類別](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 的實例。
1. 使用 Index 取得投影片的參考。
1. 使用 IShapes 物件提供的 AddAutoShape 方法，新增一個 Rectangle 類型的 IAutoShape。
1. 將矩形的填充類型設為實心 (Solid)。
1. 使用與 IShape 物件相關聯的 FillFormat 物件所公開的 SolidFillColor.Color 屬性設定矩形的顏色。
1. 設定矩形邊框的顏色。
1. 設定矩形邊框的寬度。
1. 將修改後的簡報寫入為 PPTX 檔案。  
上述步驟已於下方示例中實作。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**如何新增具有圓角的矩形？**

使用圓角的 [shape type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapetype/) 並在形狀屬性中調整角半徑；也可以透過幾何調整對每個角分別套用圓角。

**如何以影像（材質）填滿矩形？**

選擇圖片的 [fill type](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/filltype/)，提供影像來源，並設定 [stretching/tiling modes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/picturefillmode/)。

**矩形可以有陰影和發光效果嗎？**

可以。[Outer/inner shadow, glow, and soft edges](/slides/zh-hant/cpp/shape-effect/) 提供可調整的參數。

**我可以將矩形轉換為帶有超連結的按鈕嗎？**

可以。透過 [Assign a hyperlink](/slides/zh-hant/cpp/manage-hyperlinks/) 為形狀點擊設定超連結（跳轉至投影片、檔案、網址或電子郵件）。

**如何保護矩形不被移動或更改？**

使用 [Use shape locks](/slides/zh-hant/cpp/applying-protection-to-presentation/)：您可以禁止移動、調整大小、選取或文字編輯，以維持版面配置。

**我可以將矩形轉換為點陣圖或 SVG 嗎？**

可以。您可以將 [render the shape](http://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/getimage/) 以指定的尺寸/比例渲染為影像，或將其 [export it as SVG](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/writeassvg/) 以 SVG 形式匯出供向量使用。

**如何快速取得考慮佈景主題與繼承的矩形實際（有效）屬性？**

使用 [Use the shape’s effective properties](/slides/zh-hant/cpp/shape-effective-properties/)：API 會回傳考慮佈景主題樣式、版面配置與本地設定的計算值，簡化格式分析。