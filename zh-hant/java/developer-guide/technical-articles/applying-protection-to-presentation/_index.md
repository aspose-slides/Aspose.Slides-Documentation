---
title: 在 Java 中使用形狀鎖定限制簡報編輯
linktitle: 限制簡報編輯
type: docs
weight: 60
url: /zh-hant/java/applying-protection-to-presentation/
keywords:
- 防止編輯
- 防止被編輯
- 鎖定形狀
- 鎖定位置
- 鎖定選取
- 鎖定大小調整
- 鎖定分組
- PowerPoint
- PPTX
- 簡報
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Java 在 PPTX 簡報中鎖定與解鎖形狀，以限制選取、移動、大小調整和分組。"
---
## **背景**

Aspose.Slides for Java 的常見用法是建立、更新並儲存 PowerPoint (PPTX) 簡報，作為自動化工作流程的一部分。當使用者收到這些簡報時，限制對圖形的變更可以協助保留預期的版面配置與內容。

本文說明圖形在投影片上的組織方式，以及如何在 PPTX 簡報中套用與移除圖形鎖定。這些鎖定可讓您限制個別圖形的特定編輯操作。

## **投影片組成**

簡報投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於建立簡報的元素組成。在 Aspose.Slides for Java 中，投影片上的每個元素都由實作 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 介面的物件或繼承自該類別的物件表示。

不同的圖形類型會提供不同的鎖定選項。[IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) 介面是圖形鎖定的基礎介面。Aspose.Slides for Java 提供以下鎖定介面：

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) 鎖定自動圖形。  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) 鎖定連接線圖形。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) 鎖定圖形物件。  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) 鎖定群組圖形。  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) 鎖定圖片框。  

若要在整個 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 中套用鎖定，請遍歷其投影片，並對每個受支援的圖形設定相應的鎖定。

## **套用與移除保護**

相容的簡報編輯器會使用圖形鎖定來限制個別的編輯操作。檔案加密與文件層級的寫入保護是另一種 [presentation protection settings](/slides/zh-hant/java/password-protected-presentation/)。

### **對 PPTX 圖形套用保護**

Aspose.Slides for Java 提供 [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) 介面，以便在投影片上操作圖形。

範例對自動圖形呼叫 [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)、[setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) 與 [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) 並傳入 `true`，對群組圖形、連接線與圖片框使用等效的鎖定。連接線使用 [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) 以限制移動；群組圖形亦使用 [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) 以限制重新分組。

此範例載入現有的 PPTX 簡報，檢查每張投影片的圖形集合，並以這些限制儲存副本。未屬於上述四種處理類型的圖形將保持不變。迴圈不會遍歷群組內的子圖形。

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

若要移除圖形鎖定，將其值設為 `false`。以下範例載入帶有圖形鎖定的簡報，並透過 [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) 與 [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) 清除選取、移動與調整大小的限制。亦透過將 `false` 傳遞給 [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) 移除分組限制，並儲存簡報的副本。其他鎖定設定則保持不變。

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

### **保留圖片裁剪**

在工作目錄放置名為 `photo.jpg` 的照片。範例從左側裁剪 12%，從右側裁剪 8%，然後對圖片框的鎖定呼叫 [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-)，傳入 `true` 以限制進一步裁剪並保留現有裁剪。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);
    
    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` 會將裁剪鎖定儲存為 `true`。在 PowerPoint 中，選取照片時 **Crop** 指令會被停用。

### **保持圖表分組**

範例將矩形與箭頭群組，然後對群組的鎖定呼叫 [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-)，以保持圖表的各個元件一起。其他編輯（例如移動群組或變更元件的填色）仍然可用。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` 會將解除群組鎖定儲存為 `true`。在 PowerPoint 中，選取整個圖表時 **Ungroup** 指令會被停用。

### **報告現有圖形鎖定**

若要檢視範本，請開啟它並讀取每個圖形的鎖定物件。`[getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--)` 方法在該物件的所有旗標皆停用時回傳 `true`，只要有一個旗標啟用則回傳 `false`。群組與其子圖形各自擁有獨立的鎖定物件，因此即使群組本身無鎖定，也必須檢查其子圖形。

此範例檢查自動圖形、圖片框與群組的移動限制，亦檢查圖片的裁剪與群組的解除群組限制。報告會列出已辨識的啟用旗標，並標示未檢查的圖形類型。

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

假設 `Sample.pptx` 的第 1 張投影片包含一個名為 `Layout`、已鎖定解除群組的群組，其內有一個已鎖定裁剪的圖片 `Photo`，以及一個未鎖定的矩形 `Free`。報告會跳過 `Free`，並輸出以下兩行：

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

報告會讀取已儲存的圖形層級編輯旗標而不會更改它們或儲存簡報。文件層級的寫入保護是另一項設定，且每個旗標的強制執行取決於編輯器。

### **結論**

Aspose.Slides for Java 讓您能對個別圖形限制特定編輯操作，或在整個投影片中套用相同限制。請選擇每種圖形類型支援的鎖定，並在需要移除限制時將其值設為 `false`。

## **FAQ**

**我可以在同一簡報中同時結合圖形鎖定與密碼保護嗎？**

可以。圖形鎖定會限制特定的編輯操作，而 [password protection](/slides/zh-hant/java/password-protected-presentation/) 則可限制開啟或修改簡報。兩者可以同時使用於同一檔案。

**我可以只對特定投影片的圖形加以限制，而不影響其他投影片嗎？**

可以。只對所選投影片的圖形套用鎖定，其他投影片的鎖定設定不會受到影響。

**我要如何對群組內的個別圖形加上鎖定？**

遍歷群組的 [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) 方法回傳的集合，對每個子圖形套用相應的鎖定。對任何巢狀群組重複此步驟，遵循報告範例中的遍歷方式。