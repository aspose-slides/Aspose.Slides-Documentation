---
title: 在 Android 上管理 PowerPoint 簡報中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh-hant/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt 文字
- 版面類型
- 隱藏屬性
- 組織圖
- 圖片組織圖
- PowerPoint
- 簡報
- Android
- Java
- Aspose.Slides
description: "學習使用 Aspose.Slides for Android，透過清晰的 Java 程式碼範例，快速建立與編輯 PowerPoint SmartArt，以加速投影片設計與自動化。"
---
## **概述**

SmartArt 是由節點、節點形狀和版面配置組成的 PowerPoint 圖表。使用 Aspose.Slides for Android via Java，您可以建立 SmartArt、從其節點讀取文字、更改其版面配置、檢查隱藏節點、設定組織圖版面配置，並建立圖片組織圖。

## **取得 SmartArt 物件的文字**

SmartArt 節點可以包含一個或多個形狀。若要讀取可見文字，請遍歷 [ISmartArt.getAllNodes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ismartart/#getAllNodes--)，然後讀取由 [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) 回傳的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/itextframe/)。

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

## **變更 SmartArt 物件的版面類型**

SmartArt 版面控制節點的排列與連接方式。以下範例建立一個使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList` 值的 SmartArt 物件，將其變更為 `BasicProcess` 值，並儲存簡報。

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ismartartnode/#isHidden--) 表示該節點在 SmartArt 資料模型中是否為隱藏。即使所選版面未將隱藏節點顯示為可見圖表元素，隱藏節點仍可能存在於結構中。

以下範例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle` 值的 SmartArt 物件新增節點，並檢查該節點的隱藏狀態。

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

## **取得或設定組織圖版面配置**

對於使用組織圖版面的 SmartArt 圖表，[ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) 與 [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) 定義子節點在父節點下的排列方式。例如，您可以根據所選的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OrganizationChartLayoutType) 將子節點掛在左側、右側或兩側。

以下範例建立一個組織圖，並將第一個節點的版面設定為 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging` 值。

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

圖片組織圖是一種為包含圖片佔位符的階層圖表設計的 SmartArt 版面。將 SmartArt 物件加入投影片時，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` 值。

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

是。當所選 SmartArt 版面支援反轉時，[ISmartArt.setReversed](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) 方法可將圖表方向從左至右切換為右至左，或反向切換。

**如何在同一投影片或其他簡報中複製 SmartArt，同時保留格式？**

您可以使用 [ShapeCollection.addClone](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) 來 [clone SmartArt shape](/slides/zh-hant/androidjava/shape-manipulations/)，或 [clone 包含 SmartArt 的整張投影片](/slides/zh-hant/androidjava/clone-slides/)。兩種方式皆會保留大小、位置與格式。

**如何將 SmartArt 渲染為點陣圖以供預覽或網路匯出？**

[將投影片](/slides/zh-hant/androidjava/convert-powerpoint-to-png/) 或整個簡報轉換為 PNG 或 JPEG。SmartArt 會作為投影片的一部分被渲染。

**如果投影片上有多個 SmartArt，如何找出特定的物件？**

在 SmartArt 形狀上設定獨特的 [Shape.getAlternativeText](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getAlternativeText--) 或 [Shape.getName](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/shape/#getName--) 值，於 [BaseSlide.getShapes](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/baseslide/#getShapes--) 中搜尋該值，然後確認匹配的形狀為 [ISmartArt](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ismartart/)。