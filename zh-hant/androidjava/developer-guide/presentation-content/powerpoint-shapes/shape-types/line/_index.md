---
title: 在 Android 上為簡報新增線條形狀
linktitle: 線條
type: docs
weight: 50
url: /zh-hant/androidjava/Line/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android 在 PowerPoint 簡報中操作線條格式。探索屬性、方法與 Java 範例。"
---
## **概觀**

Aspose.Slides 允許您以程式方式將線條形狀新增至 PowerPoint 投影片中。本篇文章說明如何建立簡單的線條以及如何自訂線條使其顯示為箭頭。

您將學會如何在投影片上新增線條形狀、調整其外觀，並將更新後的簡報儲存。範例著重於實用的線條格式設定，包括樣式、寬度、虛線樣式、箭頭樣式以及填充顏色。

## **建立普通線條**

若要在簡報的選定投影片中新增一條簡單的普通線條，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
- 依據索引取得投影片的參考。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 物件所公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，加入類型為 Line 的 AutoShape。
- 將修改後的簡報寫出為 PPTX 檔案。

在下方的範例中，我們已將線條新增至簡報的第一張投影片。

```java
// 實例化表示 PPTX 檔案的 PresentationEx 類別
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

## **建立箭頭形線條**

Aspose.Slides for Android via Java 亦允許開發者設定線條的某些屬性，使其更具吸引力。以下示範如何設定幾個屬性，讓線條呈現為箭頭，請依照下列步驟執行：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
- 依據索引取得投影片的參考。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 物件所公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，加入類型為 Line 的 AutoShape。
- 將 [Line Style](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LineStyle) 設定為 Aspose.Slides for Android via Java 所提供的樣式之一。
- 設定線條的寬度。
- 將線條的 [Dash Style](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LineDashStyle) 設定為 Aspose.Slides for Android via Java 所提供的樣式之一。
- 設定線條起點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LineArrowheadStyle) 與 [Length](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LineArrowheadLength)。
- 設定線條終點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LineArrowheadStyle) 與 [Length](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LineArrowheadLength)。
- 將修改後的簡報寫出為 PPTX 檔案。

```java
// 實例化表示 PPTX 檔案的 PresentationEx 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增類型為 line 的 AutoShape
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 對線條套用一些格式設定
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

**我可以將普通線條轉換為連接線，使其「貼齊」到形狀嗎？**

不能。普通線條（類型為 [Line](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/autoshape/)）不會自動變為連接線。若要讓其貼齊到形狀，請使用專用的 [Connector](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/connector/) 類型，並使用 [相應的 API](/slides/zh-hant/androidjava/connector/) 進行連接。

**如果線條的屬性是從佈景主題繼承而來，且難以判斷最終值，我該怎麼辦？**

透過 [ILineFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilinefillformateffectivedata/) 介面 [閱讀有效屬性](/slides/zh-hant/androidjava/shape-effective-properties/)，這些已考慮了繼承與佈景主題樣式。

**我可以鎖定線條，使其無法編輯（移動、調整大小）嗎？**

可以。形狀提供了 [lock objects](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--)，讓您禁止編輯操作。