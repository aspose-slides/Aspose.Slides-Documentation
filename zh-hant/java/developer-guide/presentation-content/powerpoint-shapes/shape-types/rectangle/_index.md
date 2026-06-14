---
title: 在 Java 中向簡報添加矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh-hant/java/rectangle/
keywords:
- 新增矩形
- 建立矩形
- 矩形形狀
- 簡單矩形
- 格式化矩形
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "透過使用 Aspose.Slides for Java 新增矩形，提升您的 PowerPoint 簡報—輕鬆以程式方式設計與修改圖形。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在 PowerPoint 投影片中新增矩形圖形。內容涵蓋建立簡單矩形、建立格式化矩形，以及將更新後的簡報儲存為 PPTX 檔。

您還會看到如何套用基本的矩形格式設定，如實心填色、線條顏色與線條寬度。此外，本文的 FAQ 也會連結到相關的矩形工作，包括圓角、圖片填充、視覺效果、超連結、圖形鎖定、匯出選項與有效屬性等。

## **將矩形新增至投影片**
要在簡報的選定投影片中新增一個簡單矩形，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例。
- 使用 Index 取得投影片的參考。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection) 物件所公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Rectangle 的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)。
- 將已修改的簡報寫入為 PPTX 檔。

以下範例示範了我們在簡報的第一張投影片中新增了簡單矩形。

```java
// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增橢圓類型的 AutoShape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 將 PPTX 檔案寫入磁碟
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **將格式化的矩形新增至投影片**
要在投影片中新增格式化的矩形，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation) 類別的實例。
- 使用 Index 取得投影片的參考。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection) 物件所公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Rectangle 的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IAutoShape)。
- 將矩形的 [Fill Type](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/FillType) 設為 Solid。
- 使用由與 [IShape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IShape) 物件相關的 [IFillFormat](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IFillFormat) 物件所公開的 [SolidFillColor.setColor](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) 方法設定矩形的顏色。
- 設定矩形線條的顏色。
- 設定矩形線條的寬度。
- 將已修改的簡報寫入為 PPTX 檔。

以下範例實作了上述步驟。

```java
// 實例化代表 PPTX 的 Presentation 類別
Presentation pres = new Presentation();
try {
    // 取得第一張投影片
    ISlide sld = pres.getSlides().get_Item(0);

    // 新增橢圓類型的 AutoShape
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // 對橢圓形狀套用一些格式設定
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // 對橢圓的線條套用一些格式設定
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // 將 PPTX 檔案寫入磁碟
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **常見問題**

**如何新增具有圓角的矩形？**

使用圓角的 [shape type](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shapetype/)，並在圖形屬性中調整角半徑；也可以透過幾何調整對每個角套用圓角。

**如何以影像（紋理）填滿矩形？**

選取圖片 [fill type](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/filltype/)，提供影像來源，並設定 [stretching/tiling modes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/picturefillmode/)。

**矩形可以加入陰影與發光效果嗎？**

可以。支援的外部/內部陰影、發光與柔化邊緣（/shape-effect/）皆可調整參數。

**我可以將矩形設為具有超連結的按鈕嗎？**

可以。將超連結 (/slides/zh-hant/java/manage-hyperlinks/) 指派給圖形點擊事件（跳轉至投影片、檔案、網站或電子郵件）。

**如何保護矩形，使其無法移動或變更？**

使用圖形鎖定 (/slides/zh-hant/java/applying-protection-to-presentation/)：可以禁止移動、調整大小、選取或文字編輯，以維持版面配置。

**我可以將矩形轉換成點陣圖或 SVG 嗎？**

可以。您能夠使用 [render the shape](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getImage-int-float-float-) 產生指定尺寸/比例的影像，或將其以 SVG 匯出 ([writeAsSvg](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)) 供向量使用。

**如何快速取得考慮佈景主題與繼承後的矩形實際（有效）屬性？**

使用圖形的有效屬性 (/slides/zh-hant/java/shape-effective-properties/)：API 會回傳已計算的值，包含佈景主題樣式、版面與本機設定，簡化格式分析。