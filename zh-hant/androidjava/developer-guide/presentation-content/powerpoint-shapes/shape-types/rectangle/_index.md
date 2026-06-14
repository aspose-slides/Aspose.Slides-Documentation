---
title: 在 Android 上為簡報新增矩形
linktitle: 矩形
type: docs
weight: 80
url: /zh-hant/androidjava/rectangle/
keywords:
- 新增矩形
- 建立矩形
- 矩形形狀
- 簡單矩形
- 格式化矩形
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android 於 Java 中輕鬆程式設計與修改形狀，為您的 PowerPoint 簡報加入矩形，提升呈現效果。"
---
## **概述**

本文說明如何使用 Aspose.Slides 向 PowerPoint 投影片新增矩形形狀。它涵蓋建立簡單矩形、建立已格式化的矩形，以及將更新後的簡報儲存為 PPTX 檔案。  
您還會看到如何套用基本的矩形格式設定，例如純色填充、線條顏色與線條寬度。此外，本文的 FAQ 也會指向相關的矩形任務，包括圓角、圖片填充、視覺效果、超連結、形狀鎖定、匯出選項與有效屬性。

## **在投影片中新增矩形**
若要在簡報的選定投影片中新增簡單矩形，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
- 使用索引取得投影片的參考。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 物件所公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Rectangle 的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAutoShape)。
- 將修改過的簡報寫入為 PPTX 檔案。

以下範例中，我們已在簡報的第一張投影片新增了一個簡單矩形。

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

## **在投影片中新增已格式化的矩形**
若要在投影片中新增已格式化的矩形，請依照以下步驟操作：

- 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation) 類別的實例。
- 使用索引取得投影片的參考。
- 使用由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 物件所公開的 [addAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) 方法，新增類型為 Rectangle 的 [IAutoShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IAutoShape)。
- 將矩形的 [Fill Type](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/FillType) 設為 Solid。
- 使用與 [IShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShape) 物件相關聯的 [IFillFormat](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IFillFormat) 物件所公開的 [SolidFillColor.setColor](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) 方法設定矩形的顏色。
- 設定矩形線條的顏色。
- 設定矩形線條的寬度。
- 將修改過的簡報寫入為 PPTX 檔案。

上述步驟已於以下範例中實作。

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
使用圓角的 [shape type](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shapetype/)，並在形狀屬性中調整角半徑；也可透過幾何調整對每個角套用圓角。

**如何使用圖像（紋理）填充矩形？**  
選取圖片 [fill type](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/filltype/)，提供圖像來源，並設定 [stretching/tiling modes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/picturefillmode/)。

**矩形可以有陰影和發光效果嗎？**  
可以。[Outer/inner shadow、glow 與 soft edges](/slides/zh-hant/androidjava/shape-effect/) 均可使用，且可調整參數。

**我能將矩形變成帶有超連結的按鈕嗎？**  
可以。將超連結 [指派超連結](/slides/zh-hant/androidjava/manage-hyperlinks/) 指派給形狀點擊（跳轉至投影片、檔案、網址或電子郵件）。

**如何防止矩形被移動或更改？**  
使用形狀鎖定：您可以禁止移動、調整大小、選取或文字編輯，以維持版面配置。

**我能將矩形轉換為點陣圖或 SVG 嗎？**  
可以。您可以 [render the shape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getImage-int-float-float-)，以指定的尺寸/比例將形狀渲染為圖像，或使用 [export it as SVG](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) 匯出為 SVG 以供向量使用。

**如何快速取得考慮佈景主題與繼承的矩形實際（有效）屬性？**  
使用 [shape’s effective properties](/slides/zh-hant/androidjava/shape-effective-properties/)：API 會回傳已考慮佈景主題樣式、版面配置及本機設定的計算值，簡化格式分析。