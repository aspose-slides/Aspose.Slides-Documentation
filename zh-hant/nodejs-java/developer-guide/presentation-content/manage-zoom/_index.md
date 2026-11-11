---
title: 管理簡報縮放於 JavaScript
linktitle: 管理縮放
type: docs
weight: 60
url: /zh-hant/nodejs-java/manage-zoom/
keywords:
- 縮放
- 縮放框格
- 投影片縮放
- 章節縮放
- 摘要縮放
- 新增縮放
- PowerPoint
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 建立並自訂縮放——在 PowerPoint 簡報中在章節間跳轉、加入縮圖與過渡效果。"
---
## **簡介**

PowerPoint 縮放讓您在投影片放映期間在特定投影片和章節之間導航。使用 Aspose.Slides for Node.js via Java，您可以建立投影片縮放、章節縮放和摘要縮放，並自訂它們的預覽、邊框與過渡效果。

![PowerPoint 縮放概觀](overview.png)

* 要在單一投影片上概覽整個簡報，請使用[摘要縮放](#summary-zoom)。
* 只顯示選取的投影片，請使用[投影片縮放](#slide-zoom)。
* 只顯示單一章節，請使用[章節縮放](#section-zoom)。

## **投影片縮放**

投影片縮放可以讓您的簡報更具活力，使您能自由在任意順序的投影片之間導覽而不會中斷簡報的流程。投影片縮放非常適合沒有太多章節的短篇簡報，但您仍可在不同的簡報情境中使用它們。

投影片縮放讓您能從單一概觀投影片探索相關資訊。

![選取投影片以建立投影片縮放](slidezoomsel.png)

對於投影片縮放物件，Aspose.Slides 提供 [ZoomImageType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomimagetype/) 列舉、[ZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomframe/) 類別，以及 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) 類別上的方法。

### **建立縮放框格**

使用 [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addZoomFrame) 在概觀投影片上放置指向各個投影片的連結。此範例建立兩個具有不同背景與標籤的目標投影片，然後將每個投影片的預覽加入第一張投影片，並將簡報儲存為 PPTX。框格的位置與尺寸以點 (point) 為單位指定。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let secondSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    let thirdSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());

    secondSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    secondSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    thirdSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    thirdSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 189, 183, 107));

    textBox = thirdSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Third Slide");

    overviewSlide.getShapes().addZoomFrame(20, 20, 250, 200, secondSlide);
    overviewSlide.getShapes().addZoomFrame(200, 250, 250, 200, thirdSlide);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **使用自訂圖片建立縮放框格**

將自訂圖片傳遞給 [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addZoomFrame) 以取代目標投影片的預設預覽。本範例需要本機圖片，使用 [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) 讀取，並透過 [ImageCollection.addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) 加入簡報。產生的框格會顯示該圖片，同時仍連結至第二張投影片。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    overviewSlide.getShapes().addZoomFrame(20, 20, 300, 200, slide, previewImage);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **格式化縮放框格**

此範例自訂兩個投影片縮放框格。它透過 [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage) 為第一個框格指定本機圖片，並使用 [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) 為第二個框格設定五點、虛線點劃的粉紅色邊框。將 `false` 傳遞給 [ZoomObject.setShowBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setShowBackground) 會隱藏第二個框格的背景。自訂預覽需要本機圖片；兩個框格在儲存的 PPTX 中仍保留其投影片目標。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let secondSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    let thirdSlide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());

    secondSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    secondSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));

    let textBox = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Second Slide");

    thirdSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    thirdSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 189, 183, 107));

    textBox = thirdSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    textBox.getTextFrame().setText("Third Slide");

    let firstZoomFrame = overviewSlide.getShapes().addZoomFrame(20, 20, 250, 200, secondSlide);
    let secondZoomFrame = overviewSlide.getShapes().addZoomFrame(200, 250, 250, 200, thirdSlide);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    firstZoomFrame.setZoomImage(previewImage);

    secondZoomFrame.getLineFormat().setWidth(5);
    secondZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 105, 180));
    secondZoomFrame.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));

    secondZoomFrame.setShowBackground(false);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **章節縮放**

章節縮放會連結至簡報中的章節。可用於重新檢視主題或說明簡報不同部分之間的關聯。

![選取章節以建立章節縮放](seczoomsel.png)

對於章節縮放物件，Aspose.Slides 提供 [SectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/) 類別以及 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) 類別上的方法。

### **建立章節縮放框格**

使用 [SectionCollection.addSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectioncollection/#addSection) 建立章節，然後將回傳的章節傳遞給 [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSectionZoomFrame)。此範例在第一張投影片上放置章節縮放，並連結至以彩色投影片開始的章節。框格的位置與尺寸以點為單位指定，簡報最後儲存為 PPTX。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let section = presentation.getSections().addSection("Section 1", slide);
    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **使用自訂圖片建立章節縮放框格**

[ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSectionZoomFrame) 的圖片重載讓您在不更改目標章節的情況下顯示自訂預覽。本範例需要本機圖片，使用 [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) 載入，並透過 [ImageCollection.addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/#addImage) 加入。儲存的簡報在第一張投影片上包含一個連結至新建立章節的章節縮放。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    let section = presentation.getSections().addSection("Section 1", slide);
    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, previewImage);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **變更章節縮放的目標章節**

使用 [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sectionzoomframe/#setTargetSection) 可在不重新建立的情況下重新指向已有的章節縮放。從同一簡報的 [Presentation.getSections](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSections) 集合中選取已填充的章節。指派空的章節會保留目前的目標不變，故在指派前請先檢查 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSlidesListOfSection)。有關章節的更多資訊，請參閱[管理投影片章節](/slides/zh-hant/nodejs-java/slide-section/)。

以下範例載入一個簡報檔案，該檔案必須包含多個已填充的章節、一個名為 `Section navigation` 的既有章節縮放，以及一個唯一名稱為 `Results` 的章節。它會在所有投影片中搜尋縮放，並透過名稱找到目標，而非使用可能因章節重新排序而變動的集合索引。若名稱不唯一，請改用 [Section.getSectionId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/section/#getSectionId) 來識別目標。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation("section-zoom.pptx");
try {
    let zoom = null;
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            const shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.ISectionZoomFrame") && shape.getName() === "Section navigation") {
                zoom = shape;
                break;
            }
        }
        if (zoom != null) {
            break;
        }
    }

    let targetSection = null;
    for (let i = 0; i < presentation.getSections().size(); i++) {
        const section = presentation.getSections().get_Item(i);
        if (section.getName() === "Results") {
            targetSection = section;
            break;
        }
    }

    if (zoom == null || targetSection == null) {
        console.log("The section zoom or destination section was not found.");
    } else if (targetSection.getSlidesListOfSection().size() == 0) {
        console.log("The destination section is empty.");
    } else {
        let currentSection = zoom.getTargetSection();
        console.log("Current section: " + (currentSection == null ? "" : currentSection.getName()));
        zoom.setTargetSection(targetSection);
        presentation.save("section-zoom-updated.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

### **格式化章節縮放框格**

此範例將章節縮放移動並調整大小為 100 × 75 點，透過 [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage) 指定本機圖片，並套用 2.5 點、虛線點劃的棕色邊框。它啟用 [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) 以在章節結束後返回來源投影片，停用 [ZoomObject.setShowBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setShowBackground)，並將 [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration) 設為 1.5 秒。自訂預覽需要本機圖片。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 154, 205, 50));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let section = presentation.getSections().addSection("Section 1", slide);

    let sectionZoomFrame = overviewSlide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section);
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    sectionZoomFrame.setZoomImage(previewImage);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    sectionZoomFrame.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    sectionZoomFrame.getLineFormat().setWidth(2.5);

    sectionZoomFrame.setTransitionDuration(java.newFloat(1.5));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **摘要縮放**

摘要縮放提供簡報章節的概觀。在投影片放映期間，您可以使用它跳轉至章節、快進或重新檢視主題，而不必遵循投影片順序。

![選取章節以建立摘要縮放](sumzoomsel.png)

對於摘要縮放物件，Aspose.Slides 提供 [SummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/)、[SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsection/) 與 [SummaryZoomSectionCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/) 類別，以及 [ShapeCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) 類別上的方法。

### **建立摘要縮放**

使用 [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addSummaryZoomFrame) 建立簡報章節的概觀。本範例建立四個具有不同投影片背景的章節，並在第一張投影片加入摘要縮放。框格的位置與尺寸以點為單位指定，產生的概觀儲存於 PPTX 簡報中。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 127, 255, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 3", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 100, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 4", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **新增與移除摘要縮放章節**

摘要縮放會在 [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) 中儲存其 [SummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsection/) 物件。此範例建立兩個章節的概觀，使用 [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) 新增第三個章節，並使用 [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection) 移除第一個章節的條目。移除條目後，簡報的章節及其投影片仍保持不變。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let firstSection = presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 127, 255, 0));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    let thirdSection = presentation.getSections().addSection("Section 3", slide);

    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(thirdSection);

    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(firstSection);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **格式化摘要縮放章節**

此範例格式化 [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) 中的第一個條目，使用零基索引 `0`。它需要本機圖片以供 [ZoomObject.setZoomImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setZoomImage) 使用，套用 1.5 點、虛線點劃的黑色邊框，並將 [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration) 設為 1.5 秒。將 `false` 傳遞給 [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) 會停用此條目自動返回摘要投影片的功能。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let overviewSlide = presentation.getSlides().get_Item(0);

    let slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 165, 42, 42));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 1", slide);

    slide = presentation.getSlides().addEmptySlide(overviewSlide.getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));

    presentation.getSections().addSection("Section 2", slide);

    let summaryZoomFrame = overviewSlide.getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    let summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    let previewImage;
    let image = aspose.slides.Images.fromFile("image.png");
    try {
        previewImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    summarySection.setZoomImage(previewImage);
    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    summarySection.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    summarySection.getLineFormat().setWidth(1.5);

    summarySection.setTransitionDuration(java.newFloat(1.5));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **常見問題**

**我可以控制在顯示目標後返回「父」投影片嗎？**

是。呼叫 [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setReturnToParent) 並傳入 `true`，即可在顯示目標內容後返回來源投影片。

**我可以調整縮放過渡的「速度」或持續時間嗎？**

是。使用 [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/zoomobject/#setTransitionDuration) 以秒為單位控制過渡持續時間。

**簡報中可包含多少個縮放物件有上限嗎？**

文件中未列出硬性的 API 限制。實際上限取決於簡報的整體複雜度與檢視器的效能。您可以新增許多縮放框格，但需考慮檔案大小與渲染時間。