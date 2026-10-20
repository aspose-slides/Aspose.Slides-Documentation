---
title: 在 Java 中使用圖形鎖定限制簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 60
url: /zh-hant/java/applying-protection-to-presentation/
keywords:
- 防止編輯
- 防止被編輯
- 鎖定圖形
- 鎖定位置
- 鎖定選取
- 鎖定調整大小
- 鎖定群組
- PowerPoint
- PPTX
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PPTX 簡報中鎖定與解鎖圖形，以限制選取、移動、調整大小和群組化。"
---
## **背景**

在自動化工作流程中，Aspose.Slides for Java 的常見用途是建立、更新和儲存 PowerPoint (PPTX) 簡報。當使用者收到這些簡報時，限制對圖形的變更可以協助保留預期的版面配置和內容。

本文說明圖形在投影片上的組織方式，以及如何在 PPTX 簡報中套用與移除圖形鎖定。這些鎖定可讓您限制對單一圖形的特定編輯操作。

## **投影片的組成**

簡報投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於建立簡報的元素組成。在 Aspose.Slides for Java 中，投影片上的每個元素皆由實作 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 介面或繼承自該介面的類別之物件表示。

不同的圖形類型提供不同的鎖定選項。[IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) 介面是圖形鎖定的基礎介面。Aspose.Slides for Java 提供以下鎖定介面：

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) 鎖定自動圖形。  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) 鎖定連接線圖形。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) 鎖定圖形物件。  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) 鎖定群組圖形。  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) 鎖定圖片框。  

若要對整個 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 套用鎖定，請遍歷其投影片並在每個支援的圖形上設定相應的鎖定。

## **套用與移除保護**

圖形鎖定會限制選取、移動與調整大小等操作。但它不會使整個簡報無法編輯。

### **套用 PPTX 圖形的保護**

Aspose.Slides for Java 提供 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 介面，以在投影片上處理圖形。

範例對自動圖形呼叫 [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)、[setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) 與 [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) 並將其值設為 `true`，對群組圖形、連接線與圖片框使用等效的鎖定。連接線使用 [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) 來限制移動；群組亦使用 [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) 以限制群組化。

範例載入現有的 PPTX 簡報，檢查每張投影片的圖形集合，並儲存一個套用此限制的副本。非上述四種處理類型的圖形保持不變。此迴圈不會遍歷群組內的子圖形。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **移除保護**

若要移除圖形鎖定，請將其值設為 `false`。以下範例載入帶有圖形鎖定的簡報，並透過 [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) 與 [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) 清除選取、移動與調整大小的限制。亦透過將 `false` 傳遞給 [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) 來移除群組限制，並儲存簡報的副本。其他鎖定設定則保持不變。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **結論**

Aspose.Slides for Java 讓您能限制單一圖形的特定編輯操作，或在多張投影片上套用相同的限制。請依圖形類型選擇支援的鎖定，並於需要移除限制時將其值設為 `false`。

## **常見問題**

**我可以在同一簡報中同時結合圖形鎖定與密碼保護嗎？**

可以。圖形鎖定限制特定的編輯操作，而 [密碼保護](/slides/zh-hant/java/password-protected-presentation/) 可限制簡報的開啟或修改。您可以在同一檔案中同時使用兩者。

**我可以在特定投影片上限制編輯而不影響其他投影片嗎？**

可以。僅在選取的投影片上的圖形套用鎖定，這不會更改其他投影片的鎖定設定。

**我該如何對群組內的單一圖形套用鎖定？**

遍歷群組的 [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) 方法回傳的集合，並對每個子圖形套用相應的鎖定。對任何巢狀群組重複此操作。上述範例僅處理投影片的圖形集合，因此未對個別的群組成員設定鎖定。