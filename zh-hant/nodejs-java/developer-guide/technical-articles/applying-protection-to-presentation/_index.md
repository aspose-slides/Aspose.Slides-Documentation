---
title: 限制 Node.js 中使用形狀鎖定的簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 60
url: /zh-hant/nodejs-java/applying-protection-to-presentation/
keywords:
- 防止編輯
- 保護免於編輯
- 鎖定形狀
- 鎖定位置
- 鎖定選取
- 鎖定調整大小
- 鎖定群組
- PowerPoint
- PPTX
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Node.js via Java 在 PPTX 簡報中鎖定與解除鎖定形狀，以限制選取、移動、調整大小與群組。"
---
## **概述**

Aspose.Slides for Node.js via Java 的常見用法是於自動化工作流程中建立、更新與儲存 PowerPoint (PPTX) 簡報。使用者收到這些簡報時，限制對圖形的變更可以協助保留預期的版面配置與內容。

本文說明圖形在投影片中的組織方式，以及如何在 PPTX 簡報中套用與移除圖形鎖定。這些鎖定讓您能限制對單一圖形的特定編輯操作。

## **投影片的組成**

簡報投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於建立簡報的元素組成。在 Aspose.Slides for Node.js via Java 中，投影片上的每個元素皆以繼承自 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 類別的物件表示。

不同的圖形類型提供不同的鎖定選項。[BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) 類別是圖形鎖定的基底類別。Aspose.Slides for Node.js via Java 提供以下鎖定類別：

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) 鎖定自動圖形。  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) 鎖定連接線圖形。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) 鎖定圖形物件。  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) 鎖定群組圖形。  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) 鎖定圖片框。  

若要在整個 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 中套用鎖定，必須遍歷其投影片，並在每個支援的圖形上設定相應的鎖定。

## **套用與移除保護**

圖形鎖定會限制選取、移動與調整大小等操作。它不會使整個簡報變為無法編輯。

### **對 PPTX 圖形套用保護**

Aspose.Slides for Node.js via Java 提供 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 類別，以在投影片上處理圖形。

範例對自動圖形呼叫 [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) 與 [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked)，並以 `true` 設定；對群組圖形、連接線與圖片框則使用等效的鎖定。連接線使用 [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) 以限制移動；群組亦使用 [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) 以限制群組。

範例載入現有的 PPTX 簡報，檢查每張投影片的圖形集合，並將這些限制儲存為副本。未屬於上述四種類型的圖形將保持不變。此迴圈不會遍歷群組內的子圖形。

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

若要移除圖形鎖定，將其值設為 `false`。

以下範例載入含有圖形鎖定的簡報，並透過 [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/)、[PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) 清除選取、移動與調整大小的限制。它亦透過將 `false` 傳遞給 [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) 移除群組限制，並儲存簡報的副本。其他鎖定設定則保持不變。

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

### **結論**

Aspose.Slides for Node.js via Java 可讓您限制對單一圖形的特定編輯操作，或在多張投影片上套用相同的限制。依各圖形類型選擇支援的鎖定，並在需要移除限制時將其值設為 `false`。

## **常見問題**

**我可以在同一個簡報中同時結合圖形鎖定與密碼保護嗎？**

可以。圖形鎖定會限制特定的編輯操作，而 [password protection](/slides/zh-hant/nodejs-java/password-protected-presentation/) 能限制開啟或修改簡報。您可以在同一檔案中同時使用兩者。

**我可以只對特定投影片限制編輯，而不影響其他投影片嗎？**

可以。僅對所選投影片上的圖形套用鎖定，即不會改變其他投影片的鎖定設定。

**如何對群組內的單一圖形套用鎖定？**

遍歷群組的 [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) 方法回傳的集合，對每個子圖形套用相應的鎖定。對任何巢狀群組亦重複此操作。上述範例僅處理投影片的圖形集合，未對個別群組成員設定鎖定。