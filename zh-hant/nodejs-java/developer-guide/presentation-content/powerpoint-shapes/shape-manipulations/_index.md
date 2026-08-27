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
- 取得 interop 圖形 ID
- 圖形替代文字
- 圖形調整點
- 預設圖形調整
- 圖形幾何
- 圖形版面格式
- 圖形為 SVG
- 圖形轉 SVG
- 对齐图形
- 翻转图形
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 來識別、調整、複製、移除、隱藏、重新排序、匯出、對齊與翻轉簡報圖形。"
---
## **概觀**

Aspose.Slides for Node.js via Java 將投影片上的圖形表示為有序的 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/)。此集合同時是您查找和修改圖形的所在，也是它們堆疊順序的來源：索引 `0` 為最底層圖形，而最後的索引為最前面的圖形。

本文遵循此模型。首先說明如何可靠地識別圖形並修改預設的圖形調整點，接著展示如何複製、移除、隱藏以及重新排序圖形。最後的章節涵蓋版面層級的格式設定、SVG 匯出、對齊與翻轉設定。每個範例都是獨立的，您可以僅使用工作流程所需的操作。

## **識別與查找圖形**

在已知檔案的處理過程中，集合索引很方便，但它們不是穩定的識別子。新增、移除或重新排序圖形都會改變其索引。請根據簡報的撰寫與維護方式選擇識別子：

- [Name](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getname/) 在開發人員控制的範本中非常有用，且可在 PowerPoint 的「選取窗格」中輕鬆檢查。名稱可以編輯，且不保證唯一，因此若程式碼依賴名稱，請建立命名慣例。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getalternativetext/) 在已提供可存取性說明或作者標記的情況下很有用。它對使用者可見，可能會本地化或為可存取性重新撰寫，且不保證唯一。切勿將有意義的可存取性文字靜默地作為資料庫鍵使用。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) 是唯讀識別子，在同一投影片內唯一，對應 PowerPoint interop 使用的圖形 ID。當與 PowerPoint 整合或需要在圖形生命週期內取得明確參照時使用。已複製或重新建立的圖形是不同的圖形，會獲得自己的 ID。

相關的 [getUniqueId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getuniqueid/) 方法會傳回簡報範圍的識別子，但該識別子僅供外掛使用，可能會被重新指派。不要將其視為永久的外部鍵。若長期身分識別很重要，請將對應關係保存在應用程式資料中，並驗證預期的圖形仍然存在。

以下範例以完全相等的比較方式依名稱搜尋，並回報投影片範圍的 interop ID。當範本未包含預期圖形時，程式會回報該結果，而不是繼續使用錯誤的物件。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

當操作特定於圖形類型時，請在使用類型特定成員前檢查執行階段類別。此範例僅在命名物件為 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 時更新文字與替代文字。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **識別與修改預設圖形調整**

預設幾何圖形可能會暴露調整點，以控制角落大小、箭頭比例或弧形角度等特徵。透過唯讀的 [GeometryShape.getAdjustments](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/geometryshape/) 集合存取它們。集合本身由圖形提供，但每個 [AdjustValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/adjustvalue/) 包含可變更的值。

不要僅依賴固定的集合索引。遍歷所有調整，並檢查唯讀的 [getType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/adjustvalue/) 方法，其返回的 [ShapeAdjustmentType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapeadjustmenttype/) 會說明此調整控制什麼。唯讀的 [getName](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/adjustvalue/getname/) 方法提供額外的識別資訊，特別在同一預設包含多個相同語意類型的調整時很有用。

使用符合調整意義的方法：

| 調整類型 | 目的 | 變更的值 |
|---|---|---|
| `CornerSize` | 圓角大小 | [setRawValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | 箭頭尾巴粗細 | `setRawValue` |
| `ArrowheadLength` | 箭頭長度 | `setRawValue` |
| `ArrowheadWidth` | 箭頭寬度 | `setRawValue` |
| `StartAngle` | 餅圖或弧形的起始角度 | [setAngleValue](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | 餅圖或弧形的結束角度 | `setAngleValue` |

`getType` 與 `getName` 回傳唯讀資訊。`getRawValue` 與 `setRawValue` 使用預設幾何單位的整數，而 `getAngleValue` 與 `setAngleValue` 使用度數。調整的數量、順序、意義與有效範圍取決於預設的 [GeometryShape.getShapeType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/geometryshape/)。對一個預設有效的值，對另一個預設可能無效或產生不同效果。

當 `getType` 回傳 `ShapeAdjustmentType.Custom` 時，API 無法辨識標準語意。請檢查 `getName`、預設類型與現有值，除非已知預期意義與範圍，否則保持調整不變。即使是已辨識的類型，也要先確認相同類型是否出現多次，再選擇要變更的值。[Connector](/slides/zh-hant/nodejs-java/connector/) 文章說明了連接線彎曲調整的情況。

以下完整範例建立三種預設圖形的預設與修改版本。它遍歷每個調整，回報其名稱與類型，透過 `setRawValue` 變更尺寸相關值，透過 `setAngleValue` 變更角度，並儲存結果。左欄保留預設幾何，右欄顯示調整後的圓角矩形、四向箭頭與餅圖。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // 為預設與調整後的圖形欄位新增標題。
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

在變更值之前檢查語意類型，可使程式碼明確表達意圖，並避免假設相同集合索引在不同預設圖形間具有相同意義。

## **修改圖形集合**

新增、複製、移除與重新排序方法會立即作用於集合。如果操作改變了圖形的數量或順序，請不要再依賴先前捕獲的索引。

### **複製圖形**

[addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/addclone/) 會建立獨立的副本並將其附加到目標集合的末端。[insertClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/insertclone/) 亦會建立副本，但會置於指定的 Z 軸順序索引。接受座標的多載會在不變更大小的情況下移動副本；接受寬度與高度的多載則可同時調整大小。

以下範例建立目的投影片，將帶標籤的矩形複製到最前方，並在背面插入第二個副本。對任一副本的變更都不會影響來源圖形。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

複製會保留圖形的內容與格式，包括名稱與替代文字。若這些值必須唯一，請為副本指派新的邏輯識別子。複雜圖形使用的資源由簡報自行管理，但複製後仍是集合中的新項目，擁有新的圖形身分。

### **移除圖形**

[remove](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/remove/) 會從其集合中刪除特定圖形物件。當在索引迭代期間移除多個符合條件的圖形時，請從結尾向前遍歷，以確保每個剩餘索引仍然有效。

此範例移除所有具有指定名稱的圖形。它在目前索引讀取圖形，並不假設特定圖形類型。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

移除後，圖形總數與之後圖形的索引會改變。對未受影響的圖形的參照較儲存的索引更可靠。亦需考慮連接線、動畫與其他可能參照已移除物件的簡報功能；移除可見圖形可能會改變投影片外觀以外的更多內容。

### **隱藏圖形**

將 [Hidden](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/sethidden/) 設為 `true` 會保留圖形於集合中，但阻止其在正常投影片放映中出現。其索引、格式與內容仍可供程式碼存取，因此隱藏適用於可能稍後恢復的可選元素。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

隱藏並非刪除或安全措施。使用者或程式碼仍可發現並取消隱藏，且它仍是簡報檔案的一部分。

### **變更 Z 軸順序**

重疊的圖形會依集合順序繪製。[reorder](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/reorder/) 可將現有圖形移至目標索引，且不會產生副本。索引 `0` 為最底層；`size() - 1` 為最上層。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

矩形先建立且最初位於橢圓後方。將其移至最後索引即可置於前面。請於加入或複製所有相關圖形之後再完成 Z 軸順序的最終調整，因為這些操作會在集合中新增或插入項目，可能會改變原先的堆疊。

## **檢查版面投影片上的圖形**

普通投影片、版面投影片與母片投影片各自擁有獨立的圖形集合。版面集合中的圖形與普通投影片上相同位置的圖形並非同一個物件。當需要了解或變更版面提供的格式時，請檢查版面圖形。

以下範例讀取每個版面圖形的 [FillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getfillformat/) 與 [LineFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getlineformat/)，且不假設每個圖形皆為 `AutoShape`。

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

編輯版面可能會影響使用該版面的多張投影片。變更版面圖形前，請先確認普通投影片是繼承該物件或有本地覆寫，並測試所有使用該版面的投影片。

## **將圖形匯出為 SVG**

[writeAsSvg](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/writeassvg/) 會將單一圖形的渲染內容寫入串流。結果僅包含該圖形本身，而不包含整張投影片的背景或相鄰圖形。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

在渲染期間請保持簡報開啟。輸出取決於圖形的格式設定以及字型、影像等資源。若需要整個組合，請匯出投影片而非單一圖形。呼叫端擁有串流的所有權，必須自行關閉。

## **對齊圖形**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideutil/alignshapes/) 的多載可對齊全部圖形或選取的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapesalignmenttype/) 指定對齊的邊緣、中心線或分佈模式。將 `alignToSlide` 設為 `true` 時使用投影片邊緣；設為 `false` 時則相對於彼此對齊已選取的圖形。

以下範例將三個圖形對齊至投影片的上緣。對齊前會立即將返回的圖形參照轉換為目前的索引。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

對齊會變更位置，而非 Z 軸順序。相對對齊通常需至少兩個圖形，而水平或垂直分佈則需足夠的圖形以定義間距。若在呼叫方法前修改了集合，請重新計算索引。

## **翻轉圖形**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定以及旋轉角度。其 `getFlipH` 與 `getFlipV` 的值使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/nullablebool/) ：`True` 表示啟用翻轉，`False` 表示停用，`NotDefined` 則保留未指定/預設狀態。

下方的輸入簡報包含一個未翻轉的圖形。

![翻轉前的圖形](shape_to_be_flipped.png)

此範例保留所有其他框架值，僅替換兩個翻轉設定。這很重要，因為指派新 [Frame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/setframe/) 會取代完整框架。

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

儲存後的圖形會在水平與垂直方向上鏡像，同時保留其位置、大小與旋轉。

![翻轉後的圖形](flipped_shape.png)

## **常見問答**

**我可以使用集合索引作為圖形識別子嗎？**

僅在集合不會在使用索引前變動的短暫處理情境下可以。對於已創建的範本，建議使用經驗證的 `Name` 或 `AlternativeText` 慣例；對於投影片範圍的 interop 工作，則使用 `OfficeInteropShapeId`。

**隱藏圖形會從 Z 軸順序中移除嗎？**

不會。隱藏的圖形仍保留在集合中的相同索引。它仍可被找到、重新排序、編輯或再次顯示。

**為什麼複製的圖形會出現在另一個圖形的前面？**

`addClone` 會將副本附加至集合的末端，也就是 Z 軸的最前方。若想指定初始索引，可使用 `insertClone`，或在所有圖形加入後使用 `reorder`。

**我可以使用固定索引來識別預設圖形調整嗎？**

僅在已驗證確切的預設與集合布局後才可這樣做。較佳做法是遍歷 `GeometryShape.getAdjustments` 並檢查 `AdjustValue.getType`；當相同語意類型出現多次時，可使用 `AdjustValue.getName` 作為額外資訊。