---
title: 在 Node.js 中使用形狀鎖定限制簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 60
url: /zh-hant/nodejs-java/applying-protection-to-presentation/
keywords:
- 防止編輯
- 防止被編輯
- 鎖定形狀
- 鎖定位置
- 鎖定選取
- 鎖定調整大小
- 鎖定分組
- PowerPoint
- PPTX
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 在 PPTX 簡報中鎖定與解除鎖定形狀，以限制選取、移動、調整大小和分組。"
---
## **概觀**

Aspose.Slides for Node.js via Java 常用於在自動化工作流程中建立、更新與儲存 PowerPoint (PPTX) 簡報。當使用者收到這些簡報時，限制形狀的變更可協助保留預期的版面配置與內容。

本篇說明形狀在投影片中的組織方式，以及如何在 PPTX 簡報中套用與移除形狀鎖定。這些鎖定讓您能限制對個別形狀的特定編輯操作。

## **投影片的組成**

簡報投影片由自動圖形、表格、OLE 物件、群組形狀、圖片框、影片框、連接線以及其他用於構建簡報的元素組成。在 Aspose.Slides for Node.js via Java 中，投影片上的每個元素皆以繼承自[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)類別的物件表示。

不同的形狀類型提供不同的鎖定選項。[BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) 類別是形狀鎖定的基底類別。Aspose.Slides for Node.js via Java 提供以下鎖定類別：

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) 鎖定自動圖形。  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) 鎖定連接線形狀。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) 鎖定圖形物件。  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) 鎖定群組形狀。  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) 鎖定圖片框。  

若要在整個[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)上套用鎖定，請遍歷其投影片，並對每個支援的形狀設定相應的鎖定。

## **套用與移除保護**

相容的簡報編輯器使用形狀鎖定來限制個別的編輯操作。檔案加密與文件層級的寫入保護是獨立的[presentation protection settings](/slides/zh-hant/nodejs-java/password-protected-presentation/)。

### **對 PPTX 形狀套用保護**

Aspose.Slides for Node.js via Java 提供[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)類別以在投影片上操作形狀。

範例呼叫[setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked)與[setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked)，對自動圖形傳入 `true`，對群組形狀、連接線與圖片框使用等效的鎖定。連接線使用[setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove)控制移動；群組亦使用[setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked)限制分組。

範例會載入現有的 PPTX 簡報，檢查每張投影片的形狀集合，並將這些限制儲存為新副本。四種已處理類型之外的形狀保持不變。迴圈不會遍歷群組內的子形狀。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **移除保護**

若要移除形狀鎖定，將其值設為 `false`。以下範例載入包含形狀鎖定的簡報，並透過[AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/)與[PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/)清除選取、移動與調整大小的限制。亦透過將 `false` 傳給[GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked)移除分組限制，並儲存簡報副本。其他鎖定設定保持不變。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **保留圖片裁切**

將名為 `photo.jpg` 的相片放置於工作目錄。範例會從左側裁切 12%，右側裁切 8%，然後對圖片框的鎖定呼叫[setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked)。傳入 `true` 後會限制進一步的裁切，並保留既有的裁切結果。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const photoStream = java.newInstanceSync("java.io.FileInputStream", "photo.jpg");
    let photo;
    try {
        photo = presentation.getImages().addImage(photoStream);
    } finally {
        photoStream.close();
    }

    const pictureFrame = shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    const pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` 將裁切鎖定儲存為 `true`。在 PowerPoint 中，選取相片時 **Crop** 指令會被停用。

### **保持圖表群組**

範例將一個矩形與一支箭頭群組，然後對群組的鎖定呼叫[setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked)以保持圖表的元件不被分離。其他編輯操作，例如移動群組或變更元件的填色，仍可使用。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    
    const groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` 將解群組鎖定儲存為 `true`。在 PowerPoint 中，選取整個圖表時 **Ungroup** 指令會被停用。

### **報告現有形狀鎖定**

若要檢視範本，請開啟它並讀取每個形狀的鎖定物件。[getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) 方法在所有旗標皆停用時回傳 `true`，只要有任一旗標啟用則回傳 `false`。群組與其子形狀各有獨立的鎖定物件，因此即使群組本身沒有鎖也必須檢查子形狀。

此範例會檢查自動圖形、圖片框與群組的移動限制，亦會檢查圖片的裁切限制與群組的解群組限制。報告會列出已識別的啟用旗標，並標示未檢查的形狀類型。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function inspectShapes(shapes, slideNumber, prefix) {
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const path = prefix + shape.getName();
        const type = shape.getClass().getSimpleName();
        const label = `Slide ${slideNumber} | ${path} | ${type}`;
        const flags = [];
        const isGroup = java.instanceOf(shape, "com.aspose.slides.IGroupShape");
        let shapeLock;

        if (isGroup) {
            shapeLock = shape.getGroupShapeLock();
            if (shapeLock.getUngroupingLocked()) flags.push("UngroupingLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            shapeLock = shape.getPictureFrameLock();
            if (shapeLock.getCropLocked()) flags.push("CropLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shapeLock = shape.getAutoShapeLock();
        } else {
            console.log(`${label} | Uninspected`);
            continue;
        }

        if (!shapeLock.getNoLocks()) {
            if (shapeLock.getPositionLocked()) flags.push("PositionLocked");
            const restrictions = flags.length ? flags.join(", ") : "Active flag not identified";
            console.log(`${label} | ${restrictions}`);
        }

        if (isGroup) {
            inspectShapes(shape.getShapes(), slideNumber, path + "/");
        }
    }
}

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    const slides = presentation.getSlides();
    for (let i = 0; i < slides.size(); i++) {
        const slide = slides.get_Item(i);
        inspectShapes(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

假設 `Sample.pptx` 的第 1 張投影片包含一個名為 `Layout`、已鎖定解群組的群組，該群組內有一個已鎖定裁切的圖片 `Photo`，以及一個未鎖定的矩形 `Free`。報告會略過 `Free`，僅輸出以下兩行：

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

報告僅讀取已存儲的形狀層級編輯旗標，並不會修改它們或儲存簡報。文件層級的寫入保護是獨立的設定，各旗標的實際強制執行則取決於編輯器。

## **結論**

Aspose.Slides for Node.js via Java 讓您能對個別形狀限制特定編輯操作，或在多張投影片間套用相同限制。請依形狀類型選擇支援的鎖定，並在需要移除限制時將其值設為 `false`。

## **常見問題**

**我可以在同一個簡報中同時結合形狀鎖定與密碼保護嗎？**

可以。形狀鎖定限制特定的編輯操作，而[password protection](/slides/zh-hant/nodejs-java/password-protected-presentation/) 則可限制開啟或修改簡報的權限。兩者可同時使用於同一檔案。

**我可以僅限制特定投影片的編輯而不影響其他投影片嗎？**

可以。只對所選投影片上的形狀套用鎖定，即不會改變其他投影片的鎖定設定。

**如何對群組內的個別形狀套用鎖定？**

遍歷群組的[getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) 方法回傳的集合，對每個子形狀套用相應的鎖定。對任何巢狀群組重複此程序，遵循報告範例中的遍歷方式。