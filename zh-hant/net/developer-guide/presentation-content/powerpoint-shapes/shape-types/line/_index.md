---
title: 在 .NET 中向簡報新增線條形狀
linktitle: 線條
type: docs
weight: 50
url: /zh-hant/net/Line/
keywords:
- 線條
- 建立線條
- 新增線條
- 普通線條
- 設定線條
- 自訂線條
- 虛線樣式
- 箭頭
- PowerPoint
- 簡報
- .NET
- C#
- Aspose.Slides
description: "學習使用 Aspose.Slides for .NET 在 PowerPoint 簡報中操作線條格式設定。探索相關屬性、方法與範例。"
---
## **概述**

Aspose.Slides 允許您以程式方式向 PowerPoint 投影片添加線條形狀。本篇文章說明如何建立簡單的線條以及如何自訂線條，使其呈現為箭頭。

您將學會如何向投影片添加線條形狀、調整其外觀，並儲存更新後的簡報。範例著重於實用的線條格式設定，例如樣式、寬度、虛線圖樣、箭頭選項以及填充色彩。

## **建立普通線條**

要在簡報的選定投影片中添加一條簡單的普通線條，請依照以下步驟操作：

- 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation)class 的實例。
- 使用索引取得投影片的參考。
- 使用 Shapes 物件公開的 [AddAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/methods/addautoshape/index) 方法，新增類型為 Line 的 AutoShape。
- 將修改後的簡報寫入為 PPTX 檔案。

以下範例中，我們已將線條新增至簡報的第一張投影片。

```c#
 // 實例化代表 PPTX 檔案的 PresentationEx 類別
using (Presentation pres = new Presentation())
{
    // 取得第一張投影片
    ISlide sld = pres.Slides[0];

    // 新增類型為線條的自動圖形
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 將 PPTX 寫入磁碟
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **建立箭頭形線條**

Aspose.Slides for .NET 亦允許開發人員設定線條的某些屬性，使其更具吸引力。讓我們嘗試設定幾個屬性，使線條呈現為箭頭。請依照以下步驟操作：

- 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/)[](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/) 的實例。
- 使用索引取得投影片的參考。
- 使用 Shapes 物件公開的 AddAutoShape 方法，新增類型為 Line 的 AutoShape。
- 將線條樣式設定為 Aspose.Slides for .NET 提供的樣式之一。
- 設定線條的寬度。
- 將線條的 [Dash Style](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linedashstyle) 設定為 Aspose.Slides for .NET 提供的樣式之一。
- 設定線條起點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linearrowheadstyle) 與長度。
- 設定線條終點的 Arrow Head Style 與長度。
- 將修改後的簡報寫入為 PPTX 檔案。

```c#
// 實例化代表 PPTX 檔案的 PresentationEx 類別
using (Presentation pres = new Presentation())
{

    // 取得第一張投影片
    ISlide sld = pres.Slides[0];

    // 新增類型為線條的自動圖形
    IAutoShape shp = sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 對線條套用一些格式設定
    shp.LineFormat.Style = LineStyle.ThickBetweenThin;
    shp.LineFormat.Width = 10;

    shp.LineFormat.DashStyle = LineDashStyle.DashDot;

    shp.LineFormat.BeginArrowheadLength = LineArrowheadLength.Short;
    shp.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.Oval;

    shp.LineFormat.EndArrowheadLength = LineArrowheadLength.Long;
    shp.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;

    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Maroon;

    //將 PPTX 寫入磁碟
    pres.Save("LineShape2_out.pptx", SaveFormat.Pptx);
}
```

## **常見問題**

**我可以將普通線條轉換為連接線，使其「自動貼齊」形狀嗎？**

不會。普通線條（類型為 [Line](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/)）不會自動變為連接線。若要使其貼齊形狀，請使用專用的 [Connector](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/connector/) 類型以及用於連接的 [corresponding APIs](/slides/zh-hant/net/connector/)。

**如果線條的屬性繼承自佈景主題，且難以判斷最終值，我該怎麼辦？**

透過 [Read the effective properties](/slides/zh-hant/net/shape-effective-properties/) ，使用 [ILineFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilinefillformateffectivedata/) 介面——這些已考慮繼承與佈景主題樣式。

**我可以鎖定線條以防止編輯（移動、調整大小）嗎？**

可以。Shapes 提供 [lock objects](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/autoshapelock/)，讓您可以 [disallow editing operations](/slides/zh-hant/net/applying-protection-to-presentation/)。