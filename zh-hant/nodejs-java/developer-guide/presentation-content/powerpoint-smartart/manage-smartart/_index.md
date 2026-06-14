---
title: 使用 JavaScript 管理 PowerPoint 簡報中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh-hant/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt 文字
- 佈局類型
- 隱藏屬性
- 組織圖
- 圖片組織圖
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "學習使用 Aspose.Slides for Node.js 透過清晰的 JavaScript 程式碼範例，建置與編輯 PowerPoint SmartArt，以加速投影片設計與自動化。"
---
## **概述**

SmartArt 是由節點、節點形狀和佈局組成的 PowerPoint 圖表。使用 Aspose.Slides for Node.js via Java，您可以建立 SmartArt、從其節點讀取文字、變更其佈局、檢查隱藏節點、配置組織圖佈局，並建立圖片組織圖。

## **從 SmartArt 物件取得文字**

SmartArt 節點可以包含一個或多個形狀。若要讀取可見文字，請遍歷[SmartArt.getAllNodes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartart/#getAllNodes--)，然後讀取由[SmartArtShape.getTextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) 回傳的[TextFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/textframe/)。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **變更 SmartArt 物件的佈局類型**

SmartArt 佈局控制節點的排列與連接方式。以下範例建立一個使用[SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList` 值的 SmartArt 物件，將其變更為 `BasicProcess` 值，並儲存簡報。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **檢查 SmartArt 節點是否為隱藏**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartartnode/ishidden/) 表示該節點在 SmartArt 資料模型中是否被隱藏。即使所選佈局未將其顯示為可見的圖表元素，隱藏節點仍可能存在於結構中。

以下範例向使用[SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` 值的 SmartArt 物件新增一個節點，並檢查該節點的隱藏狀態。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **取得或設定組織圖佈局**

對於使用組織圖佈局的 SmartArt 圖表，[SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) 和 [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) 定義子節點在父節點下的排列方式。例如，您可以根據所選的[OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/organizationchartlayouttype/)，將子節點掛在左側、右側或兩側。

以下範例建立一個組織圖，並將第一個節點的佈局設定為[OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 值。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **建立圖片組織圖**

圖片組織圖是專為包含圖像佔位符的層級圖表設計的 SmartArt 佈局。將 SmartArt 物件加入投影片時，請使用[SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 值。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**SmartArt 是否支援 RTL 語言的鏡像或反轉？**

是的。當所選 SmartArt 佈局支援反轉時，[SmartArt.setReversed](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartart/setreversed/) 方法會將圖表方向從左至右切換為右至左，或反向切換。

**如何在保留格式的情況下將 SmartArt 複製到同一投影片或其他簡報中？**

您可以透過[ShapeCollection.addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/addclone/) [clone the SmartArt shape](/slides/zh-hant/nodejs-java/shape-manipulations/) 或[clone the whole slide](/slides/zh-hant/nodejs-java/clone-slides/) 其中包含 SmartArt 的投影片。兩種方式均保留大小、位置與格式。

**如何將 SmartArt 轉換為點陣圖以進行預覽或網路匯出？**

[Render the slide](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 或將整個簡報轉換為 PNG 或 JPEG。SmartArt 會作為投影片的一部份被渲染。

**如果投影片上有多個 SmartArt，如何找出其中特定的 SmartArt 物件？**

在 SmartArt 形狀上設定唯一的[Shape.setAlternativeText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/setalternativetext/) 或[Shape.setName](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/setname/) 值，於[BaseSlide.getShapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/#getShapes) 中搜尋該值，然後確認匹配的形狀是[SmartArt](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/smartart/)。