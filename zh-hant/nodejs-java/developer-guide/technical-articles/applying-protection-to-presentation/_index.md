---
title: 使用 Shape Locks 限制 Node.js 中的簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 60
url: /zh-hant/nodejs-java/applying-protection-to-presentation/
keywords:
- 防止編輯
- 防止被編輯
- 鎖定圖形
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
description: "了解如何使用 Aspose.Slides for Node.js via Java 在 PPTX 簡報中鎖定與解除鎖定圖形，以限制選取、移動、調整大小與分組。"
---
## **概述**

在 Aspose.Slides for Node.js via Java 中，一個常見的用途是建立、更新並儲存 PowerPoint (PPTX) 簡報，作為自動化工作流程的一部份。當使用者收到這些簡報時，限制對圖形的變更可以協助保留預期的版面配置與內容。

本文說明圖形在投影片中的組織方式以及如何在 PPTX 簡報中套用與移除圖形鎖定。這些鎖定讓您可以限制對單一圖形的特定編輯操作。

## **投影片的組成**

簡報投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於建立簡報的元素組成。在 Aspose.Slides for Node.js via Java 中，投影片上的每個元素皆以繼承自 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 類別的物件表示。

不同的圖形類型提供不同的鎖定選項。[BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) 類別是圖形鎖定的基礎類別。Aspose.Slides for Node.js via Java 提供以下鎖定類別：

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) 鎖定自動圖形。  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) 鎖定連接線圖形。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) 鎖定圖形物件。  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) 鎖定群組圖形。  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) 鎖定圖片框。  

若要在 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 中套用鎖定，請遍歷其投影片，並對每個受支援的圖形設定相應的鎖定。

## **套用與移除保護**

相容的簡報編輯器使用圖形鎖定來限制個別的編輯操作。檔案加密與文件層級的寫入保護屬於不同的 [簡報保護設定](/slides/zh-hant/nodejs-java/password-protected-presentation/)。

### **套用 PPTX 圖形的保護**

Aspose.Slides for Node.js via Java 提供 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 類別，以操作投影片上的圖形。

範例對自動圖形呼叫 [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) 與 [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) 並傳入 `true`，對群組圖形、連接線與圖片框則使用等效的鎖定。連接線使用 [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) 以限制移動；群組亦使用 [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) 來限制分組。

範例載入現有的 PPTX 簡報，檢查每張投影片的圖形集合，並儲存套用了此等限制的副本。未屬於上述四種處理類型的圖形將保持不變。此迴圈不會遍歷群組內的子圖形。

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

若要移除圖形鎖定，請將其值設為 `false`。以下範例載入具有圖形鎖定的簡報，並透過 [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) 與 [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) 解除選取、移動與調整大小的限制。它亦透過將 `false` 傳遞給 [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) 來移除分組限制，並儲存簡報的副本。其他鎖定設定保持不變。

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

在工作目錄中放置名為 `photo.jpg` 的照片。範例將左側裁切 12%、右側裁切 8%，然後在圖片框的鎖定上呼叫 [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked)。傳入 `true` 可限制進一步裁切，並保留現有的裁切。

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

`PictureLocked.pptx` 將裁切鎖定儲存為 `true`。在 PowerPoint 中，選取照片時 **Crop** 指令會被停用。

### **保持圖表群組**

範例將矩形與箭頭群組，然後在群組的鎖定上呼叫 [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) 以保持圖表的組件在一起。其他編輯，如移動群組或變更組件的填色，仍然可用。

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

`DiagramLocked.pptx` 將取消群組鎖定儲存為 `true`。在 PowerPoint 中，選取整個圖表時 **Ungroup** 指令會被停用。

### **結論**

Aspose.Slides for Node.js via Java 讓您可以限制單一圖形的特定編輯操作，或在多張投影片上套用相同的限制。依各圖形類型選擇支援的鎖定，並在需要移除限制時將其值設為 `false`。

## **常見問題**

**我可以在同一簡報中同時使用圖形鎖定與密碼保護嗎？**

是的。圖形鎖定限制特定的編輯操作，而 [密碼保護](/slides/zh-hant/nodejs-java/password-protected-presentation/) 可限制簡報的開啟或修改。您可以在同一檔案中同時使用兩者。

**我能限制特定投影片的編輯而不影響其他投影片嗎？**

可以。僅在選定的投影片上套用鎖定。這不會變更其他投影片的鎖定設定。

**我該如何對群組內的單一圖形套用鎖定？**

遍歷群組的 [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) 方法回傳的集合，並對每個子圖形套用適當的鎖定。對任何嵌套的群組重複此操作。上述範例僅處理投影片的圖形集合，因此未對群組內的個別成員設置鎖定。