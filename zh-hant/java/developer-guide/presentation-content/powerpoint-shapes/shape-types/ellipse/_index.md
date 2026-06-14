---
title: 在 Java 中為簡報新增橢圓形
linktitle: 橢圓形
type: docs
weight: 30
url: /zh-hant/java/ellipse/
keywords:
- 橢圓
- 形狀
- 新增橢圓
- 建立橢圓
- 繪製橢圓
- 格式化橢圓
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中建立、格式化與操作 PPT 以及 PPTX 簡報的橢圓形狀，並提供 Java 程式碼範例。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 在 PowerPoint 投影片中新增橢圓形狀。內容涵蓋建立簡單橢圓、建立格式化橢圓以及將更新後的簡報儲存為 PPTX 檔案。亦涉及相關問題，如處理橢圓的位置與大小、控制堆疊順序以及套用動畫效果。

## **建立橢圓形**
若要在簡報的選取投影片上新增簡單橢圓形，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的執行個體。
- 使用索引取得投影片的參照。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Ellipse 的 AutoShape。
- 將修改後的簡報寫入為 PPTX 檔案。

以下範例中，我們已在第一張投影片加入橢圓形

```java
// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 新增類型為橢圓的 AutoShape
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // 將 PPTX 檔案寫入磁碟
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **建立格式化橢圓形**
若要在投影片上加入格式更佳的橢圓形，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的執行個體。
- 使用索引取得投影片的參照。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Ellipse 的 AutoShape。
- 將橢圓形的填充類型設為實心。
- 使用與 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape) 物件關聯之 [FillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IFillFormat) 物件所提供的 SolidFillColor.Color 屬性，設定橢圓形的顏色。
- 設定橢圓形線條的顏色。
- 設定橢圓形線條的寬度。
- 将修改後的簡報寫入為 PPTX 檔案。

以下範例中，我們已在簡報的第一張投影片加入格式化的橢圓形。

```java
// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增類型為橢圓的 AutoShape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 為橢圓形狀套用一些格式設定
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // 為橢圓的線條套用一些格式設定
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // 將 PPTX 檔案寫入磁碟
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**如何設定橢圓相對於投影片單位的精確位置與大小？**

座標和尺寸通常以 **點 (points)** 為單位指定。為獲得可預測的結果，請以投影片尺寸為基礎，並在指定值之前將所需的毫米或英吋轉換為點。

**如何將橢圓置於其他物件之上或之下（控制堆疊順序）？**

透過將物件移至最上層或送至最下層來調整繪製順序。如此即可讓橢圓覆蓋其他物件或顯示其下方的物件。

**如何對橢圓套用外觀或強調的動畫？**

[套用](/slides/zh-hant/java/shape-animation/) 入口、強調或退出效果於形狀，並設定觸發條件與時間，以安排動畫的播放時機與方式。