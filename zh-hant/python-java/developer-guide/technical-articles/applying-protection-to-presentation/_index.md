---
title: 使用形狀鎖定在 Python 中限制簡報編輯
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
- 鎖定群組
- PowerPoint
- PPTX
- 簡報
- Python
- Java
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via Java 鎖定與解除鎖定 PPTX 簡報中的形狀，以限制選取、移動、調整大小和群組化。"
---
## **背景**

在自動化工作流程中，Aspose.Slides for Python via Java 常見的用途是建立、更新與儲存 PowerPoint (PPTX) 簡報。當使用者收到這些簡報時，限制形狀的變更可協助保留預期的版面配置與內容。

本文章說明形狀在投影片上的組織方式以及如何在 PPTX 簡報中套用與移除形狀鎖定。這些鎖定讓您能限制對個別形狀的特定編輯操作。

## **投影片的組成**

投影片由自動圖形、表格、OLE 物件、群組形狀、圖片框、影片框、連接線以及其他用於建立簡報的元素組成。在 Aspose.Slides for Python via Java 中，投影片上的每個元素皆以繼承自[Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 類別的物件表示。

不同的形狀類型提供不同的鎖定選項。[BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) 類別是形狀鎖的基礎類別。Aspose.Slides for Python via Java 提供以下鎖定類別：

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) 鎖定自動圖形。  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) 鎖定連接線形狀。  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) 鎖定圖形物件。  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) 鎖定群組形狀。  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) 鎖定圖片框。  

若要在整個[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) 上套用鎖定，請遍歷其投影片，並在每個支援的形狀上設定相應的鎖定。

## **套用與移除保護**

相容的簡報編輯器使用形狀鎖定來限制個別的編輯操作。檔案加密與文件層級的寫入保護屬於不同的[簡報保護設定](/slides/zh-hant/python-java/password-protected-presentation/)。

### **套用對 PPTX 形狀的保護**

Aspose.Slides for Python via Java 提供 [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) 類別，以在投影片上操作形狀。

範例對自動圖形呼叫 [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked)、[setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) 以及 [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) 並傳入 `True`，對群組形狀、連接線與圖片框則使用等效的鎖定。連接線使用 [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) 以限制移動；群組亦使用 [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) 來限制群組化。

範例載入現有的 PPTX 簡報，檢查每張投影片的形狀集合，並儲存套用此限制的副本。未屬於上述四種處理類型的形狀將保持不變。此迴圈不會遍歷群組內的子形狀。

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

若要移除形狀鎖定，將其值設為 `False`。以下範例載入含有形狀鎖定的簡報，並透過 [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/)、[GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/)、[ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) 及 [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) 清除選取、移動與調整大小的限制。它亦透過傳入 `False` 給 [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) 移除群組限制，並儲存簡報的副本。其他鎖定設定則保持不變。

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

### **保留圖片裁切**

將名為 `photo.jpg` 的照片放在工作目錄中。範例從左側裁切 12%、右側裁切 8%，然後呼叫 [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) 並傳入 `True` 以保留裁切。

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在 `PictureLocked.pptx` 中，PowerPoint 在選取照片時會停用 **Crop** 功能。

### **保持圖表群組化**

範例將矩形與箭頭群組，然後呼叫 [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) 並傳入 `True` 以保持這兩個形狀在一起。仍然可以移動群組或變更其中元件的填色。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在 `DiagramLocked.pptx` 中，PowerPoint 在選取整個圖表時會停用 **Ungroup** 功能。

### **結論**

Aspose.Slides for Python via Java 讓您能限制個別形狀的特定編輯操作，或在多張投影片上套用相同的限制。選擇每種形狀類型支援的鎖定，並在需要移除限制時將其值設為 `False`。

## **常見問題**

**我可以在同一簡報中同時結合形狀鎖定與密碼保護嗎？**

可以。形狀鎖定會限制特定的編輯操作，而[密碼保護](/slides/zh-hant/python-java/password-protected-presentation/)則可限制開啟或修改簡報。您可以在同一檔案中同時使用兩者。

**我可以只限制特定投影片的編輯而不影響其他投影片嗎？**

可以。只對所選投影片的形狀套用鎖定，這不會更改其他投影片的鎖定設定。

**如何對群組內的個別形狀套用鎖定？**

遍歷群組的 [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) 方法回傳的集合，並對每個子形狀套用相應的鎖定。對任何巢狀群組重複此步驟。上述範例僅處理投影片的形狀集合，因此未對個別群組成員設定鎖定。