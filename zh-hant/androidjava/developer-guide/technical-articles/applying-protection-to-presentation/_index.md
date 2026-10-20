---
title: 在 Android 上使用圖形鎖定限制簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 60
url: /zh-hant/androidjava/applying-protection-to-presentation/
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
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 在 PPTX 簡報中鎖定與解鎖圖形，以限制選取、移動、調整大小與分組。"
---
## **概述**

使用 Aspose.Slides for Android via Java 的一個常見用途是於自動化工作流程中建立、更新與儲存 PowerPoint (PPTX) 簡報。當使用者收到這些簡報時，限制圖形的變更可以協助保留預期的版面配置與內容。

本文說明圖形在投影片上的組織方式，以及如何在 PPTX 簡報中套用與移除圖形鎖定。這些鎖定可讓您限制對個別圖形的特定編輯操作。

## **投影片的組成**

簡報投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於建立簡報的元素組成。在 Aspose.Slides for Android via Java 中，投影片上的每個元素皆以實作 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 介面的物件或繼承自該類別的物件表示。

不同類型的圖形提供不同的鎖定選項。[IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) 介面是圖形鎖定的基礎介面。Aspose.Slides for Android via Java 提供下列鎖定介面：

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) 鎖定自動圖形。  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) 鎖定連接線圖形。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) 鎖定圖形物件。  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) 鎖定群組圖形。  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) 鎖定圖片框。  

若要對整個 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 套用鎖定，請遍歷其投影片，並對每個支援的圖形設定相應的鎖定。

## **套用與移除保護**

圖形鎖定會限制選取、移動與調整大小等操作。它們不會使整個簡報無法編輯。

### **對 PPTX 圖形套用保護**

Aspose.Slides for Android via Java 提供 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 介面以操作投影片上的圖形。

範例呼叫 [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)、[setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) 與 [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-)，並將 `true` 設為自動圖形的鎖定，對群組圖形、連接線與圖片框使用等效的鎖定。連接線使用 [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) 來限制移動；群組亦使用 [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) 以限制分組。

此範例載入既有的 PPTX 簡報，檢查每張投影片的圖形集合，並儲存套用這些限制的副本。未屬於上述四種處理類型的圖形將保持不變。迴圈不會遍歷群組內的子圖形。

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

若要移除圖形鎖定，將其值設為 `false`。以下範例載入一個具有圖形鎖定的簡報，並透過 [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) 與 [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) 清除選取、移動與調整大小的限制。它亦透過傳遞 `false` 給 [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) 移除分組限制，並儲存簡報的副本。其他鎖定設定則保持不變。

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

Aspose.Slides for Android via Java 讓您能對個別圖形限制特定的編輯操作，或在多張投影片上套用相同的限制。選擇每種圖形類型支援的鎖定，並在需要移除限制時將其值設為 `false`。

## **常見問題集**

**我可以在同一簡報中同時結合圖形鎖定與密碼保護嗎？**

是的。圖形鎖定限制特定的編輯操作，而 [password protection](/slides/zh-hant/androidjava/password-protected-presentation/) 則可限制簡報的開啟或修改。兩者可同時使用於同一檔案。

**我能否只限制特定投影片的編輯而不影響其他投影片？**

可以。僅對選取的投影片上的圖形套用鎖定，其他投影片的鎖定設定不會受到影響。

**如何對群組內的個別圖形套用鎖定？**

遍歷群組的 [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) 方法回傳的集合，並對每個子圖形套用適當的鎖定。對任何巢狀群組重複此操作。上述範例僅處理投影片的圖形集合，未對個別群組成員設定鎖定。