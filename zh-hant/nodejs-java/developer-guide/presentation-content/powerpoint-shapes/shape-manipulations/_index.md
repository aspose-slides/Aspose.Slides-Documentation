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
- 圖形版面格式
- 圖形為 SVG
- 圖形匯出為 SVG
- 對齊圖形
- 翻轉圖形
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 來辨識、複製、移除、隱藏、重新排序、匯出、對齊與翻轉簡報圖形。"
---
## **概覽**

Aspose.Slides for Node.js via Java 以有序的 [ShapeCollection](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/) 來表示投影片上的圖形。此集合同時是您尋找與修改圖形的地方，也是圖形堆疊順序的來源：索引 `0` 為最背面的圖形，而最後一個索引為最前面的圖形。

本文遵循此模型。首先說明如何可靠地識別圖形，然後展示如何複製、移除、隱藏與重新排序圖形。最後的章節涵蓋版面配置層級的格式設定、SVG 匯出、對齊與翻轉設定。每個範例皆獨立，您可以僅使用工作流程所需的操作。

## **識別與尋找圖形**

在處理已知檔案時，集合索引很方便，但它們不是穩定的識別子。加入、移除或重新排序圖形都會改變其索引。請依照簡報的編寫與維護方式選擇識別子：

- [Name](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getname/) 於開發人員控制的範本中很有用，且可在 PowerPoint 的「選取窗格」中輕鬆檢視。名稱可編輯且不保證唯一，若程式碼依賴名稱，請建立命名慣例。
- [AlternativeText](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getalternativetext/) 於已有可辨識的無障礙說明或作者提供的標籤時很有用。它會顯示給使用者，可能會本地化或為無障礙需求重新撰寫，也不保證唯一。請勿將有意義的無障礙文字作為資料庫鍵值而靜默重複使用。
- [OfficeInteropShapeId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) 為唯讀識別子，在同一投影片內唯一，對應 PowerPoint Interop 使用的圖形 ID。整合 PowerPoint 或需要在圖形生命週期內保持唯一參照時請使用它。已複製或重新建立的圖形會是不同的圖形，並擁有自己的 ID。

相關的 [getUniqueId](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getuniqueid/) 方法會傳回簡報範圍的識別子，但此識別子設計給外掛使用，可能會被重新指派，不應視為永久外部鍵。若長期身份識別至關重要，請在應用程式資料中保存對應關係，並驗證預期的圖形仍然存在。

以下範例以完全相等的方式依名稱搜尋，並回報投影片範圍的 Interop ID。當範本未包含預期圖形時，程式會回報該結果，而不是繼續使用錯誤的物件。

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

當操作特定於圖形類型時，請在使用類型特定成員前檢查執行階段類別。此範例僅在命名物件為 [AutoShape](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/autoshape/) 時才更新文字與替代文字。

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

## **修改圖形集合**

add、clone、remove 與 reorder 方法會立即作用於集合。如果操作改變了圖形的數量或順序，請不要再依賴先前取得的索引。

### **複製圖形**

[addClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/addclone/) 會建立獨立的副本並將其附加至目標集合。[insertClone](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/insertclone/) 也會建立副本，但會放置在指定的 Z‑order 索引。接受座標的重載會在不改變大小的情況下移動副本；接受寬度與高度的重載則可同時調整大小。

此範例建立目的投影片，將帶標籤的矩形複製到前方，並在背面插入第二個副本。對任一副本的變更不會影響來源圖形。

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

複製會同時複製圖形的內容與格式，包括名稱與替代文字。若這些值必須唯一，請為副本指派新的邏輯識別子。複雜圖形使用的資源由簡報負責管理，但副本仍是集合中的新項目，擁有新的圖形身分。

### **移除圖形**

[remove](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/remove/) 會從其集合中刪除特定圖形物件。當在索引迭代期間移除多個符合條件的圖形時，請自結尾向前遍歷，以確保每個剩餘的索引仍然有效。

此範例移除所有具有指定名稱的圖形。它在當前索引讀取圖形，且不假設特定的圖形類型。

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

移除後，圖形總數與後續圖形的索引會改變。對未受影響圖形的參照比已保存的索引更可靠。同時請留意連接線、動畫與其他可能參照被移除物件的簡報功能；移除可見圖形可能會影響不只是投影片外觀。

### **隱藏圖形**

將 [Hidden](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/sethidden/) 設為 `true` 會保留圖形於集合中，但阻止其在一般投影片放映中出現。其索引、格式與內容仍可供程式碼存取，因此隱藏適用於日後可能還原的可選元件。

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

隱藏不是刪除亦非安全機制。使用者或程式碼仍可發現並取消隱藏，且它仍是簡報檔案的一部份。

### **變更 Z‑Order**

重疊的圖形會依集合順序繪製。[reorder](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapecollection/reorder/) 會將已有圖形移動至目標索引，而不會複製它。索引 `0` 為最背面；`size() - 1` 為最前面。

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

矩形最先建立，最初位於橢圓之後。將它移至最後索引即會出現在前方。請在加入或複製所有相關圖形後最後調整 Z‑order，因為這些操作會在集合中新增或插入項目，可能改變原先的堆疊順序。

## **檢查版面投影片上的圖形**

普通投影片、版面投影片與母片都有各自的圖形集合。版面集合中的圖形與普通投影片上位置相同的圖形並非相同物件。當您需要了解或變更版面提供的格式時，請檢查版面圖形。

以下範例讀取每個版面圖形的 [FillFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getfillformat/) 與 [LineFormat](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/getlineformat/)，且不假設每個圖形都是 `AutoShape`。

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

編輯版面可能會影響使用該版面的多張投影片。在變更版面圖形前，請先確定普通投影片是繼承該物件還是具有本地覆寫，並測試所有使用該版面的投影片。

## **將圖形匯出為 SVG**

[writeAsSvg](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/writeassvg/) 會將單一圖形的渲染內容寫入串流。結果只包含該圖形，不會包含整張投影片的背景或相鄰圖形。

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

在渲染期間請保持簡報開啟。輸出內容取決於圖形的格式以及字型、影像等資源。若需要整體構圖，請匯出投影片而非單一圖形。呼叫端負責管理與關閉串流。

## **對齊圖形**

[SlideUtil.alignShapes](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/slideutil/alignshapes/) 的重載可對齊全部圖形或指定的集合索引。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapesalignmenttype/) 指定對齊的邊緣、中心線或分佈模式。將 `alignToSlide` 設為 `true` 會以投影片邊緣為基準；設為 `false` 則以選取的圖形相互對齊。

此範例將三個圖形對齊至投影片的上緣。返回的圖形參照會在對齊前立即轉換為其當前索引。

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

對齊會變更位置，但不會改變 Z‑order。相對對齊通常至少需要兩個圖形，而水平或垂直分佈則需要足夠的圖形以定義間距。如果在呼叫方法前修改了集合，請重新計算索引。

## **翻轉圖形**

[ShapeFrame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shapeframe/) 類別儲存位置、大小、水平與垂直翻轉設定以及旋轉。其 `getFlipH` 與 `getFlipV` 值使用 [NullableBool](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/nullablebool/)：`True` 表示啟用翻轉，`False` 表示關閉，`NotDefined` 則保留未指定/預設狀態。

下方的輸入簡報僅包含一個未翻轉的圖形。

![The shape before flipping](shape_to_be_flipped.png)

此範例保留其他所有框架值，僅取代兩個翻轉設定。這點很重要，因為指派新的 [Frame](https://reference.aspose.com/slides/zh-hant/nodejs-java/aspose.slides/shape/setframe/) 會取代完整的框架。

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

儲存的圖形會在水平與垂直方向上鏡像，同時保留其位置、大小與旋轉。

![The shape after flipping](flipped_shape.png)

## **常見問題**

**我可以使用集合索引作為圖形識別子嗎？**

僅在短暫處理且集合不會在使用索引前變更的情況下可行。對於已編寫的範本，建議使用已驗證的 `Name` 或 `AlternativeText` 慣例；若是投影片範圍的 Interop 工作，則使用 `OfficeInteropShapeId`。

**隱藏圖形會將它從 Z‑order 中移除嗎？**

不會。隱藏的圖形仍保留在集合中的相同索引。它仍可被找尋、重新排序、編輯或再次顯示。

**為什麼複製的圖形會出現在其他圖形前面？**

`addClone` 會將副本附加至集合的末端，也就是 Z‑order 的前端。若想選擇初始索引，可使用 `insertClone`，或在全部圖形加入後使用 `reorder`。