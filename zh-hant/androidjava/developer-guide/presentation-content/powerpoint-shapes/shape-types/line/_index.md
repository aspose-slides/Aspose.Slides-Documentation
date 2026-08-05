---
title: 在 Android 上於簡報中新增線形狀
linktitle: 線條
type: docs
weight: 50
url: /zh-hant/androidjava/line/
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
description: "學習使用 Aspose.Slides for Android 操作 PowerPoint 簡報中的線條格式。探索屬性、方法以及 Java 範例。"
---
## **概述**

Aspose.Slides 允許您以程式方式將線形狀新增至 PowerPoint 投影片中。本文章說明如何建立簡單的線，以及如何自訂線使其顯示為箭頭。  
您將學習如何將線形狀新增至投影片、調整其外觀，並儲存已更新的簡報。範例著重於實用的線條格式設定，如樣式、寬度、虛線模式、箭頭選項及填色。

## **建立普通線條**

若要在簡報的選定投影片上新增一條簡單的普通線條，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
- 使用索引取得投影片的參考。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Line 的 AutoShape。
- 將已修改的簡報寫入為 PPTX 檔案。

以下範例中，我們已在簡報的第一張投影片上新增了一條線條。

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

Aspose.Slides for Android via Java 也允許開發人員設定線條的某些屬性，使其外觀更為吸引人。讓我們嘗試設定一些線條屬性，使其呈現為箭頭。請依照以下步驟執行：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/Presentation) 類別的實例。
- 使用索引取得投影片的參考。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Line 的 AutoShape。
- 將 [Line Style](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LineStyle) 設定為 Aspose.Slides for Android via Java 所提供的其中一種樣式。
- 設定線條的寬度。
- 將線條的 [Dash Style](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LineDashStyle) 設定為 Aspose.Slides for Android via Java 所提供的其中一種樣式。
- 設定線條起點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LineArrowheadStyle) 與 [Length](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LineArrowheadLength)。
- 設定線條終點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LineArrowheadStyle) 與 [Length](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/LineArrowheadLength)。
- 將已修改的簡報寫入為 PPTX 檔案。

```java
// 實例化代表 PPTX 檔案的 PresentationEx 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增類型為 line 的 AutoShape
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 為線條套用一些格式設定
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

## **FAQ**

**我可以將一般線條轉換為連接線，使其「自動貼齊」到形狀嗎？**

不會。一般線條（屬於 [AutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/autoshape/) 類型為 [Line](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shapetype/)）不會自動變成連接線。若要使其貼齊形狀，請使用專用的 [Connector](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/connector/) 類型以及用於連接的 [corresponding APIs](/slides/zh-hant/androidjava/connector/)。

**如果線條的屬性是從佈景主題繼承而來，且難以確定最終值，我該怎麼辦？**

透過 [ILineFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ilinefillformateffectivedata/) 介面（或參考 [Read the effective properties](/slides/zh-hant/androidjava/shape-effective-properties/)），即可取得已考慮繼承與佈景主題樣式的實際屬性值。

**我可以鎖定線條，防止編輯（移動、調整大小）嗎？**

可以。形狀提供的 [lock objects](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/autoshape/#getAutoShapeLock--) 可讓您禁止編輯操作。