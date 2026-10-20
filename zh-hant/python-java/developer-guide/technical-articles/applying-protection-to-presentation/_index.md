---
title: 使用形狀鎖定限制 Python 簡報的編輯
linktitle: 限制簡報編輯
type: docs
weight: 60
url: /zh-hant/python-java/applying-protection-to-presentation/
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
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 在 PPTX 簡報中鎖定和解除鎖定形狀，以限制選取、移動、調整大小和分組。"
---
## **背景**

Aspose.Slides for Python via Java 的常見用途是於自動化工作流程中建立、更新與儲存 PowerPoint (PPTX) 簡報。當使用者收到這些簡報時，限制對圖形的變更可協助保留預期的版面配置與內容。

本文說明圖形在投影片上的組織方式，以及如何在 PPTX 簡報中套用與移除圖形鎖定。這些鎖定讓您能限制對單一圖形的特定編輯操作。

## **投影片的組成**

投影片由自動圖形、表格、OLE 物件、群組圖形、圖片框、影片框、連接線以及其他用於構建簡報的元素組成。在 Aspose.Slides for Python via Java 中，投影片上的每個元素皆以繼承自[Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 類別的物件表示。

不同的圖形類型提供不同的鎖定選項。[BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) 類別是圖形鎖定的基礎類別。Aspose.Slides for Python via Java 提供以下鎖定類別：

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) 鎖定自動圖形。  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) 鎖定連接線圖形。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) 鎖定圖形物件。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) 鎖定群組圖形。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) 鎖定圖片框。  

若要在整個[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 上套用鎖定，請遍歷其投影片，並對每個支援的圖形設定相應的鎖定。

## **套用與移除保護**

圖形鎖定會限制選取、移動與調整大小等操作。它們不會使整個簡報變成無法編輯。

### **套用 PPTX 圖形保護**

Aspose.Slides for Python via Java 提供[Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 類別，以在投影片上操作圖形。

範例對自動圖形呼叫[setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked)與[setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) 並將參數設為 `True`，對群組圖形、連接線與圖片框使用等效的鎖定。連接線使用[setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) 以限制移動；群組則使用[setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) 以限制分組。

範例載入現有的 PPTX 簡報，檢查每一投影片的圖形集合，並儲存套用此限制的副本。未屬於上述四種型別的圖形保持不變。此迴圈不會遍歷群組內的子圖形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **移除保護**

若要移除圖形鎖定，將其值設為 `False`。以下範例載入帶有圖形鎖定的簡報，並透過[AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/)、[PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) 清除選取、移動與調整大小的限制。亦透過將 `False` 傳遞給[GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) 以移除分組限制，並儲存簡報的副本。其他鎖定設定保持不變。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **結論**

Aspose.Slides for Python via Java 讓您能限制單一圖形的特定編輯操作，或在多張投影片上套用相同的限制。請依圖形類型選擇支援的鎖定，並在需要移除限制時將其值設為 `False`。

## **常見問題**

**我可以在同一簡報中同時結合圖形鎖定與密碼保護嗎？**

可以。圖形鎖定會限制特定的編輯操作，而[密碼保護](/slides/zh-hant/python-java/password-protected-presentation/) 可以限制簡報的開啟或修改。您可以在同一檔案中同時使用兩者。

**我可以僅限制特定投影片的編輯，而不影響其他投影片嗎？**

可以。僅對選取的投影片上的圖形套用鎖定，即不會更改其他投影片的鎖定設定。

**我該如何對群組內的單一圖形套用鎖定？**

遍歷群組的[getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) 方法返回的集合，並對每個子圖形套用相應的鎖定。對任何巢狀群組重複此操作。上述範例僅處理投影片的圖形集合，未對單一群組成員設定鎖定。