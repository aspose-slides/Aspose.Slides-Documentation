---
title: 在 Java 中向簡報新增線條形狀
linktitle: 線條
type: docs
weight: 50
url: /zh-hant/java/Line/
keywords:
- 線條
- 建立線條
- 新增線條
- 純線條
- 設定線條
- 自訂線條
- 虛線樣式
- 箭頭
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "學習如何使用 Aspose.Slides for Java 操作 PowerPoint 簡報中的線條格式設定。探索屬性、方法與範例。"
---
## **概觀**

Aspose.Slides 允許您以程式方式向 PowerPoint 投影片新增線條形狀。本文說明如何建立簡單的直線以及如何自訂線條使其呈現為箭頭。

您將學會如何在投影片中加入線條形狀、調整其視覺外觀，並儲存更新後的簡報。範例聚焦於實用的線條格式設定，如樣式、寬度、虛線圖案、箭頭選項以及填色。

## **建立純線條**

若要在簡報的選定投影片中加入簡單的純線條，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
- 使用索引取得投影片的參照。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增 Line 類型的 AutoShape。
- 將修改後的簡報寫入為 PPTX 檔案。

以下範例中，我們已在簡報的第一張投影片加入一條線條。

```java
// 實例化代表 PPTX 檔案的 PresentationEx 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 新增類型為 line 的 AutoShape
    sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    
    // 將 PPTX 寫入磁碟
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **建立箭頭形狀的線條**

Aspose.Slides for Java 也允許開發人員設定線條的某些屬性，使其更具吸引力。讓我們嘗試設定幾個線條屬性，使其呈現為箭頭。請依照以下步驟執行：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的實例。
- 使用索引取得投影片的參照。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增 Line 類型的 AutoShape。
- 將 [Line Style](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LineStyle) 設為 Aspose.Slides for Java 所提供的樣式之一。
- 設定線條的寬度。
- 將線條的 [Dash Style](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LineDashStyle) 設為 Aspose.Slides for Java 所提供的樣式之一。
- 設定線條起點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LineArrowheadStyle) 與 [Length](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LineArrowheadLength)。
- 設定線條終點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LineArrowheadStyle) 與 [Length](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LineArrowheadLength)。
- 將修改後的簡報寫入為 PPTX 檔案。

```java
// 實例化代表 PPTX 檔案的 PresentationEx 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增類型為 line 的 AutoShape
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 套用線條的格式設定
    shp.getLineFormat().setStyle(LineStyle.ThickBetweenThin);
    shp.getLineFormat().setWidth(10);

    shp.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    shp.getLineFormat().setBeginArrowheadLength(LineArrowheadLength.Short);
    shp.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.Oval);

    shp.getLineFormat().setEndArrowheadLength(LineArrowheadLength.Long);
    shp.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);

    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Maroon));

    // 將 PPTX 寫入磁碟
    pres.save("LineShape.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**我可以將一般線條轉換為連接線，使其「自動貼齊」形狀嗎？**

不會。一般線條（[AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/) 類型為 [Line](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shapetype/)）不會自動變為連接線。若要讓其貼齊形狀，請使用專用的 [Connector](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/connector/) 類型，並使用 [corresponding APIs](/slides/zh-hant/java/connector/) 進行連接。

**如果線條的屬性是從佈景主題繼承而來，且難以確定最終值，我該怎麼辦？**

可透過 [ILineFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinefillformateffectivedata/) 介面，閱讀 [實際屬性](/slides/zh-hant/java/shape-effective-properties/)。這些已考慮繼承與佈景主題樣式。

**我可以將線條鎖定，防止編輯（移動、調整大小）嗎？**

可以。形狀提供 [lock objects](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/#getAutoShapeLock--) 讓您 [禁止編輯操作](/slides/zh-hant/java/applying-protection-to-presentation/)。