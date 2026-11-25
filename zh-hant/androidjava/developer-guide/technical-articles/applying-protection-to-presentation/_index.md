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
- 鎖定群組
- PowerPoint
- PPTX
- 簡報
- Android
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Android via Java 在 PPTX 簡報中鎖定與解鎖圖形，以限制選取、移動、調整大小和群組。"
---
## **概觀**

Aspose.Slides for Android via Java 的常見用法是於自動化工作流程中建立、更新與儲存 PowerPoint (PPTX) 簡報。當使用者收到這些簡報時，限制圖形的變更可協助保留原有的版面配置與內容。

本文說明圖形在投影片上的組織方式，以及如何在 PPTX 簡報中套用與移除圖形鎖定。這些鎖定讓您能限制對單一圖形的特定編輯操作。

## **投影片的組成元素**

簡報投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於建立簡報的元素組成。在 Aspose.Slides for Android via Java 中，投影片上的每個元素皆由實作 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 介面的物件或繼承自該類別的物件表示。

不同類型的圖形會提供不同的鎖定選項。[IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) 介面是圖形鎖定的基礎介面。Aspose.Slides for Android via Java 提供以下鎖定介面：

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) 鎖定自動圖形。  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) 鎖定連接線圖形。  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) 鎖定圖形物件。  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) 鎖定群組圖形。  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) 鎖定圖片框。  

若要在 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 中套用鎖定，請遍歷其投影片，並對每個支援的圖形設定相應的鎖定。

## **套用與移除保護**

相容的簡報編輯器會使用圖形鎖定來限制個別的編輯操作。檔案加密與文件層級的寫入保護是另類的 [簡報保護設定](/slides/zh-hant/androidjava/password-protected-presentation/)。

### **套用 PPTX 圖形保護**

Aspose.Slides for Android via Java 提供 [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) 介面以處理投影片上的圖形。

範例對自動圖形呼叫 [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-)、[setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-)、以及 [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-)，並將參數設為 `true`；對群組圖形、連接線與圖片框則使用等效的鎖定。連接線使用 [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) 來限制移動；群組則使用 [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) 以限制重新群組。

此範例載入現有的 PPTX 簡報，檢查每張投影片之圖形集合中的圖形，並將套用限制後的副本儲存。未屬於上述四種類型的圖形保持不變。迴圈不會遍歷群組內的子圖形。

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

若要移除圖形鎖定，請將其值設定為 `false`。下列範例載入含有圖形鎖定的簡報，透過 [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/)、[IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/)、[IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/)、以及 [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) 清除選取、移動與調整大小的限制。亦透過將 `false` 傳遞給 [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) 移除群組限制，並將簡報的副本儲存。其他鎖定設定則保持原樣。

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

### **保留圖片裁切**

將名為 `photo.jpg` 的照片置於工作目錄。範例從左側裁切 12%，右側裁切 8%，然後對圖片框的鎖定呼叫 [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-)。將 `true` 傳入即可限制進一步的裁切並保留目前的裁切設定。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

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

`PictureLocked.pptx` 會把裁切鎖定儲存為 `true`。在 PowerPoint 中，選取照片時 **Crop** 功能會被停用。

### **保持圖表群組狀態**

範例將一個矩形與一支箭頭群組，然後對群組的鎖定呼叫 [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-)，以防止圖表的組件被拆散。其他編輯（例如移動群組或更改組件的填色）仍然可用。

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

`DiagramLocked.pptx` 會把解除群組鎖定儲存為 `true`。在 PowerPoint 中，選取整個圖表時 **Ungroup** 功能會被停用。

### **報告現有圖形鎖定**

若要檢查範本，請開啟它並讀取每個圖形的鎖定物件。[getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) 方法在所有旗標皆關閉時回傳 `true`，只要有任一旗標啟用即回傳 `false`。群組及其子圖形各自擁有獨立的鎖定物件，因此即使群組本身沒有鎖定，也必須檢查其子圖形。

此範例檢查自動圖形、圖片框與群組的移動限制，同時檢查圖片的裁切限制與群組的解除群組限制。報告會列出它能辨識的已啟用旗標，並標記未檢查的圖形類型。

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
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
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
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

假設 `Sample.pptx` 的第 1 張投影片包含一個名為 `Layout`、已鎖定解除群組的群組；群組內有一張名為 `Photo`、已鎖定裁切的圖片，另有一個未鎖定的矩形 `Free`。報告會略過 `Free`，只輸出以下兩行：

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

報告會讀取已儲存的圖形層級編輯旗標而不會變更或存檔。文件層級的寫入保護是另一項設定，且每個旗標的實際執行取決於編輯器。

### **結論**

Aspose.Slides for Android via Java 讓您能在單一圖形上限制特定編輯操作，或在多張投影片間套用相同的限制。請依圖形類型選擇支援的鎖定，並在需要移除限制時將其值設為 `false`。

## **FAQ**

**我可以在同一簡報中同時使用圖形鎖定與密碼保護嗎？**

可以。圖形鎖定限制特定的編輯操作，而 [password protection](/slides/zh-hant/androidjava/password-protected-presentation/) 可限制開啟或修改簡報。兩者可同時使用於同一檔案。

**我能只限制特定投影片的編輯而不影響其他投影片嗎？**

可以。僅對選取的投影片上的圖形套用鎖定，即不會改變其他投影片的鎖定設定。

**我要如何對群組內的單一圖形套用鎖定？**

遍歷群組的 [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) 方法回傳的集合，對每個子圖形套用相應的鎖定。對任何巢狀群組重複此程序，與報告範例的遍歷方式相同。