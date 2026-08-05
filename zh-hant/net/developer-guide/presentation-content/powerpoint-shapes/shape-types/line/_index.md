---
title: 在 .NET 中向簡報新增線條形狀
linktitle: 線條
type: docs
weight: 50
url: /zh-hant/net/line/
keywords:
- 線條
- 建立線條
- 加入線條
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
description: "學習如何使用 Aspose.Slides for .NET 操作 PowerPoint 簡報中的線條格式設定。探索屬性、方法與範例。"
---
## **概覽**

Aspose.Slides 允許您以程式方式在 PowerPoint 投影片中加入線條形狀。本文章說明如何建立簡單的線條以及如何自訂線條，使其顯示為箭頭。

您將學習如何將線條形狀加入投影片、調整其視覺外觀，並儲存更新後的簡報。範例聚焦於實用的線條格式設定，如樣式、寬度、虛線模式、箭頭選項與填色。

## **建立普通線條**
若要在簡報的選定投影片中加入簡單的普通線條，請依照以下步驟操作：

- 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation) 類別的實例。
- 使用索引取得投影片的參考。
- 使用 Shapes 物件所提供的 [AddAutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/methods/addautoshape/index) 方法，加入類型為 Line 的 AutoShape。
- 將修改後的簡報寫入為 PPTX 檔案。

以下示例中，我們已將線條加入簡報的第一張投影片。

```c#
// 實例化代表 PPTX 檔案的 PresentationEx 類別
using (Presentation pres = new Presentation())
{
    // 取得第一張投影片
    ISlide sld = pres.Slides[0];

    // 新增類型為 line 的自動圖形
    sld.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 將 PPTX 寫入磁碟
    pres.Save("LineShape1_out.pptx", SaveFormat.Pptx);
}
```

## **建立箭頭形線條**
Aspose.Slides for .NET 亦允許開發人員設定線條的某些屬性，使其更具吸引力。讓我們嘗試設定幾個線條屬性，使其呈現為箭頭。請依照以下步驟進行：

- 建立 [Presentation ](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation)class[](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/)[](http://www.aspose.com/api/net/slides/zh-hant/aspose.slides/)。
- 使用索引取得投影片的參考。
- 使用 Shapes 物件所提供的 AddAutoShape 方法，加入類型為 Line 的 AutoShape。
- 將線條樣式設定為 Aspose.Slides for .NET 所提供的樣式之一。
- 設定線條的寬度。
- 將線條的 [Dash Style](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linedashstyle) 設定為 Aspose.Slides for .NET 所提供的樣式之一。
- 設定線條起點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/linearrowheadstyle) 與長度。
- 設定線條終點的 Arrow Head Style 與長度。
- 將修改後的簡報寫入為 PPTX 檔案。

```c#
// 實例化代表 PPTX 檔案的 PresentationEx 類別
using (Presentation pres = new Presentation())
{

    // 取得第一張投影片
    ISlide sld = pres.Slides[0];

    // 新增類型為 line 的自動圖形
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

**我能將普通線條轉換為連接線，使其「自動貼齊」到形狀嗎？**

不會。普通線條（類型為 [Line](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/)）不會自動變成連接線。若要使其貼齊形狀，請使用專用的 [Connector](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/connector/) 類型以及用於連接的 [corresponding APIs](/slides/zh-hant/net/connector/)。

**如果線條的屬性是從佈景主題繼承而來，且難以判斷最終值，我該怎麼辦？**

可透過 [閱讀有效屬性](/slides/zh-hant/net/shape-effective-properties/) 以及 [ILineFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ilinefillformateffectivedata/) 介面——這些介面已考慮繼承與佈景主題樣式。

**我可以鎖定線條以防止編輯（移動、調整大小）嗎？**

可以。Shapes 提供 [lock objects](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/autoshape/autoshapelock/)，讓您 [disallow editing operations](/slides/zh-hant/net/applying-protection-to-presentation/)。