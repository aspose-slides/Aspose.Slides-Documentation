---
title: 在 Android 上於簡報中新增橢圓形
linktitle: 橢圓形
type: docs
weight: 30
url: /zh-hant/androidjava/ellipse/
keywords:
- 橢圓形
- 形狀
- 新增橢圓形
- 建立橢圓形
- 繪製橢圓形
- 已格式化的橢圓形
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Android 中於 PPT 和 PPTX 簡報中建立、格式化與操作橢圓形狀——包含 Java 程式碼範例。"
---
## **概觀**

本文說明如何使用 Aspose.Slides 在 PowerPoint 投影片中加入橢圓形狀。它涵蓋建立簡單橢圓、建立格式化橢圓，以及將更新後的簡報儲存為 PPTX 檔案。也會提及相關問題，例如處理橢圓的位置與大小、控制堆疊順序，以及套用動畫效果。

## **建立橢圓**
若要在簡報中選定的投影片上新增簡單橢圓，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
- 使用索引取得投影片的參考。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Ellipse 的 AutoShape。
- 將修改後的簡報寫入為 PPTX 檔案。

在下方的範例中，我們已將橢圓加入第一張投影片中

```java
// 建立代表 PPTX 的 Presentation 類別實例
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);
    
    // 新增橢圓類型的 AutoShape
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // 將 PPTX 檔案寫入磁碟
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **建立格式化橢圓**
若要在投影片上新增更具格式化的橢圓，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
- 使用索引取得投影片的參考。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 物件所提供的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Ellipse 的 AutoShape。
- 將橢圓的填充類型設為實心。
- 使用與 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShape) 物件關聯的 [FillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IFillFormat) 物件所公開的 SolidFillColor.Color 屬性，設定橢圓的顏色。
- 設定橢圓線條的顏色。
- 設定橢圓線條的寬度。
- 將修改後的簡報寫入為 PPTX 檔案。

在下方的範例中，我們已將格式化的橢圓加入簡報的第一張投影片。

```java
// 建立代表 PPTX 的 Presentation 類別實例
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增橢圓類型的 AutoShape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // 為橢圓形套用一些格式設定
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

**如何依據投影片單位設定橢圓的精確位置與大小？**

座標與尺寸通常以 **點 (points)** 為單位指定。為了取得可預測的結果，請以投影片大小為基礎，並在指派數值前將所需的公釐或英吋換算為點。

**如何將橢圓置於其他物件之上或之下（控制堆疊順序）？**

透過將物件移至最前或最背來調整繪圖順序。這樣即可讓橢圓覆蓋其他物件或顯示其下方的物件。

**如何為橢圓加入顯示或強調的動畫效果？**

[套用](/slides/zh-hant/androidjava/shape-animation/) 進場、強調或退出效果至形狀，並設定觸發條件與時間，安排動畫的播放時機與方式。