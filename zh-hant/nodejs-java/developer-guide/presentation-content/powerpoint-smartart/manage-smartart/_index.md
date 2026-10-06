---
title: 使用 JavaScript 在 PowerPoint 簡報中管理 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh-hant/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt 文字
- 版面配置類型
- 隱藏屬性
- 組織圖
- 圖片組織圖
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "學習使用 Aspose.Slides for Node.js，透過清晰的 JavaScript 程式碼範例，快速建構與編輯 PowerPoint SmartArt，以加速投影片設計與自動化。"
---
## **概觀**

SmartArt 是由節點、節點形狀和版面配置所組成的 PowerPoint 圖表。使用 Aspose.Slides for Node.js via Java，您可以建立 SmartArt、從其節點讀取文字、變更版面配置、檢查隱藏節點、設定組織圖版面，以及建立圖片組織圖。

## **從 SmartArt 物件取得文字**

SmartArt 節點可以包含一個或多個形狀。若要從節點形狀讀取文字，請遍歷 [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/)，然後讀取由 [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/) 回傳的 [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/)。

此範例需要一個至少包含一張投影片且在該投影片上第一個形狀為 SmartArt 物件的簡報。它會將每個可用的文字框輸出至主控台。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **變更 SmartArt 物件的版面配置類型**

SmartArt 的版面配置決定節點的排列與連接方式。以下範例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) 的 `BasicBlockList` 值建立 SmartArt 物件，將其變更為 `BasicProcess` 值，並儲存簡報。傳遞給 [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) 的位置和大小以點為單位。使用 [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) 來變更版面配置。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **檢查 SmartArt 節點是否為隱藏**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) 表示此節點在 SmartArt 資料模型中是否為隱藏狀態。即使所選的版面配置未將它們顯示為可見圖表元素，隱藏節點仍可能存在於結構中。

以下範例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` 值的 SmartArt 物件新增一個節點，並檢查新增節點的隱藏狀態。若節點為隱藏，會輸出訊息並儲存圖表。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **取得或設定組織圖版面配置**

對於使用組織圖版面配置的 SmartArt 圖表，[SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) 與 [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) 定義子節點在父節點下的排列方式。例如，您可以根據所選的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) 將子節點掛在左側、右側或兩側。

以下範例建立組織圖，並將第一個節點的版面配置設定為 [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 值。零基索引 `0` 代表第一個頂層節點；其子節點會使用所選的排列方式。最後儲存修改後的簡報。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **建立圖片組織圖**

圖片組織圖是一種為包含圖片佔位符的階層圖表設計的 SmartArt 版面配置。將 SmartArt 物件加入投影片時，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 值。本範例儲存帶有圖片佔位符的圖表；不會將圖片填入佔位符。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **將舊版圖表轉換為形狀群組**

在升級現有簡報時，您可能需要更新最初在 PowerPoint 97–2003 建立的組織圖。Aspose.Slides 將這些舊版圖表表示為 [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) 物件。使用 [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) 可將圖表轉換為形狀群組，以便編輯各個視覺元素。詳情請參閱 [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/)。

轉換會在形狀集合中新增一個群組，而不會移除原始圖表。轉換成功後，使用 [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) 移除原始圖表，以避免重複內容。於轉換前先將舊版圖表收集至清單中，避免在新增或移除形狀時中斷迭代。

以下範例開啟簡報，搜尋每張投影片，將圖表轉換為形狀群組，並將更新後的簡報儲存為 PPTX。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

儲存的簡報會以可編輯的形狀群組取代已轉換的舊版圖表，且不會留下原始圖表。於 PowerPoint 中開啟 PPTX，即可編輯每個群組內的個別元素，如文字、填色或位置。

## **FAQ**

**SmartArt 是否支援針對 RTL 語言的鏡像或反轉？**

是。當所選的 SmartArt 版面配置支援反轉時，[SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) 方法會將圖表方向由左至右切換為右至左，或反向切換。

**如何在保留格式的情況下，將 SmartArt 複製到同一張投影片或其他簡報中？**

您可以[克隆 SmartArt 形狀](/slides/zh-hant/nodejs-java/shape-manipulations/)，使用 [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) 或[克隆整張投影片](/slides/zh-hant/nodejs-java/clone-slides/) 包含 SmartArt 的投影片。兩種方式皆可保留大小、位置與格式。

**如何將 SmartArt 轉換為點陣圖供預覽或網路匯出？**

[轉換投影片](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/)或將整個簡報轉換為 PNG 或 JPEG。SmartArt 會作為投影片的一部分被轉換。

**如果投影片上有多個 SmartArt 物件，如何找到特定的 SmartArt 物件？**

使用 [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) 或 [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) 為 SmartArt 形狀指派獨特的替代文字或名稱，於 [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) 中搜尋該值，然後檢查匹配的形狀是否為 [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/).