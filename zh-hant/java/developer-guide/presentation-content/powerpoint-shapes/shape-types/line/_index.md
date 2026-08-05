---
title: 在 Java 中向簡報添加線形狀
linktitle: 線條
type: docs
weight: 50
url: /zh-hant/java/line/
keywords:
- 線條
- 建立線條
- 添加線條
- 純粹線條
- 配置線條
- 自訂線條
- 虛線樣式
- 箭頭
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 簡報中操作線條格式。探索屬性、方法和範例。"
---
## **概述**

Aspose.Slides 允許您以程式方式向 PowerPoint 投影片中新增直線形狀。本文說明如何建立簡單的直線以及如何自訂直線使其呈現為箭頭。

您將學會如何將直線形狀加入投影片、調整其外觀，並儲存更新後的簡報。範例著重於實用的直線格式設定，如樣式、寬度、虛線模式、箭頭選項以及填色。

## **建立純粹直線**

要將簡單的純粹直線加入簡報中選取的投影片，請按照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的執行個體。
- 使用索引取得投影片的參照。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Line 的 AutoShape。
- 將修改後的簡報寫入為 PPTX 檔案。

以下範例中，我們已在簡報的第一張投影片加入了一條直線。

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

## **建立箭頭形狀的直線**

Aspose.Slides for Java 亦允許開發人員設定直線的某些屬性，使其外觀更具吸引力。請按照以下步驟將直線設定為箭頭形狀：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/Presentation) 類別的執行個體。
- 使用索引取得投影片的參照。
- 使用 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Line 的 AutoShape。
- 將 [Line Style](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LineStyle) 設定為 Aspose.Slides for Java 所提供的其中一種樣式。
- 設定直線的寬度。
- 將直線的 [Dash Style](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LineDashStyle) 設定為 Aspose.Slides for Java 所提供的其中一種樣式。
- 設定直線起始點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LineArrowheadStyle) 與 [Length](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LineArrowheadLength)。
- 設定直線終點的 [Arrow Head Style](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LineArrowheadStyle) 與 [Length](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/LineArrowheadLength)。
- 將修改後的簡報寫入為 PPTX 檔案。

```java
// 實例化表示 PPTX 檔案的 PresentationEx 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增類型為 line 的 AutoShape
    IAutoShape shp = sld.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);

    // 對該直線套用一些格式設定
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

**我可以將普通直線轉換為連接線，使其「自動貼齊」到形狀嗎？**

不會。普通直線（型別為 [Line](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shapetype/) 的 [AutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/)）不會自動變成連接線。若要使其貼齊形狀，請使用專用的 [Connector](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/connector/) 類型，以及用於連接的 [相應 API](/slides/zh-hant/java/connector/)。

**如果直線的屬性是從佈景主題繼承而來，且難以判斷最終值，我該怎麼做？**

透過 [ILineFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilineformateffectivedata/)/[ILineFillFormatEffectiveData](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ilinefillformateffectivedata/) 介面[閱讀有效屬性](/slides/zh-hant/java/shape-effective-properties/)，這些已考慮繼承與佈景主題樣式。

**我可以鎖定直線，使其無法編輯（移動、調整大小）嗎？**

可以。形狀提供 [lock objects](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/autoshape/#getAutoShapeLock--)，讓您[禁止編輯操作](/slides/zh-hant/java/applying-protection-to-presentation/)。