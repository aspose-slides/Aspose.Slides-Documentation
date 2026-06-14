---
title: 在 .NET 中將矩形新增至簡報
linktitle: 矩形
type: docs
weight: 80
url: /zh-hant/net/rectangle/
keywords:
- 新增矩形
- 建立矩形
- 矩形形狀
- 簡易矩形
- 已格式化矩形
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 新增矩形，提升您的 PowerPoint 簡報——輕鬆以程式方式設計與修改形狀。"
---
## **概觀**

本文示範如何使用 Aspose.Slides 在 PowerPoint 投影片中加入矩形形狀。內容涵蓋建立簡單矩形、建立格式化矩形，以及將更新後的簡報儲存為 PPTX 檔。

您還會看到如何套用基本的矩形格式設定，例如實心填色、線條顏色與線條寬度。另外，本文的 FAQ 也提供了相關的矩形操作資訊，包括圓角、圖片填充、視覺效果、超連結、形狀鎖定、匯出選項與有效屬性等。

## **建立簡單矩形**
與先前的主題相同，此主題也在說明加入形狀，而本次討論的形狀是矩形。本文說明開發人員如何使用 Aspose.Slides for .NET 為投影片加入簡單或已格式化的矩形。若要在簡報的指定投影片中加入簡單矩形，請依照以下步驟操作：

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation)class 的實例。
1. 依據 Index 取得投影片的參考。
1. 使用 IShapes 物件所提供的 AddAutoShape 方法，加入類型為 Rectangle 的 IAutoShape。
1. 將修改後的簡報寫出為 PPTX 檔。

以下範例將簡單矩形加入簡報的第一張投影片。

```c#
// 實例化代表 PPTX 的 Presentation 類別
using (Presentation pres = new Presentation())
{

    // 取得第一張投影片
    ISlide sld = pres.Slides[0];

    // 加入類型為矩形的自動形狀
    sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    //將 PPTX 檔寫入磁碟
    pres.Save("RectShp1_out.pptx", SaveFormat.Pptx);
}
```


## **建立格式化矩形**
若要在投影片中加入格式化矩形，請依照以下步驟操作：

1. 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation)class 的實例。
1. 依據 Index 取得投影片的參考。
1. 使用 IShapes 物件所提供的 AddAutoShape 方法，加入類型為 Rectangle 的 IAutoShape。
1. 將矩形的填充類型設定為 Solid。
1. 透過與 IShape 物件關聯的 FillFormat 物件的 SolidFillColor.Color 屬性，設定矩形的顏色。
1. 設定矩形線條的顏色。
1. 設定矩形線條的寬度。
1. 將修改後的簡報寫出為 PPTX 檔。
   以上步驟已在下方範例中實作。

```c#
// 實例化代表 PPTX 的 Presentation 類別
using (Presentation pres = new Presentation())
{

    // 取得第一張投影片
    ISlide sld = pres.Slides[0];

    // 加入類型為矩形的自動形狀
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 對矩形形狀套用一些格式設定
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.Chocolate;

    // 對矩形的線條套用一些格式設定
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    shp.LineFormat.Width = 5;

    //將 PPTX 檔寫入磁碟
    pres.Save("RectShp2_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**如何加入具有圓角的矩形？**

使用圓角 [shape type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapetype/) 並在形狀屬性中調整角半徑；也可透過幾何調整對個別角套用圓角。

**如何用圖片（紋理）填滿矩形？**

選取圖片 [fill type](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/filltype/)，提供影像來源，並設定 [stretching/tiling modes](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/picturefillmode/)。

**矩形可以有陰影和發光效果嗎？**

可以。支援 [Outer/inner shadow、glow 與 soft edges](/slides/zh-hant/net/shape-effect/)，且可調整參數。

**我可以將矩形變成具有超連結的按鈕嗎？**

可以。將超連結 [assign a hyperlink](/slides/zh-hant/net/manage-hyperlinks/) 指派給形狀點擊（跳轉至投影片、檔案、網址或電子郵件）。

**如何保護矩形不被移動或變更？**

使用 [shape locks](/slides/zh-hant/net/applying-protection-to-presentation/)：可禁止移動、調整大小、選取或文字編輯，以維持版面配置。

**我可以將矩形轉換為點陣圖或 SVG 嗎？**

可以。您可 [render the shape](http://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/getimage/) 成指定尺寸/比例的影像，或 [export it as SVG](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shape/writeassvg/) 以供向量使用。

**如何快速取得考慮佈景主題與繼承後的矩形實際（effective）屬性？**

使用 [shape’s effective properties](/slides/zh-hant/net/shape-effective-properties/)：API 會回傳已計算的值，涵蓋佈景樣式、版面配置與本機設定，簡化格式分析。