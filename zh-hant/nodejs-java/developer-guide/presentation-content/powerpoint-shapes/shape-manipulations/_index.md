---
title: 在 JavaScript 中管理簡報圖形
linktitle: 圖形操作
type: docs
weight: 40
url: /zh-hant/nodejs-java/shape-manipulations/
keywords:
- PowerPoint 圖形
- 簡報圖形
- 投影片上的圖形
- 尋找圖形
- 複製圖形
- 移除圖形
- 隱藏圖形
- 變更圖形順序
- 取得 Interop 圖形 ID
- 圖形替代文字
- 圖形版面配置格式
- 圖形為 SVG
- 圖形轉 SVG
- 對齊圖形
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "學習使用 JavaScript 與 Aspose.Slides for Node.js via Java 來建立、編輯與最佳化圖形，並交付高效能的 PowerPoint 簡報。"
---
## **概述**

本文說明如何使用 Aspose.Slides 在簡報中操作圖形。它展示了如何在投影片上尋找圖形、複製圖形、移除圖形、隱藏圖形、變更圖形順序、取得 Interop 圖形 ID，並設定替代文字以便辨識與後續處理。

同時也涵蓋了如何存取圖形的版面配置格式、將圖形渲染為 SVG、在投影片上對齊圖形，以及使用翻轉屬性進行水平與垂直鏡像。除此之外，本文還包含了關於圖形合併、堆疊順序與圖形鎖定的簡短 FAQ。

## **在投影片中尋找圖形**
本主題將說明一種簡單的技巧，讓開發人員在不使用內部 Id 的情況下，更輕鬆地在投影片上找到特定圖形。必須了解 PowerPoint 簡報檔案除了內部唯一 Id 之外，沒有其他方式可辨識投影片中的圖形。開發人員若僅依靠內部唯一 Id 來尋找圖形會相當困難。所有加入投影片的圖形皆具備替代文字。我們建議開發人員使用替代文字來尋找特定圖形。您可以使用 Microsoft PowerPoint 為未來可能變更的物件定義替代文字。

設定完任意圖形的替代文字後，即可使用 Aspose.Slides for Node.js via Java 開啟該簡報，並遍歷投影片上所有圖形。在每次迭代時檢查圖形的替代文字，符合的圖形即為您需要的圖形。為了更好地展示此技巧，我們建立了方法[findShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideUtil#findShape-aspose.slides.IBaseSlide-java.lang.String-)，可在投影片中找到特定圖形並直接回傳該圖形。

```javascript
// 實例化表示簡報檔案的 Presentation 類別
var pres = new aspose.slides.Presentation("FindingShapeInSlide.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // 要尋找的圖形的替代文字
    var shape = findShape(slide, "Shape1");
    if (shape != null) {
        console.log("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function findShape(slide, altText) {
    let shapes = slide.getShapes();
    
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i);
        
        if (shape.getAlternativeText() === altText) {
            return shape;
        }
    }

    return null;
}
```

## **複製圖形**
使用 Aspose.Slides for Node.js via Java 複製圖形至投影片的步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
1. 透過索引取得投影片參考。
1. 取得來源投影片的圖形集合。
1. 新增投影片至簡報。
1. 將來源投影片圖形集合中的圖形複製至新投影片。
1. 將修改後的簡報另存為 PPTX 檔案。

下例會在投影片中新增一個群組圖形。

```javascript
// 實例化 Presentation 類別
var pres = new aspose.slides.Presentation("Source Frame.pptx");
try {
    var sourceShapes = pres.getSlides().get_Item(0).getShapes();
    var blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank);
    var destSlide = pres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
    // 將 PPTX 檔案寫入磁碟
    pres.save("CloneShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **移除圖形**
Aspose.Slides for Node.js via Java 允許開發人員移除任何圖形。若要從投影片中移除圖形，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
1. 取得第一張投影片。
1. 使用特定 AlternativeText 尋找圖形。
1. 移除該圖形。
1. 將檔案儲存至磁碟。

```javascript
// 建立 Presentation 物件
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增矩形類型的自動圖形
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var altText = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(0);
        if (alttext === ashp.getAlternativeText()) {
            sld.getShapes().remove(ashp);
        }
    }
    // 將簡報儲存至磁碟
    pres.save("RemoveShape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **隱藏圖形**
Aspose.Slides for Node.js via Java 允許開發人員隱藏任何圖形。若要在投影片中隱藏圖形，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
1. 取得第一張投影片。
1. 使用特定 AlternativeText 尋找圖形。
1. 隱藏該圖形。
1. 將檔案儲存至磁碟。

```javascript
// 實例化代表 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增矩形類型的自動圖形
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    var alttext = "User Defined";
    var iCount = sld.getShapes().size();
    for (var i = 0; i < iCount; i++) {
        var ashp = sld.getShapes().get_Item(i);
        if (alttext === ashp.getAlternativeText()) {
            ashp.setHidden(true);
        }
    }
    // 將簡報儲存至磁碟
    pres.save("Hiding_Shapes_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **變更圖形順序**
Aspose.Slides for Node.js via Java 允許開發人員重新排序圖形。重新排序可決定哪個圖形位於前面，哪個圖形位於背後。若要重新排序投影片中的圖形，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
1. 取得第一張投影片。
1. 新增一個圖形。
1. 在圖形的文字框中加入文字。
1. 再新增一個座標相同的圖形。
1. 重新排序圖形。
1. 將檔案儲存至磁碟。

```javascript
var pres = new aspose.slides.Presentation("ChangeShapeOrder.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shp3.addTextFrame(" ");
    var para = shp3.getTextFrame().getParagraphs().get_Item(0);
    var portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");
    shp3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 200, 365, 400, 150);
    slide.getShapes().reorder(2, shp3);
    pres.save("Reshape_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **取得 Interop 圖形 ID**
Aspose.Slides for Node.js via Java 允許開發人員取得投影片範圍內唯一的圖形識別碼，與 [getUniqueId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#getUniqueId--) 方法在簡報範圍內取得唯一識別碼不同。[getOfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#getOfficeInteropShapeId--) 方法已加入 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape) 類別。此方法回傳的值對應 Microsoft.Office.Interop.PowerPoint.Shape 物件的 Id。以下提供範例程式碼。

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 取得投影片範圍內唯一的圖形識別碼
    var officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **設定圖形的替代文字**
Aspose.Slides for Node.js via Java 允許開發人員設定任意圖形的 AlternateText。簡報中的圖形可透過 [AlternativeText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) 或 [Shape Name](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#setName-java.lang.String-) 方法加以區分。[setAlternativeText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#setAlternativeText-java.lang.String-) 與 [getAlternativeText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#getAlternativeText--) 方法皆可使用 Aspose.Slides 或 Microsoft PowerPoint 讀寫。利用此方法，您可以為圖形加上標記，進而執行移除圖形、隱藏圖形或重新排序圖形等不同操作。設定圖形的 AlternateText，請依照以下步驟操作：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Presentation) 類別的實例。
1. 取得第一張投影片。
1. 新增任意圖形至投影片。
1. 對新加入的圖形進行相關操作。
1. 遍歷圖形集合以尋找目標圖形。
1. 設定 AlternativeText。
1. 將檔案儲存至磁碟。

```javascript
// 實例化代表 PPTX 的 Presentation 類別
var pres = new aspose.slides.Presentation();
try {
    // 取得第一張投影片
    var sld = pres.getSlides().get_Item(0);
    // 新增矩形類型的自動圖形
    var shp1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 40, 150, 50);
    var shp2 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    for (var i = 0; i < sld.getShapes().size(); i++) {
        var shape = sld.getShapes().get_Item(i);
        if (shape != null) {
            shape.setAlternativeText("User Defined");
        }
    }
    // 將簡報儲存至磁碟
    pres.save("Set_AlternativeText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **存取圖形的版面配置格式**
Aspose.Slides for Node.js via Java 提供簡易 API 以存取圖形的版面配置格式。本文示範如何存取版面配置格式。

以下提供範例程式碼。

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (let i = 0; i < pres.getLayoutSlides().size(); i++) {
        let layoutSlide = pres.getLayoutSlides().get_Item(i);
        for (let j = 0; j < layoutSlide.getShapes().size(); j++) {
            let shape = layoutSlide.getShapes().get_Item(j);
            var fillFormats = shape.getFillFormat();
            var lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **將圖形渲染為 SVG**
現在 Aspose.Slides for Node.js via Java 支援將圖形渲染為 SVG。已在 [Shape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape) 類別中加入 [writeAsSvg](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/Shape#writeAsSvg-java.io.OutputStream-) 方法（及其重載）。此方法可將圖形內容另存為 SVG 檔案。以下程式碼示範如何將投影片的圖形匯出為 SVG 檔案。

```javascript
var pres = new aspose.slides.Presentation("TestExportShapeToSvg.pptx");
try {
    var stream = java.newInstanceSync("java.io.FileOutputStream", "SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) {
            stream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **圖形對齊**
Aspose.Slides 允許將圖形相對於投影片邊界或彼此對齊。為此已新增重載方法 [SlidesUtil.alignShape()](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/SlideUtil#alignShapes-int-boolean-aspose.slides.IBaseSlide-int:A-)。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/ShapesAlignmentType) 列舉定義了可能的對齊選項。

**範例 1**

以下原始碼將索引為 1、2 與 4 的圖形對齊至投影片的上邊界。

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var shape1 = slide.getShapes().get_Item(1);
    var shape2 = slide.getShapes().get_Item(2);
    var shape3 = slide.getShapes().get_Item(4);
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), java.newArray("int", [slide.getShapes().indexOf(shape1), slide.getShapes().indexOf(shape2), slide.getShapes().indexOf(shape3)]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**範例 2**

下例示範如何將整個圖形集合相對於集合中最底部的圖形進行對齊。

```javascript
var pres = new aspose.slides.Presentation("example.pptx");
try {
    aspose.slides.SlideUtil.alignShapes(aspose.slides.ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **翻轉屬性**

在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapeframe/) 類別透過 `flipH` 與 `flipV` 屬性提供水平與垂直鏡像的控制。兩個屬性皆為 `byte` 型別，`1` 代表翻轉，`0` 代表不翻轉，`-1` 表示使用預設行為。這些值可從圖形的 [Frame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getFrame) 取得。

若要修改翻轉設定，會以圖形目前的位置與大小、欲設定的 `flipH`、`flipV` 值以及旋轉角度建立新的 [ShapeFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapeframe/) 實例。將此實例指派給圖形的 [Frame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/#getFrame) 並儲存簡報，即可套用鏡像變換並寫入輸出檔案。

假設我們有一個 sample.pptx 檔案，其第一張投影片僅包含一個預設翻轉設定的圖形，如下圖所示。

![The shape to be flipped](shape_to_be_flipped.png)

以下程式碼範例取得圖形目前的翻轉屬性，並同時進行水平與垂直翻轉。

```js
var presentation = new asposeSlides.Presentation("sample.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    // 取得圖形的水平翻轉屬性。
    var horizontalFlip = shape.getFrame().getFlipH();
    console.log("Horizontal flip:", horizontalFlip);

    // 取得圖形的垂直翻轉屬性。
    var verticalFlip = shape.getFrame().getFlipV();
    console.log("Vertical flip:", verticalFlip);

    var x = java.newFloat(shape.getFrame().getX());
    var y = java.newFloat(shape.getFrame().getY());
    var width = java.newFloat(shape.getFrame().getWidth());
    var height = java.newFloat(shape.getFrame().getHeight());
    var flipH = java.newByte(asposeSlides.NullableBool.True); // 水平翻轉。
    var flipV = java.newByte(asposeSlides.NullableBool.True); // 垂直翻轉。
    var rotation = shape.getFrame().getRotation();

    shape.setFrame(new asposeSlides.ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

結果：

![The flipped shape](flipped_shape.png)

## **常見問題**

**我可以在投影片上像桌面編輯器一樣合併圖形（聯集/交集/相減）嗎？**

目前沒有內建的布林運算 API。您可以自行建構所需的輪廓——例如計算結果幾何（透過 [GeometryPath](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/geometrypath/)），然後以該輪廓建立新圖形，並視需求移除原始圖形。

**如何控制堆疊順序（z-order），使圖形永遠保持在最上層？**

變更投影片的 [shapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/baseslide/#getShapes) 集合中的插入/移動順序。為取得可預測的結果，請在完成所有其他投影片修改後最後確定 z-order。

**我可以「鎖定」圖形，以防止使用者在 PowerPoint 中編輯它嗎？**

可以。設定圖形層級的保護旗標（例如鎖定選取、移動、調整大小、文字編輯）。如有需要，也可在母片或版面上鏡像限制。請注意這僅屬 UI 層級的保護，而非安全機制；若需更強的保護，可搭配檔案層級的限制，如 [只讀建議或密碼保護](/slides/zh-hant/nodejs-java/password-protected-presentation/)。