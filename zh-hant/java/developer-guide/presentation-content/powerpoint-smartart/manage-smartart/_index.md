---
title: 使用 Java 管理 PowerPoint 簡報中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh-hant/java/manage-smartart/
keywords:
- SmartArt
- SmartArt 文字
- 佈局類型
- 隱藏屬性
- 組織圖
- 圖片組織圖
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "學習使用 Aspose.Slides for Java 透過清晰的程式碼範例，建立與編輯 PowerPoint SmartArt，加速投影片設計與自動化。"
---
## **概述**

SmartArt 是由節點、節點形狀和佈局組成的 PowerPoint 圖表。使用 Aspose.Slides for Java，您可以建立 SmartArt、從其節點讀取文字、變更佈局、檢查隱藏節點、配置組織圖佈局，並建立圖片組織圖。

## **從 SmartArt 物件取得文字**

SmartArt 節點可以包含一個或多個形狀。若要讀取可見的文字，請遍歷 [ISmartArt.getAllNodes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ismartart/#getAllNodes--)，然後讀取由 [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ismartartshape/#getTextFrame--) 回傳的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/itextframe/)。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **變更 SmartArt 物件的佈局類型**

SmartArt 佈局控制節點的排列與連接方式。以下範例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArtLayoutType) 的 `BasicBlockList` 值建立 SmartArt 物件，將其變更為 `BasicProcess` 值，並儲存簡報。

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **檢查 SmartArt 節點是否為隱藏**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ismartartnode/#isHidden--) 表示節點在 SmartArt 資料模型中是否為隱藏。即使所選佈局未將它們顯示為可見的圖表元素，隱藏節點仍可能存在於結構中。

以下範例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArtLayoutType) 的 `RadialCycle` 值的 SmartArt 物件加入節點，並檢查該節點的隱藏狀態。

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **取得或設定組織圖佈局**

對於使用組織圖佈局的 SmartArt 圖表，[ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) 與 [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) 定義子節點在父節點之下的排列方式。例如，您可以根據所選的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OrganizationChartLayoutType) 將子節點設定為左側懸掛、右側懸掛，或兩側皆懸掛。

以下範例建立一個組織圖，並將第一個節點的佈局設定為 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/OrganizationChartLayoutType) 的 `LeftHanging` 值。

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **建立圖片組織圖**

圖片組織圖是一種為包含圖像佔位符的階層圖而設計的 SmartArt 佈局。將 SmartArt 物件加入投影片時，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/SmartArtLayoutType) 的 `PictureOrganizationChart` 值。

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**SmartArt 是否支援 RTL 語言的鏡像或反轉？**

是。當所選的 SmartArt 佈局支援反轉時，[ISmartArt.setReversed](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ismartart/#setReversed-boolean-) 方法會將圖表方向從左至右切換為右至左，或反向切換。

**如何在保留格式的情況下將 SmartArt 複製到同一投影片或其他簡報？**

您可以使用 [ShapeCollection.addClone](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) 透過 [clone the SmartArt shape](/slides/zh-hant/java/shape-manipulations/) 或 [clone the whole slide](/slides/zh-hant/java/clone-slides/) 來複製包含 SmartArt 的投影片。兩種方式皆能保留大小、位置與格式。

**如何將 SmartArt 轉換為點陣圖以供預覽或網路匯出？**

[Render the slide](/slides/zh-hant/java/convert-powerpoint-to-png/) 或將整個簡報轉換為 PNG 或 JPEG。SmartArt 會作為投影片的一部份被渲染。

**如果投影片上有多個 SmartArt，如何找出特定的 SmartArt 物件？**

在 SmartArt 形狀上設定唯一的 [Shape.getAlternativeText](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getAlternativeText--) 或 [Shape.getName](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/shape/#getName--) 值，於 [BaseSlide.getShapes](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/baseslide/#getShapes--) 中搜尋該值，然後確認匹配的形狀為 [ISmartArt](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/ismartart/)。